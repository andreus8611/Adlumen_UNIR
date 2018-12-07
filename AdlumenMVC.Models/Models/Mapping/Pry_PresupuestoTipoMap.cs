using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_PresupuestoTipoMap : EntityTypeConfiguration<Pry_PresupuestoTipo>
    {
        public Pry_PresupuestoTipoMap()
        {
            // Primary Key
            this.HasKey(t => t.IdTipo);

            // Properties
            this.Property(t => t.Descripcion)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Pry_PresupuestoTipo");
            this.Property(t => t.IdTipo).HasColumnName("IdTipo");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
            //this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
