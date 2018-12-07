using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_CapacitacionBeneficiarioMap : EntityTypeConfiguration<Pry_CapacitacionBeneficiario>
    {
        public Pry_CapacitacionBeneficiarioMap()
        {
            // Primary Key
            this.HasKey(t => t.IdCapacitacionBeneficiario);

            // Properties
            // Table & Column Mappings
            this.ToTable("Pry_CapacitacionBeneficiario");
            this.Property(t => t.IdCapacitacionBeneficiario).HasColumnName("IdCapacitacionBeneficiario");
            this.Property(t => t.IdCapacitacion).HasColumnName("IdCapacitacion");
            this.Property(t => t.IdBeneficiario).HasColumnName("IdBeneficiario");
            this.Property(t => t.FechaInscripcion).HasColumnName("FechaInscripcion");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Pry_Beneficiarios)
                .WithMany(t => t.Pry_CapacitacionBeneficiario)
                .HasForeignKey(d => d.IdBeneficiario);
            this.HasRequired(t => t.Pry_Capacitaciones)
                .WithMany(t => t.Pry_CapacitacionBeneficiario)
                .HasForeignKey(d => d.IdCapacitacion);

        }
    }
}
