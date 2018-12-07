using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class M_TemasMap : EntityTypeConfiguration<M_Temas>
    {
        public M_TemasMap()
        {
            // Primary Key
            this.HasKey(t => t.IdTema);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("M_Temas");
            this.Property(t => t.IdTema).HasColumnName("IdTema");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
        }
    }
}
