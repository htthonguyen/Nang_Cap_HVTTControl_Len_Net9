using System;
using System.Drawing;
namespace HVTT.UI.Window.Forms
{
	/// <summary>
	/// Summary description for ItemPaintArgs.
	/// </summary>
	public class ItemPaintArgs
	{
		public System.Drawing.Graphics Graphics;
		public ColorScheme Colors;
		public System.Windows.Forms.Control ContainerControl;
		public eTextFormat ButtonStringFormat;
		public bool IsOnMenu=false;
        public bool IsOnPopupBar = false;
		public bool IsOnMenuBar=false;
        public bool IsOnRibbonBar = false;
        public bool IsOnNavigationBar = false;
		public System.Drawing.Font Font;
		public IOwner Owner;
        public bool RightToLeft = false;
		private HVTT.UI.Window.Forms.ThemeWindow m_ThemeWindow=null;
		private HVTT.UI.Window.Forms.ThemeRebar m_ThemeRebar=null;
		private HVTT.UI.Window.Forms.ThemeToolbar m_ThemeToolbar=null;
		private HVTT.UI.Window.Forms.ThemeHeader m_ThemeHeader=null;
		private HVTT.UI.Window.Forms.ThemeScrollBar m_ThemeScrollBar=null;
		private HVTT.UI.Window.Forms.ThemeExplorerBar m_ThemeExplorerBar=null;
		private HVTT.UI.Window.Forms.ThemeProgress m_ThemeProgress=null;
        private HVTT.UI.Window.Forms.ThemeButton m_ThemeButton = null;
        public bool DesignerSelection = false;
        public bool GlassEnabled = false;
        private Rendering.BaseRenderer m_Renderer = null;
        public ButtonItemRendererEventArgs ButtonItemRendererEventArgs = new ButtonItemRendererEventArgs();
        public Rectangle ClipRectangle = Rectangle.Empty;
        public bool ControlExpanded = true;
        internal bool CachedPaint = false;
        internal bool IsDefaultButton = false;

		public ItemPaintArgs(IOwner owner, System.Windows.Forms.Control control, System.Drawing.Graphics g, ColorScheme scheme)
		{
			this.Graphics=g;
			this.Colors=scheme;
			this.ContainerControl=control;
			this.Owner=owner;
            if(control!=null)
                this.RightToLeft = (control.RightToLeft == System.Windows.Forms.RightToLeft.Yes);
            if (control is MenuPanel || this.ContainerControl is ItemsListBox)
                this.IsOnMenu = true;
            else if (control is HVTTMarkStatus && ((HVTTMarkStatus)control).MenuBar)
                this.IsOnMenuBar = true;
            else if (control is HVTTMarkStatus && ((HVTTMarkStatus)control).BarState == HVTTBarState.Popup)
                this.IsOnPopupBar = true;
            else if (control is RibbonBar)
                this.IsOnRibbonBar = true;
            else if (control is NavigationBar)
                this.IsOnNavigationBar = true;
            if(control!=null)
			    this.Font=control.Font;
			CreateStringFormat();
		}

        internal Rendering.BaseRenderer Renderer
        {
            get { return m_Renderer; }
            set { m_Renderer = value; }
        }

