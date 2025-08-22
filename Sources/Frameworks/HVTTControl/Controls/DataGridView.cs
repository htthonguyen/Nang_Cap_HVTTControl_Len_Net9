

using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using HVTT.UI.Window.Forms.Rendering;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.ComponentModel;
using System.Data;

using System.Collections.Generic;
using System.Globalization;

namespace HVTT.UI.Window.Forms.Controls
{
   
    public delegate void HVTTGridBeforRowActive(Object Sender,DataGridViewRow Row);
    public delegate void HVTTEditControlClicked(Control Sender);
    public delegate void HVTTEditControlKeyDown(Control Sender,KeyEventArgs e);
    public delegate void HVTTEditControlFocus(Control Sender);
    public delegate void HVTTEditControlLeave(Control Sender);
    /// <summary>
    /// Represents the DataGridView control with enhanced Office 2007 style.
    /// </summary>
    [ToolboxBitmap(typeof(DataGridView), "Controls.DataGridView.bmp")]
    public class DataGridView : System.Windows.Forms.DataGridView
    {

        #region Private Variables
        

        private int m_MouseOverColumnHeader = -2;
        private int m_MouseDownColumnHeader = -2;
        private int m_MouseDownRowIndex = -2;
        private int m_MouseOverRowIndex = -2;
        private bool m_Office2007StyleEnabled = true;
        private Office2007DataGridViewColorTable m_ColorTable = null;
        private Office2007ButtonItemStateColorTable m_ButtonStateColorTable = null;
        private SelectionInfo[] m_ColumnSelectionState = new SelectionInfo[1];
        //private int m_CurrentCellRowIndex = -1;
        private int m_SelectedRowIndex = -2;
        private bool m_HighlightSelectedColumnHeaders = true;
        private bool m_SelectAllSignVisible = true;
        private bool m_PaintEnhancedSelection = true;


        private int _miFlagIChanged = -1;//Co hieu xem co IsChanged khong
        

        private int _miRowIndex = -1;
        
        #endregion

#region Property
        private Boolean _mblnAllowSearch = false;

        DataTable tbl = new DataTable();
        private String _msValue = "";
        private String[] _sNotEmptyKey = null;
        private String _msCodeLanguage = "";
        private int[] _mIndexArrayRowChange = null;
        private String[] _mReadOnlyKey = null;
        private String[] _mKeys = null;
        private Boolean _mbIsChange = false;
        private int _miLivel = -1;
        private Boolean _mblnAutoHeaderNumber = true;
        private Boolean _mblnAllowEdit = true;
        private Boolean _mblnUseEnterKey = true;
        private SumaryColumn[] _mSumaryColumns = null;
        private KeyPressColumn[] _mKeyPressColumns = null;
        private String[] _mUpperCaseColumns = null;
        private String[] _mNumbericColumns = null;
        private DefaultValue[] _mDefaultValues = null;

        private Boolean _mblnStampAddRow = true;
        private Boolean _mblnStampDelete = true;

        private List<MergeHeaderCell> MergeHeaderCells;


        

        public Boolean StampAddRow
        {
            get
            {
                return _mblnStampAddRow;
            }
            set
            {
                _mblnStampAddRow = value;
            }
        }
        public Boolean StampDelete
        {
            get
            {
                return _mblnStampDelete;
            }
            set
            {
                _mblnStampDelete = value;
            }
        }

        public Boolean UseEnterKey
        {
            get
            {
                return _mblnUseEnterKey;
            }
            set
            {
                _mblnUseEnterKey = value;
            }
        }

       
        internal Boolean GridTree = false;

        

