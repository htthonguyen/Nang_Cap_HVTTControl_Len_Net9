using HVTT.UI.Window.Forms.Editors;
namespace HVTT.UI.Window.Forms.Editors
{
    partial class HVTTCalendarEditor
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
            this.ctmMonth = new HVTT.UI.Window.Forms.ContextMenuBar();
            this.Month = new HVTT.UI.Window.Forms.ButtonItem();
            this.ctmJanuary = new HVTT.UI.Window.Forms.ButtonItem();
            this.ctmFebruary = new HVTT.UI.Window.Forms.ButtonItem();
            this.ctmMarch = new HVTT.UI.Window.Forms.ButtonItem();
            this.ctmApril = new HVTT.UI.Window.Forms.ButtonItem();
            this.ctmMay = new HVTT.UI.Window.Forms.ButtonItem();
            this.ctmJune = new HVTT.UI.Window.Forms.ButtonItem();
            this.cmtJuly = new HVTT.UI.Window.Forms.ButtonItem();
            this.ctmAugust = new HVTT.UI.Window.Forms.ButtonItem();
            this.cmtSeptember = new HVTT.UI.Window.Forms.ButtonItem();
            this.cmtOctober = new HVTT.UI.Window.Forms.ButtonItem();
            this.ctmNovember = new HVTT.UI.Window.Forms.ButtonItem();
            this.ctmDecember = new HVTT.UI.Window.Forms.ButtonItem();
            this.lblMonth = new HVTT.UI.Window.Forms.HVTTLabel();
            this.pn = new HVTT.UI.Window.Forms.HVTTPanel();
            this.hvttPanel1 = new HVTT.UI.Window.Forms.HVTTPanel();
            this.lblToDay = new HVTT.UI.Window.Forms.Editors.HVTTLabelEditor();
            this.btnReset = new HVTT.UI.Window.Forms.HVTTButton();
            this.btnToDay = new HVTT.UI.Window.Forms.HVTTButton();
            this.pnDay = new System.Windows.Forms.Panel();
            this.lblSun = new HVTT.UI.Window.Forms.Editors.HVTTLabelEditor();
            this.lblSat = new HVTT.UI.Window.Forms.Editors.HVTTLabelEditor();
            this.lblFri = new HVTT.UI.Window.Forms.Editors.HVTTLabelEditor();
            this.lblThu = new HVTT.UI.Window.Forms.Editors.HVTTLabelEditor();
            this.lblWed = new HVTT.UI.Window.Forms.Editors.HVTTLabelEditor();
            this.lblTue = new HVTT.UI.Window.Forms.Editors.HVTTLabelEditor();
            this.lblMon = new HVTT.UI.Window.Forms.Editors.HVTTLabelEditor();
            this.pnTop = new HVTT.UI.Window.Forms.HVTTPanel();
            this.lblMonthPreview = new HVTT.UI.Window.Forms.Editors.HVTTLabelEditor();
            this.lblMonthNext = new HVTT.UI.Window.Forms.Editors.HVTTLabelEditor();
            this.lblYearPreview = new HVTT.UI.Window.Forms.Editors.HVTTLabelEditor();
            this.lblYear = new HVTT.UI.Window.Forms.Editors.HVTTLabelEditor();
            this.lblYearNext = new HVTT.UI.Window.Forms.Editors.HVTTLabelEditor();
            ((System.ComponentModel.ISupportInitialize)(this.ctmMonth)).BeginInit();
            this.pn.SuspendLayout();
            this.hvttPanel1.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctmMonth
            // 
            this.ctmMonth.Items.AddRange(new HVTT.UI.Window.Forms.BaseItem[] {
            this.Month});
            this.ctmMonth.Location = new System.Drawing.Point(43, 60);
            this.ctmMonth.Name = "ctmMonth";
            this.ctmMonth.Size = new System.Drawing.Size(113, 25);
            this.ctmMonth.Style = HVTT.UI.Window.Forms.HVTTControlStyle.Office2007;
            this.ctmMonth.TabIndex = 7;
            this.ctmMonth.TabStop = false;
            this.ctmMonth.Text = "contextMenuBar1";
            // 
            // Month
            // 
            this.Month.AutoExpandOnClick = true;
            this.Month.ImagePaddingHorizontal = 8;
            this.Month.Name = "Month";
            this.Month.SubItems.AddRange(new HVTT.UI.Window.Forms.BaseItem[] {
            this.ctmJanuary,
            this.ctmFebruary,
            this.ctmMarch,
            this.ctmApril,
            this.ctmMay,
            this.ctmJune,
            this.cmtJuly,
            this.ctmAugust,
            this.cmtSeptember,
            this.cmtOctober,
            this.ctmNovember,
            this.ctmDecember});
            this.Month.Text = "Month";
            // 
            // ctmJanuary
            // 
            this.ctmJanuary.ImagePaddingHorizontal = 8;
            this.ctmJanuary.Name = "ctmJanuary";
            this.ctmJanuary.Text = "January";
            this.ctmJanuary.Click += new System.EventHandler(this.ctmJanuary_Click);
            // 
            // ctmFebruary
            // 
            this.ctmFebruary.ImagePaddingHorizontal = 8;
            this.ctmFebruary.Name = "ctmFebruary";
            this.ctmFebruary.Text = "February";
            this.ctmFebruary.Click += new System.EventHandler(this.ctmFebruary_Click);
            // 
            // ctmMarch
            // 
            this.ctmMarch.ImagePaddingHorizontal = 8;
            this.ctmMarch.Name = "ctmMarch";
            this.ctmMarch.Text = "March";
            this.ctmMarch.Click += new System.EventHandler(this.ctmMarch_Click);
            // 
            // ctmApril
            // 
            this.ctmApril.ImagePaddingHorizontal = 8;
            this.ctmApril.Name = "ctmApril";
            this.ctmApril.Text = "April";
            this.ctmApril.Click += new System.EventHandler(this.ctmApril_Click);
            // 
            // ctmMay
            // 
            this.ctmMay.ImagePaddingHorizontal = 8;
            this.ctmMay.Name = "ctmMay";
            this.ctmMay.Text = "May";
            this.ctmMay.Click += new System.EventHandler(this.ctmMay_Click);
            // 
            // ctmJune
            // 
            this.ctmJune.ImagePaddingHorizontal = 8;
            this.ctmJune.Name = "ctmJune";
            this.ctmJune.Text = "June";
            this.ctmJune.Click += new System.EventHandler(this.ctmJune_Click);
            // 
            // cmtJuly
            // 
            this.cmtJuly.ImagePaddingHorizontal = 8;
            this.cmtJuly.Name = "cmtJuly";
            this.cmtJuly.Text = "July";
            this.cmtJuly.Click += new System.EventHandler(this.cmtJuly_Click);
            // 
            // ctmAugust
            // 
            this.ctmAugust.ImagePaddingHorizontal = 8;
            this.ctmAugust.Name = "ctmAugust";
            this.ctmAugust.Text = "August";
            this.ctmAugust.Click += new System.EventHandler(this.ctmAugust_Click);
            // 
            // cmtSeptember
            // 
            this.cmtSeptember.ImagePaddingHorizontal = 8;
            this.cmtSeptember.Name = "cmtSeptember";
            this.cmtSeptember.Text = "September";
            this.cmtSeptember.Click += new System.EventHandler(this.cmtSeptember_Click);
            // 
            // cmtOctober
            // 
            this.cmtOctober.ImagePaddingHorizontal = 8;
            this.cmtOctober.Name = "cmtOctober";
            this.cmtOctober.Text = "October";
            this.cmtOctober.Click += new System.EventHandler(this.cmtOctober_Click);
            // 
            // ctmNovember
            // 
            this.ctmNovember.ImagePaddingHorizontal = 8;
            this.ctmNovember.Name = "ctmNovember";
            this.ctmNovember.Text = "November";
            this.ctmNovember.Click += new System.EventHandler(this.ctmNovember_Click);
            // 
            // ctmDecember
            // 
            this.ctmDecember.ImagePaddingHorizontal = 8;
            this.ctmDecember.Name = "ctmDecember";
            this.ctmDecember.Text = "December";
            this.ctmDecember.Click += new System.EventHandler(this.ctmDecember_Click);
            // 
            // lblMonth
            // 
            this.ctmMonth.SetContextMenuEx(this.lblMonth, this.Month);
            this.lblMonth.Description = "";
            this.lblMonth.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMonth.ForeColor = System.Drawing.Color.Teal;
            this.lblMonth.Location = new System.Drawing.Point(23, 0);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(80, 24);
            this.lblMonth.TabIndex = 5;
            this.lblMonth.Text = "March";
            this.lblMonth.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // pn
            // 
            this.pn.CanvasColor = System.Drawing.SystemColors.Control;
            this.pn.ColorSchemeStyle = HVTT.UI.Window.Forms.HVTTControlStyle.Office2007;
            this.pn.Controls.Add(this.hvttPanel1);
            this.pn.Controls.Add(this.pnDay);
            this.pn.Controls.Add(this.lblSun);
            this.pn.Controls.Add(this.lblSat);
            this.pn.Controls.Add(this.lblFri);
            this.pn.Controls.Add(this.lblThu);
            this.pn.Controls.Add(this.lblWed);
            this.pn.Controls.Add(this.lblTue);
            this.pn.Controls.Add(this.lblMon);
            this.pn.Controls.Add(this.pnTop);
            this.pn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn.Location = new System.Drawing.Point(0, 0);
            this.pn.Name = "pn";
            this.pn.Size = new System.Drawing.Size(198, 171);
            this.pn.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pn.Style.BackColor1.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.PanelBackground;
            this.pn.Style.BackColor2.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.PanelBackground2;
            this.pn.Style.Border = HVTT.UI.Window.Forms.eBorderType.SingleLine;
            this.pn.Style.BorderColor.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.PanelBorder;
            this.pn.Style.ForeColor.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.PanelText;
            this.pn.Style.GradientAngle = 90;
            this.pn.TabIndex = 3;
            // 
            // hvttPanel1
            // 
            this.hvttPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.hvttPanel1.ColorSchemeStyle = HVTT.UI.Window.Forms.HVTTControlStyle.Office2007;
            this.hvttPanel1.Controls.Add(this.lblToDay);
            this.hvttPanel1.Controls.Add(this.btnReset);
            this.hvttPanel1.Controls.Add(this.btnToDay);
            this.hvttPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hvttPanel1.Location = new System.Drawing.Point(0, 142);
            this.hvttPanel1.Name = "hvttPanel1";
            this.hvttPanel1.Size = new System.Drawing.Size(198, 29);
            this.hvttPanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.hvttPanel1.Style.BackColor1.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.PanelBackground;
            this.hvttPanel1.Style.BackColor2.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.PanelBackground2;
            this.hvttPanel1.Style.Border = HVTT.UI.Window.Forms.eBorderType.SingleLine;
            this.hvttPanel1.Style.BorderColor.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.PanelBorder;
            this.hvttPanel1.Style.ForeColor.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.PanelText;
            this.hvttPanel1.Style.GradientAngle = 90;
            this.hvttPanel1.TabIndex = 3;
            // 
            // lblToDay
            // 
            this.lblToDay.BackColor = System.Drawing.Color.Transparent;
            this.lblToDay.BackColor1 = System.Drawing.Color.Transparent;
            this.lblToDay.BackColor2 = System.Drawing.Color.Transparent;
            this.lblToDay.BorderColor = System.Drawing.Color.Transparent;
            this.lblToDay.Description = "";
            this.lblToDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDay.ForeColor = System.Drawing.Color.Teal;
            this.lblToDay.Interval = 100;
            this.lblToDay.Location = new System.Drawing.Point(109, 4);
            this.lblToDay.Name = "lblToDay";
            this.lblToDay.Size = new System.Drawing.Size(86, 23);
            this.lblToDay.TabIndex = 1;
            this.lblToDay.Text = "HVTTLable";
            this.lblToDay.Value = "";
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReset.Location = new System.Drawing.Point(56, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(52, 23);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset";
            this.btnReset.Value = "";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnToDay
            // 
            this.btnToDay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnToDay.Location = new System.Drawing.Point(3, 3);
            this.btnToDay.Name = "btnToDay";
            this.btnToDay.Size = new System.Drawing.Size(52, 23);
            this.btnToDay.TabIndex = 0;
            this.btnToDay.Text = "To Day";
            this.btnToDay.Value = "";
            this.btnToDay.Click += new System.EventHandler(this.btnToDay_Click);
            // 
            // pnDay
            // 
            this.pnDay.Location = new System.Drawing.Point(1, 45);
            this.pnDay.Name = "pnDay";
            this.pnDay.Size = new System.Drawing.Size(196, 98);
            this.pnDay.TabIndex = 2;
            this.pnDay.Paint += new System.Windows.Forms.PaintEventHandler(this.pnDay_Paint);
            // 
            // lblSun
            // 
            this.lblSun.BackColor = System.Drawing.Color.Transparent;
            this.lblSun.BackColor1 = System.Drawing.Color.Transparent;
            this.lblSun.BackColor2 = System.Drawing.Color.Transparent;
            this.lblSun.BorderColor = System.Drawing.Color.Transparent;
            this.lblSun.Description = "";
            this.lblSun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSun.ForeColor = System.Drawing.Color.Teal;
            this.lblSun.Interval = 100;
            this.lblSun.Location = new System.Drawing.Point(169, 27);
            this.lblSun.Name = "lblSun";
            this.lblSun.Size = new System.Drawing.Size(23, 15);
            this.lblSun.TabIndex = 1;
            this.lblSun.Text = "Sun";
            this.lblSun.Value = "";
            // 
            // lblSat
            // 
            this.lblSat.BackColor = System.Drawing.Color.Transparent;
            this.lblSat.BackColor1 = System.Drawing.Color.Transparent;
            this.lblSat.BackColor2 = System.Drawing.Color.Transparent;
            this.lblSat.BorderColor = System.Drawing.Color.Transparent;
            this.lblSat.Description = "";
            this.lblSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSat.ForeColor = System.Drawing.Color.Teal;
            this.lblSat.Interval = 100;
            this.lblSat.Location = new System.Drawing.Point(142, 27);
            this.lblSat.Name = "lblSat";
            this.lblSat.Size = new System.Drawing.Size(23, 15);
            this.lblSat.TabIndex = 1;
            this.lblSat.Text = "Sat";
            this.lblSat.Value = "";
            // 
            // lblFri
            // 
            this.lblFri.BackColor = System.Drawing.Color.Transparent;
            this.lblFri.BackColor1 = System.Drawing.Color.Transparent;
            this.lblFri.BackColor2 = System.Drawing.Color.Transparent;
            this.lblFri.BorderColor = System.Drawing.Color.Transparent;
            this.lblFri.Description = "";
            this.lblFri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFri.ForeColor = System.Drawing.Color.Teal;
            this.lblFri.Interval = 100;
            this.lblFri.Location = new System.Drawing.Point(115, 27);
            this.lblFri.Name = "lblFri";
            this.lblFri.Size = new System.Drawing.Size(23, 15);
            this.lblFri.TabIndex = 1;
            this.lblFri.Text = "Fri";
            this.lblFri.Value = "";
            // 
            // lblThu
            // 
            this.lblThu.BackColor = System.Drawing.Color.Transparent;
            this.lblThu.BackColor1 = System.Drawing.Color.Transparent;
            this.lblThu.BackColor2 = System.Drawing.Color.Transparent;
            this.lblThu.BorderColor = System.Drawing.Color.Transparent;
            this.lblThu.Description = "";
            this.lblThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThu.ForeColor = System.Drawing.Color.Teal;
            this.lblThu.Interval = 100;
            this.lblThu.Location = new System.Drawing.Point(88, 27);
            this.lblThu.Name = "lblThu";
            this.lblThu.Size = new System.Drawing.Size(23, 15);
            this.lblThu.TabIndex = 1;
            this.lblThu.Text = "Thu";
            this.lblThu.Value = "";
            // 
            // lblWed
            // 
            this.lblWed.BackColor = System.Drawing.Color.Transparent;
            this.lblWed.BackColor1 = System.Drawing.Color.Transparent;
            this.lblWed.BackColor2 = System.Drawing.Color.Transparent;
            this.lblWed.BorderColor = System.Drawing.Color.Transparent;
            this.lblWed.Description = "";
            this.lblWed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWed.ForeColor = System.Drawing.Color.Teal;
            this.lblWed.Interval = 100;
            this.lblWed.Location = new System.Drawing.Point(58, 27);
            this.lblWed.Name = "lblWed";
            this.lblWed.Size = new System.Drawing.Size(26, 15);
            this.lblWed.TabIndex = 1;
            this.lblWed.Text = "Wed";
            this.lblWed.Value = "";
            // 
            // lblTue
            // 
            this.lblTue.BackColor = System.Drawing.Color.Transparent;
            this.lblTue.BackColor1 = System.Drawing.Color.Transparent;
            this.lblTue.BackColor2 = System.Drawing.Color.Transparent;
            this.lblTue.BorderColor = System.Drawing.Color.Transparent;
            this.lblTue.Description = "";
            this.lblTue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTue.ForeColor = System.Drawing.Color.Teal;
            this.lblTue.Interval = 100;
            this.lblTue.Location = new System.Drawing.Point(31, 27);
            this.lblTue.Name = "lblTue";
            this.lblTue.Size = new System.Drawing.Size(23, 15);
            this.lblTue.TabIndex = 1;
            this.lblTue.Text = "Tue";
            this.lblTue.Value = "";
            // 
            // lblMon
            // 
            this.lblMon.BackColor = System.Drawing.Color.Transparent;
            this.lblMon.BackColor1 = System.Drawing.Color.Transparent;
            this.lblMon.BackColor2 = System.Drawing.Color.Transparent;
            this.lblMon.BorderColor = System.Drawing.Color.Transparent;
            this.lblMon.Description = "";
            this.lblMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMon.ForeColor = System.Drawing.Color.Teal;
            this.lblMon.Interval = 100;
            this.lblMon.Location = new System.Drawing.Point(3, 27);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(24, 15);
            this.lblMon.TabIndex = 1;
            this.lblMon.Text = "Mon";
            this.lblMon.Value = "";
            // 
            // pnTop
            // 
            this.pnTop.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnTop.ColorSchemeStyle = HVTT.UI.Window.Forms.HVTTControlStyle.Office2007;
            this.pnTop.Controls.Add(this.lblMonthPreview);
            this.pnTop.Controls.Add(this.lblMonth);
            this.pnTop.Controls.Add(this.lblMonthNext);
            this.pnTop.Controls.Add(this.lblYearPreview);
            this.pnTop.Controls.Add(this.lblYear);
            this.pnTop.Controls.Add(this.lblYearNext);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(198, 24);
            this.pnTop.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnTop.Style.BackColor1.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.PanelBackground;
            this.pnTop.Style.BackColor2.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.PanelBackground2;
            this.pnTop.Style.Border = HVTT.UI.Window.Forms.eBorderType.SingleLine;
            this.pnTop.Style.BorderColor.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.PanelBorder;
            this.pnTop.Style.ForeColor.ColorSchemePart = HVTT.UI.Window.Forms.eColorSchemePart.PanelText;
            this.pnTop.Style.GradientAngle = 90;
            this.pnTop.TabIndex = 0;
            // 
            // lblMonthPreview
            // 
            this.lblMonthPreview.BackColor = System.Drawing.Color.Transparent;
            this.lblMonthPreview.BackColor1 = System.Drawing.Color.Transparent;
            this.lblMonthPreview.BackColor2 = System.Drawing.Color.Transparent;
            this.lblMonthPreview.BorderColor = System.Drawing.Color.Transparent;
            this.lblMonthPreview.Description = "";
            this.lblMonthPreview.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMonthPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthPreview.ForeColor = System.Drawing.Color.Teal;
            this.lblMonthPreview.Interval = 100;
            this.lblMonthPreview.Location = new System.Drawing.Point(0, 0);
            this.lblMonthPreview.Name = "lblMonthPreview";
            this.lblMonthPreview.Size = new System.Drawing.Size(17, 24);
            this.lblMonthPreview.TabIndex = 5;
            this.lblMonthPreview.Text = "<";
            this.lblMonthPreview.Value = "";
            this.lblMonthPreview.MouseLeave += new System.EventHandler(this.lblMonthPreview_MouseLeave);
            this.lblMonthPreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblMonthPreview_MouseMove);
            this.lblMonthPreview.Click += new System.EventHandler(this.lblMonthPreview_Click);
            // 
            // lblMonthNext
            // 
            this.lblMonthNext.BackColor = System.Drawing.Color.Transparent;
            this.lblMonthNext.BackColor1 = System.Drawing.Color.Transparent;
            this.lblMonthNext.BackColor2 = System.Drawing.Color.Transparent;
            this.lblMonthNext.BorderColor = System.Drawing.Color.Transparent;
            this.lblMonthNext.Description = "3";
            this.lblMonthNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMonthNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthNext.ForeColor = System.Drawing.Color.Teal;
            this.lblMonthNext.Interval = 100;
            this.lblMonthNext.Location = new System.Drawing.Point(103, 0);
            this.lblMonthNext.Name = "lblMonthNext";
            this.lblMonthNext.Size = new System.Drawing.Size(17, 24);
            this.lblMonthNext.TabIndex = 3;
            this.lblMonthNext.Text = ">";
            this.lblMonthNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMonthNext.Value = "";
            this.lblMonthNext.MouseLeave += new System.EventHandler(this.lblMonthNext_MouseLeave);
            this.lblMonthNext.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblMonthNext_MouseMove);
            this.lblMonthNext.Click += new System.EventHandler(this.lblMonthNext_Click);
            // 
            // lblYearPreview
            // 
            this.lblYearPreview.BackColor = System.Drawing.Color.Transparent;
            this.lblYearPreview.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.lblYearPreview.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.lblYearPreview.BorderColor = System.Drawing.Color.Empty;
            this.lblYearPreview.Description = "";
            this.lblYearPreview.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblYearPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearPreview.ForeColor = System.Drawing.Color.Green;
            this.lblYearPreview.Interval = 100;
            this.lblYearPreview.Location = new System.Drawing.Point(120, 0);
            this.lblYearPreview.Name = "lblYearPreview";
            this.lblYearPreview.Size = new System.Drawing.Size(17, 24);
            this.lblYearPreview.TabIndex = 2;
            this.lblYearPreview.Text = "<";
            this.lblYearPreview.Value = "";
            this.lblYearPreview.MouseLeave += new System.EventHandler(this.lblYearPreview_MouseLeave);
            this.lblYearPreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblYearPreview_MouseMove);
            this.lblYearPreview.Click += new System.EventHandler(this.lblYearPreview_Click);
            // 
            // lblYear
            // 
            this.lblYear.BackColor = System.Drawing.Color.Transparent;
            this.lblYear.BackColor1 = System.Drawing.Color.Transparent;
            this.lblYear.BackColor2 = System.Drawing.Color.Transparent;
            this.lblYear.BorderColor = System.Drawing.Color.Transparent;
            this.lblYear.Description = "";
            this.lblYear.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.ForeColor = System.Drawing.Color.Green;
            this.lblYear.Interval = 100;
            this.lblYear.Location = new System.Drawing.Point(137, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(44, 24);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "2009";
            this.lblYear.Value = "";
            // 
            // lblYearNext
            // 
            this.lblYearNext.BackColor = System.Drawing.Color.Transparent;
            this.lblYearNext.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.lblYearNext.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.lblYearNext.BorderColor = System.Drawing.Color.Empty;
            this.lblYearNext.Description = "";
            this.lblYearNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblYearNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearNext.ForeColor = System.Drawing.Color.Green;
            this.lblYearNext.Interval = 100;
            this.lblYearNext.Location = new System.Drawing.Point(181, 0);
            this.lblYearNext.Name = "lblYearNext";
            this.lblYearNext.Size = new System.Drawing.Size(17, 24);
            this.lblYearNext.TabIndex = 0;
            this.lblYearNext.Text = ">";
            this.lblYearNext.Value = "";
            this.lblYearNext.MouseLeave += new System.EventHandler(this.lblYearNext_MouseLeave);
            this.lblYearNext.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblYearNext_MouseMove);
            this.lblYearNext.Click += new System.EventHandler(this.lblYearNext_Click);
            // 
            // HVTTCalendarEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctmMonth);
            this.Controls.Add(this.pn);
            this.Name = "HVTTCalendarEditor";
            this.Size = new System.Drawing.Size(198, 171);
            this.Resize += new System.EventHandler(this.HVTTCalendar_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ctmMonth)).EndInit();
            this.pn.ResumeLayout(false);
            this.hvttPanel1.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HVTT.UI.Window.Forms.HVTTPanel pn;
        private System.Windows.Forms.Panel pnDay;
        private HVTTLabelEditor lblSun;
        private HVTTLabelEditor lblSat;
        private HVTTLabelEditor lblFri;
        private HVTTLabelEditor lblThu;
        private HVTTLabelEditor lblWed;
        private HVTTLabelEditor lblTue;
        private HVTTLabelEditor lblMon;
        private HVTT.UI.Window.Forms.HVTTPanel pnTop;
        private HVTTLabelEditor lblMonthPreview;
        private HVTT.UI.Window.Forms.HVTTLabel lblMonth;
        private HVTTLabelEditor lblMonthNext;
        private HVTTLabelEditor lblYearPreview;
        private HVTTLabelEditor lblYear;
        private HVTTLabelEditor lblYearNext;
        private HVTT.UI.Window.Forms.ContextMenuBar ctmMonth;
        private HVTT.UI.Window.Forms.ButtonItem Month;
        private HVTT.UI.Window.Forms.ButtonItem ctmJanuary;
        private HVTT.UI.Window.Forms.ButtonItem ctmFebruary;
        private HVTT.UI.Window.Forms.ButtonItem ctmMarch;
        private HVTT.UI.Window.Forms.ButtonItem ctmApril;
        private HVTT.UI.Window.Forms.ButtonItem ctmMay;
        private HVTT.UI.Window.Forms.ButtonItem ctmJune;
        private HVTT.UI.Window.Forms.ButtonItem cmtJuly;
        private HVTT.UI.Window.Forms.ButtonItem ctmAugust;
        private HVTT.UI.Window.Forms.ButtonItem cmtSeptember;
        private HVTT.UI.Window.Forms.ButtonItem cmtOctober;
        private HVTT.UI.Window.Forms.ButtonItem ctmNovember;
        private HVTT.UI.Window.Forms.ButtonItem ctmDecember;
        private HVTTPanel hvttPanel1;
        private HVTTButton btnToDay;
        private HVTTLabelEditor lblToDay;
        private HVTTButton btnReset;
    }
}
