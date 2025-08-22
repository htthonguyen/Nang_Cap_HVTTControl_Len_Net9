using System;
using System.Text;
using System.Drawing;
using System.Xml;

using HVTT.UI.ContentManager;
namespace HVTT.UI.Window.Forms.TextMarkup
{
    internal class Paragraph : Div
    {
        #region Internal Implementation
        protected override void ArrangeInternal(Rectangle bounds, MarkupDrawContext d)
        {
            base.ArrangeInternal(bounds, d);
            this.Bounds = new Rectangle(this.Bounds.X, this.Bounds.Y, this.Bounds.Width , this.Bounds.Height + d.CurrentFont.Height);
        }
        #endregion
    }

    
}
