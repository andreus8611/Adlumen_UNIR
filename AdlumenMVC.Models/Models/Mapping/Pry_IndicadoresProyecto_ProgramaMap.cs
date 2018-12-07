using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_IndicadoresProyecto_ProgramaMap : EntityTypeConfiguration<Pry_IndicadoresProyecto_Programa>
    {
        public Pry_IndicadoresProyecto_ProgramaMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdIndicadorProyecto, t.IdIndicadorPrograma });

            // Properties
            this.Property(t => t.IdIndicadorProyecto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdIndicadorPrograma)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Pry_IndicadoresProyecto_Programa");
            this.Property(t => t.IdIndicadorProyecto).HasColumnName("IdIndicadorProyecto");
            this.Property(t => t.IdIndicadorPrograma).HasColumnName("IdIndicadorPrograma");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Pry_Indicadores)
                .WithMany(t => t.Pry_IndicadoresProyecto_Programa)
                .HasForeignKey(d => d.IdIndicadorProyecto);

        }
    }
}
