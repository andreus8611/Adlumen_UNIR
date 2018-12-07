using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_InformesEstadosMap : EntityTypeConfiguration<Pry_InformesEstados>
    {
        public Pry_InformesEstadosMap()
        {
            // Primary Key
            this.HasKey(t => t.IdEstado);

            // Properties
            this.Property(t => t.Descripcion)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Pry_InformesEstados");
            this.Property(t => t.IdEstado).HasColumnName("IdEstado");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            //this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
