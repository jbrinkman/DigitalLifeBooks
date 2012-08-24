<%@ Control language="C#" Inherits="DotNetNuke.Modules.Child.View" AutoEventWireup="false"  Codebehind="View.ascx.cs" %>
<%@ Register Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" TagPrefix="DNN" %>

<DNN:DnnJsInclude id="jsScript" runat="server" FilePath="~/DesktopModules/DigitalLifeBooks/Scripts/MainView.js"></DNN:DnnJsInclude>
<link rel="stylesheet" href="http://code.jquery.com/ui/1.8.21/themes/base/jquery-ui.css" type="text/css" media="all" />
<link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />


<div id="header" />
<fieldset>
    <div>
        <div id="childNav">
            <input type="hidden" id="hidSelectedChildId" runat="server"/>
            <label>Select Child</label>
            <select id="selChildren" name="D1"></select>
            <input id="btnGo" type="button" value="Go"/>
        </div>
    </div>
    <div id="childData">
        <input type="hidden" id="hidTabId" runat="server" />
        <input type="hidden" id="hidMid" runat="server" />
        <span id="lblChildName"></span>
        <label>Age</label>
        <span id="lblCalculatedAge"></span>
        <label>Born on</label>
        <span id="lblBirthDate"></span>
        <span id="lblCity"></span>
        <span id="lblState"></span>
        <a id="lnkEditChild" href="#">Edit Child</a>
    </div>
</fieldset>
<div id="footer" />

