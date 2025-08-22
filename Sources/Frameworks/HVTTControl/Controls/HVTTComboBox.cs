using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using HVTT.UI.Window.Forms;
using HVTT.UI.Window.Forms.Rendering;
using HVTT.UI.Window.Forms.Controls;
using HVTT.UI.Editors;
using HVTT.UI.Window.Forms.TextMarkup;

namespace HVTT.UI.Window.Forms.Controls
{
	/// <summary>
	/// Represents enhanced Windows combo box control.
	/// </summary>
    [ToolboxBitmap(typeof(HVTTComboBox), "Controls.ComboBoxEx.ico"), ToolboxItem(true), Designer(typeof(Design.HVTTComboBoxDesigner))]
	public class HVTTComboBox : System.Windows.Forms.ComboBox
	{

        /// <summary>
        /// Represents the method that will handle the DropDownChange event.
        /// </summary>
        public delegate void OnDropDownChangeEventHandler(object sender, bool Expanded);
		/// <summary>
		/// Occurs when drop down portion of combo box is shown or hidden.
		/// </summary>
		public event OnDropDownChangeEventHandler DropDownChange;

		private HVTTControlStyle m_Style=HVTTControlStyle.Office2007;
		private bool m_DefaultStyle=false;			// Disables our drawing in WndProc
		private bool m_MouseOver=false;
		private bool m_DroppedDown=false;
		//private System.Windows.Forms.Timer m_Timer;
		private bool m_WindowsXPAware=false;
		private bool m_DisableInternalDrawing=false;
		private ImageList m_ImageList=null;
		private int m_DropDownHeight=0;
		private IntPtr m_LastFocusWindow;
		private IntPtr m_DropDownHandle=IntPtr.Zero;
		private ComboTextBoxMsgHandler m_TextWindowMsgHandler=null;
        private String _msValue = "";
        private Hashtable _mValues = new Hashtable();
        private ArrayList _mlValue = new ArrayList();
        //private ComboListBoxMsgHandler m_ListBoxMsgHandler = null;
        private Boolean _mbIsChange = false;
        private String _sResentText = "";
       

        private Boolean _mblnRequire = false;
        private Boolean _mblnAllowEdit = true;

        public Boolean AllowEdit
        {
            get
            {
                return _mblnAllowEdit;
            }
            set
            {
                _mblnAllowEdit = value;
                this.Enabled = _mblnAllowEdit;
            }
        }

        public event EventHandler ValueChange;

		[DllImport("user32")]
		private static extern bool ValidateRect(IntPtr hWnd,ref NativeFunctions.RECT pRect);

		[DllImport("user32",SetLastError=true, CharSet=CharSet.Auto)]
		private static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
		private const uint GW_CHILD=5;

		private bool m_PreventEnterBeep=false;

        private string m_WatermarkText = "";
        private bool m_Focused = false;
        private Font m_WatermarkFont = null;
        private Color m_WatermarkColor = SystemColors.GrayText;
        private bool m_IsStandalone = true;
        private bool m_FirstPaintPass = true;
        private Timer m_MouseOverTimer = null;

		/// <summary>
		/// Creates new instance of ComboBoxEx.
		/// </summary>
		public HVTTComboBox():base()
		{
			if(!ColorFunctions.ColorsLoaded)
			{
				NativeFunctions.RefreshSettings();
				NativeFunctions.OnDisplayChange();
				ColorFunctions.LoadColors();
			}
            m_MouseOverTimer = new Timer();
            m_MouseOverTimer.Interval = 10;
            m_MouseOverTimer.Enabled = false;
            m_MouseOverTimer.Tick += new EventHandler(MouseOverTimerTick);

		}

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

       

        /// <summary>
        /// Gets or sets whether control is stand-alone control. Stand-alone flag affects the appearance of the control in Office 2007 style.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsStandalone
        {
            get { return m_IsStandalone; }
            set
            {
                m_IsStandalone = value;
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                _sResentText = value;
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
        /// <summary>
        /// Gets or sets the watermark (tip) text displayed inside of the control when Text is not set and control does not have input focus. This property supports text-markup.
        /// Note that WatermarkText is not compatible with the auto-complete feature of .NET Framework 2.0.
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
                this.Invalidate(true);
            }
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
        private MarkupDrawContext GetMarkupDrawContext(Graphics g)
        {
            return new MarkupDrawContext(g, (m_WatermarkFont == null ? this.Font : m_WatermarkFont), m_WatermarkColor, this.RightToLeft == RightToLeft.Yes);
        }

        public Boolean Require
        {
            get
            {
                return _mblnRequire;
            }
            set
            {
                _mblnRequire = value;
            }
        }

        /// <summary>
        /// Gets or sets the watermark font.
        /// </summary>
        [Browsable(true), Category("Appearance"), Description("Indicates watermark font."), DefaultValue(null)]
        public Font WatermarkFont
        {
            get { return m_WatermarkFont; }
            set { m_WatermarkFont = value; this.Invalidate(true); }
        }

        /// <summary>
        /// Gets or sets the watermark text color.
        /// </summary>
        [Browsable(true), Category("Appearance"), Description("Indicates watermark text color.")]
        public Color WatermarkColor
        {
            get { return m_WatermarkColor; }
            set { m_WatermarkColor = value; this.Invalidate(true); }
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

        /// <summary>
        /// Gets or sets the combo box background color. Note that in Office 2007 style back color of the control is automaticall managed.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        private bool m_UseCustomBackColor=false;
        /// <summary>
        /// Gets or sets whether the BackColor value you set is used instead of the style back color automatically provided by the control. Default
        /// value is false which indicates that BackColor property is automatically managed. Set this property to true and then set BackColor property
        /// to make control use your custom back color.
        /// </summary>
        [Browsable(false), DefaultValue(false)]
        public bool UseCustomBackColor
        {
            get { return m_UseCustomBackColor; }
            set { m_UseCustomBackColor = value; }
        }

		/// <summary>
		/// Gets or sets value indicating whether system combo box appearance is used. Default value is false.
		/// </summary>
		[Browsable(false),Category("Behavior"),Description("Makes Combo box appear the same as built-in Combo box."),DefaultValue(false)]
		public bool DefaultStyle
		{
			get
			{
				return m_DefaultStyle;
			}
			set
			{
				if(m_DefaultStyle!=value)
				{
					m_DefaultStyle=value;
					this.Refresh();
				}
			}
		}

		/// <summary>
		/// Gets or sets value indicating whether the combo box is draw using the Windows XP Theme manager when running on Windows XP or theme aware OS.
		/// </summary>
		[Browsable(false),Category("Behavior"),Description("When running on WindowsXP draws control using the Windows XP Themes if theme manager is enabled."),DefaultValue(false)]
		public bool ThemeAware
		{
			get
			{
				return m_WindowsXPAware;
			}
			set
			{
				if(m_WindowsXPAware!=value)
				{
					m_WindowsXPAware=value;
					if(!m_WindowsXPAware)
						m_DefaultStyle=false;
                    else if (m_WindowsXPAware && BarFunctions.ThemedOS)
                    {
                        m_DefaultStyle = true;
                       
                        this.FlatStyle = FlatStyle.Standard;
                      
                    }
				}
			}
		}

		/// <summary>
		/// Disables internal drawing support for the List-box portion of Combo-box. Default value is false which means that internal drawing code is used. If
        /// you plan to provide your own drawing for combo box items you must set this property to True.
		/// </summary>
		[Browsable(true),Category("Behavior"),Description("Disables internal drawing support for the List-box portion of Combo-box."), DefaultValue(false)]
		public bool DisableInternalDrawing
		{
			get
			{
				return m_DisableInternalDrawing;
			}
			set
			{
				if(m_DisableInternalDrawing!=value)
					m_DisableInternalDrawing=value;
			}
		}

		/// <summary>
		/// Gets or sets whether combo box generates the audible alert when Enter key is pressed.
		/// </summary>
		[System.ComponentModel.Browsable(true),HVTTBrowsable(true),System.ComponentModel.Category("Behavior"),System.ComponentModel.Description("Indicates whether combo box generates the audible alert when Enter key is pressed."),System.ComponentModel.DefaultValue(false)]
		public bool PreventEnterBeep
		{
			get
			{
				return m_PreventEnterBeep;
			}
			set
			{
				m_PreventEnterBeep=value;
			}
		}

		/// <summary>
		/// The ImageList control used by Combo box to draw images.
		/// </summary>
		[Browsable(true),Category("Behavior"),Description("The ImageList control used by Combo box to draw images."), DefaultValue(null)]
		public System.Windows.Forms.ImageList Images
		{
			get
			{
				return m_ImageList;
			}
			set
			{
				m_ImageList=value;
			}
		}

        public String Value
        {
            get
            {
                return _msValue;
            }
            set
            {
                _msValue = value;
                if (this.ValueMember.Trim() != "" && _msValue.Trim() != "")
                    this.Text = _mValues[_msValue].ToString();
            }
        }
		/// <summary>
		/// Determines the visual style applied to the combo box when shown. Default style is Office 2007.
		/// </summary>
		[Browsable(true),Category("Appearance"), DefaultValue(HVTTControlStyle.Office2007) ,Description("Determines the display of the item when shown.")]
		public HVTTControlStyle Style
		{
			get
			{
				return m_Style;
			}
			set
			{
				m_Style=value;
                Color c = GetComboColors().Background;
                if (!m_UseCustomBackColor && this.BackColor != c)
                    this.BackColor = c;
				this.Refresh();
			}
		}

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Color c = GetComboColors().Background;
            if (!m_UseCustomBackColor && this.BackColor != c)
                this.BackColor = c;
            SetupTextBoxMessageHandler();
            RemoveTheme(this.Handle);
        }

		/*protected override void OnHandleDestroyed(EventArgs e)
		{
			if(m_Timer!=null)
				m_Timer.Enabled=false;
			base.OnHandleDestroyed(e);
		}*/

        protected override void OnResize(EventArgs e)
        {
            ResizeMarkup();
            base.OnResize(e);
        }
        
        private void MouseOverTimerTick(object sender, EventArgs e)
        {
            bool over = false;

            if (this.IsHandleCreated)
            {
                WinApi.RECT rw = new WinApi.RECT();
                WinApi.GetWindowRect(this.Handle, ref rw);
                Rectangle r = rw.ToRectangle();
                if (r.Contains(Control.MousePosition))
                    over = true;
            }

            if (!over)
            {
                SetMouseOverTimerEnabled(false);
                m_MouseOver = false;
                Color c = GetComboColors().Background;
                if (!m_UseCustomBackColor && this.BackColor != c)
                    this.BackColor = c;
                else
                    this.Refresh();
            }
        }

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
            Color c = GetComboColors().Background;
            if (!m_MouseOver)
                m_MouseOver = true;
            if (!m_UseCustomBackColor && this.BackColor != c)
                this.BackColor = c;
            this.Invalidate(true);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			//if(!this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
				//m_MouseOver=false;
            SetMouseOverTimerEnabled(true);
            //Color c = GetComboColors().Background;
            //if (this.BackColor != c)
                //this.BackColor = c;
			//if(!m_MouseOver)
			//	this.Refresh();
			m_LastFocusWindow=IntPtr.Zero;
			base.OnLostFocus(e);
		}

