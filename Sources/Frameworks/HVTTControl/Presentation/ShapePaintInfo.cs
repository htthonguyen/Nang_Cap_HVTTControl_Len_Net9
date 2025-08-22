using System;
using System.Text;
using System.Drawing;

namespace HVTT.UI.Window.Forms.Presentation
{
    internal class ShapePaintInfo
    {
        public ShapePaintInfo(Graphics g, System.Drawing.Rectangle bounds)
        {
            this.Graphics = g;
            this.Bounds = bounds;
        }

        public Graphics Graphics;
        public System.Drawing.Rectangle Bounds = System.Drawing.Rectangle.Empty;
        public Region ChildContentClip = null;
    }
}
