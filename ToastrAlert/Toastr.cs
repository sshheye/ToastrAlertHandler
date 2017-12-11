using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace ToastrAlert
{
 


    public class Toastr
    {
  

        public static void AddSuccessMsg(string toastrMessage)
        {
            Session[toastrStatus] = "success";
            Session[toastrMsg] = toastrMessage;
        }
        public static void AddErrorMsg(string toastrMessage)
        {
            Session[toastrStatus] = "error";
            Session[toastrMsg] = toastrMessage;
        }
        public static void AddInfoMsg(string toastrMessage)
        {
            Session[toastrStatus] = "info";
            Session[toastrMsg] = toastrMessage;
        }
        public static void AddWarningMsg(string toastrMessage)
        {
            Session[toastrStatus] = "warning";
            Session[toastrMsg] = toastrMessage;
        }

        public static string Render()
        {
            string toastrNotificationScript = "";
            switch (ToastrStatus())
            {
                case "success":
                    toastrNotificationScript = $"<script>toastr.success('{ToastrMsg()}')</script>";
                    break;
                case "error":
                    toastrNotificationScript = $"<script>toastr.error('{ToastrMsg()}')</script>";
                    break;
                case "warning":
                    toastrNotificationScript = $"<script>toastr.warning('{ToastrMsg()}')</script>";
                    break;
                case "info":
                    toastrNotificationScript = $"<script>toastr.info('{ToastrMsg()}')</script>";
                    break;
                default:
                    break;
            }

            ClearNotification();
            return toastrNotificationScript;
        }

        private const string toastrStatus = "alert-notification-status";
        private const string toastrMsg = "alert-notification-message";
        private static HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }

        private static string ToastrStatus()
        {
            return (string)Session[toastrStatus];
        }
        private static string ToastrMsg()
        {
            return (string)Session[toastrMsg];
        }
        private static void ClearNotification()
        {
            Session[toastrStatus] = "";
            Session[toastrMsg] = "";
        }

  

       
    }
}
