using System.Web;
using System.Web.Mvc;
using DotNetNuke.Web.Services;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace DotNetNuke.Modules.Child.Services
{
    public class EditController : DnnController
    {
        public string SaveChild(
            string ChildId,
            string FirstName,
            string MiddleInitial,
            string LastName,
            string BirthDate,
            string City,
            string State,
            string ReferingAgency)
        {
            return ChildDetails.SaveChild(
                ChildId,
                FirstName,
                MiddleInitial,
                LastName,
                BirthDate,
                City,
                State,
                ReferingAgency);
        }


        public string AssociatedPartyAction(
            string ChildId,
            string SelectedPartyId,
            string Action,
            string Relationship)
        {
            ChildDetails.AssociatedPartyAction(ChildId, SelectedPartyId, Action, Relationship);
            return LoadControlsPresentation.GetAssociations(ChildId);
        }

        public JsonResult GetStates()
        {
            return Json(LoadControlsPresentation.GetStates());
        }

        public JsonResult GetParties()
        {
            return Json(LoadControlsPresentation.GetParties());
        }

        public string GetAssociations(string ChildId)
        {
            return LoadControlsPresentation.GetAssociations(ChildId);
        }

        public JsonResult GetChildren()
        {
            
            return  Json(MainViewPresentation.GetChildren());
        }

        public JsonResult GetChildData(string ChildId, string mid, string tabId, string pageAction)
        {
            return Json(MainViewPresentation.GetChildData(ChildId, mid, tabId, pageAction));
        }

        public string GetChildContent(string ChildId)
        {
            return MainViewPresentation.GetChildContent(ChildId);
        }

        public JsonResult GetRelationships()
        {
            return Json(LoadControlsPresentation.GetRelationships());
        }

        public JsonResult GetEvents(string ChildId)
        {
            return Json(LoadControlsPresentation.GetEvents(ChildId));
        }

        public void InsertEvent(string ChildId, string EventTitle, string EventDescription, string EventDate)
        {
            MainViewPresentation.InsertEvent(ChildId, EventTitle, EventDescription, EventDate);
        }
    }
}