namespace OracleDataMover.ora
{
    partial class frmTemplateParm
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.rmccCopyFrom = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            this.radPanel4 = new Telerik.WinControls.UI.RadPanel();
            this.rbCopy = new Telerik.WinControls.UI.RadButton();
            this.rbClose = new Telerik.WinControls.UI.RadButton();
            this.rbSave = new Telerik.WinControls.UI.RadButton();
            this.rbUndo = new Telerik.WinControls.UI.RadButton();
            this.rgvTemplateParms = new Telerik.WinControls.UI.RadGridView();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.rglTemplateSchema = new Telerik.WinControls.UI.RadLabel();
            this.rmccTemplateSchema = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccCopyFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccCopyFrom.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccCopyFrom.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).BeginInit();
            this.radPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbUndo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTemplateParms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTemplateParms.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rglTemplateSchema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.rmccCopyFrom);
            this.radPanel1.Controls.Add(this.radPanel4);
            this.radPanel1.Controls.Add(this.rgvTemplateParms);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.rglTemplateSchema);
            this.radPanel1.Controls.Add(this.rmccTemplateSchema);
            this.radPanel1.Location = new System.Drawing.Point(12, 12);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(580, 689);
            this.radPanel1.TabIndex = 0;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(3, 589);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(102, 18);
            this.radLabel2.TabIndex = 11;
            this.radLabel2.Text = "Copy Parms From...";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // rmccCopyFrom
            // 
            this.rmccCopyFrom.DisplayMember = "Name";
            // 
            // rmccCopyFrom.NestedRadGridView
            // 
            this.rmccCopyFrom.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.rmccCopyFrom.EditorControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.rmccCopyFrom.EditorControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rmccCopyFrom.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rmccCopyFrom.EditorControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rmccCopyFrom.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rmccCopyFrom.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.rmccCopyFrom.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.rmccCopyFrom.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.rmccCopyFrom.EditorControl.MasterTemplate.AllowDeleteRow = false;
            this.rmccCopyFrom.EditorControl.MasterTemplate.AllowEditRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colTemplateID";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Name";
            gridViewTextBoxColumn2.HeaderText = "TemplateName";
            gridViewTextBoxColumn2.Name = "colTemplateName";
            gridViewTextBoxColumn2.Width = 151;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "DATABASE_INFO.Name";
            gridViewTextBoxColumn3.HeaderText = "Datbase Name";
            gridViewTextBoxColumn3.Name = "colDatabaseName";
            gridViewTextBoxColumn3.Width = 225;
            this.rmccCopyFrom.EditorControl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.rmccCopyFrom.EditorControl.MasterTemplate.EnableGrouping = false;
            this.rmccCopyFrom.EditorControl.MasterTemplate.ShowFilteringRow = false;
            this.rmccCopyFrom.EditorControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rmccCopyFrom.EditorControl.Name = "NestedRadGridView";
            this.rmccCopyFrom.EditorControl.ReadOnly = true;
            this.rmccCopyFrom.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rmccCopyFrom.EditorControl.ShowGroupPanel = false;
            this.rmccCopyFrom.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.rmccCopyFrom.EditorControl.TabIndex = 0;
            this.rmccCopyFrom.Location = new System.Drawing.Point(3, 614);
            this.rmccCopyFrom.Name = "rmccCopyFrom";
            this.rmccCopyFrom.Size = new System.Drawing.Size(565, 20);
            this.rmccCopyFrom.TabIndex = 10;
            this.rmccCopyFrom.TabStop = false;
            // 
            // radPanel4
            // 
            this.radPanel4.Controls.Add(this.rbCopy);
            this.radPanel4.Controls.Add(this.rbClose);
            this.radPanel4.Controls.Add(this.rbSave);
            this.radPanel4.Controls.Add(this.rbUndo);
            this.radPanel4.Location = new System.Drawing.Point(3, 640);
            this.radPanel4.Name = "radPanel4";
            this.radPanel4.Size = new System.Drawing.Size(565, 34);
            this.radPanel4.TabIndex = 9;
            // 
            // rbCopy
            // 
            this.rbCopy.Location = new System.Drawing.Point(8, 6);
            this.rbCopy.Name = "rbCopy";
            this.rbCopy.Size = new System.Drawing.Size(110, 24);
            this.rbCopy.TabIndex = 1;
            this.rbCopy.Text = "Copy";
            this.rbCopy.ThemeName = "TelerikMetroBlue";
            this.rbCopy.Click += new System.EventHandler(this.rbCopy_Click);
            // 
            // rbClose
            // 
            this.rbClose.Location = new System.Drawing.Point(452, 7);
            this.rbClose.Name = "rbClose";
            this.rbClose.Size = new System.Drawing.Size(110, 24);
            this.rbClose.TabIndex = 2;
            this.rbClose.Text = "Close";
            this.rbClose.ThemeName = "TelerikMetroBlue";
            this.rbClose.Click += new System.EventHandler(this.rbClose_Click);
            // 
            // rbSave
            // 
            this.rbSave.Location = new System.Drawing.Point(245, 7);
            this.rbSave.Name = "rbSave";
            this.rbSave.Size = new System.Drawing.Size(110, 24);
            this.rbSave.TabIndex = 1;
            this.rbSave.Text = "Save";
            this.rbSave.ThemeName = "TelerikMetroBlue";
            this.rbSave.Click += new System.EventHandler(this.rbSave_Click);
            // 
            // rbUndo
            // 
            this.rbUndo.Location = new System.Drawing.Point(129, 7);
            this.rbUndo.Name = "rbUndo";
            this.rbUndo.Size = new System.Drawing.Size(110, 24);
            this.rbUndo.TabIndex = 0;
            this.rbUndo.Text = "Undo";
            this.rbUndo.ThemeName = "TelerikMetroBlue";
            this.rbUndo.Click += new System.EventHandler(this.rbUndo_Click);
            // 
            // rgvTemplateParms
            // 
            this.rgvTemplateParms.Location = new System.Drawing.Point(3, 78);
            // 
            // 
            // 
            this.rgvTemplateParms.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rgvTemplateParms.Name = "rgvTemplateParms";
            this.rgvTemplateParms.Size = new System.Drawing.Size(565, 505);
            this.rgvTemplateParms.TabIndex = 8;
            this.rgvTemplateParms.CellEditorInitialized += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvTemplateParms_CellEditorInitialized);
            this.rgvTemplateParms.UserAddedRow += new Telerik.WinControls.UI.GridViewRowEventHandler(this.rgvTemplateParms_UserAddedRow);
            this.rgvTemplateParms.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvTemplateParms_CellValueChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 54);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(86, 18);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "Template Parms";
            this.radLabel1.ThemeName = "Office2013Light";
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
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Id";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colTemplateID";
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Name";
            gridViewTextBoxColumn5.HeaderText = "TemplateName";
            gridViewTextBoxColumn5.Name = "colTemplateName";
            gridViewTextBoxColumn5.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn5.Width = 151;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "DATABASE_INFO.Name";
            gridViewTextBoxColumn6.HeaderText = "Datbase Name";
            gridViewTextBoxColumn6.Name = "colDatabaseName";
            gridViewTextBoxColumn6.Width = 225;
            this.rmccTemplateSchema.EditorControl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
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
            this.rmccTemplateSchema.Location = new System.Drawing.Point(3, 28);
            this.rmccTemplateSchema.Name = "rmccTemplateSchema";
            this.rmccTemplateSchema.Size = new System.Drawing.Size(492, 20);
            this.rmccTemplateSchema.TabIndex = 3;
            this.rmccTemplateSchema.TabStop = false;
            this.rmccTemplateSchema.SelectedIndexChanged += new System.EventHandler(this.rmccTemplateSchema_SelectedIndexChanged);
            // 
            // frmTemplateParm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 714);
            this.Controls.Add(this.radPanel1);
            this.Name = "frmTemplateParm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTemplateParm";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccCopyFrom.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccCopyFrom.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccCopyFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).EndInit();
            this.radPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbUndo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTemplateParms.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTemplateParms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rglTemplateSchema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmccTemplateSchema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel rglTemplateSchema;
        private Telerik.WinControls.UI.RadMultiColumnComboBox rmccTemplateSchema;
        private Telerik.WinControls.UI.RadGridView rgvTemplateParms;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadPanel radPanel4;
        private Telerik.WinControls.UI.RadButton rbClose;
        private Telerik.WinControls.UI.RadButton rbSave;
        private Telerik.WinControls.UI.RadButton rbUndo;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadMultiColumnComboBox rmccCopyFrom;
        private Telerik.WinControls.UI.RadButton rbCopy;
    }
}
