using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_ProyectosTiposMap : EntityTypeConfiguration<Pry_ProyectosTipos>
    {
        public Pry_ProyectosTiposMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Descripcion)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Pry_ProyectosTipos");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            //this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
