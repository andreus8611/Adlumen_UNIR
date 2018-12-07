using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_CapacitacionesMap : EntityTypeConfiguration<Pry_Capacitaciones>
    {
        public Pry_CapacitacionesMap()
        {
            // Primary Key
            this.HasKey(t => t.IdCapacitacion);

            // Properties
            this.Property(t => t.NombreCapacitacion)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.DescripcionCapacitacion)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("Pry_Capacitaciones");
            this.Property(t => t.IdCapacitacion).HasColumnName("IdCapacitacion");
            this.Property(t => t.IdFacilitador).HasColumnName("IdFacilitador");
            this.Property(t => t.NombreCapacitacion).HasColumnName("NombreCapacitacion");
            this.Property(t => t.DescripcionCapacitacion).HasColumnName("DescripcionCapacitacion");
            this.Property(t => t.FechaInicio).HasColumnName("FechaInicio");
            this.Property(t => t.FechaFinal).HasColumnName("FechaFinal");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Pry_Facilitadores)
                .WithMany(t => t.Pry_Capacitaciones)
                .HasForeignKey(d => d.IdFacilitador);

        }
    }
}
