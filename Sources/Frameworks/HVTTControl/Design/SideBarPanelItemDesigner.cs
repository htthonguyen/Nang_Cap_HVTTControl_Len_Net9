using System;

namespace HVTT.UI.Window.Forms.Design
{
	public class SideBarPanelItemDesigner:BaseItemDesigner
	{
		protected override void BeforeNewItemAdded(BaseItem item)
		{
			base.BeforeNewItemAdded(item);
			if(item is ButtonItem)
			{
				ButtonItem button=item as ButtonItem;
					
				SideBarPanelItem panel=this.Component as SideBarPanelItem;
				if(panel.Appearance==SideBarAppearance.Flat)
				{
					button.ImagePosition=ImagePosition.Right;
					button.ButtonStyle=HVTTButtonStyle.ImageAndText;
				}
				else
				{
					button.ImagePosition=ImagePosition.Top;
				}
			}
		}
	}
}
