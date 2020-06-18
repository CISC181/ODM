using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using OracleDataMoverEF.Repositories;
using OracleDataMoverEF.EF;
using OracleDataMoverEF.UnitOfWork;
using System.Linq;
using Telerik.WinControls.UI;
using System.Diagnostics;


namespace OracleDataMover.ora
{
    public partial class frmTemplate : Telerik.WinControls.UI.RadForm
    {
        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), "Gibbonsbr");
        protected List<DATABASE_INFO> lstDatabase = Context.DATABASE_INFORepository.FindBy(x => true).ToList();

        public frmTemplate()
        {
            InitializeComponent();
            LoadGridLayout();
            LoadGrid();
        }
        #region CommonMethods
        private  List<GridViewRowInfo> GetAllRows(GridViewTemplate template)
        {
            List<GridViewRowInfo> allRows = new List<GridViewRowInfo>();
            allRows.AddRange(template.Rows);
            foreach (GridViewTemplate childTemplate in template.Templates)
            {
                List<GridViewRowInfo> childRows = this.GetAllRows(childTemplate);
                allRows.AddRange(childRows);
            }
            return allRows;
        }
        public void rbClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void rgv_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            e.Row.Tag = "ThisRowIsDirty";
        }
        protected void rbUndo_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to undo all changes?", "Confirm",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Context.Rollback();
                LoadGrid();
            }
        }
        #endregion

        private void LoadGridLayout()
        {
            GridViewCommandColumn commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "colDelete";
            commandColumn.UseDefaultText = true;
            commandColumn.DefaultText = "Delete";
            commandColumn.FieldName = "ID";
            rgvTemplate.MasterTemplate.Columns.Add(commandColumn);
            rgvTemplate.CommandCellClick += new
            CommandCellClickEventHandler(rgvTemplate_CommandCellClick);

            GridViewCommandColumn cmdGeneratePAR = new GridViewCommandColumn();
            cmdGeneratePAR.Name = "colGenerate";
            cmdGeneratePAR.UseDefaultText = true;
            cmdGeneratePAR.DefaultText = "Generate PAR";
            cmdGeneratePAR.FieldName = "ID";
            cmdGeneratePAR.Width = 100;
            rgvTemplate.MasterTemplate.Columns.Add(cmdGeneratePAR);



            GridViewTextBoxColumn gtbTemplateID = new GridViewTextBoxColumn();
            gtbTemplateID.EnableExpressionEditor = false;
            gtbTemplateID.FieldName = "ID";
            gtbTemplateID.HeaderText = "Template ID";
            gtbTemplateID.Name = "colTemplateID";
            gtbTemplateID.IsVisible = false;
            this.rgvTemplate.Columns.Add(gtbTemplateID);

            GridViewTextBoxColumn gtbTemplateName = new GridViewTextBoxColumn();
            gtbTemplateName.EnableExpressionEditor = false;
            gtbTemplateName.FieldName = "Name";
            gtbTemplateName.HeaderText = "Template Name";
            gtbTemplateName.Name = "colTemplateName";
            gtbTemplateName.Width = 150;
            this.rgvTemplate.Columns.Add(gtbTemplateName);

            GridViewComboBoxColumn colDatabase = new GridViewComboBoxColumn();
            colDatabase.Name = "colDatabaseID";
            colDatabase.HeaderText = "Database";
            colDatabase.DataSource = lstDatabase;
            colDatabase.ValueMember = "ID";
            colDatabase.DisplayMember = "Name";
            colDatabase.FieldName = "Database_ID";
            colDatabase.Width = 200;
            this.rgvTemplate.Columns.Add(colDatabase);
        }

        private void rgvTemplate_cmdGeneratePAR_CommandCellClick(object sender, EventArgs e)
        {
            GridViewCellEventArgs args = (GridViewCellEventArgs)e;
            string strTemplateID = args.Value.ToString();

            Template T = Context.TemplateRepository.FindBy(x => x.Id == strTemplateID).FirstOrDefault();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "par files (*.par)|*.par|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save par file";
            saveFileDialog1.FileName = T.Name;
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(saveFileDialog1.FileName))
                {
                    file.WriteLine("#     OracleDataMover EXPDP written " + DateTime.Now.ToString("dddd, dd MMMM yyyy"));
                    file.WriteLine("");
                    file.WriteLine("#     Extract Parameters");
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
                }

                Process.Start("notepad.exe", saveFileDialog1.FileName);
            }


        }

        private List<String> GetTemplateParmInfo(string strTemplateID)
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

        private List<String> GetTemplateSchemas(string strTemplateID)
        {
            List<String> lstString = new List<String>();
            List<TemplateSchema> lstTemplateSchema = Context.TemplateSchemaRepository.FindBy(x => x.TemplateId == strTemplateID).OrderBy(x=>x.SchemaName).ToList();

            string strLine = "include=schema:\"in (";
            lstString.Add(strLine);

            for (int i=0; i < lstTemplateSchema.Count; i++)
            {
                if (i == lstTemplateSchema.Count-1)
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
            return lstString;
        }

        private List<String> GetRemapSanitize(string strTemplateID)
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

                    if (i == lstTemplateSchemaSanitize.Count-1)
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
                return null;

            return lstString;
        }

        private List<String> GetTableSampleSize(string strTemplateID)
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
                return null;

            return lstString;
        }

            private void rgvTemplate_CommandCellClick(object sender, EventArgs e)
        {
            GridViewCellEventArgs args = (GridViewCellEventArgs)e;

            switch (args.Column.Name)
            {
                case "colDelete":
                    rgvTemplate_Delete_CommandCellClick(sender, e);
                    break;
                case "colGenerate":
                    rgvTemplate_cmdGeneratePAR_CommandCellClick(sender, e);
                    break;
            }
        }

        private void rgvTemplate_Delete_CommandCellClick(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Are you sure you want to delete this template?", "Confirm",
                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return;
            }

            GridCommandCellElement gce = (GridCommandCellElement)sender;
            if (gce.Value != null)
            {
                var TemplateID = ((sender as GridCommandCellElement)).Value.ToString();

                List<TemplateSchema> lstTemplateSchema = Context.TemplateSchemaRepository.FindBy(x => x.TemplateId == TemplateID).ToList();
                foreach (TemplateSchema ts in lstTemplateSchema)
                {
                    List<TemplateSchemaSanitize> lstTemplateSchemaSanitize = Context.TemplateSchemaSanitizeRepository
                        .FindBy(x => x.TemplateSchemaId == ts.Id).ToList();

                    foreach (TemplateSchemaSanitize tss in lstTemplateSchemaSanitize)
                    {
                        Context.TemplateSchemaSanitizeRepository.Delete(tss);
                    }

                    List<TemplateSchemaTable> lstTemplateSchemaTable = Context.TemplateSchemaTableRepository
                        .FindBy(x => x.TemplateSchemaId == ts.Id).ToList();
                    foreach (TemplateSchemaTable tss in lstTemplateSchemaTable)
                    {
                        Context.TemplateSchemaTableRepository.Delete(tss);
                    }
                    Context.TemplateSchemaRepository.Delete(ts);
                }

                List<TemplateParm> lstTemplateParm = Context.TemplateParmRepository.FindBy(x => x.TemplateId == TemplateID).ToList();
                foreach (TemplateParm tp in lstTemplateParm)
                {
                    Context.TemplateParmRepository.Delete(tp);
                }

                Template t = Context.TemplateRepository
                    .FindBy(x => x.Id == TemplateID).FirstOrDefault();
                Context.TemplateRepository.Delete(t);
            }
            this.rgvTemplate.Rows.Remove(((GridViewDataRowInfo)this.rgvTemplate.CurrentRow));
        }
        private void LoadGrid()
        {

            List<Template> lstTemplate = Context.TemplateRepository.FindBy(x => true).ToList();
            rgvTemplate.DataSource = lstTemplate;

        }
        private void rbSave_Click(object sender, EventArgs e)
        {
            foreach (GridViewDataRowInfo dataRow in this.GetAllRows(this.rgvTemplate.MasterTemplate))
            {
                var cell = dataRow.Cells["colTemplateID"].Value;
                if (cell == null)
                {
                    Template tmpl = new Template();
                    tmpl.Name = dataRow.Cells["colTemplateName"].Value.ToString();
                    tmpl.DATABASE_ID = dataRow.Cells["colDatabaseID"].Value.ToString();
                    Context.TemplateRepository.Save(tmpl);
                }
                if ((dataRow.Tag != null) && (dataRow.Tag.ToString() == "ThisRowIsDirty"))
                {
                    string templID = dataRow.Cells["colTemplateID"].Value.ToString();
                    Template di = Context.TemplateRepository
                        .FindBy(x => x.Id == templID).FirstOrDefault();
                    di.Name = dataRow.Cells["colTemplateName"].Value.ToString();
                    di.DATABASE_ID = dataRow.Cells["colDatabaseID"].Value.ToString();
                    Context.TemplateRepository.Save(di);
                }
            }
            Context.Commit();
            MessageBox.Show("Data is saved");
            LoadGrid();
        }
    }
}
