using System;
using System.Collections.Generic;
using System.Text;

namespace HVTT.UI.Window.Forms.Design
{
    partial class HVTTNumbericDesigner:System.Windows.Forms.Design.ControlDesigner
    {
        public HVTTNumbericDesigner()
        {
        }
        protected override void PostFilterProperties(System.Collections.IDictionary Properties)
        {
            Properties.Remove("AllowDrop");
            //Properties.Remove("BackColor");
            Properties.Remove("BackgroundImage");
            Properties.Remove("ContextMenu");
            Properties.Remove("Image");
            Properties.Remove("ImageAlign");
            Properties.Remove("ImageIndex");
            Properties.Remove("ImageList");
            Properties.Remove("BorderStyle");
        }
    }
}
