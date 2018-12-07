using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class M_PreguntasResueltasMap : EntityTypeConfiguration<M_PreguntasResueltas>
    {
        public M_PreguntasResueltasMap()
        {
            // Primary Key
            this.HasKey(t => t.IdPreguntaResuelta);

            // Properties
            // Table & Column Mappings
            this.ToTable("M_PreguntasResueltas");
            this.Property(t => t.IdPreguntaResuelta).HasColumnName("IdPreguntaResuelta");
            this.Property(t => t.IdEncuestaResuelta).HasColumnName("IdEncuestaResuelta");
            this.Property(t => t.IdPregunta).HasColumnName("IdPregunta");
            this.Property(t => t.TextoRespuesta).HasColumnName("TextoRespuesta");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.M_EncuestasResueltas)
                .WithMany(t => t.M_PreguntasResueltas)
                .HasForeignKey(d => d.IdEncuestaResuelta);
            this.HasOptional(t => t.M_Preguntas)
                .WithMany(t => t.M_PreguntasResueltas)
                .HasForeignKey(d => d.IdPregunta);

        }
    }
}
