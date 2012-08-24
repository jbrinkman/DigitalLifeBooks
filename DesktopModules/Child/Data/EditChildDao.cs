using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using DotNetNuke.Modules.Child.Data;

namespace DotNetNuke.Modules.Child.Data
{
    public class EditChildDao : DataProvider
    {
        public void SaveChild(
            string ChildId,
            string FirstName,
            string MiddleInitial,
            string LastName,
            string BirthDate,
            string City,
            string State,
            string ReferingAgency)
        {
            var connection = (SqlConnection)GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spDLB_savechild";
            cmd.Parameters.AddWithValue("@childId", ChildId);
            cmd.Parameters.AddWithValue("@firstname", FirstName);
            cmd.Parameters.AddWithValue("@middleinitial", MiddleInitial);
            cmd.Parameters.AddWithValue("@lastname", LastName);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@DOB", BirthDate);
            cmd.Parameters.AddWithValue("@ReferingAgency", ReferingAgency);


            cmd.ExecuteNonQuery();

            connection.Close();
        }


        public void deleteAssociation(string childId, string selectedPartyId)
        {
            var connection = (SqlConnection)GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spDLB_DeleteAssociation";
            cmd.Parameters.AddWithValue("@childId", childId);
            cmd.Parameters.AddWithValue("@RelationshipId", selectedPartyId);

            cmd.ExecuteNonQuery();

            connection.Close();

        }

        public void insertAssociation(string childId, string selectedPartyId, string Relationship)
        {
            var connection = (SqlConnection)GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spDLB_InsertAssociation";
            cmd.Parameters.AddWithValue("@childId", childId);
            cmd.Parameters.AddWithValue("@peopleId", selectedPartyId);
            cmd.Parameters.AddWithValue("@relationship", Relationship);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        internal void InsertContentFile(string childId, string filepath, string contentType, int eventId)
        {
            var connection = (SqlConnection)GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spDLB_InsertContentInfo";
            cmd.Parameters.AddWithValue("@childId", childId);
            cmd.Parameters.AddWithValue("@filePath", filepath);
            cmd.Parameters.AddWithValue("@contentType", contentType);
            cmd.Parameters.AddWithValue("@eventId", eventId);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        internal void InsertEvent(string ChildId, string EventTitle, string EventDescription, string EventDate)
        {
            var connection = (SqlConnection)GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spDLB_InsertEvent";
            cmd.Parameters.AddWithValue("@childId", ChildId);
            cmd.Parameters.AddWithValue("@eventTitle", EventTitle);
            cmd.Parameters.AddWithValue("@eventDesc", EventDescription);
            cmd.Parameters.AddWithValue("@eventDate", EventDate);

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}