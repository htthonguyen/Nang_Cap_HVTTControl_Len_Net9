using System;
using System.Text;

namespace HVTT.UI.Window.Forms
{
    /// <summary>
    /// Represents painter for the MdiSystemItem.
    /// </summary>
    internal class MdiSystemItemPainter
    {
        /// <summary>
        /// Paints MdiSystemItem.
        /// </summary>
        /// <param name="e">Provides arguments for the operation.</param>
        public virtual void Paint(MdiSystemItemRendererEventArgs e) { }
    }
}
