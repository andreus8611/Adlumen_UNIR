using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class PRY_INFORMESICAESTADOSMap : EntityTypeConfiguration<PRY_INFORMESICAESTADOS>
    {
        public PRY_INFORMESICAESTADOSMap()
        {
            // Primary Key
            this.HasKey(t => t.IDESTADO);

            // Properties
            this.Property(t => t.DESCRIPCION)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PRY_INFORMESICAESTADOS");
            this.Property(t => t.IDESTADO).HasColumnName("IDESTADO");
            this.Property(t => t.DESCRIPCION).HasColumnName("DESCRIPCION");
            //this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
