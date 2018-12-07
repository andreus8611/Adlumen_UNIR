using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class M_MonedasMap : EntityTypeConfiguration<M_Monedas>
    {
        public M_MonedasMap()
        {
            // Primary Key
            this.HasKey(t => t.IdMoneda);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Representacion)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Codigo)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("M_Monedas");
            this.Property(t => t.IdMoneda).HasColumnName("IdMoneda");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Representacion).HasColumnName("Representacion");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            HasMany(e => e.m_TipCambio)
            .WithRequired(e => e.M_Monedas)
            .HasForeignKey(e => e.idMoneda);
        }
    }
}
