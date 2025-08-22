using System;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms.Ribbon
{
    /// <summary>
    /// Represents the stand-alone Quick Access Toolbar control
    /// </summary>
    internal class QatToolbar : ItemControl
    {
        #region Private Variables
        private CaptionItemContainer m_ItemContainer = null;
        private ElementStyle m_DefaultBackgroundStyle = new ElementStyle();
        #endregion

        #region Constructor
        public QatToolbar()
        {
            m_ItemContainer = new CaptionItemContainer();
            m_ItemContainer.GlobalItem = false;
            m_ItemContainer.ContainerControl = this;
            m_ItemContainer.WrapItems = false;
            m_ItemContainer.EventHeight = false;
            m_ItemContainer.UseMoreItemsButton = false;
            m_ItemContainer.Stretch = true;
            m_ItemContainer.Displayed = true;
            m_ItemContainer.SystemContainer = true;
            m_ItemContainer.PaddingTop = 0;
            m_ItemContainer.PaddingBottom = 0;
            m_ItemContainer.ItemSpacing = 0;
            m_ItemContainer.SetOwner(this);
            m_ItemContainer.PaddingBottom = 0;
            m_ItemContainer.PaddingTop = 0;
            m_ItemContainer.ItemSpacing = 1;
            m_ItemContainer.TrackSubItemsImageSize = false;
            //m_ItemContainer.ToolbarItemsAlign = eContainerVerticalAlignment.Middle;
            this.SetBaseItemContainer(m_ItemContainer);
            m_ItemContainer.Style = HVTTControlStyle.Office2007;
        }
        #endregion

        #region Internal Implementation
        protected override ElementStyle GetBackgroundStyle()
        {
            if(this.BackgroundStyle.Custom)
                return base.GetBackgroundStyle();

            return m_DefaultBackgroundStyle;
        }

        protected override void RecalcSize()
        {
            InitDefaultStyles();
            base.RecalcSize();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            InitDefaultStyles();
            base.OnPaint(e);
        }

        private void InitDefaultStyles()
        {
            // Initialize Default Styles
            RibbonPredefinedColorSchemes.ApplyQatElementStyle(m_DefaultBackgroundStyle, this);
        }

        /// <summary>
        /// Gets/Sets the visual style for items and color scheme.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), Category("Appearance"), Description("Specifies the visual style of the control."), DefaultValue(HVTTControlStyle.Office2007)]
        public HVTTControlStyle Style
        {
            get
            {
                return m_ItemContainer.Style;
            }
            set
            {
                this.ColorScheme.Style = value;
                m_ItemContainer.Style = value;
                this.Invalidate();
                this.RecalcLayout();
            }
        }

        /// <summary>
        /// Returns collection of items on a bar.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public SubItemsCollection Items
        {
            get
            {
                return m_ItemContainer.SubItems;
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if(this.Parent is RibbonControl)
                    ((RibbonControl)this.Parent).ShowCustomizeContextMenu(this.HitTest(e.X, e.Y), true);
            }
            base.OnMouseDown(e);
        }
        #endregion
    }
}
