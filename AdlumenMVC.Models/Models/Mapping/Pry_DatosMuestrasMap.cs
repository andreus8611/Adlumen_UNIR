using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_DatosMuestrasMap : EntityTypeConfiguration<Pry_DatosMuestras>
    {
        public Pry_DatosMuestrasMap()
        {
            // Primary Key
            this.HasKey(t => t.IdDatosMuestra);

            // Properties
            this.Property(t => t.Observaciones)
                .HasMaxLength(500);

            this.Property(t => t.USUARIOCREACION)
                .HasMaxLength(256);

            this.Property(t => t.USUARIOMODIFICACION)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Pry_DatosMuestras");
            this.Property(t => t.IdDatosMuestra).HasColumnName("IdDatosMuestra");
            this.Property(t => t.IdIndicador).HasColumnName("IdIndicador");
            this.Property(t => t.Fecha).HasColumnName("Fecha");
            this.Property(t => t.Logro).HasColumnName("Logro");
            this.Property(t => t.Observaciones).HasColumnName("Observaciones");
            this.Property(t => t.Efectividad).HasColumnName("Efectividad");
            this.Property(t => t.IdNivelAceptacionEfectividad).HasColumnName("IdNivelAceptacionEfectividad");
            this.Property(t => t.Eficacia).HasColumnName("Eficacia");
            this.Property(t => t.IdNivelAceptacionEficacia).HasColumnName("IdNivelAceptacionEficacia");
            this.Property(t => t.IdPeriodo).HasColumnName("IdPeriodo");
            this.Property(t => t.USUARIOCREACION).HasColumnName("USUARIOCREACION");
            this.Property(t => t.FECHACREACION).HasColumnName("FECHACREACION");
            this.Property(t => t.USUARIOMODIFICACION).HasColumnName("USUARIOMODIFICACION");
            this.Property(t => t.FECHAMODIFICACION).HasColumnName("FECHAMODIFICACION");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Pry_Indicadores)
                .WithMany(t => t.Pry_DatosMuestras)
                .HasForeignKey(d => d.IdIndicador);
            this.HasOptional(t => t.Pry_NivelAceptacion)
                .WithMany(t => t.Pry_DatosMuestras)
                .HasForeignKey(d => d.IdNivelAceptacionEfectividad);
            this.HasOptional(t => t.PRY_PERIODOSPROYECTOS)
                .WithMany(t => t.Pry_DatosMuestras)
                .HasForeignKey(d => d.IdPeriodo);

        }
    }
}
