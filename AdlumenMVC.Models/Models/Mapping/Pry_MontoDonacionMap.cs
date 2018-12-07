using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_MontoDonacionMap : EntityTypeConfiguration<Pry_MontoDonacion>
    {
        public Pry_MontoDonacionMap()
        {
            // Primary Key
            this.HasKey(t => t.IdMontoDonante);

            // Properties
            // Table & Column Mappings
            this.ToTable("Pry_MontoDonacion");
            this.Property(t => t.IdMontoDonante).HasColumnName("IdMontoDonante");
            this.Property(t => t.IdMovimiento).HasColumnName("IdMovimiento");
            this.Property(t => t.IdDonante).HasColumnName("IdDonante");
            this.Property(t => t.Monto).HasColumnName("Monto");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Pry_Movimientos)
                .WithMany(t => t.Pry_MontoDonacion)
                .HasForeignKey(d => d.IdMovimiento);

        }
    }
}
