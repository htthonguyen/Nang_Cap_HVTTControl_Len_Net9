using System;
using System.Text;
using System.Drawing;

namespace HVTT.UI.Window.Forms.Rendering
{
    internal class Office2007ColorTableFactory
    {
        #region Luna Blue
        #region ButtonItem Colors Initialization
        public static void SetBlueExpandColors(Office2007ButtonItemColorTable ct, ColorFactory factory)
        {
            Color cb = factory.GetColor(0x567DB1);
            Color cl = factory.GetColor(0xEAF2F9);
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

        public static void SetBlackExpandColors(Office2007ButtonItemColorTable ct, ColorFactory factory)
        {
            Color cb = factory.GetColor(0x464646);
            Color cl = factory.GetColor(0xDBDBDC);
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
        public static Office2007ButtonItemColorTable GetButtonItemBlueOrange(ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = new Office2007ButtonItemColorTable();
            cb.Default = new Office2007ButtonItemStateColorTable();
            cb.Default.Text = factory.GetColor(0x15428B);

            // Button mouse over
            cb.MouseOver = new Office2007ButtonItemStateColorTable();
            cb.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xDDCF9B), factory.GetColor(0xC0A776));
            cb.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFFFFF7), factory.GetColor(0xFFF2BE));
            cb.MouseOver.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFFFCD9), factory.GetColor(0xFFE78D));
            cb.MouseOver.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(192, Color.White), Color.Transparent);
            cb.MouseOver.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFFD748), factory.GetColor(0xFFE793));
            cb.MouseOver.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(132, Color.White), Color.Transparent);
            cb.MouseOver.SplitBorder = new LinearGradientColorTable(factory.GetColor(0xDBC374), factory.GetColor(0xDBC373));
            cb.MouseOver.SplitBorderLight = new LinearGradientColorTable(factory.GetColor(0xFFF0BF), factory.GetColor(0xFFF4D9));
            cb.MouseOver.Text = factory.GetColor(0x15428B);

            // Pressed
            cb.Pressed = new Office2007ButtonItemStateColorTable();
            cb.Pressed.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x5F7FB6), factory.GetColor(0xC4B9A8));
            cb.Pressed.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xB1905D), factory.GetColor(0xFDAD11));
            cb.Pressed.TopBackground = new LinearGradientColorTable(factory.GetColor(0xF8B869), factory.GetColor(0xFDA361));
            cb.Pressed.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            cb.Pressed.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFB8A3C), factory.GetColor(0xFEBB60));
            cb.Pressed.BottomBackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xFFDCA6), Color.Transparent);
            cb.Pressed.SplitBorder = new LinearGradientColorTable(factory.GetColor(0xB07D4B), factory.GetColor(0x907853));
            cb.Pressed.SplitBorderLight = new LinearGradientColorTable(factory.GetColor(0xFAC094), factory.GetColor(0xFFD9AC));
            cb.Pressed.Text = factory.GetColor(0x00156E);

            // Checked
            cb.Checked = new Office2007ButtonItemStateColorTable();
            cb.Checked.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xCBB499), factory.GetColor(0xFFE47F));
            cb.Checked.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xEBD1B4), Color.Transparent);
            cb.Checked.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFBDBB5), factory.GetColor(0xFEC778));
            cb.Checked.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(32, Color.White), Color.Transparent);
            cb.Checked.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFEB456), factory.GetColor(0xFDEB9F));
            cb.Checked.BottomBackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xFDEB9F), Color.Transparent);
            cb.Checked.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Checked.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Checked.Text = factory.GetColor(0x00156E);

            // Expanded button
            cb.Expanded = new Office2007ButtonItemStateColorTable();
            cb.Expanded.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x8E8165), factory.GetColor(0xC6C0B2));
            cb.Expanded.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xE5AE55), factory.GetColor(0xFFCF2D));
            cb.Expanded.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFCD3A7), factory.GetColor(0xFAA85B));
            cb.Expanded.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            cb.Expanded.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xF88E2A), factory.GetColor(0xFBE196));
            cb.Expanded.BottomBackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xFDF1B0), Color.Transparent);
            cb.Expanded.SplitBorder = new LinearGradientColorTable(factory.GetColor(0xB07D4B), factory.GetColor(0x907853));
            cb.Expanded.SplitBorderLight = new LinearGradientColorTable(factory.GetColor(0xFAC094), factory.GetColor(0xFFD9AC));
            cb.Expanded.Text = factory.GetColor(0x00156E);


            //// Menu mouse over
            //cb.MenuMouseOver = new Office2007ButtonItemStateColorTable();
            //cb.MenuMouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xDDCF9B), factory.GetColor(0xC0A776));
            //cb.MenuMouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFFFFFB), factory.GetColor(0xFFFCD1));
            //cb.MenuMouseOver.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFFFCE4), factory.GetColor(0xFFECA1));
            //cb.MenuMouseOver.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(192, Color.White), Color.Transparent);
            //cb.MenuMouseOver.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFFD842), factory.GetColor(0xFFE47B));
            //cb.MenuMouseOver.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(164, Color.White), Color.Transparent);
            //cb.MenuMouseOver.SplitBorder = new LinearGradientColorTable(factory.GetColor(0xDBC374), factory.GetColor(0xC8BB8C));
            //cb.MenuMouseOver.SplitBorderLight = new LinearGradientColorTable(factory.GetColor(0xFFF0BF), factory.GetColor(0xFFF6DF));
            //cb.MenuMouseOver.Text = factory.GetColor(0x15428B);
            SetBlueExpandColors(cb, factory);

            return cb;
        }

        public static Office2007ButtonItemColorTable GetButtonItemBlueOrangeWithBackground(ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = GetButtonItemBlueOrange(factory);
            //cb.Default = new Office2007ButtonItemStateColorTable();
            cb.Default.TopBackground = new LinearGradientColorTable(factory.GetColor(0xE8F1FC), factory.GetColor(0xE9F1FC));
            cb.Default.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xD2E1F4), factory.GetColor(0xEBF3FD));
            cb.Default.BottomBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x7793B9), Color.Empty);
            cb.Default.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            // Same as default
            cb.Disabled = new Office2007ButtonItemStateColorTable();
            cb.Disabled.TopBackground = new LinearGradientColorTable(factory.GetColor(0xE8F1FC), factory.GetColor(0xE9F1FC));
            cb.Disabled.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xD2E1F4), factory.GetColor(0xEBF3FD));
            cb.Disabled.BottomBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x7793B9), Color.Empty);
            cb.Disabled.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            return cb;
        }

        public static Office2007ButtonItemColorTable GetButtonItemBlueBlue(ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = new Office2007ButtonItemColorTable();
            cb.Default = new Office2007ButtonItemStateColorTable();
            cb.Default.Text = factory.GetColor(0x15428B);

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
            cb.MouseOver.Text = factory.GetColor(0x15428B);

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
            cb.Pressed.Text = factory.GetColor(0x00156E);

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
            cb.Checked.Text = factory.GetColor(0x00156E);

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
            cb.Expanded.Text = factory.GetColor(0x00156E);


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
            SetBlueExpandColors(cb, factory);

            return cb;
        }

        public static Office2007ButtonItemColorTable GetButtonItemBlueBlueWithBackground(ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = GetButtonItemBlueBlue(factory);
            //cb.Default = new Office2007ButtonItemStateColorTable();
            //cb.Default = new Office2007ButtonItemStateColorTable();
            cb.Default.TopBackground = new LinearGradientColorTable(factory.GetColor(0xE8F1FC), factory.GetColor(0xE9F1FC));
            cb.Default.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xD2E1F4), factory.GetColor(0xEBF3FD));
            cb.Default.BottomBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x7793B9), Color.Empty);
            cb.Default.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            // Same as default
            cb.Disabled = new Office2007ButtonItemStateColorTable();
            cb.Disabled.TopBackground = new LinearGradientColorTable(factory.GetColor(0xE8F1FC), factory.GetColor(0xE9F1FC));
            cb.Disabled.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xD2E1F4), factory.GetColor(0xEBF3FD));
            cb.Disabled.BottomBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x7793B9), Color.Empty);
            cb.Disabled.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            return cb;
        }

        public static Office2007ButtonItemColorTable GetButtonItemBlueMagenta(ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = new Office2007ButtonItemColorTable();
            cb.Default = new Office2007ButtonItemStateColorTable();
            cb.Default.Text = factory.GetColor(0x15428B);

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
            cb.Checked.Text = factory.GetColor(0x00156E);

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
            SetBlueExpandColors(cb, factory);

            return cb;
        }

        public static Office2007ButtonItemColorTable GetButtonItemBlueMagentaWithBackground(ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = GetButtonItemBlueMagenta(factory);
            //cb.Default = new Office2007ButtonItemStateColorTable();
            cb.Default.TopBackground = new LinearGradientColorTable(factory.GetColor(0xE8F1FC), factory.GetColor(0xE9F1FC));
            cb.Default.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xD2E1F4), factory.GetColor(0xEBF3FD));
            cb.Default.BottomBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x7793B9), Color.Empty);
            cb.Default.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            // Same as default
            cb.Disabled = new Office2007ButtonItemStateColorTable();
            cb.Disabled.TopBackground = new LinearGradientColorTable(factory.GetColor(0xE8F1FC), factory.GetColor(0xE9F1FC));
            cb.Disabled.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xD2E1F4), factory.GetColor(0xEBF3FD));
            cb.Disabled.BottomBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x7793B9), Color.Empty);
            cb.Disabled.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            return cb;
        }
        public static Office2007ButtonItemColorTable GetButtonItemOffice2007WithBackground(ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = new Office2007ButtonItemColorTable();
            cb.Default = new Office2007ButtonItemStateColorTable();

            cb.Default.TopBackground = new LinearGradientColorTable(factory.GetColor(0xCBF0FB), factory.GetColor(0x6FBBE5));
            cb.Default.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.BottomBackground = new LinearGradientColorTable(factory.GetColor(0x66B5DF), factory.GetColor(0xA2EDF6));
            cb.Default.BottomBackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xB1FCFF), Color.Empty);
            cb.Default.InnerBorder = new LinearGradientColorTable(Color.White, Color.Empty);
            cb.Default.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x799DB6), Color.Empty);
            cb.Default.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            // Same as default
            cb.Disabled = new Office2007ButtonItemStateColorTable();
            cb.Disabled.TopBackground = new LinearGradientColorTable(factory.GetColor(Color.WhiteSmoke), factory.GetColor(Color.LightGray));
            cb.Disabled.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.BottomBackground = new LinearGradientColorTable(factory.GetColor(Color.Silver), factory.GetColor(0xEBF3FD));
            cb.Disabled.BottomBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.InnerBorder = new LinearGradientColorTable(Color.WhiteSmoke, Color.Empty);
            cb.Disabled.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x799DB6), Color.Empty);
            cb.Disabled.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            cb.MouseOver = new Office2007ButtonItemStateColorTable();
            cb.MouseOver.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFCF9E2), factory.GetColor(0xFBEDBF));
            cb.MouseOver.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.MouseOver.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFAD84A), factory.GetColor(0xFCE595));
            cb.MouseOver.BottomBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.MouseOver.InnerBorder = new LinearGradientColorTable(Color.White, Color.Empty);
            cb.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xBFA779), Color.Empty);
            cb.MouseOver.SplitBorder = new LinearGradientColorTable(factory.GetColor(0xBFA779), Color.Empty);
            cb.MouseOver.SplitBorderLight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Empty);

            cb.Pressed = new Office2007ButtonItemStateColorTable();
            cb.Pressed.TopBackground = new LinearGradientColorTable(factory.GetColor(0xF8BA78), factory.GetColor(0xFCB24E));
            cb.Pressed.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Pressed.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFC9C0F), factory.GetColor(0xFCBA37));
            cb.Pressed.BottomBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Pressed.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xF1A74A), Color.Empty);
            cb.Pressed.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x937D5A), Color.Empty);
            cb.Pressed.SplitBorder = new LinearGradientColorTable(factory.GetColor(0x937D5A), Color.Empty);
            cb.Pressed.SplitBorderLight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Empty);

            cb.Checked = new Office2007ButtonItemStateColorTable();
            cb.Checked.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFCF9E2), factory.GetColor(0xFBEDBF));
            cb.Checked.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Checked.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFAD84A), factory.GetColor(0xFCE595));
            cb.Checked.BottomBackgroundHighlight = new LinearGradientColorTable(Color.White, Color.Empty);
            cb.Checked.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xF1A74A), Color.Empty);
            cb.Checked.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x937D5A), Color.Empty);
            cb.Checked.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Checked.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            cb.Expanded = new Office2007ButtonItemStateColorTable();
            cb.Expanded.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFCBA37), factory.GetColor(0xFC9C0F));
            cb.Expanded.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Expanded.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFCB24E), factory.GetColor(0xF8BA78)); 
            cb.Expanded.BottomBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Expanded.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xF1A74A), Color.Empty);
            cb.Expanded.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x937D5A), Color.Empty);
            cb.Expanded.SplitBorder = new LinearGradientColorTable(factory.GetColor(0x937D5A), Color.Empty);
            cb.Expanded.SplitBorderLight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Empty);
            return cb;
        }
        #endregion

        #region RibbonBar Initialization
        public static Office2007RibbonBarStateColorTable GetRibbonBarBlue(ColorFactory factory)
        {
            Office2007RibbonBarStateColorTable rb = new Office2007RibbonBarStateColorTable();
            rb.TopBackgroundHeight = 15;
            rb.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xC5D2DF), factory.GetColor(0x9EBFDB));
            rb.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xE7EEF7), factory.GetColor(0xF1F7FD));
            rb.TopBackground = new LinearGradientColorTable(factory.GetColor(0xDEE8F5), factory.GetColor(0xD1DFF0));
            rb.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xC7D8ED), factory.GetColor(0xD8E8F5));
            rb.TitleBackground = new LinearGradientColorTable(factory.GetColor(0xC2D8F1), factory.GetColor(0xC0D8EF));
            rb.TitleText = factory.GetColor(0x3E6AAA);
            return rb;
        }

        public static Office2007RibbonBarStateColorTable GetRibbonBarBlueMouseOver(ColorFactory factory)
        {
            Office2007RibbonBarStateColorTable rb = new Office2007RibbonBarStateColorTable();
            rb.TopBackgroundHeight = 15;
            rb.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xADC7DE), factory.GetColor(0x7EADD3));
            rb.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFFFFFF), factory.GetColor(0xFFFFFF));
            rb.TopBackground = new LinearGradientColorTable(factory.GetColor(0xE4EFFD), factory.GetColor(0xE8F0FC));
            rb.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xDCEAFB), factory.GetColor(0xDCE8F8));
            rb.TitleBackground = new LinearGradientColorTable(factory.GetColor(0xC8E0FF), factory.GetColor(0xD6EDFF));
            rb.TitleText = factory.GetColor(0x3E6AB9);

            return rb;
        }

        public static Office2007RibbonBarStateColorTable GetRibbonBarBlueExpanded(ColorFactory factory)
        {
            Office2007RibbonBarStateColorTable rb = new Office2007RibbonBarStateColorTable();
            rb.TopBackgroundHeight = 15;
            rb.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x869BAE), factory.GetColor(0xB1C7D9));
            rb.InnerBorder = new LinearGradientColorTable(Color.FromArgb(32, Color.White), Color.Transparent);
            rb.TopBackground = new LinearGradientColorTable(factory.GetColor(0xADC1DC), factory.GetColor(0x88A7D0));
            rb.BottomBackground = new LinearGradientColorTable(factory.GetColor(0x7699C8), factory.GetColor(0xB4D5FD));
            rb.TitleBackground = new LinearGradientColorTable(factory.GetColor(0xC3D9F2), Color.Empty);
            rb.TitleText = Color.Empty;
            return rb;
        }
        #endregion

        #region RibbonTabItem
        public static Office2007RibbonTabItemColorTable GetRibbonTabItemBlueDefault(ColorFactory factory)
        {
            Office2007RibbonTabItemColorTable rt = new Office2007RibbonTabItemColorTable();
            rt.Default.Text = factory.GetColor(0x15428B);

            // Selected Tab
            rt.Selected = new Office2007RibbonTabItemStateColorTable();
            rt.Selected.Background = new LinearGradientColorTable(factory.GetColor(0xF0F6FE), factory.GetColor(0xDBE6F5));
            rt.Selected.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.Selected.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xF8FBFF), factory.GetColor(0xBFFAFF));
            rt.Selected.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x97B9E6), factory.GetColor(0x8DB2E3));
            rt.Selected.Text = factory.GetColor(0x15428B);

            // Selected Tab Mouse Over
            rt.SelectedMouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.SelectedMouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xEBF3FE), factory.GetColor(0xE1EAF6));
            rt.SelectedMouseOver.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(32, Color.White), Color.Transparent);
            rt.SelectedMouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFAEDC6), factory.GetColor(0xFFFFBD));
            rt.SelectedMouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xD7BC8A), factory.GetColor(0xFED15E));
            rt.SelectedMouseOver.Text = factory.GetColor(0x15428B);

            // Tab Mouse Over
            rt.MouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.MouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xCDDAE0), factory.GetColor(0xE4D097));
            rt.MouseOver.BackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xC4DEFF), Color.Transparent);
            rt.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xDFEDFF), factory.GetColor(0xC7DFFF));
            rt.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x98BBE9), factory.GetColor(0x98BBE9));
            rt.MouseOver.Text = factory.GetColor(0x15428B);

            return rt;
        }

        public static Office2007RibbonTabItemColorTable GetRibbonTabItemBlueMagenta(ColorFactory factory)
        {
            Office2007RibbonTabItemColorTable rt = new Office2007RibbonTabItemColorTable();
            rt.Default.Text = factory.GetColor(0x15428B);
            // Selected Tab
            rt.Selected = new Office2007RibbonTabItemStateColorTable();
            rt.Selected.Background = new LinearGradientColorTable(factory.GetColor(0xD4C8E2), factory.GetColor(0xECE7F2));
            rt.Selected.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.Selected.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xECE7F3), factory.GetColor(0xCDC2DF));
            rt.Selected.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xBEBAC1), factory.GetColor(0xC0BFC1));
            rt.Selected.Text = factory.GetColor(0x15428B);

            // Selected Tab Mouse Over
            rt.SelectedMouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.SelectedMouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xD4C8E2), factory.GetColor(0xECE7F2));
            rt.SelectedMouseOver.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(32, Color.White), Color.Transparent);
            rt.SelectedMouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xECE7F3), factory.GetColor(0xCDC2DF));
            rt.SelectedMouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xBEBAC1), factory.GetColor(0xC0BFC1));
            rt.SelectedMouseOver.Text = factory.GetColor(0x15428B);

            // Tab Mouse Over
            rt.MouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.MouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xC4D5F8), factory.GetColor(0xC2BCE8));
            rt.MouseOver.BackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xDEECFF), Color.Transparent);
            rt.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xE0EEFF), factory.GetColor(0xC7DFFF));
            rt.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xC1C8D1), factory.GetColor(0xC0C7D0));
            rt.MouseOver.Text = factory.GetColor(0x15428B);

            return rt;
        }

        public static Office2007RibbonTabItemColorTable GetRibbonTabItemBlueGreen(ColorFactory factory)
        {
            Office2007RibbonTabItemColorTable rt = new Office2007RibbonTabItemColorTable();
            rt.Default.Text = factory.GetColor(0x15428B);

            // Selected Tab
            rt.Selected = new Office2007RibbonTabItemStateColorTable();
            rt.Selected.Background = new LinearGradientColorTable(factory.GetColor(0xE4F3E0), factory.GetColor(0xE4F2DF));
            rt.Selected.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.Selected.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xD5EAD3), factory.GetColor(0xB8DEB1));
            rt.Selected.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xB9C1B7), factory.GetColor(0xBFC1BE));
            rt.Selected.Text = factory.GetColor(0x15428B);

            // Selected Tab Mouse Over
            rt.SelectedMouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.SelectedMouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xE4F3E0), factory.GetColor(0xE4F2DF));
            rt.SelectedMouseOver.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(32, Color.White), Color.Transparent);
            rt.SelectedMouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xD5EAD3), factory.GetColor(0xB8DEB1));
            rt.SelectedMouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xB9C1B7), factory.GetColor(0xBFC1BE));
            rt.SelectedMouseOver.Text = factory.GetColor(0x15428B);

            // Tab Mouse Over
            rt.MouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.MouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xB3DEE3), factory.GetColor(0x8ADE9F));
            rt.MouseOver.BackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xDEECFF), Color.Transparent);
            rt.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xE2EFFF), factory.GetColor(0xC7DFFF));
            rt.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xC1C8D1), factory.GetColor(0xC0C7D0));
            rt.MouseOver.Text = factory.GetColor(0x15428B);

            return rt;
        }

        public static Office2007RibbonTabItemColorTable GetRibbonTabItemBlueOrange(ColorFactory factory)
        {
            Office2007RibbonTabItemColorTable rt = new Office2007RibbonTabItemColorTable();
            rt.Default.Text = factory.GetColor(0x15428B);

            // Selected Tab
            rt.Selected = new Office2007RibbonTabItemStateColorTable();
            rt.Selected.Background = new LinearGradientColorTable(factory.GetColor(0xFFF59F), factory.GetColor(0xFFFAD5));
            rt.Selected.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.Selected.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFFFBD6), factory.GetColor(0xFDF28C));
            rt.Selected.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xCAC7AC), factory.GetColor(0xC2C2C2));
            rt.Selected.Text = factory.GetColor(0x15428B);

            // Selected Tab Mouse Over
            rt.SelectedMouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.SelectedMouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xFFF59F), factory.GetColor(0xFFFAD5));
            rt.SelectedMouseOver.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(32, Color.White), Color.Transparent);
            rt.SelectedMouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFFFBD6), factory.GetColor(0xFDF28C));
            rt.SelectedMouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xCAC7AC), factory.GetColor(0xC2C2C2));
            rt.SelectedMouseOver.Text = factory.GetColor(0x15428B);

            // Tab Mouse Over
            rt.MouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.MouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xCFE0E1), factory.GetColor(0xE9E799));
            rt.MouseOver.BackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xCBE2FF), Color.Transparent);
            rt.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xE2EFFF), factory.GetColor(0xC7DFFF));
            rt.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xC1C8D1), factory.GetColor(0xC0C7D0));
            rt.MouseOver.Text = factory.GetColor(0x15428B);

            return rt;
        }
        #endregion

        #region RibbonTabItemGroup
        public static Office2007RibbonTabGroupColorTable GetRibbonTabGroupBlueDefault(ColorFactory factory)
        {
            Office2007RibbonTabGroupColorTable tg = new Office2007RibbonTabGroupColorTable();
            tg.Background = new LinearGradientColorTable(Color.Transparent /*factory.GetColor(0xCADBF3)*/, factory.GetColor(0xCDBFD7));
            tg.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, factory.GetColor(0xD068C9)), Color.Transparent);
            tg.Text = factory.GetColor(0x15428B);
            tg.Border = new LinearGradientColorTable(Color.FromArgb(16, Color.DarkGray), Color.FromArgb(192, Color.DarkGray));

            return tg;
        }

        public static Office2007RibbonTabGroupColorTable GetRibbonTabGroupBlueMagenta(ColorFactory factory)
        {
            return GetRibbonTabGroupBlueDefault(factory);
        }

        public static Office2007RibbonTabGroupColorTable GetRibbonTabGroupBlueGreen(ColorFactory factory)
        {
            Office2007RibbonTabGroupColorTable tg = new Office2007RibbonTabGroupColorTable();

            tg.Background = new LinearGradientColorTable(Color.Transparent /*factory.GetColor(0xC8DDF2)*/, factory.GetColor(0xA6E28E));
            tg.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, factory.GetColor(0x6BB954)), Color.Transparent);
            tg.Border = new LinearGradientColorTable(Color.FromArgb(16, Color.DarkGray), Color.FromArgb(192, Color.DarkGray));
            tg.Text = factory.GetColor(0x15428B);

            return tg;
        }

        public static Office2007RibbonTabGroupColorTable GetRibbonTabGroupBlueOrange(ColorFactory factory)
        {
            Office2007RibbonTabGroupColorTable tg = new Office2007RibbonTabGroupColorTable();

            tg.Background = new LinearGradientColorTable(Color.Transparent /*factory.GetColor(0xCDDFF1)*/, factory.GetColor(0xECEFA9));
            tg.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, factory.GetColor(0xFFE619)), Color.Transparent);
            tg.Border = new LinearGradientColorTable(Color.FromArgb(16, Color.DarkGray), Color.FromArgb(192, Color.DarkGray));
            tg.Text = factory.GetColor(0x15428B);

            return tg;
        }
        #endregion

        #endregion

        #region Vista Black

        #region RibbonBar
        public static Office2007RibbonBarStateColorTable GetRibbonBarBlack(ColorFactory factory)
        {
            Office2007RibbonBarStateColorTable rb = new Office2007RibbonBarStateColorTable();
            rb.TopBackgroundHeight = 15;
            rb.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xAEB0B4), factory.GetColor(0x818181));
            rb.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xE9EBEE), factory.GetColor(0xEBEBEB));
            rb.TopBackground = new LinearGradientColorTable(factory.GetColor(0xCED3DA), factory.GetColor(0xC1C6CF));
            rb.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xB4BBC5), factory.GetColor(0xE5ECEC));
            rb.TitleBackground = new LinearGradientColorTable(factory.GetColor(0xB6B8B8), factory.GetColor(0x9C9E9E));
            rb.TitleText = factory.GetColor(0xFFFFFF);
            return rb;
        }

        public static Office2007RibbonBarStateColorTable GetRibbonBarBlackMouseOver(ColorFactory factory)
        {
            Office2007RibbonBarStateColorTable rb = new Office2007RibbonBarStateColorTable();
            rb.TopBackgroundHeight = 15;
            rb.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xAEB0B4), factory.GetColor(0x818181));
            rb.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xF5F6F7), factory.GetColor(0xF1F5F6));
            rb.TopBackground = new LinearGradientColorTable(factory.GetColor(0xECEEF0), factory.GetColor(0xE7E9EC));
            rb.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xE3E5E9), factory.GetColor(0xF4F6F6));
            rb.TitleBackground = new LinearGradientColorTable(factory.GetColor(0xAAABAB), factory.GetColor(0x6D6E6E));
            rb.TitleText = factory.GetColor(0xFFFFFF);

            return rb;
        }

        public static Office2007RibbonBarStateColorTable GetRibbonBarBlackExpanded(ColorFactory factory)
        {
            Office2007RibbonBarStateColorTable rb = new Office2007RibbonBarStateColorTable();
            rb.TopBackgroundHeight = 15;
            rb.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x7C7C7C), factory.GetColor(0xBABABA));
            rb.InnerBorder = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rb.TopBackground = new LinearGradientColorTable(factory.GetColor(0xC0C0C0), factory.GetColor(0xADB1B8));
            rb.BottomBackground = new LinearGradientColorTable(factory.GetColor(0x9EA3AC), factory.GetColor(0xD5D7D8));
            rb.TitleBackground = new LinearGradientColorTable(factory.GetColor(0xC2C2C2), Color.Empty);
            rb.TitleText = Color.Empty;

            return rb;
        }
        #endregion

        #region RibbonTabItem
        public static Office2007RibbonTabItemColorTable GetRibbonTabItemBlackDefault(ColorFactory factory)
        {
            Office2007RibbonTabItemColorTable rt = new Office2007RibbonTabItemColorTable();
            rt.Default.Text = factory.GetColor(0xFFFFFF);

            // Selected Tab
            rt.Selected = new Office2007RibbonTabItemStateColorTable();
            rt.Selected.Background = new LinearGradientColorTable(factory.GetColor(0xEEEEEF), factory.GetColor(0xCED2D9));
            rt.Selected.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.Selected.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xF3F5F5), factory.GetColor(0xB8F6FC));
            rt.Selected.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xBEBEBE), factory.GetColor(0xBEBEBE));
            rt.Selected.Text = factory.GetColor(0x000000);

            // Selected Tab Mouse Over
            rt.SelectedMouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.SelectedMouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xEDEEEF), factory.GetColor(0xCACFD6));
            rt.SelectedMouseOver.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(92, Color.White), Color.Transparent);
            rt.SelectedMouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFAEBC2), factory.GetColor(0xFFFFBD));
            rt.SelectedMouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xE8BB72), factory.GetColor(0xFED15E));
            rt.SelectedMouseOver.Text = factory.GetColor(0x000000);

            // Tab Mouse Over
            rt.MouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.MouseOver.Background = new LinearGradientColorTable(factory.GetColor(0x949392), factory.GetColor(0x8E824F));
            rt.MouseOver.BackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xEDC227), Color.Transparent);
            rt.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0x979695), factory.GetColor(0x93854D));
            rt.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x969695), factory.GetColor(0xB0A986));
            rt.MouseOver.Text = factory.GetColor(0xFFFFFF);

            return rt;
        }

        public static Office2007RibbonTabItemColorTable GetRibbonTabItemBlackMagenta(ColorFactory factory)
        {
            Office2007RibbonTabItemColorTable rt = new Office2007RibbonTabItemColorTable();
            rt.Default.Text = factory.GetColor(0xFFFFFF);
            // Selected Tab
            rt.Selected = new Office2007RibbonTabItemStateColorTable();
            rt.Selected.Background = new LinearGradientColorTable(factory.GetColor(0xD4C8E2), factory.GetColor(0xEBE5F2));
            rt.Selected.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.Selected.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xE1D9EB), factory.GetColor(0xCDC2DF));
            rt.Selected.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xBCB9C1), factory.GetColor(0xC2C2C2));
            rt.Selected.Text = factory.GetColor(0x000000);

            // Selected Tab Mouse Over
            rt.SelectedMouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.SelectedMouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xD4C8E2), factory.GetColor(0xEBE5F2));
            rt.SelectedMouseOver.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.SelectedMouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xC6B6D9), factory.GetColor(0xCDC2DF));
            rt.SelectedMouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xBCB9C1), factory.GetColor(0xC2C2C2));
            rt.SelectedMouseOver.Text = factory.GetColor(0x000000);

            // Tab Mouse Over
            rt.MouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.MouseOver.Background = new LinearGradientColorTable(factory.GetColor(0x8B8D91), factory.GetColor(0x7F7495));
            rt.MouseOver.BackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0x89769D), Color.Transparent);
            rt.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0x8A8B8F), factory.GetColor(0x7F7495));
            rt.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x99989A), factory.GetColor(0xA09EA2));
            rt.MouseOver.Text = factory.GetColor(0xFFFFFF);
            return rt;
        }

        public static Office2007RibbonTabItemColorTable GetRibbonTabItemBlackGreen(ColorFactory factory)
        {
            Office2007RibbonTabItemColorTable rt = new Office2007RibbonTabItemColorTable();
            rt.Default.Text = factory.GetColor(0xFFFFFF);

            // Selected Tab
            rt.Selected = new Office2007RibbonTabItemStateColorTable();
            rt.Selected.Background = new LinearGradientColorTable(factory.GetColor(0xC1E2B8), factory.GetColor(0xE3F1DD));
            rt.Selected.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.Selected.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xE4F3E0), factory.GetColor(0xB8DEB1));
            rt.Selected.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xB0C0AC), factory.GetColor(0xC2C2C2));
            rt.Selected.Text = factory.GetColor(0x000000);

            // Selected Tab Mouse Over
            rt.SelectedMouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xC1E2B8), factory.GetColor(0xE3F1DD));
            rt.SelectedMouseOver.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.SelectedMouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xA4D496), factory.GetColor(0xB8DEB1));
            rt.SelectedMouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xB0C0AC), factory.GetColor(0xC2C2C2));
            rt.SelectedMouseOver.Text = factory.GetColor(0x000000);

            // Tab Mouse Over
            rt.MouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.MouseOver.Background = new LinearGradientColorTable(factory.GetColor(0x899087), factory.GetColor(0x659258));
            rt.MouseOver.BackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0x6C9D5C), Color.Transparent);
            rt.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0x878C86), factory.GetColor(0x659257));
            rt.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x979997), factory.GetColor(0x9DA39B));
            rt.MouseOver.Text = factory.GetColor(0xFFFFFF);
            return rt;
        }

        public static Office2007RibbonTabItemColorTable GetRibbonTabItemBlackOrange(ColorFactory factory)
        {
            Office2007RibbonTabItemColorTable rt = new Office2007RibbonTabItemColorTable();
            rt.Default.Text = factory.GetColor(0xFFFFFF);

            // Selected Tab
            rt.Selected = new Office2007RibbonTabItemStateColorTable();
            rt.Selected.Background = new LinearGradientColorTable(factory.GetColor(0xFFF59F), factory.GetColor(0xFFFAD5));
            rt.Selected.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.Selected.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFFFBD6), factory.GetColor(0xFCF395));
            rt.Selected.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xCAC7AB), factory.GetColor(0xC2C2C2));
            rt.Selected.Text = factory.GetColor(0x000000);

            // Selected Tab Mouse Over
            rt.SelectedMouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.SelectedMouseOver.Background = new LinearGradientColorTable(factory.GetColor(0xFFF59F), factory.GetColor(0xFFFAD5));
            rt.SelectedMouseOver.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, Color.White), Color.Transparent);
            rt.SelectedMouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFFF071), factory.GetColor(0xFCF395));
            rt.SelectedMouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xCAC7AB), factory.GetColor(0xC2C2C2));
            rt.SelectedMouseOver.Text = factory.GetColor(0x000000);

            // Tab Mouse Over
            rt.MouseOver = new Office2007RibbonTabItemStateColorTable();
            rt.MouseOver.Background = new LinearGradientColorTable(factory.GetColor(0x929083), factory.GetColor(0xB6A933));
            rt.MouseOver.BackgroundHighlight = new LinearGradientColorTable(factory.GetColor(0xC2B531), Color.Transparent);
            rt.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0x8F8D83), factory.GetColor(0xB1A433));
            rt.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x9C9B96), factory.GetColor(0xBEBEBE));
            rt.MouseOver.Text = factory.GetColor(0xFFFFFF);

            return rt;
        }
        #endregion

        #region ButtonItem
        public static Office2007ButtonItemColorTable GetButtonItemBlackOrange(bool ribbonBar, ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = new Office2007ButtonItemColorTable();
            cb.Default = new Office2007ButtonItemStateColorTable();
            //if(ribbonBar)
            cb.Default.Text = factory.GetColor(0x000000);  //factory.GetColor(0x464646);
            //else
            //    cb.Default.Text = factory.GetColor(0xFFFFFF);

            // Button mouse over
            cb.MouseOver = new Office2007ButtonItemStateColorTable();
            cb.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xDDCF9B), factory.GetColor(0xC0A877));
            cb.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xFFFFF7), factory.GetColor(0xFFF796));
            cb.MouseOver.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFFFCD9), factory.GetColor(0xFFE78D));
            cb.MouseOver.TopBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(192, Color.White), Color.Transparent);
            cb.MouseOver.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFFD748), factory.GetColor(0xFFE793));
            cb.MouseOver.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(164, Color.White), Color.Transparent);
            cb.MouseOver.SplitBorder = new LinearGradientColorTable(factory.GetColor(0xDBC374), factory.GetColor(0xC8BB8C));
            cb.MouseOver.SplitBorderLight = new LinearGradientColorTable(factory.GetColor(0xFFF0BF), factory.GetColor(0xFFF6DF));
            cb.MouseOver.Text = factory.GetColor(0x000000);

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
            cb.Pressed.Text = factory.GetColor(0x000000);

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
            cb.Checked.Text = factory.GetColor(0x000000);

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
            cb.Expanded.Text = factory.GetColor(0x000000);

            SetBlackExpandColors(cb, factory);
            return cb;
        }

        public static Office2007ButtonItemColorTable GetButtonItemBlackOrangeWithBackground(ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = GetButtonItemBlackOrange(false, factory);
            //cb.Default = new Office2007ButtonItemStateColorTable();

            cb.Default.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFFFFFF), factory.GetColor(0xE0E5EB));
            cb.Default.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xCBD5DF), factory.GetColor(0xFFFFFF));
            cb.Default.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(128, Color.White), Color.Transparent);
            cb.Default.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x898785), Color.Empty);
            cb.Default.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            // Copy of the default theme
            cb.Disabled = new Office2007ButtonItemStateColorTable();
            cb.Disabled.TopBackground = new LinearGradientColorTable(factory.GetColor(0xCED3DA), factory.GetColor(0xC1C6CF));
            cb.Disabled.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xB4BBC5), factory.GetColor(0xE5ECEC));
            cb.Disabled.BottomBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xC5D1DE), Color.Empty);
            cb.Disabled.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            return cb;
        }

        public static Office2007ButtonItemColorTable GetButtonItemBlackBlue(bool ribbonBar, ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = new Office2007ButtonItemColorTable();
            cb.Default = new Office2007ButtonItemStateColorTable();
            //if (ribbonBar)
            cb.Default.Text = factory.GetColor(0x000000);  //factory.GetColor(0x15428B);
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
            cb.MouseOver.Text = factory.GetColor(0x000000);

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
            cb.Pressed.Text = factory.GetColor(0x000000);

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
            cb.Checked.Text = factory.GetColor(0x000000);

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
            cb.Expanded.Text = factory.GetColor(0x000000);


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
            SetBlackExpandColors(cb, factory);
            return cb;
        }

        public static Office2007ButtonItemColorTable GetButtonItemBlackBlueWithBackground(ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = GetButtonItemBlackBlue(false, factory);
            //cb.Default = new Office2007ButtonItemStateColorTable();
            cb.Default.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFFFFFF), factory.GetColor(0xE0E5EB));
            cb.Default.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xCBD5DF), factory.GetColor(0xFFFFFF));
            cb.Default.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(128, Color.White), Color.Transparent);
            cb.Default.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x898785), Color.Empty);
            cb.Default.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            // Copy of the default theme
            cb.Disabled = new Office2007ButtonItemStateColorTable();
            cb.Disabled.TopBackground = new LinearGradientColorTable(factory.GetColor(0xCED3DA), factory.GetColor(0xC1C6CF));
            cb.Disabled.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xB4BBC5), factory.GetColor(0xE5ECEC));
            cb.Disabled.BottomBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xC5D1DE), Color.Empty);
            cb.Disabled.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            return cb;
        }

        public static Office2007ButtonItemColorTable GetButtonItemBlackMagenta(bool ribbonBar, ColorFactory factory)
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
            SetBlackExpandColors(cb, factory);

            return cb;
        }

        public static Office2007ButtonItemColorTable GetButtonItemBlackMagentaWithBackground(ColorFactory factory)
        {
            Office2007ButtonItemColorTable cb = GetButtonItemBlackMagenta(false, factory);
            //cb.Default = new Office2007ButtonItemStateColorTable();
            cb.Default.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFFFFFF), factory.GetColor(0xE0E5EB));
            cb.Default.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xCBD5DF), factory.GetColor(0xFFFFFF));
            cb.Default.BottomBackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(128, Color.White), Color.Transparent);
            cb.Default.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x898785), Color.Empty);
            cb.Default.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Default.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            // Copy of the default theme
            cb.Disabled = new Office2007ButtonItemStateColorTable();
            cb.Disabled.TopBackground = new LinearGradientColorTable(factory.GetColor(0xCED3DA), factory.GetColor(0xC1C6CF));
            cb.Disabled.TopBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xB4BBC5), factory.GetColor(0xE5ECEC));
            cb.Disabled.BottomBackgroundHighlight = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.InnerBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x4B4B4B), Color.Empty);
            cb.Disabled.SplitBorder = new LinearGradientColorTable(Color.Empty, Color.Empty);
            cb.Disabled.SplitBorderLight = new LinearGradientColorTable(Color.Empty, Color.Empty);

            return cb;
        }
        #endregion

        #region RibbonTabItemGroup
        public static Office2007RibbonTabGroupColorTable GetRibbonTabGroupBlackDefault(ColorFactory factory)
        {
            Office2007RibbonTabGroupColorTable tg = new Office2007RibbonTabGroupColorTable();
            tg.Background = new LinearGradientColorTable(Color.Transparent /*factory.GetColor(0x3C3B3C)*/, factory.GetColor(0xA0A0A0));
            tg.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, factory.GetColor(0xCDCDCD)), Color.Transparent);
            tg.Text = factory.GetColor(0xFFFFFF);
            tg.Border = new LinearGradientColorTable(Color.FromArgb(16, Color.DarkGray), Color.FromArgb(192, Color.DarkGray));

            return tg;
        }

        public static Office2007RibbonTabGroupColorTable GetRibbonTabGroupBlackMagenta(ColorFactory factory)
        {
            Office2007RibbonTabGroupColorTable tg = new Office2007RibbonTabGroupColorTable();
            tg.Background = new LinearGradientColorTable(Color.Transparent /*factory.GetColor(0x3C3B3C)*/, factory.GetColor(0x90708F));
            tg.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, factory.GetColor(0xAF7DA2)), Color.Transparent);
            tg.Text = factory.GetColor(0xFFFFFF);
            tg.Border = new LinearGradientColorTable(Color.FromArgb(16, Color.DarkGray), Color.FromArgb(192, Color.DarkGray));

            return tg;
        }

        public static Office2007RibbonTabGroupColorTable GetRibbonTabGroupBlackGreen(ColorFactory factory)
        {
            Office2007RibbonTabGroupColorTable tg = new Office2007RibbonTabGroupColorTable();

            tg.Background = new LinearGradientColorTable(Color.Transparent /*factory.GetColor(0x3A3D3B)*/, factory.GetColor(0x6E9F5D));
            tg.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, factory.GetColor(0x6BB954)), Color.Transparent);
            tg.Border = new LinearGradientColorTable(Color.FromArgb(16, Color.DarkGray), Color.FromArgb(192, Color.DarkGray));
            tg.Text = factory.GetColor(0xFFFFFF);

            return tg;
        }

        public static Office2007RibbonTabGroupColorTable GetRibbonTabGroupBlackOrange(ColorFactory factory)
        {
            Office2007RibbonTabGroupColorTable tg = new Office2007RibbonTabGroupColorTable();

            tg.Background = new LinearGradientColorTable(Color.Transparent /*factory.GetColor(0x414038)*/, factory.GetColor(0xA69B41));
            tg.BackgroundHighlight = new LinearGradientColorTable(Color.FromArgb(64, factory.GetColor(0xFFE619)), Color.Transparent);
            tg.Border = new LinearGradientColorTable(Color.FromArgb(16, Color.DarkGray), Color.FromArgb(192, Color.DarkGray));
            tg.Text = factory.GetColor(0xFFFFFF);

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
            sct.ThumbBackground.AddRange(new BackgroundColorBlend[] { new BackgroundColorBlend(factory.GetColor(0xBFD1EA),0f), 
                new BackgroundColorBlend(factory.GetColor(0xCADFFA),0.4f),
                new BackgroundColorBlend(factory.GetColor(0xAACBF6),0.4f),
                new BackgroundColorBlend(factory.GetColor(0xAACBF6),0.7f),
                new BackgroundColorBlend(factory.GetColor(0xD3E4FA),1f)});
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

        public static void InitializeAppBlueScrollBarColorTable(Office2007ColorTable t, ColorFactory factory)
        {
            Office2007ScrollBarStateColorTable sct = t.AppScrollBar.Default;
            sct.Background = new LinearGradientColorTable(factory.GetColor(0x95B0D2), factory.GetColor(0x7C9BC1), 0);
            sct.Border = new LinearGradientColorTable(factory.GetColor(0xB2D0F6));
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0x6E7EA6), factory.GetColor(0x424B63), 90);
            sct.TrackBackground.Clear();
            sct.TrackBackground.AddRange(new BackgroundColorBlend[] { new BackgroundColorBlend(factory.GetColor(0xE3E5E7),0f), 
                new BackgroundColorBlend(factory.GetColor(0xE3E9F0),0.4f),
                new BackgroundColorBlend(factory.GetColor(0xC8D4E1),0.4f),
                new BackgroundColorBlend(factory.GetColor(0xB6C4D8),.8f),
                new BackgroundColorBlend(factory.GetColor(0xB6C4D8),.8f),
                new BackgroundColorBlend(factory.GetColor(0xE1E7EF),1f)});
            sct.TrackInnerBorder = new LinearGradientColorTable(factory.GetColor(0xE3E5E7), factory.GetColor(0xE1E7EF));
            sct.TrackOuterBorder = new LinearGradientColorTable(factory.GetColor(0x596991), Color.Empty);
            sct.TrackSignBackground = new LinearGradientColorTable(Color.FromArgb(180, factory.GetColor(0x8B8E90)), Color.FromArgb(64, Color.White));

            // Mouse Over
            sct = t.AppScrollBar.MouseOver;
            sct.Background = t.AppScrollBar.Default.Background;
            sct.Border = t.AppScrollBar.Default.Border;
            sct.ThumbBackground.Clear();
            sct.ThumbBackground.AddRange(new BackgroundColorBlend[] { new BackgroundColorBlend(factory.GetColor(0xBFD1EA),0f), 
                new BackgroundColorBlend(factory.GetColor(0xCADFFA),0.4f),
                new BackgroundColorBlend(factory.GetColor(0xAACBF6),0.4f),
                new BackgroundColorBlend(factory.GetColor(0xAACBF6),0.7f),
                new BackgroundColorBlend(factory.GetColor(0xD3E4FA),1f)});
            sct.ThumbInnerBorder = new LinearGradientColorTable(factory.GetColor(0xE9E9EB), factory.GetColor(0xFCFDFF));
            sct.ThumbOuterBorder = new LinearGradientColorTable(factory.GetColor(0x3C6EB0), Color.Empty);
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0x6E7EA6), factory.GetColor(0x424B63), 90);
            sct.TrackBackground.Clear();
            sct.TrackBackground.CopyFrom(sct.ThumbBackground);
            sct.TrackInnerBorder = sct.ThumbInnerBorder;
            sct.TrackOuterBorder = sct.ThumbOuterBorder;
            sct.TrackSignBackground = new LinearGradientColorTable(Color.FromArgb(180, factory.GetColor(0x7D8692)), Color.FromArgb(64, Color.White));

            // Control Mouse Over
            sct = t.AppScrollBar.MouseOverControl;
            sct.Background = t.AppScrollBar.Default.Background;
            sct.Border = t.AppScrollBar.Default.Border;
            sct.ThumbBackground.Clear();
            sct.ThumbBackground.CopyFrom(t.AppScrollBar.Default.TrackBackground);
            sct.ThumbInnerBorder = t.AppScrollBar.Default.TrackInnerBorder;
            sct.ThumbOuterBorder = t.AppScrollBar.Default.TrackOuterBorder;
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0x55658D), factory.GetColor(0x333C54));
            sct.TrackBackground.Clear();
            sct.TrackBackground.CopyFrom(t.AppScrollBar.Default.TrackBackground);
            sct.TrackInnerBorder = t.AppScrollBar.Default.TrackInnerBorder;
            sct.TrackOuterBorder = t.AppScrollBar.Default.TrackOuterBorder;
            sct.TrackSignBackground = t.AppScrollBar.Default.TrackSignBackground;

            // Pressed
            sct = t.AppScrollBar.Pressed;
            sct.Background = t.AppScrollBar.Default.Background;
            sct.Border = t.AppScrollBar.Default.Border;
            sct.ThumbBackground.Clear();
            sct.ThumbBackground.AddRange(new BackgroundColorBlend[] { 
                new BackgroundColorBlend(factory.GetColor(0x9DBDE7),0f), 
                new BackgroundColorBlend(factory.GetColor(0xABCCF6),0.4f),
                new BackgroundColorBlend(factory.GetColor(0x6EA6F0),0.4f),
                new BackgroundColorBlend(factory.GetColor(0x6EA6F0),0.7f),
                new BackgroundColorBlend(factory.GetColor(0xB5D1F7),1f)});
            sct.ThumbInnerBorder = new LinearGradientColorTable(factory.GetColor(0xC2D3E7), factory.GetColor(0xDDEBFB));
            sct.ThumbOuterBorder = new LinearGradientColorTable(factory.GetColor(0x17498A), Color.Empty);
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0x6E7EA6), factory.GetColor(0x424B63), 90);
            sct.TrackBackground.Clear();
            sct.TrackBackground.CopyFrom(sct.ThumbBackground);
            //sct.TrackBackground.AddRange(new BackgroundColorBlend[] {
            //    new BackgroundColorBlend(factory.GetColor(0x9DBDE7),0f), 
            //    new BackgroundColorBlend(factory.GetColor(0xABCCF6),0.4f),
            //    new BackgroundColorBlend(factory.GetColor(0x79ADF1),0.4f),
            //    new BackgroundColorBlend(factory.GetColor(0xBBD5F8),1f)});
            sct.TrackInnerBorder = new LinearGradientColorTable(factory.GetColor(0xC2D3E7), factory.GetColor(0xDDEBFB));
            sct.TrackOuterBorder = new LinearGradientColorTable(factory.GetColor(0x17498A), Color.Empty);
            sct.TrackSignBackground = new LinearGradientColorTable(Color.FromArgb(180, factory.GetColor(0x818181)), Color.FromArgb(64, Color.White));
            // Disabled
            sct = t.AppScrollBar.Disabled;
            sct.Background = t.AppScrollBar.Default.Background;
            sct.Border = t.AppScrollBar.Default.Border;
            sct.ThumbBackground.Clear();
            sct.ThumbInnerBorder = new LinearGradientColorTable();
            sct.ThumbOuterBorder = new LinearGradientColorTable();
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0xBFCFF7), factory.GetColor(0x727C94));
            sct.TrackBackground.Clear();
            sct.TrackInnerBorder = new LinearGradientColorTable();
            sct.TrackOuterBorder = new LinearGradientColorTable();
            sct.TrackSignBackground = new LinearGradientColorTable();
        }

        public static void InitializeAppSilverScrollBarColorTable(Office2007ColorTable t, ColorFactory factory)
        {
            Office2007ScrollBarStateColorTable sct = t.AppScrollBar.Default;
            sct.Background = new LinearGradientColorTable(factory.GetColor(0xB4B7BF));
            sct.Border = new LinearGradientColorTable(factory.GetColor(0x9D9FA6));
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0x7D848E), factory.GetColor(0x4B4F55), 90);
            sct.TrackBackground.Clear();
            sct.TrackBackground.AddRange(new BackgroundColorBlend[] {
                new BackgroundColorBlend(factory.GetColor(0xF5F5F6),0f), 
                new BackgroundColorBlend(factory.GetColor(0xEAEAEC),0.4f),
                new BackgroundColorBlend(factory.GetColor(0xDADBDD),0.4f),
                new BackgroundColorBlend(factory.GetColor(0xC1C1C5),1f)});
            sct.TrackInnerBorder = new LinearGradientColorTable(factory.GetColor(0xF9F9F9), factory.GetColor(0xCFCFD2));
            sct.TrackOuterBorder = new LinearGradientColorTable(factory.GetColor(0x6E6F73), Color.Empty);
            sct.TrackSignBackground = new LinearGradientColorTable(Color.FromArgb(180, factory.GetColor(0x6F6F6F)), Color.FromArgb(64, Color.White));

            // Mouse Over
            sct = t.AppScrollBar.MouseOver;
            sct.Background = t.AppScrollBar.Default.Background;
            sct.Border = t.AppScrollBar.Default.Border;
            sct.ThumbBackground.Clear();
            sct.ThumbBackground.AddRange(new BackgroundColorBlend[] {
                new BackgroundColorBlend(factory.GetColor(0xDCF0FB),0f), 
                new BackgroundColorBlend(factory.GetColor(0xC9E9FA),0.4f),
                new BackgroundColorBlend(factory.GetColor(0xA9DBF6),0.4f),
                new BackgroundColorBlend(factory.GetColor(0xA9DBF6),0.7f),
                new BackgroundColorBlend(factory.GetColor(0x94C0D8),1f)});
            sct.ThumbInnerBorder = new LinearGradientColorTable(factory.GetColor(0xFDFEFF), factory.GetColor(0xDBDDDF));
            sct.ThumbOuterBorder = new LinearGradientColorTable(factory.GetColor(0x3C7FB1), Color.Empty);
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0x7D848E), factory.GetColor(0x4B4F55), 90);
            sct.TrackBackground.Clear();
            sct.TrackBackground.CopyFrom(sct.ThumbBackground);
            sct.TrackInnerBorder = sct.ThumbInnerBorder;
            sct.TrackOuterBorder = sct.ThumbOuterBorder;
            sct.TrackSignBackground = new LinearGradientColorTable(Color.FromArgb(180, factory.GetColor(0x6F6F6F)), Color.FromArgb(64, Color.White));

            // Control Mouse Over
            sct = t.AppScrollBar.MouseOverControl;
            sct.Background = t.AppScrollBar.Default.Background;
            sct.Border = t.AppScrollBar.Default.Border;
            sct.ThumbBackground.Clear();
            sct.ThumbBackground.CopyFrom(t.AppScrollBar.Default.TrackBackground);
            sct.ThumbInnerBorder = t.AppScrollBar.Default.TrackInnerBorder;
            sct.ThumbOuterBorder = t.AppScrollBar.Default.TrackOuterBorder;
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0x7D848E), factory.GetColor(0x4B4F55), 90);
            sct.TrackBackground.Clear();
            sct.TrackBackground.CopyFrom(t.AppScrollBar.Default.TrackBackground);
            sct.TrackInnerBorder = t.AppScrollBar.Default.TrackInnerBorder;
            sct.TrackOuterBorder = t.AppScrollBar.Default.TrackOuterBorder;
            sct.TrackSignBackground = t.AppScrollBar.Default.TrackSignBackground;

            // Pressed
            sct = t.AppScrollBar.Pressed;
            sct.Background = t.AppScrollBar.Default.Background;
            sct.Border = t.AppScrollBar.Default.Border;
            sct.ThumbBackground.Clear();
            sct.ThumbBackground.AddRange(new BackgroundColorBlend[] { 
                new BackgroundColorBlend(factory.GetColor(0xC4E9F9),0f), 
                new BackgroundColorBlend(factory.GetColor(0xA5DEF6),0.4f),
                new BackgroundColorBlend(factory.GetColor(0x6FCAF0),0.4f),
                new BackgroundColorBlend(factory.GetColor(0x6FCAF0),0.7f),
                new BackgroundColorBlend(factory.GetColor(0x62B1D3),1f)});
            sct.ThumbInnerBorder = new LinearGradientColorTable(factory.GetColor(0xE3F5FC), factory.GetColor(0x9EC7D9));
            sct.ThumbOuterBorder = new LinearGradientColorTable(factory.GetColor(0x18598A), Color.Empty);
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0x7D848E), factory.GetColor(0x4B4F55), 90);
            sct.TrackBackground.Clear();
            sct.TrackBackground.CopyFrom(sct.ThumbBackground);
            //sct.TrackBackground.AddRange(new BackgroundColorBlend[] {
            //    new BackgroundColorBlend(factory.GetColor(0x9DBDE7),0f), 
            //    new BackgroundColorBlend(factory.GetColor(0xABCCF6),0.4f),
            //    new BackgroundColorBlend(factory.GetColor(0x79ADF1),0.4f),
            //    new BackgroundColorBlend(factory.GetColor(0xBBD5F8),1f)});
            sct.TrackInnerBorder = new LinearGradientColorTable(factory.GetColor(0xE3F5FC), factory.GetColor(0x9EC7D9));
            sct.TrackOuterBorder = new LinearGradientColorTable(factory.GetColor(0x18598A), Color.Empty);
            sct.TrackSignBackground = new LinearGradientColorTable(Color.FromArgb(180, factory.GetColor(0x818181)), Color.FromArgb(64, Color.White));
            // Disabled
            sct = t.AppScrollBar.Disabled;
            sct.Background = t.AppScrollBar.Default.Background;
            sct.Border = t.AppScrollBar.Default.Border;
            sct.ThumbBackground.Clear();
            sct.ThumbInnerBorder = new LinearGradientColorTable();
            sct.ThumbOuterBorder = new LinearGradientColorTable();
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0xBFCFF7), factory.GetColor(0x727C94));
            sct.TrackBackground.Clear();
            sct.TrackInnerBorder = new LinearGradientColorTable();
            sct.TrackOuterBorder = new LinearGradientColorTable();
            sct.TrackSignBackground = new LinearGradientColorTable();
        }

        public static void InitializeAppBlackScrollBarColorTable(Office2007ColorTable t, ColorFactory factory)
        {
            Office2007ScrollBarStateColorTable sct = t.AppScrollBar.Default;
            sct.Background = new LinearGradientColorTable(factory.GetColor(0x404040));
            sct.Border = new LinearGradientColorTable(factory.GetColor(0x626262));
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0xCACACA), factory.GetColor(0x797979), 90);
            sct.TrackBackground.Clear();
            sct.TrackBackground.AddRange(new BackgroundColorBlend[] {
                new BackgroundColorBlend(factory.GetColor(0xF9F9F9),0f), 
                new BackgroundColorBlend(factory.GetColor(0xEAEAEC),0.4f),
                new BackgroundColorBlend(factory.GetColor(0xDADBDD),0.4f),
                new BackgroundColorBlend(factory.GetColor(0xC1C1C5),1f)});
            sct.TrackInnerBorder = new LinearGradientColorTable(factory.GetColor(0xF9F9F9), factory.GetColor(0xCFCFD2));
            sct.TrackOuterBorder = new LinearGradientColorTable(factory.GetColor(0x2F2F2F), Color.Empty);
            sct.TrackSignBackground = new LinearGradientColorTable(Color.FromArgb(180, factory.GetColor(0x6F6F6F)), Color.FromArgb(64, Color.White));

            // Mouse Over
            sct = t.AppScrollBar.MouseOver;
            sct.Background = t.AppScrollBar.Default.Background;
            sct.Border = t.AppScrollBar.Default.Border;
            sct.ThumbBackground.Clear();
            sct.ThumbBackground.AddRange(new BackgroundColorBlend[] {
                new BackgroundColorBlend(factory.GetColor(0xDCF0FB),0f), 
                new BackgroundColorBlend(factory.GetColor(0xC9E9FA),0.4f),
                new BackgroundColorBlend(factory.GetColor(0xA9DBF6),0.4f),
                new BackgroundColorBlend(factory.GetColor(0xA9DBF6),0.7f),
                new BackgroundColorBlend(factory.GetColor(0x94C0D8),1f)});
            sct.ThumbInnerBorder = new LinearGradientColorTable(factory.GetColor(0xFDFEFF), factory.GetColor(0xDBDDDF));
            sct.ThumbOuterBorder = new LinearGradientColorTable(factory.GetColor(0x3C7FB1), Color.Empty);
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0x838383), factory.GetColor(0x4E4E4E), 90);
            sct.TrackBackground.Clear();
            sct.TrackBackground.CopyFrom(sct.ThumbBackground);
            sct.TrackInnerBorder = sct.ThumbInnerBorder;
            sct.TrackOuterBorder = sct.ThumbOuterBorder;
            sct.TrackSignBackground = new LinearGradientColorTable(Color.FromArgb(180, factory.GetColor(0x6F6F6F)), Color.FromArgb(64, Color.White));

            // Control Mouse Over
            sct = t.AppScrollBar.MouseOverControl;
            sct.Background = t.AppScrollBar.Default.Background;
            sct.Border = t.AppScrollBar.Default.Border;
            sct.ThumbBackground.Clear();
            sct.ThumbBackground.CopyFrom(t.AppScrollBar.Default.TrackBackground);
            sct.ThumbInnerBorder = t.AppScrollBar.Default.TrackInnerBorder;
            sct.ThumbOuterBorder = t.AppScrollBar.Default.TrackOuterBorder;
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0x838383), factory.GetColor(0x4E4E4E), 90);
            sct.TrackBackground.Clear();
            sct.TrackBackground.CopyFrom(t.AppScrollBar.Default.TrackBackground);
            sct.TrackInnerBorder = t.AppScrollBar.Default.TrackInnerBorder;
            sct.TrackOuterBorder = t.AppScrollBar.Default.TrackOuterBorder;
            sct.TrackSignBackground = t.AppScrollBar.Default.TrackSignBackground;

            // Pressed
            sct = t.AppScrollBar.Pressed;
            sct.Background = t.AppScrollBar.Default.Background;
            sct.Border = t.AppScrollBar.Default.Border;
            sct.ThumbBackground.Clear();
            sct.ThumbBackground.AddRange(new BackgroundColorBlend[] { 
                new BackgroundColorBlend(factory.GetColor(0xC4E9F9),0f), 
                new BackgroundColorBlend(factory.GetColor(0xA5DEF6),0.4f),
                new BackgroundColorBlend(factory.GetColor(0x6FCAF0),0.4f),
                new BackgroundColorBlend(factory.GetColor(0x6FCAF0),0.7f),
                new BackgroundColorBlend(factory.GetColor(0x62B1D3),1f)});
            sct.ThumbInnerBorder = new LinearGradientColorTable(factory.GetColor(0xE3F5FC), factory.GetColor(0x9EC7D9));
            sct.ThumbOuterBorder = new LinearGradientColorTable(factory.GetColor(0x18598A), Color.Empty);
            sct.ThumbSignBackground = new LinearGradientColorTable(factory.GetColor(0x7D848E), factory.GetColor(0x4B4F55), 90);
            sct.TrackBackground.Clear();
            sct.TrackBackground.CopyFrom(sct.ThumbBackground);
            //sct.TrackBackground.AddRange(new BackgroundColorBlend[] {
            //    new BackgroundColorBlend(factory.GetColor(0x9DBDE7),0f), 
            //    new BackgroundColorBlend(factory.GetColor(0xABCCF6),0.4f),
            //    new BackgroundColorBlend(factory.GetColor(0x79ADF1),0.4f),
            //    new BackgroundColorBlend(factory.GetColor(0xBBD5F8),1f)});
            sct.TrackInnerBorder = new LinearGradientColorTable(factory.GetColor(0xE3F5FC), factory.GetColor(0x9EC7D9));
            sct.TrackOuterBorder = new LinearGradientColorTable(factory.GetColor(0x18598A), Color.Empty);
            sct.TrackSignBackground = new LinearGradientColorTable(Color.FromArgb(180, factory.GetColor(0x818181)), Color.FromArgb(64, Color.White));
            // Disabled
            sct = t.AppScrollBar.Disabled;
            sct.Background = t.AppScrollBar.Default.Background;
            sct.Border = t.AppScrollBar.Default.Border;
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

        public static void InitializeVistaBlackColorTable(Office2007ColorTable t, ColorFactory factory)
        {
            #region Ribbon Bar
            t.RibbonBar.Default = GetRibbonBarBlack(factory);
            t.RibbonBar.MouseOver = GetRibbonBarBlackMouseOver(factory);
            t.RibbonBar.Expanded = GetRibbonBarBlackExpanded(factory);
            #endregion

            #region RibbonTabItem
            // RibbonTabItem Default
            t.RibbonTabItemColors.Clear();
            Office2007RibbonTabItemColorTable rt = Office2007ColorTableFactory.GetRibbonTabItemBlackDefault(factory);
            rt.Name = Enum.GetName(typeof(RibbonTabColor), RibbonTabColor.Default);
            t.RibbonTabItemColors.Add(rt);
            // Green
            
            rt = Office2007ColorTableFactory.GetRibbonTabItemBlackGreen(factory);
            rt.Name = Enum.GetName(typeof(RibbonTabColor), RibbonTabColor.Green);
            t.RibbonTabItemColors.Add(rt);
            // Magenta
            
            rt = Office2007ColorTableFactory.GetRibbonTabItemBlackMagenta(factory);
            rt.Name = Enum.GetName(typeof(RibbonTabColor), RibbonTabColor.Magenta);
            t.RibbonTabItemColors.Add(rt);
            // Orange
            
            rt = Office2007ColorTableFactory.GetRibbonTabItemBlackOrange(factory);
            rt.Name = Enum.GetName(typeof(RibbonTabColor), RibbonTabColor.Orange);
            t.RibbonTabItemColors.Add(rt);
            #endregion

            #region Ribbon Control
            t.RibbonControl = new Office2007RibbonColorTable();
            t.RibbonControl.TabsBackground = new LinearGradientColorTable(factory.GetColor(0x535353), factory.GetColor(0x535353));
            //t.RibbonControl.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xD7DADF), factory.GetColor(0x3A3A3A));
            //t.RibbonControl.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xBEBEBE), factory.GetColor(0xBEBEBE));
            t.RibbonControl.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xCED2D9), factory.GetColor(0xBEBEBE));
            t.RibbonControl.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x535353), factory.GetColor(0x4F4F4F));
            t.RibbonControl.TabDividerBorder = factory.GetColor(0x414141); 
            t.RibbonControl.TabDividerBorderLight = factory.GetColor(0x666666);
            t.RibbonControl.PanelTopBackground = new LinearGradientColorTable(factory.GetColor(0xD7DBE0), factory.GetColor(0xC1C6CF));
            t.RibbonControl.PanelBottomBackground = new LinearGradientColorTable(factory.GetColor(0xB4BBC5), factory.GetColor(0xEBEBEB));
            t.RibbonControl.StartButtonDefault = BarFunctions.LoadBitmap("SystemImages.BlankStartButtonNormalBlack.png");
            t.RibbonControl.StartButtonMouseOver = BarFunctions.LoadBitmap("SystemImages.BlankStartButtonHotBlack.png");
            t.RibbonControl.StartButtonPressed = BarFunctions.LoadBitmap("SystemImages.BlankStartButtonPressedBlack.png");
            #endregion

            #region ItemContainer
            t.ItemGroup.TopBackground = new LinearGradientColorTable(factory.GetColor(0xD6DEDF), factory.GetColor(0xDBE2E4));
            t.ItemGroup.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xD3D8DA), factory.GetColor(0xE0E5E7));
            t.ItemGroup.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xDFE6E6), factory.GetColor(0xEDF0F1));
            t.ItemGroup.OuterBorder = new LinearGradientColorTable(factory.GetColor(0xADB7BB), factory.GetColor(0x8C959A));
            t.ItemGroup.ItemGroupDividerDark = Color.FromArgb(196, factory.GetColor(0xCECECE));
            t.ItemGroup.ItemGroupDividerLight = Color.FromArgb(128, factory.GetColor(0xFFFFFF));
            #endregion

            #region Bar
            t.Bar.ToolbarTopBackground = new LinearGradientColorTable(factory.GetColor(0x333333), factory.GetColor(0x3B3E46));
            t.Bar.ToolbarBottomBackground = new LinearGradientColorTable(factory.GetColor(0x2F3030), factory.GetColor(0x454545));
            t.Bar.ToolbarBottomBorder = factory.GetColor(0x4C4C4C);
            t.Bar.PopupToolbarBackground = new LinearGradientColorTable(factory.GetColor(0xFAFAFA), Color.Empty);
            t.Bar.PopupToolbarBorder = factory.GetColor(0x2F2F2F);
            t.Bar.StatusBarTopBorder = factory.GetColor(0x333333);
            t.Bar.StatusBarTopBorderLight = Color.Empty;
            t.Bar.StatusBarAltBackground.Clear();
            t.Bar.StatusBarAltBackground.Add(new BackgroundColorBlend(factory.GetColor(0xC6C5C6), 0f));
            t.Bar.StatusBarAltBackground.Add(new BackgroundColorBlend(factory.GetColor(0xB4B4B4), 0.4f));
            t.Bar.StatusBarAltBackground.Add(new BackgroundColorBlend(factory.GetColor(0x979898), 0.4f));
            t.Bar.StatusBarAltBackground.Add(new BackgroundColorBlend(factory.GetColor(0x484C52), 1f));
            #endregion

            #region ButtonItem Colors Initialization
            t.ButtonItemColors.Clear();
            t.RibbonButtonItemColors.Clear();
            t.MenuButtonItemColors.Clear();
            // Orange
            Office2007ButtonItemColorTable cb = Office2007ColorTableFactory.GetButtonItemBlackOrange(false, factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.Orange);
            t.ButtonItemColors.Add(cb);
            // Orange with background
            cb = Office2007ColorTableFactory.GetButtonItemBlackOrangeWithBackground(factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.OrangeWithBackground);
            t.ButtonItemColors.Add(cb);
            // Blue
            cb = Office2007ColorTableFactory.GetButtonItemBlackBlue(false,factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.Blue);
            t.ButtonItemColors.Add(cb);
            // Blue with background
            cb = Office2007ColorTableFactory.GetButtonItemBlackBlueWithBackground(factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.BlueWithBackground);
            t.ButtonItemColors.Add(cb);
            // Magenta
            cb = Office2007ColorTableFactory.GetButtonItemBlackMagenta(false, factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.Magenta);
            t.ButtonItemColors.Add(cb);
            // Magenta with background
            cb = Office2007ColorTableFactory.GetButtonItemBlackMagentaWithBackground(factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.MagentaWithBackground);
            t.ButtonItemColors.Add(cb);

            // RibbonBar buttons
            cb = Office2007ColorTableFactory.GetButtonItemBlackOrange(true,factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.Orange);
            t.RibbonButtonItemColors.Add(cb);
            // Orange with background
            cb = Office2007ColorTableFactory.GetButtonItemBlackOrangeWithBackground(factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.OrangeWithBackground);
            t.RibbonButtonItemColors.Add(cb);
            // Blue
            cb = Office2007ColorTableFactory.GetButtonItemBlackBlue(true,factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.Blue);
            t.RibbonButtonItemColors.Add(cb);
            // Blue with background
            cb = Office2007ColorTableFactory.GetButtonItemBlackBlueWithBackground(factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.BlueWithBackground);
            t.RibbonButtonItemColors.Add(cb);
            // Magenta
            cb = Office2007ColorTableFactory.GetButtonItemBlackMagenta(true, factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.Magenta);
            t.RibbonButtonItemColors.Add(cb);
            // Magenta with background
            cb = Office2007ColorTableFactory.GetButtonItemBlackMagentaWithBackground(factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.MagentaWithBackground);
            t.RibbonButtonItemColors.Add(cb);

            // MENU Orange
            cb = Office2007ColorTableFactory.GetButtonItemBlackOrange(true, factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.Orange);
            cb.Default.Text = factory.GetColor(0xFFFFFF);
            cb.MouseOver.Text = factory.GetColor(0x000000);
            cb.Checked.Text = factory.GetColor(0x000000);
            cb.Expanded.Text = factory.GetColor(0x000000);
            cb.Pressed.Text = factory.GetColor(0x000000);
            t.MenuButtonItemColors.Add(cb);

            cb = Office2007ColorTableFactory.GetButtonItemOffice2007WithBackground(factory);
            cb.Name = Enum.GetName(typeof(eButtonColor), eButtonColor.Office2007WithBackground);
            t.ButtonItemColors.Add(cb);
            #endregion

            #region RibbonTabItemGroup Colors Initialization
            t.RibbonTabGroupColors.Clear();
            // Default
            Office2007RibbonTabGroupColorTable tg = Office2007ColorTableFactory.GetRibbonTabGroupBlackDefault(factory);
            tg.Name = Enum.GetName(typeof(eRibbonTabGroupColor), eRibbonTabGroupColor.Default);
            t.RibbonTabGroupColors.Add(tg);

            // Magenta
            tg = Office2007ColorTableFactory.GetRibbonTabGroupBlackMagenta(factory);
            tg.Name = Enum.GetName(typeof(eRibbonTabGroupColor), eRibbonTabGroupColor.Magenta);
            t.RibbonTabGroupColors.Add(tg);

            // Green
            tg = Office2007ColorTableFactory.GetRibbonTabGroupBlackGreen(factory);
            tg.Name = Enum.GetName(typeof(eRibbonTabGroupColor), eRibbonTabGroupColor.Green);
            t.RibbonTabGroupColors.Add(tg);

            // Orange
            tg = Office2007ColorTableFactory.GetRibbonTabGroupBlackOrange(factory);
            tg.Name = Enum.GetName(typeof(eRibbonTabGroupColor), eRibbonTabGroupColor.Orange);
            t.RibbonTabGroupColors.Add(tg);
            #endregion

            #region Menu
            t.Menu.Background = new LinearGradientColorTable(factory.GetColor(0xFAFAFA), Color.Empty);
            t.Menu.Border = new LinearGradientColorTable(factory.GetColor(0x868686), Color.Empty);
            t.Menu.Side = new LinearGradientColorTable(factory.GetColor(0xE9EEEE), Color.Empty);
            t.Menu.SideBorder = new LinearGradientColorTable(factory.GetColor(0xC5C5C5), Color.Empty);
            t.Menu.SideBorderLight = new LinearGradientColorTable(factory.GetColor(0xF5F5F5), Color.Empty);
            t.Menu.SideUnused = new LinearGradientColorTable(factory.GetColor(0xE5E5E5), Color.Empty);

            t.Menu.FileBackgroundBlend.Clear();
            t.Menu.FileBackgroundBlend.AddRange(new HVTT.UI.Window.Forms.BackgroundColorBlend[] {
                new HVTT.UI.Window.Forms.BackgroundColorBlend(factory.GetColor(0x515050), 0F),
                new HVTT.UI.Window.Forms.BackgroundColorBlend(factory.GetColor(0x4E4E4F), 1F)});
            t.Menu.FileContainerBorder = factory.GetColor(0x6B6C71);
            t.Menu.FileContainerBorderLight = factory.GetColor(0x6B6C71);
            t.Menu.FileColumnOneBackground = factory.GetColor(0xFAFAFA);
            t.Menu.FileColumnOneBorder = factory.GetColor(0xC5C5C5);
            t.Menu.FileColumnTwoBackground = factory.GetColor(0xE9EAEE);
            t.Menu.FileBottomContainerBackgroundBlend.Clear();
            t.Menu.FileBottomContainerBackgroundBlend.AddRange(new HVTT.UI.Window.Forms.BackgroundColorBlend[] {
                new HVTT.UI.Window.Forms.BackgroundColorBlend(factory.GetColor(0x434652), 0F),
                new HVTT.UI.Window.Forms.BackgroundColorBlend(factory.GetColor(0x3C404A), 0.4F),
                new HVTT.UI.Window.Forms.BackgroundColorBlend(factory.GetColor(0x2F2F2F), 0.4F),
                new HVTT.UI.Window.Forms.BackgroundColorBlend(factory.GetColor(0x404040), 1F)});
            #endregion

            #region ComboBox
            t.ComboBox.Default.Background = factory.GetColor(0xE8E8E8);
            t.ComboBox.Default.Border = factory.GetColor(0x898989);
            t.ComboBox.Default.ExpandBackground = new LinearGradientColorTable();
            t.ComboBox.Default.ExpandBorderInner = new LinearGradientColorTable();
            t.ComboBox.Default.ExpandBorderOuter = new LinearGradientColorTable();
            t.ComboBox.Default.ExpandText = factory.GetColor(0x7C7C7C);

            t.ComboBox.DefaultStandalone.Background = factory.GetColor(0xFFFFFF);
            t.ComboBox.DefaultStandalone.Border = factory.GetColor(0x898989);
            t.ComboBox.DefaultStandalone.ExpandBackground = new LinearGradientColorTable(factory.GetColor(0xECF0F5), factory.GetColor(0xDFE4EB), 90);
            t.ComboBox.DefaultStandalone.ExpandBorderInner = new LinearGradientColorTable();
            t.ComboBox.DefaultStandalone.ExpandBorderOuter = new LinearGradientColorTable(factory.GetColor(0xB7B7B7), Color.Empty, 90);
            t.ComboBox.DefaultStandalone.ExpandText = factory.GetColor(0x7C7C7C);

            t.ComboBox.MouseOver.Background = factory.GetColor(0xFFFFFF);
            t.ComboBox.MouseOver.Border = factory.GetColor(0x898989);
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
            t.SystemButton.Default.Foreground = new LinearGradientColorTable(factory.GetColor(0x848C95), factory.GetColor(0x9FA9B7));
            t.SystemButton.Default.LightShade = factory.GetColor(0x9FA9B7);
            t.SystemButton.Default.DarkShade = factory.GetColor(0x818080);

            // Mouse over state
            t.SystemButton.MouseOver = new Office2007SystemButtonStateColorTable();
            t.SystemButton.MouseOver.Foreground = new LinearGradientColorTable(factory.GetColor(0x363535), factory.GetColor(0x4F5763));
            t.SystemButton.MouseOver.LightShade = factory.GetColor(0x9BA1A8);
            t.SystemButton.MouseOver.DarkShade = factory.GetColor(0x454C56);
            t.SystemButton.MouseOver.TopBackground = new LinearGradientColorTable(factory.GetColor(0xB1B8C1), factory.GetColor(0x8894A1));
            t.SystemButton.MouseOver.BottomBackground = new LinearGradientColorTable(factory.GetColor(0x687585), factory.GetColor(0x9DB1C1));
            t.SystemButton.MouseOver.TopHighlight = new LinearGradientColorTable(factory.GetColor(0xCDD3DA), Color.Transparent);
            t.SystemButton.MouseOver.BottomHighlight = new LinearGradientColorTable(factory.GetColor(0xB5DDF4), Color.Transparent);
            t.SystemButton.MouseOver.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x57606D), factory.GetColor(0x5C6269));
            t.SystemButton.MouseOver.InnerBorder = new LinearGradientColorTable(factory.GetColor(0xCDD3DA), factory.GetColor(0xDADFE3));

            // Pressed
            t.SystemButton.Pressed = new Office2007SystemButtonStateColorTable();
            t.SystemButton.Pressed.Foreground = new LinearGradientColorTable(factory.GetColor(0x6D6C6C), factory.GetColor(0x8B96A4));
            t.SystemButton.Pressed.LightShade = factory.GetColor(0x7F8894);
            t.SystemButton.Pressed.DarkShade = factory.GetColor(0x6D6C6C);
            t.SystemButton.Pressed.TopBackground = new LinearGradientColorTable(factory.GetColor(0x373737), factory.GetColor(0x2B2B2B));
            t.SystemButton.Pressed.TopHighlight = new LinearGradientColorTable(factory.GetColor(0x686868), Color.Transparent);
            t.SystemButton.Pressed.BottomBackground = new LinearGradientColorTable(factory.GetColor(0x000000), factory.GetColor(0x07090B));
            t.SystemButton.Pressed.BottomHighlight = new LinearGradientColorTable(factory.GetColor(0x516982), Color.Transparent);
            t.SystemButton.Pressed.OuterBorder = new LinearGradientColorTable(factory.GetColor(0x222429), factory.GetColor(0x191919));
            t.SystemButton.Pressed.InnerBorder = new LinearGradientColorTable(factory.GetColor(0x464646), factory.GetColor(0x333333));

            // Form border
            t.Form.Active.BorderColors = new Color[] {
                factory.GetColor(0x2F2F2F),
                factory.GetColor(0x4D4D4D),
                factory.GetColor(0x666666),
                factory.GetColor(0x404040)};
            t.Form.Inactive.BorderColors = new Color[] {
                factory.GetColor(0x929292),
                factory.GetColor(0x9F9F9F),
                factory.GetColor(0xABABAB),
                factory.GetColor(0x999999)};


            // Form Caption Active
            t.Form.Active.CaptionTopBackground = new LinearGradientColorTable(factory.GetColor(0x434752), factory.GetColor(0x3A3D45));
            t.Form.Active.CaptionBottomBackground = new LinearGradientColorTable(factory.GetColor(0x2F3030), factory.GetColor(0x3E3E3E));
            t.Form.Active.CaptionText = factory.GetColor(0xAED1FF);
            t.Form.Active.CaptionTextExtra = factory.GetColor(0xFFFFFF);

            // Form Caption Inactive
            t.Form.Inactive.CaptionTopBackground = new LinearGradientColorTable(factory.GetColor(0x9A9CA1), factory.GetColor(0x97989C));
            t.Form.Inactive.CaptionBottomBackground = new LinearGradientColorTable(factory.GetColor(0x929292), factory.GetColor(0x9A9A9A));
            t.Form.Inactive.CaptionText = factory.GetColor(0xE1E1E1);
            t.Form.Inactive.CaptionTextExtra = factory.GetColor(0xE1E1E1);

            t.Form.BackColor = factory.GetColor(0x7D7D7D);
            t.Form.TextColor = factory.GetColor(0xFFFFFF);
            #endregion

            #region Quick Access Toolbar Background
            t.QuickAccessToolbar.Active.TopBackground = new LinearGradientColorTable(factory.GetColor(0x7B7E84), factory.GetColor(0x797B80));
            t.QuickAccessToolbar.Active.BottomBackground = new LinearGradientColorTable(factory.GetColor(0x6D6E6E), factory.GetColor(0x444444));
            t.QuickAccessToolbar.Active.OutterBorderColor = factory.GetColor(0x474747);
            t.QuickAccessToolbar.Active.MiddleBorderColor = factory.GetColor(0x353535);
            t.QuickAccessToolbar.Active.InnerBorderColor = Color.Empty;

            t.QuickAccessToolbar.Inactive.TopBackground = new LinearGradientColorTable(factory.GetColor(0xA7A7AA), factory.GetColor(0xB3B3B6));
            t.QuickAccessToolbar.Inactive.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xADADAD), factory.GetColor(0x959595));
            t.QuickAccessToolbar.Inactive.OutterBorderColor = factory.GetColor(0xA9A9A9);
            t.QuickAccessToolbar.Inactive.MiddleBorderColor = factory.GetColor(0x5D5D5D);
            t.QuickAccessToolbar.Inactive.InnerBorderColor = Color.Empty;

            t.QuickAccessToolbar.Standalone.TopBackground = new LinearGradientColorTable();
            t.QuickAccessToolbar.Standalone.BottomBackground = new LinearGradientColorTable(factory.GetColor(0x8D9093), factory.GetColor(0x858789));
            t.QuickAccessToolbar.Standalone.OutterBorderColor = factory.GetColor(0x5D6064);
            t.QuickAccessToolbar.Standalone.MiddleBorderColor = Color.Empty;
            t.QuickAccessToolbar.Standalone.InnerBorderColor = factory.GetColor(0xCBCCCE);

            t.QuickAccessToolbar.QatCustomizeMenuLabelBackground = factory.GetColor(0xEBEBEB);
            t.QuickAccessToolbar.QatCustomizeMenuLabelText = factory.GetColor(0x464646);

            t.QuickAccessToolbar.Active.GlassBorder = new LinearGradientColorTable(factory.GetColor(Color.FromArgb(132, Color.Black)), Color.FromArgb(80, Color.Black));
            t.QuickAccessToolbar.Inactive.GlassBorder = new LinearGradientColorTable(factory.GetColor(Color.FromArgb(132, Color.Black)), Color.FromArgb(80, Color.Black));
            #endregion

            #region Tab Colors
            t.TabControl.Default = new Office2007TabItemStateColorTable();
            t.TabControl.Default.TopBackground = new LinearGradientColorTable(factory.GetColor(0xD8DCE2), factory.GetColor(0xB4BDC7));
            t.TabControl.Default.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xD4D9DF), factory.GetColor(0xEBEBEB));
            t.TabControl.Default.InnerBorder = factory.GetColor(0xEBEBEB);
            t.TabControl.Default.OuterBorder = factory.GetColor(0xAEB0B4);
            t.TabControl.Default.Text = factory.GetColor(0x303030);

            t.TabControl.MouseOver = new Office2007TabItemStateColorTable();
            t.TabControl.MouseOver.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFFFDEB), factory.GetColor(0xFFECA8));
            t.TabControl.MouseOver.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFFDA59), factory.GetColor(0xFFE68D));
            t.TabControl.MouseOver.InnerBorder = factory.GetColor(0xFFFFFB);
            t.TabControl.MouseOver.OuterBorder = factory.GetColor(0xB69D73);
            t.TabControl.MouseOver.Text = factory.GetColor(0x363636);

            t.TabControl.Selected = new Office2007TabItemStateColorTable();
            t.TabControl.Selected.TopBackground = new LinearGradientColorTable(factory.GetColor(0xFFD29B), factory.GetColor(0xFFBB6E));
            t.TabControl.Selected.BottomBackground = new LinearGradientColorTable(factory.GetColor(0xFFAF44), factory.GetColor(0xFEDC75));
            t.TabControl.Selected.InnerBorder = factory.GetColor(0xCDB69C);
            t.TabControl.Selected.OuterBorder = factory.GetColor(0x95774A);
            t.TabControl.Selected.Text = factory.GetColor(0x272727);

            t.TabControl.TabBackground = new LinearGradientColorTable(factory.GetColor(0xFDFDFD), factory.GetColor(0xC3C3C3));
            t.TabControl.TabPanelBackground = new LinearGradientColorTable(factory.GetColor(0xF7F7F7), factory.GetColor(0xC3C3C3));
            t.TabControl.TabPanelBorder = factory.GetColor(0x464646);
            #endregion

            #region CheckBoxItem
            Office2007CheckBoxColorTable chk = t.CheckBoxItem;
            chk.Default.CheckBackground = new LinearGradientColorTable(factory.GetColor(0xF4F4F4), Color.Empty);
            chk.Default.CheckBorder = factory.GetColor(0x848484);
            chk.Default.CheckInnerBackground = new LinearGradientColorTable(Color.FromArgb(192, factory.GetColor(0xA2ACB9)), Color.FromArgb(164, factory.GetColor(0xF6F6F6)));
            chk.Default.CheckInnerBorder = factory.GetColor(0xA2ACB9);
            chk.Default.CheckSign = new LinearGradientColorTable(factory.GetColor(0x4F687D), Color.Empty);
            chk.Default.Text = factory.GetColor(0x000000);

            chk.MouseOver.CheckBackground = new LinearGradientColorTable(factory.GetColor(0xF4F4F4), Color.Empty);
            chk.MouseOver.CheckBorder = factory.GetColor(0x848484);
            chk.MouseOver.CheckInnerBackground = new LinearGradientColorTable(Color.FromArgb(192, factory.GetColor(0xFAD57A)), Color.FromArgb(128, factory.GetColor(0xFEF8E7)));
            chk.MouseOver.CheckInnerBorder = factory.GetColor(0xFAD57A);
            chk.MouseOver.CheckSign = new LinearGradientColorTable(factory.GetColor(0x4F687D), Color.Empty);
            chk.MouseOver.Text = factory.GetColor(0x000000);

            chk.Pressed.CheckBackground = new LinearGradientColorTable(factory.GetColor(0xE5ECF7), Color.Empty);
            chk.Pressed.CheckBorder = factory.GetColor(0x848484);
            chk.Pressed.CheckInnerBackground = new LinearGradientColorTable(Color.FromArgb(192, factory.GetColor(0xF28926)), Color.FromArgb(164, factory.GetColor(0xFFF4D5)));
            chk.Pressed.CheckInnerBorder = factory.GetColor(0xF28926);
            chk.Pressed.CheckSign = new LinearGradientColorTable(factory.GetColor(0x4F687D), Color.Empty);
            chk.Pressed.Text = factory.GetColor(0x000000);

            chk.Disabled.CheckBackground = new LinearGradientColorTable(factory.GetColor(0xFFFFFF), Color.Empty);
            chk.Disabled.CheckBorder = factory.GetColor(0xAEB1B5);
            chk.Disabled.CheckInnerBackground = new LinearGradientColorTable(Color.FromArgb(192, factory.GetColor(0xE0E2E5)), Color.FromArgb(164, factory.GetColor(0xFBFBFB)));
            chk.Disabled.CheckInnerBorder = factory.GetColor(0xE0E2E5);
            chk.Disabled.CheckSign = new LinearGradientColorTable(factory.GetColor(0x8D8D8D), Color.Empty);
            chk.Disabled.Text = factory.GetColor(0x8D8D8D);
            #endregion

            #region Scroll Bar
            InitializeScrollBarColorTable(t, factory);
            InitializeAppBlackScrollBarColorTable(t, factory);
            #endregion

            #region ProgressBarItem
            Office2007ProgressBarColorTable pct = t.ProgressBarItem;
            pct.BackgroundColors = new GradientColorTable(0x87898B, 0x979897);
            pct.OuterBorder = factory.GetColor(0xCCCCCC);
            pct.InnerBorder = factory.GetColor(0x252525);
            pct.Chunk = new GradientColorTable(0x679720, 0xC2FF56, 0);
            pct.ChunkOverlay = new GradientColorTable();
            pct.ChunkOverlay.LinearGradientAngle = 90;
            pct.ChunkOverlay.Colors.AddRange(new BackgroundColorBlend[] {
                new BackgroundColorBlend(Color.FromArgb(164, factory.GetColor(0xEEFFD7)), 0f),
                new BackgroundColorBlend(Color.FromArgb(128, factory.GetColor(0x8DB254)), .5f),
                new BackgroundColorBlend(Color.FromArgb(64, factory.GetColor(0x69922B)), .5f),
                new BackgroundColorBlend(Color.Transparent, 1f),
            });
            pct.ChunkShadow = new GradientColorTable(0x858585, 0x909190, 0);

            // Paused
            pct = t.ProgressBarItemPaused;
            pct.BackgroundColors = new GradientColorTable(0x87898B, 0x979897);
            pct.OuterBorder = factory.GetColor(0xCCCCCC);
            pct.InnerBorder = factory.GetColor(0x252525);
            pct.Chunk = new GradientColorTable(0xAEA700, 0xFFFDCD, 0);
            pct.ChunkOverlay = new GradientColorTable();
            pct.ChunkOverlay.LinearGradientAngle = 90;
            pct.ChunkOverlay.Colors.AddRange(new BackgroundColorBlend[] {
                new BackgroundColorBlend(Color.FromArgb(192, factory.GetColor(0xFFFBA3)), 0f),
                new BackgroundColorBlend(Color.FromArgb(128, factory.GetColor(0xD2CA00)), .5f),
                new BackgroundColorBlend(Color.FromArgb(64, factory.GetColor(0xFEF400)), .5f),
                new BackgroundColorBlend(Color.Transparent, 1f),
            });
            pct.ChunkShadow = new GradientColorTable(0x858585, 0x909190, 0);

            // Error
            pct = t.ProgressBarItemError;
            pct.BackgroundColors = new GradientColorTable(0x87898B, 0x979897);
            pct.OuterBorder = factory.GetColor(0xCCCCCC);
            pct.InnerBorder = factory.GetColor(0x252525);
            pct.Chunk = new GradientColorTable(0xD20000, 0xFFCDCD, 0);
            pct.ChunkOverlay = new GradientColorTable();
            pct.ChunkOverlay.LinearGradientAngle = 90;
            pct.ChunkOverlay.Colors.AddRange(new BackgroundColorBlend[] {
                new BackgroundColorBlend(Color.FromArgb(192, factory.GetColor(0xFF8F8F)), 0f),
                new BackgroundColorBlend(Color.FromArgb(128, factory.GetColor(0xD20000)), .5f),
                new BackgroundColorBlend(Color.FromArgb(64, factory.GetColor(0xFE0000)), .5f),
                new BackgroundColorBlend(Color.Transparent, 1f),
            });
            pct.ChunkShadow = new GradientColorTable(0x858585, 0x909190, 0);
            #endregion

            #region Gallery
            Office2007GalleryColorTable gallery = t.Gallery;
            gallery.GroupLabelBackground = factory.GetColor(0xEBEBEB);
            gallery.GroupLabelText = factory.GetColor(0x000000);
            gallery.GroupLabelBorder = factory.GetColor(0xC5C5C5);
            #endregion

            #region ListViewEx
            t.ListViewEx.Border = factory.GetColor(0x4C535C);
            t.ListViewEx.ColumnBackground = new LinearGradientColorTable(factory.GetColor(0xFFFFFF), factory.GetColor(0xD4D7DB));
            t.ListViewEx.ColumnSeparator = factory.GetColor(0x9199A4);
            t.ListViewEx.SelectionBackground = new LinearGradientColorTable(factory.GetColor(0xA7CDF0), Color.Empty);
            t.ListViewEx.SelectionBorder = factory.GetColor(0xE3EFFF);
            #endregion

            #region Navigation Pane
            t.NavigationPane.ButtonBackground = new GradientColorTable();
            t.NavigationPane.ButtonBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xF8F8F9), 0));
            t.NavigationPane.ButtonBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xDFE2E4), .4f));
            t.NavigationPane.ButtonBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xC7CBD1), .4f));
            t.NavigationPane.ButtonBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xDBDEE2), 1));
            #endregion

            #region SuperTooltip
            t.SuperTooltip.BackgroundColors = new LinearGradientColorTable(factory.GetColor(0xFFFFFF), factory.GetColor(0xE4E4F0));
            t.SuperTooltip.TextColor = factory.GetColor(0x4C4C4C);
            #endregion

            #region Slider
            Office2007SliderColorTable sl = t.Slider;
            sl.Default.LabelColor = factory.GetColor(0xFFFFFF);
            sl.Default.PartBackground = new GradientColorTable();
            sl.Default.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFFFFFF), 0));
            sl.Default.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xEFEFEF), .15f));
            sl.Default.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xBEC2C3), .5f));
            sl.Default.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0x6C7178), .5f));
            sl.Default.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xDCDCDE), .85f));
            sl.Default.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFFFFFF), 1f));
            sl.Default.PartBorderColor = factory.GetColor(0x393F46);
            sl.Default.PartBorderLightColor = Color.FromArgb(28, factory.GetColor(0xFFFFFF));
            sl.Default.PartForeColor = factory.GetColor(0x5B636C);
            sl.Default.PartForeLightColor = Color.FromArgb(168, factory.GetColor(0xEAEAEA));
            sl.Default.TrackLineColor = factory.GetColor(0x252525);
            sl.Default.TrackLineLightColor = factory.GetColor(0xCCCCCC);

            sl.MouseOver.LabelColor = factory.GetColor(0xFFFFFF);
            sl.MouseOver.PartBackground = new GradientColorTable();
            sl.MouseOver.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFFFFFF), 0));
            sl.MouseOver.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFFFFFE), .2f));
            sl.MouseOver.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xF4DB93), .5f));
            sl.MouseOver.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xEEBA27), .5f));
            sl.MouseOver.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFCEEBF), .85f));
            sl.MouseOver.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xFAF0D2), 1f));
            sl.MouseOver.PartBorderColor = factory.GetColor(0x2D2D2D);
            sl.MouseOver.PartBorderLightColor = Color.FromArgb(28, factory.GetColor(0xFFFFFF));
            sl.MouseOver.PartForeColor = factory.GetColor(0x676249);
            sl.MouseOver.PartForeLightColor = Color.FromArgb(168, factory.GetColor(0xFFF4D4));
            sl.MouseOver.TrackLineColor = factory.GetColor(0x252525);
            sl.MouseOver.TrackLineLightColor = factory.GetColor(0xCCCCCC);

            sl.Pressed.LabelColor = factory.GetColor(0xFFFFFF);
            sl.Pressed.PartBackground = new GradientColorTable();
            sl.Pressed.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xE68C3A), 0));
            sl.Pressed.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xF2A253), .2f));
            sl.Pressed.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xF9C18B), .5f));
            sl.Pressed.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xF38317), .5f));
            sl.Pressed.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xF8BD86), .85f));
            sl.Pressed.PartBackground.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xF3D2B4), 1f));
            sl.Pressed.PartBorderColor = factory.GetColor(0x2D2D2D);
            sl.Pressed.PartBorderLightColor = Color.FromArgb(28, factory.GetColor(0xFFFFFF));
            sl.Pressed.PartForeColor = factory.GetColor(0x675343);
            sl.Pressed.PartForeLightColor = Color.FromArgb(168, factory.GetColor(0xFFDCBB));
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
            t.DataGridView.ColumnHeaderNormalBorder = factory.GetColor(0xB6B6B6);
            t.DataGridView.ColumnHeaderNormalBackground = new LinearGradientColorTable(factory.GetColor(0xF8F8F8), factory.GetColor(0xDEDEDE), 90);
            t.DataGridView.ColumnHeaderSelectedBackground = new LinearGradientColorTable(factory.GetColor(0xF9D99F), factory.GetColor(0xF1C15F), 90);
            t.DataGridView.ColumnHeaderSelectedBorder = factory.GetColor(0xF29536);
            t.DataGridView.ColumnHeaderSelectedMouseOverBackground = new LinearGradientColorTable(factory.GetColor(0xFFD58D), factory.GetColor(0xF2923A), 90);
            t.DataGridView.ColumnHeaderSelectedMouseOverBorder = factory.GetColor(0xF29536);
            t.DataGridView.ColumnHeaderMouseOverBackground = new LinearGradientColorTable(factory.GetColor(0xE0E0E0), factory.GetColor(0xC3C3C3), 90);
            t.DataGridView.ColumnHeaderMouseOverBorder = factory.GetColor(0xB6B6B6);
            t.DataGridView.ColumnHeaderPressedBackground = new LinearGradientColorTable(factory.GetColor(0xE0E0E0), factory.GetColor(0xC3C3C3), 90);
            t.DataGridView.ColumnHeaderPressedBorder = factory.GetColor(0xFFFFFF);

            t.DataGridView.RowNormalBackground = new LinearGradientColorTable(factory.GetColor(0xEDEDED));
            t.DataGridView.RowNormalBorder = factory.GetColor(0xB6B6B6);
            t.DataGridView.RowSelectedBackground = new LinearGradientColorTable(factory.GetColor(0xFFD58D));
            t.DataGridView.RowSelectedBorder = factory.GetColor(0xF29536);
            t.DataGridView.RowSelectedMouseOverBackground = new LinearGradientColorTable(factory.GetColor(0xF1C05C));
            t.DataGridView.RowSelectedMouseOverBorder = factory.GetColor(0xF29536);
            t.DataGridView.RowMouseOverBackground = new LinearGradientColorTable(factory.GetColor(0xF1C05C));
            t.DataGridView.RowMouseOverBorder = factory.GetColor(0xB6B6B6);
            t.DataGridView.RowPressedBackground = new LinearGradientColorTable(factory.GetColor(0xF1C05C));
            t.DataGridView.RowPressedBorder = factory.GetColor(0xFFFFFF);

            t.DataGridView.GridColor = factory.GetColor(0xD0D7E5);

            t.DataGridView.SelectorBackground = new LinearGradientColorTable(factory.GetColor(0xC9C9C9));
            t.DataGridView.SelectorBorder = factory.GetColor(0xB6B6B6);
            t.DataGridView.SelectorBorderDark = factory.GetColor(0xCCCCCC);
            t.DataGridView.SelectorBorderLight = factory.GetColor(0xEBEBEB);
            t.DataGridView.SelectorSign = new LinearGradientColorTable(factory.GetColor(0x7D7D7D), factory.GetColor(0x676767));

            t.DataGridView.SelectorMouseOverBackground = new LinearGradientColorTable(factory.GetColor(0xADADAD), factory.GetColor(0x9F9F9F));
            t.DataGridView.SelectorMouseOverBorder = factory.GetColor(0xB6B6B6);
            t.DataGridView.SelectorMouseOverBorderDark = factory.GetColor(0xCCCCCC);
            t.DataGridView.SelectorMouseOverBorderLight = factory.GetColor(0xEBEBEB);
            t.DataGridView.SelectorMouseOverSign = new LinearGradientColorTable(factory.GetColor(0x7D7D7D), factory.GetColor(0x676767));
            #endregion

            #region ElementStyle Classes
            t.StyleClasses.Clear();
            ElementStyle style = new ElementStyle();
            style.Class = ElementStyleClassKeys.RibbonGalleryContainerKey;
            style.BorderColor = factory.GetColor(0xACACAC);
            style.Border = StyleBorderType.Solid;
            style.BorderWidth = 1;
            style.CornerDiameter = 2;
            style.CornerType = CornerType.Rounded;
            style.BackColor = factory.GetColor(0xDAE2E2);
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
            style = Office2007ColorTableFactory.GetTextBoxStyle(factory.GetColor(0x898989));
            t.StyleClasses.Add(style.Class, style);
            // Ribbon Client Panel
            style = Office2007ColorTableFactory.GetRibbonClientPanelStyle(factory, eOffice2007ColorScheme.Black);
            t.StyleClasses.Add(style.Class, style);
            // ListView Border
            style = Office2007ColorTableFactory.GetListViewBorderStyle(t.ListViewEx);
            t.StyleClasses.Add(style.Class, style);
            style = Office2007ColorTableFactory.GetStatusBarAltStyle(t.Bar);
            t.StyleClasses.Add(style.Class, style);
            #endregion

            #region SideBar
            t.SideBar.Background = new LinearGradientColorTable(factory.GetColor(Color.White));
            t.SideBar.Border = factory.GetColor(0xA7ADB6);
            t.SideBar.SideBarPanelItemText = factory.GetColor(Color.Black);
            t.SideBar.SideBarPanelItemDefault = new GradientColorTable();
            t.SideBar.SideBarPanelItemDefault.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xF8F8F9), 0));
            t.SideBar.SideBarPanelItemDefault.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xDFE2E4), .4f));
            t.SideBar.SideBarPanelItemDefault.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xC7CBD1), .4f));
            t.SideBar.SideBarPanelItemDefault.Colors.Add(new BackgroundColorBlend(factory.GetColor(0xDBDEE2), 1));
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
        }

        /// <summary>
        /// Initializes ColorScheme object with the black color scheme.
        /// </summary>
        /// <param name="c">ColorScheme object to initialize.</param>
        public static void InitializeBlackLegacyColors(ColorScheme c, ColorFactory factory)
        {
            c.BarBackground = factory.GetColor(0xCDD0D5);
            c.BarBackground2 = factory.GetColor(0x8B929B);
            c.BarStripeColor = factory.GetColor(0x373C43);
            c.BarCaptionBackground = factory.GetColor(0x76808E);
            c.BarCaptionBackground2 = factory.GetColor(0x4C535C);
            c.BarCaptionInactiveBackground = factory.GetColor(0xF0F1F2);
            c.BarCaptionInactiveBackground2 = factory.GetColor(0xBDC2C9);
            c.BarCaptionInactiveText = factory.GetColor(0x373C43);
            c.BarCaptionText = factory.GetColor(0xFFFFFF);
            c.BarFloatingBorder = factory.GetColor(0x373C43);
            c.BarPopupBackground = factory.GetColor(0xF6F6F6);
            c.BarPopupBorder = factory.GetColor(0x9199A4);
            c.ItemBackground = Color.Empty;
            c.ItemBackground2 = Color.Empty;
            c.ItemCheckedBackground = factory.GetColor(0xFFD36A);
            c.ItemCheckedBackground2 = factory.GetColor(0xFBC84F);
            c.ItemCheckedBorder = factory.GetColor(0xBB5503);
            c.ItemCheckedText = factory.GetColor(0x000000);
            c.ItemDisabledBackground = Color.Empty;
            c.ItemDisabledText = factory.GetColor(0x8D8D8D);
            c.ItemExpandedShadow = Color.Empty;
            c.ItemExpandedBackground = factory.GetColor(0x9199A4);
            c.ItemExpandedBackground2 = factory.GetColor(0x656E7A);
            c.ItemExpandedText = factory.GetColor(0x000000);
            c.ItemHotBackground = factory.GetColor(0xFFF5CC);
            c.ItemHotBackground2 = factory.GetColor(0xFFDB75);
            c.ItemHotBorder = factory.GetColor(0xFFBD69);
            c.ItemHotText = factory.GetColor(0x000000);
            c.ItemPressedBackground = factory.GetColor(0xFC973D);
            c.ItemPressedBackground2 = factory.GetColor(0xFFB85E);
            c.ItemPressedBorder = factory.GetColor(0xFB8C3C);
            c.ItemPressedText = factory.GetColor(0x000000);
            c.ItemSeparator = Color.FromArgb(225, factory.GetColor(0x9199A4));
            c.ItemSeparatorShade = Color.FromArgb(180, factory.GetColor(0xFFFFFF));
            c.ItemText = factory.GetColor(0x000000); // SystemColors.ControlText;
            c.MenuBackground = factory.GetColor(0xF6F6F6);
            c.MenuBackground2 = Color.Empty; // Color.White;
            c.MenuBarBackground = factory.GetColor(0x535353);
            c.MenuBorder = factory.GetColor(0x9199A4);
            c.ItemExpandedBorder = c.MenuBorder;
            c.MenuSide = factory.GetColor(0xEFEFEF);
            c.MenuSide2 = Color.Empty; // factory.GetColor(0xDDE0E8);
            c.MenuUnusedBackground = c.MenuBackground;
            c.MenuUnusedSide = factory.GetColor(0xE9E9E9);
            c.MenuUnusedSide2 = Color.Empty;// System.Windows.Forms.ControlPaint.Light(c.MenuSide2);
            c.ItemDesignTimeBorder = Color.Black;
            c.BarDockedBorder = factory.GetColor(0x4C535C);

            c.DockSiteBackColor = factory.GetColor(0x535353);
            c.DockSiteBackColor2 = Color.Empty;

            c.CustomizeBackground = factory.GetColor(0xB2B7BF);
            c.CustomizeBackground2 = factory.GetColor(0x515862);
            c.CustomizeText = factory.GetColor(0x000000);

            c.PanelBackground = factory.GetColor(0xF0F1F2);
            c.PanelBackground2 = factory.GetColor(0xBDC2C9);
            c.PanelText = Color.Black;
            c.PanelBorder = factory.GetColor(0xA7ADB6);

            c.ExplorerBarBackground = factory.GetColor(0xF0F1F2);
            c.ExplorerBarBackground2 = factory.GetColor(0xBDC2C9);
        }
        #endregion

        #region Style Class Creation
        public static ElementStyle GetFileMenuContainerStyle(Office2007ColorTable table)
        {
            ElementStyle style = new ElementStyle();
            style.Class = ElementStyleClassKeys.RibbonFileMenuContainerKey;
            Rendering.Office2007MenuColorTable mc = table.Menu;
            
            style.PaddingBottom = 3;
            style.PaddingLeft = 3;
            style.PaddingRight = 3;
            style.PaddingTop = 12;
            BackgroundColorBlend[] blend = new BackgroundColorBlend[mc.FileBackgroundBlend.Count];
            mc.FileBackgroundBlend.CopyTo(blend);
            style.BackColorBlend.Clear();
            style.BackColorBlend.AddRange(blend);

            return style;
        }

        public static ElementStyle GetTwoColumnMenuContainerStyle(Office2007ColorTable table)
        {
            ElementStyle style = new ElementStyle();
            style.Class = ElementStyleClassKeys.RibbonFileMenuTwoColumnContainerKey;
            Rendering.Office2007MenuColorTable mc = table.Menu;

            style.BorderBottom = HVTT.UI.Window.Forms.StyleBorderType.Double;
            style.BorderBottomWidth = 1;
            style.BorderColor = mc.FileContainerBorder;
            style.BorderColorLight = mc.FileContainerBorderLight;
            style.BorderLeft = HVTT.UI.Window.Forms.StyleBorderType.Double;
            style.BorderLeftWidth = 1;
            style.BorderRight = HVTT.UI.Window.Forms.StyleBorderType.Double;
            style.BorderRightWidth = 1;
            style.BorderTop = HVTT.UI.Window.Forms.StyleBorderType.Double;
            style.BorderTopWidth = 1;
            style.PaddingBottom = 2;
            style.PaddingLeft = 2;
            style.PaddingRight = 2;
            style.PaddingTop = 2;

            return style;
        }

        public static ElementStyle GetMenuColumnOneContainerStyle(Office2007ColorTable table)
        {
            ElementStyle style = new ElementStyle();
            style.Class = ElementStyleClassKeys.RibbonFileMenuColumnOneContainerKey;
            Rendering.Office2007MenuColorTable mc = table.Menu;

            style.BackColor = mc.FileColumnOneBackground;
            style.BorderRight = HVTT.UI.Window.Forms.StyleBorderType.Solid;
            style.BorderRightColor = mc.FileColumnOneBorder;
            style.BorderRightWidth = 1;
            style.PaddingRight = 1;

            return style;
        }

        public static ElementStyle GetMenuColumnTwoContainerStyle(Office2007ColorTable table)
        {
            ElementStyle style = new ElementStyle();
            style.Class = ElementStyleClassKeys.RibbonFileMenuColumnTwoContainerKey;
            Rendering.Office2007MenuColorTable mc = table.Menu;

            style.BackColor = mc.FileColumnTwoBackground;

            return style;
        }

        public static ElementStyle GetMenuBottomContainer(Office2007ColorTable table)
        {
            ElementStyle style = new ElementStyle();
            style.Class = ElementStyleClassKeys.RibbonFileMenuBottomContainerKey;
            Rendering.Office2007MenuColorTable mc = table.Menu;

            BackgroundColorBlend[] blend = new BackgroundColorBlend[mc.FileBottomContainerBackgroundBlend.Count];
            mc.FileBottomContainerBackgroundBlend.CopyTo(blend);
            style.BackColorBlend.Clear();
            style.BackColorBlend.AddRange(blend);
            style.BackColorGradientAngle = 90;

            return style;
        }

        public static ElementStyle GetTextBoxStyle(Color borderColor)
        {
            ElementStyle style = new ElementStyle();
            style.Class = ElementStyleClassKeys.TextBoxBorderKey;
            style.BorderColor = borderColor;
            style.BorderWidth = 1;
            style.Border = StyleBorderType.Solid;
            style.PaddingBottom = 3;
            style.PaddingTop = 2;
            style.PaddingLeft = 2;
            style.PaddingRight = 2;
            return style;
        }

        public static ElementStyle GetRibbonClientPanelStyle(ColorFactory f, eOffice2007ColorScheme cs)
        {
            ElementStyle style = new ElementStyle();
            style.Class = ElementStyleClassKeys.RibbonClientPanelKey;

            style.BackColorGradientAngle = 90;

            if (cs == eOffice2007ColorScheme.Blue)
            {
                style.BackColorBlend.Add(new BackgroundColorBlend(f.GetColor(0xBED4F0), 0));
                style.BackColorBlend.Add(new BackgroundColorBlend(f.GetColor(0x567DB1), .8f));
                style.BackColorBlend.Add(new BackgroundColorBlend(f.GetColor(0x6591CD), 1));
            }
            else if (cs == eOffice2007ColorScheme.Silver)
            {
                style.BackColorBlend.Add(new BackgroundColorBlend(f.GetColor(0xCCCFD8), 0));
                style.BackColorBlend.Add(new BackgroundColorBlend(f.GetColor(0xABAEB6), .8f));
                style.BackColorBlend.Add(new BackgroundColorBlend(f.GetColor(0x9B9FA6), 1));
            }
            else if (cs == eOffice2007ColorScheme.Black)
            {
                style.BackColorBlend.Add(new BackgroundColorBlend(f.GetColor(0x7E7E7E), 0));
                style.BackColorBlend.Add(new BackgroundColorBlend(f.GetColor(0x363636), .8f));
                style.BackColorBlend.Add(new BackgroundColorBlend(f.GetColor(0x0A0A0A), 1));
            }

            return style;
        }

        public static ElementStyle GetListViewBorderStyle(Office2007ListViewColorTable lvct)
        {
            ElementStyle style = new ElementStyle();
            style.Class = ElementStyleClassKeys.ListViewBorderKey;

            style.Border = StyleBorderType.Solid;
            style.BorderWidth = 1;
            style.CornerType = CornerType.Square;
            style.BorderColor = lvct.Border;
            
            return style;
        }

        public static ElementStyle GetStatusBarAltStyle(Office2007BarColorTable t)
        {
            ElementStyle style = new ElementStyle();
            style.Class = ElementStyleClassKeys.Office2007StatusBarBackground2Key;
            style.PaddingLeft = 4;
            style.BorderLeft = StyleBorderType.Etched;
            style.BorderLeftWidth = 1;
            style.BorderLeftColor = Color.FromArgb(196, t.StatusBarTopBorder);
            style.BorderColorLight = Color.FromArgb(128, Color.White);
            if (t.StatusBarAltBackground.Count > 0)
            {
                style.BackColorBlend.CopyFrom(t.StatusBarAltBackground);
                style.BackColorGradientAngle = 90;
            }

            return style;
        }
        #endregion
    }
}
