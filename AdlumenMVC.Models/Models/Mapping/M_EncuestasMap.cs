using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class M_EncuestasMap : EntityTypeConfiguration<M_Encuestas>
    {
        public M_EncuestasMap()
        {
            // Primary Key
            this.HasKey(t => t.IdEncuesta);

            // Properties
            this.Property(t => t.Titulo)
                .HasMaxLength(50);

            this.Property(t => t.Descripcion)
                .HasMaxLength(100);

            this.Property(t => t.Estado)
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("M_Encuestas");
            this.Property(t => t.IdEncuesta).HasColumnName("IdEncuesta");
            this.Property(t => t.Titulo).HasColumnName("Titulo");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.FechaCreacion).HasColumnName("FechaCreacion");
            this.Property(t => t.IdIdioma).HasColumnName("IdIdioma");
            this.Property(t => t.Estado).HasColumnName("Estado");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.M_Idiomas)
                .WithMany(t => t.M_Encuestas)
                .HasForeignKey(d => d.IdIdioma);

        }
    }
}
