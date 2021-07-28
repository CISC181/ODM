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
using OracleDataMoverBLL.Common;

namespace OracleDataMover.ora
{
    public partial class frmTemplate : Telerik.WinControls.UI.RadForm
    {
        private Boolean isLoading;
        private Boolean quitValidating = false;
        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), Utility.UserName);
        protected List<DATABASE_INFO> lstDatabase = Context.DATABASE_INFORepository.FindBy(x => true).ToList();
        protected List<OraUtility> lstOraUtility = Context.OraUtilityRepository.FindBy(x => true).OrderBy(x => x.UtilityName).ToList();
        private MainForm MF;

        public MainForm MF1 { get => MF; set => MF = value; }
        public frmTemplate()
        {
            isLoading = true;
            InitializeComponent();
            LoadGridLayout();
            LoadGrid();
            LoadrmccTemplateSchema();
            isLoading = false;
        }
        public frmTemplate(String TemplateName) : this()
        {
            Telerik.WinControls.Data.FilterDescriptor filter = new Telerik.WinControls.Data.FilterDescriptor();
            filter.PropertyName = "Name";
            filter.Operator = Telerik.WinControls.Data.FilterOperator.Contains;
            filter.Value = TemplateName;
            filter.IsFilterEditor = true;
            this.rgvTemplate.FilterDescriptors.Add(filter);
        }
        #region CommonMethods
        private List<GridViewRowInfo> GetAllRows(GridViewTemplate template)
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
            if (Context.HasChanges())
            {
                var confirmResult = MessageBox.Show("You have pending changes.  Do you want to save changes?", "Confirm",
                         MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    Context.Commit();
                }
                else
                {
                    Context.Rollback();
                }
            }
            MF.LoadGridData();
            this.Hide();
        }
        public void rgv_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            e.Row.Tag = "ThisRowIsDirty";

            if (quitValidating == true)
            {
                quitValidating = false;
                return;
            }

            if (e.Row is GridViewNewRowInfo)
            {
                GridViewNewRowInfo row = (GridViewNewRowInfo)e.Row;

                if (e.Column.Name == "colTemplateName")
                {
                    if (row.Cells["colDmpFileName"].Value == null)
                    {
                        string strDMPName = e.Value.ToString().ToUpper().Replace("_EXP", "").Replace("_IMP", "") + ".DMP";
                        row.Cells["colDmpFileName"].Value = strDMPName;
                    }
                    if (row.Cells["colParFileName"].Value == null)
                    {
                        row.Cells["colParFileName"].Value = e.Value.ToString().ToUpper() + ".PAR";
                    }
                    if (row.Cells["colBatFileName"].Value == null)
                    {
                        row.Cells["colBatFileName"].Value = e.Value.ToString().ToUpper() + ".BAT";
                    }
                    if (row.Cells["colUtilJobName"].Value == null)
                    {
                        row.Cells["colUtilJobName"].Value = e.Value.ToString().ToUpper();
                    }
                }
            }



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

            GridViewCommandColumn commandExport = new GridViewCommandColumn();
            commandExport.Name = "colExport";
            commandExport.UseDefaultText = true;
            commandExport.DefaultText = "Export";
            commandExport.FieldName = "ID";
            rgvTemplate.MasterTemplate.Columns.Add(commandExport);

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

            GridViewComboBoxColumn colOraUtility = new GridViewComboBoxColumn();
            colOraUtility.Name = "colUtilityID";
            colOraUtility.HeaderText = "Utility";
            colOraUtility.DataSource = lstOraUtility;
            colOraUtility.ValueMember = "ID";
            colOraUtility.DisplayMember = "UtilityName";
            colOraUtility.FieldName = "ORA_UTILITY_ID";
            colOraUtility.Width = 75;
            this.rgvTemplate.Columns.Add(colOraUtility);

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

            GridViewTextBoxColumn gtbDMPFile = new GridViewTextBoxColumn();
            gtbDMPFile.Name = "colDmpFileName";
            gtbDMPFile.EnableExpressionEditor = false;
            gtbDMPFile.FieldName = "DMPFileName";
            gtbDMPFile.HeaderText = "DMP File Name";
            gtbDMPFile.Width = 150;
            this.rgvTemplate.Columns.Add(gtbDMPFile);

            GridViewTextBoxColumn gtbParFile = new GridViewTextBoxColumn();
            gtbParFile.EnableExpressionEditor = false;
            gtbParFile.FieldName = "PARFileName";
            gtbParFile.HeaderText = "PAR File Name";
            gtbParFile.Name = "colParFileName";
            gtbParFile.Width = 150;
            this.rgvTemplate.Columns.Add(gtbParFile);

            GridViewTextBoxColumn gtbBatFileName = new GridViewTextBoxColumn();
            gtbBatFileName.EnableExpressionEditor = false;
            gtbBatFileName.Name = "colBatFileName";
            gtbBatFileName.FieldName = "BATFileName";
            gtbBatFileName.HeaderText = "BAT File Name";
            gtbBatFileName.Name = "colBatFileName";
            gtbBatFileName.Width = 150;
            this.rgvTemplate.Columns.Add(gtbBatFileName);

            GridViewTextBoxColumn gtbJobName = new GridViewTextBoxColumn();
            gtbJobName.EnableExpressionEditor = false;
            gtbJobName.Name = "colUtilJobName";
            gtbJobName.FieldName = "UtilJobname";
            gtbJobName.HeaderText = "Ora Job Name";
            gtbJobName.Name = "colUtilJobName";
            gtbJobName.Width = 150;
            this.rgvTemplate.Columns.Add(gtbJobName);
        }

        private void rgvTemplate_cmdGeneratePAR_CommandCellClick(object sender, EventArgs e)
        {
            GridViewCellEventArgs args = (GridViewCellEventArgs)e;
            string strTemplateID = args.Value.ToString();

            Template T = Context.TemplateRepository.FindBy(x => x.Id == strTemplateID).FirstOrDefault();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.RestoreDirectory = true;

            saveFileDialog1.Filter = "par files (*.par)|*.par|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save par file";
            saveFileDialog1.FileName = T.Name;
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                GenerateFiles.GeneratePARFile(saveFileDialog1.FileName, strTemplateID);
            }

            Process.Start("notepad.exe", saveFileDialog1.FileName);
        }

        private void rgvTemplate_cmdExport_CommandCellClick(object sender, EventArgs e)
        {
            var TemplateID = ((sender as GridCommandCellElement)).Value.ToString();

            Utility.ExportTemplate(TemplateID);

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
                case "colExport":
                    rgvTemplate_cmdExport_CommandCellClick(sender, e);
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

                List<TemplateSchemaRemap> lstTemplateSchemaRemap = Context.TemplateSchemaRemapRepository
    .FindBy(x => x.TemplateId == TemplateID).ToList();
                foreach (TemplateSchemaRemap tss in lstTemplateSchemaRemap)
                {
                    Context.TemplateSchemaRemapRepository.Delete(tss);
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
            Cursor.Current = Cursors.WaitCursor;

            String strUtility = String.Empty;
            if (rbtExport.Checked)
            {
                strUtility = "EXPDP";
            }
            else if (rbtImport.Checked)
            {
                strUtility = "IMPDP";
            }
            if ((this.rmccDatabase.EditorControl.CurrentRow != null) && (this.rmccDatabase.EditorControl.CurrentRow.Cells["colDatabaseID"] != null))
            {
                var vDatabaseID = this.rmccDatabase.EditorControl.CurrentRow.Cells["colDatabaseID"].Value.ToString();
                List<Template> lstTemplate = Context.TemplateRepository.FindBy(x => x.DATABASE_ID == vDatabaseID).Where(y => y.ORA_UTILITY.UtilityName == strUtility).ToList();
                rgvTemplate.DataSource = lstTemplate;
            }
            else
            {
                List<Template> lstTemplate = Context.TemplateRepository.FindBy(x => true).Where(y => y.ORA_UTILITY.UtilityName == strUtility).ToList();
                rgvTemplate.DataSource = lstTemplate;
            }

            Cursor.Current = Cursors.Default;

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
                    tmpl.PARFileName = dataRow.Cells["colParFileName"].Value.ToString();
                    tmpl.BATFileName = dataRow.Cells["colBatFileName"].Value.ToString();
                    tmpl.ORA_UTILITY_ID = dataRow.Cells["colUtilityID"].Value.ToString();
                    tmpl.DMPFileName = dataRow.Cells["colDmpFileName"].Value.ToString();
                    tmpl.UtilJobname = dataRow.Cells["colUtilJobName"].Value.ToString();
                    Context.TemplateRepository.Save(tmpl);
                }
                if ((dataRow.Tag != null) && (dataRow.Tag.ToString() == "ThisRowIsDirty"))
                {
                    string templID = dataRow.Cells["colTemplateID"].Value.ToString();
                    Template tmpl = Context.TemplateRepository
                        .FindBy(x => x.Id == templID).FirstOrDefault();
                    tmpl.Name = dataRow.Cells["colTemplateName"].Value.ToString();
                    tmpl.DATABASE_ID = dataRow.Cells["colDatabaseID"].Value.ToString();
                    tmpl.PARFileName = dataRow.Cells["colParFileName"].Value.ToString();
                    tmpl.BATFileName = dataRow.Cells["colBatFileName"].Value.ToString();
                    tmpl.ORA_UTILITY_ID = dataRow.Cells["colUtilityID"].Value.ToString();
                    tmpl.DMPFileName = dataRow.Cells["colDmpFileName"].Value.ToString();
                    tmpl.UtilJobname = dataRow.Cells["colUtilJobName"].Value.ToString();
                    Context.TemplateRepository.Save(tmpl);
                }
            }

            Context.Commit();

            MessageBox.Show("Data is saved");
            LoadGrid();
            this.MF1.LoadGridData();
        }

        private void rgvTemplate_CellValidating(object sender, CellValidatingEventArgs e)
        {

            GridViewDataColumn column = e.Column as GridViewDataColumn;
            if (e.Row is GridViewDataRowInfo || e.Row is GridViewNewRowInfo && column != null)
            {
                switch (column.Name.ToString())
                {
                    case "colDmpFileName":
                        if (string.IsNullOrEmpty((string)e.Value) || ((string)e.Value).Trim() == string.Empty)
                        {
                            e.Cancel = true;
                            MessageBox.Show("DMP File Name Required");
                        }
                        if (CheckExension(e.Value.ToString(), ".DMP") == false)
                        {
                            MessageBox.Show("DMP File Must have .DMP extension");
                            e.Cancel = true;
                            return;
                        }
                        break;

                    case "colTemplateName":
                        if (string.IsNullOrEmpty((string)e.Value) || ((string)e.Value).Trim() == string.Empty)
                        {
                            e.Cancel = true;
                            MessageBox.Show("Template Name Required");
                        }
                        break;
                    case "colParFileName":
                        if (string.IsNullOrEmpty((string)e.Value) || ((string)e.Value).Trim() == string.Empty)
                        {
                            e.Cancel = true;
                            MessageBox.Show("PAR File Required");
                            break;
                        }
                        if (CheckExension(e.Value.ToString(), ".PAR") == false)
                        {
                            MessageBox.Show("BAT File Must have .PAR extension");
                            e.Cancel = true;
                            return;
                        }
                        break;
                    case "colBatFileName":
                        if (string.IsNullOrEmpty((string)e.Value) || ((string)e.Value).Trim() == string.Empty)
                        {
                            e.Cancel = true;
                            MessageBox.Show("BAT File Required");
                            break;
                        }
                        if (CheckExension(e.Value.ToString(), ".BAT") == false)
                        {
                            MessageBox.Show("BAT File Must have .BAT extension");
                            e.Cancel = true;
                            return;
                        }
                        break;
                }
            }
        }

        private void rgvTemplate_RowValidating(object sender, RowValidatingEventArgs e)
        {

            if (quitValidating == true)
            {
                quitValidating = false;
                return;
            }


            //if (e.Row is GridViewNewRowInfo)
            //{
            //    GridViewNewRowInfo row = e.Row as GridViewNewRowInfo;



            //    if (row.Cells["colTemplateName"].Value == null)
            //    {
            //        MessageBox.Show("Template Name Required");
            //        e.Cancel = true;
            //        return;
            //    }
            //    if (row.Cells["colDatabaseID"].Value == null)
            //    {
            //        MessageBox.Show("Database is required");
            //        e.Cancel = true;
            //        return;
            //    }

            //    if (row.Cells["colParFileName"].Value == null)
            //    {
            //        MessageBox.Show("PAR File Required");
            //        e.Cancel = true;
            //        return;
            //    }
            //    if (row.Cells["colBatFileName"].Value == null)
            //    {
            //        MessageBox.Show("BAT File Required");
            //        e.Cancel = true;
            //        return;
            //    }

            //    if (CheckExension(row.Cells["colBatFileName"].Value.ToString(),".BAT") == false )
            //    {
            //        MessageBox.Show("BAT File Must have .BAT extension");
            //        e.Cancel = true;
            //        return;
            //    }

            //    if (row.Cells["colUtilityID"].Value == null)
            //    {
            //        MessageBox.Show("Utility Type Required");
            //        e.Cancel = true;
            //        return;
            //    }
            //    if (row.Cells["colDmpFileName"].Value == null)
            //    {
            //        MessageBox.Show("DMP File Required Required");
            //        e.Cancel = true;
            //        return;
            //    }
            //    if (row.Cells["colUtilJobName"].Value == null)
            //    {
            //        MessageBox.Show("Job Name Required");
            //        e.Cancel = true;
            //        return;
            //    }
            //}
        }

        private void rgvTemplate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                quitValidating = true;
            }
        }

        private Boolean CheckExension(string filename, string ext)
        {
            //"d.bat".IndexOf("bat");
            //  "d.bat".ToUpper().IndexOf("bat".ToUpper());
            int iCheck = filename.ToUpper().IndexOf(ext.ToUpper());
            if (iCheck >= 0)
                return true;
            else
                return false;
        }

        private void LoadrmccTemplateSchema()
        {
            List<DATABASE_INFO> lstDatabase = Context.DATABASE_INFORepository.FindBy(x => true).OrderBy(x => x.Name).ToList();
            this.rmccDatabase.DataSource = lstDatabase;
            this.rmccDatabase.SelectedIndex = 0;
        }

        private void rmccDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rmccDatabase.SelectedIndex > -1)
            {
                if (this.rmccDatabase.EditorControl.CurrentRow.Cells["colDatabaseID"] != null)
                {
                    LoadGrid();
                }
            }


        }

        private void rbtImport_CheckedChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void rbtExport_CheckedChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}
