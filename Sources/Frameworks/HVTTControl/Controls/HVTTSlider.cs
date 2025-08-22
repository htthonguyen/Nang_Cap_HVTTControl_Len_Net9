using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.ComponentModel;

namespace HVTT.UI.Window.Forms.Controls
{
    /// <summary>
    /// Represents the Slider control.
    /// </summary>
    [ToolboxBitmap(typeof(HVTTSlider), "Controls.Slider.ico"), ToolboxItem(true), DefaultEvent("ValueChanged"), ComVisible(false)]
    public class HVTTSlider : BaseItemControl
    {
        #region Private Variables
        private SliderItem m_Slider = null;
        #endregion

        #region Events
        /// <summary>
        /// Occurs after Value property has changed.
        /// </summary>
        public event EventHandler ValueChanged;
        #endregion

        #region Constructor, Dispose
        public HVTTSlider()
        {
            m_Slider = new SliderItem();
            m_Slider.Style = HVTTControlStyle.Office2007;
            m_Slider.ValueChanged += new EventHandler(SliderValueChanged);
            this.HostItem = m_Slider;
        }

        private void SliderValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(e);
        }

        /// <summary>
        /// Raises the ValueChanged event.
        /// </summary>
        /// <param name="e">Provides event arguments</param>
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        /// <summary>
        /// Gets or sets the text label position in relationship to the slider. Default value is Left.
        /// </summary>
        [Browsable(true), DefaultValue(eSliderLabelPosition.Left), Category("Layout"), Description("Indicates text label position in relationship to the slider")]
        public eSliderLabelPosition LabelPosition
        {
            get { return m_Slider.LabelPosition; }
            set
            {
                m_Slider.LabelPosition = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the text label next to the slider is displayed.
        /// </summary>
        [HVTTBrowsable(true), Browsable(true), Description("Gets or sets whether the label text is displayed."), Category("Behavior"), DefaultValue(true)]
        public bool LabelVisible
        {
            get
            {
                return m_Slider.LabelVisible;
            }
            set
            {
                m_Slider.LabelVisible = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the label part of the item in pixels. Value must be greater than 0. Default value is 38.
        /// </summary>
        [Browsable(true), HVTTBrowsable(true), DefaultValue(38), System.ComponentModel.Category("Layout"), System.ComponentModel.Description("Indicates width of the label part of the item in pixels.")]
        public int LabelWidth
        {
            get
            {
                return m_Slider.LabelWidth;
            }
            set
            {
                m_Slider.LabelWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum value of the range of the control.
        /// </summary>
        [HVTTBrowsable(true), Browsable(true), Description("Gets or sets the maximum value of the range of the control."), Category("Behavior"), DefaultValue(100)]
        public int Maximum
        {
            get
            {
                return m_Slider.Maximum;
            }
            set
            {
                m_Slider.Maximum = value;
            }
        }

        /// <summary>
        /// Gets or sets the minimum value of the range of the control.
        /// </summary>
        [HVTTBrowsable(true), Browsable(true), Description("Gets or sets the minimum value of the range of the control."), Category("Behavior"), DefaultValue(0)]
        public int Minimum
        {
            get
            {
                return m_Slider.Minimum;
            }
            set
            {
                m_Slider.Minimum = value;
            }
        }

        /// <summary>
        /// Gets or sets the current position of the slider.
        /// </summary>
        [HVTTBrowsable(true), Browsable(true), Description("Gets or sets the current position of the slider."), Category("Behavior")]
        public int Value
        {
            get { return m_Slider.Value; }
            set
            {
                m_Slider.Value = value;
            }
        }

        /// <summary>
        /// Gets or sets the amount by which a call to the PerformStep method increases the current position of the slider. Value must be greater than 0.
        /// </summary>
        [HVTTBrowsable(true), Browsable(true), Description("Gets or sets the amount by which a call to the PerformStep method increases the current position of the slider."), Category("Behavior"), DefaultValue(1)]
        public int Step
        {
            get
            {
                return m_Slider.Step;
            }
            set
            {
                m_Slider.Step = value;
            }
        }

        /// <summary>
        /// Advances the current position of the slider by the amount of the Step property.
        /// </summary>
        public void PerformStep()
        {
            m_Slider.PerformStep();
        }

        /// <summary>
        /// Gets or sets the color of the label text.
        /// </summary>
        [Browsable(true), Category("Appearance"), Description("Indicates color of the label text.")]
        public Color TextColor
        {
            get { return m_Slider.TextColor; }
            set
            {
                m_Slider.TextColor = value;
            }
        }
        /// <summary>
        /// Returns whether property should be serialized. Used by Windows Forms designer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeTextColor()
        {
            return m_Slider.ShouldSerializeTextColor();
        }
        /// <summary>
        /// Resets the property to default value. Used by Windows Forms designer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResetTextColor()
        {
            m_Slider.ResetTextColor();
        }

        [Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        /// <summary>
        /// Gets or sets whether vertical line track marker is displayed on the slide line. Default value is true.
        /// </summary>
        [Browsable(true), Category("Appearance"), DefaultValue(true), Description("Indicates whether vertical line track marker is displayed on the slide line.")]
        public virtual bool TrackMarker
        {
            get { return m_Slider.TrackMarker; }
            set
            {
                m_Slider.TrackMarker = value;
            }
        }

        /// <summary>
        /// Forces the button to perform internal layout.
        /// </summary>
        public override void RecalcLayout()
        {
            Rectangle r = GetItemBounds();
            m_Slider.Width = Math.Max(r.Width - (m_Slider.LabelVisible ? m_Slider.LabelWidth : 0), 30);
            base.RecalcLayout();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == System.Windows.Forms.Keys.Left)
            {
                m_Slider.Increment(-m_Slider.Step);
                return true;
            }
            else if (keyData == System.Windows.Forms.Keys.Right)
            {
                m_Slider.Increment(m_Slider.Step);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Gets or sets the tooltip for the Increase button of the slider.
        /// </summary>
        [Browsable(true), DefaultValue(""), Localizable(true), Category("Appearance"), Description("Indicates tooltip for the Increase button of the slider.")]
        public string IncreaseTooltip
        {
            get { return m_Slider.IncreaseTooltip; }
            set { m_Slider.IncreaseTooltip = value; }
        }

        /// <summary>
        /// Gets or sets the tooltip for the Decrease button of the slider.
        /// </summary>
        [Browsable(true), DefaultValue(""), Localizable(true), Category("Appearance"), Description("Indicates tooltip for the Increase button of the slider.")]
        public string DecreaseTooltip
        {
            get { return m_Slider.DecreaseTooltip; }
            set { m_Slider.DecreaseTooltip = value; }
        }
        #endregion
    }
}
