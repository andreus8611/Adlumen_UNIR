using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_VariablesMap : EntityTypeConfiguration<Pry_Variables>
    {
        public Pry_VariablesMap()
        {
            // Primary Key
            this.HasKey(t => t.IdVariable);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(50);

            this.Property(t => t.FuenteInformacion)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Pry_Variables");
            this.Property(t => t.IdVariable).HasColumnName("IdVariable");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.FuenteInformacion).HasColumnName("FuenteInformacion");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
