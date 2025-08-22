using System;
using System.Drawing;
using System.Collections;

namespace HVTT.UI.Window.Forms
{
	/// <summary>
	/// Represents the layout for the element style.
	/// </summary>
	internal class ElementStyleLayout
	{
		public ElementStyleLayout()
		{
		}

		/// <summary>
		/// Calculates size of an style element.
		/// </summary>
		/// <param name="style">Style to calculate size for.</param>
		/// <param name="defaultFont">Default font that will be used by style if style does not uses it's own font.</param>
		/// <returns>Size of the style element. At this time only Height memeber will be calculated.</returns>
		public static void CalculateStyleSize(ElementStyle style, Font defaultFont)
		{
			int height=defaultFont.Height;
            ElementStyle s = ElementStyleDisplay.GetElementStyle(style);
			if(s.Font!=null)
				height=s.Font.Height;
			
			if(s.PaintTopBorder)
			{
				height+=s.BorderTopWidth;
			}

			if(s.PaintBottomBorder)
			{
				height+=s.BorderBottomWidth;
			}
			
			height+=(s.MarginTop+style.MarginBottom);
			height+=(s.PaddingTop+s.PaddingBottom);
			
			style.SetSize(new Size(0,height));
		}

		/// <summary>
		/// Returns the total white space for a style. Whitespace is the space between the edge of the element and inner content of the element.
		/// </summary>
		/// <param name="es">Style to return white space for</param>
		/// <returns></returns>
		public static int HorizontalStyleWhiteSpace(ElementStyle es)
		{
			return LeftWhiteSpace(es)+RightWhiteSpace(es);
		}

		/// <summary>
		/// Returns the total white space for a style. Whitespace is the space between the edge of the element and inner content of the element.
		/// </summary>
		/// <param name="es">Style to return white space for.</param>
		/// <returns></returns>
		public static int VerticalStyleWhiteSpace(ElementStyle es)
		{
			return TopWhiteSpace(es)+BottomWhiteSpace(es);
		}

		/// <summary>
		/// Returns total white space for left side of the style. Whitespace is the space between the edge of the element and inner content of the element.
		/// </summary>
		/// <param name="es">Style to return white space for.</param>
		/// <returns></returns>
		public static int LeftWhiteSpace(ElementStyle es)
		{
			return ElementStyleLayout.StyleSpacing(es,SpacePart.Border | SpacePart.Margin | SpacePart.Padding,eStyleSide.Left);
		}

		/// <summary>
		/// Returns total white space for right side of the style. Whitespace is the space between the edge of the element and inner content of the element.
		/// </summary>
		/// <param name="es">Style to return white space for.</param>
		/// <returns></returns>
		public static int RightWhiteSpace(ElementStyle es)
		{
			return ElementStyleLayout.StyleSpacing(es,SpacePart.Border | SpacePart.Margin | SpacePart.Padding,eStyleSide.Right);
		}

		/// <summary>
		/// Returns total white space for top side of the style. Whitespace is the space between the edge of the element and inner content of the element.
		/// </summary>
		/// <param name="es">Style to return white space for.</param>
		/// <returns></returns>
		public static int TopWhiteSpace(ElementStyle es)
		{
			return ElementStyleLayout.StyleSpacing(es,SpacePart.Border | SpacePart.Margin | SpacePart.Padding,eStyleSide.Top);
		}

		/// <summary>
		/// Returns total white space for top side of the style. Whitespace is the space between the edge of the element and inner content of the element.
		/// </summary>
		/// <param name="es">Style to return white space for.</param>
		/// <returns></returns>
		public static int BottomWhiteSpace(ElementStyle es)
		{
			return ElementStyleLayout.StyleSpacing(es,SpacePart.Border | SpacePart.Margin | SpacePart.Padding,eStyleSide.Bottom);
		}

		/// <summary>
		/// Returns amount of spacing for specified style parts.
		/// </summary>
		/// <param name="es">Style to calculate spacing for.</param>
		/// <param name="part">Part of the style spacing is calculated for. Values can be combined.</param>
		/// <param name="side">Side of the style to use for calculation.</param>
		/// <returns></returns>
		public static int StyleSpacing(ElementStyle style, SpacePart part, eStyleSide side)
		{
            ElementStyle es = ElementStyleDisplay.GetElementStyle(style);
			int space=0;
			if((part & SpacePart.Margin)==SpacePart.Margin)
			{
				switch(side)
				{
					case eStyleSide.Bottom:
						space+=es.MarginBottom;
						break;
					case eStyleSide.Left:
						space+=es.MarginLeft;
						break;
					case eStyleSide.Right:
						space+=es.MarginRight;
						break;
					case eStyleSide.Top:
						space+=es.MarginTop;
						break;
				}
			}

			if((part & SpacePart.Padding)==SpacePart.Padding)
			{
				switch(side)
				{
					case eStyleSide.Bottom:
						space+=es.PaddingBottom;
						break;
					case eStyleSide.Left:
						space+=es.PaddingLeft;
						break;
					case eStyleSide.Right:
						space+=es.PaddingRight;
						break;
					case eStyleSide.Top:
						space+=es.PaddingTop;
						break;
				}
			}

			if((part & SpacePart.Border)==SpacePart.Border)
			{
				switch(side)
				{
					case eStyleSide.Bottom:
					{
						if(es.PaintBottomBorder)
							space+=es.BorderBottomWidth;
                        if (es.BorderBottom == StyleBorderType.Etched || es.BorderBottom == StyleBorderType.Double)
                            space += es.BorderBottomWidth;
						break;
					}
					case eStyleSide.Left:
					{
						if(es.PaintLeftBorder)
							space+=es.BorderLeftWidth;
                        if (es.BorderLeft == StyleBorderType.Etched || es.BorderLeft == StyleBorderType.Double)
                            space += es.BorderLeftWidth;
						break;
					}
					case eStyleSide.Right:
					{
						if(es.PaintRightBorder)
							space+=es.BorderRightWidth;
                        if (es.BorderRight == StyleBorderType.Etched || es.BorderRight == StyleBorderType.Double)
                            space += es.BorderRightWidth;
						break;
					}
					case eStyleSide.Top:
					{
						if(es.PaintTopBorder)
							space+=es.BorderTopWidth;
                        if (es.BorderTop == StyleBorderType.Etched || es.BorderTop == StyleBorderType.Double)
                            space += es.BorderTopWidth;
						break;
					}
				}
			}

			return space;
		}
	}
}
