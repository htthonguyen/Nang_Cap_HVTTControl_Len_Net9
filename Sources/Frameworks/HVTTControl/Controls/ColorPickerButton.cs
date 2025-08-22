using System;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace HVTT.UI.Window.Forms
{
    /// <summary>
    /// Represents the color picker button control.
    /// </summary>
    [ToolboxBitmap(typeof(ColorPickerButton), "Controls.ColorPickerButton.ico"), ToolboxItem(true), DefaultEvent("SelectedColorChanged"), Designer(typeof(Design.ColorPickerButtonDesigner)), System.Runtime.InteropServices.ComVisible(false)]
    public class ColorPickerButton : HVTTButton
    {
        #region Private Variables
        #endregion

        #region Events
        /// <summary>
        /// Occurs when color is choosen from drop-down color picker or from Custom Colors dialog box. Selected color can be accessed through SelectedColor property.
        /// </summary>
        [Description("Occurs when color is choosen from drop-down color picker or from Custom Colors dialog box.")]
        public event EventHandler SelectedColorChanged;

        /// <summary>
        /// Occurs when mouse is moving over the colors presented by the color picker. You can use it to preview the color before it is selected.
        /// </summary>
        [Description("Occurs when mouse is moving over the colors presented by the color picker")]
        public event ColorPreviewEventHandler ColorPreview;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates new instance of the object.
        /// </summary>
        public ColorPickerButton()
            : base()
        {
            ColorPickerDropDown cp = GetColorPickerDropDown();
            cp.SelectedColorChanged += new EventHandler(InternalSelectedColorChanged);
            cp.ColorPreview += new ColorPreviewEventHandler(InternalColorPreview);
        }
        #endregion

        #region Properties

       

        /// <summary>
        /// Gets or sets more colors menu item is visible which allows user to open Custom Colors dialog box. Default value is true.
        /// </summary>
        [Browsable(true), DefaultValue(true), DevCoSerialize(), Category("Appearance"), Description("Indicates more colors menu item is visible which allows user to open Custom Colors dialog box.")]
        public bool DisplayMoreColors
        {
            get { return GetColorPickerDropDown().DisplayMoreColors; }
            set { GetColorPickerDropDown().DisplayMoreColors = value; }
        }

        /// <summary>
        /// Gets or sets the last selected color from either the drop-down or Custom Color dialog box. Default value is
        /// Color.Empty. You can use SelectedColorChanged event to be notified when this property changes.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color SelectedColor
        {
            get { return GetColorPickerDropDown().SelectedColor; }
            set { GetColorPickerDropDown().SelectedColor = value; }
        }

        /// <summary>
        /// Gets or sets whether theme colors are displayed on drop-down. Default value is true.
        /// </summary>
        [Browsable(true), DefaultValue(true), DevCoSerialize(), Category("Appearance"), Description("Indicates whether theme colors are displayed on drop-down.")]
        public bool DisplayThemeColors
        {
            get { return GetColorPickerDropDown().DisplayThemeColors; }
            set { GetColorPickerDropDown().DisplayThemeColors = value; }
        }

        /// <summary>
        /// Gets or sets whether standard colors are displayed on drop-down. Default value is true.
        /// </summary>
        [Browsable(true), DefaultValue(true), DevCoSerialize(), Category("Appearance"), Description("Indicates whether standard colors are displayed on drop-down.")]
        public bool DisplayStandardColors
        {
            get { return GetColorPickerDropDown().DisplayStandardColors; }
            set { GetColorPickerDropDown().DisplayStandardColors = value; }
        }

        /// <summary>
        /// Indicates whether SubItems collection is serialized. ColorPickerDropDown does not serialize the sub items.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeSubItems()
        {
            return false;
        }

        /// <summary>
        /// Gets or sets the rectangle in Image coordinates where selected color will be painted. Setting this property will
        /// have an effect only if Image property is used to set the image. Default value is an empty rectangle which indicates
        /// that selected color will not be painted on the image.
        /// </summary>
        [Browsable(true), Description("Indicates rectangle in Image coordinates where selected color will be painted. Property will have effect only if Image property is used to set the image."), Category("Behaviour")]
        public Rectangle SelectedColorImageRectangle
        {
            get { return GetColorPickerDropDown().SelectedColorImageRectangle; }
            set { GetColorPickerDropDown().SelectedColorImageRectangle = value; }
        }


        #endregion

        #region Internal Implementation
        /// <summary>
        /// Displays the Colors dialog that allows user to choose the color or create a custom color. If new color is choosen the
        /// SelectedColorChanged event is raised.
        /// </summary>
        public void DisplayMoreColorsDialog()
        {
            GetColorPickerDropDown().DisplayMoreColorsDialog();
        }

        protected override ButtonItem CreateButtonItem()
        {
            return new ColorPickerDropDown();
        }

        private ColorPickerDropDown GetColorPickerDropDown()
        {
            return InternalItem as ColorPickerDropDown;
        }

        private void InternalColorPreview(object sender, ColorPreviewEventArgs e)
        {
            OnColorPreview(e);
        }

        /// <summary>
        /// Raises the ColorPreview event.
        /// </summary>
        /// <param name="e">Provides event data.</param>
        protected virtual void OnColorPreview(ColorPreviewEventArgs e)
        {
            if (ColorPreview != null)
                ColorPreview(this, e);
        }

        private void InternalSelectedColorChanged(object sender, EventArgs e)
        {
            OnSelectedColorChanged(e);
        }

        /// <summary>
        /// Raises the SelectedColorChanged event.
        /// </summary>
        /// <param name="e">Provides event data.</param>
        protected virtual void OnSelectedColorChanged(EventArgs e)
        {
            if (SelectedColorChanged != null)
                SelectedColorChanged(this, e);
        }

       

        /// <summary>
        /// Gets whether property should be serialized.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeSelectedColorImageRectangle()
        {
            return GetColorPickerDropDown().ShouldSerializeSelectedColorImageRectangle();
        }

        /// <summary>
        /// Resets the property to its default value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResetSelectedColorImageRectangle()
        {
            GetColorPickerDropDown().ResetSelectedColorImageRectangle();
        }

        /// <summary>
        /// Invokes the ColorPreview event.
        /// </summary>
        /// <param name="e">Provides data for the event.</param>
        public void InvokeColorPreview(ColorPreviewEventArgs e)
        {
            GetColorPickerDropDown().InvokeColorPreview(e);
        }

        /// <summary>
        /// Update the selected color image if the SelectedColorImageRectangle has been set and button is using Image property to display the image.
        /// </summary>
        public void UpdateSelectedColorImage()
        {
            GetColorPickerDropDown().UpdateSelectedColorImage();
        }
        #endregion
    }
}
