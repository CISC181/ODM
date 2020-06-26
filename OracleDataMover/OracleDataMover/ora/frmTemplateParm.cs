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
using OracleDataMoverBLL.Common;

namespace OracleDataMover.ora
{
    public partial class frmTemplateParm : Telerik.WinControls.UI.RadForm
    {
        private Boolean isLoading;
        protected static ODMDataContext Context = new ODMDataContext(new ODMEntities(), Utility.UserName);

        private MainForm MF;

        public MainForm MF1 { get => MF; set => MF = value; }

        public frmTemplateParm()
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
            isLoading = false;
        }

        /// <summary>
        /// Load the Template Column Combo Box
        /// </summary>
        private void LoadrmccTemplateSchema()
        {
            List<Template> lstTemplate = Context.TemplateRepository.FindBy(x => true).ToList();
            this.rmccTemplateSchema.DataSource = lstTemplate;
        }

        private void rmccTemplateSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!isLoading && this.rmccTemplateSchema.SelectedIndex > -1))
            {
                if (this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colDatabaseName"] != null)
                {

                    //String strDatabaseName = this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colDatabaseName"].Value.ToString();
                    //String strTemplateID = this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colTemplateID"].Value.ToString();
                    LoadrgvTemplateParms();
                    LoadrmccCopyFrom();

                }
            }
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

        private void rbSave_Click(object sender, EventArgs e)
        {

            foreach (GridViewDataRowInfo dataRow in this.GetAllRows(this.rgvTemplateParms.MasterTemplate))
            {
                var cell = dataRow.Cells["colTemplateParmID"].Value;
                if (cell == null)
                {

                }
                if ((dataRow.Tag != null) && (dataRow.Tag.ToString() == "ThisRowIsDirty"))
                {
                    string strTemplateParmID = dataRow.Cells["colTemplateParmID"].Value.ToString();
                    TemplateParm TP = Context.TemplateParmRepository
                        .FindBy(x => x.Id == strTemplateParmID).FirstOrDefault();
                    TP.ParmValue = dataRow.Cells["colParmValue"].Value.ToString();
                    Context.TemplateParmRepository.Save(TP);
                }
            }


            Context.Commit();
            MessageBox.Show("Data is saved");
        }

        private void rbUndo_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to undo all changes?", "Confirm",
 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Context.Rollback();
                LoadrgvTemplateParms();
            }
        }
        private void LoadrgvTemplateParms()
        {
            LoadrgvTemplateParms_Layout();
            LoadrgvTemplateParms_LoadData();
        }

        private void LoadrmccCopyFrom()
        {
            String strTemplateID = this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colTemplateID"].Value.ToString();
            List<Template> lstTemplate = Context.TemplateRepository.FindBy(x => true).Where(x=>x.Id != strTemplateID).ToList();
            this.rmccCopyFrom.DataSource = lstTemplate;

        }


        private void LoadrgvTemplateParms_Layout()
        {
            rgvTemplateParms.Columns.Clear();

            GridViewDataRowInfo gvdri = (GridViewDataRowInfo)rmccTemplateSchema.SelectedItem;
            String strDatabaseName = gvdri.Cells["colDatabaseName"].Value.ToString();
            String strTemplateID = gvdri.Cells["colTemplateID"].Value.ToString();

            GridViewCommandColumn commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "colDelete";
            commandColumn.UseDefaultText = true;
            commandColumn.DefaultText = "Delete";
            commandColumn.FieldName = "ID";
            rgvTemplateParms.MasterTemplate.Columns.Add(commandColumn);
            rgvTemplateParms.CommandCellClick += new
            CommandCellClickEventHandler(rgvTemplateParms_CommandCellClick);

            GridViewTextBoxColumn gtbTemplateParmID = new GridViewTextBoxColumn();
            gtbTemplateParmID.EnableExpressionEditor = false;
            gtbTemplateParmID.FieldName = "Id";
            gtbTemplateParmID.HeaderText = "TemplateParmID";
            gtbTemplateParmID.Name = "colTemplateParmID";
            gtbTemplateParmID.IsVisible = false;
            this.rgvTemplateParms.Columns.Add(gtbTemplateParmID);


            List<PARM> lstParms = Context.PARMRepository.FindBy(x => true).OrderBy(x => x.ParmName).ToList();
            BindingList<PARM> bndParms = new BindingList<PARM>();
            foreach (PARM p in lstParms)
            {
                bndParms.Add(p);
            }

            GridViewComboBoxColumn colParm = new GridViewComboBoxColumn();
            colParm.DataSource = bndParms;
            colParm.Name = "colParm";
            colParm.HeaderText = "Parm";
            colParm.ValueMember = "Id";
            colParm.DisplayMember = "ParmName";
            colParm.FieldName = "ParmId";
            colParm.Width = 200;
            this.rgvTemplateParms.Columns.Add(colParm);


            GridViewTextBoxColumn gtbParmValue = new GridViewTextBoxColumn();
            gtbParmValue.EnableExpressionEditor = false;
            gtbParmValue.FieldName = "ParmValue";
            gtbParmValue.HeaderText = "Parm Value";
            gtbParmValue.Name = "colParmValue";
            gtbParmValue.Width = 200;
            this.rgvTemplateParms.Columns.Add(gtbParmValue);
        }

        private Boolean DoesParmElementExist(string strParmID)
        {
            foreach (GridViewDataRowInfo dataRow in this.GetAllRows(this.rgvTemplateParms.MasterTemplate))
            {
                if (dataRow.Cells["colParm"].Value.ToString() == strParmID)
                {
                    return true;
                }
            }
            return false;
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

        private void LoadrgvTemplateParms_LoadData()
        {
            GridViewDataRowInfo gvdri = (GridViewDataRowInfo)rmccTemplateSchema.SelectedItem;
            if (gvdri == null)
                return;
            if (isLoading)
                return;
            String strTemplateID = gvdri.Cells["colTemplateID"].Value.ToString();
            List<TemplateParm> lstTp = Context.TemplateParmRepository.FindBy(x => x.TemplateId == strTemplateID).OrderBy(x=>x.PARM.ParmName).ToList();

            rgvTemplateParms.DataSource = lstTp;

        }


        private void rgvTemplateParms_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gce = (GridCommandCellElement)sender;
            if (gce.Value != null)
            {
                var TemplateParmID = ((sender as GridCommandCellElement)).Value.ToString();

                TemplateParm tp = Context.TemplateParmRepository.FindBy(x => x.Id == TemplateParmID).FirstOrDefault();
                if (tp != null)
                    Context.TemplateParmRepository.Delete(tp);
                if (this.rgvTemplateParms.CurrentRow is GridViewDataRowInfo)
                    this.rgvTemplateParms.Rows.Remove(((GridViewDataRowInfo)this.rgvTemplateParms.CurrentRow));
            }
        }
        private void rgvTemplateParms_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            if (isLoading)
                return;

            if (e.Column.HeaderText == "Parm")
            {
                /*
                RadDropDownListEditor editor = (RadDropDownListEditor)this.rgvTemplateParms.ActiveEditor;
                RadDropDownListEditorElement editorElement = (RadDropDownListEditorElement)editor.EditorElement;
                List<PARM> lstParms = Context.PARMRepository.FindBy(x => true).OrderBy(x => x.ParmName).ToList();

                foreach (PARM p in lstParms)
                {
                    RadListDataItem rldi = new RadListDataItem();
                    rldi.Value = p.ParmName;
                    rldi.Text = p.ParmName;


                    editorElement.Items.Add(rldi);
                }

                editorElement.SelectedValue = null;
                editorElement.SelectedValue = this.rgvTemplateParms.CurrentCell.Value;
                */

            }
        }

        private void rgvTemplateParms_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            e.Row.Tag = "ThisRowIsDirty";
        }

        private void rgvTemplateParms_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            MasterGridViewTemplate mgvt = (MasterGridViewTemplate)sender;

            if (isLoading)
                return;

            foreach (GridViewDataRowInfo dataRow in this.GetAllRows(this.rgvTemplateParms.MasterTemplate))
            {
                TemplateParm tsi = (TemplateParm)dataRow.DataBoundItem;
                GridViewDataRowInfo gvdri = (GridViewDataRowInfo)rmccTemplateSchema.SelectedItem;
                String strDatabaseName = gvdri.Cells["colDatabaseName"].Value.ToString();
                String strTemplateID = gvdri.Cells["colTemplateID"].Value.ToString();

                var cell = dataRow.Cells["colTemplateParmID"].Value;

                if (cell == null)
                {
                    TemplateParm TP = new TemplateParm();
                    TP.ParmId = tsi.ParmId;
                    TP.ParmValue = tsi.ParmValue;
                    TP.TemplateId = strTemplateID;
                    Context.TemplateParmRepository.Save(TP);
                    Context.Commit();
                    dataRow.Cells["colTemplateParmID"].Value = TP.Id;
                    dataRow.Tag = string.Empty;
                }
            }
        }

        private void rbCopy_Click(object sender, EventArgs e)
        {
            String strSourceTemplateID = this.rmccCopyFrom.EditorControl.CurrentRow.Cells["colTemplateID"].Value.ToString();
            String strTargetTemplateID = this.rmccTemplateSchema.EditorControl.CurrentRow.Cells["colTemplateID"].Value.ToString();

            List<TemplateParm> lstTP = Context.TemplateParmRepository.FindBy(x => x.TemplateId == strSourceTemplateID).ToList();

            foreach (TemplateParm TP in lstTP)
            {
                TemplateParm extTP = Context.TemplateParmRepository
                    .FindBy(x => x.TemplateId == strTargetTemplateID)
                    .Where(x => x.ParmId == TP.ParmId).FirstOrDefault();
                if (extTP == null)
                {
                    TemplateParm newTP = new TemplateParm();
                    newTP.ParmId = TP.ParmId;
                    newTP.ParmValue = TP.ParmValue;
                    newTP.TemplateId = strTargetTemplateID;
                    newTP.Id = Regex.Replace(Guid.NewGuid().ToString().ToUpper(), "[-]", "");
                    Context.TemplateParmRepository.Save(newTP);
                }
                else
                {
                    extTP.ParmValue = TP.ParmValue;
                    Context.TemplateParmRepository.Save(extTP);
                }             
            }
            Context.Commit();
            LoadrgvTemplateParms();
            LoadrmccCopyFrom();

        }
    }
}
