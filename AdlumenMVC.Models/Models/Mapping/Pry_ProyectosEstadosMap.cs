using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_ProyectosEstadosMap : EntityTypeConfiguration<Pry_ProyectosEstados>
    {
        public Pry_ProyectosEstadosMap()
        {
            // Primary Key
            this.HasKey(t => t.IdEstado);

            // Properties
            this.Property(t => t.Descripcion)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Pry_ProyectosEstados");
            this.Property(t => t.IdEstado).HasColumnName("IdEstado");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            //this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
