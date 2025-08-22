using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;

namespace HVTT.UI.Window.Forms.Controls
{
    public partial class HVTTRichTextAdvanced : UserControl
    {
        public HVTTRichTextAdvanced()
        {
            InitializeComponent();

            this.mnuMainToolbar.Checked = true;
            this.mnuFormatting.Checked = true;

            System.Drawing.Text.InstalledFontCollection col = new System.Drawing.Text.InstalledFontCollection();

            this.cmbFontName.Items.Clear();

            foreach (FontFamily ff in col.Families)
            {
                this.cmbFontName.Items.Add(ff.Name);
            }

            col.Dispose();

            this.hvttRichTextBox1.Select(0, 0);
            this.hvttRichTextBox1.SelectionIndent = 0;
            this.hvttRichTextBox1.SelectionRightIndent = 0;
            this.hvttRichTextBox1.SelectionHangingIndent = 0;
            this.Toolbox_Main.Visible = false;
            this.TextEditorMenu.Visible = false;
            Toolbox_Formatting.Visible = true;
        }

        string _path = "";
        int checkPrint = 0;


        public event EventHandler HasFocus;
        protected override void OnGotFocus(EventArgs e)
        {
            if (HasFocus != null)
                HasFocus(this, e);
            base.OnGotFocus(e);

        }


       

        public HVTTRichTextBox RichText
        {
            get
            {
                return hvttRichTextBox1;
            }
        }
        public int Level
        {
            get
            {
                return hvttRichTextBox1.Level;
            }
            set
            {
                hvttRichTextBox1.Level = value;
            }
        }
        public String Rtf
        {
            get
            {
                return hvttRichTextBox1.Rtf;
            }
            set
            {
                hvttRichTextBox1.Clear();
                hvttRichTextBox1.Rtf = value;
                hvttRichTextBox1.Refresh();
               // hvttRichTextBox1.UpdateObjects();
                hvttRichTextBox1.Update();
                hvttRichTextBox1.UpdateObjects();
                
            }
        }
       
        public Boolean VisibleMenuBar
        {
            get
            {
                return TextEditorMenu.Visible;
            }
            set
            {
                TextEditorMenu.Visible = value;
            }
        }
        public Boolean VisibleMainTool
        {
            get
            {
                return Toolbox_Main.Visible;
            }
            set
            {
                Toolbox_Main.Visible = value;
            }
        }
        public Boolean VisibleFormatingTool
        {
            get
            {
                return Toolbox_Formatting.Visible;
            }
            set
            {
                Toolbox_Formatting.Visible = value;
            }
        }

