using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Doc_DocumentosMap : EntityTypeConfiguration<Doc_Documentos>
    {
        public Doc_DocumentosMap()
        {
            // Primary Key
            this.HasKey(t => t.IdDocumento);

            // Properties
            this.Property(t => t.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PalabrasClaves)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Resumen)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Url)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.UsuarioModificacion)
                .HasMaxLength(256);

            this.Property(t => t.Roles)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Doc_Documentos");
            this.Property(t => t.IdDocumento).HasColumnName("IdDocumento");
            this.Property(t => t.IdCategoria).HasColumnName("IdCategoria");
            this.Property(t => t.IdTipoArchivo).HasColumnName("IdTipoArchivo");
            this.Property(t => t.Titulo).HasColumnName("Titulo");
            this.Property(t => t.PalabrasClaves).HasColumnName("PalabrasClaves");
            this.Property(t => t.Resumen).HasColumnName("Resumen");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            this.Property(t => t.FechaCreacion).HasColumnName("FechaCreacion");
            this.Property(t => t.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            this.Property(t => t.FechaModificacion).HasColumnName("FechaModificacion");
            this.Property(t => t.Roles).HasColumnName("Roles");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Doc_ArchivosTipos)
                .WithMany(t => t.Doc_Documentos)
                .HasForeignKey(d => d.IdTipoArchivo);
            this.HasRequired(t => t.Doc_Categorias)
                .WithMany(t => t.Doc_Documentos)
                .HasForeignKey(d => d.IdCategoria);

        }
    }
}
