namespace HVTT.UI.Window.Forms.Editors
{
    partial class HVTTTreeViewColumns
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
            this.tv = new HVTT.UI.Window.Forms.Editors.HVTTTreeView();
            this.lv = new HVTT.UI.Window.Forms.Controls.HVTTListView();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.CodeLanguage = "";
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.FullRowSelect = true;
            this.tv.Location = new System.Drawing.Point(0, 21);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(285, 129);
            this.tv.TabIndex = 1;
            this.tv.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.tv_DrawNode);
            // 
            // lv
            // 
            // 
            // 
            // 
            this.lv.Border.Class = "ListViewBorder";
            this.lv.Dock = System.Windows.Forms.DockStyle.Top;
            this.lv.Location = new System.Drawing.Point(0, 0);
            this.lv.Name = "lv";
            this.lv.Scrollable = false;
            this.lv.Size = new System.Drawing.Size(285, 21);
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            // 
            // HVTTTreeViewColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tv);
            this.Controls.Add(this.lv);
            this.Name = "HVTTTreeViewColumns";
            this.Size = new System.Drawing.Size(285, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private HVTT.UI.Window.Forms.Controls.HVTTListView lv;
        private HVTTTreeView tv;
    }
}
