using System;
using System.Text;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace HVTT.UI.Window.Forms.Design
{
    /// <summary>
    /// Represents Windows Forms designer for HVTTButton control.
    /// </summary>
    public class HVTTButtonDesigner : BarBaseControlDesigner
    {
        #region Constructor
        public HVTTButtonDesigner()
		{
			this.EnableItemDragDrop=false;
            this.PassiveContainer = true;
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            if (!component.Site.DesignMode)
                return;

            ((HVTTButton)component).SetDesignMode(true);
        }
        #endregion

        #region Internal Implementation
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
                            new DesignerVerb("Add Gallery Container", new EventHandler(CreateGalleryContainer)),
							new DesignerVerb("Add Text Box", new EventHandler(CreateTextBox)),
							new DesignerVerb("Add Combo Box", new EventHandler(CreateComboBox)),
							new DesignerVerb("Add Label", new EventHandler(CreateLabel)),
                            new DesignerVerb("Add Check Box", new EventHandler(CreateCheckBox)),
                            new DesignerVerb("Add Slider", new EventHandler(CreateSliderItem)),
                            new DesignerVerb("Add Control Container", new EventHandler(CreateControlContainer)),
							new DesignerVerb("Add Color Picker", new EventHandler(CreateColorPicker))};
                return new DesignerVerbCollection(verbs);
            }
        }

        protected override void OnitemCreated(BaseItem item)
        {
            TypeDescriptor.GetProperties(item)["GlobalItem"].SetValue(item, false);
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
            try
            {
                m_CreatingItem = true;
                DesignerSupport.CreateItemContainer(this, parent, orientation);
            }
            finally
            {
                m_CreatingItem = false;
            }
            this.RecalcLayout();
        }

        protected override BaseItem GetItemContainer()
        {
            HVTTButton button = this.Control as HVTTButton;
            if (button != null)
                return button.InternalItem;
            return base.GetItemContainer();
        }

        public override bool CanParent(Control control)
        {
            return false;
        }

        protected override void OnMouseDragBegin(int x, int y)
        {
            HVTTButton ctrl = this.GetItemContainerControl() as HVTTButton;
            if (ctrl != null)
            {
                ButtonItem container = this.GetItemContainer() as ButtonItem;
                Point pos = ctrl.PointToClient(new Point(x, y));
                MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, 0, pos.X, pos.Y, 0);
                if (container != null && !container.SubItemsRect.IsEmpty && container.SubItemsRect.Contains(pos) && container.SubItems.Count>0)
                {
                    container.Expanded = !container.Expanded;
                    return;
                }
            }
            base.OnMouseDragBegin(x, y);
        }

        protected override bool OnMouseDown(ref Message m, MouseButtons button)
        {
            return false;
        }

        protected override bool OnMouseUp(ref Message m)
        {
            HVTTButton ctrl = this.GetItemContainerControl() as HVTTButton;
            if (ctrl != null)
            {
                if (ctrl.Expanded && !this.DragInProgress)
                    return true;
            }

            bool bProcessed = false;

            BaseItem container = this.GetItemContainer();
            IOwner owner = this.GetIOwner();

            if (ctrl == null || owner == null || container == null)
                return false;

            Point pos = ctrl.PointToClient(System.Windows.Forms.Control.MousePosition);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, 0, pos.X, pos.Y, 0);
            container.InternalMouseUp(e);

            if (this.DragItem != null)
            {
                MouseDragDrop(pos.X, pos.Y);
                return true;
            }

            return bProcessed;
        }

        /// <summary>
        /// Triggered when some other component on the form is removed.
        /// </summary>
        protected override void OtherComponentRemoving(object sender, ComponentEventArgs e)
        {
            bool callBase = true;
            if (e.Component is BaseItem)
            {
                BaseItem item = e.Component as BaseItem;
                BaseItem parent = this.GetItemContainer();
                if (item!=null && parent!=null && parent.SubItems.Contains(item))
                {
                    parent.SubItems.Remove(item);
                    this.RecalcLayout();
                    callBase = false;
                }
            }
            if(callBase)
                base.OtherComponentRemoving(sender, e);
        }
        #endregion
    }
}
