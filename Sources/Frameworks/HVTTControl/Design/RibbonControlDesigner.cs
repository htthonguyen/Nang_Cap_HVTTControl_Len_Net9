using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using HVTT.UI.Window.Forms.Rendering;

namespace HVTT.UI.Window.Forms.Design
{
	/// <summary>
	/// Represents Windows Forms designer for RibbonControl.
	/// </summary>
	public class RibbonControlDesigner:BarBaseControlDesigner
    {
        #region Private Variables
        private bool m_QuickAccessToolbarSelected = false;
        #endregion

        #region Internal Implementation

        public RibbonControlDesigner()
		{
			this.EnableItemDragDrop=true;
			this.AcceptExternalControls=false;
		}

		public override void Initialize(IComponent component) 
		{
			base.Initialize(component);
			if(!component.Site.DesignMode)
				return;
			RibbonControl c=component as RibbonControl;
			if(c!=null)
			{
				c.SetDesignMode();
				this.Expanded=c.Expanded;
			}
			this.EnableDragDrop(false);
		}

		public override bool CanParent(Control control)
		{
			if(control is RibbonPanel && !this.Control.Controls.Contains(control))
				return true;
			return false;
		}

		public override DesignerVerbCollection Verbs 
		{
			get 
			{
				HVTTMarkStatus bar=this.Control as HVTTMarkStatus;
				DesignerVerb[] verbs=null;
				verbs = new DesignerVerb[]
					{
						new DesignerVerb("Create Ribbon Tab", new EventHandler(CreateRibbonTab)),
						new DesignerVerb("Create Button", new EventHandler(CreateButton)),
						new DesignerVerb("Create Text Box", new EventHandler(CreateTextBox)),
						new DesignerVerb("Create Combo Box", new EventHandler(CreateComboBox)),
                        new DesignerVerb("Create Label", new EventHandler(CreateLabel))};
				
				return new DesignerVerbCollection(verbs);
			}
		}

        private BaseItem GetNewItemContainer()
        {
            RibbonControl r = this.Control as RibbonControl;
            if (m_QuickAccessToolbarSelected)
                return r.RibbonStrip.CaptionContainerItem;
            else
                return r.RibbonStrip.StripContainerItem;
        }

        protected override void CreateButton(object sender, EventArgs e)
        {
            RibbonControl r = this.Control as RibbonControl;
            if (r != null)
            {
                CreateButton(GetNewItemContainer());
            }
        }

        protected override void CreateTextBox(object sender, EventArgs e)
        {
            RibbonControl r = this.Control as RibbonControl;
            if (r != null)
            {
                CreateTextBox(GetNewItemContainer());
            }
        }

        protected override void CreateComboBox(object sender, EventArgs e)
        {
            RibbonControl r = this.Control as RibbonControl;
            if (r != null)
            {
                CreateComboBox(GetNewItemContainer());
            }
        }

        protected override void CreateLabel(object sender, EventArgs e)
        {
            RibbonControl r = this.Control as RibbonControl;
            if (r != null)
            {
                CreateLabel(GetNewItemContainer());
            }
        }

        protected override void CreateColorPicker(object sender, EventArgs e)
        {
            RibbonControl r = this.Control as RibbonControl;
            if (r != null)
            {
                CreateColorPicker(GetNewItemContainer());
            }
        }

        protected override void CreateProgressBar(object sender, EventArgs e)
        {
            RibbonControl r = this.Control as RibbonControl;
            if (r != null)
            {
                CreateProgressBar(GetNewItemContainer());
            }
        }

        protected override void ComponentChangeComponentAdded(object sender, ComponentEventArgs e)
        {
            if (m_AddingItem)
            {
                m_AddingItem = false;
                IComponentChangeService cc = this.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
                if (cc != null)
                    cc.OnComponentChanging(this.Control, null);
                this.GetNewItemContainer().SubItems.Add(e.Component as BaseItem);
                if (cc != null)
                    cc.OnComponentChanged(this.Control, null, null, null);
                m_InsertItemTransaction.Commit();
                m_InsertItemTransaction = null;
                this.RecalcLayout();
            }
        }

        protected override ArrayList GetAllAssociatedComponents()
        {
            ArrayList c = new ArrayList(base.AssociatedComponents);
            RibbonControl r = this.Control as RibbonControl;
            if (r != null)
            {
                AddSubItems(r.RibbonStrip.StripContainerItem, c);
                AddSubItems(r.RibbonStrip.CaptionContainerItem, c);
            }
            return c;
        }

