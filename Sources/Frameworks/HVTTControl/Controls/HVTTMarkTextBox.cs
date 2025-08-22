using System;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using HVTT.UI.Window.Forms.Rendering;
using System.Drawing;
using HVTT.UI.Window.Forms.TextMarkup;
using System.Reflection;
using System.Runtime.InteropServices;


namespace HVTT.UI.Window.Forms.Controls
{
    [ToolboxBitmap(typeof(HVTTMarkTextBox), "HVTTTextBox.ico"), ToolboxItem(true), Designer(typeof(Design.TextBoxXDesigner))]
    public class HVTTMarkTextBox : TextBox, INonClientControl
    {
        #region Private Variables
        private NonClientPaintHandler m_NCPainter = null;
        private string m_WatermarkText = "";
        private bool m_Focused = false;
        private Font m_WatermarkFont = null;
        private Color m_WatermarkColor = SystemColors.GrayText;
        private ElementStyle m_BorderStyle = null;
        private int m_LastFocusWindow;
        private string m_OriginalText;
        private bool m_IsTextBoxItem = false;
        private Color m_FocusHighlightColor = ColorScheme.GetColor(0xFFFF88);
        private bool m_FocusHighlightEnabled = false;
        private Color m_LastBackColor = Color.Empty;

        HVTTStyle2008 _HVTTStyle2008 = new HVTTStyle2008();
   
        #endregion

        #region Constructor
        public HVTTMarkTextBox()
        {
            m_BorderStyle = new ElementStyle();
            m_BorderStyle.StyleChanged += new EventHandler(BorderStyle_StyleChanged);
            m_NCPainter = new NonClientPaintHandler(this, eScrollBarSkin.Optimized);
            base.BorderStyle = BorderStyle.None;
            this.AutoSize = false;
        }

        internal HVTTMarkTextBox(bool isTextBoxItem)
        {
            m_IsTextBoxItem = isTextBoxItem;
            m_BorderStyle = new ElementStyle();
            m_BorderStyle.StyleChanged += new EventHandler(BorderStyle_StyleChanged);
            base.BorderStyle = BorderStyle.None;
            this.AutoSize = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (m_NCPainter != null)
            {
                m_NCPainter.Dispose();
                m_NCPainter = null;
            }
            if (m_BorderStyle != null) m_BorderStyle.StyleChanged -= new EventHandler(BorderStyle_StyleChanged);
            base.Dispose(disposing);
        }
        #endregion

        #region Property

     
        //private GradientStyles _GradientStyle;
        //private SmoothingQualities _SmoothingQuality;
        private TypeStyles _TypeStyle;

        private Color _mcrBorderColor = Color.Black;
        //private Color _mcrBackColor1;
        //private Color _mcrBackColor2;

        private Boolean _mbRequire = false;
        private Boolean _mbAllowEdit = true;
        private Object _mobjValue = null;
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

        #endregion

        #region Private Method
        private void SetControlStyle()
        {
            if (!_mbAllowEdit && !_mbRequire)
            {
                base.BackColor = _HVTTStyle2008.AllowEditBackColor;
                _mcrBorderColor = _HVTTStyle2008.AllowEditBorderColor;
                return;
            }
            else if (!_mbAllowEdit && _mbRequire)
            {
                base.BackColor = _HVTTStyle2008.AllowEditBackColor;
                _mcrBorderColor = _HVTTStyle2008.AllowEditBorderColor;
                //SetValueRequire();
                return;
            }
            else if (_mbAllowEdit && _mbRequire)
            {
                base.BackColor = _HVTTStyle2008.RequireBackColor;
                _mcrBorderColor = _HVTTStyle2008.RequireBorderColor;
                return;
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

        #region Windows Messages Handling

        private static int WM_NCPAINT = 0x0085;
        private static int WM_ERASEBKGND = 0x0014;
        private static int WM_PAINT = 0x000F;

        [DllImport("user32.dll")]
        static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);

        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);

