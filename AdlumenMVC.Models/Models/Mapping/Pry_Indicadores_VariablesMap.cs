using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_Indicadores_VariablesMap : EntityTypeConfiguration<Pry_Indicadores_Variables>
    {
        public Pry_Indicadores_VariablesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdIndicador, t.IdVariable });

            // Properties
            this.Property(t => t.IdIndicador)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdVariable)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Pry_Indicadores_Variables");
            this.Property(t => t.IdIndicador).HasColumnName("IdIndicador");
            this.Property(t => t.IdVariable).HasColumnName("IdVariable");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Pry_Indicadores)
                .WithMany(t => t.Pry_Indicadores_Variables)
                .HasForeignKey(d => d.IdVariable);
            this.HasRequired(t => t.Pry_Variables)
                .WithMany(t => t.Pry_Indicadores_Variables)
                .HasForeignKey(d => d.IdIndicador);

        }
    }
}