		protected override void OnDropDown(EventArgs e)
		{
			base.OnDropDown(e);
			if(DropDownChange!=null)
				this.DropDownChange(this,true);
			m_DroppedDown=true;
			this.Refresh();
        }

        [DllImport("user32", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] String pszSubAppName, [MarshalAs(UnmanagedType.LPWStr)] String pszSubIdList);

        private void RemoveTheme(IntPtr handle)
        {
            bool isXp = false;
            if (System.Environment.Version.Major > 5)
                isXp = true;
            else if ((System.Environment.Version.Major == 5) &&
               (System.Environment.Version.Minor >= 1))
                isXp = true;
            if (isXp)
                SetWindowTheme(handle, " ", " ");
        }

        #region Internal Combo Colors
        private class InternalComboColors
        {
            public Color Background = SystemColors.Window;
            public Color Border = SystemColors.Window;
            public LinearGradientColorTable ThumbBackground = null;
            public Color ThumbText = SystemColors.ControlText;
            public LinearGradientColorTable ThumbBorderOuter = null;
            public LinearGradientColorTable ThumbBorderInner = null;
        }

        private InternalComboColors GetComboColors()
        {
            InternalComboColors c = new InternalComboColors();
            
            bool bFocus = (m_MouseOver || this.Focused || this.DroppedDown && this.DropDownStyle != ComboBoxStyle.Simple);
            if (bFocus && !this.Enabled)
                bFocus = false;

            if (this.Style == HVTTControlStyle.Office2007 && GlobalManager.Renderer is Office2007Renderer)
            {
                Office2007ComboBoxColorTable colorTable = ((Office2007Renderer)GlobalManager.Renderer).ColorTable.ComboBox;
                Office2007ComboBoxStateColorTable stateColors = (m_IsStandalone ? colorTable.DefaultStandalone : colorTable.Default);
                if (bFocus)
                {
                    if (m_DroppedDown)
                        stateColors = colorTable.DroppedDown;
                    else
                        stateColors = colorTable.MouseOver;
                }

                c.Background = stateColors.Background;
                c.Border = stateColors.Border;
                c.ThumbBackground = stateColors.ExpandBackground;
                c.ThumbText = stateColors.ExpandText;
                c.ThumbBorderOuter = stateColors.ExpandBorderOuter;
                c.ThumbBorderInner = stateColors.ExpandBorderInner;
            }
            else
            {
                ColorScheme cs = new ColorScheme(this.Style);
                if (bFocus)
                {
                    if (m_DroppedDown)
                    {
                        c.ThumbBackground = new LinearGradientColorTable(cs.ItemPressedBackground, cs.ItemPressedBackground2, cs.ItemPressedBackgroundGradientAngle);
                        c.Border = cs.ItemPressedBorder;
                        c.ThumbText = cs.ItemPressedText;
                    }
                    else
                    {
                        c.ThumbBackground = new LinearGradientColorTable(cs.ItemHotBackground, cs.ItemHotBackground2, cs.ItemHotBackgroundGradientAngle);
                        c.Border = cs.ItemHotBorder;
                        c.ThumbText = cs.ItemHotText;
                    }
                }
                else
                {
                    c.ThumbBackground = new LinearGradientColorTable(cs.BarBackground, cs.BarBackground2, cs.BarBackgroundGradientAngle);
                }
            }

            return c;
        }
        #endregion

