using System;
using System.Drawing;
using System.Text;

namespace HVTT.UI.Window.Forms.Rendering
{
    /// <summary>
    /// Populates Office 2007 Color Table with Silver color scheme
    /// </summary>
    internal class Office2007SilverColorTableFactory
    {
        #region Silver Color Scheme
        #region RibbonBar
        public static Office2007RibbonBarStateColorTable GetRibbonBar(ColorFactory factory)
        {
            Office2007RibbonBarStateColorTable rb = new Office2007RibbonBarStateColorTable();
            rb.TopBackgroundHeight = 15;
            rb.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xBDBFC1), factory.GetColor(0x858585));
            rb.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xF6F7F9), factory.GetColor(0xFAFAFA));
            rb.TopBackground = new LinearGradientColorTable(factory.GetColor(0xEEF1F6), factory.GetColor(0xE1E6EE));
            rb.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xD5DBE7), factory.GetColor(0xEEF4F4));
            rb.TitleBackground = new LinearGradientColorTable(factory.GetColor(0xDFE3EF), factory.GetColor(0xC3C7D1));
            rb.TitleText = factory.GetColor(0x333333);
            return rb;
        }

        public static Office2007RibbonBarStateColorTable GetRibbonBarMouseOver(ColorFactory factory)
        {
            Office2007RibbonBarStateColorTable rb = new Office2007RibbonBarStateColorTable();
            rb.TopBackgroundHeight = 15;
            rb.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xBDBFC1), factory.GetColor(0x858585));
            rb.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFAFBFC), factory.GetColor(0xFAFAFA));
            rb.TopBackground = new LinearGradientColorTable(factory.GetColor(0xF7F8FA), factory.GetColor(0xF3F4F7));
            rb.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xEEF0F5), factory.GetColor(0xF7F9F9));
            rb.TitleBackground = new LinearGradientColorTable(factory.GetColor(0xDEE2EE), factory.GetColor(0xB3B9C7));
            rb.TitleText = factory.GetColor(0x333333);

            return rb;
        }

        public static Office2007RibbonBarStateColorTable GetRibbonBarExpanded(ColorFactory factory)
        {
            Office2007RibbonBarStateColorTable rb = new Office2007RibbonBarStateColorTable();
            rb.TopBackgroundHeight = 15;
            rb.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x7D7D7D), factory.GetColor(0x949494));
            rb.InnerBorder = new LinearGradientColorTable(Color.FromArgb(128, factory.GetColor(0x989899)), Color.Transparent);
            rb.TopBackground = new LinearGradientColorTable(factory.GetColor(0xE5E5E6), factory.GetColor(0xBFC3CC));
            rb.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xB3B9C3), factory.GetColor(0xDEE4E4));
            rb.TitleBackground = new LinearGradientColorTable(factory.GetColor(0xDEE4E4), Color.Empty);
            rb.TitleText = Color.Empty;

            return rb;
        }
        #endregion

        #region RibbonTabItem
        public static Office2007RibbonTabItemColorTable GetRibbonTabItemDefault(ColorFactory factory)
        {
            Office2007RibbonTabItemColorTable rt = new Office2007RibbonTabItemColorTable();
            rt.Default.Text = factory.GetColor(0x333333);

            // Selected Tab
            rt.Selected = new Office2007RibbonTabItemStateColorTable();
            rt.Selected.Background = new LinearGradientColorTable(factory.GetColor(0xF2F2F4), factory.GetColor(0xE3E7EF));
            rt.Selected.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.Selected.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xEFF9F9), factory.GetColor(0xB5F9FF));
            rt.Selected.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xBEBEBE), factory.GetColor(0xBEBEBE));
            rt.Selected.Text = factory.GetColor(0x333333);

            // Selected Tab Mouse Over
            rt.SelectedMouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.SelectedMouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xF2F7FA), factory.GetColor(0xE1E6EF));
            rt.SelectedMouseOver.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(92, Color.White), Color.Transparent);
            rt.SelectedMouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFAECC2), factory.GetColor(0xFFFFBD));
            rt.SelectedMouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xE8BB72), factory.GetColor(0xFED15E));
            rt.SelectedMouseOver.Text = factory.GetColor(0x333333);

            // Tab Mouse Over
            rt.MouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.MouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xDBD4C3), factory.GetColor(0xE9CE8D));
            rt.MouseOver.BackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xD3D7DF), Color.Transparent);
            rt.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xE8EAEE), factory.GetColor(0xDADDE4));
            rt.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xBDBEC1), factory.GetColor(0xBDBEC1));
            rt.MouseOver.Text = factory.GetColor(0x333333);

            return rt;
        }

        public static Office2007RibbonTabItemColorTable GetRibbonTabItemMagenta(ColorFactory factory)
        {
            Office2007RibbonTabItemColorTable rt = new Office2007RibbonTabItemColorTable();
            rt.Default.Text = factory.GetColor(0x333333);
            // Selected Tab
            rt.Selected = new Office2007RibbonTabItemStateColorTable();
            rt.Selected.Background = new LinearGradientColorTable(factory.GetColor(0xEBC7C7), factory.GetColor(0xF6DFDD));
            rt.Selected.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.Selected.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xF6E6E6), factory.GetColor(0xE6BBBB));
            rt.Selected.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xC3BCBC), factory.GetColor(0xC2C2C2));
            rt.Selected.Text = factory.GetColor(0x333333);

            // Selected Tab Mouse Over
            rt.SelectedMouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.SelectedMouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xFBDE9A), factory.GetColor(0xFDF1D4));
            rt.SelectedMouseOver.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.SelectedMouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFAD57E), factory.GetColor(0xF8DC94));
            rt.SelectedMouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xD7BC7D), factory.GetColor(0xC2C2C2));
            rt.SelectedMouseOver.Text = factory.GetColor(0x333333);

            // Tab Mouse Over
            rt.MouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.MouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xE1D5D9), factory.GetColor(0xE68985));
            rt.MouseOver.BackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xE0D8DD), Color.Transparent);
            rt.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xE1D3D7), factory.GetColor(0xE78885));
            rt.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xBDBEC1), factory.GetColor(0xBEBEBE));
            rt.MouseOver.Text = factory.GetColor(0x333333);
            return rt;
        }

        public static Office2007RibbonTabItemColorTable GetRibbonTabItemGreen(ColorFactory factory)
        {
            Office2007RibbonTabItemColorTable rt = new Office2007RibbonTabItemColorTable();
            rt.Default.Text = factory.GetColor(0x333333);

            // Selected Tab
            rt.Selected = new Office2007RibbonTabItemStateColorTable();
            rt.Selected.Background = new LinearGradientColorTable(factory.GetColor(0xC1E2B8), factory.GetColor(0xE1F1DB));
            rt.Selected.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.Selected.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xE4F3E0), factory.GetColor(0xB8DEB1));
            rt.Selected.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xBEC2BD), factory.GetColor(0xC2C2C2));
            rt.Selected.Text = factory.GetColor(0x333333);

            // Selected Tab Mouse Over
            rt.SelectedMouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xFBDF9E), factory.GetColor(0xFDF1D4));
            rt.SelectedMouseOver.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.SelectedMouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFDF2D5), factory.GetColor(0xF8D88A));
            rt.SelectedMouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xC7C1B2), factory.GetColor(0xC2C2C2));
            rt.SelectedMouseOver.Text = factory.GetColor(0x333333);

            // Tab Mouse Over
            rt.MouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.MouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xD8DFE1), factory.GetColor(0x9AC892));
            rt.MouseOver.BackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xD9DEDF), Color.Transparent);
            rt.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xD8DFE1), factory.GetColor(0x9AC892));
            rt.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xBDBEC1), factory.GetColor(0xBEBEBE));
            rt.MouseOver.Text = factory.GetColor(0x333333);
            return rt;
        }

        public static Office2007RibbonTabItemColorTable GetRibbonTabItemOrange(ColorFactory factory)
        {
            Office2007RibbonTabItemColorTable rt = new Office2007RibbonTabItemColorTable();
            rt.Default.Text = factory.GetColor(0x333333);

            // Selected Tab
            rt.Selected = new Office2007RibbonTabItemStateColorTable();
            rt.Selected.Background = new LinearGradientColorTable(factory.GetColor(0xFFF59F), factory.GetColor(0xFFFAD5));
            rt.Selected.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.Selected.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFFFBD6), factory.GetColor(0xFDF28C));
            rt.Selected.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xC7C5B4), factory.GetColor(0xC2C2C2));
            rt.Selected.Text = factory.GetColor(0x333333);

            // Selected Tab Mouse Over
            rt.SelectedMouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.SelectedMouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xFBDE9A), factory.GetColor(0xFDF1D4));
            rt.SelectedMouseOver.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.SelectedMouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xF9D276), factory.GetColor(0xF8D88A));
            rt.SelectedMouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xD7BC7D), factory.GetColor(0xC2C2C2));
            rt.SelectedMouseOver.Text = factory.GetColor(0x333333);

            // Tab Mouse Over
            rt.MouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.MouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xE0E1DC), factory.GetColor(0xB6A933));
            rt.MouseOver.BackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xE0E1DC), Color.Transparent);
            rt.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xE0E1DC), factory.GetColor(0xEADF6D));
            rt.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xBDBEC1), factory.GetColor(0xBDBEC1));
            rt.MouseOver.Text = factory.GetColor(0x333333);

            return rt;
        }
        #endregion

        #region ButtonItem
        public static void SetExpandColors(Office2007ButtonItemColorTable ct, ColorFactory factory)
        {
            Color cb = factory.GetColor(0x7F7F7F);
            Color cl = factory.GetColor(0xE4E6E8);
            ct.Default.ExpandBackground = cb;
            ct.Default.ExpandLight = cl;

            ct.Checked.ExpandBackground = cb;
            ct.Checked.ExpandLight = cl;

            //ct.Disabled.ExpandBackground = factory.GetColor(0xB7B7B7);
            //ct.Disabled.ExpandLight = factory.GetColor(0xEDEDED);

            ct.Expanded.ExpandBackground = cb;
            ct.Expanded.ExpandLight = cl;

            ct.MouseOver.ExpandBackground = cb;
            ct.MouseOver.ExpandLight = cl;

            ct.Pressed.ExpandBackground = cb;
            ct.Pressed.ExpandLight = cl;
        }

        public static Office2007ButtonItemColorTable GetButtonItemOrange(bool ribbonBar, ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = new Office2007ButtonItemColorTable();
            cb.Default = new Office2007ButtonItemStateColorTable();
            //if(ribbonBar)
            cb.Default.Text = factory.GetColor(0x333333);  //factory.GetColor(0x464646);
            //else
            //    cb.Default.Text = factory.GetColor(0xFFFFFF);

            // Button mouse over
            cb.MouseOver = new Office2007ButtonItemStateColorTable();
            cb.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xDDCF9B), factory.GetColor(0xC0A776));
            cb.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFFFFF7), factory.GetColor(0xFFF796));
            cb.MouseOver.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFFFBD7), factory.GetColor(0xFFE78D));
            cb.MouseOver.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(192, Color.White), Color.Transparent);
            cb.MouseOver.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFFD748), factory.GetColor(0xFFE793));
            cb.MouseOver.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(164, Color.White), Color.Transparent);
            cb.MouseOver.SplitBorder = new LinearGradientColorTable(factory.GetColor(0xDBC374), factory.GetColor(0xC8BB8C));
            cb.MouseOver.SplitBorderLight = new LinearGradientColorTable(factory.GetColor(0xFFF0BF), factory.GetColor(0xFFF6DF));
            cb.MouseOver.Text = factory.GetColor(0x333333);

            // Pressed
            cb.Pressed = new Office2007ButtonItemStateColorTable();
            cb.Pressed.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x8B7654), factory.GetColor(0xC4B9A8));
            cb.Pressed.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xE9A861), factory.GetColor(0xFDAD11));
            cb.Pressed.TopBackground = new LinearGradientColorTable(factory.GetColor(0xF8B56A), factory.GetColor(0xFCA060));
            cb.Pressed.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            cb.Pressed.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFB8A3C), factory.GetColor(0xFEBD62));
            cb.Pressed.BottomBackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xFFE0AF), Color.Transparent);
            cb.Pressed.SplitBorder = new LinearGradientColorTable(factory.GetColor(0xB07D4B), factory.GetColor(0x907853));
            cb.Pressed.SplitBorderLight = new LinearGradientColorTable(factory.GetColor(0xFAC094), factory.GetColor(0xFFD9AC));
            cb.Pressed.Text = factory.GetColor(0x333333);

            // Checked
            cb.Checked = new Office2007ButtonItemStateColorTable();
            cb.Checked.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x9F7559), factory.GetColor(0xFFCF2D));
            cb.Checked.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xEBD1B4), Color.Transparent);
            cb.Checked.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFBDBB5), factory.GetColor(0xFEC778));
            cb.Checked.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(32, Color.White), Color.Transparent);
            cb.Checked.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFEB456), factory.GetColor(0xFDEB9F));
            cb.Checked.BottomBackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xFFF59F), Color.Transparent);
            cb.Checked.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Checked.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Checked.Text = factory.GetColor(0x333333);

            // Expanded button
            cb.Expanded = new Office2007ButtonItemStateColorTable();
            cb.Expanded.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x8E8165), factory.GetColor(0xC6C0B2));
            cb.Expanded.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xE5AE55), factory.GetColor(0xFFD64A));
            cb.Expanded.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFCD3A7), factory.GetColor(0xFAA85B));
            cb.Expanded.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(128, Color.White), Color.Transparent);
            cb.Expanded.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xF88D29), factory.GetColor(0xFDE499));
            cb.Expanded.BottomBackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xFFF6C9), Color.Transparent);
            cb.Expanded.SplitBorder = new LinearGradientColorTable(factory.GetColor(0xB07D4B), factory.GetColor(0x8B7654));
            cb.Expanded.SplitBorderLight = new LinearGradientColorTable(factory.GetColor(0xFAC094), factory.GetColor(0xFFD8AB));
            cb.Expanded.Text = factory.GetColor(0x333333);

            SetExpandColors(cb, factory);
            return cb;
        }

        public static Office2007ButtonItemColorTable GetButtonItemOrangeWithBackground(ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = GetButtonItemOrange(false, factory);
            //cb.Default = new Office2007ButtonItemStateColorTable();

            cb.Default.TopBackground = new LinearGradientColorTable(factory.GetColor(0xEBF0F5), factory.GetColor(0xECF0F5));
            cb.Default.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xCBD2DB), factory.GetColor(0xF0F4F9));
            cb.Default.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            cb.Default.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x8D949D), Color.Empty);
            cb.Default.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            // Copy of the default theme
            cb.Disabled = new Office2007ButtonItemStateColorTable();
            cb.Disabled.TopBackground = new LinearGradientColorTable(factory.GetColor(0xE3E8EE), factory.GetColor(0xCBD2DB));
            cb.Disabled.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xCBD2DB), factory.GetColor(0xCBD2DB));
            cb.Disabled.BottomBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xB3B3B3), Color.Empty);
            cb.Disabled.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            return cb;
        }

        public static Office2007ButtonItemColorTable GetButtonItemBlue(bool ribbonBar, ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = new Office2007ButtonItemColorTable();
            cb.Default = new Office2007ButtonItemStateColorTable();
            //if (ribbonBar)
            cb.Default.Text = factory.GetColor(0x333333);  //factory.GetColor(0x15428B);
            //else
            //    cb.Default.Text = factory.GetColor(0xFFFFFF);

            // Button mouse over
            cb.MouseOver = new Office2007ButtonItemStateColorTable();
            cb.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x3B5A82), Color.Empty);
            cb.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFFFFFB), factory.GetColor(0xE0EEFF));
            cb.MouseOver.TopBackground = new LinearGradientColorTable(factory.GetColor(0xC0DCFF), factory.GetColor(0xA9CEFF));
            cb.MouseOver.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(192, Color.White), Color.Transparent);
            cb.MouseOver.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xA6CDFF), factory.GetColor(0xCAE1FF));
            cb.MouseOver.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(124, Color.White), Color.Transparent);
            cb.MouseOver.SplitBorder = new LinearGradientColorTable(factory.GetColor(0x7495C2), factory.GetColor(0x90AFD6));
            cb.MouseOver.SplitBorderLight = new LinearGradientColorTable(factory.GetColor(0xD6E3F3), factory.GetColor(0x83A5D0));
            cb.MouseOver.Text = factory.GetColor(0x333333);

            // Pressed
            cb.Pressed = new Office2007ButtonItemStateColorTable();
            cb.Pressed.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x3B5A82), Color.Empty);
            cb.Pressed.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFFFFFB), factory.GetColor(0xE0EEFF));
            cb.Pressed.TopBackground = new LinearGradientColorTable(factory.GetColor(0xC5DCF8), factory.GetColor(0xA9CAF7));
            cb.Pressed.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(96, Color.White), Color.Transparent);
            cb.Pressed.BottomBackground = new LinearGradientColorTable(factory.GetColor(0x90B6EA), factory.GetColor(0x7495C2));
            cb.Pressed.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(184, Color.White), Color.Transparent);
            cb.Pressed.SplitBorder = new LinearGradientColorTable(factory.GetColor(0x7495C2), factory.GetColor(0x90AFD6));
            cb.Pressed.SplitBorderLight = new LinearGradientColorTable(factory.GetColor(0xD6E3F3), factory.GetColor(0x83A5D0));
            cb.Pressed.Text = factory.GetColor(0x333333);

            // Checked
            cb.Checked = new Office2007ButtonItemStateColorTable();
            cb.Checked.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x567DB0), factory.GetColor(0x567DB0));
            cb.Checked.InnerBorder = new LinearGradientColorTable(factory.GetColor(0x90B6EA), factory.GetColor(0x7495C2));
            cb.Checked.TopBackground = new LinearGradientColorTable(factory.GetColor(0xD7E6F9), factory.GetColor(0xC7DCF8));
            cb.Checked.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            cb.Checked.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xB3D0F5), factory.GetColor(0xD7E5F7));
            cb.Checked.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(92, Color.White), Color.Transparent);
            cb.Checked.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Checked.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Checked.Text = factory.GetColor(0x333333);

            // Expanded button
            cb.Expanded = new Office2007ButtonItemStateColorTable();
            cb.Expanded.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x6187B7), factory.GetColor(0x4C83C8));
            cb.Expanded.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xA2B4CD), Color.Transparent);
            cb.Expanded.TopBackground = new LinearGradientColorTable(factory.GetColor(0xD7E6F9), factory.GetColor(0xC7DCF8));
            cb.Expanded.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(192, Color.White), Color.Transparent);
            cb.Expanded.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xB3D0F5), factory.GetColor(0xD7E5F7));
            cb.Expanded.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(164, Color.White), Color.Transparent);
            cb.Expanded.SplitBorder = new LinearGradientColorTable(factory.GetColor(0x537EB8), factory.GetColor(0x6985AA));
            cb.Expanded.SplitBorderLight = new LinearGradientColorTable(factory.GetColor(0x9AC0F5), factory.GetColor(0xB9D7FF));
            cb.Expanded.Text = factory.GetColor(0x333333);


            //// Menu mouse over
            //cb.MenuMouseOver = new Office2007ButtonItemStateColorTable();
            //cb.MenuMouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xAAC2E0), factory.GetColor(0x6591CD));
            //cb.MenuMouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFFFFFB), factory.GetColor(0xE0EEFF));
            //cb.MenuMouseOver.TopBackground = new LinearGradientColorTable(factory.GetColor(0xECF4FF), factory.GetColor(0xB0D3FF));
            //cb.MenuMouseOver.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(192, Color.White), Color.Transparent);
            //cb.MenuMouseOver.BottomBackground = new LinearGradientColorTable(factory.GetColor(0x89BDFF), factory.GetColor(0x2983FF));
            //cb.MenuMouseOver.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(164, Color.White), Color.Transparent);
            //cb.MenuMouseOver.SplitBorder = new LinearGradientColorTable(factory.GetColor(0x7495C2), factory.GetColor(0x90AFD6));
            //cb.MenuMouseOver.SplitBorderLight = new LinearGradientColorTable(factory.GetColor(0xD6E3F3), factory.GetColor(0x83A5D0));
            //cb.MenuMouseOver.Text = factory.GetColor(0x15428B);
            SetExpandColors(cb, factory);
            return cb;
        }

        public static Office2007ButtonItemColorTable GetButtonItemBlueWithBackground(ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = GetButtonItemBlue(false, factory);

            cb.Default.TopBackground = new LinearGradientColorTable(factory.GetColor(0xEBF0F5), factory.GetColor(0xECF0F5));
            cb.Default.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xCBD2DB), factory.GetColor(0xF0F4F9));
            cb.Default.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            cb.Default.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x8D949D), Color.Empty);
            cb.Default.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            // Copy of the default theme
            cb.Disabled = new Office2007ButtonItemStateColorTable();
            cb.Disabled.TopBackground = new LinearGradientColorTable(factory.GetColor(0xE3E8EE), factory.GetColor(0xCBD2DB));
            cb.Disabled.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xCBD2DB), factory.GetColor(0xCBD2DB));
            cb.Disabled.BottomBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xB3B3B3), Color.Empty);
            cb.Disabled.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            return cb;
        }

        public static Office2007ButtonItemColorTable GetButtonItemMagenta(bool ribbonBar, ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = new Office2007ButtonItemColorTable();
            cb.Default = new Office2007ButtonItemStateColorTable();
            cb.Default.Text = factory.GetColor(0x000000);

            // Button mouse over
            cb.MouseOver = new Office2007ButtonItemStateColorTable();
            cb.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x6B0060), factory.GetColor(0x56014D));
            cb.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xECE7F3), factory.GetColor(0xE8D6FF));
            cb.MouseOver.TopBackground = new LinearGradientColorTable(factory.GetColor(0xF2DFEB), factory.GetColor(0xE6C6DB));
            cb.MouseOver.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(96, Color.White), Color.Transparent);
            cb.MouseOver.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xEAA8D4), factory.GetColor(0xE181C1));
            cb.MouseOver.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(164, Color.White), Color.Transparent);
            cb.MouseOver.SplitBorder = new LinearGradientColorTable(factory.GetColor(0xA37BD1), factory.GetColor(0x8868AE));
            cb.MouseOver.SplitBorderLight = new LinearGradientColorTable(factory.GetColor(0xD9C2F3), factory.GetColor(0xBBA6D3));
            cb.MouseOver.Text = factory.GetColor(0x000000);

            // Pressed
            cb.Pressed = new Office2007ButtonItemStateColorTable();
            cb.Pressed.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x6B0060), factory.GetColor(0x56014D));
            cb.Pressed.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xECE7F3), factory.GetColor(0xE8D6FF));
            cb.Pressed.TopBackground = new LinearGradientColorTable(factory.GetColor(0xD2B0C6), factory.GetColor(0xCBADC1));
            cb.Pressed.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            cb.Pressed.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xD27AB5), factory.GetColor(0xC84C9F));
            cb.Pressed.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(184, Color.White), Color.Transparent);
            cb.Pressed.SplitBorder = new LinearGradientColorTable(factory.GetColor(0xA37BD1), factory.GetColor(0x8868AE));
            cb.Pressed.SplitBorderLight = new LinearGradientColorTable(factory.GetColor(0xD9C2F3), factory.GetColor(0xBBA6D3));
            cb.Pressed.Text = factory.GetColor(0x000000);

            // Checked
            cb.Checked = new Office2007ButtonItemStateColorTable();
            cb.Checked.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x6B0060), factory.GetColor(0x56014D));
            cb.Checked.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xECE7F3), factory.GetColor(0xE8D6FF));
            cb.Checked.TopBackground = new LinearGradientColorTable(factory.GetColor(0xE9D7E2), factory.GetColor(0xE2B0D1));
            cb.Checked.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(164, Color.White), Color.Transparent);
            cb.Checked.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xCF90BA), factory.GetColor(0xCF73B0));
            cb.Checked.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(92, Color.White), Color.Transparent);
            cb.Checked.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Checked.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Checked.Text = factory.GetColor(0x000000);

            // Expanded button
            cb.Expanded = new Office2007ButtonItemStateColorTable();
            cb.Expanded.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x6B0060), factory.GetColor(0x56014D));
            cb.Expanded.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xECE7F3), factory.GetColor(0xE8D6FF));
            cb.Expanded.TopBackground = new LinearGradientColorTable(factory.GetColor(0xE9D7E2), factory.GetColor(0xE2B0D1));
            cb.Expanded.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(192, Color.White), Color.Transparent);
            cb.Expanded.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xCF90BA), factory.GetColor(0xCF73B0));
            cb.Expanded.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(192, Color.White), Color.Transparent);
            cb.Expanded.SplitBorder = new LinearGradientColorTable(factory.GetColor(0xA37BD1), factory.GetColor(0x8868AE));
            cb.Expanded.SplitBorderLight = new LinearGradientColorTable(factory.GetColor(0xD9C2F3), factory.GetColor(0xBBA6D3));
            cb.Expanded.Text = factory.GetColor(0x000000);


            //// Menu mouse over
            //cb.MenuMouseOver = new Office2007ButtonItemStateColorTable();
            //cb.MenuMouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xDE9ECC), factory.GetColor(0xBD71A8));
            //cb.MenuMouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xECE7F3), factory.GetColor(0xE8D6FF));
            //cb.MenuMouseOver.TopBackground = new LinearGradientColorTable(factory.GetColor(0xF3EAFF), factory.GetColor(0xDBBCFF));
            //cb.MenuMouseOver.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(192, Color.White), Color.Transparent);
            //cb.MenuMouseOver.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xAF6BFF), factory.GetColor(0xD3AEFF));
            //cb.MenuMouseOver.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(164, Color.White), Color.Transparent);
            //cb.MenuMouseOver.SplitBorder = new LinearGradientColorTable(factory.GetColor(0xA37BD1), factory.GetColor(0x8868AE));
            //cb.MenuMouseOver.SplitBorderLight = new LinearGradientColorTable(factory.GetColor(0xD9C2F3), factory.GetColor(0xBBA6D3));
            //cb.MenuMouseOver.Text = factory.GetColor(0x15428B);
            Office2007ColorTableFactory.SetBlackExpandColors(cb, factory);

            return cb;
        }

        public static Office2007ButtonItemColorTable GetButtonItemMagentaWithBackground(ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = GetButtonItemMagenta(false, factory);

            cb.Default.TopBackground = new LinearGradientColorTable(factory.GetColor(0xEBF0F5), factory.GetColor(0xECF0F5));
            cb.Default.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xCBD2DB), factory.GetColor(0xF0F4F9));
            cb.Default.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            cb.Default.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x8D949D), Color.Empty);
            cb.Default.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            // Copy of the default theme
            cb.Disabled = new Office2007ButtonItemStateColorTable();
            cb.Disabled.TopBackground = new LinearGradientColorTable(factory.GetColor(0xE3E8EE), factory.GetColor(0xCBD2DB));
            cb.Disabled.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xCBD2DB), factory.GetColor(0xCBD2DB));
            cb.Disabled.BottomBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xB3B3B3), Color.Empty);
            cb.Disabled.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            return cb;
        }
        #endregion

        #region RibbonTabItemGroup
        public static Office2007RibbonTabGroupColorTable GetRibbonTabGroupDefault(ColorFactory factory)
        {
            Office2007RibbonTabGroupColorTable tg = new Office2007RibbonTabGroupColorTable();
            tg.Background = new LinearGradientColorTable(Color.Transparent /*factory.GetColor(0xC1C6C1)*/, factory.GetColor(0xF3EB96));
            tg.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, factory.GetColor(0xFEE51D)), Color.Transparent);
            tg.Text = factory.GetColor(0x333333);
            tg.Border = new LinearGradientColorTable(Color.FromArgb(16, Color.DarkGray), Color.FromArgb(192, Color.DarkGray));

            return tg;
        }

        public static Office2007RibbonTabGroupColorTable GetRibbonTabGroupMagenta(ColorFactory factory)
        {
            Office2007RibbonTabGroupColorTable tg = new Office2007RibbonTabGroupColorTable();
            tg.Background = new LinearGradientColorTable(Color.Transparent /*factory.GetColor(0xBDBBC2)*/, factory.GetColor(0xDFADB1));
            tg.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, factory.GetColor(0xF26259)), Color.Transparent);
            tg.Text = factory.GetColor(0x333333);
            tg.Border = new LinearGradientColorTable(Color.FromArgb(16, Color.DarkGray), Color.FromArgb(192, Color.DarkGray));

            return tg;
        }

        public static Office2007RibbonTabGroupColorTable GetRibbonTabGroupGreen(ColorFactory factory)
        {
            Office2007RibbonTabGroupColorTable tg = new Office2007RibbonTabGroupColorTable();

            tg.Background = new LinearGradientColorTable(Color.Transparent /*factory.GetColor(0xB7C2C5)*/, factory.GetColor(0xB5DAB0));
            tg.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, factory.GetColor(0x6CB954)), Color.Transparent);
            tg.Border = new LinearGradientColorTable(Color.FromArgb(16, Color.DarkGray), Color.FromArgb(192, Color.DarkGray));
            tg.Text = factory.GetColor(0x333333);

            return tg;
        }

        public static Office2007RibbonTabGroupColorTable GetRibbonTabGroupOrange(ColorFactory factory)
        {
            Office2007RibbonTabGroupColorTable tg = new Office2007RibbonTabGroupColorTable();

            tg.Background = new LinearGradientColorTable(Color.Transparent /*factory.GetColor(0xC0C3C0)*/, factory.GetColor(0xEFDDA0));
            tg.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, factory.GetColor(0xF3B51B)), Color.Transparent);
            tg.Border = new LinearGradientColorTable(Color.FromArgb(16, Color.DarkGray), Color.FromArgb(192, Color.DarkGray));
            tg.Text = factory.GetColor(0x333333);

            return tg;
        }
        #endregion

        #region Scroll Bar
        public static void InitializeScrollBarColorTable(Office2007ColorTable t, ColorFactory factory)
        {
            Office2007ScrollBarStateColorTable sct = t.ScrollBar.Default;
            sct.Background = new LinearGradientColorTable(factory.GetColor(0xFCFCFC), factory.GetColor(0xF0F0F0), 0);
            sct.Border = new LinearGradientColorTable(factory.GetColor(0xEBEDEF), Color.Empty);
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0x6E7EA6), factory.GetColor(0x424B63), 90);
            sct.TrackBackground.Clear();
            sct.TrackBackground.AddRange(new BackgroundColorBlend[] { new BackgroundColorBlend(factory.GetColor(0xEBEEF0),0f), 
                new BackgroundColorBlend(factory.GetColor(0xE6E9F0),0.5f),
                new BackgroundColorBlend(factory.GetColor(0xD1DAE4),0.5f),
                new BackgroundColorBlend(factory.GetColor(0xBECADB),1f)});
            sct.TrackInnerBorder = new LinearGradientColorTable(factory.GetColor(0xE8E9E9), factory.GetColor(0xE9ECF2));
            sct.TrackOuterBorder = new LinearGradientColorTable(factory.GetColor(0x5F6E93), Color.Empty);
            sct.TrackSignBackground = new LinearGradientColorTable(Color.FromArgb(180, factory.GetColor(0x606060)), Color.FromArgb(64, Color.White));

            // Mouse Over
            sct = t.ScrollBar.MouseOver;
            sct.Background = t.ScrollBar.Default.Background;
            sct.Border = t.ScrollBar.Default.Border;
            sct.ThumbBackground.Clear();
            sct.ThumbBackground.AddRange(new BackgroundColorBlend[] { new BackgroundColorBlend(factory.GetColor(0xF1F6FE),0f), 
                new BackgroundColorBlend(factory.GetColor(0xDFEAF7),0.5f),
                new BackgroundColorBlend(factory.GetColor(0xBAD0EB),0.5f),
                new BackgroundColorBlend(factory.GetColor(0xCDDEF3),1f)});
            sct.ThumbInnerBorder = new LinearGradientColorTable(factory.GetColor(0xFAFCFF), factory.GetColor(0xEEF4FC));
            sct.ThumbOuterBorder = new LinearGradientColorTable(factory.GetColor(0x8C97A5), factory.GetColor(0x66717F));
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0x333C54), factory.GetColor(0x55658D));
            sct.TrackBackground.Clear();
            sct.TrackBackground.AddRange(new BackgroundColorBlend[] { new BackgroundColorBlend(factory.GetColor(0xBFD1EA),0f), 
                new BackgroundColorBlend(factory.GetColor(0xCADFFA),0.5f),
                new BackgroundColorBlend(factory.GetColor(0xAACBF6),0.5f),
                new BackgroundColorBlend(factory.GetColor(0xD3E4FA),1f)});
            sct.TrackInnerBorder = new LinearGradientColorTable(factory.GetColor(0xE9E9EB), factory.GetColor(0xFCFDFF));
            sct.TrackOuterBorder = new LinearGradientColorTable(factory.GetColor(0x3C6EB0), Color.Empty);
            sct.TrackSignBackground = new LinearGradientColorTable(Color.FromArgb(180, factory.GetColor(0x606060)), Color.FromArgb(64, Color.White));

            // Control Mouse Over
            sct = t.ScrollBar.MouseOverControl;
            sct.Background = t.ScrollBar.Default.Background;
            sct.Border = t.ScrollBar.Default.Border;
            sct.ThumbBackground.Clear();
            sct.ThumbBackground.AddRange(new BackgroundColorBlend[] { new BackgroundColorBlend(factory.GetColor(0xF4F9FF),0f), 
                new BackgroundColorBlend(factory.GetColor(0xF4F9FF),0.5f),
                new BackgroundColorBlend(factory.GetColor(0xCFE1F8),0.5f),
                new BackgroundColorBlend(factory.GetColor(0xDFECFC),1f)});
            sct.ThumbInnerBorder = new LinearGradientColorTable(factory.GetColor(0xFBFDFF), Color.Empty);
            sct.ThumbOuterBorder = new LinearGradientColorTable(factory.GetColor(0x8C97A5), factory.GetColor(0x66717F));
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0x6E7EA6), factory.GetColor(0x424B63));
            sct.TrackBackground.Clear();
            sct.TrackBackground.AddRange(new BackgroundColorBlend[] { new BackgroundColorBlend(factory.GetColor(0xEBEEF0),0f), 
                new BackgroundColorBlend(factory.GetColor(0xE6E9F0),0.5f),
                new BackgroundColorBlend(factory.GetColor(0xD1DAE4),0.5f),
                new BackgroundColorBlend(factory.GetColor(0xBECADB),1f)});
            sct.TrackInnerBorder = new LinearGradientColorTable(factory.GetColor(0xE8E9E9), factory.GetColor(0xE9EDF2));
            sct.TrackOuterBorder = new LinearGradientColorTable(factory.GetColor(0x5F6E93), Color.Empty);
            sct.TrackSignBackground = new LinearGradientColorTable(Color.FromArgb(180, factory.GetColor(0x606060)), Color.FromArgb(64, Color.White));
            // Pressed
            sct = t.ScrollBar.Pressed;
            sct.Background = t.ScrollBar.Default.Background;
            sct.Border = t.ScrollBar.Default.Border;
            sct.ThumbBackground.Clear();
            sct.ThumbBackground.AddRange(new BackgroundColorBlend[] { 
                new BackgroundColorBlend(factory.GetColor(0xE6E9EC),0f), 
                new BackgroundColorBlend(factory.GetColor(0xE2E4E6),0.6f),
                new BackgroundColorBlend(factory.GetColor(0xC3CAD2),0.6f),
                new BackgroundColorBlend(factory.GetColor(0xD7DCE1),1f)});
            sct.ThumbInnerBorder = new LinearGradientColorTable(factory.GetColor(0xF5F7F8), Color.Empty);
            sct.ThumbOuterBorder = new LinearGradientColorTable(factory.GetColor(0x8C97A5), factory.GetColor(0x65707F));
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0x6E7EA6), factory.GetColor(0x424B63));
            sct.TrackBackground.Clear();
            sct.TrackBackground.AddRange(new BackgroundColorBlend[] {
                new BackgroundColorBlend(factory.GetColor(0x9EBEE9),0f), 
                new BackgroundColorBlend(factory.GetColor(0xABCCF6),0.5f),
                new BackgroundColorBlend(factory.GetColor(0x6EA6F0),0.5f),
                new BackgroundColorBlend(factory.GetColor(0xB5D1F7),1f)});
            sct.TrackInnerBorder = new LinearGradientColorTable(factory.GetColor(0xC2D3E7), factory.GetColor(0xDDEBFB));
            sct.TrackOuterBorder = new LinearGradientColorTable(factory.GetColor(0x17498A), Color.Empty);
            sct.TrackSignBackground = new LinearGradientColorTable(Color.FromArgb(180, factory.GetColor(0x606060)), Color.FromArgb(64, Color.White));
            // Disabled
            sct = t.ScrollBar.Disabled;
            sct.Background = t.ScrollBar.Default.Background;
            sct.Border = t.ScrollBar.Default.Border;
            sct.ThumbBackground.Clear();
            sct.ThumbInnerBorder = new LinearGradientColorTable();
            sct.ThumbOuterBorder = new LinearGradientColorTable();
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0xBFCFF7), factory.GetColor(0x727C94));
            sct.TrackBackground.Clear();
            sct.TrackInnerBorder = new LinearGradientColorTable();
            sct.TrackOuterBorder = new LinearGradientColorTable();
            sct.TrackSignBackground = new LinearGradientColorTable();
        }
        #endregion

        public static void InitializeColorTable(Office2007ColorTable t, ColorFactory factory)
        {
            #region Ribbon Bar
            t.RibbonBar.Default = GetRibbonBar(factory);
            t.RibbonBar.MouseOver = GetRibbonBarMouseOver(factory);
            t.RibbonBar.Expanded = GetRibbonBarExpanded(factory);
            #endregion

            #region RibbonTabItem
            // RibbonTabItem Default
            t.RibbonTabItemColors.Clear();
            Office2007RibbonTabItemColorTable rt = GetRibbonTabItemDefault(factory);
            rt.Name = Enum.GetName(typeof(RibbonTabColor), RibbonTabColor.Default);
            t.RibbonTabItemColors.Add(rt);
            // Green

            rt = GetRibbonTabItemGreen(factory);
            rt.Name = Enum.GetName(typeof(RibbonTabColor), RibbonTabColor.Green);
            t.RibbonTabItemColors.Add(rt);
            // Magenta

            rt = GetRibbonTabItemMagenta(factory);
            rt.Name = Enum.GetName(typeof(RibbonTabColor), RibbonTabColor.Magenta);
            t.RibbonTabItemColors.Add(rt);
            // Orange

            rt = GetRibbonTabItemOrange(factory);
            rt.Name = Enum.GetName(typeof(RibbonTabColor), RibbonTabColor.Orange);
            t.RibbonTabItemColors.Add(rt);
            #endregion

            #region Ribbon Control
            t.RibbonControl = new Office2007RibbonColorTable();
            t.RibbonControl.TabsBackground = new LinearGradientColorTable(factory.GetColor(0xD0D4DD), factory.GetColor(0xD0D4DD));
            t.RibbonControl.InnerBorder = new LinearGradientColorTable(); //factory.GetColor(0xD7DADF), factory.GetColor(0x3A3A3A));
            t.RibbonControl.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xBEBEBE), factory.GetColor(0xBEBEBE));
            t.RibbonControl.TabDividerBorder = factory.GetColor(0xACAFB7);
            t.RibbonControl.TabDividerBorderLight = Color.Empty; // factory.GetColor(0x666666);
            t.RibbonControl.PanelTopBackground = new LinearGradientColorTable(factory.GetColor(0xEEF0F4), factory.GetColor(0xE1E6EE));
            t.RibbonControl.PanelBottomBackground = new LinearGradientColorTable(factory.GetColor(0xD5DBE7), factory.GetColor(0xF0FAFB));
            t.RibbonControl.StartButtonDefault = BarFunctions.LoadBitmap("SystemImages.BlankStartButtonNormalSilver.png");
            t.RibbonControl.StartButtonMouseOver = BarFunctions.LoadBitmap("SystemImages.BlankStartButtonHotSilver.png");
            t.RibbonControl.StartButtonPressed = BarFunctions.LoadBitmap("SystemImages.BlankStartButtonPressedSilver.png");
            #endregion

            #region ItemContainer
            t.ItemGroup.TopBackground = new LinearGradientColorTable(factory.GetColor(0xF1F3F3), factory.GetColor(0xF0F2F2));
            t.ItemGroup.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xE7EAEE), factory.GetColor(0xF6F7F8));
            t.ItemGroup.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xF9F9F9), factory.GetColor(0xFFFFFF));
            t.ItemGroup.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xC5C6C7), factory.GetColor(0xC4C6C6));
            t.ItemGroup.ItemGroupDividerDark = Color.FromArgb(196, factory.GetColor(0xCECECE));
            t.ItemGroup.ItemGroupDividerLight = Color.FromArgb(128, factory.GetColor(0xFFFFFF));
            #endregion

            #region Bar
            t.Bar.ToolbarTopBackground = new LinearGradientColorTable(factory.GetColor(0xE7E8EB), factory.GetColor(0xB5BBC7));
            t.Bar.ToolbarBottomBackground = new LinearGradientColorTable(factory.GetColor(0xA9AFB6), factory.GetColor(0xC7C9CE));
            t.Bar.ToolbarBottomBorder = factory.GetColor(0x727880);
            t.Bar.PopupToolbarBackground = new LinearGradientColorTable(factory.GetColor(0xFAFAFA), Color.Empty);
            t.Bar.PopupToolbarBorder = factory.GetColor(0x2F2F2F);
            t.Bar.StatusBarTopBorder = factory.GetColor(0xACAFB7);
            t.Bar.StatusBarTopBorderLight = factory.GetColor(Color.FromArgb(148, Color.White));
            t.Bar.StatusBarAltBackground.Clear();
            t.Bar.StatusBarAltBackground.Add(new BackgroundColorBlend(factory.GetColor(0xE7E8EB), 0f));
            t.Bar.StatusBarAltBackground.Add(new BackgroundColorBlend(factory.GetColor(0xB6BBC7), 0.4f));
            t.Bar.StatusBarAltBackground.Add(new BackgroundColorBlend(factory.GetColor(0xA5ABAF), 0.4f));
            t.Bar.StatusBarAltBackground.Add(new BackgroundColorBlend(factory.GetColor(0xAEB4BA), 1f));
            #endregion

            #region ButtonItem Colors Initialization
            t.ButtonItemColors.Clear();
            t.RibbonButtonItemColors.Clear();
            t.MenuButtonItemColors.Clear();
            // Orange
            Office2007ButtonItemColorTable cb = GetButtonItemOrange(false, factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.Orange);
            t.ButtonItemColors.Add(cb);
            // Orange with background
            cb = GetButtonItemOrangeWithBackground(factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.OrangeWithBackground);
            t.ButtonItemColors.Add(cb);
            // Blue
            cb = GetButtonItemBlue(false, factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.Blue);
            t.ButtonItemColors.Add(cb);
            // Blue with background
            cb = GetButtonItemBlueWithBackground(factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.BlueWithBackground);
            t.ButtonItemColors.Add(cb);
            // Magenta
            cb = GetButtonItemMagenta(false, factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.Magenta);
            t.ButtonItemColors.Add(cb);
            // Magenta with background
            cb = GetButtonItemMagentaWithBackground(factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.MagentaWithBackground);
            t.ButtonItemColors.Add(cb);

            // RibbonBar buttons
            cb = GetButtonItemOrange(true, factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.Orange);
            t.RibbonButtonItemColors.Add(cb);
            // Orange with background
            cb = GetButtonItemOrangeWithBackground(factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.OrangeWithBackground);
            t.RibbonButtonItemColors.Add(cb);
            // Blue
            cb = GetButtonItemBlue(true, factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.Blue);
            t.RibbonButtonItemColors.Add(cb);
            // Blue with background
            cb = GetButtonItemBlueWithBackground(factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.BlueWithBackground);
            t.RibbonButtonItemColors.Add(cb);
            // Magenta
            cb = GetButtonItemMagenta(true, factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.Magenta);
            t.RibbonButtonItemColors.Add(cb);
            // Magenta with background
            cb = GetButtonItemMagentaWithBackground(factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.MagentaWithBackground);
            t.RibbonButtonItemColors.Add(cb);

            // MENU Orange
            cb = Office2007ColorTableFactory.GetButtonItemBlackOrange(true, factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.Orange);
            cb.Default.Text = factory.GetColor(0x333333);
            cb.MouseOver.Text = factory.GetColor(0x333333);
            cb.Checked.Text = factory.GetColor(0x333333);
            cb.Expanded.Text = factory.GetColor(0x333333);
            cb.Pressed.Text = factory.GetColor(0x333333);
            t.MenuButtonItemColors.Add(cb);

            cb = Office2007ColorTableFactory.GetButtonItemOffice2007WithBackground(factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.Office2007WithBackground);
            t.ButtonItemColors.Add(cb);
            #endregion

            #region RibbonTabItemGroup Colors Initialization
            t.RibbonTabGroupColors.Clear();
            // Default
            Office2007RibbonTabGroupColorTable tg = GetRibbonTabGroupDefault(factory);
            tg.Name = Enum.GetName(typeof(eRibbonTabGroupColor), eRibbonTabGroupColor.Default);
            t.RibbonTabGroupColors.Add(tg);

            // Magenta
            tg = GetRibbonTabGroupMagenta(factory);
            tg.Name = Enum.GetName(typeof(eRibbonTabGroupColor), eRibbonTabGroupColor.Magenta);
            t.RibbonTabGroupColors.Add(tg);

            // Green
            tg = GetRibbonTabGroupGreen(factory);
            tg.Name = Enum.GetName(typeof(eRibbonTabGroupColor), eRibbonTabGroupColor.Green);
            t.RibbonTabGroupColors.Add(tg);

            // Orange
            tg = GetRibbonTabGroupOrange(factory);
            tg.Name = Enum.GetName(typeof(eRibbonTabGroupColor), eRibbonTabGroupColor.Orange);
            t.RibbonTabGroupColors.Add(tg);
            #endregion

            #region Menu
            t.Menu.Background = new LinearGradientColorTable(factory.GetColor(0xFAFAFA), Color.Empty);
            t.Menu.Border = new LinearGradientColorTable(factory.GetColor(0x868686), Color.Empty);
            t.Menu.Side = new LinearGradientColorTable(factory.GetColor(0xEFEFEF), Color.Empty);
            t.Menu.SideBorder = new LinearGradientColorTable(factory.GetColor(0xC5C5C5), Color.Empty);
            t.Menu.SideBorderLight = new LinearGradientColorTable(factory.GetColor(0xF5F5F5), Color.Empty);
            t.Menu.SideUnused = new LinearGradientColorTable(factory.GetColor(0xE5E5E5), Color.Empty);

            t.Menu.FileBackgroundBlend.Clear();
            t.Menu.FileBackgroundBlend.AddRange(new HVTT.UI.Window.Forms.BackgroundColorBlend[] {
                new HVTT.UI.Window.Forms.BackgroundColorBlend(factory.GetColor(0xDEE2E5), 0F),
                new HVTT.UI.Window.Forms.BackgroundColorBlend(factory.GetColor(0xD2D7DC), 1F)});
            t.Menu.FileContainerBorder = factory.GetColor(0xA9AEB4);
            t.Menu.FileContainerBorderLight = factory.GetColor(0xF3F4F4);
            t.Menu.FileColumnOneBackground = factory.GetColor(0xFAFAFA);
            t.Menu.FileColumnOneBorder = factory.GetColor(0xA9AEB4);
            t.Menu.FileColumnTwoBackground = factory.GetColor(0xFAFAFA);
            t.Menu.FileBottomContainerBackgroundBlend.Clear();
            t.Menu.FileBottomContainerBackgroundBlend.AddRange(new HVTT.UI.Window.Forms.BackgroundColorBlend[] {
                new HVTT.UI.Window.Forms.BackgroundColorBlend(factory.GetColor(0xCAD0D7), 0F),
                new HVTT.UI.Window.Forms.BackgroundColorBlend(factory.GetColor(0xCCD1D8), 0.4F),
                new HVTT.UI.Window.Forms.BackgroundColorBlend(factory.GetColor(0xC2C8D0), 0.4F),
                new HVTT.UI.Window.Forms.BackgroundColorBlend(factory.GetColor(0xD9E2E6), 1F)});
            #endregion

            #region ComboBox
            t.ComboBox.Default.Background = factory.GetColor(0xE8EAEC);
            t.ComboBox.Default.Border = factory.GetColor(0xA9B1B8);
            t.ComboBox.Default.ExpandBackground = new LinearGradientColorTable();
            t.ComboBox.Default.ExpandBorderInner = new LinearGradientColorTable();
            t.ComboBox.Default.ExpandBorderOuter = new LinearGradientColorTable();
            t.ComboBox.Default.ExpandText = factory.GetColor(0x7C7C7C);
            t.ComboBox.DefaultStandalone.Background = factory.GetColor(0xFFFFFF);
            t.ComboBox.DefaultStandalone.Border = factory.GetColor(0xA4A4A4);
            t.ComboBox.DefaultStandalone.ExpandBackground = new LinearGradientColorTable(factory.GetColor(0xECF0F5), factory.GetColor(0xDFE4EB), 90);
            t.ComboBox.DefaultStandalone.ExpandBorderInner = new LinearGradientColorTable();
            t.ComboBox.DefaultStandalone.ExpandBorderOuter = new LinearGradientColorTable(factory.GetColor(0xB7B7B7), Color.Empty, 90);
            t.ComboBox.DefaultStandalone.ExpandText = factory.GetColor(0x7C7C7C);
            t.ComboBox.MouseOver.Background = factory.GetColor(0xFFFFFF);
            t.ComboBox.MouseOver.Border = factory.GetColor(0xA4A4A4);
            t.ComboBox.MouseOver.ExpandBackground = new LinearGradientColorTable(factory.GetColor(0xFFFCE2), factory.GetColor(0xFFE7A5), 90);
            t.ComboBox.MouseOver.ExpandBorderInner = new LinearGradientColorTable(factory.GetColor(0xFFFFFB), factory.GetColor(0xFFFCF3), 90);
            t.ComboBox.MouseOver.ExpandBorderOuter = new LinearGradientColorTable(factory.GetColor(0xDBCE99), Color.Empty, 90);
            t.ComboBox.MouseOver.ExpandText = factory.GetColor(0x567DB1);
            t.ComboBox.DroppedDown.Background = factory.GetColor(0xFFFFFF);
            t.ComboBox.DroppedDown.Border = factory.GetColor(0x898989);
            t.ComboBox.DroppedDown.ExpandBackground = new LinearGradientColorTable(factory.GetColor(0xEAE0BF), factory.GetColor(0xFFD456), 90);
            t.ComboBox.DroppedDown.ExpandBorderInner = new LinearGradientColorTable(factory.GetColor(0xF1EBD5), factory.GetColor(0xFFE694), 90);
            t.ComboBox.DroppedDown.ExpandBorderOuter = new LinearGradientColorTable(factory.GetColor(0x9A8F63), Color.Empty, 90);
            t.ComboBox.DroppedDown.ExpandText = factory.GetColor(0x567DB1);
            #endregion

            #region Dialog Launcher
            t.DialogLauncher.Default.DialogLauncher = factory.GetColor(0x656870);
            t.DialogLauncher.Default.DialogLauncherShade = factory.GetColor(0xEBEBEB);

            t.DialogLauncher.MouseOver.DialogLauncher = factory.GetColor(0x656870);
            t.DialogLauncher.MouseOver.DialogLauncherShade = factory.GetColor(0xEBEBEB);
            t.DialogLauncher.MouseOver.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFFFCDF), factory.GetColor(0xFFEFA7));
            t.DialogLauncher.MouseOver.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFFD975), factory.GetColor(0xFFE398));
            t.DialogLauncher.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFFFFFB), factory.GetColor(0xFFFBF2));
            t.DialogLauncher.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xDBCE99), Color.Empty);

            t.DialogLauncher.Pressed.DialogLauncher = factory.GetColor(0x656870);
            t.DialogLauncher.Pressed.DialogLauncherShade = factory.GetColor(0xEBEBEB);
            t.DialogLauncher.Pressed.TopBackground = new LinearGradientColorTable(factory.GetColor(0xE8DEBD), factory.GetColor(0xEAC68D));
            t.DialogLauncher.Pressed.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFFA738), factory.GetColor(0xFFCC4E));
            t.DialogLauncher.Pressed.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xF0EAD4), factory.GetColor(0xFFE391));
            t.DialogLauncher.Pressed.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x9A8F63), factory.GetColor(0xB0A472));
            #endregion

            #region Legacy Color Scheme
            InitializeBlackLegacyColors(t.LegacyColors, factory);
            #endregion

            #region System Button, Form

            // Default state no background
            t.SystemButton.Default = new Office2007SystemButtonStateColorTable();
            t.SystemButton.Default.Foreground = new LinearGradientColorTable(factory.GetColor(0x6D7989), factory.GetColor(0x8899B1));
            t.SystemButton.Default.LightShade = factory.GetColor(0xFDFDFF);
            t.SystemButton.Default.DarkShade = factory.GetColor(0x454545);

            // Mouse over state
            t.SystemButton.MouseOver = new Office2007SystemButtonStateColorTable();
            t.SystemButton.MouseOver.Foreground = new LinearGradientColorTable(factory.GetColor(0x6D7989), factory.GetColor(0x8899B1));
            t.SystemButton.MouseOver.LightShade = factory.GetColor(0xFDFDFF);
            t.SystemButton.MouseOver.DarkShade = factory.GetColor(0x454545);
            t.SystemButton.MouseOver.TopBackground = new LinearGradientColorTable(factory.GetColor(0xF7F9FB), factory.GetColor(0xF1F5FA));
            t.SystemButton.MouseOver.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xE3EAF4), factory.GetColor(0xE2E8F2));
            t.SystemButton.MouseOver.TopHighlight = new LinearGradientColorTable(factory.GetColor(0xFBFBFD), Color.Transparent);
            t.SystemButton.MouseOver.BottomHighlight = new LinearGradientColorTable(factory.GetColor(0xF9FAFC), Color.Transparent);
            t.SystemButton.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xC8CDD4), factory.GetColor(0xB9C2D0));
            t.SystemButton.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFEFEFF), factory.GetColor(0xFCFDFE));

            // Pressed
            t.SystemButton.Pressed = new Office2007SystemButtonStateColorTable();
            t.SystemButton.Pressed.Foreground = new LinearGradientColorTable(factory.GetColor(0x6D7989), factory.GetColor(0x8899B1));
            t.SystemButton.Pressed.LightShade = factory.GetColor(0xFDFDFF);
            t.SystemButton.Pressed.DarkShade = factory.GetColor(0x454545);
            t.SystemButton.Pressed.TopBackground = new LinearGradientColorTable(factory.GetColor(0xCACED3), factory.GetColor(0xAAAFB6));
            t.SystemButton.Pressed.TopHighlight = new LinearGradientColorTable(factory.GetColor(0xE4E7EA), Color.Transparent);
            t.SystemButton.Pressed.BottomBackground = new LinearGradientColorTable(factory.GetColor(0x899097), factory.GetColor(0xC3CDD4));
            t.SystemButton.Pressed.BottomHighlight = new LinearGradientColorTable(factory.GetColor(0xD5E2E9), Color.Transparent);
            t.SystemButton.Pressed.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x979CA0), factory.GetColor(0xADB2B8));
            t.SystemButton.Pressed.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xEEF1F5), factory.GetColor(0xFBFDFF));

            // Form border
            t.Form.Active.BorderColors = new Color[] {
                factory.GetColor(0x727880),
                factory.GetColor(0xDEDDDE),
                factory.GetColor(0xBBBABA),
                factory.GetColor(0xDEDDDE)};
            t.Form.Inactive.BorderColors = new Color[] {
                factory.GetColor(0xB4B9C1),
                factory.GetColor(0xF0F0F0),
                factory.GetColor(0xE0E0E0),
                factory.GetColor(0xE6E5E5)};


            // Form Caption Active
            t.Form.Active.CaptionTopBackground = new LinearGradientColorTable(factory.GetColor(0xE7E8EB), factory.GetColor(0xCACDD1));
            t.Form.Active.CaptionBottomBackground = new LinearGradientColorTable(factory.GetColor(0xBAC1CA), factory.GetColor(0xE9EEF7));
            t.Form.Active.CaptionText = factory.GetColor(0x4D5259);
            t.Form.Active.CaptionTextExtra = factory.GetColor(0x356EB1);

            // Form Caption Inactive
            t.Form.Inactive.CaptionTopBackground = new LinearGradientColorTable(factory.GetColor(0xEEEFF0), factory.GetColor(0xE5E6E8));
            t.Form.Inactive.CaptionBottomBackground = new LinearGradientColorTable(factory.GetColor(0xDDE0E5), factory.GetColor(0xF4F7FB));
            t.Form.Inactive.CaptionText = factory.GetColor(0x444444);
            t.Form.Inactive.CaptionTextExtra = factory.GetColor(0x444444);

            t.Form.BackColor = factory.GetColor(0xCACDD6);
            t.Form.TextColor = factory.GetColor(0x000000);
            #endregion

            #region Quick Access Toolbar Background
            t.QuickAccessToolbar.Active.TopBackground = new LinearGradientColorTable(factory.GetColor(0xD7D9DB), factory.GetColor(0xDEDFE2));
            t.QuickAccessToolbar.Active.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xD2D7DD), factory.GetColor(0xDADCE0));
            t.QuickAccessToolbar.Active.OutterBorderColor = Color.Empty; // factory.GetColor(0xAEAEB0);
            t.QuickAccessToolbar.Active.MiddleBorderColor = factory.GetColor(0xAEAEB0);
            t.QuickAccessToolbar.Active.InnerBorderColor = Color.Empty;

            t.QuickAccessToolbar.Inactive.TopBackground = new LinearGradientColorTable(factory.GetColor(0xE7E7E8), factory.GetColor(0xEEEFF0));
            t.QuickAccessToolbar.Inactive.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xE8EAED), factory.GetColor(0xD9DADC));
            t.QuickAccessToolbar.Inactive.OutterBorderColor = Color.Empty; // factory.GetColor(0xCECECF);
            t.QuickAccessToolbar.Inactive.MiddleBorderColor = factory.GetColor(0xB1B1B2);
            t.QuickAccessToolbar.Inactive.InnerBorderColor = Color.Empty;

            t.QuickAccessToolbar.Standalone.TopBackground = new LinearGradientColorTable();
            t.QuickAccessToolbar.Standalone.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xD9DEE6), factory.GetColor(0xD6DBE3));
            t.QuickAccessToolbar.Standalone.OutterBorderColor = factory.GetColor(0xC2C9D4);
            t.QuickAccessToolbar.Standalone.MiddleBorderColor = Color.Empty;
            t.QuickAccessToolbar.Standalone.InnerBorderColor = factory.GetColor(0xEDEFF3);

            t.QuickAccessToolbar.QatCustomizeMenuLabelBackground = factory.GetColor(0xEBEBEB);
            t.QuickAccessToolbar.QatCustomizeMenuLabelText = factory.GetColor(0x4C535C);

            t.QuickAccessToolbar.Active.GlassBorder = new LinearGradientColorTable(factory.GetColor(Color.FromArgb(132, Color.Black)), Color.FromArgb(80, Color.Black));
            t.QuickAccessToolbar.Inactive.GlassBorder = new LinearGradientColorTable(factory.GetColor(Color.FromArgb(132, Color.Black)), Color.FromArgb(80, Color.Black));
            #endregion

            #region Tab Colors
            t.TabControl.Default = new Office2007TabItemStateColorTable();
            t.TabControl.Default.TopBackground = new LinearGradientColorTable(factory.GetColor(0xDCE0E5), factory.GetColor(0xD8DDE2));
            t.TabControl.Default.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xC3C3C3), factory.GetColor(0xDFDFDF));
            t.TabControl.Default.InnerBorder = factory.GetColor(0xEDF3F4);
            t.TabControl.Default.OuterBorder = factory.GetColor(0x6F7074);
            t.TabControl.Default.Text = factory.GetColor(0x000000);

            t.TabControl.MouseOver = new Office2007TabItemStateColorTable();
            t.TabControl.MouseOver.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFFFDEB), factory.GetColor(0xFFECA8));
            t.TabControl.MouseOver.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFFDA59), factory.GetColor(0xFFE68D));
            t.TabControl.MouseOver.InnerBorder = factory.GetColor(0xFFFFFB);
            t.TabControl.MouseOver.OuterBorder = factory.GetColor(0xB69D73);
            t.TabControl.MouseOver.Text = factory.GetColor(0x000000);

            t.TabControl.Selected = new Office2007TabItemStateColorTable();
            t.TabControl.Selected.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFFD29B), factory.GetColor(0xFFBB6E));
            t.TabControl.Selected.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFFAF44), factory.GetColor(0xFEDC75));
            t.TabControl.Selected.InnerBorder = factory.GetColor(0xCDB69C);
            t.TabControl.Selected.OuterBorder = factory.GetColor(0x95774A);
            t.TabControl.Selected.Text = factory.GetColor(0x000000);

            t.TabControl.TabBackground = new LinearGradientColorTable(factory.GetColor(0xC7CAD3), factory.GetColor(0xC7CAD3));
            t.TabControl.TabPanelBackground = new LinearGradientColorTable(factory.GetColor(0xE8EAEE), factory.GetColor(0xD4D7E0));
            t.TabControl.TabPanelBorder = factory.GetColor(0x6F7074);
            #endregion

            #region CheckBoxItem
            Office2007CheckBoxColorTable chk = t.CheckBoxItem;
            chk.Default.CheckBackground = new LinearGradientColorTable(factory.GetColor(0xF4F4F4), Color.Empty);
            chk.Default.CheckBorder = factory.GetColor(0x9B9DA0);
            chk.Default.CheckInnerBackground = new LinearGradientColorTable(Color.FromArgb(192, factory.GetColor(0xCACFD5)), Color.FromArgb(164, factory.GetColor(0xF6F6F6)));
            chk.Default.CheckInnerBorder = factory.GetColor(0xA2ACB9);
            chk.Default.CheckSign = new LinearGradientColorTable(factory.GetColor(0x4F6B88), Color.Empty);
            chk.Default.Text = factory.GetColor(0x333333);

            chk.MouseOver.CheckBackground = new LinearGradientColorTable(factory.GetColor(0xF4F4F4), Color.Empty);
            chk.MouseOver.CheckBorder = factory.GetColor(0x9B9DA0);
            chk.MouseOver.CheckInnerBackground = new LinearGradientColorTable(Color.FromArgb(192, factory.GetColor(0xFCE7AF)), Color.FromArgb(128, factory.GetColor(0xFEF8E7)));
            chk.MouseOver.CheckInnerBorder = factory.GetColor(0xFAD57A);
            chk.MouseOver.CheckSign = new LinearGradientColorTable(factory.GetColor(0x4F6B88), Color.Empty);
            chk.MouseOver.Text = factory.GetColor(0x333333);

            chk.Pressed.CheckBackground = new LinearGradientColorTable(factory.GetColor(0xE5ECF7), Color.Empty);
            chk.Pressed.CheckBorder = factory.GetColor(0x9B9DA0);
            chk.Pressed.CheckInnerBackground = new LinearGradientColorTable(Color.FromArgb(192, factory.GetColor(0xFFD067)), Color.FromArgb(164, factory.GetColor(0xFFF4D5)));
            chk.Pressed.CheckInnerBorder = factory.GetColor(0xF28926);
            chk.Pressed.CheckSign = new LinearGradientColorTable(factory.GetColor(0x4F6B88), Color.Empty);
            chk.Pressed.Text = factory.GetColor(0x333333);

            chk.Disabled.CheckBackground = new LinearGradientColorTable(factory.GetColor(0xFFFFFF), Color.Empty);
            chk.Disabled.CheckBorder = factory.GetColor(0xD5D8DB);
            chk.Disabled.CheckInnerBackground = new LinearGradientColorTable(Color.FromArgb(192, factory.GetColor(0xEEF0F2)), Color.FromArgb(164, factory.GetColor(0xFBFBFB)));
            chk.Disabled.CheckInnerBorder = factory.GetColor(0xE0E2E5);
            chk.Disabled.CheckSign = new LinearGradientColorTable(factory.GetColor(0x8D8D8D), Color.Empty);
            chk.Disabled.Text = factory.GetColor(0x8D8D8D);
            #endregion

            #region Scroll Bar
            InitializeScrollBarColorTable(t, factory);
            Office2007ColorTableFactory.InitializeAppSilverScrollBarColorTable(t, factory);
            #endregion

            #region ProgressBarItem
            Office2007ProgressBarColorTable pct = t.ProgressBarItem;
            pct.BackgroundColors = new GradientColorTable(0xC6CBD5, 0xE0E4ED);
            pct.OuterBorder = factory.GetColor(0xF8FBFF);
            pct.InnerBorder = factory.GetColor(0xC0C0C0);
            pct.Chunk = new GradientColorTable(0x649021, 0xE5FCBC, 0);
            pct.ChunkOverlay = new GradientColorTable();
            pct.ChunkOverlay.LinearGradientAngle = 90;
            pct.ChunkOverlay.Colors.AddRange(new BackgroundColorBlend[] {
                new BackgroundColorBlend(Color.FromArgb(164, factory.GetColor(0xD8E6C3)), 0f),
                new BackgroundColorBlend(Color.FromArgb(128, factory.GetColor(0x88B048)), .5f),
                new BackgroundColorBlend(Color.FromArgb(64, factory.GetColor(0x6A9D1F)), .5f),
                new BackgroundColorBlend(Color.Transparent, 1f),
            });
            pct.ChunkShadow = new GradientColorTable(0xB2B9C8, 0xD5DAE5, 0);

            // Paused State
            pct = t.ProgressBarItemPaused;
            pct.BackgroundColors = new GradientColorTable(0xC6CBD5, 0xE0E4ED);
            pct.OuterBorder = factory.GetColor(0xF8FBFF);
            pct.InnerBorder = factory.GetColor(0xC0C0C0);
            pct.Chunk = new GradientColorTable(0xAEA700, 0xFFFDCD, 0);
            pct.ChunkOverlay = new GradientColorTable();
            pct.ChunkOverlay.LinearGradientAngle = 90;
            pct.ChunkOverlay.Colors.AddRange(new BackgroundColorBlend[] {
                new BackgroundColorBlend(Color.FromArgb(192, factory.GetColor(0xFFFBA3)), 0f),
                new BackgroundColorBlend(Color.FromArgb(128, factory.GetColor(0xD2CA00)), .5f),
                new BackgroundColorBlend(Color.FromArgb(64, factory.GetColor(0xFEF400)), .5f),
                new BackgroundColorBlend(Color.Transparent, 1f),
            });
            pct.ChunkShadow = new GradientColorTable(0xB2B9C8, 0xD5DAE5, 0);

            // Error State
            pct = t.ProgressBarItemError;
            pct.BackgroundColors = new GradientColorTable(0xC6CBD5, 0xE0E4ED);
            pct.OuterBorder = factory.GetColor(0xF8FBFF);
            pct.InnerBorder = factory.GetColor(0xC0C0C0);
            pct.Chunk = new GradientColorTable(0xD20000, 0xFFCDCD, 0);
            pct.ChunkOverlay = new GradientColorTable();
            pct.ChunkOverlay.LinearGradientAngle = 90;
            pct.ChunkOverlay.Colors.AddRange(new BackgroundColorBlend[] {
                new BackgroundColorBlend(Color.FromArgb(192, factory.GetColor(0xFF8F8F)), 0f),
                new BackgroundColorBlend(Color.FromArgb(128, factory.GetColor(0xD20000)), .5f),
                new BackgroundColorBlend(Color.FromArgb(64, factory.GetColor(0xFE0000)), .5f),
                new BackgroundColorBlend(Color.Transparent, 1f),
            });
            pct.ChunkShadow = new GradientColorTable(0xB2B9C8, 0xD5DAE5, 0);
            #endregion

            #region Gallery
            Office2007GalleryColorTable gallery = t.Gallery;
            gallery.GroupLabelBackground = factory.GetColor(0xEBEBEB);
            gallery.GroupLabelText = factory.GetColor(0x4C535C);
            gallery.GroupLabelBorder = factory.GetColor(0xC5C5C5);
            #endregion

            #region ListViewEx
            t.ListViewEx.Border = factory.GetColor(0x6F7074);
            t.ListViewEx.ColumnBackground = new LinearGradientColorTable(factory.GetColor(0xFFFFFF), factory.GetColor(0xD4D7DB));
            t.ListViewEx.ColumnSeparator = factory.GetColor(0x6E6D8F);
            t.ListViewEx.SelectionBackground = new LinearGradientColorTable(factory.GetColor(0xA7CDF0), Color.Empty);
            t.ListViewEx.SelectionBorder = factory.GetColor(0xE3EFFF);
            #endregion

            #region Navigation Pane
            t.NavigationPane.ButtonBackground = new GradientColorTable();
            t.NavigationPane.ButtonBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xEBEEFA), 0));
            t.NavigationPane.ButtonBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xD6DAE4), .4f));
            t.NavigationPane.ButtonBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xC5C7D1), .4f));
            t.NavigationPane.ButtonBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xD4D8E2), 1));
            #endregion

            #region SuperTooltip
            t.SuperTooltip.BackgroundColors = new LinearGradientColorTable(factory.GetColor(0xFFFFFF), factory.GetColor(0xE4E4F0));
            t.SuperTooltip.TextColor = factory.GetColor(0x4C4C4C);
            #endregion

            #region Slider
            Office2007SliderColorTable sl = t.Slider;
            sl.Default.LabelColor = factory.GetColor(0x23262A);
            sl.Default.PartBackground = new GradientColorTable();
            sl.Default.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFFFFFF), 0));
            sl.Default.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xF1F1F2), .15f));
            sl.Default.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xBDC0C3), .5f));
            sl.Default.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0x787D85), .5f));
            sl.Default.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xF8F8F9), .85f));
            sl.Default.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFFFFFF), 1f));
            sl.Default.PartBorderColor = factory.GetColor(0x3D434B);
            sl.Default.PartBorderLightColor = Color.FromArgb(28, factory.GetColor(0xFFFFFF));
            sl.Default.PartForeColor = factory.GetColor(0x5F6771);
            sl.Default.PartForeLightColor = Color.FromArgb(168, factory.GetColor(0xEBEBEC));
            sl.Default.TrackLineColor = factory.GetColor(0x252525);
            sl.Default.TrackLineLightColor = factory.GetColor(0xCCCCCC);

            sl.MouseOver.LabelColor = factory.GetColor(0x23262A);
            sl.MouseOver.PartBackground = new GradientColorTable();
            sl.MouseOver.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFFFFFF), 0));
            sl.MouseOver.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFFFDF5), .2f));
            sl.MouseOver.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFFDF83), .5f));
            sl.MouseOver.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xDDA70D), .5f));
            sl.MouseOver.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFFF4CE), .85f));
            sl.MouseOver.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFFF4CE), 1f));
            sl.MouseOver.PartBorderColor = factory.GetColor(0x2F2F2F);
            sl.MouseOver.PartBorderLightColor = Color.FromArgb(28, factory.GetColor(0xFFFFFF));
            sl.MouseOver.PartForeColor = factory.GetColor(0x676249);
            sl.MouseOver.PartForeLightColor = Color.FromArgb(168, factory.GetColor(0xFFFEFB));
            sl.MouseOver.TrackLineColor = factory.GetColor(0x252525);
            sl.MouseOver.TrackLineLightColor = factory.GetColor(0xCCCCCC);

            sl.Pressed.LabelColor = factory.GetColor(0x23262A);
            sl.Pressed.PartBackground = new GradientColorTable();
            sl.Pressed.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xF38622), 0));
            sl.Pressed.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xF2A253), .2f));
            sl.Pressed.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xF9C18B), .5f));
            sl.Pressed.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xF07E10), .5f));
            sl.Pressed.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xF3C69C), .85f));
            sl.Pressed.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFCE0C7), 1f));
            sl.Pressed.PartBorderColor = factory.GetColor(0x2F2F2F);
            sl.Pressed.PartBorderLightColor = Color.FromArgb(28, factory.GetColor(0xFFFFFF));
            sl.Pressed.PartForeColor = factory.GetColor(0x675241);
            sl.Pressed.PartForeLightColor = Color.FromArgb(168, factory.GetColor(0xFFE6CE));
            sl.Pressed.TrackLineColor = factory.GetColor(0x252525);
            sl.Pressed.TrackLineLightColor = factory.GetColor(0xCCCCCC);

            ColorBlendFactory df = new ColorBlendFactory(ColorScheme.GetColor(0xCFCFCF));
            sl.Disabled.LabelColor = factory.GetColor(0x8D8D8D);
            sl.Disabled.PartBackground = new GradientColorTable();
            foreach (BackgroundColorBlend b in sl.Default.PartBackground.Colors)
                sl.Disabled.PartBackground.Colors.Add(new BackgroundColorBlend(df.GetColor(b.Color), b.Position));
            sl.Disabled.PartBorderColor = df.GetColor(sl.Default.PartBorderColor);
            sl.Disabled.PartBorderLightColor = df.GetColor(sl.Default.PartBorderLightColor);
            sl.Disabled.PartForeColor = df.GetColor(sl.Default.PartForeColor);
            sl.Disabled.PartForeLightColor = df.GetColor(sl.Default.PartForeLightColor);
            sl.Disabled.TrackLineColor = df.GetColor(sl.Default.TrackLineColor);
            sl.Disabled.TrackLineLightColor = df.GetColor(sl.Default.TrackLineLightColor);
            #endregion

            #region DataGridView
            t.DataGridView.ColumnHeaderNormalBorder = factory.GetColor(0x909192);
            t.DataGridView.ColumnHeaderNormalBackground = new LinearGradientColorTable(factory.GetColor(0xF1F3F3), factory.GetColor(0xC8C9CA), 90);
            t.DataGridView.ColumnHeaderSelectedBackground = new LinearGradientColorTable(factory.GetColor(0xFFCC99), factory.GetColor(0xFF9B68), 90);
            t.DataGridView.ColumnHeaderSelectedBorder = factory.GetColor(0xD4763D);
            t.DataGridView.ColumnHeaderSelectedMouseOverBackground = new LinearGradientColorTable(factory.GetColor(0xD7D7D7), factory.GetColor(0xA4A4A4), 90);
            t.DataGridView.ColumnHeaderSelectedMouseOverBorder = factory.GetColor(0xD4763D);
            t.DataGridView.ColumnHeaderMouseOverBackground = new LinearGradientColorTable(factory.GetColor(0xD0D0D0), factory.GetColor(0xA6A6A6), 90);
            t.DataGridView.ColumnHeaderMouseOverBorder = factory.GetColor(0x9DA3A9);
            t.DataGridView.ColumnHeaderPressedBackground = new LinearGradientColorTable(factory.GetColor(0xD0D0D0), factory.GetColor(0xA6A6A6), 90);
            t.DataGridView.ColumnHeaderPressedBorder = factory.GetColor(0xFFFFFF);

            t.DataGridView.RowNormalBackground = new LinearGradientColorTable(factory.GetColor(0xE7E7E7));
            t.DataGridView.RowNormalBorder = factory.GetColor(0x909192);
            t.DataGridView.RowSelectedBackground = new LinearGradientColorTable(factory.GetColor(0xF5C795));
            t.DataGridView.RowSelectedBorder = factory.GetColor(0xD4763D);
            t.DataGridView.RowSelectedMouseOverBackground = new LinearGradientColorTable(factory.GetColor(0xED8B4E));
            t.DataGridView.RowSelectedMouseOverBorder = factory.GetColor(0xD4763D);
            t.DataGridView.RowMouseOverBackground = new LinearGradientColorTable(factory.GetColor(0xB8BFC4));
            t.DataGridView.RowMouseOverBorder = factory.GetColor(0x9DA3A9);
            t.DataGridView.RowPressedBackground = new LinearGradientColorTable(factory.GetColor(0xB8BFC4));
            t.DataGridView.RowPressedBorder = factory.GetColor(0xFFFFFF);

            t.DataGridView.GridColor = factory.GetColor(0xD0D7E5);

            t.DataGridView.SelectorBackground = new LinearGradientColorTable(factory.GetColor(0xC6C6C6));
            t.DataGridView.SelectorBorder = factory.GetColor(0x909192);
            t.DataGridView.SelectorBorderDark = factory.GetColor(0xC3C3C3);
            t.DataGridView.SelectorBorderLight = factory.GetColor(0xF9F9F9);
            t.DataGridView.SelectorSign = new LinearGradientColorTable(factory.GetColor(0xFDFDFD), factory.GetColor(0xEFEFEF));

            t.DataGridView.SelectorMouseOverBackground = new LinearGradientColorTable(factory.GetColor(0xA1A1A1));
            t.DataGridView.SelectorMouseOverBorder = factory.GetColor(0x909192);
            t.DataGridView.SelectorMouseOverBorderDark = factory.GetColor(0xC3C3C3);
            t.DataGridView.SelectorMouseOverBorderLight = factory.GetColor(0xF9F9F9);
            t.DataGridView.SelectorMouseOverSign = new LinearGradientColorTable(factory.GetColor(0xFDFDFD), factory.GetColor(0xEFEFEF));
            #endregion

            #region SideBar
            t.SideBar.Background = new LinearGradientColorTable(factory.GetColor(Color.White));
            t.SideBar.Border = factory.GetColor(0x6F7074);
            t.SideBar.SideBarPanelItemText = factory.GetColor(0x333333);
            t.SideBar.SideBarPanelItemDefault = new GradientColorTable();
            t.SideBar.SideBarPanelItemDefault.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xEBEEFA), 0));
            t.SideBar.SideBarPanelItemDefault.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xD6DAE4), .4f));
            t.SideBar.SideBarPanelItemDefault.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xC5C7D1), .4f));
            t.SideBar.SideBarPanelItemDefault.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xD4D8E2), 1));
            // Expanded
            t.SideBar.SideBarPanelItemExpanded = new GradientColorTable();
            t.SideBar.SideBarPanelItemExpanded.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFBDBB5), 0));
            t.SideBar.SideBarPanelItemExpanded.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFEC778), .4f));
            t.SideBar.SideBarPanelItemExpanded.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFEB456), .4f));
            t.SideBar.SideBarPanelItemExpanded.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFDEB9F), 1));
            // MouseOver
            t.SideBar.SideBarPanelItemMouseOver = new GradientColorTable();
            t.SideBar.SideBarPanelItemMouseOver.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFFFCD9), 0));
            t.SideBar.SideBarPanelItemMouseOver.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFFE78D), .4f));
            t.SideBar.SideBarPanelItemMouseOver.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFFD748), .4f));
            t.SideBar.SideBarPanelItemMouseOver.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFFE793), 1));
            // Pressed
            t.SideBar.SideBarPanelItemPressed = new GradientColorTable();
            t.SideBar.SideBarPanelItemPressed.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xF8B869), 0));
            t.SideBar.SideBarPanelItemPressed.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFDA361), .4f));
            t.SideBar.SideBarPanelItemPressed.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFB8A3C), .4f));
            t.SideBar.SideBarPanelItemPressed.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFEBB60), 1));
            #endregion

            #region ElementStyle Classes
            t.StyleClasses.Clear();
            ElementStyle style = new ElementStyle();
            style.Class = ElementStyleClassKeys.RibbonGalleryContainerKey;
            style.BorderColor = factory.GetColor(0xA9B1B8);
            style.Border = StyleBorderType.Solid;
            style.BorderWidth = 1;
            style.CornerDiameter = 2;
            style.CornerType = CornerType.Rounded;
            style.BackColor = factory.GetColor(0xE8EAEC);
            t.StyleClasses.Add(style.Class, style);
            // FileMenuContainer
            style = Office2007ColorTableFactory.GetFileMenuContainerStyle(t);
            t.StyleClasses.Add(style.Class, style);
            // Two Column File Menu Container
            style = Office2007ColorTableFactory.GetTwoColumnMenuContainerStyle(t);
            t.StyleClasses.Add(style.Class, style);
            // Column one File Menu Container
            style = Office2007ColorTableFactory.GetMenuColumnOneContainerStyle(t);
            t.StyleClasses.Add(style.Class, style);
            // Column two File Menu Container
            style = Office2007ColorTableFactory.GetMenuColumnTwoContainerStyle(t);
            t.StyleClasses.Add(style.Class, style);
            // Bottom File Menu Container
            style = Office2007ColorTableFactory.GetMenuBottomContainer(t);
            t.StyleClasses.Add(style.Class, style);
            // TextBox border
            style = Office2007ColorTableFactory.GetTextBoxStyle(factory.GetColor(0xA4A4A4));
            t.StyleClasses.Add(style.Class, style);
            // Ribbon Client Panel
            style = Office2007ColorTableFactory.GetRibbonClientPanelStyle(factory, eOffice2007ColorScheme.Silver);
            t.StyleClasses.Add(style.Class, style);
            // ListView Border
            style = Office2007ColorTableFactory.GetListViewBorderStyle(t.ListViewEx);
            t.StyleClasses.Add(style.Class, style);
            // Status bar alt background
            style = Office2007ColorTableFactory.GetStatusBarAltStyle(t.Bar);
            t.StyleClasses.Add(style.Class, style);
            #endregion
        }

        /// <summary>
        /// Initializes ColorScheme object with the black color scheme.
        /// </summary>
        /// <param name="c">ColorScheme object to initialize.</param>
        public static void InitializeBlackLegacyColors(ColorScheme c, ColorFactory factory)
        {
            c.BarBackground = factory.GetColor(0xF2F2F9);
            c.BarBackground2 = factory.GetColor(0x9997B5);
            c.BarStripeColor = factory.GetColor(0x6E6D8F);
            c.BarCaptionBackground = factory.GetColor(0x7A7999);
            c.BarCaptionBackground2 = factory.GetColor(0x626179);
            c.BarCaptionInactiveBackground = factory.GetColor(0xF6F7F8);
            c.BarCaptionInactiveBackground2 = factory.GetColor(0xDADFE6);
            c.BarCaptionInactiveText = factory.GetColor(0x333333);
            c.BarCaptionText = factory.GetColor(0xFFFFFF);
            c.BarFloatingBorder = factory.GetColor(0x7A7999);
            c.BarPopupBackground = factory.GetColor(0xFDFAFF);
            c.BarPopupBorder = factory.GetColor(0x7A7999);
            c.ItemBackground = Color.Empty;
            c.ItemBackground2 = Color.Empty;
            c.ItemCheckedBackground = factory.GetColor(0xFFCF92);
            c.ItemCheckedBackground2 = factory.GetColor(0xFFAF49);
            c.ItemCheckedBorder = factory.GetColor(0xFFAB3F);
            c.ItemCheckedText = factory.GetColor(0x000000);
            c.ItemDisabledBackground = Color.Empty;
            c.ItemDisabledText = factory.GetColor(0x8D8D8D);
            c.ItemExpandedShadow = Color.Empty;
            c.ItemExpandedBackground = factory.GetColor(0xE8E9F1);
            c.ItemExpandedBackground2 = factory.GetColor(0xBAB9CD);
            c.ItemExpandedText = factory.GetColor(0x000000);
            c.ItemHotBackground = factory.GetColor(0xFFF5CC);
            c.ItemHotBackground2 = factory.GetColor(0xFFDF84);
            c.ItemHotBorder = factory.GetColor(0xFFBD69);
            c.ItemHotText = factory.GetColor(0x000000);
            c.ItemPressedBackground = factory.GetColor(0xFC973D);
            c.ItemPressedBackground2 = factory.GetColor(0xFFB85E);
            c.ItemPressedBorder = factory.GetColor(0xFB8C3C);
            c.ItemPressedText = factory.GetColor(0x000000);
            c.ItemSeparator = Color.FromArgb(225, factory.GetColor(0x6E6D8F));
            c.ItemSeparatorShade = Color.FromArgb(180, factory.GetColor(0xFFFFFF));
            c.ItemText = factory.GetColor(0x000000); // SystemColors.ControlText;
            c.MenuBackground = factory.GetColor(0xFDFAFF);
            c.MenuBackground2 = Color.Empty; // Color.White;
            c.MenuBarBackground = factory.GetColor(0xE5E5EE);
            c.MenuBorder = factory.GetColor(0x7C7C94);
            c.ItemExpandedBorder = c.MenuBorder;
            c.MenuSide = factory.GetColor(0xEFEFEF);
            c.MenuSide2 = Color.Empty; // factory.GetColor(0xDDE0E8);
            c.MenuUnusedBackground = c.MenuBackground;
            c.MenuUnusedSide = factory.GetColor(0xE9E9E9);
            c.MenuUnusedSide2 = Color.Empty;// System.Windows.Forms.ControlPaint.Light(c.MenuSide2);
            c.ItemDesignTimeBorder = Color.Black;
            c.BarDockedBorder = factory.GetColor(0x6F7074);

            c.DockSiteBackColor = factory.GetColor(0xD7D7E5);
            c.DockSiteBackColor2 = factory.GetColor(0xF3F3F7);

            c.CustomizeBackground = factory.GetColor(0xB3B2C8);
            c.CustomizeBackground2 = factory.GetColor(0x767492);
            c.CustomizeText = factory.GetColor(0x000000);

            c.PanelBackground = factory.GetColor(0xF0F1F2);
            c.PanelBackground2 = factory.GetColor(0xBDC2C9);
            c.PanelText = Color.Black;
            c.PanelBorder = factory.GetColor(0x6F7074);

            c.ExplorerBarBackground = factory.GetColor(0xF3F3F7);
            c.ExplorerBarBackground2 = factory.GetColor(0xD7D7E5);
        }
        #endregion
    }
}
