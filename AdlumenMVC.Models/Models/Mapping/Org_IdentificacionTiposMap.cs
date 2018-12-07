using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Org_IdentificacionTiposMap : EntityTypeConfiguration<Org_IdentificacionTipos>
    {
        public Org_IdentificacionTiposMap()
        {
            // Primary Key
            this.HasKey(t => t.IdIdentificacionTipo);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Org_IdentificacionTipos");
            this.Property(t => t.IdIdentificacionTipo).HasColumnName("IdIdentificacionTipo");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            //this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
