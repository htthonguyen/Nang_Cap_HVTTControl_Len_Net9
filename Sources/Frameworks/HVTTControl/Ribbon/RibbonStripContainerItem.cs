using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms
{
    /// <summary>
    /// Defines the internal container item for the ribbon strip control.
    /// </summary>
    [System.ComponentModel.ToolboxItem(false), System.ComponentModel.DesignTimeVisible(false)]
    public class RibbonStripContainerItem : ImageItem, IDesignTimeProvider
    {
        #region Private Variables
        private RibbonTabItemContainer m_ItemContainer = null;
        private CaptionItemContainer m_CaptionContainer = null;
        private SystemCaptionItem m_SystemCaptionItem = null;
        private RibbonStrip m_RibbonStrip = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates new instance of the class and initializes it with the parent RibbonStrip control.
        /// </summary>
        /// <param name="parent">Reference to parent RibbonStrip control</param>
        public RibbonStripContainerItem(RibbonStrip parent)
        {
            m_RibbonStrip = parent;

            // We contain other controls
            m_IsContainer = true;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;

            m_ItemContainer = new RibbonTabItemContainer();
            m_ItemContainer.ContainerControl = parent;
            m_ItemContainer.GlobalItem = false;
            m_ItemContainer.WrapItems = false;
            m_ItemContainer.EventHeight = false;
            m_ItemContainer.UseMoreItemsButton = false;
            m_ItemContainer.Stretch = true;
            m_ItemContainer.Displayed = true;
            m_ItemContainer.SystemContainer = true;
            m_ItemContainer.PaddingTop = 0;
            m_ItemContainer.PaddingBottom = 0;
            m_ItemContainer.ItemSpacing = 1;

            m_CaptionContainer = new CaptionItemContainer();
            m_CaptionContainer.ContainerControl = parent;
            m_CaptionContainer.GlobalItem = false;
            m_CaptionContainer.WrapItems = false;
            m_CaptionContainer.EventHeight = false;
            m_CaptionContainer.EqualButtonSize = false;
            m_CaptionContainer.ToolbarItemsAlign = eContainerVerticalAlignment.Top;
            m_CaptionContainer.UseMoreItemsButton = false;
            m_CaptionContainer.Stretch = true;
            m_CaptionContainer.Displayed = true;
            m_CaptionContainer.SystemContainer = true;
            m_CaptionContainer.PaddingBottom = 0;
            m_CaptionContainer.PaddingTop = 0;
            m_CaptionContainer.ItemSpacing = 1;
            m_CaptionContainer.TrackSubItemsImageSize = false;
            m_CaptionContainer.ItemAdded += new EventHandler(this.CaptionContainerNewItemAdded);
            this.SubItems.Add(m_CaptionContainer);
            this.SubItems.Add(m_ItemContainer);

            SystemCaptionItem sc = new SystemCaptionItem();
            sc.RestoreEnabled = false;
            sc.IsSystemIcon = false;
            sc.ItemAlignment = eItemAlignment.Far;
            m_CaptionContainer.SubItems.Add(sc);
            m_SystemCaptionItem = sc;

        }
        #endregion

        #region Internal Implementation
        private void CaptionContainerNewItemAdded(object sender, EventArgs e)
        {
            if (sender is BaseItem)
            {
                BaseItem item = sender as BaseItem;
                if (!(item is SystemCaptionItem))
                {
                    if (m_CaptionContainer.SubItems.Contains(m_SystemCaptionItem))
                    {
                        m_CaptionContainer.SubItems._Remove(m_SystemCaptionItem);
                        m_CaptionContainer.SubItems._Add(m_SystemCaptionItem);
                    }
                }

                //if (item is CustomizeItem)
                //    m_CustomizeItem = (CustomizeItem)item;
                //else if(m_CustomizeItem!=null)
                //{
                //    m_CaptionContainer.SubItems._Remove(m_CustomizeItem);
                //    m_CaptionContainer.SubItems._Add(m_CustomizeItem, m_CaptionContainer.SubItems.Count - 1);
                //}
            }
        }

        internal void ReleaseSystemFocus()
        {
            m_ItemContainer.ReleaseSystemFocus();
            if (m_RibbonStrip.CaptionVisible)
                m_CaptionContainer.ReleaseSystemFocus();
        }

        public override void ContainerLostFocus(bool appLostFocus)
        {
            base.ContainerLostFocus(appLostFocus);
            m_ItemContainer.ContainerLostFocus(appLostFocus);
            if (m_RibbonStrip.CaptionVisible)
                m_CaptionContainer.ContainerLostFocus(appLostFocus);
        }

        internal void SetSystemFocus()
        {
            if (m_RibbonStrip.CaptionVisible && m_ItemContainer.ExpandedItem()==null)
                m_CaptionContainer.SetSystemFocus();
            else
                m_ItemContainer.SetSystemFocus();
        }

        /// <summary>
		/// Paints this base container
		/// </summary>
        public override void Paint(ItemPaintArgs pa)
        {
            if (this.SuspendLayout)
                return;

            m_ItemContainer.Paint(pa);
            if (m_RibbonStrip.CaptionVisible)
                m_CaptionContainer.Paint(pa);
        }

        public override void RecalcSize()
        {
            if (this.SuspendLayout)
                return;

            m_ItemContainer.Bounds = GetItemContainerBounds();
            m_ItemContainer.RecalcSize();
            if (m_ItemContainer.HeightInternal < 0) m_ItemContainer.HeightInternal = 0;
            bool isMaximized = false;
            if (m_RibbonStrip.CaptionVisible)
            {
                m_CaptionContainer.Bounds = GetCaptionContainerBounds();
                m_CaptionContainer.RecalcSize();
                if (m_RibbonStrip.CaptionHeight == 0 && m_SystemCaptionItem.TopInternal < (SystemInformation.FrameBorderSize.Height - 1))
                {
                    Control c = this.ContainerControl as Control;
                    Form form = null;
                    if (c != null) form = c.FindForm();
                    if (form != null && form.WindowState == FormWindowState.Maximized)
                        isMaximized = true;

                    if (System.Environment.OSVersion.Version.Major >= 6 && !this.IsGlassEnabled)
                    {
                        if (isMaximized)
                            m_SystemCaptionItem.TopInternal = 1;
                        else
                            m_SystemCaptionItem.TopInternal = SystemInformation.FrameBorderSize.Height - 4;
                    }
                    else
                    {
                        m_SystemCaptionItem.TopInternal = SystemInformation.FrameBorderSize.Height - 1;
                    }
                }
                
                // Adjust the Y position of the items inside of the caption container since they are top aligned and
                // quick access toolbar items should be aligned with the bottom of the system caption item.
                if (System.Environment.OSVersion.Version.Major >= 6)
                {
                    int topOffset = 2;
                    if (!this.IsGlassEnabled)
                        topOffset++;
                    else if (isMaximized)
                        topOffset += 1;
                    
                    foreach (BaseItem item in m_CaptionContainer.SubItems)
                    {
                        if (!(item is Office2007StartButton) && item != m_SystemCaptionItem)
                            item.TopInternal += topOffset;
                    }
                    if (m_CaptionContainer.MoreItems != null)
                        m_CaptionContainer.MoreItems.TopInternal += topOffset;
                }
                else
                {
                    foreach (BaseItem item in m_CaptionContainer.SubItems)
                    {
                        if (item.HeightInternal < m_SystemCaptionItem.HeightInternal)
                        {
                            item.TopInternal += (m_SystemCaptionItem.HeightInternal - item.HeightInternal);
                        }
                    }
                    if (m_CaptionContainer.MoreItems != null)
                        m_CaptionContainer.MoreItems.TopInternal += (m_SystemCaptionItem.HeightInternal - m_CaptionContainer.MoreItems.HeightInternal);
                }

                if (m_ItemContainer.HeightInternal == 0)
                    this.HeightInternal = m_CaptionContainer.HeightInternal;
                else
                    this.HeightInternal = m_ItemContainer.Bounds.Bottom;// -m_CaptionContainer.Bounds.Top;
            }
            else
            {
                int h = m_ItemContainer.HeightInternal;
                if (m_RibbonStrip.TabGroupsVisible)
                    h += m_RibbonStrip.TabGroupHeight + 1;
                this.HeightInternal = h;
            }

            base.RecalcSize();
        }

        private bool IsGlassEnabled
        {
            get { if (this.DesignMode || !m_RibbonStrip.CanSupportGlass) return false; return WinApi.IsGlassEnabled; }
        }

        private Rectangle GetItemContainerBounds()
        {
            return m_RibbonStrip.GetItemContainerBounds();
        }

        private Rectangle GetCaptionContainerBounds()
        {
            return m_RibbonStrip.GetCaptionContainerBounds();
        }

        /// <summary>
        /// Gets reference to internal ribbon strip container that contains tabs and/or other items.
        /// </summary>
        public GenericItemContainer RibbonStripContainer
        {
            get { return m_ItemContainer; }
        }

        /// <summary>
        /// Gets reference to internal caption container item that contains the quick toolbar, start button and system caption item.
        /// </summary>
        public GenericItemContainer CaptionContainer
        {
            get { return m_CaptionContainer; }
        }

        public SystemCaptionItem SystemCaptionItem
        {
            get { return m_SystemCaptionItem; }
        }

        /// <summary>
        /// Returns copy of GenericItemContainer item
        /// </summary>
        public override BaseItem Copy()
        {
            RibbonStripContainerItem objCopy = new RibbonStripContainerItem(m_RibbonStrip);
            this.CopyToItem(objCopy);

            return objCopy;
        }
        protected override void CopyToItem(BaseItem copy)
        {
            RibbonStripContainerItem objCopy = copy as RibbonStripContainerItem;
            base.CopyToItem(objCopy);
        }


        public override void InternalClick(MouseButtons mb, Point mpos)
        {
            m_ItemContainer.InternalClick(mb, mpos);
            if (m_RibbonStrip.CaptionVisible) m_CaptionContainer.InternalClick(mb, mpos);
        }

        public override void InternalDoubleClick(MouseButtons mb, Point mpos)
        {
            m_ItemContainer.InternalDoubleClick(mb, mpos);
            if (m_RibbonStrip.CaptionVisible) m_CaptionContainer.InternalDoubleClick(mb, mpos);
        }

        public override void InternalMouseDown(MouseEventArgs objArg)
        {
            m_ItemContainer.InternalMouseDown(objArg);
            if (m_RibbonStrip.CaptionVisible)
            {
                if(this.DesignMode && m_CaptionContainer.ItemAtLocation(objArg.X, objArg.Y)!=null || !this.DesignMode)
                    m_CaptionContainer.InternalMouseDown(objArg);
            }
        }

        public override void InternalMouseHover()
        {
            m_ItemContainer.InternalMouseHover();
            if (m_RibbonStrip.CaptionVisible) m_CaptionContainer.InternalMouseHover();
        }

        public override void InternalMouseLeave()
        {
            m_ItemContainer.InternalMouseLeave();
            if (m_RibbonStrip.CaptionVisible) m_CaptionContainer.InternalMouseLeave();
        }

        public override void InternalMouseMove(MouseEventArgs objArg)
        {
            m_ItemContainer.InternalMouseMove(objArg);
            if (m_RibbonStrip.CaptionVisible) m_CaptionContainer.InternalMouseMove(objArg);
        }

        public override void InternalMouseUp(MouseEventArgs objArg)
        {
            m_ItemContainer.InternalMouseUp(objArg);
            if (m_RibbonStrip.CaptionVisible) m_CaptionContainer.InternalMouseUp(objArg);
        }

        public override void InternalKeyDown(KeyEventArgs objArg)
        {
            BaseItem expanded = this.ExpandedItem();
            if (expanded == null)
                expanded = m_CaptionContainer.ExpandedItem();
            if (expanded == null)
                expanded = m_ItemContainer.ExpandedItem();

            if (expanded == null || !m_RibbonStrip.CaptionVisible)
            {
                m_ItemContainer.InternalKeyDown(objArg);
                if (!objArg.Handled && m_RibbonStrip.CaptionVisible)
                    m_CaptionContainer.InternalKeyDown(objArg);
            }
            else
            {
                if (expanded.Parent == m_ItemContainer)
                {
                    m_ItemContainer.InternalKeyDown(objArg);
                }
                else
                {
                    m_CaptionContainer.InternalKeyDown(objArg);
                }
            }
        }

        /// <summary>
        /// Return Sub Item at specified location
        /// </summary>
        public override BaseItem ItemAtLocation(int x, int y)
        {
            if (m_ItemContainer.DisplayRectangle.Contains(x, y))
                return m_ItemContainer.ItemAtLocation(x, y);

            if (m_CaptionContainer.DisplayRectangle.Contains(x, y))
                return m_CaptionContainer.ItemAtLocation(x, y);

            return null;
        }
        #endregion

        #region IDesignTimeProvider Members

        public InsertPosition GetInsertPosition(Point pScreen, BaseItem DragItem)
        {
            InsertPosition pos = m_ItemContainer.GetInsertPosition(pScreen, DragItem);
            if(pos==null && m_RibbonStrip.CaptionVisible)
                pos = m_CaptionContainer.GetInsertPosition(pScreen, DragItem);
            return pos;
        }

        public void DrawReversibleMarker(int iPos, bool Before)
        {
            //DesignTimeProviderContainer.DrawReversibleMarker(this, iPos, Before);
        }

        public void InsertItemAt(BaseItem objItem, int iPos, bool Before)
        {
            //DesignTimeProviderContainer.InsertItemAt(this, objItem, iPos, Before);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the item is expanded or not. For Popup items this would indicate whether the item is popped up or not.
        /// </summary>
        [System.ComponentModel.Browsable(false), System.ComponentModel.DefaultValue(false), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public override bool Expanded
        {
            get
            {
                return base.Expanded;
            }
            set
            {
                base.Expanded = value;
                if (!value)
                {
                    foreach (BaseItem item in this.SubItems)
                        item.Expanded = false;
                }
            }
        }

        /// <summary>
        /// When parent items does recalc size for its sub-items it should query
        /// image size and store biggest image size into this property.
        /// </summary>
        [System.ComponentModel.Browsable(false), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override System.Drawing.Size SubItemsImageSize
        {
            get
            {
                return base.SubItemsImageSize;
            }
            set
            {
                //m_SubItemsImageSize = value;
            }
        }
        #endregion
    }
}