		public override System.Collections.ICollection AssociatedComponents
		{
			get
			{
                ArrayList c = new ArrayList(this.BaseAssociatedComponents);
				RibbonControl rc=this.Control as RibbonControl;
				if(rc!=null)
				{
                    foreach (BaseItem item in rc.QuickToolbarItems)
                    {
                        if (!item.SystemItem)
                            c.Add(item);
                    }
                    foreach (BaseItem item in rc.Items)
                    {
                        if(!item.SystemItem)
                            c.Add(item);
                    }
					foreach(RibbonTabItemGroup group in rc.TabGroups)
						c.Add(group);
				}
				return c;
			}
		}

        // Removed FRAMEWORK20 directives. Keep both overrides.
        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            SetDesignTimeDefaults();
        }

		public override void OnSetComponentDefaults()
		{
            SetDesignTimeDefaults();
			base.OnSetComponentDefaults();
		}

        private void SetDesignTimeDefaults()
        {
            CreateRibbonTab();
            CreateRibbonTab();
            
            RibbonControl c = this.Control as RibbonControl;
            if (c != null)
            {
                try
                {
                    c.KeyTipsFont = new Font("Tahoma", 7);
                }
                catch { }
            }
            this.Style = HVTTControlStyle.Office2007;
            this.CanCustomize = true;
            c.Size = new Size(200, 154);
            c.Dock = DockStyle.Top;
            CreateRibbonBar();
            this.CaptionVisible = true;
        }

		protected override BaseItem GetItemContainer()
		{
			RibbonControl ribbon=this.Control as RibbonControl;
            if (ribbon != null)
                return ribbon.RibbonStrip.GetBaseItemContainer();
			return null;
		}

		protected override System.Windows.Forms.Control GetItemContainerControl()
		{
			RibbonControl ribbon=this.Control as RibbonControl;
			if(ribbon!=null)
				return ribbon.RibbonStrip;
			return null;
		}

		/// <summary>
		/// Support for popup menu closing.
		/// </summary>
		protected override void DesignTimeSelectionChanged(ISelectionService ss)
		{
			base.DesignTimeSelectionChanged(ss);

			if(ss==null)
				return;
			if(this.Control==null || this.Control.IsDisposed)
				return;

            RibbonControl r = this.Control as RibbonControl;
            if (r == null) return;
			
            BaseItem container = r.RibbonStrip.StripContainerItem;
            if (container == null) return;

			if(ss.PrimarySelection is RibbonTabItem)
			{
				RibbonTabItem item=ss.PrimarySelection as RibbonTabItem;
				if(container.SubItems.Contains(item))
				{
					TypeDescriptor.GetProperties(item)["Checked"].SetValue(item,true);
				}
			}
		}

		/// <summary>
		/// Triggered when some other component on the form is removed.
		/// </summary>
		protected override void OtherComponentRemoving(object sender, ComponentEventArgs e)
		{
            RibbonControl r = this.Control as RibbonControl;
            if (r != null)
            {
                BaseItem container = r.RibbonStrip.StripContainerItem;

                if (e.Component is RibbonTabItem && container != null && container.SubItems != null &&
                    container.SubItems.Contains(((RibbonTabItem)e.Component)))
                {
                    IDesignerHost dh = this.GetService(typeof(IDesignerHost)) as IDesignerHost;
                    if (dh != null)
                        dh.DestroyComponent(((RibbonTabItem)e.Component).Panel);
                }
            }
			base.OtherComponentRemoving(sender,e);
		}

        protected override void ComponentRemoved(object sender, ComponentEventArgs e)
        {
            RibbonControl r = this.Control as RibbonControl;
            if (e.Component is BaseItem && r!=null)
            {
                BaseItem item = e.Component as BaseItem;
                if (r.Items.Contains(item))
                    r.Items.Remove(item);
                else if (r.QuickToolbarItems.Contains(item))
                    r.QuickToolbarItems.Remove(item);
                DestroySubItems(item);
            }
        }

