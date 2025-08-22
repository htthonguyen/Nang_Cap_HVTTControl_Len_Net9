using System;
using System.Text;

namespace HVTT.UI.Window.Forms.Rendering
{
    /// <summary>
    /// Defines base class for QAT overflow item painter.
    /// </summary>
    internal abstract class QatOverflowPainter
    {
        public abstract void Paint(QatOverflowItemRendererEventArgs e);
    }
}
