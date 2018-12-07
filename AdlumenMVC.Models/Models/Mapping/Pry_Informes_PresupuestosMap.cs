using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_Informes_PresupuestosMap : EntityTypeConfiguration<Pry_Informes_Presupuestos>
    {
        public Pry_Informes_PresupuestosMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdInforme, t.IdPresupuesto });

            // Properties
            this.Property(t => t.IdInforme)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdPresupuesto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Pry_Informes_Presupuestos");
            this.Property(t => t.IdInforme).HasColumnName("IdInforme");
            this.Property(t => t.IdPresupuesto).HasColumnName("IdPresupuesto");
            this.Property(t => t.Ejecutado).HasColumnName("Ejecutado");
            this.Property(t => t.Utilizacion).HasColumnName("Utilizacion");
            this.Property(t => t.Evaluacion).HasColumnName("Evaluacion");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Pry_Informes)
                .WithMany(t => t.Pry_Informes_Presupuestos)
                .HasForeignKey(d => d.IdInforme);
            this.HasOptional(t => t.Pry_NivelAceptacion)
                .WithMany(t => t.Pry_Informes_Presupuestos)
                .HasForeignKey(d => d.Evaluacion);
            this.HasRequired(t => t.Pry_Presupuesto)
                .WithMany(t => t.Pry_Informes_Presupuestos)
                .HasForeignKey(d => d.IdPresupuesto);

        }
    }
}
