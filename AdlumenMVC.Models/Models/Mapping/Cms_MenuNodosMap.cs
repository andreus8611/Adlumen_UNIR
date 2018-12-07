using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Cms_MenuNodosMap : EntityTypeConfiguration<Cms_MenuNodos>
    {
        public Cms_MenuNodosMap()
        {
            // Primary Key
            this.HasKey(t => t.IdNodo);

            // Properties
            this.Property(t => t.Destino)
                .HasMaxLength(50);

            this.Property(t => t.Url)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Nombre)
                .HasMaxLength(256);

            this.Property(t => t.Descripcion)
                .HasMaxLength(256);

            this.Property(t => t.IconoUrl)
                .HasMaxLength(256);

            this.Property(t => t.UsuarioCreacion)
                .HasMaxLength(256);

            this.Property(t => t.UsuarioModificacion)
                .HasMaxLength(256);

            this.Property(t => t.Roles)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Cms_MenuNodos");
            this.Property(t => t.IdNodo).HasColumnName("IdNodo");
            this.Property(t => t.IdMenu).HasColumnName("IdMenu");
            this.Property(t => t.IdPadre).HasColumnName("IdPadre");
            this.Property(t => t.Posicion).HasColumnName("Posicion");
            this.Property(t => t.Destino).HasColumnName("Destino");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.IconoUrl).HasColumnName("IconoUrl");
            this.Property(t => t.Estado).HasColumnName("Estado");
            this.Property(t => t.FechaCreacion).HasColumnName("FechaCreacion");
            this.Property(t => t.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            this.Property(t => t.FechaModificacion).HasColumnName("FechaModificacion");
            this.Property(t => t.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            this.Property(t => t.Roles).HasColumnName("Roles");
            this.Property(t => t.RutaXml).HasColumnName("RutaXml");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Cms_Menus)
                .WithMany(t => t.Cms_MenuNodos)
                .HasForeignKey(d => d.IdMenu);

        }
    }
}