        private bool m_IgnoreFocus = false;
        protected override void WndProc(ref Message m)
        {
            SetControlStyle();
            if (m_NCPainter != null)
            {
                bool callBase = m_NCPainter.WndProc(ref m);

                if (callBase)
                    base.WndProc(ref m);
            }
            else
            {
                base.WndProc(ref m);
            }

            switch (m.Msg)
            {
                case (int)WinApi.WindowsMessages.WM_SETFOCUS:
                    {
                        if (m_IgnoreFocus)
                        {
                            m_IgnoreFocus = false;
                        }
                        else
                        {
                            m_Focused = true;
                            m_LastFocusWindow = m.WParam.ToInt32();
                            m_OriginalText = this.Text;
                            if (this.FocusHighlightEnabled)
                            {
                                m_LastBackColor = this.BackColor;
                                this.BackColor = this.FocusHighlightColor;
                                this.InvalidateNonClient();
                            }
                        }
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_KILLFOCUS:
                    {
                        if (!m_Focused)
                        {
                            m_IgnoreFocus = true;
                        }
                        else
                        {
                            m_Focused = false;
                            if (this.Text.Length == 0)
                                this.Invalidate();
                            if (this.FocusHighlightEnabled && !m_LastBackColor.IsEmpty)
                            {
                                this.BackColor = m_LastBackColor;
                                this.InvalidateNonClient();
                            }
                        }
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_PAINT:
                    {
                        if (!m_Focused && this.Enabled && this.Text != null && this.Text.Length == 0 && m_WatermarkText.Length > 0)
                            DrawWatermark();
                        if (this.Parent is ItemControl)
                            ((ItemControl)this.Parent).UpdateKeyTipsCanvas();
                        break;
                    }
            }
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
        }
        #endregion

        #region Internal Implementation
        public event EventHandler ValueChanged;



        /// <summary>
        /// Gets or sets whether FocusHighlightColor is used as background color to highlight text box when it has input focus. Default value is false.
        /// </summary>
        [DefaultValue(false), Browsable(true), Category("Appearance"), Description("Indicates whether FocusHighlightColor is used as background color to highlight text box when it has input focus.")]
        public bool FocusHighlightEnabled
        {
            get { return m_FocusHighlightEnabled; }
            set
            {
                if (m_FocusHighlightEnabled != value)
                {
                    m_FocusHighlightEnabled = value;
                    if (this.Focused)
                        this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color used as background color to highlight text box when it has input focus and focus highlight is enabled.
        /// </summary>
        [Browsable(true), Category("Appearance"), Description("Indicates color used as background color to highlight text box when it has input focus and focus highlight is enabled.")]
        public Color FocusHighlightColor
        {
            get { return m_FocusHighlightColor; }
            set
            {
                if (m_FocusHighlightColor != value)
                {
                    m_FocusHighlightColor = value;
                    if (this.Focused)
                        this.Invalidate();
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFocusHighlightColor()
        {
            return !m_FocusHighlightColor.Equals(ColorScheme.GetColor(0xFFFF88));
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public void ResetFocusHighlightColor()
        {
            FocusHighlightColor = ColorScheme.GetColor(0xFFFF88);
        }

        internal void ReleaseFocus()
        {
            if (this.Focused && m_LastFocusWindow != 0)
            {
                int focus = m_LastFocusWindow;
                m_LastFocusWindow = 0;
                Control ctrl = Control.FromChildHandle(new System.IntPtr(focus));
                if (ctrl != this)
                {
                    Control p = this.Parent;
                    while (p != null)
                    {
                        if (p == ctrl)
                        {
                            if (ctrl is MenuPanel)
                                ctrl.Focus();
                            return;
                        }
                        p = p.Parent;
                    }

                    if (ctrl != null)
                        ctrl.Focus();
                    else
                    {
                        NativeFunctions.SetFocus(focus);
                    }
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (m_IsTextBoxItem)
            {
                if (e.KeyCode == Keys.Enter)
                    ReleaseFocus();
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Text = m_OriginalText;
                    this.SelectionStart = 0;
                    ReleaseFocus();
                }
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            m_LastFocusWindow = 0;
            base.OnLostFocus(e);
        }

        /// <summary>
        /// Gets or sets the scrollbar skining type when control is using Office 2007 style.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public eScrollBarSkin ScrollbarSkin
        {
            get { return m_NCPainter.SkinScrollbars; }
            set { m_NCPainter.SkinScrollbars = value; }
        }

        /// <summary>
        /// Specifies the control border style. Default value has Class property set so the system style for the control is used.
        /// </summary>
        [Browsable(true), Category("Style"), Description("Specifies the control border style. Default value has Class property set so the system style for the control is used."), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ElementStyle Border
        {
            get { return m_BorderStyle; }
        }

        private void BorderStyle_StyleChanged(object sender, EventArgs e)
        {
            InvalidateNonClient();
        }

        /// <summary>
        /// Invalidates non-client area of the text box as response to the border changes.
        /// </summary>
        public void InvalidateNonClient()
        {
            if (!BarFunctions.IsHandleValid(this)) return;
            NativeFunctions.SetWindowPos(this.Handle, 0, 0, 0, 0, 0, NativeFunctions.SWP_FRAMECHANGED |
                                NativeFunctions.SWP_NOACTIVATE | NativeFunctions.SWP_NOMOVE | NativeFunctions.SWP_NOSIZE | NativeFunctions.SWP_NOZORDER);
            SetAutoHeight();
            const int RDW_INVALIDATE = 0x0001;
            const int RDW_FRAME = 0x0400;
            NativeFunctions.RECT r = new NativeFunctions.RECT(0, 0, this.Width, this.Height);
            NativeFunctions.RedrawWindow(this.Handle, ref r, IntPtr.Zero, RDW_INVALIDATE | RDW_FRAME);
        }

        private TextMarkup.BodyElement m_TextMarkup = null;
        private void MarkupTextChanged()
        {
            m_TextMarkup = null;

            if (!TextMarkup.MarkupParser.IsMarkup(ref m_WatermarkText))
                return;

            m_TextMarkup = TextMarkup.MarkupParser.Parse(m_WatermarkText);
            ResizeMarkup();
        }

        private void ResizeMarkup()
        {
            if (m_TextMarkup != null)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    MarkupDrawContext dc = GetMarkupDrawContext(g);
                    m_TextMarkup.Measure(GetWatermarkBounds().Size, dc);
                    Size sz = m_TextMarkup.Bounds.Size;
                    m_TextMarkup.Arrange(new Rectangle(GetWatermarkBounds().Location, sz), dc);
                }
            }
        }

        private Rectangle GetWatermarkBounds()
        {
            Rectangle r = this.ClientRectangle;
            r.Inflate(-1, 0);
            return r;
        }

        private void DrawWatermark()
        {
            using (Graphics g = this.CreateGraphics())
            {
                if (m_TextMarkup != null)
                {
                    MarkupDrawContext dc = GetMarkupDrawContext(g);
                    m_TextMarkup.Render(dc);
                }
                else
                {
                    eTextFormat tf = eTextFormat.Left;
                    if(this.Multiline)
                        tf |= eTextFormat.VerticalCenter;

                    if (this.RightToLeft == RightToLeft.Yes) tf |= eTextFormat.RightToLeft;
                    if (this.TextAlign == HorizontalAlignment.Left)
                        tf |= eTextFormat.Left;
                    else if (this.TextAlign == HorizontalAlignment.Right)
                        tf |= eTextFormat.Right;
                    else if (this.TextAlign == HorizontalAlignment.Center)
                        tf |= eTextFormat.HorizontalCenter;
                    tf |= eTextFormat.EndEllipsis;
                    tf |= eTextFormat.WordBreak;
                    TextDrawing.DrawString(g, m_WatermarkText, (m_WatermarkFont == null ? this.Font : m_WatermarkFont),
                        m_WatermarkColor, GetWatermarkBounds(), tf);
                }
            }
        }

        internal void SetAutoHeight()
        {
            if (!this.AutoSize && this.Multiline == false && this.BorderStyle == BorderStyle.None && !this.IsDisposed && this.Parent!=null)
            {
                int h = this.FontHeight;
                ElementStyle style = GetBorderStyle();
                if (style != null)
                {
                    if (style.PaintTopBorder)
                    {
                        if (style.CornerType == CornerType.Rounded || style.CornerType == CornerType.Diagonal)
                            h += Math.Max(style.BorderTopWidth, style.CornerDiameter / 2 + 1);
                        else
                            h += style.BorderTopWidth;
                    }

                    if (style.PaintBottomBorder)
                    {
                        if (style.CornerType == CornerType.Rounded || style.CornerType == CornerType.Diagonal)
                            h += Math.Max(style.BorderBottomWidth, style.CornerDiameter / 2 + 1);
                        else
                            h += style.BorderBottomWidth;
                    }
                    h += style.PaddingTop + style.PaddingBottom;
                }
                this.Height = h;
            }
        }

        //protected override void OnMultilineChanged(EventArgs e)
        //{
        //    SetAutoHeight();
        //    base.OnMultilineChanged(e);
        //}

        //protected override void OnHandleCreated(EventArgs e)
        //{
        //    SetAutoHeight();
        //    base.OnHandleCreated(e);
        //}

        //protected override void OnFontChanged(EventArgs e)
        //{
        //    SetAutoHeight();
        //    base.OnFontChanged(e);
        //}

        protected override void OnResize(EventArgs e)
        {
            //if(this.DesignMode)
            //    SetAutoHeight();
            ResizeMarkup();
            base.OnResize(e);
        }

        private MarkupDrawContext GetMarkupDrawContext(Graphics g)
        {
            return new MarkupDrawContext(g, (m_WatermarkFont == null ? this.Font : m_WatermarkFont), m_WatermarkColor, this.RightToLeft == RightToLeft.Yes);
        }

        protected override void OnTextAlignChanged(EventArgs e)
        {
            if(m_WatermarkText.Length>0)
                this.Invalidate();  
            base.OnTextAlignChanged(e);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (m_WatermarkText.Length > 0)
                this.Invalidate();
            base.OnEnabledChanged(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            _mobjValue = this.Text;
            
            if (ValueChanged != null)
                ValueChanged(this, e);
            if (m_WatermarkText.Length > 0 && !m_Focused)
                this.Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            String s = "";
            if (_TypeStyle == TypeStyles.OnlyNumber)
                s = "1234567890";
            else if (_TypeStyle == TypeStyles.OnlyWords)
                s = "qwertyuiopasdfghjklzxcvbnm ";
            else if (_TypeStyle == TypeStyles.WordAndNumber)
                s = "1234567890qwertyuiopasdfghjklzxcvbnm ";

            if (s.Trim() == "")
                return;
            if (!Search(s, e.KeyChar))
                e.Handled = true;

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Select();
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.SelectAll();
            base.OnMouseMove(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            //if (_mbRequire)
            //{
            //    if (this.Text.Trim() == "")
            //    {
            //        this.Select();
                    
            //        objMessage.FillData("00000006", _sCodeLanguage);
            //        HVTTMessages.Show(objMessage.MessageText, "", HVTTMessages.MessageTypes.Warning);
            //    }
            //}
            base.OnLeave(e);
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new BorderStyle BorderStyle
        {
            get {return base.BorderStyle;}
            set {}
        }

        private Rendering.BaseRenderer m_DefaultRenderer = null;
        private Rendering.BaseRenderer m_Renderer = null;
        private eRenderMode m_RenderMode = eRenderMode.Global;
        /// <summary>
        /// Returns the renderer control will be rendered with.
        /// </summary>
        /// <returns>The current renderer.</returns>
        public virtual Rendering.BaseRenderer GetRenderer()
        {
            if (m_RenderMode == eRenderMode.Global && Rendering.GlobalManager.Renderer != null)
                return Rendering.GlobalManager.Renderer;
            else if (m_RenderMode == eRenderMode.Custom && m_Renderer != null)
                return m_Renderer;

            if (m_DefaultRenderer == null)
                m_DefaultRenderer = new Rendering.Office2007Renderer();

            return m_DefaultRenderer;
        }

        /// <summary>
        /// Gets or sets the redering mode used by control. Default value is eRenderMode.Global which means that static GlobalManager.Renderer is used. If set to Custom then Renderer property must
        /// also be set to the custom renderer that will be used.
        /// </summary>
        [Browsable(false), DefaultValue(eRenderMode.Global)]
        public eRenderMode RenderMode
        {
            get { return m_RenderMode; }
            set
            {
                if (m_RenderMode != value)
                {
                    m_RenderMode = value;
                    this.Invalidate(true);
                }
            }
        }

        /// <summary>
        /// Gets or sets the custom renderer used by the items on this control. RenderMode property must also be set to eRenderMode.Custom in order renderer
        /// specified here to be used.
        /// </summary>
        [Browsable(false), DefaultValue(null)]
        public HVTT.UI.Window.Forms.Rendering.BaseRenderer Renderer
        {
            get
            {
                return m_Renderer;
            }
            set { m_Renderer = value; }
        }

        /// <summary>
        /// Gets or sets the watermark (tip) text displayed inside of the control when Text is not set and control does not have input focus. This property supports text-markup.
        /// </summary>
        [Browsable(true), DefaultValue(""), Localizable(true), Category("Appearance"), Description("Indicates watermark text displayed inside of the control when Text is not set and control does not have input focus."), Editor(typeof(Design.TextMarkupUIEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string WatermarkText
        {
            get { return m_WatermarkText; }
            set
            {
                if (value == null) value = "";
                m_WatermarkText = value;
                MarkupTextChanged();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the watermark font.
        /// </summary>
        [Browsable(true), Category("Appearance"), Description("Indicates watermark font."), DefaultValue(null)]
        public Font WatermarkFont
        {
            get { return m_WatermarkFont; }
            set { m_WatermarkFont = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the watermark text color.
        /// </summary>
        [Browsable(true), Category("Appearance"), Description("Indicates watermark text color.")]
        public Color WatermarkColor
        {
            get { return m_WatermarkColor; }
            set { m_WatermarkColor = value; this.Invalidate(); }
        }
        /// <summary>
        /// Indicates whether property should be serialized by Windows Forms designer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeWatermarkColor()
        {
            return m_WatermarkColor != SystemColors.GrayText;
        }
        /// <summary>
        /// Resets the property to default value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResetWatermarkColor()
        {
            this.WatermarkColor = SystemColors.GrayText;
        }

        private ElementStyle GetBorderStyle()
        {
            m_BorderStyle.SetColorScheme(this.GetColorScheme());
            return ElementStyleDisplay.GetElementStyle(m_BorderStyle);
        }
        #endregion

        #region INonClientControl Members
        void INonClientControl.BaseWndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        //CreateParams INonClientControl.ControlCreateParams
        //{
        //    get { return base.CreateParams; }
        //}

        ItemPaintArgs INonClientControl.GetItemPaintArgs(System.Drawing.Graphics g)
        {
            ItemPaintArgs pa = new ItemPaintArgs(this as IOwner, this, g, GetColorScheme());
            pa.Renderer = this.GetRenderer();
            pa.DesignerSelection = false; // m_DesignerSelection;
            pa.GlassEnabled = !this.DesignMode && WinApi.IsGlassEnabled;
            return pa;
        }

        ElementStyle INonClientControl.BorderStyle
        {
            get { return GetBorderStyle(); }
        }

        void INonClientControl.PaintBackground(PaintEventArgs e)
        {
            if (this.Parent == null) return;
            Type t = typeof(Control);
            MethodInfo mi = t.GetMethod("PaintTransparentBackground", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(PaintEventArgs), typeof(Rectangle) }, null);
            if (mi != null)
            {
                mi.Invoke(this, new object[] {e, new Rectangle(0,0,this.Width, this.Height)});
            }
        }

        private ColorScheme m_ColorScheme = null;
        /// <summary>
        /// Returns the color scheme used by control. Color scheme for Office2007 style will be retrived from the current renderer instead of
        /// local color scheme referenced by ColorScheme property.
        /// </summary>
        /// <returns>An instance of ColorScheme object.</returns>
        protected virtual ColorScheme GetColorScheme()
        {
            BaseRenderer r = GetRenderer();
            if (r is Office2007Renderer)
                return ((Office2007Renderer)r).ColorTable.LegacyColors;
            if (m_ColorScheme == null)
                m_ColorScheme = new ColorScheme(HVTTControlStyle.Office2007);
            return m_ColorScheme;
        }

        IntPtr INonClientControl.Handle
        {
            get { return this.Handle; }
        }

        int INonClientControl.Width
        {
            get { return this.Width; }
        }

        int INonClientControl.Height
        {
            get { return this.Height; }
        }

        bool INonClientControl.IsHandleCreated
        {
            get { return this.IsHandleCreated; }
        }

        Point INonClientControl.PointToScreen(Point client)
        {
            return this.PointToScreen(client);
        }

        Color INonClientControl.BackColor
        {
            get { return this.BackColor; }
        }

        void INonClientControl.AdjustClientRectangle(ref Rectangle r) { }
        
        void INonClientControl.AdjustBorderRectangle(ref Rectangle r) { }
        #endregion

        #region Enum

        public enum TypeStyles
        {
            Normal,
            Anny,
            OnlyNumber,
            OnlyWords,
            WordAndNumber
        }

        #endregion
    }
}