		protected override bool OnMouseDown(ref Message m, MouseButtons button)
		{
            m_QuickAccessToolbarSelected = false;

            System.Windows.Forms.Control ctrl = this.GetItemContainerControl();
            RibbonStrip strip = ctrl as RibbonStrip;

            if (strip == null)
                return base.OnMouseDown(ref m, button);

            Point pos = strip.PointToClient(System.Windows.Forms.Control.MousePosition);
            if (!strip.ClientRectangle.Contains(pos))
                return base.OnMouseDown(ref m, button);

            if (button == MouseButtons.Right)
            {
                if (strip.QuickToolbarBounds.Contains(pos))
                    m_QuickAccessToolbarSelected = true;
                return base.OnMouseDown(ref m, button);
            }
			
			bool callBase=true;
			foreach(RibbonTabItemGroup g in strip.TabGroups)
			{
				foreach(Rectangle r in g.DisplayPositions)
				{
					if(r.Contains(pos))
					{
						ArrayList arr=new ArrayList(1);
						arr.Add(g);
						ISelectionService selection = (ISelectionService) this.GetService(typeof(ISelectionService));
                        selection.SetSelectedComponents(arr,SelectionTypes.Primary);
                        this.MouseDownSelectionPerformed = true;
						callBase=false;
						break;
					}
				}
			}

			if(callBase)
				return base.OnMouseDown(ref m,button);
			else
				return true;
		}

		#endregion

		#region Design-Time Item Creation
		protected virtual void CreateRibbonTab(object sender, EventArgs e)
		{
			CreateRibbonTab();
		}

		private void CreateRibbonTab()
		{
            m_QuickAccessToolbarSelected = false;
			IDesignerHost dh=(IDesignerHost)GetService(typeof(IDesignerHost));
			if(dh!=null)
			{
				DesignerTransaction trans=dh.CreateTransaction("Create Ribbon Tab");
				IComponentChangeService cc=(IComponentChangeService)GetService(typeof(IComponentChangeService));
				RibbonControl ribbon=this.Control as RibbonControl;
				try
				{
                    m_CreatingItem = true;
					OnSubItemsChanging();
					RibbonTabItem item=dh.CreateComponent(typeof(RibbonTabItem)) as RibbonTabItem;
					TypeDescriptor.GetProperties(item)["Text"].SetValue(item,item.Name);

					RibbonPanel panel=dh.CreateComponent(typeof(RibbonPanel)) as RibbonPanel;
					TypeDescriptor.GetProperties(panel)["Dock"].SetValue(panel,DockStyle.Fill);
					TypeDescriptor.GetProperties(panel)["ColorSchemeStyle"].SetValue(panel,ribbon.Style);
                    ribbon.SetRibbonPanelStyle(panel);
					
                    cc.OnComponentChanging(this.Control,TypeDescriptor.GetProperties(typeof(Control))["Controls"]);
					this.Control.Controls.Add(panel);
					panel.SendToBack();
					cc.OnComponentChanged(this.Control,TypeDescriptor.GetProperties(typeof(Control))["Controls"],null,null);

					TypeDescriptor.GetProperties(item)["Panel"].SetValue(item,panel);

                    GenericItemContainer cont = ribbon.RibbonStrip.StripContainerItem;
                    cc.OnComponentChanging(cont, TypeDescriptor.GetProperties(typeof(BaseItem))["SubItems"]);
                    cont.SubItems.Add(item);
                    cc.OnComponentChanged(cont, TypeDescriptor.GetProperties(typeof(BaseItem))["SubItems"], null, null);
                    if (cont.SubItems.Count == 1)
						TypeDescriptor.GetProperties(item)["Checked"].SetValue(item,true);

					this.RecalcLayout();
					OnSubItemsChanged();
				}
				catch
				{
					trans.Cancel();
					throw;
				}
				finally
				{
					if(!trans.Canceled)
						trans.Commit();
                    m_CreatingItem = false;
				}
			}
		}

