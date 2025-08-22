using System;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.ComponentModel;

namespace HVTT.UI.Window.Forms.ColorPickerItem
{
    [ToolboxItem(false)]
    internal class CustomColorBlender : System.Windows.Forms.UserControl
    {
        #region Events
        /// <summary>
        /// Occurs after selected color has changed.
        /// </summary>
        public event EventHandler SelectedColorChanged;
        #endregion
    	
        #region Private Variables
        private Bitmap m_ColorBlendBitmap = null;
        private Point m_SelectedPoint = new Point(-1, -1);
        #endregion

        #region Constructor, Dispose
        public CustomColorBlender()
		{
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(DisplayHelp.DoubleBufferFlag, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
		}

        private void CreateBlendBitmap()
        {
            int stripeCount = 6;
            Rectangle clientRect = this.ClientRectangle;

            int stripeWidth = clientRect.Width / stripeCount;
            int ySteps=127;
            int xStart = clientRect.X;
            Bitmap bmp = new Bitmap(clientRect.Width, clientRect.Height, PixelFormat.Format24bppRgb);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                graph.FillRectangle(SystemBrushes.Control, clientRect);

                for (int stripe = 0; stripe < stripeCount; stripe++)
                {
                    // Calculate X steps and point Width
                    int pointWidth = 4;
                    int colorStepX = 255 / (stripeWidth / pointWidth);

                    if (colorStepX<1)
                    {
                        pointWidth = stripeWidth / 255;
                        colorStepX = 1;
                    }

                    int pointHeight = 4;
                    int colorStepY = ySteps / (clientRect.Height / pointHeight);
                    
                    if (colorStepY<1)
                    {
                        pointHeight = clientRect.Height / ySteps;
                        colorStepY = 1;
                    }

                    int x = xStart;
                    int y = clientRect.Y;
                    int r = 0, g = 0, b = 0;
                    int rXInc = 0, gXInc = 0, bXInc = 0;
                    int rYInc = 0, gYInc = 0, bYInc = 0;

                    if (stripe == 0)
                    {
                        r = 255;
                        g = 0;
                        b = 0;
                        gXInc = colorStepX;
                    }
                    else if (stripe == 1)
                    {
                        r = 255;
                        g = 255;
                        b = 0;
                        rXInc = - colorStepX;
                    }
                    else if (stripe == 2)
                    {
                        r = 0;
                        g = 255;
                        b = 0;
                        bXInc = colorStepX;
                    }
                    else if (stripe == 3)
                    {
                        r = 0;
                        g = 255;
                        b = 255;
                        gXInc = -colorStepX;
                    }
                    else if (stripe == 4)
                    {
                        r = 0;
                        g = 0;
                        b = 255;
                        rXInc = colorStepX;
                    }
                    else if (stripe == 5)
                    {
                        r = 255;
                        g = 0;
                        b = 255;
                        bXInc = -colorStepX;
                    }
                    
                    for (int i = 0; i < stripeWidth; i += pointWidth)
                    {
                        int ry = r, gy = g, by = b;
                        rYInc = 127-r;
                        gYInc = 127-g;
                        bYInc = 127-b;

                        for (int j = clientRect.Y; j < clientRect.Height; j += pointHeight)
                        {
                            using (SolidBrush brush = new SolidBrush(Color.FromArgb(ry, gy, by)))
                                graph.FillRectangle(brush, new Rectangle(x, y, pointWidth, pointHeight));
                            y += pointHeight;

                            ry = r + (int)(rYInc * ((float)j / (float)clientRect.Height));
                            gy = g + (int)(gYInc * ((float)j / (float)clientRect.Height));
                            by = b + (int)(bYInc * ((float)j / (float)clientRect.Height));
                        }

                        x += pointWidth;
                        y = clientRect.Y;
                        r += rXInc;
                        g += gXInc;
                        b += bXInc;

                    }
                    xStart = x;
                    if (stripe == 5)
                        break;
                }
            }
			
        	if(m_ColorBlendBitmap!=null)
        		m_ColorBlendBitmap.Dispose();
            m_ColorBlendBitmap = bmp;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(m_ColorBlendBitmap, 0, 0);

            if (m_SelectedPoint.X >= 0 && m_SelectedPoint.Y >= 0)
            {
                Color clr = Color.White;
                using (SolidBrush brush = new SolidBrush(clr))
                {
                    Rectangle r = new Rectangle(m_SelectedPoint.X - 2, m_SelectedPoint.Y - 9, 3, 5);
                    g.FillRectangle(brush, r);
                    r.Offset(0, 10);
                    g.FillRectangle(brush, r);
                    r = new Rectangle(m_SelectedPoint.X - 8, m_SelectedPoint.Y - 3, 5, 3);
                    g.FillRectangle(brush, r);
                    r.Offset(10, 0);
                    g.FillRectangle(brush, r);
                }

            }

            base.OnPaint(e);
        }

        private void SetSelectedPoint(Point p)
        {
            Rectangle r = this.ClientRectangle;

            if (m_ColorBlendBitmap != null)
            {
                r.Width = m_ColorBlendBitmap.Width;
                r.Height = m_ColorBlendBitmap.Height;
            }

            if (p.X < 0)
                p.X = 0;
            if (p.Y < 0)
                p.Y = 0;
            if (p.X > r.Right)
                p.X = r.Right - 1;
            if (p.Y > r.Bottom)
                p.Y = r.Bottom - 1;

            if (p != m_SelectedPoint)
            {
                if (m_SelectedPoint.X >= 0 && m_SelectedPoint.Y >= 0)
                {
                    Rectangle inv = new Rectangle(m_SelectedPoint, Size.Empty);
                    inv.Inflate(10, 10);
                    this.Invalidate(inv);
                }
                m_SelectedPoint = p;
                if (m_SelectedPoint.X >= 0 && m_SelectedPoint.Y >= 0)
                {
                    Rectangle inv = new Rectangle(m_SelectedPoint, Size.Empty);
                    inv.Inflate(10, 10);
                    this.Invalidate(inv);
                }
                if (SelectedColorChanged != null)
                    SelectedColorChanged(this, new EventArgs());
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            SetSelectedPoint(new Point(e.X, e.Y));
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
            	int x = e.X;
            	int y = e.Y;
            	if(x<0)
            		x = 0;
            	if(x>=this.ClientRectangle.Width)
            		x = this.ClientRectangle.Width - 1;
				if(y<0)
					y = 0;
				if(y>=this.ClientRectangle.Height)
					y = this.ClientRectangle.Height - 1;
            	SetSelectedPoint(new Point(x, y));
            }
        }

        protected override void OnResize(EventArgs e)
        {
            CreateBlendBitmap();
            base.OnResize(e);
        }

        public Color SelectedColor
        {
            get
            {
                if (m_SelectedPoint.X < 0 || m_SelectedPoint.Y < 0 || m_ColorBlendBitmap==null)
                    return Color.Empty;
                return m_ColorBlendBitmap.GetPixel(m_SelectedPoint.X, m_SelectedPoint.Y);
            }
        }
        #endregion
    }
}
