using System;
using System.Text;
using System.Windows.Forms.Design;
using HVTT.UI.Window.Forms.Controls;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel.Design;
using HVTT.UI.Editors;

namespace HVTT.UI.Window.Forms.Design
{
    /// <summary>
    /// Represents Windows Forms designer for the ComboBoxEx control.
    /// </summary>
    public class HVTTComboBoxDesigner : ControlDesigner
    {
        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            SetDesignTimeDefaults();
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            if (component.Site!=null && !component.Site.DesignMode)
                return;

            IComponentChangeService cc = (IComponentChangeService)GetService(typeof(IComponentChangeService));
            if (cc != null)
            {
                cc.ComponentRemoving += new ComponentEventHandler(this.OnComponentRemoved);
            }
        }

        protected override void Dispose(bool disposing)
        {
            IComponentChangeService cc = (IComponentChangeService)GetService(typeof(IComponentChangeService));
            if (cc != null)
                cc.ComponentRemoved -= new ComponentEventHandler(this.OnComponentRemoved);

            base.Dispose(disposing);
        }

        private void SetDesignTimeDefaults()
        {
            HVTTComboBox c = this.Control as HVTTComboBox;
            c.DisplayMember = "Text";
            c.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            c.FormattingEnabled = true;

            PropertyDescriptor d = TypeDescriptor.GetProperties(c)["Text"];
            if (d != null && d.PropertyType == typeof(string) && !d.IsReadOnly && d.IsBrowsable)
            {
                d.SetValue(c, "");
            }
        }

        private DesignerActionListCollection m_ActionLists;
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (m_ActionLists == null)
                {
                    m_ActionLists = new DesignerActionListCollection();
                    object o = this.GetType().Assembly.CreateInstance("System.Windows.Forms.Design.ListControlBoundActionList", false, System.Reflection.BindingFlags.NonPublic, null, new object[] { this }, null, null);
                    if(o!=null)
                        m_ActionLists.Add(o as DesignerActionList);
                }
                return m_ActionLists;
            }
        }
        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules r = base.SelectionRules;
                HVTTComboBox c = this.Control as HVTTComboBox; ;
                PropertyDescriptor d = TypeDescriptor.GetProperties(c)["DropDownStyle"];
                if (d == null)
                    return r;

                ComboBoxStyle style = (ComboBoxStyle)d.GetValue(c);
                if (style != ComboBoxStyle.DropDown && style != ComboBoxStyle.DropDownList)
                {
                    return r;
                }
                return (r & ~(SelectionRules.BottomSizeable | SelectionRules.TopSizeable));
            }
        }

        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            base.PreFilterProperties(properties);

            properties["FlatStyle"] = TypeDescriptor.CreateProperty(
                this.GetType(),
                "FlatStyle",
                typeof(FlatStyle),
                new Attribute[] { new BrowsableAttribute(true), new DefaultValueAttribute(FlatStyle.Flat)});
        }
        

        [Browsable(true), DefaultValue(FlatStyle.Flat), Description("Gets or sets the combo box flat style")]
        public FlatStyle FlatStyle
        {
            get
            {
                ComboBox cb = this.Control as ComboBox;
                return cb.FlatStyle;
            }
            set
            {
                ComboBox cb = this.Control as ComboBox;
                cb.FlatStyle = value;
            }
        }

		public override ICollection AssociatedComponents
		{
			get
			{
				ArrayList al = new ArrayList(base.AssociatedComponents);
				HVTTComboBox cex = this.Component as HVTTComboBox;
				foreach(object o in cex.Items)
				{
					if (o is ComboItem)
					{
						al.Add(o);
					}
				}
				return al;
			}
		}

		private void OnComponentRemoved(object sender, ComponentEventArgs e)
		{
			if (e.Component == this.Component)
			{
				HVTTComboBox cex = this.Component as HVTTComboBox;
				IDesignerHost dh = GetService(typeof(IDesignerHost)) as IDesignerHost;
				if (dh == null) return;
				foreach (object o in cex.Items)
				{
					if (o is ComboItem)
					{
						ComboItem ci = o as ComboItem;
						dh.DestroyComponent(ci);
					}
				}
			}
		}
    }
}
