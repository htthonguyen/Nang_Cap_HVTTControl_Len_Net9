using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace HVTT.UI.Window.Forms.Controls
{
    class HVTTGridEditTextEditControl : HVTTEditTextInGrid, IDataGridViewEditingControl
    {
        private System.Windows.Forms.DataGridView dataGridView;  // grid owning this editing control
        private bool valueChanged;  // editing control's value has changed or not
        private int rowIndex;  //  row index in which the editing control resides
        public HVTTGridEditTextEditControl()
        {
            this.TabStop = false;  // control must not be part of the tabbing loop
            //this.TypeShow = TypeShows.Folder;
        }

        public virtual System.Windows.Forms.DataGridView EditingControlDataGridView
        {
            get { return this.dataGridView; }
            set 
            { 
                this.dataGridView = value; 
                
            }
        }

        public virtual object EditingControlFormattedValue
        {
            get
            {
                return GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
            }
            set
            {
                this.Text = (string)value;
            }
        }

        public virtual int EditingControlRowIndex
        {
            get { return this.rowIndex; }
            set { this.rowIndex = value; }
        }

        public virtual bool EditingControlValueChanged
        {
            get 
            { 
                return this.valueChanged; 
            }
            set
            { 
                this.valueChanged = value;
            }
        }
        
        
        /// <summary>
        /// Property which determines which cursor must be used for the editing panel,
        /// i.e. the parent of the editing control.
        /// </summary>
        public virtual Cursor EditingPanelCursor
        {
            get { return Cursors.Default; }
        }

        /// <summary>
        /// Property which indicates whether the editing control needs to be repositioned 
        /// when its value changes.
        /// </summary>
        public virtual bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        /// <summary>
        /// Method called by the grid before the editing control is shown so it can adapt to the 
        /// provided cell style.
        /// </summary>
        public virtual void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            if (dataGridViewCellStyle.BackColor.A < 255)
            {
                // The NumericUpDown control does not support transparent back colors
                Color opaqueBackColor = Color.FromArgb(255, dataGridViewCellStyle.BackColor);
                this.BackColor = opaqueBackColor;
                this.dataGridView.EditingPanel.BackColor = opaqueBackColor;
            }
            else
            {
                this.BackColor = dataGridViewCellStyle.BackColor;
            }
            this.ForeColor = dataGridViewCellStyle.ForeColor;
        }

        /// <summary>
        /// Method called by the grid on keystrokes to determine if the editing control is
        /// interested in the key or not.
        /// </summary>
        public virtual bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Down:
                case Keys.Up:
                case Keys.Home:
                case Keys.End:
                case Keys.Delete:
                    return true;
            }
            return !dataGridViewWantsInputKey;
        }

        /// <summary>
        /// Returns the current value of the editing control.
        /// </summary>
        public virtual object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return this.Text;
        }

        /// <summary>
        /// Called by the grid to give the editing control a chance to prepare itself for
        /// the editing session.
        /// </summary>
        public virtual void PrepareEditingControlForEdit(bool selectAll)
        {
            if (selectAll)
            {
                this.SelectAll();
            }
            else
            {
                this.SelectionStart = this.Text.Length;
            }
        }

        // End of the IDataGridViewEditingControl interface implementation

        /// <summary>
        /// Small utility function that updates the local dirty state and 
        /// notifies the grid of the value change.
        /// </summary>
        private void NotifyDataGridViewOfValueChange()
        {
            if (!this.valueChanged)
            {
                this.valueChanged = true;
                this.dataGridView.NotifyCurrentCellDirty(true);

            }
        }

        /// <summary>
        /// Listen to the KeyPress notification to know when the value changed, and 
        /// notify the grid of the change.
        /// </summary>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            // The value changes when a digit, the decimal separator or the negative sign is pressed.
            bool notifyValueChange = false;

            //if (char.IsDigit(e.KeyChar))
            //{
            //    notifyValueChange = true;
            //}
            //else
            //{
            //    System.Globalization.NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            //    string decimalSeparatorStr = numberFormatInfo.NumberDecimalSeparator;
            //    string groupSeparatorStr = numberFormatInfo.NumberGroupSeparator;
            //    string negativeSignStr = numberFormatInfo.NegativeSign;
            //    if (!string.IsNullOrEmpty(decimalSeparatorStr) && decimalSeparatorStr.Length == 1)
            //    {
            //        notifyValueChange = decimalSeparatorStr[0] == e.KeyChar;
            //    }
            //    if (!notifyValueChange && !string.IsNullOrEmpty(groupSeparatorStr) && groupSeparatorStr.Length == 1)
            //    {
            //        notifyValueChange = groupSeparatorStr[0] == e.KeyChar;
            //    }
            //    if (!notifyValueChange && !string.IsNullOrEmpty(negativeSignStr) && negativeSignStr.Length == 1)
            //    {
            //        notifyValueChange = negativeSignStr[0] == e.KeyChar;
            //    }
            //}

            if (notifyValueChange)
            {
                // Let the DataGridView know about the value change
                NotifyDataGridViewOfValueChange();
            }
        }

        /// <summary>
        /// Listen to the ValueChanged notification to forward the change to the grid.
        /// </summary>
        /// 
        private void tb_TextChanged(object sender, EventArgs e)
        {
            //base.OnTextChanged(e);

            if (this.Focused)
            {
                // Let the DataGridView know about the value change
                NotifyDataGridViewOfValueChange();
                this.dataGridView.CurrentCell.Value = this.Text;

            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (this.Focused)
            {
                // Let the DataGridView know about the value change
                NotifyDataGridViewOfValueChange();
                this.dataGridView.CurrentCell.Value = this.Text;

            }
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HVTTGridEditTextEditControl
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "HVTTGridEditTextEditControl";
            this.Validated += new System.EventHandler(this.HVTTGridEditTextEditControl_Validated);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HVTTGridEditTextEditControl_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void HVTTGridEditTextEditControl_Validated(object sender, EventArgs e)
        {
            if (this.Focused)
            {
                // Let the DataGridView know about the value change
                NotifyDataGridViewOfValueChange();
                this.dataGridView.CurrentCell.Value = this.Text;
            }
        }

        private void HVTTGridEditTextEditControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnTextChanged(e);

            if (this.Focused)
            {
                // Let the DataGridView know about the value change
                NotifyDataGridViewOfValueChange();
                this.dataGridView.CurrentCell.Value = this.Text;

            }
        }
    }


    public class HVTTGridEditTextColumn : DataGridViewTextBoxColumn
    {

        private HVTTEditTextInGrid.TypeShows _mTypeShow;
        private String _msStoreName = "";
        private String _msCodeLanguage = "";
        private String _msTitle = "";
        private Boolean _mbIsSys = true;
        private Boolean _mbUseSystemPasswordChar = false;
        private Char _mcPasswordChar;
        private HVTTEditText.ParamObject[] _poParams = null;

        public HVTTGridEditTextColumn()
        {
            HVTTGridEditTextCell cell = new HVTTGridEditTextCell();
            base.CellTemplate = cell;
            _mTypeShow = HVTTEditTextInGrid.TypeShows.None;
            base.SortMode = DataGridViewColumnSortMode.Automatic;
            //base.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //base.DefaultCellStyle.Format = "F" + this.DecimalLength.ToString();
        }

        private HVTTGridEditTextCell EditCellTemplate
        {
            get
            {
                HVTTGridEditTextCell cell = this.CellTemplate as HVTTGridEditTextCell;
                if (cell == null)
                {
                    throw new InvalidOperationException("HVTTGridEditTextColumn does not have a CellTemplate.");
                }
                return cell;
            }
        }

        [
            Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public override DataGridViewCell CellTemplate
        {
            get 
            { 
                return base.CellTemplate; 
            }
            set
            {
                HVTTGridEditTextCell cell = value as HVTTGridEditTextCell;
                if (value != null && cell == null)
                {
                    throw new InvalidCastException("Value provided for CellTemplate must be of type HVTTGridEditTextCell or derive from it.");
                }
                base.CellTemplate = value;
            }
        }

        [
            Category("Appearance"),
            Description("The decimal length of cell value.")
        ]
        public HVTTEditTextInGrid.TypeShows TypeShow
        {
            get 
            {
                return _mTypeShow;
            }
            set
            {
                //if (value < 0 || value > m_allowMaxDecimalLength)
                //{
                //    throw new ArgumentOutOfRangeException("The DecimalLength must be between 0 and " + m_allowMaxDecimalLength.ToString() + ".");
                //}

                //base.DefaultCellStyle.Format = "F" + value.ToString();

              
                _mTypeShow = value;
                this.EditCellTemplate.TypeShow = _mTypeShow;
                if (this.DataGridView != null)
                {
                    // Update all the existing DataGridViewNumericUpDownCell cells in the column accordingly.
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        // Be careful not to unshare rows unnecessarily. 
                        // This could have severe performance repercussions.
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        HVTTGridEditTextCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as HVTTGridEditTextCell;
                        if (dataGridViewCell != null)
                        {
                            // Call the internal SetDecimalPlaces method instead of the property to avoid invalidation 
                            // of each cell. The whole column is invalidated later in a single operation for better performance.
                            dataGridViewCell.SetTypeShow(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                    // TODO: Call the grid's autosizing methods to autosize the column, rows, column headers / row headers as needed.
                }
            }
        }

        public String StoreName
        {
            get
            {
                return _msStoreName;
            }
            set
            {
                //if (value < 0 || value > m_allowMaxDecimalLength)
                //{
                //    throw new ArgumentOutOfRangeException("The DecimalLength must be between 0 and " + m_allowMaxDecimalLength.ToString() + ".");
                //}

                //base.DefaultCellStyle.Format = "F" + value.ToString();
               

                _msStoreName = value;
                this.EditCellTemplate.StoreName = _msStoreName;
                if (this.DataGridView != null)
                {
                    // Update all the existing DataGridViewNumericUpDownCell cells in the column accordingly.
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        // Be careful not to unshare rows unnecessarily. 
                        // This could have severe performance repercussions.
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        HVTTGridEditTextCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as HVTTGridEditTextCell;
                        if (dataGridViewCell != null)
                        {
                            // Call the internal SetDecimalPlaces method instead of the property to avoid invalidation 
                            // of each cell. The whole column is invalidated later in a single operation for better performance.
                            dataGridViewCell.SetStoreName(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                    // TODO: Call the grid's autosizing methods to autosize the column, rows, column headers / row headers as needed.
                }
            }
        }

        public String CodeLanguage
        {
            get
            {
                return _msCodeLanguage;
            }
            set
            {
                //if (value < 0 || value > m_allowMaxDecimalLength)
                //{
                //    throw new ArgumentOutOfRangeException("The DecimalLength must be between 0 and " + m_allowMaxDecimalLength.ToString() + ".");
                //}

                //base.DefaultCellStyle.Format = "F" + value.ToString();


                _msCodeLanguage = value;
                this.EditCellTemplate.CodeLanguage = _msCodeLanguage;
                if (this.DataGridView != null)
                {
                    // Update all the existing DataGridViewNumericUpDownCell cells in the column accordingly.
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        // Be careful not to unshare rows unnecessarily. 
                        // This could have severe performance repercussions.
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        HVTTGridEditTextCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as HVTTGridEditTextCell;
                        if (dataGridViewCell != null)
                        {
                            // Call the internal SetDecimalPlaces method instead of the property to avoid invalidation 
                            // of each cell. The whole column is invalidated later in a single operation for better performance.
                            dataGridViewCell.SetCodeLanguage(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                    // TODO: Call the grid's autosizing methods to autosize the column, rows, column headers / row headers as needed.
                }
            }
        }

        public String Title
        {
            get
            {
                return _msTitle;
            }
            set
            {
                //if (value < 0 || value > m_allowMaxDecimalLength)
                //{
                //    throw new ArgumentOutOfRangeException("The DecimalLength must be between 0 and " + m_allowMaxDecimalLength.ToString() + ".");
                //}

                //base.DefaultCellStyle.Format = "F" + value.ToString();


                _msTitle = value;
                this.EditCellTemplate.Title = _msTitle;
                if (this.DataGridView != null)
                {
                    // Update all the existing DataGridViewNumericUpDownCell cells in the column accordingly.
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        // Be careful not to unshare rows unnecessarily. 
                        // This could have severe performance repercussions.
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        HVTTGridEditTextCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as HVTTGridEditTextCell;
                        if (dataGridViewCell != null)
                        {
                            // Call the internal SetDecimalPlaces method instead of the property to avoid invalidation 
                            // of each cell. The whole column is invalidated later in a single operation for better performance.
                            dataGridViewCell.SetTitle(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                    // TODO: Call the grid's autosizing methods to autosize the column, rows, column headers / row headers as needed.
                }
            }
        }
        public Boolean IsSys
        {
            get
            {
                return _mbIsSys;
            }
            set
            {
                //if (value < 0 || value > m_allowMaxDecimalLength)
                //{
                //    throw new ArgumentOutOfRangeException("The DecimalLength must be between 0 and " + m_allowMaxDecimalLength.ToString() + ".");
                //}

                //base.DefaultCellStyle.Format = "F" + value.ToString();


                _mbIsSys = value;
                this.EditCellTemplate.IsSys = _mbIsSys;
                if (this.DataGridView != null)
                {
                    // Update all the existing DataGridViewNumericUpDownCell cells in the column accordingly.
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        // Be careful not to unshare rows unnecessarily. 
                        // This could have severe performance repercussions.
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        HVTTGridEditTextCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as HVTTGridEditTextCell;
                        if (dataGridViewCell != null)
                        {
                            // Call the internal SetDecimalPlaces method instead of the property to avoid invalidation 
                            // of each cell. The whole column is invalidated later in a single operation for better performance.
                            dataGridViewCell.SetIsSys(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                    // TODO: Call the grid's autosizing methods to autosize the column, rows, column headers / row headers as needed.
                }
            }
        }
        public Boolean UseSystemPasswordChar
        {
            get
            {
                return _mbUseSystemPasswordChar;
            }
            set
            {
                //if (value < 0 || value > m_allowMaxDecimalLength)
                //{
                //    throw new ArgumentOutOfRangeException("The DecimalLength must be between 0 and " + m_allowMaxDecimalLength.ToString() + ".");
                //}

                //base.DefaultCellStyle.Format = "F" + value.ToString();


                _mbUseSystemPasswordChar = value;
                this.EditCellTemplate.UseSystemPasswordChar = _mbUseSystemPasswordChar;
                if (this.DataGridView != null)
                {
                    // Update all the existing DataGridViewNumericUpDownCell cells in the column accordingly.
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        // Be careful not to unshare rows unnecessarily. 
                        // This could have severe performance repercussions.
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        HVTTGridEditTextCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as HVTTGridEditTextCell;
                        if (dataGridViewCell != null)
                        {
                            // Call the internal SetDecimalPlaces method instead of the property to avoid invalidation 
                            // of each cell. The whole column is invalidated later in a single operation for better performance.
                            dataGridViewCell.SetUseSystemPasswordChar(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                    // TODO: Call the grid's autosizing methods to autosize the column, rows, column headers / row headers as needed.
                }
            }
        }
        public Char PasswordChar
        {
            get
            {
                return _mcPasswordChar;
            }
            set
            {
                //if (value < 0 || value > m_allowMaxDecimalLength)
                //{
                //    throw new ArgumentOutOfRangeException("The DecimalLength must be between 0 and " + m_allowMaxDecimalLength.ToString() + ".");
                //}

                //base.DefaultCellStyle.Format = "F" + value.ToString();


                _mcPasswordChar = value;
                this.EditCellTemplate.PasswordChar = _mcPasswordChar;
                if (this.DataGridView != null)
                {
                    // Update all the existing DataGridViewNumericUpDownCell cells in the column accordingly.
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        // Be careful not to unshare rows unnecessarily. 
                        // This could have severe performance repercussions.
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        HVTTGridEditTextCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as HVTTGridEditTextCell;
                        if (dataGridViewCell != null)
                        {
                            // Call the internal SetDecimalPlaces method instead of the property to avoid invalidation 
                            // of each cell. The whole column is invalidated later in a single operation for better performance.
                            dataGridViewCell.SetPasswordChar(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                    // TODO: Call the grid's autosizing methods to autosize the column, rows, column headers / row headers as needed.
                }
            }
        }

        public HVTTEditText.ParamObject[] Param
        {
            get
            {
                return _poParams;
            }
            set
            {
                //if (value < 0 || value > m_allowMaxDecimalLength)
                //{
                //    throw new ArgumentOutOfRangeException("The DecimalLength must be between 0 and " + m_allowMaxDecimalLength.ToString() + ".");
                //}

                //base.DefaultCellStyle.Format = "F" + value.ToString();


                _poParams = value;
                this.EditCellTemplate.Param = _poParams;
                if (this.DataGridView != null)
                {
                    // Update all the existing DataGridViewNumericUpDownCell cells in the column accordingly.
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        // Be careful not to unshare rows unnecessarily. 
                        // This could have severe performance repercussions.
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        HVTTGridEditTextCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as HVTTGridEditTextCell;
                        if (dataGridViewCell != null)
                        {
                            // Call the internal SetDecimalPlaces method instead of the property to avoid invalidation 
                            // of each cell. The whole column is invalidated later in a single operation for better performance.
                            dataGridViewCell.SetParam(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                    // TODO: Call the grid's autosizing methods to autosize the column, rows, column headers / row headers as needed.
                }
            }
        }
        protected override void OnDataGridViewChanged()
        {
            CellTemplate.Value = EditCellTemplate.Value;
            base.OnDataGridViewChanged();
        }
        //[
        //    Category("Appearance"),
        //    DefaultValue(true),
        //    Description("Whether negative sign is allowed or not.")
        //]
        //public bool AllowNegative
        //{
        //    get { return this.NumEditCellTemplate.AllowNegative; }
        //    set
        //    {
        //        this.NumEditCellTemplate.AllowNegative = value;
        //        if (this.DataGridView != null)
        //        {
        //            DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
        //            int rowCount = dataGridViewRows.Count;
        //            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
        //            {
        //                DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
        //                TNumEditDataGridViewCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as TNumEditDataGridViewCell;
        //                if (dataGridViewCell != null)
        //                {
        //                    dataGridViewCell.EnableNegative(rowIndex, value);
        //                }
        //            }
        //        }
        //    }
        //}

        //[
        //    Category("Appearance"),
        //    DefaultValue(false),
        //    Description("Whether show null when value is zero or not.")
        //]
        //public bool ShowNullWhenZero
        //{
        //    get { return this.NumEditCellTemplate.ShowNullWhenZero; }
        //    set
        //    {
        //        this.NumEditCellTemplate.ShowNullWhenZero = value;
        //        if (this.DataGridView != null)
        //        {
        //            DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
        //            int rowCount = dataGridViewRows.Count;
        //            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
        //            {
        //                DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
        //                TNumEditDataGridViewCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as TNumEditDataGridViewCell;
        //                if (dataGridViewCell != null)
        //                {
        //                    dataGridViewCell.EnableShowNullWhenZero(rowIndex, value);
        //                }
        //            }
        //            this.DataGridView.InvalidateColumn(this.Index);
        //        }
        //    }
        //}

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(100);
            sb.Append("HVTTGridEditTextColumn { Name=");
            sb.Append(this.Name);
            sb.Append(", Index=");
            sb.Append(this.Index.ToString(CultureInfo.CurrentCulture));
            sb.Append(" }");
            return sb.ToString();
        }
    }



    public class HVTTGridEditTextCell : DataGridViewTextBoxCell
    {

        private HVTTEditTextInGrid.TypeShows _mTypeShow;
        private String _msStoreName = "";
        private String _msCodeLanguage = "";
        private String _msTitle = "";
        private Boolean _mbIsSys = true;
        private HVTTEditText.ParamObject[] _poParams = null;
        private Boolean _mbUseSystemPasswordChar = false;
        private Char _mcPasswordChar;
        private static Type defaultEditType = typeof(HVTTGridEditTextEditControl);
        private static Type defaultValueType = typeof(System.Decimal);

        public HVTTGridEditTextCell() 
        {
            //_mTypeShow = HVTTEditText.TypeShows.None;
        }

        public HVTTEditTextInGrid.TypeShows TypeShow
        {
            get { return _mTypeShow; }
            set
            {

                //if (_mTypeShow != value)
                //{
                SetTypeShow(this.RowIndex, value);
                    OnCommonChange();  // Assure that the cell/column gets repainted and autosized if needed
                //}
            }
        }
        public String StoreName
        {
            get { return _msStoreName; }
            set
            {

                //if (_mTypeShow != value)
                //{

               
                SetStoreName(this.RowIndex, value);
                OnCommonChange();  // Assure that the cell/column gets repainted and autosized if needed
                //}
            }
        }

        public String Title
        {
            get { return _msTitle; }
            set
            {

                //if (_mTypeShow != value)
                //{

                SetTitle(this.RowIndex, value);
                OnCommonChange();  // Assure that the cell/column gets repainted and autosized if needed
                //}
            }
        }

        public String CodeLanguage
        {
            get { return _msCodeLanguage; }
            set
            {

                //if (_mTypeShow != value)
                //{

                SetCodeLanguage(this.RowIndex, value);
                OnCommonChange();  // Assure that the cell/column gets repainted and autosized if needed
                //}
            }
        }

        public Boolean IsSys
        {
            get { return _mbIsSys; }
            set
            {

                //if (_mTypeShow != value)
                //{

                SetIsSys(this.RowIndex, value);
                OnCommonChange();  // Assure that the cell/column gets repainted and autosized if needed
                //}
            }
        }

        public Boolean UseSystemPasswordChar
        {
            get { return _mbUseSystemPasswordChar; }
            set
            {

                //if (_mTypeShow != value)
                //{

                SetUseSystemPasswordChar(this.RowIndex, value);
                OnCommonChange();  // Assure that the cell/column gets repainted and autosized if needed
                //}
            }
        }

        public Char PasswordChar
        {
            get { return _mcPasswordChar; }
            set
            {

                //if (_mTypeShow != value)
                //{

                SetPasswordChar(this.RowIndex, value);
                OnCommonChange();  // Assure that the cell/column gets repainted and autosized if needed
                //}
            }
        }

        public HVTTEditText.ParamObject[] Param
        {
            get { return _poParams; }
            set
            {

                //if (_mTypeShow != value)
                //{

                SetParam(this.RowIndex, value);
                OnCommonChange();  // Assure that the cell/column gets repainted and autosized if needed
                //}
            }
        }
        //[DefaultValue(true)]
        //public bool AllowNegative
        //{
        //    get { return m_allowNegative; }
        //    set
        //    {
        //        if (m_allowNegative != value)
        //        {
        //            EnableNegative(this.RowIndex, value);
        //        }
        //    }
        //}

        //[DefaultValue(false)]
        //public bool ShowNullWhenZero
        //{
        //    get { return m_showNullWhenZero; }
        //    set
        //    {
        //        if (m_showNullWhenZero != value)
        //        {
        //            EnableShowNullWhenZero(this.RowIndex, value);
        //            OnCommonChange();
        //        }
        //    }
        //}

        private HVTTGridEditTextEditControl EditingEditText
        {
            get
            {
                return this.DataGridView.EditingControl as HVTTGridEditTextEditControl;
            }
        }

        public override Type EditType
        {
            get { return defaultEditType; }
        }

        public override Type ValueType
        {
            get
            {
                Type valueType = base.ValueType;
                if (valueType != null)
                {
                    return valueType;
                }
                return defaultValueType;
            }
        }

        /// <summary>
        /// If set 0/1.23 to two cells, it will throw Exception when sort by clicking column header.
        /// Override this method to ensure the type of value.
        /// </summary>
        protected override bool SetValue(int rowIndex, object value)
        {
            String val = "";
            try
            {
                val = value.ToString();
            }
            catch { }
            return base.SetValue(rowIndex, val); 
        }

        public override object Clone()
        {
            HVTTGridEditTextCell dataGridViewCell = base.Clone() as HVTTGridEditTextCell;
            if (dataGridViewCell != null)
            {
                dataGridViewCell.TypeShow = _mTypeShow;
                dataGridViewCell.StoreName = _msStoreName;
                dataGridViewCell.Title = _msTitle;
                dataGridViewCell._poParams = _poParams;
                dataGridViewCell.CodeLanguage = _msCodeLanguage;
                dataGridViewCell.IsSys = _mbIsSys;
                dataGridViewCell.UseSystemPasswordChar = _mbUseSystemPasswordChar;
                dataGridViewCell._mcPasswordChar = _mcPasswordChar;
            }
            return dataGridViewCell;
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            HVTTEditTextInGrid numEditBox = this.DataGridView.EditingControl as HVTTEditTextInGrid;
            if (numEditBox != null)
            {
                numEditBox.BorderStyle = BorderStyle.None;
                //numEditBox.DecimalLength = this.DecimalLength;
                //numEditBox.AllowNegative = this.AllowNegative;
                numEditBox.TypeShow = _mTypeShow;
                numEditBox.StoreName = _msStoreName;
                numEditBox.Title = _msTitle;
                numEditBox.IsSys = _mbIsSys;
                numEditBox.Param = _poParams;
                numEditBox.CodeLanguage = _msCodeLanguage;
                numEditBox.PasswordChar = _mcPasswordChar;
                numEditBox.UseSystemPasswordChar = _mbUseSystemPasswordChar;
                string initialFormattedValueStr = initialFormattedValue as string;

                if (string.IsNullOrEmpty(initialFormattedValueStr))
                {
                    numEditBox.Text = "";
                }
                else
                {
                    numEditBox.Text = initialFormattedValueStr;
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public override void DetachEditingControl()
        {
            System.Windows.Forms.DataGridView dataGridView = this.DataGridView;
            if (dataGridView == null || dataGridView.EditingControl == null)
            {
                throw new InvalidOperationException("Cell is detached or its grid has no editing control.");
            }

            //HVTTEditText numEditBox = dataGridView.EditingControl as HVTTEditText;
            //if (numEditBox != null)
            //{
            //    numEditBox.ClearUndo();  // avoid interferences between the editing sessions
            //}

            base.DetachEditingControl();
        }

        /// <summary>
        /// Consider the decimal in the formatted representation of the cell value.
        /// </summary>
        protected override object GetFormattedValue(object value,
                                                    int rowIndex,
                                                    ref DataGridViewCellStyle cellStyle,
                                                    TypeConverter valueTypeConverter,
                                                    TypeConverter formattedValueTypeConverter,
                                                    DataGridViewDataErrorContexts context)
        {
            object baseFormattedValue = base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
            string formattedText = baseFormattedValue as string;

            if (value == null || string.IsNullOrEmpty(formattedText))
            {
                return baseFormattedValue;
            }

            //Decimal unformattedDecimal = System.Convert.ToDecimal(value); // 123.1 to "123.1"
            //Decimal formattedDecimal = System.Convert.ToDecimal(formattedText); // 123.1 to "123.12" if DecimalLength is 2

            //if (unformattedDecimal == 0.0m && m_showNullWhenZero)
            //{
            //    return base.GetFormattedValue(null, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
            //}

            //if (unformattedDecimal == formattedDecimal)
            //{
            //    return formattedDecimal.ToString("F" + m_decimalLength.ToString());
            //}
            return formattedText;
        }

        private void OnCommonChange()
        {
            if (this.DataGridView != null && !this.DataGridView.IsDisposed && !this.DataGridView.Disposing)
            {
                if (this.RowIndex == -1)
                {
                    this.DataGridView.InvalidateColumn(this.ColumnIndex);
                }
                else
                {
                    this.DataGridView.UpdateCellValue(this.ColumnIndex, this.RowIndex);
                }
            }
        }
        
        private bool OwnsEditingControl(int rowIndex)
        {
            if (rowIndex == -1 || this.DataGridView == null)
            {
                return false;
            }
            HVTTGridEditTextEditControl editingControl = this.DataGridView.EditingControl as HVTTGridEditTextEditControl;
            return editingControl != null && rowIndex == ((IDataGridViewEditingControl)editingControl).EditingControlRowIndex;
        }

        internal void SetTypeShow(int rowIndex, HVTTEditTextInGrid.TypeShows value)
        {
            _mTypeShow = value;
            if (OwnsEditingControl(rowIndex))
            {
                this.EditingEditText.TypeShow = value;
            }
            //this.EditingEditText.TypeShow = value;
        }

        internal void SetStoreName(int rowIndex, String value)
        {
            _msStoreName = value;
            if (OwnsEditingControl(rowIndex))
            {
                this.EditingEditText.StoreName = value;
            }
            //this.EditingEditText.TypeShow = value;
        }

        internal void SetTitle(int rowIndex, String value)
        {
            _msTitle = value;
            if (OwnsEditingControl(rowIndex))
            {
                this.EditingEditText.Title = value;
            }
            //this.EditingEditText.TypeShow = value;
        }

        internal void SetCodeLanguage(int rowIndex, String value)
        {
            _msCodeLanguage = value;
            if (OwnsEditingControl(rowIndex))
            {
                this.EditingEditText.CodeLanguage = value;
            }
            //this.EditingEditText.TypeShow = value;
        }

        internal void SetIsSys(int rowIndex, Boolean value)
        {
            _mbIsSys = value;
            if (OwnsEditingControl(rowIndex))
            {
                this.EditingEditText.IsSys = value;
            }
            //this.EditingEditText.TypeShow = value;
        }
        internal void SetUseSystemPasswordChar(int rowIndex, Boolean value)
        {
            _mbUseSystemPasswordChar = value;
            if (OwnsEditingControl(rowIndex))
            {
                this.EditingEditText.UseSystemPasswordChar = value;
            }
            //this.EditingEditText.TypeShow = value;
        }

        internal void SetPasswordChar(int rowIndex, Char value)
        {
            _mcPasswordChar = value;
            if (OwnsEditingControl(rowIndex))
            {
                this.EditingEditText.PasswordChar = value;
            }
            //this.EditingEditText.TypeShow = value;
        }

        internal void SetParam(int rowIndex, HVTTEditText.ParamObject[] value)
        {
            _poParams = value;
            if (OwnsEditingControl(rowIndex))
            {
                this.EditingEditText.Param = value;
            }
            //this.EditingEditText.TypeShow = value;
        }

        //internal void EnableNegative(int rowIndex, bool value)
        //{
        //    m_allowNegative = value;
        //    if (OwnsEditingControl(rowIndex))
        //    {
        //        this.EditingTNumEditBox.AllowNegative = value;
        //    }
        //}

        //internal void EnableShowNullWhenZero(int rowIndex, bool value)
        //{
        //    m_showNullWhenZero = value;
        //}

        public override string ToString()
        {
            return "HVTTGridEditTextCell { ColIndex=" + ColumnIndex.ToString(CultureInfo.CurrentCulture) +
                ", RowIndex=" + RowIndex.ToString(CultureInfo.CurrentCulture) + " }";
        }
    }

}
