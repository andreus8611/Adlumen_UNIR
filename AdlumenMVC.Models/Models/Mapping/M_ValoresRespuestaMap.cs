using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class M_ValoresRespuestaMap : EntityTypeConfiguration<M_ValoresRespuesta>
    {
        public M_ValoresRespuestaMap()
        {
            // Primary Key
            this.HasKey(t => t.IdValorRespuesta);

            // Properties
            this.Property(t => t.Valor)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("M_ValoresRespuesta");
            this.Property(t => t.IdValorRespuesta).HasColumnName("IdValorRespuesta");
            this.Property(t => t.IdPreguntaResuelta).HasColumnName("IdPreguntaResuelta");
            this.Property(t => t.Valor).HasColumnName("Valor");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.M_PreguntasResueltas)
                .WithMany(t => t.M_ValoresRespuesta)
                .HasForeignKey(d => d.IdPreguntaResuelta);

        }
    }
}
