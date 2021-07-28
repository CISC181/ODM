using OracleDataMoverEF.EF;
using OracleDataMoverEF.UnitOfWork;
using OracleDataMoverOraEF.EF;
using OracleDataMoverOraEF.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.ComponentModel;
using OracleDataMoverBLL.Common;
using System.Diagnostics;


namespace ODM
{
    public class Program
    {
        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), Utility.UserName);

        public static void Main(string[] args)
        {
            String  strTemplateName = args[0].ToString();            
            Template T = GetTemplate(strTemplateName);

            if (T != null)
                CreateFiles(T);
        }

        private static void CreateFiles(Template T)
        {
            ODMSetting ODMSetting = Context.ODMSettingRepository.FindBy(x => x.SettingName == "WORKING_DIR").FirstOrDefault();
            GenerateFiles.GeneratePARFile(ODMSetting.SettingValue + '\\' + T.PARFileName.ToString(), T.Id.ToString());
            GenerateFiles.GenerateBATFile(ODMSetting.SettingValue + '\\' + T.BATFileName.ToString(), T.Id.ToString());
            Utility.ExecuteAsAdmin(ODMSetting.SettingValue + '\\' + T.BATFileName.ToString());
        }
        private static Template GetTemplate(String strTemplateName)
        {
            Template tmpl = Context.TemplateRepository.FindBy(x => x.Name == strTemplateName).FirstOrDefault();
            return tmpl;
        }
    }
}
