using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_BeneficiariosMap : EntityTypeConfiguration<Pry_Beneficiarios>
    {
        public Pry_BeneficiariosMap()
        {
            // Primary Key
            this.HasKey(t => t.IdBeneficiario);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Telefono)
                .HasMaxLength(20);

            this.Property(t => t.Direccion)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Pry_Beneficiarios");
            this.Property(t => t.IdBeneficiario).HasColumnName("IdBeneficiario");
            this.Property(t => t.IdObjetivo).HasColumnName("IdObjetivo");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Telefono).HasColumnName("Telefono");
            this.Property(t => t.Direccion).HasColumnName("Direccion");
            this.Property(t => t.extensionTerritorial).HasColumnName("extensionTerritorial");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Pry_Objetivos)
                .WithMany(t => t.Pry_Beneficiarios)
                .HasForeignKey(d => d.IdObjetivo);

        }
    }
}
