using System;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace HVTT.UI.Window.Forms
{
    [ToolboxBitmap(typeof(HVTTButton),"HVTTButton.HVTTButton.ico"),ToolboxItem(true), DefaultEvent("Click"), Designer(typeof(Design.HVTTButtonDesigner)), System.Runtime.InteropServices.ComVisible(false)]
    public class HVTTButton : Control, IButtonControl, IThemeCache, IMessageHandlerClient,
        IOwnerMenuSupport, IOwner, IRenderingSupport, IAccessibilitySupport, IOwnerLocalize
    {
        #region Events
        /// <summary>
        /// Occurs when popup of type container is loading.
        /// </summary>
        [Description("Occurs when popup of type container is loading.")]
        public event EventHandler PopupContainerLoad;

        /// <summary>
        /// Occurs when popup of type container is unloading.
        /// </summary>
        [Description("Occurs when popup of type container is unloading.")]
        public event EventHandler PopupContainerUnload;

        /// <summary>
        /// Occurs when popup item is about to open.
        /// </summary>
        [Description("Occurs when popup item is about to open.")]
        public event EventHandler PopupOpen;

        /// <summary>
        /// Occurs when popup item is closing.
        /// </summary>
        [Description("Occurs when popup item is closing.")]
        public event EventHandler PopupClose;

        /// <summary>
        /// Occurs just before popup window is shown.
        /// </summary>
        [Description("Occurs just before popup window is shown.")]
        public event EventHandler PopupShowing;

        /// <summary>
        /// Occurs when Checked property has changed.
        /// </summary>
        [Description("Occurs when Checked property has changed.")]
        public event EventHandler CheckedChanged;

        /// <summary>
        /// Occurs when ButtonItem clicked.
        /// </summary>
        [Description("Occurs when ButtonItem clicked.")]
        public event HVTTButtonItemClickEventHandler ItemClicked;

        /// <summary>
        /// Occurs when Control is looking for translated text for one of the internal text that are
        /// displayed on menus, toolbars and customize forms. You need to set Handled=true if you want
        /// your custom text to be used instead of the built-in system value.
        /// </summary>
        public event HVTTManager.LocalizeStringEventHandler LocalizeString;
        #endregion

        #region Private Variables
        private ButtonItem m_Button = null;
        private ColorScheme m_ColorScheme = null;
        private bool m_FadeEffect = true;
        private bool m_AntiAlias = false;
        private DialogResult m_DialogResult = DialogResult.None;
        private bool m_IsDefault = false;
        private bool m_FilterInstalled = false;
        private bool m_MenuEventSupport = false;
        private bool m_MenuFocus = false;
        private Timer m_ActiveWindowTimer = null;
        private IntPtr m_ForegroundWindow = IntPtr.Zero;
        private IntPtr m_ActiveWindow = IntPtr.Zero;
        private Hashtable m_ShortcutTable = new Hashtable();
        private bool m_DisabledImagesGrayScale = true;
        private BaseItem m_ExpandedItem = null;
        private BaseItem m_FocusItem = null;
		private System.Windows.Forms.ImageList m_ImageList;
		private System.Windows.Forms.ImageList m_ImageListMedium=null;
		private System.Windows.Forms.ImageList m_ImageListLarge=null;

        // Theme Caching Support
        private ThemeWindow m_ThemeWindow = null;
        private ThemeRebar m_ThemeRebar = null;
        private ThemeToolbar m_ThemeToolbar = null;
        private ThemeHeader m_ThemeHeader = null;
        private ThemeScrollBar m_ThemeScrollBar = null;
        private ThemeExplorerBar m_ThemeExplorerBar = null;
        private ThemeProgress m_ThemeProgress = null;
        private ThemeButton m_ThemeButton = null;

        private eButtonTextAlignment m_TextAlignment = eButtonTextAlignment.Center;
        private BaseItem m_DoDefaultActionItem = null;
        private Size m_PreferedSize = Size.Empty;

        private HVTTStyle2008 m_Style2008 = new HVTTStyle2008();
        private String m_sValue = "";

        public String LanguageCode { get; set; }
        #endregion

        #region Constructor
        public HVTTButton()
        {
            PainterFactory.InitFactory();
            if (!ColorFunctions.ColorsLoaded)
            {
                NativeFunctions.RefreshSettings();
                NativeFunctions.OnDisplayChange();
                ColorFunctions.LoadColors();
            }
            LanguageCode = "";
            m_Button = CreateButtonItem();
            m_Button.GlobalItem = false;
            m_Button.Displayed = true;
            m_Button.ContainerControl = this;
            m_Button.ColorTable = eButtonColor.BlueWithBackground;
            m_Button.ButtonStyle = HVTTButtonStyle.ImageAndText;
            m_Button._FitContainer = true;
            m_Button.Style = HVTTControlStyle.Office2007;
            m_Button.SetOwner(this);
            m_Button.CheckedChanged += new EventHandler(OnCheckedChanged);
            m_ColorScheme = new ColorScheme(m_Button.Style);

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(DisplayHelp.DoubleBufferFlag, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.ContainerControl, false);

            this.SetStyle(ControlStyles.Selectable, true);
            base.SetStyle(ControlStyles.StandardDoubleClick | ControlStyles.StandardClick, false);
            this.IsAccessible = true;
            this.AccessibleRole = AccessibleRole.PushButton;
        }

        protected virtual ButtonItem CreateButtonItem()
        {
            return new ButtonItem();
        }

        private void OnCheckedChanged(object sender, EventArgs e)
        {
            if (CheckedChanged != null)
                CheckedChanged(this, e);
        }

        /// <summary>
        /// Creates new accessibility instance.
        /// </summary>
        /// <returns>Reference to AccessibleObject.</returns>
        protected override AccessibleObject CreateAccessibilityInstance()
        {
            return new HVTTButtonAccessibleObject(this);
        }

        /// <summary>
        /// Notifies the accessibility client applications of the specified AccessibleEvents for the specified child control.
        /// </summary>
        /// <param name="accEvent">The AccessibleEvents object to notify the accessibility client applications of. </param>
        /// <param name="childID">The child Control to notify of the accessible event.</param>
        internal void InternalAccessibilityNotifyClients(AccessibleEvents accEvent, int childID)
        {
            this.AccessibilityNotifyClients(accEvent, childID);
        }

        
        #endregion

        #region Internal Implementation
        /// <summary>
        /// Starts the button pulse effect which alternates slowly between the mouse over and the default state. The pulse effect
        /// continues indefinitely until it is stopped by call to StopPulse method.
        /// </summary>
        public void Pulse()
        {
            m_Button.Pulse();
        }

        /// <summary>
        /// Starts the button pulse effect which alternates slowly between the mouse over and the default state. Pulse effect
        /// will alternate between the pulse state for the number of times specified by the pulseBeatCount parameter.
        /// </summary>
        /// <param name="pulseBeatCount">Specifies the number of times button alternates between pulse states. 0 indicates indefinite pulse</param>
        public void Pulse(int pulseBeatCount)
        {
            m_Button.Pulse(pulseBeatCount);
        }

        /// <summary>
        /// Stops the button Pulse effect.
        /// </summary>
        public void StopPulse()
        {
            m_Button.StopPulse();
        }

        /// <summary>
        /// Gets whether the button is currently pulsing, alternating slowly between the mouse over and default state.
        /// </summary>
        [Browsable(false)]
        public bool IsPulsing
        {
            get { return m_Button.IsPulsing; }
        }

        /// <summary>
        /// Gets or sets whether pulse effect started with StartPulse method stops automatically when mouse moves over the button. Default value is true.
        /// </summary>
        [DefaultValue(true), Browsable(true), Category("Behavior"), Description("Indicates whether pulse effect started with Pulse method stops automatically when mouse moves over the button.")]
        public bool StopPulseOnMouseOver
        {
            get { return m_Button.StopPulseOnMouseOver; }
            set { m_Button.StopPulseOnMouseOver = value; }
        }

        /// <summary>
        /// Gets or sets the pulse speed. The value must be greater than 0 and less than 128. Higher values indicate faster pulse. Default value is 12.
        /// </summary>
        [Browsable(true), DefaultValue(12), Category("Behavior"), Description("Indicates pulse speed. The value must be greater than 0 and less than 128.")]
        public int PulseSpeed
        {
            get { return m_Button.PulseSpeed; }
            set
            {
                m_Button.PulseSpeed = value;
            }
        }

        /// <summary>
        /// Sets fixed size of the image. Image will be scaled and painted it size specified.
        /// </summary>
        [Browsable(true)]
        public System.Drawing.Size ImageFixedSize
        {
            get { return m_Button.ImageFixedSize; }
            set
            {
                m_Button.ImageFixedSize = value;
                this.RecalcLayout();
            }
        }
        /// <summary>
        /// Gets whether ImageFixedSize property should be serialized.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeImageFixedSize()
        {
            return m_Button.ShouldSerializeImageFixedSize();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            InvalidateAutoSize();
            this.RecalcLayout();
        }
        
        protected override void OnEnabledChanged(EventArgs e)
        {
            m_Button.Enabled = this.Enabled;
            base.OnEnabledChanged(e);
        }
        /// <summary>
        /// Gets or sets the text alignment. Applies only when button text is not composed using text markup. Default value is center.
        /// </summary>
        [Browsable(true), DefaultValue(eButtonTextAlignment.Center), Category("Appearance"), Description("Indicates text alignment. Applies only when button text is not composed using text markup. Default value is center.")]
        public eButtonTextAlignment TextAlignment
        {
            get { return m_TextAlignment; }
            set
            {
                m_TextAlignment = value;
                this.RecalcLayout();
            }
        }

        //private void PaintParentBackground(PaintEventArgs e)
        //{
        //    if (Parent != null)
        //    {
        //        Console.WriteLine(e.ClipRectangle);
        //        Rectangle rect = new Rectangle(Left, Top, Width, Height);
        //        e.Graphics.TranslateTransform(-rect.X, -rect.Y);
        //        try
        //        {
        //            using (PaintEventArgs pea = new PaintEventArgs(e.Graphics, rect))
        //            {
        //                pea.Graphics.SetClip(rect);
        //                InvokePaintBackground(Parent, pea);
        //                InvokePaint(Parent, pea);
        //            }
        //        }
        //        finally
        //        {
        //            e.Graphics.TranslateTransform(rect.X, rect.Y);
        //        }
        //    }
        //    else
        //    {
        //        e.Graphics.FillRectangle(SystemBrushes.Control, ClientRectangle);
        //    }
        //}
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (this.BackColor.IsEmpty || this.BackColor == Color.Transparent)
                {
                    //PaintParentBackground(e);
                    base.OnPaintBackground(e);
                }
                else
                {
                    DisplayHelp.FillRectangle(e.Graphics, this.ClientRectangle, this.BackColor, System.Drawing.Color.Empty);
                }

                Rectangle r = this.ClientRectangle;
                Graphics g = e.Graphics;

                ColorScheme cs = this.GetColorScheme();

                if (!IsThemed)
                {
                    if (BarFunctions.IsOffice2007Style(m_Button.Style))
                    {
                        //int cornerSize = this.CornerSize;
                        //SmoothingMode sm = g.SmoothingMode;
                        //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        //DisplayHelp.FillRoundedRectangle(g, r, cornerSize, cs.BarBackground, cs.BarBackground2, cs.BarBackgroundGradientAngle);
                        //DisplayHelp.DrawRoundedRectangle(g, cs.BarDockedBorder, r, cornerSize);
                        //g.SmoothingMode = sm;
                    }
                    //else if (BarFunctions.IsHVTTStyle2008(m_Button.Style))
                    //{
                    //    DisplayHelp.FillRectangle(g, r, cs.BarBackground, cs.BarBackground2, cs.BarBackgroundGradientAngle);
                    //    DisplayHelp.DrawRectangle(g, cs.BarDockedBorder, r);
                    //}
                    else
                    {
                        DisplayHelp.FillRectangle(g, r, cs.BarBackground, cs.BarBackground2, cs.BarBackgroundGradientAngle);
                        DisplayHelp.DrawRectangle(g, cs.BarDockedBorder, r);
                    }
                }

                SmoothingMode sm = g.SmoothingMode;
                TextRenderingHint th = g.TextRenderingHint;

                ItemPaintArgs pa = GetItemPaintArgs(g);

                if (m_AntiAlias)
                {
                    pa.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    pa.Graphics.TextRenderingHint = DisplayHelp.AntiAliasTextRenderingHint;
                }

                m_Button.Paint(pa);

                g.SmoothingMode = sm;
                g.TextRenderingHint = th;
            }
            catch { }
        }

        private ColorScheme GetColorScheme()
        {
            return m_ColorScheme;
        }

        protected override void OnResize(EventArgs e)
        {
            RecalcLayout();
            base.OnResize(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            m_Button.Text = this.Text;
            InvalidateAutoSize();

    

            this.RecalcLayout();
            base.OnTextChanged(e);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            if (this.ForeColor != SystemColors.ControlText)
                m_Button.ForeColor = this.ForeColor;
            else
                m_Button.ForeColor = Color.Empty;

            base.OnForeColorChanged(e);
        }

        /// <summary>
        /// Forces the button to perform internal layout.
        /// </summary>
        public void RecalcLayout()
        {
            RecalcSize();
            this.Invalidate();
        }

        private void RecalcSize()
        {
            m_Button.Bounds = this.ClientRectangle;
            m_Button.RecalcSize();
            m_Button.Bounds = this.ClientRectangle;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space && !m_Button.Expanded)
            {
                if (m_Button.GetShouldAutoExpandOnClick())
                    m_Button.Expanded = true;
                else
                    m_Button.SetMouseDown(true);
                this.Invalidate();
            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !m_Button.Expanded)
            {
                m_Button.SetMouseDown(false);
                this.Invalidate();
                PerformClick();
            }
            base.OnKeyUp(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            m_Button.InternalMouseEnter();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            m_Button.InternalMouseMove(e);
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            m_Button.InternalMouseLeave();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            m_Button.InternalMouseHover();
            base.OnMouseHover(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!this.Focused)
                {
                    this.Focus();
                }
            }

            m_Button.InternalMouseDown(e);
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            m_Button.InternalMouseUp(e);
            if (e.Button == MouseButtons.Left && this.ClientRectangle.Contains(e.X, e.Y))
            {
                this.OnClick(e);

                this.OnMouseClick(e);

            }
            base.OnMouseUp(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if(m_Button.IsMouseOver)
                m_Button.InternalMouseLeave();

            base.OnVisibleChanged(e);
        }

        protected override void OnClick(EventArgs e)
        {
            // Ignore Click event if it is fired when click occurred on sub items rectangle...
            if (!m_Button.SubItemsRect.IsEmpty)
            {
                Point p = this.PointToClient(Control.MousePosition);
                if (m_Button.SubItemsRect.Contains(p))
                    return;
            }
            
            if (this.SplitButton && !m_Button.TextDrawRect.IsEmpty)
            {
                Point p = this.PointToClient(Control.MousePosition);
                if (m_Button.TextDrawRect.Contains(p))
                    return;
            }

            Form form1 = this.FindForm();
            if (form1 != null)
            {
                form1.DialogResult = this.DialogResult;
            }
            
            base.OnClick(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            m_Button.OnGotFocus();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            m_Button.OnLostFocus();
            base.OnLostFocus(e);
        }

        internal void SetDesignMode(bool value)
        {
            m_Button.SetDesignMode(value);
        }

        /// <summary>
        /// Gets/Sets the visual style for the button.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), Category("Appearance"), Description("Specifies the visual style of the button."), DefaultValue(HVTTControlStyle.Office2007)]
        public HVTTControlStyle Style
        {
            get
            {
                return m_Button.Style;
            }
            set
            {
                this.GetColorScheme().Style = value;
                m_Button.Style = value;
                this.RecalcLayout();
            }
        }

        /// <summary>
        /// Specifies the Button image.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), Category("Appearance"), Description("The image that will be displayed on the face of the button."), DefaultValue(null)]
        public System.Drawing.Image Image
        {
            get { return m_Button.Image; }
            set
            {
                m_Button.Image = value;
                InvalidateAutoSize();

            }
        }

        /// <summary>
        /// Specifies the image for the button when mouse is over the item.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), Category("Appearance"), Description("The image that will be displayed when mouse hovers over the item."), DefaultValue(null)]
        public System.Drawing.Image HoverImage
        {
            get { return m_Button.HoverImage; }
            set { m_Button.HoverImage = value; }
        }

        /// <summary>
        /// Specifies the image for the button when items Enabled property is set to false.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), Category("Appearance"), Description("The image that will be displayed when item is disabled."),DefaultValue(null)]
        public System.Drawing.Image DisabledImage
        {
            get { return m_Button.DisabledImage; }
            set { m_Button.DisabledImage = value; }
        }

        /// <summary>
        /// Specifies the image for the button when mouse left button is pressed.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), Category("Appearance"), Description("The image that will be displayed when item is pressed."), DefaultValue(null)]
        public System.Drawing.Image PressedImage
        {
            get { return m_Button.PressedImage; }
            set { m_Button.PressedImage = value; }
        }

        /// <summary>
        /// Gets or sets the location of popup in relation to it's parent.
        /// </summary>
        [Browsable(true), HVTTBrowsable(false), DefaultValue(PopupSide.Default), Description("Indicates location of popup in relation to it's parent.")]
        public PopupSide PopupSide
        {
            get { return m_Button.PopupSide; }
            set { m_Button.PopupSide = value; InvalidateAutoSize(); }
        }

        /// <summary>
        /// Returns the collection of sub items.
        /// </summary>
        [Browsable(true), HVTTBrowsable(false), Editor(typeof(ButtonItemEditor), typeof(System.Drawing.Design.UITypeEditor)), Category("Data"), Description("Collection of sub items."), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual SubItemsCollection SubItems
        {
            get
            {
                return m_Button.SubItems;
            }
        }

        /// <summary>
        /// Gets or sets whether button appears as split button. Split button appearance divides button into two parts. Image which raises the click event
        /// when clicked and text and expand sign which shows button sub items on popup menu when clicked. Button must have both text and image visible (ButtonStyle property) in order to appear as a full split button.
        /// </summary>
        [Browsable(true), DefaultValue(false), Category("Appearance"), Description("Indicates whether button appears as split button.")]
        public bool SplitButton
        {
            get { return m_Button.SplitButton; }
            set { m_Button.SplitButton = value; InvalidateAutoSize(); }
        }

        /// <summary>
        /// Gets or sets whether button displays the expand part that indicates that button has popup.
        /// </summary>
        [System.ComponentModel.Browsable(true), HVTTBrowsable(true), System.ComponentModel.DefaultValue(true), System.ComponentModel.Category("Behavior"), System.ComponentModel.Description("Determines whether sub-items are displayed.")]
        public bool ShowSubItems
        {
            get
            {
                return m_Button.ShowSubItems;
            }
            set
            {
                m_Button.ShowSubItems = value;
            }
        }
        

        /// <summary>
        /// Gets/Sets the image position inside the button.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), Category("Appearance"), Description("The alignment of the image in relation to text displayed by this item."), DefaultValue(ImagePosition.Left)]
        public ImagePosition ImagePosition
        {
            get { return m_Button.ImagePosition; }
            set
            {
                m_Button.ImagePosition = value;
                InvalidateAutoSize();
                this.RecalcLayout();
            }
        }

        /// <summary>
        /// Gets or sets whether mouse over fade effect is enabled. Default value is true.
        /// </summary>
        [Browsable(true), DefaultValue(true), Category("Appearance"), Description("Indicates whether mouse over fade effect is enabled")]
        public bool FadeEffect
        {
            get { return m_FadeEffect; }
            set
            {
                m_FadeEffect = value;
            }
        }

        internal bool IsFadeEnabled
        {
            get
            {
                if (this.DesignMode || (m_Button.Style!=HVTTControlStyle.Office2007) || m_FadeEffect && NativeFunctions.IsTerminalSession() || IsThemed)
                    return false;
                return m_FadeEffect;
            }
        }

        /// <summary>
        /// Indicates the way button is rendering the mouse over state. Setting the value to Color will render the image in gray-scale when mouse is not over the item.
        /// </summary>
        [System.ComponentModel.Browsable(true), HVTTBrowsable(true), System.ComponentModel.Category("Appearance"), System.ComponentModel.Description("Indicates the button mouse over tracking style. Setting the value to Color will render the image in gray-scale when mouse is not over the item."), System.ComponentModel.DefaultValue(HotTrackingStyle.Default)]
        public virtual HotTrackingStyle HotTrackingStyle
        {
            get { return m_Button.HotTrackingStyle; }
            set
            {
                m_Button.HotTrackingStyle = value;
            }
        }

        /// <summary>
        /// Creates the Graphics object for the control.
        /// </summary>
        /// <returns>The Graphics object for the control.</returns>
        public new Graphics CreateGraphics()
        {
            Graphics g = base.CreateGraphics();
            if (m_AntiAlias)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
		
                if (!SystemInformation.IsFontSmoothingEnabled)
               
                    g.TextRenderingHint = DisplayHelp.AntiAliasTextRenderingHint;
            }
            return g;
        }

        internal ItemPaintArgs GetItemPaintArgs(Graphics g)
        {
            ItemPaintArgs pa = new ItemPaintArgs(this, this, g, m_ColorScheme);
            pa.Renderer = this.GetRenderer();
            pa.ButtonStringFormat = pa.ButtonStringFormat & ~(pa.ButtonStringFormat & eTextFormat.SingleLine);
            pa.ButtonStringFormat |= (eTextFormat.WordBreak | eTextFormat.EndEllipsis);
            pa.IsDefaultButton = m_IsDefault;
            return pa;
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
            {
                if (this.Style == HVTTControlStyle.Office2007)
                    m_DefaultRenderer = new Rendering.Office2007Renderer();
                //else
                //    m_DefaultRenderer = new Rendering.Office12Renderer();
            }

            return m_Renderer;
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
        /// Gets or sets whether anti-alias smoothing is used while painting. Default value is false.
        /// </summary>
        [DefaultValue(false), Browsable(true), Category("Appearance"), Description("Gets or sets whether anti-aliasing is used while painting.")]
        public bool AntiAlias
        {
            get { return m_AntiAlias; }
            set
            {
                if (m_AntiAlias != value)
                {
                    m_AntiAlias = value;
                    InvalidateAutoSize();
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the expand part of the button item.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), Category("Behavior"), Description("Indicates the width of the expand part of the button item."), DefaultValue(12)]
        public virtual int SubItemsExpandWidth
        {
            get { return m_Button.SubItemsExpandWidth; }
            set
            {
                m_Button.SubItemsExpandWidth = value;
                this.RecalcLayout();
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this button.
        /// </summary>
        [Browsable(true), Editor(typeof(Design.TextMarkupUIEditor), typeof(System.Drawing.Design.UITypeEditor)), Category("Appearance"), Description("Indicates text associated with this button.."), Localizable(true), DefaultValue("")]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        /// <summary>
        /// Gets/Sets informational text (tooltip) for the button.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), DefaultValue(""), Editor(typeof(Design.TextMarkupUIEditor), typeof(System.Drawing.Design.UITypeEditor)), Category("Appearance"), Description("Indicates informational text (tooltip) for the button."), Localizable(true)]
        public virtual string Tooltip
        {
            get { return m_Button.Tooltip; }
            set { m_Button.Tooltip = value; }
        }

        /// <summary>
        /// Gets or sets button Color Scheme. ColorScheme does not apply to Office2007 styled buttons.
        /// </summary>
        [Browsable(false), HVTTBrowsable(false), Category("Appearance"), Description("Gets or sets Bar Color Scheme."), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorScheme ColorScheme
        {
            get { return m_ColorScheme; }
            set
            {
                if (value == null)
                    throw new ArgumentException("NULL is not a valid value for this property.");
                m_ColorScheme = value;
                if (this.Visible)
                    this.Invalidate();
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        private bool ShouldSerializeColorScheme()
        {
            return m_ColorScheme.SchemeChanged;
        }

        protected override bool ProcessMnemonic(char charCode)
        {
            if (IsMnemonic(charCode, this.Text) && this.Enabled)
            {
                if (Focus())
                {
                    PerformClick();
                    return true;
                }
            }
            return base.ProcessMnemonic(charCode);
        }

        /// <summary>
        /// Indicates whether the button will auto-expand when clicked. 
        /// When button contains sub-items, sub-items will be shown only if user
        /// click the expand part of the button. Setting this propert to true will expand the button and show sub-items when user
        /// clicks anywhere inside of the button. Default value is false which indicates that button is expanded only
        /// if its expand part is clicked.
        /// </summary>
        [DefaultValue(false), Browsable(true), HVTTBrowsable(true), Category("Behavior"), Description("Indicates whether the button will auto-expand (display pop-up menu or toolbar) when clicked.")]
        public virtual bool AutoExpandOnClick
        {
            get { return m_Button.AutoExpandOnClick; }
            set
            {
                m_Button.AutoExpandOnClick = value;
                this.RecalcLayout();
            }
        }

        /// <summary>
        /// Gets or sets whether Checked property is automatically inverted, button checked/unchecked, when button is clicked. Default value is false.
        /// </summary>
        [Browsable(true), DefaultValue(false), Category("Behavior"), Description("Indicates whether Checked property is automatically inverted when button is clicked.")]
        public bool AutoCheckOnClick
        {
            get { return m_Button.AutoCheckOnClick; }
            set { m_Button.AutoCheckOnClick = value; }
        }

        /// <summary>
        /// Specifies whether button is drawn using Windows Themes when running on OS that supports themes like Windows XP.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), DefaultValue(false), Category("Appearance"), Description("Specifies whether button is drawn using Themes when running on OS that supports themes like Windows XP.")]
        public virtual bool ThemeAware
        {
            get { return m_Button.ThemeAware; }
            set
            {
                m_Button.ThemeAware = value;
                this.RecalcLayout();
            }
        }

        /// <summary>
        /// Gets whether Windows Themes should be used to draw the button.
        /// </summary>
        protected bool IsThemed
        {
            get
            {
                if (ThemeAware && m_Button.Style != HVTTControlStyle.Office2000 && BarFunctions.ThemedOS && Themes.ThemesActive)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Gets or set a value indicating whether the button is in the checked state.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), Category("Appearance"), Description("Indicates whether item is checked or not."), DefaultValue(false)]
        public virtual bool Checked
        {
            get
            {
                return m_Button.Checked;
            }
            set
            {
                m_Button.Checked = value;
                this.Invalidate();
            }
        }

        internal int CornerSize
        {
            get { return 2; }
        }

        internal BaseItem InternalItem
        {
            get { return m_Button; }
        }

        /// <summary>
        /// Gets or sets the custom color name. Name specified here must be represented by the coresponding object with the same name that is part
        /// of the Office2007ColorTable.ButtonItemColors collection. See documentation for Office2007ColorTable.ButtonItemColors for more information.
        /// If color table with specified name cannot be found default color will be used. Valid settings for this property override any
        /// setting to the Color property.
        /// Applies to items with Office 2007 style only.
        /// </summary>
        [Browsable(true), HVTTBrowsable(false), DefaultValue(""), Category("Appearance"), Description("Indicates custom color table name for the button when Office 2007 style is used.")]
        public string CustomColorName
        {
            get { return m_Button.CustomColorName; }
            set
            {
                m_Button.CustomColorName = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the predefined color of the button. Color specified applies to buttons with Office 2007 style only. It does not have
        /// any effect on other styles. Default value is eButtonColor.Default
        /// </summary>
        [Browsable(true), HVTTBrowsable(false), DefaultValue(eButtonColor.BlueWithBackground), Category("Appearance"), Description("Indicates predefined color of button when Office 2007 style is used.")]
        public eButtonColor ColorTable
        {
            get { return m_Button.ColorTable; }
            set
            {
                if (m_Button.ColorTable != value)
                {
                    m_Button.ColorTable = value;
                    this.Invalidate();
                }
            }
        }
        private void InvalidateAutoSize()
        {
            m_PreferedSize = Size.Empty;
        }


        [Localizable(true), Browsable(false)]
        public new System.Windows.Forms.Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            if (!m_PreferedSize.IsEmpty) return m_PreferedSize;

            if (!BarFunctions.IsHandleValid(this))
                return base.GetPreferredSize(proposedSize);
            if (this.Text.Length == 0 && this.Image == null)
                return base.GetPreferredSize(proposedSize);

            int oldWidth = m_Button.WidthInternal, oldHeight = m_Button.HeightInternal;

            m_Button._FitContainer = false;
            m_Button.RecalcSize();

            Size s = m_Button.Size;
            if (s.Width < this.MinimumSize.Width)
                s.Width = this.MinimumSize.Width;
            if (s.Height < this.MinimumSize.Height)
                s.Height = this.MinimumSize.Height;

            if (m_AutoSizeMode == AutoSizeMode.GrowOnly)
            {
                if (s.Width < this.Size.Width)
                    s.Width = this.Size.Width;
                if (s.Height < this.Size.Height)
                    s.Height = this.Size.Height;

                if (proposedSize.Width > 0 && proposedSize.Width < 50000 && s.Width < proposedSize.Width)
                    s.Width = proposedSize.Width;
                if (proposedSize.Height > 0 && proposedSize.Height < 50000 && s.Height < proposedSize.Height)
                    s.Height = proposedSize.Height;
                    
            }
            m_Button._FitContainer = true;
            RecalcSize();
            m_PreferedSize = s;
            return m_PreferedSize;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control is automatically resized to display its entire contents. You can set MaximumSize.Width property to set the maximum width used by the control.
        /// </summary>
        [Browsable(true), DefaultValue(false), EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                if (this.AutoSize != value)
                {
                    base.AutoSize = value;
                    InvalidateAutoSize();
                    AdjustSize();
                }
            }
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (this.AutoSize)
            {
                Size preferredSize = base.PreferredSize;
                if(preferredSize.Width>0)
                    width = preferredSize.Width;
                if (preferredSize.Height > 0)
                    height = preferredSize.Height;
            }
            base.SetBoundsCore(x, y, width, height, specified);
        }

        private void AdjustSize()
        {
            if (this.AutoSize)
            {
                System.Drawing.Size prefSize = base.PreferredSize;
                if(prefSize.Width>0 && prefSize.Height>0)
                    this.Size = base.PreferredSize;
            }
        }

        private AutoSizeMode m_AutoSizeMode = AutoSizeMode.GrowOnly;
        /// <summary>
        /// Gets or sets the mode by which the Button automatically resizes itself. 
        /// </summary>
        [LocalizableAttribute(true), Browsable(true), DefaultValue(AutoSizeMode.GrowOnly), Category("Layout"), Description("Indicates the mode by which the Button automatically resizes itself. ")]
        public AutoSizeMode AutoSizeMode
        {
            get { return m_AutoSizeMode; }
            set
            {
                if (m_AutoSizeMode != value)
                {
                    m_AutoSizeMode = value;
                    InvalidateAutoSize();
                    AdjustSize();
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; }
        }

        #endregion

        #region IOwnerMenuSupport Implementation
        private bool GetDesignMode()
        {
            return this.DesignMode;
        }
        private Hook m_Hook = null;
        // IOwnerMenuSupport
        private ArrayList m_RegisteredPopups = new ArrayList();
        bool IOwnerMenuSupport.PersonalizedAllVisible { get { return false; } set { } }
        bool IOwnerMenuSupport.ShowFullMenusOnHover { get { return true; } set { } }
        bool IOwnerMenuSupport.AlwaysShowFullMenus { get { return false; } set { } }

        void IOwnerMenuSupport.RegisterPopup(PopupItem objPopup)
        {
            this.MenuFocus = true;

            if (m_RegisteredPopups.Contains(objPopup))
                return;

            if (!this.GetDesignMode())
            {
                if (!m_FilterInstalled)
                {
                    MessageHandler.RegisterMessageClient(this);
                    m_FilterInstalled = true;
                }
            }
            else
            {
                if (m_Hook == null)
                {
                    m_Hook = new Hook(this);
                }
            }

            if (!m_MenuEventSupport)
                MenuEventSupportHook();

            m_RegisteredPopups.Add(objPopup);
            if (objPopup.GetOwner() != this)
                objPopup.SetOwner(this);
        }
        void IOwnerMenuSupport.UnregisterPopup(PopupItem objPopup)
        {
            if (m_RegisteredPopups.Contains(objPopup))
                m_RegisteredPopups.Remove(objPopup);
            if (m_RegisteredPopups.Count == 0)
            {
                MenuEventSupportUnhook();
                if (m_Hook != null)
                {
                    m_Hook.Dispose();
                    m_Hook = null;
                }
                this.MenuFocus = false;
            }
        }
        bool IOwnerMenuSupport.RelayMouseHover()
        {
            foreach (PopupItem popup in m_RegisteredPopups)
            {
                Control ctrl = popup.PopupControl;
                if (ctrl != null && ctrl.DisplayRectangle.Contains(MousePosition))
                {
                    if (ctrl is MenuPanel)
                        ((MenuPanel)ctrl).InternalMouseHover();
                    else if (ctrl is HVTTMarkStatus)
                        ((HVTTMarkStatus)ctrl).InternalMouseHover();
                    return true;
                }
            }
            return false;
        }

        void IOwnerMenuSupport.ClosePopups()
        {
            ClosePopups();
        }

        private void ClosePopups()
        {
            ArrayList popupList = new ArrayList(m_RegisteredPopups);
            foreach (PopupItem objPopup in popupList)
                objPopup.ClosePopup();
        }

        // Events
        void IOwnerMenuSupport.InvokePopupClose(PopupItem item, EventArgs e)
        {
            if (PopupClose != null)
                PopupClose(item, e);
        }
        void IOwnerMenuSupport.InvokePopupContainerLoad(PopupItem item, EventArgs e)
        {
            if (PopupContainerLoad != null)
                PopupContainerLoad(item, e);
        }
        void IOwnerMenuSupport.InvokePopupContainerUnload(PopupItem item, EventArgs e)
        {
            if (PopupContainerUnload != null)
                PopupContainerUnload(item, e);
        }
        void IOwnerMenuSupport.InvokePopupOpen(PopupItem item, PopupOpenEventArgs e)
        {
            if (PopupOpen != null)
                PopupOpen(item, e);
        }
        void IOwnerMenuSupport.InvokePopupShowing(PopupItem item, EventArgs e)
        {
            if (PopupShowing != null)
                PopupShowing(item, e);
        }
        bool IOwnerMenuSupport.ShowPopupShadow { get { return true; } }
        HVTTMenuDropShadow IOwnerMenuSupport.MenuDropShadow { get { return HVTTMenuDropShadow.SystemDefault; } set { } }
        HVTTPopupAnimation IOwnerMenuSupport.PopupAnimation { get { return HVTTPopupAnimation.SystemDefault; } set { } }
        bool IOwnerMenuSupport.AlphaBlendShadow { get { return true; } set { } }

        internal bool MenuFocus
        {
            get
            {
                return m_MenuFocus;
            }
            set
            {
                if (m_MenuFocus != value)
                {
                    m_MenuFocus = value;
                    if (m_MenuFocus)
                    {
                        SetupActiveWindowTimer();
                    }
                    else
                    {
                        ReleaseActiveWindowTimer();
                        ClosePopups();
                    }
                    this.Invalidate();
                }
            }
        }
        #endregion

        #region Active Window Changed Handling
        /// <summary>
        /// Sets up timer that watches when active window changes.
        /// </summary>
        protected virtual void SetupActiveWindowTimer()
        {
            if (m_ActiveWindowTimer != null)
                return;
            m_ActiveWindowTimer = new Timer();
            m_ActiveWindowTimer.Interval = 100;
            m_ActiveWindowTimer.Tick += new EventHandler(ActiveWindowTimer_Tick);

            m_ForegroundWindow = NativeFunctions.GetForegroundWindow();
            m_ActiveWindow = NativeFunctions.GetActiveWindow();

            m_ActiveWindowTimer.Start();
        }

        private void ActiveWindowTimer_Tick(object sender, EventArgs e)
        {
            if (m_ActiveWindowTimer == null)
                return;

            IntPtr f = NativeFunctions.GetForegroundWindow();
            IntPtr a = NativeFunctions.GetActiveWindow();

            if (f != m_ForegroundWindow || a != m_ActiveWindow)
            {
                Control c = Control.FromChildHandle(a);
                if (c != null)
                {
                    do
                    {
                        if ((c is MenuPanel || c is HVTTMarkStatus || c is PopupContainer || c is PopupContainerControl))
                            return;
                        c = c.Parent;
                    } while (c!=null && c.Parent != null);
                }
                m_ActiveWindowTimer.Stop();
                OnActiveWindowChanged();
            }
        }

        /// <summary>
        /// Called after change of active window has been detected. SetupActiveWindowTimer must be called to enable detection.
        /// </summary>
        protected virtual void OnActiveWindowChanged()
        {
            if (this.MenuFocus)
                this.MenuFocus = false;
        }

        /// <summary>
        /// Releases and disposes the active window watcher timer.
        /// </summary>
        protected virtual void ReleaseActiveWindowTimer()
        {
            if (m_ActiveWindowTimer != null)
            {
                Timer timer = m_ActiveWindowTimer;
                m_ActiveWindowTimer = null;
                timer.Stop();
                timer.Tick -= new EventHandler(ActiveWindowTimer_Tick);
                timer.Dispose();
            }
        }
        #endregion

        #region IMessageHandlerClient Implementation
        bool IMessageHandlerClient.IsModal
        {
            get
            {
                Form form = this.FindForm();
                if (form != null && form.Modal && Form.ActiveForm == form)
                    return true;
                return false;
            }
        }

        bool IMessageHandlerClient.OnMouseWheel(IntPtr hWnd, IntPtr wParam, IntPtr lParam)
        {
            return OnMouseWheel(hWnd, wParam, lParam);
        }

        protected virtual bool OnMouseWheel(IntPtr hWnd, IntPtr wParam, IntPtr lParam)
        {
            return false;
        }

        bool IMessageHandlerClient.OnKeyDown(IntPtr hWnd, IntPtr wParam, IntPtr lParam)
        {
            return OnKeyDown(hWnd, wParam, lParam);
        }

        protected virtual bool OnKeyDown(IntPtr hWnd, IntPtr wParam, IntPtr lParam)
        {
            if (m_RegisteredPopups.Count > 0)
            {
                if (((BaseItem)m_RegisteredPopups[m_RegisteredPopups.Count - 1]).Parent == null)
                {
                    PopupItem objItem = (PopupItem)m_RegisteredPopups[m_RegisteredPopups.Count - 1];

                    Control ctrl = objItem.PopupControl as Control;
                    Control ctrl2 = FromChildHandle(hWnd);

                    if (ctrl2 != null)
                    {
                        while (ctrl2.Parent != null)
                            ctrl2 = ctrl2.Parent;
                    }

                    bool bIsOnHandle = false;
                    if (ctrl2 != null && objItem != null)
                        bIsOnHandle = objItem.IsAnyOnHandle(ctrl2.Handle.ToInt32());

                    bool bNoEat = ctrl != null && ctrl2 != null && ctrl.Handle == ctrl2.Handle || bIsOnHandle;

                    if (!bIsOnHandle)
                    {
                        Keys key = (Keys)NativeFunctions.MapVirtualKey((uint)wParam, 2);
                        if (key == Keys.None)
                            key = (Keys)wParam.ToInt32();
                        objItem.InternalKeyDown(new KeyEventArgs(key));
                    }

                    // Don't eat the message if the pop-up window has focus
                    if (bNoEat)
                        return false;
                    return true;
                }
            }

            if (this.MenuFocus)
            {
                bool bPassToMenu = true;
                Control ctrl2 = Control.FromChildHandle(hWnd);
                if (ctrl2 != null)
                {
                    while (ctrl2.Parent != null)
                        ctrl2 = ctrl2.Parent;
                    if ((ctrl2 is MenuPanel || ctrl2 is ItemControl || ctrl2 is PopupContainer || ctrl2 is PopupContainerControl) && ctrl2.Handle != hWnd)
                        bPassToMenu = false;
                }

                if (bPassToMenu)
                {
                    Keys key = (Keys)NativeFunctions.MapVirtualKey((uint)wParam, 2);
                    if (key == Keys.None)
                        key = (Keys)wParam.ToInt32();
                    m_Button.InternalKeyDown(new KeyEventArgs(key));
                    return true;
                }
            }

            if (!this.IsParentFormActive)
                return false;

            if (wParam.ToInt32() >= 0x70 || ModifierKeys != Keys.None || (lParam.ToInt32() & 0x1000000000) != 0 || wParam.ToInt32() == 0x2E || wParam.ToInt32() == 0x2D) // 2E=VK_DELETE, 2D=VK_INSERT
            {
                int i = (int)ModifierKeys | wParam.ToInt32();
                return ProcessShortcut((eShortcut)i);
            }
            return false;
        }

        private bool ProcessShortcut(eShortcut key)
        {
            foreach (eShortcut k in m_Button.Shortcuts)
            {
                if (k == key)
                {
                    PerformClick();
                    return true;
                }
            }
            return BarFunctions.ProcessItemsShortcuts(key, m_ShortcutTable);
        }
        protected bool IsParentFormActive
        {
            get
            {
                // Process only if parent form is active
                Form form = this.FindForm();
                if (form == null)
                    return false;
                if (form.IsMdiChild)
                {
                    if (form.MdiParent == null)
                        return false;
                    if (form.MdiParent.ActiveMdiChild != form)
                        return false;
                }
                else if (form != Form.ActiveForm)
                    return false;
                return true;
            }
        }

        private Design.PopupDelayedClose m_DelayClose = null;
        private Design.PopupDelayedClose GetDelayClose()
        {
            if (m_DelayClose == null)
                m_DelayClose = new Design.PopupDelayedClose();
            return m_DelayClose;
        }

        internal void DesignerNewItemAdded()
        {
            this.GetDelayClose().EraseDelayClose();
        }

        bool IMessageHandlerClient.OnMouseDown(IntPtr hWnd, IntPtr wParam, IntPtr lParam)
        {
            if (m_RegisteredPopups.Count == 0)
                return false;

            BaseItem[] popups = new BaseItem[m_RegisteredPopups.Count];
            m_RegisteredPopups.CopyTo(popups);
            for (int i = popups.Length - 1; i >= 0; i--)
            {
                PopupItem objPopup = popups[i] as PopupItem;
                bool bChildHandle = objPopup.IsAnyOnHandle(hWnd.ToInt32());

                if (!bChildHandle)
                {
                    System.Windows.Forms.Control cTmp = System.Windows.Forms.Control.FromChildHandle(hWnd);
                    if (cTmp != null)
                    {
                        while (cTmp.Parent != null)
                        {
                            cTmp = cTmp.Parent;
                            if (cTmp.GetType().FullName.IndexOf("DropDownHolder") >= 0 || cTmp is MenuPanel || cTmp is PopupContainerControl)
                            {
                                bChildHandle = true;
                                break;
                            }
                        }
                        if (!bChildHandle)
                            bChildHandle = objPopup.IsAnyOnHandle(cTmp.Handle.ToInt32());
                    }
                    else
                    {
                        string s = NativeFunctions.GetClassName(hWnd);
                        s = s.ToLower();
                        if (s.IndexOf("combolbox") >= 0)
                            bChildHandle = true;
                    }
                }

                if (!bChildHandle)
                {
                    Control popupContainer = objPopup.PopupControl;
                    if (popupContainer != null)
                        while (popupContainer.Parent != null) popupContainer = popupContainer.Parent;
                    if (popupContainer != null && popupContainer.Bounds.Contains(Control.MousePosition))
                        bChildHandle = true;
                }

                if (bChildHandle)
                    break;

                if (objPopup.Displayed)
                {
                    // Do not close if mouse is inside the popup parent button
                    Point p = this.PointToClient(MousePosition);
                    if (objPopup.DisplayRectangle.Contains(p))
                        break;
                }

                if (this.GetDesignMode())
                {
                    this.GetDelayClose().DelayClose(objPopup);
                }
                else
                    objPopup.ClosePopup();

                if (m_RegisteredPopups.Count == 0)
                    break;
            }
            if (m_RegisteredPopups.Count == 0)
                this.MenuFocus = false;
            return false;
        }
        bool IMessageHandlerClient.OnMouseMove(IntPtr hWnd, IntPtr wParam, IntPtr lParam)
        {
            if (m_RegisteredPopups.Count > 0)
            {
                foreach (BaseItem item in m_RegisteredPopups)
                {
                    if (item.Parent == null)
                    {
                        Control ctrl = ((PopupItem)item).PopupControl;
                        if (ctrl != null && ctrl.Handle != hWnd && !item.IsAnyOnHandle(hWnd.ToInt32()) && !(ctrl.Parent != null && ctrl.Parent.Handle != hWnd))
                            return true;
                    }
                }
            }
            return false;
        }
        bool IMessageHandlerClient.OnSysKeyDown(IntPtr hWnd, IntPtr wParam, IntPtr lParam)
        {
            return OnSysKeyDown(hWnd, wParam, lParam);
        }

        protected virtual bool OnSysKeyDown(IntPtr hWnd, IntPtr wParam, IntPtr lParam)
        {
            if (!this.GetDesignMode())
            {
                // Check Shortcuts
                if (ModifierKeys != Keys.None || wParam.ToInt32() >= (int)eShortcut.F1 && wParam.ToInt32() <= (int)eShortcut.F12)
                {
                    int i = (int)ModifierKeys | wParam.ToInt32();
                    if (ProcessShortcut((eShortcut)i))
                        return true;
                }
            }
            return false;
        }

        bool IMessageHandlerClient.OnSysKeyUp(IntPtr hWnd, IntPtr wParam, IntPtr lParam)
        {
            return OnSysKeyUp(hWnd, wParam, lParam);
        }

        protected virtual bool OnSysKeyUp(IntPtr hWnd, IntPtr wParam, IntPtr lParam)
        {
            return false;
        }

        private void MenuEventSupportHook()
        {
            if (m_MenuEventSupport)
                return;
            m_MenuEventSupport = true;

            Form parentForm = this.FindForm();
            if (parentForm == null)
            {
                m_MenuEventSupport = false;
                return;
            }

            parentForm.Resize += new EventHandler(this.ParentResize);
            parentForm.Deactivate += new EventHandler(this.ParentDeactivate);

            HVTTManager.RegisterParentMsgHandler(this, parentForm);
        }

        private void MenuEventSupportUnhook()
        {
            if (!m_MenuEventSupport)
                return;
            m_MenuEventSupport = false;

            Form parentForm = this.FindForm();
            if (parentForm == null)
                return;
            HVTTManager.UnRegisterParentMsgHandler(this, parentForm);
            parentForm.Resize -= new EventHandler(this.ParentResize);
            parentForm.Deactivate -= new EventHandler(this.ParentDeactivate);
        }
        private void ParentResize(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm != null && parentForm.WindowState == FormWindowState.Minimized)
                ((IOwner)this).OnApplicationDeactivate();
        }
        private void ParentDeactivate(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm != null && parentForm.WindowState == FormWindowState.Minimized)
                ((IOwner)this).OnApplicationDeactivate();
        }
        #endregion

        #region IButtonControl Members
        /// <summary>
        /// Gets or sets the value returned to the parent form when the button is clicked.
        /// </summary>
        [Browsable(true), Category("Behavior"), DefaultValue(DialogResult.None), Description("Gets or sets the value returned to the parent form when the button is clicked.")]
        public DialogResult DialogResult
        {
            get
            {
                return m_DialogResult;
            }

            set
            {
                if (Enum.IsDefined(typeof(DialogResult), value))
                {
                    m_DialogResult = value;
                }
            }
        }

        public String Value
        {
            get
            {
                return m_sValue;
            }
            set
            {
                m_sValue = value;
            }
        }

        /// <summary>
        /// Notifies a control that it is the default button so that its appearance and behavior is adjusted accordingly.
        /// </summary>
        /// <param name="value">true if the control should behave as a default button; otherwise false.</param>
        public void NotifyDefault(bool value)
        {
            if (m_IsDefault != value)
            {
                m_IsDefault = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Generates a Click event for the control.
        /// </summary>
        public virtual void PerformClick()
        {
            if (!this.Enabled) return;

            Form form1 = this.FindForm();
            if (form1 != null)
            {
                form1.DialogResult = this.DialogResult;
            }
            if (this.AutoCheckOnClick) this.Checked = !this.Checked;

            // Must call base since this class overrides OnClick to prevent it from firing when sub-items rect is clicked
            base.OnClick(EventArgs.Empty);
        }
        #endregion

        #region IThemeCache Implementation
        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == NativeFunctions.WM_THEMECHANGED)
                {
                    this.RefreshThemes();
                }
                else if (m.Msg == NativeFunctions.WM_USER + 107)
                {
                    if (m_DoDefaultActionItem != null)
                    {
                        if (!m_DoDefaultActionItem._AccessibleExpandAction)
                            this.PerformClick();
                        m_DoDefaultActionItem.DoAccesibleDefaultAction();
                        m_DoDefaultActionItem = null;
                    }
                }
                base.WndProc(ref m);
            }
            catch { }
        }
        protected void RefreshThemes()
        {
            if (m_ThemeWindow != null)
            {
                m_ThemeWindow.Dispose();
                m_ThemeWindow = new ThemeWindow(this);
            }
            if (m_ThemeRebar != null)
            {
                m_ThemeRebar.Dispose();
                m_ThemeRebar = new ThemeRebar(this);
            }
            if (m_ThemeToolbar != null)
            {
                m_ThemeToolbar.Dispose();
                m_ThemeToolbar = new ThemeToolbar(this);
            }
            if (m_ThemeHeader != null)
            {
                m_ThemeHeader.Dispose();
                m_ThemeHeader = new ThemeHeader(this);
            }
            if (m_ThemeScrollBar != null)
            {
                m_ThemeScrollBar.Dispose();
                m_ThemeScrollBar = new ThemeScrollBar(this);
            }
            if (m_ThemeProgress != null)
            {
                m_ThemeProgress.Dispose();
                m_ThemeProgress = new ThemeProgress(this);
            }
            if (m_ThemeExplorerBar != null)
            {
                m_ThemeExplorerBar.Dispose();
                m_ThemeExplorerBar = new ThemeExplorerBar(this);
            }
            if (m_ThemeButton != null)
            {
                m_ThemeButton.Dispose();
                m_ThemeButton = new ThemeButton(this);
            }
        }
        private void DisposeThemes()
        {
            if (m_ThemeWindow != null)
            {
                m_ThemeWindow.Dispose();
                m_ThemeWindow = null;
            }
            if (m_ThemeRebar != null)
            {
                m_ThemeRebar.Dispose();
                m_ThemeRebar = null;
            }
            if (m_ThemeToolbar != null)
            {
                m_ThemeToolbar.Dispose();
                m_ThemeToolbar = null;
            }
            if (m_ThemeHeader != null)
            {
                m_ThemeHeader.Dispose();
                m_ThemeHeader = null;
            }
            if (m_ThemeScrollBar != null)
            {
                m_ThemeScrollBar.Dispose();
                m_ThemeScrollBar = null;
            }
            if (m_ThemeProgress != null)
            {
                m_ThemeProgress.Dispose();
                m_ThemeProgress = null;
            }
            if (m_ThemeExplorerBar != null)
            {
                m_ThemeExplorerBar.Dispose();
                m_ThemeExplorerBar = null;
            }
            if (m_ThemeButton != null)
            {
                m_ThemeButton.Dispose();
                m_ThemeButton = null;
            }
        }
        
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (!m_FilterInstalled && !this.DesignMode)
            {
                MessageHandler.RegisterMessageClient(this);
                m_FilterInstalled = true;
            }


            if (this.AutoSize)
                this.AdjustSize();

            this.RecalcLayout();
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            DisposeThemes();
            if (m_Button != null)
            {
                m_Button.Dispose();
                m_Button = null;
            }
            MenuEventSupportUnhook();
            base.OnHandleDestroyed(e);

            if (m_FilterInstalled)
            {
                MessageHandler.UnregisterMessageClient(this);
                m_FilterInstalled = false;
            }
        }
        ThemeWindow IThemeCache.ThemeWindow
        {
            get
            {
                if (m_ThemeWindow == null)
                    m_ThemeWindow = new ThemeWindow(this);
                return m_ThemeWindow;
            }
        }
        ThemeRebar IThemeCache.ThemeRebar
        {
            get
            {
                if (m_ThemeRebar == null)
                    m_ThemeRebar = new ThemeRebar(this);
                return m_ThemeRebar;
            }
        }
        ThemeToolbar IThemeCache.ThemeToolbar
        {
            get
            {
                if (m_ThemeToolbar == null)
                    m_ThemeToolbar = new ThemeToolbar(this);
                return m_ThemeToolbar;
            }
        }
        ThemeHeader IThemeCache.ThemeHeader
        {
            get
            {
                if (m_ThemeHeader == null)
                    m_ThemeHeader = new ThemeHeader(this);
                return m_ThemeHeader;
            }
        }
        ThemeScrollBar IThemeCache.ThemeScrollBar
        {
            get
            {
                if (m_ThemeScrollBar == null)
                    m_ThemeScrollBar = new ThemeScrollBar(this);
                return m_ThemeScrollBar;
            }
        }
        ThemeExplorerBar IThemeCache.ThemeExplorerBar
        {
            get
            {
                if (m_ThemeExplorerBar == null)
                    m_ThemeExplorerBar = new ThemeExplorerBar(this);
                return m_ThemeExplorerBar;
            }
        }
        ThemeProgress IThemeCache.ThemeProgress
        {
            get
            {
                if (m_ThemeProgress == null)
                    m_ThemeProgress = new ThemeProgress(this);
                return m_ThemeProgress;
            }
        }
        ThemeButton IThemeCache.ThemeButton
        {
            get
            {
                if (m_ThemeButton == null)
                    m_ThemeButton = new ThemeButton(this);
                return m_ThemeButton;
            }
        }

        #endregion

        #region IOwner Implementation
        /// <summary>
        /// Gets or sets the form button is attached to.
        /// </summary>
        Form IOwner.ParentForm
        {
            get
            {
                return base.FindForm();
            }
            set { }
        }

        /// <summary>
        /// Returns the collection of items with the specified name. This member is not implemented and should not be used.
        /// </summary>
        /// <param name="ItemName">Item name to look for.</param>
        /// <returns></returns>
        ArrayList IOwner.GetItems(string ItemName)
        {
            ArrayList list = new ArrayList(15);
            BarFunctions.GetSubItemsByName(m_Button, ItemName, list);
            return list;
        }

        /// <summary>
        /// Returns the collection of items with the specified name and type. This member is not implemented and should not be used.
        /// </summary>
        /// <param name="ItemName">Item name to look for.</param>
        /// <param name="itemType">Item type to look for.</param>
        /// <returns></returns>
        ArrayList IOwner.GetItems(string ItemName, Type itemType)
        {
            ArrayList list = new ArrayList(15);
            BarFunctions.GetSubItemsByNameAndType(m_Button, ItemName, list, itemType);
            return list;
        }

        /// <summary>
        /// Returns the collection of items with the specified name and type. This member is not implemented and should not be used.
        /// </summary>
        /// <param name="ItemName">Item name to look for.</param>
        /// <param name="itemType">Item type to look for.</param>
        /// <param name="useGlobalName">Indicates whether GlobalName property is used for searching.</param>
        /// <returns></returns>
        ArrayList IOwner.GetItems(string ItemName, Type itemType, bool useGlobalName)
        {
            ArrayList list = new ArrayList(15);
            BarFunctions.GetSubItemsByNameAndType(m_Button, ItemName, list, itemType, useGlobalName);
            return list;
        }

        /// <summary>
        /// Returns the first item that matches specified name.  This member is not implemented and should not be used.
        /// </summary>
        /// <param name="ItemName">Item name to look for.</param>
        /// <returns></returns>
        BaseItem IOwner.GetItem(string ItemName)
        {
            BaseItem item = BarFunctions.GetSubItemByName(m_Button, ItemName);
            if (item != null)
                return item;
            return null;
        }

        // Only one Popup Item can be expanded at a time. This is used
        // to track the currently expanded popup item and to close the popup item
        // if another item is expanding.
        void IOwner.SetExpandedItem(BaseItem objItem)
        {
            if (objItem != null && objItem.Parent is PopupItem)
                return;
            if (m_ExpandedItem != null)
            {
                if (m_ExpandedItem.Expanded)
                    m_ExpandedItem.Expanded = false;
                m_ExpandedItem = null;
            }
            m_ExpandedItem = objItem;
        }

        BaseItem IOwner.GetExpandedItem()
        {
            return m_ExpandedItem;
        }

        // Currently we are using this to communicate "focus" when control is in
        // design mode. This can be used later if we decide to add focus
        // handling to our BaseItem class.
        void IOwner.SetFocusItem(BaseItem objFocusItem)
        {
            if (m_FocusItem != null && m_FocusItem != objFocusItem)
            {
                m_FocusItem.OnLostFocus();
            }
            m_FocusItem = objFocusItem;
            if (m_FocusItem != null)
                m_FocusItem.OnGotFocus();
        }

        BaseItem IOwner.GetFocusItem()
        {
            return m_FocusItem;
        }

        void IOwner.DesignTimeContextMenu(BaseItem objItem)
        {
        }

        bool IOwner.DesignMode
        {
            get { return this.GetDesignMode(); }
        }

        void IOwner.RemoveShortcutsFromItem(BaseItem objItem)
        {
            ShortcutTableEntry objEntry = null;
            if (objItem.ShortcutString != "")
            {
                foreach (eShortcut key in objItem.Shortcuts)
                {
                    if (m_ShortcutTable.ContainsKey(key))
                    {
                        objEntry = (ShortcutTableEntry)m_ShortcutTable[key];
                        try
                        {
                            objEntry.Items.Remove(objItem.Id);
                            if (objEntry.Items.Count == 0)
                                m_ShortcutTable.Remove(objEntry.Shortcut);
                        }
                        catch (ArgumentException) { }
                    }
                }
            }
            IOwner owner = this as IOwner;
            foreach (BaseItem objTmp in objItem.SubItems)
                owner.RemoveShortcutsFromItem(objTmp);
        }

        void IOwner.AddShortcutsFromItem(BaseItem objItem)
        {
            ShortcutTableEntry objEntry = null;
            if (objItem.ShortcutString != "")
            {
                foreach (eShortcut key in objItem.Shortcuts)
                {
                    if (m_ShortcutTable.ContainsKey(key))
                        objEntry = (ShortcutTableEntry)m_ShortcutTable[objItem.Shortcuts[0]];
                    else
                    {
                        objEntry = new ShortcutTableEntry(key);
                        m_ShortcutTable.Add(objEntry.Shortcut, objEntry);
                    }
                    try
                    {
                        objEntry.Items.Add(objItem.Id, objItem);
                    }
                    catch (ArgumentException) { }
                }
            }
            IOwner owner = this as IOwner;
            foreach (BaseItem objTmp in objItem.SubItems)
                owner.AddShortcutsFromItem(objTmp);
        }

        Form IOwner.ActiveMdiChild
        {
            get
            {
                Form form = base.FindForm();
                if (form == null)
                    return null;
                if (form.IsMdiContainer)
                {
                    return form.ActiveMdiChild;
                }
                return null;
            }
        }

        bool IOwner.AlwaysDisplayKeyAccelerators
        {
            get { return true; }
            set { }
        }

        /// <summary>
        /// Invokes the HVTTCONTROLS Customize dialog.
        /// </summary>
        void IOwner.Customize()
        {
        }

        void IOwner.InvokeResetDefinition(BaseItem item, EventArgs e)
        {
        }

        /// <summary>
        /// Indicates whether Reset buttons is shown that allows end-user to reset the toolbar state.
        /// </summary>
        bool IOwner.ShowResetButton
        {
            get { return false; }
            set { }
        }

        void IOwner.OnApplicationActivate() { }
        void IOwner.OnApplicationDeactivate()
        {
            ClosePopups();
        }
        void IOwner.OnParentPositionChanging() { }

        void IOwner.StartItemDrag(BaseItem item) { }

        bool IOwner.DragInProgress
        {
            get { return false; }
        }

        BaseItem IOwner.DragItem
        {
            get { return null; }
        }

        void IOwner.InvokeUserCustomize(object sender, EventArgs e)  {}

        void IOwner.InvokeEndUserCustomize(object sender, EndUserCustomizeEventArgs e) { }

        MdiClient IOwner.GetMdiClient(Form MdiForm)
        {
            return BarFunctions.GetMdiClient(MdiForm);
        }

		/// <summary>
		/// ImageList for images used on Items. Images specified here will always be used on menu-items and are by default used on all Bars.
		/// </summary>
		[System.ComponentModel.Browsable(false),System.ComponentModel.Category("Data"),DefaultValue(null),System.ComponentModel.Description("ImageList for images used on Items. Images specified here will always be used on menu-items and are by default used on all Bars.")]
		public System.Windows.Forms.ImageList Images
		{
			get
			{
				return m_ImageList;
			}
			set
			{
				if(m_ImageList!=null)
					m_ImageList.Disposed-=new EventHandler(this.ImageListDisposed);
				m_ImageList=value;
				if(m_ImageList!=null)
					m_ImageList.Disposed+=new EventHandler(this.ImageListDisposed);
			}
		}

		/// <summary>
		/// ImageList for medium-sized images used on Items.
		/// </summary>
		[System.ComponentModel.Browsable(false),System.ComponentModel.Category("Data"),DefaultValue(null),System.ComponentModel.Description("ImageList for medium-sized images used on Items.")]
		public System.Windows.Forms.ImageList ImagesMedium
		{
			get
			{
				return m_ImageListMedium;
			}
			set
			{
				if(m_ImageListMedium!=null)
					m_ImageListMedium.Disposed-=new EventHandler(this.ImageListDisposed);
				m_ImageListMedium=value;
				if(m_ImageListMedium!=null)
					m_ImageListMedium.Disposed+=new EventHandler(this.ImageListDisposed);
			}
		}

		/// <summary>
		/// ImageList for large-sized images used on Items.
		/// </summary>
		[System.ComponentModel.Browsable(false),System.ComponentModel.Category("Data"),DefaultValue(null),System.ComponentModel.Description("ImageList for large-sized images used on Items.")]
		public System.Windows.Forms.ImageList ImagesLarge
		{
			get
			{
				return m_ImageListLarge;
			}
			set
			{
				if(m_ImageListLarge!=null)
					m_ImageListLarge.Disposed-=new EventHandler(this.ImageListDisposed);
				m_ImageListLarge=value;
				if(m_ImageListLarge!=null)
					m_ImageListLarge.Disposed+=new EventHandler(this.ImageListDisposed);
			}
		}

		private void ImageListDisposed(object sender, EventArgs e)
		{
			if(sender==m_ImageList)
			{
				m_ImageList=null;
			}
			else if(sender==m_ImageListLarge)
			{
				m_ImageListLarge=null;
			}
			else if(sender==m_ImageListMedium)
			{
				m_ImageListMedium=null;
			}
		}


        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (this.DesignMode)
                m_Button.SetDesignMode(this.DesignMode);
        }

        void IOwner.InvokeDefinitionLoaded(object sender, EventArgs e) {}

        /// <summary>
        /// Indicates whether Tooltips are shown on Bars and menus.
        /// </summary>
        //[Browsable(false), DefaultValue(true), Category("Run-time Behavior"), Description("Indicates whether Tooltips are shown on Bars and menus.")]
        bool IOwner.ShowToolTips
        {
            get
            {
                return true;
            }
            set
            {
                //m_ShowToolTips = value;
            }
        }

        /// <summary>
        /// Indicates whether item shortcut is displayed in Tooltips.
        /// </summary>
        //[Browsable(false), DefaultValue(false), Category("Run-time Behavior"), Description("Indicates whether item shortcut is displayed in Tooltips.")]
        bool IOwner.ShowShortcutKeysInToolTips
        {
            get
            {
                return true;
            }
            set
            {
                //m_ShowShortcutKeysInToolTips = value;
            }
        }

        /// <summary>
        /// Gets or sets whether gray-scale algorithm is used to create automatic gray-scale images. Default is true.
        /// </summary>
        [Browsable(true), DefaultValue(true), Category("Appearance"), Description("Gets or sets whether gray-scale algorithm is used to create automatic gray-scale images.")]
        public bool DisabledImagesGrayScale
        {
            get
            {
                return m_DisabledImagesGrayScale;
            }
            set
            {
                m_DisabledImagesGrayScale = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the button is expanded (displays drop-down) or not.
        /// </summary>
        [Browsable(false), DefaultValue(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool Expanded
        {
            get { return m_Button.Expanded; }
            set { m_Button.Expanded = value; }
        }

        /// <summary>
        /// Gets or sets the collection of shortcut keys associated with the button. When shortcut key is pressed button Click event is raised.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), Category("Design"), Description("Indicates list of shortcut keys for this button."), Editor(typeof(Design.ShortcutsDesigner), typeof(System.Drawing.Design.UITypeEditor)), System.ComponentModel.TypeConverter(typeof(Design.ShortcutsConverter)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual ShortcutsCollection Shortcuts
        {
            get { return m_Button.Shortcuts; }
            set { m_Button.Shortcuts = value; }
        }

        /// <summary>
		/// Displays the sub-items on popup specified by PopupType.
		/// </summary>
		/// <param name="p">Popup location.</param>
		public virtual void Popup(Point p)
		{
            m_Button.Popup(p);
		}

		/// <summary>
		/// Displays the sub-items on popup specified by PopupType.
		/// </summary>
		/// <param name="x">Horizontal coordinate in pixels of the upper left corner of a popup.</param>
		/// <param name="y">Vertical coordinate in pixels of the upper left corner of a popup.</param>
		public virtual void Popup(int x, int y)
		{
            m_Button.Popup(x, y);
		}
        #endregion

        #region IAccessibilitySupport Members

        BaseItem IAccessibilitySupport.DoDefaultActionItem
        {
            get
            {
                return m_DoDefaultActionItem;
            }
            set
            {
                m_DoDefaultActionItem = value; ;
            }
        }

        #endregion

        #region IOwnerLocalize Members
        void IOwnerLocalize.InvokeLocalizeString(LocalizeEventArgs e)
        {
            if (LocalizeString != null)
                LocalizeString(this, e);
        }
        #endregion
    }

    #region HVTTButtonAccessibleObject
    /// <summary>
    /// Represents class for Accessibility support.
    /// </summary>
    public class HVTTButtonAccessibleObject : Control.ControlAccessibleObject
    {
        private HVTTButton m_Owner = null;
        /// <summary>
        /// Creates new instance of the object and initializes it with owner control.
        /// </summary>
        /// <param name="owner">Reference to owner control.</param>
        public HVTTButtonAccessibleObject(HVTTButton owner)
            : base(owner)
        {
            m_Owner = owner;
        }

        protected HVTTButton Owner
        {
            get { return m_Owner; }
        }

        /// <summary>
        /// Gets or sets accessible name.
        /// </summary>
        public override string Name
        {
            get
            {
                if (m_Owner != null && !m_Owner.IsDisposed)
                    return m_Owner.AccessibleName;
                return "";
            }
            set
            {
                if (m_Owner != null && !m_Owner.IsDisposed)
                    m_Owner.AccessibleName = value;
            }
        }

        /// <summary>
        /// Gets accessible description.
        /// </summary>
        public override string Description
        {
            get
            {
                if (m_Owner != null && !m_Owner.IsDisposed)
                    return m_Owner.AccessibleDescription;
                return "";
            }
        }

        /// <summary>
        /// Gets accessible role.
        /// </summary>
        public override AccessibleRole Role
        {
            get
            {
                if (m_Owner != null && !m_Owner.IsDisposed)
                    return m_Owner.AccessibleRole;
                return System.Windows.Forms.AccessibleRole.None;
            }
        }

        /// <summary>
        /// Gets parent accessibility object.
        /// </summary>
        public override AccessibleObject Parent
        {
            get
            {
                if (m_Owner != null && !m_Owner.IsDisposed)
                    return m_Owner.Parent.AccessibilityObject;
                return null;
            }
        }

        /// <summary>
        /// Returns bounds of the control.
        /// </summary>
        public override Rectangle Bounds
        {
            get
            {
                if (m_Owner != null && !m_Owner.IsDisposed && m_Owner.Parent != null)
                    return this.m_Owner.Parent.RectangleToScreen(m_Owner.Bounds);
                return Rectangle.Empty;
            }
        }

        /// <summary>
        /// Returns number of child objects.
        /// </summary>
        /// <returns>Total number of child objects.</returns>
        public override int GetChildCount()
        {
            if (m_Owner != null && !m_Owner.IsDisposed)
                return m_Owner.InternalItem.AccessibleObject.GetChildCount();
            return 0;
        }

        /// <summary>
        /// Returns reference to child object given the index.
        /// </summary>
        /// <param name="iIndex">0 based index of child object.</param>
        /// <returns>Reference to child object.</returns>
        public override System.Windows.Forms.AccessibleObject GetChild(int iIndex)
        {
            if (m_Owner != null && !m_Owner.IsDisposed)
                return m_Owner.InternalItem.AccessibleObject.GetChild(iIndex);  //return m_Owner.SubItems[iIndex].AccessibleObject;
            return null;
        }

        /// <summary>
        /// Returns current accessible state.
        /// </summary>
        public override AccessibleStates State
        {
            get
            {
                return m_Owner.InternalItem.AccessibleObject.State;
            }
        }

        /// <summary>
        /// Gets or sets the value of an accessible object.
        /// </summary>
        public override string Value
        {
            get
            {
                return m_Owner.Text;
            }
            set
            {
                m_Owner.Text = value;
            }
        }
    }
    #endregion
}
