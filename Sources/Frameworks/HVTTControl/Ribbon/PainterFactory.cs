using System.Windows.Forms;
namespace HVTT.UI.Window.Forms
{
	/// <summary>
	/// Summary description for PainterFactory.
	/// </summary>
	internal class PainterFactory
	{
		private static Office2003ButtonItemPainter m_Office2003Painter=new Office2003ButtonItemPainter();
        private static Office2007ButtonItemPainter m_Office2007Painter = new Office2007ButtonItemPainter();
		private static Office2003RibbonTabItemPainter m_RibbonTabItemOffice2003Painter=new Office2003RibbonTabItemPainter();
        private static Office2007ItemContainerPainter m_Office2007ItemContainerPainter = new Office2007ItemContainerPainter();
        private static Office2007BarBackgroundPainter m_Office2007BarBackgroundPainter = new Office2007BarBackgroundPainter();
        private static Office2007KeyTipsPainter m_Office2007KeyTipsPainter = new Office2007KeyTipsPainter();
        private static Office2007DialogLauncherPainter m_Office2007RibbonBarPainter = new Office2007DialogLauncherPainter();
        private static Office2007RibbonControlPainter m_Office2007RibbonControlPainter = new Office2007RibbonControlPainter();
        private static Office2007RibbonTabItemPainter m_Office2007RibbonTabItemPainter = new Office2007RibbonTabItemPainter();
        private static Office2007RibbonTabGroupPainter m_Office2007RibbonTabGroupPainter = new Office2007RibbonTabGroupPainter();
        private static Rendering.Office2007ColorItemPainter m_Office2007ColorItemPainter = new Rendering.Office2007ColorItemPainter();
        private static Office2007SystemCaptionItemPainter m_Office2007SystemCaptionItemPainter = new Office2007SystemCaptionItemPainter();
        private static Office2007MdiSystemItemPainter m_Office2007MdiSystemItemPainter = new Office2007MdiSystemItemPainter();
        private static Office2007FormCaptionPainter m_Office2007FormCaptionPainter = new Office2007FormCaptionPainter();
        private static Rendering.Office2007RibbonOverflowPainter m_Office2007RibbonOverflowPainter = new HVTT.UI.Window.Forms.Rendering.Office2007RibbonOverflowPainter();
        private static Rendering.Office2007QatOverflowPainter m_Office2007QatOverflowPainter = new HVTT.UI.Window.Forms.Rendering.Office2007QatOverflowPainter();
        private static Rendering.Office2007QatCustomizeItemPainter m_Office2007QatCustomizePainter = new HVTT.UI.Window.Forms.Rendering.Office2007QatCustomizeItemPainter();
        private static Rendering.Office2007CheckBoxItemPainter m_Office2007CheckBoxItemPainter = new Rendering.Office2007CheckBoxItemPainter();
        private static Rendering.Office2007ProgressBarItemPainter m_Office2007ProgressBarPainter = new HVTT.UI.Window.Forms.Rendering.Office2007ProgressBarItemPainter();
        private static Rendering.Office2007NavigationPanePainter m_Office2007NavPanePainter = new HVTT.UI.Window.Forms.Rendering.Office2007NavigationPanePainter();
        private static Rendering.SliderPainter m_SliderPainter = new HVTT.UI.Window.Forms.Rendering.Office2007SliderPainter();
        private static Rendering.SideBarPainter m_SideBarPainter = new HVTT.UI.Window.Forms.Rendering.Office2007SideBarPainter();

		public static ButtonItemPainter CreateButtonPainter(ButtonItem button)
		{
			if(button is RibbonTabItem)
			{
				return CreateRibbonTabItemPainter((RibbonTabItem)button);
			}
            if (button is RibbonOverflowButtonItem)
            {
                ButtonItemPainter p = CreateRibbonOverflowButtonPainter((RibbonOverflowButtonItem)button);
                if (p != null)
                    return p;
            }
			if(button.Style==HVTTControlStyle.Office2003 || button.Style==HVTTControlStyle.VS2005 || button.Style==HVTTControlStyle.OfficeXP || button.Style==HVTTControlStyle.Office2000)
			{
				return m_Office2003Painter;
			}
            else if (button.Style == HVTTControlStyle.Office2007)
            {
                if (button.ContainerControl is RibbonBar)
                    return m_Office2007Painter;
                return m_Office2007Painter;
            }
			return null;
		}

