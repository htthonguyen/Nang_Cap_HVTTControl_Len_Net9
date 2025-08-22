using System;
using System.Text;

namespace HVTT.UI.Window.Forms
{
    internal abstract class DialogLauncherPainter
    {
        public abstract void PaintDialogLauncher(RibbonBarRendererEventArgs e);
        //public virtual void PaintBackground(RibbonBarRendererEventArgs e) { }
        //public virtual void PaintTitle(RibbonBarRendererEventArgs e) { }
    }
}
