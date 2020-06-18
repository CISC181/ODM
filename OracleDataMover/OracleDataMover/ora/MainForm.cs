using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace OracleDataMover.ora
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        public MainForm()
        {
            InitializeComponent();
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //MessageBox.Show(userName);
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


    }
}
