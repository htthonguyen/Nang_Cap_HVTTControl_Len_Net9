using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using HVTT.UI.Window.Forms.Rendering;
using System;

namespace HVTT.UI.Window.Forms
{
	/// <summary>
	/// Represents predefined color schemes for ribbon controls.
	/// </summary>
	public class RibbonPredefinedColorSchemes
	{
		/// <summary>
		/// Applies default gray color scheme to background and title.
		/// </summary>
		/// <param name="b">Reference to object.</param>
		public static void ApplyGrayColorScheme(RibbonBar b)
		{
            b.BackgroundStyle.Reset();
			b.BackgroundMouseOverStyle.Reset();
            b.TitleStyle.Reset();
            b.TitleStyleMouseOver.Reset();

            TypeDescriptor.GetProperties(b.BackgroundStyle)["BackColor"].SetValue(b.BackgroundStyle, ColorScheme.GetColor("CFD5E2"));
            TypeDescriptor.GetProperties(b.BackgroundStyle)["BackColor2"].SetValue(b.BackgroundStyle, ColorScheme.GetColor("C2C9D9"));
            TypeDescriptor.GetProperties(b.BackgroundStyle)["BackColorGradientAngle"].SetValue(b.BackgroundStyle, 90);

            TypeDescriptor.GetProperties(b.BackgroundMouseOverStyle)["BackColor"].SetValue(b.BackgroundMouseOverStyle, ColorScheme.GetColor("EFEFEF"));
            TypeDescriptor.GetProperties(b.BackgroundMouseOverStyle)["BackColor2"].SetValue(b.BackgroundMouseOverStyle, ColorScheme.GetColor("D2DAED"));
            TypeDescriptor.GetProperties(b.BackgroundMouseOverStyle)["BackColorGradientAngle"].SetValue(b.BackgroundMouseOverStyle, 90);

			TypeDescriptor.GetProperties(b.TitleStyle)["BackColor"].SetValue(b.TitleStyle,ColorScheme.GetColor("6A7080"));
			TypeDescriptor.GetProperties(b.TitleStyle)["BackColor2"].SetValue(b.TitleStyle,ColorScheme.GetColor("A8B2CC"));
			TypeDescriptor.GetProperties(b.TitleStyle)["BackColorGradientAngle"].SetValue(b.TitleStyle,90);
			TypeDescriptor.GetProperties(b.TitleStyle)["TextColor"].SetValue(b.TitleStyle,Color.White);
            
			TypeDescriptor.GetProperties(b.TitleStyle)["PaddingTop"].SetValue(b.TitleStyle,3);
			TypeDescriptor.GetProperties(b.TitleStyle)["PaddingBottom"].SetValue(b.TitleStyle,2);
			TypeDescriptor.GetProperties(b.TitleStyle)["PaddingLeft"].SetValue(b.TitleStyle,2);
			TypeDescriptor.GetProperties(b.TitleStyle)["PaddingRight"].SetValue(b.TitleStyle,2);
			TypeDescriptor.GetProperties(b.TitleStyle)["TextShadowColor"].SetValue(b.TitleStyle,Color.Black);
			TypeDescriptor.GetProperties(b.TitleStyle)["TextShadowOffset"].SetValue(b.TitleStyle,new Point(1,1));
            TypeDescriptor.GetProperties(b.TitleStyle)["Border"].SetValue(b.TitleStyle, StyleBorderType.None);

            TypeDescriptor.GetProperties(b.TitleStyleMouseOver)["BackColor"].SetValue(b.TitleStyleMouseOver, ColorScheme.GetColor("53607D"));
            TypeDescriptor.GetProperties(b.TitleStyleMouseOver)["BackColor2"].SetValue(b.TitleStyleMouseOver, ColorScheme.GetColor("8BA1CA"));

            b.Invalidate();
		}

