namespace HVTT.UI.Window.Forms.Controls
{
    partial class HVTTEditBox
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
            this.hvttButton1 = new HVTT.UI.Window.Forms.HVTTButton();
            this.hvttTextBox1 = new HVTT.UI.Window.Forms.Controls.HVTTTextBox();
            this.SuspendLayout();
            // 
            // hvttButton1
            // 
            this.hvttButton1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.hvttButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.hvttButton1.LanguageCode = "";
            this.hvttButton1.Location = new System.Drawing.Point(242, 0);
            this.hvttButton1.Name = "hvttButton1";
            this.hvttButton1.Size = new System.Drawing.Size(30, 18);
            this.hvttButton1.Style = HVTT.UI.Window.Forms.HVTTControlStyle.Office2003;
            this.hvttButton1.TabIndex = 0;
            this.hvttButton1.Value = "";
            // 
            // hvttTextBox1
            // 
            this.hvttTextBox1.AllowEdit = true;
            this.hvttTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.hvttTextBox1.BorderColor = System.Drawing.Color.Black;
            this.hvttTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hvttTextBox1.IsChange = true;
            this.hvttTextBox1.Level = -1;
            this.hvttTextBox1.Location = new System.Drawing.Point(0, 0);
            this.hvttTextBox1.Name = "hvttTextBox1";
            this.hvttTextBox1.PlaceHolder = "";
            this.hvttTextBox1.PlaceHolderActiveForeColor = System.Drawing.Color.Gray;
            this.hvttTextBox1.PlaceHolderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hvttTextBox1.PlaceHolderForeColor = System.Drawing.Color.LightGray;
            this.hvttTextBox1.Require = false;
            this.hvttTextBox1.SelectedItems = null;
            this.hvttTextBox1.Size = new System.Drawing.Size(242, 20);
            this.hvttTextBox1.TabIndex = 1;
            this.hvttTextBox1.Text = "hvttTextBox1";
            this.hvttTextBox1.TypeStyle = HVTT.UI.Window.Forms.Controls.HVTTTextBox.TypeStyles.Normal;
            this.hvttTextBox1.Value = "hvttTextBox1";
            // 
            // HVTTEditBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.hvttTextBox1);
            this.Controls.Add(this.hvttButton1);
            this.Name = "HVTTEditBox";
            this.Size = new System.Drawing.Size(272, 18);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HVTTButton hvttButton1;
        private HVTTTextBox hvttTextBox1;
    }
}
