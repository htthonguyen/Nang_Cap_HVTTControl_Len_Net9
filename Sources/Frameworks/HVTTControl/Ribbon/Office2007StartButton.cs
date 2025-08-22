using System;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using HVTT.UI.Window.Forms.Rendering;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms
{
    /// <summary>
    /// Represents the Office 2007 start round button displayed in the top-left corner of the Ribbon Control.
    /// </summary>
    [System.ComponentModel.ToolboxItem(false), System.ComponentModel.DesignTimeVisible(false), DefaultEvent("Click"), Designer(typeof(Design.BaseItemDesigner))]
    public class Office2007StartButton : ButtonItem
    {
        #region Private Variables
        private bool m_ThumbTucked = false;
        #endregion

        #region Internal Implementation
        public override void RecalcSize()
        {
            ButtonItemLayout.LayoutButton(this, true);
            m_NeedRecalcSize = false;
        }

        protected internal override void OnExpandChange()
        {
            m_ThumbTucked = false;
            if (!this.DesignMode && this.Expanded && this.PopupLocation.IsEmpty && this.PopupSide == PopupSide.Default && this.Parent is CaptionItemContainer)
            {
                if (this.SubItems.Count > 0 && this.SubItems[0] is ItemContainer &&
                    ((ItemContainer)this.SubItems[0]).BackgroundStyle.Class == ElementStyleClassKeys.RibbonFileMenuContainerKey)
                {
                    RibbonStrip rs = this.ContainerControl as RibbonStrip;
                    if (rs != null)
                    {
                        this.PopupLocation = new Point(this.IsRightToLeft ? this.Bounds.Right : this.LeftInternal, rs.GetItemContainerBounds().Y - 1);
                        m_ThumbTucked = true;
                    }
                }
            }

            base.OnExpandChange();
        }

        internal override bool PopupPositionAdjusted
        {
            get { return base.PopupPositionAdjusted; }
            set
            {
                base.PopupPositionAdjusted = value;
                if (base.PopupPositionAdjusted && m_ThumbTucked)
                    m_ThumbTucked = false;
            }
        }

        internal void OnMenuPaint(ItemPaintArgs pa)
        {
            if (!m_ThumbTucked) return;

            Graphics g = pa.Graphics;
            RibbonStrip rs = this.ContainerControl as RibbonStrip;
            if (rs != null)
            {
                if(pa.RightToLeft)
                    g.TranslateTransform(-(this.LeftInternal - pa.ContainerControl.Width + this.WidthInternal), -(rs.GetItemContainerBounds().Y - 1));
                else
                    g.TranslateTransform(-this.LeftInternal, -(rs.GetItemContainerBounds().Y - 1));
                g.ResetClip();
                Control c = pa.ContainerControl;
                pa.ContainerControl = rs;
                pa.IsOnMenu = false;
                this.IgnoreAlpha = true;
                this.Paint(pa);
                this.IgnoreAlpha = false;
                pa.ContainerControl = c;
                pa.IsOnMenu = true;
                g.ResetTransform();
            }
        }
        #endregion
    }
}
