using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetNuke.Modules.Child
{
    public static class Utils
    {
        internal static string getChildFullName(string firstname, string middleinitial, string lastname)
        {
            return string.IsNullOrWhiteSpace(middleinitial) ? firstname + " " + lastname :
                firstname + " " + middleinitial + " " + lastname;
        }

    }
}