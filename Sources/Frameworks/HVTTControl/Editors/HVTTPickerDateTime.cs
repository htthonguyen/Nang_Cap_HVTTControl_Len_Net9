using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace HVTT.UI.Window.Forms.Editors
{
    [DefaultEvent("ValueChanged")]
    public partial class HVTTPickerDateTime : UserControl
    {
         #region Designer

        public HVTTPickerDateTime()
        {
            InitializeComponent();
            base.Size = new Size(100, 20);
            base.Font = new Font("Microsoft Sans Serif", 9);
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer |
                ControlStyles.Selectable |
                ControlStyles.UserMouse,
                true
                );
            SetValueDefault();
            tb.BorderColor = this.BackColor;
        }

        #endregion

        #region Avalible

        HVTTStyle2008 _HVTTStyle2008 = new HVTTStyle2008();
        Color _RecentBackColor = Color.Empty;
        Color _RecentBorderColor = Color.Empty;

        int iPopup = 0;
        Boolean bFlag = false;
        #endregion

        #region Property

        //private GradientStyles _GradientStyle;
        //private SmoothingQualities _SmoothingQuality;

        private Color _mcrBorderColor;
        //private Color _mcrBackColor1;
        //private Color _mcrBackColor2;

        private Boolean _mbRequire = false;
        private Boolean _mbAllowEdit = true;
        private DateTime _mobjValue = DateTime.Now;
        private String _sCodeLanguage = "";

        private FormatStyles _mFormatStyle = FormatStyles.ShortDate;
        private Char _mchCharacterOnDate = '/';
        private Char _mchCharacterOnTime = ':';
        private Boolean _mbAllowNull = false;
        private DateStyles _mDateStyle = DateStyles.DDMMYYYY;
        private Boolean _mbIsChange = false;

        Color _mcHoverColor1 = Color.FromArgb(251, 230, 148);
        Color _mcHoverColor2 = Color.FromArgb(238, 149, 21);
        Color _mcForColorActive = Color.Black;
        Color _mcForColor = Color.Silver;

        Color _mcDefaultSelectBackDay = Color.White;
        Color _mcDefaultSelectBorderDay = Color.Transparent;
        Color _mcSelectBackDay = Color.FromArgb(192, 255, 192);
        Color _mcSelectBorderDay = Color.Transparent;

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
        [Browsable(false)]
        public String CodeLanguage
        {
            get
            {
                return _sCodeLanguage;

            }
            set
            {
                _sCodeLanguage = value;
            }
        }
        [Browsable(false)]
        public Boolean IsChange
        {
            get
            {
                return tb.IsChange;

            }
            set
            {
                _mbIsChange = value;
                tb.IsChange = value;
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
                return tb.Text;
            }
            set
            {
                base.Text = value;
                tb.Text = value;
                Invalidate();
            }
        }

        [Description("Get or set Value Of HVTTTextBox"), Category("HVTTTextBox")]
        public DateTime Value
        {
            get
            {
                return _mobjValue;
            }
            set
            {
                _mobjValue = value;
                if (_mobjValue != null)
                {
                    FillDate(_mobjValue.Day, _mobjValue.Month, _mobjValue.Year);
                }
                else
                    FillDate(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
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
                this.tb.ReadOnly = !_mbAllowEdit;
                this.pt.Enabled = _mbAllowEdit;

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

        [Browsable(false)]
        public int SelectionStart
        {
            get
            {
                return tb.SelectionStart;
            }
            set
            {
                tb.SelectionStart = value;
            }
        }
        [Browsable(false)]
        public int SelectionLength
        {
            get
            {
                return tb.SelectionLength;
            }
            set
            {
                tb.SelectionLength = value;
            }
        }
        [Browsable(false)]
        public String SelectedText
        {
            get
            {
                return tb.SelectedText;
            }
            set
            {
                tb.SelectedText = value;
            }
        }

        public DateStyles DateStyle
        {
            get
            {
                return _mDateStyle;
            }
            set
            {
                _mDateStyle = value;
                if (_mobjValue != null)
                {
                    FillDate(_mobjValue.Day, _mobjValue.Month, _mobjValue.Year);
                }
                else
                    FillDate(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            }
        }
        public Boolean AllowNull
        {
            get
            {
                return _mbAllowNull;
            }
            set
            {
                _mbAllowNull = value;
                if (_mbAllowNull == false)
                {
                    if (_mobjValue != null)
                    {
                        FillDate(_mobjValue.Day, _mobjValue.Month, _mobjValue.Year);
                    }
                    else
                        FillDate(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
                }
            }
        }
        public Char CharacterOnDate
        {
            get
            {
                return _mchCharacterOnDate;
            }
            set
            {
                _mchCharacterOnDate = value;
                if (_mchCharacterOnDate == null)
                    _mchCharacterOnDate = '/';
                if (_mobjValue != null)
                {
                    FillDate(_mobjValue.Day, _mobjValue.Month, _mobjValue.Year);
                }
                else
                    FillDate(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            }
        }
        public Char CharacterOnTime
        {
            get
            {
                return _mchCharacterOnTime;
            }
            set
            {
                _mchCharacterOnTime = value;
                if (_mchCharacterOnTime == null)
                    _mchCharacterOnTime = ':';
                if (_mobjValue != null)
                {
                    FillDate(_mobjValue.Day, _mobjValue.Month, _mobjValue.Year);
                }
                else
                    FillDate(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            }
        }

        public FormatStyles FormatStyle
        {
            get
            {
                return _mFormatStyle;
            }
            set
            {
                _mFormatStyle = value;
                if (_mobjValue != null)
                {
                    FillDate(_mobjValue.Day, _mobjValue.Month, _mobjValue.Year);
                }
                else
                    FillDate(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            }
        }
        public Color HoverColor1
        {
            get
            {
                return _mcHoverColor1;
            }
            set
            {
                _mcHoverColor1 = value;
            }
        }
        public Color ForeColorActive
        {
            get
            {
                return _mcForColorActive;
            }
            set
            {
                _mcForColorActive = value;
            }
        }

        public Color HoverColor2
        {
            get
            {
                return _mcHoverColor2;
            }
            set
            {
                _mcHoverColor2 = value;
            }
        }
        public Color SelectBackColor
        {
            get
            {
                return _mcSelectBackDay;
            }
            set
            {
                _mcSelectBackDay = value;
            }
        }
        public Color SelectBorderColor
        {
            get
            {
                return _mcSelectBorderDay;
            }
            set
            {
                _mcSelectBorderDay = value;
            }
        }
        public Color SelectDefaultBackColor
        {
            get
            {
                return _mcDefaultSelectBackDay;
            }
            set
            {
                _mcDefaultSelectBackDay = value;
            }
        }
        public Color SelectDefaultBorderColor
        {
            get
            {
                return _mcDefaultSelectBorderDay;
            }
            set
            {
                _mcDefaultSelectBorderDay = value;
            }
        }
        public Color DateColor
        {
            get
            {
                return tb.BackColor;
            }
            set
            {
                tb.BackColor = value;
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


            //if (iPopup > 0)
            //{
            if (m.Msg == WM_NCPAINT || m.Msg == WM_ERASEBKGND || m.Msg == WM_PAINT)
            {
                IntPtr hdc = GetDCEx(m.HWnd, (IntPtr)1, 1 | 0x0020);

                if (hdc != IntPtr.Zero)
                {
                    Graphics g = Graphics.FromHdc(hdc);
                    Rectangle rect = new Rectangle(0, 0, tb.Width + pt.Width + 1, 23);//this.Width, this.Height);
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
            //}
        }

        #endregion

        #region Private Method
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
        private void GetFotmat_DDMMYYYY(String Day,String Month,String Year,out int iDay, out int iMonth, out int iYear)
        {
            if (!int.TryParse(Day, out iDay) || iDay<=0)
            {
                iDay = DateTime.Now.Day;
            }
            if (!int.TryParse(Month, out iMonth) || iMonth<=0)
            {
                iMonth = DateTime.Now.Month;
            }
            
            if (!int.TryParse(Year, out iYear) || iYear<=1000)
            {
                iYear = DateTime.Now.Year;
            }
        }        
        private void FillDateTime_DDMMYYYY()
        {
            String[] M = tb.Text.Split(new String[] { "/" }, StringSplitOptions.None);

            int iDay = 0;
            int iMonth = 0;
            int iYear = 0;
            if (M[2].Length < 4)
            {
                int i = M[2].Length;
                while (i < 4)
                {
                    M[2] = M[2] + "0";
                    i++;
                }
            }
            GetFotmat_DDMMYYYY(M[0], M[1], M[2], out iDay, out iMonth, out iYear);
            if (iMonth > 12)
            {
                M[2] = M[1][1].ToString() + M[2];
                M[1] = M[1][0].ToString();
                if (M[2].Length > 4)
                    M[2] = M[2].Substring(0, 4);
            }
            else
            {
                int iDayInMonth = DateTime.DaysInMonth(iYear, iMonth);
                if (iDay > iDayInMonth)
                {
                    M[1] = M[0][1].ToString() + M[1];
                    M[0] = M[0][0].ToString();
                    GetFotmat_DDMMYYYY(M[0], M[1], M[2], out iDay, out iMonth, out iYear);
                    if (iMonth > 12)
                    {
                        M[2] = M[1][1].ToString() + M[2];
                        M[1] = M[1][0].ToString();
                        if (M[2].Length > 4)
                            M[2] = M[2].Substring(0, 4);
                        GetFotmat_DDMMYYYY(M[0], M[1], M[2], out iDay, out iMonth, out iYear);
                    }
                }
                dateTimePicker1.Value = new DateTime(iYear, iMonth, iDay);
            }
        }
        private DateTime FormatDateTime()
        {
            try
            {
                DateTime dtm = new DateTime();
                int iYear = 1;
                int iMonth = 1;
                int iDay = 1;
                int iHour = 0;
                int iMunite = 0;
                int iSecond = 0;
                String[] M = null;
                switch (_mFormatStyle)
                {
                    case FormatStyles.Time:
                        M = tb.Text.Split(new Char[] { _mchCharacterOnTime }, StringSplitOptions.None);
                        if (M.Length > 2)
                        {
                            if (!int.TryParse(M[0], out iHour))
                                iHour = 1;
                            if (!int.TryParse(M[1], out iMunite))
                                iMunite = 1;
                            if (!int.TryParse(M[2], out iSecond))
                                iSecond = 1;
                        }
                        dtm = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,iHour,iMunite,iSecond);
                        break;
                    case FormatStyles.ShortDate:
                        switch (_mDateStyle)
                        {
                            case DateStyles.DDMMYY:
                                M = tb.Text.Split(new Char[] { _mchCharacterOnDate }, StringSplitOptions.None);
                                if (M.Length > 2)
                                {
                                    if (!int.TryParse(M[0], out iDay))
                                        iDay = 1;
                                    if (!int.TryParse(M[1], out iMonth))
                                        iMonth = 1;
                                    if (!int.TryParse(M[2], out iYear))
                                        iYear = 1;
                                }
                                if (iYear > 1)
                                    dtm = new DateTime(iYear, iMonth, iDay);
                                else
                                    throw new ExecutionEngineException("Date value invalid !");
                                break;
                            case DateStyles.DDMMYYYY:
                                M = tb.Text.Split(new Char[] { _mchCharacterOnDate }, StringSplitOptions.None);
                                if (M.Length > 2)
                                {
                                    if (!int.TryParse(M[0], out iDay))
                                        iDay = 1;
                                    if (!int.TryParse(M[1], out iMonth))
                                        iMonth = 1;
                                    if (!int.TryParse(M[2], out iYear))
                                        iYear = 1;
                                }
                                if (iYear > 1)
                                    dtm = new DateTime(iYear, iMonth, iDay);
                                else
                                    throw new ExecutionEngineException("Date value invalid !");
                                break;
                            case DateStyles.MMDDYY:
                                M = tb.Text.Split(new Char[] { _mchCharacterOnDate }, StringSplitOptions.None);
                                if (M.Length > 2)
                                {
                                    if (!int.TryParse(M[0], out iMonth))
                                        iMonth = 1;
                                    if (!int.TryParse(M[1], out iDay))
                                        iDay = 1;
                                    if (!int.TryParse(M[2], out iYear))
                                        iYear = 1;
                                }
                                if (iYear > 1)
                                    dtm = new DateTime(iYear, iMonth, iDay);
                                else
                                    throw new ExecutionEngineException("Date value invalid !");
                                break;
                            case DateStyles.MMDDYYYY:
                                M = tb.Text.Split(new Char[] { _mchCharacterOnDate }, StringSplitOptions.None);
                                if (M.Length > 2)
                                {
                                    if (!int.TryParse(M[0], out iMonth))
                                        iMonth = 1;
                                    if (!int.TryParse(M[1], out iDay))
                                        iDay = 1;
                                    if (!int.TryParse(M[2], out iYear))
                                        iYear = 1;
                                }
                                if (iYear > 1)
                                    dtm = new DateTime(iYear, iMonth, iDay);
                                else
                                    throw new ExecutionEngineException("Date value invalid !");
                                break;
                            case DateStyles.YYMMDD:
                                M = tb.Text.Split(new Char[] { _mchCharacterOnDate }, StringSplitOptions.None);
                                if (M.Length > 2)
                                {
                                    if (!int.TryParse(M[0], out iYear))
                                        iYear = 1;
                                    if (!int.TryParse(M[1], out iMonth))
                                        iMonth = 1;
                                    if (!int.TryParse(M[2], out iDay))
                                        iDay = 1;
                                }
                                if (iYear > 1)
                                    dtm = new DateTime(iYear, iMonth, iDay);
                                else
                                    throw new ExecutionEngineException("Date value invalid !");
                                break;
                            case DateStyles.YYYYMMDD:
                                M = tb.Text.Split(new Char[] { _mchCharacterOnDate }, StringSplitOptions.None);
                                if (M.Length > 2)
                                {
                                    if (!int.TryParse(M[0], out iYear))
                                        iYear = 1;
                                    if (!int.TryParse(M[1], out iMonth))
                                        iMonth = 1;
                                    if (!int.TryParse(M[2], out iDay))
                                        iDay = 1;
                                }
                                if (iYear > 1)
                                    dtm = new DateTime(iYear, iMonth, iDay);
                                else
                                    throw new ExecutionEngineException("Date value invalid !");
                                break;
                        }
                        break;
                    case FormatStyles.ShortDateTime:
                        String[] MDateTime = tb.Text.Split(new String[] { " " }, StringSplitOptions.None);
                        String[] MTime = null;
                        if(MDateTime.Length<1)
                            throw new ExecutionEngineException("Date value invalid !");

                        M = MDateTime[0].Split(new Char[] { _mchCharacterOnDate }, StringSplitOptions.None);
                        MTime = MDateTime[1].Split(new Char[] { _mchCharacterOnTime }, StringSplitOptions.None);
                        
                        switch (_mDateStyle)
                        {
                            case DateStyles.DDMMYY:
                                if (M.Length > 2)
                                {
                                    if (!int.TryParse(M[0], out iDay))
                                        iDay = 1;
                                    if (!int.TryParse(M[1], out iMonth))
                                        iMonth = 1;
                                    if (!int.TryParse(M[2], out iYear))
                                        iYear = 1;
                                }
                                if (MTime != null && MTime.Length > 2)
                                {
                                    if (!int.TryParse(MTime[0], out iHour))
                                        iHour = 1;
                                    if (!int.TryParse(MTime[1], out iMunite))
                                        iMunite = 1;
                                    if (!int.TryParse(MTime[2], out iSecond))
                                        iSecond = 1;
                                }

                                if (iYear > 1)
                                    dtm = new DateTime(iYear, iMonth, iDay,iHour,iMunite,iSecond);
                                else
                                    throw new ExecutionEngineException("Date value invalid !");
                                break;
                            case DateStyles.DDMMYYYY:
                                if (M.Length > 2)
                                {
                                    if (!int.TryParse(M[0], out iDay))
                                        iDay = 1;
                                    if (!int.TryParse(M[1], out iMonth))
                                        iMonth = 1;
                                    if (!int.TryParse(M[2], out iYear))
                                        iYear = 1;
                                }
                                if (MTime != null && MTime.Length > 2)
                                {
                                    if (!int.TryParse(MTime[0], out iHour))
                                        iHour = 1;
                                    if (!int.TryParse(MTime[1], out iMunite))
                                        iMunite = 1;
                                    if (!int.TryParse(MTime[2], out iSecond))
                                        iSecond = 1;
                                }
                                if (iYear > 1)
                                    dtm = new DateTime(iYear, iMonth, iDay, iHour, iMunite, iSecond);
                                else
                                    throw new ExecutionEngineException("Date value invalid !");
                                break;
                            case DateStyles.MMDDYY:
                                if (M.Length > 2)
                                {
                                    if (!int.TryParse(M[0], out iMonth))
                                        iMonth = 1;
                                    if (!int.TryParse(M[1], out iDay))
                                        iDay = 1;
                                    if (!int.TryParse(M[2], out iYear))
                                        iYear = 1;
                                }
                                if (MTime != null && MTime.Length > 2)
                                {
                                    if (!int.TryParse(MTime[0], out iHour))
                                        iHour = 1;
                                    if (!int.TryParse(MTime[1], out iMunite))
                                        iMunite = 1;
                                    if (!int.TryParse(MTime[2], out iSecond))
                                        iSecond = 1;
                                }
                                if (iYear > 1)
                                    dtm = new DateTime(iYear, iMonth, iDay, iHour, iMunite, iSecond);
                                else
                                    throw new ExecutionEngineException("Date value invalid !");
                                break;
                            case DateStyles.MMDDYYYY:
                                if (M.Length > 2)
                                {
                                    if (!int.TryParse(M[0], out iMonth))
                                        iMonth = 1;
                                    if (!int.TryParse(M[1], out iDay))
                                        iDay = 1;
                                    if (!int.TryParse(M[2], out iYear))
                                        iYear = 1;
                                }
                                if (MTime != null && MTime.Length > 2)
                                {
                                    if (!int.TryParse(MTime[0], out iHour))
                                        iHour = 1;
                                    if (!int.TryParse(MTime[1], out iMunite))
                                        iMunite = 1;
                                    if (!int.TryParse(MTime[2], out iSecond))
                                        iSecond = 1;
                                }
                                if (iYear > 1)
                                    dtm = new DateTime(iYear, iMonth, iDay, iHour, iMunite, iSecond);
                                else
                                    throw new ExecutionEngineException("Date value invalid !");
                                break;
                            case DateStyles.YYMMDD:
                                if (M.Length > 2)
                                {
                                    if (!int.TryParse(M[0], out iYear))
                                        iYear = 1;
                                    if (!int.TryParse(M[1], out iMonth))
                                        iMonth = 1;
                                    if (!int.TryParse(M[2], out iDay))
                                        iDay = 1;
                                }
                                if (MTime != null && MTime.Length > 2)
                                {
                                    if (!int.TryParse(MTime[0], out iHour))
                                        iHour = 1;
                                    if (!int.TryParse(MTime[1], out iMunite))
                                        iMunite = 1;
                                    if (!int.TryParse(MTime[2], out iSecond))
                                        iSecond = 1;
                                }
                                if (iYear > 1)
                                    dtm = new DateTime(iYear, iMonth, iDay, iHour, iMunite, iSecond);
                                else
                                    throw new ExecutionEngineException("Date value invalid !");
                                break;
                            case DateStyles.YYYYMMDD:
                                if (M.Length > 2)
                                {
                                    if (!int.TryParse(M[0], out iYear))
                                        iYear = 1;
                                    if (!int.TryParse(M[1], out iMonth))
                                        iMonth = 1;
                                    if (!int.TryParse(M[2], out iDay))
                                        iDay = 1;
                                }
                                if (MTime != null && MTime.Length > 2)
                                {
                                    if (!int.TryParse(MTime[0], out iHour))
                                        iHour = 1;
                                    if (!int.TryParse(MTime[1], out iMunite))
                                        iMunite = 1;
                                    if (!int.TryParse(MTime[2], out iSecond))
                                        iSecond = 1;
                                }
                                if (iYear > 1)
                                    dtm = new DateTime(iYear, iMonth, iDay, iHour, iMunite, iSecond);
                                else
                                    throw new ExecutionEngineException("Date value invalid !");
                                break;
                        }
                        break;
                }
                
                return dtm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetValueDefault()
        {


            _mcrBorderColor = Color.Black;
            _mobjValue = DateTime.Now;
            if (_mobjValue != null)
            {
                FillDate(_mobjValue.Day, _mobjValue.Month, _mobjValue.Year);
            }
            else
                FillDate(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

            this.Size = new Size(199, 23);
            iPopup = 0;
        }
        private void SetControlStyle()
        {
           
            if (!_mbAllowEdit && !_mbRequire)
            {
                base.BackColor = _HVTTStyle2008.AllowEditBackColor;
                //_mcrBorderColor = _HVTTStyle2008.AllowEditBorderColor;
            }
            else if (!_mbAllowEdit && _mbRequire)
            {
                base.BackColor = _HVTTStyle2008.AllowEditBackColor;
                //_mcrBorderColor = _HVTTStyle2008.AllowEditBorderColor;
                //SetValueRequire();
            }
            else if (_mbAllowEdit && _mbRequire)
            {
                base.BackColor = _HVTTStyle2008.RequireBackColor;
                //_mcrBorderColor = _HVTTStyle2008.RequireBorderColor;
            }
            else if (_mbAllowEdit && !_mbRequire)
            {
                base.BackColor = SystemColors.Window;
                //_mcrBorderColor = Color.Black;
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

        private String GetMonth(int iMonth)
        {
            switch (iMonth)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "Augus";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";

            }
            return "";
        }
        private String GetFormatMonth(int iMonth)
        {
            String sRS = "";
            String s = GetMonth(iMonth);
            for (int i = 0; i < s.Length; i++)
                sRS = sRS + "C";
            return sRS;
        }
        private void FillDate(int iDay, int iMonth, int iYear)
        {
            switch (_mFormatStyle)
            {
                case FormatStyles.ShortDate:
                    switch (_mDateStyle)
                    {
                        case DateStyles.YYYYMMDD:
                            tb.Mask = "0000" + _mchCharacterOnDate + "00" + _mchCharacterOnDate + "00";
                            tb.Text = iYear.ToString() + _mchCharacterOnDate + iMonth.ToString("00") + _mchCharacterOnDate + iDay.ToString("00");
                            break;
                        case DateStyles.YYMMDD:
                            tb.Mask = "00" + _mchCharacterOnDate + "00" + _mchCharacterOnDate + "00";
                            tb.Text = iYear.ToString().Substring(2, 2) + _mchCharacterOnDate + iMonth.ToString("00") + _mchCharacterOnDate + iDay.ToString("00");
                            break;
                        case DateStyles.MMDDYYYY:
                            tb.Mask = "00" + _mchCharacterOnDate + "00" + _mchCharacterOnDate + "0000";
                            tb.Text = iMonth.ToString("00") + _mchCharacterOnDate + iDay.ToString("00") + _mchCharacterOnDate + iYear.ToString();
                            break;
                        case DateStyles.MMDDYY:
                            tb.Mask = "00" + _mchCharacterOnDate + "00" + _mchCharacterOnDate + "00";
                            tb.Text = iMonth.ToString("00") + _mchCharacterOnDate + iDay.ToString("00") + _mchCharacterOnDate + iYear.ToString().Substring(2, 2);
                            break;
                        case DateStyles.DDMMYYYY:
                            tb.Mask = "00" + _mchCharacterOnDate + "00" + _mchCharacterOnDate + "0000";
                            tb.Text = iDay.ToString("00") + _mchCharacterOnDate + iMonth.ToString("00") + _mchCharacterOnDate + iYear.ToString();
                            break;
                        case DateStyles.DDMMYY:
                            tb.Mask = "00" + _mchCharacterOnDate + "00" + _mchCharacterOnDate + "00";
                            tb.Text = iDay.ToString("00") + _mchCharacterOnDate + iMonth.ToString("00") + _mchCharacterOnDate + iYear.ToString().Substring(2, 2);
                            break;
                    }
                    break;

                case FormatStyles.ShortDateTime:
                    switch (_mDateStyle)
                    {
                        case DateStyles.YYYYMMDD:
                            tb.Mask = "0000" + _mchCharacterOnDate + "00" + _mchCharacterOnDate + "00 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime + "00";
                            tb.Text = iYear.ToString() + _mchCharacterOnDate + iMonth.ToString("00") + _mchCharacterOnDate + iDay.ToString("00") + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                            break;
                        case DateStyles.YYMMDD:
                            tb.Mask = "00" + _mchCharacterOnDate + "00" + _mchCharacterOnDate + "00 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime + "00";
                            tb.Text = iYear.ToString().Substring(2, 2) + _mchCharacterOnDate + iMonth.ToString("00") + _mchCharacterOnDate + iDay.ToString("00") + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                            break;
                        case DateStyles.MMDDYYYY:
                            tb.Mask = "00" + _mchCharacterOnDate + "00" + _mchCharacterOnDate + "0000 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime + "00";
                            tb.Text = iMonth.ToString("00") + _mchCharacterOnDate + iDay.ToString("00") + _mchCharacterOnDate + iYear.ToString() + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                            break;
                        case DateStyles.MMDDYY:
                            tb.Mask = "00" + _mchCharacterOnDate + "00" + _mchCharacterOnDate + "00 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime + "00";
                            tb.Text = iMonth.ToString("00") + _mchCharacterOnDate + iDay.ToString("00") + _mchCharacterOnDate + iYear.ToString().Substring(2, 2) + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                            break;
                        case DateStyles.DDMMYYYY:
                            tb.Mask = "00" + _mchCharacterOnDate + "00" + _mchCharacterOnDate + "0000 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime + "00";
                            tb.Text = iDay.ToString("00") + _mchCharacterOnDate + iMonth.ToString("00") + _mchCharacterOnDate + iYear.ToString() + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                            break;
                        case DateStyles.DDMMYY:
                            tb.Mask = "00" + _mchCharacterOnDate + "00" + _mchCharacterOnDate + "00 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime + "00";
                            tb.Text = iDay.ToString("00") + _mchCharacterOnDate + iMonth.ToString("00") + _mchCharacterOnDate + iYear.ToString().Substring(2, 2) + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                            break;
                    }
                    break;
                //case FormatStyles.LongDate:
                //    switch (_mDateStyle)
                //    {
                //        case DateStyles.YYYYMMDD:
                //            tb.Mask = "0000" + _mchCharacterOnDate.ToString() + GetFormatMonth(iMonth) + _mchCharacterOnDate.ToString() + "00 00" + _mchCharacterOnTime.ToString() + "00" + _mchCharacterOnTime.ToString() + "00";
                //            tb.Text = iYear.ToString() + _mchCharacterOnDate + GetMonth(iMonth) + _mchCharacterOnDate + iDay.ToString("00") + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                //            break;
                //        case DateStyles.YYMMDD:
                //            tb.Mask = "00" + _mchCharacterOnDate.ToString() + GetFormatMonth(iMonth) + _mchCharacterOnDate.ToString() + "00 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime + "00";
                //            tb.Text = iYear.ToString().Substring(2, 2) + _mchCharacterOnDate + GetMonth(iMonth) + _mchCharacterOnDate + iDay.ToString("00") + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                //            break;
                //        case DateStyles.MMDDYYYY:
                //            tb.Mask = GetFormatMonth(iMonth) + _mchCharacterOnDate + "00" + _mchCharacterOnDate + "0000 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime + "00";
                //            tb.Text = GetMonth(iMonth) + _mchCharacterOnDate + iDay.ToString("00") + _mchCharacterOnDate + iYear.ToString() + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                //            break;
                //        case DateStyles.MMDDYY:
                //            tb.Mask = GetFormatMonth(iMonth) + _mchCharacterOnDate + "00" + _mchCharacterOnDate + "00 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime + "00";
                //            tb.Text = GetMonth(iMonth) + _mchCharacterOnDate + iDay.ToString("00") + _mchCharacterOnDate + iYear.ToString().Substring(2, 2) + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                //            break;
                //        case DateStyles.DDMMYYYY:
                //            tb.Mask = "00" + _mchCharacterOnDate + GetFormatMonth(iMonth) + _mchCharacterOnDate + "0000 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime + "00";
                //            tb.Text = iDay.ToString("00") + _mchCharacterOnDate + GetMonth(iMonth) + _mchCharacterOnDate + iYear.ToString() + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                //            break;
                //        case DateStyles.DDMMYY:
                //            tb.Mask = "00" + _mchCharacterOnDate + GetFormatMonth(iMonth) + _mchCharacterOnDate + "00 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime + "00";
                //            tb.Text = iDay.ToString("00") + _mchCharacterOnDate + GetMonth(iMonth) + _mchCharacterOnDate + iYear.ToString().Substring(2, 2) + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                //            break;
                //    }
                //    break;
                //case FormatStyles.LongDateTime:
                //    switch (_mDateStyle)
                //    {
                //        case DateStyles.YYYYMMDD:
                //            tb.Mask = "0000" + _mchCharacterOnDate + GetFormatMonth(iMonth) + _mchCharacterOnDate + "00 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime.ToString() + "00";
                //            tb.Text = iYear.ToString() + _mchCharacterOnDate + GetMonth(iMonth) + _mchCharacterOnDate + iDay.ToString("00") + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                //            break;
                //        case DateStyles.YYMMDD:
                //            tb.Mask = "00" + _mchCharacterOnDate + GetFormatMonth(iMonth) + _mchCharacterOnDate + "00 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime.ToString() + "00";
                //            tb.Text = iYear.ToString().Substring(2, 2) + _mchCharacterOnDate + GetMonth(iMonth) + _mchCharacterOnDate + iDay.ToString("00") + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                //            break;
                //        case DateStyles.MMDDYYYY:
                //            tb.Mask = GetFormatMonth(iMonth) + _mchCharacterOnDate + "00" + _mchCharacterOnDate + "0000 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime.ToString() + "00";
                //            tb.Text = GetMonth(iMonth) + _mchCharacterOnDate + iDay.ToString("00") + _mchCharacterOnDate + iYear.ToString() + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                //            break;
                //        case DateStyles.MMDDYY:
                //            tb.Mask = GetFormatMonth(iMonth) + _mchCharacterOnDate + "00" + _mchCharacterOnDate + "00 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime + "00 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime.ToString() + "00";
                //            tb.Text = GetMonth(iMonth) + _mchCharacterOnDate + iDay.ToString("00") + _mchCharacterOnDate + iYear.ToString().Substring(2, 2) + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                //            break;
                //        case DateStyles.DDMMYYYY:
                //            tb.Mask = "00" + _mchCharacterOnDate + GetFormatMonth(iMonth) + _mchCharacterOnDate + "0000 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime.ToString() + "00";
                //            tb.Text = iDay.ToString("00") + _mchCharacterOnDate + GetMonth(iMonth) + _mchCharacterOnDate + iYear.ToString() + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                //            break;
                //        case DateStyles.DDMMYY:
                //            tb.Mask = "00" + _mchCharacterOnDate + GetFormatMonth(iMonth) + _mchCharacterOnDate + "00 00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime.ToString() + "00";
                //            tb.Text = iDay.ToString("00") + _mchCharacterOnDate + GetMonth(iMonth) + _mchCharacterOnDate + iYear.ToString().Substring(2, 2) + " " + DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                //            break;
                //    }
                //    break;
                case FormatStyles.Time:
                    tb.Mask = "00" + _mchCharacterOnTime + "00" + _mchCharacterOnTime + "00";
                    String[]M = tb.Text.Trim().Split(new String[] { ":" }, StringSplitOptions.None);
                    if (M != null && M.Length > 1)
                    {
                        int iHour = 12;
                        int iMunite = 0;
                        int iSecond = 0;
                        Int32.TryParse(M[0], out iHour);
                        Int32.TryParse(M[1], out iMunite);
                        Int32.TryParse(M[2], out iSecond);
                        tb.Text = iHour.ToString("00") + _mchCharacterOnTime + iMunite.ToString("00") + _mchCharacterOnTime + iSecond.ToString("00");
                       // _mobjValue = new DateTime(myFr.Value.Year, myFr.Value.Month, myFr.Value.Day, iHour, iMunite, iSecond);
                    }
                    else
                        tb.Text = DateTime.Now.Hour.ToString("00") + _mchCharacterOnTime + DateTime.Now.Minute.ToString("00") + _mchCharacterOnTime + DateTime.Now.Second.ToString("00");
                    break;
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
        #endregion

        #region Public Method
        public void SelectAll()
        {
            tb.SelectAll();
        }
        public DateTime GetDate()
        {
            try
            {
                return new DateTime(Value.Year, Value.Month, Value.Day);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Event

        public event EventHandler ValueChanged;
        public new event EventHandler TextChanged;

        private void pt_MouseMove(object sender, MouseEventArgs e)
        {
            pt.Image = Properties.Resources.Down4;
        }

        private void pt_MouseLeave(object sender, EventArgs e)
        {
            pt.Image = Properties.Resources.Down2;
        }

        private void pt_MouseDown(object sender, MouseEventArgs e)
        {
            pt.Image = Properties.Resources.Down7;
        }
        private void myFr_AfterShowdownEvent(object sender, DateTime date)
        {
            try
            {
                if (date != null)
                {
                    String[] M = null;
                    if (_mFormatStyle == FormatStyles.Time)
                    {
                        M = tb.Text.Trim().Split(new String[] { ":" }, StringSplitOptions.None);
                        if (M != null && M.Length > 1)
                        {
                            int iHour = 12;
                            int iMunite = 0;
                            int iSecond = 0;
                            Int32.TryParse(M[0], out iHour);
                            Int32.TryParse(M[1], out iMunite);
                            Int32.TryParse(M[2], out iSecond);
                            _mobjValue = new DateTime(date.Year, date.Month, date.Day, iHour, iMunite, iSecond);
                        }
                    }
                    else
                        _mobjValue = date;
                    FillDate(_mobjValue.Day, _mobjValue.Month, _mobjValue.Year);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(this, exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pt_Click(object sender, EventArgs e)
        {
            try
            {
                frPickerDateTime myFr = new frPickerDateTime();
                Form parent = this.FindForm();
                //Point pScreen = new Point();
                //foreach (Screen scr in Screen.AllScreens)
                //{
                //    pScreen.X += scr.Bounds.Width;
                //    pScreen.Y += scr.Bounds.Height;
                //}
                //Point Locationparent = GetParentLocation(this);
                //Point PopupLocation = new Point(parent.Left + Locationparent.X + this.Left + 4, parent.Top + Locationparent.Y + this.Bottom + this.Height + 2);
                //Point Rs = new Point();
                //if (PopupLocation.Y + myFr.Height + 8 > pScreen.Y)
                //{
                //    Rs.X = PopupLocation.X;
                //    Rs.Y = PopupLocation.Y - myFr.Height - this.Height + 4;
                //    //return Rs;
                //}
                //else
                //    Rs = PopupLocation;

                //Point DockButtom = Rs;

                myFr.Value = _mobjValue;
                myFr.SelectBackColor = _mcSelectBackDay;
                myFr.SelectBorderColor = _mcSelectBorderDay;
                myFr.SelectDefaultBackColor = _mcDefaultSelectBackDay;
                myFr.SelectDefaultBorderColor = _mcDefaultSelectBackDay;
                myFr.HoverColor1 = _mcHoverColor1;
                myFr.HoverColor2 = _mcHoverColor2;
                myFr.ResetDate = _mobjValue;
                myFr.Location = InnitLocation(GetLocation(parent), myFr);
                myFr.AfterShowdownEvent+=new AfterShowdownEventHandler(myFr_AfterShowdownEvent);
                myFr.Show(); 
                //if (myFr.ShowDialog() == DialogResult.OK)
                //{
                //    String[] M = null;
                //    if (_mFormatStyle == FormatStyles.Time)
                //        M = tb.Text.Trim().Split(new String[] { ":" }, StringSplitOptions.None);
                //    if (M != null && M.Length > 1)
                //    {
                //        int iHour = 12;
                //        int iMunite = 0;
                //        int iSecond = 0;
                //        Int32.TryParse(M[0], out iHour);
                //        Int32.TryParse(M[1], out iMunite);
                //        Int32.TryParse(M[2], out iSecond);
                //        _mobjValue = new DateTime(myFr.Value.Year, myFr.Value.Month, myFr.Value.Day, iHour, iMunite, iSecond);
                //    }
                //    else
                //        _mobjValue = myFr.Value;
                //    FillDate(_mobjValue.Day, _mobjValue.Month, _mobjValue.Year);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void HVTTPickerDateTime_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    Collapse();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        private void tb_Leave(object sender, EventArgs e)
        {
            try
            {
                tb.Text = dateTimePicker1.Value.ToString("dd/MM/yyyy");

                _mobjValue = FormatDateTime();
                if (!_mbAllowNull)
                {
                    if (_mobjValue == null)
                        _mobjValue = DateTime.Now;
                }
                FillDate(_mobjValue.Day, _mobjValue.Month, _mobjValue.Year);
                String[] M = null;
                if (_mFormatStyle == FormatStyles.Time)
                    M = tb.Text.Trim().Split(new String[] { ":" }, StringSplitOptions.None);
                if (M != null && M.Length > 1)
                {
                    int iHour = 12;
                    int iMunite = 0;
                    int iSecond = 0;
                    Int32.TryParse(M[0], out iHour);
                    Int32.TryParse(M[1], out iMunite);
                    Int32.TryParse(M[2], out iSecond);
                    _mobjValue = new DateTime(_mobjValue.Year, _mobjValue.Month, _mobjValue.Day, iHour, iMunite, iSecond);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void HVTTPickerDateTime_Resize(object sender, EventArgs e)
        {
            if (this.Height > 23)
                this.Height = 23;
        }
        private void tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FillDateTime_DDMMYYYY();
                if (TextChanged != null)
                    TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void tb_ValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(sender, e);
        }

        #endregion

        #region Enum
        public enum FormatStyles
        {
            ShortDate,
            ShortDateTime,
            //LongDate,
            //LongDateTime,
            Time
        }
        public enum DateStyles
        {
            DDMMYY,
            DDMMYYYY,
            MMDDYY,
            MMDDYYYY,
            YYMMDD,
            YYYYMMDD,
        }
        #endregion

       

    }
}
