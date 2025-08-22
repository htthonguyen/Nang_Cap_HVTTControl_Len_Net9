using System;
using System.Text;

namespace HVTT.UI.Window.Forms.Rendering
{
    internal class SideBarPainter
    {
        public virtual void PaintSideBar(SideBarRendererEventArgs e){}

        public virtual void PaintSideBarPanelItem(SideBarPanelItemRendererEventArgs e) { }
    }
}
