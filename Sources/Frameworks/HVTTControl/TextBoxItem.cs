namespace HVTT.UI.Window.Forms
{
	using System;
	using System.Drawing;
    using HVTT.UI.Window.Forms.Controls;
    using System.ComponentModel;
    using HVTT.UI.Window.Forms.Rendering;
    using System.Windows.Forms;

	/// <summary>
	///		Summary description for TextBoxItem.
	/// </summary>
    [System.ComponentModel.ToolboxItem(false), System.ComponentModel.DesignTimeVisible(false), Designer(typeof(Design.SimpleBaseItemDesigner))]
	public class TextBoxItem:ImageItem,IPersonalizedMenuItem
	{
		public delegate void TextChangedEventHandler(object sender);
		public event TextChangedEventHandler InputTextChanged;
		public event System.Windows.Forms.KeyEventHandler KeyDown;
		public event System.Windows.Forms.KeyPressEventHandler KeyPress;
		public event System.Windows.Forms.KeyEventHandler KeyUp;

		//public delegate void LostFocusEventHandler(object sender);
		//public event LostFocusEventHandler LostFocus;

		private HVTTMarkTextBox m_TextBox;
		private bool m_MouseOver;
		private bool m_AlwaysShowCaption;
		private int m_TextBoxWidth;
		private string m_ControlText="";

		// IPersonalizedMenuItem Implementation
		private HVTTMenuVisibility m_MenuVisibility=HVTTMenuVisibility.VisibleAlways;
		private bool m_RecentlyUsed=false;

		public TextBoxItem():this("","") {}
		public TextBoxItem(string sName):this(sName,"") {}

		public TextBoxItem(string sName, string ItemText):base(sName,ItemText)
		{
			CreateTextBox();
			m_MouseOver=false;
			m_AlwaysShowCaption=false;
			m_TextBoxWidth=64;
			this.ImageSize=new Size(16,16);
			m_SupportedOrientation=HVTTSupportedOrientation.Horizontal;
		}
		private void CreateTextBox()
		{
			if(m_TextBox!=null)
			{
				m_TextBox.Dispose();
				m_TextBox=null;
			}
			m_TextBox=new HVTTMarkTextBox(true);
			m_TextBox.BorderStyle=System.Windows.Forms.BorderStyle.None;
			m_TextBox.AutoSize=false;
			m_TextBox.Visible=false;
            m_TextBox.TabStop = false;
			m_TextBox.MouseEnter+=new EventHandler(this.TextBoxMouseEnter);
			m_TextBox.MouseLeave+=new EventHandler(this.TextBoxMouseLeave);
			m_TextBox.MouseHover+=new EventHandler(this.TextBoxMouseHover);
			m_TextBox.LostFocus+=new EventHandler(this.TextBoxLostFocus);
			m_TextBox.GotFocus+=new EventHandler(this.TextBoxGotFocus);
			m_TextBox.TextChanged+=new EventHandler(this.TextBoxTextChanged);
			m_TextBox.KeyDown+=new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
			m_TextBox.KeyPress+=new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPress);
			m_TextBox.KeyUp+=new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyUp);
			m_TextBox.Text=m_ControlText;
			m_TextBox.SelectionStart=0;

			if(this.ContainerControl!=null)
			{
				System.Windows.Forms.Control objCtrl=this.ContainerControl as System.Windows.Forms.Control;
				if(objCtrl!=null)
					objCtrl.Controls.Add(m_TextBox);
			}

			if(this.Displayed)
			{
				m_TextBox.Visible=true;
				this.Refresh();
			}

			CustomizeChanged();

		}
		public override BaseItem Copy()
		{
			TextBoxItem objCopy=new TextBoxItem(this.Name);
			this.CopyToItem(objCopy);
			return objCopy;
		}
		protected override void CopyToItem(BaseItem copy)
		{
			TextBoxItem objCopy=copy as TextBoxItem;
			base.CopyToItem(objCopy);

			objCopy.ControlText=m_ControlText;
			objCopy.TextBoxWidth=m_TextBoxWidth;
		}
		public override void Dispose()
		{
			if(m_TextBox!=null)
			{
				if(m_TextBox.Parent!=null)
					m_TextBox.Parent.Controls.Remove(m_TextBox);
				m_TextBox.Dispose();
				m_TextBox=null;
			}
			base.Dispose();
		}

		protected internal override void Serialize(ItemSerializationContext context)
		{
			base.Serialize(context);
            System.Xml.XmlElement ThisItem = context.ItemXmlElement;
			ThisItem.SetAttribute("CText",m_ControlText);
			ThisItem.SetAttribute("TextBoxWidth",System.Xml.XmlConvert.ToString(m_TextBoxWidth));
			ThisItem.SetAttribute("AlwaysShowCaption",System.Xml.XmlConvert.ToString(m_AlwaysShowCaption));

			ThisItem.SetAttribute("MenuVisibility",System.Xml.XmlConvert.ToString((int)m_MenuVisibility));
			ThisItem.SetAttribute("RecentlyUsed",System.Xml.XmlConvert.ToString(m_RecentlyUsed));
		}

		protected internal override void Deserialize(ItemSerializationContext context)
		{
			base.Deserialize(context);
            System.Xml.XmlElement ItemXmlSource = context.ItemXmlElement;
			this.ControlText=ItemXmlSource.GetAttribute("CText");
			m_TextBoxWidth=System.Xml.XmlConvert.ToInt32(ItemXmlSource.GetAttribute("TextBoxWidth"));
			m_AlwaysShowCaption=System.Xml.XmlConvert.ToBoolean(ItemXmlSource.GetAttribute("AlwaysShowCaption"));

			m_MenuVisibility=(HVTTMenuVisibility)System.Xml.XmlConvert.ToInt32(ItemXmlSource.GetAttribute("MenuVisibility"));
			m_RecentlyUsed=System.Xml.XmlConvert.ToBoolean(ItemXmlSource.GetAttribute("RecentlyUsed"));
		}
		public override void Paint(ItemPaintArgs pa)
		{
			if(this.SuspendLayout)
				return;
			System.Drawing.Graphics g=pa.Graphics;
			Rectangle r=this.DisplayRectangle;
            bool enabled = GetEnabled();
			Size objImageSize=GetMaxImageSize();
			bool bOnMenu=this.IsOnMenu && !(this.Parent is ItemContainer);

			if(this.Orientation==HVTTOrientation.Horizontal)
			{
                if (bOnMenu && (this.Style == HVTTControlStyle.OfficeXP || this.Style == HVTTControlStyle.Office2003 || this.Style == HVTTControlStyle.VS2005 || BarFunctions.IsOffice2007Style(this.Style)))
				{
					objImageSize.Width+=7;
					r.Width-=objImageSize.Width;
					r.X+=objImageSize.Width;
					if(this.IsOnCustomizeMenu)
						objImageSize.Width+=objImageSize.Height+8;
					// Draw side bar
					if(this.MenuVisibility==HVTTMenuVisibility.VisibleIfRecentlyUsed && !this.RecentlyUsed)
					{
						if(!pa.Colors.MenuUnusedSide2.IsEmpty)
						{
							System.Drawing.Drawing2D.LinearGradientBrush gradient=BarFunctions.CreateLinearGradientBrush(new Rectangle(m_Rect.Left,m_Rect.Top,objImageSize.Width,m_Rect.Height),pa.Colors.MenuUnusedSide,pa.Colors.MenuUnusedSide2,pa.Colors.MenuUnusedSideGradientAngle);
							g.FillRectangle(gradient,m_Rect.Left,m_Rect.Top,objImageSize.Width,m_Rect.Height);
							gradient.Dispose();
						}
						else
							g.FillRectangle(new SolidBrush(pa.Colors.MenuUnusedSide),m_Rect.Left,m_Rect.Top,objImageSize.Width,m_Rect.Height);
					}
					else
					{
						if(!pa.Colors.MenuSide2.IsEmpty)
						{
							System.Drawing.Drawing2D.LinearGradientBrush gradient=BarFunctions.CreateLinearGradientBrush(new Rectangle(m_Rect.Left,m_Rect.Top,objImageSize.Width,m_Rect.Height),pa.Colors.MenuSide,pa.Colors.MenuSide2,pa.Colors.MenuSideGradientAngle);
							g.FillRectangle(gradient,m_Rect.Left,m_Rect.Top,objImageSize.Width,m_Rect.Height);
							gradient.Dispose();
						}
						else
							g.FillRectangle(new SolidBrush(pa.Colors.MenuSide),m_Rect.Left,m_Rect.Top,objImageSize.Width,m_Rect.Height);
					}
				}

				if(this.IsOnCustomizeMenu)
				{
                    if (this.Style == HVTTControlStyle.OfficeXP || this.Style == HVTTControlStyle.Office2003 || this.Style == HVTTControlStyle.VS2005 || BarFunctions.IsOffice2007Style(this.Style))
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

                if (bOnMenu && (this.Style == HVTTControlStyle.OfficeXP || this.Style == HVTTControlStyle.Office2003 || this.Style == HVTTControlStyle.VS2005 || BarFunctions.IsOffice2007Style(this.Style)))
				{
                    if (enabled)
                    {
                        if (m_MouseOver || this.Focused)
                        {
                            Rectangle rHover = this.DisplayRectangle;
                            rHover.Inflate(-1, 0);
                            if (!pa.Colors.ItemHotBackground2.IsEmpty)
                            {
                                System.Drawing.Drawing2D.LinearGradientBrush gradient = BarFunctions.CreateLinearGradientBrush(rHover, pa.Colors.ItemHotBackground, pa.Colors.ItemHotBackground2, pa.Colors.ItemHotBackgroundGradientAngle);
                                g.FillRectangle(gradient, rHover);
                                gradient.Dispose();
                            }
                            else
                                g.FillRectangle(new SolidBrush(pa.Colors.ItemHotBackground), rHover);
                            NativeFunctions.DrawRectangle(g, new Pen(pa.Colors.ItemHotBorder), rHover);
                        }
                    }
				}

				// Draw text if needed
				if(m_Text!="" && (m_AlwaysShowCaption || bOnMenu))
				{
					eTextFormat objStringFormat=GetStringFormat();
					Font objFont=this.GetFont();
					Rectangle rText=new Rectangle(r.X+8,r.Y,r.Width,r.Height);
                    Color textColor = pa.Colors.ItemText;
                    if (this.ContainerControl is ItemControl && this.Style == HVTTControlStyle.Office2007 && GlobalManager.Renderer is Office2007Renderer)
                    {
                        textColor = ((Office2007Renderer)GlobalManager.Renderer).ColorTable.ButtonItemColors[0].Default.Text;
                    }
                    //if(m_MouseOver)
                    //    textColor = pa.Colors.ItemHotText;
					
					if(this.Style==HVTTControlStyle.Office2000)
					{
                        TextDrawing.DrawString(g, m_Text, objFont, textColor, rText, objStringFormat);
					}
					else
					{
                        TextDrawing.DrawString(g, m_Text, objFont, textColor, rText, objStringFormat);
					}
					Size textSize=TextDrawing.MeasureString(g,m_Text,objFont,0,objStringFormat);
					r.X+=(int)textSize.Width+8;
					r.Width-=((int)textSize.Width+8);
				}

                if (this.DesignMode && !bOnMenu)
                {
                    Rectangle back = r;
                    back.Inflate(-2, -2);
                    g.FillRectangle(SystemBrushes.Window, back);
                    if (m_ControlText != "")
                    {
                        back.Inflate(-1, -1);
                        TextDrawing.DrawString(g, m_ControlText, this.GetFont(), SystemColors.ControlText, back, this.GetStringFormat());
                    }
                }

				if(m_TextBox!=null)
				{
					r.Inflate(-5,-3);
					m_TextBox.Size=r.Size;
					Point loc=r.Location;
					loc.Offset((r.Width-m_TextBox.Width)/2,(r.Height-m_TextBox.Height)/2);
					m_TextBox.Location=loc;
					
					if(enabled && (m_MouseOver || this.Focused))
					{
						if(this.Style==HVTTControlStyle.Office2000)
						{
							r=new Rectangle(m_TextBox.Location,m_TextBox.Size);
							r.Inflate(2,2);
							System.Windows.Forms.ControlPaint.DrawBorder3D(g,r,System.Windows.Forms.Border3DStyle.SunkenOuter,System.Windows.Forms.Border3DSide.All);
						}
                        else if (this.Style == HVTTControlStyle.OfficeXP || this.Style == HVTTControlStyle.Office2003 || this.Style == HVTTControlStyle.VS2005 || BarFunctions.IsOffice2007Style(this.Style))
						{
							r=new Rectangle(m_TextBox.Location,m_TextBox.Size);
							r.Inflate(1,1);
							NativeFunctions.DrawRectangle(g,SystemPens.Highlight,r);
							//g.DrawRectangle(SystemPens.Highlight,r);
						}
					}
				}
				else
				{
					r.Inflate(-3,-3);
					g.FillRectangle(SystemBrushes.Window,r);
				}

				if(this.IsOnCustomizeMenu && this.Visible)
				{
					// Draw check box if this item is visible
					Rectangle rBox=new Rectangle(m_Rect.Left,m_Rect.Top,m_Rect.Height,m_Rect.Height);
                    if (this.Style == HVTTControlStyle.OfficeXP || this.Style == HVTTControlStyle.Office2003 || this.Style == HVTTControlStyle.VS2005 || BarFunctions.IsOffice2007Style(this.Style))
						rBox.Inflate(-1,-1);
					BarFunctions.DrawMenuCheckBox(pa,rBox,this.Style,m_MouseOver);
				}
			}
			else
			{
				string Caption=this.Text;
				if(Caption=="")
					Caption="...";
				else
					Caption+=" »";

                if (this.Style == HVTTControlStyle.OfficeXP || this.Style == HVTTControlStyle.Office2003 || this.Style == HVTTControlStyle.VS2005 || BarFunctions.IsOffice2007Style(this.Style))
					g.FillRectangle(new SolidBrush(pa.Colors.BarBackground),this.DisplayRectangle);
				else
					g.FillRectangle(SystemBrushes.Control,this.DisplayRectangle);

				if(m_MouseOver && !this.DesignMode)
				{
					if(this.Style==HVTTControlStyle.Office2000)
					{
						//r.Inflate(-1,-1);
						System.Windows.Forms.ControlPaint.DrawBorder3D(g,r,System.Windows.Forms.Border3DStyle.RaisedInner,System.Windows.Forms.Border3DSide.All);
					}
                    else if (this.Style == HVTTControlStyle.OfficeXP || this.Style == HVTTControlStyle.Office2003 || this.Style == HVTTControlStyle.VS2005 || BarFunctions.IsOffice2007Style(this.Style))
					{
						r.Inflate(-1,-1);
						if(!pa.Colors.ItemHotBackground2.IsEmpty)
						{
							System.Drawing.Drawing2D.LinearGradientBrush gradient=BarFunctions.CreateLinearGradientBrush(r,pa.Colors.ItemHotBackground,pa.Colors.ItemHotBackground2,pa.Colors.ItemHotBackgroundGradientAngle);
							g.FillRectangle(gradient,r);
							gradient.Dispose();
						}
						else
							g.FillRectangle(new SolidBrush(pa.Colors.ItemHotBackground),r);
						NativeFunctions.DrawRectangle(g,new Pen(pa.Colors.ItemHotBorder),r);
					}
				}

				r=new Rectangle(m_Rect.Top,-m_Rect.Right,m_Rect.Height,m_Rect.Width);
				g.RotateTransform(90);
				eTextFormat sf=GetStringFormat();
				sf|=eTextFormat.HorizontalCenter;
				if(m_MouseOver)
					TextDrawing.DrawStringLegacy(g,Caption,GetFont(),pa.Colors.ItemHotText,r,sf);
				else
                    TextDrawing.DrawStringLegacy(g, Caption, GetFont(), pa.Colors.ItemText, r, sf);
				g.ResetTransform();
			}

			if(this.Focused && this.DesignMode)
			{
				r=this.DisplayRectangle;
				r.Inflate(-1,-1);
				DesignTime.DrawDesignTimeSelection(g,r,pa.Colors.ItemDesignTimeBorder);
			}

			this.DrawInsertMarker(g);
		}

		public override void RecalcSize()
		{
			if(this.SuspendLayout)
				return;

			bool bOnMenu=this.IsOnMenu;

			if(this.Orientation==HVTTOrientation.Horizontal)
			{
				// Default Height
				if(this.Parent!=null && this.Parent is ImageItem)
					m_Rect.Height=((ImageItem)this.Parent).SubItemsImageSize.Height+4;
				else
					m_Rect.Height=this.SubItemsImageSize.Height+4;
                    
				// Default width
				m_Rect.Width=m_TextBoxWidth+4;

				// Calculate Item Height
				if(m_Text!="" && (m_AlwaysShowCaption || bOnMenu))
				{
					System.Windows.Forms.Control objCtrl=this.ContainerControl as System.Windows.Forms.Control;
					if(objCtrl!=null && IsHandleValid(objCtrl))
					{
						Graphics g=BarFunctions.CreateGraphics(objCtrl);
                        try
                        {
                            Size textSize = TextDrawing.MeasureString(g, m_Text, GetFont(), 0, GetStringFormat());
                            if (textSize.Height > this.SubItemsImageSize.Height)
                                m_Rect.Height = (int)textSize.Height + 4;
                            m_Rect.Width = m_TextBoxWidth + 4 + (int)textSize.Width + 8;
                        }
                        finally
                        {
                            g.Dispose();
                        }
					}
				}

				Size objImageSize=GetMaxImageSize();

				if(m_TextBox!=null)
				{
					if(m_Rect.Height<m_TextBox.Height)
					{
						m_TextBox.Height=objImageSize.Height+2;
						if(m_Rect.Height<m_TextBox.Height)
							m_Rect.Height=m_TextBox.Height+4;
					}
				}

                if (this.IsOnMenu && (this.Style == HVTTControlStyle.OfficeXP || this.Style == HVTTControlStyle.Office2003 || this.Style == HVTTControlStyle.VS2005 || BarFunctions.IsOffice2007Style(this.Style)))
				{
					// Get the right image size that we will use for calculation
					m_Rect.Width+=(objImageSize.Width+7);
				}

				if(this.IsOnCustomizeMenu)
					m_Rect.Width+=(objImageSize.Height+2);
			}
			else
			{
				// Default width
				m_Rect.Width=this.SubItemsImageSize.Width+4;
				string Caption=this.Text;
				if(Caption=="")
					Caption="...";
				else
					Caption+=" »";
				System.Windows.Forms.Control objCtrl=this.ContainerControl as System.Windows.Forms.Control;
				if(objCtrl!=null && IsHandleValid(objCtrl))
				{
					Graphics g=BarFunctions.CreateGraphics(objCtrl);
                    try
                    {
                        Size textSize = TextDrawing.MeasureString(g, Caption, GetFont(), 0, GetStringFormat());
                        if (textSize.Height > this.SubItemsImageSize.Height)
                            m_Rect.Width = (int)textSize.Height + 4;
                        m_Rect.Height = (int)textSize.Width + 8;
                    }
                    finally
                    {
                        g.Dispose();
                    }
				}

			}

			// Always call base implementation to reset resize flag
			base.RecalcSize();
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
		protected internal override void OnContainerChanged(object objOldContainer)
		{	
			base.OnContainerChanged(objOldContainer);
			if(m_TextBox!=null)
			{
				if(m_TextBox.Parent!=null)
					m_TextBox.Parent.Controls.Remove(m_TextBox);

				System.Windows.Forms.Control objCtrl=null;
				if(this.ContainerControl!=null)
				{
					objCtrl=this.ContainerControl as System.Windows.Forms.Control;
					if(objCtrl!=null)
						objCtrl.Controls.Add(m_TextBox);
				}
			}
		}
		protected internal override void OnAfterItemRemoved(BaseItem item)
		{
			base.OnAfterItemRemoved(item);
			this.ContainerControl=null;
		}

		protected internal override void OnVisibleChanged(bool newValue)
		{
			if(m_TextBox!=null && !newValue)
			{
				m_TextBox.Visible=newValue;
				CustomizeChanged();
			}
			base.OnVisibleChanged(newValue);
		}
		protected override void OnDisplayedChanged()
		{
			if(m_TextBox!=null)
			{
				m_TextBox.Visible=this.Displayed;
				CustomizeChanged();
			}
		}
		
		private void TextBoxMouseEnter(object sender, EventArgs e)
		{
			if(!m_MouseOver)
			{
				m_MouseOver=true;			
				this.Refresh();
			}
		}

		private void TextBoxMouseLeave(object sender, EventArgs e)
		{
			this.HideToolTip();
			if(m_MouseOver)
			{
				m_MouseOver=false;
				this.Refresh();
			}
		}

		private void TextBoxMouseHover(object sender, EventArgs e)
		{
			if(this.DesignMode)
				return;
			if(System.Windows.Forms.Control.MouseButtons==System.Windows.Forms.MouseButtons.None)
				ShowToolTip();
		}

		private void TextBoxLostFocus(object sender, EventArgs e)
		{
			m_ControlText=m_TextBox.Text;
			this.ReleaseFocus();
			//if(!m_MouseOver)
			//	return;
			//m_MouseOver=false;
			this.HideToolTip();
			this.Refresh();
		}

		protected internal override void OnLostFocus()
		{
			if(m_TextBox!=null)
				m_ControlText=m_TextBox.Text;
			base.OnLostFocus();
		}

		protected internal override void OnGotFocus()
		{
			base.OnGotFocus();
			if(m_TextBox==null)
				return;
			if(m_TextBox.Focused || this.IsOnCustomizeMenu || this.IsOnCustomizeDialog || this.DesignMode)
				return;
			m_TextBox.Focus();
		}

		private void TextBoxGotFocus(object sender, EventArgs e)
		{
			this.HideToolTip();
			this.Focus();

            if (GetEnabled() && !this.DesignMode)
			{
				if(m_MenuVisibility==HVTTMenuVisibility.VisibleIfRecentlyUsed && !m_RecentlyUsed && this.IsOnMenu)
				{
					// Propagate to the top
					m_RecentlyUsed=true;
					BaseItem objItem=this.Parent;
					while(objItem!=null)
					{
						IPersonalizedMenuItem ipm=objItem as IPersonalizedMenuItem;
						if(ipm!=null)
							ipm.RecentlyUsed=true;
						objItem=objItem.Parent;
					}
				}
			}
		}

		private void TextBoxKeyDown(object sender,System.Windows.Forms.KeyEventArgs e)
		{
			this.HideToolTip();
			if(KeyDown!=null)
				KeyDown(this,e);
			if(e.KeyCode==System.Windows.Forms.Keys.Enter && this.Parent is PopupItem)
			{
				this.RaiseClick();
				//((PopupItem)this.Parent).ClosePopup();
			}
			if(e.KeyCode==System.Windows.Forms.Keys.Escape)
			{
				m_TextBox.ReleaseFocus();
			}
		}

		private void TextBoxKeyPress(object sender,System.Windows.Forms.KeyPressEventArgs e)
		{
			if(KeyPress!=null)
				KeyPress(this,e);
		}

		private void TextBoxKeyUp(object sender,System.Windows.Forms.KeyEventArgs e)
		{
			if(KeyUp!=null)
				KeyUp(this,e);
		}

		private void TextBoxTextChanged(object sender, EventArgs e)
		{
            m_ControlText = m_TextBox.Text;

			if(InputTextChanged!=null)
			{
				InputTextChanged(this);
			}

            HVTTManager owner = this.GetOwner() as HVTTManager;
            if (owner != null)
                owner.InvokeTextBoxItemTextChanged(this);
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

		private void CustomizeChanged()
		{
			if(this.IsOnCustomizeMenu || this.IsOnCustomizeDialog || this.DesignMode)
			{
				if(m_TextBox!=null)
					m_TextBox.Visible=false;
			}
			else
			{
				if(m_TextBox==null)
					CreateTextBox();
				else if(!m_TextBox.Visible)
				{
					m_TextBox.Visible=this.Displayed && this.Visible;
				}
			}
		}

		[DefaultValue(false), Browsable(true),HVTTBrowsable(true),System.ComponentModel.Category("Behavior"),System.ComponentModel.Description("Indicates whether item caption is always shown.")]
		public bool AlwaysShowCaption
		{
			get
			{
				return m_AlwaysShowCaption;
			}
			set
			{
				m_AlwaysShowCaption=value;
			}
		}

		[DefaultValue(64), Browsable(true),HVTTBrowsable(true),System.ComponentModel.Category("Layout"),System.ComponentModel.Description("Indicates the Width of the Text Box part of the item.")]
		public int TextBoxWidth
		{
			get
			{
				return m_TextBoxWidth;
			}
			set
			{
				if(m_TextBoxWidth!=value)
				{
					m_TextBoxWidth=value;
                    if(ShouldSyncProperties)
                        BarFunctions.SyncProperty(this, "TextBoxWidth");
					OnExternalSizeChange();
                    this.OnAppearanceChanged();
				}
			}
		}

		public override void InternalMouseEnter()
		{
			base.InternalMouseEnter();
			//if(this.DesignMode || this.IsOnCustomizeMenu || this.IsOnCustomizeDialog || this.Orientation==HVTTOrientation.Vertical)
			if(!m_MouseOver)
			{
				m_MouseOver=true;
				this.Refresh();
			}
		}

		public override void InternalMouseLeave()
		{
			base.InternalMouseLeave();
			if(m_MouseOver)
			{
				m_MouseOver=false;
				this.Refresh();
			}
		}

		public override void InternalKeyDown(System.Windows.Forms.KeyEventArgs objArg)
		{
			if(objArg.KeyCode==System.Windows.Forms.Keys.Escape)
			{
				if(m_TextBox.Focused)
				{
					m_TextBox.SelectionStart=0;
					m_TextBox.Text=m_ControlText;
				}
			}
			else if(objArg.KeyCode==System.Windows.Forms.Keys.Enter)
			{
				if(!m_TextBox.Focused)
				{
					m_TextBox.Focus();
					objArg.Handled=true;
					return;
				}
			}
			base.InternalKeyDown(objArg);
		}

		protected virtual Font GetFont()
		{
			System.Windows.Forms.Control objCtrl=this.ContainerControl as System.Windows.Forms.Control;
			if(objCtrl!=null)
				return (Font)objCtrl.Font;
			return (Font)System.Windows.Forms.SystemInformation.MenuFont;
		}

		private eTextFormat GetStringFormat()
		{
            eTextFormat format = eTextFormat.Default | eTextFormat.VerticalCenter | eTextFormat.EndEllipsis | eTextFormat.SingleLine;
            return format;
            //StringFormat sfmt=BarFunctions.CreateStringFormat(); //new StringFormat(StringFormat.GenericDefault)
            //sfmt.HotkeyPrefix=System.Drawing.Text.HotkeyPrefix.Show;
            ////sfmt.FormatFlags=sfmt.FormatFlags & ~(sfmt.FormatFlags & StringFormatFlags.DisableKerning);
            //sfmt.FormatFlags=sfmt.FormatFlags | StringFormatFlags.NoWrap;
            //sfmt.Trimming=StringTrimming.EllipsisCharacter;
            //sfmt.Alignment=System.Drawing.StringAlignment.Near;
            //sfmt.LineAlignment=System.Drawing.StringAlignment.Center;

            //return sfmt;
		}

		[DefaultValue(""), Browsable(true),HVTTBrowsable(true),System.ComponentModel.Category("Appearance"),System.ComponentModel.Description("The text contained in the text box that user can edit.")]
		public virtual string ControlText
		{
			get
			{
				return m_ControlText;
			}
			set
			{
                if (value == null) value = "";
				if(m_TextBox!=null)
				{
					m_TextBox.Text=value;
					m_TextBox.SelectionStart=0;
				}
				m_ControlText=value;
			}
		}

		[System.ComponentModel.Browsable(false)]
		public System.Windows.Forms.TextBox TextBox
		{
			get
			{
				return m_TextBox;
			}
		}

		public override void ReleaseFocus()
		{
			if(m_TextBox!=null && m_TextBox.Focused)
				m_TextBox.ReleaseFocus();
			base.ReleaseFocus();
		}

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int SelectionStart
		{
			get
			{
				if(m_TextBox!=null)
					return m_TextBox.SelectionStart;
				return 0;
			}
			set
			{
				if(m_TextBox!=null)
					m_TextBox.SelectionStart=value;
			}
		}

		[System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int SelectionLength
		{
			get
			{
				if(m_TextBox!=null)
					return m_TextBox.SelectionLength;
				return 0;
			}
			set
			{
				if(m_TextBox!=null)
					m_TextBox.SelectionLength=value;
			}
		}

		[System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string SelectedText
		{
			get
			{
				if(m_TextBox!=null)
					return m_TextBox.SelectedText;
				return "";
			}
			set
			{
				if(m_TextBox!=null)
					m_TextBox.SelectedText=value;
			}
		}

        /// <summary>
        /// Gets or sets the maximum number of characters the user can type or paste into the text box control. 
        /// </summary>
        [DefaultValue(32767), Description("Indciates maximum number of characters the user can type or paste into the text box control. ")]
        public int MaxLength
        {
            get { return m_TextBox.MaxLength; }
            set
            {
                if(m_TextBox!=null)
                    m_TextBox.MaxLength = value;
            }

        }

        [DefaultValue(HVTTMenuVisibility.VisibleAlways), Browsable(true), HVTTBrowsable(true), System.ComponentModel.Category("Appearance"), System.ComponentModel.Description("Indicates item's visibility when on pop-up menu.")]
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
		[Browsable(false), DefaultValue(false)]
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

		protected override void OnEnabledChanged()
		{
			base.OnEnabledChanged();
			if(m_TextBox!=null)
				m_TextBox.Enabled=this.Enabled;
		}

		[System.ComponentModel.Browsable(false),System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public override bool IsWindowed
		{
			get {return true;}
		}

        // <summary>
        /// Gets or sets the watermark (tip) text displayed inside of the control when Text is not set and control does not have input focus. This property supports text-markup.
        /// </summary>
        [Browsable(true), DefaultValue(""), Localizable(true), Category("Appearance"), Description("Indicates watermark text displayed inside of the control when Text is not set and control does not have input focus."), Editor(typeof(Design.TextMarkupUIEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string WatermarkText
        {
            get { return m_TextBox.WatermarkText; }
            set
            {
                m_TextBox.WatermarkText = value;
            }
        }

        /// <summary>
        /// Gets or sets the watermark font.
        /// </summary>
        [Browsable(true), Category("Appearance"), Description("Indicates watermark font."), DefaultValue(null)]
        public Font WatermarkFont
        {
            get { return m_TextBox.WatermarkFont; }
            set { m_TextBox.WatermarkFont = value; }
        }

        /// <summary>
        /// Gets or sets the watermark text color.
        /// </summary>
        [Browsable(true), Category("Appearance"), Description("Indicates watermark text color.")]
        public Color WatermarkColor
        {
            get { return m_TextBox.WatermarkColor; }
            set { m_TextBox.WatermarkColor = value; }
        }
        /// <summary>
        /// Indicates whether property should be serialized by Windows Forms designer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeWatermarkColor()
        {
            return m_TextBox.WatermarkColor != SystemColors.GrayText;
        }
        /// <summary>
        /// Resets the property to default value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResetWatermarkColor()
        {
            this.WatermarkColor = SystemColors.GrayText;
        }

        /// <summary>
        /// Gets or sets whether FocusHighlightColor is used as background color to highlight text box when it has input focus. Default value is false.
        /// </summary>
        [DefaultValue(false), Browsable(true), Category("Appearance"), Description("Indicates whether FocusHighlightColor is used as background color to highlight text box when it has input focus.")]
        public bool FocusHighlightEnabled
        {
            get { return m_TextBox.FocusHighlightEnabled; }
            set
            {
                m_TextBox.FocusHighlightEnabled = value;
            }
        }

        /// <summary>
        /// Gets or sets the color used as background color to highlight text box when it has input focus and focus highlight is enabled.
        /// </summary>
        [Browsable(true), Category("Appearance"), Description("Indicates color used as background color to highlight text box when it has input focus and focus highlight is enabled.")]
        public Color FocusHighlightColor
        {
            get { return m_TextBox.FocusHighlightColor; }
            set
            {
                m_TextBox.FocusHighlightColor = value;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFocusHighlightColor()
        {
            return m_TextBox.ShouldSerializeFocusHighlightColor();
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public void ResetFocusHighlightColor()
        {
            m_TextBox.ResetFocusHighlightColor();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), RefreshProperties(RefreshProperties.All), ParenthesizePropertyName(true)]
        public ControlBindingsCollection DataBindings
        {
            get { return m_TextBox.DataBindings; }
        }
	}
}
