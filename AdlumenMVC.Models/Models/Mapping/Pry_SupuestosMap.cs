using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_SupuestosMap : EntityTypeConfiguration<Pry_Supuestos>
    {
        public Pry_SupuestosMap()
        {
            // Primary Key
            this.HasKey(t => t.IdSupuesto);

            // Properties
            this.Property(t => t.Descripcion)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.PlanContingencia)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Pry_Supuestos");
            this.Property(t => t.IdSupuesto).HasColumnName("IdSupuesto");
            this.Property(t => t.IdObjetivo).HasColumnName("IdObjetivo");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.Impacto).HasColumnName("Impacto");
            this.Property(t => t.PlanContingencia).HasColumnName("PlanContingencia");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Pry_Objetivos)
                .WithMany(t => t.Pry_Supuestos)
                .HasForeignKey(d => d.IdObjetivo);

        }
    }
}
