using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class View_Informe_de_SaldosMap : EntityTypeConfiguration<View_Informe_de_Saldos>
    {
        public View_Informe_de_SaldosMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdProyecto, t.Ejecutor, t.Pais, t.ObjetivoProposito, t.ObjetivoResultado, t.ObjetivoActividad, t.IdPresupuestoActividad, t.Fecha_Gasto, t.IdMovimiento });

            // Properties
            this.Property(t => t.Proyecto)
                .HasMaxLength(500);

            this.Property(t => t.IdProyecto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Ejecutor)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Pais)
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
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Descripcion_Monto)
                .HasMaxLength(500);

            this.Property(t => t.IdMovimiento)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("View_Informe de Saldos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Proyecto).HasColumnName("Proyecto");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.Ejecutor).HasColumnName("Ejecutor");
            this.Property(t => t.Pais).HasColumnName("Pais");
            this.Property(t => t.Fecha_de_Vencimiento).HasColumnName("Fecha_de_Vencimiento");
            this.Property(t => t.Fecha_de_Inicio).HasColumnName("Fecha_de_Inicio");
            this.Property(t => t.ObjetivoProposito).HasColumnName("ObjetivoProposito");
            this.Property(t => t.Presupuesto_Proposito).HasColumnName("Presupuesto_Proposito");
            this.Property(t => t.Proposito).HasColumnName("Proposito");
            this.Property(t => t.Presupuesto_de_Resultado).HasColumnName("Presupuesto_de_Resultado");
            this.Property(t => t.Tipo_Presupuesto_Resultado).HasColumnName("Tipo_Presupuesto_Resultado");
            this.Property(t => t.ObjetivoResultado).HasColumnName("ObjetivoResultado");
            this.Property(t => t.Resultado).HasColumnName("Resultado");
            this.Property(t => t.ObjetivoActividad).HasColumnName("ObjetivoActividad");
            this.Property(t => t.Actividad).HasColumnName("Actividad");
            this.Property(t => t.Descripcion_de_Actividad).HasColumnName("Descripcion_de_Actividad");
            this.Property(t => t.IdPresupuestoActividad).HasColumnName("IdPresupuestoActividad");
            this.Property(t => t.Tipo_de_Presupuesto_Actividad).HasColumnName("Tipo_de_Presupuesto_Actividad");
            this.Property(t => t.Presupuesto_de_Actividad).HasColumnName("Presupuesto_de_Actividad");
            this.Property(t => t.Monto_Movimiento).HasColumnName("Monto_Movimiento");
            this.Property(t => t.Fecha_Gasto).HasColumnName("Fecha_Gasto");
            this.Property(t => t.Año).HasColumnName("Año");
            this.Property(t => t.Descripcion_Monto).HasColumnName("Descripcion_Monto");
            this.Property(t => t.IdMovimiento).HasColumnName("IdMovimiento");
        }
    }
}