        private void CreateRibbonBar()
        {
            RibbonControl ribbon = this.Control as RibbonControl;
            if (ribbon == null || ribbon.SelectedRibbonTabItem == null || ribbon.SelectedRibbonTabItem.Panel == null) return;
            IDesignerHost dh = (IDesignerHost)GetService(typeof(IDesignerHost));
            if (dh != null)
            {
                DesignerTransaction trans = dh.CreateTransaction("Create Default Ribbon Bar");
                IComponentChangeService cc = (IComponentChangeService)GetService(typeof(IComponentChangeService));
                try
                {
                    RibbonBar bar = dh.CreateComponent(typeof(RibbonBar)) as RibbonBar;
                    TypeDescriptor.GetProperties(bar)["Width"].SetValue(bar, 100);
                    // Removed TRIAL conditional block
                    TypeDescriptor.GetProperties(bar)["Text"].SetValue(bar, bar.Name);

                    cc.OnComponentChanging(ribbon.SelectedRibbonTabItem.Panel, TypeDescriptor.GetProperties(typeof(Control))["Controls"]);
                    ribbon.SelectedRibbonTabItem.Panel.Controls.Add(bar);
                    bar.Dock = DockStyle.Left;
                    cc.OnComponentChanged(ribbon.SelectedRibbonTabItem.Panel, TypeDescriptor.GetProperties(typeof(Control))["Controls"], null, null);

                    this.RecalcLayout();
                }
                catch
                {
                    trans.Cancel();
                    throw;
                }
                finally
                {
                    if (!trans.Canceled)
                        trans.Commit();
                }
            }
        }
		#endregion

		#region Shadowing
		/// <summary>
		/// Gets/Sets the visual style of the control.
		/// </summary>
		[Browsable(true),HVTTBrowsable(true),Category("Appearance"),Description("Specifies the visual style of the control."),DefaultValue(HVTTControlStyle.Office2003)]
		public HVTTControlStyle Style
		{
			get
			{
				RibbonControl r=this.Control as RibbonControl;
				return r.Style;
			}
			set 
			{
				RibbonControl r=this.Control as RibbonControl;
				r.Style=value;
				IDesignerHost dh=this.GetService(typeof(IDesignerHost)) as IDesignerHost;
				if(dh!=null && !dh.Loading)
				{
					RibbonPredefinedColorSchemes.SetRibbonControlStyle(r, value);
				}
			}
		}

        /// <summary>
        /// Gets or sets whether custom caption and quick access toolbar provided by the control is visible. Default value is false.
        /// This property should be set to true when control is used on Office2007RibbonForm.
        /// </summary>
        [Browsable(true), DefaultValue(false), Category("Appearance"), Description("Indicates whether custom caption and quick access toolbar provided by the control is visible.")]

