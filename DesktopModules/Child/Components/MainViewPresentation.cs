using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Web.UI.HtmlControls;
using DotNetNuke.Modules.Child.Data;
using System.Data;

namespace DotNetNuke.Modules.Child
{
    public static class MainViewPresentation 
    {
        public static List<ListItem> GetChildren()
        {
            //var roles = DotNetNuke.Entities.Users.UserController.GetCurrentUserInfo();
            //if(roles.admin) 
            return new LoadControlsDao().GetAllChildren();
        }

        public static Array GetChildData(string ChildId, string mid, string tabId, string action)
        {
            return new LoadControlsDao().GetChildData(ChildId, mid, tabId, action);
        }

        public static string GetChildContent(string ChildId)
        {
            DataTable dt = new LoadControlsDao().GetEventDetails(ChildId);
            StringBuilder sb = new StringBuilder();
            sb.Append("<OL>");
            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<H1>" + row["EventTitle"].ToString() + "</H1>");
                sb.Append("<H2>");
                sb.Append("<span>" + row["EventDate"].ToString() + "</span>");
                sb.Append("<span>" + row["Description"].ToString() + "</span>");
                sb.Append("</H2>");
                sb.Append("<hr/>");
                //get content for this event.
                DataTable dtContent = new LoadControlsDao().GetChildContent(ChildId, row["Id"].ToString());

                if (dtContent.Rows.Count != 0)
                {
                    sb.Append("<OL>");
                    foreach (DataRow contentRow in dtContent.Rows)
                    {
                        string filepath = contentRow["Location"].ToString();
                        filepath = "/" + filepath.Substring(filepath.IndexOf(ChildId));
                        filepath.Replace(@"\", "/");
                        string host = string.Empty;

                        if (HttpContext.Current.Request.ApplicationPath == "/")
                            host = "http://" + HttpContext.Current.Request.Url.Host;
                        else
                            host = "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath;
                        filepath = host + filepath;

                        sb.Append("<LI>");
                        sb.Append("<span>" + contentRow["Type"].ToString() + "</span>");
                        sb.Append("<span><a href=\"" + filepath + "\")>View</a></span>");
                        sb.Append("</LI>");
                    }
                    sb.Append("</OL>");
                }
                sb.Append("<hr/>");
                sb.Append("</LI>");
            }
            sb.Append("</OL>");
            return sb.ToString();
        }

        public static void InsertContentFile(string childId, string filepath, string mimeType, int eventId)
        {
            new EditChildDao().InsertContentFile(childId, filepath, mimeType, eventId);
        }

        internal static void InsertEvent(string ChildId, string EventTitle, string EventDescription, string EventDate)
        {
            new EditChildDao().InsertEvent(ChildId, EventTitle, EventDescription, EventDate);
        }
    }
}