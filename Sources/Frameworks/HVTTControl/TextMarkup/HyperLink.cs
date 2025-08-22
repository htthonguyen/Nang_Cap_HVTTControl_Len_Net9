using System;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;


namespace HVTT.UI.Window.Forms.TextMarkup

{
    internal class HyperLink : MarkupElement, IActiveMarkupElement
    {
        #region Private Variables
        private Color m_ForeColor = Color.Blue;
        private Color m_OldForeColor = Color.Empty;
        private string m_HRef = "";
        private string m_Name = "";
        private Cursor m_OldCursor = null;
        #endregion

        #region Internal Implementation
        public override void Measure(Size availableSize, MarkupDrawContext d)
        {
            this.Bounds = Rectangle.Empty;
            SetForeColor(d);
        }

        public override void Render(MarkupDrawContext d)
        {
            d.HyperLink = true;
            SetForeColor(d);
        }

        protected virtual void SetForeColor(MarkupDrawContext d)
        {
            if (!m_ForeColor.IsEmpty)
            {
                m_OldForeColor = d.CurrentForeColor;
                d.CurrentForeColor = m_ForeColor;
            }
        }

        public override void RenderEnd(MarkupDrawContext d)
        {
            RestoreForeColor(d);
            d.HyperLink = false;
            base.RenderEnd(d);
        }

        public override void MeasureEnd(Size availableSize, MarkupDrawContext d)
        {
            RestoreForeColor(d);
            base.MeasureEnd(availableSize, d);
        }

        protected override void ArrangeCore(Rectangle finalRect, MarkupDrawContext d) { }

        protected virtual void RestoreForeColor(MarkupDrawContext d)
        {
            if (!m_OldForeColor.IsEmpty)
                d.CurrentForeColor = m_OldForeColor;
            m_OldForeColor = Color.Empty;
        }

        public Color ForeColor
        {
            get { return m_ForeColor; }
            set { m_ForeColor = value; }
        }

        public string HRef
        {
            get { return m_HRef; }
            set { m_HRef = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public override void ReadAttributes(XmlTextReader reader)
        {
            for (int i = 0; i < reader.AttributeCount; i++)
            {
                reader.MoveToAttribute(i);
                if (reader.Name.ToLower() == "href")
                {
                    m_HRef = reader.Value;
                }
                else if (reader.Name.ToLower() == "name")
                {
                    m_Name = reader.Value;
                }
            }
        }

        /// <summary>
        /// Returns whether hyper-link contains specified coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool HitTest(int x, int y)
        {
            if (this.Parent == null)
                return false;

            MarkupElementCollection col = this.Parent.Elements;
            int start = col.IndexOf(this)+1;
            for (int i = start; i < col.Count; i++)
            {
                MarkupElement el = col[i];
                if (el is EndMarkupElement && ((EndMarkupElement)el).StartElement == this)
                    break;

                if (col[i].RenderBounds.Contains(x, y))
                    return true;

            }

            return false;
        }

        public void MouseEnter(Control parent)
        {
            m_OldCursor = parent.Cursor;;
            parent.Cursor = Cursors.Hand;
        }

        public void MouseLeave(Control parent)
        {
            if (m_OldCursor != null && parent!=null)
                parent.Cursor = m_OldCursor;
            m_OldCursor = null;
        }

        public void MouseDown(Control parent, MouseEventArgs e) { }
        public void MouseUp(Control parent, MouseEventArgs e) { }
        public void Click(Control parent) { }
        #endregion
    }
}
