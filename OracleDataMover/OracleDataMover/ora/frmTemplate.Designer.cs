namespace OracleDataMover.ora
{
    partial class frmTemplate
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.rlblGridLabel = new Telerik.WinControls.UI.RadLabel();
            this.rgvTemplate = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.rbClose = new Telerik.WinControls.UI.RadButton();
            this.rbSave = new Telerik.WinControls.UI.RadButton();
            this.rbUndo = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rlblGridLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTemplate.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbUndo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.rlblGridLabel);
            this.radPanel2.Controls.Add(this.rgvTemplate);
            this.radPanel2.Location = new System.Drawing.Point(12, 12);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1234, 284);
            this.radPanel2.TabIndex = 4;
            // 
            // rlblGridLabel
            // 
            this.rlblGridLabel.Location = new System.Drawing.Point(3, 6);
            this.rlblGridLabel.Name = "rlblGridLabel";
            this.rlblGridLabel.Size = new System.Drawing.Size(53, 18);
            this.rlblGridLabel.TabIndex = 1;
            this.rlblGridLabel.Text = "Template";
            this.rlblGridLabel.ThemeName = "Office2013Light";
            // 
            // rgvTemplate
            // 
            this.rgvTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgvTemplate.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvTemplate.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgvTemplate.ForeColor = System.Drawing.Color.Black;
            this.rgvTemplate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvTemplate.Location = new System.Drawing.Point(3, 30);
            // 
            // 
            // 
            this.rgvTemplate.MasterTemplate.EnableFiltering = true;
            this.rgvTemplate.MasterTemplate.EnableGrouping = false;
            this.rgvTemplate.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgvTemplate.Name = "rgvTemplate";
            this.rgvTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvTemplate.ShowGroupPanel = false;
            this.rgvTemplate.Size = new System.Drawing.Size(1220, 251);
            this.rgvTemplate.TabIndex = 0;
            this.rgvTemplate.ThemeName = "TelerikMetroBlue";
            this.rgvTemplate.RowValidating += new Telerik.WinControls.UI.RowValidatingEventHandler(this.rgvTemplate_RowValidating);
            this.rgvTemplate.CellValidating += new Telerik.WinControls.UI.CellValidatingEventHandler(this.rgvTemplate_CellValidating);
            this.rgvTemplate.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgv_CellValueChanged);
            this.rgvTemplate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.rgvTemplate_PreviewKeyDown);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.rbClose);
            this.radPanel1.Controls.Add(this.rbSave);
            this.radPanel1.Controls.Add(this.rbUndo);
            this.radPanel1.Location = new System.Drawing.Point(9, 302);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1237, 52);
            this.radPanel1.TabIndex = 3;
            // 
            // rbClose
            // 
            this.rbClose.Location = new System.Drawing.Point(1116, 13);
            this.rbClose.Name = "rbClose";
            this.rbClose.Size = new System.Drawing.Size(110, 24);
            this.rbClose.TabIndex = 2;
            this.rbClose.Text = "Close";
            this.rbClose.ThemeName = "TelerikMetroBlue";
            this.rbClose.Click += new System.EventHandler(this.rbClose_Click);
            // 
            // rbSave
            // 
            this.rbSave.Location = new System.Drawing.Point(119, 13);
            this.rbSave.Name = "rbSave";
            this.rbSave.Size = new System.Drawing.Size(110, 24);
            this.rbSave.TabIndex = 1;
            this.rbSave.Text = "Save";
            this.rbSave.ThemeName = "TelerikMetroBlue";
            this.rbSave.Click += new System.EventHandler(this.rbSave_Click);
            // 
            // rbUndo
            // 
            this.rbUndo.Location = new System.Drawing.Point(3, 13);
            this.rbUndo.Name = "rbUndo";
            this.rbUndo.Size = new System.Drawing.Size(110, 24);
            this.rbUndo.TabIndex = 0;
            this.rbUndo.Text = "Undo";
            this.rbUndo.ThemeName = "TelerikMetroBlue";
            this.rbUndo.Click += new System.EventHandler(this.rbUndo_Click);
            // 
            // frmTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 366);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel1);
            this.Name = "frmTemplate";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTemplate";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rlblGridLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTemplate.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbUndo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadLabel rlblGridLabel;
        private Telerik.WinControls.UI.RadGridView rgvTemplate;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton rbClose;
        private Telerik.WinControls.UI.RadButton rbSave;
        private Telerik.WinControls.UI.RadButton rbUndo;
    }
}
