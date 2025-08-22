using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms.Editors
{
    public partial class HVTTTreeViewColumns : UserControl
    {
        public HVTTTreeViewColumns()
        {
            InitializeComponent();
        }

        #region Event
        private void tv_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;

            Rectangle rect = e.Bounds;

            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                if ((e.State & TreeNodeStates.Focused) != 0)
                    e.Graphics.FillRectangle(SystemBrushes.Highlight, rect);
                else
                    e.Graphics.FillRectangle(SystemBrushes.Control, rect);
            }
            else
                e.Graphics.FillRectangle(Brushes.White, rect);

            e.Graphics.DrawRectangle(SystemPens.Control, rect);

            for (int intColumn = 1; intColumn < this.lv.Columns.Count; intColumn++)
            {
                rect.Offset(this.lv.Columns[intColumn - 1].Width, 0);
                rect.Width = this.lv.Columns[intColumn].Width;

                e.Graphics.DrawRectangle(SystemPens.Control, rect);

                string strColumnText;
                string[] list = e.Node.Tag as string[];
                if (list != null && intColumn <= list.Length)
                    strColumnText = list[intColumn - 1];
                else
                    strColumnText = intColumn + " " + e.Node.Text; // dummy

                TextFormatFlags flags = TextFormatFlags.EndEllipsis;
                switch (this.lv.Columns[intColumn].TextAlign)
                {
                    case HorizontalAlignment.Center:
                        flags |= TextFormatFlags.HorizontalCenter;
                        break;
                    case HorizontalAlignment.Left:
                        flags |= TextFormatFlags.Left;
                        break;
                    case HorizontalAlignment.Right:
                        flags |= TextFormatFlags.Right;
                        break;
                    default:
                        break;
                }

                rect.Y++;
                if ((e.State & TreeNodeStates.Selected) != 0 &&
                    (e.State & TreeNodeStates.Focused) != 0)
                    TextRenderer.DrawText(e.Graphics, strColumnText, e.Node.NodeFont, rect, SystemColors.HighlightText, flags);
                else
                    TextRenderer.DrawText(e.Graphics, strColumnText, e.Node.NodeFont, rect, e.Node.ForeColor, e.Node.BackColor, flags);
                rect.Y--;
            }
        }

        #endregion

        #region Property
        [Browsable(false)]
        public ListView.ColumnHeaderCollection Columns
        {
            get
            {
                return lv.Columns;
            }
        }

        [Description("TreeView associated with the control"), Category("Behavior")]
        public TreeView TreeView
        {
            get
            {
                return this.tv;
            }
        }
        #endregion

    }
}
