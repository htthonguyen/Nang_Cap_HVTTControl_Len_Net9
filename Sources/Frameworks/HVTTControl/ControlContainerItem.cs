using System;
using System.Drawing;
using System.ComponentModel;

namespace HVTT.UI.Window.Forms
{
	/// <summary>
	/// Summary description for ControlContainerItem.
	/// </summary>
    [System.ComponentModel.ToolboxItem(false), System.ComponentModel.DesignTimeVisible(false), Designer(typeof(Design.SimpleBaseItemDesigner))]
	public class ControlContainerItem:ImageItem,IPersonalizedMenuItem
	{
		/// <summary>
		/// Occurs when container control needs to be assigned to the item.
		/// </summary>
		public event EventHandler ContainerLoadControl;
		public delegate void ControlContainerSerializationEventHandler(object sender, ControlContainerSerializationEventArgs e);
		public event ControlContainerSerializationEventHandler ContainerControlSerialize;
		public event ControlContainerSerializationEventHandler ContainerControlDeserialize;

		// IPersonalizedMenuItem Implementation
		private HVTTMenuVisibility m_MenuVisibility=HVTTMenuVisibility.VisibleAlways;
		private bool m_RecentlyUsed=false;
		private System.Windows.Forms.Control m_Control=null;
		private bool m_MouseOver=false;
		private bool m_AllowItemResize=true;

		/// <summary>
		/// Creates new instance of ControlContainerItem and assigns item name.
		/// </summary>
		public ControlContainerItem():this("","") {}
		/// <summary>
		/// Creates new instance of ControlContainerItem and assigns item name.
		/// </summary>
		/// <param name="sName">Item name.</param>
		public ControlContainerItem(string sName):this(sName,""){}
		/// <summary>
		/// Creates new instance of ControlContainerItem and assigns item name and item text.
		/// </summary>
		/// <param name="sName">Item name.</param>
		/// <param name="ItemText">Item text.</param>
		public ControlContainerItem(string sName, string ItemText):base(sName,ItemText)
		{
			m_SupportedOrientation=HVTTSupportedOrientation.Horizontal;
		}

		internal void InitControl()
		{
			EventArgs e=new EventArgs();
			if(ContainerLoadControl!=null)
				ContainerLoadControl(this,e);
			IOwnerItemEvents owner=this.GetIOwnerItemEvents();
			if(owner!=null)
				owner.InvokeContainerLoadControl(this,e);
			CustomizeChanged();
		}

		/// <summary>
		/// Overriden. Returns the copy of the ControlContainerItem.
		/// </summary>
		/// <returns>Copy of the ControlContainerItem.</returns>
		public override BaseItem Copy()
		{
			ControlContainerItem objCopy=new ControlContainerItem(this.Name);
            objCopy.AllowItemResize = this.AllowItemResize;
			this.CopyToItem(objCopy);
			return objCopy;
		}
		protected override void CopyToItem(BaseItem copy)
		{
			ControlContainerItem objCopy=copy as ControlContainerItem;
			base.CopyToItem(objCopy);
			objCopy.ContainerLoadControl=this.ContainerLoadControl;
			objCopy.InitControl();
		}
		public override void Dispose()
		{
			if(m_Control!=null)
			{
//				if(m_Control.Parent!=null && (!m_Control.Parent.Disposing && !(m_Control.Parent is Bar && ((Bar)m_Control.Parent).IsDisposing)))
//				{
//					m_Control.Parent.Controls.Remove(m_Control);
//				}
				m_Control=null;
			}
			base.Dispose();
		}
		protected internal override void Serialize(ItemSerializationContext context)
		{
			base.Serialize(context);
            System.Xml.XmlElement ThisItem = context.ItemXmlElement;
			ThisItem.SetAttribute("AllowResize",System.Xml.XmlConvert.ToString(m_AllowItemResize));

			if(ContainerControlSerialize!=null)
				this.ContainerControlSerialize(this,new ControlContainerSerializationEventArgs(ThisItem));
			IOwnerItemEvents owner=this.GetIOwnerItemEvents();
			if(owner!=null)
				owner.InvokeContainerControlSerialize(this,new ControlContainerSerializationEventArgs(ThisItem));

		}
		protected internal override void Deserialize(ItemSerializationContext context)
		{
			base.Deserialize(context);
            System.Xml.XmlElement ItemXmlSource = context.ItemXmlElement;
			m_AllowItemResize=System.Xml.XmlConvert.ToBoolean(ItemXmlSource.GetAttribute("AllowResize"));
			InitControl();

			if(ContainerControlDeserialize!=null)
				this.ContainerControlDeserialize(this,new ControlContainerSerializationEventArgs(ItemXmlSource));
			IOwnerItemEvents owner=this.GetIOwnerItemEvents();
			if(owner!=null)
				owner.InvokeContainerControlDeserialize(this,new ControlContainerSerializationEventArgs(ItemXmlSource));
		}

