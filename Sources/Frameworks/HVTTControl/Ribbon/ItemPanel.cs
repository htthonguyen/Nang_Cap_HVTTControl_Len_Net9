using System;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace HVTT.UI.Window.Forms
{
    /// <summary>
    /// Represents generic item panel container control.
    /// </summary>
    [ToolboxBitmap(typeof(ItemPanel), "Ribbon.ItemPanel.ico"), ToolboxItem(true), Designer(typeof(Design.ItemPanelDesigner)), System.Runtime.InteropServices.ComVisible(false)]
    public class ItemPanel : ItemControl, IScrollableItemControl, Controls.INonClientControl
    {
        #region Private Variables
        private ItemContainer m_ItemContainer = null;
        private bool m_EnableDragDrop = false;
        private Point m_MouseDownPoint = Point.Empty;
        private bool m_SuspendPaint = false;
        private Controls.NonClientPaintHandler m_NCPainter = null;
        private int m_SuspendPaintCount = 0;
        #endregion

        #region Constructor
        public ItemPanel()
        {
            m_ItemContainer = new ItemContainer();
            m_ItemContainer.GlobalItem = false;
            m_ItemContainer.ContainerControl = this;
            m_ItemContainer.Stretch = false;
            m_ItemContainer.Displayed = true;
            m_ItemContainer.Style = HVTTControlStyle.Office2007;
            this.ColorScheme.Style = HVTTControlStyle.Office2007;
            m_ItemContainer.SetOwner(this);
            m_ItemContainer.SetSystemContainer(true);

            this.SetBaseItemContainer(m_ItemContainer);
            m_ItemContainer.Style = HVTTControlStyle.Office2007;

            this.DragDropSupport = true;
            m_NCPainter = new Controls.NonClientPaintHandler(this, eScrollBarSkin.Optimized);
        }

        protected override void Dispose(bool disposing)
        {
            if (m_NCPainter != null)
            {
                m_NCPainter.Dispose();
                m_NCPainter = null;
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Internal Implementation
        /// <summary>
        /// Invalidates non-client area of the control. This method should be used
        /// when you need to invalidate non-client area of the control.
        /// </summary>
        public void InvalidateNonClient()
        {
            if(BarFunctions.IsHandleValid(this))
                WinApi.RedrawWindow(this.Handle, IntPtr.Zero, IntPtr.Zero, WinApi.RedrawWindowFlags.RDW_FRAME | WinApi.RedrawWindowFlags.RDW_INVALIDATE);
        }
        /// <summary>
        /// Returns first checked top-level button item.
        /// </summary>
        /// <returns>An ButtonItem object or null if no button could be found.</returns>
        public ButtonItem GetChecked()
        {
            foreach (BaseItem item in this.Items)
            {
                if (item.Visible && item is ButtonItem && ((ButtonItem)item).Checked)
                    return item as ButtonItem;
            }

            return null;
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
                if(value == HVTTControlStyle.Office2007)
                    m_NCPainter.SkinScrollbars = eScrollBarSkin.Optimized;
                else
                    m_NCPainter.SkinScrollbars = eScrollBarSkin.None;
                this.ColorScheme.SwitchStyle(value);
                m_ItemContainer.Style = value;
                this.Invalidate();
                this.RecalcLayout();
            }
        }

        /// <summary>
        /// Gets or sets spacing in pixels between items. Default value is 1.
        /// </summary>
        [Browsable(true), DefaultValue(1), Category("Layout"), Description("Indicates spacing in pixels between items.")]
        public int ItemSpacing
        {
            get { return m_ItemContainer.ItemSpacing; }
            set
            {
                m_ItemContainer.ItemSpacing = value;
            }
        }

        /// <summary>
        /// Gets or sets default layout orientation inside the control. You can have multiple layouts inside of the control by adding
        /// one or more instances of the ItemContainer object and chaning it's LayoutOrientation property.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), Category("Layout"), DefaultValue(HVTTOrientation.Horizontal), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual HVTTOrientation LayoutOrientation
        {
            get { return m_ItemContainer.LayoutOrientation; }
            set
            {
                m_ItemContainer.LayoutOrientation = value;
                if (this.DesignMode)
                    this.RecalcLayout();
            }
        }

        /// <summary>
        /// Gets or sets whether items contained by container are resized to fit the container bounds. When container is in horizontal
        /// layout mode then all items will have the same height. When container is in vertical layout mode then all items
        /// will have the same width. Default value is true.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), DefaultValue(true), Category("Layout")]
        public bool ResizeItemsToFit
        {
            get { return m_ItemContainer.ResizeItemsToFit; }
            set
            {
                m_ItemContainer.ResizeItemsToFit = value;
            }
        }

        /// <summary>
        /// Gets or sets the item alignment when container is in horizontal layout. Default value is Left.
        /// </summary>
        [Browsable(true), DefaultValue(eHorizontalItemsAlignment.Left), Category("Layout"), Description("Indicates item alignment when container is in horizontal layout."), HVTTBrowsable(true)]
        public eHorizontalItemsAlignment HorizontalItemAlignment
        {
            get { return m_ItemContainer.HorizontalItemAlignment; }
            set
            {
                m_ItemContainer.HorizontalItemAlignment = value;
            }
        }

        /// <summary>
        /// Gets or sets whether items in horizontal layout are wrapped into the new line when they cannot fit allotted container size. Default value is false.
        /// </summary>
        [Browsable(true), DefaultValue(false), Category("Layout"), Description("Indicates whether items in horizontal layout are wrapped into the new line when they cannot fit allotted container size.")]
        public bool MultiLine
        {
            get { return m_ItemContainer.MultiLine; }
            set
            {
                m_ItemContainer.MultiLine = value;
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

        /// <summary>
        /// Scrolls the control so that item is displayed within the visible bounds of the control.
        /// </summary>
        /// <param name="item">Item to ensure visiblity for. Item must belong to this control.</param>
        public void EnsureVisible(BaseItem item)
        {
            if (item.ContainerControl != this)
                return;

            Rectangle r = item.DisplayRectangle;
            if (!this.ClientRectangle.Contains(r))
            {
                if (this.AutoScroll)
                {
                    Point p = Point.Empty;
                    if (r.Y < 0)
                        p = new Point(this.AutoScrollPosition.X, Math.Abs(this.AutoScrollPosition.Y - r.Y) - 2);
                    else
                        p = new Point(this.AutoScrollPosition.X,
                                                                  r.Bottom - (this.AutoScrollPosition.Y + this.ClientRectangle.Height));
                    this.InvalidateLayout();
                    this.AutoScrollPosition = p;
                    this.RecalcLayout();
                }
            }
            m_NCPainter.PaintNonClientAreaBuffered();
        }

        protected override Rectangle GetPaintClipRectangle()
        {
            Rectangle r = this.ClientRectangle;

            if (this.BackgroundStyle == null)
                return r;

            //r.X += ElementStyleLayout.LeftWhiteSpace(this.BackgroundStyle);
            //r.Width -= ElementStyleLayout.HorizontalStyleWhiteSpace(this.BackgroundStyle);
            //r.Y += ElementStyleLayout.TopWhiteSpace(this.BackgroundStyle);
            //r.Height -= ElementStyleLayout.VerticalStyleWhiteSpace(this.BackgroundStyle);

            return r;
        }

        protected override Rectangle GetItemContainerRectangle()
        {
            Rectangle r = base.GetItemContainerRectangle();
            if (this.AutoScroll && this.AutoScrollPosition.Y!=0)
                r.Y += this.AutoScrollPosition.Y;
            return r;
        }

        private void ApplyScrollChange()
        {
            if (!this.AutoScroll) return;

            if (m_ItemContainer.NeedRecalcSize)
            {
                this.RecalcSize();
                return;
            }

            Rectangle r = base.GetItemContainerRectangle();
            if (this.AutoScrollPosition.Y != 0)
                r.Y += this.AutoScrollPosition.Y;
            r.Height = m_ItemContainer.HeightInternal;
            m_ItemContainer.Bounds = r;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!this.Focused)
                this.Select();

            m_MouseDownPoint.X = e.X;
            m_MouseDownPoint.Y = e.Y;

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (m_EnableDragDrop && !this.DragInProgress && e.Button == MouseButtons.Left)
            {
                if (Math.Abs(e.X - m_MouseDownPoint.X) > SystemInformation.DragSize.Width ||
                    Math.Abs(e.Y - m_MouseDownPoint.Y) > SystemInformation.DragSize.Height)
                {
                    BaseItem item = HitTest(e.X, e.Y);
                    if (item != null)
                        ((IOwner)this).StartItemDrag(item);
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.Focused)
            {
                KeyEventArgs e = new KeyEventArgs(keyData);
                m_ItemContainer.InternalKeyDown(e);
                if (e.Handled)
                    return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// Gets or sets the minimum size of the auto-scroll.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size AutoScrollMinSize
        {
            get { return base.AutoScrollMinSize; }
            set { base.AutoScrollMinSize = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the container will allow the user to scroll to any controls placed outside of its visible boundaries.
        /// </summary>
        [DefaultValue(false), Browsable(true)]
        public override bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }
            set
            {
                if (!value)
                    this.AutoScrollMinSize = Size.Empty;
                base.AutoScroll = value;
                RecalcLayout();
            }
        }
        
        protected override void RecalcSize()
        {
            m_ItemContainer.MinimumSize = new Size(this.GetItemContainerRectangle().Width, 0);
            base.RecalcSize();
            
            if (!this.AutoSize && this.AutoScroll)
            {
                if (m_ItemContainer.HeightInternal > this.ClientRectangle.Height)
                {
                    Size areaSize = new Size(this.ClientRectangle.Width - (SystemInformation.VerticalScrollBarWidth + 2), m_ItemContainer.HeightInternal);
                    if (this.BackgroundStyle != null)
                    {
                        //areaSize.Width += ElementStyleLayout.HorizontalStyleWhiteSpace(this.BackgroundStyle);
                        areaSize.Height += ElementStyleLayout.VerticalStyleWhiteSpace(this.BackgroundStyle);
                    }

                    /*if (!this.AutoScroll)
                    {
                        this.Invalidate();
                        this.AutoScroll = true;
                        this.AutoScrollMinSize = areaSize;
                    }
                    else*/ 
                    if (this.AutoScrollMinSize != areaSize)
                    {
                        this.Invalidate();
                        bool b = this.VScroll;
                        this.AutoScrollMinSize = areaSize;
                        if (b != this.VScroll && this.Style == HVTTControlStyle.Office2007)
                        {
                            NativeFunctions.SetWindowPos(this.Handle, 0, 0, 0, 0, 0, NativeFunctions.SWP_FRAMECHANGED |
                                NativeFunctions.SWP_NOACTIVATE | NativeFunctions.SWP_NOMOVE | NativeFunctions.SWP_NOSIZE | NativeFunctions.SWP_NOZORDER);
                            m_NCPainter.UpdateScrollValues();
                        }
                    }
                }
                else if (!this.AutoScrollMinSize.IsEmpty)
                {
                    this.AutoScrollMinSize = Size.Empty;
                    //this.AutoScroll = false;
                }
            }
            //else if (!this.AutoScrollMinSize.IsEmpty)
            //{
            //    this.AutoScrollMinSize = Size.Empty;
            //}
        }

        protected override void OnVisualPropertyChanged()
        {
            if (this.GetDesignMode() ||
                this.Parent != null && this.Parent.Site != null && this.Parent.Site.DesignMode)
            {
                if (BarFunctions.IsHandleValid(this))
                {
                    NativeFunctions.SetWindowPos(this.Handle, 0, 0, 0, 0, 0,
                        NativeFunctions.SWP_FRAMECHANGED | NativeFunctions.SWP_NOACTIVATE | NativeFunctions.SWP_NOMOVE |
                        NativeFunctions.SWP_NOOWNERZORDER | NativeFunctions.SWP_NOSENDCHANGING | NativeFunctions.SWP_NOSIZE |
                        NativeFunctions.SWP_NOZORDER);
                    this.InvalidateNonClient();
                }
            }
            else
                this.InvalidateNonClient();
            base.OnVisualPropertyChanged();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (m_NCPainter != null) m_NCPainter.PaintNonClientAreaBuffered();
        }
        /// <summary>
        /// This member overrides Control.WndProc.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override void WndProc(ref Message m)
        {
            if (m_NCPainter == null)
            {
                base.WndProc(ref m);
                return;
            }

            bool callBase = true;

            if (this.AutoScroll)
            {
                if (m.Msg == (int)WinApi.WindowsMessages.WM_HSCROLL || m.Msg == (int)WinApi.WindowsMessages.WM_VSCROLL || m.Msg == (int)WinApi.WindowsMessages.WM_MOUSEWHEEL)
                {
                    m_SuspendPaint = true;
                    m_NCPainter.SuspendPaint = true;
                    try
                    {
                        callBase = m_NCPainter.WndProc(ref m);
                        if (callBase)
                            base.WndProc(ref m);
                    }
                    finally
                    {
                        m_SuspendPaint = false;
                        m_NCPainter.SuspendPaint = false;
                    }
                    ApplyScrollChange();
                    m_NCPainter.PaintNonClientAreaBuffered();
                    return;
                }
                else if (m.Msg == (int)WinApi.WindowsMessages.WM_COMMAND && this.Controls.Count > 0 && WinApi.HIWORD(m.WParam)==0x100 && m.LParam!=IntPtr.Zero)
                {
                    Control c = Control.FromChildHandle(m.LParam);
                    Rectangle r = new Rectangle(Point.Empty, this.ClientSize);
                    r.Inflate(-1, -1);
                    if (c != null && c.Parent == this && !r.Contains(c.Bounds))
                    {
                        m_SuspendPaintCount = 2;
                    }
                }
            }

            callBase = m_NCPainter.WndProc(ref m);

            if (callBase)
                base.WndProc(ref m);
        }
        
        protected override void PaintControlBackground(ItemPaintArgs pa)
        {
            ElementStyle style = GetBackgroundStyle();
            if (style != null)
            {
                Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
                if (style.PaintBorder && (style.CornerType == CornerType.Rounded || style.CornerType == CornerType.Diagonal))
                {
                    style = style.Copy();
                    style.CornerType = CornerType.Square;
                    style.Border = StyleBorderType.None;
                    r.Inflate(style.BorderWidth, style.BorderWidth);
                }

                ElementStyleDisplayInfo displayInfo = new ElementStyleDisplayInfo(style, pa.Graphics, r);
                ElementStyleDisplay.PaintBackground(displayInfo);
                ElementStyleDisplay.PaintBackgroundImage(displayInfo);
            }
        }

        /// <summary>
        /// Gets or sets the scrollbar skinning type when control is using Office 2007 style.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public eScrollBarSkin ScrollbarSkin
        {
            get { return m_NCPainter.SkinScrollbars; }
            set { m_NCPainter.SkinScrollbars = value; }
        }

        // Unified OnPaint without licensing logic
        protected override void OnPaint(PaintEventArgs e)
        {
            if (m_SuspendPaint) return;
            if (m_SuspendPaintCount > 0)
            {
                m_SuspendPaintCount--;
                if (m_SuspendPaintCount == 0 && this.AutoScroll)
                {
                    this.ApplyScrollChange();
                    this.Invalidate();
                }
                return;
            }
            base.OnPaint(e);
        }
        #endregion

        #region IScrollableItemControl Members
        void IScrollableItemControl.KeyboardItemSelected(BaseItem item)
        {
            if (item != null)
                EnsureVisible(item);
        }
        #endregion

        #region Misc Properties
        [Browsable(true), DefaultValue(false), Category("Behavior"), Description("Gets or sets whether external ButtonItem object is accepted in drag and drop operation. UseNativeDragDrop must be set to true in order for this property to be effective.")]
        public override bool AllowExternalDrop
        {
            get { return base.AllowExternalDrop; }
            set { base.AllowExternalDrop = value; }
        }

        [Browsable(true), DefaultValue(false), Category("Behavior"), Description("Specifies whether native .NET Drag and Drop is used by control to perform drag and drop operations. AllowDrop must be set to true to allow drop of the items on control.")]
        public override bool UseNativeDragDrop
        {
            get { return base.UseNativeDragDrop; }
            set { base.UseNativeDragDrop = value; }
        }

        [Browsable(true), DefaultValue(false), Category("Behavior"), Description("Specifies whether automatic drag & drop support is enabled.")]
        public virtual bool EnableDragDrop
        {
            get { return m_EnableDragDrop; }
            set { m_EnableDragDrop = value; }
        }
        #endregion

        #region INonClientControl Members
        void HVTT.UI.Window.Forms.Controls.INonClientControl.BaseWndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        ItemPaintArgs HVTT.UI.Window.Forms.Controls.INonClientControl.GetItemPaintArgs(Graphics g)
        {
            return GetItemPaintArgs(g);
        }

        ElementStyle HVTT.UI.Window.Forms.Controls.INonClientControl.BorderStyle
        {
            get { return this.GetBackgroundStyle(); }
        }

        void HVTT.UI.Window.Forms.Controls.INonClientControl.PaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        IntPtr HVTT.UI.Window.Forms.Controls.INonClientControl.Handle
        {
            get { return this.Handle; }
        }

        int HVTT.UI.Window.Forms.Controls.INonClientControl.Width
        {
            get { return this.Width; }
        }

        int HVTT.UI.Window.Forms.Controls.INonClientControl.Height
        {
            get { return this.Height; }
        }

        bool HVTT.UI.Window.Forms.Controls.INonClientControl.IsHandleCreated
        {
            get { return this.IsHandleCreated; }
        }

        Point HVTT.UI.Window.Forms.Controls.INonClientControl.PointToScreen(Point client)
        {
            return this.PointToScreen(client);
        }

        Color HVTT.UI.Window.Forms.Controls.INonClientControl.BackColor
        {
            get { return this.BackColor; }
        }
        void HVTT.UI.Window.Forms.Controls.INonClientControl.AdjustClientRectangle(ref Rectangle r) { }
        void HVTT.UI.Window.Forms.Controls.INonClientControl.AdjustBorderRectangle(ref Rectangle r) { }
        #endregion
    }
}
