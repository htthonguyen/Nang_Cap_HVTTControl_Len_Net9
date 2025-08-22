using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Collections;
using System.Drawing;
using System.ComponentModel.Design;
using System.ComponentModel;

namespace HVTT.UI.Window.Forms.Design
{
	/// <summary>
	/// Summary description for SuperTooltipDesigner.
	/// </summary>
	public class SuperTooltipDesigner:ComponentDesigner
    {
        #region Internal Implementation
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            if (!component.Site.DesignMode)
                return;
        }

        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            SetDesignTimeDefaults();
        }

		private void SetDesignTimeDefaults()
		{
			SuperTooltip sp=this.Component as SuperTooltip;
			if(sp==null)
				return;
        }
        #endregion
    }
}
