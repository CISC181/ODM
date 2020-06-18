namespace OracleDataMover.ora
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.rmFile = new Telerik.WinControls.UI.RadMenuItem();
            this.rmClose = new Telerik.WinControls.UI.RadMenuItem();
            this.rmManage = new Telerik.WinControls.UI.RadMenuItem();
            this.rmManageDatabase = new Telerik.WinControls.UI.RadMenuItem();
            this.rmManageRemap = new Telerik.WinControls.UI.RadMenuItem();
            this.rmManageParms = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.rmManageTemplate = new Telerik.WinControls.UI.RadMenuItem();
            this.rmTemplateParms = new Telerik.WinControls.UI.RadMenuItem();
            this.rmManageTemplateSchema = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radMenu1
            // 
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.rmFile,
            this.rmManage});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(692, 20);
            this.radMenu1.TabIndex = 4;
            // 
            // rmFile
            // 
            this.rmFile.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.rmClose});
            this.rmFile.Name = "rmFile";
            this.rmFile.Text = "File";
            // 
            // rmClose
            // 
            this.rmClose.Name = "rmClose";
            this.rmClose.Text = "Close";
            this.rmClose.Click += new System.EventHandler(this.rmClose_Click);
            // 
            // rmManage
            // 
            this.rmManage.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.rmManageDatabase,
            this.rmManageRemap,
            this.rmManageParms,
            this.radMenuSeparatorItem1,
            this.rmManageTemplate,
            this.rmTemplateParms,
            this.rmManageTemplateSchema});
            this.rmManage.Name = "rmManage";
            this.rmManage.Text = "Manage";
            // 
            // rmManageDatabase
            // 
            this.rmManageDatabase.Name = "rmManageDatabase";
            this.rmManageDatabase.Text = "Manage Database Info";
            this.rmManageDatabase.Click += new System.EventHandler(this.rmManageDatabase_Click);
            // 
            // rmManageRemap
            // 
            this.rmManageRemap.Name = "rmManageRemap";
            this.rmManageRemap.Text = "Manage Remap Function";
            this.rmManageRemap.Click += new System.EventHandler(this.rmManageRemap_Click);
            // 
            // rmManageParms
            // 
            this.rmManageParms.Name = "rmManageParms";
            this.rmManageParms.Text = "Manage Parms";
            this.rmManageParms.Click += new System.EventHandler(this.rmManageParms_Click);
            // 
            // radMenuSeparatorItem1
            // 
            this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rmManageTemplate
            // 
            this.rmManageTemplate.Name = "rmManageTemplate";
            this.rmManageTemplate.Text = "Manage Template";
            this.rmManageTemplate.Click += new System.EventHandler(this.rmManageTemplate_Click);
            // 
            // rmTemplateParms
            // 
            this.rmTemplateParms.Name = "rmTemplateParms";
            this.rmTemplateParms.Text = "Manage Template Parms";
            this.rmTemplateParms.Click += new System.EventHandler(this.rmTemplateParms_Click);
            // 
            // rmManageTemplateSchema
            // 
            this.rmManageTemplateSchema.Name = "rmManageTemplateSchema";
            this.rmManageTemplateSchema.Text = "Manage Templae Schema";
            this.rmManageTemplateSchema.Click += new System.EventHandler(this.rmManageTemplateSchema_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 546);
            this.Controls.Add(this.radMenu1);
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem rmFile;
        private Telerik.WinControls.UI.RadMenuItem rmClose;
        private Telerik.WinControls.UI.RadMenuItem rmManage;
        private Telerik.WinControls.UI.RadMenuItem rmManageDatabase;
        private Telerik.WinControls.UI.RadMenuItem rmManageRemap;
        private Telerik.WinControls.UI.RadMenuItem rmManageParms;
        private Telerik.WinControls.UI.RadMenuItem rmManageTemplate;
        private Telerik.WinControls.UI.RadMenuItem rmManageTemplateSchema;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
        private Telerik.WinControls.UI.RadMenuItem rmTemplateParms;
    }
}
