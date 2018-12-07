using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class View_InformeAdministrativoITFUNIPMap : EntityTypeConfiguration<View_InformeAdministrativoITFUNIP>
    {
        public View_InformeAdministrativoITFUNIPMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdProyecto, t.Pais, t.Entidad_Desarrolladora, t.IdPeriodo, t.Periodo });

            // Properties
            this.Property(t => t.Programa)
                .HasMaxLength(500);

            this.Property(t => t.IdProyecto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Proyecto)
                .HasMaxLength(500);

            this.Property(t => t.Codigo)
                .HasMaxLength(50);

            this.Property(t => t.Pais)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Entidad_Desarrolladora)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.IdPeriodo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Periodo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Actividad)
                .HasMaxLength(50);

            this.Property(t => t.Descripcion_de_Actividad)
                .HasMaxLength(2000);

            this.Property(t => t.Observacion_de_la_Actividad)
                .HasMaxLength(2000);

            this.Property(t => t.Recomendaciones)
                .HasMaxLength(2000);

            this.Property(t => t.Observaciones_Generales)
                .HasMaxLength(2000);

            this.Property(t => t.Datos_Financieros)
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("View_InformeAdministrativoITFUNIP");
            this.Property(t => t.Programa).HasColumnName("Programa");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.Proyecto).HasColumnName("Proyecto");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.Fecha_de_Inicio).HasColumnName("Fecha_de_Inicio");
            this.Property(t => t.Fecha_de_Vencimiento).HasColumnName("Fecha_de_Vencimiento");
            this.Property(t => t.Pais).HasColumnName("Pais");
            this.Property(t => t.Entidad_Desarrolladora).HasColumnName("Entidad_Desarrolladora");
            this.Property(t => t.IdPeriodo).HasColumnName("IdPeriodo");
            this.Property(t => t.Periodo).HasColumnName("Periodo");
            this.Property(t => t.ObjetivoActividad).HasColumnName("ObjetivoActividad");
            this.Property(t => t.Actividad).HasColumnName("Actividad");
            this.Property(t => t.Descripcion_de_Actividad).HasColumnName("Descripcion_de_Actividad");
            this.Property(t => t.Observacion_de_la_Actividad).HasColumnName("Observacion_de_la_Actividad");
            this.Property(t => t.Recomendaciones).HasColumnName("Recomendaciones");
            this.Property(t => t.Observaciones_Generales).HasColumnName("Observaciones_Generales");
            this.Property(t => t.Datos_Financieros).HasColumnName("Datos_Financieros");
        }
    }
}
