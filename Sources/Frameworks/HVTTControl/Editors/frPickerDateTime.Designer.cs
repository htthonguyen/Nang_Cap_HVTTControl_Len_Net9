namespace HVTT.UI.Window.Forms.Editors
{
    partial class frPickerDateTime
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
            this.Cal = new HVTT.UI.Window.Forms.Editors.HVTTCalendarEditor();
            this.SuspendLayout();
            // 
            // Cal
            // 
            this.Cal.BoldedDates = null;
            this.Cal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cal.ForeColorActive = System.Drawing.Color.Black;
            this.Cal.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            this.Cal.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            this.Cal.Location = new System.Drawing.Point(0, 0);
            this.Cal.Name = "Cal";
            this.Cal.SelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Cal.SelectBorderColor = System.Drawing.Color.Transparent;
            this.Cal.SelectDate = new System.DateTime(2009, 2, 27, 0, 0, 0, 0);
            this.Cal.SelectDefaultBackColor = System.Drawing.Color.White;
            this.Cal.SelectDefaultBorderColor = System.Drawing.Color.Transparent;
            this.Cal.Size = new System.Drawing.Size(198, 171);
            this.Cal.TabIndex = 4;
            this.Cal.ResetDate += new System.EventHandler(this.Cal_ResetDate);
            this.Cal.ToDayClick += new System.EventHandler(this.Cal_ToDayClick);
            this.Cal.DateClick += new System.EventHandler(this.Cal_DateClick);
            // 
            // frPickerDateTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 171);
            this.Controls.Add(this.Cal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frPickerDateTime";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frPickerDateTime";
            this.Deactivate += new System.EventHandler(this.frPickerDateTime_Deactivate);
            this.Load += new System.EventHandler(this.frPickerDateTimeInGrid_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HVTTCalendarEditor Cal;
    }
}