        protected override void WndProc(ref Message m)
        {
            const int WM_PAINT = 0xF;
            const int WM_PRINTCLIENT = 0x0318;
            const int WM_CTLCOLORLISTBOX = 0x0134;
            const int CB_ADDSTRING = 0x143;
            const int CB_INSERTSTRING = 0x14A;

            WinApi.RECT rect = new WinApi.RECT();

            if (m.Msg == WM_CTLCOLORLISTBOX)
            {
                m_DropDownHandle = m.LParam;
                //if (m_DropDownHandle != IntPtr.Zero && m_Style == HVTTControlStyle.Office2007)
                //{
                //    if (m_ListBoxMsgHandler == null)
                //    {
                //        //CreateListBoxMsgHandler(m_DropDownHandle);
                //        //m_ListBoxMsgHandler.Paint();
                //    }
                //}
                //else
                //    DisposeListBoxMsgHandler();
                if (m_DropDownHeight > 0)
                {
                    WinApi.GetWindowRect(m.LParam, ref rect);
                    NativeFunctions.SetWindowPos(m.LParam, 0, rect.Left, rect.Top, rect.Right - rect.Left, m_DropDownHeight, NativeFunctions.SWP_NOACTIVATE | NativeFunctions.SWP_NOMOVE);
                }
            }
            else if (m.Msg == (int)WinApi.WindowsMessages.CB_GETDROPPEDSTATE)
            {
                base.WndProc(ref m);
                if (m.Result == IntPtr.Zero)
                {
                    if (m_DroppedDown)
                    {
                        m_DroppedDown = false;
                        if (DropDownChange != null)
                            DropDownChange(this, false);
                    }
                    //DisposeListBoxMsgHandler();
                }
                return;
            }
            else if (m.Msg == NativeFunctions.WM_SETFOCUS)
            {
                if (m.WParam != this.Handle)
                    m_LastFocusWindow = m.WParam;
            }
            else if (m.Msg == CB_ADDSTRING)
            {
                if (this.Items.Count > 0)
                {
                    ComboItem cb = this.Items[this.Items.Count - 1] as ComboItem;
                    if (cb != null)
                        cb.m_ComboBox = this;
                }
            }
            else if (m.Msg == CB_INSERTSTRING)
            {
                int index = m.WParam.ToInt32();
                if (index >= 0 && index < this.Items.Count)
                {
                    ComboItem cb = this.Items[index] as ComboItem;
                    if (cb != null)
                        cb.m_ComboBox = this;
                }
            }
            else if (m.Msg == NativeFunctions.WM_USER + 7)
            {
                if (this.DropDownStyle == ComboBoxStyle.DropDown && !m_Focused) this.SelectionLength = 0;
                this.Invalidate(true);
                return;
            }
            
            if (m_DefaultStyle || this.RightToLeft == RightToLeft.Yes)
            {
                base.WndProc(ref m);
                return;
            }

            if ((m.Msg == WM_PAINT || m.Msg == WM_PRINTCLIENT) && this.DrawMode != DrawMode.Normal)
            {
                try
                {
                    base.WndProc(ref m);
                    
                    Graphics g = null;
                    System.Drawing.Size controlSize = this.Size;

                    IntPtr hdc = WinApi.GetWindowDC(this.Handle);
                    g = Graphics.FromHdc(hdc);
                    //if (m.Msg == WM_PAINT)
                    //    g = this.CreateGraphics();
                    //else
                    //    g = Graphics.FromHdc(m.WParam);

                    try
                    {
                        InternalComboColors colors = GetComboColors();

                        int thumbWidth = SystemInformation.HorizontalScrollBarThumbWidth;
                        if (this.Style == HVTTControlStyle.Office2003 || this.Style == HVTTControlStyle.VS2005 || BarFunctions.IsOffice2007Style(this.Style))
                            thumbWidth -= 3;

                        if (m.Msg == WM_PAINT)
                        {
                            if (this.DropDownStyle != ComboBoxStyle.Simple)
                            {
                                Rectangle fillRect = new Rectangle(0, 0, controlSize.Width, controlSize.Height);
                                //using (SolidBrush brush = new SolidBrush(this.BackColor))
                                    //g.FillRectangle(brush, fillRect);
                                fillRect.Inflate(-2, -2);
                                fillRect.Height--;
                                if (this.RightToLeft == RightToLeft.Yes)
                                {
                                    fillRect.X += thumbWidth;
                                    fillRect.Width -= thumbWidth;
                                }
                                else
                                {
                                    fillRect.Width -= thumbWidth + 4;
                                }
                                fillRect.Inflate(-1, -1);
                                Region oldClip = g.Clip;
                                g.SetClip(fillRect, System.Drawing.Drawing2D.CombineMode.Exclude);
                                using (SolidBrush brush = new SolidBrush(colors.Background))
                                    g.FillRectangle(brush, new Rectangle(0, 0, controlSize.Width, controlSize.Height));
                                g.Clip = oldClip;
                            }
                            //Rectangle fillRect = new Rectangle(0, 0, controlSize.Width, controlSize.Height);
                            //using (SolidBrush brush = new SolidBrush(colors.Background))
                            //    g.FillRectangle(brush, fillRect);
                            NativeFunctions.RECT rect1 = new NativeFunctions.RECT(0, 0, controlSize.Width, 3);
                            ValidateRect(this.Handle, ref rect1);
                            rect1.Top = controlSize.Height - 3;
                            rect1.Bottom = controlSize.Height;
                            ValidateRect(this.Handle, ref rect1);
                            rect1 = new NativeFunctions.RECT(0, 0, 3, controlSize.Height);
                            ValidateRect(this.Handle, ref rect1);
                            rect1.Left = controlSize.Width - 3;
                            rect1.Right = controlSize.Width;
                            ValidateRect(this.Handle, ref rect1);

                            if (this.DropDownStyle != ComboBoxStyle.Simple)
                            {
                                rect1.Left = controlSize.Width - (thumbWidth + 6);
                                rect1.Top = 0;
                                rect1.Bottom = controlSize.Height;
                                rect1.Right = controlSize.Width;
                                ValidateRect(this.Handle, ref rect1);
                            }
                        }

                        //base.WndProc(ref m);

                        bool bFocus = (m_MouseOver || this.Focused || this.DroppedDown && this.DropDownStyle != ComboBoxStyle.Simple);
                        if (bFocus && !this.Enabled)
                            bFocus = false;

                        Rectangle r = new Rectangle(0, 0, controlSize.Width, controlSize.Height);
                        Rectangle r1;
                        if ((this.Style == HVTTControlStyle.Office2003 || this.Style == HVTTControlStyle.VS2005 || BarFunctions.IsOffice2007Style(this.Style)) && !this.Enabled)
                            r1 = new Rectangle(r.Left + 1, r.Top + 1, r.Width - 2, r.Height - 2);
                        else
                            r1 = new Rectangle(r.Left + 2, r.Top + 2, r.Width - 4, r.Height - 4);
                        Rectangle rBorder = r;

                        if (this.DropDownStyle != ComboBoxStyle.Simple && this.Enabled)
                            r1.Width -= thumbWidth;

                        if ((this.Style == HVTTControlStyle.Office2003 || m_Style == HVTTControlStyle.VS2005 || BarFunctions.IsOffice2007Style(m_Style)) && this.Enabled)
                        {
                            using(SolidBrush brush = new SolidBrush(colors.Background))
                                g.FillRectangle(brush, r.Width - SystemInformation.HorizontalScrollBarThumbWidth - 2, r.Y, SystemInformation.HorizontalScrollBarThumbWidth - thumbWidth + 1, r.Height);
                        }

                        g.SetClip(r1, System.Drawing.Drawing2D.CombineMode.Exclude);

                        if ((this.Style == HVTTControlStyle.Office2003 || this.Style == HVTTControlStyle.VS2005 || BarFunctions.IsOffice2007Style(this.Style)) && !this.Enabled)
                        {
                            using (SolidBrush brush = new SolidBrush(SystemColors.ControlDark))
                                g.FillRectangle(brush, 0, 0, this.Width, this.Height);
                        }
                        else
                        {
                            using (SolidBrush brush = new SolidBrush(colors.Background))
                                g.FillRectangle(brush, 0, 0, this.Width, this.Height);
                        }

                        if (this.DesignMode || !this.Enabled)
                        {
                            g.SetClip(r1, System.Drawing.Drawing2D.CombineMode.Replace);
                            if (this.Enabled)
                            {
                                using (SolidBrush brush = new SolidBrush(this.BackColor))
                                    g.FillRectangle(brush, 0, 0, this.Width, this.Height);
                            }
                            else
                            {
                                using (SolidBrush brush = new SolidBrush(SystemColors.Control))
                                    g.FillRectangle(brush, 0, 0, this.Width, this.Height);
                            }
                        }

                        if (bFocus)
                        {
                            if (m_Style == HVTTControlStyle.OfficeXP || m_Style == HVTTControlStyle.Office2003 || m_Style == HVTTControlStyle.VS2005 || BarFunctions.IsOffice2007Style(m_Style))
                            {
                                DisplayHelp.DrawRectangle(g, colors.Border, r);
                                //NativeFunctions.DrawRectangle(g, new Pen(scheme.ItemHotBorder), r);
                            }
                            else
                            {
                                ControlPaint.DrawBorder3D(g, r, Border3DStyle.SunkenOuter, (Border3DSide.Left | Border3DSide.Top | Border3DSide.Right | Border3DSide.Bottom));
                                rBorder = r;
                                rBorder.Inflate(-1, -1);
                            }
                        }
                        else
                        {
                            if (this.Enabled)
                            {
                                NativeFunctions.DrawRectangle(g, new Pen(colors.Border, 1), r);
                            }
                            else
                            {
                                NativeFunctions.DrawRectangle(g, new Pen(SystemColors.ControlDark, 1), r);
                                if (this.DropDownStyle == ComboBoxStyle.DropDownList || this.DropDownStyle == ComboBoxStyle.DropDown)
                                {
                                    Rectangle rText = r;
                                    rText.Inflate(-2, -3);
                                    rText.Width -= thumbWidth;
                                    if (this.SelectedIndex >= 0)
                                    {
                                        DrawItemEventArgs drawArgs = new DrawItemEventArgs(g, this.Font, rText, this.SelectedIndex, DrawItemState.Disabled, SystemColors.ControlDarkDark, SystemColors.Control);
                                        InternalDrawItem(drawArgs);
                                    }
                                    else if (this.Text != "")
                                    {
                                        TextDrawing.DrawString(g, this.Text, this.Font, SystemColors.ControlDark, rText, eTextFormat.Default);
                                    }
                                }
                            }
                        }
                        g.ResetClip();

                        // Draws Combo Button
                        if (this.DropDownStyle != ComboBoxStyle.Simple)
                        {
                            r = new Rectangle(this.ClientRectangle.Width - thumbWidth + 1, 0, thumbWidth - 1, controlSize.Height);
                            if (bFocus)
                            {
                                if (m_Style == HVTTControlStyle.OfficeXP || m_Style == HVTTControlStyle.Office2003 || m_Style == HVTTControlStyle.VS2005 || BarFunctions.IsOffice2007Style(m_Style))
                                {
                                    DisplayHelp.FillRectangle(g, r, colors.ThumbBackground);
                                    if (colors.ThumbBorderOuter != null && !colors.ThumbBorderOuter.IsEmpty)
                                    {
                                        DisplayHelp.DrawGradientRectangle(g, r, colors.ThumbBorderOuter, 1);
                                        if (colors.ThumbBorderInner != null && !colors.ThumbBorderInner.IsEmpty)
                                        {
                                            Rectangle rInner = r;
                                            rInner.Inflate(-1, -1);
                                            DisplayHelp.DrawGradientRectangle(g, rInner, colors.ThumbBorderInner, 1);
                                        }
                                    }
                                    else
                                        DisplayHelp.DrawRectangle(g, colors.Border, r);
                                    //NativeFunctions.DrawRectangle(g, new Pen(scheme.ItemHotBorder)
                                    using (SolidBrush brush = new SolidBrush(colors.ThumbText))
                                        DrawArrow(r, g, brush);
                                    //if (this.DroppedDown)
                                    //    DrawArrow(r, g, new SolidBrush(scheme.ItemPressedText));
                                    //else
                                    //    DrawArrow(r, g, new SolidBrush(scheme.ItemText));
                                }
                                else
                                {
                                    r.Inflate(-1, -1);
                                    r.X -= 1;
                                    r.Width += 1;
                                    if (this.DroppedDown)
                                    {
                                        NativeFunctions.DrawRectangle(g, SystemPens.Control, rBorder);
                                        ControlPaint.DrawBorder3D(g, r, Border3DStyle.Sunken, Border3DSide.All);
                                    }
                                    else
                                    {
                                        ControlPaint.DrawBorder3D(g, r, Border3DStyle.Raised, Border3DSide.All);
                                        NativeFunctions.DrawRectangle(g, SystemPens.Control, rBorder);
                                    }

                                    DrawArrow(r, g, SystemBrushes.ControlText);
                                }
                            }
                            else
                            {
                                if (this.Style == HVTTControlStyle.Office2003 || this.Style == HVTTControlStyle.VS2005 || BarFunctions.IsOffice2007Style(this.Style))
                                {
                                    if (this.Enabled || m_MouseOver)
                                    {
                                        DisplayHelp.FillRectangle(g, r, colors.ThumbBackground);
                                        if (colors.ThumbBorderOuter != null && !colors.ThumbBorderOuter.IsEmpty)
                                        {
                                            DisplayHelp.DrawGradientRectangle(g, r, colors.ThumbBorderOuter, 1);
                                            if (colors.ThumbBorderInner != null && !colors.ThumbBorderInner.IsEmpty)
                                            {
                                                Rectangle rInner = r;
                                                rInner.Inflate(-1, -1);
                                                DisplayHelp.DrawGradientRectangle(g, rInner, colors.ThumbBorderInner, 1);
                                            }
                                        }
                                    }
                                }
                                else
                                    g.FillRectangle(SystemBrushes.Control, r);
                                if (this.Enabled)
                                    DrawArrow(r, g, SystemBrushes.ControlText);
                                else
                                    DrawArrow(r, g, SystemBrushes.ControlDark);

                                if (this.Enabled)
                                {
                                    if (!BarFunctions.IsOffice2007Style(this.Style) || m_MouseOver)
                                    DisplayHelp.DrawRectangle(g, colors.Border, r);
                                }
                            }
                        }

                        if (this.ShouldDrawWatermark() && this.DropDownStyle == ComboBoxStyle.DropDownList)
                            DrawWatermark(g);
                        //g.FillRectangle(Brushes.Red, new Rectangle(this.Width - 30, 0, 30, this.Height));
                    }
                    finally
                    {
                        g.Dispose();
                        WinApi.ReleaseDC(this.Handle, hdc);
                    }
                    if (m_FirstPaintPass)
                    {
                        m_FirstPaintPass = false;
                        WinApi.PostMessage(this.Handle, NativeFunctions.WM_USER + 7, IntPtr.Zero, IntPtr.Zero);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                if (this.Parent is ItemControl)
                    ((ItemControl)this.Parent).UpdateKeyTipsCanvas();
            }
            else
                base.WndProc(ref m);
        }

        private bool ShouldDrawWatermark()
        {
            if (this.Enabled && !this.Focused && this.Text == "" && this.SelectedIndex == -1)
                return true;
            return false;
        }

        private void DrawWatermark(Graphics g)
        {
            if (m_TextMarkup != null)
            {
                MarkupDrawContext dc = GetMarkupDrawContext(g);
                m_TextMarkup.Render(dc);
            }
            else
            {
                eTextFormat tf = eTextFormat.Left | eTextFormat.VerticalCenter;

                if (this.RightToLeft == RightToLeft.Yes) tf |= eTextFormat.RightToLeft;
                //if (this.TextAlign == HorizontalAlignment.Left)
                //    tf |= eTextFormat.Left;
                //else if (this.TextAlign == HorizontalAlignment.Right)
                //    tf |= eTextFormat.Right;
                //else if (this.TextAlign == HorizontalAlignment.Center)
                //    tf |= eTextFormat.HorizontalCenter;
                tf |= eTextFormat.EndEllipsis;
                tf |= eTextFormat.WordBreak;
                TextDrawing.DrawString(g, m_WatermarkText, (m_WatermarkFont == null ? this.Font : m_WatermarkFont),
                    m_WatermarkColor, GetWatermarkBounds(), tf);
            }
        }

        private Rectangle GetWatermarkBounds()
        {
            if (this.DropDownStyle != ComboBoxStyle.DropDownList && m_TextWindowMsgHandler!=null)
            {
                WinApi.RECT rect = new WinApi.RECT();
                WinApi.GetWindowRect(m_TextWindowMsgHandler.Handle, ref rect);
                return new Rectangle(0, 0, rect.Width, rect.Height);
            }

            Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
            r.Inflate(-2, -1);
            int thumbSize = SystemInformation.HorizontalScrollBarThumbWidth;
            r.Width -= thumbSize;
            if (this.RightToLeft == RightToLeft.Yes)
                r.X += thumbSize;

            return r;
        }

        //private void CreateListBoxMsgHandler(IntPtr m_DropDownHandle)
        //{
        //    DisposeListBoxMsgHandler();
        //    m_ListBoxMsgHandler = new ComboListBoxMsgHandler();
        //    m_ListBoxMsgHandler.AssignHandle(m_DropDownHandle);
        //}

        //private void DisposeListBoxMsgHandler()
        //{
        //    if (m_ListBoxMsgHandler != null)
        //    {
        //        m_ListBoxMsgHandler.ReleaseHandle();
        //        m_ListBoxMsgHandler = null;
        //    }
        //}

		private void DrawArrow(Rectangle r, Graphics g, Brush b)
		{
			Point[] p=new Point[3];
			p[0].X=r.Left+(r.Width-4)/2;
			p[0].Y=r.Top+(r.Height-3)/2;
			p[1].X=p[0].X+5;
			p[1].Y=p[0].Y;
			p[2].X=p[0].X+2;
			p[2].Y=p[0].Y+3;
			g.FillPolygon(b,p);
		}

		/*private void OnTimer(object sender, EventArgs e)
		{
			bool bRefresh=false;

			if(m_DroppedDown && !this.DroppedDown)
			{
				m_DroppedDown=false;
				
				if(DropDownChange!=null)
					this.DropDownChange(this,false);

				m_DropDownHandle=IntPtr.Zero;
				bRefresh=true;
			}

			Point mousePos=this.PointToClient(Control.MousePosition);
			if(!this.ClientRectangle.Contains(mousePos))
			{
				if(m_MouseOver && !m_DroppedDown)
				{
					m_MouseOver=false;
					bRefresh=true;
				}
			}
			else if(!m_MouseOver)
			{
				m_MouseOver=true;
				bRefresh=true;
			}

			if(bRefresh)
				this.Refresh();
		}*/

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			m_MouseOver=false;
            if (this.DropDownStyle == ComboBoxStyle.DropDown && this.Items.Count > 0 && this.Items[0] is ComboItem && this.DisplayMember!="")
            {
                string s = this.DisplayMember;
                this.DisplayMember = "";
                this.DisplayMember = s;
            }
            if (this.IsHandleCreated && !this.IsDisposed)
            {
                Color c = GetComboColors().Background;
                if (!m_UseCustomBackColor && this.BackColor != c)
                    this.BackColor = c;
            }
		}

		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			if(!this.DroppedDown)
			{
				if(m_DroppedDown)
				{
                    
					m_DroppedDown=false;
					if(DropDownChange!=null)
						DropDownChange(this,false);
				}
				if(!m_MouseOver)
					this.Refresh();
			}
			base.OnSelectedIndexChanged(e);
		}

