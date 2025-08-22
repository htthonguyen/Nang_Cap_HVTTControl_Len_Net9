using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using HVTT.UI.Window.Forms.HVTTAutoCompleteMenu;
using System.Linq;

namespace HVTT.UI.Window.Forms.Controls
{
    [Description("HVTTMaskTextBox Control")]
    [ToolboxBitmap(typeof(MaskedTextBox))]
    public partial class HVTTMaskTextBox : MaskedTextBox
    {

          #region Designer

        public HVTTMaskTextBox()
        {
            InitializeComponent();
          
            //SetStyle(
            //    ControlStyles.AllPaintingInWmPaint |
            //    ControlStyles.ResizeRedraw |
            //    ControlStyles.DoubleBuffer |
            //    ControlStyles.Selectable |
            //    ControlStyles.UserMouse,
            //    true
            //    );
            SetValueDefault();
        }

        #endregion


        #region Avalible

        HVTTStyle2008 _HVTTStyle2008 = new HVTTStyle2008();
        Color _RecentBackColor = Color.Empty;
        Color _RecentBorderColor = Color.Empty;

        #endregion


        #region Property



        private Color _mcrBorderColor;

        private Boolean _mbRequire = false;
        private Boolean _mbAllowEdit = true;
        private Object _mobjValue = null;
        private Boolean _mbIsChange = false;
        private String _sResentText = "";
        
        private int _miLivel = -1;

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

        
        [Description("The border color"), Category("Appearance")]
        public Color BorderColor
        {
            get
            {
                return _mcrBorderColor;
            }
            set
            {
                _mcrBorderColor = value;
                this.Invalidate();
            }

        }

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
     

