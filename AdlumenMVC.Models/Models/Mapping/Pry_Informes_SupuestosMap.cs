using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_Informes_SupuestosMap : EntityTypeConfiguration<Pry_Informes_Supuestos>
    {
        public Pry_Informes_SupuestosMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdInforme, t.IdSupuesto });

            // Properties
            this.Property(t => t.IdInforme)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdSupuesto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Tipo)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Pry_Informes_Supuestos");
            this.Property(t => t.IdInforme).HasColumnName("IdInforme");
            this.Property(t => t.IdSupuesto).HasColumnName("IdSupuesto");
            this.Property(t => t.Valor).HasColumnName("Valor");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Pry_Informes)
                .WithMany(t => t.Pry_Informes_Supuestos)
                .HasForeignKey(d => d.IdInforme);
            this.HasRequired(t => t.Pry_Supuestos)
                .WithMany(t => t.Pry_Informes_Supuestos)
                .HasForeignKey(d => d.IdSupuesto);

        }
    }
}
