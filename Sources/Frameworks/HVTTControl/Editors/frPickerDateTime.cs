using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms.Editors
{
    public delegate void AfterShowdownEventHandler(object sender, DateTime Value);
    partial class frPickerDateTime : Form
    {
        public frPickerDateTime()
        {
            InitializeComponent();
        }

        #region Property

        //private GradientStyles _GradientStyle;
        //private SmoothingQualities _SmoothingQuality;

        private Color _mcrBorderColor;
        //private Color _mcrBackColor1;
        //private Color _mcrBackColor2;

        private DateTime _mobjValue = DateTime.Now;
        private String _sCodeLanguage = "";
        private DateTime _mdResetDate = DateTime.Now;


        Color _mcHoverColor1 = Color.FromArgb(251, 230, 148);
        Color _mcHoverColor2 = Color.FromArgb(238, 149, 21);
        Color _mcForColorActive = Color.Black;
        Color _mcForColor = Color.Silver;

        Color _mcDefaultSelectBackDay = Color.White;
        Color _mcDefaultSelectBorderDay = Color.Transparent;
        Color _mcSelectBackDay = Color.FromArgb(192, 255, 192);
        Color _mcSelectBorderDay = Color.Transparent;

        [Browsable(false)]
        public String CodeLanguage
        {
            get
            {
                return _sCodeLanguage;

            }
            set
            {
                _sCodeLanguage = value;
            }
        }
        [Browsable(false)]
        public DateTime ResetDate
        {
            get
            {
                return _mdResetDate;
            }
            set
            {
                _mdResetDate = value;
            }
        }


        //private Color _mcrHoverBorder;
        //private Color _mcrHoverColor1;
        //private Color _mcrHoverColor2;

        //private String _msText = "";
        //private HVTTAppearance _mAppearance;


        //[Description("Smoothing Quality"), Category("Appearance")]
        //public SmoothingQualities SmoothingQuality
        //{
        //    get
        //    {
        //        return _SmoothingQuality;
        //    }
        //    set
        //    {
        //        _SmoothingQuality = value;
        //        this.Invalidate();
        //    }
        //}

        //[Description("Gradient Style"), Category("Appearance")]
        //public GradientStyles GradientStyle
        //{
        //    get
        //    {
        //        return _GradientStyle;
        //    }
        //    set
        //    {
        //        _GradientStyle = value;
        //        this.Invalidate();
        //    }

        //}

        [Description("The border color"), Category("Appearance")]
        public Color BorderColor
        {
            get
            {
                return _mcrBorderColor;
            }
            set
            {
                _mcrBorderColor = value;
                this.Invalidate();
            }

        }

        //[Description("The hover border color"), Category("Appearance")]
        //public Color HoverBorderColor
        //{
        //    get
        //    {
        //        return _mcrHoverBorder;
        //    }
        //    set
        //    {
        //        _mcrHoverBorder = value;
        //        this.Invalidate();
        //    }

        //}

        //[Description("Back color 1"), Category("Appearance")]
        //public Color BackColor1
        //{
        //    get
        //    {
        //        return _mcrBackColor1;
        //    }
        //    set
        //    {
        //        _mcrBackColor1 = value;
        //        this.Invalidate();
        //    }
        //}

        //[Description("Back color 2"), Category("Appearance")]
        //public Color BackColor2
        //{
        //    get
        //    {
        //        return _mcrBackColor2;
        //    }
        //    set
        //    {
        //        _mcrBackColor2 = value;
        //        this.Invalidate();
        //    }
        //}


        //[Description("Hover color 1"), Category("Appearance")]
        //public Color HoverColor1
        //{
        //    get
        //    {
        //        return _mcrHoverColor1;
        //    }
        //    set
        //    {
        //        _mcrHoverColor1 = value;
        //        this.Invalidate();
        //    }
        //}

        //[Description("Hover color 2"), Category("Appearance")]
        //public Color HoverColor2
        //{
        //    get
        //    {
        //        return _mcrHoverColor2;
        //    }
        //    set
        //    {
        //        _mcrHoverColor2 = value;
        //        this.Invalidate();
        //    }
        //}

        //[Description("Appearance Of HVTTControl"), Category("Appearance")]
        //[Browsable(true)]
        //public HVTTAppearance Appearance
        //{
        //    get
        //    {
        //        return _mAppearance;
        //    }
        //    set
        //    {
        //        _mAppearance = value;
        //        this.Invalidate();
        //    }
        //}





        [Description("Get or set Value Of HVTTTextBox"), Category("HVTTTextBox")]
        public DateTime Value
        {
            get
            {
                return _mobjValue;
            }
            set
            {
                _mobjValue = value;
                Invalidate();
            }
        }








        public Color HoverColor1
        {
            get
            {
                return _mcHoverColor1;
            }
            set
            {
                _mcHoverColor1 = value;
            }
        }
        public Color ForeColorActive
        {
            get
            {
                return _mcForColorActive;
            }
            set
            {
                _mcForColorActive = value;
            }
        }

        public Color HoverColor2
        {
            get
            {
                return _mcHoverColor2;
            }
            set
            {
                _mcHoverColor2 = value;
            }
        }
        public Color SelectBackColor
        {
            get
            {
                return _mcSelectBackDay;
            }
            set
            {
                _mcSelectBackDay = value;
            }
        }
        public Color SelectBorderColor
        {
            get
            {
                return _mcSelectBorderDay;
            }
            set
            {
                _mcSelectBorderDay = value;
            }
        }
        public Color SelectDefaultBackColor
        {
            get
            {
                return _mcDefaultSelectBackDay;
            }
            set
            {
                _mcDefaultSelectBackDay = value;
            }
        }
        public Color SelectDefaultBorderColor
        {
            get
            {
                return _mcDefaultSelectBorderDay;
            }
            set
            {
                _mcDefaultSelectBorderDay = value;
            }
        }


        #endregion

        #region Private Method


        private void Result()
        {
            _mobjValue = Cal.SelectDate;
        }
        private void Expand()
        {

            Cal.SelectDate = _mobjValue;
            Cal.SelectBackColor = _mcSelectBackDay;
            Cal.SelectBorderColor = _mcSelectBorderDay;
            Cal.SelectDefaultBackColor = _mcDefaultSelectBackDay;
            Cal.SelectDefaultBorderColor = _mcDefaultSelectBackDay;
            Cal.HoverColor1 = _mcHoverColor1;
            Cal.HoverColor2 = _mcHoverColor2;
        }
        #endregion

        #region event
        public event AfterShowdownEventHandler AfterShowdownEvent;

        private void Cal_ToDayClick(object sender, EventArgs e)
        {
            try
            {
                Result();
                if (AfterShowdownEvent != null)
                    AfterShowdownEvent(this, _mobjValue);
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void Cal_DateClick(object sender, EventArgs e)
        {
            try
            {
                Result();
                if (AfterShowdownEvent != null)
                    AfterShowdownEvent(this, _mobjValue);
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void frPickerDateTimeInGrid_Load(object sender, EventArgs e)
        {
            Expand();
        }

        private void frPickerDateTime_Deactivate(object sender, EventArgs e)
        {
            try
            {
                Result();
                if (AfterShowdownEvent != null)
                    AfterShowdownEvent(this, _mobjValue);
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void Cal_ResetDate(object sender, EventArgs e)
        {
            try
            {
                this.Value = _mdResetDate;
                if (AfterShowdownEvent != null)
                    AfterShowdownEvent(this, _mobjValue);
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