        public bool CaptionVisible 
		{
			get 
			{
                RibbonControl r = this.Control as RibbonControl;
                return r.CaptionVisible;
			}
			set 
			{
                RibbonControl r = this.Control as RibbonControl;
                if (r.CaptionVisible == value) return;
                r.CaptionVisible = value;
                if (r.CaptionVisible && (r.QuickToolbarItems.Count == 0 || r.QuickToolbarItems.Count == 1 && r.QuickToolbarItems[0] is SystemCaptionItem || 
					r.QuickToolbarItems.Count == 2 && r.QuickToolbarItems[0] is QatCustomizeItem))
                {
                    string fileNormal="StartButtonImage.png";
                    string fileNewDocument = "NewDocument.png";
                    string fileOpenDocument = "OpenDocument.png";
                    string fileSaveDocument = "Save.png";
                    string fileShare = "Share.png";
                    string filePrint = "Print.png";
                    string fileClose = "Close.png";
                    string fileExit = "Exit.png";
                    string fileOptions = "Options.png";

                    // Add custom items to the toolbar
                    IDesignerHost dh = this.GetService(typeof(IDesignerHost)) as IDesignerHost;
                    IComponentChangeService cc = this.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
                    if (dh != null && !dh.Loading && cc!=null && dh.TransactionDescription != "Paste components")
                    {
                        DesignerTransaction trans = dh.CreateTransaction();
                        try
                        {
                            Rendering.Office2007MenuColorTable mc = null;
                            if (Rendering.GlobalManager.Renderer is Rendering.Office2007Renderer)
                                mc = ((Rendering.Office2007Renderer)Rendering.GlobalManager.Renderer).ColorTable.Menu;

                            m_CreatingItem = true;
                            Office2007StartButton sb = dh.CreateComponent(typeof(Office2007StartButton)) as Office2007StartButton;
                            sb.HotTrackingStyle = HotTrackingStyle.Image;

                            sb.Image = LoadImage(fileNormal);

                            sb.ImagePaddingHorizontal = 2;
                            sb.ImagePaddingVertical = 2;
                            sb.ShowSubItems = false;
                            sb.CanCustomize = false;
                            sb.AutoExpandOnClick = true;
                            sb.Text = "&File";
                            cc.OnComponentChanging(r, TypeDescriptor.GetProperties(r)["QuickToolbarItems"]);
                            r.QuickToolbarItems.Add(sb, 0);
                            cc.OnComponentChanged(r, TypeDescriptor.GetProperties(r)["QuickToolbarItems"], null, null);
                            ButtonItem buttonStart = sb;

                            ButtonItem b = dh.CreateComponent(typeof(ButtonItem)) as ButtonItem;
                            b.Text = b.Name;
                            cc.OnComponentChanging(r, TypeDescriptor.GetProperties(r)["QuickToolbarItems"]);
                            r.QuickToolbarItems.Add(b, 1);
                            cc.OnComponentChanged(r, TypeDescriptor.GetProperties(r)["QuickToolbarItems"], null, null);

                            ItemContainer topContainer = dh.CreateComponent(typeof(ItemContainer)) as ItemContainer;
                            topContainer.BackgroundStyle.Class = ElementStyleClassKeys.RibbonFileMenuContainerKey;
                            topContainer.LayoutOrientation = HVTTOrientation.Vertical;
                            buttonStart.SubItems.Add(topContainer);

                            ItemContainer twoColumnMenu = dh.CreateComponent(typeof(ItemContainer)) as ItemContainer;
                            twoColumnMenu.BackgroundStyle.Class = ElementStyleClassKeys.RibbonFileMenuTwoColumnContainerKey;
                            twoColumnMenu.ItemSpacing = 0;
                            
                            topContainer.SubItems.Add(twoColumnMenu);

                            // Column One
                            ItemContainer columnOne = dh.CreateComponent(typeof(ItemContainer)) as ItemContainer;
                            columnOne.BackgroundStyle.Class = ElementStyleClassKeys.RibbonFileMenuColumnOneContainerKey;
                            columnOne.LayoutOrientation = HVTT.UI.Window.Forms.HVTTOrientation.Vertical;
                            columnOne.MinimumSize = new System.Drawing.Size(120, 0);
                            ButtonItem fileButton = CreateFileButton(dh, "&New", LoadImage(fileNewDocument));
                            columnOne.SubItems.Add(fileButton);
                            fileButton = CreateFileButton(dh, "&Open...", LoadImage(fileOpenDocument));
                            columnOne.SubItems.Add(fileButton);
                            fileButton = CreateFileButton(dh, "&Save...", LoadImage(fileSaveDocument));
                            columnOne.SubItems.Add(fileButton);
                            fileButton = CreateFileButton(dh, "S&hare...", LoadImage(fileShare));
                            fileButton.BeginGroup = true;
                            columnOne.SubItems.Add(fileButton);
                            fileButton = CreateFileButton(dh, "&Print...", LoadImage(filePrint));
                            columnOne.SubItems.Add(fileButton);
                            fileButton = CreateFileButton(dh, "&Close", LoadImage(fileClose));
                            fileButton.BeginGroup = true;
                            columnOne.SubItems.Add(fileButton);
                            twoColumnMenu.SubItems.Add(columnOne);

                            // Column Two
                            ItemContainer columnTwo = dh.CreateComponent(typeof(ItemContainer)) as ItemContainer;
                            columnTwo.BackgroundStyle.Class = ElementStyleClassKeys.RibbonFileMenuColumnTwoContainerKey;
                            columnTwo.LayoutOrientation = HVTT.UI.Window.Forms.HVTTOrientation.Vertical;
                            columnTwo.MinimumSize = new System.Drawing.Size(180, 0);
                            LabelItem mruLabel = dh.CreateComponent(typeof(LabelItem)) as LabelItem;
                            mruLabel.CanCustomize = false;
                            mruLabel.BackColor = System.Drawing.Color.Empty;
                            mruLabel.BorderSide = HVTT.UI.Window.Forms.BorderSide.Bottom;
                            mruLabel.BorderType = HVTT.UI.Window.Forms.eBorderType.Etched;
                            mruLabel.Font = null;
                            mruLabel.ForeColor = System.Drawing.SystemColors.ControlText;
                            mruLabel.Name = "labelItem8";
                            mruLabel.PaddingBottom = 2;
                            mruLabel.PaddingTop = 2;
                            mruLabel.Stretch = true;
                            mruLabel.Text = "Recent Documents";
                            columnTwo.SubItems.Add(mruLabel);
                            columnTwo.SubItems.Add(CreateMRUButton(dh, "&1. Short News 5-7.rtf"));
                            columnTwo.SubItems.Add(CreateMRUButton(dh, "&2. Prospect Email.rtf"));
                            columnTwo.SubItems.Add(CreateMRUButton(dh, "&3. Customer Email.rtf"));
                            columnTwo.SubItems.Add(CreateMRUButton(dh, "&4. example.rtf"));

                            twoColumnMenu.SubItems.Add(columnTwo);

                            // Bottom Container
                            ItemContainer bottomContainer = dh.CreateComponent(typeof(ItemContainer)) as ItemContainer;
                            bottomContainer.BackgroundStyle.Class = ElementStyleClassKeys.RibbonFileMenuBottomContainerKey;
                            bottomContainer.HorizontalItemAlignment = HVTT.UI.Window.Forms.eHorizontalItemsAlignment.Right;
                            fileButton = CreateFileButton(dh, "Opt&ions", LoadImage(fileOptions));
                            fileButton.ColorTable = eButtonColor.OrangeWithBackground;
                            bottomContainer.SubItems.Add(fileButton);
                            fileButton = CreateFileButton(dh, "E&xit", LoadImage(fileExit));
                            fileButton.ColorTable = eButtonColor.OrangeWithBackground;
                            bottomContainer.SubItems.Add(fileButton);
                            topContainer.SubItems.Add(bottomContainer);
                        }
                        catch
                        {
                            trans.Cancel();
                        }
                        finally
                        {
                            if (!trans.Canceled) trans.Commit();
                            m_CreatingItem = false;
                        }
                    }
                }
			}
		}

