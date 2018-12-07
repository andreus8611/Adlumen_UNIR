using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Sys_Usuarios_EmpresasMap : EntityTypeConfiguration<Sys_Usuarios_Empresas>
    {
        public Sys_Usuarios_EmpresasMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdUsuario, t.IdEmpresa });

            // Properties
            this.Property(t => t.IdUsuario)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdEmpresa)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Sys_Usuarios_Empresas");
            this.Property(t => t.IdUsuario).HasColumnName("IdUsuario");
            this.Property(t => t.IdEmpresa).HasColumnName("IdEmpresa");

            // Relationships
            //this.HasRequired(t => t.Org_Empresas)
            //    .WithMany(t => t.)
            //    .HasForeignKey(d => d.IdEmpresa);
            //this.HasRequired(t => t.Sys_Usuarios)
            //    .WithMany(t => t.Sys_Usuarios_Empresas)
            //    .HasForeignKey(d => d.IdUsuario);

        }
    }
}
