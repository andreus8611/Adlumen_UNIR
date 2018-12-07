using EntityFramework.DynamicFilters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdlumenMVC.Models
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext()
        {
            Init();
        }

        public TenantDbContext(string connectionString) : base(connectionString)
        {
            Init();
        }

        public TenantDbContext(string connectionString, DbCompiledModel model)
            : base(connectionString, model)
        {
            Init();
        }

        protected internal virtual void Init()
        {
            this.InitializeDynamicFilters();
            TenantDiscovery = new TenantDiscovery();
        }

        public int? IdTenant { get; protected set; }
        public TenantDiscovery TenantDiscovery { get; set; }

        public void SetTenantId(int idTenant)
        {
            //IdTenant = idTenant;
            //(this).SetFilterScopedParameterValue("FilterByTenant", "idTenant", IdTenant);
            //(this).SetFilterGlobalParameterValue("FilterByTenant", "idTenant", IdTenant);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Filter(
                "FilterByTenant",
                (ITenant tenant, int idTenant) => tenant.IdTenant == idTenant,
                (TenantDbContext context) => context.TenantDiscovery.GetTenantId()
            );

            base.OnModelCreating(modelBuilder);

            //if (IdTenant == null)
            //{
            //    var tenant = TenantUtil.GetTenantFromUrl();
            //    if (tenant != null)
            //    {
            //        SetTenantId(tenant.Id);
            //    }
            //}
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
                        var idTenant = TenantDiscovery.GetTenantId();
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
                        var idTenant = TenantDiscovery.GetTenantId();
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
                        var idTenant = TenantDiscovery.GetTenantId();
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
    }
}
