using System;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;

namespace HVTT.UI.Window.Forms.Design
{
    /// <summary>
    /// Represents Windows Forms Designer for the ItemPanel control.
    /// </summary>
    public class ItemPanelDesigner : BarBaseControlDesigner
    {
        public ItemPanelDesigner()
		{
			this.EnableItemDragDrop=true;
		}

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            if (component == null || component.Site == null || !component.Site.DesignMode)
                return;
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
            ItemPanel panel = this.Control as ItemPanel;
            panel.LayoutOrientation = HVTTOrientation.Vertical;
            panel.BackgroundStyle.Border = StyleBorderType.Solid;
            panel.BackgroundStyle.BorderColor = ColorScheme.GetColor("7F9DB9");
            panel.BackgroundStyle.BorderWidth = 1;
            panel.BackgroundStyle.PaddingLeft = 1;
            panel.BackgroundStyle.PaddingRight = 1;
            panel.BackgroundStyle.PaddingTop = 1;
            panel.BackgroundStyle.PaddingBottom = 1;
            panel.BackgroundStyle.BackColor = Color.White;
        }

        public override DesignerVerbCollection Verbs
        {
            get
            {
                HVTTMarkStatus bar = this.Control as HVTTMarkStatus;
                DesignerVerb[] verbs = null;
                verbs = new DesignerVerb[]
						{
							new DesignerVerb("Add Button", new EventHandler(CreateButton)),
							new DesignerVerb("Add Horizontal Container", new EventHandler(CreateHorizontalContainer)),
							new DesignerVerb("Add Vertical Container", new EventHandler(CreateVerticalContainer)),
							new DesignerVerb("Add Text Box", new EventHandler(CreateTextBox)),
							new DesignerVerb("Add Combo Box", new EventHandler(CreateComboBox)),
							new DesignerVerb("Add Label", new EventHandler(CreateLabel)),
							new DesignerVerb("Add Color Picker", new EventHandler(CreateColorPicker)),
                            new DesignerVerb("Add Progress bar", new EventHandler(CreateProgressBar)),
                            new DesignerVerb("Add Check box", new EventHandler(CreateCheckBox)),
                            new DesignerVerb("Apply Panel Style", new EventHandler(ApplyPanelStyle)),
                            new DesignerVerb("Apply Default Style", new EventHandler(ApplyDefaultStyle))
                        };
                return new DesignerVerbCollection(verbs);
            }
        }

        private void ApplyPanelStyle(object sender, EventArgs e)
        {
            ItemPanel p = this.Control as ItemPanel;
            if (p == null)
                return;

            IComponentChangeService change = this.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            if (change != null)
                change.OnComponentChanging(this.Component, null);

            ElementStyle bs = p.BackgroundStyle;
            bs.Reset();

            bs.Border = StyleBorderType.Solid;
            bs.BorderWidth = 1;
            bs.BorderColorSchemePart = eColorSchemePart.PanelBorder;
            bs.BackColorSchemePart = eColorSchemePart.PanelBackground;
            bs.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
            bs.BackColorGradientAngle = 90;
            
            if (change != null)
                change.OnComponentChanged(this.Component, null, null, null);
        }

        private void ApplyDefaultStyle(object sender, EventArgs e)
        {
            ItemPanel p = this.Control as ItemPanel;
            if (p == null)
                return;

            IComponentChangeService change = this.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            if (change != null)
                change.OnComponentChanging(this.Component, null);

            ElementStyle bs = p.BackgroundStyle;
            bs.Reset();

            bs.Border = StyleBorderType.Solid;
            bs.BorderWidth = 1;
            bs.BorderColorSchemePart = eColorSchemePart.PanelBorder;
            bs.BackColor = Color.White;

            if (change != null)
                change.OnComponentChanged(this.Component, null, null, null);
        }

        private void CreateVerticalContainer(object sender, EventArgs e)
        {
            CreateContainer(this.GetItemContainer(), HVTTOrientation.Vertical);
        }

        private void CreateHorizontalContainer(object sender, EventArgs e)
        {
            CreateContainer(this.GetItemContainer(), HVTTOrientation.Horizontal);
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
    }
}
