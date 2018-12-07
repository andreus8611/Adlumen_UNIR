using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Doc_CategoriasMap : EntityTypeConfiguration<Doc_Categorias>
    {
        public Doc_CategoriasMap()
        {
            // Primary Key
            this.HasKey(t => t.IdCategoria);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Descripcion)
                .HasMaxLength(200);

            this.Property(t => t.Ruta)
                .HasMaxLength(256);

            this.Property(t => t.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.UsuarioModificacion)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Doc_Categorias");
            this.Property(t => t.IdCategoria).HasColumnName("IdCategoria");
            this.Property(t => t.IdPadre).HasColumnName("IdPadre");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.Ruta).HasColumnName("Ruta");
            this.Property(t => t.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            this.Property(t => t.FechaCreacion).HasColumnName("FechaCreacion");
            this.Property(t => t.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            this.Property(t => t.FechaModificacion).HasColumnName("FechaModificacion");
            this.Property(t => t.Estado).HasColumnName("Estado");
            this.Property(t => t.IdTipo).HasColumnName("IdTipo");
            this.Property(t => t.IdEmpresa).HasColumnName("IdEmpresa");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
