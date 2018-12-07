using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Com_MensajesMap : EntityTypeConfiguration<Com_Mensajes>
    {
        public Com_MensajesMap()
        {
            // Primary Key
            this.HasKey(t => t.IdMensaje);

            // Properties
            this.Property(t => t.Asunto)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Mensaje)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Com_Mensajes");
            this.Property(t => t.IdMensaje).HasColumnName("IdMensaje");
            this.Property(t => t.IdUsuarioRemitente).HasColumnName("IdUsuarioRemitente");
            this.Property(t => t.IdUsuarioDestinatario).HasColumnName("IdUsuarioDestinatario");
            this.Property(t => t.IdEstado).HasColumnName("IdEstado");
            this.Property(t => t.Asunto).HasColumnName("Asunto");
            this.Property(t => t.Mensaje).HasColumnName("Mensaje");
            this.Property(t => t.Prioridad).HasColumnName("Prioridad");
            this.Property(t => t.FechaEnvio).HasColumnName("FechaEnvio");
            this.Property(t => t.FechaLectura).HasColumnName("FechaLectura");
            this.Property(t => t.FechaBorrado).HasColumnName("FechaBorrado");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Sys_Usuarios)
                .WithMany(t => t.Com_Mensajes)
                .HasForeignKey(d => d.IdUsuarioRemitente);
            this.HasRequired(t => t.Com_MensajesEstado)
                .WithMany(t => t.Com_Mensajes)
                .HasForeignKey(d => d.IdEstado);

        }
    }
}
