<%@ Control language="C#" Inherits="DotNetNuke.Modules.AddEvent.Edit" AutoEventWireup="false"  Codebehind="Edit.ascx.cs" %>
<%@ Register Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" TagPrefix="DNN" %>

<DNN:DnnJsInclude id="jsScript" runat="server" FilePath="~/DesktopModules/DigitalLifeBooks/Scripts/Edit.js"></DNN:DnnJsInclude>

<link rel="stylesheet" href="http://code.jquery.com/ui/1.8.21/themes/base/jquery-ui.css" type="text/css" media="all" />
<link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />
<fieldset>
    <h2>Create an Event</h2>
    <div>
        <label>New Event Name:</label>
        <input type="text" id="txtNewEventName" maxlength="50"/>
    </div>
    <div>
        <label>Event Description:</label>
        <textarea id="txtEventDescription" rows="5" cols="26"></textarea>
    </div>
    <div>
        <label>Event Date:</label>
        <input type="text" id="txtEventDate" maxlength="12"/>
        <input type="button" id="btnCreateNewEvent" value="Create" />
    </div>
</fieldset>
