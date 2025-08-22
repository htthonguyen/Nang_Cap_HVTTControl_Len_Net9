using System;
using System.Text;
using System.Drawing;

namespace HVTT.UI.Window.Forms
{
    internal abstract class KeyTipsPainter
    {
        public abstract void PaintKeyTips(KeyTipsRendererEventArgs e);

        public static Size KeyTipsPadding = new Size(6, 4);
    }
}