        [Description("Get or set Text Of HVTTTextBox"), Category("HVTTTextBox")]
        public override String Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                _sResentText = base.Text;
                Invalidate();
            }
        }

        [Description("Get or set Value Of HVTTTextBox"), Category("HVTTTextBox")]
        [Browsable(false)]
        public Object Value
        {
            get
            {
                return _mobjValue;
            }
            set
            {
                _mobjValue = value;
                Invalidate();
            }
        }

       

        [Description("Get or set property allowedit"), Category("HVTTTextBox")]
        public Boolean AllowEdit
        {
            get
            {
                return _mbAllowEdit;
            }
            set
            {
                _mbAllowEdit = value;
                this.ReadOnly = !_mbAllowEdit;

            }
        }

        [Description("Get or set property Require"), Category("HVTTTextBox")]
        public Boolean Require
        {
            get
            {
                return _mbRequire;
            }
            set
            {
                _mbRequire = value;
            }
        }
     



        #endregion

        #region WndProc


        private static int WM_NCPAINT = 0x0085;
        private static int WM_ERASEBKGND = 0x0014;
        private static int WM_PAINT = 0x000F;

        [DllImport("user32.dll")]
        static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);

        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);




        protected override void WndProc(ref Message m)
        {
            SetControlStyle();
            base.WndProc(ref m);



            //Rectangle rect = this.ClientRectangle;


            if (m.Msg == WM_NCPAINT || m.Msg == WM_ERASEBKGND || m.Msg == WM_PAINT)
            {
                IntPtr hdc = GetDCEx(m.HWnd, (IntPtr)1, 1 | 0x0020);

                if (hdc != IntPtr.Zero)
                {
                    Graphics g = Graphics.FromHdc(hdc);
                    Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                    ControlPaint.DrawBorder(g, rect, _mcrBorderColor, ButtonBorderStyle.Solid);

                    // SizeF textSize = g.MeasureString(base.Text, base.Font);

                    // int iTextX = (int)(base.Size.Width) - (int)(textSize.Width);
                    // int iTextY = (int)(base.Size.Height)- (int)(textSize.Height);

                    // rect = new Rectangle(1, 1, this.Width - 2, this.Height - 2);
                    // FillSmoothingQuality(ref g);
                    // mode = GetGradientStyle();
                    // if (_GradientStyle == GradientStyles.Default)
                    // {
                    //     brush = new SolidBrush(_mcrBackColor1);
                    //     BackColor = _mcrBackColor1;
                    //     g.FillRectangle(brush, rect);
                    // }
                    // else
                    // {
                    //     brush = new LinearGradientBrush(rect, _mcrBackColor1, _mcrBackColor2, mode);

                    //     g.FillRectangle(brush, rect);
                    // }
                    //// g.DrawString(base.Text, base.Font, new SolidBrush(base.ForeColor), new Point(iTextX, iTextY));
                    // if (brush != null)
                    //     brush.Dispose();
                    //ControlPaint.DrawButton(graphics, this.Width - 20, 0, 20, this.Height, ButtonState.Flat);
                    m.Result = (IntPtr)1;
                    ReleaseDC(m.HWnd, hdc);
                }
            }
        }

        #endregion


        #region Private Method

        private void SetValueDefault()
        {
          
            //_GradientStyle = GradientStyles.Default;
            //_SmoothingQuality = SmoothingQualities.None;

            //_mcrBackColor1 = SystemColors.Window;
            //_mcrBackColor2 = SystemColors.Window;
            _mcrBorderColor = Color.Black;

            //_mcrHoverBorder = SystemColors.Window;
            //_mcrHoverColor1 = SystemColors.Window;
            //_mcrHoverColor2 = SystemColors.Window;

            //this.Text = "HVTTTextBox";

            // _mAppearance = new HVTTAppearance(new String[]{"HoverColor1","HoverColor2","HoverBorderColor"});
            //this.BackColor = _mcrBackColor1;
        }
        private void SetControlStyle()
        {
            if (!_mbAllowEdit && !_mbRequire)
            {
                base.BackColor = _HVTTStyle2008.AllowEditBackColor;
                _mcrBorderColor = _HVTTStyle2008.AllowEditBorderColor;
            }
            else if (!_mbAllowEdit && _mbRequire)
            {
                base.BackColor = _HVTTStyle2008.AllowEditBackColor;
                _mcrBorderColor = _HVTTStyle2008.AllowEditBorderColor;
                //SetValueRequire();
            }
            else if (_mbAllowEdit && _mbRequire)
            {
                base.BackColor = _HVTTStyle2008.RequireBackColor;
                _mcrBorderColor = _HVTTStyle2008.RequireBorderColor;
            }
            else if (_mbAllowEdit && !_mbRequire)
            {
                base.BackColor = SystemColors.Window;
                _mcrBorderColor = Color.Black;
            }



        }

        private void SetValueAllowEdit()
        {

            this.BackColor = _HVTTStyle2008.AllowEditBackColor;
            _mcrBorderColor = _HVTTStyle2008.AllowEditBorderColor;
            // this.BackColor = _mcrBackColor1;
        }

        private void SetValueRequire()
        {

            this.BackColor = _HVTTStyle2008.RequireBackColor;
            _mcrBorderColor = _HVTTStyle2008.RequireBorderColor;
            //this.BackColor = _mcrBackColor1;
        }

        private void SetValueRecent()
        {

            this.BackColor = _RecentBackColor;
            _mcrBorderColor = _RecentBorderColor;
            //this.BackColor = _mcrBackColor1;
        }

     
       
        private Boolean Search(String s, Char x)
        {
            Char[] cArray = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                if (cArray[i].ToString().ToUpper() == x.ToString().ToUpper())
                    return true;
            }
            return false;
        }
        private int CountChar(String s, Char x)
        {
            int iCount = 0;
            for (int i = 0; i < s.Length; i++)
                if (s[i].ToString().ToUpper() == x.ToString().ToUpper())
                    iCount++;
            return iCount;
        }
    


        #endregion

        #region Public Method

        [Description("Return a Int16 all NumberTypes.If Value biger than Int16 value,it will choose a value smaller or same MaxValue.If Value smaller than Int16 value,it will choose a value bigger or same MinValue")]
        public Int16 GetInt16()
        {
            try
            {
                if (this.Text.Trim() == "")
                    return 0;

                return Convert.ToInt16(this.Text.Trim());

                //if (_mobjValue != null)
                //{
                //    if (_mobjValue.ToString().Length > 5 && _mobjValue.ToString()[0] != '-')
                //        return Convert.ToInt16(_mobjValue.ToString().Substring(0, 4));
                //    if (_mobjValue.ToString().Length > 5 && _mobjValue.ToString()[0] == '-')
                //        return Convert.ToInt16(_mobjValue.ToString().Substring(0, 5));
                //    int i = Convert.ToInt32(_mobjValue);
                //    if (i >= Int16.MaxValue)
                //        return Convert.ToInt16(_mobjValue.ToString().Substring(0, _mobjValue.ToString().Length - 1));
                //    return Convert.ToInt16(i);
                //}
            }
            catch
            {
                return 0;
            }
            //return Int16.MinValue;
        }

        [Description("Return a Int32 all NumberTypes.If Value biger than Int32 value,it will choose a value smaller or same MaxValue.If Value smaller than Int32 value,it will choose a value bigger or same MinValue")]
        public Int32 GetInt32()
        {
            try
            {
                if (this.Text.Trim() == "")
                    return 0;
                return Convert.ToInt32(this.Text.Trim());
                //if (_mobjValue != null)
                //{
                //    if (_mobjValue.ToString().Length > 10 && _mobjValue.ToString()[0] != '-')
                //        return Convert.ToInt32(_mobjValue.ToString().Substring(0, 9));
                //    if (_mobjValue.ToString().Length > 10 && _mobjValue.ToString()[0] == '-')
                //        return Convert.ToInt16(_mobjValue.ToString().Substring(0, 9));
                //    Int64 i = Convert.ToInt64(_mobjValue);
                //    if (i >= Int32.MaxValue)
                //        return Convert.ToInt32(_mobjValue.ToString().Substring(0, _mobjValue.ToString().Length - 1));
                //    return Convert.ToInt32(i);
            
            }
            catch
            {
                return 0;
            }
            //return Int32.MinValue;
        }

        [Description("Return a Int64 all NumberTypes.If Value biger than Int64 value,it will choose a value smaller or same MaxValue.If Value smaller than Int64 value,it will choose a value bigger or same MinValue")]
        public Int64 GetInt64()
        {
            try
            {
                if (this.Text.Trim() == "")
                    return 0;
                return Convert.ToInt64(this.Text.Trim());
                //if (_mobjValue != null)
                //{
                //    if (_mobjValue.ToString().Length > 20 && _mobjValue.ToString()[0] != '-')
                //        return Convert.ToInt32(_mobjValue.ToString().Substring(0, 19));
                //    if (_mobjValue.ToString().Length > 20 && _mobjValue.ToString()[0] == '-')
                //        return Convert.ToInt16(_mobjValue.ToString().Substring(0, 19));
                //    Int64 i = 0;
                //    try
                //    {
                //        i = Convert.ToInt64(_mobjValue);
                //    }
                //    catch (Exception ex)
                //    {
                //        throw ex;
                //    }

                //    return i;
                //}
            }
            catch
            {
                return 0;
            }
            //return Int64.MinValue;
        }

        [Description("Return a Double all NumberTypes.If Value biger than Double value,it will choose a value smaller or same Double.If Value smaller than Double value,it will choose a value bigger or same MinValue")]
        public Double GetDouble()
        {
            try
            {
                if (this.Text.Trim() == "")
                    return 0;
                return Convert.ToDouble(this.Text.Trim());
            }
            catch
            {
                return 0;
            }
            //return Double.MinValue;
        }
        [Description("Return a Decimal all NumberTypes.If Value biger than Decimal value,it will choose a value smaller or same Double.If Value smaller than Double value,it will choose a value bigger or same MinValue")]
        public Double GetDecimal()
        {
            try
            {
                if (this.Text.Trim() == "")
                    return 0;
                return Convert.ToDouble(this.Text.Trim());
            }
            catch
            {
                return 0;
            }
            //return Double.MinValue;
        }






        #endregion


        #region Auto menu
        List<MenuColumn> _mSelectedItems = new List<MenuColumn>();
        public List<MenuColumn> SelectedItems
        {
            get
            {


                if ((_mSelectedItems == null || _mSelectedItems.Count <= 0 || _mSelectedItems[0].ColumnValue.Trim() == "") && this.Text.Trim() != "" && _mAutoMenu != null
                    && _mAutoMenu.AutocompleteItems != null && _mAutoMenu.AutocompleteItems.Count > 0)
                {
                    _mSelectedItems = new List<MenuColumn>();
                    var lst = (from x in _mAutoMenu.AutocompleteItems
                               where x.MenuColumns[1].ColumnValue.Trim().ToLower().Contains(this.Text.Trim().ToLower())
                               select x).ToList();
                    if (lst == null || lst.Count <= 0)
                    {
                        _mSelectedItems = _mAutoMenu.AutocompleteItems[0].MenuColumns;
                        _mSelectedItems[0].ColumnValue = "";
                        _mSelectedItems[1].ColumnValue = this.Text.Trim();
                    }
                    else
                    {
                        _mSelectedItems = lst[0].MenuColumns;
                    }
                }

                return _mSelectedItems;
            }
            set
            {
                _mSelectedItems = value;
            }
        }

        AutocompleteMenu _mAutoMenu = null;

        public event EventHandler<SelectedEventArgs> AutoMenuSelected;
        public event EventHandler<SelectingEventArgs> AutoMenuSelecting;

        public Boolean AutoMenuOpened
        {
            get
            {
                if (_mAutoMenu == null || !_mAutoMenu.Opened)
                    return false;
                return _mAutoMenu.Opened;
            }
        }

        public void SetAutoMenu(DataTable dt,
          List<HVTT.UI.Window.Forms.HVTTAutoCompleteMenu.MenuColumn> Columns, String FilterColumnName,
          Boolean ShowPopupOnClick = false,
          Boolean SearchAllText = true,
          int MinFragmentLength = 0,
          int Height = 200
          )
        {
            if (_mAutoMenu != null)
            {
                _mAutoMenu.Dispose();
                _mAutoMenu = null;
            }

            _mAutoMenu = new AutocompleteMenu();
            _mAutoMenu.Colors = new Colors();
            _mAutoMenu.Font = this.Font;
            _mAutoMenu.ImageList = null;
            _mAutoMenu.Items = new string[0];
            _mAutoMenu.TargetControlWrapper = null;

            _mAutoMenu.ShowPopupOnClick = ShowPopupOnClick;
            _mAutoMenu.AutocompleteItems.Clear();
            _mAutoMenu.Update();
            _mAutoMenu.MaximumSize = new Size(Columns.Sum(c => c.Width), Height);
            _mAutoMenu.SearchAllText = SearchAllText;
            _mAutoMenu.MinFragmentLength = MinFragmentLength;
            _mAutoMenu.Selected += _mAutoMenu_Selected;
            _mAutoMenu.Selecting += _mAutoMenu_Selecting;
            _mAutoMenu.AllowsTabKey = true;

            foreach (DataRow R in dt.Rows)
            {
                var lst = new List<HVTT.UI.Window.Forms.HVTTAutoCompleteMenu.MenuColumn>();
                Columns.ForEach(item =>
                {
                    lst.Add(new MenuColumn()
                    {
                        ColumnName = item.ColumnName,
                        ColumnValue = "",
                        IsVisible = item.IsVisible,
                        Width = item.Width
                    });
                });

                for (int i = 0; i < lst.Count; i++)
                {
                    lst[i].ColumnValue = R[lst[i].ColumnName].ToString();
                }
                    

                _mAutoMenu.AddItem(new HVTT.UI.Window.Forms.HVTTAutoCompleteMenu.MulticolumnAutocompleteItem(lst, R[FilterColumnName].ToString(), false));
            }
            _mAutoMenu.SetAutocompleteMenu(this, _mAutoMenu);
        }

        private void _mAutoMenu_Selecting(object sender, SelectingEventArgs e)
        {
            SelectedItems = e.Item.MenuColumns;
            if (AutoMenuSelecting != null)
                AutoMenuSelecting(this, e);
        }

        private void _mAutoMenu_Selected(object sender, SelectedEventArgs e)
        {
            if (AutoMenuSelected != null)
                AutoMenuSelected(this, e);
        }

        public void AutoMenuOnSelecting()
        {
            if (_mAutoMenu == null)
                return;

            _mAutoMenu.OnSelecting();
        }
        public void AutoMenuSelectNext(int Shift)
        {
            if (_mAutoMenu == null)
                return;
            _mAutoMenu.SelectNext(Shift);
        }
        public void AutoMenuOnClose()
        {
            if (_mAutoMenu == null)
                return;
            _mAutoMenu.Close();
        }

        public List<List<MenuColumn>> GetAutoMenuItemByFilterData(String FilterData)
        {
            List<List<MenuColumn>> RS = new List<List<MenuColumn>>();
            if (_mAutoMenu.AutocompleteItems == null || _mAutoMenu.AutocompleteItems.Count < 0)
                return RS;
            try
            {
                var lst = (from x in _mAutoMenu.AutocompleteItems
                           where x.MenuColumns[0].ColumnValue.ToLower().Trim() == FilterData.ToLower().Trim()
                           select new { x.MenuColumns }).ToList();
                if (lst != null && lst.Count > 0)
                {
                    foreach (var x in lst)
                        RS.Add(x.MenuColumns);
                }
            }
            catch { }
            return RS;
        }
        public List<List<MenuColumn>> GetAutoMenuItemByFilterData(String FilterData, String ColumnName)
        {
            List<List<MenuColumn>> RS = new List<List<MenuColumn>>();
            if (_mAutoMenu.AutocompleteItems == null || _mAutoMenu.AutocompleteItems.Count < 0)
                return RS;
            try
            {
                var lst = (from x in _mAutoMenu.AutocompleteItems
                           where
                           (
                               (
                                from y in x.MenuColumns
                                where y.ColumnName.Trim().ToLower() == ColumnName.Trim().ToLower()
                                    && y.ColumnValue.Trim().ToLower() == FilterData.Trim().ToLower()
                                select y
                               ).ToList()
                           ).Count > 0
                           select new { x.MenuColumns }).ToList();
                if (lst != null && lst.Count > 0)
                {
                    foreach (var x in lst)
                        RS.Add(x.MenuColumns);
                }
            }
            catch { }
            return RS;
        }

        public List<List<MenuColumn>> GetAutoMenuItemByFilterData()
        {
            List<List<MenuColumn>> RS = new List<List<MenuColumn>>();
            if (_mAutoMenu.AutocompleteItems == null || _mAutoMenu.AutocompleteItems.Count < 0)
                return RS;
            try
            {
                var lst = (from x in _mAutoMenu.AutocompleteItems
                           where x.MenuColumns[0].ColumnValue.ToLower().Trim() == this.Text.ToLower().Trim()
                           select new { x.MenuColumns }).ToList();
                if (lst != null && lst.Count > 0)
                {
                    foreach (var x in lst)
                        RS.Add(x.MenuColumns);
                }
            }
            catch { }
            return RS;
        }
        #endregion


        protected override void OnGotFocus(EventArgs e)
        {
            this.SelectAll();
            base.OnGotFocus(e);
        }

        #region Event

        public event EventHandler ValueChanged;




        protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
        {
            base.OnGiveFeedback(gfbevent);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            //this.Select();
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            //this.SelectAll();
            base.OnMouseMove(e);
        }
       
        protected override void OnTextChanged(EventArgs e)
        {
            _mobjValue = this.Text;
            if (_sResentText != this.Text)
                _mbIsChange = true;

            if (ValueChanged != null)
                ValueChanged(this, e);

            base.OnTextChanged(e);
        }

        #endregion

    }
}
