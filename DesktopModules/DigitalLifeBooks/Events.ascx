<%@ Control Language="C#" AutoEventWireup="false" Inherits="DotNetNuke.Modules.DigitalLifeBooks.Events" Codebehind="Events.ascx.cs" %>
<%@ Register Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" TagPrefix="DNN" %>

<DNN:DnnJsInclude id="jsScript" runat="server" FilePath="~/DesktopModules/DigitalLifeBooks/Scripts/Events.js"></DNN:DnnJsInclude>

<link rel="stylesheet" href="http://code.jquery.com/ui/1.8.21/themes/base/jquery-ui.css" type="text/css" media="all" />
<link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />

<fieldset>
    <input type="hidden" runat="server" id="hidPassedInChild" />
    <div>
        <label>Event Name:</label>
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
        <input id="btnSave" type="button" value="Save"/>
    </div>
</fieldset>
