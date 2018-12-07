using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class AccioneMap : EntityTypeConfiguration<Accione>
    {
        public AccioneMap()
        {
            // Primary Key
            this.HasKey(t => t.AccionesId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Acciones");
            this.Property(t => t.AccionesId).HasColumnName("AccionesId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.ModuloId).HasColumnName("ModuloId");

            // Relationships
            this.HasMany(t => t.AspNetRoles)
                .WithMany(t => t.Acciones)
                .Map(m =>
                    {
                        m.ToTable("AspNetRolesAcciones");
                        m.MapLeftKey("AccionesId");
                        m.MapRightKey("RoleId");
                    });

            this.HasRequired(t => t.Modulo)
                .WithMany(t => t.Acciones)
                .HasForeignKey(d => d.ModuloId);

        }
    }
}