		/// <summary>
		/// Applies orange color scheme to background and title.
		/// </summary>
		/// <param name="b">Reference to object</param>
		public static void ApplyOrangeColorScheme(RibbonBar b)
		{
            b.BackgroundStyle.Reset();
			b.BackgroundMouseOverStyle.Reset();
            b.TitleStyle.Reset();
            b.TitleStyleMouseOver.Reset();

			TypeDescriptor.GetProperties(b.BackgroundStyle)["BackColor"].SetValue(b.BackgroundStyle,ColorScheme.GetColor("CFD5E2"));
			TypeDescriptor.GetProperties(b.BackgroundStyle)["BackColor2"].SetValue(b.BackgroundStyle,ColorScheme.GetColor("C2C9D9"));
			TypeDescriptor.GetProperties(b.BackgroundStyle)["BackColorGradientAngle"].SetValue(b.BackgroundStyle,90);

			TypeDescriptor.GetProperties(b.TitleStyle)["BackColor"].SetValue(b.TitleStyle,ColorScheme.GetColor("CBA950"));
			TypeDescriptor.GetProperties(b.TitleStyle)["BackColor2"].SetValue(b.TitleStyle,ColorScheme.GetColor("FED665"));
			TypeDescriptor.GetProperties(b.TitleStyle)["BackColorGradientAngle"].SetValue(b.TitleStyle,90);
			TypeDescriptor.GetProperties(b.TitleStyle)["TextColor"].SetValue(b.TitleStyle,Color.White);
			TypeDescriptor.GetProperties(b.TitleStyle)["PaddingTop"].SetValue(b.TitleStyle,3);
			TypeDescriptor.GetProperties(b.TitleStyle)["PaddingBottom"].SetValue(b.TitleStyle,2);
			TypeDescriptor.GetProperties(b.TitleStyle)["PaddingLeft"].SetValue(b.TitleStyle,2);
			TypeDescriptor.GetProperties(b.TitleStyle)["PaddingRight"].SetValue(b.TitleStyle,2);
			TypeDescriptor.GetProperties(b.TitleStyle)["TextShadowColor"].SetValue(b.TitleStyle,Color.Black);
			TypeDescriptor.GetProperties(b.TitleStyle)["TextShadowOffset"].SetValue(b.TitleStyle,new Point(1,1));
            TypeDescriptor.GetProperties(b.TitleStyle)["Border"].SetValue(b.TitleStyle, StyleBorderType.None);

            b.Invalidate();
		}

		/// <summary>
		/// Apply Office 2003 color scheme to background and title.
		/// </summary>
		/// <param name="b">Reference to object</param>
		public static void ApplyOffice2003ColorScheme(RibbonBar b)
		{
            

            b.Invalidate();
		}

        internal static void ApplyRibbonBarOffice2003ElementStyle(ElementStyle backStyle, ElementStyle backMouseOverStyle, ElementStyle titleStyle, ElementStyle titleMouseOverStyle)
        {
            backStyle.Reset();
            backMouseOverStyle.Reset();
            titleStyle.Reset();
            titleMouseOverStyle.Reset();

            backStyle.BackColorSchemePart = eColorSchemePart.BarBackground2;
            backStyle.BackColor2SchemePart = eColorSchemePart.BarBackground;
            backStyle.BackColorGradientAngle = 90;

            titleStyle.BackColorSchemePart=eColorSchemePart.PanelBackground;
            titleStyle.BackColor2SchemePart=eColorSchemePart.PanelBackground2;
            titleStyle.BackColorGradientAngle=90;
            titleStyle.TextColorSchemePart=eColorSchemePart.PanelText;
            titleStyle.PaddingTop=1;
            titleStyle.PaddingBottom=1;
            titleStyle.PaddingLeft=2;
            titleStyle.PaddingRight=2;
            titleStyle.TextShadowColor=Color.Black;
            titleStyle.TextShadowOffset=new Point(1, 1);

            titleStyle.BorderColorSchemePart = eColorSchemePart.PanelBorder;
            titleStyle.Border = StyleBorderType.Solid;
            titleStyle.BorderWidth = 1;
        }

		/// <summary>
		/// Applies Office 2003 color scheme to ribbon control background.
		/// </summary>
		/// <param name="b">Reference to object.</param>
		public static void ApplyOffice2003ColorScheme(RibbonControl b)
		{
            ApplyRibbonOffice2003ElementStyle(b.BackgroundStyle);
            b.Invalidate(true);
		}

		/// <summary>
		/// Applies Gray color scheme to ribbon control background.
		/// </summary>
		/// <param name="b">Reference to object.</param>
		public static void ApplyGrayColorScheme(RibbonControl b)
		{
            b.BackgroundStyle.Reset();
            TypeDescriptor.GetProperties(b.BackgroundStyle)["BackColor"].SetValue(b.BackgroundStyle, ColorScheme.GetColor("F4F4F4"));
            TypeDescriptor.GetProperties(b.BackgroundStyle)["BackColor2"].SetValue(b.BackgroundStyle, ColorScheme.GetColor("CFCFCF"));
			TypeDescriptor.GetProperties(b.BackgroundStyle)["BackColorGradientAngle"].SetValue(b.BackgroundStyle,0);
            TypeDescriptor.GetProperties(b.BackgroundStyle)["BackColorGradientType"].SetValue(b.BackgroundStyle,eGradientType.Radial);

            b.Invalidate(true);
		}

        /// <summary>
        /// Applies Office 2007 color table to ribbon control background.
        /// </summary>
        /// <param name="b">Reference to object.</param>
        public static void ApplyOffice2007ColorScheme(RibbonControl b)
        {
            //Rendering.Office2007ColorTable ct = GetOffice2007ColorTable(b);
            //ApplyRibbonOffice2007ElementStyle(b.BackgroundStyle, ct);
            b.Invalidate(true);
        }

        internal static void ApplyRibbonElementStyle(ElementStyle style, RibbonControl rc)
        {
            if (rc!=null && rc.Style == HVTTControlStyle.Office2007)
            {
                ApplyRibbonOffice2007ElementStyle(style, GetOffice2007ColorTable(rc));
            }
            else
            {
                ApplyRibbonOffice2003ElementStyle(style);
            }
        }

