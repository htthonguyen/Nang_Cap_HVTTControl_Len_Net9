using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms.Controls
{
    [DefaultEvent("SelectedIndexChanged")]
    [ToolboxBitmap("HVTTDownUp.png")]
    public partial class HVTTDownUp : UserControl
    {
        public HVTTDownUp()
        {
            InitializeComponent();
            SetStyle(
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.ResizeRedraw |
                  ControlStyles.DoubleBuffer |
                  ControlStyles.Selectable |
                  ControlStyles.UserMouse,
                  true
                  );
            SetValueDefault();
            tb.BorderStyle = BorderStyle.None;
        }

        #region Avalible

        HVTTStyle2008 _HVTTStyle2008 = new HVTTStyle2008();
        Color _RecentBackColor = Color.Empty;
        Color _RecentBorderColor = Color.Empty;


        int iIndex = 0;
        #endregion

        #region Private Method

        private Boolean Search(String s, Char c)
        {
            Char[] c_Array = s.ToCharArray();
            for (int i = 0; i < c_Array.Length; i++)
                if (c_Array[i].ToString().ToUpper() == c.ToString().ToUpper())
                    return true;
            return false;
        }

        private String Search(String s, DataTable tbl)
        {
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                if (s.Trim().ToUpper() == tbl.Rows[i][0].ToString().Trim().ToUpper())
                    return s;
            }
            return String.Empty;
        }
        private int Search(String s, DataTable tbl, Boolean b)
        {
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                if (s.Trim().ToUpper() == tbl.Rows[i][0].ToString().Trim().ToUpper())
                    return i;
            }
            return -1;
        }



        private void SetValueDefault()
        {
            //_GradientStyle = GradientStyles.Default;
            //_SmoothingQuality = SmoothingQualities.None;
            //_mcrBackColor1 = SystemColors.Window;
            //_mcrBackColor2 = SystemColors.Window;
            _mcrBorderColor = Color.Black;

            //_mcrHoverBorder = SystemColors.Window;
            //_mcrHoverColor1 = SystemColors.Window;
            //_mcrHoverColor2 = SystemColors.Window;

            //this.Text = "HVTTTextBox";

            // _mAppearance = new HVTTAppearance(new String[]{"HoverColor1","HoverColor2","HoverBorderColor"});
            this.BackColor = Color.Transparent;
            tb.ForeColor = this.ForeColor;
        }
        private void SetControlStyle()
        {



            if (!_mbAllowEdit && !_mbRequire)
            {
                //SetValueAllowEdit();
                tb.BackColor = _HVTTStyle2008.AllowEditBackColor;
                //bt.BackColor1 = _HVTTStyle2008.AllowEditBackColor;
                _mcrBorderColor = _HVTTStyle2008.AllowEditBorderColor;
            }
            else if (!_mbAllowEdit && _mbRequire)
            {
                tb.BackColor = _HVTTStyle2008.AllowEditBackColor;
                //bt.BackColor1 = _HVTTStyle2008.AllowEditBackColor;
                _mcrBorderColor = _HVTTStyle2008.AllowEditBorderColor;
            }
            else if (_mbAllowEdit && _mbRequire)
            {
                tb.BackColor = _HVTTStyle2008.RequireBackColor;
                //bt.BackColor1 = _HVTTStyle2008.RequireBackColor;
                _mcrBorderColor = _HVTTStyle2008.RequireBorderColor;
                //this.BackColor = _mcrBackColor1;
            }
            else if (_mbAllowEdit && !_mbRequire)
            {
                tb.BackColor = SystemColors.Window;
                //bt.BackColor1 = _HVTTStyle2008.RequireBackColor;
                _mcrBorderColor = Color.Black;
                //this.BackColor = _mcrBackColor1;
            }
            //if (!_mbAllowEditText)
            //{
            //    SetValueAllowText();
            //    return;
            //}
            //if (!_mbAllowEditButton)
            //{
            //    SetValueAllowButton();
            //    return;
            //}

        }

        private void SetValueAllowEdit()
        {

            tb.BackColor = _HVTTStyle2008.AllowEditBackColor;
            //bt.BackColor1 = _HVTTStyle2008.AllowEditBackColor;
            _mcrBorderColor = _HVTTStyle2008.AllowEditBorderColor;
            // this.BackColor = _mcrBackColor1;
        }

        private void SetValueRequire()
        {

            tb.BackColor = _HVTTStyle2008.RequireBackColor;
            //bt.BackColor1 = _HVTTStyle2008.RequireBackColor;
            _mcrBorderColor = _HVTTStyle2008.RequireBorderColor;
            //this.BackColor = _mcrBackColor1;
        }

        //private void SetValueAllowText()
        //{

        //    tb.BackColor = Color.WhiteSmoke;
        //  // bt.BackColor1 = _RecentBackColor;
        //    tb.BorderColor = Color.WhiteSmoke;
        //    //this.BackColor = _mcrBackColor1;
        //}

        //private void SetValueAllowButton()
        //{

        //    //tb.BackColor = Color.WhiteSmoke;
        //    bt.BackColor1 = Color.WhiteSmoke;

        //    //this.BackColor = _mcrBackColor1;
        //}




        //private Boolean Search(String s, Char x)
        //{
        //    Char[] cArray = s.ToCharArray();
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        if (cArray[i].ToString().ToUpper() == x.ToString().ToUpper())
        //            return true;
        //    }
        //    return false;
        //}
        private int CountChar(String s, Char x)
        {
            int iCount = 0;
            for (int i = 0; i < s.Length; i++)
                if (s[i].ToString().ToUpper() == x.ToString().ToUpper())
                    iCount++;
            return iCount;
        }

        #endregion

        #region Property

        //private GradientStyles _GradientStyle;
        //private SmoothingQualities _SmoothingQuality;

        private Color _mcrBorderColor;
        //private Color _mcrBackColor1;
        //private Color _mcrBackColor2;

        private Boolean _mbRequire = false;
        private Object _mobjValue = null;
        private Boolean _mbAllowEdit = true;
        private Boolean _mbAllowEditText = true;
        private Boolean _mbAllowEditButton = true;
        private String _msSelectedValue = "";
        private String _msSelectedKey = "";
        private int _miSelectedIndex = -1;

        private Boolean _bIsChange = false;

        private String _msDescription = "";
        private ObjectItem[] _mItems = null;
        private int _miLivel = -1;

        public int Level
        {
            get
            {
                return _miLivel;
            }
            set
            {
                _miLivel = value;
            }
        }

       
        
        [Browsable(false)]
        public Boolean IsChange
        {
            get
            {
                return _bIsChange;
            }
            set
            {
                _bIsChange = value;
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

        [Description("Get or set Text Of HVTTDownUp"), Category("HVTTDownUp")]
        public override String Text
        {
            get
            {
                return tb.Text;
            }
            set
            {
                tb.Text = value;
                base.Text = value;
                Invalidate();
            }
        }

        [Description("Get or set Value Of HVTTDownUp"), Category("HVTTDownUp")]
        [Browsable(false)]
        public Object Value
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

        public ObjectItem[] Items
        {
            get
            {
                return _mItems;
            }
            set
            {
                _mItems = value;
            }
        }


        [Description("Get or set property allowedit"), Category("HVTTDownUp")]
        public Boolean AllowEdit
        {
            get
            {
                return _mbAllowEdit;
            }
            set
            {
                _mbAllowEdit = value;
                //_mbAllowEditButton = _mbAllowEdit;
                //_mbAllowEditText = _mbAllowEdit;

                //SetControlStyle();
                tb.ReadOnly = !_mbAllowEdit;
                pn.Enabled = _mbAllowEditButton;
            }
        }

        [Description("Get or set property Require"), Category("HVTTDownUp")]
        public Boolean Require
        {
            get
            {
                return _mbRequire;
            }
            set
            {
                _mbRequire = value;
                SetControlStyle();
            }
        }

        

      
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                tb.ForeColor = base.ForeColor;
            }
        }

        [Description("Get or set Backcolor"), Category("Appearance")]
        [Browsable(false)]
        public Color EditBackColor
        {
            get
            {
                return tb.BackColor;
            }
            set
            {
                tb.BackColor = value;
            }
        }

        [Description("Get or set SelectedValue"), Category("Appearance")]
        [Browsable(false)]
        public String SelectedValue
        {
            get
            {
                return _msSelectedValue;
            }
            set
            {
                _msSelectedValue = value;
            }
        }

        [Description("Get or set SelectedKey"), Category("Appearance")]
        [Browsable(false)]
        public String SelectedKey
        {
            get
            {
                return _msSelectedKey;
            }
            set
            {
                try
                {
                    _msSelectedKey = value;
                    if (_mItems != null)
                    {
                        for (int i = 0; i < _mItems.Length; i++)
                            if (_msSelectedKey == _mItems[i].Key)
                            {
                                tb.Text = _mItems[i].Text;
                                _miSelectedIndex = i;
                                iIndex = i;
                            }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        [Description("Get or set SelectedIndex"), Category("Appearance")]
        [Browsable(false)]
        public int SelectedIndex
        {
            get
            {
                return _miSelectedIndex;
            }
            set
            {
                try
                {
                    _miSelectedIndex = value;
                    if (_mItems != null)
                    {
                        if (_miSelectedIndex >= 0)
                        {
                            tb.Text = _mItems[_miSelectedIndex].Text;
                            _msSelectedKey = _mItems[_miSelectedIndex].Key;
                            iIndex = _miSelectedIndex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

      
        [Description("Get or set Description"), Category("HVTTDownUp")]
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

        [Browsable(false)]
        public String SelectedText
        {
            get
            {
                return tb.SelectedText;
            }
            set
            {
                tb.SelectedText = value;
            }
        }

        [Browsable(false)]
        public int SelectionLength
        {
            get
            {
                return tb.SelectionLength;
            }
            set
            {
                tb.SelectionLength = value;
            }
        }
        [Browsable(false)]
        public int SelectionStart
        {
            get
            {
                return tb.SelectionStart;
            }
            set
            {
                tb.SelectionStart = value;
            }
        }
        #endregion

        #region Event

        public new event EventHandler TextChanged;
        public event EventHandler ValueChanged;
        public event EventHandler SelectedIndexChanged;
        public event EventHandler SelectedValueChanged;
        public event EventHandler ButtonUpClick;
        public event EventHandler ButtonDownClick;
        public new event EventHandler Validated;
        public new event CancelEventHandler Validating;
        public new event KeyPressEventHandler KeyPress;
        public new event KeyEventHandler KeyDown;

        //public virtual void OnTextChanged(EventArgs e)
        //{
        //    tb_TextChanged(tb, e);
        //}

        protected override void OnPaint(PaintEventArgs e)
        {
            SetControlStyle();
            Graphics g = e.Graphics;
            Rectangle newRect = new Rectangle(ClientRectangle.X + 1, ClientRectangle.Y + 1,
                 ClientRectangle.Width - 3, ClientRectangle.Height - 4);
            g.DrawRectangle(new Pen(_mcrBorderColor, 1), newRect);
        }

        private void HVTTDownUp_Resize(object sender, EventArgs e)
        {
            this.Height = 26;
            pn.Height = 21;
            tb.Height = 21;
            pn.Location = new Point(this.Width - pn.Width - 2, 2);
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (_mItems != null)
                {
                    if (iIndex > 0)
                    {
                        iIndex--;
                    }
                    if (iIndex >= 0 )
                    {
                        tb.Text = _mItems[iIndex].Text;
                        _msSelectedKey = _mItems[iIndex].Key;
                        _msSelectedValue = tb.Text;
                        _miSelectedIndex = iIndex;
                        if (SelectedIndexChanged != null)
                        {
                            EventArgs e1 = new EventArgs();
                            SelectedIndexChanged(this, e1);
                        }
                        if (SelectedValueChanged != null)
                        {
                            EventArgs e1 = new EventArgs();
                            SelectedValueChanged(this, e1);
                        }
                    }
                   
                   
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (_mItems != null)
                {
                    if (iIndex < _mItems.Length - 1)
                    {
                        iIndex++;
                        
                    }
                    if (iIndex < _mItems.Length)
                    {
                        tb.Text = _mItems[iIndex].Text;
                        _msSelectedKey = _mItems[iIndex].Key;
                        _msSelectedValue = tb.Text;
                        _miSelectedIndex = iIndex;

                        if (SelectedIndexChanged != null)
                        {
                            EventArgs e1 = new EventArgs();
                            SelectedIndexChanged(this, e1);
                        }
                        if (SelectedValueChanged != null)
                        {
                            EventArgs e1 = new EventArgs();
                            SelectedValueChanged(this, e1);
                        }
                    }
                   
                }

            }
     
            if (KeyDown != null)
                KeyDown(sender, e);
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            _mobjValue = tb.Text;
            if (TextChanged != null)
                TextChanged(sender, e);
        }

        private void tb_ValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(sender, e);
        }

        private void tb_Validating(object sender, CancelEventArgs e)
        {
            if (Validating != null)
                Validating(sender, e);
        }

        private void tb_Validated(object sender, EventArgs e)
        {
            if (Validated != null)
                Validated(sender, e);
        }

        private void ptUp_Click(object sender, EventArgs e)
        {
            if (_mItems != null)
            {
                if (iIndex < _mItems.Length - 1)
                {
                    iIndex++;
                   
                }
                if (iIndex < _mItems.Length)
                {
                    tb.Text = _mItems[iIndex].Text;
                    _msSelectedKey = _mItems[iIndex].Key;
                    _msSelectedValue = tb.Text;
                    _miSelectedIndex = iIndex;
                    if (SelectedIndexChanged != null)
                    {
                        EventArgs e1 = new EventArgs();
                        SelectedIndexChanged(this, e1);
                    }
                    if (SelectedValueChanged != null)
                    {
                        EventArgs e1 = new EventArgs();
                        SelectedValueChanged(this, e1);
                    }
                }
                
            }

            if (ButtonUpClick != null)
                ButtonUpClick(sender, e);
        }

        private void ptD_Click(object sender, EventArgs e)
        {
            if (_mItems != null)
            {
                if (iIndex > 0)
                {
                    iIndex--;
                    
                }
                if (iIndex < _mItems.Length)
                {
                    tb.Text = _mItems[iIndex].Text;
                    _msSelectedKey = _mItems[iIndex].Key;
                    _msSelectedValue = tb.Text;
                    _miSelectedIndex = iIndex;
                    if (SelectedIndexChanged != null)
                    {
                        EventArgs e1 = new EventArgs();
                        SelectedIndexChanged(this, e1);
                    }
                    if (SelectedValueChanged != null)
                    {
                        EventArgs e1 = new EventArgs();
                        SelectedValueChanged(this, e1);
                    }
                }
               
            }
            if (ButtonDownClick != null)
                ButtonDownClick(sender, e);

            
        }

        private void ptD_MouseMove(object sender, MouseEventArgs e)
        {
            ptD.Image = Properties.Resources.D4;
        }

        private void ptD_MouseLeave(object sender, EventArgs e)
        {
            ptD.Image = Properties.Resources.D2;
        }

        private void ptD_MouseDown(object sender, MouseEventArgs e)
        {
            ptD.Image = Properties.Resources.D7;
        }

        private void ptU_MouseMove(object sender, MouseEventArgs e)
        {
            ptUp.Image = Properties.Resources.Up4;
        }

        private void ptU_MouseLeave(object sender, EventArgs e)
        {
            ptUp.Image = Properties.Resources.Up2;
        }

        private void ptU_MouseDown(object sender, MouseEventArgs e)
        {
            ptUp.Image = Properties.Resources.Up7;
        }

        #endregion

        #region Enum
        public enum NumberTypes
        {
            None,
            Integer,
            Int64,
            Double,
            HVTTNumber
        }
        #endregion

        #region Classes
        public class ObjectItem
        {
            public ObjectItem()
            {
                _msKey = "";
                _msText = "";
            }

            private String _msKey = "";
            private String _msText = "";

            public String Key
            {
                get
                {
                    return _msKey;
                }
                set
                {
                    _msKey = value;
                }
            }
            public String Text
            {
                get
                {
                    return _msText;
                }
                set
                {
                    _msText = value;
                }
            }
        }
        #endregion

        

    }
}
