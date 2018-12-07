using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class PRY_INFORMESICAMap : EntityTypeConfiguration<PRY_INFORMESICA>
    {
        public PRY_INFORMESICAMap()
        {
            // Primary Key
            this.HasKey(t => t.IDINFORME);

            // Properties
            // Table & Column Mappings
            this.ToTable("PRY_INFORMESICA");
            this.Property(t => t.IDINFORME).HasColumnName("IDINFORME");
            this.Property(t => t.IDPROYECTO).HasColumnName("IDPROYECTO");
            this.Property(t => t.IDTIPO).HasColumnName("IDTIPO");
            this.Property(t => t.FECHA).HasColumnName("FECHA");
            this.Property(t => t.IDESTADO).HasColumnName("IDESTADO");
            this.Property(t => t.PERIODOINICIAL).HasColumnName("PERIODOINICIAL");
            this.Property(t => t.PERIODOFINAL).HasColumnName("PERIODOFINAL");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.PRY_INFORMESICAESTADOS)
                .WithMany(t => t.PRY_INFORMESICA)
                .HasForeignKey(d => d.IDESTADO);
            this.HasRequired(t => t.PRY_INFORMESICATIPOS)
                .WithMany(t => t.PRY_INFORMESICA)
                .HasForeignKey(d => d.IDTIPO);
            this.HasRequired(t => t.PRY_PERIODOSPROYECTOS)
                .WithMany(t => t.PRY_INFORMESICA)
                .HasForeignKey(d => d.PERIODOINICIAL);
            this.HasRequired(t => t.PRY_PERIODOSPROYECTOS1)
                .WithMany(t => t.PRY_INFORMESICA1)
                .HasForeignKey(d => d.PERIODOFINAL);
            this.HasRequired(t => t.Pry_Proyectos)
                .WithMany(t => t.PRY_INFORMESICA)
                .HasForeignKey(d => d.IDPROYECTO);

        }
    }
}
