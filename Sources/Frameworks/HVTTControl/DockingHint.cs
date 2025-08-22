using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms
{
	#region Enums
	[System.Flags()]
	internal enum eDockingHintSide
	{
		Left=1,
		Right=2,
		Top=4,
        Bottom=8,
		DockTab=16,
		All=(Left | Right | Top | Bottom | DockTab),
		Sides=(Left | Right | Top | Bottom)
	}

	internal enum eMouseOverHintSide
	{
		None,
		Left,
		Right,
		Top,
		Bottom,
		DockTab,
	}
	#endregion

	/// <summary>
	/// Summary description for DockingHint.
	/// </summary>
	[ToolboxItem(false)]
	internal class DockingHint : System.Windows.Forms.Form
	{
		#region Private Variables
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private eDockingHintSide m_DockingHintSide=eDockingHintSide.All;

		private eMouseOverHintSide m_MouseOverHintSide=eMouseOverHintSide.None;
		private bool m_PendingRefresh=false;

		private GraphicsPath m_LeftHint=null;
		private GraphicsPath m_RightHint=null;
		private GraphicsPath m_BottomHint=null;
		private GraphicsPath m_TopHint=null;
		private GraphicsPath m_DockTabHint=null;
		private bool m_MiddleDockHint=false;
		#endregion
		
		#region Static Members
		// Static Images
		private static Bitmap s_ImageGuideTop=null;
		private static Bitmap s_ImageGuideBottom=null;
		private static Bitmap s_ImageGuideLeft=null;
		private static Bitmap s_ImageGuideRight=null;
		private static Bitmap s_ImageGuideTab=null;
		private static Bitmap s_ImageGuideAllSides=null;
		public static Bitmap ImageGuideTop
		{
			get
			{
				if(s_ImageGuideTop==null)
					s_ImageGuideTop=BarFunctions.LoadBitmap("SystemImages.DockHintTop.png");
				return s_ImageGuideTop;
			}
		}
		public static Bitmap ImageGuideBottom
		{
			get
			{
				if(s_ImageGuideBottom==null)
					s_ImageGuideBottom=BarFunctions.LoadBitmap("SystemImages.DockHintBottom.png");
				return s_ImageGuideBottom;
			}
		}
		public static Bitmap ImageGuideLeft
		{
			get
			{
				if(s_ImageGuideLeft==null)
					s_ImageGuideLeft=BarFunctions.LoadBitmap("SystemImages.DockHintLeft.png");// new Bitmap(typeof(HVTT.UI.Window.Forms.HVTTManager),"SystemImages.DockHintLeft.png");
				return s_ImageGuideLeft;
			}
		}
		public static Bitmap ImageGuideRight
		{
			get
			{
				if(s_ImageGuideRight==null)
					s_ImageGuideRight=BarFunctions.LoadBitmap("SystemImages.DockHintRight.png");
				return s_ImageGuideRight;
			}
		}
		public static Bitmap ImageGuideTab
		{
			get
			{
				if(s_ImageGuideTab==null)
					s_ImageGuideTab=BarFunctions.LoadBitmap("SystemImages.DockHintTab.png");
				return s_ImageGuideTab;
			}
		}
		public static Bitmap ImageGuideAllSides
		{
			get
			{
				if(s_ImageGuideAllSides==null)
					s_ImageGuideAllSides=BarFunctions.LoadBitmap("SystemImages.DockHintAllSides.png");
				return s_ImageGuideAllSides;
			}
		}
		#endregion

		#region Constructor
		public DockingHint(eDockingHintSide hintSide):this(hintSide,false){}
		public DockingHint(eDockingHintSide hintSide, bool middleDockingHint)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			m_MiddleDockHint=middleDockingHint;

			this.SetStyle(ControlStyles.Selectable,false);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint,true);
			this.SetStyle(DisplayHelp.DoubleBufferFlag,true);
			this.SetStyle(ControlStyles.Opaque,true);

			m_DockingHintSide=hintSide;
			UpdateControlRegion();
		}
		#endregion

		#region Internal Implemementation
		public void ShowFocusless()
		{
			Size size=this.Size;
			NativeFunctions.SetWindowPos(this.Handle,NativeFunctions.HWND_TOP,0,0,size.Width,size.Height,NativeFunctions.SWP_SHOWWINDOW | NativeFunctions.SWP_NOACTIVATE | NativeFunctions.SWP_NOMOVE);
			this.TopMost=true;
			if(!BarFunctions.ThemedOS)
				UpdateControlRegion();
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

		/// <summary>
		/// Update control region based on hint side
		/// </summary>
		private void UpdateControlRegion()
		{
			System.Drawing.Region region=null;
			System.Drawing.Size size=Size.Empty;
			if(m_MiddleDockHint)
			{
				GraphicsPath path=new GraphicsPath();

				m_DockTabHint=this.GetHintPath(eDockingHintSide.DockTab);

				// Assign paths
				if((m_DockingHintSide & eDockingHintSide.Left)!=0)
				{
					m_LeftHint=this.GetHintPath(eDockingHintSide.Left);
					path.AddPath(m_LeftHint,true);
				}
				else
                    path.AddLine(23,57,23,29);

				if((m_DockingHintSide & eDockingHintSide.Top)!=0)
				{
					m_TopHint=this.GetHintPath(eDockingHintSide.Top);
					path.AddPath(m_TopHint,true);
				}
				else
					path.AddLine(29,23,57,23);

				if((m_DockingHintSide & eDockingHintSide.Right)!=0)
				{
					m_RightHint=this.GetHintPath(eDockingHintSide.Right);
					path.AddPath(m_RightHint,true);
				}
				else
					path.AddLine(64,29,64,57);

				if((m_DockingHintSide & eDockingHintSide.Bottom)!=0)
				{
					m_BottomHint=this.GetHintPath(eDockingHintSide.Bottom);
					path.AddPath(m_BottomHint,true);
				}
				else
					path.AddLine(57,64,29,64);

				path.CloseAllFigures();
				size=new Size(88,88);
				region=new Region(path);
			}
			else
			{
				if((m_DockingHintSide & eDockingHintSide.Left)!=0 || (m_DockingHintSide & eDockingHintSide.Right)!=0)
					size=new Size(31,29);
				else
					size=new Size(29,31);
				if((m_DockingHintSide & eDockingHintSide.Left)!=0)
				{
					m_LeftHint=new GraphicsPath();
					m_LeftHint.AddRectangle(new Rectangle(Point.Empty,size));
				}
				if((m_DockingHintSide & eDockingHintSide.Right)!=0)
				{
					m_RightHint=new GraphicsPath();
					m_RightHint.AddRectangle(new Rectangle(Point.Empty,size));
				}
				if((m_DockingHintSide & eDockingHintSide.Top)!=0)
				{
					m_TopHint=new GraphicsPath();
					m_TopHint.AddRectangle(new Rectangle(Point.Empty,size));
				}
				if((m_DockingHintSide & eDockingHintSide.Bottom)!=0)
				{
					m_BottomHint=new GraphicsPath();
					m_BottomHint.AddRectangle(new Rectangle(Point.Empty,size));
				}
				region=new Region(new Rectangle(Point.Empty,size));
			}

			this.Size=size;
			if(region!=null)
				this.Region=region;
		}

		private Rectangle GetHintRect()
		{
			System.Drawing.Size size=Size.Empty;

			if((m_DockingHintSide & eDockingHintSide.Bottom)==eDockingHintSide.Bottom)
			{
				SizeF sf=m_BottomHint.GetBounds().Size;
				size=new Size((int)sf.Width,(int)sf.Height);
			}
			if((m_DockingHintSide & eDockingHintSide.Top)==eDockingHintSide.Top)
			{
				SizeF sf=m_TopHint.GetBounds().Size;
				size=new Size((int)sf.Width,(int)sf.Height);
			}
			if((m_DockingHintSide & eDockingHintSide.Right)==eDockingHintSide.Right)
			{
				SizeF sf=m_RightHint.GetBounds().Size;
				size=new Size((int)sf.Width,(int)sf.Height);
			}
			if((m_DockingHintSide & eDockingHintSide.DockTab)==eDockingHintSide.DockTab)
			{
				SizeF sf=m_DockTabHint.GetBounds().Size;
				size=new Size((int)sf.Width,(int)sf.Height);
			}
			if((m_DockingHintSide & eDockingHintSide.Left)==eDockingHintSide.Left)
			{
				SizeF sf=m_LeftHint.GetBounds().Size;
				size=new Size((int)sf.Width,(int)sf.Height);
			}
			if(m_DockingHintSide==eDockingHintSide.Sides)
				size=new Size(88,88);

			return new Rectangle(Point.Empty,size);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g=e.Graphics;
			Color colorHot=Color.FromArgb(65,112,202);
			Color color=Color.FromArgb(228,228,228);

			SolidBrush brush=new SolidBrush(color);
			Pen pen=new Pen(colorHot,1);

			try
			{
				if(m_MiddleDockHint)
				{
					g.DrawImageUnscaled(DockingHint.ImageGuideAllSides,0,0);
					//if(m_DockingHintSide==eDockingHintSide.DockTab || m_DockingHintSide==eDockingHintSide.All)
					if((m_DockingHintSide & eDockingHintSide.DockTab)==eDockingHintSide.DockTab)
					{
						g.DrawImageUnscaled(DockingHint.ImageGuideTab,(this.Width-DockingHint.ImageGuideTab.Width)/2+2,(this.Height-DockingHint.ImageGuideTab.Height)/2+2);
					}

					if((m_DockingHintSide & eDockingHintSide.Bottom)!=eDockingHintSide.Bottom)
						g.FillRectangle(brush,33,60,23,26);
					if((m_DockingHintSide & eDockingHintSide.Top)!=eDockingHintSide.Top)
						g.FillRectangle(brush,33,4,23,26);
					if((m_DockingHintSide & eDockingHintSide.Left)!=eDockingHintSide.Left)
						g.FillRectangle(brush,4,33,26,23);
					if((m_DockingHintSide & eDockingHintSide.Right)!=eDockingHintSide.Right)
						g.FillRectangle(brush,60,33,26,23);
				}
				else
				{

					if((m_DockingHintSide & eDockingHintSide.Left)==eDockingHintSide.Left)
					{
						g.DrawImage(DockingHint.ImageGuideLeft,m_LeftHint.GetBounds());
					}

					if((m_DockingHintSide & eDockingHintSide.Right)==eDockingHintSide.Right)
					{
						g.DrawImage(DockingHint.ImageGuideRight,m_RightHint.GetBounds());
					}

					if((m_DockingHintSide & eDockingHintSide.Top)==eDockingHintSide.Top)
					{
						g.DrawImage(DockingHint.ImageGuideTop,m_TopHint.GetBounds());
					}

					if((m_DockingHintSide & eDockingHintSide.Bottom)==eDockingHintSide.Bottom)
					{
						g.DrawImage(DockingHint.ImageGuideBottom,m_BottomHint.GetBounds());
					}
					else
						g.FillRectangle(brush,33,84,23,26);
				}

				if(m_MouseOverHintSide==eMouseOverHintSide.Left)
				{
					RectangleF r=m_LeftHint.GetBounds();
					if(m_MiddleDockHint)
					{
						r.Inflate(0,-6);
						r.Width-=6;
					}
					g.DrawLine(pen,r.X,r.Y,r.Right,r.Y);
					g.DrawLine(pen,r.X,r.Y,r.X,r.Bottom);
					g.DrawLine(pen,r.X,r.Bottom-1,r.Right,r.Bottom-1);
				}
				if(m_MouseOverHintSide==eMouseOverHintSide.Right)
				{
					RectangleF r=m_RightHint.GetBounds();
					if(m_MiddleDockHint)
					{
						r.Inflate(0,-6);
						r.Width-=6;
						r.X+=6;
					}
					g.DrawLine(pen,r.X,r.Y,r.Right,r.Y);
					g.DrawLine(pen,r.Right-1,r.Y,r.Right-1,r.Bottom);
					g.DrawLine(pen,r.X,r.Bottom-1,r.Right,r.Bottom-1);
				}
				if(m_MouseOverHintSide==eMouseOverHintSide.Top)
				{
					RectangleF r=m_TopHint.GetBounds();
					if(m_MiddleDockHint)
					{
						r.Inflate(-6,0);
						r.Height-=6;
					}
					g.DrawLine(pen,r.X,r.Y,r.Right,r.Y);
					g.DrawLine(pen,r.Right-1,r.Y,r.Right-1,r.Bottom);
					g.DrawLine(pen,r.X,r.Y,r.X,r.Bottom);
				}
				if(m_MouseOverHintSide==eMouseOverHintSide.Bottom)
				{
					RectangleF r=m_BottomHint.GetBounds();
					if(m_MiddleDockHint)
					{
						r.Inflate(-6,0);
						r.Height-=6;
						r.Y+=6;
					}
					g.DrawLine(pen,r.X,r.Bottom-1,r.Right,r.Bottom-1);
					g.DrawLine(pen,r.Right-1,r.Y,r.Right-1,r.Bottom);
					g.DrawLine(pen,r.X,r.Y,r.X,r.Bottom);
				}
			}
			finally
			{
				brush.Dispose();
				pen.Dispose();
			}
		}

		private GraphicsPath GetHintPath(eDockingHintSide hintSide)
		{
			// Create top hint path then rotate depending on desired side
			GraphicsPath path=new GraphicsPath();
			if(hintSide==eDockingHintSide.DockTab)
			{
				path.AddRectangle(new Rectangle(29,29,29,29));
			}
			else
			{
				path.StartFigure();
				path.AddLine(23,28,28,23);
				path.AddLine(29,23,29,0);
				path.AddLine(57,0,57,23);
				path.AddLine(58,23,63,28);
			}

			switch(hintSide)
			{
				case eDockingHintSide.Bottom:
				{
					using(Matrix matrix=new Matrix())
					{
						matrix.Rotate(180);
						matrix.Translate(-path.GetBounds().Width*2-6,-path.GetBounds().Height*2-30);
						path.Transform(matrix);
					}
					break;
				}
				case eDockingHintSide.Left:
				{
					using(Matrix matrix=new Matrix())
					{
						matrix.Rotate(-90);
						matrix.Translate(-46,0);
						path.Transform(matrix);
						matrix.Reset();
						matrix.Translate(0,path.GetBounds().Height);
						path.Transform(matrix);
					}
					break;
				}
				case eDockingHintSide.Right:
				{
					using(Matrix matrix=new Matrix())
					{
						matrix.Rotate(90);
						path.Transform(matrix);
						matrix.Reset();
						matrix.Translate(path.GetBounds().Width*2+30,0);
						path.Transform(matrix);
					}
					break;
				}
			}

			return path;
		}

		public eMouseOverHintSide ExMouseMove(int x, int y)
		{
			if(this.Bounds.Contains(x,y))
			{
				Point p=this.PointToClient(new Point(x,y));
				if(m_LeftHint!=null && m_LeftHint.IsVisible(p))
				{
					this.MouseOverHintSide=eMouseOverHintSide.Left;
				}
				else if(m_RightHint!=null && m_RightHint.IsVisible(p))
				{
					this.MouseOverHintSide=eMouseOverHintSide.Right;
				}
				else if(m_TopHint!=null && m_TopHint.IsVisible(p))
				{
					this.MouseOverHintSide=eMouseOverHintSide.Top;
				}
				else if(m_BottomHint!=null && m_BottomHint.IsVisible(p))
				{
					this.MouseOverHintSide=eMouseOverHintSide.Bottom;
				}
				else if(m_DockTabHint!=null && m_DockTabHint.IsVisible(p) && ((m_DockingHintSide & eDockingHintSide.DockTab)==eDockingHintSide.DockTab))
				{
					this.MouseOverHintSide=eMouseOverHintSide.DockTab;
				}
				else
					this.MouseOverHintSide=eMouseOverHintSide.None;
			}
			else
				this.MouseOverHintSide=eMouseOverHintSide.None;
			this.ProcessPendingRefresh();

			return this.MouseOverHintSide;
		}

		private eMouseOverHintSide MouseOverHintSide
		{
			get {return m_MouseOverHintSide;}
			set
			{
				if(m_MouseOverHintSide!=value)
				{
					m_MouseOverHintSide=value;
					m_PendingRefresh=true;
				}
			}
		}

		private void ProcessPendingRefresh()
		{
			if(m_PendingRefresh)
			{
				m_PendingRefresh=false;
				this.Refresh();
			}
		}

		public eDockingHintSide DockingHintSides
		{
			get {return m_DockingHintSide;}
			set
			{
				if(m_DockingHintSide!=value)
				{
					m_DockingHintSide=value;
					UpdateControlRegion();
					if(this.IsHandleCreated)
						this.Refresh();
				}
			}
		}

		public bool MiddleDockHint
		{
			get {return m_MiddleDockHint;}
			set {m_MiddleDockHint=value;}
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// DockingHint
			// 
//			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
//			this.ClientSize = new System.Drawing.Size(24, 24);
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MinimizeBox = false;
			this.MaximizeBox = false;
			this.ControlBox = false;
			this.Name = "DockingHint";
			this.Text="";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition=FormStartPosition.Manual;
		}
		#endregion
	}
}
