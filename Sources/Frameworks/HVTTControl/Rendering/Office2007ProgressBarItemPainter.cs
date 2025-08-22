using System;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HVTT.UI.Window.Forms.Rendering
{
    internal class Office2007ProgressBarItemPainter : ProgressBarItemPainter, IOffice2007Painter
    {
        #region IOffice2007Painter
        private Office2007ColorTable m_ColorTable = null; //new Office2007ColorTable();

        /// <summary>
        /// Gets or sets color table used by renderer.
        /// </summary>
        public Office2007ColorTable ColorTable
        {
            get { return m_ColorTable; }
            set { m_ColorTable = value; }
        }
        #endregion

        #region Internal Implementation
        public override void Paint(ProgressBarItemRenderEventArgs e)
        {
            Rectangle r = e.ProgressBarItem.DisplayRectangle;
            if (r.Width <= 0 || r.Height <= 0)
                return;

            ProgressBarItem item = e.ProgressBarItem;
            Office2007ProgressBarColorTable ct = m_ColorTable.ProgressBarItem;
            if(item.ColorTable == eProgressBarItemColor.Paused)
                ct = m_ColorTable.ProgressBarItemPaused;
            else if (item.ColorTable == eProgressBarItemColor.Error)
                ct = m_ColorTable.ProgressBarItemError;
            
            Graphics g = e.Graphics;

            DisplayHelp.DrawRoundedRectangle(g, ct.OuterBorder, r, 2);
            r.Inflate(-1, -1);
            
            Brush brush = DisplayHelp.CreateBrush(r, ct.BackgroundColors);
            if (brush != null)
            {
                g.FillRectangle(brush, r);
                brush.Dispose();
            }
            DisplayHelp.DrawRoundedRectangle(g, ct.InnerBorder, r, 2);
            r.Inflate(-1, -1);

            Region oldClip = g.Clip;
            try
            {
                g.SetClip(r, CombineMode.Intersect);

                Rectangle chunkRect = r;
                if (item.ProgressType == eProgressItemType.Marquee)
                {
                    chunkRect.Width = (int)(chunkRect.Width * .3);
                    chunkRect.X += r.Width * item.MarqueeValue / 100 - (int)(chunkRect.Width / 2);
                }
                else
                    chunkRect.Width = (int)(chunkRect.Width * ((float)(item.Value - item.Minimum) / (float)(item.Maximum - item.Minimum)));
                if (chunkRect.Width <= 0) return;

                brush = DisplayHelp.CreateBrush(chunkRect, ct.Chunk);
                if (brush != null)
                {
                    g.FillRectangle(brush, chunkRect);
                    brush.Dispose();
                }

                brush = DisplayHelp.CreateBrush(chunkRect, ct.ChunkOverlay);
                if (brush != null)
                {
                    g.FillRectangle(brush, chunkRect);

                    if (item.ProgressType == eProgressItemType.Marquee && chunkRect.Right > r.Right + 4)
                    {
                        chunkRect = new Rectangle(r.X, r.Y, chunkRect.Right - r.Right - 4, r.Height);
                        g.FillRectangle(brush, chunkRect);
                    }

                    brush.Dispose();
                }

                if (chunkRect.Right + 4 <= r.Right)
                {
                    chunkRect.X = chunkRect.Right;
                    chunkRect.Width = 4;
                    brush = DisplayHelp.CreateBrush(chunkRect, ct.ChunkShadow);
                    if (brush != null)
                    {
                        g.FillRectangle(brush, chunkRect);
                        brush.Dispose();
                    }
                }
            }
            finally
            {
                g.Clip = oldClip;
            }
        }

        #endregion
    }
}