        internal static void ApplyRibbonOffice2007ElementStyle(ElementStyle backStyle, Rendering.Office2007ColorTable ct)
        {
            backStyle.Reset();

            backStyle.BackColor = ct.RibbonControl.TabsBackground.Start;
            backStyle.BackColor2 = ct.RibbonControl.TabsBackground.End;
            backStyle.BackColorGradientAngle = ct.RibbonControl.TabsBackground.GradientAngle;
            backStyle.BackColorGradientType = eGradientType.Linear;           
        }

        internal static void ApplyRibbonOffice2003ElementStyle(ElementStyle backStyle)
        {
            backStyle.Reset();

            backStyle.BackColorSchemePart = eColorSchemePart.BarBackground2;
            backStyle.BackColor2SchemePart = eColorSchemePart.BarBackground;
            backStyle.BackColorGradientAngle = 90;
        }

        /// <summary>
        /// Applies Office 2007 Luna blue color scheme to the Ribbon Bar.
        /// </summary>
        /// <param name="b">Reference to object.</param>
        public static void ApplyOffice2007ColorScheme(RibbonBar b)
        {
            //Rendering.Office2007ColorTable c = GetOffice2007ColorTable(b);
            //ApplyRibbonBarOffice2007ElementStyle(b.BackgroundStyle, b.BackgroundMouseOverStyle, b.TitleStyle, b.TitleStyleMouseOver, c);
            b.Invalidate();
        }

        internal static Rendering.Office2007ColorTable GetOffice2007ColorTable(RibbonBar b)
        {
            Rendering.Office2007ColorTable c = null;
            if ((b.RenderMode == eRenderMode.Custom || b.RenderMode == eRenderMode.Instance) && b.Renderer != null)
            {
                Rendering.Office2007Renderer rn = b.Renderer as Rendering.Office2007Renderer;
                if (rn != null)
                    c = rn.ColorTable;
            }
            else
            {
                Rendering.Office2007Renderer rn = GlobalManager.Renderer as Rendering.Office2007Renderer;
                if (rn != null)
                    c = rn.ColorTable;
            }

            if (c == null) c = new Office2007ColorTable();

            return c;
        }

        internal static Rendering.Office2007ColorTable GetOffice2007ColorTable(RibbonControl b)
        {
            Rendering.Office2007ColorTable c = null;
            if ((b.RibbonStrip.RenderMode == eRenderMode.Custom || b.RibbonStrip.RenderMode == eRenderMode.Instance) && b.RibbonStrip.Renderer != null)
            {
                Rendering.Office2007Renderer rn = b.RibbonStrip.Renderer as Rendering.Office2007Renderer;
                if (rn != null)
                    c = rn.ColorTable;
            }
            else
            {
                Rendering.Office2007Renderer rn = GlobalManager.Renderer as Rendering.Office2007Renderer;
                if (rn != null)
                    c = rn.ColorTable;
            }

            if (c == null) c = new Office2007ColorTable();

            return c;
        }

        internal static void ApplyRibbonBarElementStyle(ElementStyle backStyle, ElementStyle backMouseOverStyle, ElementStyle titleStyle, ElementStyle titleMouseOverStyle, RibbonBar b)
        {
            if (b.Style == HVTTControlStyle.Office2007)
            {
                Rendering.Office2007ColorTable c = GetOffice2007ColorTable(b);
                ApplyRibbonBarOffice2007ElementStyle(backStyle, backMouseOverStyle, titleStyle, titleMouseOverStyle, c);
            }
            else
            {
                ApplyRibbonBarOffice2003ElementStyle(backStyle, backMouseOverStyle, titleStyle, titleMouseOverStyle);
            }
        }

