using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class PRY_INFORMESICADOCUMENTOSMap : EntityTypeConfiguration<PRY_INFORMESICADOCUMENTOS>
    {
        public PRY_INFORMESICADOCUMENTOSMap()
        {
            // Primary Key
            this.HasKey(t => t.IDDOCUMENTO);

            // Properties
            this.Property(t => t.DESCRIPCION)
                .HasMaxLength(250);

            this.Property(t => t.URL)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.NOMBRE)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("PRY_INFORMESICADOCUMENTOS");
            this.Property(t => t.IDDOCUMENTO).HasColumnName("IDDOCUMENTO");
            this.Property(t => t.IDINFORME).HasColumnName("IDINFORME");
            this.Property(t => t.DESCRIPCION).HasColumnName("DESCRIPCION");
            this.Property(t => t.URL).HasColumnName("URL");
            this.Property(t => t.NOMBRE).HasColumnName("NOMBRE");
            this.Property(t => t.TIPO).HasColumnName("TIPO");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.PRY_INFORMESICA)
                .WithMany(t => t.PRY_INFORMESICADOCUMENTOS)
                .HasForeignKey(d => d.IDINFORME);

        }
    }
}
