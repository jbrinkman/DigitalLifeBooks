using System;
using DotNetNuke.Services.Exceptions;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.Script.Services;
using DotNetNuke.Framework;

namespace DotNetNuke.Modules.DigitalLifeBooks
{
    public partial class AddEvent : DigitalLifeBooksModuleBase
    {
       override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);

            hidPassedInChild.Value = Request.Params["childId"];
        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
        private void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                DotNetNuke.Framework.jQuery.RequestRegistration();
                DotNetNuke.Framework.jQuery.RequestUIRegistration();
                ServicesFramework.Instance.RequestAjaxScriptSupport();

            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }


    }
}