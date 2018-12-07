using AdlumenMVC.Models;
using AdlumenMVC.WebUI.Infraestructure;
using EntityFramework.DynamicFilters;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AdlumenMVC.WebUI.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public int? TenantId { get; private set; }
        public TenantDiscovery TenantDiscovery { get; set; }

        public ApplicationDbContext()
            : base("Adlumen2SocIdentity", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            //RequireUniqueEmail = false;

            this.InitializeDynamicFilters();
            TenantDiscovery = new TenantDiscovery();

            TenantId = TenantDiscovery.GetTenantId();
            //Database.Log = sql => Debug.Write(sql);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Filter(
                "FilterUsersByTenant",
                (ITenant tenant, int idTenant) => tenant.IdTenant == idTenant,
                (ApplicationDbContext context) =>
                {
                    return context.TenantId ?? context.TenantDiscovery.GetTenantId();
                }
            );

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var createdEntries = GetModifiedEntries();

            if (createdEntries.Any())
            {
                foreach (var createdEntry in createdEntries)
                {
                    var entity = createdEntry.Entity as ITenant;
                    if (entity != null && entity.IdTenant == 0)
                    {
                        var idTenant = TenantId ?? TenantDiscovery.GetTenantId();
                        if (idTenant == 0)
                        {
                            throw new InvalidOperationException("Se intento guardar una entidad de Tenant sin IdTenant.");
                        }
                        entity.IdTenant = idTenant;
                    }
                }
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            var createdEntries = GetModifiedEntries();

            if (createdEntries.Any())
            {
                foreach (var createdEntry in createdEntries)
                {
                    var entity = createdEntry.Entity as ITenant;
                    if (entity != null && entity.IdTenant == 0)
                    {
                        var idTenant = TenantId ?? TenantDiscovery.GetTenantId();
                        if (idTenant == 0)
                        {
                            throw new InvalidOperationException("Se intento guardar una entidad de Tenant sin IdTenant.");
                        }
                        entity.IdTenant = idTenant;
                    }
                }
            }

            return base.SaveChangesAsync();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var createdEntries = GetModifiedEntries();

            if (createdEntries.Any())
            {
                foreach (var createdEntry in createdEntries)
                {
                    var entity = createdEntry.Entity as ITenant;
                    if (entity != null && entity.IdTenant == 0)
                    {
                        var idTenant = TenantId ?? TenantDiscovery.GetTenantId();
                        if (idTenant == 0)
                        {
                            throw new InvalidOperationException("Se intento guardar una entidad de Tenant sin IdTenant.");
                        }
                        entity.IdTenant = idTenant;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        private IEnumerable<DbEntityEntry> GetModifiedEntries()
        {
            var createdEntries = ChangeTracker.Entries().Where(x =>
                EntityState.Added.HasFlag(x.State) || EntityState.Modified.HasFlag(x.State));

            return createdEntries;
        }

        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Acciones> Acciones { get; set; }
        public DbSet<AccionesRole> AccionesRoles { get; set; }
    }
}