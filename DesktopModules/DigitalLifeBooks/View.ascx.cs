/*
' Copyright (c) 2012  DotNetNuke Corporation
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using System.Web.Services;
using System.Web.UI.WebControls;
using DotNetNuke.Services.Exceptions;
using System.Collections.Generic;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Security;
using DotNetNuke.Framework;
using System.IO;



namespace DotNetNuke.Modules.DigitalLifeBooks
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from DigitalLifeBooksModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : DigitalLifeBooksModuleBase, IActionable
    {

        #region Event Handlers

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);

        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Page_Load runs when the control is loaded
        /// </summary>
        /// -----------------------------------------------------------------------------
        private void Page_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                hidMid.Value = this.ModuleId.ToString();
                hidTabId.Value = this.TabId.ToString();
                DotNetNuke.Framework.jQuery.RequestRegistration();
                DotNetNuke.Framework.jQuery.RequestUIRegistration();

                ServicesFramework.Instance.RequestAjaxScriptSupport();
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }

            btnUpload.Click += new EventHandler(btnUpload_Click);
        }

        protected string GetEditURL(string childId)
        { 
            return EditUrl("ChildId",childId);
        }


        protected void btnUpload_Click(object sender, System.EventArgs e)
        {
            
            if (fuContent.FileBytes.Length < 1) return;
            if (string.IsNullOrWhiteSpace(hidSelectedChildId.Value)) return;
            if (string.IsNullOrWhiteSpace(hiddenSelectedEventId.Value)) return;

            byte[] binaryFile = fuContent.FileBytes;
            string filepath = Server.MapPath(hidSelectedChildId.Value + "\\" + DateTime.Now.ToString("MMyyyy") + "\\");
            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(filepath);
            string filename = DateTime.Now.ToString("ss-mm-hh-dd-MM-yyyy") + "." + fuContent.FileName.Split('.')[1];
            filepath += filename;
            fuContent.SaveAs(filepath);
            string mimetype = fuContent.PostedFile.ContentType;
            
            //pretent we got an event id
            MainViewPresentation.InsertContentFile(hidSelectedChildId.Value, filepath, mimetype, Convert.ToInt32(hiddenSelectedEventId.Value));
            
        }

        #endregion

        #region Optional Interfaces

        public ModuleActionCollection ModuleActions
        {
            get
            {
                ModuleActionCollection Actions = new ModuleActionCollection();
                Actions.Add(GetNextActionID(), Localization.GetString("EditModule", this.LocalResourceFile), "", "", "", EditUrl(), false, SecurityAccessLevel.Edit, true, false);
                //Actions.Add(GetNextActionID(), Localization.GetString("AddEventModule", this.LocalResourceFile), "", "", "", EditUrl(), false, SecurityAccessLevel.Edit, true, false);
                return Actions;
            }
        }

        #endregion

        Entities.Modules.Actions.ModuleActionCollection IActionable.ModuleActions
        {
            get { throw new NotImplementedException(); }
        }
        
    }

    

}
