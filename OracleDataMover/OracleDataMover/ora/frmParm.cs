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
    public partial class frmParm : Telerik.WinControls.UI.RadForm
    {
        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), Utility.UserName);
        private MainForm MF;

        public MainForm MF1 { get => MF; set => MF = value; }

        public frmParm()
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
            rgvParm.MasterTemplate.Columns.Add(commandColumn);
            rgvParm.CommandCellClick += new
            CommandCellClickEventHandler(rgvParm_CommandCellClick);


            GridViewTextBoxColumn gtbParmID = new GridViewTextBoxColumn();
            gtbParmID.EnableExpressionEditor = false;
            gtbParmID.FieldName = "ID";
            gtbParmID.HeaderText = "Parm ID";
            gtbParmID.Name = "colParmId";
            gtbParmID.Width = 341;
            gtbParmID.IsVisible = false;
            this.rgvParm.Columns.Add(gtbParmID);

            GridViewTextBoxColumn gtbParmName = new GridViewTextBoxColumn();
            gtbParmName.EnableExpressionEditor = false;
            gtbParmName.FieldName = "ParmName";
            gtbParmName.HeaderText = "Parm Name";
            gtbParmName.Name = "colParmName";
            gtbParmName.Width = 400;
            this.rgvParm.Columns.Add(gtbParmName);
        }
        private void LoadGrid()
        {
            List<PARM> lstParms = Context.PARMRepository.FindBy(x => true).ToList();
            rgvParm.DataSource = lstParms;
        }



        void rgvParm_CommandCellClick(object sender, EventArgs e)
        {
            // MessageBox.Show("You ordered " + ((sender as GridCommandCellElement)).Value);
            GridCommandCellElement gce = (GridCommandCellElement)sender;
            if (gce.Value != null)
            {
                var parmID = ((sender as GridCommandCellElement)).Value.ToString();
                PARM p = Context.PARMRepository
                    .FindBy(x => x.Id == parmID).FirstOrDefault();
                Context.PARMRepository.Delete(p);
            }
            this.rgvParm.Rows.Remove(((GridViewDataRowInfo)this.rgvParm.CurrentRow));
        }



        private void rbSave_Click(object sender, EventArgs e)
        {
            foreach (GridViewDataRowInfo dataRow in this.GetAllRows(this.rgvParm.MasterTemplate))
            {
                var cell = dataRow.Cells["colParmID"].Value;
                if (cell == null)
                {
                    PARM p = new PARM();
                    p.ParmName = dataRow.Cells["colParmName"].Value.ToString();
                    Context.PARMRepository.Save(p);
                }
                if ((dataRow.Tag != null) && (dataRow.Tag.ToString() == "ThisRowIsDirty"))
                {
                    string parmID = dataRow.Cells["colParmID"].Value.ToString();
                    PARM p = Context.PARMRepository
                        .FindBy(x => x.Id == parmID).FirstOrDefault();
                    p.ParmName = dataRow.Cells["colParmName"].Value.ToString();
                    Context.PARMRepository.Save(p);
                }
            }
            Context.Commit();
            MessageBox.Show("Data is saved");
            LoadGrid();
        }
    }
}
