using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_Proyectos_NivelAceptacionMap : EntityTypeConfiguration<Pry_Proyectos_NivelAceptacion>
    {
        public Pry_Proyectos_NivelAceptacionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdProyecto, t.IdNivelAceptacion });

            // Properties
            this.Property(t => t.IdProyecto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdNivelAceptacion)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Pry_Proyectos_NivelAceptacion");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.IdNivelAceptacion).HasColumnName("IdNivelAceptacion");
            this.Property(t => t.Valor).HasColumnName("Valor");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Pry_NivelAceptacion)
                .WithMany(t => t.Pry_Proyectos_NivelAceptacion)
                .HasForeignKey(d => d.IdNivelAceptacion);
            this.HasRequired(t => t.Pry_Proyectos)
                .WithMany(t => t.Pry_Proyectos_NivelAceptacion)
                .HasForeignKey(d => d.IdProyecto);

        }
    }
}
