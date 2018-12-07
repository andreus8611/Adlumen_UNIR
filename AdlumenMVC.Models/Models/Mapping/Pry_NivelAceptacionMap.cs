using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_NivelAceptacionMap : EntityTypeConfiguration<Pry_NivelAceptacion>
    {
        public Pry_NivelAceptacionMap()
        {
            // Primary Key
            this.HasKey(t => t.IdNivelAceptacion);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Descripcion)
                .HasMaxLength(100);

            this.Property(t => t.Color)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Pry_NivelAceptacion");
            this.Property(t => t.IdNivelAceptacion).HasColumnName("IdNivelAceptacion");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.Color).HasColumnName("Color");
            //this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
