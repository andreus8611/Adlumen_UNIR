using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Sys_UsuariosMap : EntityTypeConfiguration<Sys_Usuarios>
    {
        public Sys_UsuariosMap()
        {
            // Primary Key
            this.HasKey(t => t.IdUsuario);

            // Properties
            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Nombre)
                .HasMaxLength(250);

            this.Property(t => t.Correo)
                .HasMaxLength(250);

            this.Property(t => t.UserReport)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Sys_Usuarios");
            this.Property(t => t.IdUsuario).HasColumnName("IdUsuario");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Correo).HasColumnName("Correo");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.UserReport).HasColumnName("UserReport");
            this.Property(t => t.idEmpresa).HasColumnName("idEmpresa");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasMany(t => t.Org_Empresas)
                .WithMany(t => t.Sys_Usuarios)
                .Map(cs =>
                {
                    cs.MapLeftKey("IdUsuario");
                    cs.MapRightKey("IdEmpresa");
                    cs.ToTable("Sys_Usuarios_Empresas");
                });
        }
    }
}
