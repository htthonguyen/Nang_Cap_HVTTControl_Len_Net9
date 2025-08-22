using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HVTT.UI.Window.Forms
{
    internal class MessageBoxDialog : Office2007Form
    {
        private HVTTButton Button1;
        private HVTTButton Button2;
        private HVTTButton Button3;
        private PictureBox PictureBox1;
        private HVTTPanel TextPanel;
        private HVTTControlStyle m_Style = HVTTControlStyle.Office2007;
        private bool m_Button1Visible = true;
        private bool m_Button2Visible = true;
        private bool m_Button3Visible = true;
        private MessageBoxButtons m_Buttons = MessageBoxButtons.OK;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MessageBoxDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Button1 = new HVTT.UI.Window.Forms.HVTTButton();
            this.Button2 = new HVTT.UI.Window.Forms.HVTTButton();
            this.Button3 = new HVTT.UI.Window.Forms.HVTTButton();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.TextPanel = new HVTT.UI.Window.Forms.HVTTPanel();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Button1.ColorTable = HVTT.UI.Window.Forms.eButtonColor.OrangeWithBackground;
            this.Button1.Location = new System.Drawing.Point(26, 85);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(77, 24);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "&OK";
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Button2
            // 
            this.Button2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Button2.ColorTable = HVTT.UI.Window.Forms.eButtonColor.OrangeWithBackground;
            this.Button2.Location = new System.Drawing.Point(109, 85);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(77, 24);
            this.Button2.TabIndex = 1;
            this.Button2.Text = "&Cancel";
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button3
            // 
            this.Button3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Button3.ColorTable = HVTT.UI.Window.Forms.eButtonColor.OrangeWithBackground;
            this.Button3.Location = new System.Drawing.Point(192, 85);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(77, 24);
            this.Button3.TabIndex = 2;
            this.Button3.Text = "&Ignore";
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.Location = new System.Drawing.Point(10, 10);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(32, 32);
            this.PictureBox1.TabIndex = 3;
            this.PictureBox1.TabStop = false;
            // 
            // TextPanel
            // 
            this.TextPanel.AntiAlias = false;
            this.TextPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.TextPanel.Location = new System.Drawing.Point(53, 10);
            this.TextPanel.Name = "TextPanel";
            this.TextPanel.Size = new System.Drawing.Size(225, 53);
            this.TextPanel.Style.Border = HVTT.UI.Window.Forms.eBorderType.SingleLine;
            this.TextPanel.Style.BorderWidth = 0;
            this.TextPanel.Style.ForeColor.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.ItemText;
            this.TextPanel.Style.GradientAngle = 90;
            this.TextPanel.Style.LineAlignment = System.Drawing.StringAlignment.Near;
            this.TextPanel.TabIndex = 4;
            this.TextPanel.Style.WordWrap = true;
            // 
            // MessageBoxDialog
            // 

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(290, 121);
            this.ShowInTaskbar = false;
            this.Controls.Add(this.TextPanel);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageBoxDialog";
            this.ResumeLayout(false);

        }

        #endregion


        public DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, bool topMost)
        {
            m_Buttons = buttons;
            this.Text = caption;
            TextPanel.Text = text;
            if (icon != MessageBoxIcon.None)
                PictureBox1.Image = GetSytemImage(icon);
            else
            {
                PictureBox1.Image = null;
                PictureBox1.Visible = false;
            }

            if (m_Style != HVTTControlStyle.Office2007)
                this.EnableCustomStyle = false;

            if (buttons == MessageBoxButtons.OKCancel || buttons == MessageBoxButtons.RetryCancel || buttons == MessageBoxButtons.YesNo)
            {
                Button3.Visible = false;
                m_Button3Visible = false;
            }
            else if (buttons == MessageBoxButtons.OK)
            {
                Button2.Visible = false;
                Button3.Visible = false;
                m_Button2Visible = false;
                m_Button3Visible = false;
            }

            // Set Cancel and Accept buttons
            if (buttons == MessageBoxButtons.OK)
            {
                this.AcceptButton = Button1;
                this.CancelButton = Button1;
            }
            else if (buttons == MessageBoxButtons.OKCancel || buttons == MessageBoxButtons.RetryCancel || buttons == MessageBoxButtons.YesNo)
            {
                this.AcceptButton = Button1;
                this.CancelButton = Button2;
            }
            else if (buttons == MessageBoxButtons.YesNoCancel)
            {
                this.AcceptButton = Button1;
                this.CancelButton = Button3;
            }

            SetButtonText(buttons);

            if (defaultButton == MessageBoxDefaultButton.Button1 && m_Button1Visible)
            {
                Button1.Select();
                this.AcceptButton = Button1;
            }
            else if (defaultButton == MessageBoxDefaultButton.Button2 && m_Button2Visible)
            {
                this.AcceptButton = Button2;
                Button2.Select();
            }
            else if (defaultButton == MessageBoxDefaultButton.Button3 && m_Button3Visible)
            {
                this.AcceptButton = Button3;
                Button3.Select();
            }

            ResizeDialog();

            SetupColors();

            if (icon == MessageBoxIcon.Question)
                System.Media.SystemSounds.Question.Play(); // NativeFunctions.sndPlaySound("SystemQuestion", NativeFunctions.SND_ASYNC | NativeFunctions.SND_NODEFAULT);
            else if (icon == MessageBoxIcon.Asterisk)
                System.Media.SystemSounds.Asterisk.Play(); // NativeFunctions.sndPlaySound("SystemAsterisk", NativeFunctions.SND_ASYNC | NativeFunctions.SND_NODEFAULT);
            else
                System.Media.SystemSounds.Exclamation.Play(); // NativeFunctions.sndPlaySound("SystemExclamation", NativeFunctions.SND_ASYNC | NativeFunctions.SND_NODEFAULT);


            if(this.TopMost!=topMost)
                this.TopMost = topMost;
            return this.ShowDialog(owner);
        }

        private void SetupColors()
        {
            if (m_Style == HVTTControlStyle.Office2007 && Rendering.GlobalManager.Renderer is Rendering.Office2007Renderer)
            {
                if (WinApi.IsGlassEnabled)
                {
                    this.TextPanel.Style.ForeColor.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.Custom;
                    this.TextPanel.Style.ForeColor.Color = SystemColors.ControlText;
                }
                else
                {
                    Rendering.Office2007ColorTable ct = ((Rendering.Office2007Renderer)Rendering.GlobalManager.Renderer).ColorTable;
                    this.TextPanel.Style.ForeColor.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.Custom;
                    this.TextPanel.Style.ForeColor.Color = ct.Form.TextColor;
                }
            }
        }

        private void SetButtonText(MessageBoxButtons buttons)
        {
            if (buttons == MessageBoxButtons.AbortRetryIgnore)
            {
                Button1.Text = GetString(SystemStrings.Abort);
                Button2.Text = GetString(SystemStrings.Retry);
                Button3.Text = GetString(SystemStrings.Ignore);
            }
            else if (buttons == MessageBoxButtons.OK)
            {
                Button1.Text = GetString(SystemStrings.OK);
            }
            else if (buttons == MessageBoxButtons.OKCancel)
            {
                Button1.Text = GetString(SystemStrings.OK);
                Button2.Text = GetString(SystemStrings.Cancel);
            }
            else if (buttons == MessageBoxButtons.RetryCancel)
            {
                Button1.Text = GetString(SystemStrings.Retry);
                Button2.Text = GetString(SystemStrings.Cancel);
            }
            else if (buttons == MessageBoxButtons.YesNo)
            {
                Button1.Text = GetString(SystemStrings.Yes);
                Button2.Text = GetString(SystemStrings.No);
            }
            else if (buttons == MessageBoxButtons.YesNoCancel)
            {
                Button1.Text = GetString(SystemStrings.Yes);
                Button2.Text = GetString(SystemStrings.No);
                Button3.Text = GetString(SystemStrings.Cancel);
            }
        }

        private Image GetSytemImage(MessageBoxIcon icon)
        {
            Icon ico = null;
            if (icon == MessageBoxIcon.Asterisk)
                ico = SystemIcons.Asterisk;
            else if (icon == MessageBoxIcon.Error || icon == MessageBoxIcon.Stop)
                ico = SystemIcons.Error;
            else if (icon == MessageBoxIcon.Exclamation)
                ico = SystemIcons.Exclamation;
            else if (icon == MessageBoxIcon.Hand)
                ico = SystemIcons.Hand;
            else if (icon == MessageBoxIcon.Information)
                ico = SystemIcons.Information;
            else if (icon == MessageBoxIcon.Question)
                ico = SystemIcons.Question;
            else if (icon == MessageBoxIcon.Warning)
                ico = SystemIcons.Warning;

            Bitmap bmp = new Bitmap(ico.Width, ico.Height);
            bmp.MakeTransparent();
            using (Graphics g = Graphics.FromImage(bmp))
            {
                if (System.Environment.Version.Build <= 3705 && System.Environment.Version.Revision == 288 && System.Environment.Version.Major == 1 && System.Environment.Version.Minor == 0)
                {
                    IntPtr hdc = g.GetHdc();
                    try
                    {
                        NativeFunctions.DrawIconEx(hdc, 0, 0, ico.Handle, ico.Width, ico.Height, 0, IntPtr.Zero, 3);
                    }
                    finally
                    {
                        g.ReleaseHdc(hdc);
                    }
                }
                else if (ico.Handle != IntPtr.Zero)
                {
                    try
                    {
                        g.DrawIcon(ico, 0,0);
                    }
                    catch { }
                }
            }
            return bmp;
        }

        private void ResizeDialog()
        {
            Size size = Size.Empty;
            int buttonSpacing = 6;
            int buttonMargin = 40;
            int textMargin = 10;
            int minTextSize = 110;

            if (PictureBox1.Image!=null)
            {
                TextPanel.Left = PictureBox1.Bounds.Right + 16;
            }
            else
                TextPanel.Left = PictureBox1.Left;

            TextPanel.Size = TextPanel.GetAutoSize();
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            if (TextPanel.Size.Width > workingArea.Width / 3)
                TextPanel.Size = TextPanel.GetAutoSize(workingArea.Width / 3);
            else if (TextPanel.Size.Width < minTextSize)
                TextPanel.Width = minTextSize;
            
            // Measure the caption size
            if (this.Text.Length > 0)
            {
                Size captionSize = Size.Empty;
                Font font = this.Font;
                using (Graphics g = BarFunctions.CreateGraphics(this))
                {
                    size = TextDrawing.MeasureString(g, this.Text, font);
                }
                size.Width += 2;
                size.Height += 2;
                if (size.Width > TextPanel.Width)
                    TextPanel.Width = size.Width;
            }

            int y = Math.Max(TextPanel.Bounds.Bottom, PictureBox1.Bounds.Bottom);
            y += 16;

            Button1.Top = y;
            Button2.Top = y;
            Button3.Top = y;

            int buttonWidth = Button1.Width +
                (m_Button2Visible ? Button2.Width + buttonSpacing : 0) +
                (m_Button3Visible ? Button3.Width + buttonSpacing : 0);

            int buttonArea = buttonWidth + buttonMargin * 2;
            if (buttonWidth < TextPanel.Bounds.Right + textMargin)
                buttonArea = TextPanel.Bounds.Right + textMargin;
            else
            {
                TextPanel.Width += buttonArea - TextPanel.Bounds.Right - textMargin;
            }
           
            // Arrange buttons inside of the available area
            int x = (buttonArea - buttonWidth) / 2;
            Button1.Left = x;
            x += Button1.Width + buttonSpacing;

            if (m_Button2Visible)
            {
                Button2.Left = x;
                x += Button2.Width + buttonSpacing;
            }

            if (m_Button3Visible)
            {
                Button3.Left = x;
                x += Button3.Width + buttonSpacing;
            }

            size = new Size(TextPanel.Bounds.Right + textMargin + SystemInformation.FixedFrameBorderSize.Width * 2,
                Button1.Bounds.Bottom + textMargin + +SystemInformation.FixedFrameBorderSize.Height * 2 + SystemInformation.CaptionHeight);

            this.Size = size;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult r = DialogResult.OK;
            if (m_Buttons == MessageBoxButtons.OK || m_Buttons == MessageBoxButtons.OKCancel)
                r = DialogResult.OK;
            else if (m_Buttons == MessageBoxButtons.YesNo || m_Buttons == MessageBoxButtons.YesNoCancel)
                r = DialogResult.Yes;
            else if (m_Buttons == MessageBoxButtons.AbortRetryIgnore)
                r = DialogResult.Abort;
            else if (m_Buttons == MessageBoxButtons.RetryCancel)
                r = DialogResult.Retry;

            this.DialogResult = r;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult r = DialogResult.Cancel;
            if (m_Buttons == MessageBoxButtons.OKCancel)
                r = DialogResult.Cancel;
            else if (m_Buttons == MessageBoxButtons.YesNo || m_Buttons == MessageBoxButtons.YesNoCancel)
                r = DialogResult.No;
            else if (m_Buttons == MessageBoxButtons.AbortRetryIgnore)
                r = DialogResult.Retry;
            else if (m_Buttons == MessageBoxButtons.RetryCancel)
                r = DialogResult.Cancel;

            this.DialogResult = r;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult r = DialogResult.Cancel;
            if (m_Buttons == MessageBoxButtons.AbortRetryIgnore)
                r = DialogResult.Ignore;
            else if (m_Buttons == MessageBoxButtons.YesNoCancel)
                r = DialogResult.Cancel;

            this.DialogResult = r;
        }

        #region System Strings
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern string MB_GetString(int i);

        private static string GetString(SystemStrings sysString)
        {
            string result = "";
            try
            {
                result = MB_GetString((int)sysString);
            }
            catch
            {
                result = "";
            }

            if (result == "")
            {
                if (sysString == SystemStrings.Abort)
                    result = "&Abort";
                else if (sysString == SystemStrings.Cancel)
                    result = "&Cancel";
                else if (sysString == SystemStrings.Close)
                    result = "C&lose";
                else if (sysString == SystemStrings.Continue)
                    result = "Co&ntinue";
                else if (sysString == SystemStrings.Help)
                    result = "&Help";
                else if (sysString == SystemStrings.Ignore)
                    result = "&Ignore";
                else if (sysString == SystemStrings.No)
                    result = "&No";
                else if (sysString == SystemStrings.OK)
                    result = "&OK";
                else if (sysString == SystemStrings.Retry)
                    result = "&Retry";
                else if (sysString == SystemStrings.TryAgain)
                    result = "&Try Again";
                else if (sysString == SystemStrings.Yes)
                    result = "&Yes";
            }

            return result;
        }

        /// <summary>
        /// Enumeration of available common system strings.
        /// </summary>
        private enum SystemStrings
        {
            OK = 0,
            Cancel = 1,
            Abort = 2,
            Retry = 3,
            Ignore = 4,
            Yes = 5,
            No = 6,
            Close = 7,
            Help = 8,
            TryAgain = 9,
            Continue = 10
        }
        #endregion
    }
}