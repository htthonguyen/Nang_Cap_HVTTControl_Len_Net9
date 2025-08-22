using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms.ColorPickerItem
{
	[ToolboxItem(false)]
	internal class ColorCombControl : System.Windows.Forms.UserControl
    {
		#region Events
		public event EventHandler SelectedColorChanged;
		#endregion
		
        #region Private Variables
        private CombCell[] m_ColorCombs = new CombCell[144];
        private const float YOffset = .824f;
        private float[] arrXOffset = new float[] { -0.5f, -1.0f, -0.5f, 0.5f, 1.0f, 0.5f };
        private float[] arrYOffset = new float[] { YOffset, 0.0f, -YOffset, -YOffset, 0.0f, YOffset };
        private int CombDepth = 7;
        private int m_MouseOverIndex = -1;
        private int m_SelectedIndex = -1;

        /// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        #endregion

        #region Constructor, Dispose
        public ColorCombControl()
		{
            for (int i = 0; i < m_ColorCombs.Length; i++)
                m_ColorCombs[i] = new CombCell();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(DisplayHelp.DoubleBufferFlag, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
        }
        #endregion

        #region Component Designer generated code
        /// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

        #region Internal Implementation
        private int GetCellSize(int height)
        {
            int cellSize = height / (2 * CombDepth - 1) + 1;
            if ((int)(Math.Floor((double)cellSize / 2)) * 2 < cellSize)
                cellSize--;
            return cellSize;
        }

        private void InitializeColorComb()
        {
            Rectangle clientRect = this.ClientRectangle;
            clientRect.Inflate(-8, -8);
            clientRect.Height -= GetCellSize(Math.Min(clientRect.Height, clientRect.Width))*3;

            // Normalize...
            if (clientRect.Height < clientRect.Width)
                clientRect.Inflate(-(clientRect.Width - clientRect.Height) / 2, 0);
            else
                clientRect.Inflate(0, -(clientRect.Height - clientRect.Width) / 2);

            int cellSize = GetCellSize(clientRect.Height);

            int x = (clientRect.Left + clientRect.Right) / 2;
            int y = (clientRect.Top + clientRect.Bottom) / 2;

            // Center White Comb
            m_ColorCombs[0].Color = Color.White;
            m_ColorCombs[0].SetPosition(x, y, cellSize);

            int index = 1;
            for (int nLevel = 1; nLevel < CombDepth; nLevel++)
            {
                float posX = x + (cellSize * nLevel);
                float posY = y;

                for (int nSide = 0; nSide < CombDepth - 1; nSide++)
                {
                    int xIncrease = (int)((cellSize) * arrXOffset[nSide]);
                    int yIncrease = (int)((cellSize) * arrYOffset[nSide]);

                    for (int nCell = 0; nCell < nLevel; nCell++)
                    {
                        float nAngle = GetAngleFromPoint(posX - x, posY - y);
                        double L = .936 * (CombDepth - nLevel) / CombDepth + .12;

                        m_ColorCombs[index].Color = GetRGBFromHLSExtend((float)nAngle, L, 1.0F);
                        m_ColorCombs[index].SetPosition(posX, posY, cellSize);
                        index++;

                        posX += xIncrease;
                        posY += yIncrease;
                    }
                }
            }

            m_ColorCombs[index].Color = Color.Black;
            index++;
            m_ColorCombs[index].Color = Color.White;

            int RGBOffset = 255 / (15 + 2);

            int rgb = 255 - RGBOffset;

            x = clientRect.X + cellSize * 3;
            y = clientRect.Bottom;
            
            for (int i = 0; i < 15; i++)
            {
                Color color = Color.FromArgb(rgb, rgb, rgb);
                m_ColorCombs[index].Color = color;
                m_ColorCombs[index].SetPosition(x, y, cellSize);
                x += cellSize;
                index++;
                if (i == 7)
                {
                    x = clientRect.X + (int)(cellSize * 3.5);
                    y += (int)(cellSize * YOffset);
                }
                rgb -= RGBOffset;
            }
            m_ColorCombs[index].Color = Color.Black;
        }


        private Color GetRGBFromHLSExtend(double H, double L, double S)
        {
            int R, G, B;

            if (S == 0.0)
            {
                R = G = B = (int)(L * 255.0);
            }
            else
            {
                float rm1, rm2;

                if (L <= 0.5f)
                    rm2 = (float)(L + L * S);
                else
                    rm2 = (float)(L + S - L * S);

                rm1 = (float)(2.0f * L - rm2);

                R = GetRGBFromHue(rm1, rm2, (float)(H + 120.0f));
                G = GetRGBFromHue(rm1, rm2, (float)(H));
                B = GetRGBFromHue(rm1, rm2, (float)(H - 120.0f));
            }

            return Color.FromArgb(R, G, B);
        }

        private float GetAngleFromPoint(float nX, float nY)
        {
            double dAngle = Math.Atan2(nY, nX);
            return (float)(dAngle * 180.0 / Math.PI);
        }

        private int GetRGBFromHue(float rm1, float rm2, float rh)
        {
            if (rh > 360.0f)
                rh -= 360.0f;
            else if (rh < 0.0f)
                rh += 360.0f;

            if (rh < 60.0f)
                rm1 = rm1 + (rm2 - rm1) * rh / 60.0f;
            else if (rh < 180.0f)
                rm1 = rm2;
            else if (rh < 240.0f)
                rm1 = rm1 + (rm2 - rm1) * (240.0f - rh) / 60.0f;

            return (int)(rm1 * 255);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
			if(this.BackColor == Color.Transparent)
			{
				base.OnPaintBackground(e);
			}

            Graphics g = e.Graphics;
            using (SolidBrush brush = new SolidBrush(this.BackColor))
                g.FillRectangle(brush, this.ClientRectangle);

            foreach (CombCell c in m_ColorCombs)
                c.Draw(g);

            if (m_MouseOverIndex >= 0)
                m_ColorCombs[m_MouseOverIndex].Draw(g);
			if (m_SelectedIndex >= 0)
				m_ColorCombs[m_SelectedIndex].Draw(g);

            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            InitializeColorComb();
            base.OnResize(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            int newMouseOver = GetCellAt(e.X, e.Y);
            SetMouseOver(newMouseOver);
        }
		
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if(e.Button==MouseButtons.Left)
			{
				if(m_SelectedIndex>=0)
				{
					m_ColorCombs[m_SelectedIndex].Selected = false;
					this.Invalidate(m_ColorCombs[m_SelectedIndex].Bounds);
				}
				m_SelectedIndex = -1;

				if(m_MouseOverIndex>=0)
				{
					m_SelectedIndex = m_MouseOverIndex;
					m_ColorCombs[m_SelectedIndex].Selected = true;
					if(this.SelectedColorChanged!=null)
					{
						this.SelectedColorChanged(this, new EventArgs());
					}
					this.Invalidate(m_ColorCombs[m_SelectedIndex].Bounds);
				}
			}
			base.OnMouseDown (e);
		}


		public Color SelectedColor
		{
			get
			{
				if(m_SelectedIndex<0)
					return Color.Empty;
				return m_ColorCombs[m_SelectedIndex].Color;
			}
		}
		
        private void SetMouseOver(int newMouseOver)
        {
            if (newMouseOver != m_MouseOverIndex)
            {
                if (m_MouseOverIndex >= 0)
                {
                    m_ColorCombs[m_MouseOverIndex].MouseOver = false;
                    this.Invalidate(m_ColorCombs[m_MouseOverIndex].Bounds);
                }
                m_MouseOverIndex = newMouseOver;
                if (m_MouseOverIndex >= 0)
                {
                    m_ColorCombs[m_MouseOverIndex].MouseOver = true;
                    this.Invalidate(m_ColorCombs[m_MouseOverIndex].Bounds);
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            SetMouseOver(-1);
        }

        private int GetCellAt(int x, int y)
        {
            for (int i = 0; i < m_ColorCombs.Length; i++)
            {
                if (m_ColorCombs[i].Bounds.Contains(x, y))
                {
                    return i;
                }
            }

            return -1;
        }
        #endregion
    }
}
