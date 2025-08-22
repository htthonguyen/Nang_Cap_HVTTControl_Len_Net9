
using System;
using System.Collections.Generic;
using System.Text;

namespace HVTT.UI.Window.Forms.Editors
{
    public class HVTTTreeGridNodeCollection : System.Collections.Generic.IList<HVTTTreeGridNode>, System.Collections.IList
	{
        internal System.Collections.Generic.List<HVTTTreeGridNode> _list;
        internal HVTTTreeGridNode _owner;
        internal HVTTTreeGridNodeCollection(HVTTTreeGridNode owner)
		{
			this._owner = owner;
            this._list = new List<HVTTTreeGridNode>();
		}

		#region Public Members
        public void Add(HVTTTreeGridNode item)
		{
			// The row needs to exist in the child collection before the parent is notified.
			item._grid = this._owner._grid;

            bool hadChildren = this._owner.HasChildren;
			item._owner = this;

			this._list.Add(item);

			this._owner.AddChildNode(item);

            // if the owner didn't have children but now does (asserted) and it is sited update it
            if (!hadChildren && this._owner.IsSited)
            {
                this._owner._grid.InvalidateRow(this._owner.RowIndex);
            }
		}

        public HVTTTreeGridNode Add(string text)
        {
            HVTTTreeGridNode node = new HVTTTreeGridNode();
            this.Add(node);

            node.Cells[0].Value = text;
            return node;
        }

        public HVTTTreeGridNode Add(params object[] values)
        {
            HVTTTreeGridNode node = new HVTTTreeGridNode();
            this.Add(node);

            int cell = 0;

            if (values.Length > node.Cells.Count )
                throw new ArgumentOutOfRangeException("values");

            foreach (object o in values)
            {
                node.Cells[cell].Value = o;
                cell++;
            }
            return node;
        }

        public void Insert(int index, HVTTTreeGridNode item)
        {
            // The row needs to exist in the child collection before the parent is notified.
            item._grid = this._owner._grid;
            item._owner = this;

            this._list.Insert(index, item);

            this._owner.InsertChildNode(index, item);
        }

        public bool Remove(HVTTTreeGridNode item)
		{
			// The parent is notified first then the row is removed from the child collection.
			this._owner.RemoveChildNode(item);
			item._grid = null;
			return this._list.Remove(item);
		}

        public void RemoveAt(int index)
		{
            HVTTTreeGridNode row = this._list[index];

			// The parent is notified first then the row is removed from the child collection.
			this._owner.RemoveChildNode(row);
			row._grid = null;
			this._list.RemoveAt(index);
		}

        public void Clear()
		{
			// The parent is notified first then the row is removed from the child collection.
			this._owner.ClearNodes();
			this._list.Clear();
		}

        public int IndexOf(HVTTTreeGridNode item)
        {
            return this._list.IndexOf(item);
        }

        public HVTTTreeGridNode this[int index]
		{
			get
			{
				return this._list[index];
			}
			set
			{
				throw new Exception("The method or operation is not implemented.");
			}
		}

        public bool Contains(HVTTTreeGridNode item)
		{
			return this._list.Contains(item);
		}

        public void CopyTo(HVTTTreeGridNode[] array, int arrayIndex)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public int Count
		{
			get{ return this._list.Count; }
		}

        public bool IsReadOnly
		{
			get{ return false; }
		}
        #endregion

        #region IList Interface
        void System.Collections.IList.Remove(object value)
        {
            this.Remove(value as HVTTTreeGridNode);
        }


        int System.Collections.IList.Add(object value)
        {
            HVTTTreeGridNode item = value as HVTTTreeGridNode;
            this.Add(item);
            return item.Index;
        }

        void System.Collections.IList.RemoveAt(int index)
        {
            this.RemoveAt(index);
        }


        void System.Collections.IList.Clear()
        {
            this.Clear();
        }

        bool System.Collections.IList.IsReadOnly
		{
			get { return this.IsReadOnly;}
		}

		bool System.Collections.IList.IsFixedSize
		{
			get { return false; }
		}

        int System.Collections.IList.IndexOf(object item)
        {
            return this.IndexOf(item as HVTTTreeGridNode);
        }

        void System.Collections.IList.Insert(int index, object value)
        {
            this.Insert(index, value as HVTTTreeGridNode);
        }
        int System.Collections.ICollection.Count
        {
            get { return this.Count; }
        }
        bool System.Collections.IList.Contains(object value)
        {
            return this.Contains(value as HVTTTreeGridNode);
        }
        void System.Collections.ICollection.CopyTo(Array array, int index)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        object System.Collections.IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }



		#region IEnumerable<ExpandableRow> Members

        public IEnumerator<HVTTTreeGridNode> GetEnumerator()
		{
			return this._list.GetEnumerator();
		}

		#endregion


		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		#endregion
		#endregion

		#region ICollection Members

		bool System.Collections.ICollection.IsSynchronized
		{
			get { throw new Exception("The method or operation is not implemented."); }
		}

		object System.Collections.ICollection.SyncRoot
		{
			get { throw new Exception("The method or operation is not implemented."); }
		}

		#endregion
	}

}
