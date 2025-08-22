using System.Drawing;

namespace HVTT.UI.ContentManager

{
	/// <summary>
	/// Represents block layout manager responsible for sizing the content blocks.
	/// </summary>
	public abstract class BlockLayoutManager
	{
		private Graphics m_Graphics;
		/// <summary>
		/// Creates new instance of BlockLayoutManager.
		/// </summary>
		public BlockLayoutManager()
		{
		}

		/// <summary>
		/// Resizes the content block and sets it's Bounds property to reflect new size.
		/// </summary>
		/// <param name="block">Content block to resize.</param>
        /// <param name="availableSize">Content size available for the block in the given line.</param>
		public abstract void Layout(IBlock block, Size availableSize);

		/// <summary>
		/// Gets or sets the graphics object used by layout manager.
		/// </summary>
		public System.Drawing.Graphics Graphics
		{
			get {return m_Graphics;}
			set {m_Graphics=value;}
		}
	}
}
