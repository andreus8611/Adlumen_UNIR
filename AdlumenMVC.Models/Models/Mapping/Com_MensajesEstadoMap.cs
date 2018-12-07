using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Com_MensajesEstadoMap : EntityTypeConfiguration<Com_MensajesEstado>
    {
        public Com_MensajesEstadoMap()
        {
            // Primary Key
            this.HasKey(t => t.IdEstado);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Observaciones)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Com_MensajesEstado");
            this.Property(t => t.IdEstado).HasColumnName("IdEstado");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Observaciones).HasColumnName("Observaciones");
            //this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
