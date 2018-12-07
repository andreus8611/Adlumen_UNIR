using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_MovimientosMap : EntityTypeConfiguration<Pry_Movimientos>
    {
        public Pry_MovimientosMap()
        {
            // Primary Key
            this.HasKey(t => t.IdMovimiento);

            // Properties
            this.Property(t => t.Observaciones)
                .HasMaxLength(500);

            this.Property(t => t.UrlSoporte)
                .HasMaxLength(250);

            this.Property(t => t.BENEFICIARIO)
                .HasMaxLength(150);

            this.Property(t => t.MEDIOPAGO)
                .HasMaxLength(50);

            this.Property(t => t.USUARIOCREACION)
                .HasMaxLength(256);

            this.Property(t => t.USUARIOMODIFICACION)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Pry_Movimientos");
            this.Property(t => t.IdMovimiento).HasColumnName("IdMovimiento");
            this.Property(t => t.IdPresupuesto).HasColumnName("IdPresupuesto");
            this.Property(t => t.IdProveedor).HasColumnName("IdProveedor");
            this.Property(t => t.Monto).HasColumnName("Monto");
            this.Property(t => t.Fecha).HasColumnName("Fecha");
            this.Property(t => t.Observaciones).HasColumnName("Observaciones");
            this.Property(t => t.UrlSoporte).HasColumnName("UrlSoporte");
            this.Property(t => t.IdPeriodo).HasColumnName("IdPeriodo");
            this.Property(t => t.BENEFICIARIO).HasColumnName("BENEFICIARIO");
            this.Property(t => t.MEDIOPAGO).HasColumnName("MEDIOPAGO");
            this.Property(t => t.CONTRAPARTIDA).HasColumnName("CONTRAPARTIDA");
            this.Property(t => t.APORTEPROGRAMA).HasColumnName("APORTEPROGRAMA");
            this.Property(t => t.IDPARTIDAGASTO).HasColumnName("IDPARTIDAGASTO");
            this.Property(t => t.USUARIOCREACION).HasColumnName("USUARIOCREACION");
            this.Property(t => t.FECHACREACION).HasColumnName("FECHACREACION");
            this.Property(t => t.USUARIOMODIFICACION).HasColumnName("USUARIOMODIFICACION");
            this.Property(t => t.FECHAMODIFICACION).HasColumnName("FECHAMODIFICACION");
            this.Property(t => t.MONEDALOCAL).HasColumnName("MONEDALOCAL");
            this.Property(t => t.APORTEMONEDALOCAL).HasColumnName("APORTEMONEDALOCAL");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.M_Monedas)
                .WithMany(t => t.Pry_Movimientos)
                .HasForeignKey(d => d.MONEDALOCAL);
            this.HasOptional(t => t.PRY_PARTIDAGASTOS)
                .WithMany(t => t.Pry_Movimientos)
                .HasForeignKey(d => d.IDPARTIDAGASTO);
            this.HasOptional(t => t.PRY_PERIODOSPROYECTOS)
                .WithMany(t => t.Pry_Movimientos)
                .HasForeignKey(d => d.IdPeriodo);
            this.HasOptional(t => t.Pry_Presupuesto)
                .WithMany(t => t.Pry_Movimientos)
                .HasForeignKey(d => d.IdPresupuesto);

        }
    }
}
