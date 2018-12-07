using AdlumenMVC.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdlumenMVC.Models
{
    public class NonTenantDbContext : DbContext
    {
        static NonTenantDbContext()
        {
            Database.SetInitializer<NonTenantDbContext>(null);
        }

        public NonTenantDbContext()
            : base("Name=Adlumen2SocEntities")
        {
            Configuration.ProxyCreationEnabled = false;
            //Database.Log = sql => Debug.Write(sql);
        }

        public DbSet<Tenant> Tenants { get; set; }
    }
}
