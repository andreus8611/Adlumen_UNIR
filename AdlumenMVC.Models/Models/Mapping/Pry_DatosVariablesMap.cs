using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_DatosVariablesMap : EntityTypeConfiguration<Pry_DatosVariables>
    {
        public Pry_DatosVariablesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdDatosMuestra, t.IdVariable });

            // Properties
            this.Property(t => t.IdDatosMuestra)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdVariable)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Pry_DatosVariables");
            this.Property(t => t.IdDatosMuestra).HasColumnName("IdDatosMuestra");
            this.Property(t => t.IdVariable).HasColumnName("IdVariable");
            this.Property(t => t.Valor).HasColumnName("Valor");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Pry_DatosMuestras)
                .WithMany(t => t.Pry_DatosVariables)
                .HasForeignKey(d => d.IdDatosMuestra);
            this.HasRequired(t => t.Pry_Variables)
                .WithMany(t => t.Pry_DatosVariables)
                .HasForeignKey(d => d.IdVariable);

        }
    }
}
