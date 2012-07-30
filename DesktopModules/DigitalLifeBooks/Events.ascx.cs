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
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.Script.Services;
using DotNetNuke.Framework;

namespace DotNetNuke.Modules.DigitalLifeBooks
{

    public partial class Events : DigitalLifeBooksModuleBase
    {
        #region Event Handlers

        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
            hidPassedInChild.Value = Request.Params["childId"];
        }

        private void InitializeComponent()
        {
            this.Load += new EventHandler(this.Page_Load);
        }

        void Page_Load(object sender, EventArgs e)
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
        
        #endregion


    }

}

