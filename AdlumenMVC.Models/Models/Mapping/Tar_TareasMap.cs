using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Tar_TareasMap : EntityTypeConfiguration<Tar_Tareas>
    {
        public Tar_TareasMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Descripcion)
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("Tar_Tareas");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdLista).HasColumnName("IdLista");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.FechaInicio).HasColumnName("FechaInicio");
            this.Property(t => t.FechaFin).HasColumnName("FechaFin");
            this.Property(t => t.IdResponsable).HasColumnName("IdResponsable");
            this.Property(t => t.IdUsuarioCreacion).HasColumnName("IdUsuarioCreacion");
            this.Property(t => t.FechaCreacion).HasColumnName("FechaCreacion");
            this.Property(t => t.IdUsuarioModificacion).HasColumnName("IdUsuarioModificacion");
            this.Property(t => t.FechaModificacion).HasColumnName("FechaModificacion");
            this.Property(t => t.Prioridad).HasColumnName("Prioridad");
            this.Property(t => t.Estado).HasColumnName("Estado");
            this.Property(t => t.FechaCompletado).HasColumnName("FechaCompletado");
            this.Property(t => t.IdUsuarioCompletado).HasColumnName("IdUsuarioCompletado");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Sys_Usuarios)
                .WithMany(t => t.Tar_Tareas)
                .HasForeignKey(d => d.IdResponsable);
            this.HasOptional(t => t.Sys_Usuarios1)
                .WithMany(t => t.Tar_Tareas1)
                .HasForeignKey(d => d.IdUsuarioCreacion);
            this.HasOptional(t => t.Sys_Usuarios2)
                .WithMany(t => t.Tar_Tareas2)
                .HasForeignKey(d => d.IdUsuarioModificacion);
            this.HasOptional(t => t.Sys_Usuarios3)
                .WithMany(t => t.Tar_Tareas3)
                .HasForeignKey(d => d.IdUsuarioCompletado);
            this.HasOptional(t => t.Tar_Listas)
                .WithMany(t => t.Tar_Tareas)
                .HasForeignKey(d => d.IdLista);

        }
    }
}