        internal static void ApplyRibbonBarOffice2007ElementStyle(ElementStyle backStyle, ElementStyle backMouseOverStyle, ElementStyle titleStyle, ElementStyle titleMouseOverStyle, Rendering.Office2007ColorTable c)
        {
            backStyle.Reset();
            backMouseOverStyle.Reset();
            titleStyle.Reset();
            titleMouseOverStyle.Reset();

            backStyle.Border = StyleBorderType.Etched;
            backStyle.BorderWidth = 1;
            backStyle.CornerType = CornerType.Rounded;
            backStyle.CornerDiameter = 3;
            backStyle.BorderColor = c.RibbonBar.Default.OuterBorder.Start;
            backStyle.BorderColor2 = c.RibbonBar.Default.OuterBorder.End;
            backStyle.BorderColorLight = c.RibbonBar.Default.InnerBorder.Start;
            backStyle.BorderColorLight2 = c.RibbonBar.Default.InnerBorder.End;
            backStyle.BackColorGradientAngle = 90;
            backStyle.BackColorBlend.Add(new BackgroundColorBlend(c.RibbonBar.Default.TopBackground.Start, 0));
            backStyle.BackColorBlend.Add(new BackgroundColorBlend(c.RibbonBar.Default.TopBackground.End, c.RibbonBar.Default.TopBackgroundHeight));
            backStyle.BackColorBlend.Add(new BackgroundColorBlend(c.RibbonBar.Default.BottomBackground.Start, c.RibbonBar.Default.TopBackgroundHeight));
            backStyle.BackColorBlend.Add(new BackgroundColorBlend(c.RibbonBar.Default.BottomBackground.End, 1));

            backMouseOverStyle.BorderColor = c.RibbonBar.MouseOver.OuterBorder.Start;
            backMouseOverStyle.BorderColor2 = c.RibbonBar.MouseOver.OuterBorder.End;
            backMouseOverStyle.BorderColorLight = c.RibbonBar.MouseOver.InnerBorder.Start;
            backMouseOverStyle.BorderColorLight2 = c.RibbonBar.MouseOver.InnerBorder.End;
            backMouseOverStyle.BackColorGradientAngle = 90;
            backMouseOverStyle.BackColorBlend.Add(new BackgroundColorBlend(c.RibbonBar.MouseOver.TopBackground.Start, 0));
            backMouseOverStyle.BackColorBlend.Add(new BackgroundColorBlend(c.RibbonBar.MouseOver.TopBackground.End, c.RibbonBar.MouseOver.TopBackgroundHeight));
            backMouseOverStyle.BackColorBlend.Add(new BackgroundColorBlend(c.RibbonBar.MouseOver.BottomBackground.Start, c.RibbonBar.MouseOver.TopBackgroundHeight));
            backMouseOverStyle.BackColorBlend.Add(new BackgroundColorBlend(c.RibbonBar.MouseOver.BottomBackground.End, 1));

            titleStyle.BackColor = c.RibbonBar.Default.TitleBackground.Start;
            titleStyle.BackColor2 = c.RibbonBar.Default.TitleBackground.End;
            titleStyle.BackColorGradientAngle = 90;
            titleStyle.TextAlignment = StyleTextAlignment.Center;
            titleStyle.TextColor = c.RibbonBar.Default.TitleText;
            titleStyle.TextShadowOffset = Point.Empty;
            titleStyle.PaddingTop = 1;
            titleStyle.PaddingBottom = 1;

            titleMouseOverStyle.BackColor = c.RibbonBar.MouseOver.TitleBackground.Start;
            titleMouseOverStyle.BackColor2 = c.RibbonBar.MouseOver.TitleBackground.End;
            titleMouseOverStyle.BackColorGradientAngle = 90;
            titleMouseOverStyle.TextAlignment = StyleTextAlignment.Center;
            titleMouseOverStyle.TextColor = c.RibbonBar.MouseOver.TitleText;
        }

        internal static ElementStyle StyleFromRibbonBarStateColorTable(Office2007RibbonBarStateColorTable table)
        {
            ElementStyle style = new ElementStyle();
            style.Border = StyleBorderType.Etched;
            style.BorderWidth = 1;
            style.CornerType = CornerType.Rounded;
            style.CornerDiameter = 3;
            style.BorderColor = table.OuterBorder.Start;
            style.BorderColor2 = table.OuterBorder.End;
            style.BorderColorLight = table.InnerBorder.Start;
            style.BorderColorLight2 = table.InnerBorder.End;
            style.BackColorGradientAngle = 90;
            style.BackColorBlend.Add(new BackgroundColorBlend(table.TopBackground.Start, 0));
            style.BackColorBlend.Add(new BackgroundColorBlend(table.TopBackground.End, table.TopBackgroundHeight));
            style.BackColorBlend.Add(new BackgroundColorBlend(table.BottomBackground.Start, table.TopBackgroundHeight));
            style.BackColorBlend.Add(new BackgroundColorBlend(table.BottomBackground.End, 1));

            return style;
        }

        /// <summary>
        /// Applies specified style to Ribbon control and all other controls that are managed by the ribbon control.
        /// This method is useful for example when switching the color tables for Office 2007 renderer. Once
        /// the GlobalManager.Renderer color table is changed you can call this method to apply color table
        /// changes to the Ribbon Control and other controls managed by it.
        /// </summary>
        /// <param name="r">RibbonControl to set the style on.</param>
        /// <param name="style">Visual style to apply.</param>
        public static void SetRibbonControlStyle(RibbonControl r, HVTTControlStyle style)
        {
            r.BackgroundStyle.Reset();
            r.Style = style;

            foreach (Control c in r.Controls)
            {
                if (c is RibbonPanel)
                {
                    RibbonPanel rp = c as RibbonPanel;
                    rp.Style.Reset();
                    rp.StyleMouseDown.Reset();
                    rp.StyleMouseOver.Reset();
                    rp.ColorSchemeStyle = style;
                }
                else if (c is RibbonBar)
                    SetRibbonBarStyle(c as RibbonBar, style);

                foreach (Control child in c.Controls)
                {
                    if (child is RibbonBar)
                        SetRibbonBarStyle(child as RibbonBar, style);
                }
            }

            r.Invalidate(true);
        }

