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
using OracleDataMover.Common;

namespace OracleDataMover.ora
{
    public partial class frmTemplate : Telerik.WinControls.UI.RadForm
    {
        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), "Gibbonsbr");
        protected List<DATABASE_INFO> lstDatabase = Context.DATABASE_INFORepository.FindBy(x => true).ToList();
        protected List<OraUtility> lstOraUtility = Context.OraUtilityRepository.FindBy(x => true).OrderBy(x => x.UtilityName).ToList();
        private MainForm MF;

        public MainForm MF1 { get => MF; set => MF = value; }
        public frmTemplate()
        {
            InitializeComponent();
            LoadGridLayout();
            LoadGrid();
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
            MF.LoadGridData();
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
                    tmpl.PARFileName = dataRow.Cells["colParFileName"].Value.ToString();
                    tmpl.BATFileName = dataRow.Cells["colBatFileName"].Value.ToString();
                    tmpl.ORA_UTILITY_ID = dataRow.Cells["colUtilityID"].Value.ToString();
                    tmpl.DMPFileName = dataRow.Cells["colDmpFileName"].Value.ToString(); 
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
                    Context.TemplateRepository.Save(tmpl);
                }
            }
            Context.Commit();
            MessageBox.Show("Data is saved");
            LoadGrid();
        }
    }
}
