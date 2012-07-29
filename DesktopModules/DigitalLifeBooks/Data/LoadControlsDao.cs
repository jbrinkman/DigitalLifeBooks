using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml.Linq;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;

namespace DotNetNuke.Modules.DigitalLifeBooks.Data
{
    public class LoadControlsDao : DataProvider
    {
        public List<ListItem> GetParties()
        {
            var connection = (SqlConnection)GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spDLB_GetPeople";
            SqlDataReader rdr = cmd.ExecuteReader();

            DataTable dt = new DataTable("dtParties");
            dt.Load(rdr);

            List<ListItem> list = (from item in dt.AsEnumerable()
                                   select new ListItem()
                                   {
                                       Text = Utils.getChildFullName(item["firstname"].ToString(),
                                                                     item["middleinitial"].ToString(),
                                                                     item["lastname"].ToString()),
                                       Value = item["id"].ToString()
                                   }).ToList<ListItem>();
            rdr.Close();
            connection.Close();

            return list;
        }

        public DataTable GetAssociations(string childId)
        {
            var connection = (SqlConnection)GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spDLB_GetAssociations";
            cmd.Parameters.AddWithValue("@childId", childId);
            SqlDataReader rdr = cmd.ExecuteReader();

            DataTable dt = new DataTable("dtParties");
            dt.Load(rdr);
            rdr.Close();
            connection.Close();
            return dt;
        }

        public List<ListItem> GetRelationships()
        {
            var connection = (SqlConnection)GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spDLB_GetRelationship";
            SqlDataReader rdr = cmd.ExecuteReader();

            DataTable dt = new DataTable("dtRelationships");
            dt.Load(rdr);

            List<ListItem> list = (from item in dt.AsEnumerable()
                                   select new ListItem()
                                   {
                                       Text = item["Type"].ToString(),
                                       Value = item["Id"].ToString()
                                   }).ToList<ListItem>();
            rdr.Close();
            connection.Close();

            return list;
        }

        
        internal List<ListItem> GetChildren()
        {
            throw new NotImplementedException();
        }

        internal List<ListItem> GetAllChildren()
        {
            var connection = (SqlConnection)GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spDLB_GetAllChildren";
            SqlDataReader rdr = cmd.ExecuteReader();

            DataTable dt = new DataTable("dtAllChildren");
            dt.Load(rdr);

            List<ListItem> list = (from item in dt.AsEnumerable()
                                   select new ListItem()
                                   {
                                       Text = Utils.getChildFullName(item["firstname"].ToString(), item["middleinitial"].ToString(), item["lastname"].ToString()),
                                       Value = item["Id"].ToString()
                                   }).ToList<ListItem>();
            rdr.Close();
            connection.Close();

            return list;
        }

        public Array GetChildData(string ChildId, string mid, string tabId, string action)
        {
            var connection = (SqlConnection)GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spDLB_GetChildData";
            cmd.Parameters.AddWithValue("@childId", ChildId);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable("dtChildData");
            dt.Load(rdr);
            string url = string.Empty;
            string addEventUrl = string.Empty;
            if (action == "Redirect")
            {
               url = Globals.NavigateURL(Int32.Parse(tabId), "Edit", new string[] { "mid=" + mid, "childId=" + ChildId });
               url = UrlUtils.PopUpUrl(url, null, Globals.GetPortalSettings(), false, false);

               addEventUrl = Globals.NavigateURL(Int32.Parse(tabId), "AddEvent", new string[] { "mid=" + mid, "childId=" + ChildId });
               addEventUrl = UrlUtils.PopUpUrl(addEventUrl, null, Globals.GetPortalSettings(), false, false);

            }

            Array list = (from row in dt.AsEnumerable()
                          select new
                          {
                              ChildName = row["firstname"].ToString() + " " + row["lastname"].ToString(),
                              FirstName = row["firstname"].ToString(),
                              LastName = row["lastname"].ToString(),
                              MiddleInitial = row["middleinitial"].ToString(),
                              DOB = DateTime.Parse(row["DOB"].ToString()).ToString("MM-dd-yyyy"),
                              City = row["city"].ToString(),
                              State = row["state"].ToString(),
                              ReferingAgency = row["ReferingAgency"].ToString(),
                              Url = url,
                              AddEventUrl = addEventUrl
                          }).ToArray();
            rdr.Close();
            connection.Close();
            return list;
        }

        public DataTable GetChildContent(string ChildId, string eventId)
        {
            var connection = (SqlConnection)GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spDLB_GetContentForEvent";
            cmd.Parameters.AddWithValue("@childId", ChildId);
            cmd.Parameters.AddWithValue("@eventId", eventId);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable("dtContentData");
            dt.Load(rdr);

            rdr.Close();
            connection.Close();

            return dt;
        }

        public DataTable GetEventDetails(string ChildId)
        {
            var connection = (SqlConnection)GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spDLB_GetChildEvents";
            cmd.Parameters.AddWithValue("@childId", ChildId);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable("dtEventData");
            dt.Load(rdr);

            rdr.Close();
            connection.Close();

            return dt;
        }

        internal Array GetEvents(string childId)
        {
            var connection = (SqlConnection)GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spDLB_GetChildEvents";
            cmd.Parameters.AddWithValue("@childId", childId);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable("dtEventData");
            dt.Load(rdr);

            Array list = (from row in dt.AsEnumerable()
                          select new
                          {
                               Text = row["EventTitle"].ToString(),
                               Value = row["Id"].ToString()
                          }).ToArray();
            rdr.Close();
            connection.Close();
            return list;
        }
    }
}