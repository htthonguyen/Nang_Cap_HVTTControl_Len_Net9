using System;
using System.Drawing;
using HVTT.UI.ContentManager;

namespace HVTT.UI.Window.Forms
{
	/// <summary>
	/// Represents class for default layout of the BubbleButton objects.
	/// </summary>
	public class BubbleButtonLayoutManager:BlockLayoutManager
	{
		/// <summary>
		/// Creates new instance of the class.
		/// </summary>
		public BubbleButtonLayoutManager()
		{
		}

		/// <summary>
		/// Resizes the content block and sets it's Bounds property to reflect new size.
		/// </summary>
		/// <param name="block">Content block to resize.</param>
        public override void Layout(IBlock block, Size availableSize)
		{
			BubbleButton button=block as BubbleButton;
			BubbleBar bar=button.GetBubbleBar();
			if(bar==null)
			{
				if(button.Site!=null && button.Site.DesignMode)
					return;
				throw new InvalidOperationException("BubbleBar object could not be found for button named: '"+button.Name+"' in BubbleButtonLayoutManager.Layout");
			}
			Size defaultSize=bar.ImageSizeNormal;
			button.SetDisplayRectangle(new Rectangle(button.DisplayRectangle.Location,defaultSize));
		}
	}
}
