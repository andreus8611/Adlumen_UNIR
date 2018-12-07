using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class m_TipCambioMap : EntityTypeConfiguration<m_TipCambio>
    {
        public m_TipCambioMap()
        {
            // Primary Key
            this.HasKey(t => t.idTipCambio);

            // Properties
            // Table & Column Mappings
            this.ToTable("m_TipCambio");
            this.Property(t => t.idTipCambio).HasColumnName("idTipCambio");
            this.Property(t => t.idMoneda).HasColumnName("idMoneda");
            this.Property(t => t.FecTipCambio).HasColumnName("FecTipCambio");
            this.Property(t => t.ValCompra).HasColumnName("ValCompra");
            this.Property(t => t.ValVenta).HasColumnName("ValVenta");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            //this.Ignore(x => x.M_Monedas);

            // Relationships
            //this.HasRequired(t => t.M_Monedas)
            //    .WithMany(t => t.m_TipCambio)
            //    .HasForeignKey(x => x.idMoneda);
            HasRequired(e => e.M_Monedas)
            .WithMany()
            .HasForeignKey(e => e.idMoneda);

        }
    }
}
