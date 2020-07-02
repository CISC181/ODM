using OracleDataMoverEF.EF;
using OracleDataMoverEF.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDataMoverBLL.Common
{
    public class GenerateFiles
    {
        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), Utility.UserName);






        public static void GeneratePARFile(string strFileName, string strTemplateID)
        {
            Template t = Context.TemplateRepository.FindBy(x => x.Id == strTemplateID).FirstOrDefault();

            using (System.IO.StreamWriter file =
                 new System.IO.StreamWriter(strFileName))
            {
                file.WriteLine("#     OracleDataMover " + t.ORA_UTILITY.UtilityName  + " written " + DateTime.Now.ToString("dddd, dd MMMM yyyy"));
                file.WriteLine("");
                file.WriteLine("#     " + t.ORA_UTILITY.UtilityName + " Parameters");
                foreach (string str in GetTemplateParmInfo(strTemplateID))
                {
                    file.WriteLine(str.ToString());
                }
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("#     Schemas to Extract");
                foreach (string str in GetTemplateSchemas(strTemplateID))
                {
                    file.WriteLine(str.ToString());
                }
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("#     Remap Parameters");
                foreach (string str in GetRemapSanitize(strTemplateID))
                {
                    file.WriteLine(str.ToString());
                }
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("#     Sample Size Parameters");
                foreach (string str in GetTableSampleSize(strTemplateID))
                {
                    file.WriteLine(str.ToString());
                }
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("#     Remap Schemas");
                foreach (string str in GetRemap(strTemplateID))
                {
                    file.WriteLine(str.ToString());
                }
            }
        }

        public static void GenerateBATFile(string strFileName, string strTemplateID)
        {
            using (System.IO.StreamWriter file =
                 new System.IO.StreamWriter(strFileName))
            {
                foreach (string str in GetBATInfo(strTemplateID))
                {
                    file.WriteLine(str.ToString());
                }
            }
        }

        private static List<String> GetBATInfo(string strTemplateID)
        {
            List<String> lstString = new List<String>();
            Template t = Context.TemplateRepository.FindBy(x => x.Id == strTemplateID).FirstOrDefault();
            List<ODMSetting> ODMSetting = Context.ODMSettingRepository.FindBy(x => true).ToList();

            lstString.Add("echo off");

            lstString.Add("SET /P UID=  UserID  ");
            lstString.Add("SET /P PW=  Password  ");
            lstString.Add("SET SID=" + t.DATABASE_INFO.TnsName.ToString());

            String str = t.ORA_UTILITY.UtilityName
                + " '"
                + "%UID%/"
                + "%PW%"
                + "@%SID%' dumpfile=" + t.DMPFileName
                + " Job_name=" + t.UtilJobname 
                + " parfile=" + ODMSetting.Where(x => x.SettingName == "WORKING_DIR").FirstOrDefault().SettingValue + "\\" + t.PARFileName;

            lstString.Add(str);
            lstString.Add("pause");

            return lstString;
        }

        private static List<String> GetTemplateParmInfo(string strTemplateID)
        {
            List<String> lstString = new List<String>();

            List<TemplateParm> lstTemplateParm = Context.TemplateParmRepository.FindBy(x => x.TemplateId == strTemplateID).ToList();
            foreach (TemplateParm TP in lstTemplateParm)
            {
                String str = TP.PARM.ParmName.ToString().Trim() + "=" + TP.ParmValue.ToString().Trim();
                lstString.Add(str);
            }
            return lstString;
        }

        private static List<String> GetTemplateSchemas(string strTemplateID)
        {
            List<String> lstString = new List<String>();
            List<TemplateSchema> lstTemplateSchema = Context.TemplateSchemaRepository.FindBy(x => x.TemplateId == strTemplateID).OrderBy(x => x.SchemaName).ToList();

            string strLine = "include=schema:\"in (";
            lstString.Add(strLine);

            for (int i = 0; i < lstTemplateSchema.Count; i++)
            {
                if (i == lstTemplateSchema.Count - 1)
                {
                    lstString.Add("'" + lstTemplateSchema[i].SchemaName + "' ");
                }
                else
                {
                    lstString.Add("'" + lstTemplateSchema[i].SchemaName + "', ");
                }
            }
            strLine = ")\"";
            lstString.Add(strLine);

            if (lstString.Count == 2)
            {
                lstString.Clear();
                lstString.Add("");
            }

            return lstString;
        }

        private static List<String> GetRemapSanitize(string strTemplateID)
        {
            List<String> lstString = new List<String>();
            List<TemplateSchema> lstTemplateSchema = Context.TemplateSchemaRepository.FindBy(x => x.TemplateId == strTemplateID).OrderBy(x => x.SchemaName).ToList();

            lstString.Add("REMAP_DATA=");
            foreach (TemplateSchema TS in lstTemplateSchema)
            {
                List<TemplateSchemaSanitize> lstTemplateSchemaSanitize = Context.TemplateSchemaSanitizeRepository
                    .FindBy(x => x.TemplateSchemaId == TS.Id).OrderBy(x => x.TableName).OrderBy(x => x.ColumnName).ToList();


                for (int i = 0; i < lstTemplateSchemaSanitize.Count; i++)
                {
                    string strline = TS.SchemaName.Trim()
                        + '.' + lstTemplateSchemaSanitize[i].TableName.Trim()
                        + '.' + lstTemplateSchemaSanitize[i].ColumnName.Trim()
                        + ":"
                        + lstTemplateSchemaSanitize[i].REMAP_FUNCTION.SchemaName
                        + '.' + lstTemplateSchemaSanitize[i].REMAP_FUNCTION.PackageName
                        + '.' + lstTemplateSchemaSanitize[i].REMAP_FUNCTION.FunctionName;

                    if (i == lstTemplateSchemaSanitize.Count - 1)
                    {
                    }
                    else
                    {
                        strline = strline + ',';
                    }
                    lstString.Add(strline);
                }
            }
            if (lstString.Count == 1)   // There's no remapping, just first entry, return null
            {
                lstString.Clear();
                lstString.Add("");
            }


            return lstString;
        }

        private static List<String> GetTableSampleSize(string strTemplateID)
        {
            List<String> lstString = new List<String>();
            List<TemplateSchema> lstTemplateSchema = Context.TemplateSchemaRepository.FindBy(x => x.TemplateId == strTemplateID).OrderBy(x => x.SchemaName).ToList();

            lstString.Add("SAMPLE=");
            foreach (TemplateSchema TS in lstTemplateSchema)
            {
                foreach (TemplateSchemaTable TSS in Context.TemplateSchemaTableRepository.FindBy(x => x.TemplateSchemaId == TS.Id).OrderBy(x => x.TableName).ToList())
                {
                    lstString.Add(TSS.TEMPLATE_SCHEMA.SchemaName + '.' + TSS.TableName + ':' + TSS.SampleSize);
                }
            }

            if (lstString.Count == 1)       //  In case there are no table sample size
            {
                lstString.Clear();
                lstString.Add("");
            }

            return lstString;
        }



        private static List<String> GetRemap(string strTemplateID)
        {
            List<String> lstString = new List<String>();
            List<TemplateSchemaRemap> lstTemplateRemap = Context.TemplateSchemaRemapRepository.FindBy(x => x.TemplateId == strTemplateID).OrderBy(x => x.OldSchema).ToList();

            lstString.Add("remap_schema=");
            foreach (TemplateSchemaRemap TS in lstTemplateRemap)
            {
                lstString.Add(TS.OldSchema + ":" + TS.NewSchema);
                lstString.Add(",");
            }

            if (lstString.Count == 1)       //  In case there are no table sample size
            {
                lstString.Clear();
                lstString.Add("");
            }
            lstString.RemoveAt(lstString.Count() - 1);

            return lstString;
        }
    }
}