        internal static void ApplyQatElementStyle(ElementStyle style, Ribbon.QatToolbar qat)
        {
            style.Reset();
            if (qat.Style == HVTTControlStyle.Office2007)
            {
                Rendering.Office2007ColorTable ct = GetOffice2007ColorTable(qat.Parent as RibbonControl);

                Rendering.Office2007QuickAccessToolbarStateColorTable qatColors = ct.QuickAccessToolbar.Standalone;
                style.BackColor = qatColors.BottomBackground.Start;
                style.BackColor2 = qatColors.BottomBackground.End;
                style.BackColorGradientAngle = qatColors.BottomBackground.GradientAngle;
                style.Border = StyleBorderType.Etched;
                style.BorderWidth = 1;
                style.CornerType = CornerType.Rounded;
                style.CornerDiameter = 2;
                style.BorderColor = qatColors.OutterBorderColor;
                style.BorderColorLight = qatColors.InnerBorderColor;
            }
            else
            {
                style.BackColorSchemePart = eColorSchemePart.BarBackground;
                style.BackColor2SchemePart = eColorSchemePart.BarBackground2;
                style.BackColorGradientAngle = 90;
            }
        }

        //internal static void ApplyOffice2007ColorScheme(Ribbon.QatToolbar qat)
        //{
        //    Rendering.Office2007ColorTable ct = null;
        //    Rendering.Office2007Renderer rn = Rendering.GlobalManager.Renderer as Rendering.Office2007Renderer;
        //    if (rn != null)
        //        ct = rn.ColorTable;
        //    else
        //        ct = new Rendering.Office2007ColorTable();

        //    Rendering.Office2007QuickAccessToolbarStateColorTable qatColors = ct.QuickAccessToolbar.Standalone;
        //    qat.BackColor = Color.Transparent;
        //    qat.BackgroundStyle.BackColor = qatColors.BottomBackground.Start;
        //    qat.BackgroundStyle.BackColor2 = qatColors.BottomBackground.End;
        //    qat.BackgroundStyle.BackColorGradientAngle = qatColors.BottomBackground.GradientAngle;
        //    qat.BackgroundStyle.Border = StyleBorderType.Etched;
        //    qat.BackgroundStyle.BorderWidth = 1;
        //    qat.BackgroundStyle.CornerType = CornerType.Rounded;
        //    qat.BackgroundStyle.CornerDiameter = 2;
        //    qat.BackgroundStyle.BorderColor = qatColors.OutterBorderColor;
        //    qat.BackgroundStyle.BorderColorLight = qatColors.InnerBorderColor;
        //}

		/// <summary>
		/// Applies specified visual style to the RibbonBar control.
		/// </summary>
		/// <param name="bar">RibbonBar control to set the style on.</param>
		/// <param name="style">Visual style to apply.</param>
		public static void SetRibbonBarStyle(RibbonBar bar, HVTTControlStyle style)
		{
            bar.BackgroundStyle.Reset();
            bar.BackgroundMouseOverStyle.Reset();
            bar.TitleStyle.Reset();
            bar.TitleStyleMouseOver.Reset();
            bar.Style = style;
            bar.Invalidate();
		}

        /// <summary>
        /// Applies current color scheme and layout settings to the container which acts as top-level file menu container.
        /// Applies to Office 2007 style only.
        /// </summary>
        /// <param name="container">Container to apply style to.</param>
        public static void SetupFileMenuContainer(ItemContainer topContainer)
        {
            Rendering.Office2007MenuColorTable mc = GetOffice2007MenuColorTable();
            if (mc == null)
                return;

            topContainer.LayoutOrientation = HVTTOrientation.Vertical;
            topContainer.BackgroundStyle.PaddingBottom = 3;
            topContainer.BackgroundStyle.PaddingLeft = 3;
            topContainer.BackgroundStyle.PaddingRight = 3;
            topContainer.BackgroundStyle.PaddingTop = 8;
            BackgroundColorBlend[] blend = new BackgroundColorBlend[mc.FileBackgroundBlend.Count];
            mc.FileBackgroundBlend.CopyTo(blend);
            topContainer.BackgroundStyle.BackColorBlend.Clear();
            topContainer.BackgroundStyle.BackColorBlend.AddRange(blend);
        }

        private static Rendering.Office2007MenuColorTable GetOffice2007MenuColorTable()
        {
            Rendering.Office2007MenuColorTable mc = null;
            if (Rendering.GlobalManager.Renderer is Rendering.Office2007Renderer)
                mc = ((Rendering.Office2007Renderer)Rendering.GlobalManager.Renderer).ColorTable.Menu;
            return mc;
        }

