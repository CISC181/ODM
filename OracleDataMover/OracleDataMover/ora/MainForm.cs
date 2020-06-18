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
using OracleDataMover.Common;

namespace OracleDataMover.ora
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        private Boolean isLoading;
        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), "Gibbonsbr");

        public MainForm()
        {
            InitializeComponent();
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //MessageBox.Show(userName);
            RadToolTip newToolTip = new RadToolTip();
            newToolTip.Show("A tooltip which appears at mouse position", 2000);

            isLoading = true;
            LoadrmccDatabase();
            LoadGrid();
            isLoading = false;


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
                    LoadGrid();
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
            cmdExecuteEXPDP.DefaultText = "Execute EXPDP";
            cmdExecuteEXPDP.FieldName = "Id";
            cmdExecuteEXPDP.Width = 150;
            rgvTemplate.MasterTemplate.Columns.Add(cmdExecuteEXPDP);
            rgvTemplate.CommandCellClick += new
            CommandCellClickEventHandler(rgvTemplate_CommandCellClick);

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
        }

        private void LoadGridData()
        {
            if (this.rmccDatabase.EditorControl.CurrentRow.Cells["colDatabaseID"] != null)
            {
                string strDatabaseID = rmccDatabase.EditorControl.CurrentRow.Cells["colDatabaseID"].Value.ToString();
                List<Template> lstTemplate = Context.TemplateRepository.FindBy(x => x.DATABASE_ID == strDatabaseID).ToList();
                rgvTemplate.DataSource = lstTemplate;
            }
        }

        private void rgvTemplate_CommandCellClick(object sender, EventArgs e)
        {
            GridViewCellEventArgs args = (GridViewCellEventArgs)e;

            switch (args.Column.Name)
            {
                case "colExecute":
                    rgvTemplate_cmdGeneratePAR_CommandCellClick(sender, e);
                    break;
            }
        }

        private void rgvTemplate_cmdGeneratePAR_CommandCellClick(object sender, EventArgs e)
        {
            GridViewCellEventArgs args = (GridViewCellEventArgs)e;
            ODMSetting ODMSetting = Context.ODMSettingRepository.FindBy(x => x.SettingName == "WORKING_DIR").FirstOrDefault();
            Template tmpl = Context.TemplateRepository.FindBy(x => x.Id == args.Value.ToString()).FirstOrDefault();

            GenerateFiles.GeneratePARFile(ODMSetting.SettingValue + '\\' + tmpl.PARFileName.ToString(), args.Value.ToString());



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
            frmDb.Show();

        }

        private void rmManageRemap_Click(object sender, EventArgs e)
        {
            frmRemapFunction frmT = new frmRemapFunction();
            frmT.Show();
        }

        private void rmManageParms_Click(object sender, EventArgs e)
        {
            frmParm pf = new frmParm();
            pf.Show();

        }

        private void rmManageTemplate_Click(object sender, EventArgs e)
        {
            frmTemplate frmT = new frmTemplate();
            frmT.Show();
        }

        private void rmManageTemplateSchema_Click(object sender, EventArgs e)
        {
            frmTemplateSchema frmT = new frmTemplateSchema();
            frmT.Show();
        }

        private void rmTemplateParms_Click(object sender, EventArgs e)
        {
            frmTemplateParm frmT = new frmTemplateParm();
            frmT.Show();
        }


        #endregion

        private void rbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
