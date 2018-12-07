using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class PRY_EVALUACIONPROYECTOPERIODOMap : EntityTypeConfiguration<PRY_EVALUACIONPROYECTOPERIODO>
    {
        public PRY_EVALUACIONPROYECTOPERIODOMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IDPERIODO, t.IDPROYECTO });

            // Properties
            this.Property(t => t.IDPERIODO)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IDPROYECTO)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DATOSFINANCIEROS)
                .HasMaxLength(2000);

            this.Property(t => t.OBSERVACIONES)
                .HasMaxLength(2000);

            this.Property(t => t.RECOMENDACIONES)
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("PRY_EVALUACIONPROYECTOPERIODO");
            this.Property(t => t.IDPERIODO).HasColumnName("IDPERIODO");
            this.Property(t => t.IDPROYECTO).HasColumnName("IDPROYECTO");
            this.Property(t => t.DATOSFINANCIEROS).HasColumnName("DATOSFINANCIEROS");
            this.Property(t => t.OBSERVACIONES).HasColumnName("OBSERVACIONES");
            this.Property(t => t.RECOMENDACIONES).HasColumnName("RECOMENDACIONES");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.PRY_PERIODOSPROYECTOS)
                .WithMany(t => t.PRY_EVALUACIONPROYECTOPERIODO)
                .HasForeignKey(d => d.IDPERIODO);
            this.HasRequired(t => t.Pry_Proyectos)
                .WithMany(t => t.PRY_EVALUACIONPROYECTOPERIODO)
                .HasForeignKey(d => d.IDPROYECTO);

        }
    }
}
