using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms.Controls.HVTTImageViewer
{
    partial class frmSplitConfig : HVTT.UI.Window.Forms.Office2007RibbonForm
    {
        public String OldImagePath = "";
        public String NewImagePath = "";
        public Bitmap NewImage;
        public Image Image;

        public frmSplitConfig()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                base.OnLoad(e);
                cmdSave.Image = Properties.Resources.save;
                cmdSave.ImageFixedSize = new Size(30, 30);
                cmdSave.ButtonStyle = HVTTButtonStyle.ImageAndText;

                //imageViewer1.ImagePath = NewImagePath;
                imageViewer1.Image = NewImage;
                imageViewer1.ShowPreview = false;

            }
            catch (Exception ex)
            {
                HVTT.UI.Window.Forms.HVTTMessages.Show(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        
           

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Image.Save(OldImagePath, ImageFormat.Png);
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                HVTT.UI.Window.Forms.HVTTMessages.Show(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void imageViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
