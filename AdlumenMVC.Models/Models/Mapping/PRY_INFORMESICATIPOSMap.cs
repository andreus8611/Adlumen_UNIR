using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class PRY_INFORMESICATIPOSMap : EntityTypeConfiguration<PRY_INFORMESICATIPOS>
    {
        public PRY_INFORMESICATIPOSMap()
        {
            // Primary Key
            this.HasKey(t => t.IDTIPO);

            // Properties
            this.Property(t => t.DESCRIPCION)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PRY_INFORMESICATIPOS");
            this.Property(t => t.IDTIPO).HasColumnName("IDTIPO");
            this.Property(t => t.DESCRIPCION).HasColumnName("DESCRIPCION");
            //this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
