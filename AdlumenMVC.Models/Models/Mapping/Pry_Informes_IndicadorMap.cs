using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_Informes_IndicadorMap : EntityTypeConfiguration<Pry_Informes_Indicador>
    {
        public Pry_Informes_IndicadorMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdInforme, t.IdIndicador });

            // Properties
            this.Property(t => t.IdInforme)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdIndicador)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Pry_Informes_Indicador");
            this.Property(t => t.IdInforme).HasColumnName("IdInforme");
            this.Property(t => t.IdIndicador).HasColumnName("IdIndicador");
            this.Property(t => t.Meta).HasColumnName("Meta");
            this.Property(t => t.IdDatosMuestra).HasColumnName("IdDatosMuestra");
            this.Property(t => t.Evaluacion).HasColumnName("Evaluacion");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Pry_DatosMuestras)
                .WithMany(t => t.Pry_Informes_Indicador)
                .HasForeignKey(d => d.IdDatosMuestra);
            this.HasRequired(t => t.Pry_Indicadores)
                .WithMany(t => t.Pry_Informes_Indicador)
                .HasForeignKey(d => d.IdIndicador);
            this.HasRequired(t => t.Pry_Informes)
                .WithMany(t => t.Pry_Informes_Indicador)
                .HasForeignKey(d => d.IdInforme);
            this.HasOptional(t => t.Pry_NivelAceptacion)
                .WithMany(t => t.Pry_Informes_Indicador)
                .HasForeignKey(d => d.Evaluacion);

        }
    }
}
