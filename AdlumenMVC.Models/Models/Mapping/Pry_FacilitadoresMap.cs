using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_FacilitadoresMap : EntityTypeConfiguration<Pry_Facilitadores>
    {
        public Pry_FacilitadoresMap()
        {
            // Primary Key
            this.HasKey(t => t.IdFacilitador);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Telefono)
                .HasMaxLength(20);

            this.Property(t => t.Direccion)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Pry_Facilitadores");
            this.Property(t => t.IdFacilitador).HasColumnName("IdFacilitador");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Telefono).HasColumnName("Telefono");
            this.Property(t => t.Direccion).HasColumnName("Direccion");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
