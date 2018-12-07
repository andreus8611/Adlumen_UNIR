using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class M_PosiblesRespuestasMap : EntityTypeConfiguration<M_PosiblesRespuestas>
    {
        public M_PosiblesRespuestasMap()
        {
            // Primary Key
            this.HasKey(t => t.IdPosibleRespuesta);

            // Properties
            // Table & Column Mappings
            this.ToTable("M_PosiblesRespuestas");
            this.Property(t => t.IdPosibleRespuesta).HasColumnName("IdPosibleRespuesta");
            this.Property(t => t.Respuesta).HasColumnName("Respuesta");
            this.Property(t => t.IdPregunta).HasColumnName("IdPregunta");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.M_Preguntas)
                .WithMany(t => t.M_PosiblesRespuestas)
                .HasForeignKey(d => d.IdPregunta);

        }
    }
}
