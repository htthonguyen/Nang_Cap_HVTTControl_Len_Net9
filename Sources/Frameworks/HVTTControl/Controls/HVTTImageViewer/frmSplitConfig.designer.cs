namespace HVTT.UI.Window.Forms.Controls.HVTTImageViewer
{
    partial class frmSplitConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplitConfig));
            this.ribbonControl1 = new HVTT.UI.Window.Forms.RibbonControl();
            this.office2007StartButton1 = new HVTT.UI.Window.Forms.Office2007StartButton();
            this.cmdSave = new HVTT.UI.Window.Forms.ButtonItem();
            this.imageViewer1 = new HVTT.UI.Window.Forms.Controls.HVTTImageViewer.ImageViewer();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.CaptionFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(4, 1);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.ribbonControl1.QuickToolbarItems.AddRange(new HVTT.UI.Window.Forms.BaseItem[] {
            this.office2007StartButton1,
            this.cmdSave});
            this.ribbonControl1.Size = new System.Drawing.Size(743, 46);
            this.ribbonControl1.Style = HVTT.UI.Window.Forms.HVTTControlStyle.Office2007;
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 8;
            this.ribbonControl1.Text = "ribbonControl1";
            // 
            // office2007StartButton1
            // 
            this.office2007StartButton1.AutoExpandOnClick = true;
            this.office2007StartButton1.CanCustomize = false;
            this.office2007StartButton1.HotTrackingStyle = HVTT.UI.Window.Forms.HotTrackingStyle.Image;
            this.office2007StartButton1.Icon = ((System.Drawing.Icon)(resources.GetObject("office2007StartButton1.Icon")));
            this.office2007StartButton1.ImagePaddingHorizontal = 2;
            this.office2007StartButton1.ImagePaddingVertical = 2;
            this.office2007StartButton1.Name = "office2007StartButton1";
            this.office2007StartButton1.ShowSubItems = false;
            this.office2007StartButton1.Text = "&File";
            // 
            // cmdSave
            // 
            this.cmdSave.ButtonStyle = HVTT.UI.Window.Forms.HVTTButtonStyle.ImageAndText;
            this.cmdSave.ImagePaddingHorizontal = 8;
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Text = "Xác nhận";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // imageViewer1
            // 
            this.imageViewer1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.imageViewer1.Descr = null;
            this.imageViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer1.EnablePrintButton = false;
            this.imageViewer1.EnableSplitButton = false;
            this.imageViewer1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.imageViewer1.GifAnimation = false;
            this.imageViewer1.GifFPS = 15D;
            this.imageViewer1.Image = null;
            this.imageViewer1.Location = new System.Drawing.Point(4, 47);
            this.imageViewer1.MenuColor = System.Drawing.Color.LightSteelBlue;
            this.imageViewer1.MenuPanelColor = System.Drawing.Color.LightSteelBlue;
            this.imageViewer1.MinimumSize = new System.Drawing.Size(454, 157);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.NavigationPanelColor = System.Drawing.Color.LightSteelBlue;
            this.imageViewer1.NavigationTextColor = System.Drawing.SystemColors.ButtonHighlight;
            this.imageViewer1.OpenButton = false;
            this.imageViewer1.PreviewButton = false;
            this.imageViewer1.PreviewPanelColor = System.Drawing.Color.LightSteelBlue;
            this.imageViewer1.PreviewText = "Preview";
            this.imageViewer1.PreviewTextColor = System.Drawing.SystemColors.ButtonHighlight;
            this.imageViewer1.Rotation = 0;
            this.imageViewer1.Scrollbars = false;
            this.imageViewer1.ShowPreview = true;
            this.imageViewer1.Size = new System.Drawing.Size(743, 361);
            this.imageViewer1.TabIndex = 9;
            this.imageViewer1.TextColor = System.Drawing.SystemColors.ButtonHighlight;
            this.imageViewer1.Zoom = 100D;
            this.imageViewer1.Load += new System.EventHandler(this.imageViewer1_Load);
            // 
            // frmSplitConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 410);
            this.Controls.Add(this.imageViewer1);
            this.Controls.Add(this.ribbonControl1);
            this.EnableGlass = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSplitConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HVTT: Hỏi";
            this.ResumeLayout(false);

        }

        #endregion

        private RibbonControl ribbonControl1;
        private Office2007StartButton office2007StartButton1;
        private ButtonItem cmdSave;
        private ImageViewer imageViewer1;
    }
}