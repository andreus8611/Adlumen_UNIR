using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Org_EmpleadosCargosHistoricoMap : EntityTypeConfiguration<Org_EmpleadosCargosHistorico>
    {
        public Org_EmpleadosCargosHistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.IdEmpleadoCargo);

            // Properties
            this.Property(t => t.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.UsuarioModificacion)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Org_EmpleadosCargosHistorico");
            this.Property(t => t.IdEmpleadoCargo).HasColumnName("IdEmpleadoCargo");
            this.Property(t => t.IdEmpleado).HasColumnName("IdEmpleado");
            this.Property(t => t.IdCargo).HasColumnName("IdCargo");
            this.Property(t => t.FechaInicioCargo).HasColumnName("FechaInicioCargo");
            this.Property(t => t.FechaFinCargo).HasColumnName("FechaFinCargo");
            this.Property(t => t.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            this.Property(t => t.FechaCreacion).HasColumnName("FechaCreacion");
            this.Property(t => t.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            this.Property(t => t.FechaModificacion).HasColumnName("FechaModificacion");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Org_Cargos)
                .WithMany(t => t.Org_EmpleadosCargosHistorico)
                .HasForeignKey(d => d.IdCargo);
            this.HasRequired(t => t.Org_Empleados)
                .WithMany(t => t.Org_EmpleadosCargosHistorico)
                .HasForeignKey(d => d.IdEmpleado);

        }
    }
}
