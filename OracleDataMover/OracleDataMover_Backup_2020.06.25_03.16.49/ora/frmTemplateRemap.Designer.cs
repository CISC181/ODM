namespace OracleDataMover.ora
{
    partial class frmTemplateRemap
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.rglTemplateSchema = new Telerik.WinControls.UI.RadLabel();
            this.rmccTemplateSchema = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            this.rlblDatabaseSchemas = new Telerik.WinControls.UI.RadLabel();
            this.radPanel4 = new Telerik.WinControls.UI.RadPanel();
            this.rbClose = new Telerik.WinControls.UI.RadButton();
            this.rbSave = new Telerik.WinControls.UI.RadButton();
            this.rbUndo = new Telerik.WinControls.UI.RadButton();
            this.rgvRemap = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rglTemplateSchema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlblDatabaseSchemas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).BeginInit();
            this.radPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbUndo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvRemap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvRemap.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.rgvRemap);
            this.radPanel1.Controls.Add(this.rlblDatabaseSchemas);
            this.radPanel1.Controls.Add(this.rglTemplateSchema);
            this.radPanel1.Controls.Add(this.rmccTemplateSchema);
            this.radPanel1.Location = new System.Drawing.Point(12, 12);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(453, 402);
            this.radPanel1.TabIndex = 0;
            // 
            // rglTemplateSchema
            // 
            this.rglTemplateSchema.Location = new System.Drawing.Point(3, 3);
            this.rglTemplateSchema.Name = "rglTemplateSchema";
            this.rglTemplateSchema.Size = new System.Drawing.Size(95, 18);
            this.rglTemplateSchema.TabIndex = 4;
            this.rglTemplateSchema.Text = "Template Schema";
            this.rglTemplateSchema.ThemeName = "Office2013Light";
            // 
            // rmccTemplateSchema
            // 
            this.rmccTemplateSchema.DisplayMember = "Name";
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
            this.rmccTemplateSchema.EditorControl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.rmccTemplateSchema.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rmccTemplateSchema.EditorControl.MasterTemplate.ShowFilteringRow = false;
            sortDescriptor1.PropertyName = "colTemplateName";
            this.rmccTemplateSchema.EditorControl.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.rmccTemplateSchema.EditorControl.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rmccTemplateSchema.EditorControl.Name = "NestedRadGridView";
            this.rmccTemplateSchema.EditorControl.ReadOnly = true;
            this.rmccTemplateSchema.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rmccTemplateSchema.EditorControl.ShowGroupPanel = false;
            this.rmccTemplateSchema.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rmccTemplateSchema.EditorControl.TabIndex = 0;
            this.rmccTemplateSchema.Location = new System.Drawing.Point(3, 27);
            this.rmccTemplateSchema.Name = "rmccTemplateSchema";
            this.rmccTemplateSchema.Size = new System.Drawing.Size(426, 20);
            this.rmccTemplateSchema.TabIndex = 3;
            this.rmccTemplateSchema.TabStop = false;
            this.rmccTemplateSchema.SelectedIndexChanged += new System.EventHandler(this.rmccTemplateSchema_SelectedIndexChanged);
            // 
            // rlblDatabaseSchemas
            // 
            this.rlblDatabaseSchemas.Location = new System.Drawing.Point(3, 53);
            this.rlblDatabaseSchemas.Name = "rlblDatabaseSchemas";
            this.rlblDatabaseSchemas.Size = new System.Drawing.Size(88, 18);
            this.rlblDatabaseSchemas.TabIndex = 6;
            this.rlblDatabaseSchemas.Text = "Remap Schemas";
            this.rlblDatabaseSchemas.ThemeName = "Office2013Light";
            // 
            // radPanel4
            // 
            this.radPanel4.Controls.Add(this.rbClose);
            this.radPanel4.Controls.Add(this.rbSave);
            this.radPanel4.Controls.Add(this.rbUndo);
            this.radPanel4.Location = new System.Drawing.Point(15, 420);
            this.radPanel4.Name = "radPanel4";
            this.radPanel4.Size = new System.Drawing.Size(450, 34);
            this.radPanel4.TabIndex = 6;
            // 
            // rbClose
            // 
            this.rbClose.Location = new System.Drawing.Point(316, 3);
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
            // rgvRemap
            // 
            this.rgvRemap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgvRemap.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvRemap.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgvRemap.ForeColor = System.Drawing.Color.Black;
            this.rgvRemap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvRemap.Location = new System.Drawing.Point(6, 77);
            // 
            // 
            // 
            this.rgvRemap.MasterTemplate.EnableAlternatingRowColor = true;
            this.rgvRemap.MasterTemplate.EnableFiltering = true;
            this.rgvRemap.MasterTemplate.EnableGrouping = false;
            this.rgvRemap.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgvRemap.Name = "rgvRemap";
            this.rgvRemap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvRemap.Size = new System.Drawing.Size(423, 322);
            this.rgvRemap.TabIndex = 7;
            this.rgvRemap.CellValidating += new Telerik.WinControls.UI.CellValidatingEventHandler(this.MasterTemplate_CellValidating);
            this.rgvRemap.UserAddedRow += new Telerik.WinControls.UI.GridViewRowEventHandler(this.MasterTemplate_UserAddedRow);
            // 
            // frmTemplateRemap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 471);
            this.Controls.Add(this.radPanel4);
            this.Controls.Add(this.radPanel1);
            this.Name = "frmTemplateRemap";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTemplateRemap";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rglTemplateSchema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlblDatabaseSchemas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).EndInit();
            this.radPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbUndo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvRemap.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvRemap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel rglTemplateSchema;
        private Telerik.WinControls.UI.RadMultiColumnComboBox rmccTemplateSchema;
        private Telerik.WinControls.UI.RadLabel rlblDatabaseSchemas;
        private Telerik.WinControls.UI.RadPanel radPanel4;
        private Telerik.WinControls.UI.RadButton rbClose;
        private Telerik.WinControls.UI.RadButton rbSave;
        private Telerik.WinControls.UI.RadButton rbUndo;
        private Telerik.WinControls.UI.RadGridView rgvRemap;
    }
}
