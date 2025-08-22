using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Collections;
using System.Drawing;
using System.ComponentModel.Design;
using System.ComponentModel;

namespace HVTT.UI.Window.Forms.Design
{
    /// <summary>
    /// Windows Forms Designer for PanelControl
    /// </summary>
    public class PanelControlDesigner : System.Windows.Forms.Design.ScrollableControlDesigner
    {
        public override DesignerVerbCollection Verbs
        {
            get
            {
                DesignerVerb[] verbs;
                verbs = new DesignerVerb[]
				{
					new DesignerVerb("Apply Panel Style", new EventHandler(ApplyPanelStyle)),
					new DesignerVerb("Apply Button Style", new EventHandler(ApplyButtonStyle)),
					new DesignerVerb("Apply Label Style", new EventHandler(ApplyLabelStyle))
				};
                return new DesignerVerbCollection(verbs);
            }
        }

        private void ApplyPanelStyle(object sender, EventArgs e)
        {
            PanelControl p = this.Control as PanelControl;
            if (p == null)
                return;

            IComponentChangeService change = this.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            if (change != null)
                change.OnComponentChanging(this.Component, null);

            p.ApplyPanelStyle();

            if (change != null)
                change.OnComponentChanged(this.Component, null, null, null);
        }

        private void ApplyButtonStyle(object sender, EventArgs e)
        {
            PanelControl p = this.Control as PanelControl;
            if (p == null)
                return;

            IComponentChangeService change = this.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            if (change != null)
                change.OnComponentChanging(this.Component, null);

            p.ApplyButtonStyle();

            if (change != null)
                change.OnComponentChanged(this.Component, null, null, null);
        }

        private void ApplyLabelStyle(object sender, EventArgs e)
        {
            PanelControl p = this.Control as PanelControl;
            if (p == null)
                return;

            IComponentChangeService change = this.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            if (change != null)
                change.OnComponentChanging(this.Component, null);

            p.ApplyLabelStyle();

            if (change != null)
                change.OnComponentChanged(this.Component, null, null, null);
        }

        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            SetDesignTimeDefaults();
        }


        protected virtual void SetDesignTimeDefaults()
        {
            PanelControl p = this.Control as PanelControl;
            if (p == null)
                return;
            p.ApplyPanelStyle();
            p.CanvasColor = SystemColors.Control;
        }

        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            PanelControl p;
            p = this.Component as PanelControl;
            if (p.Style.Border == StyleBorderType.None)
                this.DrawBorder(pe.Graphics);
            base.OnPaintAdornments(pe);
        }

        /// <summary>
        /// Draws design-time border around the panel when panel does not have one.
        /// </summary>
        /// <param name="g"></param>
        protected virtual void DrawBorder(Graphics g)
        {
            PanelControl panel = this.Control as PanelControl;
            Color border = SystemColors.ControlDarkDark;
            Rectangle rClient = this.Control.ClientRectangle;
            Color backColor = panel.Style.BackColor;

            BarFunctions.DrawDesignTimeSelection(g, rClient, backColor, border, 1);
        }
    }
}
