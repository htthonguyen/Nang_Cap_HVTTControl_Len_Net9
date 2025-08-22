
using System;
using System.Collections.Generic;
using System.Text;

namespace HVTT.UI.Window.Forms.Editors
{
	public class HVTTTreeGridNodeEventBase
	{
        private HVTTTreeGridNode _node;

        public HVTTTreeGridNodeEventBase(HVTTTreeGridNode node)
		{
			this._node = node;
		}

        public HVTTTreeGridNode Node
		{
			get { return _node; }
		}
	}
	public class CollapsingEventArgs : System.ComponentModel.CancelEventArgs
	{
        private HVTTTreeGridNode _node;

		private CollapsingEventArgs() { }
        public CollapsingEventArgs(HVTTTreeGridNode node)
			: base()
		{
			this._node = node;
		}
        public HVTTTreeGridNode Node
		{
			get { return _node; }
		}

	}
    public class CollapsedEventArgs : HVTTTreeGridNodeEventBase
	{
        public CollapsedEventArgs(HVTTTreeGridNode node)
			: base(node)
		{
		}
	}

	public class ExpandingEventArgs:System.ComponentModel.CancelEventArgs
	{
        private HVTTTreeGridNode _node;

		private ExpandingEventArgs() { }
        public ExpandingEventArgs(HVTTTreeGridNode node)
            : base()
		{
			this._node = node;
		}
        public HVTTTreeGridNode Node
		{
			get { return _node; }
		}

	}
    public class ExpandedEventArgs : HVTTTreeGridNodeEventBase
	{
        public ExpandedEventArgs(HVTTTreeGridNode node)
            : base(node)
		{
		}
	}

	public delegate void ExpandingEventHandler(object sender, ExpandingEventArgs e);
	public delegate void ExpandedEventHandler(object sender, ExpandedEventArgs e);

	public delegate void CollapsingEventHandler(object sender, CollapsingEventArgs e);
	public delegate void CollapsedEventHandler(object sender, CollapsedEventArgs e);

}
