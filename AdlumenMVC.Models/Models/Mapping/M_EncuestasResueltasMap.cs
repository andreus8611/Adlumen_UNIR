using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class M_EncuestasResueltasMap : EntityTypeConfiguration<M_EncuestasResueltas>
    {
        public M_EncuestasResueltasMap()
        {
            // Primary Key
            this.HasKey(t => t.IdEncuestaResuelta);

            // Properties
            this.Property(t => t.Usuario)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("M_EncuestasResueltas");
            this.Property(t => t.IdEncuestaResuelta).HasColumnName("IdEncuestaResuelta");
            this.Property(t => t.IdEncuesta).HasColumnName("IdEncuesta");
            this.Property(t => t.Usuario).HasColumnName("Usuario");
            this.Property(t => t.Fecha).HasColumnName("Fecha");
            this.Property(t => t.Comentarios).HasColumnName("Comentarios");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.M_Encuestas)
                .WithMany(t => t.M_EncuestasResueltas)
                .HasForeignKey(d => d.IdEncuesta);

        }
    }
}
