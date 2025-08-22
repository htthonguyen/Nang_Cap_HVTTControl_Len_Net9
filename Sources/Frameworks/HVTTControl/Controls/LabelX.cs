using System;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;

namespace HVTT.UI.Window.Forms
{
//#if FRAMEWORK20
    [Designer(typeof(Design.LabelXDesigner))]
//#endif
    [ToolboxBitmap(typeof(LabelX), "Controls.LabelX.ico"), ToolboxItem(true), System.Runtime.InteropServices.ComVisible(false)]
    public class LabelX : BaseItemControl
    {
        #region Private Variables
        private LabelItem m_Label = null;
        private bool m_UseMnemonic = true;
        private Size m_PreferedSize = Size.Empty;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when text markup link is clicked. Markup links can be created using "a" tag, for example:
        /// <a name="MyLink">Markup link</a>
        /// </summary>
        public event MarkupLinkClickEventHandler MarkupLinkClick;
        #endregion

        #region Constructor, Dispose
        public LabelX()
        {
            m_Label = new LabelItem();
            m_Label.Style = eDotNetBarStyle.Office2007;
            m_Label.MarkupLinkClick += new MarkupLinkClickEventHandler(LabelMarkupLinkClick);
            this.HostItem = m_Label;
            this.TabStop = false;
            this.SetStyle(ControlStyles.Selectable, false);
        }
        #endregion

        #region Internal Implementation
        protected override void OnHandleCreated(EventArgs e)
        {
#if FRAMEWORK20
            if (this.AutoSize)
                this.AdjustSize();
#endif
            this.RecalcLayout();
            base.OnHandleCreated(e);
        }
        /// <summary>
        /// Recalculates the size of the internal item.
        /// </summary>
        protected override void RecalcSize()
        {
            m_Label.SuspendPaint = true;
            m_Label.Width = m_Label.Bounds.Width;
            m_Label.Height = m_Label.Bounds.Height;
            m_Label.SuspendPaint = false;
            base.RecalcSize();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            m_Label.BackColor = this.BackColor;
            base.OnBackColorChanged(e);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            m_Label.ForeColor = this.ForeColor;
            base.OnForeColorChanged(e);
        }

        /// <summary>
        /// Gets or sets the border sides that are displayed. Default value specifies border on all 4 sides.
        /// </summary>
        [Browsable(true), Category("Appearance"), DefaultValue(LabelItem.DEFAULT_BORDERSIDE), Description("Specifies border sides that are displayed.")]
        public eBorderSide BorderSide
        {
            get { return m_Label.BorderSide; }
            set { m_Label.BorderSide = value; InvalidateAutoSize(); }
        }

        /// <summary>
        /// Gets or sets the type of the border drawn around the label.
        /// </summary>
        [Browsable(true), Category("Appearance"), DefaultValue(eBorderType.None) , Description("Indicates the type of the border drawn around the label.")]
        public eBorderType BorderType
        {
            get { return m_Label.BorderType; }
            set { m_Label.BorderType = value; InvalidateAutoSize(); }
        }

        /// <summary>
        /// Specifies label image.
        /// </summary>
        [Browsable(true), Category("Appearance"), Description("The image that will be displayed on the face of the item."), DefaultValue(null)]
        public System.Drawing.Image Image
        {
            get { return m_Label.Image; }
            set { m_Label.Image = value; InvalidateAutoSize(); }
        }

        /// <summary>
        /// Gets/Sets the image position inside the label.
        /// </summary>
        [Browsable(true), Category("Appearance"), Description("The alignment of the image in relation to text displayed by this item."), DefaultValue(eImagePosition.Left)]
        public eImagePosition ImagePosition
        {
            get { return m_Label.ImagePosition; }
            set { m_Label.ImagePosition = value; InvalidateAutoSize(); }
        }

        /// <summary>
        /// Gets or sets the border line color when border is single line.
        /// </summary>
        [Browsable(true), Category("Appearance"), Description("Indicates border line color when border is single line.")]
        public Color SingleLineColor
        {
            get { return m_Label.SingleLineColor; }
            set { m_Label.SingleLineColor = value; }
        }

        /// <summary>
        /// Gets whether property should be serialized.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeSingleLineColor()
        {
            return m_Label.ShouldSerializeSingleLineColor();
        }

        /// <summary>
        /// Resets the SingleLineColor property to its default value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResetSingleLineColor()
        {
            m_Label.ResetSingleLineColor();
        }

        /// <summary>
		/// Gets or sets the text associated with this item.
		/// </summary>
        [Browsable(true), Editor(typeof(Design.TextMarkupUIEditor), typeof(System.Drawing.Design.UITypeEditor)), Category("Appearance"), Description("The text contained in the item.")]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        /// <summary>
        /// Gets or sets the horizontal text alignment.
        /// </summary>
        [Browsable(true), DefaultValue(StringAlignment.Near), HVTTBrowsable(true), Category("Layout"), Description("Indicates text alignment.")]
        public System.Drawing.StringAlignment TextAlignment
        {
            get { return m_Label.TextAlignment; }
            set { m_Label.TextAlignment = value; }
        }

        /// <summary>
        /// Gets or sets the text vertical alignment.
        /// </summary>
        [Browsable(true), DefaultValue(System.Drawing.StringAlignment.Center), HVTTBrowsable(true), Category("Layout"), Description("Indicates text line alignment.")]
        public System.Drawing.StringAlignment TextLineAlignment
        {
            get  { return m_Label.TextLineAlignment; }
            set { m_Label.TextLineAlignment = value; }
        }

