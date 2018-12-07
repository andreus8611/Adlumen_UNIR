using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_Proyectos_DonantesMap : EntityTypeConfiguration<Pry_Proyectos_Donantes>
    {
        public Pry_Proyectos_DonantesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdProyecto, t.IdDonante });

            // Properties
            this.Property(t => t.IdProyecto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdDonante)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.UsuarioModificacion)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Pry_Proyectos_Donantes");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.IdDonante).HasColumnName("IdDonante");
            this.Property(t => t.IdUsuarioResponsable).HasColumnName("IdUsuarioResponsable");
            this.Property(t => t.Monto).HasColumnName("Monto");
            this.Property(t => t.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            this.Property(t => t.FechaCreacion).HasColumnName("FechaCreacion");
            this.Property(t => t.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            this.Property(t => t.FechaModificacion).HasColumnName("FechaModificacion");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Org_Donantes)
                .WithMany(t => t.Pry_Proyectos_Donantes)
                .HasForeignKey(d => d.IdDonante);
            this.HasRequired(t => t.Pry_Proyectos)
                .WithMany(t => t.Pry_Proyectos_Donantes)
                .HasForeignKey(d => d.IdProyecto);
            this.HasOptional(t => t.Sys_Usuarios)
                .WithMany(t => t.Pry_Proyectos_Donantes)
                .HasForeignKey(d => d.IdUsuarioResponsable);

        }
    }
}
