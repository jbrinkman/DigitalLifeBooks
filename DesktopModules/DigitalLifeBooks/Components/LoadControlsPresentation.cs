using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.IO;
using DotNetNuke.Modules.DigitalLifeBooks.Data;
using DotNetNuke.Common.Lists;
using System.Web.Mvc;
using System.Data;

namespace DotNetNuke.Modules.DigitalLifeBooks
{
    public static class LoadControlsPresentation
    {
        
        public static List<ListItem> GetStates()
        {
            return (from itm in new ListController().GetListEntryInfoItems("Region", "Country.US").AsEnumerable()
                       select new ListItem(){ Text = itm.Text, Value = itm.Value }).ToList<ListItem>();
        }

        public static List<ListItem> GetParties()
        {
            return new LoadControlsDao().GetParties();
        }

        public static string GetAssociations(string childId)
        {
            DataTable dt = new LoadControlsDao().GetAssociations(childId);
            StringBuilder sb = new StringBuilder();
            sb.Append("<OL>");
            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<span>");
                sb.Append(row["Firstname"].ToString() + " " + row["lastname"].ToString());
                sb.Append("</span>");

                sb.Append("<span>");
                sb.Append(row["Type"].ToString());
                sb.Append("</span>");

                sb.Append("<span>");
                sb.Append("<a href=\"javascript:associatedPartyAction('Delete','" + row["id"].ToString() + "', '')\">Delete</a>");
                sb.Append("</span>");
                sb.Append("</li>");
                sb.Append("\n");

            }
            sb.Append("</OL>");
            return sb.ToString() ;
        }

        public static List<ListItem> GetRelationships()
        {
            LoadControlsDao dao = new LoadControlsDao();
            return dao.GetRelationships();
        }

        internal static Array GetEvents(string childId)
        {
            return new LoadControlsDao().GetEvents(childId);
        }
    }
}