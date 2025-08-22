using System;
using System.Windows.Forms.Design;
using System.Collections;

namespace HVTT.UI.Window.Forms.Design
{
	/// <summary>
	/// Designer for Navigation Pane Panel.
	/// </summary>
	public class NavigationPanePanelDesigner:PanelExDesigner
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

		public override void OnSetComponentDefaults()
		{
			base.OnSetComponentDefaults();
			SetDesignTimeDefaults();
		}
		private void SetDesignTimeDefaults()
		{
			HVTTPanel p = this.Control as HVTTPanel;
			if (p == null)
				return;
			p.ApplyLabelStyle();
			p.Text = "";
		}
	}
}
