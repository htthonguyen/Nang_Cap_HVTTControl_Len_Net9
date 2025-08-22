﻿using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using HVTT.UI.Window.Forms.Rendering;
using System.Drawing.Imaging;
using System.Collections;
using HVTT.UI.Window.Forms.Controls;

namespace HVTT.UI.Window.Forms
{
    /// <summary>
    /// Represents the form class that should be used instead of standard Form when form caption is provided by Ribbon control
    /// and custom form look and feel in style of Office 2007 is required. This form does not have standard form caption.
    /// </summary>
    public class Office2007RibbonForm : Form
    {
        #region Private Variables
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private int m_TopLeftCornerSize = 6;
        private int m_TopRightCornerSize = 6;
        private int m_BottomLeftCornerSize = 6;
        private int m_BottomRightCornerSize = 6;
        protected int m_DisplayRectangleReductionTop = 1;
        protected int m_DisplayRectangleReductionBottom = 2;
        protected int m_DisplayRectangleReductionHorizontal = 4;
        RibbonControl m_RibbonControl = null;
        private FormWindowState m_WindowStateDelayed = FormWindowState.Normal;
        private bool m_TrackWindowStateSetting = false;
        private bool m_IsLoaded = false;
        private bool m_FlattenMDIBorder = true;
        private bool m_NonClientActive = true;
        private Point m_NonClientOffset = Point.Empty;
        protected bool m_EnableCustomStyle = true;
        private int m_GlassHeight = 0;
        private bool m_IsGlassEnabled = false;
        private bool m_GlassHitTestTrack = false;
        private bool m_EnableGlass = true;


        private Boolean _mbUseKeyOnAllControls = false;
        #endregion

        #region Event

