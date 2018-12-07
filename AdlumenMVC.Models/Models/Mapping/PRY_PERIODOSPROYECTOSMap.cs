using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class PRY_PERIODOSPROYECTOSMap : EntityTypeConfiguration<PRY_PERIODOSPROYECTOS>
    {
        public PRY_PERIODOSPROYECTOSMap()
        {
            // Primary Key
            this.HasKey(t => t.IdPeriodo);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PRY_PERIODOSPROYECTOS");
            this.Property(t => t.IdPeriodo).HasColumnName("IdPeriodo");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.FechaInicio).HasColumnName("FechaInicio");
            this.Property(t => t.FechaFin).HasColumnName("FechaFin");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.Activo).HasColumnName("Activo");
            this.Property(t => t.Secuencia).HasColumnName("Secuencia");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Pry_Proyectos)
                .WithMany(t => t.PRY_PERIODOSPROYECTOS)
                .HasForeignKey(d => d.IdProyecto);

        }
    }
}