        private ButtonItem CreateFileButton(IDesignerHost dh, string text, Image image)
        {
            ButtonItem button = dh.CreateComponent(typeof(ButtonItem)) as ButtonItem;
            button.ButtonStyle = HVTT.UI.Window.Forms.HVTTButtonStyle.ImageAndText;
            button.Image = image;
            button.SubItemsExpandWidth = 24;
            button.Text = text;

            return button;
        }

        private ButtonItem CreateMRUButton(IDesignerHost dh, string text)
        {
            ButtonItem button = dh.CreateComponent(typeof(ButtonItem)) as ButtonItem;
            button.Text = text;

            return button;
        }


        private static Bitmap LoadImage(string imageName)
        {
            string imagesFolder = GetImagesFolder();
            if (imagesFolder != "")
            {
                if (File.Exists(imagesFolder + imageName))
                    return new Bitmap(imagesFolder + imageName);
            }

            return null;
        }

        private static string GetImagesFolder()
        {
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine;
                string path = "";
                try
                {
                    if (key != null)
                        key = key.OpenSubKey("Software\\HVTT\\HVTTCONTROLS");
                    if (key != null)
                        path = key.GetValue("InstallationFolder", "").ToString();
                }
                finally { if (key != null) key.Close(); }

                if (path != "")
                {
                    if (path.Substring(path.Length - 1, 1) != "\\")
                        path += "\\";
                    path += "Images\\";
                    return path;
                }
            }
            catch (Exception)
            {
            }
            return "";
        }

        /// <summary>
        /// Gets or sets whether control is expanded or not. When control is expanded both the tabs and the tab ribbons are visible. When collapsed
        /// only tabs are visible.
        /// </summary>
        [DefaultValue(true), Browsable(true), HVTTBrowsable(true), Category("Layout"), Description("Gets or sets whether control is expanded or not. When control is expanded both the tabs and the tab ribbons are visible.")]
        public bool Expanded
        {
            get
            {
                return (bool)ShadowProperties["Expanded"];
            }
            set
            {
                // this value is not passed to the actual control
                this.ShadowProperties["Expanded"] = value;

            }
        }
        
        /// <summary>
        /// Gets or sets whether control can be customized and items added by end-user using context menu to the quick access toolbar.
        /// Caption of the control must be visible for customization to be enabled. Default value is true.
        /// </summary>
        [DefaultValue(true), Browsable(true), Category("Quick Access Toolbar"), Description("Indicates whether control can be customized. Caption must be visible for customization to be fully enabled.")]
        public bool CanCustomize
        {
            get
            {
                RibbonControl rc = this.Control as RibbonControl;
                return rc.CanCustomize;
            }
            set
            {
                RibbonControl rc = this.Control as RibbonControl;
                rc.CanCustomize = value;

                IDesignerHost dh = this.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (dh != null && !dh.Loading)
                {
                    if (value)
                    {
                        // Make sure that QatCustomizeItem exists
                        QatCustomizeItem qatCustom = GetQatCustomizeItem(rc);
                        if (qatCustom == null)
                        {
                            DesignerTransaction dt = dh.CreateTransaction("Creating the QAT");
                            try
                            {
                                // Create QatCustomItem...
                                m_CreatingItem = true;
                                qatCustom = dh.CreateComponent(typeof(QatCustomizeItem)) as QatCustomizeItem;
                                IComponentChangeService cc = this.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
                                if (cc != null)
                                    cc.OnComponentChanging(rc, TypeDescriptor.GetProperties(rc)["QuickToolbarItems"]);
                                rc.QuickToolbarItems.Add(qatCustom);
                                if (cc != null)
                                    cc.OnComponentChanged(rc, TypeDescriptor.GetProperties(rc)["QuickToolbarItems"], null, null);
                                m_CreatingItem = false;
                                this.RecalcLayout();
                            }
                            catch
                            {
                                dt.Cancel();
                            }
                            finally
                            {
                                if (!dt.Canceled) dt.Commit();
                            }
                        }
                    }
                    else
                    {
                        QatCustomizeItem qatCustom = GetQatCustomizeItem(rc);
                        if (qatCustom != null)
                        {
                            DesignerTransaction dt = dh.CreateTransaction("Removing the QAT");
                            try
                            {
                                IComponentChangeService cc = this.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
                                if (cc != null)
                                    cc.OnComponentChanging(rc, TypeDescriptor.GetProperties(rc)["QuickToolbarItems"]);
                                rc.QuickToolbarItems.Remove(qatCustom);
                                if (cc != null)
                                    cc.OnComponentChanged(rc, TypeDescriptor.GetProperties(rc)["QuickToolbarItems"], null, null);
                                dh.DestroyComponent(qatCustom);
                            }
                            catch
                            {
                                dt.Cancel();
                            }
                            finally
                            {
                                if (!dt.Canceled) dt.Commit();
                            }
                        }
                    }
                }
            }
        }

        private QatCustomizeItem GetQatCustomizeItem(RibbonControl rc)
        {
            QatCustomizeItem qatCustom = null;
            foreach (BaseItem item in rc.QuickToolbarItems)
            {
                if (item is QatCustomizeItem)
                {
                    qatCustom = item as QatCustomizeItem;
                    break;
                }
            }
            return qatCustom;
        }

		protected override void PreFilterProperties(IDictionary properties)
		{
			base.PreFilterProperties(properties);
			properties["Expanded"] = TypeDescriptor.CreateProperty(typeof(RibbonControlDesigner),(PropertyDescriptor)properties["Expanded"], new Attribute[]
				{new DefaultValueAttribute(true),
					new BrowsableAttribute(true),
					new CategoryAttribute("Layout")});

			properties["Style"] = TypeDescriptor.CreateProperty(typeof(RibbonControlDesigner),(PropertyDescriptor)properties["Style"], new Attribute[]
				{
						new DefaultValueAttribute(HVTTControlStyle.Office2003),
					new BrowsableAttribute(true),
					new CategoryAttribute("Appearance")});

            properties["CaptionVisible"] = TypeDescriptor.CreateProperty(typeof(RibbonControlDesigner), (PropertyDescriptor)properties["CaptionVisible"], new Attribute[]
				{
					new DefaultValueAttribute(false),
					new BrowsableAttribute(true),
					new CategoryAttribute("Appearance"),
                    new DescriptionAttribute("Indicates whether custom caption and quick access toolbar provided by the control is visible.")});

            properties["CanCustomize"] = TypeDescriptor.CreateProperty(typeof(RibbonControlDesigner), (PropertyDescriptor)properties["CanCustomize"], new Attribute[]
				{
					new DefaultValueAttribute(true),
					new BrowsableAttribute(true),
					new CategoryAttribute("Quick Access Toolbar"),
                    new DescriptionAttribute("Indicates whether control can be customized. Caption must be visible for customization to be fully enabled")});
		}

		#endregion
	}
}
