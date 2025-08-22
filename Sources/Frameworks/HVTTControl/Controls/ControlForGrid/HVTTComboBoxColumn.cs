using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace HVTT.UI.Window.Forms.Controls
{

    public class HVTTComboBoxColumn : DataGridViewComboBoxColumn
    {
        public HVTTComboBoxColumn()
        {
            HVTTComboBoxCell cbc = new HVTTComboBoxCell();
            this.CellTemplate = cbc;
        }

    }

    public class HVTTComboBoxCell : DataGridViewComboBoxCell
    {
        public HVTTComboBoxCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            HVTTComboBoxControl ctl = DataGridView.EditingControl as HVTTComboBoxControl;
            ctl.DropDownStyle = ComboBoxStyle.DropDownList;
            ctl.Style = HVTTControlStyle.Office2007;
            if (ctl != null)
            {
                ctl.SelectedIndex = 0;
            }
        }
    }


    public class HVTTComboBoxControl : HVTTComboBox, IDataGridViewEditingControl
    {
        private int index_ = 0;
        private System.Windows.Forms.DataGridView dataGridView_ = null;
        private bool valueChanged_ = false;

        public HVTTComboBoxControl()
            : base()
        {
            this.SelectedIndexChanged += new EventHandler(ComboBoxControl_SelectedIndexChanged);
        }


        public void ComboBoxControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //I will add code here
            NotifyDataGridViewOfValueChange();
        }


        protected virtual void NotifyDataGridViewOfValueChange()
        {
            this.valueChanged_ = true;
            if (this.dataGridView_ != null)
            {
                this.dataGridView_.NotifyCurrentCellDirty(true);
            }
        }

        #region IDataGridViewEditingControl members


        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }


        public System.Windows.Forms.DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView_;
            }
            set
            {
                dataGridView_ = value;
            }
        }

        public object EditingControlFormattedValue
        {
            get
            {
                return base.SelectedValue;
            }
            set
            {
                base.SelectedValue = value;
                NotifyDataGridViewOfValueChange();
            }
        }

        public int EditingControlRowIndex
        {
            get
            {
                return index_;
            }
            set
            {
                index_ = value;
            }
        }

        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged_;
            }
            set
            {
                valueChanged_ = value;
            }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            if (keyData == Keys.Return)
                return true;
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                case Keys.Return:
                    return true;
                default:
                    return false;
            }
        }

        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue.ToString();
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        #endregion

    }

 

       
}
