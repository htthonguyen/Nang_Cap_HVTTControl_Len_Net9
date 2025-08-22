using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace HVTT.UI.Window.Forms.Controls
{
	/// <summary>
	/// HVTTMultiColumnComboBox for HVTT.
	/// </summary>
    public delegate void AfterSelected(Object sender, EventArgs e);

	public class HVTTMultiColumnComboBox : HVTT.UI.Window.Forms.Controls.HVTTComboBox
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		

		public HVTTMultiColumnComboBox(System.ComponentModel.IContainer container)
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			container.Add(this);
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        public HVTTMultiColumnComboBox()
		{
			InitializeComponent();
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

        #region Event
        public event AfterSelected AfterDropDown;
        public new event EventHandler SelectedIndexChanged;
        public new event EventHandler SelectedValueChanged;

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
        }
        protected override void OnDropDown(System.EventArgs e)
        {

            //this.DroppedDown = false;
            this.DropDownHeight = 1;
            this.DropDownWidth = 1;
            if (this._mDataTable != null && this._mDataTable.Rows.Count > 0)
            {
                Form parent = this.FindForm();

                //Point Locationparent = GetParentLocation(this);

                //Point pScreen = new Point();
                //foreach (Screen scr in Screen.AllScreens)
                //{
                //    pScreen.X += scr.Bounds.Width;
                //    pScreen.Y += scr.Bounds.Height;
                //}


				MultiColumnComboPopup popup = new MultiColumnComboPopup(this._mDataTable,this._mSelectedRow,_miSelectedIndex,_mDisplayColumns,_mblnShowRowHeader,_mblnShowColumnHeader);
                popup.AfterRowSelectEvent += new AfterRowSelectEventHandler(MultiColumnComboBox_AfterSelectEvent);
                popup.Location = InnitLocation(GetLocation(parent), popup);
				popup.Show();
                popup.Activate();
				if(popup.SelectedRow!=null)
                {
					try
                    {
						this._mSelectedRow = popup.SelectedRow;
                        int iIndexKey = FindKey();
                        if (iIndexKey < 0)
                            this.Text = "";
                        else
                            this.Text = this._mSelectedRow[_mDisplayColumns[iIndexKey].ColumnName].ToString();
                        //this.Value = popup.SelectedRow[this.ValueMember].ToString();
					}
                    catch(Exception e2) 
                    {
                        throw e2;
					}
				}
			}
			base.OnDropDown(e);
            if (AfterDropDown != null)
                AfterDropDown(this, e);
		}
        protected override void OnTextChanged(EventArgs e)
        {
            
            base.OnTextChanged(e);
        }


        #endregion

        #region Properties

        private DataRow _mSelectedRow = null;
        private HVTTMultiComboBoxDisplayColumn[] _mDisplayColumns = null;
        private int _miSelectedIndex = -1;
        private DataTable _mDataTable = null;
        private Boolean _mblnAllowLoadLanguage = false;
        private Boolean _mblnShowColumnHeader = true;
        private Boolean _mblnShowRowHeader = false;

        //public new Object SelectedValue
        //{
        //    get
        //    {
        //        return _mobjSelectedValue;
        //    }
        //    set
        //    {
        //        try
        //        {
        //            _mobjSelectedValue = value;
        //            if (dataTable != null && ValueMember != null && ValueMember.Trim() != "" && _mobjSelectedValue != null)
        //            {
        //                int iSearch = Search(_mobjSelectedValue.ToString());
        //                if (iSearch >= 0)
        //                {
        //                    selectedRow = dataTable.Rows[iSearch];
        //                    _miSelectedIndex = iSearch;
        //                    //this.SelectedText = selectedRow[_mstrDisplayValue].ToString();
        //                    this.Text = selectedRow[_mstrDisplayMember].ToString();
        //                }
        //                else
        //                    throw new ExecutionEngineException("Value was not in datasource");
        //            }
        //            this.Value = (_mobjSelectedValue == null ? "" : _mobjSelectedValue.ToString());
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}
        //public DataRow SelectedRow
        //{
        //    get
        //    {
        //        return selectedRow;
        //    }
        //}

        //public String DisplayValue
        //{
        //    get
        //    {
        //        return _mstrDisplayValue;
        //    }
        //}

        //public new String DisplayMember
        //{
        //    set
        //    {
        //        _mstrDisplayMember = value;
        //    }
        //}
        //public new int SelectedIndex
        //{
        //    get
        //    {
        //        return _miSelectedIndex;
        //    }
        //    set
        //    {
        //        try
        //        {
        //            _miSelectedIndex = value;
        //            if (_miSelectedIndex >= 0 && dataTable != null)
        //            {
        //                if (_miSelectedIndex >= dataTable.Rows.Count)
        //                    throw new ExecutionEngineException("Index out of DataSource!");
        //                else
        //                {
        //                    selectedRow = dataTable.Rows[_miSelectedIndex];
        //                    if (ValueMember != null && ValueMember.Trim() != "")
        //                        this._mobjSelectedValue = selectedRow[ValueMember];
        //                    this.Text = selectedRow[_mstrDisplayMember].ToString();
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
                
        //    }
        //}
        [Browsable(false)]
        public new DataTable DataSource
        {
            set
            {
                try
                {
                    _mDataTable = value;
                    if (_mDataTable == null)
                        return;
                    if (_mDisplayColumns == null)
                    {
                        _mDisplayColumns = new HVTTMultiComboBoxDisplayColumn[_mDataTable.Columns.Count];
                        for (int i = 0; i < _mDataTable.Columns.Count; i++)
                        {
                            _mDisplayColumns[i] = new HVTTMultiComboBoxDisplayColumn();
                            _mDisplayColumns[i].ColumnName = _mDataTable.Columns[i].ColumnName;
                            _mDisplayColumns[i].ColumnText = _mDataTable.Columns[i].ColumnName;
                            _mDisplayColumns[i].Index = i;
                            _mDisplayColumns[i].Width = 100;
                        }
                    }
                    if (_miSelectedIndex >= 0 && _mDataTable != null)
                    {
                        if (_miSelectedIndex >= _mDataTable.Rows.Count)
                            throw new ExecutionEngineException("Index out of DataSource!");
                        else
                        {
                            _mSelectedRow = _mDataTable.Rows[_miSelectedIndex];

                            int iIndexKey = FindKey();
                            if (iIndexKey < 0)
                                this.Text = "";
                            else
                                this.Text = _mSelectedRow[_mDisplayColumns[iIndexKey].ColumnName].ToString();

                            return;
                        }
                    }

                    //if (_mDataTable != null)
                    //{
                    //    int iSearch = Search(_mobjSelectedValue.ToString());
                    //    if (iSearch >= 0)
                    //    {
                    //        selectedRow = dataTable.Rows[iSearch];
                    //        _miSelectedIndex = iSearch;
                    //        //this.SelectedText = selectedRow[_mstrDisplayValue].ToString();
                    //        this.Text = selectedRow[_mstrDisplayMember].ToString();
                    //    }
                    //    else
                    //        throw new ExecutionEngineException("Value was not in datasource");
                    //}
                    //else
                    //    selectedRow = dataTable.NewRow();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            get
            {
                return _mDataTable;
            }
            
        }
        public new int SelectedIndex
        {
            get
            {
                return _miSelectedIndex;
            }
            set
            {
                _miSelectedIndex = value;
            }
        }
        [Browsable(false)]
        public DataRow SelectedRow
        {
            get
            {
                return _mSelectedRow;
            }
        }
        public Boolean AllowLoadLanguage
        {
            get
            {
                return _mblnAllowLoadLanguage;
            }
            set
            {
                _mblnAllowLoadLanguage = value;
            }
        }
        public HVTTMultiComboBoxDisplayColumn[] DisplayColumns
        {
            get
            {
                return _mDisplayColumns;
            }
            set
            {
                _mDisplayColumns = value;
            }
        }
        public Boolean ShowColumnsHeader
        {
            get
            {
                return _mblnShowColumnHeader;
            }
            set
            {
                _mblnShowColumnHeader = value;
            }
        }
        public Boolean ShowRowsHeader
        {
            get
            {
                return _mblnShowRowHeader;
            }
            set
            {
                _mblnShowRowHeader = value;
            }
        }

        #endregion

        #region Private Method
        //private int Search(String s)
        //{
        //    for (int i = 0; i < _mDataTable.Rows.Count; i++)
        //        if (_mDataTable.Rows[i][ValueMember].ToString() == s)
        //            return i;
        //    return -1;
        //}
        private Point GetLocation(Form frm)
        {
            int iX = this.Location.X + 7;
            int iY = this.Location.Y + this.Size.Height;
            if (frm is HVTT.UI.Window.Forms.Office2007Form)
                iY = this.Location.Y + 2 * this.Size.Height + 7;

            Control ctrl = this.Parent;
            while (ctrl != null)
            {
                iX = iX + ctrl.Location.X;
                iY = iY + ctrl.Location.Y;
                ctrl = ctrl.Parent;
            }
            return new Point(iX, iY);
        }
        private Point InnitLocation(Point pLocation, Form frm)
        {
            int iX = pLocation.X;
            int iY = pLocation.Y;

            int iXScreen = 0;
            int iYScreen = 0;
            foreach (Screen Scr in Screen.AllScreens)
            {
                iXScreen = iXScreen + Scr.Bounds.Width;
                iYScreen = iYScreen + Scr.Bounds.Height;
            }
            if (frm.Height > (iYScreen - iY))
            {
                iY = iY - frm.Height - this.Height;
            }
            if (frm.Width > (iXScreen - iX))
            {
                iX = iXScreen - frm.Width;
            }
            return new Point(iX, iY);
        }


        private int FindKey()
        {
            if (_mDisplayColumns == null)
                return -1;
            for (int i = 0; i < _mDisplayColumns.Length; i++)
                if (_mDisplayColumns[i].IsKey)
                    return i;
            if (_mDisplayColumns.Length > 0)
                return 0;
            return -1;
        }   
        private Point GetParentLocation(Control c)
        {
            Point Rs = new Point();
            if (c != null)
            {
                Control c1 = c.Parent;
                if (c1 != null && !(c1 is Form))
                {
                    Rs.X += c1.Left;
                    Rs.Y += c1.Top;
                    Point p = GetParentLocation(c1);
                    Rs.X += p.X;
                    Rs.Y += p.Y;
                }
            }
            return Rs;
        }
        private Point DockBottom(Point p, Point pScreen, int iHeight)
        {
            Point Rs = new Point();
            if (p.Y + iHeight + 4 > pScreen.Y)
            {
                Rs.X = p.X;
                Rs.Y = pScreen.Y - 2 * iHeight - 6;
                return Rs;
            }
            return p;
        }
        private void MultiColumnComboBox_AfterSelectEvent(object sender, DataRow drow,int index)
        {
            try
            {
                if (drow != null)
                {
                    int iIndexKey = FindKey();
                    if (iIndexKey < 0)
                        this.Text = "";
                    else
                        this.Text = drow[_mDisplayColumns[iIndexKey].ColumnName].ToString();
                    this._mSelectedRow = drow;
                    this._miSelectedIndex = index;
                    if (SelectedIndexChanged != null)
                        SelectedIndexChanged(this, new EventArgs());
                    if (SelectedValueChanged != null)
                    {
                        SelectedValueChanged(this, new EventArgs());
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }



        #endregion

        #region Public Method
        #endregion


    }
}
