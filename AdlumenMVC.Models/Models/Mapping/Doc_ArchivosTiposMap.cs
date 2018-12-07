using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Doc_ArchivosTiposMap : EntityTypeConfiguration<Doc_ArchivosTipos>
    {
        public Doc_ArchivosTiposMap()
        {
            // Primary Key
            this.HasKey(t => t.IdTipoArchivo);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Mime_Type)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Doc_ArchivosTipos");
            this.Property(t => t.IdTipoArchivo).HasColumnName("IdTipoArchivo");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Mime_Type).HasColumnName("Mime_Type");
            //this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
