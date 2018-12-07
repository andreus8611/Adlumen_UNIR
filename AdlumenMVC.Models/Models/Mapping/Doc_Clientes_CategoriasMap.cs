using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Doc_Clientes_CategoriasMap : EntityTypeConfiguration<Doc_Clientes_Categorias>
    {
        public Doc_Clientes_CategoriasMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdCliente, t.IdCategoria });

            // Properties
            this.Property(t => t.IdCliente)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdCategoria)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Doc_Clientes_Categorias");
            this.Property(t => t.IdCliente).HasColumnName("IdCliente");
            this.Property(t => t.IdCategoria).HasColumnName("IdCategoria");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Doc_Categorias)
                .WithMany(t => t.Doc_Clientes_Categorias)
                .HasForeignKey(d => d.IdCategoria);
            this.HasRequired(t => t.Sys_Clientes)
                .WithMany(t => t.Doc_Clientes_Categorias)
                .HasForeignKey(d => d.IdCliente);

        }
    }
}
