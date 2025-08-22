using System;

namespace HVTT.UI.Window.Forms
{
	/// <summary>
	/// Summary description for HVTTResourcesAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Assembly)]
	public class HVTTResourcesAttribute:System.Attribute
	{
		private string m_NamespacePrefix="";
		public HVTTResourcesAttribute(string namespacePrefix)
		{
			m_NamespacePrefix=namespacePrefix;
		}

		public virtual string NamespacePrefix
		{
			get {return m_NamespacePrefix;}
		}
	}
}
