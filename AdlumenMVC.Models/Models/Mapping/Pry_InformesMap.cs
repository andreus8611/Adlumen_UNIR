using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_InformesMap : EntityTypeConfiguration<Pry_Informes>
    {
        public Pry_InformesMap()
        {
            // Primary Key
            this.HasKey(t => t.IdInforme);

            // Properties
            this.Property(t => t.Descripcion)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Pry_Informes");
            this.Property(t => t.IdInforme).HasColumnName("IdInforme");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.FechaProgramada).HasColumnName("FechaProgramada");
            this.Property(t => t.FechaInforme).HasColumnName("FechaInforme");
            this.Property(t => t.PresupuestoMeta).HasColumnName("PresupuestoMeta");
            this.Property(t => t.PresupuestoEjecutado).HasColumnName("PresupuestoEjecutado");
            this.Property(t => t.AvanceMeta).HasColumnName("AvanceMeta");
            this.Property(t => t.AvanceEjecutado).HasColumnName("AvanceEjecutado");
            this.Property(t => t.DescripcionSupuestos).HasColumnName("DescripcionSupuestos");
            this.Property(t => t.Informe).HasColumnName("Informe");
            this.Property(t => t.EvaluacionComponentes).HasColumnName("EvaluacionComponentes");
            this.Property(t => t.EvaluacionComponentesDes).HasColumnName("EvaluacionComponentesDes");
            this.Property(t => t.EvaluacionProposito).HasColumnName("EvaluacionProposito");
            this.Property(t => t.EvaluacionPropositoDes).HasColumnName("EvaluacionPropositoDes");
            this.Property(t => t.Lecciones).HasColumnName("Lecciones");
            this.Property(t => t.Acciones).HasColumnName("Acciones");
            this.Property(t => t.IdEstado).HasColumnName("IdEstado");
            this.Property(t => t.IdEstadoNotificado).HasColumnName("IdEstadoNotificado");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Pry_InformesEstados)
                .WithMany(t => t.Pry_Informes)
                .HasForeignKey(d => d.IdEstado);
            this.HasOptional(t => t.Pry_NivelAceptacion)
                .WithMany(t => t.Pry_Informes)
                .HasForeignKey(d => d.EvaluacionProposito);
            this.HasOptional(t => t.Pry_NivelAceptacion1)
                .WithMany(t => t.Pry_Informes1)
                .HasForeignKey(d => d.EvaluacionComponentes);
            this.HasOptional(t => t.Pry_Proyectos)
                .WithMany(t => t.Pry_Informes)
                .HasForeignKey(d => d.IdProyecto);

        }
    }
}
