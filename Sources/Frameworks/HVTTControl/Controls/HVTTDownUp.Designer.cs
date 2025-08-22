namespace HVTT.UI.Window.Forms.Controls
{
    partial class HVTTDownUp
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVTTDownUp));
            this.pn = new System.Windows.Forms.Panel();
            this.ptD = new System.Windows.Forms.PictureBox();
            this.ptUp = new System.Windows.Forms.PictureBox();
            this.tb = new System.Windows.Forms.TextBox();
            this.pn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptUp)).BeginInit();
            this.SuspendLayout();
            // 
            // pn
            // 
            this.pn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pn.Controls.Add(this.ptD);
            this.pn.Controls.Add(this.ptUp);
            this.pn.Location = new System.Drawing.Point(95, 2);
            this.pn.Name = "pn";
            this.pn.Size = new System.Drawing.Size(18, 21);
            this.pn.TabIndex = 2;
            // 
            // ptD
            // 
            this.ptD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptD.Image = ((System.Drawing.Image)(resources.GetObject("ptD.Image")));
            this.ptD.Location = new System.Drawing.Point(0, 11);
            this.ptD.Name = "ptD";
            this.ptD.Size = new System.Drawing.Size(18, 10);
            this.ptD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptD.TabIndex = 3;
            this.ptD.TabStop = false;
            this.ptD.MouseLeave += new System.EventHandler(this.ptD_MouseLeave);
            this.ptD.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptD_MouseMove);
            this.ptD.Click += new System.EventHandler(this.ptD_Click);
            this.ptD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptD_MouseDown);
            // 
            // ptUp
            // 
            this.ptUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptUp.Image = global::HVTT.UI.Window.Forms.Properties.Resources.Up2;
            this.ptUp.Location = new System.Drawing.Point(0, 0);
            this.ptUp.Name = "ptUp";
            this.ptUp.Size = new System.Drawing.Size(18, 11);
            this.ptUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptUp.TabIndex = 2;
            this.ptUp.TabStop = false;
            this.ptUp.MouseLeave += new System.EventHandler(this.ptU_MouseLeave);
            this.ptUp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptU_MouseMove);
            this.ptUp.Click += new System.EventHandler(this.ptUp_Click);
            this.ptUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptU_MouseDown);
            // 
            // tb
            // 
            this.tb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tb.Location = new System.Drawing.Point(2, 2);
            this.tb.Multiline = true;
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(94, 21);
            this.tb.TabIndex = 4;
            this.tb.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb.Validated += new System.EventHandler(this.tb_Validated);
            this.tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_KeyDown);
            this.tb.Validating += new System.ComponentModel.CancelEventHandler(this.tb_Validating);
            // 
            // HVTTDownUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tb);
            this.Controls.Add(this.pn);
            this.Name = "HVTTDownUp";
            this.Size = new System.Drawing.Size(116, 26);
            this.Resize += new System.EventHandler(this.HVTTDownUp_Resize);
            this.pn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pn;
        private System.Windows.Forms.PictureBox ptD;
        private System.Windows.Forms.PictureBox ptUp;
        private System.Windows.Forms.TextBox tb;
    }
}
