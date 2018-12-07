using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class View_InformeCronogramaHitos1Map : EntityTypeConfiguration<View_InformeCronogramaHitos1>
    {
        public View_InformeCronogramaHitos1Map()
        {
            // Primary Key
            this.HasKey(t => new { t.IdProyecto, t.Periodo, t.IdobjetivoResultado, t.IdobjetivoAvtividad, t.Hito, t.Meta_actividad, t.Meta_Resultado, t.Meta_Proposito, t.Idperiodo });

            // Properties
            this.Property(t => t.Proyecto)
                .HasMaxLength(500);

            this.Property(t => t.IdProyecto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Periodo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Proposito)
                .HasMaxLength(2000);

            this.Property(t => t.IdobjetivoResultado)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Entregable)
                .HasMaxLength(2000);

            this.Property(t => t.IdobjetivoAvtividad)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Actividad)
                .HasMaxLength(50);

            this.Property(t => t.Descripcion_Actividad)
                .HasMaxLength(2000);

            this.Property(t => t.Hito)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.Idperiodo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("View_InformeCronogramaHitos1");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Proyecto).HasColumnName("Proyecto");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.Fecha_de_Inicio).HasColumnName("Fecha_de_Inicio");
            this.Property(t => t.Fecha_de_Vencimiento).HasColumnName("Fecha_de_Vencimiento");
            this.Property(t => t.Periodo).HasColumnName("Periodo");
            this.Property(t => t.IdProposito).HasColumnName("IdProposito");
            this.Property(t => t.Proposito).HasColumnName("Proposito");
            this.Property(t => t.IdobjetivoResultado).HasColumnName("IdobjetivoResultado");
            this.Property(t => t.Entregable).HasColumnName("Entregable");
            this.Property(t => t.IdClaseResultdo).HasColumnName("IdClaseResultdo");
            this.Property(t => t.IdobjetivoAvtividad).HasColumnName("IdobjetivoAvtividad");
            this.Property(t => t.Actividad).HasColumnName("Actividad");
            this.Property(t => t.Descripcion_Actividad).HasColumnName("Descripcion_Actividad");
            this.Property(t => t.Fecha_de_Inicio_Actividad).HasColumnName("Fecha_de_Inicio_Actividad");
            this.Property(t => t.IdClaseActividad).HasColumnName("IdClaseActividad");
            this.Property(t => t.Fecha_de_Inicio_Resultado).HasColumnName("Fecha_de_Inicio_Resultado");
            this.Property(t => t.Hito).HasColumnName("Hito");
            this.Property(t => t.PondereadoProposito).HasColumnName("PondereadoProposito");
            this.Property(t => t.PonderedoResultado).HasColumnName("PonderedoResultado");
            this.Property(t => t.PonderedoActividad).HasColumnName("PonderedoActividad");
            this.Property(t => t.Ponderado_Hito).HasColumnName("Ponderado_Hito");
            this.Property(t => t.Meta_actividad).HasColumnName("Meta_actividad");
            this.Property(t => t.Meta_Resultado).HasColumnName("Meta_Resultado");
            this.Property(t => t.Meta_Proposito).HasColumnName("Meta_Proposito");
            this.Property(t => t.Idperiodo).HasColumnName("Idperiodo");
        }
    }
}
