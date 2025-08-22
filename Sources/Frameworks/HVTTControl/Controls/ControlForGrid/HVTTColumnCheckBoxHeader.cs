using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms.Controls
{
   public delegate void HVTTCheckBoxClickedHandler(bool state);
    public class HVTTDataGridViewCheckBoxHeaderCellEventArgs : EventArgs
    {
        bool _bChecked;
        public HVTTDataGridViewCheckBoxHeaderCellEventArgs(bool bChecked)
        {
            _bChecked = bChecked;
        }
        public bool Checked
        {
            get { return _bChecked; }
        }
    }
    public class HVTTDatagridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
    {
        Point checkBoxLocation;
        Size checkBoxSize;
        bool _checked = false;
        Point _cellLocation = new Point();
        System.Windows.Forms.VisualStyles.CheckBoxState _cbState = System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
        Boolean _mblnUsingIsChange = true;

        public Boolean UsingIsChange
        {
            get
            {
                return _mblnUsingIsChange;
            }
            set
            {
                _mblnUsingIsChange = value;
            }
        }

        public event HVTTCheckBoxClickedHandler OnCheckBoxClicked;

        public HVTTDatagridViewCheckBoxHeaderCell()
        {           
        }

        protected override void Paint(System.Drawing.Graphics graphics, 
            System.Drawing.Rectangle clipBounds, 
            System.Drawing.Rectangle cellBounds, 
            int rowIndex, 
            DataGridViewElementStates dataGridViewElementState, 
            object value, 
            object formattedValue, 
            string errorText, 
            DataGridViewCellStyle cellStyle, 
            DataGridViewAdvancedBorderStyle advancedBorderStyle, 
            DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, 
                dataGridViewElementState, value, 
                formattedValue, errorText, cellStyle, 
                advancedBorderStyle, paintParts);
            Point p = new Point();
            Size s = CheckBoxRenderer.GetGlyphSize(graphics, 
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            p.X = cellBounds.Location.X + 
                (cellBounds.Width / 2) - (s.Width / 2) ;
            p.Y = cellBounds.Location.Y + 
                (cellBounds.Height / 2) - (s.Height / 2);
            _cellLocation = cellBounds.Location;
            checkBoxLocation = p;
            checkBoxSize = s;
            if (_checked)
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.CheckedNormal;
            else
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.UncheckedNormal;
            CheckBoxRenderer.DrawCheckBox
            (graphics, checkBoxLocation, _cbState);
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
            if (p.X >= checkBoxLocation.X && p.X <= 
                checkBoxLocation.X + checkBoxSize.Width 
            && p.Y >= checkBoxLocation.Y && p.Y <= 
                checkBoxLocation.Y + checkBoxSize.Height)
            {
                _checked = !_checked;
                if (DataGridView.Rows.Count > 0)
                {

                    for (int i = 0; i < DataGridView.Rows.Count; i++)
                    {
                        DataGridView.Rows[i].Cells[e.ColumnIndex].Value = _checked;
                        if (_mblnUsingIsChange)
                            DataGridView.Rows[i].Cells["IsChange"].Value = 1;
                    }
                }
                if (OnCheckBoxClicked != null)
                {
                    OnCheckBoxClicked(_checked);
                    this.DataGridView.InvalidateCell(this);
                }
                
            } 
            base.OnMouseClick(e);
        }     
    }

}

