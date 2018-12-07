using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Tar_VisitasMap : EntityTypeConfiguration<Tar_Visitas>
    {
        public Tar_VisitasMap()
        {
            // Primary Key
            this.HasKey(t => t.IdVisita);

            // Properties
            this.Property(t => t.Descripcion)
                .HasMaxLength(1000);

            this.Property(t => t.Ubicacion)
                .HasMaxLength(500);

            this.Property(t => t.PersonaContacto)
                .HasMaxLength(100);

            this.Property(t => t.Estado)
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("Tar_Visitas");
            this.Property(t => t.IdVisita).HasColumnName("IdVisita");
            this.Property(t => t.IdTarea).HasColumnName("IdTarea");
            this.Property(t => t.Fecha).HasColumnName("Fecha");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.Ubicacion).HasColumnName("Ubicacion");
            this.Property(t => t.PersonaContacto).HasColumnName("PersonaContacto");
            this.Property(t => t.Latitud).HasColumnName("Latitud");
            this.Property(t => t.Longitud).HasColumnName("Longitud");
            this.Property(t => t.Estado).HasColumnName("Estado");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Tar_Tareas)
                .WithMany(t => t.Tar_Visitas)
                .HasForeignKey(d => d.IdTarea);

        }
    }
}
