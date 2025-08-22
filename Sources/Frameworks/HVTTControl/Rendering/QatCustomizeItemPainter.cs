using System;
using System.Text;

namespace HVTT.UI.Window.Forms.Rendering
{
    /// <summary>
    /// Defines base class for QAT customize item painter.
    /// </summary>
    internal abstract class QatCustomizeItemPainter
    {
        public abstract void Paint(QatCustomizeItemRendererEventArgs e);
    }
}
