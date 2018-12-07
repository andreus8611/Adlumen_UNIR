using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_ObjetivosMap : EntityTypeConfiguration<Pry_Objetivos>
    {
        public Pry_ObjetivosMap()
        {
            // Primary Key
            this.HasKey(t => t.IdObjetivo);

            // Properties
            this.Property(t => t.Codigo)
                .HasMaxLength(50);

            this.Property(t => t.Descripcion)
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("Pry_Objetivos");
            this.Property(t => t.IdObjetivo).HasColumnName("IdObjetivo");
            this.Property(t => t.IdPadre).HasColumnName("IdPadre");
            this.Property(t => t.IdObjetivoClase).HasColumnName("IdObjetivoClase");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.Eliminado).HasColumnName("Eliminado");
            this.Property(t => t.IdEmpresa).HasColumnName("IdEmpresa");
            this.Property(t => t.IdResponsable).HasColumnName("IdResponsable");
            this.Property(t => t.FechaInicio).HasColumnName("FechaInicio");
            this.Property(t => t.FechaFin).HasColumnName("FechaFin");
            this.Property(t => t.Ponderado).HasColumnName("Ponderado");
            this.Property(t => t.Progreso).HasColumnName("Progreso");
            this.Property(t => t.IdNivelAceptacion).HasColumnName("IdNivelAceptacion");
            this.Property(t => t.Efectividad).HasColumnName("Efectividad");
            this.Property(t => t.Eficacia).HasColumnName("Eficacia");
            this.Property(t => t.Eficiencia).HasColumnName("Eficiencia");
            this.Property(t => t.Costo).HasColumnName("Costo");
            this.Property(t => t.IdNivelAceptacionEfectividad).HasColumnName("IdNivelAceptacionEfectividad");
            this.Property(t => t.IdNivelAceptacionEficacia).HasColumnName("IdNivelAceptacionEficacia");
            this.Property(t => t.IdNivelAceptacionEficiencia).HasColumnName("IdNivelAceptacionEficiencia");
            this.Property(t => t.IdNivelAceptacionCosto).HasColumnName("IdNivelAceptacionCosto");
            this.Property(t => t.CostoNotificado).HasColumnName("CostoNotificado");
            this.Property(t => t.EfectividadNotificada).HasColumnName("EfectividadNotificada");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Org_Empresas)
                .WithMany(t => t.Pry_Objetivos)
                .HasForeignKey(d => d.IdEmpresa);
            this.HasOptional(t => t.Pry_ObjetivosClase)
                .WithMany(t => t.Pry_Objetivos)
                .HasForeignKey(d => d.IdObjetivoClase);

        }
    }
}
