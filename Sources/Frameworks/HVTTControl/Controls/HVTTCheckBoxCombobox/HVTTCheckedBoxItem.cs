using System;
using System.Collections.Generic;
using System.Text;

namespace HVTT.UI.Window.Forms.Controls
{
    public class HVTTCheckedBoxItem
    {
       
        public String Value {
            get;
            set;
        }
        
       
        public string Text {
            get;
            set;
        }

      
        public Boolean Checked
        {
            get;set;
        }

        public HVTTCheckedBoxItem() {
            Value = "";
            Text = "";
            Checked = false;
        }

        public HVTTCheckedBoxItem(string text, String val) {
            this.Text = text;
            this.Value = val;
            Checked = false;
        }
        public HVTTCheckedBoxItem(string text, String val,Boolean check)
        {
            this.Text = text;
            this.Value = val;
            this.Checked = check;
        }

        public override string ToString() {
            return string.Format("Value: '{0}', Text: '{1}', Checked: {2}", Value, Text, Checked);
        }
    }
}
