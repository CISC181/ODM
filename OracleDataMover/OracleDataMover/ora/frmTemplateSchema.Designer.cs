namespace OracleDataMover.ora
{
    partial class frmTemplateSchema
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.rglTemplateSchema = new Telerik.WinControls.UI.RadLabel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.cmdAutoSanitizeSchema = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.rgvSchemaSanitize = new Telerik.WinControls.UI.RadGridView();
            this.radPanel4 = new Telerik.WinControls.UI.RadPanel();
            this.rbClose = new Telerik.WinControls.UI.RadButton();
            this.rbSave = new Telerik.WinControls.UI.RadButton();
            this.rbUndo = new Telerik.WinControls.UI.RadButton();
            this.rlblTableSample = new Telerik.WinControls.UI.RadLabel();
            this.rgvTableSample = new Telerik.WinControls.UI.RadGridView();
            this.rlblDatabaseSchemas = new Telerik.WinControls.UI.RadLabel();
            this.rlcbScheams = new Telerik.WinControls.UI.RadCheckedListBox();
            this.rmccTemplateSchema = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rglTemplateSchema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAutoSanitizeSchema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSchemaSanitize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSchemaSanitize.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).BeginInit();
            this.radPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbUndo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlblTableSample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTableSample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTableSample.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlblDatabaseSchemas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlcbScheams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.rglTemplateSchema);
            this.radPanel1.Controls.Add(this.radPanel2);
            this.radPanel1.Controls.Add(this.rmccTemplateSchema);
            this.radPanel1.Location = new System.Drawing.Point(12, 12);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1193, 742);
            this.radPanel1.TabIndex = 3;
            // 
            // rglTemplateSchema
            // 
            this.rglTemplateSchema.Location = new System.Drawing.Point(19, 3);
            this.rglTemplateSchema.Name = "rglTemplateSchema";
            this.rglTemplateSchema.Size = new System.Drawing.Size(95, 18);
            this.rglTemplateSchema.TabIndex = 2;
            this.rglTemplateSchema.Text = "Template Schema";
            this.rglTemplateSchema.ThemeName = "Office2013Light";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radPanel3);
            this.radPanel2.Controls.Add(this.radLabel1);
            this.radPanel2.Controls.Add(this.rgvSchemaSanitize);
            this.radPanel2.Controls.Add(this.radPanel4);
            this.radPanel2.Controls.Add(this.rlblTableSample);
            this.radPanel2.Controls.Add(this.rgvTableSample);
            this.radPanel2.Controls.Add(this.rlblDatabaseSchemas);
            this.radPanel2.Controls.Add(this.rlcbScheams);
            this.radPanel2.Location = new System.Drawing.Point(15, 54);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1175, 670);
            this.radPanel2.TabIndex = 1;
            // 
            // radPanel3
            // 
            this.radPanel3.Controls.Add(this.cmdAutoSanitizeSchema);
            this.radPanel3.Location = new System.Drawing.Point(7, 343);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(398, 34);
            this.radPanel3.TabIndex = 6;
            // 
            // cmdAutoSanitizeSchema
            // 
            this.cmdAutoSanitizeSchema.Location = new System.Drawing.Point(3, 3);
            this.cmdAutoSanitizeSchema.Name = "cmdAutoSanitizeSchema";
            this.cmdAutoSanitizeSchema.Size = new System.Drawing.Size(182, 24);
            this.cmdAutoSanitizeSchema.TabIndex = 0;
            this.cmdAutoSanitizeSchema.Text = "Auto Sanitize Schema";
            this.cmdAutoSanitizeSchema.ThemeName = "TelerikMetroBlue";
            this.cmdAutoSanitizeSchema.Click += new System.EventHandler(this.cmdAutoSanitizeSchema_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(423, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(87, 18);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "Schema Sanitize";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // rgvSchemaSanitize
            // 
            this.rgvSchemaSanitize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgvSchemaSanitize.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvSchemaSanitize.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgvSchemaSanitize.ForeColor = System.Drawing.Color.Black;
            this.rgvSchemaSanitize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvSchemaSanitize.Location = new System.Drawing.Point(423, 28);
            // 
            // 
            // 
            this.rgvSchemaSanitize.MasterTemplate.EnableFiltering = true;
            this.rgvSchemaSanitize.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgvSchemaSanitize.Name = "rgvSchemaSanitize";
            this.rgvSchemaSanitize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvSchemaSanitize.ShowGroupPanel = false;
            this.rgvSchemaSanitize.Size = new System.Drawing.Size(749, 599);
            this.rgvSchemaSanitize.TabIndex = 7;
            this.rgvSchemaSanitize.CellEditorInitialized += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvSchemaSanitize_CellEditorInitialized);
            this.rgvSchemaSanitize.UserAddedRow += new Telerik.WinControls.UI.GridViewRowEventHandler(this.rgvSchemaSanitize_UserAddedRow);
            // 
            // radPanel4
            // 
            this.radPanel4.Controls.Add(this.rbClose);
            this.radPanel4.Controls.Add(this.rbSave);
            this.radPanel4.Controls.Add(this.rbUndo);
            this.radPanel4.Location = new System.Drawing.Point(4, 633);
            this.radPanel4.Name = "radPanel4";
            this.radPanel4.Size = new System.Drawing.Size(382, 34);
            this.radPanel4.TabIndex = 5;
            // 
            // rbClose
            // 
            this.rbClose.Location = new System.Drawing.Point(269, 3);
            this.rbClose.Name = "rbClose";
            this.rbClose.Size = new System.Drawing.Size(110, 24);
            this.rbClose.TabIndex = 2;
            this.rbClose.Text = "Close";
            this.rbClose.ThemeName = "TelerikMetroBlue";
            this.rbClose.Click += new System.EventHandler(this.rbClose_Click);
            // 
            // rbSave
            // 
            this.rbSave.Location = new System.Drawing.Point(119, 3);
            this.rbSave.Name = "rbSave";
            this.rbSave.Size = new System.Drawing.Size(110, 24);
            this.rbSave.TabIndex = 1;
            this.rbSave.Text = "Save";
            this.rbSave.ThemeName = "TelerikMetroBlue";
            this.rbSave.Click += new System.EventHandler(this.rbSave_Click);
            // 
            // rbUndo
            // 
            this.rbUndo.Location = new System.Drawing.Point(3, 3);
            this.rbUndo.Name = "rbUndo";
            this.rbUndo.Size = new System.Drawing.Size(110, 24);
            this.rbUndo.TabIndex = 0;
            this.rbUndo.Text = "Undo";
            this.rbUndo.ThemeName = "TelerikMetroBlue";
            this.rbUndo.Click += new System.EventHandler(this.rbUndo_Click);
            // 
            // rlblTableSample
            // 
            this.rlblTableSample.Location = new System.Drawing.Point(3, 383);
            this.rlblTableSample.Name = "rlblTableSample";
            this.rlblTableSample.Size = new System.Drawing.Size(104, 18);
            this.rlblTableSample.TabIndex = 4;
            this.rlblTableSample.Text = "Schema Sample Pct";
            this.rlblTableSample.ThemeName = "Office2013Light";
            // 
            // rgvTableSample
            // 
            this.rgvTableSample.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgvTableSample.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvTableSample.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgvTableSample.ForeColor = System.Drawing.Color.Black;
            this.rgvTableSample.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvTableSample.Location = new System.Drawing.Point(4, 407);
            // 
            // 
            // 
            this.rgvTableSample.MasterTemplate.EnableFiltering = true;
            this.rgvTableSample.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rgvTableSample.Name = "rgvTableSample";
            this.rgvTableSample.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvTableSample.ShowGroupPanel = false;
            this.rgvTableSample.Size = new System.Drawing.Size(401, 220);
            this.rgvTableSample.TabIndex = 4;
            this.rgvTableSample.UserAddedRow += new Telerik.WinControls.UI.GridViewRowEventHandler(this.rgvTableSample_UserAddedRow);
            // 
            // rlblDatabaseSchemas
            // 
            this.rlblDatabaseSchemas.Location = new System.Drawing.Point(4, 3);
            this.rlblDatabaseSchemas.Name = "rlblDatabaseSchemas";
            this.rlblDatabaseSchemas.Size = new System.Drawing.Size(50, 18);
            this.rlblDatabaseSchemas.TabIndex = 3;
            this.rlblDatabaseSchemas.Text = "Scheams";
            this.rlblDatabaseSchemas.ThemeName = "Office2013Light";
            // 
            // rlcbScheams
            // 
            this.rlcbScheams.CheckedMember = "SchemaChecked";
            this.rlcbScheams.DisplayMember = "SchemaName";
            this.rlcbScheams.EnableFiltering = true;
            this.rlcbScheams.Location = new System.Drawing.Point(4, 28);
            this.rlcbScheams.Name = "rlcbScheams";
            this.rlcbScheams.Size = new System.Drawing.Size(401, 306);
            this.rlcbScheams.TabIndex = 0;
            this.rlcbScheams.ValueMember = "SchemaName";
            this.rlcbScheams.SelectedItemChanged += new System.EventHandler(this.rlcbScheams_SelectedItemChanged);
            this.rlcbScheams.ItemCheckedChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.rlcbScheams_ItemCheckedChanged);
            // 
            // rmccTemplateSchema
            // 
            this.rmccTemplateSchema.DisplayMember = "Name";
            this.rmccTemplateSchema.DropDownMinSize = new System.Drawing.Size(0, 100);
            // 
            // rmccTemplateSchema.NestedRadGridView
            // 
            this.rmccTemplateSchema.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rmccTemplateSchema.EditorControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.rmccTemplateSchema.EditorControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rmccTemplateSchema.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rmccTemplateSchema.EditorControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rmccTemplateSchema.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rmccTemplateSchema.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rmccTemplateSchema.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rmccTemplateSchema.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rmccTemplateSchema.EditorControl.MasterTemplate.AllowDeleteRow = false;
            this.rmccTemplateSchema.EditorControl.MasterTemplate.AllowEditRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colTemplateID";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Name";
            gridViewTextBoxColumn2.HeaderText = "TemplateName";
            gridViewTextBoxColumn2.Name = "colTemplateName";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn2.Width = 151;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "DATABASE_INFO.Name";
            gridViewTextBoxColumn3.HeaderText = "Datbase Name";
            gridViewTextBoxColumn3.Name = "colDatabaseName";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 225;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "DATABASE_INFO.TnsName";
            gridViewTextBoxColumn4.HeaderText = "TNSName";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colTNSName";
            this.rmccTemplateSchema.EditorControl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.rmccTemplateSchema.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rmccTemplateSchema.EditorControl.MasterTemplate.ShowFilteringRow = false;
            sortDescriptor1.PropertyName = "colTemplateName";
            this.rmccTemplateSchema.EditorControl.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.rmccTemplateSchema.EditorControl.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.rmccTemplateSchema.EditorControl.Name = "NestedRadGridView";
            this.rmccTemplateSchema.EditorControl.ReadOnly = true;
            this.rmccTemplateSchema.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rmccTemplateSchema.EditorControl.ShowGroupPanel = false;
            this.rmccTemplateSchema.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rmccTemplateSchema.EditorControl.TabIndex = 0;
            this.rmccTemplateSchema.Location = new System.Drawing.Point(19, 28);
            this.rmccTemplateSchema.Name = "rmccTemplateSchema";
            this.rmccTemplateSchema.Size = new System.Drawing.Size(426, 20);
            this.rmccTemplateSchema.TabIndex = 0;
            this.rmccTemplateSchema.TabStop = false;
            this.rmccTemplateSchema.SelectedIndexChanged += new System.EventHandler(this.rmccTemplateSchema_SelectedIndexChanged);
            // 
            // frmTemplateSchema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 755);
            this.Controls.Add(this.radPanel1);
            this.Name = "frmTemplateSchema";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTemplateSchema";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rglTemplateSchema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmdAutoSanitizeSchema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSchemaSanitize.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSchemaSanitize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).EndInit();
            this.radPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbUndo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlblTableSample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTableSample.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTableSample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlblDatabaseSchemas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlcbScheams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel rglTemplateSchema;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadLabel rlblTableSample;
        private Telerik.WinControls.UI.RadGridView rgvTableSample;
        private Telerik.WinControls.UI.RadLabel rlblDatabaseSchemas;
        private Telerik.WinControls.UI.RadCheckedListBox rlcbScheams;
        private Telerik.WinControls.UI.RadMultiColumnComboBox rmccTemplateSchema;
        private Telerik.WinControls.UI.RadButton rbClose;
        private Telerik.WinControls.UI.RadButton rbSave;
        private Telerik.WinControls.UI.RadButton rbUndo;
        private Telerik.WinControls.UI.RadPanel radPanel4;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGridView rgvSchemaSanitize;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private Telerik.WinControls.UI.RadButton cmdAutoSanitizeSchema;
    }
}
