using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms.Editors
{
    public partial class HVTTCalendar : UserControl
    {
        public HVTTCalendar()
        {
            InitializeComponent();

        }

        #region Avarible
        Boolean bDesign = true;
        Boolean bIsClick = false;


        Color _mcHoverColor1 = Color.FromArgb(251, 230, 148);
        Color _mcHoverColor2 = Color.FromArgb(238, 149, 21);
        Color _mcForColorActive = Color.Black;
        Color _mcForColor = Color.Silver;

        Color _mcDefaultSelectBackDay = Color.White;
        Color _mcDefaultSelectBorderDay = Color.Transparent;
        Color _mcSelectBackDay = Color.FromArgb(192, 255, 192);
        Color _mcSelectBorderDay = Color.Transparent;

        int _miSelectDay = DateTime.Now.Day;
        int _miSelectMonth = DateTime.Now.Month;
        int _miSelectYear = DateTime.Now.Year;
        int _miSelectDayDefault = DateTime.Now.Day;
        int _miSelectMonthDefault = DateTime.Now.Month;
        int _miSelectYearDefault = DateTime.Now.Year;

        DateTime[] _mdBoldedDate = null;

        #endregion


        #region Property

        private int _miLivel = -1;

        public int Level
        {
            get
            {
                return _miLivel;
            }
            set
            {
                _miLivel = value;
            }
        }

        public DateTime ToDay
        {
            get
            {
                return new DateTime(_miSelectYearDefault, _miSelectMonthDefault, _miSelectDayDefault);
            }
        }
        public DateTime SelectDate
        {
            get
            {
                return new DateTime(_miSelectYear, _miSelectMonth, _miSelectDay);
            }
            set
            {
                _miSelectDay = value.Day;
                _miSelectMonth = value.Month;
                _miSelectYear = value.Year;

                FillYear(_miSelectYear);
                FillMonth(_miSelectMonth);
                FillDate(_miSelectYear, _miSelectMonth);
                if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
                {
                    SelectDay(_miSelectDayDefault, true);
                    if (_miSelectDay != _miSelectDayDefault)
                        SelectDay(_miSelectDay, false);
                }
                else
                    SelectDay(_miSelectDay, false);
            }
        }
        public DateTime[] BoldedDates
        {
            get
            {
                return _mdBoldedDate;
            }
            set
            {
                _mdBoldedDate = value;
                if (_mdBoldedDate != null)
                {
                    for (int i = 0; i < _mdBoldedDate.Length; i++)
                        BoldedDate(_mdBoldedDate[i]);
                }
            }
        }

        public Color HoverColor1
        {
            get
            {
                return _mcHoverColor1;
            }
            set
            {
                _mcHoverColor1 = value;
            }
        }
        public Color ForeColorActive
        {
            get
            {
                return _mcForColorActive;
            }
            set
            {
                _mcForColorActive = value;
            }
        }

        public Color HoverColor2
        {
            get
            {
                return _mcHoverColor2;
            }
            set
            {
                _mcHoverColor2 = value;
            }
        }

        #endregion

        #region Private Method
        private void FillYear(int iYear)
        {
            lblYear.Text = iYear.ToString();
        }
        private void ClearLableDate()
        {
            Control.ControlCollection c = pnDay.Controls;
            for (int i = 0; i < c.Count; i++)
            {
                if (c[i] is HVTT.UI.Window.Forms.Editors.HVTTLabelEditor)
                {
                    HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = c[i] as HVTT.UI.Window.Forms.Editors.HVTTLabelEditor;
                    if (lbl.Name != "lblYear" && lbl.Name != "lblMonth" && lbl.Name != "lblYearPreview" && lbl.Name != "lblYearNext" && lbl.Name != "lblMon" && lbl.Name != "lblTue" && lbl.Name != "lblWed" &&
                        lbl.Name != "lblThu" && lbl.Name != "lblFri" && lbl.Name != "lblSat" && lbl.Name != "lblSun")
                        pnDay.Controls.RemoveAt(i);
                }
            }
        }
        private void FillMonth(int iMonth)
        {
            switch (iMonth)
            {
                case 1:
                    lblMonth.Text = "January";
                    lblMonth.Description = "1";
                    break;
                case 2:
                    lblMonth.Text = "February";
                    lblMonth.Description = "2";
                    break;
                case 3:
                    lblMonth.Text = "March";
                    lblMonth.Description = "3";
                    break;
                case 4:
                    lblMonth.Text = "April";
                    lblMonth.Description = "4";
                    break;
                case 5:
                    lblMonth.Text = "May";
                    lblMonth.Description = "5";
                    break;
                case 6:
                    lblMonth.Text = "June";
                    lblMonth.Description = "6";
                    break;
                case 7:
                    lblMonth.Text = "July";
                    lblMonth.Description = "7";
                    break;
                case 8:
                    lblMonth.Text = "August";
                    lblMonth.Description = "8";
                    break;
                case 9:
                    lblMonth.Text = "September";
                    lblMonth.Description = "9";
                    break;
                case 10:
                    lblMonth.Text = "October";
                    lblMonth.Description = "10";
                    break;
                case 11:
                    lblMonth.Text = "November";
                    lblMonth.Description = "11";
                    break;
                case 12:
                    lblMonth.Text = "December";
                    lblMonth.Description = "12";
                    break;
            }
        }
        private void SelectDay(int iDay,Boolean bIsDefault)
        {
            Control.ControlCollection c = pnDay.Controls;
            for (int i = 0; i < c.Count; i++)
            {
                if (c[i] is HVTT.UI.Window.Forms.Editors.HVTTLabelEditor)
                {
                    HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = c[i] as HVTT.UI.Window.Forms.Editors.HVTTLabelEditor;
                    if (lbl.Name != "lblYear" && lbl.Name != "lblMonth" && lbl.Name != "lblYearPreview" && lbl.Name != "lblYearNext" && lbl.Name != "lblMon" && lbl.Name != "lblTue" && lbl.Name != "lblWed" &&
                        lbl.Name != "lblThu" && lbl.Name != "lblFri" && lbl.Name != "lblSat" && lbl.Name != "lblSun")
                    {
                        int id = Convert.ToInt32(lbl.Text);
                        if (id == iDay && lbl.ForeColor == _mcForColorActive)
                        {
                            if (bIsDefault)
                            {
                                lbl.BackColor = _mcDefaultSelectBackDay;
                                lbl.BackColor1 = _mcDefaultSelectBackDay;
                                lbl.BackColor2 = _mcDefaultSelectBackDay;
                                lbl.BorderColor = _mcDefaultSelectBorderDay;
                                _miSelectDayDefault = iDay;
                            }
                            else
                            {
                                lbl.BackColor = _mcSelectBackDay;
                                lbl.BackColor1 = _mcSelectBackDay;
                                lbl.BackColor2 = _mcSelectBackDay;
                                lbl.BorderColor = _mcSelectBorderDay;
                                _miSelectDay = iDay;

                                lbl.Description = "Click";
                                bIsClick = true;
                            }
                        }
                    }
                }
            }
        }
        private void BoldedDate(DateTime d)
        {
            Control.ControlCollection c = pnDay.Controls;
            for (int i = 0; i < c.Count; i++)
            {
                if (c[i] is HVTT.UI.Window.Forms.Editors.HVTTLabelEditor)
                {
                    HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = c[i] as HVTT.UI.Window.Forms.Editors.HVTTLabelEditor;
                    if (lbl.Name != "lblYear" && lbl.Name != "lblMonth" && lbl.Name != "lblYearPreview" && lbl.Name != "lblYearNext" && lbl.Name != "lblMon" && lbl.Name != "lblTue" && lbl.Name != "lblWed" &&
                        lbl.Name != "lblThu" && lbl.Name != "lblFri" && lbl.Name != "lblSat" && lbl.Name != "lblSun")
                    {
                        int id = Convert.ToInt32(lbl.Text);
                        int iMonth = Convert.ToInt32(lblMonth.Description);
                        int iYear = Convert.ToInt32(lblYear.Text);
                        if (id == d.Day && iMonth == d.Month && iYear == d.Year)
                        {
                            lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        }
                        //else
                        //    lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                }
            }
        }
        private int GetPositionDayOfWeek(String sDayOfWeek)
        {
            switch (sDayOfWeek.ToUpper())
            {
                case "MONDAY":
                    return 0;
                case "TUESDAY":
                    return 1;
                case "WEDNESDAY":
                    return 2;
                case "THURSDAY":
                    return 3;
                case "FRIDAY":
                    return 4;
                case "SATURDAY":
                    return 5;
                case "SUNDAY":
                    return 6;
            }
            return -1;
        }
       
        private void FillDate(int iYear, int iMonth)
        {
            pnDay.Controls.Clear();

            int iDayInMonth = DateTime.DaysInMonth(iYear, iMonth);
            int iHeight = 0;
            int iWith = 2;
            int iCount = 1;
            Boolean bFlag = false;


            DateTime d = new DateTime(iYear, iMonth, 1);
            int iPosition = GetPositionDayOfWeek(d.DayOfWeek.ToString());
            if (iPosition >= 0)
            {
                int iMonthPreview = 0;
                int iYearPreview = 0;

                if (iMonth == 1)
                {
                    iMonthPreview = 12;
                    iYearPreview = iYear - 1;
                }
                else
                {
                    iMonthPreview = iMonth - 1;
                    iYearPreview = iYear;
                }


                int iDayInMonthPreview = DateTime.DaysInMonth(iYearPreview, iMonthPreview);
                int iCountPreview = iDayInMonthPreview - iPosition;

                for (int k = 0; k < iPosition; k++)
                {
                    HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = new HVTT.UI.Window.Forms.Editors.HVTTLabelEditor();
                    lbl.BackColor = System.Drawing.Color.Transparent;
                    lbl.BackColor1 = System.Drawing.Color.Transparent;
                    lbl.BackColor2 = System.Drawing.Color.Transparent;
                    lbl.BorderColor = System.Drawing.Color.Transparent;
                    lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lbl.Location = new System.Drawing.Point(iWith, iHeight);
                    lbl.Name = "lbl";
                    lbl.Size = new System.Drawing.Size(26, 16);
                    lbl.Text = (iCountPreview + 1).ToString();
                    lbl.ForeColor = _mcForColor;
                    lbl.Value = "Pr";

                    lbl.MouseMove += new MouseEventHandler(lbl_MouseMove);
                    lbl.MouseLeave += new System.EventHandler(lbl_MouseLeave);
                    lbl.Click += new System.EventHandler(lbl_Click);

                    iWith = iWith + 28;
                    pnDay.Controls.Add(lbl);
                    iCountPreview++;
                }
            }

            Boolean bFlagPosition = false;
            for (int i = 0; i < 6; i++)
            {
                if (bFlagPosition)
                    iWith = 2;
                for (int j = bFlagPosition == true ? 0 : iPosition; j < 7; j++)
                {
                    bFlagPosition = true;
                    HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = new HVTT.UI.Window.Forms.Editors.HVTTLabelEditor();
                    if (iCount <= iDayInMonth)
                    {
                        lbl.Text = iCount.ToString();
                    }
                    else
                    {
                        iCount = 1;
                        lbl.Text = iCount.ToString();
                        bFlag = true;
                    }
                    if (bFlag)
                    {
                        lbl.ForeColor = _mcForColor;
                        lbl.Value = "Ne";
                    }
                    else
                        lbl.ForeColor = _mcForColorActive;


                    lbl.BackColor = System.Drawing.Color.Transparent;
                    lbl.BackColor1 = System.Drawing.Color.Transparent;
                    lbl.BackColor2 = System.Drawing.Color.Transparent;
                    lbl.BorderColor = System.Drawing.Color.Transparent;
                    lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lbl.Location = new System.Drawing.Point(iWith, iHeight);
                    lbl.Name = "lbl";
                    lbl.Size = new System.Drawing.Size(26, 16);

                    lbl.MouseMove += new MouseEventHandler(lbl_MouseMove);
                    lbl.MouseLeave += new System.EventHandler(lbl_MouseLeave);
                    lbl.Click += new System.EventHandler(lbl_Click);

                    iWith = iWith + 28;
                    pnDay.Controls.Add(lbl);
                    iCount++;
                }
                iHeight = iHeight + 16;
            }
            if (_mdBoldedDate != null)
            {
                for(int t = 0;t<_mdBoldedDate.Length;t++)
                {
                    BoldedDate(_mdBoldedDate[t]);
                }
            }
        }
       
        private int CountLableActive()
        {
            int iCount = 0;
            foreach (Control c in pnDay.Controls)
            {
                if (c is HVTT.UI.Window.Forms.Editors.HVTTLabelEditor)
                {
                    HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = c as HVTT.UI.Window.Forms.Editors.HVTTLabelEditor;
                    if (lbl.Description.Trim() != "")
                        iCount++;
                }
            }
            return iCount;
        }
        private int FindLableActive()
        {
            Control.ControlCollection c = pnDay.Controls;
            for (int i = 0; i < c.Count; i++)
            {
                if (c[i] is HVTT.UI.Window.Forms.Editors.HVTTLabelEditor)
                {
                    HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = c[i] as HVTT.UI.Window.Forms.Editors.HVTTLabelEditor;
                    if (lbl.Description.Trim() != "")
                        return i;
                }
            }
            return -1;
        }
        #endregion

        #region Event

        public event EventHandler DateClick;
        public event EventHandler DateChanged;
        public event EventHandler MonthChanged;
        public event EventHandler YearChanged;


        #region MenuClick
        private void ctmJanuary_Click(object sender, EventArgs e)
        {
            int iSelectMonthPre = _miSelectMonth;
           
            lblMonth.Description = "1";
            lblMonth.Text = "January";
            _miSelectMonth = 1;

            
            int i = DateTime.DaysInMonth(_miSelectYear, _miSelectMonth);
            while (_miSelectDay > i)
                _miSelectDay--;

            FillYear(_miSelectYear);
            FillMonth(_miSelectMonth);
            FillDate(_miSelectYear, _miSelectMonth);
            if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
            {
                SelectDay(_miSelectDayDefault, true);
                if (_miSelectDay != _miSelectDayDefault)
                    SelectDay(_miSelectDay, false);
            }
            else
                SelectDay(_miSelectDay, false);
            bDesign = false;

            if (iSelectMonthPre != 1)
            {
                if (MonthChanged != null)
                    MonthChanged(this, e);

                if (DateChanged != null)
                    DateChanged(this, e);
            }

           
        }

        private void ctmFebruary_Click(object sender, EventArgs e)
        {
            int iSelectMonthPre = _miSelectMonth;


            _miSelectMonth = 2;
            lblMonth.Description = "2";
            lblMonth.Text = "February";

           
            int i = DateTime.DaysInMonth(_miSelectYear, _miSelectMonth);
            while (_miSelectDay > i)
                _miSelectDay--;

            FillYear(_miSelectYear);
            FillMonth(_miSelectMonth);
            FillDate(_miSelectYear, _miSelectMonth);
            if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
            {
                SelectDay(_miSelectDayDefault, true);
                if (_miSelectDay != _miSelectDayDefault)
                    SelectDay(_miSelectDay, false);
            }
            else
                SelectDay(_miSelectDay, false);
            bDesign = false;

            if (iSelectMonthPre != 2)
            {
                if (MonthChanged != null)
                    MonthChanged(this, e);
                if (DateChanged != null)
                    DateChanged(this, e);
            }

        }

        private void ctmMarch_Click(object sender, EventArgs e)
        {
            int iSelectMonthPre = _miSelectMonth;

            _miSelectMonth = 3;
            lblMonth.Description = "3";
            lblMonth.Text = "March";

            int i = DateTime.DaysInMonth(_miSelectYear, _miSelectMonth);
            while (_miSelectDay > i)
                _miSelectDay--;

            FillYear(_miSelectYear);
            FillMonth(_miSelectMonth);
            FillDate(_miSelectYear, _miSelectMonth);
            if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
            {
                SelectDay(_miSelectDayDefault, true);
                if (_miSelectDay != _miSelectDayDefault)
                    SelectDay(_miSelectDay, false);
            }
            else
                SelectDay(_miSelectDay, false);
            bDesign = false;

            if (iSelectMonthPre != 3)
            {
                if (MonthChanged != null)
                    MonthChanged(this, e);

                if (DateChanged != null)
                    DateChanged(this, e);
            }

        }

        private void ctmApril_Click(object sender, EventArgs e)
        {
            int iSelectMonthPre = _miSelectMonth;

            _miSelectMonth = 4;
            lblMonth.Description = "4";
            lblMonth.Text = "April";
            

            int i = DateTime.DaysInMonth(_miSelectYear, _miSelectMonth);
            while (_miSelectDay > i)
                _miSelectDay--;

            FillYear(_miSelectYear);
            FillMonth(_miSelectMonth);
            FillDate(_miSelectYear, _miSelectMonth);
            if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
            {
                SelectDay(_miSelectDayDefault, true);
                if (_miSelectDay != _miSelectDayDefault)
                    SelectDay(_miSelectDay, false);
            }
            else
                SelectDay(_miSelectDay, false);
            bDesign = false;

            if (iSelectMonthPre != 4)
            {
                if (MonthChanged != null)
                    MonthChanged(this, e);
                if (DateChanged != null)
                {
                    DateChanged(this, e);
                }
            }
        }

        private void ctmMay_Click(object sender, EventArgs e)
        {
            int iSelectMonthPre = _miSelectMonth;
           
            _miSelectMonth = 5;
            lblMonth.Description = "5";
            lblMonth.Text = "May";

           

            int i = DateTime.DaysInMonth(_miSelectYear, _miSelectMonth);
            while (_miSelectDay > i)
                _miSelectDay--;

            FillYear(_miSelectYear);
            FillMonth(_miSelectMonth);
            FillDate(_miSelectYear, _miSelectMonth);
            if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
            {
                SelectDay(_miSelectDayDefault, true);
                if (_miSelectDay != _miSelectDayDefault)
                    SelectDay(_miSelectDay, false);
            }
            else
                SelectDay(_miSelectDay, false);
            bDesign = false;

            if (iSelectMonthPre != 5)
            {
                if (MonthChanged != null)
                    MonthChanged(this, e);
                if (DateChanged != null)
                    DateChanged(this, e);
            }
        }

        private void ctmJune_Click(object sender, EventArgs e)
        {
            int iSelectMonthPre = _miSelectMonth;

            _miSelectMonth = 6;
            lblMonth.Description = "6";
            lblMonth.Text = "June";

           
            int i = DateTime.DaysInMonth(_miSelectYear, _miSelectMonth);
            while (_miSelectDay > i)
                _miSelectDay--;

            FillYear(_miSelectYear);
            FillMonth(_miSelectMonth);
            FillDate(_miSelectYear, _miSelectMonth);
            if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
            {
                SelectDay(_miSelectDayDefault, true);
                if (_miSelectDay != _miSelectDayDefault)
                    SelectDay(_miSelectDay, false);
            }
            else
                SelectDay(_miSelectDay, false);
            bDesign = false;

            if (iSelectMonthPre != 6)
            {
                if (MonthChanged != null)
                    MonthChanged(this, e);
                if (DateChanged != null)
                    DateChanged(this, e);
            }
        }

        private void cmtJuly_Click(object sender, EventArgs e)
        {
            int iSelectMonthPre = _miSelectMonth;
            
            _miSelectMonth = 7;
            lblMonth.Description = "7";
            lblMonth.Text = "July";
          

            int i = DateTime.DaysInMonth(_miSelectYear, _miSelectMonth);
            while (_miSelectDay > i)
                _miSelectDay--;

            FillYear(_miSelectYear);
            FillMonth(_miSelectMonth);
            FillDate(_miSelectYear, _miSelectMonth);
            if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
            {
                SelectDay(_miSelectDayDefault, true);
                if (_miSelectDay != _miSelectDayDefault)
                    SelectDay(_miSelectDay, false);
            }
            else
                SelectDay(_miSelectDay, false);
            bDesign = false;

            if (iSelectMonthPre != 7)
            {
                if (MonthChanged != null)
                    MonthChanged(this, e);
                if (DateChanged != null)
                    DateChanged(this, e);
            }
        }

        private void ctmAugust_Click(object sender, EventArgs e)
        {
            int iSelectMonthPre = _miSelectMonth;
            

            _miSelectMonth = 8;
            lblMonth.Description = "8";
            lblMonth.Text = "August";
            
            int i = DateTime.DaysInMonth(_miSelectYear, _miSelectMonth);
            while (_miSelectDay > i)
                _miSelectDay--;

            FillYear(_miSelectYear);
            FillMonth(_miSelectMonth);
            FillDate(_miSelectYear, _miSelectMonth);
            if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
            {
                SelectDay(_miSelectDayDefault, true);
                if (_miSelectDay != _miSelectDayDefault)
                    SelectDay(_miSelectDay, false);
            }
            else
                SelectDay(_miSelectDay, false);
            bDesign = false;

            if (iSelectMonthPre != 8)
            {
                if (MonthChanged != null)
                    MonthChanged(this, e);
                if (DateChanged != null)
                    DateChanged(this, e);
            }
        }

        private void cmtSeptember_Click(object sender, EventArgs e)
        {
            int iSelectMonthPre = _miSelectMonth;
            _miSelectMonth = 9;
            lblMonth.Description = "9";
            lblMonth.Text = "September";

            
            int i = DateTime.DaysInMonth(_miSelectYear, _miSelectMonth);
            while (_miSelectDay > i)
                _miSelectDay--;

            FillYear(_miSelectYear);
            FillMonth(_miSelectMonth);
            FillDate(_miSelectYear, _miSelectMonth);
            if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
            {
                SelectDay(_miSelectDayDefault, true);
                if (_miSelectDay != _miSelectDayDefault)
                    SelectDay(_miSelectDay, false);
            }
            else
                SelectDay(_miSelectDay, false);
            bDesign = false;

            if (iSelectMonthPre != 9)
            {
                if (MonthChanged != null)
                    MonthChanged(this, e);
                if (DateChanged != null)
                    DateChanged(this, e);
            }

        }

        private void cmtOctober_Click(object sender, EventArgs e)
        {
            int iSelectMonthPre = _miSelectMonth;


            _miSelectMonth = 10;
            lblMonth.Description = "10";
            lblMonth.Text = "October";


            int i = DateTime.DaysInMonth(_miSelectYear, _miSelectMonth);
            while (_miSelectDay > i)
                _miSelectDay--;

            FillYear(_miSelectYear);
            FillMonth(_miSelectMonth);
            FillDate(_miSelectYear, _miSelectMonth);
            if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
            {
                SelectDay(_miSelectDayDefault, true);
                if (_miSelectDay != _miSelectDayDefault)
                    SelectDay(_miSelectDay, false);
            }
            else
                SelectDay(_miSelectDay, false);
            bDesign = false;


            if (iSelectMonthPre != 10)
            {
                if (MonthChanged != null)
                    MonthChanged(this, e);
                if (DateChanged != null)
                    DateChanged(this, e);
            }
        }

        private void ctmNovember_Click(object sender, EventArgs e)
        {
            int iSelectMonthPre = _miSelectMonth;

            _miSelectMonth = 11;
            lblMonth.Description = "11";
            lblMonth.Text = "November";

           

            int i = DateTime.DaysInMonth(_miSelectYear, _miSelectMonth);
            while (_miSelectDay > i)
                _miSelectDay--;

            FillYear(_miSelectYear);
            FillMonth(_miSelectMonth);
            FillDate(_miSelectYear, _miSelectMonth);
            if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
            {
                SelectDay(_miSelectDayDefault, true);
                if (_miSelectDay != _miSelectDayDefault)
                    SelectDay(_miSelectDay, false);
            }
            else
                SelectDay(_miSelectDay, false);
            bDesign = false;

            if (iSelectMonthPre != 11)
            {
                if (MonthChanged != null)
                    MonthChanged(this, e);

                if (DateChanged != null)
                    DateChanged(this, e);
            }
        }

        private void ctmDecember_Click(object sender, EventArgs e)
        {
            int iSelectMonthPre = _miSelectMonth;


            _miSelectMonth = 12;
            lblMonth.Description = "12";
            lblMonth.Text = "December";

          

            int i = DateTime.DaysInMonth(_miSelectYear, _miSelectMonth);
            while (_miSelectDay > i)
                _miSelectDay--;

            FillYear(_miSelectYear);
            FillMonth(_miSelectMonth);
            FillDate(_miSelectYear, _miSelectMonth);
            if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
            {
                SelectDay(_miSelectDayDefault, true);
                if (_miSelectDay != _miSelectDayDefault)
                    SelectDay(_miSelectDay, false);
            }
            else
                SelectDay(_miSelectDay, false);
            bDesign = false;

            if (iSelectMonthPre != 12)
            {
                if (MonthChanged != null)
                    MonthChanged(this, e);
                if (DateChanged != null)
                    DateChanged(this, e);
            }
        }

        #endregion


        private void lbl_MouseMove(object sender, MouseEventArgs e)
        {
            HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = (HVTT.UI.Window.Forms.Editors.HVTTLabelEditor)sender;
            if (!bIsClick && lbl.Description.Trim() == "" && Convert.ToInt32(lbl.Text) != _miSelectDayDefault && Convert.ToInt32(lbl.Text) != _miSelectDay)
            {

                lbl.BackColor = System.Drawing.Color.Transparent;
                lbl.BackColor1 = _mcHoverColor1;
                lbl.BackColor2 = _mcHoverColor2;
                lbl.BorderColor = System.Drawing.Color.Red;
            }
        }
        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = (HVTT.UI.Window.Forms.Editors.HVTTLabelEditor)sender;
            if (!bIsClick && lbl.Description.Trim() == "" && Convert.ToInt32(lbl.Text) != _miSelectDayDefault && Convert.ToInt32(lbl.Text) != _miSelectDay)
            {

                lbl.BackColor = System.Drawing.Color.Transparent;
                lbl.BackColor1 = System.Drawing.Color.Transparent;
                lbl.BackColor2 = System.Drawing.Color.Transparent;
                lbl.BorderColor = System.Drawing.Color.Transparent;
               
            }
            bIsClick = false;
           
        }
        private void lbl_Click(object sender, EventArgs e)
        {
            HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = (HVTT.UI.Window.Forms.Editors.HVTTLabelEditor)sender;
            int i = FindLableActive();
            if (i >= 0)
            {

                HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl1 = pnDay.Controls[i] as HVTT.UI.Window.Forms.Editors.HVTTLabelEditor;
                lbl1.BackColor = System.Drawing.Color.Transparent;
                lbl1.BackColor1 = System.Drawing.Color.Transparent;
                lbl1.BackColor2 = System.Drawing.Color.Transparent;
                lbl1.BorderColor = System.Drawing.Color.Transparent;
                lbl1.Description = "";
            }
            _miSelectDay = Convert.ToInt32(lbl.Text);
            if (lbl.Value.Trim() == "Pr")
            {
                
                if (_miSelectMonth == 1)
                {
                    _miSelectYear--;
                    _miSelectMonth = 12;

                    if (YearChanged != null)
                        YearChanged(this, e);
                }
                else
                {
                    _miSelectMonth--;
                }
                FillYear(_miSelectYear);
                FillMonth(_miSelectMonth);
                FillDate(_miSelectYear, _miSelectMonth);
                if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
                {
                    SelectDay(_miSelectDayDefault, true);
                    if (_miSelectDay != _miSelectDayDefault)
                        SelectDay(_miSelectDay, false);
                }
                else
                    SelectDay(_miSelectDay, false);

                if (MonthChanged != null)
                    MonthChanged(this, e);
          
            }
            else if (lbl.Value.Trim() == "Ne")
            {
                
                if (_miSelectMonth == 12)
                {
                    _miSelectYear++;
                    _miSelectMonth = 1;
                    if (YearChanged != null)
                        YearChanged(this, e);
                }
                else
                {
                    _miSelectMonth++;
                }
                FillYear(_miSelectYear);
                FillMonth(_miSelectMonth);
                FillDate(_miSelectYear, _miSelectMonth);
                if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
                {
                    SelectDay(_miSelectDayDefault, true);
                    if (_miSelectDay != _miSelectDayDefault)
                        SelectDay(_miSelectDay, false);
                }
                else
                    SelectDay(_miSelectDay, false);

                if (MonthChanged != null)
                    MonthChanged(this, e);
                
            }
            else
            {
                if (Convert.ToInt32(lbl.Text) == _miSelectDayDefault && _miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
                {
                    lbl.BackColor = _mcDefaultSelectBackDay;
                    lbl.BackColor1 = _mcDefaultSelectBackDay;
                    lbl.BackColor2 = _mcDefaultSelectBackDay;
                    lbl.BorderColor = _mcDefaultSelectBorderDay;
                    _miSelectDay = _miSelectDayDefault;
                }
                else
                {
                    lbl.BackColor = _mcSelectBackDay;//System.Drawing.Color.FromArgb(255, 224, 192);
                    lbl.BackColor1 = _mcSelectBackDay;//System.Drawing.Color.FromArgb(255, 224, 192);
                    lbl.BackColor2 = _mcSelectBackDay;//System.Drawing.Color.FromArgb(255, 224, 192);
                    lbl.BorderColor = _mcSelectBorderDay;//System.Drawing.Color.FromArgb(0, 192, 0);
                    lbl.Description = "Click";
                    bIsClick = true;
                }
            }
            bDesign = false;

            if (DateClick != null)
                DateClick(this, e);

            if (DateChanged != null)
                DateChanged(this, e);
        }



        private void lblYearNext_MouseMove(object sender, MouseEventArgs e)
        {
            HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = (HVTT.UI.Window.Forms.Editors.HVTTLabelEditor)sender;
            lbl.BackColor = System.Drawing.Color.Transparent;
            lbl.BackColor1 = _mcHoverColor1;
            lbl.BackColor2 = _mcHoverColor2;
        }
        private void lblYearNext_MouseLeave(object sender, EventArgs e)
        {
            HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = (HVTT.UI.Window.Forms.Editors.HVTTLabelEditor)sender;
            lbl.BackColor = System.Drawing.Color.Transparent;
            lbl.BackColor1 = System.Drawing.Color.Transparent;
            lbl.BackColor2 = System.Drawing.Color.Transparent;
        }
        private void lblYearNext_Click(object sender, EventArgs e)
        {
            _miSelectYear = Convert.ToInt32(lblYear.Text) + 1;
            int iDays = DateTime.DaysInMonth(_miSelectYear, _miSelectMonth);
            while (_miSelectDay > iDays)
                _miSelectDay--;

            FillYear(_miSelectYear);
            FillMonth(_miSelectMonth);
            FillDate(_miSelectYear, _miSelectMonth);
            if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
            {
                SelectDay(_miSelectDayDefault, true);
                if (_miSelectDay != _miSelectDayDefault)
                    SelectDay(_miSelectDay, false);
            }
            else
                SelectDay(_miSelectDay, false);
           
            bDesign = false;
        }

        private void lblYearPreview_MouseMove(object sender, MouseEventArgs e)
        {
            HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = (HVTT.UI.Window.Forms.Editors.HVTTLabelEditor)sender;
            lbl.BackColor = System.Drawing.Color.Transparent;
            lbl.BackColor1 = _mcHoverColor1;
            lbl.BackColor2 = _mcHoverColor2;
        }
        private void lblYearPreview_MouseLeave(object sender, EventArgs e)
        {
            HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = (HVTT.UI.Window.Forms.Editors.HVTTLabelEditor)sender;
            lbl.BackColor = System.Drawing.Color.Transparent;
            lbl.BackColor1 = System.Drawing.Color.Transparent;
            lbl.BackColor2 = System.Drawing.Color.Transparent;
        }
        private void lblYearPreview_Click(object sender, EventArgs e)
        {
            _miSelectYear = Convert.ToInt32(lblYear.Text) - 1;
            _miSelectYear = Convert.ToInt32(lblYear.Text) + 1;
            int iDays = DateTime.DaysInMonth(_miSelectYear, _miSelectMonth);
            while (_miSelectDay > iDays)
                _miSelectDay--;

            FillYear(_miSelectYear);
            FillMonth(_miSelectMonth);
            FillDate(_miSelectYear, _miSelectMonth);
            if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
            {
                SelectDay(_miSelectDayDefault, true);
                if (_miSelectDay != _miSelectDayDefault)
                    SelectDay(_miSelectDay, false);
            }
            else
                SelectDay(_miSelectDay, false);
           
            bDesign = false;
        }

        private void lblMonthNext_MouseMove(object sender, MouseEventArgs e)
        {
            HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = (HVTT.UI.Window.Forms.Editors.HVTTLabelEditor)sender;
            lbl.BackColor = System.Drawing.Color.Transparent;
            lbl.BackColor1 = _mcHoverColor1;
            lbl.BackColor2 = _mcHoverColor2;
        }
        private void lblMonthNext_MouseLeave(object sender, EventArgs e)
        {
            HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = (HVTT.UI.Window.Forms.Editors.HVTTLabelEditor)sender;
            lbl.BackColor = System.Drawing.Color.Transparent;
            lbl.BackColor1 = System.Drawing.Color.Transparent;
            lbl.BackColor2 = System.Drawing.Color.Transparent;
        }
        private void lblMonthNext_Click(object sender, EventArgs e)
        {
           
            if (_miSelectMonth == 12)
            {
                _miSelectMonth = 1;
                _miSelectYear++;

                if (YearChanged != null)
                    YearChanged(this, e);
            }
            else
            {
                _miSelectMonth++;
                int iDays = DateTime.DaysInMonth(_miSelectYear, _miSelectMonth);
                while (_miSelectDay > iDays)
                    _miSelectDay--;
            }

            FillYear(_miSelectYear);
            FillMonth(_miSelectMonth);
            FillDate(_miSelectYear, _miSelectMonth);
            if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
            {
                SelectDay(_miSelectDayDefault, true);
                if (_miSelectDay != _miSelectDayDefault)
                    SelectDay(_miSelectDay, false);
            }
            else
                SelectDay(_miSelectDay, false);
           
            bDesign = false;

            if (MonthChanged != null)
                MonthChanged(this, e);

            if (DateChanged != null)
                DateChanged(this, e);
        }

        private void lblMonthPreview_MouseMove(object sender, MouseEventArgs e)
        {
            HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = (HVTT.UI.Window.Forms.Editors.HVTTLabelEditor)sender;
            lbl.BackColor = System.Drawing.Color.Transparent;
            lbl.BackColor1 = _mcHoverColor1;
            lbl.BackColor2 = _mcHoverColor2;
        }
        private void lblMonthPreview_MouseLeave(object sender, EventArgs e)
        {
            HVTT.UI.Window.Forms.Editors.HVTTLabelEditor lbl = (HVTT.UI.Window.Forms.Editors.HVTTLabelEditor)sender;
            lbl.BackColor = System.Drawing.Color.Transparent;
            lbl.BackColor1 = System.Drawing.Color.Transparent;
            lbl.BackColor2 = System.Drawing.Color.Transparent;
        }
        private void lblMonthPreview_Click(object sender, EventArgs e)
        {
            
            if (_miSelectMonth == 1)
            {
                _miSelectMonth = 12;
                _miSelectYear--;


                if (YearChanged != null)
                    YearChanged(this, e);
            }
            else
            {
                _miSelectMonth--;
                int iDays = DateTime.DaysInMonth(_miSelectYear, _miSelectMonth);
                while (_miSelectDay > iDays)
                    _miSelectDay--;
            }

            FillYear(_miSelectYear);
            FillMonth(_miSelectMonth);
            FillDate(_miSelectYear, _miSelectMonth);
            if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
            {
                SelectDay(_miSelectDayDefault, true);
                if (_miSelectDay != _miSelectDayDefault)
                    SelectDay(_miSelectDay, false);
            }
            else
                SelectDay(_miSelectDay, false);
          
            bDesign = false;

            if (MonthChanged != null)
                MonthChanged(this, e);

            if (DateChanged != null)
                DateChanged(this, e);
        }


        private void HVTTCalendar_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(198, 144);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            

            //FillYear(DateTime.Now.Year);
            //FillMonth(DateTime.Now.Month);
            //FillDate(DateTime.Now.Year, DateTime.Now.Month);
            //SelectDay(DateTime.Now.Day);

            base.OnPaint(e);
        }

        private void pnDay_Paint(object sender, PaintEventArgs e)
        {
            if (bDesign)
            {
                FillYear(_miSelectYear);
                FillMonth(_miSelectMonth);
                FillDate(_miSelectYear, _miSelectMonth);

                if (_miSelectMonth == _miSelectMonthDefault && _miSelectYear == _miSelectYearDefault)
                {
                    SelectDay(_miSelectDayDefault, true);
                    if (_miSelectDay != _miSelectDayDefault)
                        SelectDay(_miSelectDay, false);
                }
                else
                    SelectDay(_miSelectDay, false);
                bDesign = false;
            }
        }
        #endregion


        #region Classes
        //public class ColorStyles
        //{
        //    Color _mcHoverColor1 = Color.FromArgb(251, 230, 148);
        //    Color _mcHoverColor2 = Color.FromArgb(238, 149, 21);
        //    Color _mcForColorActive = Color.Black;
        //    Color _mcForColor = Color.Silver;

        //    Color _mcDefaultSelectBackDay = Color.White;
        //    Color _mcDefaultSelectBorderDay = Color.Transparent;
        //    Color _mcSelectBackDay = Color.FromArgb(192, 255, 192);
        //    Color _mcSelectBorderDay = Color.Transparent;
        //}
        #endregion




    }
}
