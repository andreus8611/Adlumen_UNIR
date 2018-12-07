using AdlumenMVC.Models.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;

namespace AdlumenMVC.Models
{
    public static class TenantUtil
    {
        public static Dictionary<int, Tenant> TenantsById;

        public static Dictionary<string, Tenant> TenantsByName;

        static TenantUtil()
        {
            TenantsById = new Dictionary<int, Tenant>();
            TenantsByName = new Dictionary<string, Tenant>();
            LoadTenants();
        }

        public static void LoadTenants()
        {
            using (var db = new NonTenantDbContext())
            {
                var tenants = db.Tenants.ToList();

                TenantsById = tenants.ToDictionary(x => x.Id, x => x);
                TenantsByName = tenants.ToDictionary(x => x.Name, x => x);
            }
        }

        public static Tenant GetTenantFromUrl()
        {
            Uri url = null;var a = SynchronizationContext.Current;
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                url = HttpContext.Current.Request.Url; 
            }
            return GetTenantFromUrl(url);
        }

        public static Tenant GetTenantFromUrl(Uri url)
        {
            Debug.WriteLine($"Url: {url}\nSync: {SynchronizationContext.Current}");
            Debug.WriteLineIf(url == null, $"Stack: {Environment.StackTrace}");

            if (url == null)
                return null;

            var subdomain = string.Empty;

            if (url.HostNameType == UriHostNameType.Dns)
            {
                var host = url.Host;
                var nodes = host.Split('.');

                subdomain = nodes.Length > 0 ? nodes[0] : null;
            }

            Tenant tenant = null;
            TenantsByName.TryGetValue(subdomain, out tenant);

            return tenant;
        }
    }
}