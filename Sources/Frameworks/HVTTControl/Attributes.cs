using System;

namespace HVTT.UI.Window.Forms
{
	[AttributeUsage(AttributeTargets.Property|AttributeTargets.Method|AttributeTargets.Field)]
	public class HVTTBrowsable : Attribute
	{
		public static readonly HVTTBrowsable Yes=new HVTTBrowsable(true);
		public static readonly HVTTBrowsable No=new HVTTBrowsable(false);
		public bool Browsable;
		public HVTTBrowsable(bool browsable)
		{
			this.Browsable = browsable;
		}
	}
}
