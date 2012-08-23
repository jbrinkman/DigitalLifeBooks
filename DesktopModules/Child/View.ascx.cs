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



namespace DotNetNuke.Modules.Child
{

    public partial class View : ChildModuleBase, IActionable
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
        }

        protected string GetEditURL(string childId)
        {
            return EditUrl("ChildId", childId);
        }


        #endregion

        #region Optional Interfaces

        public ModuleActionCollection ModuleActions
        {
            get
            {
                ModuleActionCollection Actions = new ModuleActionCollection();
                Actions.Add(GetNextActionID(), Localization.GetString("EditModule", this.LocalResourceFile), "", "", "", EditUrl(), false, SecurityAccessLevel.Edit, true, false);
                return Actions;
            }
        }

        Entities.Modules.Actions.ModuleActionCollection IActionable.ModuleActions
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

    }

}
