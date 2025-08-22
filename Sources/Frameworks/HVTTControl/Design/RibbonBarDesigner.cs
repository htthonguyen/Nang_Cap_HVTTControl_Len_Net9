using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Collections;

namespace HVTT.UI.Window.Forms.Design
{
	/// <summary>
	/// Represents Windows Forms Designer for RibbonBar control
	/// </summary>
	public class RibbonBarDesigner:BarBaseControlDesigner
	{
		public RibbonBarDesigner()
		{
			this.EnableItemDragDrop=true;
		}

		public override void Initialize(IComponent component) 
		{
			base.Initialize(component);
			if(component==null || component.Site==null || !component.Site.DesignMode)
				return;
		}


        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            SetDesignTimeDefaults();
        }

		public override void OnSetComponentDefaults()
		{
            SetDesignTimeDefaults();
			base.OnSetComponentDefaults();
		}

        private void SetDesignTimeDefaults()
        {
            RibbonBar b = this.Control as RibbonBar;
            this.Style = HVTTControlStyle.Office2007;
        }

		public override DesignerVerbCollection Verbs 
		{
			get 
			{
				HVTTMarkStatus bar=this.Control as HVTTMarkStatus;
				DesignerVerb[] verbs=null;
				verbs = new DesignerVerb[]
						{
							new DesignerVerb("Add Button", new EventHandler(CreateButton)),
							new DesignerVerb("Add Horizontal Container", new EventHandler(CreateHorizontalContainer)),
							new DesignerVerb("Add Vertical Container", new EventHandler(CreateVerticalContainer)),
							new DesignerVerb("Add Text Box", new EventHandler(CreateTextBox)),
							new DesignerVerb("Add Combo Box", new EventHandler(CreateComboBox)),
							new DesignerVerb("Add Label", new EventHandler(CreateLabel)),
							new DesignerVerb("Add Color Picker", new EventHandler(CreateColorPicker)),
                            new DesignerVerb("Add Check Box", new EventHandler(CreateCheckBox)),
                            new DesignerVerb("Add Slider", new EventHandler(CreateSliderItem)),
                            new DesignerVerb("Add Gallery Container", new EventHandler(CreateGalleryContainer)),
                            new DesignerVerb("Add Control Container", new EventHandler(CreateControlContainer))};
				return new DesignerVerbCollection(verbs);
			}
		}

		private void CreateVerticalContainer(object sender, EventArgs e)
		{
			CreateContainer(this.GetItemContainer(),HVTTOrientation.Vertical);
		}

		private void CreateHorizontalContainer(object sender, EventArgs e)
		{
			CreateContainer(this.GetItemContainer(),HVTTOrientation.Horizontal);
		}

		private void CreateContainer(BaseItem parent, HVTTOrientation orientation)
		{
            m_CreatingItem = true;
            try
            {
                DesignerSupport.CreateItemContainer(this, parent, orientation);
            }
            finally
            {
                m_CreatingItem = false;
            }
			this.RecalcLayout();
		}
		protected override void PreFilterProperties(
			System.Collections.IDictionary properties) 
		{
			base.PreFilterProperties(properties);
			properties["Style"] = 
				TypeDescriptor.CreateProperty(typeof(RibbonBarDesigner), 
				(PropertyDescriptor)properties["Style"], 
				new Attribute[0]);
		}

		/// <summary>
		/// Gets/Sets the visual style of the control.
		/// </summary>
		[Browsable(true),HVTTBrowsable(true),Category("Appearance"),Description("Specifies the visual style of the control."),DefaultValue(HVTTControlStyle.Office2003)]
		public HVTTControlStyle Style
		{
			get
			{
				RibbonBar bar=this.Control as RibbonBar;
				return bar.Style;
			}
			set 
			{
				RibbonBar bar=this.Control as RibbonBar;
				bar.Style=value;
				IDesignerHost dh=this.GetService(typeof(IDesignerHost)) as IDesignerHost;
				if(dh!=null && !dh.Loading)
				{
                    RibbonPredefinedColorSchemes.SetRibbonBarStyle(bar, value);
				}
			}
		}

        protected override void OnitemCreated(BaseItem item)
        {
            if (item is ButtonItem)
            {
                ButtonItem b = item as ButtonItem;
                TypeDescriptor.GetProperties(b)["SubItemsExpandWidth"].SetValue(b, 14);
            }
            base.OnitemCreated(item);
        }
	}
}
