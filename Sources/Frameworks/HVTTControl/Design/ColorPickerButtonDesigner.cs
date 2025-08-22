using System;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Collections;

namespace HVTT.UI.Window.Forms.Design
{
    public class ColorPickerButtonDesigner : HVTTButtonDesigner
    {
        // Removed FRAMEWORK20 directives. Keep both overrides for compatibility.
        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            SetDesignTimeDefaults();
        }

		public override void OnSetComponentDefaults()
		{
			base.OnSetComponentDefaults();
            SetDesignTimeDefaults();
		}

        private void SetDesignTimeDefaults()
        {
            ColorPickerButton b = this.Control as ColorPickerButton;
            TypeDescriptor.GetProperties(b)["Image"].SetValue(b, BarFunctions.LoadBitmap("SystemImages.ColorPickerButtonImage.png"));
            TypeDescriptor.GetProperties(b)["SelectedColorImageRectangle"].SetValue(b, new Rectangle(2,2,12,12));
            TypeDescriptor.GetProperties(b)["Text"].SetValue(b, "");
            TypeDescriptor.GetProperties(b)["Size"].SetValue(b, new Size(37,23));
        }
    }
}
