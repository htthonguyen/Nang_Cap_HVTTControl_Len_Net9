using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms.Controls
{
    public partial class TextBoxForEditBox : TextBox
    {
        public TextBoxForEditBox()
        {
            InitializeComponent();
            Initialize();
        }

        public event EventHandler HasFocus;
        protected override void OnGotFocus(EventArgs e)
        {
            //if (this.Text.Trim()==PlaceHolder)
            //{
            //    this.Text = "";
            //}

            if (HasFocus != null)
                HasFocus(this, e);
            this.SelectAll();

            base.OnGotFocus(e);
        }

        #region Placehooder

        #region Fields

        #region Protected Fields

        protected string _PlaceHolderText = ""; //The PlaceHolder text
        protected Color _PlaceHolderColor; //Color of the PlaceHolder when the control does not have focus
        protected Color _PlaceHolderActiveColor; //Color of the PlaceHolder when the control has focus

        #endregion

        #region Private Fields

        private Panel _mPlaceHolderContainer; //Container to hold the PlaceHolder
        private Font _mPlaceHolderFont; //Font of the PlaceHolder
        private SolidBrush _mPlaceHolderBrush; //Brush for the PlaceHolder

        #endregion

        #endregion


        #region Private Methods

        /// <summary>
        /// Initializes PlaceHolder properties and adds CtextBox events
        /// </summary>
        private void Initialize()
        {
            //Sets some default values to the PlaceHolder properties
            _PlaceHolderColor = Color.LightGray;
            _PlaceHolderActiveColor = Color.Gray;
            _mPlaceHolderFont = this.Font;
            _mPlaceHolderBrush = new SolidBrush(_PlaceHolderActiveColor);
            _mPlaceHolderContainer = null;

            //Draw the PlaceHolder, so we can see it in design time
            DrawPlaceHolder();

            //Eventhandlers which contains function calls. 
            //Either to draw or to remove the PlaceHolder
            this.Enter += new EventHandler(ThisHasFocus);
            this.Leave += new EventHandler(ThisWasLeaved);
            this.TextChanged += new EventHandler(ThisTextChanged);
        }

        /// <summary>
        /// Removes the PlaceHolder if it should
        /// </summary>
        private void RemovePlaceHolder()
        {
            if (_mPlaceHolderContainer != null)
            {
                this.Controls.Remove(_mPlaceHolderContainer);
                _mPlaceHolderContainer = null;
            }
        }

        /// <summary>
        /// Draws the PlaceHolder if the text length is 0
        /// </summary>
        private void DrawPlaceHolder()
        {
            if (PlaceHolder == null || PlaceHolder.Trim() == "")
                return;

            if (this._mPlaceHolderContainer == null && this.TextLength <= 0)
            {
                _mPlaceHolderContainer = new Panel(); // Creates the new panel instance
                _mPlaceHolderContainer.Paint += new PaintEventHandler(PlaceHolderContainer_Paint);
                _mPlaceHolderContainer.Invalidate();
                _mPlaceHolderContainer.Click += new EventHandler(PlaceHolderContainer_Click);
                this.Controls.Add(_mPlaceHolderContainer); // adds the control
            }
        }

        #endregion

        #region Eventhandlers

        #region PlaceHolder Events

        private void PlaceHolderContainer_Click(object sender, EventArgs e)
        {
            this.Focus(); //Makes sure you can click wherever you want on the control to gain focus
        }

        private void PlaceHolderContainer_Paint(object sender, PaintEventArgs e)
        {
            //Setting the PlaceHolder container up
            _mPlaceHolderContainer.Location = new Point(2, 0); // sets the location
            _mPlaceHolderContainer.Height = this.Height; // Height should be the same as its parent
            _mPlaceHolderContainer.Width = this.Width; // same goes for width and the parent
            _mPlaceHolderContainer.Anchor = AnchorStyles.Left | AnchorStyles.Right; // makes sure that it resizes with the parent control



            if (this.ContainsFocus)
            {
                //if focused use normal color
                _mPlaceHolderBrush = new SolidBrush(this._PlaceHolderActiveColor);
            }

            else
            {
                //if not focused use not active color
                _mPlaceHolderBrush = new SolidBrush(this._PlaceHolderColor);
            }

            //Drawing the string into the panel 
            Graphics g = e.Graphics;
            g.DrawString(this._PlaceHolderText, PlaceHolderFont, _mPlaceHolderBrush, new PointF(-2f, 1f));//Take a look at that point
            //The reason I'm using the panel at all, is because of this feature, that it has no limits
            //I started out with a label but that looked very very bad because of its paddings 

        }

        #endregion

        #region CTextBox Events

        private void ThisHasFocus(object sender, EventArgs e)
        {
            //if focused use focus color
            _mPlaceHolderBrush = new SolidBrush(this._PlaceHolderActiveColor);

            //The PlaceHolder should not be drawn if the user has already written some text
            if (this.TextLength <= 0)
            {
                RemovePlaceHolder();
                DrawPlaceHolder();
            }
        }

        private void ThisWasLeaved(object sender, EventArgs e)
        {
            //if the user has written something and left the control
            if (this.TextLength > 0)
            {
                //Remove the PlaceHolder
                RemovePlaceHolder();
            }
            else
            {
                //But if the user didn't write anything, Then redraw the control.
                this.Invalidate();
            }
        }

        private void ThisTextChanged(object sender, EventArgs e)
        {
            //If the text of the textbox is not empty
            if (this.TextLength > 0)
            {
                //Remove the PlaceHolder
                RemovePlaceHolder();
            }
            else
            {
                //But if the text is empty, draw the PlaceHolder again.
                DrawPlaceHolder();
            }
        }

        #region Overrided Events

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Draw the PlaceHolder even in design time
            DrawPlaceHolder();
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
            //Check if there is a PlaceHolder
            if (_mPlaceHolderContainer != null)
                //if there is a PlaceHolder it should also be invalidated();
                _mPlaceHolderContainer.Invalidate();
        }

        #endregion

        #endregion

        #endregion

        #region Properties
        [Category("PlaceHolder attribtues")]
        [Description("Sets the text of the PlaceHolder")]
        public string PlaceHolder
        {
            get { return this._PlaceHolderText; }
            set
            {
                this._PlaceHolderText = value;
                DrawPlaceHolder();
                this.Invalidate();
            }
        }

        [Category("PlaceHolder attribtues")]
        [Description("When the control gaines focus, this color will be used as the PlaceHolder's forecolor")]
        public Color PlaceHolderActiveForeColor
        {
            get { return this._PlaceHolderActiveColor; }

            set
            {
                this._PlaceHolderActiveColor = value;
                this.Invalidate();
            }
        }

        [Category("PlaceHolder attribtues")]
        [Description("When the control looses focus, this color will be used as the PlaceHolder's forecolor")]
        public Color PlaceHolderForeColor
        {
            get { return this._PlaceHolderColor; }

            set
            {
                this._PlaceHolderColor = value;
                this.Invalidate();
            }
        }

        [Category("PlaceHolder attribtues")]
        [Description("The font used on the PlaceHolder. Default is the same as the control")]
        public Font PlaceHolderFont
        {
            get
            {
                return this._mPlaceHolderFont;
            }

            set
            {
                this._mPlaceHolderFont = value;
                this.Invalidate();
            }
        }


        #endregion

        #endregion
    }
}
