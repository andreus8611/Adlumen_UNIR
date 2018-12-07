using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Org_DonantesMap : EntityTypeConfiguration<Org_Donantes>
    {
        public Org_DonantesMap()
        {
            // Primary Key
            this.HasKey(t => t.IdDonante);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Identificacion)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Contacto)
                .HasMaxLength(256);

            this.Property(t => t.Telefono)
                .HasMaxLength(20);

            this.Property(t => t.Ubicacion)
                .HasMaxLength(100);

            this.Property(t => t.Correo)
                .HasMaxLength(256);

            this.Property(t => t.URL)
                .HasMaxLength(256);

            this.Property(t => t.HojaVida)
                .HasMaxLength(256);

            this.Property(t => t.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.UsuarioModificacion)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Org_Donantes");
            this.Property(t => t.IdDonante).HasColumnName("IdDonante");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.IdIdentificacionTipo).HasColumnName("IdIdentificacionTipo");
            this.Property(t => t.Identificacion).HasColumnName("Identificacion");
            this.Property(t => t.Contacto).HasColumnName("Contacto");
            this.Property(t => t.Telefono).HasColumnName("Telefono");
            this.Property(t => t.Ubicacion).HasColumnName("Ubicacion");
            this.Property(t => t.Correo).HasColumnName("Correo");
            this.Property(t => t.URL).HasColumnName("URL");
            this.Property(t => t.HojaVida).HasColumnName("HojaVida");
            this.Property(t => t.FechaCreacion).HasColumnName("FechaCreacion");
            this.Property(t => t.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            this.Property(t => t.FechaModificacion).HasColumnName("FechaModificacion");
            this.Property(t => t.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            this.Property(t => t.Eliminado).HasColumnName("Eliminado");
            this.Property(t => t.IdCliente).HasColumnName("IdCliente");
            this.Property(t => t.IdPrograma).HasColumnName("IdPrograma");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Org_IdentificacionTipos)
                .WithMany(t => t.Org_Donantes)
                .HasForeignKey(d => d.IdIdentificacionTipo);
            this.HasOptional(t => t.Sys_Clientes)
                .WithMany(t => t.Org_Donantes)
                .HasForeignKey(d => d.IdCliente);

        }
    }
}
