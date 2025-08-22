using HVTT.UI.Window.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms
{
    public class HVTTMessages
    {
        public static DialogResult Show(String Title, String Msg, HVTTMessageTypes MessageType)
        {
            frmMessageBox myFrm = new frmMessageBox();
            //myFrm.Language = null;
            myFrm.Title1 = "";
            myFrm.Title = Title;
            myFrm.Msg = Msg;
            myFrm.MessageType = MessageType;
            return myFrm.ShowDialog();

        }
        public static DialogResult Show(String Msg, HVTTMessageTypes MessageType)
        {
            frmMessageBox myFrm = new frmMessageBox();
            //myFrm.Language = null;
            myFrm.Title1 = "";
            if (MessageType == HVTTMessageTypes.Error)
                myFrm.Title = "Lỗi";
            else if (MessageType == HVTTMessageTypes.Info)
                myFrm.Title = "Thông báo";
            else if (MessageType == HVTTMessageTypes.Question)
                myFrm.Title = "Hỏi";
            else if (MessageType == HVTTMessageTypes.Success)
                myFrm.Title = "Thông báo";
            else if (MessageType == HVTTMessageTypes.Warning)
                myFrm.Title = "Cảnh báo";
            myFrm.Msg = Msg;
            myFrm.MessageType = MessageType;
            return myFrm.ShowDialog();

        }
        public static DialogResult Show(Exception ex)
        {
            frmMessageBox myFrm = new frmMessageBox();
            //myFrm.Language = null;
            myFrm.Title1 = "";
            myFrm.Title = "Lỗi";
            myFrm.Msg = "<b>" + ex.Message + "</b><br/> " + ex.StackTrace + "<br/> " + ex.Source;
            myFrm.MessageType = HVTTMessageTypes.Error;
            return myFrm.ShowDialog();

        }
        //public static DialogResult Show(clsLanguageStruct Language, Exception ex)
        //{
        //    frmMessageBox myFrm = new frmMessageBox();
        //    myFrm.Language = Language;
        //    myFrm.Title1 = "";
        //    myFrm.Title =  Language.GetLanguage("Loi");
        //    myFrm.Msg = "<b>" + ex.Message + "</b><br/> " + ex.StackTrace + "<br/> " + ex.Source;
        //    myFrm.MessageType = HVTTMessageTypes.Error;
        //    return myFrm.ShowDialog();

        //}
        public static DialogResult Show(String Title,String Title1, String Msg, HVTTMessageTypes MessageType)
        {
            frmMessageBox myFrm = new frmMessageBox();
            //myFrm.Language = null;
            myFrm.Title1 = Title1;
            myFrm.Title = Title;
            myFrm.Msg = Msg;
            myFrm.MessageType = MessageType;
            return myFrm.ShowDialog();

        }
        //public static DialogResult Show(clsLanguageStruct Language,String Title, String Msg, HVTTMessageTypes MessageType)
        //{
        //    frmMessageBox myFrm = new frmMessageBox();
        //    myFrm.Language = Language;
        //    myFrm.Title1 = "";
        //    myFrm.Title = Title;
        //    myFrm.Msg = Msg;
        //    myFrm.MessageType = MessageType;
        //    return myFrm.ShowDialog();

        //}
        //public static DialogResult Show(clsLanguageStruct Language, String Msg, HVTTMessageTypes MessageType)
        //{
        //    frmMessageBox myFrm = new frmMessageBox();
        //    myFrm.Language = Language;
        //    myFrm.Title1 = "";
        //    if(Language!=null)
        //    {
        //        if (MessageType == HVTTMessageTypes.Error)
        //            myFrm.Title = Language.GetLanguage("Loi");
        //        else if (MessageType == HVTTMessageTypes.Info)
        //            myFrm.Title = Language.GetLanguage("ThongBao");
        //        else if (MessageType == HVTTMessageTypes.Question)
        //            myFrm.Title = Language.GetLanguage("Hoi");
        //        else if (MessageType == HVTTMessageTypes.Success)
        //            myFrm.Title = Language.GetLanguage("ThongBao");
        //        else if (MessageType == HVTTMessageTypes.Warning)
        //            myFrm.Title = Language.GetLanguage("CanhBao");
        //    }
        //    else
        //    {
        //        if (MessageType == HVTTMessageTypes.Error)
        //            myFrm.Title = "Lỗi";
        //        else if (MessageType == HVTTMessageTypes.Info)
        //            myFrm.Title = "Thông báo";
        //        else if (MessageType == HVTTMessageTypes.Question)
        //            myFrm.Title = "Hỏi";
        //        else if (MessageType == HVTTMessageTypes.Success)
        //            myFrm.Title = "Thông báo";
        //        else if (MessageType == HVTTMessageTypes.Warning)
        //            myFrm.Title = "Cảnh báo";
        //    }
        //    myFrm.Msg = Msg;
        //    myFrm.MessageType = MessageType;
        //    return myFrm.ShowDialog();

        //}
        //public static DialogResult Show(clsLanguageStruct Language, String Title,String Title1, String Msg, HVTTMessageTypes MessageType)
        //{
        //    frmMessageBox myFrm = new frmMessageBox();
        //    myFrm.Language = Language;
        //    myFrm.Title1 = Title1;
        //    myFrm.Title = Title;
        //    myFrm.Msg = Msg;
        //    myFrm.MessageType = MessageType;
        //    return myFrm.ShowDialog();

        //}

        public enum HVTTMessageTypes
        {
            Success,
            Warning,
            Error,
            Question,
            Info
        }
    }
}
