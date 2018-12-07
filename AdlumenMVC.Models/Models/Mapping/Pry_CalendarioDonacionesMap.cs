using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_CalendarioDonacionesMap : EntityTypeConfiguration<Pry_CalendarioDonaciones>
    {
        public Pry_CalendarioDonacionesMap()
        {
            // Primary Key
            this.HasKey(t => t.IdDonacion);

            // Properties
            // Table & Column Mappings
            this.ToTable("Pry_CalendarioDonaciones");
            this.Property(t => t.IdDonacion).HasColumnName("IdDonacion");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.IdDonante).HasColumnName("IdDonante");
            this.Property(t => t.Monto).HasColumnName("Monto");
            this.Property(t => t.FechaProgramada).HasColumnName("FechaProgramada");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Org_Donantes)
                .WithMany(t => t.Pry_CalendarioDonaciones)
                .HasForeignKey(d => d.IdDonante);
            this.HasRequired(t => t.Pry_Proyectos)
                .WithMany(t => t.Pry_CalendarioDonaciones)
                .HasForeignKey(d => d.IdProyecto);

        }
    }
}
