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
using System.Linq;

using System.Globalization;
using HVTT.UI.Window.Forms.HVTTAutoCompleteMenu;

namespace HVTT.UI.Window.Forms.Controls
{

    [Description("HVTTNumberic Control")]
    [ToolboxBitmap(typeof(TextBox))]
    [Designer(typeof(HVTTNumbericDesigner))]
    public partial class HVTTNumberic : TextBox
    {

        #region Designer


        
        protected override void Dispose(bool disposing)
        {
        
            base.Dispose(disposing);
        }

        public HVTTNumberic()
        {

            //base.Size = new Size(100, 20);
            //base.Font = new Font("Microsoft Sans Serif", 9);
            //SetStyle(
            //    //ControlStyles.AllPaintingInWmPaint |
            //    //ControlStyles.ResizeRedraw |
            //    //ControlStyles.DoubleBuffer |
            //    //ControlStyles.Selectable |
            //    //ControlStyles.UserMouse,
            //    //true
            //    ControlStyles.AllPaintingInWmPaint |
            //    ControlStyles.ResizeRedraw |
            //    //ControlStyles.DoubleBuffer |
            //    ControlStyles.Selectable |
            //    ControlStyles.UserMouse,
            //    true
            //    );
            SetValueDefault();
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //this.Leave += new System.EventHandler(this.HVTTNumberic_Leave);
        }

        #endregion


        #region Avalible

        HVTTStyle2008 _HVTTStyle2008 = new HVTTStyle2008();
      
        Color _RecentBackColor = Color.Empty;
        Color _RecentBorderColor = Color.Empty;
        String _sResentText = "";

        CultureInfo ci = new CultureInfo("en-us");

        #endregion


        #region Property

        //private GradientStyles _GradientStyle;
        //private SmoothingQualities _SmoothingQuality;
        private NumberTypes _NumberType;

        private Color _mcrBorderColor;
        //private Color _mcrBackColor1;
        //private Color _mcrBackColor2;

        private Boolean _mbRequire = false;
        private Object _mobjValue = String.Empty;
        private int _miDecimal;
        private Boolean _mbIsNegative = true;
        private Boolean _mbAllowEdit = true;

        private Boolean _mbIsChange = false;
        private int _miLivel = -1;
 
        private Decimal _mdclDefaultValue = 0;
        private float _mfMaxPecent = 1;
        private Boolean _mblnDisableCurrencySymboy = true;

        public float MaxPercent
        {
            get
            {
                return _mfMaxPecent;
            }
            set
            {
                _mfMaxPecent = value;
            }
        }
        public Decimal DefaultValue
        {
            get
            {
                return _mdclDefaultValue;
            }
            set
            {
                _mdclDefaultValue = value;
            }
        }
        public Boolean DesableCurrencySymboy
        {
            get
            {
                return _mblnDisableCurrencySymboy;
            }
            set
            {
                _mblnDisableCurrencySymboy = value;
            }
        }

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

        

