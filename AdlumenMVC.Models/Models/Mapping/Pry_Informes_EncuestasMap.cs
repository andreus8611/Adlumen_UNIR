using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_Informes_EncuestasMap : EntityTypeConfiguration<Pry_Informes_Encuestas>
    {
        public Pry_Informes_EncuestasMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdInforme, t.IdPregunta });

            // Properties
            this.Property(t => t.IdInforme)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdPregunta)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Descripcion)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Pry_Informes_Encuestas");
            this.Property(t => t.IdInforme).HasColumnName("IdInforme");
            this.Property(t => t.IdPregunta).HasColumnName("IdPregunta");
            this.Property(t => t.Respuesta).HasColumnName("Respuesta");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.M_Preguntas)
                .WithMany(t => t.Pry_Informes_Encuestas)
                .HasForeignKey(d => d.IdPregunta);
            this.HasRequired(t => t.Pry_Informes)
                .WithMany(t => t.Pry_Informes_Encuestas)
                .HasForeignKey(d => d.IdInforme);

        }
    }
}
