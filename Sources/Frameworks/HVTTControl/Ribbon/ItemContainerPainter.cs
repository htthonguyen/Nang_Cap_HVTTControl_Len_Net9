using System;
using System.Text;

namespace HVTT.UI.Window.Forms
{
    internal abstract class ItemContainerPainter
    {
        public abstract void PaintBackground(ItemContainerRendererEventArgs e);

        public abstract void PaintItemSeparator(ItemContainerSeparatorRendererEventArgs e);
    }
}