		internal HVTT.UI.Window.Forms.ThemeWindow ThemeWindow
		{
			get
			{
				if(m_ThemeWindow==null)
				{
					if(this.ContainerControl is HVTTMarkStatus)
						m_ThemeWindow=((HVTTMarkStatus)this.ContainerControl).ThemeWindow;
					else if(this.ContainerControl is IThemeCache)
						m_ThemeWindow=((IThemeCache)this.ContainerControl).ThemeWindow;

				}
				return m_ThemeWindow;
			}
		}
		internal HVTT.UI.Window.Forms.ThemeRebar ThemeRebar
		{
			get
			{
				if(m_ThemeRebar==null)
				{
					if(this.ContainerControl is HVTTMarkStatus)
						m_ThemeRebar=((HVTTMarkStatus)this.ContainerControl).ThemeRebar;
					else if(this.ContainerControl is IThemeCache)
						m_ThemeRebar=((IThemeCache)this.ContainerControl).ThemeRebar;
				}
				return m_ThemeRebar;
			}
		}
		internal HVTT.UI.Window.Forms.ThemeToolbar ThemeToolbar
		{
			get
			{
				if(m_ThemeToolbar==null)
				{
					if(this.ContainerControl is HVTTMarkStatus)
						m_ThemeToolbar=((HVTTMarkStatus)this.ContainerControl).ThemeToolbar;
					else if(this.ContainerControl is IThemeCache)
						m_ThemeToolbar=((IThemeCache)this.ContainerControl).ThemeToolbar;
				}
				return m_ThemeToolbar;
			}
		}
		internal HVTT.UI.Window.Forms.ThemeHeader ThemeHeader
		{
			get
			{
				if(m_ThemeHeader==null)
				{
					if(this.ContainerControl is HVTTMarkStatus)
						m_ThemeHeader=((HVTTMarkStatus)this.ContainerControl).ThemeHeader;
					else if(this.ContainerControl is IThemeCache)
						m_ThemeHeader=((IThemeCache)this.ContainerControl).ThemeHeader;						
				}
				return m_ThemeHeader;
			}
		}
		internal HVTT.UI.Window.Forms.ThemeScrollBar ThemeScrollBar
		{
			get
			{
				if(m_ThemeScrollBar==null)
				{
					if(this.ContainerControl is HVTTMarkStatus)
						m_ThemeScrollBar=((HVTTMarkStatus)this.ContainerControl).ThemeScrollBar;
					else if(this.ContainerControl is IThemeCache)
						m_ThemeScrollBar=((IThemeCache)this.ContainerControl).ThemeScrollBar;
				}
				return m_ThemeScrollBar;
			}
		}

		internal HVTT.UI.Window.Forms.ThemeExplorerBar ThemeExplorerBar
		{
			get
			{
				if(m_ThemeExplorerBar==null)
				{
					if(this.ContainerControl is IThemeCache)
						m_ThemeExplorerBar=((IThemeCache)this.ContainerControl).ThemeExplorerBar;
				}
				return m_ThemeExplorerBar;
			}
		}

		internal HVTT.UI.Window.Forms.ThemeProgress ThemeProgress
		{
			get
			{
				if(m_ThemeProgress==null)
				{
					if(this.ContainerControl is HVTTMarkStatus)
						m_ThemeProgress=((HVTTMarkStatus)this.ContainerControl).ThemeProgress;
					else if(this.ContainerControl is IThemeCache)
						m_ThemeProgress=((IThemeCache)this.ContainerControl).ThemeProgress;
				}
				return m_ThemeProgress;
			}
		}

        internal HVTT.UI.Window.Forms.ThemeButton ThemeButton
        {
            get
            {
                if (m_ThemeButton == null)
                {
                    if (this.ContainerControl is IThemeCache)
                        m_ThemeButton = ((IThemeCache)this.ContainerControl).ThemeButton;
                }
                return m_ThemeButton;
            }
        }

		private void CreateStringFormat()
		{
            eTextFormat sfmt = eTextFormat.Default;
            if (this.ContainerControl is ItemControl)
                sfmt |= eTextFormat.HidePrefix;
			else if(!((this.Owner!=null && this.Owner.AlwaysDisplayKeyAccelerators) || NativeFunctions.ShowKeyboardCues || this.IsOnMenu)) 
			{
				HVTTMarkStatus bar=this.ContainerControl as HVTTMarkStatus;
                if (!((this.ContainerControl != null && this.ContainerControl.Focused) || (bar != null && bar.MenuFocus) || (bar != null && bar.AlwaysDisplayKeyAccelerators) || this.ContainerControl is NavigationBar))
                    sfmt |= eTextFormat.HidePrefix;
			}

            sfmt |= eTextFormat.SingleLine | eTextFormat.EndEllipsis | eTextFormat.VerticalCenter;
			this.ButtonStringFormat=sfmt;
		}
	}
}
