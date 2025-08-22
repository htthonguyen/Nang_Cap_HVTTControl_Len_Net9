using System;
using HVTT.UI.ContentManager;
using System.Drawing;

namespace HVTT.UI.Window.Forms
{
	/// <summary>
	/// Reprensets IBlock layout manager implmenetation
	/// </summary>
	public class ItemBlockLayoutManager:BlockLayoutManager
	{
		/// <summary>
		/// Resizes the content block and sets it's Bounds property to reflect new size.
		/// </summary>
		/// <param name="block">Content block to resize.</param>
        public override void Layout(IBlock block, Size availableSize)
		{
			if(block is BaseItem)
			{
				BaseItem item=block as BaseItem;
                if (item is ItemContainer)
                {
                    item.SuspendLayout = true;
                    item.WidthInternal = availableSize.Width;
                    item.HeightInternal = availableSize.Height;
                    item.SuspendLayout = false;
                }
                item.RecalcSize();
				item.Displayed=item.Visible;
			}
		}
	}
}
