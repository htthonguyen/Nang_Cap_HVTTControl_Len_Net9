using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using HVTT.UI.Window.Forms.Design;
using HVTT.UI.Window.Forms.TextMarkup;
using System.Reflection;
using HVTT.UI.Window.Forms.Rendering;
using System.Linq;

using HVTT.UI.Window.Forms.HVTTAutoCompleteMenu;

namespace HVTT.UI.Window.Forms.Controls
{

    [Description("HVTTTextBox Control")]
    [ToolboxBitmap(typeof(TextBox))]
    [Designer(typeof(HVTTTextBoxDesigner))]
    public partial class HVTTTextBox : TextBox
    {

        #region Designer

        public HVTTTextBox()
        {
           
            //base.Size = new Size(100, 20);
            //base.Font = new Font("Microsoft Sans Serif", 9);
            //SetStyle(
            //    ControlStyles.AllPaintingInWmPaint |
            //    ControlStyles.ResizeRedraw |
            //    //ControlStyles.DoubleBuffer |
            //    //ControlStyles.Selectable |
            //    ControlStyles.UserMouse,
            //    true
            //    );
            SetValueDefault();
            Initialize();
            //base.BorderStyle = BorderStyle.Fixed3D;
            //PlaceHolder = "";
        }

        protected override void Dispose(bool disposing)
        {
        
            base.Dispose(disposing);
        }

        #endregion


        #region Avalible

        HVTTStyle2008 _HVTTStyle2008 = new HVTTStyle2008();
        Color _RecentBackColor = Color.Empty;
        Color _RecentBorderColor = Color.Empty;
        String _sResentText = "";


        
        #endregion


        #region Property

        //private GradientStyles _GradientStyle;
        //private SmoothingQualities _SmoothingQuality;
        private TypeStyles _TypeStyle;
        private String _mstrFormatNumber = "N0";

        private Color _mcrBorderColor;
        //private Color _mcrBackColor1;
        //private Color _mcrBackColor2;

        private Boolean _mbRequire = false;
        private Boolean _mbAllowEdit = true;
        private Object _mobjValue = null;
        private Boolean _mbIsChange = false;
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
       


        //private Color _mcrHoverBorder;
        //private Color _mcrHoverColor1;
        //private Color _mcrHoverColor2;

        //private String _msText = "";
        //private HVTTAppearance _mAppearance;


        //[Description("Smoothing Quality"), Category("Appearance")]
        //public SmoothingQualities SmoothingQuality
        //{
        //    get
        //    {
        //        return _SmoothingQuality;
        //    }
        //    set
        //    {
        //        _SmoothingQuality = value;
        //        this.Invalidate();
        //    }
        //}

        //[Description("Gradient Style"), Category("Appearance")]
        //public GradientStyles GradientStyle
        //{
        //    get
        //    {
        //        return _GradientStyle;
        //    }
        //    set
        //    {
        //        _GradientStyle = value;
        //        this.Invalidate();
        //    }

        //}

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

        //[Description("The hover border color"), Category("Appearance")]
        //public Color HoverBorderColor
        //{
        //    get
        //    {
        //        return _mcrHoverBorder;
        //    }
        //    set
        //    {
        //        _mcrHoverBorder = value;
        //        this.Invalidate();
        //    }

        //}

        //[Description("Back color 1"), Category("Appearance")]
        //public Color BackColor1
        //{
        //    get
        //    {
        //        return _mcrBackColor1;
        //    }
        //    set
        //    {
        //        _mcrBackColor1 = value;
        //        this.Invalidate();
        //    }
        //}

        //[Description("Back color 2"), Category("Appearance")]
        //public Color BackColor2
        //{
        //    get
        //    {
        //        return _mcrBackColor2;
        //    }
        //    set
        //    {
        //        _mcrBackColor2 = value;
        //        this.Invalidate();
        //    }
        //}


        //[Description("Hover color 1"), Category("Appearance")]
        //public Color HoverColor1
        //{
        //    get
        //    {
        //        return _mcrHoverColor1;
        //    }
        //    set
        //    {
        //        _mcrHoverColor1 = value;
        //        this.Invalidate();
        //    }
        //}

