using System;
using System.ComponentModel.Design;

namespace HVTT.UI.Window.Forms.Design
{
	/// <summary>
	/// Reprensents Windows Forms Designer for ItemContainer object.
	/// </summary>
	public class ItemContainerDesigner:BaseItemDesigner
	{
		public override DesignerVerbCollection Verbs 
		{
			get 
			{
				DesignerVerb[] verbs = new DesignerVerb[]
					{
						new DesignerVerb("Add Button", new EventHandler(CreateButton)),
						new DesignerVerb("Add Horizontal Container", new EventHandler(CreateHorizontalContainer)),
						new DesignerVerb("Add Vertical Container", new EventHandler(CreateVerticalContainer)),
						new DesignerVerb("Add Text Box", new EventHandler(CreateTextBox)),
						new DesignerVerb("Add Combo Box", new EventHandler(CreateComboBox)),
						new DesignerVerb("Add Label", new EventHandler(CreateLabel)),
                        new DesignerVerb("Add Check Box", new EventHandler(CreateCheckBox)),
                        new DesignerVerb("Add Control Container", new EventHandler(CreateControlContainer)),
						new DesignerVerb("Add Color Picker", new EventHandler(CreateColorPicker)),
                        new DesignerVerb("Add Progress bar", new EventHandler(CreateProgressBar)),
                        new DesignerVerb("Add Slider", new EventHandler(CreateSlider))
				};
				return new DesignerVerbCollection(verbs);
			}
		}

		private void CreateVerticalContainer(object sender, EventArgs e)
		{
			CreateContainer(HVTTOrientation.Vertical);
		}

		private void CreateHorizontalContainer(object sender, EventArgs e)
		{
			CreateContainer(HVTTOrientation.Horizontal);
		}

		private void CreateContainer(HVTTOrientation orientation)
		{
            try
            {
                m_CreatingItem = true;
                DesignerSupport.CreateItemContainer(this, (BaseItem)this.Component, orientation);
                this.RecalcLayout();
            }
            finally
            {
                m_CreatingItem = false;
            }
		}

	}
}
