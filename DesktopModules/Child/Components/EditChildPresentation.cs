using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Modules.Child.Data;

namespace DotNetNuke.Modules.Child
{

    public static class ChildDetails 
    {
        public static string SaveChild(
            string ChildId,
            string FirstName,
            string MiddleInitial,
            string LastName,
            string BirthDate,
            string City,
            string State,
            string ReferingAgency)
        {
            string response = string.Empty;
            try
            {
                new EditChildDao().SaveChild(
                    ChildId,
                    FirstName,
                    MiddleInitial,
                    LastName,
                    BirthDate,
                    City,
                    State,
                    ReferingAgency);
               
            }
            catch (Exception)
            {
                response = "Error: Save failed.";
            }
            return response;
        }

        public static string AssociatedPartyAction(
            string ChildId,
            string SelectedPartyId,
            string Action,
            string Relationship)
        {
            string response = string.Empty;
            try
            {
                switch (Action)
                { 
                    case "Delete":
                        deleteAssociation(ChildId, SelectedPartyId);
                        break;
                    case "Add":
                        insertAssociation(ChildId, SelectedPartyId, Relationship);
                        break;
                    default:
                        response = "Invalid action.";
                        break;
                }
            }
            catch (Exception)
            {
                response = "Error: Association failed.";
            }
            return response;

        }

        private static void deleteAssociation(string childId, string selectedPartyId)
        {
            new EditChildDao().deleteAssociation(childId, selectedPartyId);
        }

        private static void insertAssociation(string childId, string selectedPartyId, string Relationship)
        {
            new EditChildDao().insertAssociation(childId, selectedPartyId, Relationship);
        }
    }
}