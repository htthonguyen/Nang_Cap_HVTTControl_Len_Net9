using System;
using System.Collections.Generic;
using System.Text;

namespace HVTT.UI.Window.Forms
{
    public class HVTTButtonItemClickEventArgs
    {
        private String _mstrKey = String.Empty;
        public String Key
        {
            get
            {
                return _mstrKey;
            }
        }

        internal void Innit(String Key)
        {
            _mstrKey = Key;
        }
    }
    public delegate void  HVTTButtonItemClickEventHandler(Object sender, HVTTButtonItemClickEventArgs e);

}