        [Description("Get or set Text Of Numberic"), Category("HVTTNumberic")]
        public override String Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                _sResentText = base.Text;
                base.Text = value;
                Invalidate();
            }
        }

        [Description("Get or set Value Of Numberic"), Category("HVTTNumberic")]
        [Browsable(false)]
        public  Object Value
        {
            get
            {
               // _mobjValue = GetAllNumber();
                return ((_mobjValue == null || _mobjValue.ToString().Trim() == "") ? 0 : _mobjValue);
            }
            set
            {
                _mobjValue = value;
                base.Text = _mobjValue.ToString();
            }
        }

        [Description("Allow or don't allow input negative number"), Category("HVTTNumberic")]
        public Boolean IsNegative
        {
            get
            {
                return _mbIsNegative;
            }
            set
            {
                _mbIsNegative = value;
                Invalidate();
            }
        }

        [Description("Get or set property allowedit"), Category("HVTTNumberic")]
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

        [Description("Get or set property Require"), Category("HVTTNumberic")]
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

        [Description("Get or set NumberType"), Category("HVTTNumberic")]
        public NumberTypes NumberType
        {
            get
            {
                return _NumberType;
            }
            set
            {
                _NumberType = value;
            }
        }

        [Description("Get or set Decimal"), Category("HVTTNumberic")]
        public int Decimal
        {
            get
            {
                return _miDecimal;
            }
            set
            {
                _miDecimal = value;
            }
        }

        [Browsable(false)]
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
        private String GetAllNumber()
        {
            if (this.Text.Trim() != "")
            {
                return this.Text.Replace(",", "");
            }
            return "0";
        }

        private void SetValueDefault()
        {
            _NumberType = NumberTypes.Integer;
            _mcrBorderColor = Color.Black;

            _miDecimal = 0;
            
        }
        private void SetControlStyle()
        {
            //if (!_mbAllowEdit && !_mbRequire)
            //{
            //    base.BackColor = _HVTTStyle2008.AllowEditBackColor;
            //    _mcrBorderColor = _HVTTStyle2008.AllowEditBorderColor;
            //}
            //else if (!_mbAllowEdit && _mbRequire)
            //{
            //    base.BackColor = _HVTTStyle2008.AllowEditBackColor;
            //    _mcrBorderColor = _HVTTStyle2008.AllowEditBorderColor;
            //    //SetValueRequire();
            //}
            //else if (_mbAllowEdit && _mbRequire)
            //{
            //    base.BackColor = _HVTTStyle2008.RequireBackColor;
            //    _mcrBorderColor = _HVTTStyle2008.RequireBorderColor;
            //}

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

            this.BackColor = _HVTTStyle2008.AllowEditBackColor; //Color.FromArgb(224, 224, 224);
            _mcrBorderColor = _HVTTStyle2008.AllowEditBorderColor;//Color.FromArgb(0, 0, 192);
            // this.BackColor = _mcrBackColor1;
        }

        private void SetValueRequire()
        {

            this.BackColor = _HVTTStyle2008.RequireBackColor;//Color.Moccasin;
            _mcrBorderColor = _HVTTStyle2008.RequireBorderColor;//Color.Red;
            //this.BackColor = _mcrBackColor1;
        }

        private void SetValueRecent()
        {

            this.BackColor = _RecentBackColor;
            _mcrBorderColor = _RecentBorderColor;
            //this.BackColor = _mcrBackColor1;
        }


        private void FillSmoothingQuality(ref Graphics g)
        {
            //switch (_SmoothingQuality)
            //{
            //    case SmoothingQualities.None:
            //        g.SmoothingMode = SmoothingMode.Default;
            //        break;
            //    case SmoothingQualities.HighSpeed:
            //        g.SmoothingMode = SmoothingMode.HighSpeed;
            //        break;
            //    case SmoothingQualities.AntiAlias:
            //        g.SmoothingMode = SmoothingMode.AntiAlias;
            //        break;
            //    case SmoothingQualities.HighQuality:
            //        g.SmoothingMode = SmoothingMode.HighQuality;
            //        break;
            //}
        }
        private LinearGradientMode GetGradientStyle()
        {
            LinearGradientMode Mode = new LinearGradientMode();

            //switch (_GradientStyle)
            //{
            //    case GradientStyles.Horizontal:
            //        Mode = LinearGradientMode.Horizontal;
            //        break;
            //    case GradientStyles.Vertical:
            //        Mode = LinearGradientMode.Vertical;
            //        break;
            //    case GradientStyles.ForwardDiagonal:
            //        Mode = LinearGradientMode.ForwardDiagonal;
            //        break;
            //    case GradientStyles.BackwardDiagonal:
            //        Mode = LinearGradientMode.BackwardDiagonal;
            //        break;
            //    default:
            //        Mode = LinearGradientMode.Vertical;
            //        break;
            //}
            return Mode;
        }

        private int GetLengthAllow()
        {
            int iLength = 0;
            switch (_NumberType)
            {
                case NumberTypes.Int16:
                    iLength = 5;
                    break;
                case NumberTypes.Integer:
                    iLength = 10;
                    break;
                case NumberTypes.In64:
                    iLength = 19;
                    break;
                case NumberTypes.Double:
                    iLength = 19;
                    break;
                case NumberTypes.HVTTNumber:
                    iLength = 1000;
                    break;
            }
            return iLength;
        }
        private void TestNumber(String s)
        {
            String sNegative = "";
            s = GetNumber(s, ref sNegative);
            s = UnFormat(s);
            if (s.Trim() != "")
            {
                switch (_NumberType)
                {
                    case NumberTypes.Int16:
                        Int16 i = 0;
                        if (!Int16.TryParse(s, out i))
                        {
                            throw new ExecutionEngineException("Int16 out of value");
                        }
                        break;
                    case NumberTypes.Integer:
                        Int32 i1 = 0;
                        if (!Int32.TryParse(s, out i1))
                        {
                            throw new ExecutionEngineException("Integer out of value");
                        }
                        break;
                    case NumberTypes.In64:
                        Int64 i2 = 0;
                        if (!Int64.TryParse(s, out i2))
                        {
                            throw new ExecutionEngineException("Int64 out of value");
                        }
                        break;
                    case NumberTypes.Double:
                        Double i3 = 0;
                        if (!Double.TryParse(s, out i3))
                        {
                            throw new ExecutionEngineException("Double out of value");
                        }
                        break;
                    case NumberTypes.HVTTNumber:

                        if (s.Length > 1000)
                        {
                            throw new ExecutionEngineException("HVTTNumber out of value");
                        }
                        break;
                }
            }
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
        private String GetNumber(String s, ref String sNegative)
        {
            if (s.Trim() != "")
            {
                if (s.Trim()[0] == '-')
                {
                    sNegative = "-";
                    return s.Substring(1);
                }
                sNegative = "";
            }
            return s;   
        }
        private String Format(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
                if (s[i] != ',')
                    sb.Append(s[i]);
            return sb.ToString();
        }
        private String Format(String s, ref int iSelectionStart, Boolean IsDeleteKey)
        {
            String s1 = Format(s);
            if (s1.Length < s.Length)
                iSelectionStart--;
            int i = s1.Length - 1;
            int iLength = 0;
            String sRS = "";
            StringBuilder sb = new StringBuilder();
            Char[] cArray = s1.ToCharArray();
            while (i >= 0)
            {
                if (iLength == 3)
                {

                    sb.Append(',');
                    //for (int j = sb.Length - 1; j >= 0; j--)
                    //    sRS = sRS + sb[j];
                    sb.Append(cArray[i]);
                    if (!IsDeleteKey)
                        iSelectionStart++;
                    iLength = 1;
                    //sb = new StringBuilder();
                }
                else
                {
                    sb.Append(cArray[i]);
                    iLength++;
                }

                i--;
            }


            for (int j = sb.Length - 1; j >= 0; j--)
                sRS = sRS + sb[j];


            //this.SelectionStart = ((iSelectionStart>1 && this.Text.Length>3)?iSelectionStart-1:iSelectionStart);
            return sRS;
        }
        private String GetDecimal(String s, ref String sDecimal)
        {
            if (Search(s, '.'))
            {
                sDecimal = s.Substring(s.LastIndexOf("."));
                return s.Substring(0,s.LastIndexOf("."));
            }
            sDecimal = "";
            return s;
        }

        private String FormatDecimal(String s, ref int iSelection,Boolean IsDeleteKey)
        {
            String sDecimal = "";
            String s1 = GetDecimal(s, ref sDecimal);
            if (sDecimal.Trim() != "")
            {
                return Format(s1,ref iSelection,IsDeleteKey) + sDecimal;
            }
            return Format(s1,ref iSelection,IsDeleteKey);
        }
        private String UnFormat(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ',')
                    sb.Append(s[i]);
            }
            return sb.ToString();
        }


        #endregion

        #region Public Method

        [Description("Return a Int16 all NumberTypes.If Value biger than Int16 value,it will choose a value smaller or same MaxValue.If Value smaller than Int16 value,it will choose a value bigger or same MinValue")]
        public Int16 GetInt16()
        {
            if (this.Text.Trim() == "")
                return 0;
            try
            {
                return Convert.ToInt16(this.Text.Trim());
            }
            catch { }
            return 0;
            //try
            //{
            //    return Convert.ToInt16((_mobjValue == null || _mobjValue.ToString().Trim() == "") ? 0 : _mobjValue);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        [Description("Return a Int32 all NumberTypes.If Value biger than Int32 value,it will choose a value smaller or same MaxValue.If Value smaller than Int32 value,it will choose a value bigger or same MinValue")]
        public Int32 GetInt32()
        {
            //if (this.Text.Trim() == "")
            //    return 0;
            //try
            //{
            //    return Convert.ToInt32(this.Text.Trim());
            //}
            //catch { }
            //return 0;
            try
            {
                return Convert.ToInt32((_mobjValue == null || _mobjValue.ToString().Trim() == "") ? 0 : _mobjValue);
            }
            catch
            {
                return 0;
            }
        }

        [Description("Return a Int64 all NumberTypes.If Value biger than Int64 value,it will choose a value smaller or same MaxValue.If Value smaller than Int64 value,it will choose a value bigger or same MinValue")]
        public Int64 GetInt64()
        {
            //if (this.Text.Trim() == "")
            //    return 0;
            //try
            //{
            //    return Convert.ToInt64(this.Text.Trim());
            //}
            //catch { }
            //return 0;
            try
            {
                return Convert.ToInt64((_mobjValue == null || _mobjValue.ToString().Trim() == "") ? 0 : _mobjValue);
            }
            catch
            {
                return 0;
            }
        }

        [Description("Return a Double all NumberTypes.If Value biger than Double value,it will choose a value smaller or same Double.If Value smaller than Double value,it will choose a value bigger or same MinValue")]
        public Double GetDouble()
        {
            //if (this.Text.Trim() == "")
            //    return 0;
            //try
            //{
            //    return Convert.ToDouble(this.Text.Trim());
            //}
            //catch { }
            //return 0;
            try
            {
                return Convert.ToDouble((_mobjValue == null || _mobjValue.ToString().Trim() == "") ? 0 : _mobjValue);
            }
            catch
            {
                return 0;
            }
        }
        [Description("Return a Decimal all NumberTypes.If Value biger than Double value,it will choose a value smaller or same Double.If Value smaller than Double value,it will choose a value bigger or same MinValue")]
        public Decimal GetDecimal()
        {
            //if (this.Text.Trim() == "")
            //    return 0;
            //try
            //{
            //    return Convert.ToDecimal(this.Text.Trim());
            //}
            //catch { }
            //return 0;
            try
            {
                return Convert.ToDecimal((_mobjValue == null || _mobjValue.ToString().Trim() == "") ? 0 : _mobjValue);
            }
            catch
            {
                return 0;
            }
        }

        //[Description("Return a HVTTNumber all NumberTypes.If Value biger than HVTTNumber value,it will choose a value smaller or same HVTTNumber.If Value smaller than HVTTNumber value,it will choose a value bigger or same MinValue")]
        //public HVTTNumber GetHVTTNumber()
        //{
        //    if (_mobjValue != null)
        //    {
        //        if (_mobjValue.ToString().Length > 1000)
        //        {
        //            String s = "";
        //            for (int i = 0; i <= 1000; i++)
        //                s = s + "9";
        //            return new HVTTNumber(s);
        //        }
        //        else
        //            return new HVTTNumber(_mobjValue.ToString());
        //    }
        //    else
        //    {
        //        String s = "-";
        //        for (int i = 0; i <= 1000; i++)
        //            s = s + "9";
        //        return new HVTTNumber(s);
        //    }

        //}




        #endregion

        #region Event

        public event EventHandler ValueChanged;
        public event EventHandler HasFocus;

       
       



        protected override void OnMouseDown(MouseEventArgs e)
        {
            //this.Select();
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
           // this.SelectAll();
            base.OnMouseMove(e);
        }
        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
        //    {
        //        if (_NumberType == NumberTypes.Currency && e.KeyChar.ToString() != ci.NumberFormat.CurrencyDecimalSeparator)
        //        {
        //            e.Handled = true;
        //            return;
        //        }
        //        else if (_mbIsNegative && e.KeyChar.ToString() != "-")
        //        {
        //            e.Handled = true;
        //            return;
        //        }
        //        else if (e.KeyChar.ToString() != ci.NumberFormat.NumberDecimalSeparator)
        //        {
        //            e.Handled = true;
        //            return;
        //        }
        //    }
        //    if (_NumberType == NumberTypes.Currency)
        //    {
        //        int iSelected = this.SelectionStart;
        //        for (int i = iSelected; i < this.Text.Length; i++)
        //        {
        //            if (this.Text[i].ToString() == ci.NumberFormat.CurrencySymbol)
        //            {
        //                e.Handled = true;
        //                return;
        //            }
        //        }

        //        if (e.KeyChar.ToString() == ci.NumberFormat.CurrencyDecimalSeparator && this.Text.Contains(ci.NumberFormat.CurrencyDecimalSeparator))
        //        {
        //            e.Handled = true;
        //            return;
        //        }
        //        if (e.KeyChar.ToString() == ci.NumberFormat.CurrencyDecimalSeparator && this.Text.Length < 1)
        //        {
        //            e.Handled = true;
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        if (e.KeyChar.ToString() == ci.NumberFormat.NumberDecimalSeparator && this.Text.Contains(ci.NumberFormat.NumberDecimalSeparator))
        //        {
        //            e.Handled = true;
        //            return;
        //        }
        //        if (e.KeyChar.ToString() == ci.NumberFormat.NumberDecimalSeparator && this.Text.Length < 1)
        //        {
        //            e.Handled = true;
        //            return;
        //        }
        //    }

            
           
        //}
        
        //protected override void OnTextChanged(EventArgs e)
        //{
        //    try
        //    {
        //        base.OnTextChanged(e);

        //        int iSelected = this.SelectionStart;
        //        int iLength = this.Text.Length;

        //        _HVTTSys.IsChange = true;
        //        if (_sResentText != this.Text)
        //            _mbIsChange = true;
        //        _sResentText = this.Text;

                
        //        if (_NumberType == NumberTypes.In64 || _NumberType == NumberTypes.Int16 || _NumberType == NumberTypes.Integer)
        //        {
        //            String text = "";
        //            if (this.Text.LastIndexOf(ci.NumberFormat.CurrencyDecimalSeparator) > 0)
        //                text = this.Text.Substring(0, this.Text.LastIndexOf(ci.NumberFormat.CurrencyDecimalSeparator));
        //            else
        //                text = this.Text;

             
        //            _mobjValue = Int64.Parse(text.Replace(ci.NumberFormat.CurrencyGroupSeparator, ""), System.Globalization.NumberStyles.Number);
        //        }
        //        else if (_NumberType== NumberTypes.Double || _NumberType == NumberTypes.Decimal || _NumberType== NumberTypes.Percent)
        //        {
        //            if (_NumberType == NumberTypes.Percent)
        //            {
        //                _mobjValue = decimal.Parse(this.Text.Replace("%", ""), System.Globalization.NumberStyles.Number);
        //            }
        //            else
        //                _mobjValue = decimal.Parse(this.Text, System.Globalization.NumberStyles.Number);
        //        }
        //        else if(_NumberType== NumberTypes.Currency)
        //        {
        //            _mobjValue = decimal.Parse(this.Text, System.Globalization.NumberStyles.Currency);
        //        }
                
        //        if (_NumberType == NumberTypes.In64 || _NumberType == NumberTypes.Int16 || _NumberType == NumberTypes.Integer)
        //        {
        //            Int64 l = GetInt64();
        //            String txt = "";
        //            if (l.ToString("N", ci).LastIndexOf(ci.NumberFormat.CurrencyDecimalSeparator) > 0)
        //                txt = l.ToString("N", ci).Substring(0, l.ToString("N", ci).LastIndexOf(ci.NumberFormat.CurrencyDecimalSeparator));
        //            else
        //                txt = l.ToString("N", ci);
        //            if (txt.Length > iLength)
        //                this.SelectionStart = iSelected + 1;
        //            else if (txt.Length < iLength)
        //                this.SelectionStart = iSelected - 1;
        //            else
        //                this.SelectionStart = iSelected;
        //        }
        //        else if (_NumberType == NumberTypes.Double || _NumberType == NumberTypes.Decimal || _NumberType == NumberTypes.Percent)
        //        {
        //            decimal dec = GetDecimal();
        //            if (_NumberType == NumberTypes.Percent && dec > Convert.ToDecimal(_mfMaxPecent * 100))
        //            {
        //                _mobjValue = _mfMaxPecent * 100;
        //                dec = Convert.ToDecimal(_mfMaxPecent * 100);
        //            }
        //            String txt = dec.ToString("N", ci);
        //            if (_NumberType == NumberTypes.Percent)
        //                this.Text = txt + "%";
        //            else
        //                this.Text = txt;
        //            //this.SelectionStart = iSelected + 1;
        //            if (txt.Length > iLength)
        //                this.SelectionStart = iSelected + 1;
        //            else if (txt.Length < iLength)
        //                this.SelectionStart = iSelected - 1;
        //            else
        //            {
        //                this.SelectionStart = iSelected;
        //            }
        //        }
        //        else if (_NumberType == NumberTypes.Currency)
        //        {
        //            decimal dec = GetDecimal();
        //            String txt = dec.ToString("C", ci);
        //            this.Text = txt;
        //            if (txt.Length > iLength)
        //                this.SelectionStart = iSelected + 1;
        //            else if (txt.Length < iLength)
        //                this.SelectionStart = iSelected - 1;
        //            else
        //                this.SelectionStart = iSelected;
        //        }
                
        //        if (_NumberType == NumberTypes.Double || _NumberType == NumberTypes.Decimal||_NumberType== NumberTypes.Currency)
        //        {
        //            int iCi = this.Text.Length - this.SelectionStart - 1;
        //            if (iCi < ci.NumberFormat.NumberDecimalDigits)
        //            {
        //                this.SelectionStart++;
        //            }
        //        }
        //        else if (_NumberType == NumberTypes.Percent)
        //        {
        //            int iCi = this.Text.Length - this.SelectionStart - 2;
        //            if (iCi < ci.NumberFormat.NumberDecimalDigits)
        //            {
        //                this.SelectionStart++;
        //            }
        //        }
        //        if (ValueChanged != null)
        //            ValueChanged(this, e);
                
        //    }
        //    catch 
        //    {
        //        //throw ex;
        //    }
        //}
        int iSelectionStarted = -1;
        int iLengthed = -1;
        int iSelectionStartNoneDecimalDigit = -1;
        int iSelectionLengthNone = -1;
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                if (_NumberType == NumberTypes.Currency && e.KeyChar.ToString() != ci.NumberFormat.CurrencyDecimalSeparator)
                {
                    e.Handled = true;
                    return;
                }
                else if (_mbIsNegative && e.KeyChar.ToString() != "-" && e.KeyChar.ToString() != ci.NumberFormat.NumberDecimalSeparator)
                {
                    e.Handled = true;
                    return;
                }
                //else if (e.KeyChar.ToString() != ci.NumberFormat.NumberDecimalSeparator)
                //{
                //    e.Handled = true;
                //    return;
                //}
            }
            if (_NumberType == NumberTypes.Currency)
            {
                int iSelected = this.SelectionStart;
                for (int i = iSelected; i < this.Text.Length; i++)
                {
                    if (this.Text[i].ToString() == ci.NumberFormat.CurrencySymbol)
                    {
                        e.Handled = true;
                        return;
                    }
                }

                if (e.KeyChar.ToString() == ci.NumberFormat.CurrencyDecimalSeparator && this.Text.Contains(ci.NumberFormat.CurrencyDecimalSeparator))
                {
                    e.Handled = true;
                    return;
                }
                if (e.KeyChar.ToString() == ci.NumberFormat.CurrencyDecimalSeparator && this.Text.Length < 1)
                {
                    e.Handled = true;
                    return;
                }
                if (Char.IsControl(e.KeyChar))
                {
                    int iDigitDecimal = ci.NumberFormat.CurrencyDecimalDigits;
                    if (this.Text.Length - iSelected < iDigitDecimal)
                    {
                        //this.SelectionStart--;
                        iSelectionStarted = this.SelectionStart - 1;
                    }
                }
                else if (this.Text.LastIndexOf(ci.NumberFormat.CurrencyDecimalSeparator) < SelectionStart)
                    iSelectionStarted = this.SelectionStart + 1;
                
            }
            else
            {
                int iSelected = this.SelectionStart;
                if (e.KeyChar.ToString() == ci.NumberFormat.NumberDecimalSeparator && this.Text.Contains(ci.NumberFormat.NumberDecimalSeparator))
                {
                    e.Handled = true;
                    return;
                }
                if (e.KeyChar.ToString() == ci.NumberFormat.NumberDecimalSeparator && this.Text.Length < 1)
                {
                    e.Handled = true;
                    return;
                }
                if (Char.IsControl(e.KeyChar))
                {
                    int iDigitDecimal = ci.NumberFormat.NumberDecimalDigits;
                    if (this.Text.Length - iSelected < iDigitDecimal)
                    {
                        //this.SelectionStart--;
                        iSelectionStarted = this.SelectionStart - 1;
                    }
                }
                else if ( this.Text.LastIndexOf(ci.NumberFormat.NumberDecimalSeparator) > 0 && this.Text.LastIndexOf(ci.NumberFormat.NumberDecimalSeparator) < SelectionStart)
                    iSelectionStarted = this.SelectionStart + 1;
            }
            iLengthed = this.Text.Length;
            iSelectionStartNoneDecimalDigit = this.SelectionStart;
            iSelectionLengthNone = this.SelectionLength;
           // this.SelectionLength = 0;
        }
        int iSelectionStartTextChanged = -1;
        protected override void OnTextChanged(EventArgs e)
        {
            try
            {
                base.OnTextChanged(e);


                int iSelected = this.SelectionStart;

                int iLength = this.Text.Length;
                int iCurrencyDigitDecimal = ci.NumberFormat.CurrencyDecimalDigits;
                int iNumberDigitDecimal = ci.NumberFormat.NumberDecimalDigits;

                
                if (_sResentText != this.Text)
                    _mbIsChange = true;
                _sResentText = this.Text;


                if (_NumberType == NumberTypes.In64 || _NumberType == NumberTypes.Int16 || _NumberType == NumberTypes.Integer)
                {
                    _mobjValue = Int64.Parse(this.Text, (System.Globalization.NumberStyles)(System.Globalization.NumberStyles.Number | System.Globalization.NumberStyles.AllowDecimalPoint));
                }
                else if (_NumberType == NumberTypes.Double || _NumberType == NumberTypes.Decimal || _NumberType == NumberTypes.Percent)
                {
                    if (_NumberType == NumberTypes.Percent)
                    {
                        _mobjValue = decimal.Parse(this.Text.Replace("%", ""), System.Globalization.NumberStyles.Number);
                    }
                    else
                        _mobjValue = decimal.Parse(this.Text, System.Globalization.NumberStyles.Number);
                }
                else if (_NumberType == NumberTypes.Currency)
                {
                    _mobjValue = decimal.Parse(this.Text, System.Globalization.NumberStyles.Currency);
                }

                if (_NumberType == NumberTypes.In64 || _NumberType == NumberTypes.Int16 || _NumberType == NumberTypes.Integer)
                {
                    String text = "";
                    Int64 l = this.GetInt64();
                    text = l.ToString("N0");
                    this.Text = text;
                    int iCurrentLength = this.Text.Length;
                    if (iLengthed < iCurrentLength)
                    {
                        this.SelectionStart = iSelectionStartNoneDecimalDigit + iCurrentLength - iLengthed;
                    }
                    else if (iLengthed == iCurrentLength)
                    {
                        if (iSelectionLengthNone > 0)
                            this.SelectionStart = iSelectionStartNoneDecimalDigit + 1;
                        else
                            this.SelectionStart = iSelectionStartNoneDecimalDigit;
                    }
                    else
                        this.SelectionStart = iSelectionStartNoneDecimalDigit - iLengthed + iCurrentLength;

                }
                else if (_NumberType == NumberTypes.Double || _NumberType == NumberTypes.Decimal || _NumberType == NumberTypes.Percent)
                {
                    decimal dec = GetDecimal();
                    if (_NumberType == NumberTypes.Percent && dec > Convert.ToDecimal(_mfMaxPecent * 100))
                    {
                        _mobjValue = _mfMaxPecent * 100;
                        dec = Convert.ToDecimal(_mfMaxPecent * 100);
                    }
                    String txt = dec.ToString("N", ci);

                    if (this.Text.LastIndexOf(ci.NumberFormat.NumberDecimalSeparator) + 1 > this.SelectionStart && this.SelectionStart > 0)
                        iSelectionStartTextChanged = this.SelectionStart;

                    if (_NumberType == NumberTypes.Percent)
                        this.Text = txt + "%";
                    else
                        this.Text = txt;
                    
                    int iCurrentLength = this.Text.Length;
                    if (iNumberDigitDecimal <= 0)
                    {
                        if (iLengthed < iCurrentLength)
                        {
                            this.SelectionStart = iSelectionStartNoneDecimalDigit + iCurrentLength - iLengthed;
                        }
                        else if (iLengthed == iCurrentLength)
                        {
                            if (iSelectionLengthNone > 0)
                                this.SelectionStart = iSelectionStartNoneDecimalDigit + 1;
                            else
                                this.SelectionStart = iSelectionStartNoneDecimalDigit;
                        }
                        else
                            this.SelectionStart = iSelectionStartNoneDecimalDigit - iLengthed + iCurrentLength;
                    }
                    else
                    {
                        if (this.Text.Length - iSelected < iNumberDigitDecimal || iSelectionStarted > 0)
                        {
                            if (this.Text.LastIndexOf(ci.NumberFormat.NumberDecimalSeparator) + 1 == iSelectionStarted)
                            {
                                this.SelectionStart = iSelectionStarted - 1;
                            }
                            else
                                this.SelectionStart = iSelectionStarted;
                            iSelectionStarted = -1;
                            return;
                        }
                        if (txt.Length > iLength)
                        {
                            if (iSelectionLengthNone > 0)
                            {
                                if (iSelectionLengthNone >= this.Text.Length)
                                    this.SelectionStart = this.Text.LastIndexOf(ci.NumberFormat.NumberDecimalSeparator);
                                else
                                    this.SelectionStart = iSelectionLengthNone;
                            }
                            else
                            {
                                if (iSelectionStarted < 0 && this.Text.LastIndexOf(ci.NumberFormat.NumberDecimalSeparator) > this.SelectionStart)
                                    this.SelectionStart = iSelected + 1;
                                else
                                {
                                    iSelectionStarted = -1;
                                }
                            }
                        }
                        else if (txt.Length < iLength)
                            this.SelectionStart = iSelected - 1;
                        else
                        {
                            //MessageBox.Show("2");
                            if (iSelectionStarted > 0)
                            {
                                this.SelectionStart = iSelectionStarted - 1;
                                iSelectionStarted = -1;
                            }
                            else
                                this.SelectionStart = iSelectionStartTextChanged;//iSelected;
                        }
                    }
                }
                else if (_NumberType == NumberTypes.Currency)
                {
                    decimal dec = GetDecimal();
                    String txt = dec.ToString("C", ci);
                    if (this.Text.LastIndexOf(ci.NumberFormat.CurrencyDecimalSeparator) + 1 > this.SelectionStart && this.SelectionStart > 0)
                        iSelectionStartTextChanged = this.SelectionStart;
                    this.Text = txt;

                    int iCurrentLength = this.Text.Length;
                    if (iCurrencyDigitDecimal <= 0)
                    {
                        if (iLengthed < iCurrentLength)
                        {
                            this.SelectionStart = iSelectionStartNoneDecimalDigit + iCurrentLength - iLengthed;
                        }
                        else if (iLengthed == iCurrentLength)
                            this.SelectionStart = iSelectionStartNoneDecimalDigit;
                        else
                            this.SelectionStart = iSelectionStartNoneDecimalDigit - iLengthed + iCurrentLength;
                    }
                    else
                    {
                        if (this.Text.Length - iSelected < iCurrencyDigitDecimal || iSelectionStarted > 0)
                        {
                            if (this.Text.LastIndexOf(ci.NumberFormat.CurrencyDecimalSeparator) + 1 == iSelectionStarted)
                            {
                                this.SelectionStart = iSelectionStarted - 1;
                            }
                            else
                                this.SelectionStart = iSelectionStarted;
                            iSelectionStarted = -1;
                            return;
                        }


                        if (txt.Length > iLength)
                        {
                            if (iSelectionStarted < 0 && this.Text.LastIndexOf(ci.NumberFormat.CurrencyDecimalSeparator) > this.SelectionStart)
                                this.SelectionStart = iSelected + 1;
                            else
                            {
                                iSelectionStarted = -1;
                            }
                        }
                        else if (txt.Length < iLength)
                            this.SelectionStart = iSelected - 1;
                        else
                        {
                            if (iSelectionStarted > 0)
                            {
                                this.SelectionStart = iSelectionStarted - 1;
                                iSelectionStarted = -1;
                            }
                            else
                                this.SelectionStart = iSelectionStartTextChanged;//iSelected;
                        }
                    }
                }

                if (_NumberType == NumberTypes.Double || _NumberType == NumberTypes.Decimal || _NumberType == NumberTypes.Currency && iSelectionStarted < 0)
                {
                    int iCi = this.Text.Length - this.SelectionStart - 1;
                    if (iCi < ci.NumberFormat.NumberDecimalDigits)
                    {
                        this.SelectionStart++;
                    }
                }
                else if (_NumberType == NumberTypes.Percent)
                {
                    int iCi = this.Text.Length - this.SelectionStart - 2;
                    if (iCi < ci.NumberFormat.NumberDecimalDigits)
                    {
                        this.SelectionStart++;
                    }
                }
                if (this.SelectionStart < 0)
                    this.SelectionStart = 0;
                this.SelectionLength = 0;

                if (ValueChanged != null)
                    ValueChanged(this, e);

            }
            catch
            {
                //throw ex;
            }
        }
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (this.Text.Trim() == "")
                this.Text = _mdclDefaultValue.ToString();
            //if (_NumberType == NumberTypes.In64 || _NumberType == NumberTypes.Int16 || _NumberType == NumberTypes.Integer)
            //    this.Text = "";
            int iCurrencyDigitDecimal = ci.NumberFormat.CurrencyDecimalDigits;
            int iNumberDigitDecimal = ci.NumberFormat.NumberDecimalDigits;

            if (_NumberType == NumberTypes.Double || _NumberType == NumberTypes.Decimal)
            {
                if (iNumberDigitDecimal <= 0)
                    this.SelectionStart = this.Text.Length - ci.NumberFormat.NumberDecimalDigits;
                else
                    this.SelectionStart = this.Text.Length - ci.NumberFormat.NumberDecimalDigits - 1;
                this.SelectionLength = 0; 
            }
            else if (_NumberType== NumberTypes.Currency)
            {
                if (iCurrencyDigitDecimal <= 0)
                    this.SelectionStart = this.Text.Length - ci.NumberFormat.CurrencyDecimalDigits;
                else
                    this.SelectionStart = this.Text.Length - ci.NumberFormat.CurrencyDecimalDigits - 1;
                this.SelectionLength = 0;

            }
            else if (_NumberType == NumberTypes.Percent)
            {
                //if (this.GetDouble() == 0)
                //{
                    this.SelectionStart = this.Text.Length - ci.NumberFormat.NumberDecimalDigits - 2;
                    this.SelectionLength = 0;
                //}
                //else
                //{
                //    this.SelectionStart = this.Text.Length;
                //}
            }
            else
            {
                if (this.Text.Trim() == "0")
                {
                    this.SelectionStart = this.Text.Length + 1;
                }
                else
                {
                    this.SelectionStart = this.Text.Length;
                }
            }
            if (this.SelectionStart < 0)
                this.SelectionStart = 0;

            if (HasFocus != null)
                HasFocus(this, e);
            this.SelectAll();
        }
        protected override void OnLostFocus(EventArgs e)
        {
            if (this.Text.Trim() == "")
            {
                this.Text = _mdclDefaultValue.ToString();
            }
            else
            {
                if (_NumberType == NumberTypes.Currency)
                {
                    decimal dec = GetDecimal();
                    String txt = dec.ToString("C", ci);
                    this.Text = txt;
                }
                else if (_NumberType == NumberTypes.In64 || _NumberType == NumberTypes.Int16 || _NumberType == NumberTypes.Integer)
                {

                    Int64 dec = GetInt64();
                    String txt = dec.ToString("N0");
                    this.Text = txt;
                }
                else
                {
                    decimal dec = GetDecimal();
                    String txt = dec.ToString("N", ci);
                    this.Text = txt;
                }
            }
            base.OnLostFocus(e);
        }
        #endregion

        #region Auto menu
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
                    lst[i].ColumnValue = R[lst[i].ColumnName].ToString();

                _mAutoMenu.AddItem(new HVTT.UI.Window.Forms.HVTTAutoCompleteMenu.MulticolumnAutocompleteItem(lst, R[FilterColumnName].ToString(), false));
            }
            _mAutoMenu.SetAutocompleteMenu(this, _mAutoMenu);
        }

        private void _mAutoMenu_Selecting(object sender, SelectingEventArgs e)
        {
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
        #endregion

        #region Enum
        public enum NumberTypes
        {
            Int16,
            Integer,
            In64,
            Decimal,
            Double,
            Currency,
            Percent,
            HVTTNumber
        }
        
        #endregion

    }
}
