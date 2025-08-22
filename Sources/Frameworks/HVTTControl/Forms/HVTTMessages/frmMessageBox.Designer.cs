namespace HVTT.UI.Window.Forms
{
    partial class frmMessageBox
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
            HVTT.UI.Window.Forms.Controls.HVTTRichTextBox.CharStyle charStyle1 = new HVTT.UI.Window.Forms.Controls.HVTTRichTextBox.CharStyle();
            HVTT.UI.Window.Forms.Controls.HVTTRichTextBox.ParaLineSpacing paraLineSpacing1 = new HVTT.UI.Window.Forms.Controls.HVTTRichTextBox.ParaLineSpacing();
            HVTT.UI.Window.Forms.Controls.HVTTRichTextBox.ParaListStyle paraListStyle1 = new HVTT.UI.Window.Forms.Controls.HVTTRichTextBox.ParaListStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessageBox));
            this.hvttPanel1 = new HVTT.UI.Window.Forms.HVTTPanel();
            this.txtMessage = new HVTT.UI.Window.Forms.Controls.HVTTRichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOk = new HVTT.UI.Window.Forms.HVTTButton();
            this.btnCancel = new HVTT.UI.Window.Forms.HVTTButton();
            this.lblTitle1 = new HVTT.UI.Window.Forms.HVTTLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.hvttPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // hvttPanel1
            // 
            this.hvttPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.hvttPanel1.ColorSchemeStyle = HVTT.UI.Window.Forms.HVTTControlStyle.Office2007;
            this.hvttPanel1.Controls.Add(this.txtMessage);
            this.hvttPanel1.Controls.Add(this.panel2);
            this.hvttPanel1.Controls.Add(this.lblTitle1);
            this.hvttPanel1.Controls.Add(this.panel1);
            this.hvttPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hvttPanel1.Location = new System.Drawing.Point(0, 0);
            this.hvttPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.hvttPanel1.Name = "hvttPanel1";
            this.hvttPanel1.Size = new System.Drawing.Size(538, 199);
            this.hvttPanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.hvttPanel1.Style.BackColor1.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.PanelBackground;
            this.hvttPanel1.Style.BackColor2.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.PanelBackground2;
            this.hvttPanel1.Style.BorderColor.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.PanelBorder;
            this.hvttPanel1.Style.ForeColor.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.PanelText;
            this.hvttPanel1.Style.GradientAngle = 90;
            this.hvttPanel1.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.AllowEdit = false;
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.ForeColor = System.Drawing.Color.Blue;
            this.txtMessage.Level = -1;
            this.txtMessage.Location = new System.Drawing.Point(120, 43);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Require = false;
            charStyle1.Bold = false;
            charStyle1.Italic = false;
            charStyle1.Link = false;
            charStyle1.Strikeout = false;
            charStyle1.Underline = false;
            this.txtMessage.SelectionCharStyle = charStyle1;
            this.txtMessage.SelectionFont2 = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Inch);
            paraLineSpacing1.ExactSpacing = 0;
            paraLineSpacing1.SpacingStyle = HVTT.UI.Window.Forms.Controls.HVTTRichTextBox.ParaLineSpacing.LineSpacingStyle.Unknown;
            this.txtMessage.SelectionLineSpacing = paraLineSpacing1;
            paraListStyle1.BulletCharCode = ((short)(0));
            paraListStyle1.NumberingStart = ((short)(0));
            paraListStyle1.Style = HVTT.UI.Window.Forms.Controls.HVTTRichTextBox.ParaListStyle.ListStyle.NumberAndParenthesis;
            paraListStyle1.Type = HVTT.UI.Window.Forms.Controls.HVTTRichTextBox.ParaListStyle.ListType.None;
            this.txtMessage.SelectionListType = paraListStyle1;
            this.txtMessage.SelectionOffsetType = HVTT.UI.Window.Forms.Controls.HVTTRichTextBox.OffsetType.None;
            this.txtMessage.SelectionSpaceAfter = 0;
            this.txtMessage.SelectionSpaceBefore = 0;
            this.txtMessage.Size = new System.Drawing.Size(418, 114);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.TabStop = false;
            this.txtMessage.Text = "";
            this.txtMessage.Value = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(120, 157);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(418, 42);
            this.panel2.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(230, 0);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(94, 42);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Đồng ý";
            this.btnOk.Value = "";
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(324, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 42);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Value = "";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTitle1
            // 
            this.lblTitle1.AllowChangeText = true;
            this.lblTitle1.Description = "";
            this.lblTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle1.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle1.Location = new System.Drawing.Point(120, 0);
            this.lblTitle1.Margin = new System.Windows.Forms.Padding(4);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(418, 43);
            this.lblTitle1.TabIndex = 2;
            this.lblTitle1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lblTitle1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 199);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 48);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 199);
            this.Controls.Add(this.hvttPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HVTT: Messages";
            this.hvttPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HVTTPanel hvttPanel1;
        private System.Windows.Forms.Panel panel2;
        private HVTTButton btnOk;
        private HVTTButton btnCancel;
        private HVTTLabel lblTitle1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Controls.HVTTRichTextBox txtMessage;
    }
}