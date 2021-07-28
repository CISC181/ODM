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
    public partial class frmRemapFunction : Telerik.WinControls.UI.RadForm
    {
        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), Utility.UserName);

        private MainForm MF;

        public MainForm MF1 { get => MF; set => MF = value; }
        public frmRemapFunction()
        {

            InitializeComponent();
            LoadGridLayout();
            LoadGrid();
        }
        #region CommonMethods
        public List<GridViewRowInfo> GetAllRows(GridViewTemplate template)
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
            rgvRemapFunction.MasterTemplate.Columns.Add(commandColumn);
            rgvRemapFunction.CommandCellClick += new
            CommandCellClickEventHandler(rgvRemapFunction_CommandCellClick);


            GridViewTextBoxColumn gtbRemapID = new GridViewTextBoxColumn();
            gtbRemapID.EnableExpressionEditor = false;
            gtbRemapID.FieldName = "ID";
            gtbRemapID.HeaderText = "Remap Function ID";
            gtbRemapID.Name = "colRemapFunctionID";
            gtbRemapID.IsVisible = false;
            this.rgvRemapFunction.Columns.Add(gtbRemapID);

            GridViewTextBoxColumn gtbSchemaName = new GridViewTextBoxColumn();
            gtbSchemaName.EnableExpressionEditor = false;
            gtbSchemaName.FieldName = "SchemaName";
            gtbSchemaName.HeaderText = "Schema Name";
            gtbSchemaName.Name = "colSchemaName";
            gtbSchemaName.Width = 150;
            this.rgvRemapFunction.Columns.Add(gtbSchemaName);

            GridViewTextBoxColumn gtbPackageName = new GridViewTextBoxColumn();
            gtbPackageName.EnableExpressionEditor = false;
            gtbPackageName.FieldName = "PackageName";
            gtbPackageName.HeaderText = "Package Name";
            gtbPackageName.Name = "colPackageName";
            gtbPackageName.Width = 150;
            this.rgvRemapFunction.Columns.Add(gtbPackageName);

            GridViewTextBoxColumn gtbFunctionName = new GridViewTextBoxColumn();
            gtbFunctionName.EnableExpressionEditor = false;
            gtbFunctionName.FieldName = "FunctionName";
            gtbFunctionName.HeaderText = "Function Name";
            gtbFunctionName.Name = "colFunctionName";
            gtbFunctionName.Width = 150;
            this.rgvRemapFunction.Columns.Add(gtbFunctionName);
        }


        private void rgvRemapFunction_CommandCellClick(object sender, EventArgs e)
        {
            // MessageBox.Show("You ordered " + ((sender as GridCommandCellElement)).Value);
            GridCommandCellElement gce = (GridCommandCellElement)sender;
            if (gce.Value != null)
            {
                var TemplateID = ((sender as GridCommandCellElement)).Value.ToString();
                Template t = Context.TemplateRepository
                    .FindBy(x => x.Id == TemplateID).FirstOrDefault();
                Context.TemplateRepository.Delete(t);
            }
            this.rgvRemapFunction.Rows.Remove(((GridViewDataRowInfo)this.rgvRemapFunction.CurrentRow));
        }

        private void LoadGrid()
        {

            List<RemapFunction> lstTemplate = Context.RemapFunctionRepository.FindBy(x => true).ToList();
            rgvRemapFunction.DataSource = lstTemplate;

        }
        private void rbSave_Click(object sender, EventArgs e)
        {
            foreach (GridViewDataRowInfo dataRow in this.GetAllRows(this.rgvRemapFunction.MasterTemplate))
            {
                var cell = dataRow.Cells["colRemapFunctionID"].Value;
                if (cell == null)
                {
                    RemapFunction itmRemap = new RemapFunction();
                    itmRemap.FunctionName = dataRow.Cells["colFunctionName"].Value.ToString();
                    itmRemap.PackageName = dataRow.Cells["colPackageName"].Value.ToString();
                    itmRemap.SchemaName = dataRow.Cells["colSchemaName"].Value.ToString();
                    Context.RemapFunctionRepository.Save(itmRemap);
                }
                if ((dataRow.Tag != null) && (dataRow.Tag.ToString() == "ThisRowIsDirty"))
                {
                    string itmRemap = dataRow.Cells["colRemapFunctionID"].Value.ToString();
                    RemapFunction updRemap = Context.RemapFunctionRepository
                        .FindBy(x => x.Id == itmRemap).FirstOrDefault();
                    updRemap.FunctionName = dataRow.Cells["colFunctionName"].Value.ToString();
                    updRemap.PackageName = dataRow.Cells["colPackageName"].Value.ToString();
                    updRemap.SchemaName = dataRow.Cells["colSchemaName"].Value.ToString();
                    Context.RemapFunctionRepository.Save(updRemap);
                }
            }
            Context.Commit();
            MessageBox.Show("Data is saved");
            LoadGrid();
        }

    }
}
