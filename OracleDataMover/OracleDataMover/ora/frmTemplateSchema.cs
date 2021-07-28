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
using OracleDataMoverBLL.Common;
using System.Configuration;

namespace OracleDataMover.ora
{
    public partial class frmTemplateSchema : Telerik.WinControls.UI.RadForm
    {
        private Boolean isLoading;
        protected static OraDataContext ContextOra = null;
        private List<ALL_CONSTRAINTS> lstConstraints = null;
        private List<ALL_CONS_COLUMNS> lstAllConsCols = null;
        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), Utility.UserName);
        private MainForm MF;

        public MainForm MF1 { get => MF; set => MF = value; }
        public frmTemplateSchema()
        {
            InitializeComponent();
            LoadForm();
        }

        /// <summary>
        /// Load the form
        /// </summary>
        private void LoadForm()
        {
            isLoading = true;
            LoadrmccTemplateSchema();
            rlcbScheams.Items.Clear();
            rgvTableSample.Columns.Clear();
            isLoading = false;
        }

        /// <summary>
        /// Load the Template Column Combo Box
        /// </summary>
        private void LoadrmccTemplateSchema()
        {
            List<Template> lstTemplate = Context.TemplateRepository.FindBy(x => true).Where(x=> x.ORA_UTILITY.UtilityName=="EXPDP").ToList();
            this.rmccTemplateSchema.DataSource = lstTemplate;
        }

        private void rmccTemplateSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!isLoading && this.rmccTemplateSchema.SelectedIndex > -1))
            {
                if (this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colDatabaseName"] != null)
                {

                    String strDatabaseName = this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colDatabaseName"].Value.ToString();
                    String strTemplateID = this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colTemplateID"].Value.ToString();
                    string strTNSName = this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colTNSName"].Value.ToString();

                    String connBuilder = ConfigurationManager.AppSettings["OracleConnectionStringTemplate"];
                    connBuilder = connBuilder.Replace("ODM_Database", strTNSName);

                    ContextOra = new OraDataContext(new OraEntities(connBuilder), Utility.UserName);

                    //ContextOra = new OraDataContext(new OraEntities(strDatabaseName), Utility.UserName);
                    LoadrlcbScheams(strTemplateID, strDatabaseName, strTNSName);

                }
            }
        }

        /// <summary>
        /// Load the Schema checked list box
        /// </summary>
        /// <param name="strTemplateID"></param>
        /// <param name="strDatabaseName"></param>
        private void LoadrlcbScheams(string strTemplateID, string strDatabaseName, string strTNSName)
        {
            rlcbScheams.Items.Clear();
            rlblDatabaseSchemas.Text = "Non-Oracle Scheams for Database: " + strDatabaseName;
            isLoading = true;





            List<ALL_USERS> lstUsers = ContextOra.ALL_USERSRepository
                    .FindBy(x => x.ORACLE_MAINTAINED == "N")
                    .OrderBy(x => x.USERNAME).ToList();

            List<TemplateSchema> lstTemplateSchema = Context.TemplateSchemaRepository
                .FindBy(x => x.TemplateId == strTemplateID).ToList();

            foreach (ALL_USERS u in lstUsers)
            {
                ListViewDataItem ldi = new ListViewDataItem();
                ldi.Value = u.USERNAME;
                ldi.Tag = string.Empty;

                if (lstTemplateSchema.Where(x => x.SchemaName == u.USERNAME).Count() > 0)
                {
                    ldi.CheckState = ToggleState.On;
                    ldi.BackColor = Color.LightBlue;
                    ldi.Tag = lstTemplateSchema.Where(x => x.SchemaName == u.USERNAME).FirstOrDefault().Id;
                }
                else
                {
                    ldi.CheckState = ToggleState.Off;
                    ldi.BackColor = Color.White;
                }
                ldi.Text = u.USERNAME;
                rlcbScheams.Items.Add(ldi);
            }
            rlcbScheams.SelectedIndex = 0;
            rlcbScheams.SelectedItem = null;
            isLoading = false;
        }

        private void rlcbScheams_SelectedItemChanged(object sender, EventArgs e)
        {
            ListViewDataItem item = rlcbScheams.SelectedItem;

            if (!isLoading)
            {
                if ((item != null) && (item.CheckState == ToggleState.On))
                {
                    LoadDatabaseConstraints(rlcbScheams.SelectedItem.Text);
                    LoadGridrgvTableSample();
                    LoadrgvSchemaSanitize();
                }
                else
                {
                    rgvTableSample.Columns.Clear();
                    rgvSchemaSanitize.Columns.Clear();
                }

            }
        }
        private void LoadDatabaseConstraints(string strOwner)
        {
            lstConstraints = ContextOra.ALL_CONSTRAINTSRepository
                .FindBy(x => x.OWNER == strOwner).ToList();

            lstAllConsCols = ContextOra.ALL_CONS_COLUMNSRepository
                .FindBy(x => x.OWNER == strOwner).ToList();
        }
        private void LoadGridrgvTableSample()
        {
            LoadGridLayout_rgvTableSample();
            LoadGridData_rgvTableSample();
        }

        private void LoadrgvSchemaSanitize()
        {
            LoadGridLayout_rgvSchemaSanitize();
            LoadGridData_rgvSchemaSanitize();
        }

        private void LoadGridLayout_rgvTableSample()
        {
            rgvTableSample.Columns.Clear();
            ListViewDataItem ldi = rlcbScheams.SelectedItem;
            if (ldi == null)
                return;
            if (isLoading)
                return;

            if (ldi.CheckState == ToggleState.Off)
            {
                rgvTableSample.Enabled = false;
                return;
            }
            rgvTableSample.Enabled = true;

            GridViewDataRowInfo gvdri = (GridViewDataRowInfo)rmccTemplateSchema.SelectedItem;
            String strDatabaseName = gvdri.Cells["colDatabaseName"].Value.ToString();

            //OraDataContext ContextOra = new OraDataContext(new OraEntities(strDatabaseName), Utility.UserName);

            List<ALL_TABLES> lstAllTables = ContextOra.ALL_TABLESRepository
                .FindBy(x => x.OWNER == ldi.Value.ToString()).OrderBy(x => x.TABLE_NAME).ToList();

            GridViewCommandColumn commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "colDelete";
            commandColumn.UseDefaultText = true;
            commandColumn.DefaultText = "Delete";
            commandColumn.FieldName = "ID";
            rgvTableSample.MasterTemplate.Columns.Add(commandColumn);
            rgvTableSample.CommandCellClick += new
            CommandCellClickEventHandler(rgvTableSample_CommandCellClick);

            GridViewTextBoxColumn gtbTemplateID = new GridViewTextBoxColumn();
            gtbTemplateID.EnableExpressionEditor = false;
            gtbTemplateID.FieldName = "Id";
            gtbTemplateID.HeaderText = "TemplateSchemaTableID";
            gtbTemplateID.Name = "colTemplateSchemaTableID";
            gtbTemplateID.IsVisible = false;
            this.rgvTableSample.Columns.Add(gtbTemplateID);

            GridViewTextBoxColumn gtbTemplateSchemaID = new GridViewTextBoxColumn();
            gtbTemplateSchemaID.EnableExpressionEditor = false;
            gtbTemplateSchemaID.FieldName = "TemplateSchemaId";
            gtbTemplateSchemaID.HeaderText = "TemplateSchemaId";
            gtbTemplateSchemaID.Name = "colTemplateSchmeaID";
            gtbTemplateSchemaID.IsVisible = false;
            this.rgvTableSample.Columns.Add(gtbTemplateSchemaID);

            GridViewComboBoxColumn colTableName = new GridViewComboBoxColumn();
            colTableName.Name = "colTableName";
            colTableName.HeaderText = "Table Name";
            colTableName.DataSource = lstAllTables;
            colTableName.ValueMember = "TABLE_NAME";
            colTableName.DisplayMember = "TABLE_NAME";
            colTableName.FieldName = "TableName";
            colTableName.Width = 200;
            this.rgvTableSample.Columns.Add(colTableName);

            GridViewDecimalColumn gtbSample = new GridViewDecimalColumn();
            gtbSample.EnableExpressionEditor = false;
            gtbSample.FieldName = "SampleSize";
            gtbSample.HeaderText = "Sample Size";
            gtbSample.Name = "colSampleSize";
            gtbSample.Width = 75;
            gtbSample.Minimum = (Decimal)0.000001;
            gtbSample.Maximum = (Decimal)100.0;
            this.rgvTableSample.Columns.Add(gtbSample);
        }


        private void rgvTableSample_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gce = (GridCommandCellElement)sender;
            if (gce.Value != null)
            {
                var TemplateSchemaTableID = ((sender as GridCommandCellElement)).Value.ToString();
                TemplateSchemaTable tst = Context.TemplateSchemaTableRepository
                    .FindBy(x => x.Id == TemplateSchemaTableID).FirstOrDefault();
                Context.TemplateSchemaTableRepository.Delete(tst);

                if (this.rgvTableSample.CurrentRow is GridViewDataRowInfo)
                    this.rgvTableSample.Rows.Remove(((GridViewDataRowInfo)this.rgvTableSample.CurrentRow));
            }


        }

        private void LoadGridData_rgvTableSample()
        {
            ListViewDataItem ldi = rlcbScheams.SelectedItem;
            if (ldi == null)
                return;
            if (isLoading)
                return;

            List<TemplateSchemaTable> lstTST = Context.TemplateSchemaTableRepository
                .FindBy(x => x.TemplateSchemaId == ldi.Tag.ToString())
                .ToList();
            rgvTableSample.DataSource = lstTST;
        }

        private void LoadGridLayout_rgvSchemaSanitize()
        {
            rgvSchemaSanitize.Columns.Clear();
            ListViewDataItem ldi = rlcbScheams.SelectedItem;
            if (ldi == null)
                return;
            if (isLoading)
                return;

            rgvSchemaSanitize.Enabled = true;

            GridViewDataRowInfo gvdri = (GridViewDataRowInfo)rmccTemplateSchema.SelectedItem;
            String strDatabaseName = gvdri.Cells["colDatabaseName"].Value.ToString();
            List<ALL_TABLES> lstAllTables = ContextOra.ALL_TABLESRepository
                .FindBy(x => x.OWNER == ldi.Value.ToString()).OrderBy(x => x.TABLE_NAME).ToList();

            List<RemapFunction> lstRemap = Context.RemapFunctionRepository.FindBy(x => true).ToList();

            GridViewCommandColumn commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "colDelete";
            commandColumn.UseDefaultText = true;
            commandColumn.DefaultText = "Delete";
            commandColumn.FieldName = "ID";
            rgvSchemaSanitize.MasterTemplate.Columns.Add(commandColumn);
            rgvSchemaSanitize.CommandCellClick += new
                CommandCellClickEventHandler(rgvSanitize_CommandCellClick);

            GridViewTextBoxColumn gtbTemplateSchemaSanitize = new GridViewTextBoxColumn();
            gtbTemplateSchemaSanitize.EnableExpressionEditor = false;
            gtbTemplateSchemaSanitize.FieldName = "Id";
            gtbTemplateSchemaSanitize.HeaderText = "TemplateSchemaSanitizeId";
            gtbTemplateSchemaSanitize.Name = "colTemplateSchemaSanitizeId";
            gtbTemplateSchemaSanitize.IsVisible = false;
            this.rgvSchemaSanitize.Columns.Add(gtbTemplateSchemaSanitize);

            GridViewTextBoxColumn gtbTemplateSchemaId = new GridViewTextBoxColumn();
            gtbTemplateSchemaId.EnableExpressionEditor = false;
            gtbTemplateSchemaId.FieldName = "TemplateSchemaId";
            gtbTemplateSchemaId.HeaderText = "TemplateSchemaId";
            gtbTemplateSchemaId.Name = "colTemplateSchemaId";
            gtbTemplateSchemaId.IsVisible = false;
            this.rgvSchemaSanitize.Columns.Add(gtbTemplateSchemaId);

            GridViewComboBoxColumn colTableName = new GridViewComboBoxColumn();
            colTableName.Name = "colTableName";
            colTableName.HeaderText = "Table Name";
            colTableName.DataSource = lstAllTables;
            colTableName.ValueMember = "TABLE_NAME";
            colTableName.DisplayMember = "TABLE_NAME";
            colTableName.FieldName = "TableName";
            colTableName.Width = 275;
            this.rgvSchemaSanitize.Columns.Add(colTableName);

            GridViewComboBoxColumn colColumnName = new GridViewComboBoxColumn();
            colColumnName.Name = "colColumnName";
            colColumnName.HeaderText = "Column Name";
            colColumnName.ValueMember = "COLUMN_NAME";
            colColumnName.DisplayMember = "COLUMN_NAME";
            colColumnName.FieldName = "ColumnName";
            colColumnName.Width = 275;
            this.rgvSchemaSanitize.Columns.Add(colColumnName);

            GridViewComboBoxColumn colFunctionName = new GridViewComboBoxColumn();
            colFunctionName.Name = "colFunctionName";
            colFunctionName.HeaderText = "Function Name";
            colFunctionName.DataSource = lstRemap;
            colFunctionName.ValueMember = "Id";
            colFunctionName.DisplayMember = "FunctionName";
            colFunctionName.FieldName = "FunctionId";
            colFunctionName.Width = 100;
            this.rgvSchemaSanitize.Columns.Add(colFunctionName);
        }

        private void rgvSanitize_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gce = (GridCommandCellElement)sender;
            if (gce.Value != null)
            {
                var TemplateSchemaSanitizeID = ((sender as GridCommandCellElement)).Value.ToString();
                TemplateSchemaSanitize tst = Context.TemplateSchemaSanitizeRepository
                    .FindBy(x => x.Id == TemplateSchemaSanitizeID).FirstOrDefault();
                Context.TemplateSchemaSanitizeRepository.Delete(tst);

                if (this.rgvSchemaSanitize.CurrentRow is GridViewDataRowInfo)
                    this.rgvSchemaSanitize.Rows.Remove(((GridViewDataRowInfo)this.rgvSchemaSanitize.CurrentRow));
            }
        }

        private void LoadGridData_rgvSchemaSanitize()
        {
            ListViewDataItem ldi = rlcbScheams.SelectedItem;
            if (ldi == null)
                return;
            if (isLoading)
                return;

            List<TemplateSchemaSanitize> lstTST = Context.TemplateSchemaSanitizeRepository
                .FindBy(x => x.TemplateSchemaId == ldi.Tag.ToString())
                .OrderBy(X=>X.TEMPLATE_SCHEMA.SchemaName)
                .ThenBy(X=>X.TableName)
                .ThenBy(X=>X.ColumnName)
                .ToList();

            rgvSchemaSanitize.DataSource = lstTST;
        }

        private void rgvSchemaSanitize_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            GridViewDataRowInfo gvdri = (GridViewDataRowInfo)rmccTemplateSchema.SelectedItem;
            String strDatabaseName = gvdri.Cells["colDatabaseName"].Value.ToString();

            //OraDataContext ContextOra = new OraDataContext(new OraEntities(strDatabaseName), Utility.UserName);
            ListViewDataItem ldi = rlcbScheams.SelectedItem;
            if (ldi == null)
                return;
            if (isLoading)
                return;

            if (e.Column.HeaderText == "Column Name")
            {
                if (this.rgvSchemaSanitize.CurrentRow.Cells["colTableName"].Value != DBNull.Value
     && this.rgvSchemaSanitize.CurrentRow.Cells["colTableName"].Value != null)
                {
                    RadDropDownListEditor editor = (RadDropDownListEditor)this.rgvSchemaSanitize.ActiveEditor;
                    RadDropDownListEditorElement editorElement = (RadDropDownListEditorElement)editor.EditorElement;
                    string strTableName = this.rgvSchemaSanitize.CurrentRow.Cells["colTableName"].Value.ToString();

                    List<ALL_TAB_COLS> lstColumns = ContextOra.ALL_TAB_COLSRepository
                        .FindBy(x => x.OWNER == ldi.Value.ToString())
                        .Where(x => x.TABLE_NAME == strTableName)
                        .OrderBy(x => x.TABLE_NAME).OrderBy(x => x.COLUMN_ID).ToList();

                    foreach (ALL_TAB_COLS atc in lstColumns)
                    {
                        RadListDataItem rldi = new RadListDataItem();
                        rldi.Enabled = !DoesConstraintExist(ldi.Value.ToString(), strTableName, atc.COLUMN_NAME);
                        if (DoesCheckConstraintExist(ldi.Value.ToString(), strTableName, atc.COLUMN_NAME))
                        {
                            rldi.ForeColor = System.Drawing.Color.Red;
                        }


                        rldi.Text = atc.COLUMN_NAME;
                        rldi.Value = atc.COLUMN_NAME;
                        editorElement.Items.Add(rldi);
                    }

                    editorElement.SelectedValue = null;
                    editorElement.SelectedValue = this.rgvSchemaSanitize.CurrentCell.Value;
                }
            }
        }




        private void rlcbScheams_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem ldi = (ListViewDataItem)e.Item;
            this.rlcbScheams.SelectedItem = ldi;
            if (ldi.CheckState == ToggleState.On)
            {
                ldi.BackColor = Color.LightBlue;
                if (ldi.Tag.ToString() == string.Empty)
                {
                    TemplateSchema ts = new TemplateSchema();
                    ts.SchemaName = ldi.Text;
                    ts.TemplateId = this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colTemplateID"].Value.ToString();
                    Context.TemplateSchemaRepository.Save(ts);
                    Context.Commit();
                    ldi.Tag = ts.Id;
                    rgvTableSample.Enabled = true;
                }
            }
            else
            {
                var confirmResult = MessageBox.Show("Unchecking this schema will delete all the schema settings.  Continue?", "Confirm",
                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.No)
                {
                    ldi.CheckState = ToggleState.On;
                    return;
                }
                TemplateSchema ts = Context.TemplateSchemaRepository.FindBy(x => x.Id == ldi.Tag.ToString()).FirstOrDefault();
                if (ts != null)
                {
                    List<TemplateSchemaSanitize> lstTemplateSanitize = Context.TemplateSchemaSanitizeRepository.FindBy(x => x.TemplateSchemaId == ldi.Tag.ToString()).ToList();
                    foreach (TemplateSchemaSanitize tss in lstTemplateSanitize)
                    {
                        Context.TemplateSchemaSanitizeRepository.Delete(tss);
                    }

                    List<TemplateSchemaTable> lstTemplateScheamTable = Context.TemplateSchemaTableRepository.FindBy(x => x.TemplateSchemaId == ldi.Tag.ToString()).ToList();
                    foreach (TemplateSchemaTable tst in lstTemplateScheamTable)
                    {
                        Context.TemplateSchemaTableRepository.Delete(tst);
                    }

                    ldi.Tag = string.Empty;
                    ldi.BackColor = Color.White;
                    Context.TemplateSchemaRepository.Delete(ts);
                    Context.Commit();
                }

                rgvTableSample.Enabled = false;
            }
            rlcbScheams_SelectedItemChanged(null, null);
        }

        private void rbUndo_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to undo all changes?", "Confirm",
             MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Context.Rollback();
                LoadGridrgvTableSample();
                LoadGridData_rgvSchemaSanitize();
            }
        }

        private void rbSave_Click(object sender, EventArgs e)
        {
            Context.Commit();
        }

        private void rgvTableSample_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            ListViewDataItem ldi = rlcbScheams.SelectedItem;
            if (ldi == null)
                return;
            if (isLoading)
                return;

            foreach (GridViewDataRowInfo dataRow in this.GetAllRows(this.rgvTableSample.MasterTemplate))
            {
                TemplateSchemaTable tsi = (TemplateSchemaTable)dataRow.DataBoundItem;
                var cell = dataRow.Cells["colTemplateSchemaTableID"].Value;
                if (cell == null)
                {
                    TemplateSchemaTable tst = new TemplateSchemaTable();
                    String strTemplateSchemaTable = Regex.Replace(Guid.NewGuid().ToString().ToUpper(), "[-]", "");
                    tst.Id = strTemplateSchemaTable;
                    tst.TemplateSchemaId = ldi.Tag.ToString();
                    if ((dataRow.Cells["colSampleSize"].Value == null) || (double.Parse(dataRow.Cells["colSampleSize"].Value.ToString()) == 0))
                        tst.SampleSize = (Decimal)0.00001;
                    else
                        tst.SampleSize = decimal.Parse(dataRow.Cells["colSampleSize"].Value.ToString());

                    tst.TableName = dataRow.Cells["colTableName"].Value.ToString();
                    dataRow.Cells["colTemplateSchemaTableID"].Value = strTemplateSchemaTable;
                    dataRow.Cells["colTemplateSchmeaID"].Value = ldi.Tag.ToString();
                    dataRow.Cells["colSampleSize"].Value = tst.SampleSize;

                    Context.TemplateSchemaTableRepository.Save(tst);
                    dataRow.Tag = string.Empty;
                }
            }
        }
        private List<GridViewRowInfo> GetAllRows(GridViewTemplate template)
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
            MF.LoadGridData();
            this.Hide();
        }
        private Boolean DoesConstraintExist(string strOwner, string strTableName, string strColumnName)
        {
            var query = from c in lstConstraints
                        join o in lstAllConsCols on c.CONSTRAINT_NAME equals o.CONSTRAINT_NAME
                        where c.OWNER == strOwner
                        where c.TABLE_NAME == strTableName
                        where o.COLUMN_NAME == strColumnName
                        where c.CONSTRAINT_TYPE == "P" || c.CONSTRAINT_TYPE == "R"
                        select new { c.CONSTRAINT_NAME, c.CONSTRAINT_TYPE, c.TABLE_NAME, o.COLUMN_NAME };

            if (query.Count() > 0)
                return true;
            return false;
        }

        private Boolean DoesCheckConstraintExist(string strOwner, string strTableName, string strColumnName)
        {
            var query = from c in lstConstraints
                        join o in lstAllConsCols on c.CONSTRAINT_NAME equals o.CONSTRAINT_NAME
                        where c.OWNER == strOwner
                        where c.TABLE_NAME == strTableName
                        where o.COLUMN_NAME == strColumnName
                        where c.CONSTRAINT_TYPE == "C"
                        select new { c.CONSTRAINT_NAME, c.CONSTRAINT_TYPE, c.TABLE_NAME, o.COLUMN_NAME };

            if (query.Count() > 0)
                return true;
            return false;
        }

        private void rgvSchemaSanitize_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            MasterGridViewTemplate mgvt = (MasterGridViewTemplate)sender;

            ListViewDataItem ldi = rlcbScheams.SelectedItem;
            if (ldi == null)
                return;
            if (isLoading)
                return;

            foreach (GridViewDataRowInfo dataRow in this.GetAllRows(this.rgvSchemaSanitize.MasterTemplate))
            {
                TemplateSchemaSanitize tsi = (TemplateSchemaSanitize)dataRow.DataBoundItem;

                var cell = dataRow.Cells["colTemplateSchemaSanitizeId"].Value;

                if (cell == null)
                {
                    TemplateSchemaSanitize tst = new TemplateSchemaSanitize();
                    String strcolTemplateSchemaSanitizeId = Regex.Replace(Guid.NewGuid().ToString().ToUpper(), "[-]", "");
                    tst.Id = strcolTemplateSchemaSanitizeId;
                    dataRow.Cells["colTemplateSchemaSanitizeId"].Value = tst.Id;
                    tst.ColumnName = tsi.ColumnName;
                    tst.FunctionId = tsi.FunctionId;
                    tst.TableName = tsi.TableName;
                    tst.TemplateSchemaId = ldi.Tag.ToString();
                    Context.TemplateSchemaSanitizeRepository.Save(tst);
                    dataRow.Tag = string.Empty;
                }
            }
        }

        private void cmdAutoSanitizeSchema_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to auto-sanitize each available column?", "Confirm",
                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                GridViewDataRowInfo gvdri = (GridViewDataRowInfo)rmccTemplateSchema.SelectedItem;
                String strTemplateID = gvdri.Cells["colTemplateID"].Value.ToString();
                string strDatabaseName = gvdri.Cells["colDatabaseName"].Value.ToString();
                string strSchemaName = rlcbScheams.SelectedItem.Text.ToString();
                string strSchemaID = rlcbScheams.SelectedItem.Tag.ToString();
                AutoSanitize(strDatabaseName, strTemplateID, strSchemaName, strSchemaID);
            }
        }

        private void AutoSanitize(string strDatabaseName, string strTemplateID, string strSchemaName, string strSchemaID)
        {
           // ContextOra = new OraDataContext(new OraEntities(strDatabaseName), Utility.UserName);

            List<TemplateSchemaSanitize> TSS = Context.TemplateSchemaSanitizeRepository.FindBy(x => x.TemplateSchemaId == strSchemaID).ToList();
            List<RemapFunction> RF = Context.RemapFunctionRepository.FindBy(x => true).ToList();

            List<ALL_TABLES> lstTables = ContextOra.ALL_TABLESRepository
                .FindBy(x => x.OWNER == strSchemaName).OrderBy(x => x.TABLE_NAME).ToList();

            foreach (ALL_TABLES T in lstTables)
            {
                List<ALL_TAB_COLS> lstColumns = ContextOra.ALL_TAB_COLSRepository
                    .FindBy(x => x.OWNER == strSchemaName).Where(x => x.TABLE_NAME == T.TABLE_NAME).OrderBy(x => x.COLUMN_NAME).ToList();

                foreach (ALL_TAB_COLS TC in lstColumns)
                {
                    if (!DoesConstraintExist(strSchemaName, T.TABLE_NAME, TC.COLUMN_NAME))
                    {
                        int iCount = TSS.Where(x => x.TableName == T.TABLE_NAME).Where(x => x.ColumnName == TC.COLUMN_NAME).Count();

                        if (iCount == 0)
                        {
                            // There isn't a Sanitize...  Attempt to create a new sanitize

                            TemplateSchemaSanitize newTSS = new TemplateSchemaSanitize();
                            newTSS.ColumnName = TC.COLUMN_NAME;
                            newTSS.TableName = T.TABLE_NAME;
                            newTSS.TemplateSchemaId = strSchemaID;

                            switch (TC.DATA_TYPE)
                            {
                                case "CLOB":
                                case "BLOB":
                                    newTSS.FunctionId = RF.Where(x => x.FunctionName == "NIL").FirstOrDefault().Id.ToString();
                                    break;
                                case "CHAR":
                                case "VARCHAR2":
                                    newTSS.FunctionId = RF.Where(x => x.FunctionName == "VRCHR").FirstOrDefault().Id.ToString();
                                    break;
                            }

                            if ((newTSS.FunctionId != null) && (newTSS.FunctionId != string.Empty))

                                if (AutoGenerateSanitizeColumn(TC.COLUMN_NAME))
                                {
                                    Context.TemplateSchemaSanitizeRepository.Save(newTSS);
                                }                                
                        }
                    }
                }
            }

            Context.Commit();
            LoadrgvSchemaSanitize();

        }
        private Boolean AutoGenerateSanitizeColumn(string ColumnName)
        {
            if (ColumnName.ToUpper().Contains("CREATED"))
                return false;

            if (ColumnName.ToUpper().Contains("UPDATED"))
                return false;

            if (ColumnName.ToUpper().Contains("MODIFIED"))
                return false;

            return true;
        }
    }
}
