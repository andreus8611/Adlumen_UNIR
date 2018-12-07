using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class M_IdiomasMap : EntityTypeConfiguration<M_Idiomas>
    {
        public M_IdiomasMap()
        {
            // Primary Key
            this.HasKey(t => t.IdIdioma);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Mime)
                .HasMaxLength(8);

            // Table & Column Mappings
            this.ToTable("M_Idiomas");
            this.Property(t => t.IdIdioma).HasColumnName("IdIdioma");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Mime).HasColumnName("Mime");
        }
    }
}
