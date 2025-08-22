using System;
using System.Text;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.Collections;
using System.ComponentModel.Design;

namespace HVTT.UI.Window.Forms.Design
{
    /// <summary>
    /// Represents the Windows Forms Designer for RibbonBarMergeContainer control.
    /// </summary>
    public class RibbonBarMergeContainerDesigner : ParentControlDesigner
    {

        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            SetDesignTimeDefaults();
        }


        private void SetDesignTimeDefaults()
        {
            RibbonBarMergeContainer c = this.Control as RibbonBarMergeContainer;
            if (c != null)
            {
                TypeDescriptor.GetProperties(c)["Visible"].SetValue(c, false);
                TypeDescriptor.GetProperties(c)["ColorSchemeStyle"].SetValue(c, HVTTControlStyle.Office2007);
            }
        }

        public override DesignerVerbCollection Verbs
        {
            get
            {
                DesignerVerbCollection verbs = new DesignerVerbCollection(new DesignerVerb[]
				    {
					    new DesignerVerb("Layout Ribbons", new EventHandler(LayoutRibbons))
                    });
                //verbs.AddRange(base.Verbs);

                return verbs;
            }
        }

        private void LayoutRibbons(object sender, EventArgs e)
        {
            RibbonPanel panel = this.Control as RibbonPanel;
            if (panel == null)
                return;

            IDesignerHost host = this.GetService(typeof(IDesignerHost)) as IDesignerHost;
            DesignerTransaction trans = null;
            if (host != null)
                trans = host.CreateTransaction("Rendering Layout");

            try
            {
                panel.LayoutRibbons();
            }
            finally
            {
                if (trans != null)
                    trans.Commit();
            }
        }
    }
}