        public event KeyEventHandler UseKeyOnAllControlsEvent;
        #endregion
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
            if (m_CashedCaptionBitmap != null)
            {
                m_CashedCaptionBitmap.Dispose();
                m_CashedCaptionBitmap = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Office2007RibbonForm));
            this.SuspendLayout();
            // 
            // Office2007RibbonForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Office2007RibbonForm";
            this.ResumeLayout(false);

        }

        #endregion

        public Office2007RibbonForm()
        {
            
            this.DockPadding.Top = m_DisplayRectangleReductionTop;
            this.DockPadding.Bottom = m_DisplayRectangleReductionBottom;
            this.DockPadding.Right = m_DisplayRectangleReductionHorizontal;
            this.DockPadding.Left = m_DisplayRectangleReductionHorizontal;
            
            m_IsGlassEnabled = GetGlassEnabled();
            InitializeComponent();
            UpdateFormStyle();
            UserEnterKey = true;
            EscOnClose = true;
        }




       
        



        protected virtual void UpdateFormStyle()
        {
            if (IsCustomFormStyleEnabled())
            {
                if (!this.GetStyle(ControlStyles.AllPaintingInWmPaint))
                {
                    this.SetStyle(ControlStyles.AllPaintingInWmPaint
                       | ControlStyles.ResizeRedraw
                       | DisplayHelp.DoubleBufferFlag
                       | ControlStyles.UserPaint
                       , true);
                }
            }
            else
            {
                if (this.GetStyle(ControlStyles.AllPaintingInWmPaint))
                {
                    this.SetStyle(ControlStyles.AllPaintingInWmPaint
                       | ControlStyles.ResizeRedraw
                       | DisplayHelp.DoubleBufferFlag
                       /*| ControlStyles.UserPaint*/
                       , false);
                }
            }
        }

        internal int DisplayRectangleReductionHorizontal
        {
            get { return m_DisplayRectangleReductionHorizontal; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (IsCustomFormStyleEnabled())
            {
                if (this.BackColor == SystemColors.Control && GlobalManager.Renderer is Office2007Renderer)
                    this.BackColor = ((Office2007Renderer)GlobalManager.Renderer).ColorTable.Form.BackColor;
            }

            m_IsLoaded = true;
            if (m_TrackWindowStateSetting)
            {
                base.WindowState = m_WindowStateDelayed;
                m_TrackWindowStateSetting = false;
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            InvalidateRibbonCaption();
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            InvalidateRibbonCaption();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            InvalidateRibbonCaption();
        }

        protected override void OnStyleChanged(EventArgs e)
        {
            UpdateRibbonSystemCaptionItem();
            UpdateFormStyle();
            base.OnStyleChanged(e);
        }

        /// <summary>
        /// Gets or sets whether Windows Vista Glass support is enabled when form is running on Windows Vista with Glass support.
        /// Default value is true.
        /// </summary>
        [Browsable(true), DefaultValue(true), Category("Appearance"), Description("Indicates whether Windows Vista Glass support is enabled when form is running on Windows Vista with Glass support.")]
        public bool EnableGlass
        {
            get { return m_EnableGlass; }
            set
            {
                if (m_EnableGlass != value)
                {
                    m_EnableGlass = value;
                    if (m_RibbonControl != null)
                        m_RibbonControl.CanSupportGlass = true && m_EnableGlass;
                    if (m_IsGlassEnabled && this.IsHandleCreated && !this.DesignMode)
                    {
                        bool isMdiChildMaximized = false;
                        if (this.IsMdiContainer && this.ActiveMdiChild != null && this.ActiveMdiChild.WindowState == FormWindowState.Maximized)
                            isMdiChildMaximized = true;
                        this.RecreateHandle();
                        if (isMdiChildMaximized && this.IsMdiContainer && this.ActiveMdiChild != null)
                            this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the RibbonControl that is hosted by this form. This property is for internal use only.
        /// </summary>
        [Browsable(false)]
        protected virtual RibbonControl RibbonControl
        {
            get { return m_RibbonControl; }
            set
            {
                m_RibbonControl = value;
                if (m_RibbonControl != null)
                    UpdateRibbonSystemCaptionItem();
            }
        }

        private void UpdateRibbonSystemCaptionItem()
        {
            if (m_RibbonControl != null && IsCustomFormStyleEnabled())
            {
                m_RibbonControl.RibbonStrip.SystemCaptionItem.MinimizeVisible = this.MinimizeBox;
                if (this.IsGlassEnabled && this.MinimizeBox && this.FormBorderStyle == FormBorderStyle.Sizable)
                    m_RibbonControl.RibbonStrip.SystemCaptionItem.RestoreMaximizeVisible = true;
                else
                    m_RibbonControl.RibbonStrip.SystemCaptionItem.RestoreMaximizeVisible = this.MaximizeBox;

                m_RibbonControl.RibbonStrip.SystemCaptionItem.HelpVisible = this.HelpButton;
                m_RibbonControl.RibbonStrip.SystemCaptionItem.Visible = this.ControlBox;
                m_RibbonControl.RecalcLayout();
            }
        }

        /// <summary>
        /// Gets whether Vista glass effect extension over the ribbon control caption is enabled.
        /// </summary>
        protected virtual bool EnableGlassExtend
        {
            get
            {
                return true;
            }
        }

        internal void UpdateGlass()
        {
            if (!this.IsGlassEnabled || !BarFunctions.IsHandleValid(this) || !this.EnableGlassExtend) return;

            int glassHeight = 0;

            if (m_RibbonControl == null || !m_RibbonControl.CaptionVisible)
            {
                glassHeight = SystemInformation.FrameBorderSize.Height * NativeFunctions.BorderMultiplierFactor;
            }
            else
            {
                glassHeight = m_RibbonControl.RibbonStrip.GetTotalCaptionHeight();
            }

            WinApi.ExtendGlass(this.Handle, glassHeight);
            m_GlassHeight = glassHeight;
        }

        internal int GlassHeight
        {
            get { return m_GlassHeight; }
        }

        internal void InvalidateRibbonCaption()
        {
            if (!IsCustomFormStyleEnabled())
                return;

            if (m_RibbonControl != null && m_RibbonControl.RibbonStrip.CaptionVisible)
            {
                m_RibbonControl.RibbonStrip.Invalidate(m_RibbonControl.RibbonStrip.CaptionBounds);
            }
            Rectangle r = this.ClientRectangle;
            r.Inflate(-m_DisplayRectangleReductionHorizontal * 2, -(m_DisplayRectangleReductionTop *2 + m_DisplayRectangleReductionBottom * 2));
            Region reg = new Region(this.ClientRectangle);
            reg.Exclude(GetFormPath(r));
            this.Invalidate(reg);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (e.Control is RibbonControl)
            {
                m_RibbonControl = e.Control as RibbonControl;
                m_RibbonControl.CanSupportGlass = true && m_EnableGlass;
                UpdateRibbonSystemCaptionItem();
                UpdateGlass();
            }
            base.OnControlAdded(e);
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            if (e.Control == m_RibbonControl)
            {
                m_RibbonControl.CanSupportGlass = false;
                m_RibbonControl = null;
            }
            base.OnControlRemoved(e);
        }

        protected override void OnMdiChildActivate(EventArgs e)
        {
            InvalidateRibbonCaption();
            base.OnMdiChildActivate(e);
            if (this.IsGlassEnabled)
            {
                IntPtr menu = WinApi.GetMenu(this.Handle);
                if(menu!=IntPtr.Zero)
                    WinApi.SetMenu(this.Handle, IntPtr.Zero);
            }
        }

        private bool ShouldForwardCornerEvents()
        {
            return this.WindowState == FormWindowState.Maximized && this.RibbonControl != null && !this.IsGlassEnabled;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (ShouldForwardCornerEvents() && (e.X <= m_DisplayRectangleReductionHorizontal || e.X >= this.ClientRectangle.Width - m_DisplayRectangleReductionHorizontal) && e.Y <= m_DisplayRectangleReductionHorizontal)
            {
                MouseEventArgs e1 = e;
                if (e.X >= this.ClientRectangle.Width - m_DisplayRectangleReductionHorizontal)
                    e1 = new MouseEventArgs(e.Button, e.Clicks, e.X - m_DisplayRectangleReductionHorizontal*2, e.Y, e.Delta);
                this.RibbonControl.RibbonStrip.InvokeMouseDown(e1);
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (ShouldForwardCornerEvents() && (e.X <= m_DisplayRectangleReductionHorizontal || e.X >= this.ClientRectangle.Width - m_DisplayRectangleReductionHorizontal) && e.Y <= m_DisplayRectangleReductionHorizontal)
            {
                MouseEventArgs e1 = e;
                if (e.X >= this.ClientRectangle.Width - m_DisplayRectangleReductionHorizontal)
                    e1 = new MouseEventArgs(e.Button, e.Clicks, e.X - m_DisplayRectangleReductionHorizontal * 2, e.Y, e.Delta);
                this.RibbonControl.RibbonStrip.InvokeMouseUp(e1);
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (ShouldForwardCornerEvents() && (e.X <= m_DisplayRectangleReductionHorizontal || e.X >= this.ClientRectangle.Width - m_DisplayRectangleReductionHorizontal))
            {
                MouseEventArgs e1 = e;
                if(e.X >= this.ClientRectangle.Width - m_DisplayRectangleReductionHorizontal)
                    e1 = new MouseEventArgs(e.Button, e.Clicks, e.X -m_DisplayRectangleReductionHorizontal*2, e.Y, e.Delta);
                this.RibbonControl.RibbonStrip.InvokeMouseMove(e1);
            }
            base.OnMouseMove(e);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (this.IsMdiContainer)
            {
                BarUtilities.ChangeMDIClientBorder(this, m_FlattenMDIBorder);
            }

            UpdateGlass();
            //if (IsCustomFormStyleEnabled() && IsGlassEnabled)
            //{
            //    int enable = 0;
            //    WinApi.DwmGetWindowAttribute(this.Handle, (int)WinApi.DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_ENABLED, ref enable, Marshal.SizeOf(enable));
            //    if (enable != 0)
            //    {
            //        enable = (int)WinApi.DWMNCRENDERINGPOLICY.DWMNCRP_DISABLED;
            //        int res = WinApi.DwmSetWindowAttribute(this.Handle, (int)WinApi.DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_POLICY,
            //            ref enable, Marshal.SizeOf(enable));
            //        WinApi.DwmSetWindowAttribute(this.Handle, (int)WinApi.DWMWINDOWATTRIBUTE.DWMWA_TRANSITIONS_FORCEDISABLED,
            //            ref enable, Marshal.SizeOf(enable));
            //    }
            //}
            base.OnHandleCreated(e);
        }

        private void OnFlattenMDIBorderChanged()
        {
            if (this.IsMdiContainer && this.IsHandleCreated)
            {
                BarUtilities.ChangeMDIClientBorder(this, m_FlattenMDIBorder);
            }
        }

        /// <summary>
        /// Gets or sets the form's window state.
        /// </summary>
        [Browsable(true), DefaultValue(FormWindowState.Normal)]
        public new FormWindowState WindowState
        {
            get
            {
                if (m_TrackWindowStateSetting)
                    return m_WindowStateDelayed;
                return base.WindowState;
            }
            set
            {
                //if (!m_IsLoaded)
                //{
                //    m_TrackWindowStateSetting = true;
                //    m_WindowStateDelayed = value;
                //}
                //else
                    base.WindowState = value;
                    if (value == FormWindowState.Maximized && !this.IsHandleCreated && !m_IsLoaded)
                        this.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        /// <summary>
        /// Gets or sets whether custom style for the form is enabled. Default value is true.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EnableCustomStyle
        {
            get { return m_EnableCustomStyle; }
            set
            {
                m_EnableCustomStyle = value;
                OnEnableCustomStyleChanged();
            }
        }

        /// <summary>
        /// Called when EnableCustomStyle property has changed.
        /// </summary>
        protected virtual void OnEnableCustomStyleChanged()
        {
            this.Region = null;
            FormBorderStyle fbs = this.FormBorderStyle;
            this.FormBorderStyle = FormBorderStyle.None;
            this.FormBorderStyle = fbs;
            if (this.IsGlassEnabled)
                WinApi.ExtendGlass(this.Handle, 0);
        }

        /// <summary>
        /// Gets whether custom form styling is enabled.
        /// </summary>
        /// <returns>true if custom styling is enabled otherwise false.</returns>
        protected virtual bool IsCustomFormStyleEnabled()
        {
            return m_EnableCustomStyle;
        }

        /// <summary>
        /// Gets or sets top left rounded corner size. Default value is 6.
        /// </summary>
        [Browsable(true), DefaultValue(6), Description("Indicates top left rounded corner size"), Category("Border")]
        public int TopLeftCornerSize
        {
            get { return m_TopLeftCornerSize; }
            set
            {
                if (value < 0) value = 0;
                m_TopLeftCornerSize = value;
                this.Region = null;
            }
        }

        /// <summary>
        /// Gets or sets top right rounded corner size. Default value is 6.
        /// </summary>
        /// 
        [Browsable(true), DefaultValue(6), Description("Indicates top right rounded corner size"), Category("Border")]
        public int TopRightCornerSize
        {
            get { return m_TopRightCornerSize; }
            set
            {
                if (value < 0) value = 0;
                m_TopRightCornerSize = value;
                this.Region = null;
            }
        }

        /// <summary>
        /// Gets or sets bottom left rounded corner size. Default value is 6.
        /// </summary>
        [Browsable(true), DefaultValue(6), Description("Indicates bottom left rounded corner size"), Category("Border")]
        public int BottomLeftCornerSize
        {
            get { return m_BottomLeftCornerSize; }
            set
            {
                if (value < 0) value = 0;
                m_BottomLeftCornerSize = value;
                this.Region = null;
            }
        }

        /// <summary>
        /// Gets or sets bottom right rounded corner size. Default value is 6.
        /// </summary>
        [Browsable(true), DefaultValue(6), Description("Indicates bottom right rounded corner size"), Category("Border")]
        public int BottomRightCornerSize
        {
            get { return m_BottomRightCornerSize; }
            set
            {
                if (value < 0) value = 0;
                m_BottomRightCornerSize = value;
                this.Region = null;
            }
        }

        /// <summary>
        /// Gets whether client border is painted in OnPaint method.
        /// </summary>
        protected virtual bool PaintClientBorder
        {
            get { return true && IsCustomFormStyleEnabled(); }
        }

        /// <summary>
        /// Gets whether ribbon control caption is painted
        /// </summary>
        protected virtual bool PaintRibbonCaption
        {
            get { return m_RibbonControl != null; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.HasCustomRegion && this.Region == null)
                this.Region = GetRegion();
            
            if (this.IsGlassEnabled && m_GlassHeight > 0)
            {
                e.Graphics.SetClip(new Rectangle(0, 0, this.Width, m_GlassHeight), CombineMode.Exclude);
            }

            if (this.RightToLeftLayout)
            {
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                    e.Graphics.FillRectangle(brush, new Rectangle(0, 0, this.Width, this.Height));
            }
            else

                base.OnPaint(e);

            if (PaintClientBorder && !this.IsGlassEnabled)
                PaintFormBorder(e);

            if (PaintRibbonCaption && !this.IsGlassEnabled)
                PaintCaptionParts(e.Graphics);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (this.IsGlassEnabled && m_GlassHeight > 0)
            {
                e.Graphics.SetClip(new Rectangle(0, 0, this.Width, m_GlassHeight), CombineMode.Exclude);
            }
            base.OnPaintBackground(e);
        }

        protected virtual void PaintFormBorder(PaintEventArgs e)
        {
            PaintFormBorder(e.Graphics, GetBorderColors().Length);
        }

        protected virtual void PaintFormBorder(Graphics g, int borderSize)
        {
            if (this.IsGlassEnabled) return;

            Color[] borders = GetBorderColors();

            Rectangle r = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            
            SmoothingMode sm = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.HighQuality;
            r.Inflate(-1, -1);
            using (GraphicsPath path = GetFormPath(r))
            {
                Region oldClip = g.Clip;
                g.SetClip(path, CombineMode.Exclude);
                DisplayHelp.FillRectangle(g, new Rectangle(0, 0, this.Width, this.Height), borders[0]);
                g.Clip = oldClip;
            }
            r.Inflate(1, 1);
            int colorTableIndex = 0;
            for (int i = 0; i < borderSize; i++)
            {
                Color color = borders[colorTableIndex];
                using (GraphicsPath path = GetFormPath(r))
                {
                    DisplayHelp.DrawGradientPathBorder(g, path, color, (i + 1 == borderSize ? this.BackColor : Color.Empty), 90, 1);
                }
                r.Inflate(-1, -1);

                if (colorTableIndex < borders.Length - 1)
                    colorTableIndex++;
            }

            g.SmoothingMode = sm;
        }

        protected virtual void PaintCaptionParts(Graphics g)
        {
            if (m_RibbonControl == null || !m_RibbonControl.CaptionVisible) return;
            if (m_DisplayRectangleReductionHorizontal<=2)
                return;
            
            RibbonControlRendererEventArgs e = new RibbonControlRendererEventArgs(g, m_RibbonControl, this.IsGlassEnabled);
            BaseRenderer r = m_RibbonControl.RibbonStrip.GetRenderer();
            if (r == null) return;
            Region oldClip = g.Clip;
            Rectangle formRect = new Rectangle(1, 1, this.Width - 3, this.Height - 3);
            Region formRegion = GetRegion(formRect);
            int part = m_DisplayRectangleReductionHorizontal;
            Rectangle excludeRect = new Rectangle(formRect.X, m_RibbonControl.RibbonStrip.CaptionBounds.Height + 2,
                formRect.Width, this.Height - (m_RibbonControl.RibbonStrip.CaptionBounds.Height + 2));

            g.SetClip(formRegion, CombineMode.Replace);
            g.SetClip(excludeRect, CombineMode.Exclude);
            g.TranslateTransform(1, 1);
            r.DrawRibbonControlBackground(e);
            r.DrawQuickAccessToolbarBackground(e); // Will not be needed with latest Office 2007 style
            // Draw Status bar if any...
            g.ResetTransform();
            HVTTMarkStatus statusBar = GetStatusBar();
            if (statusBar != null && BarFunctions.IsOffice2007Style(statusBar.Style) && !statusBar.IsThemed)
            {
                r = statusBar.GetRenderer();
                if (r != null)
                {
                    g.SetClip(formRegion, CombineMode.Replace);
                    ToolbarRendererEventArgs te = new ToolbarRendererEventArgs(statusBar, g, new Rectangle(0, statusBar.Top, this.Width, statusBar.Height + 4));
                    te.ItemPaintArgs = statusBar.GetItemPaintArgs(g);
                    te.ItemPaintArgs.CachedPaint = true;
                    r.DrawToolbarBackground(te);
                }
            }

            g.Clip = oldClip;
            formRegion.Dispose();
        }

        private HVTTMarkStatus GetStatusBar()
        {
            foreach (Control c in this.Controls)
            {
                if (c.Dock == DockStyle.Bottom && c is HVTTMarkStatus)
                    return c as HVTTMarkStatus;
            }

            return null;
        }

        /// <summary>
        /// Gets the array of LinearGradientColorTable objects that describe the border colors. The colors with index 0 is used as the outer most
        /// border.
        /// </summary>
        /// <returns>Array of LinearGradientColorTable</returns>
        protected virtual Color[] GetBorderColors()
        {
            if (GlobalManager.Renderer is Office2007Renderer)
            {
                Office2007FormStateColorTable ct = ((Office2007Renderer)GlobalManager.Renderer).ColorTable.Form.Active;
                if (!m_NonClientActive && !this.DesignMode) ct = ((Office2007Renderer)GlobalManager.Renderer).ColorTable.Form.Inactive;
                return ct.BorderColors;
            }
            else
            {
                return new Color[] {
                Color.FromArgb(59, 90 , 130),
                Color.FromArgb(177, 198, 225)};
            }
        }

        /// <summary>
        /// Gets or sets whether 3D MDI border is removed. Default value is true.
        /// </summary>
        [Browsable(true), DefaultValue(true), Category("Appearance"), Description("Indicates whether 3D MDI border is removed.")]
        public bool FlattenMDIBorder
        {
            get
            {
                return m_FlattenMDIBorder;
            }
            set
            {
                m_FlattenMDIBorder = value;
                OnFlattenMDIBorderChanged();
            }
        }


        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle r = base.DisplayRectangle;
                r = ReduceDisplayRectangle(r);
                return r;
            } 
        }


        protected virtual Rectangle ReduceDisplayRectangle(Rectangle r)
        {
            if (IsCustomFormStyleEnabled() && !this.IsGlassEnabled)
            {
                r.Inflate(-m_DisplayRectangleReductionHorizontal, 0);
                r.Y += m_DisplayRectangleReductionTop;
                r.Height -= (m_DisplayRectangleReductionTop + m_DisplayRectangleReductionBottom);
            }

            return r;
        }

        protected override void OnResize(EventArgs e)
        {
            if (this.HasCustomRegion)
            {
                this.Region = GetRegion();
                this.Invalidate();
            }
            base.OnResize(e);
        }

        /// <summary>
        /// Gets whether form uses custom region
        /// </summary>
        protected virtual bool HasCustomRegion
        {
            get { return true && IsCustomFormStyleEnabled() && !this.IsGlassEnabled; }
        }

        /// <summary>
        /// Returns form custom region.
        /// </summary>
        /// <returns>New instance of the custom region.</returns>
        protected virtual Region GetRegion()
        {
            if (this.WindowState == FormWindowState.Maximized || !IsCustomFormStyleEnabled())
                return null;

            return GetRegion(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }

        private Region GetRegion(Rectangle bounds)
        {
            GraphicsPath path = GetFormPath(bounds);
            Region r = new Region();
            r.MakeEmpty();
            r.Union(path);

            // Widen path for the border...
            path.Widen(SystemPens.Control);
            Region r2 = new Region(path);
            r.Union(path);

            return r;
        }

        /// <summary>
        /// Gets the form path for the give input bounds.
        /// </summary>
        /// <param name="bounds">Reprents the form bounds.</param>
        /// <returns></returns>
        protected virtual GraphicsPath GetFormPath(Rectangle bounds)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle r = bounds;
            bool rightToLeft = (this.RightToLeft == RightToLeft.Yes);
            ArcData arc;

            int cornerSize = (rightToLeft ? m_TopRightCornerSize : m_TopLeftCornerSize + 1);
            if (cornerSize>0)
            {
                arc = ElementStyleDisplay.GetCornerArc(r, cornerSize, eCornerArc.TopLeft);
                path.AddArc(arc.X, arc.Y, arc.Width, arc.Height, arc.StartAngle, arc.SweepAngle);
            }
            else
            {
                path.AddLine(bounds.X, bounds.Y + 2, bounds.X, bounds.Y);
                path.AddLine(bounds.X, bounds.Y, bounds.X + 2, bounds.Y);
            }

            cornerSize = (rightToLeft ? m_TopLeftCornerSize + 1: m_TopRightCornerSize);
            if (cornerSize > 0)
            {
                arc = ElementStyleDisplay.GetCornerArc(r, cornerSize, eCornerArc.TopRight);
                path.AddArc(arc.X, arc.Y, arc.Width, arc.Height, arc.StartAngle, arc.SweepAngle);
            }
            else
            {
                path.AddLine(bounds.Right - 2, bounds.Y, bounds.Right, bounds.Y);
                path.AddLine(bounds.Right, bounds.Y, bounds.Right, bounds.Y + 2);
            }

            if (m_BottomRightCornerSize > 0)
            {
                arc = ElementStyleDisplay.GetCornerArc(r, m_BottomRightCornerSize, eCornerArc.BottomRight);
                path.AddArc(arc.X, arc.Y, arc.Width, arc.Height, arc.StartAngle, arc.SweepAngle);
            }
            else
            {
                path.AddLine(bounds.Right, bounds.Bottom - 2, bounds.Right, bounds.Bottom);
                path.AddLine(bounds.Right, bounds.Bottom, bounds.Right - 2, bounds.Bottom);
            }

            if (m_BottomLeftCornerSize > 0)
            {
                arc = ElementStyleDisplay.GetCornerArc(r, m_BottomLeftCornerSize, eCornerArc.BottomLeft);
                path.AddArc(arc.X, arc.Y, arc.Width, arc.Height, arc.StartAngle, arc.SweepAngle);
            }
            else
            {
                path.AddLine(bounds.X + 2, bounds.Bottom, bounds.X, bounds.Bottom);
                path.AddLine(bounds.X, bounds.Bottom, bounds.X, bounds.Bottom - 2);
            }

            path.CloseAllFigures();

            return path;
        }

        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    base.OnPaintBackground(e);
        //    Graphics g = e.Graphics;
        //    Rectangle r = new Rectangle(0,0,this.Width-1, this.Height-1);
        //    using (GraphicsPath path = GetFormPath(r))
        //    {
        //        using (Pen pen = new Pen(Color.Red, 1))
        //        {
        //            path.Widen(pen);
        //            SmoothingMode sm = g.SmoothingMode;
        //            g.SmoothingMode = SmoothingMode.HighQuality;
        //            g.DrawPath(pen, path);
        //            //g.FillPath(SystemBrushes.ControlDarkDark, path);
        //            g.SmoothingMode = sm;
        //        }
        //    }
        //}

        #region Non-client area painting
        /// <summary>
        /// Paints the non-client area of the form.
        /// </summary>
        protected virtual bool WindowsMessageNCPaint(ref Message m)
        {
            if (this.IsGlassEnabled)
            {
                return true;
            }
            else
            {
                m.Result = IntPtr.Zero;
                return false;
            }
        }

        internal bool NonClientActive
        {
            get { return m_NonClientActive; }
            set { m_NonClientActive = value; }
        }
        #endregion

        #region Non-client area handling
        protected virtual bool WindowsMessageNCCalcSize(ref Message m)
        {
            // Default implementation of ribbon form does not have non-client area at all...
            if (m.WParam == IntPtr.Zero)
            {
                WinApi.RECT r = (WinApi.RECT)Marshal.PtrToStructure(m.LParam, typeof(WinApi.RECT));
                WinApi.RECT newClientRect = WinApi.RECT.FromRectangle(GetClientRectangle(r.ToRectangle())); //WinApi.RECT newClientRect = new WinApi.RECT(r.Left, r.Top, r.Right, r.Bottom);
                Marshal.StructureToPtr(newClientRect, m.LParam, false);
                m.Result = IntPtr.Zero;
            }
            else
            {
                WinApi.NCCALCSIZE_PARAMS csp;
                csp = (WinApi.NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(WinApi.NCCALCSIZE_PARAMS));

                WinApi.WINDOWPOS pos = (WinApi.WINDOWPOS)Marshal.PtrToStructure(csp.lppos, typeof(WinApi.WINDOWPOS));

                WinApi.RECT newClientRect = WinApi.RECT.FromRectangle(GetClientRectangle(new Rectangle(pos.x, pos.y, pos.cx, pos.cy)));  //WinApi.RECT newClientRect = new WinApi.RECT(pos.x, pos.y, (pos.x + pos.cx), (pos.y + pos.cy));
                
                csp.rgrc0 = newClientRect;
                csp.rgrc1 = newClientRect;
                Marshal.StructureToPtr(csp, m.LParam, false);
                m.Result = new IntPtr((int)WinApi.WindowsMessages.WVR_VALIDRECTS);
            }

            return false;
        }

        protected virtual Rectangle GetClientRectangle(Rectangle r)
        {
            if (this.WindowState == FormWindowState.Maximized && !this.IsGlassEnabled)
            {
                WinApi.RECT rect = new WinApi.RECT(0, 0, 100, 100);
                CreateParams params1 = this.CreateParams;
                WinApi.AdjustWindowRectEx(ref rect, params1.Style, false, params1.ExStyle);
                Rectangle wr = rect.ToRectangle();
                int borderWidth = Math.Abs(wr.X);
                int borderHeight = wr.Bottom - 100;
                int formBorderSize = 3;
                int formBorderSizeHorizontal = m_DisplayRectangleReductionHorizontal + 1 - 3;

                m_NonClientOffset.X = (borderWidth - formBorderSizeHorizontal);
                m_NonClientOffset.Y = (borderWidth - formBorderSize - 1);

                r.X += m_NonClientOffset.X;
                r.Width -= (borderWidth * 2 - formBorderSizeHorizontal * 2 - 1);
                r.Height -= (borderWidth * 2 - formBorderSize * 2 - 1);
                r.Y += m_NonClientOffset.Y;
                Screen scr = Screen.FromHandle(this.Handle);
                if (r.Height > scr.Bounds.Height && scr.Primary)
                    r.Height = scr.Bounds.Height;
            }
            else
            {
                m_NonClientOffset = Point.Empty;
                if (IsGlassEnabled)
                {
                    int borderWidth = SystemInformation.FrameBorderSize.Width * NativeFunctions.BorderMultiplierFactor;
                    int borderHeight = SystemInformation.FrameBorderSize.Height * NativeFunctions.BorderMultiplierFactor;
                    r.X += borderWidth;
                    r.Width -= borderWidth * 2;
                    r.Height -= borderHeight;
                }
            }

            return r;
        }

        internal bool IsGlassEnabled
        {
            get
            {
                if (this.DesignMode || this.IsMdiChild) return false;
                return m_IsGlassEnabled && m_EnableGlass;
            }
        }

        /// <summary>
        /// Called when WM_NCACTIVATE message is received.
        /// </summary>
        /// <param name="m">Reference to message data.</param>
        /// <returns>Return true to call base form implementation otherwise return false.</returns>
        protected virtual bool WindowsMessageNCActivate(ref Message m)
        {
            if (m.WParam != IntPtr.Zero)
                m_NonClientActive = true;
            else
                m_NonClientActive = false;
            
            CreateCashedCaptionBitmap();
            //if (m_CashedCaptionBitmap == null)
            //{
                base.WndProc(ref m);
            //}
            //else
                //m.Result = new IntPtr(1);
            DrawCashedCaptionBitmap();
            //if(!this.DesignMode)
            //    Redraw();
            return false;
        }

        #region Cashed Drawing of ribbon caption
        private BufferedBitmap m_CashedCaptionBitmap = null;
        private Rectangle[] m_CashedCaptionRegion = null;
        private Point m_CashedCaptionBitmapLocation = Point.Empty;
        private void CreateCashedCaptionBitmap()
        {
            if (m_RibbonControl == null || this.WindowState == FormWindowState.Minimized || !this.IsHandleCreated || !m_RibbonControl.IsHandleCreated || m_RibbonControl.RibbonStrip == null
                || m_RibbonControl.RibbonStrip.Width <= 0 || m_RibbonControl.RibbonStrip.Height <= 0 || !m_RibbonControl.Visible)
                return;
            if (m_CashedCaptionBitmap != null)
            {
                m_CashedCaptionBitmap.Dispose();
                m_CashedCaptionBitmap = null;
            }
            if (m_CashedCaptionRegion != null)
            {
                m_CashedCaptionRegion = null;
            }
            
            Rectangle r = m_RibbonControl.RibbonStrip.Bounds;
            r.Location = m_RibbonControl.PointToScreen(r.Location);
            r.Location = this.PointToClient(r.Location);
            if (this.IsGlassEnabled) r.X += SystemInformation.FrameBorderSize.Width * NativeFunctions.BorderMultiplierFactor;
            m_CashedCaptionBitmapLocation = r.Location;
            if (this.WindowState == FormWindowState.Maximized)
                m_CashedCaptionBitmapLocation.Offset(m_NonClientOffset.X, m_NonClientOffset.Y);

            Size bmpSize = new Size(m_RibbonControl.RibbonStrip.Width, Math.Min(m_RibbonControl.RibbonStrip.Height, m_RibbonControl.Height));

            IntPtr hdc = WinApi.GetWindowDC(this.Handle);
            m_CashedCaptionBitmap = new BufferedBitmap(hdc, new Rectangle(m_CashedCaptionBitmapLocation, bmpSize));
            WinApi.ReleaseDC(this.Handle, hdc);
            m_RibbonControl.RibbonStrip.InternalPaint(new PaintEventArgs(m_CashedCaptionBitmap.Graphics, Rectangle.Empty));

            ArrayList clips = new ArrayList(10);
            foreach (Control c in m_RibbonControl.RibbonStrip.Controls)
            {
                if (c.Visible)
                {
                    Rectangle rc = c.Bounds;
                    rc.Location = m_RibbonControl.RibbonStrip.PointToScreen(rc.Location);
                    rc.Location = this.PointToClient(rc.Location);
                    clips.Add(rc);
                }
            }

            m_CashedCaptionRegion = new Rectangle[clips.Count];
            clips.CopyTo(m_CashedCaptionRegion);
        }
        private void DrawCashedCaptionBitmap()
        {
            if (m_CashedCaptionBitmap == null)
                return;
            try
            {
                IntPtr dc = WinApi.GetWindowDC(this.Handle);
                try
                {
                    using (Graphics g = Graphics.FromHdc(dc))
                    {
                        m_CashedCaptionBitmap.Render(g, m_CashedCaptionRegion);
                    }
                }
                finally
                {
                    WinApi.ReleaseDC(this.Handle, dc);
                }
            }
            finally
            {
                m_CashedCaptionBitmap.Dispose();
                m_CashedCaptionBitmap = null;
                m_CashedCaptionRegion = null;
            }

            if (System.Environment.OSVersion.Version.Major >= 6)
            {
                this.RedrawBorder();
            }
            else
            {
                if (m_RibbonControl != null)
                {
                    foreach (Control c in m_RibbonControl.RibbonStrip.Controls)
                    {
                        if (c.Visible)
                        {
                            c.Refresh();
                        }
                    }
                }
            }
        }

        //private void RedrawRibbonCaption()
        //{
        //    if (m_RibbonControl == null || !this.IsHandleCreated)
        //        return;

        //    Bitmap bmp = new Bitmap(m_RibbonControl.RibbonStrip.Width, m_RibbonControl.RibbonStrip.Height);
        //    using (Graphics g = Graphics.FromImage(bmp))
        //    {
        //        m_RibbonControl.RibbonStrip.InternalPaint(new PaintEventArgs(g, Rectangle.Empty));
        //    }

        //    IntPtr dc = GetWindowDC(this.Handle);
        //    try
        //    {
        //        using (Graphics g = Graphics.FromHdc(dc))
        //        {
        //            Rectangle r = m_RibbonControl.RibbonStrip.Bounds;
        //            r.Location = m_RibbonControl.PointToScreen(r.Location);
        //            r.Location = this.PointToClient(r.Location);
        //            g.SetClip(r);
        //            foreach (Control c in m_RibbonControl.RibbonStrip.Controls)
        //            {
        //                if (c.Visible)
        //                {
        //                    Rectangle rc = c.Bounds;
        //                    rc.Location = m_RibbonControl.RibbonStrip.PointToScreen(rc.Location);
        //                    rc.Location = this.PointToClient(rc.Location);
        //                    g.SetClip(rc, CombineMode.Exclude);
        //                }
        //            }
                    
        //            //g.DrawImage(bmp, r.Location);
        //            g.TranslateTransform(r.Location.X, r.Location.Y);
        //            m_RibbonControl.RibbonStrip.InternalPaint(new PaintEventArgs(g, m_RibbonControl.RibbonStrip.ClientRectangle));
        //        }
        //    }
        //    finally
        //    {
        //        ReleaseDC(this.Handle, dc);
        //    }
        //    //bmp.Save(@"c:\denis.png", System.Drawing.Imaging.ImageFormat.Png);
        //    //bmp.Dispose();
        //}
        #endregion

        protected virtual void Redraw()
        {
            WinApi.RedrawWindow(this.Handle, IntPtr.Zero, IntPtr.Zero, WinApi.RedrawWindowFlags.RDW_UPDATENOW |
                WinApi.RedrawWindowFlags.RDW_INVALIDATE | WinApi.RedrawWindowFlags.RDW_INTERNALPAINT | WinApi.RedrawWindowFlags.RDW_ALLCHILDREN);
        }

        protected virtual void RedrawBorder()
        {
            Region r = new Region();
            Size bs = new Size(SystemInformation.Border3DSize.Width * NativeFunctions.BorderMultiplierFactor, 
                SystemInformation.Border3DSize.Height * NativeFunctions.BorderMultiplierFactor);
            r.Union(new Rectangle(0, 0, this.Width, bs.Height));
            r.Union(new Rectangle(this.Height - bs.Height, 0, this.Width, bs.Height));
            r.Union(new Rectangle(0, 0, bs.Width, this.Height));
            r.Union(new Rectangle(this.Width - bs.Width, 0, bs.Width, this.Height));
            this.Invalidate(r, true);
            r.Dispose();
            this.Update();
        }

        protected virtual bool WindowsMessageNCHitTest(ref Message m)
        {
            // Get position being tested...
            int x = WinApi.LOWORD(m.LParam);
            int y = WinApi.HIWORD(m.LParam);
            //Console.WriteLine(WinApi.LOWORD(m.LParam) + "    " + WinApi.HIWORD(m.LParam));
            Point p = PointToClient(new Point(x, y));
            int borderSize = 5;
            int cornerPadding = 1;

            if (this.IsGlassEnabled)
            {
                borderSize = SystemInformation.FrameBorderSize.Width * NativeFunctions.BorderMultiplierFactor;
                IntPtr result = IntPtr.Zero;
                WinApi.DwmDefWindowProc(this.Handle, m.Msg, m.WParam, m.LParam, out result);
                int res = result.ToInt32();
                if (res == (int)WinApi.WindowHitTestRegions.MinimizeButton ||
                    res == (int)WinApi.WindowHitTestRegions.MaximizeButton ||
                    res == (int)WinApi.WindowHitTestRegions.CloseButton ||
                    res == (int)WinApi.WindowHitTestRegions.ReduceButton ||
                    res == (int)WinApi.WindowHitTestRegions.HelpButton)
                {
                    m.Result = result;
                    m_GlassHitTestTrack = true;
                    return false;
                }
                p.X += SystemInformation.FrameBorderSize.Width * NativeFunctions.BorderMultiplierFactor;
                //p.Y += SystemInformation.FrameBorderSize.Height * NativeFunctions.BorderMultiplierFactor;
            }

            Rectangle r = Rectangle.Empty;
            if (IsSizable)
            {
                // Top border
                r = new Rectangle(m_TopLeftCornerSize, 0, this.Width - (m_BottomLeftCornerSize + m_BottomRightCornerSize), borderSize);
                if (r.Contains(p))
                {
                    m.Result = new IntPtr((int)WinApi.WindowHitTestRegions.TopSizeableBorder);
                    return false;
                }
                // Bottom border
                r = new Rectangle(m_BottomLeftCornerSize, this.Height - borderSize, this.Width - (m_BottomLeftCornerSize + m_BottomRightCornerSize), borderSize);
                if (r.Contains(p))
                {
                    m.Result = new IntPtr((int)WinApi.WindowHitTestRegions.BottomSizeableBorder);
                    return false;
                }
                // Is form mirrored?


                if (this.RightToLeftLayout && this.RightToLeft == RightToLeft.Yes)

                {
                    // Top-left corner
                    r = new Rectangle(this.Width - m_TopRightCornerSize, 0, m_TopRightCornerSize + cornerPadding, m_TopRightCornerSize + cornerPadding);
                    if (r.Contains(p))
                    {
                        m.Result = new IntPtr((int)WinApi.WindowHitTestRegions.TopLeftSizeableCorner);
                        return false;
                    }
                    // Top Right
                    r = new Rectangle(0, 0, m_TopLeftCornerSize + cornerPadding, m_TopLeftCornerSize + cornerPadding);
                    if (r.Contains(p))
                    {
                        m.Result = new IntPtr((int)WinApi.WindowHitTestRegions.TopRightSizeableCorner);
                        return false;
                    }
                    // Bottom Left
                    r = new Rectangle(this.Width - m_BottomRightCornerSize, this.Height - m_BottomRightCornerSize, m_BottomRightCornerSize + cornerPadding, m_BottomRightCornerSize + cornerPadding);
                    if (r.Contains(p))
                    {
                        m.Result = new IntPtr((int)WinApi.WindowHitTestRegions.BottomLeftSizeableCorner);
                        return false;
                    }
                    // Bottom Right
                    r = new Rectangle(0, this.Height - m_BottomLeftCornerSize, m_BottomLeftCornerSize + cornerPadding, m_BottomLeftCornerSize + cornerPadding);
                    if (r.Contains(p))
                    {
                        m.Result = new IntPtr((int)WinApi.WindowHitTestRegions.BottomRightSizeableCorner);
                        return false;
                    }

                    // Left border
                    r = new Rectangle(this.Width - borderSize, 0, borderSize, this.Height);
                    if (r.Contains(p))
                    {
                        m.Result = new IntPtr((int)WinApi.WindowHitTestRegions.LeftSizeableBorder);
                        return false;
                    }
                    // Right border
                    r = new Rectangle(0, 0, borderSize, this.Height);
                    if (r.Contains(p))
                    {
                        m.Result = new IntPtr((int)WinApi.WindowHitTestRegions.RightSizeableBorder);
                        return false;
                    }
                }
                else
                {
                    // Top-left corner
                    r = new Rectangle(0, 0, m_TopLeftCornerSize + cornerPadding, m_TopLeftCornerSize + cornerPadding);
                    if (r.Contains(p))
                    {
                        m.Result = new IntPtr((int)WinApi.WindowHitTestRegions.TopLeftSizeableCorner);
                        return false;
                    }
                    // Top Right
                    r = new Rectangle(this.Width - m_TopRightCornerSize, 0, m_TopRightCornerSize + cornerPadding, m_TopRightCornerSize + cornerPadding);
                    if (r.Contains(p))
                    {
                        m.Result = new IntPtr((int)WinApi.WindowHitTestRegions.TopRightSizeableCorner);
                        return false;
                    }
                    // Bottom Left
                    r = new Rectangle(0, this.Height - m_BottomLeftCornerSize, m_BottomLeftCornerSize + cornerPadding, m_BottomLeftCornerSize + cornerPadding);
                    if (r.Contains(p))
                    {
                        m.Result = new IntPtr((int)WinApi.WindowHitTestRegions.BottomLeftSizeableCorner);
                        return false;
                    }
                    // Bottom Right
                    r = new Rectangle(this.Width - m_BottomRightCornerSize, this.Height - m_BottomRightCornerSize, m_BottomRightCornerSize + cornerPadding, m_BottomRightCornerSize + cornerPadding);
                    if (r.Contains(p))
                    {
                        m.Result = new IntPtr((int)WinApi.WindowHitTestRegions.BottomRightSizeableCorner);
                        return false;
                    }

                    // Left border
                    r = new Rectangle(0, 0, borderSize, this.Height);
                    if (r.Contains(p))
                    {
                        m.Result = new IntPtr((int)WinApi.WindowHitTestRegions.LeftSizeableBorder);
                        return false;
                    }
                    // Right border
                    r = new Rectangle(this.Width - borderSize, 0, borderSize, this.Height);
                    if (r.Contains(p))
                    {
                        m.Result = new IntPtr((int)WinApi.WindowHitTestRegions.RightSizeableBorder);
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Returns whether form is sizable given form state (maximized, minimized, normal) and FormBorderStyle setting.
        /// </summary>
        protected virtual bool IsSizable
        {
            get
            {
                if (FormBorderStyle == FormBorderStyle.Sizable || FormBorderStyle == FormBorderStyle.SizableToolWindow)
                {
                    if (WindowState == FormWindowState.Normal)
                        return true;
                }
                return false;
            }
        }

        protected virtual bool WindowsMessageSetText(ref Message m)
        {
            base.DefWndProc(ref m);
            if (m_RibbonControl != null && m_RibbonControl.RibbonStrip != null) m_RibbonControl.RibbonStrip.Refresh();
            return false;
        }

        protected virtual bool WindowsMessageInitMenuPopup(ref Message m)
        {
            base.WndProc(ref m);
            this.Invalidate(true);
            return false;
        }

        protected virtual bool WindowsMessageWindowsPosChanged(ref Message m)
        {
            if (this.WindowState == FormWindowState.Minimized || this.WindowState == FormWindowState.Maximized)
            {
                m_TrackSetBoundsCore = true;
                base.WndProc(ref m);
                m_TrackSetBoundsCore = true;
                return false;
            }
            return true;
        }

        protected virtual bool WindowsMessageNCMouseMove(ref Message m)
        {
            return true;
        }

        protected virtual bool WindowsMessageNCMouseLeave(ref Message m)
        {
            if (m_GlassHitTestTrack)
            {
                IntPtr result = IntPtr.Zero;
                WinApi.DwmDefWindowProc(this.Handle, (int)WinApi.WindowsMessages.WM_NCHITTEST,
                    IntPtr.Zero, IntPtr.Zero, out result);
                int res = result.ToInt32();
                m_GlassHitTestTrack = false;
            }
            return true;
        }

        protected virtual bool WindowsMessageNCLButtonDown(ref Message m)
        {
            return true;
        }

        protected virtual bool WindowsMessageNCLButtonUp(ref Message m)
        {
            return true;
        }

        protected virtual bool WindowsMessageNCDblClk(ref Message m)
        {
            return true;
        }

        protected virtual bool WindowsMessageMouseActivate(ref Message m)
        {
            this.Activate();
            return true;
        }

        protected virtual bool WindowsMessageMdiSetMenu(ref Message m)
        {
            return false;
        }

        protected virtual bool WindowsMessageMdiRefreshMenu(ref Message m)
        {
            return false;
        }

        private bool WindowsMessageMdiActivate(ref Message m)
        {
            if (this.IsGlassEnabled && m_RibbonControl != null)
            {
                IntPtr menu = WinApi.GetMenu(this.Handle);
                if (menu != IntPtr.Zero)
                    WinApi.SetMenu(this.Handle, IntPtr.Zero);
            }
            return true;
        }
        
        protected virtual bool WindowsMessageSetIcon(ref Message m)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                CreateCashedCaptionBitmap();
                base.WndProc(ref m);
                DrawCashedCaptionBitmap();
                return false;
            }
            return true;
        }

        protected virtual bool WindowsMessageDwmCompositionChanged(ref Message m)
        {
            m_IsGlassEnabled = GetGlassEnabled();
            bool isMdiChildMaximized = false;
            if (this.IsMdiContainer && this.ActiveMdiChild != null && this.ActiveMdiChild.WindowState == FormWindowState.Maximized)
            {
                this.ActiveMdiChild.WindowState = FormWindowState.Normal;
                isMdiChildMaximized = true;
            }
            string text = this.Text;
            this.RecreateHandle();
            if (this.IsGlassEnabled)
            {
                this.Region = null;
                if (m_RibbonControl != null)
                    m_RibbonControl.Region = null;
                UpdateGlass();
            }

            if (isMdiChildMaximized && this.IsMdiContainer && this.ActiveMdiChild != null)
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
            this.Text = text;
            return true;
        }

        private bool GetGlassEnabled()
        {
            if (this.DesignMode) return false;
            return WinApi.IsGlassEnabled;
        }
        
        protected virtual bool WindowsMessageStyleChanged(ref Message m)
        {
            if (!m_NoStyleChangeProcessing)
            {
                CreateCashedCaptionBitmap();
                base.WndProc(ref m);
                DrawCashedCaptionBitmap();
                return false;
            }

            return true;
        }

        private bool m_NoStyleChangeProcessing = false;
        protected virtual bool WindowsMessageSetCursor(ref Message m)
        {
            // Button down on client area while there is a modal form displayed
            if (!m_NonClientActive && (WinApi.HIWORD(m.LParam) == (int)WinApi.WindowsMessages.WM_LBUTTONUP || WinApi.HIWORD(m.LParam) == (int)WinApi.WindowsMessages.WM_LBUTTONDOWN) && WinApi.LOWORD(m.LParam) == (int)WinApi.WindowHitTestRegions.Error || 
                IsGlassEnabled)
                return true;
            m_NoStyleChangeProcessing = true;
            const int WS_VISIBLE      = 0x10000000;
            IntPtr style = WinApi.GetWindowLongPtr(this.Handle, (int)WinApi.GWL.GWL_STYLE);
            int newStyle = style.ToInt32();
            newStyle = newStyle & ~(newStyle & WS_VISIBLE);
            WinApi.SetWindowLong(this.Handle, (int)WinApi.GWL.GWL_STYLE, newStyle);
            base.WndProc(ref m);
            WinApi.SetWindowLong(this.Handle, (int)WinApi.GWL.GWL_STYLE, style.ToInt32());
            m_NoStyleChangeProcessing=false;
            return false;
        }

        private bool m_TrackSetBoundsCore = false;
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (IsCustomFormStyleEnabled())
            {
                if (m_TrackSetBoundsCore ||
                    this.DesignMode && ((specified & BoundsSpecified.Height) == BoundsSpecified.Height || (specified & BoundsSpecified.Width) == BoundsSpecified.Width))
                {
                    if (width != this.Width || height != this.Height)
                    {
                        AdjustBounds(ref width, ref height, specified);
                    }
                    m_TrackSetBoundsCore = false;
                }
            }

            base.SetBoundsCore(x, y, width, height, specified);
        }

        protected virtual void AdjustBounds(ref int width, ref int height)
        {
            AdjustBounds(ref width, ref height, BoundsSpecified.Width | BoundsSpecified.Height);
        }

        protected virtual void AdjustBounds(ref int width, ref int height, BoundsSpecified specified)
        {
            WinApi.RECT rect = new WinApi.RECT(0, 0, width, height);
            CreateParams params1 = this.CreateParams;
            WinApi.AdjustWindowRectEx(ref rect, params1.Style, false, params1.ExStyle);

            if ((specified & BoundsSpecified.Height) == BoundsSpecified.Height)
            {
                height -= (rect.Height - height);
                if (IsGlassEnabled)
                    height += SystemInformation.FrameBorderSize.Height * NativeFunctions.BorderMultiplierFactor;
            }

            if ((specified & BoundsSpecified.Width) == BoundsSpecified.Width && !IsGlassEnabled)
                width -= (rect.Width - width);
        }

        protected override void SetClientSizeCore(int x, int y)
        {
            if (!this.DesignMode && IsCustomFormStyleEnabled())
            {
                m_TrackSetBoundsCore = true;

                AdjustBounds(ref x, ref y);
            }
            base.SetClientSizeCore(x, y);
        }

        //protected virtual bool SetClientSizeCoreExtension(ref int x, ref int y)
        //{
        //    if (!this.DesignMode)
        //    {
        //        m_TrackSetBoundsCore = true;
        //        int originalWidth = x, originalHeight = y;
        //        AdjustBounds(ref x, ref y);
        //        base.SetClientSizeCore(x, y);
        //        Type controlType = GetControlType();
        //        if (controlType != null)
        //        {
        //            MemberInfo[] mems = controlType.GetMember("clientWidth", BindingFlags.NonPublic | BindingFlags.Instance);
        //            if (mems.Length > 0)
        //            {
        //                controlType.InvokeMember("clientWidth", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetField, null, this, new object[] { originalWidth });
        //                controlType.InvokeMember("clientHeight", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetField, null, this, new object[] { originalHeight });
        //            }
        //        }
        //        return false;
        //    }

        //    return true;
        //}

        private Type GetControlType()
        {
            Type t = this.GetType().BaseType;
            while (t != null && t.Name != "Control")
                t = t.BaseType;
            return t;
        }
        #endregion

        protected virtual void BaseWndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        protected override void WndProc(ref Message m)
        {
            if (!IsCustomFormStyleEnabled())
            {
                base.WndProc(ref m);
                return;
            }

            bool callBase = true;
            switch (m.Msg)
            {
                case (int)WinApi.WindowsMessages.WM_STYLECHANGED:
                    {
                        callBase = WindowsMessageStyleChanged(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_NCPAINT:
                    {
                        callBase = WindowsMessageNCPaint(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_NCCALCSIZE:
                    {
                        base.WndProc(ref m);
                        WindowsMessageNCCalcSize(ref m);
                        callBase = false;
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_NCACTIVATE:
                    {
                        callBase = WindowsMessageNCActivate(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_SETTEXT:
                    {
                        callBase = WindowsMessageSetText(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_INITMENUPOPUP:
                    {
                        callBase = WindowsMessageInitMenuPopup(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_WINDOWPOSCHANGED:
                    {
                        callBase = WindowsMessageWindowsPosChanged(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_NCHITTEST:
                    {
                        callBase = WindowsMessageNCHitTest(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_ERASEBKGND:
                    {
                        callBase = false;
                        //using (Graphics g = this.CreateGraphics())
                        //{
                        //    using (SolidBrush brush = new SolidBrush(Color.Green))
                        //        g.FillRectangle(brush, new Rectangle(0,0, this.Width, this.Height));
                        //}
                        m.Result = new IntPtr(1);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_NCMOUSEMOVE:
                    {
                        callBase = WindowsMessageNCMouseMove(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_NCMOUSELEAVE:
                    {
                        callBase = WindowsMessageNCMouseLeave(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_NCLBUTTONDOWN:
                    {
                        callBase = WindowsMessageNCLButtonDown(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_NCLBUTTONUP:
                    {
                        callBase = WindowsMessageNCLButtonUp(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_SETCURSOR:
                    {
                        callBase = WindowsMessageSetCursor(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_SETICON:
                    {
                        callBase = WindowsMessageSetIcon(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_NCLBUTTONDBLCLK:
                    {
                        callBase = WindowsMessageNCDblClk(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_MOUSEACTIVATE:
                    {
                        callBase = WindowsMessageMouseActivate(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_MDISETMENU:
                    {
                        callBase = WindowsMessageMdiSetMenu(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_MDIREFRESHMENU:
                    {
                        callBase = WindowsMessageMdiRefreshMenu(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_DWMCOMPOSITIONCHANGED:
                    {
                        callBase = WindowsMessageDwmCompositionChanged(ref m);
                        break;
                    }
                case (int)WinApi.WindowsMessages.WM_MDIACTIVATE:
                    {
                        callBase = WindowsMessageMdiActivate(ref m);
                        break;
                    }
                case 0xae:
                case 0x92:
                    {
                        // Mistery message that paints the min, max, close buttons when mouse hits the corners of the form for resizing...
                        callBase = false;
                        break;
                    }
            }

            if(callBase)
                base.WndProc(ref m);
        }


        public Boolean UseKeyOnAllControls
        {
            get
            {
                return _mbUseKeyOnAllControls;
            }
            set
            {
                _mbUseKeyOnAllControls = value;
            }
        }
        public Boolean UserEnterKey
        {
            get;set;
        }
        [Browsable(false)]
        public Boolean AutoMenuOpened
        {
            get;set;
        }
        public Boolean EscOnClose
        {
            get; set;
        }
        private Boolean IsDataGridView(Control c)
        {
            if (c != null)
            {
                if (c is HVTT.UI.Window.Forms.Controls.DataGridView)
                    return true;
                Boolean bln = IsDataGridView(c.Parent);
                return bln;
            }
            else
                return false;
        }
        private Boolean IsRichTextBox(Control c)
        {
            if (c != null)
            {
                if (c is HVTT.UI.Window.Forms.Controls.HVTTRichTextBox)
                    return true;
                Boolean bln = IsRichTextBox(c.Parent);
                return bln;
            }
            else
                return false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(!AutoMenuOpened)
            {
                if (UserEnterKey)
                {
                    if (keyData == Keys.Up)
                    {
                        if (IsDataGridView(this.ActiveControl))
                            return base.ProcessCmdKey(ref msg, keyData);

                        if (this.ActiveControl != null && this.ActiveControl is HVTTRichTextBox)
                            return base.ProcessCmdKey(ref msg, keyData);
                        if (this.ActiveControl != null && this.ActiveControl is HVTTRichTextAdvanced)
                            return base.ProcessCmdKey(ref msg, keyData);

                        if (this.ActiveControl != null && this.ActiveControl is HVTTRichTextAdvanced)
                            return base.ProcessCmdKey(ref msg, keyData);

                        if (this.ActiveControl != null
                            && (
                                (this.ActiveControl is HVTTUserControl)
                                ||
                                (
                                    this.ActiveControl.Parent != null
                                    && this.ActiveControl.Parent is HVTTUserControl
                                )
                                ||
                                (
                                    this.ActiveControl.Parent.Parent != null
                                    && this.ActiveControl.Parent.Parent is HVTTUserControl
                                )
                                ||
                                (
                                    this.ActiveControl.Parent.Parent.Parent != null
                                    && this.ActiveControl.Parent.Parent.Parent is HVTTUserControl
                                )
                                )

                            )
                        {

                            return base.ProcessCmdKey(ref msg, keyData);
                        }

                        HVTTTextBox txt = this.ActiveControl as HVTTTextBox;
                        if (txt != null && txt.AutoMenuOpened)
                        {
                            txt.AutoMenuSelectNext(-1);
                            return true;
                        }

                        HVTTRichTextBox txt5 = this.ActiveControl as HVTTRichTextBox;
                        if (txt5 != null && txt5.AutoMenuOpened)
                        {
                            txt5.AutoMenuSelectNext(-1);
                            return true;
                        }

                        var txt1 = this.ActiveControl as HVTTMaskTextBox;
                        if (txt1 != null && txt1.AutoMenuOpened)
                        {
                            txt1.AutoMenuSelectNext(-1);
                            return true;
                        }

                        var txt2 = this.ActiveControl as HVTTNumberic;
                        if (txt2 != null && txt2.AutoMenuOpened)
                        {
                            txt2.AutoMenuSelectNext(-1);
                            return true;
                        }


                        return ProcessTabKey(false);
                    }
                    else if (keyData == Keys.Down)
                    {
                        if (IsDataGridView(this.ActiveControl))
                            return base.ProcessCmdKey(ref msg, keyData);

                        if (this.ActiveControl != null && this.ActiveControl is HVTTRichTextBox)
                            return base.ProcessCmdKey(ref msg, keyData);
                        if (this.ActiveControl != null && this.ActiveControl is HVTTRichTextAdvanced)
                            return base.ProcessCmdKey(ref msg, keyData);
                        if (this.ActiveControl != null
                           && (
                               (this.ActiveControl is HVTTUserControl)
                               ||
                               (
                                   this.ActiveControl.Parent != null
                                   && this.ActiveControl.Parent is HVTTUserControl
                               )
                               ||
                               (
                                   this.ActiveControl.Parent.Parent != null
                                   && this.ActiveControl.Parent.Parent is HVTTUserControl
                               )
                               ||
                               (
                                   this.ActiveControl.Parent.Parent.Parent != null
                                   && this.ActiveControl.Parent.Parent.Parent is HVTTUserControl
                               )
                               )

                           )
                        {

                            return base.ProcessCmdKey(ref msg, keyData);
                        }

                        HVTTTextBox txt = this.ActiveControl as HVTTTextBox;
                        if (txt != null && txt.AutoMenuOpened)
                        {
                            txt.AutoMenuSelectNext(+1);
                            return true;
                        }

                        HVTTRichTextBox txt5 = this.ActiveControl as HVTTRichTextBox;
                        if (txt5 != null && txt5.AutoMenuOpened)
                        {
                            txt5.AutoMenuSelectNext(+1);
                            return true;
                        }

                        var txt1 = this.ActiveControl as HVTTMaskTextBox;
                        if (txt1 != null && txt1.AutoMenuOpened)
                        {
                            txt1.AutoMenuSelectNext(+1);
                            return true;
                        }

                        var txt2 = this.ActiveControl as HVTTNumberic;
                        if (txt2 != null && txt2.AutoMenuOpened)
                        {
                            txt2.AutoMenuSelectNext(+1);
                            return true;
                        }

                        return ProcessTabKey(true);
                    }
                    else if (keyData == Keys.Tab)
                    {
                        HVTTTextBox txt = this.ActiveControl as HVTTTextBox;
                        if (txt != null && txt.AutoMenuOpened)
                        {
                            txt.AutoMenuOnSelecting();
                            return true;
                        }

                        HVTTRichTextBox txt5 = this.ActiveControl as HVTTRichTextBox;
                        if (txt5 != null && txt5.AutoMenuOpened)
                        {
                            txt5.AutoMenuOnSelecting();
                            return true;
                        }

                        HVTTMaskTextBox txt1 = this.ActiveControl as HVTTMaskTextBox;
                        if (txt1 != null && txt1.AutoMenuOpened)
                        {
                            txt1.AutoMenuOnSelecting();
                            return true;
                        }

                        HVTTNumberic txt2 = this.ActiveControl as HVTTNumberic;
                        if (txt2 != null && txt2.AutoMenuOpened)
                        {
                            txt2.AutoMenuOnSelecting();
                            return true;
                        }
                    }

                }
                if (keyData == Keys.Escape && this.EscOnClose)
                {
                    HVTTTextBox txt = this.ActiveControl as HVTTTextBox;
                    if (txt != null && txt.AutoMenuOpened)
                    {
                        txt.AutoMenuOnClose();
                        return true;
                    }
                    HVTTRichTextBox txt5 = this.ActiveControl as HVTTRichTextBox;
                    if (txt5 != null && txt5.AutoMenuOpened)
                    {
                        txt5.AutoMenuOnClose();
                        return true;
                    }

                    HVTTMaskTextBox txt1 = this.ActiveControl as HVTTMaskTextBox;
                    if (txt1 != null && txt1.AutoMenuOpened)
                    {
                        txt1.AutoMenuOnClose();
                        return true;
                    }

                    HVTTNumberic txt2 = this.ActiveControl as HVTTNumberic;
                    if (txt2 != null && txt2.AutoMenuOpened)
                    {
                        txt2.AutoMenuOnClose();
                        return true;
                    }

                    this.Close();
                    return true;
                }
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if(!AutoMenuOpened)
            {
                if (UserEnterKey)
                {
                    if (keyData == Keys.Enter)
                    {

                        if (IsDataGridView(this.ActiveControl))
                            return base.ProcessDialogKey(keyData);
                        if (this.ActiveControl != null && (this.ActiveControl is HVTTButton || this.ActiveControl is HVTTRichTextBox || this.ActiveControl is HVTTRichTextAdvanced))
                            return base.ProcessDialogKey(keyData);
                        if (this.ActiveControl != null
                           && (
                               (this.ActiveControl is HVTTUserControl)
                               ||
                               (
                                   this.ActiveControl.Parent != null
                                   && this.ActiveControl.Parent is HVTTUserControl
                               )
                               ||
                               (
                                   this.ActiveControl.Parent.Parent != null
                                   && this.ActiveControl.Parent.Parent is HVTTUserControl
                               )
                               ||
                               (
                                   this.ActiveControl.Parent.Parent.Parent != null
                                   && this.ActiveControl.Parent.Parent.Parent is HVTTUserControl
                               )
                               )

                           )
                        {

                            return base.ProcessDialogKey(keyData);
                        }

                        HVTTTextBox txt = this.ActiveControl as HVTTTextBox;
                        if (txt != null && txt.AutoMenuOpened)
                        {
                            txt.AutoMenuOnSelecting();
                            return true;
                        }

                        HVTTRichTextBox txt5 = this.ActiveControl as HVTTRichTextBox;
                        if (txt5 != null && txt5.AutoMenuOpened)
                        {
                            txt5.AutoMenuOnSelecting();
                            return true;
                        }

                        HVTTMaskTextBox txt1 = this.ActiveControl as HVTTMaskTextBox;
                        if (txt1 != null && txt1.AutoMenuOpened)
                        {
                            txt1.AutoMenuOnSelecting();
                            return true;
                        }

                        HVTTNumberic txt2 = this.ActiveControl as HVTTNumberic;
                        if (txt2 != null && txt2.AutoMenuOpened)
                        {
                            txt2.AutoMenuOnSelecting();
                            return true;
                        }

                        return ProcessTabKey(true);
                    }
                }
                if (_mbUseKeyOnAllControls)
                {
                    if (UseKeyOnAllControlsEvent != null)
                    {
                        KeyEventArgs Key = new KeyEventArgs(keyData);
                        UseKeyOnAllControlsEvent(this, Key);
                    }
                }
            }
            
            return base.ProcessDialogKey(keyData);
        }
    }
}