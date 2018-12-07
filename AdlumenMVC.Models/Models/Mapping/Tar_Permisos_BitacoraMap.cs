using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Tar_Permisos_BitacoraMap : EntityTypeConfiguration<Tar_Permisos_Bitacora>
    {
        public Tar_Permisos_BitacoraMap()
        {
            // Primary Key
            this.HasKey(t => t.IdPermisoBitacora);

            // Properties
            this.Property(t => t.Permiso)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Tar_Permisos_Bitacora");
            this.Property(t => t.IdPermisoBitacora).HasColumnName("IdPermisoBitacora");
            this.Property(t => t.IdUsuario).HasColumnName("IdUsuario");
            this.Property(t => t.IdVisita).HasColumnName("IdVisita");
            this.Property(t => t.Permiso).HasColumnName("Permiso");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Sys_Usuarios)
                .WithMany(t => t.Tar_Permisos_Bitacora)
                .HasForeignKey(d => d.IdUsuario);
            this.HasOptional(t => t.Tar_Visitas)
                .WithMany(t => t.Tar_Permisos_Bitacora)
                .HasForeignKey(d => d.IdVisita);

        }
    }
}
