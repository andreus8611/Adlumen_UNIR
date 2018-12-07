using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Documentos_TareasMap : EntityTypeConfiguration<Documentos_Tareas>
    {
        public Documentos_TareasMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdDocumento, t.IdTarea });

            // Properties
            this.Property(t => t.IdDocumento)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdTarea)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Documentos_Tareas");
            this.Property(t => t.IdDocumento).HasColumnName("IdDocumento");
            this.Property(t => t.IdTarea).HasColumnName("IdTarea");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Doc_Documentos)
                .WithMany(t => t.Documentos_Tareas)
                .HasForeignKey(d => d.IdDocumento);
            this.HasRequired(t => t.Doc_Documentos1)
                .WithMany(t => t.Documentos_Tareas1)
                .HasForeignKey(d => d.IdDocumento);
            this.HasRequired(t => t.Tar_Tareas)
                .WithMany(t => t.Documentos_Tareas)
                .HasForeignKey(d => d.IdTarea);
            this.HasRequired(t => t.Tar_Tareas1)
                .WithMany(t => t.Documentos_Tareas1)
                .HasForeignKey(d => d.IdTarea);

        }
    }
}
