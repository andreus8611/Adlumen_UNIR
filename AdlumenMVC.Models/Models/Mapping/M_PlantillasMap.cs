using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class M_PlantillasMap : EntityTypeConfiguration<M_Plantillas>
    {
        public M_PlantillasMap()
        {
            // Primary Key
            this.HasKey(t => t.IdTenant);

            // Properties
            this.Property(t => t.IdTenant)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("M_Plantillas");
            this.Property(t => t.IdPlantilla).HasColumnName("IdPlantilla");
            this.Property(t => t.Plantilla).HasColumnName("Plantilla");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