        /// <summary>
        /// Applies current color scheme and layout properties to the two column menu container used by the top-level file menu.
        /// Applies to Office 2007 style only.
        /// </summary>
        /// <param name="twoColumn">Container to apply style to.</param>
        public static void SetupTwoColumnMenuContainer(ItemContainer twoColumnMenu)
        {
            Rendering.Office2007MenuColorTable mc = GetOffice2007MenuColorTable();
            if (mc == null)
                return;

            twoColumnMenu.BackgroundStyle.BorderBottom = HVTT.UI.Window.Forms.StyleBorderType.Double;
            twoColumnMenu.BackgroundStyle.BorderBottomWidth = 1;
            twoColumnMenu.BackgroundStyle.BorderColor = mc.FileContainerBorder;
            twoColumnMenu.BackgroundStyle.BorderColorLight = mc.FileContainerBorderLight;
            twoColumnMenu.BackgroundStyle.BorderLeft = HVTT.UI.Window.Forms.StyleBorderType.Double;
            twoColumnMenu.BackgroundStyle.BorderLeftWidth = 1;
            twoColumnMenu.BackgroundStyle.BorderRight = HVTT.UI.Window.Forms.StyleBorderType.Double;
            twoColumnMenu.BackgroundStyle.BorderRightWidth = 1;
            twoColumnMenu.BackgroundStyle.BorderTop = HVTT.UI.Window.Forms.StyleBorderType.Double;
            twoColumnMenu.BackgroundStyle.BorderTopWidth = 1;
            twoColumnMenu.BackgroundStyle.PaddingBottom = 2;
            twoColumnMenu.BackgroundStyle.PaddingLeft = 2;
            twoColumnMenu.BackgroundStyle.PaddingRight = 2;
            twoColumnMenu.BackgroundStyle.PaddingTop = 2;
            twoColumnMenu.ItemSpacing = 0;
        }

        /// <summary>
        /// Applies current color scheme and layout properties to the first column menu container used by the top-level file menu.
        /// This column usually contains menu items.
        /// Applies to Office 2007 style only.
        /// </summary>
        /// <param name="menuColumn">Container to apply style to.</param>
        public static void SetupMenuColumnOneContainer(ItemContainer menuColumn)
        {
            Rendering.Office2007MenuColorTable mc = GetOffice2007MenuColorTable();
            if (mc == null)
                return;

            menuColumn.BackgroundStyle.BackColor = mc.FileColumnOneBackground;
            menuColumn.BackgroundStyle.BorderRight = HVTT.UI.Window.Forms.StyleBorderType.Solid;
            menuColumn.BackgroundStyle.BorderRightColor = mc.FileColumnOneBorder;
            menuColumn.BackgroundStyle.BorderRightWidth = 1;
            menuColumn.BackgroundStyle.PaddingRight = 1;
            menuColumn.LayoutOrientation = HVTT.UI.Window.Forms.HVTTOrientation.Vertical;
            menuColumn.MinimumSize = new System.Drawing.Size(120, 0);
        }

        /// <summary>
        /// Applies current color scheme and layout properties to the first column menu container used by the top-level file menu.
        /// This column usualy contains most recently used list of files or documents.
        /// Applies to Office 2007 style only.
        /// </summary>
        /// <param name="menuColumn">Container to apply style to.</param>
        public static void SetupMenuColumnTwoContainer(ItemContainer columnTwo)
        {
            Rendering.Office2007MenuColorTable mc = GetOffice2007MenuColorTable();
            if (mc == null)
                return;

            columnTwo.BackgroundStyle.BackColor = mc.FileColumnTwoBackground;
            columnTwo.LayoutOrientation = HVTT.UI.Window.Forms.HVTTOrientation.Vertical;
            columnTwo.MinimumSize = new System.Drawing.Size(180, 0);
        }

        /// <summary>
        /// Applies current color scheme and layout properties to the bottom menu container used by the top-level file menu.
        /// This container usualy contains Options and Exit buttons.
        /// Applies to Office 2007 style only.
        /// </summary>
        /// <param name="menuColumn">Container to apply style to.</param>
        public static void SetupMenuBottomContainer(ItemContainer bottomContainer)
        {
            Rendering.Office2007MenuColorTable mc = GetOffice2007MenuColorTable();
            if (mc == null)
                return;

            BackgroundColorBlend[] blend = new BackgroundColorBlend[mc.FileBottomContainerBackgroundBlend.Count];
            mc.FileBottomContainerBackgroundBlend.CopyTo(blend);
            bottomContainer.BackgroundStyle.BackColorBlend.Clear();
            bottomContainer.BackgroundStyle.BackColorBlend.AddRange(blend);

            bottomContainer.BackgroundStyle.BackColorGradientAngle = 90;
            bottomContainer.HorizontalItemAlignment = HVTT.UI.Window.Forms.eHorizontalItemsAlignment.Right;
        }


