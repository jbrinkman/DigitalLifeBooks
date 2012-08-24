using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Web.Services;

namespace DotNetNuke.Modules.Child.Services
{
    public class DefaultRoutMapper: IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            // Service will be callable by /DesktopModules/DigitalLifeBooks/API/{controller}.ashx/{methodname}
            mapRouteManager.MapRoute("Child", "{controller}.ashx/{action}", new[] { "DotNetNuke.Modules.Child.Services" });
        }
    }
}