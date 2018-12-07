using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_Informes_DonantesMap : EntityTypeConfiguration<Pry_Informes_Donantes>
    {
        public Pry_Informes_DonantesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdInforme, t.IdDonante });

            // Properties
            this.Property(t => t.IdInforme)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdDonante)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Pry_Informes_Donantes");
            this.Property(t => t.IdInforme).HasColumnName("IdInforme");
            this.Property(t => t.IdDonante).HasColumnName("IdDonante");
            this.Property(t => t.Donacion).HasColumnName("Donacion");
            this.Property(t => t.FechaPrimeraDonacion).HasColumnName("FechaPrimeraDonacion");
            this.Property(t => t.FechaUltimaDonacion).HasColumnName("FechaUltimaDonacion");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Org_Donantes)
                .WithMany(t => t.Pry_Informes_Donantes)
                .HasForeignKey(d => d.IdDonante);
            this.HasRequired(t => t.Pry_Informes)
                .WithMany(t => t.Pry_Informes_Donantes)
                .HasForeignKey(d => d.IdInforme);

        }
    }
}
