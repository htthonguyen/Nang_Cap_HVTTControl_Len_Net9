using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms
{

    public class HVTTStyle2008
    {


#region Property

        public Color BackColor1 = Color.FromArgb(0, 189, 31);
        public Color BackColor2 = Color.FromArgb(183, 255, 190);
        public Color BorderColor = Color.Black;

        public Color HoverColor1 = Color.FromArgb(238, 149, 21);
        public Color HoverColor2 = Color.FromArgb(251, 230, 148);
        public Color HoverBorderColor = Color.MediumSeaGreen;

        public Color ForeColor = Color.Teal;

        public Color RequireBackColor = Color.Moccasin;
        public Color RequireBorderColor = Color.Red;

        public Color UseBackColor = Color.Silver;//MediumSeaGreen
        public Color UseForeColor = Color.LavenderBlush;
        public Color UseBorderColor = Color.Red;
        public Color UseSelectForeColor = Color.White;

        public Color AllowEditBackColor = Color.FromArgb(224, 224, 224);
        public Color AllowEditBorderColor = Color.FromArgb(0, 0, 192);//Color.FromArgb(0, 0, 192);

    
#endregion

#region Private Method

#endregion

#region Public Method
        public void Require()
        {
            BackColor1 = Color.Wheat;
            BorderColor = Color.Red;
        }

        public void ReadOnly()
        {
            BorderColor = Color.FromArgb(0, 0, 192);
            BackColor1 = Color.Lavender;
        }
#endregion

#region Sub Class

#endregion

#region Enum

#endregion

#region Struct

#endregion

#region Event

#endregion
    }

   
}
