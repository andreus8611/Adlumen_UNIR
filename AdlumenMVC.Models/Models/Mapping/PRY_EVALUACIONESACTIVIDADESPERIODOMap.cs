using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class PRY_EVALUACIONESACTIVIDADESPERIODOMap : EntityTypeConfiguration<PRY_EVALUACIONESACTIVIDADESPERIODO>
    {
        public PRY_EVALUACIONESACTIVIDADESPERIODOMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IDOBJETIVO, t.IDPERIODO, t.IDPROYECTO });

            // Properties
            this.Property(t => t.IDOBJETIVO)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IDPERIODO)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IDPROYECTO)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.OBSERVACIONES)
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("PRY_EVALUACIONESACTIVIDADESPERIODO");
            this.Property(t => t.IDOBJETIVO).HasColumnName("IDOBJETIVO");
            this.Property(t => t.IDPERIODO).HasColumnName("IDPERIODO");
            this.Property(t => t.IDPROYECTO).HasColumnName("IDPROYECTO");
            this.Property(t => t.OBSERVACIONES).HasColumnName("OBSERVACIONES");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.PRY_EVALUACIONPROYECTOPERIODO)
                .WithMany(t => t.PRY_EVALUACIONESACTIVIDADESPERIODO)
                .HasForeignKey(d => new { d.IDPERIODO, d.IDPROYECTO });
            this.HasRequired(t => t.Pry_Objetivos)
                .WithMany(t => t.PRY_EVALUACIONESACTIVIDADESPERIODO)
                .HasForeignKey(d => d.IDOBJETIVO);

        }
    }
}