        //[Description("Hover color 2"), Category("Appearance")]
        //public Color HoverColor2
        //{
        //    get
        //    {
        //        return _mcrHoverColor2;
        //    }
        //    set
        //    {
        //        _mcrHoverColor2 = value;
        //        this.Invalidate();
        //    }
        //}

        //[Description("Appearance Of HVTTControl"), Category("Appearance")]
        //[Browsable(true)]
        //public HVTTAppearance Appearance
        //{
        //    get
        //    {
        //        return _mAppearance;
        //    }
        //    set
        //    {
        //        _mAppearance = value;
        //        this.Invalidate();
        //    }
        //}

     

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
                //Invalidate();
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
                if (value == null)
                    this.Text = "";
                else
                    this.Text = value.ToString();
                //Invalidate();
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

        [Description("Get or set TypeStyle"), Category("HVTTTextBox")]
        public TypeStyles TypeStyle
        {
            get
            {
                return _TypeStyle;
            }
            set
            {
                _TypeStyle = value;
            }
        }
        [Description("Get or set fortmat number of TextBox. It's avalible when TypeStyle = Number"), Category("HVTTTextBox")]
        public String FormatNumber
        {
            get
            {
                return _mstrFormatNumber;
            }
            set
            {
                _mstrFormatNumber = value;
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

       

        List<MenuColumn> _mSelectedItems = new List<MenuColumn>();
        public List<MenuColumn> SelectedItems
        {
            get
            {
                if(this.Text.Trim()=="")
                {
                    _mSelectedItems = new List<MenuColumn>();
                    _mSelectedItems.Add(new MenuColumn());
                    _mSelectedItems.Add(new MenuColumn());
                    return _mSelectedItems;
                }

                if ((_mSelectedItems == null||_mSelectedItems.Count<=0||_mSelectedItems[0].ColumnValue.Trim()=="") && this.Text.Trim() != "" && _mAutoMenu != null
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
                else if(_mSelectedItems==null||_mSelectedItems.Count<=0)
                {
                    _mSelectedItems = new List<MenuColumn>();
                    _mSelectedItems.Add(new MenuColumn());
                    _mSelectedItems.Add(new MenuColumn());
                }

                return _mSelectedItems;
            }
            set
            {
                _mSelectedItems = value;
            }
        }

        public void SetValue(String Value)
        {
            if(Value==null)
            {
                this.Text = "";
                _mSelectedItems = new List<MenuColumn>();
                _mSelectedItems.Add(new MenuColumn());
                _mSelectedItems.Add(new MenuColumn());

                return;
            }
            if (_mSelectedItems == null||_mSelectedItems.Count<=0)
            {
                _mSelectedItems = new List<MenuColumn>();
                _mSelectedItems.Add(new MenuColumn());
                _mSelectedItems.Add(new MenuColumn());
            }
            if ( _mAutoMenu != null
                    && _mAutoMenu.AutocompleteItems != null && _mAutoMenu.AutocompleteItems.Count > 0)
            {
              
                var lst = (from x in _mAutoMenu.AutocompleteItems
                           where x.MenuColumns[0].ColumnValue.Trim().ToLower().Contains(Value.Trim().ToLower())
                           select x).ToList();

                if (lst == null || lst.Count <= 0)
                {
                    _mSelectedItems = _mAutoMenu.AutocompleteItems[0].MenuColumns;
                    _mSelectedItems[1].ColumnValue = "";
                    _mSelectedItems[0].ColumnValue = Value;
                }
                else
                {
                    _mSelectedItems = lst[0].MenuColumns;
                    this.Text = lst[0].MenuColumns[1].ColumnValue;
                }
            }
        }
        public void SetValue(String Value,String Text)
        {

            SetValue(Value);
            if (this.Text.Trim() == "")
                this.Text = Text;
        }
        public void SetText(String text)
        {

            if (_mSelectedItems == null || _mSelectedItems.Count <= 0)
            {
                _mSelectedItems = new List<MenuColumn>();
                _mSelectedItems.Add(new MenuColumn());
                _mSelectedItems.Add(new MenuColumn());
            }
            if (_mAutoMenu != null
                    && _mAutoMenu.AutocompleteItems != null && _mAutoMenu.AutocompleteItems.Count > 0)
            {

                var lst = (from x in _mAutoMenu.AutocompleteItems
                           where x.MenuColumns[1].ColumnValue.Trim().ToLower().Contains(text.Trim().ToLower())
                           select x).ToList();

                if (lst == null || lst.Count <= 0)
                {
                    _mSelectedItems = _mAutoMenu.AutocompleteItems[0].MenuColumns;
                    _mSelectedItems[0].ColumnValue = "";
                    _mSelectedItems[1].ColumnValue = text;
                }
                else
                {
                    _mSelectedItems = lst[0].MenuColumns;
                    this.Text = text;
                }
            }
        }
        public void Empty()
        {
            this.Text = "";
            if (_mAutoMenu != null
                    && _mAutoMenu.AutocompleteItems != null)
            {
                _mSelectedItems = new List<MenuColumn>();
                _mSelectedItems.Add(new MenuColumn());
                _mSelectedItems.Add(new MenuColumn());
            }
            else
                _mSelectedItems = null;
           
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
            //if (m_NCPainter != null)
            //{
            //    bool callBase = m_NCPainter.WndProc(ref m);

            //    if (callBase)
            //        base.WndProc(ref m);
            //}
            //else
            //{
            //    base.WndProc(ref m);
            //}

            if (m.Msg == WM_NCPAINT || m.Msg == WM_ERASEBKGND || m.Msg == WM_PAINT)
            {
                IntPtr hdc = GetDCEx(m.HWnd, (IntPtr)1, 1 | 0x0020);

                if (hdc != IntPtr.Zero)
                {
                    Graphics g = Graphics.FromHdc(hdc);
                    Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                    ControlPaint.DrawBorder(g, rect, _mcrBorderColor, ButtonBorderStyle.Solid);
                    m.Result = (IntPtr)1;
                    ReleaseDC(m.HWnd, hdc);
                }
            }
            base.WndProc(ref m);
        }

        #endregion

        #region Private Method

        private void SetValueDefault()
        {
          
            //_GradientStyle = GradientStyles.Default;
            //_SmoothingQuality = SmoothingQualities.None;
            _TypeStyle = TypeStyles.Normal;

            //_mcrBackColor1 = SystemColors.Window;
            //_mcrBackColor2 = SystemColors.Window;
            _mcrBorderColor = Color.Black;
            //m_BorderStyle.BackColor = _mcrBorderColor;
            //m_BorderStyle.BorderLeftWidth = 1;
            //m_BorderStyle.BorderRightWidth = 1;
            //m_BorderStyle.BorderBottomWidth = 1;
            //m_BorderStyle.BorderTopWidth = 1;
            //m_BorderStyle.BorderWidth = 0;
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
            //else if (_RecentBackColor == SystemColors.Window)
            //{
            //    base.BackColor = SystemColors.Window;
            //    _mcrBorderColor = Color.Black;
            //}
            
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
            var lst = s.Where(y => y.ToString().ToLower() == x.ToString().ToLower());
            if (lst != null && lst.Count() > 0)
                return true;
            return false;
            //Char[] cArray = s.ToCharArray();
            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (cArray[i].ToString().ToUpper() == x.ToString().ToUpper())
            //        return true;
            //}
            //return false;
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
            if (this.Text.Trim() == "")
                return 0;

            if (this.Text.Trim() == "")
                return 0;
            try
            {
                return Convert.ToInt16(this.Text.Trim());
            }
            catch { }
            return 0;
        }

        [Description("Return a Int32 all NumberTypes.If Value biger than Int32 value,it will choose a value smaller or same MaxValue.If Value smaller than Int32 value,it will choose a value bigger or same MinValue")]
        public Int32 GetInt32()
        {
            if (this.Text.Trim() == "")
                return 0;

            if (this.Text.Trim() == "")
                return 0;
            try
            {
                return Convert.ToInt32(this.Text.Trim());
            }
            catch { }
            return 0;
        }

        [Description("Return a Int64 all NumberTypes.If Value biger than Int64 value,it will choose a value smaller or same MaxValue.If Value smaller than Int64 value,it will choose a value bigger or same MinValue")]
        public Int64 GetInt64()
        {

            if (this.Text.Trim() == "")
                return 0;
            if (this.Text.Trim() == "")
                return 0;
            try
            {
                return Convert.ToInt64(this.Text.Trim());
            }
            catch { }
            return 0;
        }

        [Description("Return a Double all NumberTypes.If Value biger than Double value,it will choose a value smaller or same Double.If Value smaller than Double value,it will choose a value bigger or same MinValue")]
        public Double GetDouble()
        {
            if (this.Text.Trim() == "")
                return 0;
            try
            {
                return Convert.ToDouble(this.Text.Trim());
            }
            catch { }
            return 0;
        }

        public Decimal GetDecimal()
        {
            if (this.Text.Trim() == "")
                return 0;
            try
            {
                return Convert.ToDecimal(this.Text.Trim());
            }
            catch { }
            return 0;
        }


      

        #endregion

        #region Event
      
        public event EventHandler ValueChanged;
        public event EventHandler HasFocus;
       

        protected override void OnGotFocus(EventArgs e)
        {
            //if (this.Text.Trim()==PlaceHolder)
            //{
            //    this.Text = "";
            //}

            if (HasFocus != null)
                HasFocus(this, e);
            this.SelectAll();
            
            base.OnGotFocus(e);
        }

        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    //this.Select();
        //    base.OnMouseDown(e);
        //}
        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    //this.SelectAll();
        //    base.OnMouseMove(e);
        //}
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (_TypeStyle == TypeStyles.None)
            {
                e.Handled = true;
                return;
            }
            if (Char.IsControl(e.KeyChar))
                return;
            String s = "";
            if (_TypeStyle == TypeStyles.OnlyNumber)
                s = "1234567890";
            else if (_TypeStyle == TypeStyles.OnlyWords)
                s = "qwertyuiopasdfghjklzxcvbnm ";
            else if (_TypeStyle == TypeStyles.WordAndNumber)
                s = "1234567890qwertyuiopasdfghjklzxcvbnm ";
            else if (_TypeStyle == TypeStyles.Number)
                s = "1234567890.-,";

            if (s.Trim() == "")
                return;
            if (!Search(s, e.KeyChar))
                e.Handled = true;
            
        }
        protected override void OnTextChanged(EventArgs e)
        {
            _mobjValue = this.Text;
            if (_sResentText != this.Text)
                _mbIsChange = true;

            
             _sResentText = this.Text;

            if (ValueChanged != null)
                ValueChanged(this, e);

           
            base.OnTextChanged(e);
        }
        
        private void HVTTTextBox_BackColorChanged(object sender, EventArgs e)
        {
            _RecentBackColor = base.BackColor;
            _RecentBorderColor = _mcrBorderColor;
        }
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            this.SelectAll();
            base.OnMouseDoubleClick(e);
        }
        #endregion

        #region Enum

        public enum TypeStyles
        {
            Normal,
            Anny,
            OnlyNumber,
            OnlyWords,
            WordAndNumber,
            Number,
            None
        }

        #endregion

        #region Auto menu
        AutocompleteMenu _mAutoMenu = null;

        public event EventHandler<SelectedEventArgs> AutoMenuSelected;
        public event EventHandler<SelectingEventArgs> AutoMenuSelecting;
        public event EventHandler<CancelEventArgs> AutoMenuOpening;

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
                _mAutoMenu.AutocompleteItems.Clear();
                _mAutoMenu.Update();
            }
            else
            {
                _mAutoMenu = new AutocompleteMenu();
                _mAutoMenu.Colors = new Colors();
                _mAutoMenu.Font = this.Font;
                _mAutoMenu.ImageList = null;
                _mAutoMenu.Items = new string[0];
                _mAutoMenu.TargetControlWrapper = null;
                _mAutoMenu.Selected += _mAutoMenu_Selected;
                _mAutoMenu.Selecting += _mAutoMenu_Selecting;
                _mAutoMenu.Opening += _mAutoMenu_Opening;
                _mAutoMenu.AllowsTabKey = true;
            }

          