        private string GetFilePath()
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Multiselect = false;
            o.RestoreDirectory = true;
            o.ShowReadOnly = false;
            o.ReadOnlyChecked = false;
            o.Filter = "RTF (*.rtf)|*.rtf|TXT (*.txt)|*.txt";
            if (o.ShowDialog(this) == DialogResult.OK)
            {
                return o.FileName;
            }
            else
            {
                return "";
            }
        }
        private string SetFilePath()
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "RTF (*.rtf)|*.rtf|TXT (*.txt)|*.txt";
            if (s.ShowDialog(this) == DialogResult.OK)
            {
                return s.FileName;
            }
            else
            {
                return "";
            }
        }
        private Color GetColor(Color initColor)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.Color = initColor;
                cd.AllowFullOpen = true;
                cd.AnyColor = true;
                cd.FullOpen = true;
                cd.ShowHelp = false;
                cd.SolidColorOnly = false;
                if (cd.ShowDialog() == DialogResult.OK)
                    return cd.Color;
                else
                    return initColor;
            }
        }
        private Font GetFont(Font initFont)
        {
            using (FontDialog fd = new FontDialog())
            {
                fd.Font = initFont;
                fd.AllowSimulations = true;
                fd.AllowVectorFonts = true;
                fd.AllowVerticalFonts = true;
                fd.FontMustExist = true;
                fd.ShowHelp = false;
                fd.ShowEffects = true;
                fd.ShowColor = false;
                fd.ShowApply = false;
                fd.FixedPitchOnly = false;

                if (fd.ShowDialog() == DialogResult.OK)
                    return fd.Font;
                else
                    return initFont;
            }
        }
        private string GetImagePath()
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Multiselect = false;
            o.ShowReadOnly = false;
            o.RestoreDirectory = true;
            o.ReadOnlyChecked = false;
            o.Filter = "Images|*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.tif;*.tiff,*.wmf;*.emf";
            if (o.ShowDialog(this) == DialogResult.OK)
            {
                return o.FileName;
            }
            else
            {
                return "";
            }
        }

        public void Clear()
        {
            _path = "";
            this.hvttRichTextBox1.Clear();

            //set indents to default positions
            this.hvttRichTextBox1.Select(0, 0);
           
            this.hvttRichTextBox1.SelectionIndent = 0;
            this.hvttRichTextBox1.SelectionRightIndent = 0;
            this.hvttRichTextBox1.SelectionHangingIndent = 0;

            //clear tabs on the ruler
            this.hvttRichTextBox1.SelectionTabs = null;

            HVTTRichTextBox.ParaListStyle pls = new HVTTRichTextBox.ParaListStyle();

            pls.Type =  HVTTRichTextBox.ParaListStyle.ListType.None;
            pls.Style = HVTTRichTextBox.ParaListStyle.ListStyle.NumberAndParenthesis;

            this.hvttRichTextBox1.SelectionListType = pls;
        }
        private void Open()
        {
            try
            {
                string file = GetFilePath();

                if (file != "")
                {
                    Clear();
                    try
                    {
                        this.hvttRichTextBox1.Rtf = System.IO.File.ReadAllText(file, System.Text.Encoding.Default);
                    }
                    catch (Exception) //error occured, that means we loaded invalid RTF, so load as plain text
                    {
                        this.hvttRichTextBox1.Text = System.IO.File.ReadAllText(file, System.Text.Encoding.Default);
                    }
                    _path = file;
                }
                file = null;
            }
            catch (Exception)
            {
                Clear();
            }
        }
        private void Save(bool SaveAs)
        {
            try
            {
                if (SaveAs == true)
                {
                    string file = SetFilePath();

                    if (file != "")
                    {
                        this.hvttRichTextBox1.SaveFile(file, RichTextBoxStreamType.RichText);
                        _path = file;
                        file = null;
                    }
                }
                else
                {
                    if (_path == "")
                    {
                        string file = SetFilePath();

                        if (file != "")
                        {
                            this.hvttRichTextBox1.SaveFile(file, RichTextBoxStreamType.RichText);
                            _path = file;
                            file = null;
                        }
                    }
                    else
                    {
                        this.hvttRichTextBox1.SaveFile(_path, RichTextBoxStreamType.RichText);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

       

        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            this.hvttRichTextBox1.Cut();
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            this.hvttRichTextBox1.Cut();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            this.hvttRichTextBox1.Copy();
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            this.hvttRichTextBox1.Paste();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.hvttRichTextBox1.Copy();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            this.hvttRichTextBox1.Paste();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            this.hvttRichTextBox1.Undo();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            this.hvttRichTextBox1.Redo();
        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {
            this.hvttRichTextBox1.Undo();
        }

        private void mnuRedo_Click(object sender, EventArgs e)
        {
            this.hvttRichTextBox1.Redo();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void hvttRichTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                #region Alignment
                if (hvttRichTextBox1.SelectionAlignment ==  HVTTRichTextBox.RichTextAlign.Left)
                {
                    this.btnAlignLeft.Checked = true;
                    this.btnAlignCenter.Checked = false;
                    this.btnAlignRight.Checked = false;
                    this.btnJustify.Checked = false;
                }
                else if (hvttRichTextBox1.SelectionAlignment == HVTTRichTextBox.RichTextAlign.Center)
                {
                    this.btnAlignLeft.Checked = false;
                    this.btnAlignCenter.Checked = true;
                    this.btnAlignRight.Checked = false;
                    this.btnJustify.Checked = false;
                }
                else if (hvttRichTextBox1.SelectionAlignment == HVTTRichTextBox.RichTextAlign.Right)
                {
                    this.btnAlignLeft.Checked = false;
                    this.btnAlignCenter.Checked = false;
                    this.btnAlignRight.Checked = true;
                    this.btnJustify.Checked = false;
                }
                else if (hvttRichTextBox1.SelectionAlignment == HVTTRichTextBox.RichTextAlign.Justify)
                {
                    this.btnAlignLeft.Checked = false;
                    this.btnAlignRight.Checked = false;
                    this.btnAlignCenter.Checked = false;
                    this.btnJustify.Checked = true;
                }
                else
                {
                    this.btnAlignLeft.Checked = true;
                    this.btnAlignCenter.Checked = false;
                    this.btnAlignRight.Checked = false;
                }

                #endregion

                #region Tab positions
                
                #endregion

                #region Font
                try
                {
                    this.cmbFontSize.Text = Convert.ToInt32(this.hvttRichTextBox1.SelectionFont2.Size).ToString();
                }
                catch
                {
                    this.cmbFontSize.Text = "";
                }

                try
                {
                    this.cmbFontName.Text = this.hvttRichTextBox1.SelectionFont2.Name;
                }
                catch
                {
                    this.cmbFontName.Text = "";
                }

                if (this.cmbFontName.Text != "")
                {
                    FontFamily ff = new FontFamily(this.cmbFontName.Text);
                    if (ff.IsStyleAvailable(FontStyle.Bold) == true)
                    {
                        this.btnBold.Enabled = true;
                        this.btnBold.Checked = this.hvttRichTextBox1.SelectionCharStyle.Bold;
                    }
                    else
                    {
                        this.btnBold.Enabled = false;
                        this.btnBold.Checked = false;
                    }

                    if (ff.IsStyleAvailable(FontStyle.Italic) == true)
                    {
                        this.btnItalic.Enabled = true;
                        this.btnItalic.Checked = this.hvttRichTextBox1.SelectionCharStyle.Italic;
                    }
                    else
                    {
                        this.btnItalic.Enabled = false;
                        this.btnItalic.Checked = false;
                    }

                    if (ff.IsStyleAvailable(FontStyle.Underline) == true)
                    {
                        this.btnUnderline.Enabled = true;
                        this.btnUnderline.Checked = this.hvttRichTextBox1.SelectionCharStyle.Underline;
                    }
                    else
                    {
                        this.btnUnderline.Enabled = false;
                        this.btnUnderline.Checked = false;
                    }

                    if (ff.IsStyleAvailable(FontStyle.Strikeout) == true)
                    {
                        this.btnStrikeThrough.Enabled = true;
                        this.btnStrikeThrough.Checked = this.hvttRichTextBox1.SelectionCharStyle.Strikeout;
                    }
                    else
                    {
                        this.btnStrikeThrough.Enabled = false;
                        this.btnStrikeThrough.Checked = false;
                    }

                    ff.Dispose();
                }
                else
                {
                    this.btnBold.Checked = false;
                    this.btnItalic.Checked = false;
                    this.btnUnderline.Checked = false;
                    this.btnStrikeThrough.Checked = false;
                }
                #endregion

                //if (this.hvttRichTextBox1.SelectionLength < this.hvttRichTextBox1.TextLength - 1)
                //{
                //    this.Ruler.LeftIndent = (int)(this.hvttRichTextBox1.SelectionIndent / this.Ruler.DotsPerMillimeter); //convert pixels to millimeter

                //    this.Ruler.LeftHangingIndent = (int)((float)this.hvttRichTextBox1.SelectionHangingIndent / this.Ruler.DotsPerMillimeter) + this.Ruler.LeftIndent; //convert pixels to millimeters

                //    this.Ruler.RightIndent = (int)(this.hvttRichTextBox1.SelectionRightIndent / this.Ruler.DotsPerMillimeter); //convert pixels to millimeters                
                //}

                switch (this.hvttRichTextBox1.SelectionListType.Type)
                {
                    case HVTTRichTextBox.ParaListStyle.ListType.None:
                        this.btnNumberedList.Checked = false;
                        this.btnBulletedList.Checked = false;
                        break;
                    case HVTTRichTextBox.ParaListStyle.ListType.SmallLetters:
                        this.btnNumberedList.Checked = false;
                        this.btnBulletedList.Checked = false;
                        break;
                    case HVTTRichTextBox.ParaListStyle.ListType.CapitalLetters:
                        this.btnNumberedList.Checked = false;
                        this.btnBulletedList.Checked = false;
                        break;
                    case HVTTRichTextBox.ParaListStyle.ListType.SmallRoman:
                        this.btnNumberedList.Checked = false;
                        this.btnBulletedList.Checked = false;
                        break;
                    case HVTTRichTextBox.ParaListStyle.ListType.CapitalRoman:
                        this.btnNumberedList.Checked = false;
                        this.btnBulletedList.Checked = false;
                        break;
                    case HVTTRichTextBox.ParaListStyle.ListType.Bullet:
                        this.btnNumberedList.Checked = false;
                        this.btnBulletedList.Checked = true;
                        break;
                    case HVTTRichTextBox.ParaListStyle.ListType.Numbers:
                        this.btnNumberedList.Checked = true;
                        this.btnBulletedList.Checked = false;
                        break;
                    case HVTTRichTextBox.ParaListStyle.ListType.CharBullet:
                        this.btnNumberedList.Checked = true;
                        this.btnBulletedList.Checked = false;
                        break;
                    default:
                        break;
                }

                this.hvttRichTextBox1.UpdateObjects();                
            }
            catch (Exception)
            {
            }
        }

        private void AdvancedhvttRichTextBox1_Load(object sender, EventArgs e)
        {
            //code below will cause refreshing formatting by adding and removing (changing) text
            this.hvttRichTextBox1.Select(0, 0);
            this.hvttRichTextBox1.AppendText("some text");
            this.hvttRichTextBox1.Select(0, 0);
            this.hvttRichTextBox1.Clear();
            this.hvttRichTextBox1.SetLayoutType(HVTTRichTextBox.LayoutModes.WYSIWYG);
            Toolbox_Formatting.Visible = true;
        }

        private void cmbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.cmbFontSize.Focused) return;
                this.hvttRichTextBox1.SelectionFont2 = new Font(this.cmbFontName.Text, Convert.ToInt32(this.cmbFontSize.Text), this.hvttRichTextBox1.SelectionFont.Style);
            }
            catch (Exception)
            {

            }
        }

        private void cmbFontSize_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.hvttRichTextBox1.SelectionFont2 = new Font(this.cmbFontName.Text, Convert.ToSingle(this.cmbFontSize.Text));
                    this.hvttRichTextBox1.Focus();
                }
                catch (Exception)
                {
                }
            }
        }

        #region Old style formatting

        private FontStyle SwitchBold()
        {
            FontStyle fs = new FontStyle();

            fs = FontStyle.Regular;

            if (this.hvttRichTextBox1.SelectionFont.Italic == true)
            {
                fs = FontStyle.Italic;
            }

            if (this.hvttRichTextBox1.SelectionFont.Underline == true)
            {
                fs = fs | FontStyle.Underline;
            }

            if (this.hvttRichTextBox1.SelectionFont.Strikeout == true)
            {
                fs = fs | FontStyle.Strikeout;
            }

            if (this.hvttRichTextBox1.SelectionFont.Bold == false)
            {
                fs = fs | FontStyle.Bold;
            }

            return fs;
        }
        private FontStyle SwitchItalic()
        {
            FontStyle fs = new FontStyle();

            fs = FontStyle.Regular;

            if (this.hvttRichTextBox1.SelectionFont.Underline == true)
            {
                fs = fs | FontStyle.Underline;
            }

            if (this.hvttRichTextBox1.SelectionFont.Strikeout == true)
            {
                fs = fs | FontStyle.Strikeout;
            }

            if (this.hvttRichTextBox1.SelectionFont.Bold == true)
            {
                fs = fs | FontStyle.Bold;
            }

            if (this.hvttRichTextBox1.SelectionFont.Italic == false)
            {
                fs = fs | FontStyle.Italic;
            }

            return fs;
        }
        private FontStyle SwitchUnderline()
        {
            FontStyle fs = new FontStyle();

            fs = FontStyle.Regular;

            if (this.hvttRichTextBox1.SelectionFont.Strikeout == true)
            {
                fs = fs | FontStyle.Strikeout;
            }

            if (this.hvttRichTextBox1.SelectionFont.Bold == true)
            {
                fs = fs | FontStyle.Bold;
            }

            if (this.hvttRichTextBox1.SelectionFont.Italic == true)
            {
                fs = fs | FontStyle.Italic;
            }

            if (this.hvttRichTextBox1.SelectionFont.Underline == false)
            {
                fs = fs | FontStyle.Underline;
            }

            return fs;
        }
        private FontStyle SwitchStrikeout()
        {
            FontStyle fs = new FontStyle();

            fs = FontStyle.Regular;

            if (this.hvttRichTextBox1.SelectionFont.Bold == true)
            {
                fs = fs | FontStyle.Bold;
            }

            if (this.hvttRichTextBox1.SelectionFont.Italic == true)
            {
                fs = fs | FontStyle.Italic;
            }

            if (this.hvttRichTextBox1.SelectionFont.Underline == true)
            {
                fs = fs | FontStyle.Underline;
            }

            if (this.hvttRichTextBox1.SelectionFont.Strikeout == false)
            {
                fs = fs | FontStyle.Strikeout;
            }

            return fs;
        }

        #endregion

        private Boolean CheckBold()
        {
            if (hvttRichTextBox1.SelectedRtf.Contains(@"\b\"))
            {
                return true;
            }
            return false;
        }
        private Boolean CheckItalic()
        {
            if (hvttRichTextBox1.SelectedRtf.Contains(@"\i\"))
            {
                return true;
            }
            return false;
        }
        private Boolean CheckUnderline()
        {
            if (hvttRichTextBox1.SelectedRtf.Contains(@"\ul\"))
            {
                return true;
            }
            return false;
        }
        private void Rich_Bold()
        {
           // if (this.hvttRichTextBox1.SelectionCharStyle.Bold == true)
           if(CheckBold())
            {
                this.btnBold.Checked = false;
                HVTTRichTextBox.CharStyle cs = this.hvttRichTextBox1.SelectionCharStyle;
                cs.Bold = false;
                this.hvttRichTextBox1.SelectionCharStyle = cs;
                cs = null;
            }
            else
            {
                this.btnBold.Checked = true;
                HVTTRichTextBox.CharStyle cs = this.hvttRichTextBox1.SelectionCharStyle;
                cs.Bold = true;
                this.hvttRichTextBox1.SelectionCharStyle = cs;
                cs = null;
            }
        }
        private void btnBold_Click(object sender, EventArgs e)
        {
            Rich_Bold();
        }

        private void btnAlignLeft_Click(object sender, EventArgs e)
        {
            this.hvttRichTextBox1.SelectionAlignment = HVTTRichTextBox.RichTextAlign.Left;
            this.btnAlignLeft.Checked = true;
            this.btnAlignRight.Checked = false;
            this.btnAlignCenter.Checked = false;
            this.btnJustify.Checked = false;
        }

        private void btnAlignCenter_Click(object sender, EventArgs e)
        {
            this.hvttRichTextBox1.SelectionAlignment = HVTTRichTextBox.RichTextAlign.Center;
            this.btnAlignLeft.Checked = false;
            this.btnAlignRight.Checked = false;
            this.btnAlignCenter.Checked = true;
            this.btnJustify.Checked = false;
        }

        private void btnAlignRight_Click(object sender, EventArgs e)
        {
            this.hvttRichTextBox1.SelectionAlignment = HVTTRichTextBox.RichTextAlign.Right;
            this.btnAlignLeft.Checked = false;
            this.btnAlignRight.Checked = true;
            this.btnAlignCenter.Checked = false;
            this.btnJustify.Checked = false;
        }

        private void Ruler_LeftIndentChanging(int NewValue)
        {
            try
            {
                //this.hvttRichTextBox1.SelectionIndent = (int)(this.Ruler.LeftIndent * this.Ruler.DotsPerMillimeter);
                //this.hvttRichTextBox1.SelectionHangingIndent = (int)(this.Ruler.LeftHangingIndent * this.Ruler.DotsPerMillimeter) - (int)(this.Ruler.LeftIndent * this.Ruler.DotsPerMillimeter);
            }
            catch (Exception)
            {
            }
        }

        private void Ruler_LeftHangingIndentChanging(int NewValue)
        {
            try
            {
                //this.hvttRichTextBox1.SelectionHangingIndent = (int)(this.Ruler.LeftHangingIndent * this.Ruler.DotsPerMillimeter) - (int)(this.Ruler.LeftIndent * this.Ruler.DotsPerMillimeter);
            }
            catch (Exception)
            {
            }
        }

        private void Ruler_RightIndentChanging(int NewValue)
        {
            try
            {
                //this.hvttRichTextBox1.SelectionRightIndent = (int)(this.Ruler.RightIndent * this.Ruler.DotsPerMillimeter);
            }
            catch (Exception)
            {
            }
        }

        private void cmbFontName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.cmbFontName.Focused) return;
                this.hvttRichTextBox1.SelectionFont2 = new Font(this.cmbFontName.Text, Convert.ToInt32(this.cmbFontSize.Text));
            }
            catch (Exception)
            {
            }
        }

        private void cmbFontName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.hvttRichTextBox1.SelectionFont2 = new Font(this.cmbFontName.Text, Convert.ToInt32(this.cmbFontSize.Text));
                    this.hvttRichTextBox1.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void mnuRuler_Click(object sender, EventArgs e)
        {

        }


        private void mnuMainToolbar_Click(object sender, EventArgs e)
        {
            if (this.Toolbox_Main.Visible == true)
            {
                this.Toolbox_Main.Visible = false;
                this.mnuMainToolbar.Checked = false;
            }
            else
            {
                this.Toolbox_Main.Visible = true;
                this.mnuMainToolbar.Checked = true;
            }
        }

        private void mnuFormatting_Click(object sender, EventArgs e)
        {
            if (this.Toolbox_Formatting.Visible == true)
            {
                this.Toolbox_Formatting.Visible = false;
                this.mnuFormatting.Checked = false;
            }
            else
            {
                this.Toolbox_Formatting.Visible = true;
                this.mnuFormatting.Checked = true;
            }
        }

        private void mnuFont_Click(object sender, EventArgs e)
        {
            try
            {
                this.hvttRichTextBox1.SelectionFont2 = GetFont(this.hvttRichTextBox1.SelectionFont);
            }
            catch (Exception)
            {
            }
        }

        private void mnuTextColor_Click(object sender, EventArgs e)
        {
            try
            {
                this.hvttRichTextBox1.SelectionColor2 = GetColor(this.hvttRichTextBox1.SelectionColor);
            }
            catch (Exception)
            {
            }
        }

        private void mnuHighlightColor_Click(object sender, EventArgs e)
        {
            try
            {
                this.hvttRichTextBox1.SelectionBackColor2 = GetColor(this.hvttRichTextBox1.SelectionBackColor);
            }
            catch (Exception)
            {
            }
        }

       
    

        private void cmbFontSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
                e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
                e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
                e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 ||
                e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4 ||
                e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 ||
                e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.Back ||
                e.KeyCode == Keys.Enter || e.KeyCode == Keys.Delete)
            {
                //allow key
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }

        private void mnuInsertPicture_Click(object sender, EventArgs e)
        {
            string _imgPath = GetImagePath();
            if (_imgPath == "")
                return;
            this.hvttRichTextBox1.InsertImage(_imgPath);
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This control was created by Krassovskikh Aleksei. You can freely use it in your application, but if it possible, mention about creator of that control (this is not required but desired :)  )");
        }

        private void prtDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            checkPrint = this.hvttRichTextBox1.Print(checkPrint, this.hvttRichTextBox1.TextLength, e);

            if (checkPrint < this.hvttRichTextBox1.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void prtDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            checkPrint = 0;
        }

        private void mnuPageSettings_Click(object sender, EventArgs e)
        {
            this.PageSettings.ShowDialog(this);
        }

        private void mnuPrintPreview_Click(object sender, EventArgs e)
        {
            this.DocPreview.ShowDialog(this);
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            this.DocPreview.ShowDialog(this);
        }


        delegate void printDialogHelperDelegate(); // Helper delegate for PrintDialog bug

        /// <summary>
        /// Helper thread which sole purpose is to invoke PrintDialogHelper function
        /// to circumvent the PrintDialog focus problem reported on
        /// https://connect.microsoft.com/VisualStudio/feedback/ViewFeedback.aspx?FeedbackID=234179
        /// </summary>
        private void PrintHelpThread()
        {
            if (InvokeRequired)
            {
                printDialogHelperDelegate d = new printDialogHelperDelegate(PrintHelpThread);
                Invoke(d);
            }
            else
            {
                PrintDialogHelper();
            }
        }

        /// <summary>
        /// Shows the print dialog (invoked from a different thread to get the focus to the dialog)
        /// </summary>
        private void PrintDialogHelper()
        {
            if (PrintWnd.ShowDialog(this) == DialogResult.OK)
            {
                this.prtDoc.Print();
            }
        }
        
        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void mnuPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void mnuSave_Click(object sender, EventArgs e)
        {

        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {

        }

        private void mnuInsertDateTime_DropDownOpening(object sender, EventArgs e)
        {

        }

        private void cmbDateTimeFormats_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCustom_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtCustom_Leave(object sender, EventArgs e)
        {

        }

        private void txtCustom_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void txtCustom_Enter(object sender, EventArgs e)
        {

        }

        private void Rich_Italic()
        {
            //if (this.hvttRichTextBox1.SelectionCharStyle.Italic == true)
            if(CheckItalic())
            {
                this.btnItalic.Checked = false;
                HVTTRichTextBox.CharStyle cs = this.hvttRichTextBox1.SelectionCharStyle;
                cs.Italic = false;
                this.hvttRichTextBox1.SelectionCharStyle = cs;
                cs = null;
            }
            else
            {
                this.btnItalic.Checked = true;
                HVTTRichTextBox.CharStyle cs = this.hvttRichTextBox1.SelectionCharStyle;
                cs.Italic = true;
                this.hvttRichTextBox1.SelectionCharStyle = cs;
                cs = null;
            }
        }
        private void btnItalic_Click(object sender, EventArgs e)
        {
            try
            {
                Rich_Italic();
            }
            catch (Exception)
            {
            }
        }

        private void Rich_UnderLine()
        {
            try
            {
               // if (this.hvttRichTextBox1.SelectionCharStyle.Underline == true)
               if(CheckUnderline())
                {
                    this.btnUnderline.Checked = false;
                    HVTTRichTextBox.CharStyle cs = this.hvttRichTextBox1.SelectionCharStyle;
                    cs.Underline = false;
                    this.hvttRichTextBox1.SelectionCharStyle = cs;
                    cs = null;
                }
                else
                {
                    this.btnUnderline.Checked = true;
                    HVTTRichTextBox.CharStyle cs = this.hvttRichTextBox1.SelectionCharStyle;
                    cs.Underline = true;
                    this.hvttRichTextBox1.SelectionCharStyle = cs;
                    cs = null;
                }
            }
            catch (Exception)
            {
            }
        }
        private void btnUnderline_Click(object sender, EventArgs e)
        {
            Rich_UnderLine();
        }

        private void btnStrikeThrough_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.hvttRichTextBox1.SelectionCharStyle.Strikeout == true)
                {
                    this.btnStrikeThrough.Checked = false;
                    HVTTRichTextBox.CharStyle cs = this.hvttRichTextBox1.SelectionCharStyle;
                    cs.Strikeout = false;
                    this.hvttRichTextBox1.SelectionCharStyle = cs;
                    cs = null;
                }
                else
                {
                    this.btnStrikeThrough.Checked = true;
                    HVTTRichTextBox.CharStyle cs = this.hvttRichTextBox1.SelectionCharStyle;
                    cs.Strikeout = true;
                    this.hvttRichTextBox1.SelectionCharStyle = cs;
                    cs = null;
                }
            }
            catch (Exception)
            {
            }
        }

        private void mnuFind_Click(object sender, EventArgs e)
        {

        }

        private void hvttRichTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B && e.Control == true)
            {
                //this.btnBold.PerformClick();
            }

            if (e.Control == true && e.KeyCode == Keys.I)
            {
                //this.btnItalic.PerformClick();
                e.SuppressKeyPress = true;
            }

            if (e.Control == true && e.KeyCode == Keys.U)
            {
                //this.btnUnderline.PerformClick();
            }
        }

        private void btnJustify_Click(object sender, EventArgs e)
        {
            this.hvttRichTextBox1.SelectionAlignment = HVTTRichTextBox.RichTextAlign.Justify;
            this.btnAlignLeft.Checked = false;
            this.btnAlignRight.Checked = false;
            this.btnAlignCenter.Checked = false;
            this.btnJustify.Checked = true;
        }

        private void Ruler_BothLeftIndentsChanged(int LeftIndent, int HangIndent)
        {
            //this.hvttRichTextBox1.SelectionIndent = (int)(this.Ruler.LeftIndent * this.Ruler.DotsPerMillimeter);
            //this.hvttRichTextBox1.SelectionHangingIndent = (int)(this.Ruler.LeftHangingIndent * this.Ruler.DotsPerMillimeter) - (int)(this.Ruler.LeftIndent * this.Ruler.DotsPerMillimeter);            
        }

        private void hvttRichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.LinkText);
            }
            catch (Exception)
            {
            }
        }

        private void btnNumberedList_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnNumberedList.Checked)
                {
                    this.btnBulletedList.Checked = false;
                    this.btnNumberedList.Checked = false;
                    HVTTRichTextBox.ParaListStyle pls = new HVTTRichTextBox.ParaListStyle();

                    pls.Type = HVTTRichTextBox.ParaListStyle.ListType.None;
                    pls.Style = HVTTRichTextBox.ParaListStyle.ListStyle.NumberAndParenthesis;

                    this.hvttRichTextBox1.SelectionListType = pls;
                }
                else
                {
                    this.btnBulletedList.Checked = false;
                    this.btnNumberedList.Checked = true;
                    HVTTRichTextBox.ParaListStyle pls = new HVTTRichTextBox.ParaListStyle();

                    pls.Type = HVTTRichTextBox.ParaListStyle.ListType.Numbers;
                    pls.Style = HVTTRichTextBox.ParaListStyle.ListStyle.NumberInPar;

                    this.hvttRichTextBox1.SelectionListType = pls;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnBulletedList_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnBulletedList.Checked)
                {
                    this.btnBulletedList.Checked = false;
                    this.btnNumberedList.Checked = false;
                    HVTTRichTextBox.ParaListStyle pls = new HVTTRichTextBox.ParaListStyle();

                    pls.Type = HVTTRichTextBox.ParaListStyle.ListType.None;
                    pls.Style = HVTTRichTextBox.ParaListStyle.ListStyle.NumberAndParenthesis;

                    this.hvttRichTextBox1.SelectionListType = pls;
                }
                else
                {
                    this.btnBulletedList.Checked = true;
                    this.btnNumberedList.Checked = false;
                    HVTTRichTextBox.ParaListStyle pls = new HVTTRichTextBox.ParaListStyle();

                    pls.Type = HVTTRichTextBox.ParaListStyle.ListType.Bullet;
                    pls.Style = HVTTRichTextBox.ParaListStyle.ListStyle.NumberAndParenthesis;

                    this.hvttRichTextBox1.SelectionListType = pls;
                }
            }
            catch (Exception)
            {
            }
        }

        private void hvttRichTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.hvttRichTextBox1.SelectionType == RichTextBoxSelectionTypes.Object ||
                    this.hvttRichTextBox1.SelectionType == RichTextBoxSelectionTypes.MultiObject)
                {
                    MessageBox.Show(Convert.ToString(this.hvttRichTextBox1.SelectedObject().sizel.Width));
                }
            }
        }

        private void hvttRichTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void mnuULWave_Click(object sender, EventArgs e)
        {

        }

        private void mnuULineSolid_Click(object sender, EventArgs e)
        {

        }

        private void hvttRichTextBox1Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void clpFontColor_SelectedColorChanged(object sender, EventArgs e)
        {
            try
            {
                this.hvttRichTextBox1.SelectionColor2 = clpFontColor.SelectedColor;//GetColor(this.hvttRichTextBox1.SelectionColor);
            }
            catch (Exception)
            {
            }
        }

        private void clpBackground_SelectedColorChanged(object sender, EventArgs e)
        {
            try
            {
                this.hvttRichTextBox1.SelectionBackColor2 = clpBackground.SelectedColor;
            }
            catch (Exception)
            {
            }
        }

        private void hvttRichTextBox1_HasFocus(object sender, EventArgs e)
        {
            if (HasFocus != null)
                HasFocus(this, e);
        }

        private Boolean IsUpperCase(String str)
        {
            foreach(var c in str)
            {
                if (c.ToString().Trim() != "" && Char.IsLower(c)
                    && Char.IsLetter(c))
                    return false;
            }
            return true;
        }
        private Boolean IsFirstUpperCase(String str)
        {
            String[] M = str.Trim().Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if(M!=null && M.Length>0)
            {
                int i = 0;
                while(i<M.Length)
                {
                    foreach(var c in M[i])
                    {
                        if (Char.IsLetter(c) && Char.IsUpper(c))
                            return true;
                    }
                    i++;
                }
            }
            return false;
        }

        private void Rich_UpperCase()
        {
            if (hvttRichTextBox1.SelectedText.Trim() == "")
                return;

            int iSelectionStart = hvttRichTextBox1.SelectionStart;
            int iSelectionEnd = hvttRichTextBox1.SelectedText.Length;
            if (IsUpperCase(hvttRichTextBox1.SelectedText.Trim()))
            {
                hvttRichTextBox1.SelectedText = hvttRichTextBox1.SelectedText.ToLower();
            }
            else if(IsFirstUpperCase(hvttRichTextBox1.SelectedText.Trim()))
            {
                hvttRichTextBox1.SelectedText = hvttRichTextBox1.SelectedText.ToUpper();
            }
            
            hvttRichTextBox1.Select(iSelectionStart, iSelectionEnd);
        }
        private void btnUpperCase_Click(object sender, EventArgs e)
        {
            Rich_UpperCase();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control|Keys.B))
            {
                Rich_Bold();
                return true;
            }
            if (keyData == (Keys.Control | Keys.U))
            {
                Rich_UnderLine();
                return true;
            }
            if (keyData == (Keys.Control | Keys.I))
            {
                Rich_Italic();
                return true;
            }
            if (keyData == (Keys.Shift | Keys.F3))
            {
                Rich_UpperCase();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
           
            return base.ProcessDialogKey(keyData);
        }

        private void btnTabToRight_Click(object sender, EventArgs e)
        {
            hvttRichTextBox1.SelectionIndent += 20;
        }

        private void btnTabToLeft_Click(object sender, EventArgs e)
        {
            if (hvttRichTextBox1.SelectionIndent <= 0)
                hvttRichTextBox1.SelectionIndent = 0;
            else
                hvttRichTextBox1.SelectionIndent -= 20;
        }
    }
}
