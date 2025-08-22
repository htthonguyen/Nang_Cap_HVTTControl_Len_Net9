using System;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HVTT.UI.Window.Forms.Rendering
{
    internal class Office2007SliderPainter : SliderPainter, IOffice2007Painter
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
        public override void Paint(SliderItemRendererEventArgs e)
        {
            Office2007SliderColorTable ct = m_ColorTable.Slider;
            SliderItem item = e.SliderItem;
            Office2007SliderStateColorTable decreaseCt = null;
            Office2007SliderStateColorTable increaseCt = null;
            Office2007SliderStateColorTable trackCt = null;

            if (item.GetEnabled())
            {
                decreaseCt = ct.Default;
                increaseCt = ct.Default;
                trackCt = ct.Default;

                if (item.MouseDownPart == eSliderPart.DecreaseButton)
                    decreaseCt = ct.Pressed;
                else if (item.MouseDownPart == eSliderPart.IncreaseButton)
                    increaseCt = ct.Pressed;
                else if(item.MouseDownPart == eSliderPart.TrackArea)
                    trackCt = ct.Pressed;
                else if (item.MouseOverPart == eSliderPart.DecreaseButton)
                    decreaseCt = ct.MouseOver;
                else if (item.MouseOverPart == eSliderPart.IncreaseButton)
                    increaseCt = ct.MouseOver;
                else if (item.MouseOverPart == eSliderPart.TrackArea)
                    trackCt = ct.MouseOver;
            }
            else
            {
                decreaseCt = ct.Disabled;
                increaseCt = ct.Disabled;
                trackCt = ct.Disabled;
            }

            Rectangle itemRect=  item.DisplayRectangle;
            Rectangle r = item.LabelBounds;
            Graphics g = e.Graphics;

            string text = GetText(item);
            if(!r.IsEmpty && text.Length>0)
            {
                r.Offset(itemRect.Location);
                eTextFormat tf = eTextFormat.Default | eTextFormat.WordEllipsis;
                if(item.LabelPosition == eSliderLabelPosition.Left)
                    tf |= eTextFormat.Left | eTextFormat.VerticalCenter;
                else if(item.LabelPosition == eSliderLabelPosition.Right)
                    tf |= eTextFormat.Right | eTextFormat.VerticalCenter;
                else if(item.LabelPosition == eSliderLabelPosition.Top)
                    tf |= eTextFormat.HorizontalCenter | eTextFormat.Top | eTextFormat.WordBreak;
                else if(item.LabelPosition == eSliderLabelPosition.Bottom)
                    tf |= eTextFormat.HorizontalCenter | eTextFormat.Bottom | eTextFormat.WordBreak;

                Color cl = trackCt.LabelColor;
                if (!item.TextColor.IsEmpty)
                    cl = item.TextColor;
                if (item.TextMarkupBody == null)
                {
					
                    if (e.ItemPaintArgs != null && e.ItemPaintArgs.GlassEnabled && item.Parent is CaptionItemContainer)
                    {
                        if (!e.ItemPaintArgs.CachedPaint)
                            Office2007RibbonControlPainter.PaintTextOnGlass(g, GetText(item), e.ItemPaintArgs.Font, r, TextDrawing.GetTextFormat(tf));
                    }
                    else
					
                        TextDrawing.DrawString(g, GetText(item), e.ItemPaintArgs.Font, cl, r, tf);
                }
                else
                {
                    TextMarkup.MarkupDrawContext d = new TextMarkup.MarkupDrawContext(g, e.ItemPaintArgs.Font, cl, e.ItemPaintArgs.RightToLeft);
                    d.HotKeyPrefixVisible = !((tf & eTextFormat.HidePrefix) == eTextFormat.HidePrefix);
                    item.TextMarkupBody.Bounds = r;
                    item.TextMarkupBody.Render(d);
                }
            }

            r = item.SlideBounds;
            if (!r.IsEmpty)
            {
                SmoothingMode sm = g.SmoothingMode;
                g.SmoothingMode = SmoothingMode.None;
                r.Offset(itemRect.Location);
                // Draw the track line
                int ty = r.Y + r.Height / 2 - 1;
                int tmx = r.X + r.Width / 2;
                if (!trackCt.TrackLineColor.IsEmpty)
                {
                    using (Pen pen = new Pen(trackCt.TrackLineColor))
                    {
                        //g.DrawLine(pen, tmx, ty - 3, tmx, ty + 3);
                        g.DrawLine(pen, r.X - 1, ty, r.Right, ty);
                    }
                }

                if (!trackCt.TrackLineLightColor.IsEmpty)
                {
                    ty++;
                    tmx++;
                    using (Pen pen = new Pen(trackCt.TrackLineLightColor))
                    {
                        if(item.TrackMarker)
                            g.DrawLine(pen, tmx, ty - 3, tmx, ty + 3);
                        g.DrawLine(pen, r.X - 1, ty, r.Right, ty);
                    }
                }

                if (!trackCt.TrackLineColor.IsEmpty && item.TrackMarker)
                {
                    ty--;
                    tmx--;
                    using (Pen pen = new Pen(trackCt.TrackLineColor))
                    {
                        g.DrawLine(pen, tmx, ty - 3, tmx, ty + 3);
                    }
                }
                g.SmoothingMode = sm;

                int tx = 0;
                if(e.ItemPaintArgs.RightToLeft)
                    tx = (int)((r.Width - 11) * (1-((item.Maximum - item.Minimum == 0) ? 0 : (float)(item.Value - item.Minimum) / (item.Maximum - item.Minimum))));
                else
                    tx = (int)((r.Width - 11) * ((item.Maximum - item.Minimum == 0) ? 0 : (float)(item.Value - item.Minimum) / (item.Maximum - item.Minimum)));

                // Draw the tracker
                Rectangle trackRect = r;
                trackRect.X += tx;
                trackRect.Width = 11;
                trackRect.Height = 15;
                trackRect.Y += (r.Height - trackRect.Height) / 2;
                PaintSliderPart(trackCt, trackRect, g, eSliderPart.TrackArea);
                item.TrackBounds = trackRect;
            }

            r = item.DecreaseBounds;
            if(!r.IsEmpty)
            {
                r.Offset(itemRect.Location);
                r.Width--;
                r.Height--;
                PaintSliderPart(decreaseCt, r, g, eSliderPart.DecreaseButton);
            }

            r = item.IncreaseBounds;
            if(!r.IsEmpty)
            {
                r.Offset(itemRect.Location);
                r.Width--;
                r.Height--;
                PaintSliderPart(increaseCt, r, g, eSliderPart.IncreaseButton);
            }

            base.Paint(e);
        }

        private string GetText(SliderItem item)
        {
            return item.Text;
        }

        private void PaintSliderPart(Office2007SliderStateColorTable ct, Rectangle r, Graphics g, eSliderPart part)
        {
            if (r.Width <= 0 || r.Height <= 0) return;

            if (part == eSliderPart.DecreaseButton || part == eSliderPart.IncreaseButton)
            {
                r.Inflate(-1, -1);
                SmoothingMode sm = g.SmoothingMode;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Brush brush = DisplayHelp.CreateBrush(r, ct.PartBackground))
                {
                    g.FillEllipse(brush, r);
                }

                if (!ct.PartBorderColor.IsEmpty)
                {
                    using (Pen pen = new Pen(ct.PartBorderColor, 1))
                        g.DrawEllipse(pen, r);
                }
                
                r.Inflate(1, 1);
                if (!ct.PartBorderLightColor.IsEmpty)
                {
                    using (Pen pen = new Pen(ct.PartBorderLightColor, 1))
                        g.DrawEllipse(pen, r);
                }
                g.SmoothingMode = SmoothingMode.None;

                if (part == eSliderPart.DecreaseButton)
                {
                    Size ps = new Size(9, 3);
                    Rectangle rp = new Rectangle(r.X + (r.Width - ps.Width) / 2 , r.Y + (r.Height - ps.Height) / 2, ps.Width, ps.Height);
                    if (!ct.PartForeLightColor.IsEmpty)
                    {
                        using (Pen pen = new Pen(ct.PartForeLightColor, 1))
                            g.DrawRectangle(pen, rp);
                    }

                    if (!ct.PartForeColor.IsEmpty)
                    {
                        rp.Offset(1, 1);
                        rp.Width--;
                        rp.Height--;
                        using (SolidBrush brush = new SolidBrush(ct.PartForeColor))
                            g.FillRectangle(brush, rp);
                    }
                }
                else if (part == eSliderPart.IncreaseButton)
                {
                    Size ps = new Size(8, 8);
                    Rectangle rp = new Rectangle(r.X + (r.Width - ps.Width) / 2, r.Y + (r.Height - ps.Height) / 2, ps.Width, ps.Height);
                    if (!ct.TrackLineLightColor.IsEmpty)
                    {
                        using (SolidBrush brush = new SolidBrush(ct.PartForeLightColor))
                        {
                            g.FillRectangle(brush, new Rectangle(rp.X, rp.Y + 3, rp.Width + 2, 4));
                            g.FillRectangle(brush, new Rectangle(rp.X + 3, rp.Y, 4, 3));
                            g.FillRectangle(brush, new Rectangle(rp.X + 3, rp.Bottom - 1, 4, 3));
                        }
                    }

                    if (!ct.TrackLineColor.IsEmpty)
                    {
                        using (SolidBrush brush = new SolidBrush(ct.PartForeColor))
                        {
                            g.FillRectangle(brush, new Rectangle(rp.X + 1, rp.Y + 4, rp.Width, 2));
                            g.FillRectangle(brush, new Rectangle(rp.X + 4, rp.Y + 1, 2, 3));
                            g.FillRectangle(brush, new Rectangle(rp.X + 4, rp.Bottom - 2, 2, 3));
                        }
                    }
                }
                g.SmoothingMode = sm;
            }
            else if (part == eSliderPart.TrackArea)
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddLine(r.X, r.Y, r.X + 11, r.Y);
                    path.AddLine(r.X + 11, r.Y, r.X + 11, r.Y + 9);
                    path.AddLine(r.X + 11, r.Y + 9, r.X + 6, r.Y + 15);
                    path.AddLine(r.X + 5, r.Y + 15, r.X, r.Y + 10);
                    path.CloseAllFigures();
                    using (SolidBrush brush = new SolidBrush(ct.PartBorderLightColor))
                        g.FillPath(brush, path);
                }

                SmoothingMode sm = g.SmoothingMode;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                r.Offset(1, 1);
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddLine(r.X, r.Y, r.X + 8, r.Y);
                    path.AddLine(r.X + 8, r.Y + 8, r.X + 4, r.Y + 12);
                    path.AddLine(r.X, r.Y + 8, r.X, r.Y);
                    path.CloseAllFigures();
                    
                    using (Brush brush = DisplayHelp.CreateBrush(Rectangle.Ceiling(path.GetBounds()), ct.PartBackground))
                    {
                        g.FillPath(brush, path);
                    }

                    using (Pen pen = new Pen(ct.PartBorderColor, 1))
                        g.DrawPath(pen, path);
                }

                using (Pen pen = new Pen(Color.FromArgb(200,ct.PartForeColor), 1))
                    g.DrawLine(pen, r.X + 4, r.Y + 3, r.X + 4, r.Y + 8);

                using (Pen pen = new Pen(ct.PartForeLightColor, 1))
                    g.DrawLine(pen, r.X + 5, r.Y + 4, r.X + 5, r.Y + 7);

                g.SmoothingMode = sm;

                //using (Pen pen = new Pen(Color.FromArgb(128, ct.PartForeColor), 1))
                //{
                //    g.DrawLine(pen, r.X + 2, r.Y + 9, r.X + 4, r.Y + 11);
                //    g.DrawLine(pen, r.X + 6, r.Y + 9, r.X + 4, r.Y + 11);
                //}
            }

        }
        #endregion
    }
}
