using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_IndicadoresMap : EntityTypeConfiguration<Pry_Indicadores>
    {
        public Pry_IndicadoresMap()
        {
            // Primary Key
            this.HasKey(t => t.IdIndicador);

            // Properties
            this.Property(t => t.Codigo)
                .HasMaxLength(50);

            this.Property(t => t.Descripcion)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.Definicion)
                .HasMaxLength(500);

            this.Property(t => t.Objetivo)
                .HasMaxLength(500);

            this.Property(t => t.Cualidades)
                .HasMaxLength(500);

            this.Property(t => t.UnidadMedida)
                .HasMaxLength(250);

            this.Property(t => t.Cobertura)
                .HasMaxLength(250);

            this.Property(t => t.UnidadOperativa)
                .HasMaxLength(500);

            this.Property(t => t.UnidadOperativaId)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Pry_Indicadores");
            this.Property(t => t.IdIndicador).HasColumnName("IdIndicador");
            this.Property(t => t.IdObjetivo).HasColumnName("IdObjetivo");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.IdTipo).HasColumnName("IdTipo");
            this.Property(t => t.IdSubTipo).HasColumnName("IdSubTipo");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.Definicion).HasColumnName("Definicion");
            this.Property(t => t.Objetivo).HasColumnName("Objetivo");
            this.Property(t => t.Cualidades).HasColumnName("Cualidades");
            this.Property(t => t.UnidadMedida).HasColumnName("UnidadMedida");
            this.Property(t => t.Cobertura).HasColumnName("Cobertura");
            this.Property(t => t.IdResponsableIndicador).HasColumnName("IdResponsableIndicador");
            this.Property(t => t.UnidadOperativa).HasColumnName("UnidadOperativa");
            this.Property(t => t.UnidadOperativaId).HasColumnName("UnidadOperativaId");
            this.Property(t => t.FechaInicio).HasColumnName("FechaInicio");
            this.Property(t => t.FechaFin).HasColumnName("FechaFin");
            this.Property(t => t.Base).HasColumnName("Base");
            this.Property(t => t.Meta).HasColumnName("Meta");
            this.Property(t => t.Porcentual).HasColumnName("Porcentual");
            this.Property(t => t.Ponderado).HasColumnName("Ponderado");
            this.Property(t => t.IdDatosMuestra).HasColumnName("IdDatosMuestra");
            this.Property(t => t.EfectividadNotificada).HasColumnName("EfectividadNotificada");
            this.Property(t => t.PalabrasClave).HasColumnName("PalabrasClave");
            this.Property(t => t.IdPeriodo).HasColumnName("IdPeriodo");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Org_Empleados)
                .WithMany(t => t.Pry_Indicadores)
                .HasForeignKey(d => d.IdResponsableIndicador);
            this.HasRequired(t => t.Pry_IndicadoresTipos)
                .WithMany(t => t.Pry_Indicadores)
                .HasForeignKey(d => d.IdSubTipo);
            this.HasRequired(t => t.Pry_IndicadoresTipos1)
                .WithMany(t => t.Pry_Indicadores1)
                .HasForeignKey(d => d.IdTipo);

        }
    }
}
