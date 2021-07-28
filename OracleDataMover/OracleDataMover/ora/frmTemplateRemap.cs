using OracleDataMoverEF.EF;
using OracleDataMoverEF.UnitOfWork;
using OracleDataMoverOraEF.EF;
using OracleDataMoverOraEF.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.Enumerations;
using System.Text.RegularExpressions;
using System.Drawing;
using OracleDataMoverBLL.Common;

namespace OracleDataMover.ora
{

    public partial class frmTemplateRemap : Telerik.WinControls.UI.RadForm
    {
        private Boolean isLoading;
        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), Utility.UserName);
        protected static OraDataContext ContextOra = null;
        private MainForm MF;

        public MainForm MF1 { get => MF; set => MF = value; }

        public frmTemplateRemap()
        {
            InitializeComponent();
            LoadForm();
        }

        private void LoadForm()
        {
            isLoading = true;
            LoadrmccTemplateSchema();
            isLoading = false;
        }

        private void LoadrmccTemplateSchema()
        {
            List<Template> lstTemplate = Context.TemplateRepository.FindBy(x => true).Where(x => x.ORA_UTILITY.UtilityName == "IMPDP").ToList();
            this.rmccTemplateSchema.DataSource = lstTemplate;
        }

        private void rbClose_Click(object sender, EventArgs e)
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

        private void rmccTemplateSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!isLoading && this.rmccTemplateSchema.SelectedIndex > -1))
            {
                if (this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colDatabaseName"] != null)
                {

                    String strDatabaseName = this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colDatabaseName"].Value.ToString();
                    String strTemplateID = this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colTemplateID"].Value.ToString();
                    ContextOra = new OraDataContext(new OraEntities(strDatabaseName), Utility.UserName);
                    LoadrgvRemap(strTemplateID);
                }
            }
        }

        private void LoadrgvRemap(String strTemplateID)
        {
            LoadGridLayout_rgvRemap_Layout();
            LoadGridLayout_rgvRemap_Data();
        }

        private void LoadGridLayout_rgvRemap_Layout()
        {
            rgvRemap.Columns.Clear();
            if (isLoading)
                return;

            GridViewCommandColumn commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "colDelete";
            commandColumn.UseDefaultText = true;
            commandColumn.DefaultText = "Delete";
            commandColumn.FieldName = "ID";
            rgvRemap.MasterTemplate.Columns.Add(commandColumn);
            rgvRemap.CommandCellClick += new
            CommandCellClickEventHandler(rgvRemap_CommandCellClick);

            GridViewTextBoxColumn gtbTemplateSchemaRemapID = new GridViewTextBoxColumn();
            gtbTemplateSchemaRemapID.EnableExpressionEditor = false;
            gtbTemplateSchemaRemapID.FieldName = "Id";
            gtbTemplateSchemaRemapID.HeaderText = "TemplateSchemaTableID";
            gtbTemplateSchemaRemapID.Name = "colTemplateSchemaTableID";
            gtbTemplateSchemaRemapID.IsVisible = false;
            this.rgvRemap.Columns.Add(gtbTemplateSchemaRemapID);

            GridViewTextBoxColumn gtbTemplateSchemaID = new GridViewTextBoxColumn();
            gtbTemplateSchemaID.EnableExpressionEditor = false;
            gtbTemplateSchemaID.FieldName = "TemplateId";
            gtbTemplateSchemaID.HeaderText = "TemplateId";
            gtbTemplateSchemaID.Name = "colTemplateSchmeaID";
            gtbTemplateSchemaID.IsVisible = false;
            this.rgvRemap.Columns.Add(gtbTemplateSchemaID);

            GridViewTextBoxColumn gtbOldSchema = new GridViewTextBoxColumn();
            gtbOldSchema.EnableExpressionEditor = false;
            gtbOldSchema.FieldName = "OldSchema";
            gtbOldSchema.HeaderText = "Old Schema";
            gtbOldSchema.Name = "colOldSchema";
            gtbOldSchema.Width = 125;
            gtbOldSchema.IsVisible = true;
            this.rgvRemap.Columns.Add(gtbOldSchema);

            GridViewTextBoxColumn gtbNewSchema = new GridViewTextBoxColumn();
            gtbNewSchema.EnableExpressionEditor = false;
            gtbNewSchema.FieldName = "NewSchema";
            gtbNewSchema.HeaderText = "New Schema";
            gtbNewSchema.Name = "colNewSchema";
            gtbNewSchema.IsVisible = true;
            gtbNewSchema.Width = 125;
            this.rgvRemap.Columns.Add(gtbNewSchema);
        }


        private void rgvRemap_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gce = (GridCommandCellElement)sender;
            if (gce.Value != null)
            {
                var TemplateSchemaRemapID = ((sender as GridCommandCellElement)).Value.ToString();
                TemplateSchemaRemap tst = Context.TemplateSchemaRemapRepository
                    .FindBy(x => x.Id == TemplateSchemaRemapID).FirstOrDefault();
                Context.TemplateSchemaRemapRepository.Delete(tst);

                if (this.rgvRemap.CurrentRow is GridViewDataRowInfo)
                    this.rgvRemap.Rows.Remove(((GridViewDataRowInfo)this.rgvRemap.CurrentRow));
            }
        }

        private void LoadGridLayout_rgvRemap_Data()
        {
            rgvRemap.DataSource = null;

            if ((!isLoading && this.rmccTemplateSchema.SelectedIndex > -1))
            {
                if (this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colDatabaseName"] != null)
                {
                    String strDatabaseName = this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colDatabaseName"].Value.ToString();
                    String strTemplateID = this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colTemplateID"].Value.ToString();

                    List<TemplateSchemaRemap> lstTST = Context.TemplateSchemaRemapRepository
                        .FindBy(x => x.TemplateId == strTemplateID).OrderBy(x => x.OldSchema)
                        .ToList();
                    rgvRemap.DataSource = lstTST;
                }
            }

        }

        private void rbUndo_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to undo all changes?", "Confirm",
    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Context.Rollback();
                LoadGridLayout_rgvRemap_Data();
            }

        }



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

        private void MasterTemplate_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            String strTemplateID = null;
            if ((!isLoading && this.rmccTemplateSchema.SelectedIndex > -1))
            {
                if (this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colDatabaseName"] != null)
                {
                    String strDatabaseName = this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colDatabaseName"].Value.ToString();
                    strTemplateID = this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colTemplateID"].Value.ToString();
                }
            }

            foreach (GridViewDataRowInfo dataRow in this.GetAllRows(this.rgvRemap.MasterTemplate))
            {
                TemplateSchemaRemap tsi = (TemplateSchemaRemap)dataRow.DataBoundItem;

                var cell = dataRow.Cells["colTemplateSchemaTableID"].Value;
                if (cell == null)
                {
                    TemplateSchemaRemap tst = new TemplateSchemaRemap();
                    String strTemplateSchemaRemapID = Regex.Replace(Guid.NewGuid().ToString().ToUpper(), "[-]", "");
                    tst.Id = strTemplateSchemaRemapID;
                    tst.TemplateId = strTemplateID;
                    tst.OldSchema = dataRow.Cells["colOldSchema"].Value.ToString();
                    tst.NewSchema = dataRow.Cells["colNewSchema"].Value.ToString();
                    Context.TemplateSchemaRemapRepository.Save(tst);
                    dataRow.Cells["colTemplateSchemaTableID"].Value = tst.Id;
                    dataRow.Tag = string.Empty;
                }
            }
        }

        private void rbSave_Click(object sender, EventArgs e)
        {
            Context.Commit();
        }

        private void MasterTemplate_CellValidating(object sender, CellValidatingEventArgs e)
        {
            GridViewDataColumn column = e.Column as GridViewDataColumn;
            if (e.Row is GridViewDataRowInfo || e.Row is GridViewNewRowInfo && column != null)
            {
                switch (column.Name.ToString())
                {
                    case "colOldSchema":
                        if (string.IsNullOrEmpty((string)e.Value) || ((string)e.Value).Trim() == string.Empty)
                        {
                            e.Cancel = true;
                            MessageBox.Show("Old Schema Required");
                        }
                        break;
                    case "colNewSchema":
                        if (string.IsNullOrEmpty((string)e.Value) || ((string)e.Value).Trim() == string.Empty)
                        {
                            e.Cancel = true;
                            MessageBox.Show("New Schema Required");
                        }
                        break;
                }
            }
        }
    }
}