        /// <summary>
        /// Changes the Office 2007 color table for all HVTTCONTROLS controls on the open forms that are tracked by Application.OpenForms collection. You can use this function for example to
        /// apply Black color scheme to all HVTTCONTROLS control on all open forms. The color table will be changed only for controls that
        /// have Office 2007 style. Any other style will be unchanged.
        /// </summary>
        /// <param name="colorTable">Color table to select and apply.</param>
        public static void ChangeOffice2007ColorTable(eOffice2007ColorScheme colorTable)
        {
            // Make sure we use right color table in our global renderer
            if (GlobalManager.Renderer is Office2007Renderer)
            {
                ((Office2007Renderer)GlobalManager.Renderer).ColorTable.Dispose();
                ((Office2007Renderer)GlobalManager.Renderer).ColorTable = new Office2007ColorTable(colorTable);
            }
            else
                throw new InvalidOperationException("GlobalManager.Renderer is not Office2007Renderer. Cannot change the color table. Make sure that renderer is set to Office2007Renderer");

            ApplyOffice2007ColorTable();
        }

        /// <summary>
        /// Applies current Office 2007 style color table set on GlobalManager.Renderer to all HVTTCONTROLS controls with Office 2007 style on all open forms.
        /// </summary>
        public static void ApplyOffice2007ColorTable()
        {
            foreach (Form f in Application.OpenForms)
            {
                ApplyOffice2007ColorTable(f);
            }
        }


        /// <summary>
        /// Changes the Office 2007 color table for all HVTTCONTROLS controls on the form. You can use this function for example to
        /// apply Black color scheme to all HVTTCONTROLS control on given form. The color table will be changed only for controls that
        /// have Office 2007 style. Any other style will be unchanged.
        /// </summary>
        /// <param name="form">Form to apply color table to.</param>
        /// <param name="colorTable">Color table to select and apply.</param>
        public static void ChangeOffice2007ColorTable(Control form, eOffice2007ColorScheme colorTable)
        {
            // Make sure we use right color table in our global renderer
            if (GlobalManager.Renderer is Office2007Renderer)
            {
                ((Office2007Renderer)GlobalManager.Renderer).ColorTable.Dispose();
                ((Office2007Renderer)GlobalManager.Renderer).ColorTable = new Office2007ColorTable(colorTable);
            }
            else
                throw new InvalidOperationException("GlobalManager.Renderer is not Office2007Renderer. Cannot change the color table. Make sure that renderer is set to Office2007Renderer");

            ApplyOffice2007ColorTable(form);
        }

        /// <summary>
        /// Generates and Changes the Office 2007 color table for all HVTTCONTROLS controls on the form. You can use this function for example to
        /// create custom color scheme based on the base color and apply it to all HVTTCONTROLS control on given form. The new color table will be applied only to controls that
        /// have Office 2007 style. Any other style will be unchanged.
        /// </summary>
        /// <param name="form">Form to apply color table to.</param>
        /// <param name="colorTable">Base color table to use for creation of custom color table that will be applied.</param>
        /// <param name="baseSchemeColor">Base color used to create custom color table.</param>
        public static void ChangeOffice2007ColorTable(Control form, eOffice2007ColorScheme colorTable, Color baseSchemeColor)
        {
            // Make sure we use black color table in our global renderer
            if (GlobalManager.Renderer is Office2007Renderer)
            {
                ((Office2007Renderer)GlobalManager.Renderer).ColorTable.Dispose();
                ((Office2007Renderer)GlobalManager.Renderer).ColorTable = new Office2007ColorTable(colorTable, baseSchemeColor);
            }
            else
                throw new InvalidOperationException("GlobalManager.Renderer is not Office2007Renderer. Cannot change the color table. Make sure that renderer is set to Office2007Renderer");

            ApplyOffice2007ColorTable(form);
        }


        /// <summary>
        /// Generates and Changes the Office 2007 color table for all HVTTCONTROLS controls on all open forms. You can use this function for example to
        /// create custom color scheme based on the base color and apply it to all HVTTCONTROLS control on given form. The new color table will be applied only to controls that
        /// have Office 2007 style. Any other style will be unchanged.
        /// </summary>
        /// <param name="colorTable">Base color table to use for creation of custom color table that will be applied.</param>
        /// <param name="baseSchemeColor">Base color used to create custom color table.</param>
        public static void ChangeOffice2007ColorTable(eOffice2007ColorScheme colorTable, Color baseSchemeColor)
        {
            // Make sure we use black color table in our global renderer
            if (GlobalManager.Renderer is Office2007Renderer)
            {
                ((Office2007Renderer)GlobalManager.Renderer).ColorTable.Dispose();
                ((Office2007Renderer)GlobalManager.Renderer).ColorTable = new Office2007ColorTable(colorTable, baseSchemeColor);
            }
            else
                throw new InvalidOperationException("GlobalManager.Renderer is not Office2007Renderer. Cannot change the color table. Make sure that renderer is set to Office2007Renderer");

            ApplyOffice2007ColorTable();
        }


