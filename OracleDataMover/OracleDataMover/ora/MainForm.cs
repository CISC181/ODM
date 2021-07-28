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
using System.ComponentModel;
using Telerik.WinControls;
using OracleDataMoverBLL.Common;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace OracleDataMover.ora
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        private Boolean isLoading;
        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), Utility.UserName);
        protected static OraDataContext ContextOra = null;


        public MainForm()
        {
            InitializeComponent();

            //MessageBox.Show(userName); test
            RadToolTip newToolTip = new RadToolTip();
            newToolTip.Show("A tooltip which appears at mouse position", 2000);

            isLoading = true;
            LoadrmccDatabase();
            LoadGrid();
            LoadDBAGrid();
            isLoading = false;

            gridTimer.Interval = 1000;
            gridTimer.Tick += new EventHandler(Timer1_Tick);
            gridTimer.Enabled = false;
        }

        private void Timer1_Tick(object Sender, EventArgs e)
        {
            this.LoadGridData();
            this.LoadDBAGridData();
        }

        private void LoadrmccDatabase()
        {
            List<DATABASE_INFO> lstDB = Context.DATABASE_INFORepository.FindBy(x => true)
                .OrderBy(x => x.Name).ToList();
            this.rmccDatabase.DataSource = lstDB;
        }

        private void rmccDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!isLoading && this.rmccDatabase.SelectedIndex > -1))
            {
                if (this.rmccDatabase.EditorControl.CurrentRow.Cells["colDatabaseID"] != null)
                {
                    LoadGridData();
                    LoadDBAGrid();
                }
            }
        }

        private void LoadGrid()
        {
            LoadGridLayout();
            LoadGridData();
        }

        private void LoadGridLayout()
        {
            rgvTemplate.Columns.Clear();

            GridViewCommandColumn cmdExecuteEXPDP = new GridViewCommandColumn();
            cmdExecuteEXPDP.Name = "colExecute";
            cmdExecuteEXPDP.UseDefaultText = true;
            cmdExecuteEXPDP.DefaultText = "Execute";
            cmdExecuteEXPDP.FieldName = "Id";
            cmdExecuteEXPDP.Width = 75;
            rgvTemplate.MasterTemplate.Columns.Add(cmdExecuteEXPDP);
            rgvTemplate.CommandCellClick += new
            CommandCellClickEventHandler(rgvTemplate_CommandCellClick);

            GridViewTextBoxColumn gtbUtilityName = new GridViewTextBoxColumn();
            gtbUtilityName.EnableExpressionEditor = false;
            gtbUtilityName.FieldName = "ORA_UTILITY.UtilityName";
            gtbUtilityName.HeaderText = "Utility Name";
            gtbUtilityName.Name = "colUtilityName";
            gtbUtilityName.Width = 150;
            this.rgvTemplate.Columns.Add(gtbUtilityName);

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
            gtbTemplateName.Width = 200;
            this.rgvTemplate.Columns.Add(gtbTemplateName);

            GridViewTextBoxColumn gtbDMPFileName = new GridViewTextBoxColumn();
            gtbDMPFileName.EnableExpressionEditor = false;
            gtbDMPFileName.FieldName = "DMPFileName";
            gtbDMPFileName.HeaderText = "DMP Filename";
            gtbDMPFileName.Name = "colDmpFileName";
            gtbDMPFileName.Width = 150;
            this.rgvTemplate.Columns.Add(gtbDMPFileName);
        }

        public void LoadGridData()
        {
            if (this.rmccDatabase.EditorControl.CurrentRow.Cells["colDatabaseID"] != null)
            {
                string strDatabaseID = rmccDatabase.EditorControl.CurrentRow.Cells["colDatabaseID"].Value.ToString();
                String strDatabaseName = this.rmccDatabase.EditorControl.CurrentRow.Cells["colDatabaseName"].Value.ToString();
                List<Template> lstTemplate = Context.TemplateRepository.FindBy(x => x.DATABASE_ID == strDatabaseID).ToList();

                rgvTemplate.DataSource = null;
                rgvTemplate.DataSource = lstTemplate;



                //ContextOra = new OraDataContext(new OraEntities(strDatabaseName), "Gibbonsbr");
                //List<OracleDataMoverOraEF.EF.DBA_DataPump_Jobs> lstDBAJobs = ContextOra.GetDBADataPumpJobs();


                //List <DBA_DataPump_Jobs> lstDBAJobs = Context.GetDBADataPumpJobs();


                //var results = from Template in lstTemplate
                //              join DBAJobs in lstDBAJobs
                //              on  Template.UtilJobname.ToUpper() equals DBAJobs.JOB_NAME.ToUpper() into joined
                //              from j in joined.DefaultIfEmpty()
                //              select new
                //              {
                //                  TemplateData = Template,
                //                  DBAJobData = j
                //              };










            }
        }

        private void rgvTemplate_CommandCellClick(object sender, EventArgs e)
        {

            GridViewCellEventArgs args = (GridViewCellEventArgs)e;

            switch (args.Column.Name)
            {
                case "colExecute":
                    rgvTemplate_cmdGeneratePAR_CommandCellClick(sender, e);
                    Utility.WriteHistoryRecord(args.Value.ToString());
                    break;
            }
        }

        private void rgvTemplate_cmdGeneratePAR_CommandCellClick(object sender, EventArgs e)
        {
            gridTimer.Enabled = true;
            GridViewCellEventArgs args = (GridViewCellEventArgs)e;
            ODMSetting ODMSetting = Context.ODMSettingRepository.FindBy(x => x.SettingName == "WORKING_DIR").FirstOrDefault();
            Template tmpl = Context.TemplateRepository.FindBy(x => x.Id == args.Value.ToString()).FirstOrDefault();
            GenerateFiles.GeneratePARFile(ODMSetting.SettingValue + '\\' + tmpl.PARFileName.ToString(), args.Value.ToString());
            GenerateFiles.GenerateBATFile(ODMSetting.SettingValue + '\\' + tmpl.BATFileName.ToString(), args.Value.ToString());
            Utility.ExecuteAsAdmin(ODMSetting.SettingValue + '\\' + tmpl.BATFileName.ToString());

        }

        private void LoadDBAGrid()
        {
            LoadDBAGridLayout();
            LoadDBAGridData();
        }

        private void LoadDBAGridLayout()
        {
            rgvDBAJobs.Columns.Clear();


            GridViewTextBoxColumn gtbOwnerName = new GridViewTextBoxColumn();
            gtbOwnerName.EnableExpressionEditor = false;
            gtbOwnerName.FieldName = "OWNER_NAME";
            gtbOwnerName.HeaderText = "Owner";
            gtbOwnerName.Name = "colOWNER_NAME";
            gtbOwnerName.Width = 100;
            this.rgvDBAJobs.Columns.Add(gtbOwnerName);

            GridViewTextBoxColumn gtbJOB_NAME = new GridViewTextBoxColumn();
            gtbJOB_NAME.EnableExpressionEditor = false;
            gtbJOB_NAME.FieldName = "JOB_NAME";
            gtbJOB_NAME.HeaderText = "Job Name";
            gtbJOB_NAME.Name = "colJOB_NAME";
            gtbJOB_NAME.Width = 100;
            this.rgvDBAJobs.Columns.Add(gtbJOB_NAME);

            GridViewTextBoxColumn gtbOPERATION = new GridViewTextBoxColumn();
            gtbOPERATION.EnableExpressionEditor = false;
            gtbOPERATION.FieldName = "OPERATION";
            gtbOPERATION.HeaderText = "Operation";
            gtbOPERATION.Name = "colOPERATION";
            gtbOPERATION.Width = 85;
            this.rgvDBAJobs.Columns.Add(gtbOPERATION);

            GridViewTextBoxColumn gtbJOB_MODE = new GridViewTextBoxColumn();
            gtbJOB_MODE.EnableExpressionEditor = false;
            gtbJOB_MODE.FieldName = "JOB_MODE";
            gtbJOB_MODE.HeaderText = "Job Mode";
            gtbJOB_MODE.Name = "colJOB_MODE";
            gtbJOB_MODE.Width = 85;
            this.rgvDBAJobs.Columns.Add(gtbJOB_MODE);

            GridViewTextBoxColumn gtbSTATE = new GridViewTextBoxColumn();
            gtbSTATE.EnableExpressionEditor = false;
            gtbSTATE.FieldName = "STATE";
            gtbSTATE.HeaderText = "State";
            gtbSTATE.Name = "colSTATE";
            gtbSTATE.Width = 85;
            this.rgvDBAJobs.Columns.Add(gtbSTATE);

        }
        private void LoadDBAGridData()
        {
            if (this.rmccDatabase.EditorControl.CurrentRow.Cells["colDatabaseID"] != null)
            {
                string strDatabaseID = rmccDatabase.EditorControl.CurrentRow.Cells["colDatabaseID"].Value.ToString();
                String strDatabaseName = this.rmccDatabase.EditorControl.CurrentRow.Cells["colDatabaseName"].Value.ToString();

                DATABASE_INFO vDatabase_Info = Context.DATABASE_INFORepository.GetById(strDatabaseID);

                String connBuilder = ConfigurationManager.AppSettings["OracleConnectionStringTemplate"];

                connBuilder = connBuilder.Replace("ODM_Database", vDatabase_Info.TnsName);
                //String connBuilder = "metadata=res://*/EF.ODMModel.csdl|res://*/EF.ODMModel.ssdl|res://*/EF.ODMModel.msl;provider=Oracle.ManagedDataAccess.Client;provider connection string='data source=NEWARK;persist security info=True;USER ID=ODM;PASSWORD=ODM;'";

                ContextOra = new OraDataContext(new OraEntities(connBuilder), Utility.UserName);

                //ContextOra = new OraDataContext(new OraEntities(strDatabaseName), Utility.UserName);
                List<OracleDataMoverOraEF.EF.DBA_DataPump_Jobs> lstDBAJobs = ContextOra.GetDBADataPumpJobs();
                rgvDBAJobs.DataSource = lstDBAJobs;
            }

        }



        #region MenuClicks
        private void rbParms_Click(object sender, EventArgs e)
        {
            frmParm pf = new frmParm();
            pf.Show();
            this.Hide();
        }

        private void rmClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rmManageDatabase_Click(object sender, EventArgs e)
        {
            frmDatabaseInfo frmDb = new frmDatabaseInfo();
            frmDb.MF1 = this;
            frmDb.Show();

        }

        private void rmManageRemap_Click(object sender, EventArgs e)
        {
            frmRemapFunction frmT = new frmRemapFunction();
            frmT.MF1 = this;
            frmT.Show();
        }

        private void rmManageParms_Click(object sender, EventArgs e)
        {
            frmParm pf = new frmParm();
            pf.MF1 = this;
            pf.Show();

        }

        private void rmManageTemplate_Click(object sender, EventArgs e)
        {
            frmTemplate frmT = new frmTemplate();
            frmT.MF1 = this;
            frmT.Show();
        }

        private void rmManageTemplateSchema_Click(object sender, EventArgs e)
        {
            frmTemplateSchema frmT = new frmTemplateSchema();
            frmT.MF1 = this;
            frmT.Show();
        }

        private void rmTemplateParms_Click(object sender, EventArgs e)
        {
            frmTemplateParm frmT = new frmTemplateParm();
            frmT.MF1 = this;
            frmT.Show();
        }

        private void rmiTemplateSchemaImport_Click(object sender, EventArgs e)
        {
            frmTemplateRemap frmT = new frmTemplateRemap();
            frmT.MF1 = this;
            frmT.Show();
        }

        #endregion

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
            Application.Exit();
        }

        private void rgvDBAJobs_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            string strState = (String)e.RowElement.RowInfo.Cells["colSTATE"].Value.ToString().ToUpper();

            switch (strState)
            {
                case "EXECUTING":
                    e.RowElement.DrawFill = true;
                    e.RowElement.GradientStyle = GradientStyles.Solid;
                    e.RowElement.BackColor = Color.HotPink;
                    break;
                case "NOT RUNNING":
                    e.RowElement.DrawFill = true;
                    e.RowElement.GradientStyle = GradientStyles.Solid;
                    e.RowElement.BackColor = Color.Yellow;
                    break;
                case "COMPLETING":
                    e.RowElement.DrawFill = true;
                    e.RowElement.GradientStyle = GradientStyles.Solid;
                    e.RowElement.BackColor = Color.Green;
                    gridTimer.Enabled = false;
                    break;
                default:
                    e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                    e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                    e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                    break;
            }

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            frmTemplateSchedule rf = new frmTemplateSchedule();
            rf.Show();

        }

        private void rgvTemplate_DoubleClick(object sender, EventArgs e)
        {
            RadGridView rgv = (RadGridView)sender;
            String TemplateName = rgv.SelectedRows[0].Cells["colTemplateName"].Value.ToString();
            frmTemplate frm = new frmTemplate(TemplateName);
            frm.MF1 = this;
            frm.Show();

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (this.rmccDatabase.EditorControl.CurrentRow.Cells["colTNSName"] != null)
            {
                String strTNSName = this.rmccDatabase.EditorControl.CurrentRow.Cells["colTNSName"].Value.ToString();


                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (OracleDataMover.Common.Utility.validateDatabaseConnection(strTNSName) == true)
                    {
                        MessageBox.Show("Connection successful: " + strTNSName);
                        Cursor.Current = Cursors.Default;
                        return;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        return;
                    }
                }
                catch (System.Data.Entity.Core.EntityException ex)
                {
                    var strMessage = ex.InnerException.Message;
                    MessageBox.Show("Error with Database: " + strTNSName + Environment.NewLine + strMessage);
                    Cursor.Current = Cursors.Default;
                    return;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    return;
                }

            }
        }
    }

}