            _mAutoMenu.ShowPopupOnClick = ShowPopupOnClick;
           
            _mAutoMenu.MaximumSize = new Size(Columns.Sum(c => c.Width), Height);
            _mAutoMenu.SearchAllText = SearchAllText;
            _mAutoMenu.MinFragmentLength = MinFragmentLength;


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
                    lst[i].ColumnValue = R[lst[i].ColumnName].ToString();

                _mAutoMenu.AddItem(new HVTT.UI.Window.Forms.HVTTAutoCompleteMenu.MulticolumnAutocompleteItem(lst, R[FilterColumnName].ToString(), false));
            }
            _mAutoMenu.SetAutocompleteMenu(this, _mAutoMenu);
        }

        

        public void SetAutoMenu(List<DataRow> Rows,
          List<HVTT.UI.Window.Forms.HVTTAutoCompleteMenu.MenuColumn> Columns, String FilterColumnName,
          Boolean ShowPopupOnClick = false,
          Boolean SearchAllText = true,
          int MinFragmentLength = 0,
          int Height = 200
          )
        {
            if (_mAutoMenu != null)
            {
                _mAutoMenu.AutocompleteItems.Clear();
                _mAutoMenu.Update();
            }
            else
            {
                _mAutoMenu = new AutocompleteMenu();
                _mAutoMenu.Colors = new Colors();
                _mAutoMenu.Font = this.Font;
                _mAutoMenu.ImageList = null;
                _mAutoMenu.Items = new string[0];
                _mAutoMenu.TargetControlWrapper = null;
                _mAutoMenu.Selected += _mAutoMenu_Selected;
                _mAutoMenu.Selecting += _mAutoMenu_Selecting;
                _mAutoMenu.AllowsTabKey = true;
            }



            _mAutoMenu.ShowPopupOnClick = ShowPopupOnClick;

            _mAutoMenu.MaximumSize = new Size(Columns.Sum(c => c.Width), Height);
            _mAutoMenu.SearchAllText = SearchAllText;
            _mAutoMenu.MinFragmentLength = MinFragmentLength;


            foreach (DataRow R in Rows)
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
                    lst[i].ColumnValue = R[lst[i].ColumnName].ToString();

                _mAutoMenu.AddItem(new HVTT.UI.Window.Forms.HVTTAutoCompleteMenu.MulticolumnAutocompleteItem(lst, R[FilterColumnName].ToString(), false));
            }
            _mAutoMenu.SetAutocompleteMenu(this, _mAutoMenu);
        }

        public void SetAutoMenu(List<DataRow> Rows,
         List<HVTT.UI.Window.Forms.HVTTAutoCompleteMenu.MenuColumn> Columns, String FilterColumnName,
         Boolean ShowPopupOnClick = false,
         Boolean SearchAllText = true,
         int MinFragmentLength = 0,
         int Height = 200,
         Boolean CompareBySubString=false
         )
        {
            if (_mAutoMenu != null)
            {
                _mAutoMenu.AutocompleteItems.Clear();
                _mAutoMenu.Update();
            }
            else
            {
                _mAutoMenu = new AutocompleteMenu();
                _mAutoMenu.Colors = new Colors();
                _mAutoMenu.Font = this.Font;
                _mAutoMenu.ImageList = null;
                _mAutoMenu.Items = new string[0];
                _mAutoMenu.TargetControlWrapper = null;
                _mAutoMenu.Selected += _mAutoMenu_Selected;
                _mAutoMenu.Selecting += _mAutoMenu_Selecting;
                _mAutoMenu.AllowsTabKey = true;
            }



            _mAutoMenu.ShowPopupOnClick = ShowPopupOnClick;

            _mAutoMenu.MaximumSize = new Size(Columns.Sum(c => c.Width), Height);
            _mAutoMenu.SearchAllText = SearchAllText;
            _mAutoMenu.MinFragmentLength = MinFragmentLength;


            if (CompareBySubString)
            {
                foreach (DataRow R in Rows)
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
                        lst[i].ColumnValue = R[lst[i].ColumnName].ToString();

                    _mAutoMenu.AddItem(new HVTT.UI.Window.Forms.HVTTAutoCompleteMenu.MulticolumnAutocompleteItem(lst, R[FilterColumnName].ToString()));
                }
            }
            else
            {
                foreach (DataRow R in Rows)
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
                        lst[i].ColumnValue = R[lst[i].ColumnName].ToString();

                    _mAutoMenu.AddItem(new HVTT.UI.Window.Forms.HVTTAutoCompleteMenu.MulticolumnAutocompleteItem(lst, R[FilterColumnName].ToString(), false));
                }
            }
            _mAutoMenu.SetAutocompleteMenu(this, _mAutoMenu);
        }

        public void SetAutoMenu(DataTable dt,
          List<HVTT.UI.Window.Forms.HVTTAutoCompleteMenu.MenuColumn> Columns, String FilterColumnName,
          Boolean ShowPopupOnClick,
          Boolean SearchAllText,
          int MinFragmentLength,
          int Height,
          Boolean CompareBySubString
          )
        {
            if (_mAutoMenu != null)
            {
                _mAutoMenu.AutocompleteItems.Clear();
                _mAutoMenu.Update();
            }
            else
            {
                _mAutoMenu = new AutocompleteMenu();
                _mAutoMenu.Colors = new Colors();
                _mAutoMenu.Font = this.Font;
                _mAutoMenu.ImageList = null;
                _mAutoMenu.Items = new string[0];
                _mAutoMenu.TargetControlWrapper = null;
                _mAutoMenu.Selected += _mAutoMenu_Selected;
                _mAutoMenu.Selecting += _mAutoMenu_Selecting;
                _mAutoMenu.AllowsTabKey = true;
            }



            _mAutoMenu.ShowPopupOnClick = ShowPopupOnClick;

            _mAutoMenu.MaximumSize = new Size(Columns.Sum(c => c.Width), Height);
            _mAutoMenu.SearchAllText = SearchAllText;
            _mAutoMenu.MinFragmentLength = MinFragmentLength;


            if (CompareBySubString)
            {
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
                        lst[i].ColumnValue = R[lst[i].ColumnName].ToString();

                    _mAutoMenu.AddItem(new HVTT.UI.Window.Forms.HVTTAutoCompleteMenu.MulticolumnAutocompleteItem(lst, R[FilterColumnName].ToString()));
                }
            }
            else
            {
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
                        lst[i].ColumnValue = R[lst[i].ColumnName].ToString();

                    _mAutoMenu.AddItem(new HVTT.UI.Window.Forms.HVTTAutoCompleteMenu.MulticolumnAutocompleteItem(lst, R[FilterColumnName].ToString(), false));
                }
            }
            _mAutoMenu.SetAutocompleteMenu(this, _mAutoMenu);
        }
        public enum AutoMenuFilterModes
        {
            Text,
            Value,
            TextAndValue,
            ValueAndText
        }

        public void SetAutoMenu(Dictionary<String,String> lstData,
         List<HVTT.UI.Window.Forms.HVTTAutoCompleteMenu.MenuColumn> Columns,
         AutoMenuFilterModes FilterMode= AutoMenuFilterModes.Value,
         Boolean ShowPopupOnClick = false,
         Boolean SearchAllText = true,
         int MinFragmentLength = 0,
         int Height = 200
         )
        {
            if (_mAutoMenu != null)
            {
                _mAutoMenu.AutocompleteItems.Clear();
                _mAutoMenu.Update();
            }
            else
            {
                _mAutoMenu = new AutocompleteMenu();
                _mAutoMenu.Colors = new Colors();
                _mAutoMenu.Font = this.Font;
                _mAutoMenu.ImageList = null;
                _mAutoMenu.Items = new string[0];
                _mAutoMenu.TargetControlWrapper = null;
                _mAutoMenu.Selected += _mAutoMenu_Selected;
                _mAutoMenu.Selecting += _mAutoMenu_Selecting;
                _mAutoMenu.AllowsTabKey = true;
            }



            _mAutoMenu.ShowPopupOnClick = ShowPopupOnClick;

            _mAutoMenu.MaximumSize = new Size(Columns.Sum(c => c.Width), Height);
            _mAutoMenu.SearchAllText = SearchAllText;
            _mAutoMenu.MinFragmentLength = MinFragmentLength;


            foreach (var x in lstData)
            {
                var lst = new List<HVTT.UI.Window.Forms.HVTTAutoCompleteMenu.MenuColumn>();
               

                lst.Add(new MenuColumn()
                {
                    ColumnName = Columns[0].ColumnName,
                    ColumnValue = x.Key,
                    IsVisible = Columns[0].IsVisible,
                    Width = Columns[0].Width
                });
                lst.Add(new MenuColumn()
                {
                    ColumnName = Columns[1].ColumnName,
                    ColumnValue = x.Value,
                    IsVisible = Columns[1].IsVisible,
                    Width = Columns[1].Width
                });

                String strFilter = "";
                switch(FilterMode)
                {
                    default:
                        strFilter = x.Key;
                        break;
                    case AutoMenuFilterModes.Text:
                        strFilter = x.Value;
                        break;
                    case AutoMenuFilterModes.TextAndValue:
                        strFilter = x.Value + " - " + x.Key;
                        
                        break;
                    case AutoMenuFilterModes.ValueAndText:
                        strFilter = x.Key + " " + x.Value;
                        break;
                }

                _mAutoMenu.AddItem(new HVTT.UI.Window.Forms.HVTTAutoCompleteMenu.MulticolumnAutocompleteItem(lst, strFilter.Trim()));
            }
            _mAutoMenu.SetAutocompleteMenu(this, _mAutoMenu);
        }

        private void _mAutoMenu_Opening(object sender, CancelEventArgs e)
        {
            if (AutoMenuOpening != null)
                AutoMenuOpening(this, e);
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

        protected override void OnDoubleClick(EventArgs e)
        {
            if (_mAutoMenu != null && _mAutoMenu.AutocompleteItems.Count > 0)
                _mAutoMenu.ShowAutocomplete(true);
            base.OnDoubleClick(e);
        }
        #endregion

        #region Placehooder

        #region Fields

        #region Protected Fields

        protected string _PlaceHolderText = ""; //The PlaceHolder text
        protected Color _PlaceHolderColor; //Color of the PlaceHolder when the control does not have focus
        protected Color _PlaceHolderActiveColor; //Color of the PlaceHolder when the control has focus

        #endregion

        #region Private Fields

        private Panel _mPlaceHolderContainer; //Container to hold the PlaceHolder
        private Font _mPlaceHolderFont; //Font of the PlaceHolder
        private SolidBrush _mPlaceHolderBrush; //Brush for the PlaceHolder

        #endregion

        #endregion


        #region Private Methods

        /// <summary>
        /// Initializes PlaceHolder properties and adds CtextBox events
        /// </summary>
        private void Initialize()
        {
            //Sets some default values to the PlaceHolder properties
            _PlaceHolderColor = Color.LightGray;
            _PlaceHolderActiveColor = Color.Gray;
            _mPlaceHolderFont = this.Font;
            _mPlaceHolderBrush = new SolidBrush(_PlaceHolderActiveColor);
            _mPlaceHolderContainer = null;

            //Draw the PlaceHolder, so we can see it in design time
            DrawPlaceHolder();

            //Eventhandlers which contains function calls. 
            //Either to draw or to remove the PlaceHolder
            this.Enter += new EventHandler(ThisHasFocus);
            this.Leave += new EventHandler(ThisWasLeaved);
            this.TextChanged += new EventHandler(ThisTextChanged);
        }

        /// <summary>
        /// Removes the PlaceHolder if it should
        /// </summary>
        private void RemovePlaceHolder()
        {
            if (_mPlaceHolderContainer != null)
            {
                this.Controls.Remove(_mPlaceHolderContainer);
                _mPlaceHolderContainer = null;
            }
        }

        /// <summary>
        /// Draws the PlaceHolder if the text length is 0
        /// </summary>
        private void DrawPlaceHolder()
        {
            if (PlaceHolder == null || PlaceHolder.Trim() == "")
                return;

            if (this._mPlaceHolderContainer == null && this.TextLength <= 0)
            {
                _mPlaceHolderContainer = new Panel(); // Creates the new panel instance
                _mPlaceHolderContainer.Paint += new PaintEventHandler(PlaceHolderContainer_Paint);
                _mPlaceHolderContainer.Invalidate();
                _mPlaceHolderContainer.Click += new EventHandler(PlaceHolderContainer_Click);
                this.Controls.Add(_mPlaceHolderContainer); // adds the control
            }
        }

        #endregion

        #region Eventhandlers

        #region PlaceHolder Events

        private void PlaceHolderContainer_Click(object sender, EventArgs e)
        {
            this.Focus(); //Makes sure you can click wherever you want on the control to gain focus
        }

        private void PlaceHolderContainer_Paint(object sender, PaintEventArgs e)
        {
            //Setting the PlaceHolder container up
            _mPlaceHolderContainer.Location = new Point(2, 0); // sets the location
            _mPlaceHolderContainer.Height = this.Height; // Height should be the same as its parent
            _mPlaceHolderContainer.Width = this.Width; // same goes for width and the parent
            _mPlaceHolderContainer.Anchor = AnchorStyles.Left | AnchorStyles.Right; // makes sure that it resizes with the parent control



            if (this.ContainsFocus)
            {
                //if focused use normal color
                _mPlaceHolderBrush = new SolidBrush(this._PlaceHolderActiveColor);
            }

            else
            {
                //if not focused use not active color
                _mPlaceHolderBrush = new SolidBrush(this._PlaceHolderColor);
            }

            //Drawing the string into the panel 
            Graphics g = e.Graphics;
            g.DrawString(this._PlaceHolderText, PlaceHolderFont, _mPlaceHolderBrush, new PointF(-2f, 1f));//Take a look at that point
            //The reason I'm using the panel at all, is because of this feature, that it has no limits
            //I started out with a label but that looked very very bad because of its paddings 

        }

        #endregion

        #region CTextBox Events

        private void ThisHasFocus(object sender, EventArgs e)
        {
            //if focused use focus color
            _mPlaceHolderBrush = new SolidBrush(this._PlaceHolderActiveColor);

            //The PlaceHolder should not be drawn if the user has already written some text
            if (this.TextLength <= 0)
            {
                RemovePlaceHolder();
                DrawPlaceHolder();
            }
        }

        private void ThisWasLeaved(object sender, EventArgs e)
        {
            //if the user has written something and left the control
            if (this.TextLength > 0)
            {
                //Remove the PlaceHolder
                RemovePlaceHolder();
            }
            else
            {
                //But if the user didn't write anything, Then redraw the control.
                this.Invalidate();
            }
        }

        private void ThisTextChanged(object sender, EventArgs e)
        {
            //If the text of the textbox is not empty
            if (this.TextLength > 0)
            {
                //Remove the PlaceHolder
                RemovePlaceHolder();
            }
            else
            {
                //But if the text is empty, draw the PlaceHolder again.
                DrawPlaceHolder();
            }
        }

        #region Overrided Events

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Draw the PlaceHolder even in design time
            DrawPlaceHolder();
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
            //Check if there is a PlaceHolder
            if (_mPlaceHolderContainer != null)
                //if there is a PlaceHolder it should also be invalidated();
                _mPlaceHolderContainer.Invalidate();
            if(TypeStyle== TypeStyles.Number)
            {
                this.Text = this.GetDecimal().ToString(FormatNumber);
            }
        }

        #endregion

        #endregion

        #endregion

        #region Properties
        [Category("PlaceHolder attribtues")]
        [Description("Sets the text of the PlaceHolder")]
        public string PlaceHolder
        {
            get { return this._PlaceHolderText; }
            set
            {
                this._PlaceHolderText = value;
                DrawPlaceHolder();
                this.Invalidate();
            }
        }

        [Category("PlaceHolder attribtues")]
        [Description("When the control gaines focus, this color will be used as the PlaceHolder's forecolor")]
        public Color PlaceHolderActiveForeColor
        {
            get { return this._PlaceHolderActiveColor; }

            set
            {
                this._PlaceHolderActiveColor = value;
                this.Invalidate();
            }
        }

        [Category("PlaceHolder attribtues")]
        [Description("When the control looses focus, this color will be used as the PlaceHolder's forecolor")]
        public Color PlaceHolderForeColor
        {
            get { return this._PlaceHolderColor; }

            set
            {
                this._PlaceHolderColor = value;
                this.Invalidate();
            }
        }

        [Category("PlaceHolder attribtues")]
        [Description("The font used on the PlaceHolder. Default is the same as the control")]
        public Font PlaceHolderFont
        {
            get
            {
                return this._mPlaceHolderFont;
            }

            set
            {
                this._mPlaceHolderFont = value;
                this.Invalidate();
            }
        }


        #endregion

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
