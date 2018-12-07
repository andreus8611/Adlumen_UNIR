using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Org_EmpleadosMap : EntityTypeConfiguration<Org_Empleados>
    {
        public Org_EmpleadosMap()
        {
            // Primary Key
            this.HasKey(t => t.IdEmpleado);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Apellido)
                .HasMaxLength(256);

            this.Property(t => t.Identificacion)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Foto)
                .HasMaxLength(256);

            this.Property(t => t.Correo)
                .HasMaxLength(50);

            this.Property(t => t.HojaVida)
                .HasMaxLength(256);

            this.Property(t => t.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.UsuarioModificacion)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Org_Empleados");
            this.Property(t => t.IdEmpleado).HasColumnName("IdEmpleado");
            this.Property(t => t.IdCargo).HasColumnName("IdCargo");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Apellido).HasColumnName("Apellido");
            this.Property(t => t.IdIdentificacionTipo).HasColumnName("IdIdentificacionTipo");
            this.Property(t => t.Identificacion).HasColumnName("Identificacion");
            this.Property(t => t.Foto).HasColumnName("Foto");
            this.Property(t => t.Correo).HasColumnName("Correo");
            this.Property(t => t.Observaciones).HasColumnName("Observaciones");
            this.Property(t => t.Competencias).HasColumnName("Competencias");
            this.Property(t => t.HojaVida).HasColumnName("HojaVida");
            this.Property(t => t.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            this.Property(t => t.FechaCreacion).HasColumnName("FechaCreacion");
            this.Property(t => t.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            this.Property(t => t.FechaModificacion).HasColumnName("FechaModificacion");
            this.Property(t => t.Retirado).HasColumnName("Retirado");
            this.Property(t => t.IdUsuario).HasColumnName("IdUsuario");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Org_Cargos)
                .WithMany(t => t.Org_Empleados)
                .HasForeignKey(d => d.IdCargo);
            this.HasRequired(t => t.Org_IdentificacionTipos)
                .WithMany(t => t.Org_Empleados)
                .HasForeignKey(d => d.IdIdentificacionTipo);
            this.HasOptional(t => t.Sys_Usuarios)
                .WithMany(t => t.Org_Empleados)
                .HasForeignKey(d => d.IdUsuario);

        }
    }
}