        public static ButtonItemPainter CreateRibbonOverflowButtonPainter(RibbonOverflowButtonItem button)
        {
            if (button.Style == HVTTControlStyle.Office2007)
                return m_Office2007RibbonOverflowPainter;
            return null;
        }

		public static ButtonItemPainter CreateRibbonTabItemPainter(RibbonTabItem tab)
		{
            if (tab.Style == HVTTControlStyle.Office2007 && !tab.IsOnMenu)
            {
                return m_Office2007RibbonTabItemPainter;
            }
			if((tab.Style==HVTTControlStyle.Office2003 || tab.Style==HVTTControlStyle.VS2005) && !tab.IsOnMenu)
			{
				return m_RibbonTabItemOffice2003Painter;
			}
			
			return m_Office2003Painter;
		}

        public static ItemContainerPainter CreateItemContainerPainter(ItemContainer container)
        {
            if (container.Style == HVTTControlStyle.Office2007)
                return m_Office2007ItemContainerPainter;
            return null;
        }

        public static BarBackgroundPainter CreateBarBackgroundPainter(HVTTMarkStatus bar)
        {
            return m_Office2007BarBackgroundPainter;
        }

        public static KeyTipsPainter CreateKeyTipsPainter()
        {
            return m_Office2007KeyTipsPainter;
        }

        public static DialogLauncherPainter CreateRibbonBarPainter(RibbonBar ribbon)
        {
            if (ribbon.Style == HVTTControlStyle.Office2007)
                return m_Office2007RibbonBarPainter;
            return null;
        }

        public static RibbonTabGroupPainter CreateRibbonTabGroupPainter(RibbonTabItemGroup group)
        {
            return m_Office2007RibbonTabGroupPainter;
        }

        public static Rendering.ColorItemPainter CreateColorItemPainter(ColorItem item)
        {
            return m_Office2007ColorItemPainter;
        }

        public static RibbonControlPainter CreateRibbonControlPainter(RibbonControl r)
        {
            if (r.Style == HVTTControlStyle.Office2007)
                return m_Office2007RibbonControlPainter;
            return null;
        }

        public static SystemCaptionItemPainter CreateSystemCaptionItemPainter(SystemCaptionItem item)
        {
            if (item.Style == HVTTControlStyle.Office2007)
                return m_Office2007SystemCaptionItemPainter;
            return null;
        }

        public static MdiSystemItemPainter CreateMdiSystemItemPainter(MDISystemItem mdiSystemItem)
        {
            if (mdiSystemItem.Style == HVTTControlStyle.Office2007)
                return m_Office2007MdiSystemItemPainter;
            return null;
        }

        public static FormCaptionPainter CreateFormCaptionPainter(Form form)
        {
            return m_Office2007FormCaptionPainter;
        }

        public static HVTT.UI.Window.Forms.Rendering.QatOverflowPainter CreateQatOverflowItemPainter(QatOverflowItem ribbonQatOverflowItem)
        {
            return m_Office2007QatOverflowPainter;
        }

        public static HVTT.UI.Window.Forms.Rendering.QatCustomizeItemPainter CreateQatCustomizeItemPainter(QatCustomizeItem qatCustomizeItem)
        {
            return m_Office2007QatCustomizePainter;
        }

        public static Rendering.Office2007CheckBoxItemPainter CreateCheckBoxItemPainter(CheckBoxItem item)
        {
            return m_Office2007CheckBoxItemPainter;
        }

        /// <summary>
        /// Forces the creation of the objects inside of factory.
        /// </summary>
        public static void InitFactory() { }

        public static HVTT.UI.Window.Forms.Rendering.ProgressBarItemPainter CreateProgressBarItemPainter(ProgressBarItem progressBarItem)
        {
            return m_Office2007ProgressBarPainter;
        }

        internal static HVTT.UI.Window.Forms.Rendering.NavigationPanePainter CreateNavigationPanePainter()
        {
            return m_Office2007NavPanePainter;
        }

        internal static HVTT.UI.Window.Forms.Rendering.SliderPainter CreateSliderPainter()
        {
            return m_SliderPainter;
        }

        internal static HVTT.UI.Window.Forms.Rendering.SideBarPainter CreateSideBarPainter()
        {
            return m_SideBarPainter;
        }
    }
}
