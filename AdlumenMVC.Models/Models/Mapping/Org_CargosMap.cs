using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Org_CargosMap : EntityTypeConfiguration<Org_Cargos>
    {
        public Org_CargosMap()
        {
            // Primary Key
            this.HasKey(t => t.IdCargo);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.UsuarioModificacion)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Org_Cargos");
            this.Property(t => t.IdCargo).HasColumnName("IdCargo");
            this.Property(t => t.IdArea).HasColumnName("IdArea");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.IdPadre).HasColumnName("IdPadre");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.Perfil).HasColumnName("Perfil");
            this.Property(t => t.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            this.Property(t => t.FechaCreacion).HasColumnName("FechaCreacion");
            this.Property(t => t.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            this.Property(t => t.FechaModificacion).HasColumnName("FechaModificacion");
            this.Property(t => t.Eliminado).HasColumnName("Eliminado");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Org_Areas)
                .WithMany(t => t.Org_Cargos)
                .HasForeignKey(d => d.IdArea);

        }
    }
}
