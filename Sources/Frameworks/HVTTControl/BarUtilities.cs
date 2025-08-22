using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace HVTT.UI.Window.Forms
{
	/// <summary>
	/// Represents class with static functions that provide commonly used utility functions when working with
	/// Bar objects and items hosted by Bar object.
	/// </summary>
	public class BarUtilities
    {
        #region Docking
        /// <summary>
		/// Sets the visible property of DockContainerItem and hides the bar if the given item is the last visible item on the bar.
		/// It will also automatically display the bar if bar is not visible.
		/// </summary>
		/// <param name="item">DockContainerItem to set visibility for.</param>
		/// <param name="visible">Indicates the visibility of the item</param>
		public static void SetDockContainerVisible(HVTT.UI.Window.Forms.DockContainerItem item, bool visible)
		{
			if(item==null || item.Visible==visible)
				return;

			HVTT.UI.Window.Forms.HVTTMarkStatus containerBar=item.ContainerControl as HVTT.UI.Window.Forms.HVTTMarkStatus;

			if(containerBar==null)
			{
				// If bar has not been assigned yet just set the visible property and exit
				item.Visible=visible;
				return;
			}

			HVTTManager manager=containerBar.Owner as HVTTManager;
			if(manager!=null)
				manager.SuspendLayout=true;

			try
			{
				int visibleCount=containerBar.VisibleItemCount;

				if(visible)
				{
					item.Visible=true;
					if(!containerBar.AutoHide && !containerBar.Visible && visibleCount<=1)
					{
						containerBar.Visible=true;
						if(containerBar.PropertyBag.ContainsKey(BarPropertyBagKeys.AutoHideSetting))
						{
							containerBar.PropertyBag.Remove(BarPropertyBagKeys.AutoHideSetting);
							containerBar.AutoHide=true;
						}
					}
				}
				else
				{
                    if (visibleCount <= 1)
                    {
                        if (containerBar.PropertyBag.ContainsKey(BarPropertyBagKeys.AutoHideSetting))
                            containerBar.PropertyBag.Remove(BarPropertyBagKeys.AutoHideSetting);
                        // Remember auto-hide setting
                        if (containerBar.AutoHide)
                            containerBar.PropertyBag.Add(BarPropertyBagKeys.AutoHideSetting, true);
                        containerBar.CloseBar();
                    }
					item.Visible=false;
				}
			}
			finally
			{
				if(manager!=null)
					manager.SuspendLayout=false;
				containerBar.RecalcLayout();
			}
		}

		/// <summary>
		/// Creates new instance of the bar and sets its properties so bar can be used as Document bar.
		/// </summary>
		/// <returns>Returns new instance of the bar.</returns>
		public static HVTTMarkStatus CreateDocumentBar()
		{
			HVTTMarkStatus bar=new HVTTMarkStatus();
			BarUtilities.InitializeDocumentBar(bar);
			return bar;
		}

		/// <summary>
		/// Sets the properties on a bar so it can be used as Document bar.
		/// </summary>
		/// <param name="bar">Bar to set properties of.</param>
		public static void InitializeDocumentBar(HVTTMarkStatus bar)
		{
			TypeDescriptor.GetProperties(bar)["LayoutType"].SetValue(bar,HVTTLayoutType.DockContainer);
			TypeDescriptor.GetProperties(bar)["DockTabAlignment"].SetValue(bar,eTabStripAlignment.Top);
			TypeDescriptor.GetProperties(bar)["AlwaysDisplayDockTab"].SetValue(bar,true);
			TypeDescriptor.GetProperties(bar)["Stretch"].SetValue(bar,true);
			TypeDescriptor.GetProperties(bar)["GrabHandleStyle"].SetValue(bar,HVTTGrabHandleStyle.None);
			TypeDescriptor.GetProperties(bar)["CanDockBottom"].SetValue(bar,false);
			TypeDescriptor.GetProperties(bar)["CanDockTop"].SetValue(bar,false);
			TypeDescriptor.GetProperties(bar)["CanDockLeft"].SetValue(bar,false);
			TypeDescriptor.GetProperties(bar)["CanDockRight"].SetValue(bar,false);
			TypeDescriptor.GetProperties(bar)["CanDockDocument"].SetValue(bar,true);
			TypeDescriptor.GetProperties(bar)["CanUndock"].SetValue(bar,false);
			TypeDescriptor.GetProperties(bar)["CanHide"].SetValue(bar,true);
			TypeDescriptor.GetProperties(bar)["CanCustomize"].SetValue(bar,false);
			TypeDescriptor.GetProperties(bar)["TabNavigation"].SetValue(bar,true);
        }

        #region Win API
        [DllImport("user32")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        private const int GWL_EXSTYLE = (-20);
        private const int WS_EX_CLIENTEDGE = 0x00000200;
        [DllImport("user32")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
        const int SWP_FRAMECHANGED = 0x0020;
        const int SWP_NOSIZE = 0x0001;
        const int SWP_NOMOVE = 0x0002;
        const int SWP_NOZORDER = 0x0004;
        #endregion

        /// <summary>
        /// Changes the MDI Client border edge to remove 3D border or to add it.
        /// </summary>
        /// <param name="c">Reference to MDI Client object.</param>
        /// <param name="removeBorder">Indicates whether to remove border.</param>
        public static void ChangeMDIClientBorder(System.Windows.Forms.MdiClient c, bool removeBorder)
        {
            if (c != null)
            {
                int exStyle = GetWindowLong(c.Handle, GWL_EXSTYLE);
                
                if(removeBorder)
                    exStyle ^= WS_EX_CLIENTEDGE;
                else
                    exStyle |= WS_EX_CLIENTEDGE;

                SetWindowLong(c.Handle, GWL_EXSTYLE, exStyle);
                SetWindowPos(c.Handle, IntPtr.Zero, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED);
            }
        }

        /// <summary>
        /// Changes the MDI Client border edge to remove 3D border or to add it.
        /// </summary>
        /// <param name="c">Reference to MDI parent form.</param>
        /// <param name="removeBorder">Indicates whether to remove border.</param>
        public static void ChangeMDIClientBorder(System.Windows.Forms.Form c, bool removeBorder)
        {
            if (c.IsMdiContainer && c.IsHandleCreated)
            {
                foreach (System.Windows.Forms.Control control in c.Controls)
                {
                    if (control is System.Windows.Forms.MdiClient)
                    {
                        ChangeMDIClientBorder(control as System.Windows.Forms.MdiClient, removeBorder);
                        break;
                    }
                }
            }
        }
        #endregion

        #region Item Invalidate
        internal static void InvalidateFontChange(SubItemsCollection col)
        {
            foreach (BaseItem item in col)
            {
                InvalidateFontChange(item);
            }
        }

        internal static void InvalidateFontChange(BaseItem item)
        {
            if (item.TextMarkupBody != null) item.TextMarkupBody.InvalidateElementsSize();
            if (item.SubItems.Count > 0) InvalidateFontChange(item.SubItems);
        }
        #endregion

        internal static void InvokeRecalcLayout(System.Windows.Forms.Control control)
        {
            if (control is HVTTMarkStatus)
                ((HVTTMarkStatus)control).RecalcLayout();
            else if (control is ItemControl)
                ((ItemControl)control).RecalcLayout();
            else if (control is BaseItemControl)
                ((BaseItemControl)control).RecalcLayout();
            else if (control is ExplorerBar)
                ((ExplorerBar)control).RecalcLayout();
            else if (control is SideBar)
                ((SideBar)control).RecalcLayout();
        }

        /// <summary>
        /// Gets or sets whether StringFormat internally used by all HVTTCONTROLS controls to render text is GenericDefault. Default value is false
        /// which indicates that GenericTypographic is used.
        /// </summary>
        public static bool UseGenericDefaultStringFormat
        {
            get { return TextDrawing.UseGenericDefault; }
            set { TextDrawing.UseGenericDefault = value; }
        }
    }

	internal class BarPropertyBagKeys
	{
		public static string AutoHideSetting="autohide";
	}
}