        /// <summary>
        /// Gets or sets a value that determines whether text is displayed in multiple lines or one long line.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), Category("Style"), DefaultValue(false), Description("Gets or sets a value that determines whether text is displayed in multiple lines or one long line.")]
        public bool WordWrap
        {
            get { return m_Label.WordWrap; }
            set { m_Label.WordWrap = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool TabStop
        {
            get { return base.TabStop; }
            set { base.TabStop = value; }
        }

        /// <summary>
        /// Gets or sets the left padding in pixels.
        /// </summary>
        [Browsable(true), DefaultValue(0), Category("Layout"), Description("Indicates left padding in pixels.")]
        public int PaddingLeft
        {
            get { return m_Label.PaddingLeft;  }
            set { m_Label.PaddingLeft = value; InvalidateAutoSize(); }
        }

        /// <summary>
        /// Gets or sets the right padding in pixels.
        /// </summary>
        [Browsable(true), DefaultValue(0), Category("Layout"), Description("Indicates right padding in pixels.")]
        public int PaddingRight
        {
            get
            {
                return m_Label.PaddingRight;
            }
            set
            {
                m_Label.PaddingRight = value;
                InvalidateAutoSize();
            }
        }

        /// <summary>
        /// Gets or sets the top padding in pixels.
        /// </summary>
        [Browsable(true), DefaultValue(0), Category("Layout"), Description("Indicates top padding in pixels.")]
        public int PaddingTop
        {
            get
            {
                return m_Label.PaddingTop;
            }
            set
            {
                m_Label.PaddingTop = value;
                InvalidateAutoSize();
            }
        }

        /// <summary>
        /// Gets or sets the bottom padding in pixels.
        /// </summary>
        [Browsable(true), DefaultValue(0), Category("Layout"), Description("Indicates bottom padding in pixels.")]
        public int PaddingBottom
        {
            get
            {
                return m_Label.PaddingBottom;
            }
            set
            {
                m_Label.PaddingBottom = value;
                InvalidateAutoSize();
            }
        }

        private void LabelMarkupLinkClick(object sender, MarkupLinkClickEventArgs e)
        {
            OnMarkupLinkClick(e);
        }

        /// <summary>
        /// Invokes the MarkupLinkClick event.
        /// </summary>
        /// <param name="e">Provides additional data about event.</param>
        protected virtual void OnMarkupLinkClick(MarkupLinkClickEventArgs e)
        {
            if (MarkupLinkClick != null)
                MarkupLinkClick(this, e);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control interprets an ampersand character (&) in the control's Text property to be an access key prefix character.
        /// </summary>
        [Browsable(true), DefaultValue(true), Category("Appearance"), Description("Indicates whether the control interprets an ampersand character (&) in the control's Text property to be an access key prefix character.")]
        public bool UseMnemonic
        {
            get { return m_UseMnemonic; }
            set
            {
                m_UseMnemonic = value;
                InvalidateAutoSize();
                this.Invalidate();
            }
        }

        private void InvalidateAutoSize()
        {
            m_PreferedSize = Size.Empty;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (m_UseMnemonic)
                m_Label.ShowPrefix = true;
            else
                m_Label.ShowPrefix = false;

            base.OnPaint(e);
        }

        private bool CanProcessMnemonic()
        {
            if (!this.Enabled || !this.Visible)
                return false;
            return true;
        }

        [UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
        protected override bool ProcessMnemonic(char charCode)
        {
            if ((!this.UseMnemonic || !Control.IsMnemonic(charCode, this.Text)) || !this.CanProcessMnemonic())
            {
                return false;
            }
            Control parent = this.Parent;
            if (parent != null)
            {
                if (parent.SelectNextControl(this, true, false, true, false) && !parent.ContainsFocus)
                {
                    parent.Focus();
                }
            }
            return true;
        }

#if FRAMEWORK20
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
            if (this.Text.Length == 0)
                return base.GetPreferredSize(proposedSize);

            int oldWidth = m_Label.Width, oldHeight = m_Label.Height;
            m_Label.SuspendPaint = true;
            m_Label.Width = 0;
            m_Label.Height = 0;

            if ((proposedSize.Width > 0 && proposedSize.Width < 500000 || this.MaximumSize.Width > 0) && m_Label.TextMarkupBody != null)
                m_Label.RecalcSizeMarkup((this.MaximumSize.Width > 0 ? this.MaximumSize.Width : proposedSize.Width));
            else
            {
                m_Label.RecalcSize();
                if (this.WordWrap && m_Label.WidthInternal > this.MaximumSize.Width && this.MaximumSize.Width > 0)
                {
                    m_Label.Height = 0;
                    m_Label.Width = this.MaximumSize.Width;
                    m_Label.RecalcSize();
                }
            }
            Size s = m_Label.Size;
            m_Label.Width = oldWidth;
            m_Label.Height = oldHeight;
            m_Label.SuspendPaint = false;
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
                    AdjustSize();
                }
            }
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (this.AutoSize)
            {
                Size preferredSize = base.PreferredSize;
                width = preferredSize.Width;
                height = preferredSize.Height;
            }
            base.SetBoundsCore(x, y, width, height, specified);
        }

        private void AdjustSize()
        {
            if (this.AutoSize)
            {
                this.Size = base.PreferredSize;
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            InvalidateAutoSize();
            base.OnFontChanged(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            InvalidateAutoSize();
            base.OnTextChanged(e);
            this.AdjustSize();
        }
#endif
        
        #endregion
    }
}
