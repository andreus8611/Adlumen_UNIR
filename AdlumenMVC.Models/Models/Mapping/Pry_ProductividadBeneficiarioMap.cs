using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_ProductividadBeneficiarioMap : EntityTypeConfiguration<Pry_ProductividadBeneficiario>
    {
        public Pry_ProductividadBeneficiarioMap()
        {
            // Primary Key
            this.HasKey(t => t.IdProductividadBeneficiario);

            // Properties
            this.Property(t => t.CultivoSembrado)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Pry_ProductividadBeneficiario");
            this.Property(t => t.IdProductividadBeneficiario).HasColumnName("IdProductividadBeneficiario");
            this.Property(t => t.IdBeneficiario).HasColumnName("IdBeneficiario");
            this.Property(t => t.AreaSembrada).HasColumnName("AreaSembrada");
            this.Property(t => t.CultivoSembrado).HasColumnName("CultivoSembrado");
            this.Property(t => t.CantidadSembrada).HasColumnName("CantidadSembrada");
            this.Property(t => t.ProduccionCultivo).HasColumnName("ProduccionCultivo");
            this.Property(t => t.Eliminado).HasColumnName("Eliminado");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Pry_Beneficiarios)
                .WithMany(t => t.Pry_ProductividadBeneficiario)
                .HasForeignKey(d => d.IdBeneficiario);

        }
    }
}
