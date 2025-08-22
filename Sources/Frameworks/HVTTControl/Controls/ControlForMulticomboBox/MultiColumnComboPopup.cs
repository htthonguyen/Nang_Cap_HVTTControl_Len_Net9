using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace HVTT.UI.Window.Forms.Controls
{
	public delegate void AfterRowSelectEventHandler(object sender, DataRow SelectedRow,int SelectIndex);
	/// <summary>
	/// Summary description for MultiColumnComboPopup.
	/// </summary>
	internal class MultiColumnComboPopup : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private DataRow _mSelectedRow = null;
		private DataTable _mDataTable = null;
        private int _miSelectIndex = -1;
        private HVTTMultiComboBoxDisplayColumn[] _mDisplayColumns = null;
        
        private Boolean _mblnShowColumnHeader = true;
        private Boolean _mblnShowRowHeader = false;



        private DataGridView gd;

		public event AfterRowSelectEventHandler AfterRowSelectEvent; 
		
		
		public MultiColumnComboPopup()
		{
			InitializeComponent();
            _mDisplayColumns = null;
            //mCols = 4;
            //mRows = 0;
            //InitializeGridProperties();
		}

		public MultiColumnComboPopup(DataRow[] drows) {
			InitializeComponent();
            //SetDataRows(inputRows);
            //this.dataTable = inputRows[0].Table;
		}

		public MultiColumnComboPopup(DataTable dtable, DataRow selRow,HVTTMultiComboBoxDisplayColumn[] DisplayColumns) 
        {
			InitializeComponent();
			this._mDataTable = dtable;
			this._mSelectedRow = selRow;
            this._mDisplayColumns = DisplayColumns;
            Binding_Grid();
            Format_Grid();
		}
        public MultiColumnComboPopup(DataTable dtable, DataRow selRow, int SelectIndex, HVTTMultiComboBoxDisplayColumn[] DisplayColumns, Boolean ShowRowsHeader, Boolean ShowColumnsHeader)
        {
            InitializeComponent();
            this._mDataTable = dtable;
            this._mSelectedRow = selRow;
            this._mDisplayColumns = DisplayColumns;
            this._miSelectIndex = SelectIndex;
            _mblnShowColumnHeader = ShowColumnsHeader;
            _mblnShowRowHeader = ShowRowsHeader;
            Binding_Grid();
            Format_Grid();
        }
      
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gd = new HVTT.UI.Window.Forms.Controls.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).BeginInit();
            this.SuspendLayout();
            // 
            // gd
            // 
            this.gd.AllowEdit = true;
            this.gd.AllowUserToAddRows = false;
            this.gd.AllowUserToDeleteRows = false;
            this.gd.AutoHeaderNumber = true;
            this.gd.CodeLanguage = "";
            this.gd.ColKeys = null;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gd.DefaultCellStyle = dataGridViewCellStyle1;
            this.gd.DefaultValues = null;
            this.gd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gd.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gd.IndexArrayRowChange = new int[0];
            this.gd.IsChange = false;
            this.gd.KeyPressColumns = null;
            this.gd.Level = -1;
            this.gd.Location = new System.Drawing.Point(0, 0);
            this.gd.MultiSelect = false;
            this.gd.Name = "gd";
            this.gd.NotEmptyKey = null;
            this.gd.NumbericColumns = null;
            this.gd.ReadOnly = true;
            this.gd.ReadOnlyKey = null;
            this.gd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gd.Size = new System.Drawing.Size(288, 137);
            this.gd.SumaryColumns = null;
            this.gd.TabIndex = 0;
            this.gd.UpperCaseColumn = null;
            this.gd.UseEnterKey = false;
            this.gd.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gd_CellMouseDoubleClick);
            this.gd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MultiColumnComboPopup_KeyDown);
            // 
            // MultiColumnComboPopup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(288, 137);
            this.ControlBox = false;
            this.Controls.Add(this.gd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MultiColumnComboPopup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Deactivate += new System.EventHandler(this.MultiColumnComboPopup_Deactivate);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MultiColumnComboPopup_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gd)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


        protected override void OnLoad(EventArgs e)
        {
            this.Activate();
            base.OnLoad(e);
        }

		public DataTable Table
        {
			set
            {
				_mDataTable = value;
				if(_mDataTable == null)
					return;
			}
		}

		public DataRow SelectedRow
        {
			get
            {
				return _mSelectedRow;
			}
		}
        public HVTTMultiComboBoxDisplayColumn[] DisplayColumns
        {
            get
            {
                return _mDisplayColumns;
            }
            set
            {
                _mDisplayColumns = value;
            }
        }
       
       
        private void MultiColumnComboPopup_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MultiColumnComboPopup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataTable dt = gd.DataSource as DataTable;
                    if (dt != null && gd.CurrentRow != null && gd.CurrentRow.Index >= 0)
                    {
                        _mSelectedRow = dt.Rows[gd.CurrentRow.Index];
                        if (AfterRowSelectEvent != null)
                            AfterRowSelectEvent(this, dt.Rows[gd.CurrentRow.Index],gd.CurrentRow.Index);
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                HVTT.UI.Window.Forms.HVTTMessages.Show(ex);
            }
        }

        private void gd_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataTable dt = gd.DataSource as DataTable;
                if (dt != null && gd.CurrentRow != null && gd.CurrentRow.Index >= 0)
                {
                    _mSelectedRow = dt.Rows[gd.CurrentRow.Index];
                    if (AfterRowSelectEvent != null)
                        AfterRowSelectEvent(this, dt.Rows[gd.CurrentRow.Index],gd.CurrentRow.Index);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                HVTT.UI.Window.Forms.HVTTMessages.Show(ex);
            }
        }


        private void Format_Grid()
        {
           

            if (_mDisplayColumns == null)
                return;
            int iKey = -1;
            for (int i = 0; i < gd.Columns.Count; i++)
            {
                int iSearch = Search(gd.Columns[i].Name);
                if (iSearch >= 0)
                {
                    if (_mDisplayColumns[iSearch].IsKey)
                        iKey = iSearch;
                    gd.Columns[i].HeaderText = _mDisplayColumns[iSearch].ColumnText;
                    gd.Columns[i].DisplayIndex = _mDisplayColumns[iSearch].Index;
                    gd.Columns[i].Width = _mDisplayColumns[iSearch].Width;
                }
                else
                    gd.Columns[i].Visible = false;
            }
            if (_miSelectIndex >= 0 && iKey >= 0)
                gd.SetRecentCurentRow(_miSelectIndex, _mDisplayColumns[iKey].ColumnName);
        }
        private void Binding_Grid()
        {
            gd.DataSource = _mDataTable;
            gd.ColumnHeadersVisible = _mblnShowColumnHeader;
            gd.AutoHeaderNumber = _mblnShowRowHeader;
            gd.RowHeadersVisible = _mblnShowRowHeader;
        }
        private int FindKey()
        {
            if (_mDisplayColumns == null)
                return -1;
            for (int i = 0; i < _mDisplayColumns.Length; i++)
                if (_mDisplayColumns[i].IsKey)
                    return i;
            if (_mDisplayColumns.Length > 0)
                return 0;
            return -1;
        }
        private int Search(String ColumnName)
        {
            if (_mDisplayColumns == null)
                return -1;
            for (int i = 0; i < _mDisplayColumns.Length; i++)
                if (_mDisplayColumns[i].ColumnName == ColumnName)
                    return i;
            return -1;
        }   
	}
}
