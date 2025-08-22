using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms.Controls
{
    public partial class HVTTDateTimePicker : DateTimePicker
    {
         #region Design
        public HVTTDateTimePicker()
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            components = new System.ComponentModel.Container();
        }
        #endregion
        #endregion

        #region Avalibles
        private System.ComponentModel.Container components = null;
        private Boolean _mblnRealDate = true;
        private DateTimePickerFormat _mOldFormat;

        #endregion

        #region Properties
        private int _miLevel = 0;
        private Boolean _mblnAllowEdit = true;
        public Boolean AllowEdit
        {
            get
            {
                return _mblnAllowEdit;
            }
            set
            {
                _mblnAllowEdit = value;
                this.Enabled = _mblnAllowEdit;
            }
        }
        public int Level
        {
            get
            {
                return _miLevel;
            }
            set
            {
                _miLevel = value;
            }
        }

       


        [Bindable(true), Browsable(false)]
        public new Object Value
        {
            get
            {
                if (_mblnRealDate)
                {
                    return base.Value;
                }
                else
                {
                    return DBNull.Value;
                }
            }
            set
            {
                if (Convert.IsDBNull(value))
                {
                    _mblnRealDate = false;
                    _mOldFormat = Format;
                    Format = DateTimePickerFormat.Custom;
                    CustomFormat = " ";
                }
                else
                {
                    _mblnRealDate = true;
                    base.Value = Convert.ToDateTime(value);
                }
            }
        }

        #endregion

        #region Public Methods
        public string ToShortDateString()
        {
            if (!_mblnRealDate)
                return String.Empty;
            else
            {
                DateTime dt = (DateTime)Value;
                return dt.ToShortDateString();
            }
        }

        public DateTime GetDateValue()
        {
            return base.Value;
        }
        #endregion

        #region Custom Events
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Delete)
            {
                Value = MinDate;
                Value = DateTime.Now;
                Value = DBNull.Value;
            }
            else
            {
                if (!_mblnRealDate)
                {
                    Format = _mOldFormat;
                    CustomFormat = null;
                    _mblnRealDate = true;
                    Value = DateTime.Now;
                }
            }
        }
        protected override void OnCloseUp(EventArgs eventargs)
        {
            if (Control.MouseButtons == MouseButtons.None)
            {
                if (!_mblnRealDate)
                {
                    Format = _mOldFormat;
                    CustomFormat = null;
                    _mblnRealDate = true;
                    DateTime tempdate;
                    tempdate = (DateTime)Value;
                    Value = MinDate;
                    Value = tempdate;
                }
            }
            base.OnCloseUp(eventargs);
        }
        protected override void OnValueChanged(EventArgs eventargs)
        {
            base.OnValueChanged(eventargs);
        }
        #endregion
    }
}
