using System;
using System.Collections.Generic;
using System.Text;

namespace HVTT.UI.Window.Forms.Controls
{
    public class HVTTMultiComboBoxDisplayColumn
    {
        private String _mstrColumnName = String.Empty;
        private int _miIndex = 0;
        private int _miWidth = 100;
        private Boolean _mblnKey = false;
        private String _mstrColumnText = String.Empty;

        public HVTTMultiComboBoxDisplayColumn()
        {
            _mstrColumnName = String.Empty;
            _miIndex = 0;
            _mblnKey = false;
            _miWidth = 100;
            _mstrColumnText = String.Empty;
        }

        public String ColumnName
        {
            get
            {
                return _mstrColumnName;
            }
            set
            {
                _mstrColumnName = value;
            }
        }
        public String ColumnText
        {
            get
            {
                return _mstrColumnText;
            }
            set
            {
                _mstrColumnText = value;
            }
        }
        public int Index
        {
            get
            {
                return _miIndex;
            }
            set
            {
                _miIndex = value;
            }
        }
        public int Width
        {
            get
            {
                return _miWidth;
            }
            set
            {
                _miWidth = value;
            }
        }
        public Boolean IsKey
        {
            get
            {
                return _mblnKey;
            }
            set
            {
                _mblnKey = value;
            }
        }
    }

}
