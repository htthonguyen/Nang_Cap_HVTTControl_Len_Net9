using System;
using System.Text;

namespace HVTT.UI.Window.Forms.Rendering
{
    /// <summary>
    /// Defines abstract class for the ProgressBarItem painter.
    /// </summary>
    internal abstract class ProgressBarItemPainter
    {
        public abstract void Paint(ProgressBarItemRenderEventArgs e);
    }
}
