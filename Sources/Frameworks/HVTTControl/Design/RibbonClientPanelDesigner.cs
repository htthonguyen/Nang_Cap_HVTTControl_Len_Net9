using System;
using System.Text;
using HVTT.UI.Window.Forms.Rendering;
using System.Drawing;

namespace HVTT.UI.Window.Forms.Design
{
    public class RibbonClientPanelDesigner : PanelControlDesigner
    {
        protected override void SetDesignTimeDefaults()
        {
            PanelControl p = this.Control as PanelControl;
            if (p == null)
                return;
            p.CanvasColor = SystemColors.Control;
            p.Style.Class = ElementStyleClassKeys.RibbonClientPanelKey;
        }
    }
}
