using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_ObjetivosClaseMap : EntityTypeConfiguration<Pry_ObjetivosClase>
    {
        public Pry_ObjetivosClaseMap()
        {
            // Primary Key
            this.HasKey(t => t.IdObjetivoClase);

            // Properties
            this.Property(t => t.Descripcion)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Pry_ObjetivosClase");
            this.Property(t => t.IdObjetivoClase).HasColumnName("IdObjetivoClase");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            //this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