		// IPersonalizedMenuItem Impementation
		/// <summary>
		/// Indicates item's visiblity when on pop-up menu.
		/// </summary>
		[System.ComponentModel.Browsable(true),HVTTBrowsable(true),System.ComponentModel.Category("Appearance"),System.ComponentModel.Description("Indicates item's visiblity when on pop-up menu.")]
		public HVTTMenuVisibility MenuVisibility
		{
			get
			{
				return m_MenuVisibility;
			}
			set
			{
				if(m_MenuVisibility!=value)
				{
					m_MenuVisibility=value;
                    if(ShouldSyncProperties)
                        BarFunctions.SyncProperty(this, "MenuVisibility");
				}
			}
		}
		/// <summary>
		/// Indicates whether item was recently used.
		/// </summary>
		[System.ComponentModel.Browsable(false),System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public bool RecentlyUsed
		{
			get
			{
				return m_RecentlyUsed;
			}
			set
			{
				if(m_RecentlyUsed!=value)
				{
					m_RecentlyUsed=value;
                    if(ShouldSyncProperties)
                        BarFunctions.SyncProperty(this, "RecentlyUsed");
				}
			}
		}

		/// <summary>
		/// Gets/Sets infromational text (tooltip) for the item.
		/// </summary>
		[System.ComponentModel.Browsable(false),HVTTBrowsable(false),System.ComponentModel.DefaultValue(""),System.ComponentModel.Category("Appearance"),System.ComponentModel.Description("Indicates the text that is displayed when mouse hovers over the item."),System.ComponentModel.Localizable(true)]
		public override string Tooltip
		{
			get
			{
			
				return base.Tooltip;
			}
			set
			{
				base.Tooltip=value;
			}
		}

		/// <summary>
		/// Gets or sets the reference to the control that is managed by the item.
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		public System.Windows.Forms.Control Control
		{
			get
			{
				return m_Control;
			}
			set
			{
				if(m_Control!=null)
				{
					if(m_Control.Parent!=null)
						m_Control.Parent.Controls.Remove(m_Control);
				}
				m_Control=value;
				if(m_Control!=null)
				{
					if(m_Control.Parent!=null)
						m_Control.Parent.Controls.Remove(m_Control);
					m_Control.Dock=System.Windows.Forms.DockStyle.None;

                    //if (m_Control is System.Windows.Forms.ListBox)
                    //{
                    //    TypeDescriptor.GetProperties(m_Control)["IntegralHeight"].SetValue(m_Control, false);
                    //}
                    //if (!(m_Control is ItemControl) && TypeDescriptor.GetProperties(m_Control).Find("AutoSize", true) != null)
                    //    TypeDescriptor.GetProperties(m_Control)["AutoSize"].SetValue(m_Control, false);

					System.Windows.Forms.Control objCtrl=null;
					if(this.ContainerControl!=null)
					{
						objCtrl=this.ContainerControl as System.Windows.Forms.Control;
						if(objCtrl!=null)
						{
							objCtrl.Controls.Add(m_Control);
							m_Control.Refresh();
						}
					}
					if(!this.Displayed)
						m_Control.Visible=false;
				}
			}
		}

		/// <summary>
		/// Overriden. Draws the item.
		/// </summary>
		/// <param name="g">Target Graphics object.</param>
		public override void Paint(ItemPaintArgs pa)
		{
			if(this.SuspendLayout)
				return;

			System.Drawing.Graphics g=pa.Graphics;

			if(m_Control!=null && m_Control.Visible!=this.Displayed && !m_Control.Visible)
                CustomizeChanged();  // Determine based on customize status				

			Rectangle r=this.DisplayRectangle;

			Size objImageSize=GetMaxImageSize();
			bool bOnMenu=this.IsOnMenu;
            if (bOnMenu && this.Parent is ItemContainer)
                bOnMenu = false;

			if(this.Orientation==HVTTOrientation.Horizontal)
			{
				if(bOnMenu && !this.Stretch)
				{
					objImageSize.Width+=7;
					r.Width-=objImageSize.Width;
					r.X+=objImageSize.Width;
					if(this.IsOnCustomizeMenu)
						objImageSize.Width+=objImageSize.Height+8;
					// Draw side bar
					if(!pa.Colors.MenuSide2.IsEmpty)
					{
						System.Drawing.Drawing2D.LinearGradientBrush gradient=BarFunctions.CreateLinearGradientBrush(new Rectangle(m_Rect.Left,m_Rect.Top,objImageSize.Width,m_Rect.Height),pa.Colors.MenuSide,pa.Colors.MenuSide2,pa.Colors.MenuSideGradientAngle);
						g.FillRectangle(gradient,m_Rect.Left,m_Rect.Top,objImageSize.Width,m_Rect.Height);
						gradient.Dispose();
					}
					else
						g.FillRectangle(new SolidBrush(pa.Colors.MenuSide),m_Rect.Left,m_Rect.Top,objImageSize.Width,m_Rect.Height);
				}

				if(this.IsOnCustomizeMenu)
				{
					if(this.Style!=HVTTControlStyle.Office2000)
					{
						r.X+=(objImageSize.Height+8);
						r.Width-=(objImageSize.Height+8);
					}
					else
					{
						r.X+=(objImageSize.Height+4);
						r.Width-=(objImageSize.Height+4);
					}
				}

				if(bOnMenu && this.Style!=HVTTControlStyle.Office2000)
				{
					//g.FillRectangle(new SolidBrush(pa.Colors.MenuBackground),r);
				}
				//else if(this.Style==HVTTControlStyle.OfficeXP && !this.IsOnMenuBar)
				//	g.FillRectangle(new SolidBrush(ColorFunctions.ToolMenuFocusBackColor(g)),this.DisplayRectangle);
				//else
				//	g.FillRectangle(SystemBrushes.Control,this.DisplayRectangle);

				// Draw text if needed
                if (m_Control == null || this.GetDesignMode() || this.IsOnCustomizeMenu)
				{
					string text=m_Text;
					if(text=="")
						text="Container";
					eTextFormat objStringFormat=GetStringFormat();
					Font objFont=this.GetFont();
					Rectangle rText=new Rectangle(r.X+8,r.Y,r.Width,r.Height);
					if(this.Style==HVTTControlStyle.Office2000)
					{
                        TextDrawing.DrawString(g, text, objFont, SystemColors.ControlText, rText, objStringFormat);
					}
					else
					{
                        TextDrawing.DrawString(g, text, objFont, SystemColors.ControlText, rText, objStringFormat);
					}
					Size textSize=TextDrawing.MeasureString(g,text,objFont,0,objStringFormat);
					r.X+=(int)textSize.Width+8;
					r.Width-=((int)textSize.Width+8);
				}
				else if(m_Control!=null)
				{
					r.Inflate(-2,-2);
                    if (m_AllowItemResize)
                    {
                        m_Control.Width = r.Width;
                    }
					Point loc=r.Location;
					loc.Offset((r.Width-m_Control.Width)/2,(r.Height-m_Control.Height)/2);
					m_Control.Location=loc;
				}

				if(this.IsOnCustomizeMenu && this.Visible)
				{
					// Draw check box if this item is visible
					Rectangle rBox=new Rectangle(m_Rect.Left,m_Rect.Top,m_Rect.Height,m_Rect.Height);
					if(this.Style!=HVTTControlStyle.Office2000)
						rBox.Inflate(-1,-1);
					BarFunctions.DrawMenuCheckBox(pa,rBox,this.Style,m_MouseOver);
				}
			}

            if (this.Focused && (this.GetDesignMode() || m_Control == null && this.DesignMode))
			{
				r=this.DisplayRectangle;
				r.Inflate(-1,-1);
				DesignTime.DrawDesignTimeSelection(g,r,pa.Colors.ItemDesignTimeBorder);
			}
		}
		/// <summary>
		/// Overridden. Recalculates the size of the item.
		/// </summary>
		public override void RecalcSize()
		{
			if(this.SuspendLayout)
				return;

			bool bOnMenu=this.IsOnMenu;

			if(m_Control==null && !this.DesignMode)
				InitControl();

            // Default Height
			if(this.Parent!=null && this.Parent is ImageItem)
				m_Rect.Height=((ImageItem)this.Parent).SubItemsImageSize.Height+4;
			else
				m_Rect.Height=this.SubItemsImageSize.Height+4;

			if(this.Style==HVTTControlStyle.OfficeXP || this.Style==HVTTControlStyle.Office2003 || this.Style==HVTTControlStyle.VS2005)
			{
				if(m_Control!=null && m_Rect.Height<(m_Control.Height+2))
					m_Rect.Height=m_Control.Height+2;
			}
			else
			{
				if(m_Control!=null && m_Rect.Height<(m_Control.Height+2))
					m_Rect.Height=m_Control.Height+2;
			}
                
			// Default width
			if(m_Control!=null)
			{
                if (this.Stretch)
                    m_Rect.Width = 32;
                else
                {
                    m_Rect.Width = m_Control.Width + 4;
                }
			}
			else
				m_Rect.Width=64+4;

			// Calculate Item Height
			if(m_Control==null)
			{
				string text=m_Text;
				if(text=="")
					text="Container";
				System.Windows.Forms.Control objCtrl=this.ContainerControl as System.Windows.Forms.Control;
				if(objCtrl!=null && IsHandleValid(objCtrl))
				{
					Graphics g=BarFunctions.CreateGraphics(objCtrl);
                    try
                    {
                        Size textSize = TextDrawing.MeasureString(g, text, GetFont(), 0, GetStringFormat());
                        if (textSize.Height > this.SubItemsImageSize.Height && textSize.Height > m_Rect.Height)
                            m_Rect.Height = (int)textSize.Height + 4;
                        m_Rect.Width = (int)textSize.Width + 8;
                    }
                    finally
                    {
                        g.Dispose();
                    }
				}
			}

			Size objImageSize=GetMaxImageSize();
			if(this.IsOnMenu && this.Style!=HVTTControlStyle.Office2000 && !this.Stretch && !(this.Parent is ItemContainer))
			{
				// THis is side bar that will need to be drawn for DotNet style
				m_Rect.Width+=(objImageSize.Width+7);
			}

			if(this.IsOnCustomizeMenu)
				m_Rect.Width+=(objImageSize.Height+2);

			// Always call base implementation to reset resize flag
			base.RecalcSize();
		}

		/// <summary>
		/// Called when size of the item is changed externaly.
		/// </summary>
		protected override void OnExternalSizeChange()
		{
			base.OnExternalSizeChange();
            if(m_AllowItemResize)
			    NeedRecalcSize=true;
		}

		protected internal override void OnContainerChanged(object objOldContainer)
		{	
			base.OnContainerChanged(objOldContainer);
			if(m_Control!=null)
			{
				System.Windows.Forms.Control objCtrl=this.ContainerControl as System.Windows.Forms.Control;
				if(m_Control.Parent!=null && objCtrl!=m_Control.Parent)
					m_Control.Parent.Controls.Remove(m_Control);

				if(objCtrl!=null && m_Control.Parent==null)
				{
					objCtrl.Controls.Add(m_Control);
					m_Control.Refresh();
				}
			}
		}

		protected internal override void OnVisibleChanged(bool newValue)
		{
			if(m_Control!=null && !newValue)
				m_Control.Visible=newValue;
			base.OnVisibleChanged(newValue);
		}
		protected override void OnDisplayedChanged()
		{
            if (!this.Displayed && m_Control != null && !(this.IsOnCustomizeMenu || this.IsOnCustomizeDialog || this.GetDesignMode()))
			{
				m_Control.Visible=this.Displayed;
			}
		}

		protected override void OnIsOnCustomizeDialogChanged()
		{
			base.OnIsOnCustomizeDialogChanged();
			CustomizeChanged();
		}

		protected override void OnDesignModeChanged()
		{
			base.OnDesignModeChanged();
			CustomizeChanged();
		}

		protected override void OnIsOnCustomizeMenuChanged()
		{
			base.OnIsOnCustomizeMenuChanged();
			CustomizeChanged();
		}

        private bool m_CustomizeChangedExecuting = false;
        private void CustomizeChanged()
        {
	        if(m_Control!=null)
	        {
                if (m_CustomizeChangedExecuting) return;
                m_CustomizeChangedExecuting = true;
                try
                {
                    if (this.IsOnCustomizeMenu || this.IsOnCustomizeDialog || this.GetDesignMode())
                    {
                        m_Control.Visible = false;
                    }
                    else
                    {
                        m_Control.Visible = this.Displayed;
                    }
                }
                finally
                {
                    m_CustomizeChangedExecuting = false;
                }
	        }
        }

		private Size GetMaxImageSize()
		{
			if(m_Parent!=null)
			{
				ImageItem objParentImageItem=m_Parent as ImageItem;
				if(objParentImageItem!=null)
					return objParentImageItem.SubItemsImageSize;
				else
					return this.ImageSize;
			}
			else
				return this.ImageSize;
		}
        private eTextFormat GetStringFormat()
		{
            eTextFormat format = eTextFormat.Default;
            format |= eTextFormat.SingleLine;
            format |= eTextFormat.EndEllipsis;
            format |= eTextFormat.VerticalCenter;
            return format;


            //StringFormat sfmt=BarFunctions.CreateStringFormat(); //new StringFormat(StringFormat.GenericDefault);
            //sfmt.HotkeyPrefix=System.Drawing.Text.HotkeyPrefix.Show;
            ////sfmt.FormatFlags=sfmt.FormatFlags & ~(sfmt.FormatFlags & StringFormatFlags.DisableKerning);
            //sfmt.FormatFlags=sfmt.FormatFlags | StringFormatFlags.NoWrap;
            //sfmt.Trimming=StringTrimming.EllipsisCharacter;
            //sfmt.Alignment=System.Drawing.StringAlignment.Near;
            //sfmt.LineAlignment=System.Drawing.StringAlignment.Center;

            //return sfmt;
		}

		/// <summary>
		/// Returns the Font object to be used for drawing the item text.
		/// </summary>
		/// <returns>Font object.</returns>
		protected virtual Font GetFont()
		{
			System.Windows.Forms.Control objCtrl=this.ContainerControl as System.Windows.Forms.Control;
			if(objCtrl!=null)
				return (Font)objCtrl.Font;
			return (Font)System.Windows.Forms.SystemInformation.MenuFont;
		}
		protected internal override bool IsAnyOnHandle(int iHandle)
		{
			bool bRet=base.IsAnyOnHandle(iHandle);
			if(!bRet && m_Control!=null && m_Control.Handle.ToInt32()==iHandle)
				bRet=true;
			return bRet;
		}
		protected override void OnEnabledChanged()
		{
			base.OnEnabledChanged();
			if(m_Control!=null)
				m_Control.Enabled=this.Enabled;
		}

		[System.ComponentModel.Browsable(false),System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public override void InternalMouseEnter()
		{
			base.InternalMouseEnter();
			if(!m_MouseOver)
			{
				m_MouseOver=true;
				this.Refresh();
			}
		}

		[System.ComponentModel.Browsable(false),System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public override void InternalMouseLeave()
		{
			base.InternalMouseLeave();
			if(m_MouseOver)
			{
				m_MouseOver=false;
				this.Refresh();
			}
		}

		/// <summary>
		/// Specifies whether contained control can be automatically resized to fill the item container.
		/// </summary>
		[System.ComponentModel.Browsable(true),HVTTBrowsable(true),System.ComponentModel.Category("Behavior"),System.ComponentModel.Description("Specifies whether contained control can be automatically resized to fill the item container.")]
		public bool AllowItemResize
		{
			get {return m_AllowItemResize;}
			set {m_AllowItemResize=value;}
		}

		protected internal override void OnGotFocus()
		{
			base.OnGotFocus();
			if(m_Control==null)
				return;
            if (m_Control.Focused || this.IsOnCustomizeMenu || this.IsOnCustomizeDialog || this.GetDesignMode())
				return;
			m_Control.Focus();
		}

		[System.ComponentModel.Browsable(false),System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public override bool IsWindowed
		{
			get {return true;}
		}

        private bool GetDesignMode()
        {
            if (this.ContainerControl is Design.IBarDesignerServices && ((Design.IBarDesignerServices)this.ContainerControl).Designer != null)
                return false;
            return base.DesignMode;
        }
	}

	public class ControlContainerSerializationEventArgs : EventArgs 
	{
		private readonly System.Xml.XmlElement xmlstore;
		public ControlContainerSerializationEventArgs(System.Xml.XmlElement xmlstorage) 
		{
			this.xmlstore=xmlstorage;
		}
		public System.Xml.XmlElement XmlStorage
		{
			get{return this.xmlstore;}
		}
	}
}
