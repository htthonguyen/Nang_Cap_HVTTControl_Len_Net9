using System;
using System.Drawing;
using System.Text;

namespace HVTT.UI.Window.Forms.TextMarkup
{
    internal class TextElement : MarkupElement
    {
        #region Private Variables
        private string m_Text = "";
        private bool m_TrailingSpace = false;
        private bool m_EnablePrefixHandling = true;
        #endregion

        #region Internal Implementation
        public override void Measure(System.Drawing.Size availableSize, MarkupDrawContext d)
        {
            StringFormat format = new StringFormat(StringFormat.GenericTypographic);
            format.FormatFlags = StringFormatFlags.NoWrap;
            if (d.HotKeyPrefixVisible || !m_EnablePrefixHandling)
                format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
            else
                format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Hide;

            if (m_TrailingSpace)
            {
                if (d.CurrentFont.Italic)
                {
                    Size size=Size.Ceiling(d.Graphics.MeasureString(m_Text, d.CurrentFont, 0, format));
                    size.Width += (int)(d.Graphics.MeasureString("|", d.CurrentFont).Width / 4);
                    this.Bounds = new Rectangle(Point.Empty, size);
                }
                else
                    this.Bounds = new Rectangle(Point.Empty, Size.Ceiling(d.Graphics.MeasureString(m_Text + "|", d.CurrentFont, 0, format)));
            }
            else
                this.Bounds = new Rectangle(Point.Empty, Size.Ceiling(d.Graphics.MeasureString(m_Text, d.CurrentFont, 0, format)));
            
            IsSizeValid = true;
        }

        public override void Render(MarkupDrawContext d)
        {
            Rectangle r = this.Bounds;
            r.Offset(d.Offset);

            if (!d.ClipRectangle.IsEmpty && !r.IntersectsWith(d.ClipRectangle))
                return;
            
            StringFormat format = new StringFormat(StringFormat.GenericTypographic);
            format.FormatFlags = StringFormatFlags.NoWrap;
            if (d.RightToLeft) format.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
            if (d.HotKeyPrefixVisible)
                format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
            else
                format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Hide;
            if (!d.ClipRectangle.IsEmpty && r.Right > d.ClipRectangle.Right)
            {
                format.Trimming = StringTrimming.EllipsisCharacter;
                r.Width -= (r.Right - d.ClipRectangle.Right);
            }

            Graphics g = d.Graphics;

            using(SolidBrush brush=new SolidBrush(d.CurrentForeColor))
                g.DrawString(m_Text, d.CurrentFont, brush, r, format);

            if (d.HyperLink || d.Underline)
            {
                // Underline Hyperlink
                float descent = d.CurrentFont.FontFamily.GetCellDescent(d.CurrentFont.Style) * d.CurrentFont.Size/d.CurrentFont.FontFamily.GetEmHeight(d.CurrentFont.Style);
                using (Pen pen = new Pen(d.CurrentForeColor, 1))
                {
                    descent -= 1;
                    System.Drawing.Drawing2D.SmoothingMode sm = g.SmoothingMode;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                    g.DrawLine(pen, r.X, r.Bottom - descent, r.Right, r.Bottom - descent);
                    g.SmoothingMode = sm;
                }
            }

            this.RenderBounds = r;
        }

        protected override void ArrangeCore(System.Drawing.Rectangle finalRect, MarkupDrawContext d) {}

        public string Text
        {
            get { return m_Text; }
            set
            {
                m_Text = value;
                this.IsSizeValid = false;
            }
        }

        public bool TrailingSpace
        {
            get { return m_TrailingSpace; }
            set
            {
                m_TrailingSpace = value;
                this.IsSizeValid = false;
            }
        }

        public bool EnablePrefixHandling
        {
            get { return m_EnablePrefixHandling; }
            set { m_EnablePrefixHandling = value; }
        }
        #endregion
    }
}
