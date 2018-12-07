using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class M_PreguntasMap : EntityTypeConfiguration<M_Preguntas>
    {
        public M_PreguntasMap()
        {
            // Primary Key
            this.HasKey(t => t.IdPregunta);

            // Properties
            // Table & Column Mappings
            this.ToTable("M_Preguntas");
            this.Property(t => t.IdPregunta).HasColumnName("IdPregunta");
            this.Property(t => t.IdEncuesta).HasColumnName("IdEncuesta");
            this.Property(t => t.Pregunta).HasColumnName("Pregunta");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
            this.Property(t => t.Orden).HasColumnName("Orden");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.M_Encuestas)
                .WithMany(t => t.M_Preguntas)
                .HasForeignKey(d => d.IdEncuesta);

        }
    }
}
