using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Cms_MenusMap : EntityTypeConfiguration<Cms_Menus>
    {
        public Cms_MenusMap()
        {
            // Primary Key
            this.HasKey(t => t.IdMenu);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Cms_Menus");
            this.Property(t => t.IdMenu).HasColumnName("IdMenu");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Estado).HasColumnName("Estado");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
