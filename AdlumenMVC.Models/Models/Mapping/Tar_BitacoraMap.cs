using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Tar_BitacoraMap : EntityTypeConfiguration<Tar_Bitacora>
    {
        public Tar_BitacoraMap()
        {
            // Primary Key
            this.HasKey(t => t.IdBitacora);

            // Properties
            // Table & Column Mappings
            this.ToTable("Tar_Bitacora");
            this.Property(t => t.IdBitacora).HasColumnName("IdBitacora");
            this.Property(t => t.IdVisita).HasColumnName("IdVisita");
            this.Property(t => t.Comentario).HasColumnName("Comentario");
            this.Property(t => t.FechaRegistro).HasColumnName("FechaRegistro");
            this.Property(t => t.IdUsuario).HasColumnName("IdUsuario");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Sys_Usuarios)
                .WithMany(t => t.Tar_Bitacora)
                .HasForeignKey(d => d.IdUsuario);
            this.HasOptional(t => t.Tar_Visitas)
                .WithMany(t => t.Tar_Bitacora)
                .HasForeignKey(d => d.IdVisita);

        }
    }
}
