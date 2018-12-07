using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Tar_ListasMap : EntityTypeConfiguration<Tar_Listas>
    {
        public Tar_ListasMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Descripcion)
                .IsRequired()
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("Tar_Listas");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.IdUsuarioCreacion).HasColumnName("IdUsuarioCreacion");
            this.Property(t => t.FechaCreacion).HasColumnName("FechaCreacion");
            this.Property(t => t.IdUsuarioModificacion).HasColumnName("IdUsuarioModificacion");
            this.Property(t => t.FechaModificacion).HasColumnName("FechaModificacion");
            this.Property(t => t.IdPadre).HasColumnName("IdPadre");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Pry_Proyectos)
                .WithMany(t => t.Tar_Listas)
                .HasForeignKey(d => d.IdProyecto);
            this.HasRequired(t => t.Sys_Usuarios)
                .WithMany(t => t.Tar_Listas)
                .HasForeignKey(d => d.IdUsuarioCreacion);
            this.HasOptional(t => t.Sys_Usuarios1)
                .WithMany(t => t.Tar_Listas1)
                .HasForeignKey(d => d.IdUsuarioModificacion);

        }
    }
}