        public int Level
        {
            get
            {
                return _miLivel;
            }
            set
            {
                _miLivel = value;
            }
        }
        public Boolean AutoHeaderNumber
        {
            get
            {
                return _mblnAutoHeaderNumber;
            }
            set
            {
                _mblnAutoHeaderNumber = value;
            }
        }
        [Browsable(false)]
        public int[] IndexArrayRowChange
        {
            get
            {


                _mIndexArrayRowChange = new int[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                    _mIndexArrayRowChange[i] = int.Parse(tbl.Rows[i][0].ToString());
                return _mIndexArrayRowChange;
            }
            set
            {
                _mIndexArrayRowChange = value;
            }
        }

        [Browsable(false)]
        public String CodeLanguage
        {
            get
            {
                return _msCodeLanguage;
            }
            set
            {
                _msCodeLanguage = value;
            }
        }
        [Browsable(false)]
        public Boolean AllowSearch
        {
            get
            {
                return _mblnAllowSearch;
            }
            set
            {
                _mblnAllowSearch = value;
            }
        }

        [Description("NotEmptyKey"), Category("HVTTGrid")]
        public String[] NotEmptyKey
        {
            get
            {
                return _sNotEmptyKey;
            }
            set
            {
                _sNotEmptyKey = value;
            }
        }

        [Description("ReadOnlyKey"), Category("HVTTGrid")]
        public String[] ReadOnlyKey
        {
            get
            {
                return _mReadOnlyKey;
            }
            set
            {
                _mReadOnlyKey = value;
            }
        }

        [Description("Keys"), Category("HVTTGrid")]
        public String[] ColKeys
        {
            get
            {
                return _mKeys;
            }
            set
            {
                _mKeys = value;
            }
        }

        [Description("IsChange"), Category("HVTTGrid"),
        Browsable(false)
        ]
        public Boolean IsChange
        {
            get
            {
                return _mbIsChange;
            }
            set
            {
                _mbIsChange = value;
            }
        }

        public Boolean AllowEdit
        {
            get
            {
                return _mblnAllowEdit;
            }
            set
            {
                _mblnAllowEdit = value;
                if (!GridTree)
                {
                    this.AllowUserToAddRows = _mblnAllowEdit;
                    this.AllowUserToDeleteRows = _mblnAllowEdit;
                }
            }
        }

        public SumaryColumn[] SumaryColumns
        {
            get
            {
                return _mSumaryColumns;
            }
            set
            {
                _mSumaryColumns = value;
            }
        }

        public KeyPressColumn[] KeyPressColumns
        {
            get
            {
                return _mKeyPressColumns;
            }
            set
            {
                _mKeyPressColumns = value;
            }
        }
        public String[] UpperCaseColumn
        {
            get
            {
                return _mUpperCaseColumns;
            }
            set
            {
                _mUpperCaseColumns = value;
            }
        }
        public String[] NumbericColumns
        {
            get
            {
                return _mNumbericColumns;
            }
            set
            {
                _mNumbericColumns = value;
            }
        }
        public DefaultValue[] DefaultValues
        {
            get
            {
                return _mDefaultValues;
            }
            set
            {
                _mDefaultValues = value;
            }
        }

        //private void Innit()
        //{
        //    Boolean bFlag = false;
        //    for (int i = 0; i < tbl.Columns.Count; i++)
        //    {
        //        if (tbl.Columns[i].ColumnName == "Indexs")
        //            bFlag = true;
        //    }
        //    if (!bFlag)
        //        tbl.Columns.Add(new DataColumn("Indexs"));
        //    //if (_sReadOnlyKey != null)
        //    //{
        //    //    for (int i = 0; i < this.Rows.Count; i++)
        //    //    {
        //    //        for (int j = 0; j < _sReadOnlyKey.Length; j++)
        //    //        {
        //    //            this.Rows[i].Cells[_sReadOnlyKey[j]].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        //    //        }
        //    //    }
        //    //}
        //}
#endregion

        #region Constructor
        public DataGridView()
            : base()
        {
            SetupScrollBars();

           
        }
        #endregion

        #region Public Method

        public void InnitCheckHeader(String ColumnName,String HeaderText)
        {
            DataGridViewCheckBoxColumn colCB = new DataGridViewCheckBoxColumn();
            colCB.Name = ColumnName;
            colCB.HeaderText = HeaderText;
            colCB.DataPropertyName = ColumnName;
            HVTTDatagridViewCheckBoxHeaderCell cbHeader = new HVTTDatagridViewCheckBoxHeaderCell();
            cbHeader.UsingIsChange = true;
            cbHeader.OnCheckBoxClicked+=new HVTTCheckBoxClickedHandler(cbHeader_OnCheckBoxClicked);
            colCB.HeaderCell = cbHeader;
            this.Columns.Add(colCB);
        }
        public void InnitCheckHeader(String ColumnName, String HeaderText,Boolean UsingIsChange)
        {
            DataGridViewCheckBoxColumn colCB = new DataGridViewCheckBoxColumn();
            colCB.Name = ColumnName;
            colCB.HeaderText = HeaderText;
            colCB.DataPropertyName = ColumnName;
            HVTTDatagridViewCheckBoxHeaderCell cbHeader = new HVTTDatagridViewCheckBoxHeaderCell();
            cbHeader.UsingIsChange = UsingIsChange;
            cbHeader.OnCheckBoxClicked += new HVTTCheckBoxClickedHandler(cbHeader_OnCheckBoxClicked);
            colCB.HeaderCell = cbHeader;
            this.Columns.Add(colCB);
        }
        private void cbHeader_OnCheckBoxClicked(Boolean bln)
        {
            if (HeaderCheckBoxClick != null)
                HeaderCheckBoxClick(bln);
        }

        public void MergeCellHeader(List<MergeHeaderCell>lst)
        {
            MergeHeaderCells = lst;
            if (MergeHeaderCells != null && MergeHeaderCells.Count > 0)
            {
                this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                this.ColumnHeadersHeight = this.ColumnHeadersHeight * 2;

                this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            }
        }
        

        public void UpdateCellValue(String ColumnName,int RowIndex)
        {
            this.UpdateCellValue(this.Columns[ColumnName].Index, RowIndex);
        }
        public void UpdateCellValue(String ColumnName)
        {
            this.UpdateCellValue(this.Columns[ColumnName].Index, this.CurrentRow.Index);
        }
        public void UpdateCellValue(String[] ColumnName)
        {
            if(ColumnName!=null)
            {
                foreach(var s in ColumnName)
                {
                    UpdateCellValue(s);
                }
            }
        }
        public void UpdateCellValue(String[] ColumnName,int RowIndex)
        {
            if (ColumnName != null)
            {
                foreach (var s in ColumnName)
                {
                    UpdateCellValue(s, RowIndex);
                }
            }
        }

        public void UpdateSumary()
        {


            if (_mSumaryColumns != null && _mSumaryColumns.Length > 0)
            {
                for (int j = 0; j < _mSumaryColumns.Length; j++)
                {
                    Decimal dblSum = 0;
                    for (int i = 0; i < this.Rows.Count; i++)
                    {
                        if (this.Rows[i] != null && this.Rows[i].Cells[_mSumaryColumns[j].ColumnName] != null && this.Rows[i].Cells[_mSumaryColumns[j].ColumnName].Value != null)
                        {

                            Decimal dbl = (this.Rows[i].Cells[_mSumaryColumns[j].ColumnName].Value.ToString() == "" ? 0 : Convert.ToDecimal(this.Rows[i].Cells[_mSumaryColumns[j].ColumnName].Value));
                            dblSum = dblSum + dbl;
                        }
                    }
                    if (_mSumaryColumns[j].DecimalLength < 0)
                    {
                        if (_mSumaryColumns[j].Format.Trim() == "")
                            _mSumaryColumns[j].TextControl.Text = dblSum.ToString();
                        else
                            _mSumaryColumns[j].TextControl.Text = dblSum.ToString(_mSumaryColumns[j].Format);
                    }
                    else
                    {
                        if (_mSumaryColumns[j].Format.Trim() == "")
                            _mSumaryColumns[j].TextControl.Text = Math.Round(dblSum, _mSumaryColumns[j].DecimalLength).ToString();
                        else
                            _mSumaryColumns[j].TextControl.Text = Math.Round(dblSum, _mSumaryColumns[j].DecimalLength).ToString(_mSumaryColumns[j].Format);
                    }
                }
            }

        }
        public void UpdateSumary(Decimal MinusValue,params String[] ColumnNames)
        {
            //if (this.Rows.Count <= 0)
            //    for (int k = 0; k < _mSumaryColumns.Length; k++)
            //        _mSumaryColumns[k].TextControl.Text = "0";
            //if (this.CurrentRow != null)
            //{

            if (_mSumaryColumns != null && _mSumaryColumns.Length > 0)
            {
                for (int j = 0; j < _mSumaryColumns.Length; j++)
                {
                    Decimal dblSum = 0;
                    for (int i = 0; i < this.Rows.Count; i++)
                    {
                        if (this.Rows[i] != null && this.Rows[i].Cells[_mSumaryColumns[j].ColumnName] != null && this.Rows[i].Cells[_mSumaryColumns[j].ColumnName].Value != null)
                        {
                            Decimal dbl = (this.Rows[i].Cells[_mSumaryColumns[j].ColumnName].Value.ToString() == "" ? 0 : Convert.ToDecimal(this.Rows[i].Cells[_mSumaryColumns[j].ColumnName].Value));
                            dblSum = dblSum + dbl;
                        }
                    }
                    for (int i = 0; i < ColumnNames.Length; i++)
                    {
                        if (ColumnNames[i] == _mSumaryColumns[j].ColumnName)
                            _mSumaryColumns[j].TextControl.Text = (dblSum - MinusValue).ToString();
                        else
                            _mSumaryColumns[j].TextControl.Text = dblSum.ToString();
                    }
                    
                }
            }
            //}
        }
        public Decimal GetSumary(String ColumnName)
        {
            Decimal dblSum = 0;
            if (ColumnName.Trim()!="")
            {
                
                for (int i = 0; i < this.Rows.Count; i++)
                {
                    if (this.Rows[i] != null && this.Rows[i].Cells[ColumnName]!= null && this.Rows[i].Cells[ColumnName].Value!= null)
                    {
                        Decimal dbl = (this.Rows[i].Cells[ColumnName].Value.ToString().Trim() == "" ? 0 : Convert.ToDecimal(this.Rows[i].Cells[ColumnName].Value));
                        dblSum = dblSum + dbl;
                    }
                }
            }
            return dblSum;
            //}
        }
        public void SetRecentCurentRow(int Index,String ColumnName)
        {
            try
            {
                this.FirstDisplayedScrollingRowIndex = Index;
                this.Refresh();
                this.CurrentCell = this.Rows[Index].Cells[ColumnName];
                this.CurrentRow.Selected = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetRowIndex(String Value, String ColumnName)
        {
            try
            {
                for (int i = 0; i <= this.Rows.Count; i++)
                {
                    if (this.Rows[i] != null && this.Rows[i].Cells[ColumnName].Value.ToString() == Value)
                        return i;
                }
                return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void New_Data()
        {
            try
            {
                DataGridViewCell cell = this.Rows[this.NewRowIndex].Cells[GetColumnName(GetMinDisplayIndexColumn())];
                this.CurrentCell = cell;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       

       

       

        public void NextColumn(int CurrentColumnIndex)
        {
            if (this.CurrentRow != null)
            {
                int DisplayIndexColumn = this.CurrentRow.Cells[CurrentColumnIndex].OwningColumn.DisplayIndex;
                for (int i = 0; i < this.Columns.Count; i++)
                {
                    if (this.Columns[i].DisplayIndex == DisplayIndexColumn + 1)
                    {
                        this.CurrentCell = this.CurrentRow.Cells[i];
                        this.BeginEdit(true);
                        return;
                    }
                }
                
            }
        }
        public void NextColumn(String CurrentColumnName)
        {
            if (this.CurrentRow != null)
            {
                int DisplayIndexColumn = this.CurrentRow.Cells[CurrentColumnName].OwningColumn.DisplayIndex;
                for (int i = 0; i < this.Columns.Count; i++)
                {
                    if (this.Columns[i].DisplayIndex == DisplayIndexColumn + 1)
                    {
                        this.CurrentCell = this.CurrentRow.Cells[i];
                        this.BeginEdit(true);
                        return;
                    }
                }

            }
        }
        #endregion

        #region Private Method
        private int Search(String s, String[] sArray)
        {
            for (int i = 0; i < sArray.Length; i++)
                if (sArray[i].ToUpper() == s.ToUpper())
                    return i;
            return -1;
        }
        private int Search(String s,SumaryColumn[]Columns)
        {
            for (int i = 0; i < Columns.Length; i++)
                if (s == Columns[i].ColumnName)
                    return i;
            return -1;
        }

        private void Sort_Search()
        {
            if (this.CurrentCell != null && this.CurrentCell.Value != null)
            {
                String str = this.CurrentCell.Value.ToString();
                String ColumnName = this.CurrentCell.OwningColumn.Name;
                for (int i = 0; i < this.Rows.Count; i++)
                {
                    if (this.Rows[i] != null && this.Rows[i].Cells[ColumnName] != null && this.Rows[i].Cells[ColumnName].Value != null)
                    {
                        if (this.Rows[i].Cells[ColumnName].Value.ToString().Contains(str))
                        {
                            int iIndex = i;
                            //this.RefreshEdit();
                            this.FirstDisplayedScrollingRowIndex = iIndex;
                            this.CurrentCell = this.Rows[iIndex].Cells[ColumnName];
                           // this.Refresh();
                        }
                    }
                }
            }

        }


        private void UpdateSelectionState()
        {
            SelectionInfo[] newSelection = new SelectionInfo[this.Columns.Count];
            for (int i = 0; i < this.Columns.Count; i++)
                newSelection[this.Columns[i].DisplayIndex].ColumnIndex = i;
            int columnCount = this.Columns.Count;

            if (this.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                if (this.CurrentCell != null)
                {
                    int displayIndex = this.Columns[this.CurrentCell.ColumnIndex].DisplayIndex;
                    newSelection[displayIndex].Selected = true;
                    newSelection[displayIndex].ColumnIndex = this.CurrentCell.ColumnIndex;
                }
            }
            else
            {
                foreach (DataGridViewCell cell in this.SelectedCells)
                {
                    if (cell.ColumnIndex == -1) continue;
                    int displayIndex = this.Columns[cell.ColumnIndex].DisplayIndex;
                    if (!newSelection[displayIndex].Selected)
                    {
                        columnCount--;
                        newSelection[displayIndex].Selected = true;
                        newSelection[displayIndex].ColumnIndex = cell.ColumnIndex;
                        if (columnCount == 0) break;
                    }
                }
            }

            for (int i = 0; i < newSelection.Length; i++)
            {
                if (m_ColumnSelectionState.Length > i && newSelection[i].Selected != m_ColumnSelectionState[i].Selected)
                {
                    this.InvalidateColumn(m_ColumnSelectionState[i].ColumnIndex);
                    if (m_ColumnSelectionState[i].ColumnIndex > 0) this.InvalidateColumn(m_ColumnSelectionState[i].ColumnIndex - 1);
                }
            }
            if (m_SelectedRowIndex > 0 && m_SelectedRowIndex < this.Rows.Count)
                this.InvalidateRow(m_SelectedRowIndex - 1);
            if (this.CurrentCell != null && this.CurrentCell.RowIndex > 0)
            {
                m_SelectedRowIndex = this.CurrentCell.RowIndex;
                this.InvalidateRow(m_SelectedRowIndex - 1);
            }
            else
                m_SelectedRowIndex = -2;
            m_ColumnSelectionState = newSelection;
        }

        private void InvalidatePreviousColumn(int displayIndex)
        {
            displayIndex--;
            for (int i = 0; i < this.Columns.Count; i++)
            {
                DataGridViewColumn c = this.Columns[i];
                if (c.Displayed && c.DisplayIndex == displayIndex)
                {
                    this.InvalidateColumn(i);
                    break;
                }
            }
        }

        private bool IsRepeatedCellValue(int rowIndex, int colIndex)
        {
            DataGridViewCell currCell =
               Rows[rowIndex].Cells[colIndex];
            DataGridViewCell prevCell =
               Rows[rowIndex - 1].Cells[colIndex];
            if ((currCell.Value == prevCell.Value) ||
               (currCell.Value != null && prevCell.Value != null &&
               currCell.Value.ToString() == prevCell.Value.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private int GetMinDisplayIndexColumn()
        {
            try
            {
                System.Collections.Generic.List<int> lstColumnIndex = new System.Collections.Generic.List<int>();
                for (int i = 0; i < this.Columns.Count; i++)
                    if (this.Columns[i].Displayed)
                        lstColumnIndex.Add(this.Columns[i].DisplayIndex);
                if (lstColumnIndex.Count <= 0)
                    return -1;
                lstColumnIndex.Sort();
                return lstColumnIndex[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private String GetColumnName(int DisplayIndex)
        {
            for (int i = 0; i < this.Columns.Count; i++)
                if (DisplayIndex == this.Columns[i].DisplayIndex)
                    return this.Columns[i].Name;
            return "";
        }
        private void Sort()
        {
            for (int i = 0; i < _mKeyPressColumns.Length - 1; i++)
            {
                for (int j = i + 1; j < _mKeyPressColumns.Length; j++)
                {
                    if (_mKeyPressColumns[i].Index >= _mKeyPressColumns[j].Index)
                    {
                        KeyPressColumn Col = _mKeyPressColumns[i];
                        _mKeyPressColumns[i] = _mKeyPressColumns[j];
                        _mKeyPressColumns[j] = Col;
                    }
                }
            }
        }
        private int GetLeaps(String CurrentColumnName)
        {
            try
            {
                int iRS = 0;
                String NextColumnName = "";
                int iIndex = -1;
                for (int i = 0; i < _mKeyPressColumns.Length; i++)
                {
                    if (_mKeyPressColumns[i].ColumnName == CurrentColumnName)
                    {
                        if (i < _mKeyPressColumns.Length - 1)
                        {
                            NextColumnName = _mKeyPressColumns[i + 1].ColumnName;
                            iIndex = i;
                            break;
                        }
                        else
                        {
                            NextColumnName = _mKeyPressColumns[0].ColumnName;
                            iIndex = 0;

                        }
                        //return 1;
                    }
                }
                //if (iIndex == -1)
                //{
                //    iIndex = 0;
                //    NextColumnName = _mKeyPressColumns[0].ColumnName;
                //}
                if (NextColumnName.Trim() == "")
                    return -1;
                for (int i = 0; i < this.Columns.Count; i++)
                {
                    Boolean blnFlag = false;
                    if (this.Columns[i].Name == CurrentColumnName)
                    {
                        for (int j = i; j < this.Columns.Count; j++)
                        {
                            if (NextColumnName != this.Columns[j].Name && this.Columns[j].Visible)
                                iRS++;
                            else if (NextColumnName == this.Columns[j].Name)
                                return iRS;
                        }
                        blnFlag = true;
                    }
                    if (blnFlag)
                        return iRS;
                }
                return iRS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.CurrentCell != null && Search(_mNumbericColumns, this.CurrentCell.OwningColumn.Name) >= 0)
            {
                if (!(char.IsDigit(e.KeyChar)))
                {
                    TextBox txt = sender as TextBox;
                    txt.TextAlign = HorizontalAlignment.Right;
                    if (e.KeyChar != '\b' && e.KeyChar != '.') //allow the backspace key and .
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void txt_KeyPress_Upper(object sender, KeyPressEventArgs e)
        {
            if (this.CurrentCell != null && Search(_mUpperCaseColumns, this.CurrentCell.OwningColumn.Name) >= 0)
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }
        private void txt_KeyPress_Normal(object sender, KeyPressEventArgs e)
        {

        }
        private int Search(String[] ColumnNames, String ColumnName)
        {
            for (int i = 0; i < ColumnNames.Length; i++)
            {
                if (ColumnNames[i] == ColumnName)
                    return i;
            }
            return -1;
        }
        #endregion

        #region Internal Implementation
        public event HVTTCheckBoxClickedHandler HeaderCheckBoxClick;
        public event HVTTGridBeforRowActive BeforeRowActive;

        public event HVTTEditControlClicked HVTTEditTextControlClicked;
        public event HVTTEditControlKeyDown HVTTEditTextControlKeyDown;
        public event HVTTEditControlLeave HVTTEditTextControlLeave;
        public event HVTTEditControlFocus HVTTEditTextControlFocus;

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);
            Office2007DataGridViewColorTable ct = GetColorTable();
            if (!m_Office2007StyleEnabled || ct == null ||
                e.Handled || e.ColumnIndex >= 0 && e.RowIndex >= 0 && 
                (!m_PaintEnhancedSelection  || (e.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.Selected)) return;

            Rectangle r = e.CellBounds;
            Graphics g = e.Graphics;
            LinearGradientColorTable bt = null;
            Color borderColor = Color.Empty;
            DataGridViewColumn column = null;
            if(MergeHeaderCells!=null && MergeHeaderCells.Count>0)
            {
                if (e.RowIndex == -1 && e.ColumnIndex > -1)
                {

                    Rectangle r2 = e.CellBounds;

                    r2.Y += e.CellBounds.Height / 2;

                    r2.Height = e.CellBounds.Height / 2;



                    e.PaintBackground(r2, true);



                    e.PaintContent(r2);

                    //e.Handled = true;

                }
            }
            

            int displayIndex = -1;
            if (e.ColumnIndex >= 0)
            {
                column = this.Columns[e.ColumnIndex];
                displayIndex = column.DisplayIndex;
            }

            if (e.ColumnIndex == -1 && e.RowIndex == -1)
            {
                // Paint top-left corner
                if (m_MouseOverColumnHeader == -1)
                {
                    bt = ct.SelectorMouseOverBackground;
                    borderColor = ct.SelectorMouseOverBorder;
                }
                else
                {
                    bt = ct.SelectorBackground;
                    borderColor = ct.SelectorBorder;
                }
                DisplayHelp.FillRectangle(g, r, bt);
                DisplayHelp.DrawRectangle(g, borderColor, r);
                if (m_MouseOverColumnHeader == -1)
                    borderColor = ct.SelectorMouseOverBorderLight;
                else
                    borderColor = ct.SelectorBorderLight;
                Rectangle inner = r;
                inner.Inflate(-1, -1);
                using (Pen p = new Pen(borderColor))
                {
                    g.DrawLine(p, inner.X, inner.Bottom - 1, inner.X, inner.Y);
                    g.DrawLine(p, inner.X, inner.Y, inner.Right - 1, inner.Y);
                }
                if (m_MouseOverColumnHeader == -1)
                    borderColor = ct.SelectorMouseOverBorderDark;
                else
                    borderColor = ct.SelectorBorderDark;
                using (Pen p = new Pen(borderColor))
                {
                    g.DrawLine(p, inner.Right - 1, inner.Y, inner.Right - 1, inner.Bottom - 1);
                    g.DrawLine(p, inner.X, inner.Bottom - 1, inner.Right - 1, inner.Bottom - 1);
                }

                if (m_SelectAllSignVisible)
                {
                    GraphicsPath path = GetSelectorPath(inner);
                    if (path != null)
                    {
                        DisplayHelp.FillPath(g, path, (m_MouseOverColumnHeader == -1 ? ct.SelectorMouseOverSign : ct.SelectorSign));
                        path.Dispose();
                    }
                }
            }
            else if (e.ColumnIndex == -1)
            {
                // Paint Rows
                bt = ct.RowNormalBackground;
                borderColor = ct.RowNormalBorder;

                if (m_MouseDownRowIndex == e.RowIndex)
                {
                    bt = ct.RowPressedBackground;
                    borderColor = ct.RowPressedBorder;
                }
                else if (m_SelectedRowIndex == e.RowIndex)
                {
                    if (m_MouseOverRowIndex == e.RowIndex)
                    {
                        bt = ct.RowSelectedMouseOverBackground;
                        borderColor = ct.RowSelectedMouseOverBorder;
                    }
                    else
                    {
                        bt = ct.RowSelectedBackground;
                        borderColor = ct.RowSelectedBorder;
                    }
                }
                else if (this.Rows[e.RowIndex].Selected)
                {
                    if (m_MouseOverRowIndex == e.RowIndex)
                    {
                        bt = ct.RowPressedBackground;
                        borderColor = ct.RowPressedBorder;
                    }
                    else
                    {
                        bt = ct.RowPressedBackground;
                        borderColor = ct.RowPressedBorder;
                    }
                }
                else if (m_MouseOverRowIndex == e.RowIndex)
                {
                    bt = ct.RowMouseOverBackground;
                    borderColor = ct.RowMouseOverBorder;
                }

                DisplayHelp.FillRectangle(g, r, bt);
                // Paint border
                using (Pen p = new Pen(borderColor))
                {
                    g.DrawLine(p, r.Right - 1, r.Y, r.Right - 1, r.Bottom - 1);
                    
                    if (m_SelectedRowIndex == e.RowIndex + 1)
                    {
                        Color bc = ct.RowSelectedBorder;
                        if (m_MouseDownRowIndex == e.RowIndex  + 1)
                            bc = ct.RowPressedBorder;
                        else if (m_MouseOverRowIndex == e.RowIndex + 1)
                            bc = ct.RowSelectedMouseOverBorder;
                        using (Pen p2 = new Pen(bc))
                            g.DrawLine(p2, r.X, r.Bottom - 1, r.Right - 1, r.Bottom - 1);
                    }
                    else
                        g.DrawLine(p, r.X, r.Bottom - 1, r.Right - 1, r.Bottom - 1);
                }

                e.PaintContent(r);
            }
            else if (e.RowIndex == -1)
            {
                // Determine Colors
                if (m_MouseDownColumnHeader == e.ColumnIndex)
                {
                    bt = ct.ColumnHeaderPressedBackground;
                    borderColor = ct.ColumnHeaderPressedBorder;
                }
                else if (m_MouseOverColumnHeader == e.ColumnIndex)
                {
                    if (m_HighlightSelectedColumnHeaders && (displayIndex >= 0 && e.ColumnIndex >= 0 && (m_ColumnSelectionState.Length > displayIndex && m_ColumnSelectionState[displayIndex].Selected || this.Columns[e.ColumnIndex].Selected)))
                    {
                        bt = ct.ColumnHeaderSelectedMouseOverBackground;
                        borderColor = ct.ColumnHeaderSelectedMouseOverBorder;
                    }
                    else
                    {
                        bt = ct.ColumnHeaderMouseOverBackground;
                        borderColor = ct.ColumnHeaderMouseOverBorder;
                    }
                }
                else if (!m_HighlightSelectedColumnHeaders)
                {
                    bt = ct.ColumnHeaderNormalBackground;
                    borderColor = ct.ColumnHeaderNormalBorder;
                }
                else if (displayIndex >= 0 && e.ColumnIndex >= 0 && (m_ColumnSelectionState.Length > e.ColumnIndex && m_ColumnSelectionState[displayIndex].Selected || this.Columns[e.ColumnIndex].Selected))
                {
                    bt = ct.ColumnHeaderSelectedBackground;
                    borderColor = ct.ColumnHeaderSelectedBorder;
                }
                else
                {
                    if (this.Columns[e.ColumnIndex].Selected)
                    {
                        bt = ct.ColumnHeaderPressedBackground;
                        borderColor = ct.ColumnHeaderPressedBorder;
                    }
                    else
                    {
                        bt = ct.ColumnHeaderNormalBackground;
                        borderColor = ct.ColumnHeaderNormalBorder;
                    }
                }

                // Paint row markers
                DisplayHelp.FillRectangle(g, r, bt);
                // Paint border
                using (Pen p = new Pen(borderColor))
                {
                    g.DrawLine(p, r.X, r.Bottom-1, r.Right, r.Bottom-1);
                    //if (displayIndex == 0)
                    //    g.DrawLine(p, r.X, r.Y, r.X, r.Bottom - 1);

                    if (m_HighlightSelectedColumnHeaders && (displayIndex>=0 && m_ColumnSelectionState.Length > displayIndex + 1 && (m_ColumnSelectionState[displayIndex + 1].Selected ||
                        m_ColumnSelectionState[displayIndex + 1].ColumnIndex == m_MouseDownColumnHeader)))
                    {
                        Color bc = ct.ColumnHeaderSelectedBorder;
                        if (m_ColumnSelectionState[displayIndex + 1].ColumnIndex == m_MouseDownColumnHeader)
                            bc = ct.ColumnHeaderPressedBorder;
                        else if (m_MouseOverColumnHeader == displayIndex + 1)
                            bc = ct.ColumnHeaderSelectedMouseOverBorder;
                        using (Pen p2 = new Pen(bc))
                            g.DrawLine(p2, r.Right - 1, r.Y, r.Right - 1, r.Bottom - 1);
                    }
                    else
                        g.DrawLine(p, r.Right - 1, r.Y, r.Right - 1, r.Bottom - 1);
                }
                e.PaintContent(r);
            }
            else if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
            {
                e.PaintBackground(r, false);
                r.Height--;
                Office2007ButtonItemPainter.PaintBackground(g, m_ButtonStateColorTable, r, 0, false, false);
                r.Height++;
                e.PaintContent(r);
            }

            /*
            e.AdvancedBorderStyle.Bottom =
                DataGridViewAdvancedCellBorderStyle.None;
            // Ignore column and row headers and first row
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsRepeatedCellValue(e.RowIndex, e.ColumnIndex))
            {

                e.AdvancedBorderStyle.Top =
                   DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = AdvancedCellBorderStyle.Top;
            }
            */
            e.Handled = true;
        }

        private GraphicsPath GetSelectorPath(Rectangle inner)
        {
            inner.Inflate(-3, -3);
            if (inner.Width > 2 && inner.Height > 2)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddLine(inner.Right, inner.Y, inner.Right, inner.Bottom);
                path.AddLine(inner.Right, inner.Bottom, inner.Right - inner.Height, inner.Bottom);
                path.CloseAllFigures();
                return path;
            }

            return null;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (GlobalManager.Renderer is Office2007Renderer)
            {
                Office2007DataGridViewColorTable ct = ((Office2007Renderer)GlobalManager.Renderer).ColorTable.DataGridView;
                UpdateOffice2007Styles(ct);
            }
            base.OnHandleCreated(e);
        }

        private void UpdateOffice2007Styles(Office2007DataGridViewColorTable ct)
        {
            if (this.GridColor != ct.GridColor)
                this.GridColor = ct.GridColor;
            if(m_PaintEnhancedSelection)
                this.DefaultCellStyle.SelectionForeColor = this.DefaultCellStyle.ForeColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                Office2007ColorTable ct = null;
                if (GlobalManager.Renderer is Office2007Renderer)
                {
                    ct = ((Office2007Renderer)GlobalManager.Renderer).ColorTable;
                    m_ColorTable = ct.DataGridView;
                    m_ButtonStateColorTable = ct.ButtonItemColors[0].Checked;
                }

                if (this.CurrentCell != null)
                {
                    m_SelectedRowIndex = this.CurrentCell.RowIndex;
                }
                else
                    m_SelectedRowIndex = -1;

                base.OnPaint(e);


                if (this.VerticalScrollBar.Visible && this.HorizontalScrollBar.Visible)
                {
                    Rectangle r = new Rectangle(this.VerticalScrollBar.Left, this.VerticalScrollBar.Bottom, this.VerticalScrollBar.Width, this.HorizontalScrollBar.Height);
                    Color c = ct.AppScrollBar.Default.Background.End;
                    if (c.IsEmpty) c = ct.AppScrollBar.Default.Background.Start;
                    DisplayHelp.FillRectangle(e.Graphics, r, c);
                    //e.Graphics.FillRectangle(Brushes.BlueViolet, r);
                }

                if (MergeHeaderCells != null && MergeHeaderCells.Count > 0)
                {
                    foreach (var x in MergeHeaderCells)
                    {
                        int iFromIndex = Columns[x.FromColumnName].Index;
                        int iToIndex = Columns[x.ToColumnName].Index;

                        Rectangle r1 = this.GetCellDisplayRectangle(iFromIndex, -1, true);

                        int iWith = 0;
                        int i = iFromIndex + 1;
                        while (i <= iToIndex)
                        {
                            iWith += this.GetCellDisplayRectangle(i, -1, true).Width;
                            i++;
                        }


                        r1.X += 1;

                        r1.Y += 1;

                        r1.Width = r1.Width + iWith - 2;

                        r1.Height = r1.Height / 2 - 2;

                        e.Graphics.FillRectangle(new SolidBrush(this.ColumnHeadersDefaultCellStyle.BackColor), r1);

                        StringFormat format = new StringFormat();

                        format.Alignment = StringAlignment.Center;

                        format.LineAlignment = StringAlignment.Center;

                        e.Graphics.DrawString(x.DisplayName,
                            this.ColumnHeadersDefaultCellStyle.Font,
                            new SolidBrush(this.ColumnHeadersDefaultCellStyle.ForeColor),
                            r1,
                            format);
                    }
                }

                m_ColorTable = null;
                m_ButtonStateColorTable = null;
            }
            catch { }

           


        }

        protected override void OnCurrentCellChanged(EventArgs e)
        {
            if (this.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
                UpdateSelectionState();

            //UpdateCellValue(this.CurrentCell.ColumnIndex, this.CurrentRow.Index);
            base.OnCurrentCellChanged(e);
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            if (this.CurrentRow != null && _miRowIndex != this.CurrentRow.Index)
                if (BeforeRowActive != null)
                {
                    BeforeRowActive(this, this.CurrentRow);
                    _miRowIndex = this.CurrentRow.Index;
                }
            UpdateSelectionState();
            base.OnSelectionChanged(e);

         
        }
        protected override void OnRowStateChanged(int rowIndex, DataGridViewRowStateChangedEventArgs e)
        {
            base.OnRowStateChanged(rowIndex, e);
            if (this.CurrentRow != null && _miRowIndex != this.CurrentRow.Index)
                if (BeforeRowActive != null)
                {
                    BeforeRowActive(this, this.CurrentRow);
                    _miRowIndex = this.CurrentRow.Index;
                }
        }
        protected override void OnDataSourceChanged(EventArgs e)
        {
           
            base.OnDataSourceChanged(e);
            UpdateSelectionState();
            _miRowIndex = -1;
            
        }

        protected override void OnDataError(bool displayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e)
        {
            //if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && (this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() == "" || this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() == "0"))
            //{
            //    displayErrorDialogIfNoHandler = false;
            //}
            
            e.Cancel = false;
            base.OnDataError(false, e);
            
        }

        /*
        protected override void OnCellFormatting(

              DataGridViewCellFormattingEventArgs args)
        {
            // Call home to base
            base.OnCellFormatting(args);
            // First row always displays
            if (args.RowIndex == 0)
                return;
            if (IsRepeatedCellValue(args.RowIndex, args.ColumnIndex))
            {
                args.Value = string.Empty;
                args.FormattingApplied = true;
            }
        }
        */

            
        protected virtual Office2007DataGridViewColorTable GetColorTable()
        {
            return m_ColorTable;
        }

        protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                m_MouseDownColumnHeader = e.ColumnIndex;
                if (e.ColumnIndex >= 0)
                    this.InvalidatePreviousColumn(this.Columns[e.ColumnIndex].DisplayIndex);
            }
            else
                m_MouseDownColumnHeader = -2;

            if (e.ColumnIndex == -1)
            {
                m_MouseDownRowIndex = e.RowIndex;
                if (m_MouseDownRowIndex > 0 && m_MouseDownRowIndex < this.Rows.Count)
                    this.InvalidateRow(m_MouseDownRowIndex - 1);
            }
            else
                m_MouseDownRowIndex = -2;

            base.OnCellMouseDown(e);
        }

     
        protected override void OnCellMouseUp(DataGridViewCellMouseEventArgs e)
        {
            if (m_MouseDownRowIndex > 0 && m_MouseDownRowIndex < this.Rows.Count)
                this.InvalidateRow(m_MouseDownRowIndex - 1);
            if(m_MouseDownRowIndex>=0)
                this.InvalidateRow(m_MouseDownRowIndex);

            m_MouseDownRowIndex = -2;
            m_MouseDownColumnHeader = -2;
            base.OnCellMouseUp(e);
        }

        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                m_MouseOverColumnHeader = e.ColumnIndex;
            else
                m_MouseOverColumnHeader = -2;
            if (e.ColumnIndex == -1)
            {
                if (m_MouseOverRowIndex != e.RowIndex)
                {
                    m_MouseOverRowIndex = e.RowIndex;
                    if (m_MouseOverRowIndex > 0)
                        this.InvalidateRow(m_MouseOverRowIndex - 1);
                }
            }
            else
                m_MouseOverRowIndex = -2;
            base.OnCellMouseEnter(e);
        }

        protected override void OnCellMouseLeave(DataGridViewCellEventArgs e)
        {
            m_MouseOverColumnHeader = -2;
            m_MouseOverRowIndex = -2;
            base.OnCellMouseLeave(e);
        }

        

        
       

        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (_mblnAutoHeaderNumber)
                {
                    string strRowNumber = (e.RowIndex + 1).ToString();

                    //prepend leading zeros to the string if necessary to improve
                    //appearance. For example, if there are ten rows in the grid,
                    //row seven will be numbered as "07" instead of "7". Similarly, if 
                    //there are 100 rows in the grid, row seven will be numbered as "007".
                    while (strRowNumber.Length < this.RowCount.ToString().Length)
                        strRowNumber = "0" + strRowNumber;

                    //determine the display size of the row number string using
                    //the DataGridView's current font.
                    SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);

                    //adjust the width of the column that contains the row header cells 
                    //if necessary
                    if (this.RowHeadersWidth < (int)(size.Width + 20))
                        this.RowHeadersWidth = (int)(size.Width + 20);

                    //this brush will be used to draw the row number string on the
                    //row header cell using the system's current ControlText color
                    Brush b = SystemBrushes.ControlText;

                    //draw the row number string on the current row header cell using
                    //the brush defined above and the DataGridView's default font
                    e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));

                }
                base.OnRowPostPaint(e);
            }
            catch { }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            try
            {
                if (_mKeys != null && _mKeys.Length > 0)
                {
                    if (e.Control && e.KeyCode == Keys.N)
                    {
                        DataGridViewCell cell = this.Rows[this.NewRowIndex].Cells[_mKeys[0]];
                        this.CurrentCell = cell;
                    }
                }

                //if (e.Control && e.KeyCode == Keys.F)
                //{
                //    DataTable dt = new DataTable();
                //    dt.Columns.AddRange(new DataColumn[] { new DataColumn("Code"), new DataColumn("Text") });
                //    for (int i = 0; i < this.Columns.Count; i++)
                //    {
                //        if (this.Columns[i].Visible)
                //        {
                //            dt.Rows.Add(this.Columns[i].Name, this.Columns[i].HeaderText);
                //        }
                //    }
                    

                //}

            }
            catch
            {
                //throw ex;
            }
            base.OnKeyDown(e);
        }

        int iPressColumn = 0;
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            try
            {
                if (this.Rows.Count > 0)
                {
                    if (_mblnUseEnterKey)
                    {
                        if (e.KeyData == Keys.Enter)
                        {
                            //if (this.CurrentCell != null && this.CurrentCell.DataGridView.EditingControl is HVTTEditText)
                            //{
                            //    HVTTEditText txt = this.CurrentCell.DataGridView.EditingControl as HVTTEditText;
                            //    if (txt != null)
                            //    {
                            //        if (!txt.Test_Value())
                            //        {
                            //            txt.Focus();
                            //            HVTTMessages.Show(_HVTTSys.GetMessage("RQ002"), "", HVTTMessages.HVTTMessageTypes.Warning);
                            //            txt.Text = "";
                            //            return false;
                            //        }
                            //    }
                            //}

                            bool retCode;
                            if (_mKeyPressColumns != null && _mKeyPressColumns.Length > 0)
                            {

                                Sort();
                                StandardTab = false;
                                int iLeads = GetLeaps(this.CurrentCell.OwningColumn.Name);
                                if (iLeads > 0 && iLeads > 1)
                                {

                                    for (int i = 0; i < iLeads - 1; i++)
                                        base.ProcessTabKey(Keys.Tab);
                                }
                                //MessageBox.Show(iLeads.ToString());
                                retCode = base.ProcessTabKey(Keys.Tab);
                                StandardTab = true;
                                if (this.CurrentCell == null)
                                    return base.ProcessDataGridViewKey(e);
                                this.BeginEdit(true);
                                return retCode;
                            }
                            this.BeginEdit(true);
                            StandardTab = false;
                            if (this.CurrentCell == null)
                                return base.ProcessDataGridViewKey(e);

                            retCode = base.ProcessTabKey(Keys.Tab);
                            StandardTab = true;
                            return retCode;
                        }
                    }
                }
                if (e.Control && e.KeyData == Keys.End)
                {
                    if (this.CurrentRow != null)
                    {

                        this.CurrentRow.Selected = true;
                        this.Refresh();
                        return ProcessEscapeKey(Keys.Escape);
                    }
                }
                
            }
            catch { }
            return base.ProcessDataGridViewKey(e);
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            try
            {
                if (this.Rows.Count > 0)
                {
                    if (_mblnUseEnterKey)
                    {
                        if (keyData == Keys.Enter)
                        {
                            //if (this.CurrentCell != null && this.CurrentCell.DataGridView.EditingControl is HVTTEditText)
                            //{
                            //    HVTTEditText txt = this.CurrentCell.DataGridView.EditingControl as HVTTEditText;
                            //    if (txt != null)
                            //    {
                            //        if (!txt.Test_Value())
                            //        {

                            //            txt.Focus();
                            //            return false;
                            //        }
                            //    }
                            //}
                            bool retCode;
                            if (_mKeyPressColumns != null && _mKeyPressColumns.Length > 0)
                            {

                                Sort();
                                StandardTab = false;
                                int iLeads = GetLeaps(this.CurrentCell.OwningColumn.Name);
                                if (iLeads > 0 && iLeads > 1)
                                {
                                    for (int i = 0; i < iLeads - 1; i++)
                                        base.ProcessTabKey(Keys.Tab);
                                }
                                retCode = base.ProcessTabKey(Keys.Tab);
                                StandardTab = true;
                                if (this.CurrentCell == null)
                                    return base.ProcessDialogKey(keyData);

                                this.BeginEdit(true);
                                return retCode;
                            }
                            if (this.CurrentCell != null)
                            {

                            }
                            StandardTab = false;
                            retCode = base.ProcessTabKey(Keys.Tab);
                            StandardTab = true;
                            if (this.CurrentCell == null)
                                return base.ProcessDialogKey(keyData);
                            this.BeginEdit(true);
                            return retCode;
                        }

                    }
                }
                else if (_mblnAllowSearch)
                {
                    if (this.Rows.Count > 0)
                    {
                        if (keyData == Keys.Enter)
                        {
                            //Sort_Search();
                        }
                    }
                }
                if (keyData == Keys.End)
                {
                    if (this.CurrentRow != null)
                    {
                        this.CurrentRow.Selected = true;
                        this.Refresh();
                        return ProcessEscapeKey(Keys.Escape);
                    }
                }
            }
            catch { }
            return base.ProcessDialogKey(keyData);

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (this.Rows.Count > 0 && this.CurrentCell != null)
                {
                    if (_mblnUseEnterKey)
                    {
                        if (keyData == Keys.Down)
                        {
                            this.EndEdit();
                        }
                    }
                }
            }
            catch { }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private struct SelectionInfo
        {
            public bool Selected;
            public int ColumnIndex;
        }
        protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = this.DisplayRectangle;

            rtHeader.Height = this.ColumnHeadersHeight / 2;

            this.Invalidate(rtHeader);

            base.OnColumnWidthChanged(e);

        }
        protected override void OnScroll(ScrollEventArgs e)
        {
            if(MergeHeaderCells!=null && MergeHeaderCells.Count>0)
            {
                Rectangle rtHeader = this.DisplayRectangle;

                rtHeader.Height = this.ColumnHeadersHeight / 2;

                this.Invalidate(rtHeader);
            }
            base.OnScroll(e);
            DGVScrollBar vsb = GetVScrollBar();
            if (vsb != null && vsb.Visible) vsb.UpdateScrollValues();

            DGHScrollBar hsb = GetHScrollBar();
            if (hsb != null && hsb.Visible) hsb.UpdateScrollValues();
        }

        private DGVScrollBar GetVScrollBar()
        {
            return this.VerticalScrollBar as DGVScrollBar;
            //Type t = typeof(System.Windows.Forms.DataGridView);
            //FieldInfo fi = t.GetField("vertScrollBar", BindingFlags.NonPublic | BindingFlags.Instance);
            //if (fi == null) return null;
            //DGVScrollBar sb = fi.GetValue(this) as DGVScrollBar;
            //return sb;
        }

        private DGHScrollBar GetHScrollBar()
        {
            return this.HorizontalScrollBar as DGHScrollBar;
            //Type t = typeof(System.Windows.Forms.DataGridView);
            //FieldInfo fi = t.GetField("horizScrollBar", BindingFlags.NonPublic | BindingFlags.Instance);
            //if (fi == null) return null;
            //DGHScrollBar sb = fi.GetValue(this) as DGHScrollBar;
            //return sb;
        }

        private void SetupScrollBars()
        {
            // Vertical Scroll Bar Replacement
            Type t = typeof(System.Windows.Forms.DataGridView);
            FieldInfo fi = t.GetField("vertScrollBar", BindingFlags.NonPublic | BindingFlags.Instance);
            if(fi==null) return;
            System.Windows.Forms.ScrollBar sb = fi.GetValue(this) as System.Windows.Forms.ScrollBar;
            if (sb == null) return;
            //sb.Scroll += new ScrollEventHandler(sb_Scroll); return;
            MethodInfo mi = t.GetMethod("DataGridViewVScrolled", BindingFlags.NonPublic | BindingFlags.Instance);
            if (mi == null) return;

            DGVScrollBar newVSb = new DGVScrollBar();
            newVSb.AppStyleScrollBar = true;
            newVSb.Minimum = sb.Minimum;
            newVSb.Maximum = sb.Maximum;
            newVSb.SmallChange = sb.SmallChange;
            newVSb.LargeChange = sb.LargeChange;
            newVSb.Top = sb.Top;
            newVSb.AccessibleName = sb.AccessibleName;
            newVSb.Left = sb.Left;
            newVSb.Visible = sb.Visible;
            newVSb.Scroll += (ScrollEventHandler)ScrollEventHandler.CreateDelegate(typeof(ScrollEventHandler), this, mi);
            fi.SetValue(this, newVSb);
            sb.Dispose();
            this.Controls.Remove(sb);
            this.Controls.Add(newVSb);

            // Horizontal Scroll Bar Replacement
            fi = t.GetField("horizScrollBar", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fi == null) return;
            sb = fi.GetValue(this) as System.Windows.Forms.ScrollBar;
            if (sb == null) return;
            mi = t.GetMethod("DataGridViewHScrolled", BindingFlags.NonPublic | BindingFlags.Instance);
            if (mi == null) return;

            DGHScrollBar newHSb = new DGHScrollBar();
            newHSb.AppStyleScrollBar = true;
            newHSb.Minimum = sb.Minimum;
            newHSb.Maximum = sb.Maximum;
            newHSb.SmallChange = sb.SmallChange;
            newHSb.LargeChange = sb.LargeChange;
            newHSb.Top = sb.Top;
            newHSb.AccessibleName = sb.AccessibleName;
            newHSb.Left = sb.Left;
            newHSb.Visible = sb.Visible;
            newHSb.RightToLeft = sb.RightToLeft;
            newHSb.Scroll += (ScrollEventHandler)ScrollEventHandler.CreateDelegate(typeof(ScrollEventHandler), this, mi);
            fi.SetValue(this, newHSb);
            sb.Dispose();
            this.Controls.Remove(sb);
            this.Controls.Add(newHSb);
        }

        //void sb_Scroll(object sender, ScrollEventArgs e)
        //{
        //    Console.WriteLine(e.NewValue);
        //}

        /// <summary>
        /// Gets or sets whether selected column header is highlighted. Default value is true.
        /// </summary>
        [Browsable(true), DefaultValue(true), Category("Behavior"), Description("Indicates whether selected column header is highlighted.")]
        public bool HighlightSelectedColumnHeaders
        {
            get { return m_HighlightSelectedColumnHeaders; }
            set
            {
                m_HighlightSelectedColumnHeaders = value;
                if(BarFunctions.IsHandleValid(this))
                    this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets whether select all sign displayed in top-left corner of the grid is visible. Default value is true.
        /// </summary>
        [Browsable(true), DefaultValue(true), Category("Behavior"), Description("Indicates whether select all sign displayed in top-left corner of the grid is visible.")]
        public bool SelectAllSignVisible
        {
            get { return m_SelectAllSignVisible; }
            set
            {
                m_SelectAllSignVisible = value;
                if (BarFunctions.IsHandleValid(this))
                    this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets whether enhanced selection for the cells is painted in Office 2007 style. Default value is true.
        /// </summary>
        [Browsable(true), DefaultValue(true), Category("Appearance"), Description("Indicates whether enhanced selection for the cells is painted in Office 2007 style")]
        public bool PaintEnhancedSelection
        {
            get { return m_PaintEnhancedSelection; }
            set
            {
                m_PaintEnhancedSelection = value;
                if (BarFunctions.IsHandleValid(this))
                    this.Invalidate();
            }
        }

        public Boolean ActiveReadonlyKey(Boolean bActive)
        {
            if (_mReadOnlyKey != null)
            {
                if (_mReadOnlyKey.Length > 0)
                {
                    for (int i = 0; i < this.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < _mReadOnlyKey.Length; j++)
                        {

                            this.Rows[i].Cells[_mReadOnlyKey[j]].ReadOnly = bActive;
                        }
                    }
                }
            }
            return bActive;
        }

        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            base.OnEditingControlShowing(e);
            if (e.Control is TextBox)
            {


                if (_mNumbericColumns != null && _mNumbericColumns.Length > 0)
                {
                    if (this.CurrentCell != null)
                    {
                        if (Search(_mNumbericColumns, this.CurrentCell.OwningColumn.Name) >= 0)
                        {
                            TextBox txt = e.Control as TextBox;
                            txt.TextAlign = HorizontalAlignment.Right;
                            txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                        }
                    }
                }
                if (_mUpperCaseColumns != null && _mUpperCaseColumns.Length > 0)
                {
                    if (this.CurrentCell != null)
                    {
                        if (Search(_mUpperCaseColumns, this.CurrentCell.OwningColumn.Name) >= 0)
                        {
                            TextBox txt = e.Control as TextBox;
                            txt.KeyPress += new KeyPressEventHandler(txt_KeyPress_Upper);
                        }
                    }
                }

            }
            //if (e.Control is HVTTEditText)
            //{
            //    HVTTEditText editText = e.Control as HVTTEditText;
            //    editText.Name = this.CurrentCell.OwningColumn.Name;
            //    editText.ButtonClick+=new EventHandler(EditText_ButtonClick);
            //    editText.KeyDown+=new KeyEventHandler(EditText_KeyDown);
            //    editText.Leave += new EventHandler(EditText_Leave);
            //    editText.HasFocus+=new EventHandler(EditText_Focus);
            //}
        }
        
        #endregion

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView
            // 
            this.DataSourceChanged += new System.EventHandler(this.DataGridView_DataSourceChanged);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

            this.RowHeadersWidth = 41;
        }


        #region SubClasses

        public class MergeHeaderCell
        {
            public String FromColumnName { get; set; }
            public String ToColumnName { get; set; }
            public String DisplayName { get; set; }
        }
        public class SumaryColumn
        {
            private int _miDecimalLength = -1;
            private String _mstrColumnName = String.Empty;
            private Control _mTextControl = null;
            private String _mstrConditional = String.Empty;
            private String _mstrFormat = String.Empty;

            public String ColumnName
            {
                get
                {
                    return _mstrColumnName;
                }
                set
                {
                    _mstrColumnName = value;
                }
            }
            public String Format
            {
                get
                {
                    return _mstrFormat;
                }
                set
                {
                    _mstrFormat = value;
                }
            }
            public Control TextControl
            {
                get
                {
                    return _mTextControl;
                }
                set
                {
                    _mTextControl = value;
                }
            }
            public String Conditional
            {
                get
                {
                    return _mstrConditional;
                }
                set
                {
                    _mstrConditional = value;
                }
            }
            public int DecimalLength
            {
                get
                {
                    return _miDecimalLength;
                }
                set
                {
                    _miDecimalLength = value;
                }
            }
        }


        public class KeyPressColumn
        {
            private String _mstrColumnName = String.Empty;
            private int _miIndex = 0;

            public String ColumnName
            {
                get
                {
                    return _mstrColumnName;
                }
                set
                {
                    _mstrColumnName = value;
                }
            }
            public int Index
            {
                get
                {
                    return _miIndex;
                }
                set
                {
                    _miIndex = value;
                }
            }
        }
        public class DefaultValue
        {
            private String _mstrColumnName = String.Empty;
            private String _mstrValue = "";
            private DefaultDataTypes _mDataType = DefaultDataTypes.String;

            public String ColumnName
            {
                get
                {
                    return _mstrColumnName;
                }
                set
                {
                    _mstrColumnName = value;
                }
            }
            public String Value
            {
                get
                {
                    return _mstrValue;
                }
                set
                {
                    _mstrValue = value;
                }
            }
            public DefaultDataTypes DataType
            {
                get
                {
                    return _mDataType;
                }
                set
                {
                    _mDataType = value;
                }
            }
        }
        public enum DefaultDataTypes
        {
            String,
            Datetime
        }
        #endregion

        private void DataGridView_DataSourceChanged(object sender, EventArgs e)
        {
           
        }

    }
}
//#endif