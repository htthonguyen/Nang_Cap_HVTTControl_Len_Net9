namespace HVTT.UI.Window.Forms.Editors
{
    partial class HVTTPickerDateTime
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
            this.pt = new System.Windows.Forms.PictureBox();
            this.tb = new HVTT.UI.Window.Forms.Controls.HVTTMaskTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pt)).BeginInit();
            this.SuspendLayout();
            // 
            // pt
            // 
            this.pt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pt.Image = global::HVTT.UI.Window.Forms.Properties.Resources.Down2;
            this.pt.Location = new System.Drawing.Point(185, 1);
            this.pt.Name = "pt";
            this.pt.Size = new System.Drawing.Size(13, 21);
            this.pt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pt.TabIndex = 1;
            this.pt.TabStop = false;
            this.pt.MouseLeave += new System.EventHandler(this.pt_MouseLeave);
            this.pt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pt_MouseMove);
            this.pt.Click += new System.EventHandler(this.pt_Click);
            this.pt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pt_MouseDown);
            // 
            // tb
            // 
            this.tb.AllowEdit = true;
            this.tb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tb.BorderColor = System.Drawing.Color.Transparent;
            this.tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tb.IsChange = true;
            this.tb.Level = -1;
            this.tb.Location = new System.Drawing.Point(1, 1);
            this.tb.Mask = "00/00/0000";
            this.tb.Name = "tb";
            this.tb.PromptChar = ' ';
            this.tb.Require = false;
            this.tb.Size = new System.Drawing.Size(185, 21);
            this.tb.TabIndex = 2;
            this.tb.ValidatingType = typeof(System.DateTime);
            this.tb.Value = "  /  /    ";
            this.tb.ValueChanged += new System.EventHandler(this.tb_ValueChanged);
            this.tb.Leave += new System.EventHandler(this.tb_Leave);
            this.tb.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(157, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.Visible = false;
            // 
            // HVTTPickerDateTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.pt);
            this.Name = "HVTTPickerDateTime";
            this.Size = new System.Drawing.Size(199, 23);
            this.Leave += new System.EventHandler(this.HVTTPickerDateTime_Leave);
            this.Resize += new System.EventHandler(this.HVTTPickerDateTime_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pt;
        private HVTT.UI.Window.Forms.Controls.HVTTMaskTextBox tb;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}
