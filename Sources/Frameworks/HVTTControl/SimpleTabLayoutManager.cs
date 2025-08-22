using System;
using System.Drawing;
using HVTT.UI.ContentManager;

namespace HVTT.UI.Window.Forms
{
	/// <summary>
	/// Provides layout management for ISimpleTab tab implementations.
	/// </summary>
	public class SimpleTabLayoutManager:BlockLayoutManager
	{
		public SimpleTabLayoutManager()
		{
		}

		/// <summary>
		/// Resizes the content block and sets it's Bounds property to reflect new size.
		/// </summary>
		/// <param name="block">Content block to resize.</param>
        public override void Layout(IBlock block, Size availableSize)
		{
			if(this.Graphics==null)
				throw(new InvalidOperationException("Graphics property must be set to valid instance of Graphics object."));

			ISimpleTab tab=block as ISimpleTab;
			if(!tab.Visible)
				return;

			int width=0;
			int height=0;
			int paddingTop=1;
			int paddingBottom=0;
			int paddingLeft=1;
			int paddingRight=1;
			int paddingBottomSelected=2;

            eTextFormat strFormat = eTextFormat.Default;

			Font font=tab.GetTabFont();
			if(tab.Text!="")
			{
				Size textSize=TextDrawing.MeasureString(this.Graphics,tab.Text,font,0,strFormat);
				width+=textSize.Width;
				if(textSize.Height>height)
					height=textSize.Height;
			}
			else
				height+=font.Height;

			height+=(paddingTop+paddingBottom);
			if(tab.IsSelected)
				height+=paddingBottomSelected;
			width+=(paddingLeft+paddingRight);

			if(tab.TabAlignment==eTabStripAlignment.Left || tab.TabAlignment==eTabStripAlignment.Right)
				block.Bounds=new Rectangle(0,0,height,width);
			else
				block.Bounds=new Rectangle(0,0,width,height);
		}

	}
}
