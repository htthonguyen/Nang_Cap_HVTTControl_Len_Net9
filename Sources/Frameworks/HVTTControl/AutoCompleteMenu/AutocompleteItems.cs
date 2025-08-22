using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms.HVTTAutoCompleteMenu
{
    /// <summary>
    /// This autocomplete item appears after dot
    /// </summary>
    public class MethodAutocompleteItem : AutocompleteItem
    {
        string firstPart;
        string lowercaseText;

        public MethodAutocompleteItem(string text)
            : base(text)
        {
            lowercaseText = Text.ToLower();
        }

        public override CompareResult Compare(string fragmentText)
        {
            int i = fragmentText.LastIndexOf('.');
            if (i < 0)
                return CompareResult.Hidden;
            string lastPart = fragmentText.Substring(i + 1);
            firstPart = fragmentText.Substring(0, i);

            if (lastPart == "") return CompareResult.Visible;
            if (Text.StartsWith(lastPart, StringComparison.InvariantCultureIgnoreCase))
                return CompareResult.VisibleAndSelected;
            if (lowercaseText.Contains(lastPart.ToLower()))
                return CompareResult.Visible;

            return CompareResult.Hidden;
        }

        public override string GetTextForReplace()
        {
            return firstPart + "." + Text;
        }
    }

    /// <summary>
    /// Autocomplete item for code snippets
    /// </summary>
    /// <remarks>Snippet can contain special char ^ for caret position.</remarks>
    public class SnippetAutocompleteItem : AutocompleteItem
    {
        public SnippetAutocompleteItem(string snippet)
        {
            Text = snippet.Replace("\r", "");
            ToolTipTitle = "Code snippet:";
            ToolTipText = Text;
        }

        public override string ToString()
        {
            return MenuText ?? Text.Replace("\n", " ").Replace("^", "");
        }

        public override string GetTextForReplace()
        {
            return Text;
        }

        public override void OnSelected(SelectedEventArgs e)
        {
            var tb = Parent.TargetControlWrapper;
            //
            if (!Text.Contains("^"))
                return;
            var text = tb.Text;
            for (int i = Parent.Fragment.Start; i < text.Length; i++)
                if (text[i] == '^')
                {
                    tb.SelectionStart = i;
                    tb.SelectionLength = 1;
                    tb.SelectedText = "";
                    return;
                }
        }

        /// <summary>
        /// Compares fragment text with this item
        /// </summary>
        public override CompareResult Compare(string fragmentText)
        {
            if (Text.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase) &&
                   Text != fragmentText)
                return CompareResult.Visible;

            return CompareResult.Hidden;
        }
    }

    /// <summary>
    /// This class finds items by substring
    /// </summary>
    public class SubstringAutocompleteItem : AutocompleteItem
    {
        protected readonly string lowercaseText;
        protected readonly bool ignoreCase;

        public SubstringAutocompleteItem(string text, bool ignoreCase = true)
            : base(text)
        {
            this.ignoreCase = ignoreCase;
            if(ignoreCase)
                lowercaseText = text.ToLower();
        }
        public SubstringAutocompleteItem(string text, List<MenuColumn> menuColumns, bool ignoreCase = true)
            : base(text, menuColumns)
        {
            this.ignoreCase = ignoreCase;
            if (ignoreCase)
                lowercaseText = text.ToLower();
        }
        public SubstringAutocompleteItem(string text,String keyText, List<MenuColumn> menuColumns, bool ignoreCase = true)
           : base(text, menuColumns,keyText)
        {
            this.ignoreCase = ignoreCase;
            if (ignoreCase)
                lowercaseText = text.ToLower();
        }

        public override CompareResult Compare(string fragmentText)
        {
            if(ignoreCase)
            {
                if (lowercaseText.Contains(fragmentText.ToLower()))
                    return CompareResult.Visible;
            }
            else
            {
                if (Text.Contains(fragmentText))
                    return CompareResult.Visible;
            }

            return CompareResult.Hidden;
        }
    }

    /// <summary>
    /// this column of MulticolumnAutocompleteItem
    /// </summary>
    /// 
    [Serializable]
    public class MenuColumn
    {
        public String ColumnName { get; set; }
        public String ColumnValue { get; set; }


        public int Width { get; set; }

        [DefaultValue(true)]
        public Boolean IsVisible { get; set; }

      

        public MenuColumn()
        {
            ColumnName = "";
            ColumnValue = "";
            
            
            Width = 100;
            IsVisible = true;
           
        }
        //public Boolean IsSearch { get; set; }
    }

    /// <summary>
    /// This item draws multicolumn menu
    /// </summary>
    public class MulticolumnAutocompleteItem : SubstringAutocompleteItem
    {
        public bool CompareBySubstring { get; set; }
     


        public MulticolumnAutocompleteItem(List<MenuColumn> menuColumns, string searchingText, bool compareBySubstring = true, bool ignoreCase = true)
            : base(searchingText, menuColumns, ignoreCase)
        {
            this.CompareBySubstring = compareBySubstring;
            this.MenuColumns = menuColumns;
        }
        public MulticolumnAutocompleteItem(List<MenuColumn> menuColumns, string searchingText,String keyText, bool compareBySubstring = true, bool ignoreCase = true)
            : base(searchingText,keyText, menuColumns, ignoreCase)
        {
            this.CompareBySubstring = compareBySubstring;
            this.MenuColumns = menuColumns;
            this.KeyText = keyText;
        }

        public override CompareResult Compare(string fragmentText)
        {
            if (CompareBySubstring)
                return base.Compare(fragmentText);

            if(ignoreCase)
            {
                if (Text.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase))
                    return CompareResult.VisibleAndSelected;
            }else
                if (Text.StartsWith(fragmentText))
                    return CompareResult.VisibleAndSelected;

            return CompareResult.Hidden;
        }

        public List<int> ColumnsWidth
        {
            get
            {
                var colums = new List<int>();
                foreach (var c in MenuColumns)
                {
                    if (c.IsVisible)
                        colums.Add(c.Width);
                }
                return colums;
            }
        }

        public override void OnPaint(PaintItemEventArgs e)
        {

           

            int[] columnWidth = ColumnsWidth.ToArray();
            if(columnWidth == null)
            {
                columnWidth = new int[MenuColumns.Count];
                float step = e.TextRect.Width/MenuColumns.Count;
                for (int i = 0; i < MenuColumns.Count; i++)
                    columnWidth[i] = (int)step;
            }

            //draw columns
            Pen pen = Pens.Silver;
            float x = e.TextRect.X;
            e.StringFormat.FormatFlags = e.StringFormat.FormatFlags | StringFormatFlags.NoWrap;

            using (var brush = new SolidBrush(e.IsSelected ? e.Colors.SelectedForeColor : e.Colors.ForeColor))
                for (int i = 0; i < MenuColumns.Count; i++)
                {
                    if (MenuColumns[i].IsVisible)
                    {
                        var width = MenuColumns[i].Width;
                        var rect = new RectangleF(x, e.TextRect.Top, width, e.TextRect.Height);
                        e.Graphics.DrawLine(pen, new PointF(x, e.TextRect.Top), new PointF(x, e.TextRect.Bottom));

                        e.Graphics.DrawString(MenuColumns[i].ColumnValue, e.Font, brush, rect, e.StringFormat);

                        x += width;
                    }
                }
        }
    }
}