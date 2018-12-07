using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdlumenMVC.WebUI
{
    public static class WebUtil
    {
        public static string GetSubdomain(Uri url)
        {
            if (url.HostNameType == UriHostNameType.Dns)
            {
                var host = url.Host;
                var nodes = host.Split('.');

                return nodes.Length > 0 ? nodes[0] : null;
            }

            return null;
        }
    }
}