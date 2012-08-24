using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Web.Services;

namespace DotNetNuke.Modules.Event.Services
{
    public class DefaultRoutMapper: IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            // Service will be callable by /DesktopModules/DigitalLifeBooks/API/{controller}.ashx/{methodname}
            mapRouteManager.MapRoute("Event", "{controller}.ashx/{action}", new[] { "DotNetNuke.Modules.Event.Services" });
        }
    }
}