using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class ModuloMap : EntityTypeConfiguration<Modulo>
    {
        public ModuloMap()
        {
            // Primary Key
            this.HasKey(t => t.ModuloId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Moduloes");
            this.Property(t => t.ModuloId).HasColumnName("ModuloId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
        }
    }
}
