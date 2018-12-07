using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_BitacorasMap : EntityTypeConfiguration<Pry_Bitacoras>
    {
        public Pry_BitacorasMap()
        {
            // Primary Key
            this.HasKey(t => t.IdBitacora);

            // Properties
            this.Property(t => t.Titulo)
                .HasMaxLength(250);

            this.Property(t => t.Url)
                .HasMaxLength(250);

            this.Property(t => t.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.UsuarioModificacion)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Pry_Bitacoras");
            this.Property(t => t.IdBitacora).HasColumnName("IdBitacora");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.Titulo).HasColumnName("Titulo");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            this.Property(t => t.FechaCreacion).HasColumnName("FechaCreacion");
            this.Property(t => t.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            this.Property(t => t.FechaModificacion).HasColumnName("FechaModificacion");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Pry_Proyectos)
                .WithMany(t => t.Pry_Bitacoras)
                .HasForeignKey(d => d.IdProyecto);

        }
    }
}
