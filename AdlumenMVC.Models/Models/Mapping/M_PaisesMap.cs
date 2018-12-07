using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class M_PaisesMap : EntityTypeConfiguration<M_Paises>
    {
        public M_PaisesMap()
        {
            // Primary Key
            this.HasKey(t => t.IdPais);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("M_Paises");
            this.Property(t => t.IdPais).HasColumnName("IdPais");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
        }
    }
}
