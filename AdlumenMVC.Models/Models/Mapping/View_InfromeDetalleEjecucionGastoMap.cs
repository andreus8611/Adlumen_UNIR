using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class View_InfromeDetalleEjecucionGastoMap : EntityTypeConfiguration<View_InfromeDetalleEjecucionGasto>
    {
        public View_InfromeDetalleEjecucionGastoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdProyecto, t.Pais, t.Ejecutor, t.Periodo_Movimiento, t.ObjetivoProposito, t.ObjetivoResultado, t.ObjetivoActividad, t.IdPartidaGasto, t.Partida_Gasto, t.Taza_Cambio, t.Cheque_Operacion, t.Numero_Comprobante });

            // Properties
            this.Property(t => t.Proyecto)
                .HasMaxLength(500);

            this.Property(t => t.IdProyecto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Pais)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Ejecutor)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Periodo_Movimiento)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ObjetivoProposito)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Proposito)
                .HasMaxLength(2000);

            this.Property(t => t.ObjetivoResultado)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Resultado)
                .HasMaxLength(2000);

            this.Property(t => t.ObjetivoActividad)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Actividad)
                .HasMaxLength(50);

            this.Property(t => t.Descripcion_de_Actividad)
                .HasMaxLength(2000);

            this.Property(t => t.IdPresupuestoActividad)
                .HasMaxLength(150);

            this.Property(t => t.IdPartidaGasto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Partida_Gasto)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Beneficiario)
                .HasMaxLength(150);

            this.Property(t => t.Taza_Cambio)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Cheque_Operacion)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Numero_Comprobante)
                .IsRequired()
                .HasMaxLength(9);

            // Table & Column Mappings
            this.ToTable("View_InfromeDetalleEjecucionGasto");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Proyecto).HasColumnName("Proyecto");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.Pais).HasColumnName("Pais");
            this.Property(t => t.Ejecutor).HasColumnName("Ejecutor");
            this.Property(t => t.Fecha_de_Inicio).HasColumnName("Fecha_de_Inicio");
            this.Property(t => t.Fecha_de_Vencimiento).HasColumnName("Fecha_de_Vencimiento");
            this.Property(t => t.Periodo_Movimiento).HasColumnName("Periodo_Movimiento");
            this.Property(t => t.ObjetivoProposito).HasColumnName("ObjetivoProposito");
            this.Property(t => t.Proposito).HasColumnName("Proposito");
            this.Property(t => t.Presupuesto_Proposito).HasColumnName("Presupuesto_Proposito");
            this.Property(t => t.ObjetivoResultado).HasColumnName("ObjetivoResultado");
            this.Property(t => t.Resultado).HasColumnName("Resultado");
            this.Property(t => t.ObjetivoActividad).HasColumnName("ObjetivoActividad");
            this.Property(t => t.Actividad).HasColumnName("Actividad");
            this.Property(t => t.Descripcion_de_Actividad).HasColumnName("Descripcion_de_Actividad");
            this.Property(t => t.Presupuesto_Actividad).HasColumnName("Presupuesto_Actividad");
            this.Property(t => t.IdPresupuestoActividad).HasColumnName("IdPresupuestoActividad");
            this.Property(t => t.Monto_Movimiento).HasColumnName("Monto_Movimiento");
            this.Property(t => t.Tipo_Presupuesto_Actividad).HasColumnName("Tipo_Presupuesto_Actividad");
            this.Property(t => t.IdPartidaGasto).HasColumnName("IdPartidaGasto");
            this.Property(t => t.Partida_Gasto).HasColumnName("Partida_Gasto");
            this.Property(t => t.Beneficiario).HasColumnName("Beneficiario");
            this.Property(t => t.Aportes).HasColumnName("Aportes");
            this.Property(t => t.Contrapartida).HasColumnName("Contrapartida");
            this.Property(t => t.Fecha_Pago).HasColumnName("Fecha_Pago");
            this.Property(t => t.Taza_Cambio).HasColumnName("Taza_Cambio");
            this.Property(t => t.Cheque_Operacion).HasColumnName("Cheque_Operacion");
            this.Property(t => t.Numero_Comprobante).HasColumnName("Numero_Comprobante");
        }
    }
}
