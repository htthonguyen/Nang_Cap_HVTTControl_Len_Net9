using System;
using System.Windows.Forms.Design;
using System.Collections;

namespace HVTT.UI.Window.Forms.Design
{
	#region PanelDockContainerDesigner
	/// <summary>
	/// Designer for Tab Control Panel.
	/// </summary>
	public class PanelDockContainerDesigner:PanelExDesigner
	{
		public override SelectionRules SelectionRules
		{
			get{return (SelectionRules.Locked | SelectionRules.Visible);} 
		}
        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            SetDesignTimeDefaults();
        }

		private void SetDesignTimeDefaults()
		{
			PanelDockContainer p = this.Control as PanelDockContainer;
			if (p == null)
				return;
			p.ApplyLabelStyle();
			p.Text = "";
		}
	}
	#endregion
}
