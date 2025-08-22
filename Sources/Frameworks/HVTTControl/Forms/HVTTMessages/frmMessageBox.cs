using HVTT.UI.Window.Forms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms
{
    partial class frmMessageBox : HVTT.UI.Window.Forms.Office2007Form
    {
        public String Title = "";
        public String Title1 = "";
        public String Msg = "";
        //public clsLanguageStruct Language = null;
        public HVTTMessages.HVTTMessageTypes MessageType = HVTTMessages.HVTTMessageTypes.Success;

        public frmMessageBox()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //if(Language!=null)
                //{
                //    btnCancel.Text = Language.GetLanguage("Thoat");
                //    btnOk.Text = Language.GetLanguage("DongY");
                //}

                this.Text = "HVTT: " + Title;
                if(Title1!=null && Title1.Trim()!="")
                {
                    lblTitle1.Text = Title1;
                    lblTitle1.Visible = true;
                }
                else
                {
                    lblTitle1.Text = "";
                    lblTitle1.Visible = false;
                }

                txtMessage.Text = Msg;

                switch(MessageType)
                {
                    case HVTTMessages.HVTTMessageTypes.Error:
                        pictureBox1.Image = global::HVTT.UI.Window.Forms.Properties.Resources.MsgError;
                        txtMessage.ForeColor = Color.Red;
                        break;
                    case HVTTMessages.HVTTMessageTypes.Question:
                        pictureBox1.Image = global::HVTT.UI.Window.Forms.Properties.Resources.MsgQuestion;
                        break;
                    case HVTTMessages.HVTTMessageTypes.Success:
                        pictureBox1.Image = global::HVTT.UI.Window.Forms.Properties.Resources.MsgSuccess;
                        break;
                    case HVTTMessages.HVTTMessageTypes.Warning:
                        pictureBox1.Image = global::HVTT.UI.Window.Forms.Properties.Resources.MsgWarning;
                        txtMessage.ForeColor = Color.OrangeRed;
                        break;
                    case HVTTMessages.HVTTMessageTypes.Info:
                        pictureBox1.Image = global::HVTT.UI.Window.Forms.Properties.Resources.MsgInfo;
                        break;
                }



                if(MessageType!= HVTTMessages.HVTTMessageTypes.Question)
                {
                    btnOk.Visible = false;
                    btnCancel.Focus();
                }
                else
                {
                    btnOk.Visible = true;
                    btnOk.Focus();
                }

                this.Activate();
            }
            finally
            {
                this.Activate();
                this.Cursor = Cursors.Default;
            }
            base.OnLoad(e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if(keyData== Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
