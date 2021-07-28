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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition7 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor4 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition8 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.rlblGridLabel = new Telerik.WinControls.UI.RadLabel();
            this.rgvTemplate = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.rbClose = new Telerik.WinControls.UI.RadButton();
            this.rbSave = new Telerik.WinControls.UI.RadButton();
            this.rbUndo = new Telerik.WinControls.UI.RadButton();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.rmccDatabase = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtImport = new System.Windows.Forms.RadioButton();
            this.rbtExport = new System.Windows.Forms.RadioButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccDatabase.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccDatabase.EditorControl.MasterTemplate)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.rlblGridLabel);
            this.radPanel2.Controls.Add(this.rgvTemplate);
            this.radPanel2.Location = new System.Drawing.Point(12, 88);
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
            this.rgvTemplate.MasterTemplate.ViewDefinition = tableViewDefinition7;
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
            this.radPanel1.Location = new System.Drawing.Point(9, 378);
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
            // radPanel3
            // 
            this.radPanel3.Controls.Add(this.groupBox1);
            this.radPanel3.Controls.Add(this.rmccDatabase);
            this.radPanel3.Controls.Add(this.radLabel2);
            this.radPanel3.Controls.Add(this.radLabel1);
            this.radPanel3.Location = new System.Drawing.Point(15, 12);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(1234, 62);
            this.radPanel3.TabIndex = 5;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(17, 30);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(53, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Database";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 6);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(36, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Filters";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // rmccDatabase
            // 
            this.rmccDatabase.DisplayMember = "Name";
            // 
            // rmccDatabase.NestedRadGridView
            // 
            this.rmccDatabase.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rmccDatabase.EditorControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.rmccDatabase.EditorControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rmccDatabase.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rmccDatabase.EditorControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rmccDatabase.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rmccDatabase.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rmccDatabase.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rmccDatabase.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rmccDatabase.EditorControl.MasterTemplate.AllowDeleteRow = false;
            this.rmccDatabase.EditorControl.MasterTemplate.AllowEditRow = false;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "Id";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "colDatabaseID";
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Name";
            gridViewTextBoxColumn8.HeaderText = "Datbase Name";
            gridViewTextBoxColumn8.Name = "colDatabaseName";
            gridViewTextBoxColumn8.Width = 182;
            this.rmccDatabase.EditorControl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.rmccDatabase.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rmccDatabase.EditorControl.MasterTemplate.ShowFilteringRow = false;
            sortDescriptor4.PropertyName = "colTemplateName";
            this.rmccDatabase.EditorControl.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor4});
            this.rmccDatabase.EditorControl.MasterTemplate.ViewDefinition = tableViewDefinition8;
            this.rmccDatabase.EditorControl.Name = "NestedRadGridView";
            this.rmccDatabase.EditorControl.ReadOnly = true;
            this.rmccDatabase.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rmccDatabase.EditorControl.ShowGroupPanel = false;
            this.rmccDatabase.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rmccDatabase.EditorControl.TabIndex = 0;
            this.rmccDatabase.Location = new System.Drawing.Point(76, 30);
            this.rmccDatabase.Name = "rmccDatabase";
            this.rmccDatabase.Size = new System.Drawing.Size(254, 20);
            this.rmccDatabase.TabIndex = 5;
            this.rmccDatabase.TabStop = false;
            this.rmccDatabase.SelectedIndexChanged += new System.EventHandler(this.rmccDatabase_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtExport);
            this.groupBox1.Controls.Add(this.rbtImport);
            this.groupBox1.Location = new System.Drawing.Point(336, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 36);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Utility";
            // 
            // rbtImport
            // 
            this.rbtImport.AutoSize = true;
            this.rbtImport.Location = new System.Drawing.Point(48, 13);
            this.rbtImport.Name = "rbtImport";
            this.rbtImport.Size = new System.Drawing.Size(59, 17);
            this.rbtImport.TabIndex = 0;
            this.rbtImport.Text = "Import";
            this.rbtImport.UseVisualStyleBackColor = true;
            this.rbtImport.CheckedChanged += new System.EventHandler(this.rbtImport_CheckedChanged);
            // 
            // rbtExport
            // 
            this.rbtExport.AutoSize = true;
            this.rbtExport.Checked = true;
            this.rbtExport.Location = new System.Drawing.Point(113, 13);
            this.rbtExport.Name = "rbtExport";
            this.rbtExport.Size = new System.Drawing.Size(58, 17);
            this.rbtExport.TabIndex = 1;
            this.rbtExport.TabStop = true;
            this.rbtExport.Text = "Export";
            this.rbtExport.UseVisualStyleBackColor = true;
            this.rbtExport.CheckedChanged += new System.EventHandler(this.rbtExport_CheckedChanged);
            // 
            // frmTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 434);
            this.Controls.Add(this.radPanel3);
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
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            this.radPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccDatabase.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccDatabase.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccDatabase)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadMultiColumnComboBox rmccDatabase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtExport;
        private System.Windows.Forms.RadioButton rbtImport;
    }
}
