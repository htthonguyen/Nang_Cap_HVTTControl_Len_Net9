using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace HVTT.UI.Window.Forms.Editors
{
    [Description("LabelEditor Control")]
    internal partial class HVTTLabelEditor : System.Windows.Forms.Label
    {
       

       

#region Designer

        public HVTTLabelEditor()
        {
            InitializeComponent();
            Size = new Size(75, 23);
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer |
                ControlStyles.Selectable |
                ControlStyles.UserMouse,
                true
                );
            SetValueDefault();
        }

#endregion

    #region Avalible
        //String sText = "";
    #endregion

#region Property

        //private TextStyles _TextStyle;

        private Color _mcrBorderColor;
        private Color _mcrBackColor1;
        private Color _mcrBackColor2;

        private MouseStates _mMouseState = MouseStates.MouseLeave;
        private String _msDescription = "";
        private String _msValue = "";
        private int _miInterval;
        //private Color _mcrHoverBorder;
        //private Color _mcrHoverColor1;
        //private Color _mcrHoverColor2;
       
        //[Description("Text Style"), Category("HVTTLabel")]
        //public TextStyles TextStyle
        //{
        //    get
        //    {
        //        return _TextStyle;
        //    }
        //    set
        //    {
        //        _TextStyle = value;
        //        if (_TextStyle == TextStyles.TextRun)
        //        {
        //            sText = this.Text;
        //            Timer.Enabled = true;
        //            Timer.Interval = _miInterval;
        //        }
        //        else
        //        {
        //            Timer.Enabled = false;
        //           this.Text = sText;
        //        }
        //    }
        //}


        [Description("Interval Text run"), Category("HVTTLabel")]
        public int Interval
        {
            get
            {
                return _miInterval;
            }
            set
            {
                _miInterval = value;
            }
        }

        [Description("Description for control"), Category("HVTTLabel")]
        public String Description
        {
            get
            {
                return _msDescription;
            }
            set
            {
                _msDescription = value;
            }
        }

        [Description("Value for control"), Category("HVTTLabel")]
        public String Value
        {
            get
            {
                return _msValue;
            }
            set
            {
                _msValue = value;
            }
        }

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

        [Description("Back color 1"), Category("Appearance")]
        public Color BackColor1
        {
            get
            {
                return _mcrBackColor1;
            }
            set
            {
                _mcrBackColor1 = value;
                this.Invalidate();
            }
        }

        [Description("Back color 2"), Category("Appearance")]
        public Color BackColor2
        {
            get
            {
                return _mcrBackColor2;
            }
            set
            {
                _mcrBackColor2 = value;
                this.Invalidate();
            }
        }

#endregion

#region Private Method
        private void SetValueDefault()
        {
           
            //_TextStyle = TextStyles.Normal;
            _mcrBackColor1 = SystemColors.Control;
            _mcrBackColor2 = SystemColors.Control;
            _mcrBorderColor = SystemColors.Control;

            _miInterval = 100;
            //_mcrHoverBorder = SystemColors.Control;
            //_mcrHoverColor1 = SystemColors.Control;
            //_mcrHoverColor2 = SystemColors.Control;
            this.BackColor = Color.Transparent;
            this.Text = "HVTTLable";
            this.AutoSize = false;
        }
        private void SetControlStyle()
        {
            
            
        }
        private String FormatText(Graphics g)
        {
            String s = this.Text;
            SizeF TextSize = g.MeasureString(s, base.Font);
            int iWith = (int)TextSize.Width;

            String RS = s;
            if (iWith > this.Width)
            {
                int iWhile = (int)(iWith / this.Width);
                String[] RSArray = new String[iWhile + 2];
                int k = 0;
                RS = "";
                while (iWhile >= 0)
                {
                    String[] M = s.Split(new String[] { " " }, StringSplitOptions.None);
                    String sPlus = M[0] + " ";
                    TextSize = g.MeasureString(sPlus, base.Font);
                    iWith = (int)TextSize.Width;
                    int i = 1;
                    TextSize = g.MeasureString(M[0], base.Font);
                    int x = (int)TextSize.Width;
                    while (iWith < this.Width - x && i < M.Length)
                    {
                        sPlus = sPlus + M[i] + " ";
                        TextSize = g.MeasureString(sPlus, base.Font);
                        iWith = (int)TextSize.Width;
                        i++;
                        if (i < M.Length - 1)
                        {
                            TextSize = g.MeasureString(M[i], base.Font);
                            x = (int)TextSize.Width;
                        }

                    }
                    RSArray[k] = sPlus;
                    s = "";
                    if (i < M.Length)
                    {
                     
                        for (; i < M.Length; i++)
                        {
                            if (i < M.Length - 1)
                                s = s + M[i] + " ";
                            else
                                s = s + M[i];
                        }
                    }
                    iWhile--;
                    k++;
                }
                if (s.Trim() != "" && k < RSArray.Length)
                    RSArray[k] = s.Trim();
                
                for (int i = 0; i < RSArray.Length; i++)
                {
                    if (i < RSArray.Length - 1)
                        RS = RS + RSArray[i] + "\n";
                    else
                        RS = RS + RSArray[i];
                }
            }
            return RS;
        }


      
        

#endregion

#region Public Method

#endregion

#region Sub Class

#endregion

#region Enum

        //public enum TextStyles
        //{
        //    Normal,
        //    TextRun
        //}

        private enum MouseStates
        {
            MouseMove,
            MouseLeave,
            MouseClick,
            Default
        }
#endregion

#region Struct

#endregion

#region Event
        protected override void OnMouseMove(MouseEventArgs e)
        {
            _mMouseState = MouseStates.MouseMove;
            base.OnMouseMove(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            _mMouseState = MouseStates.MouseLeave;
            base.OnMouseLeave(e);
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            _mMouseState = MouseStates.MouseClick;
            base.OnMouseClick(e);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            //if (_mcrBackColor1 == Color.Transparent)
            //{
            //    this.BackColor = Color.Transparent;
            //}
            //else
            //{
                Brush brush;
                LinearGradientMode Mode;
                Graphics g = pe.Graphics;

                g.SmoothingMode = SmoothingMode.HighQuality;
                Mode = Mode = LinearGradientMode.Vertical;

                Rectangle NewRect = new Rectangle(ClientRectangle.X + 1, ClientRectangle.Y + 1, ClientRectangle.Width - 3, ClientRectangle.Height - 3);
                brush = new SolidBrush(_mcrBackColor1);
                brush = new LinearGradientBrush(NewRect, _mcrBackColor1, _mcrBackColor2, Mode);
                g.FillRectangle(brush, NewRect);

                g.DrawRectangle(new Pen(_mcrBorderColor, 1), NewRect);
                g.DrawString(this.Text, base.Font, new SolidBrush(base.ForeColor), 1, 1);

                if (brush != null)
                    brush.Dispose();
            //}
        
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //String s = this.Text;
            //String x = s.Substring(0, 1);
            //String y = s.Substring(1);
            //this.Text = y + x;
        }
#endregion

       
    }
}
