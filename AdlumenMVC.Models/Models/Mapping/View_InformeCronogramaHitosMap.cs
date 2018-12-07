using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class View_InformeCronogramaHitosMap : EntityTypeConfiguration<View_InformeCronogramaHitos>
    {
        public View_InformeCronogramaHitosMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idproyecto, t.nombreproyecto, t.idejcutor, t.nombreejecutor, t.nombrepais, t.fechainicio, t.fechafin, t.resultadoid, t.porcentajeresultado, t.nombreresultado, t.actividadid, t.actividadDes, t.porcentajeact, t.Idhito, t.hito, t.porcentajehito, t.porcentajeperiodo, t.periodo });

            // Properties
            this.Property(t => t.idproyecto)
                .IsRequired()
                .HasMaxLength(7);

            this.Property(t => t.nombreproyecto)
                .IsRequired()
                .HasMaxLength(111);

            this.Property(t => t.idejcutor)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.nombreejecutor)
                .IsRequired()
                .HasMaxLength(6);

            this.Property(t => t.nombrepais)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.fechainicio)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.fechafin)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.resultadoid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.porcentajeresultado)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.nombreresultado)
                .IsRequired()
                .HasMaxLength(18);

            this.Property(t => t.actividadid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.actividadDes)
                .IsRequired()
                .HasMaxLength(85);

            this.Property(t => t.porcentajeact)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Idhito)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.hito)
                .IsRequired()
                .HasMaxLength(47);

            this.Property(t => t.porcentajehito)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.porcentajeperiodo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.periodo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("View_InformeCronogramaHitos");
            this.Property(t => t.idproyecto).HasColumnName("idproyecto");
            this.Property(t => t.nombreproyecto).HasColumnName("nombreproyecto");
            this.Property(t => t.idejcutor).HasColumnName("idejcutor");
            this.Property(t => t.nombreejecutor).HasColumnName("nombreejecutor");
            this.Property(t => t.nombrepais).HasColumnName("nombrepais");
            this.Property(t => t.fechainicio).HasColumnName("fechainicio");
            this.Property(t => t.fechafin).HasColumnName("fechafin");
            this.Property(t => t.resultadoid).HasColumnName("resultadoid");
            this.Property(t => t.porcentajeresultado).HasColumnName("porcentajeresultado");
            this.Property(t => t.nombreresultado).HasColumnName("nombreresultado");
            this.Property(t => t.actividadid).HasColumnName("actividadid");
            this.Property(t => t.actividadDes).HasColumnName("actividadDes");
            this.Property(t => t.porcentajeact).HasColumnName("porcentajeact");
            this.Property(t => t.Idhito).HasColumnName("Idhito");
            this.Property(t => t.hito).HasColumnName("hito");
            this.Property(t => t.porcentajehito).HasColumnName("porcentajehito");
            this.Property(t => t.porcentajeperiodo).HasColumnName("porcentajeperiodo");
            this.Property(t => t.periodo).HasColumnName("periodo");
        }
    }
}
