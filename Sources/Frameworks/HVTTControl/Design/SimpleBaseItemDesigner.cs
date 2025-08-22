using System;
using System.Text;
using System.ComponentModel.Design;

namespace HVTT.UI.Window.Forms.Design
{
    public class SimpleBaseItemDesigner : BaseItemDesigner
    {
        public override DesignerVerbCollection Verbs
        {
            get
            {
                return new DesignerVerbCollection();
            }
        }
    }
}
