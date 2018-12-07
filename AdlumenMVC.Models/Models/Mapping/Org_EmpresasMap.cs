using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Org_EmpresasMap : EntityTypeConfiguration<Org_Empresas>
    {
        public Org_EmpresasMap()
        {
            // Primary Key
            this.HasKey(t => t.IdEmpresa);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Ubicacion)
                .HasMaxLength(256);

            this.Property(t => t.URL)
                .HasMaxLength(256);

            this.Property(t => t.Telefono)
                .HasMaxLength(50);

            this.Property(t => t.Logo)
                .HasMaxLength(256);

            this.Property(t => t.Identificacion)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.UsuarioModificacion)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Org_Empresas");
            this.Property(t => t.IdEmpresa).HasColumnName("IdEmpresa");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Ubicacion).HasColumnName("Ubicacion");
            this.Property(t => t.URL).HasColumnName("URL");
            this.Property(t => t.Telefono).HasColumnName("Telefono");
            this.Property(t => t.Logo).HasColumnName("Logo");
            this.Property(t => t.IdIdentificacionTipo).HasColumnName("IdIdentificacionTipo");
            this.Property(t => t.Identificacion).HasColumnName("Identificacion");
            this.Property(t => t.IdPais).HasColumnName("IdPais");
            this.Property(t => t.IdMenuAdministracion).HasColumnName("IdMenuAdministracion");
            this.Property(t => t.IdMenuSuperior).HasColumnName("IdMenuSuperior");
            this.Property(t => t.IdMenuIzquierdo).HasColumnName("IdMenuIzquierdo");
            this.Property(t => t.IdMenuPanel).HasColumnName("IdMenuPanel");
            this.Property(t => t.FechaCreacion).HasColumnName("FechaCreacion");
            this.Property(t => t.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            this.Property(t => t.FechaModificacion).HasColumnName("FechaModificacion");
            this.Property(t => t.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            this.Property(t => t.Eliminado).HasColumnName("Eliminado");
            this.Property(t => t.IdMenuSLDerecho).HasColumnName("IdMenuSLDerecho");
            this.Property(t => t.IdMenuReportes).HasColumnName("IdMenuReportes");
            this.Property(t => t.Latitude).HasColumnName("Latitude");
            this.Property(t => t.Longitude).HasColumnName("Longitude");
            this.Property(t => t.IdCliente).HasColumnName("IdCliente");
            this.Property(t => t.IdCategoriaDocumentos).HasColumnName("IdCategoriaDocumentos");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Cms_Menus)
                .WithMany(t => t.Org_Empresas)
                .HasForeignKey(d => d.IdMenuSuperior);
            this.HasOptional(t => t.Cms_Menus1)
                .WithMany(t => t.Org_Empresas1)
                .HasForeignKey(d => d.IdMenuIzquierdo);
            this.HasOptional(t => t.Cms_Menus2)
                .WithMany(t => t.Org_Empresas2)
                .HasForeignKey(d => d.IdMenuPanel);
            this.HasRequired(t => t.M_Paises)
                .WithMany(t => t.Org_Empresas)
                .HasForeignKey(d => d.IdPais);
            this.HasRequired(t => t.Org_IdentificacionTipos)
                .WithMany(t => t.Org_Empresas)
                .HasForeignKey(d => d.IdIdentificacionTipo);
            this.HasOptional(t => t.Sys_Clientes)
                .WithMany(t => t.Org_Empresas)
                .HasForeignKey(d => d.IdCliente);

        }
    }
}