		/*protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			SyncTimerEnabled();
		}*/

		/*private void SyncTimerEnabled()
		{
			if(this.Visible)
			{
				if(!m_Timer.Enabled && this.Enabled && !this.DesignMode)
					m_Timer.Enabled=true;
			}
			else
			{
				if(m_Timer.Enabled)
					m_Timer.Enabled=false;
			}
		}*/

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			/*if(m_Timer!=null)
			{
				if(m_Timer.Enabled)
					m_Timer.Enabled=false;
				m_Timer.Dispose();
				m_Timer=null;
			}*/
            if (m_MouseOverTimer != null)
            {
                m_MouseOverTimer.Enabled = false;
                m_MouseOverTimer.Dispose();
                m_MouseOverTimer = null;
            }
			m_DisableInternalDrawing=true;
			if(m_TextWindowMsgHandler!=null)
			{
				m_TextWindowMsgHandler.ReleaseHandle();
				m_TextWindowMsgHandler=null;
			}
			base.Dispose( disposing );
		}

		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			if(this.Disposing || this.IsDisposed)
				return;
			if(!m_DisableInternalDrawing && this.DrawMode==DrawMode.OwnerDrawFixed)
			{
				if(this.IsHandleCreated && this.Parent!=null && !this.Parent.IsDisposed)
					this.ItemHeight=this.FontHeight;
			}
		}

		protected override void OnMeasureItem(MeasureItemEventArgs e)
		{
			base.OnMeasureItem(e);
			if(!m_DisableInternalDrawing)
			{
				if(this.DrawMode==DrawMode.OwnerDrawFixed)
				{
                    e.ItemHeight = this.ItemHeight - 2;
				}
				else
				{
					object o=this.Items[e.Index];
					if(o is ComboItem)
					{
						if(((ComboItem)o).IsFontItem)
							MeasureFontItem(e);
						else
						{
							Size sz=GetComboItemSize(o as ComboItem);
							e.ItemHeight=sz.Height;
							e.ItemWidth=sz.Width;
                            if (m_Style == HVTTControlStyle.Office2007)
                            {
                                e.ItemHeight += 6;
                                e.ItemWidth += 6;
                            }
						}
					}
				}
			}
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			base.OnDrawItem(e);
			InternalDrawItem(e);
		}

		private void InternalDrawItem(DrawItemEventArgs e)
		{
			if(!m_DisableInternalDrawing && e.Index>=0)
			{
				object o=this.Items[e.Index];
				if(o is ComboItem)
					DrawComboItem(e);
				else
					DrawObjectItem(e);
			}
		}

		protected virtual Size GetComboItemSize(ComboItem item)
		{
			Size size=Size.Empty;
			if(BarFunctions.IsHandleValid(this))
			{
				Graphics g=this.CreateGraphics();
				try
				{
					size=GetComboItemSize(item, g);
				}
				finally
				{
					g.Dispose();
				}
			}
			return size;
		}

		protected virtual void DrawObjectItem(DrawItemEventArgs e)
		{
			Graphics g=e.Graphics;
			string text=GetItemText(this.Items[e.Index]);
            Color textColor = Color.Empty;
            Office2007ButtonItemStateColorTable ct = null;
            
            if (m_Style == HVTTControlStyle.Office2007)
            {
                Office2007ButtonItemColorTable bct = ((Office2007Renderer)GlobalManager.Renderer).ColorTable.ButtonItemColors[0];
                if ((e.State & DrawItemState.Selected) != 0 || (e.State & DrawItemState.HotLight) != 0)
                    ct = bct.MouseOver;
                else if ((e.State & DrawItemState.Disabled) != 0 || !this.Enabled)
                    ct = bct.Disabled;
                else
                    ct = bct.Default;

                if (ct != null)
                    textColor = ct.Text;
                else if ((e.State & DrawItemState.Disabled) != 0 || !this.Enabled)
                    textColor = SystemColors.ControlDark;
                else
                    textColor = SystemColors.ControlText;

                if ((e.State & DrawItemState.HotLight) != 0 || (e.State & DrawItemState.Selected) != 0)
                {
                    Rectangle r = e.Bounds;
                    r.Width--;
                    r.Height--;
                    Office2007ButtonItemPainter.PaintBackground(g, ct, r, 2);
                }
                else
                    e.DrawBackground();
            }
            else
            {
                e.DrawBackground();

                if ((e.State & DrawItemState.HotLight) != 0 || (e.State & DrawItemState.Selected) != 0)
                {
                    g.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                    textColor = SystemColors.HighlightText;
                }
                else if ((e.State & DrawItemState.Disabled) != 0 || (e.State & DrawItemState.Grayed) != 0)
                    textColor = SystemColors.ControlDarkDark;
                else
                    textColor = SystemColors.ControlText;
            }

			if((e.State & DrawItemState.Focus)!=0)
                DrawFocusRectangle(e);
            Rectangle rText = e.Bounds;
            if (m_Style == HVTTControlStyle.Office2007)
                rText.Inflate(-3, 0);
            else
                rText.Inflate(-2, 0);
			TextDrawing.DrawString(g,text,this.Font,textColor,rText,eTextFormat.Default | eTextFormat.NoClipping | eTextFormat.NoPrefix);
		}

        private void DrawFocusRectangle(DrawItemEventArgs e)
        {
            if (((e.State & DrawItemState.Focus) == DrawItemState.Focus) && ((e.State & DrawItemState.NoFocusRect) != DrawItemState.NoFocusRect))
            {
                Rectangle r = e.Bounds;
                r.Width--;
                r.Height--;
                ControlPaint.DrawFocusRectangle(e.Graphics, r, e.ForeColor, e.BackColor);
            }
        } 


		protected virtual void DrawComboItem(DrawItemEventArgs e)
		{
			ComboItem item=this.Items[e.Index] as ComboItem;
			if(item.IsFontItem)
			{
				this.DrawFontItem(e);
				return;
			}

			Graphics g=e.Graphics;
			Image img=null;
			Color clr;
            Color textColor = item.ForeColor;
            if (textColor.IsEmpty || (e.State & DrawItemState.Selected) != 0 || (e.State & DrawItemState.HotLight) != 0)
                textColor = e.ForeColor;

            if (item.ImageIndex >= 0 && m_ImageList != null && m_ImageList.Images.Count > item.ImageIndex)
                img = m_ImageList.Images[item.ImageIndex];
            else if (item.Image != null)
                img = item.Image;

            Office2007ButtonItemStateColorTable ct = null;
            if (m_Style == HVTTControlStyle.Office2007)
            {
                Office2007ButtonItemColorTable bct = ((Office2007Renderer)GlobalManager.Renderer).ColorTable.ButtonItemColors[0];
                if ((e.State & DrawItemState.Selected) != 0 || (e.State & DrawItemState.HotLight) != 0)
                    ct = bct.MouseOver;
                else if ((e.State & DrawItemState.Disabled) != 0 || !this.Enabled)
                    ct = bct.Disabled;
                else
                    ct = bct.Default;
                //if (ct == null)
                if (!this.Enabled)
                    textColor = SystemColors.ControlDark;
                else
                    textColor = SystemColors.ControlText;
                //else
                  //  textColor = ct.Text;
            }

			int contWidth=this.DropDownWidth;
			if(item.ImagePosition!=HorizontalAlignment.Center && img!=null)
			{
				contWidth-=img.Width;
				if(contWidth<=0)
					contWidth=this.DropDownWidth;
			}

			// Back Color
			if((e.State & DrawItemState.Selected)!=0 || (e.State & DrawItemState.HotLight)!=0)
			{
                if (m_Style == HVTTControlStyle.Office2007)
                    Office2007ButtonItemPainter.PaintBackground(g, ct, e.Bounds, 2);
                else
                    e.DrawBackground();
                DrawFocusRectangle(e);
			}
			else
			{
				clr=item.BackColor;
				if(item.BackColor.IsEmpty)
					clr=e.BackColor;
				g.FillRectangle(new SolidBrush(clr),e.Bounds);
			}

			// Draw Image
			Rectangle rImg=e.Bounds;
			Rectangle rText=e.Bounds;
            if (e.State != DrawItemState.ComboBoxEdit)
            {
                if (m_Style == HVTTControlStyle.Office2007)
                    rText.Inflate(-3, 0);
                else
                    rText.Inflate(-2, 0);
            }
			if(img!=null)
			{
                rImg.Width=img.Width;
				rImg.Height=img.Height;
				if(item.ImagePosition==HorizontalAlignment.Left)
				{
					// Left
					if(e.Bounds.Height>img.Height)
						rImg.Y+=(e.Bounds.Height-img.Height)/2;
					rText.Width-=rImg.Width;
					rText.X+=rImg.Width;
				}
				else if(item.ImagePosition==HorizontalAlignment.Right)
				{
					// Right
					if(e.Bounds.Height>img.Height)
						rImg.Y+=(e.Bounds.Height-img.Height)/2;
					rImg.X=e.Bounds.Right-img.Width;
					rText.Width-=rImg.Width;
				}
				else
				{
					// Center
					rImg.X+=(e.Bounds.Width-img.Width)/2;
					rText.Y=rImg.Bottom;
				}
				g.DrawImage(img,rImg);
			}
			
			// Draw Text
			if(item.Text!="")
			{
				System.Drawing.Font f=e.Font;
				bool bDisposeFont=false;
				try
				{
					if(item.FontName!="")
					{
						f=new Font(item.FontName,item.FontSize,item.FontStyle);
						bDisposeFont=true;
					}
					else if(item.FontStyle!=f.Style)
					{
						f=new Font(f,f.Style);
						bDisposeFont=true;
					}
				}
				catch
				{
					f=e.Font;
					if(f==null)
					{
						f=System.Windows.Forms.SystemInformation.MenuFont.Clone() as Font;
						bDisposeFont=true;
					}
				}

                eTextFormat format = eTextFormat.Default | eTextFormat.NoClipping | eTextFormat.NoPrefix;
                if (item.TextFormat.Alignment == StringAlignment.Center)
                    format = eTextFormat.HorizontalCenter;
                else if (item.TextFormat.Alignment == StringAlignment.Far)
                    format = eTextFormat.Right;
                if (item.TextLineAlignment == StringAlignment.Center)
                    format |= eTextFormat.VerticalCenter;
                else if (item.TextLineAlignment == StringAlignment.Far)
                    format |= eTextFormat.Bottom;
                TextDrawing.DrawString(g, item.Text, f, textColor, rText, format);

				if(bDisposeFont)
					f.Dispose();
			}
			
		}

		protected virtual Size GetComboItemSize(ComboItem item, Graphics g)
		{
			if(this.DrawMode==DrawMode.OwnerDrawFixed)
				return new Size(this.DropDownWidth,this.ItemHeight);

			Size sz=Size.Empty;
			Size textSize=Size.Empty;
			Image img=null;
			if(item.ImageIndex>=0)
				img=m_ImageList.Images[item.ImageIndex];
			else if(item.Image!=null)
				img=item.Image;
			
			int contWidth=this.DropDownWidth;
			if(item.ImagePosition!=HorizontalAlignment.Center && img!=null)
			{
				contWidth-=img.Width;
				if(contWidth<=0)
					contWidth=this.DropDownWidth;
			}
			
			Font font=this.Font;
			if(item.FontName!="")
			{
				try
				{
					font=new Font(item.FontName,item.FontSize,item.FontStyle);
				}
				catch
				{
					font=this.Font;
				}
			}

            eTextFormat format = eTextFormat.Default;
            if (item.TextFormat.Alignment == StringAlignment.Center)
                format = eTextFormat.HorizontalCenter;
            else if (item.TextFormat.Alignment == StringAlignment.Far)
                format = eTextFormat.Right;
            if (item.TextLineAlignment == StringAlignment.Center)
                format |= eTextFormat.VerticalCenter;
            else if (item.TextLineAlignment == StringAlignment.Far)
                format |= eTextFormat.Bottom;

			textSize=TextDrawing.MeasureString(g,item.Text,font,this.DropDownWidth,format);
            textSize.Width += 2;
            sz.Width=textSize.Width;
			sz.Height=textSize.Height;
            if(sz.Width<this.DropDownWidth)
				sz.Width=this.DropDownWidth;

			if(item.ImagePosition==HorizontalAlignment.Center && img!=null)
                sz.Height+=img.Height;
			else if(img!=null && img.Height>sz.Height)
				sz.Height=img.Height;

			return sz;
		}

		/// <summary>
		/// Loads all fonts available on system into the combo box.
		/// </summary>
		public void LoadFonts()
		{
			this.Items.Clear();
//			Graphics g=this.CreateGraphics();
//			FontFamily[] families = FontFamily.GetFamilies(g);
//			g.Dispose();
//    
//			this.DrawMode=DrawMode.OwnerDrawFixed;
//			foreach (FontFamily family in families) 
//			{
//				if(family.IsStyleAvailable(FontStyle.Regular))
//				{
//					ComboItem item=new ComboItem();
//					item.FontName=family.Name;
//					item.FontSize=this.Font.Size;
//					item.Text=family.Name;
//					this.Items.Add(item);
//				}
//			}

			System.Drawing.Text.InstalledFontCollection colInstalledFonts = new System.Drawing.Text.InstalledFontCollection();
			FontFamily[] aFamilies = colInstalledFonts.Families;
			foreach(FontFamily ff in aFamilies)
			{
				ComboItem item=new ComboItem();
				item.IsFontItem=true;
				item.FontName=ff.GetName(0);
				item.FontSize=this.Font.Size;
				item.Text=ff.GetName(0);
				this.Items.Add(item);
			}
			this.DropDownWidth=this.Width*2;
		}

		private void DrawFontItem(DrawItemEventArgs e)
		{
			FontStyle[] styles=new FontStyle[4]{FontStyle.Regular,FontStyle.Bold,FontStyle.Italic,FontStyle.Bold | FontStyle.Italic};
			e.DrawBackground();
			string fontname = this.Items[e.Index].ToString();
			FontFamily family = new FontFamily(fontname);

			int iWidth = this.DropDownWidth/2-4;
			if(iWidth<=0)
				iWidth=this.Width;
			foreach(FontStyle style in styles)
			{
				if(family.IsStyleAvailable(style))
				{
                    eTextFormat format = eTextFormat.Default | eTextFormat.NoClipping | eTextFormat.NoPrefix;
                    Color textColor = (e.State & DrawItemState.Selected) != 0 ? SystemColors.HighlightText : SystemColors.ControlText;

                    if ((e.State & DrawItemState.ComboBoxEdit) == DrawItemState.ComboBoxEdit)
                    {
                        TextDrawing.DrawString(e.Graphics, fontname, this.Font, textColor, e.Bounds, format);
                    }
                    else
                    {
                        Size szFont = TextDrawing.MeasureString(e.Graphics, fontname, this.Font);
                        int iDiff = (int)((e.Bounds.Height - szFont.Height) / 2);
                        Rectangle rFontName = new Rectangle(e.Bounds.X, e.Bounds.Y + iDiff, 
                            ((e.State & DrawItemState.Disabled)==DrawItemState.Disabled?e.Bounds.Width: Math.Max(e.Bounds.Width - 100, 32)), e.Bounds.Height - iDiff);
                        TextDrawing.DrawString(e.Graphics, fontname, this.Font, textColor, rFontName, format);
                        Rectangle rRemainder = new Rectangle(e.Bounds.X + iWidth + 4, e.Bounds.Y, e.Bounds.Width + 100, e.Bounds.Height);
                        Font f = new Font(family, (float)e.Bounds.Height - 8, style);
                        TextDrawing.DrawString(e.Graphics, fontname, f, textColor, rRemainder, format);
                    }
					break;
				}
			}
		}

		private void MeasureFontItem(MeasureItemEventArgs e)
		{
			e.ItemHeight = 18;
		}


		/// <summary>
		/// Specifies the height of the drop-down portion of combo box.
		/// </summary>
		[Browsable(true),Category("Behavior"),Description("The height, in pixels, of drop down box in a combo box."), DefaultValue(0)]
		public int DropDownHeight
		{
			get
			{
				return m_DropDownHeight;
			}
			set
			{
				m_DropDownHeight=value;
			}
		}


		/// <summary>
		/// Releases the focus from combo box. The control that last had focus will receive focus back when this method is called.
		/// </summary>
		public void ReleaseFocus()
		{
			if(this.Focused && m_LastFocusWindow!=IntPtr.Zero)
			{
				Control ctrl=Control.FromChildHandle(new System.IntPtr(m_LastFocusWindow.ToInt32()));
				if(ctrl!=this)
				{
					if(ctrl!=null)
						ctrl.Focus();
					else
					{
						NativeFunctions.SetFocus(m_LastFocusWindow.ToInt32());
					}
					this.OnLostFocus(new System.EventArgs());
				}
				m_LastFocusWindow=IntPtr.Zero;
			}
		}

		protected override bool ProcessCmdKey(ref Message msg,Keys keyData)
		{
			if(keyData==Keys.Enter && m_PreventEnterBeep)
			{
				this.OnKeyPress(new KeyPressEventArgs((char)13));
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				ReleaseFocus();
			else if(e.KeyCode==Keys.Escape)
			{
				ReleaseFocus();
			}

			base.OnKeyDown(e);
		}
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
        }
		/// <summary>
		/// Gets the window handle that the drop down list is bound to.
		/// </summary>
		[Browsable(false)]
		public IntPtr DropDownHandle
		{
			get
			{
				return m_DropDownHandle;
			}
		}

		internal bool MouseOver
		{
			get
			{
				return m_MouseOver;
			}
			set
			{
				if(m_MouseOver!=value)
				{
					m_MouseOver=value;
					this.Refresh();
				}
			}
		}

		[System.ComponentModel.Editor(typeof(HVTT.UI.Editors.ComboItemsEditor), typeof(System.Drawing.Design.UITypeEditor)), Localizable(true)]
		public new ComboBox.ObjectCollection Items
		{
			get
			{
				return base.Items;
			}
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			if(!m_MouseOver)
			{
				m_MouseOver=true;
                Color c = GetComboColors().Background;
                if (!m_UseCustomBackColor && this.BackColor != c)
                    this.BackColor = c;
                this.Invalidate(true);
			}
			base.OnMouseEnter(e);
		}
		protected override void OnMouseLeave(EventArgs e)
		{
            //if(this.DroppedDown)
            //{
            //    m_MouseOver=false;
            //}
            //else if(this.DropDownStyle!=ComboBoxStyle.DropDownList && m_MouseOver)
            //{
            //    // Get the mouse position
            //    Point p=this.PointToClient(Control.MousePosition);
            //    if(!this.ClientRectangle.Contains(p))
            //    {
            //        m_MouseOver=false;
            //    }
            //}
            //else if(m_MouseOver)
            //{
            //    m_MouseOver=false;
            //}
            SetMouseOverTimerEnabled(true);
            //Color c = GetComboColors().Background;
            //if (this.BackColor != c)
            //    this.BackColor = c;
            //this.Refresh();
			base.OnMouseLeave(e);
		}

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!m_MouseOver)
            {
                if (!m_Focused)
                {
                    m_MouseOver = true;
                    this.Refresh();
                    SetMouseOverTimerEnabled(true);
                }
            }
        }

        private void SetMouseOverTimerEnabled(bool value)
        {
            if (m_MouseOverTimer != null) m_MouseOverTimer.Enabled = value;
        }

        private void SetupTextBoxMessageHandler()
        {

            if (this.DropDownStyle != ComboBoxStyle.DropDownList && this.AutoCompleteMode == AutoCompleteMode.None)
            {
                if (m_TextWindowMsgHandler == null)
                {
                    // Get hold of the text box
                    IntPtr hwnd = GetWindow(this.Handle, GW_CHILD);
                    // Subclass so we can track messages
                    if (hwnd != IntPtr.Zero)
                    {
                        m_TextWindowMsgHandler = new ComboTextBoxMsgHandler();
                        m_TextWindowMsgHandler.MouseLeave += new EventHandler(this.TextBoxMouseLeave);
                        m_TextWindowMsgHandler.Paint += new PaintEventHandler(TextBoxPaint);
                        m_TextWindowMsgHandler.AssignHandle(hwnd);
                    }
                }
            }
            else if (m_TextWindowMsgHandler != null)
            {
                m_TextWindowMsgHandler.ReleaseHandle();
                m_TextWindowMsgHandler = null;
            }
        }
		
		protected override void OnDropDownStyleChanged(EventArgs e)
		{
            SetupTextBoxMessageHandler();
			base.OnDropDownStyleChanged(e);
		}

        private void TextBoxPaint(object sender, PaintEventArgs e)
        {
            if (ShouldDrawWatermark())
                DrawWatermark(e.Graphics);
        }

		private void TextBoxMouseLeave(object sender, EventArgs e)
		{
			if(!m_MouseOver)
				return;
            SetMouseOverTimerEnabled(true);
			// Get the mouse position
			//Point p=this.PointToClient(Control.MousePosition);
			//if(!this.Bounds.Contains(p))
			//{
				//m_MouseOver=false;
				//this.Refresh();
			//}
		}

        //private class ComboListBoxMsgHandler : NativeWindow, INonClientControl
        //{
        //    private NonClientPaintHandler m_NCPainter = null;

        //    protected override void OnHandleChange()
        //    {
        //        if (m_NCPainter != null)
        //        {
        //            m_NCPainter.Dispose();
        //            m_NCPainter = null;
        //        }
        //        if (this.Handle != IntPtr.Zero)
        //        {this.
        //            m_NCPainter = new NonClientPaintHandler(this, true);
        //        }

        //        base.OnHandleChange();
        //    }

        //    public override void ReleaseHandle()
        //    {
        //        if (m_NCPainter != null)
        //        {
        //            m_NCPainter.Dispose();
        //            m_NCPainter = null;
        //        }
        //        base.ReleaseHandle();
        //    }

        //    protected override void WndProc(ref Message m)
        //    {
        //        bool callBase = m_NCPainter.WndProc(ref m);

        //        if (callBase)
        //            base.WndProc(ref m);
        //    }

        //    #region INonClientControl Members

        //    void INonClientControl.BaseWndProc(ref Message m)
        //    {
        //        base.WndProc(ref m);
        //    }

        //    private ColorScheme GetColorScheme()
        //    {
        //        Office2007Renderer r = GlobalManager.Renderer as Office2007Renderer;
        //        if (r != null) return r.ColorTable.LegacyColors;
        //        return new ColorScheme(HVTTControlStyle.Office2007);
        //    }

        //    private BaseRenderer GetRenderer()
        //    {
        //        return GlobalManager.Renderer;
        //    }

        //    ItemPaintArgs INonClientControl.GetItemPaintArgs(Graphics g)
        //    {
        //        ItemPaintArgs pa = new ItemPaintArgs(this as IOwner, Control.FromHandle(this.Handle), g, GetColorScheme());
        //        pa.Renderer = this.GetRenderer();
        //        pa.DesignerSelection = false;
        //        pa.GlassEnabled = false;
        //        return pa;
        //    }

        //    ElementStyle INonClientControl.BorderStyle
        //    {
        //        get
        //        {
        //            return null;
        //            //Office2007Renderer r = GlobalManager.Renderer as Office2007Renderer;
        //            //if (r != null) return r.ColorTable.StyleClasses[ElementStyleClassKeys.TextBoxBorderKey] as ElementStyle;
        //            ElementStyle style = new ElementStyle();
        //            //style.BackColor = SystemColors.Window;
        //            style.Border = StyleBorderType.Solid;
        //            style.BorderWidth = 1;
        //            style.BorderColor = Color.Red;
        //            return style;
        //        }
        //    }

        //    void INonClientControl.PaintBackground(PaintEventArgs e)
        //    {
        //    }

        //    IntPtr INonClientControl.Handle
        //    {
        //        get { return this.Handle; }
        //    }

        //    int INonClientControl.Width
        //    {
        //        get { return this.GetBounds().Width; }
        //    }

        //    int INonClientControl.Height
        //    {
        //        get { return this.GetBounds().Height; }
        //    }

        //    bool INonClientControl.IsHandleCreated
        //    {
        //        get { return this.Handle!=IntPtr.Zero; }
        //    }

        //    Point INonClientControl.PointToScreen(Point client)
        //    {
        //        Rectangle r = this.GetBounds();
        //        return new Point(r.X + client.X, r.Y + client.Y);
        //    }

        //    private Rectangle GetBounds()
        //    {
        //        WinApi.RECT r = new WinApi.RECT();
        //        WinApi.GetWindowRect(this.Handle, ref r);
        //        return r.ToRectangle();
        //    }

        //    Color INonClientControl.BackColor
        //    {
        //        get { return Color.Transparent; }
        //    }

        //    #endregion

        //    internal void Paint()
        //    {
        //        m_NCPainter.PaintNonClientAreaBuffered();
        //    }
        //}

		private class ComboTextBoxMsgHandler:NativeWindow
		{
			private const int WM_MOUSELEAVE=0x02A3;
			private const int WM_MOUSEMOVE=0x0200;
			private const int TME_LEAVE=0x02;
			[DllImport("user32",SetLastError=true, CharSet=CharSet.Auto)]
			private static extern bool TrackMouseEvent(ref TRACKMOUSEEVENT lpEventTrack);

			public event EventHandler MouseLeave;
            public event PaintEventHandler Paint;

			private struct TRACKMOUSEEVENT 
			{
				public int cbSize;
				public int dwFlags;
				public int hwndTrack;
				public int dwHoverTime;
			}

			private bool m_MouseTracking=false;

			protected override void WndProc(ref Message m)
			{
                const int WM_PAINT = 0xF;
				if(m.Msg==WM_MOUSEMOVE && !m_MouseTracking)
				{
                    m_MouseTracking = true;
                    TRACKMOUSEEVENT tme = new TRACKMOUSEEVENT();
                    tme.dwFlags = TME_LEAVE;
                    tme.cbSize = Marshal.SizeOf(tme);
                    tme.hwndTrack = this.Handle.ToInt32();
                    tme.dwHoverTime = 0;
                    m_MouseTracking = TrackMouseEvent(ref tme);
				}
				else if(m.Msg==WM_MOUSELEAVE)
				{
					if(MouseLeave!=null)
						MouseLeave(this,new EventArgs());
					m_MouseTracking=false;
				}
                else if (m.Msg == WM_PAINT)
                {
                    base.WndProc(ref m);
                    if (Paint != null)
                    {
                        using (Graphics g = Graphics.FromHwnd(m.HWnd))
                            Paint(this, new PaintEventArgs(g, Rectangle.Empty));
                    }
                    return;
                }
				base.WndProc(ref m);
			}
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HVTTComboBox
            // 
            this.ResumeLayout(false);

        }
        protected override void OnDataSourceChanged(EventArgs e)
        {
            if (this.ValueMember.Trim() != "")
            {
                if (this.DataSource is DataTable)
                {
                    DataTable tbl = new DataTable();
                    tbl = this.DataSource as DataTable;
                    _mValues = new Hashtable();
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        _mValues.Add(tbl.Rows[i][this.ValueMember].ToString(), tbl.Rows[i][this.DisplayMember].ToString());
                        _mlValue.Add(tbl.Rows[i][this.ValueMember].ToString());
                    }
                }
            }
            
            base.OnDataSourceChanged(e);
        }

        protected override void OnSelectedValueChanged(EventArgs e)
        {
            _mbIsChange = true;
            
            base.OnSelectedValueChanged(e);
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (ValueChange != null)
                ValueChange(this, e);

            if (_mlValue.Count >= this.SelectedIndex && (_mlValue.Count > 0 && _mValues.Count > 0) && _mlValue.Count == _mValues.Count)
            {
                _msValue = _mlValue[this.SelectedIndex].ToString();
                
            }
            if (_sResentText != base.Text)
            {
                _mbIsChange = true;
            }

        }
        

    }
}
