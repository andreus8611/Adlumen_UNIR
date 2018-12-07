using AdlumenMVC.Models.AbstractRepository;
using AdlumenMVC.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdlumenMVC.Models
{
    public class TenantDiscovery
    {
        public int GetTenantId()
        {
            var tenant = TenantUtil.GetTenantFromUrl();
            return tenant == null ? 0 : tenant.Id;
        }
    }
}