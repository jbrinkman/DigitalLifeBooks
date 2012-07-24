<%@ Control language="C#" Inherits="DotNetNuke.Modules.DigitalLifeBooks.Edit" AutoEventWireup="false"  Codebehind="Edit.ascx.cs" %>
<%@ Register Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" TagPrefix="DNN" %>

<DNN:DnnJsInclude id="jsScript" runat="server" FilePath="~/DesktopModules/DigitalLifeBooks/Scripts/Edit.js"></DNN:DnnJsInclude>
<DNN:DnnJsInclude id="jsScript2" runat="server" FilePath="~/DesktopModules/DigitalLifeBooks/Scripts/Common.js"></DNN:DnnJsInclude>
<link rel="stylesheet" href="http://code.jquery.com/ui/1.8.21/themes/base/jquery-ui.css" type="text/css" media="all" />
<link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />

<fieldset>
    <input type="hidden" runat="server" id="hidPassedInChild" />
    <div>
        <label>SACWIS Number</label>
        <input type="text" id="txtSacwisNo"/>
    </div>
    <div>
        <label>Refering Agency</label>
        <input id="txtReferingAgency" type="text" maxlength="100" />
    </div>
    <div>
        <label>First Name</label>
        <input id="txtFirstName" type="text" maxlength="32" />
        <label>Middle Initial</label>
        <input id="txtMiddleInitial" type="text" maxlength="1" /> 
        <label>Last Name</label>
        <input id="txtLastName" type="text" maxlength="32" /> 
    </div>
    <div>
        <label>Birth Date</label>
        <input id="txtBirthDate" type="text" maxlength="8" />        
    </div>
    <div>
        <label>City</label>
        <input id="txtCity" type="text" maxlength="32" />
        <label>State</label>
        <select id="selState"></select> 
    </div>
    <div>
        <label>Name</label>
        <select id="selAssociatedParties"></select>
        <label>Relationship</label>
        <select id="selRelationship"></select>
        <input id="btnAddAssociation" type="button" value="Add" />
    </div>
    <div id="lstAssociatedParties">
    </div> 
    <div>
        <input id="btnSave" type="button" value="Save"/>
    </div>   
</fieldset>
