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
using OracleDataMoverOraEF.UnitOfWork;
using OracleDataMoverOraEF.EF;
using OracleDataMover.Common;

namespace OracleDataMover.ora
{
    public partial class frmDatabaseInfo : Telerik.WinControls.UI.RadForm
    {
        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), OracleDataMoverBLL.Common.Utility.UserName);
        protected static OraDataContext ContextOra = null;



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
            CommandCellClickEventHandler(rgvDatabaseInfoDelete_CommandCellClick);

            GridViewCommandColumn commandProofOfLifeColumn = new GridViewCommandColumn();
            commandProofOfLifeColumn.Name = "colProofOfLife";
            commandProofOfLifeColumn.UseDefaultText = true;
            commandProofOfLifeColumn.DefaultText = "Check";
            commandProofOfLifeColumn.FieldName = "TNSName";
            rgvDatabaseInfo.MasterTemplate.Columns.Add(commandProofOfLifeColumn);
            //rgvDatabaseInfo.CommandCellClick += new
            //CommandCellClickEventHandler(rgvDatabase_ProofOfLife_CommandCellClick);


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

        private void rgvDatabaseInfoDelete_CommandCellClick(object sender, EventArgs e)
        {

            GridViewCellEventArgs args = (GridViewCellEventArgs)e;
            GridCommandCellElement gce = (GridCommandCellElement)sender;
            switch (args.Column.Name)
            {
                case "colDelete":
                    // MessageBox.Show("You ordered " + ((sender as GridCommandCellElement)).Value);

                    if (gce.Value != null)
                    {
                        var databaseID = ((sender as GridCommandCellElement)).Value.ToString();
                        DATABASE_INFO di = Context.DATABASE_INFORepository
                            .FindBy(x => x.Id == databaseID).FirstOrDefault();
                        Context.DATABASE_INFORepository.Delete(di);
                    }
                    this.rgvDatabaseInfo.Rows.Remove(((GridViewDataRowInfo)this.rgvDatabaseInfo.CurrentRow));
                    break;
                case "colProofOfLife":
                    // MessageBox.Show("You ordered " + ((sender as GridCommandCellElement)).Value);
                    if (gce.Value != null)
                    {

                        validateDatabaseConnection(((sender as GridCommandCellElement)).Value.ToString());
                    }
                    break;
            }



        }



        private void LoadGrid()
        {
            List<DATABASE_INFO> lstDatabaseInfo = Context.DATABASE_INFORepository.FindBy(x => true).ToList();
            rgvDatabaseInfo.DataSource = lstDatabaseInfo;
        }


        private void rbSave_Click(object sender, EventArgs e)
        {
            String strTNSName;

            foreach (GridViewDataRowInfo dataRow in this.GetAllRows(this.rgvDatabaseInfo.MasterTemplate))
            {
                strTNSName = dataRow.Cells["colTNSName"].Value.ToString();

                if (validateDatabaseConnection(strTNSName))
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
                else
                {
                    Context.Rollback();
                    LoadGrid();
                    return;
                }

            }
            Context.Commit();
            MessageBox.Show("Data is saved");
            LoadGrid();
        }

        private Boolean validateDatabaseConnection(string strTNSName)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (OracleDataMover.Common.Utility.validateDatabaseConnection(strTNSName) == true)
                {
                    MessageBox.Show("Connection successful: " + strTNSName);
                    Cursor.Current = Cursors.Default;
                    return true;
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    return false;
                }
            }
            catch (System.Data.Entity.Core.EntityException e)
            {
                var strMessage = e.InnerException.Message;
                MessageBox.Show("Error with Database: " + strTNSName + Environment.NewLine + strMessage);
                Cursor.Current = Cursors.Default;
                return false;
            }
            catch (Exception e)
            {
                Cursor.Current = Cursors.Default;
                return false;
            }
         

            //Cursor.Current = Cursors.Default;



            //String connBuilder = ConfigurationManager.AppSettings["OracleConnectionStringTemplate"];
            //connBuilder = connBuilder.Replace("ODM_Database", strTNSName);

            //try
            //{
            //    ContextOra = new OraDataContext(new OraEntities(connBuilder), Utility.UserName);
            //    ContextOra.ProofOfLife();
            //}
            //catch (System.Data.Entity.Core.EntityException e)
            //{
            //    var strMessage = e.InnerException.Message;
            //    MessageBox.Show("Error with Database: " + strTNSName + Environment.NewLine + strMessage);
            //    Cursor.Current = Cursors.Default;
            //    return false;
            //}
            //catch (Exception e)
            //{
            //    Cursor.Current = Cursors.Default;
            //    return false;
            //}

            //Cursor.Current = Cursors.Default;
            //return true;
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
