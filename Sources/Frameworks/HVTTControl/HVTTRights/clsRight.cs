using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HVTT.UI.Window.Forms.HVTTRights
{
    public class clsRight
    {
        public Boolean Watch { get; set; }
        public Boolean Save { get; set; }
        public Boolean Delete { get; set; }
        public Boolean Import { get; set; }
        public Boolean Export { get; set; }
        public Boolean Print { get; set; }
        public Boolean Release { get; set; }
        public Boolean UnRelease { get; set; }
    }

    class clsRightMethod
    {
        public static clsRight FillData(DataRow R)
        {
            return new clsRight()
            {
                Delete = Convert.ToBoolean(R["RDelete"].ToString().Trim() == "" ? false : (Convert.ToInt32(R["RDelete"]) > 0 ? true : false)),
                Export = Convert.ToBoolean(R["RExport"].ToString().Trim() == "" ? false : (Convert.ToInt32(R["RExport"]) > 0 ? true : false)),
                Import = Convert.ToBoolean(R["RImport"].ToString().Trim() == "" ? false : (Convert.ToInt32(R["RImport"]) > 0 ? true : false)),
                Watch = Convert.ToBoolean(R["RWatch"].ToString().Trim() == "" ? false : (Convert.ToInt32(R["RWatch"]) > 0 ? true : false)),
                Print = Convert.ToBoolean(R["RPrint"].ToString().Trim() == "" ? false : (Convert.ToInt32(R["RPrint"]) > 0 ? true : false)),
                Release = Convert.ToBoolean(R["RRelease"].ToString().Trim() == "" ? false : (Convert.ToInt32(R["RRelease"]) > 0 ? true : false)),
                Save = Convert.ToBoolean(R["RSave"].ToString().Trim() == "" ? false : (Convert.ToInt32(R["RSave"]) > 0 ? true : false)),
                UnRelease = Convert.ToBoolean(R["RUnRelease"].ToString().Trim() == "" ? false : (Convert.ToInt32(R["RUnRelease"]) > 0 ? true : false)),
            };

        }
    }
}