        /// <summary>
        /// Applies current Office 2007 style color table to all HVTTCONTROLS controls on the form.
        /// </summary>
        /// <param name="form">Reference to the form or parent control that contains HVTTCONTROLS controls you would like to apply color table to.</param>
        public static void ApplyOffice2007ColorTable(Control form)
        {
            if (form == null)
                return;

            // Make sure we use black color table in our global renderer
            if (!(GlobalManager.Renderer is Office2007Renderer))
                throw new InvalidOperationException("GlobalManager.Renderer is not Office2007Renderer. Cannot change the color table. Make sure that renderer is set to Office2007Renderer");

            ColorScheme cs = ((Office2007Renderer)GlobalManager.Renderer).ColorTable.LegacyColors;

            foreach (Control c in form.Controls)
            {
                ChangeOffice2007ColorTable(c, cs);
            }

            if (form is Office2007RibbonForm)
            {
                form.BackColor = ((Office2007Renderer)GlobalManager.Renderer).ColorTable.Form.BackColor;
            }
            if (form is Office2007Form)
                ((Office2007Form)form).InvalidateNonClient(true);
            form.Invalidate(true);
        }

        private static void ChangeOffice2007ColorTable(Control cont, ColorScheme cs)
        {
            bool enumChildControls = true;
            if (cont is HVTTPanel && ((HVTTPanel)cont).ColorSchemeStyle == HVTTControlStyle.Office2007)
            {
                HVTTPanel pe = cont as HVTTPanel;
                pe.ColorSchemeStyle = HVTTControlStyle.Office2007;
                cont.Invalidate();
            }
            if (cont is PanelControl && ((PanelControl)cont).ColorSchemeStyle == HVTTControlStyle.Office2007)
            {
                PanelControl pc = cont as PanelControl;
                pc.RefreshStyleSystemColors();
                pc.Invalidate();
            }
            else if (cont is ExpandablePanel && ((ExpandablePanel)cont).ColorSchemeStyle == HVTTControlStyle.Office2007)
            {
                //ExpandablePanel ep = cont as ExpandablePanel;
                //ep.ColorScheme = cs;
                cont.Invalidate();
            }
            else if (cont is RibbonControl)
            {
                ((RibbonControl)cont).RibbonStrip.InitDefaultStyles();
                cont.Invalidate(true);
                //RibbonControl rc = cont as RibbonControl;
                //SetRibbonControlStyle(rc, HVTTControlStyle.Office2007);
                //enumChildControls = false;
            }
            else if (cont is RibbonBar)
            {
                cont.Invalidate();
                //RibbonBar rb = cont as RibbonBar;
                //ApplyOffice2007ColorScheme(rb);
            }
            else if (cont is TabControl)
            {
                TabControl tc = cont as TabControl;
                if (tc.Style == eTabStripStyle.Office2007Dock || tc.Style == eTabStripStyle.Office2007Document)
                    tc.Style = tc.Style;
            }
            else if (cont is TabStrip)
            {
                TabStrip ts = cont as TabStrip;
                if (ts.Style == eTabStripStyle.Office2007Dock || ts.Style == eTabStripStyle.Office2007Document)
                    ts.Style = ts.Style;
            }
            else if (cont is SideBar)
            {
                SideBar sb = cont as SideBar;
                if (sb.Style == HVTTControlStyle.Office2007)
                    sb.Invalidate();
            }
            else if (cont is Office2007RibbonForm)
            {
                cont.BackColor = ((Office2007Renderer)GlobalManager.Renderer).ColorTable.Form.BackColor;
                if (cont is Office2007Form)
                    ((Office2007Form)cont).InvalidateNonClient(true);
            }
            else if (cont is DockSite && cont.Dock == DockStyle.Top)
            {
                // Update any floating bars through HVTTManager
                DockSite ds = cont as DockSite;
                if (ds.Owner != null)
                {
                    foreach (HVTTMarkStatus bar in ds.Owner.Bars)
                    {
                        if (bar.DockSide == eDockSide.None)
                        {
                            bar.Invalidate(true);
                            ChangeOffice2007ColorTable(bar, cs);
                        }
                    }
                }
            }
            else if (cont is Controls.HVTTComboBox)
                ((Controls.HVTTComboBox)cont).Style = ((Controls.HVTTComboBox)cont).Style;
            else if (cont is NavigationPane)
                ((NavigationPane)cont).Office2007ColorTableChanged();
            else if (cont is BaseItemControl && ((BaseItemControl)cont).Style == HVTTControlStyle.Office2007)
                cont.Invalidate();

            else if (cont is Controls.HVTTListView)
            {
                Controls.HVTTListView lv = cont as Controls.HVTTListView;
                lv.Invalidate(true);
                lv.ResetCachedColorTableReference();
            }
            else if (cont is Controls.DataGridView)
                cont.Invalidate(true);
            else if (cont is Controls.DGHScrollBar || cont is Controls.DGVScrollBar)
                cont.Invalidate();


            if (enumChildControls)
            {
                foreach (Control c in cont.Controls)
                    ChangeOffice2007ColorTable(c, cs);
            }
        }
    }
}
