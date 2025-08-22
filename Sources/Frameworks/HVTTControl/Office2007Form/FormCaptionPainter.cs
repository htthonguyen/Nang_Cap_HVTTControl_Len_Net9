using System;
using System.Text;

namespace HVTT.UI.Window.Forms
{
    /// <summary>
    /// Defines the abstract class for form caption painter.
    /// </summary>
    internal abstract class FormCaptionPainter
    {
        public abstract void PaintCaptionBackground(FormCaptionRendererEventArgs e);
    }
}
