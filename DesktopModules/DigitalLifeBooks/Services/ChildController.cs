using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetNuke.Web.Services;

namespace DotNetNuke.Modules.DigitalLifeBooks.Services
{
    public class ChildController: DnnController
    {
        public ActionResult Hello(string name)
        {
            return Json(new {result ="Hello " + name});
        }
    }
}