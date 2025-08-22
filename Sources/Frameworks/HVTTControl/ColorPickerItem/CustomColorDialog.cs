using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace HVTT.UI.Window.Forms.ColorPickerItem
{
    [ToolboxItem(false)]
	internal class CustomColorDialog : HVTT.UI.Window.Forms.Office2007Form
	{
		#region Private Variables

        internal System.Windows.Forms.Label labelNewColor;
		internal System.Windows.Forms.Label labelCurrentColor;
		
		private Color m_CurrentColor = Color.Black;
		private Color m_NewColor = Color.Empty;
		private ColorCombControl colorCombControl1;
		internal System.Windows.Forms.Label labelStandardColors;
		internal System.Windows.Forms.Label labelCustomColors;
		private System.Windows.Forms.NumericUpDown numericRed;
		internal System.Windows.Forms.Label labelGreen;
		internal System.Windows.Forms.Label labelBlue;
		private HVTT.UI.Window.Forms.TabControl tabControl2;
		internal HVTT.UI.Window.Forms.TabItem tabItemStandard;
		private HVTT.UI.Window.Forms.TabControlPanel tabControlPanel1;
        internal HVTT.UI.Window.Forms.TabItem tabItemCustom;
		private HVTT.UI.Window.Forms.TabControlPanel tabControlPanel2;
		private CustomColorBlender customColorBlender3;
		internal System.Windows.Forms.Label labelRed;
		internal System.Windows.Forms.Label labelColorModel;
		private System.Windows.Forms.NumericUpDown numericBlue;
		private System.Windows.Forms.NumericUpDown numericGreen;
		internal System.Windows.Forms.ComboBox comboColorModel;
		private ColorContrastControl colorContrastControl1;
        private ColorSelectionPreviewControl colorSelectionPreview;
        public HVTTButton buttonOK;
        public HVTTButton buttonCancel;
		private System.ComponentModel.IContainer components;
		#endregion
		
		#region Constructor, Dispose
		public CustomColorDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.labelStandardColors = new System.Windows.Forms.Label();
            this.colorCombControl1 = new HVTT.UI.Window.Forms.ColorPickerItem.ColorCombControl();
            this.labelBlue = new System.Windows.Forms.Label();
            this.labelGreen = new System.Windows.Forms.Label();
            this.numericBlue = new System.Windows.Forms.NumericUpDown();
            this.numericGreen = new System.Windows.Forms.NumericUpDown();
            this.numericRed = new System.Windows.Forms.NumericUpDown();
            this.labelCustomColors = new System.Windows.Forms.Label();
            this.labelNewColor = new System.Windows.Forms.Label();
            this.labelCurrentColor = new System.Windows.Forms.Label();
            this.tabControl2 = new HVTT.UI.Window.Forms.TabControl();
            this.tabControlPanel2 = new HVTT.UI.Window.Forms.TabControlPanel();
            this.colorContrastControl1 = new HVTT.UI.Window.Forms.ColorPickerItem.ColorContrastControl();
            this.customColorBlender3 = new HVTT.UI.Window.Forms.ColorPickerItem.CustomColorBlender();
            this.comboColorModel = new System.Windows.Forms.ComboBox();
            this.labelRed = new System.Windows.Forms.Label();
            this.labelColorModel = new System.Windows.Forms.Label();
            this.tabItemCustom = new HVTT.UI.Window.Forms.TabItem(this.components);
            this.tabControlPanel1 = new HVTT.UI.Window.Forms.TabControlPanel();
            this.tabItemStandard = new HVTT.UI.Window.Forms.TabItem(this.components);
            this.colorSelectionPreview = new HVTT.UI.Window.Forms.ColorPickerItem.ColorSelectionPreviewControl();
            this.buttonOK = new HVTT.UI.Window.Forms.HVTTButton();
            this.buttonCancel = new HVTT.UI.Window.Forms.HVTTButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelStandardColors
            // 
            this.labelStandardColors.BackColor = System.Drawing.Color.Transparent;
            this.labelStandardColors.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStandardColors.Location = new System.Drawing.Point(1, 1);
            this.labelStandardColors.Name = "labelStandardColors";
            this.labelStandardColors.Size = new System.Drawing.Size(224, 19);
            this.labelStandardColors.TabIndex = 1;
            this.labelStandardColors.Text = " Colors:";
            this.labelStandardColors.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // colorCombControl1
            // 
            this.colorCombControl1.BackColor = System.Drawing.Color.Transparent;
            this.colorCombControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorCombControl1.Location = new System.Drawing.Point(1, 20);
            this.colorCombControl1.Name = "colorCombControl1";
            this.colorCombControl1.Size = new System.Drawing.Size(224, 267);
            this.colorCombControl1.TabIndex = 0;
            this.colorCombControl1.SelectedColorChanged += new System.EventHandler(this.colorCombControl1_SelectedColorChanged);
            // 
            // labelBlue
            // 
            this.labelBlue.BackColor = System.Drawing.Color.Transparent;
            this.labelBlue.Location = new System.Drawing.Point(4, 256);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(76, 16);
            this.labelBlue.TabIndex = 10;
            this.labelBlue.Text = "&Blue:";
            // 
            // labelGreen
            // 
            this.labelGreen.BackColor = System.Drawing.Color.Transparent;
            this.labelGreen.Location = new System.Drawing.Point(4, 232);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(76, 16);
            this.labelGreen.TabIndex = 8;
            this.labelGreen.Text = "&Green:";
            // 
            // numericBlue
            // 
            this.numericBlue.Location = new System.Drawing.Point(84, 260);
            this.numericBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericBlue.Name = "numericBlue";
            this.numericBlue.Size = new System.Drawing.Size(47, 20);
            this.numericBlue.TabIndex = 11;
            this.numericBlue.ValueChanged += new System.EventHandler(this.numericRGBValueChanged);
            // 
            // numericGreen
            // 
            this.numericGreen.Location = new System.Drawing.Point(84, 236);
            this.numericGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericGreen.Name = "numericGreen";
            this.numericGreen.Size = new System.Drawing.Size(47, 20);
            this.numericGreen.TabIndex = 9;
            this.numericGreen.ValueChanged += new System.EventHandler(this.numericRGBValueChanged);
            // 
            // numericRed
            // 
            this.numericRed.Location = new System.Drawing.Point(84, 212);
            this.numericRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericRed.Name = "numericRed";
            this.numericRed.Size = new System.Drawing.Size(47, 20);
            this.numericRed.TabIndex = 7;
            this.numericRed.ValueChanged += new System.EventHandler(this.numericRGBValueChanged);
            // 
            // labelCustomColors
            // 
            this.labelCustomColors.BackColor = System.Drawing.Color.Transparent;
            this.labelCustomColors.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCustomColors.Location = new System.Drawing.Point(1, 1);
            this.labelCustomColors.Name = "labelCustomColors";
            this.labelCustomColors.Size = new System.Drawing.Size(224, 20);
            this.labelCustomColors.TabIndex = 2;
            this.labelCustomColors.Text = " Colors:";
            this.labelCustomColors.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labelNewColor
            // 
            this.labelNewColor.Location = new System.Drawing.Point(256, 232);
            this.labelNewColor.Name = "labelNewColor";
            this.labelNewColor.Size = new System.Drawing.Size(44, 12);
            this.labelNewColor.TabIndex = 4;
            this.labelNewColor.Text = "New";
            this.labelNewColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCurrentColor
            // 
            this.labelCurrentColor.Location = new System.Drawing.Point(256, 306);
            this.labelCurrentColor.Name = "labelCurrentColor";
            this.labelCurrentColor.Size = new System.Drawing.Size(44, 16);
            this.labelCurrentColor.TabIndex = 5;
            this.labelCurrentColor.Text = "Current";
            this.labelCurrentColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl2
            // 
            this.tabControl2.BackColor = System.Drawing.Color.Transparent;
            this.tabControl2.CanReorderTabs = true;
            this.tabControl2.ColorScheme.TabBackground = System.Drawing.Color.Transparent;
            this.tabControl2.Controls.Add(this.tabControlPanel1);
            this.tabControl2.Controls.Add(this.tabControlPanel2);
            this.tabControl2.FixedTabSize = new System.Drawing.Size(60, 0);
            this.tabControl2.Location = new System.Drawing.Point(8, 8);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl2.SelectedTabIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(226, 314);
            this.tabControl2.Style = HVTT.UI.Window.Forms.eTabStripStyle.VS2005;
            this.tabControl2.TabIndex = 6;
            this.tabControl2.TabLayoutType = HVTT.UI.Window.Forms.TabLayoutType.FixedWithNavigationBox;
            this.tabControl2.Tabs.Add(this.tabItemStandard);
            this.tabControl2.Tabs.Add(this.tabItemCustom);
            this.tabControl2.ThemeAware = true;
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.colorContrastControl1);
            this.tabControlPanel2.Controls.Add(this.numericGreen);
            this.tabControlPanel2.Controls.Add(this.labelGreen);
            this.tabControlPanel2.Controls.Add(this.numericRed);
            this.tabControlPanel2.Controls.Add(this.customColorBlender3);
            this.tabControlPanel2.Controls.Add(this.comboColorModel);
            this.tabControlPanel2.Controls.Add(this.labelRed);
            this.tabControlPanel2.Controls.Add(this.labelColorModel);
            this.tabControlPanel2.Controls.Add(this.numericBlue);
            this.tabControlPanel2.Controls.Add(this.labelBlue);
            this.tabControlPanel2.Controls.Add(this.labelCustomColors);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(226, 288);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.tabControlPanel2.Style.Border = HVTT.UI.Window.Forms.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderSide = ((HVTT.UI.Window.Forms.BorderSide)(((HVTT.UI.Window.Forms.BorderSide.Left | HVTT.UI.Window.Forms.BorderSide.Right)
                        | HVTT.UI.Window.Forms.BorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItemCustom;
            this.tabControlPanel2.ThemeAware = true;
            // 
            // colorContrastControl1
            // 
            this.colorContrastControl1.BackColor = System.Drawing.Color.Transparent;
            this.colorContrastControl1.Location = new System.Drawing.Point(188, 28);
            this.colorContrastControl1.Name = "colorContrastControl1";
            this.colorContrastControl1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.colorContrastControl1.Size = new System.Drawing.Size(32, 152);
            this.colorContrastControl1.TabIndex = 12;
            this.colorContrastControl1.SelectedColorChanged += new System.EventHandler(this.colorContrastControl1_SelectedColorChanged);
            // 
            // customColorBlender3
            // 
            this.customColorBlender3.Location = new System.Drawing.Point(8, 28);
            this.customColorBlender3.Name = "customColorBlender3";
            this.customColorBlender3.Size = new System.Drawing.Size(174, 152);
            this.customColorBlender3.TabIndex = 3;
            this.customColorBlender3.SelectedColorChanged += new System.EventHandler(this.customColorBlender3_SelectedColorChanged);
            // 
            // comboColorModel
            // 
            this.comboColorModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboColorModel.Items.AddRange(new object[] {
            "RGB"});
            this.comboColorModel.Location = new System.Drawing.Point(84, 188);
            this.comboColorModel.Name = "comboColorModel";
            this.comboColorModel.Size = new System.Drawing.Size(89, 21);
            this.comboColorModel.TabIndex = 5;
            // 
            // labelRed
            // 
            this.labelRed.BackColor = System.Drawing.Color.Transparent;
            this.labelRed.Location = new System.Drawing.Point(4, 212);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(76, 16);
            this.labelRed.TabIndex = 6;
            this.labelRed.Text = "&Red:";
            // 
            // labelColorModel
            // 
            this.labelColorModel.BackColor = System.Drawing.Color.Transparent;
            this.labelColorModel.Location = new System.Drawing.Point(4, 192);
            this.labelColorModel.Name = "labelColorModel";
            this.labelColorModel.Size = new System.Drawing.Size(76, 16);
            this.labelColorModel.TabIndex = 4;
            this.labelColorModel.Text = "Color Mo&del:";
            // 
            // tabItemCustom
            // 
            this.tabItemCustom.AttachedControl = this.tabControlPanel2;
            this.tabItemCustom.Name = "tabItemCustom";
            this.tabItemCustom.Text = "Custom";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.colorCombControl1);
            this.tabControlPanel1.Controls.Add(this.labelStandardColors);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(226, 288);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.tabControlPanel1.Style.Border = HVTT.UI.Window.Forms.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderSide = ((HVTT.UI.Window.Forms.BorderSide)(((HVTT.UI.Window.Forms.BorderSide.Left | HVTT.UI.Window.Forms.BorderSide.Right)
                        | HVTT.UI.Window.Forms.BorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItemStandard;
            this.tabControlPanel1.ThemeAware = true;
            // 
            // tabItemStandard
            // 
            this.tabItemStandard.AttachedControl = this.tabControlPanel1;
            this.tabItemStandard.Name = "tabItemStandard";
            this.tabItemStandard.Text = "Standard";
            // 
            // colorSelectionPreview
            // 
            this.colorSelectionPreview.CurrentColor = System.Drawing.Color.Black;
            this.colorSelectionPreview.Location = new System.Drawing.Point(252, 252);
            this.colorSelectionPreview.Name = "colorSelectionPreview";
            this.colorSelectionPreview.NewColor = System.Drawing.Color.Empty;
            this.colorSelectionPreview.Size = new System.Drawing.Size(56, 48);
            this.colorSelectionPreview.TabIndex = 7;
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOK.Location = new System.Drawing.Point(240, 8);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "Ok";
            this.buttonOK.Value = "";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCancel.Location = new System.Drawing.Point(240, 38);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Value = "";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // CustomColorDialog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(324, 326);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.colorSelectionPreview);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.labelCurrentColor);
            this.Controls.Add(this.labelNewColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomColorDialog";
            this.ShowInTaskbar = false;
            this.Text = "Colors";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Internal Implementation
        internal void SetStyle(HVTTControlStyle style)
        {
            if (style == HVTTControlStyle.Office2007)
            {
                this.EnableCustomStyle = true;
                tabControl2.Style = eTabStripStyle.Office2007Dock;
            }
            else
            {
                this.EnableCustomStyle = false;
                this.tabControl2.Style = HVTT.UI.Window.Forms.eTabStripStyle.VS2005;
            }

            tabControl2.BackColor = Color.Transparent;
            tabControl2.ColorScheme.TabBackground = Color.Transparent;
            tabControl2.ColorScheme.TabBackground2 = Color.Empty;
        }
		private void colorCombControl1_SelectedColorChanged(object sender, System.EventArgs e)
		{
			SetNewColor(colorCombControl1.SelectedColor);
			colorContrastControl1.SelectedColor = colorCombControl1.SelectedColor;
		}

		private void customColorBlender3_SelectedColorChanged(object sender, System.EventArgs e)
		{
            colorContrastControl1.SelectedColor = customColorBlender3.SelectedColor;
            SetNewColor(colorContrastControl1.SelectedColor);
		}
		
		private bool m_SettingColor = false;
		private void SetNewColor(Color color)
		{
			if(m_SettingColor) return;
			m_SettingColor = true;
			try
			{
				m_NewColor = color;
				colorSelectionPreview.NewColor = color;
			
				numericRed.Value = m_NewColor.R;
				numericGreen.Value = m_NewColor.G;
				numericBlue.Value = m_NewColor.B;
			}
			finally
			{
				m_SettingColor = false;
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			comboColorModel.SelectedIndex = 0;
		}

		private void numericRGBValueChanged(object sender, System.EventArgs e)
		{
			SetNewColor(Color.FromArgb((int)numericRed.Value, (int)numericGreen.Value, (int)numericBlue.Value));
		}

		private void colorContrastControl1_SelectedColorChanged(object sender, System.EventArgs e)
		{
			SetNewColor(colorContrastControl1.SelectedColor);
		}
		
		public Color CurrentColor
		{
			get { return m_CurrentColor;}
			set
			{
				m_CurrentColor = value;
				colorSelectionPreview.CurrentColor = value;
			}
		}
		
		public Color NewColor
		{
			get { return m_NewColor;}
		}
		#endregion

        private void buttonOK_Click(object sender, EventArgs e)
        {
            m_CurrentColor = colorSelectionPreview.CurrentColor;
            m_NewColor = colorSelectionPreview.NewColor;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
	}
}
