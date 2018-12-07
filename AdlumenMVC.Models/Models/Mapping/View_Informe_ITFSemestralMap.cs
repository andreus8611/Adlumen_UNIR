using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class View_Informe_ITFSemestralMap : EntityTypeConfiguration<View_Informe_ITFSemestral>
    {
        public View_Informe_ITFSemestralMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdProyecto, t.Pais, t.Ejecutor, t.Periodo, t.IdPeriodo, t.CantidadPro, t.CantidadResul, t.Indicadores_Proposito, t.IdIndicadorproposito, t.ObjetivoResultado, t.Tipo_Informe, t.Indicadores_Resultado, t.Idindicadorresultado, t.Base_Proposito, t.Base_Resultado });

            // Properties
            this.Property(t => t.Proyecto)
                .HasMaxLength(500);

            this.Property(t => t.IdProyecto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Codigo)
                .HasMaxLength(50);

            this.Property(t => t.Pais)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Ejecutor)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Periodo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.IdPeriodo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LogrosPrincipales)
                .HasMaxLength(4000);

            this.Property(t => t.Observaciones)
                .HasMaxLength(4000);

            this.Property(t => t.Factores_Exito)
                .HasMaxLength(4000);

            this.Property(t => t.Factores_Limitantes)
                .HasMaxLength(4000);

            this.Property(t => t.Condiicionalidad)
                .HasMaxLength(4000);

            this.Property(t => t.Sostenibilidad)
                .HasMaxLength(4000);

            this.Property(t => t.Problemas_y_Acciones)
                .HasMaxLength(4000);

            this.Property(t => t.Sostenibilidad_Replicas)
                .HasMaxLength(4000);

            this.Property(t => t.Proposito)
                .HasMaxLength(2000);

            this.Property(t => t.Logros_Comentarios_Proproposito)
                .HasMaxLength(4000);

            this.Property(t => t.Indicadores_Proposito)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.IdIndicadorproposito)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Explicacion_Logros_Proposito)
                .HasMaxLength(4000);

            this.Property(t => t.ObjetivoResultado)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Resultado)
                .HasMaxLength(2000);

            this.Property(t => t.Logros_Comentarios_Resultado)
                .HasMaxLength(4000);

            this.Property(t => t.Recomendaciones)
                .HasMaxLength(4000);

            this.Property(t => t.Replicas)
                .HasMaxLength(4000);

            this.Property(t => t.Avance_Principal)
                .HasMaxLength(4000);

            this.Property(t => t.Cambios_Internos)
                .HasMaxLength(4000);

            this.Property(t => t.Tipo_Informe)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Objetivo_General)
                .HasMaxLength(2000);

            this.Property(t => t.Indicadores_Resultado)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.Explicacion_logros_Resultado)
                .HasMaxLength(4000);

            this.Property(t => t.Idindicadorresultado)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("View_Informe ITFSemestral");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Proyecto).HasColumnName("Proyecto");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.Pais).HasColumnName("Pais");
            this.Property(t => t.Ejecutor).HasColumnName("Ejecutor");
            this.Property(t => t.Periodo).HasColumnName("Periodo");
            this.Property(t => t.IdPeriodo).HasColumnName("IdPeriodo");
            this.Property(t => t.LogrosPrincipales).HasColumnName("LogrosPrincipales");
            this.Property(t => t.Observaciones).HasColumnName("Observaciones");
            this.Property(t => t.Factores_Exito).HasColumnName("Factores_Exito");
            this.Property(t => t.Factores_Limitantes).HasColumnName("Factores_Limitantes");
            this.Property(t => t.Condiicionalidad).HasColumnName("Condiicionalidad");
            this.Property(t => t.Sostenibilidad).HasColumnName("Sostenibilidad");
            this.Property(t => t.Problemas_y_Acciones).HasColumnName("Problemas_y_Acciones");
            this.Property(t => t.Sostenibilidad_Replicas).HasColumnName("Sostenibilidad_Replicas");
            this.Property(t => t.ObjetivoProposito).HasColumnName("ObjetivoProposito");
            this.Property(t => t.Proposito).HasColumnName("Proposito");
            this.Property(t => t.Logros_Comentarios_Proproposito).HasColumnName("Logros_Comentarios_Proproposito");
            this.Property(t => t.CantidadPro).HasColumnName("CantidadPro");
            this.Property(t => t.CantidadResul).HasColumnName("CantidadResul");
            this.Property(t => t.Indicadores_Proposito).HasColumnName("Indicadores_Proposito");
            this.Property(t => t.IdIndicadorproposito).HasColumnName("IdIndicadorproposito");
            this.Property(t => t.Explicacion_Logros_Proposito).HasColumnName("Explicacion_Logros_Proposito");
            this.Property(t => t.ObjetivoResultado).HasColumnName("ObjetivoResultado");
            this.Property(t => t.Resultado).HasColumnName("Resultado");
            this.Property(t => t.Logros_Comentarios_Resultado).HasColumnName("Logros_Comentarios_Resultado");
            this.Property(t => t.Recomendaciones).HasColumnName("Recomendaciones");
            this.Property(t => t.Replicas).HasColumnName("Replicas");
            this.Property(t => t.Avance_Principal).HasColumnName("Avance_Principal");
            this.Property(t => t.Cambios_Internos).HasColumnName("Cambios_Internos");
            this.Property(t => t.Tipo_Informe).HasColumnName("Tipo_Informe");
            this.Property(t => t.Objetivo_General).HasColumnName("Objetivo_General");
            this.Property(t => t.Fecha_Fin).HasColumnName("Fecha_Fin");
            this.Property(t => t.Fecha_Inicio).HasColumnName("Fecha_Inicio");
            this.Property(t => t.Indicadores_Resultado).HasColumnName("Indicadores_Resultado");
            this.Property(t => t.Explicacion_logros_Resultado).HasColumnName("Explicacion_logros_Resultado");
            this.Property(t => t.Idindicadorresultado).HasColumnName("Idindicadorresultado");
            this.Property(t => t.Base_Proposito).HasColumnName("Base_Proposito");
            this.Property(t => t.Base_Resultado).HasColumnName("Base_Resultado");
        }
    }
}
