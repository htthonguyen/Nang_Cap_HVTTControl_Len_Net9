using System;
using System.Drawing;

namespace HVTT.UI.Window.Forms
{
	/// <summary>
	/// Summary description for ButtonItemPainter.
	/// </summary>
	internal abstract class ButtonItemPainter
	{
		public abstract void PaintButton(ButtonItem button, ItemPaintArgs pa);
        public abstract void PaintButtonBackground(ButtonItem button, ItemPaintArgs pa, CompositeImage image);
		public abstract void PaintButtonCheck(ButtonItem button, ItemPaintArgs pa, CompositeImage image, Rectangle r);
		public abstract void PaintButtonImage(ButtonItem button, ItemPaintArgs pa, CompositeImage image, Rectangle imagebounds);
		public abstract void PaintButtonMouseOver(ButtonItem button, ItemPaintArgs pa, CompositeImage image, Rectangle r);
		public abstract void PaintButtonText(ButtonItem button, ItemPaintArgs pa, Color textColor, CompositeImage image);
		public abstract void PaintCustomizeCheck(ButtonItem button, ItemPaintArgs pa, Rectangle r);
		public abstract void PaintExpandButton(ButtonItem button, ItemPaintArgs pa);

		public abstract Rectangle GetCheckRectangle(ButtonItem button, ItemPaintArgs pa, CompositeImage image);
		public abstract Rectangle GetCustomizeMenuCheckRectangle(ButtonItem button, ItemPaintArgs pa);
		public abstract Rectangle GetImageRectangle(ButtonItem button, ItemPaintArgs pa, CompositeImage image);
		public abstract Rectangle GetMouseOverRectangle(ButtonItem button, ItemPaintArgs pa, CompositeImage image);

		public abstract eTextFormat GetStringFormat(ButtonItem button, ItemPaintArgs pa, CompositeImage image);

		public static string GetDrawText(string text)
		{
			return text; //.Replace(@"\n",Environment.NewLine);
		}

		public static bool IsItemEnabled(BaseItem item, ItemPaintArgs pa)
		{
			return item.Enabled && pa.ContainerControl.Enabled;
		}

        public static void PaintButtonExpandIndicator(ButtonItem button, ItemPaintArgs pa)
        {
            Graphics g = pa.Graphics;
            Rectangle itemRect = button.DisplayRectangle;
            Point[] p = new Point[3];
            Rectangle r = button.SubItemsRect;

            if (button.PopupSide == PopupSide.Default)
            {
                if (button.Orientation == HVTTOrientation.Horizontal)
                {
                    p[0].X = itemRect.Left + r.Left + (r.Width - 5) / 2;
                    p[0].Y = itemRect.Top + r.Top + (r.Height - 3) / 2 + 1;
                    p[1].X = p[0].X + 5;
                    p[1].Y = p[0].Y;
                    p[2].X = p[0].X + 2;
                    p[2].Y = p[0].Y + 3;
                }
                else
                {
                    p[0].X = itemRect.Left + r.Left + r.Width / 2;
                    p[0].Y = itemRect.Top + r.Top + r.Height / 2 - 3;
                    p[1].X = p[0].X;
                    p[1].Y = p[0].Y + 6;
                    p[2].X = p[0].X + 3;
                    p[2].Y = p[0].Y + 3;
                }
            }
            else
            {
                switch (button.PopupSide)
                {
                    case PopupSide.Right:
                        {
                            p[0].X = itemRect.Left + r.Left + r.Width / 2;
                            p[0].Y = itemRect.Top + r.Top + r.Height / 2 - 3;
                            p[1].X = p[0].X;
                            p[1].Y = p[0].Y + 6;
                            p[2].X = p[0].X + 3;
                            p[2].Y = p[0].Y + 3;
                            break;
                        }
                    case PopupSide.Left:
                        {
                            p[0].X = itemRect.Left + r.Left + r.Width / 2 + 3;
                            p[0].Y = itemRect.Top + r.Top + r.Height / 2 - 3;
                            p[1].X = p[0].X;
                            p[1].Y = p[0].Y + 6;
                            p[2].X = p[0].X - 3;
                            p[2].Y = p[0].Y + 3;
                            break;
                        }
                    case PopupSide.Top:
                        {
                            p[0].X = itemRect.Left + r.Left + (r.Width - 5) / 2;
                            p[0].Y = itemRect.Top + r.Top + (r.Height - 3) / 2 + 4;
                            p[1].X = p[0].X + 6;
                            p[1].Y = p[0].Y;
                            p[2].X = p[0].X + 3;
                            p[2].Y = p[0].Y - 4;
                            break;
                        }
                    case PopupSide.Bottom:
                        {
                            p[0].X = itemRect.Left + r.Left + (r.Width - 5) / 2 + 1;
                            p[0].Y = itemRect.Top + r.Top + (r.Height - 3) / 2 + 1;
                            p[1].X = p[0].X + 5;
                            p[1].Y = p[0].Y;
                            p[2].X = p[0].X + 2;
                            p[2].Y = p[0].Y + 3;
                            break;
                        }
                }
            }
            if (IsItemEnabled(button, pa))
            {
                using (SolidBrush mybrush = new SolidBrush(pa.Colors.ItemText))
                    g.FillPolygon(mybrush, p);
            }
            else
            {
                using (SolidBrush mybrush = new SolidBrush(pa.Colors.ItemDisabledText))
                    g.FillPolygon(mybrush, p);
            }
        }

	}
}
