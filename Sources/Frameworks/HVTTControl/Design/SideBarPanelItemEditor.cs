using System;

namespace HVTT.UI.Window.Forms.Design
{
	/// <summary>
	/// Summary description for ComboItemsEditor.
	/// </summary>
	public class SideBarPanelItemEditor:System.ComponentModel.Design.CollectionEditor
	{
		public SideBarPanelItemEditor(Type type):base(type)
		{
		}
		protected override Type CreateCollectionItemType()
		{
			return typeof(ButtonItem);
		}
		protected override object CreateInstance(Type itemType)
		{
			object item=base.CreateInstance(itemType);
			if(item is ButtonItem)
			{
				ButtonItem button=item as ButtonItem;
				button.Text="New Item";
				button.ButtonStyle = HVTTButtonStyle.ImageAndText;
				button.ImagePosition=ImagePosition.Top;
			}
			return item;
		}
	}
}
