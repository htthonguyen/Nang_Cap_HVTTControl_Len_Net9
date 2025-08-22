using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System;
using System.Drawing;

namespace HVTT.UI.Window.Forms.Design
{
    public class ExpandablePanelDesigner : PanelExDesigner
    {
        #region Internal Implementation
        

        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            SetDesignTimeDefaults();
        }


        private void SetDesignTimeDefaults()
        {
            ExpandablePanel p = this.Control as ExpandablePanel;
            if (p == null)
                return;
            p.ApplyLabelStyle();
            p.Style.BorderColor.ColorSchemePart = eColorSchemePart.BarDockedBorder;
            p.Style.Border = eBorderType.SingleLine;
            p.Style.BackColor1.ColorSchemePart = eColorSchemePart.PanelBackground;
            p.Style.BackColor2.ColorSchemePart = eColorSchemePart.PanelBackground2;
            p.Text = "";
			p.TitlePanel.ApplyPanelStyle();
            this.ColorSchemeStyle = HVTTControlStyle.Office2007;
        }

        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);
            properties["ColorSchemeStyle"] = TypeDescriptor.CreateProperty(typeof(ExpandablePanelDesigner), (PropertyDescriptor)properties["ColorSchemeStyle"], new Attribute[]
				{
					new DefaultValueAttribute(HVTTControlStyle.Office2003),
					new BrowsableAttribute(true),
					new CategoryAttribute("Style"),
                    new DescriptionAttribute("Gets or sets color scheme style.")});
        }

        /// <summary>
        ///     Gets or sets color scheme style.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), Category("Style"), Description("Gets or sets color scheme style."), DefaultValue(HVTTControlStyle.Office2003)]
        public HVTTControlStyle ColorSchemeStyle
        {
            get
            {
                ExpandablePanel ep = this.Control as ExpandablePanel;
                return ep.ColorSchemeStyle;
            }
            set
            {
                ExpandablePanel ep = this.Control as ExpandablePanel;
                ep.ColorSchemeStyle = value;
                IDesignerHost dh = this.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (dh != null && !dh.Loading)
                {
                    if (value == HVTTControlStyle.Office2007)
                        ep.TitleStyle.Border = eBorderType.RaisedInner;
                    else
                        ep.TitleStyle.Border = eBorderType.SingleLine;
                }
            }
        }

        protected override bool GetHitTest(System.Drawing.Point pt)
        {
            ExpandablePanel p = this.Control as ExpandablePanel;
            if (p != null)
            {
                Point pt2 = p.PointToClient(pt);
                PanelExTitle titlePanel = p.TitlePanel as PanelExTitle;
                if (titlePanel != null && titlePanel.ExpandChangeButton!=null && titlePanel.ExpandChangeButton.DisplayRectangle.Contains(pt2))
                    return true;
                else if (titlePanel != null && titlePanel.ExpandChangeButton!=null)
                    titlePanel.ExpandChangeButton.InternalMouseLeave();

            }
            return base.GetHitTest(pt);
        }
        #endregion
    }
}
