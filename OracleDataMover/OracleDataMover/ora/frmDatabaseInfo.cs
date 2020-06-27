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
using System.Configuration;
using OracleDataMoverBLL.Common;

namespace OracleDataMover.ora
{
    public partial class frmDatabaseInfo : Telerik.WinControls.UI.RadForm
    {
        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), Utility.UserName);
        private Boolean bDirty;
        private MainForm MF;
        public MainForm MF1 { get => MF; set => MF = value; }

        public frmDatabaseInfo()
        {
            InitializeComponent();
            LoadGridLayout();
            LoadGrid();
            SetButtonStates();


        }

        private void SetButtonStates()
        {
            rbClose.Enabled = true;
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
            rgvDatabaseInfo.MasterTemplate.Columns.Add(commandColumn);
            rgvDatabaseInfo.CommandCellClick += new
            CommandCellClickEventHandler(rgvDatabaseInfo_CommandCellClick);


            GridViewTextBoxColumn gtbDatabaseID = new GridViewTextBoxColumn();
            gtbDatabaseID.EnableExpressionEditor = false;
            gtbDatabaseID.FieldName = "ID";
            gtbDatabaseID.HeaderText = "Database ID";
            gtbDatabaseID.Name = "colDatabaseID";
            gtbDatabaseID.IsVisible = false;
            this.rgvDatabaseInfo.Columns.Add(gtbDatabaseID);

            GridViewComboBoxColumn colDatabaseName = new GridViewComboBoxColumn();
            colDatabaseName.Name = "colDatabaseName";
            colDatabaseName.HeaderText = "Database Name";
            colDatabaseName.ValueMember = "Name";
            colDatabaseName.DisplayMember = "Name";
            colDatabaseName.FieldName = "Name";
            colDatabaseName.Width = 275;
            this.rgvDatabaseInfo.Columns.Add(colDatabaseName);

            GridViewTextBoxColumn gbtTNSNames = new GridViewTextBoxColumn();
            gbtTNSNames.EnableExpressionEditor = false;
            gbtTNSNames.FieldName = "TNSName";
            gbtTNSNames.HeaderText = "TNS Name";
            gbtTNSNames.Name = "colTNSName";
            gbtTNSNames.Width = 150;
            this.rgvDatabaseInfo.Columns.Add(gbtTNSNames);
        }

        private void rgvDatabaseInfo_CommandCellClick(object sender, EventArgs e)
        {
            // MessageBox.Show("You ordered " + ((sender as GridCommandCellElement)).Value);
            GridCommandCellElement gce = (GridCommandCellElement)sender;
            if (gce.Value != null)
            {
                var databaseID = ((sender as GridCommandCellElement)).Value.ToString();
                DATABASE_INFO di = Context.DATABASE_INFORepository
                    .FindBy(x => x.Id == databaseID).FirstOrDefault();
                Context.DATABASE_INFORepository.Delete(di);
            }
            this.rgvDatabaseInfo.Rows.Remove(((GridViewDataRowInfo)this.rgvDatabaseInfo.CurrentRow));
        }

        private void LoadGrid()
        {
            List<DATABASE_INFO> lstDatabaseInfo = Context.DATABASE_INFORepository.FindBy(x => true).ToList();
            rgvDatabaseInfo.DataSource = lstDatabaseInfo;
        }


        private void rbSave_Click(object sender, EventArgs e)
        {
            foreach (GridViewDataRowInfo dataRow in this.GetAllRows(this.rgvDatabaseInfo.MasterTemplate))
            {
                var cell = dataRow.Cells["colDatabaseID"].Value;
                if (cell == null)
                {
                    DATABASE_INFO di = new DATABASE_INFO();
                    di.Name = dataRow.Cells["colDatabaseName"].Value.ToString();
                    di.TnsName = dataRow.Cells["colTNSName"].Value.ToString();
                    Context.DATABASE_INFORepository.Save(di);
                }
                if ((dataRow.Tag != null) && (dataRow.Tag.ToString() == "ThisRowIsDirty"))
                {
                    string diID = dataRow.Cells["colDatabaseID"].Value.ToString();
                    DATABASE_INFO di = Context.DATABASE_INFORepository
                        .FindBy(x => x.Id == diID).FirstOrDefault();
                    di.Name = dataRow.Cells["colDatabaseName"].Value.ToString();
                    di.TnsName = dataRow.Cells["colTNSName"].Value.ToString();
                    Context.DATABASE_INFORepository.Save(di);
                }
            }
            Context.Commit();
            MessageBox.Show("Data is saved");
            LoadGrid();
        }

        private void rgvDatabaseInfo_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {

            if (e.Column.HeaderText == "Database Name")
            {
                RadDropDownListEditor editor = (RadDropDownListEditor)this.rgvDatabaseInfo.ActiveEditor;
                RadDropDownListEditorElement editorElement = (RadDropDownListEditorElement)editor.EditorElement;


                foreach (ConnectionStringSettings css in ConfigurationManager.ConnectionStrings)
                {
                    List<GridViewRowInfo> dataRow = this.GetAllRows(this.rgvDatabaseInfo.MasterTemplate).ToList();
                    {
                        if (dataRow.Where(x => x.Cells["colDatabaseName"].Value.ToString() == css.Name).Count() == 0)
                        {

                            if (css.ConnectionString.ToString().Contains("OraModel"))
                            {
                                RadListDataItem rldi = new RadListDataItem();
                                rldi.Text = css.Name;
                                rldi.Value = css.Name;
                                editorElement.Items.Add(rldi);
                            }
                        }
                    }
                }
                editorElement.SelectedValue = null;
                editorElement.SelectedValue = this.rgvDatabaseInfo.CurrentCell.Value;
            }
        }
    }
}
