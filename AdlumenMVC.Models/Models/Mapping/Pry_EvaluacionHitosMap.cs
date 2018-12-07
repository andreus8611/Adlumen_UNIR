using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_EvaluacionHitosMap : EntityTypeConfiguration<Pry_EvaluacionHitos>
    {
        public Pry_EvaluacionHitosMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdProyecto, t.IdPeriodo, t.IdResultado, t.IdActividad, t.IdHito });

            // Properties
            this.Property(t => t.IdProyecto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdPeriodo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdResultado)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdActividad)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdHito)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ObservacionED)
                .HasMaxLength(2000);

            this.Property(t => t.ObservacionUrip)
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("Pry_EvaluacionHitos");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.IdPeriodo).HasColumnName("IdPeriodo");
            this.Property(t => t.IdResultado).HasColumnName("IdResultado");
            this.Property(t => t.IdActividad).HasColumnName("IdActividad");
            this.Property(t => t.IdHito).HasColumnName("IdHito");
            this.Property(t => t.HitoEfectividad).HasColumnName("HitoEfectividad");
            this.Property(t => t.ObservacionED).HasColumnName("ObservacionED");
            this.Property(t => t.ADH).HasColumnName("ADH");
            this.Property(t => t.CV).HasColumnName("CV");
            this.Property(t => t.ObservacionUrip).HasColumnName("ObservacionUrip");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Pry_Indicadores)
                .WithMany(t => t.Pry_EvaluacionHitos)
                .HasForeignKey(d => d.IdHito);
            this.HasRequired(t => t.Pry_Objetivos)
                .WithMany(t => t.Pry_EvaluacionHitos)
                .HasForeignKey(d => d.IdResultado);
            this.HasRequired(t => t.Pry_Objetivos1)
                .WithMany(t => t.Pry_EvaluacionHitos1)
                .HasForeignKey(d => d.IdActividad);
            this.HasRequired(t => t.PRY_PERIODOSPROYECTOS)
                .WithMany(t => t.Pry_EvaluacionHitos)
                .HasForeignKey(d => d.IdPeriodo);
            this.HasRequired(t => t.Pry_Proyectos)
                .WithMany(t => t.Pry_EvaluacionHitos)
                .HasForeignKey(d => d.IdProyecto);

        }
    }
}
