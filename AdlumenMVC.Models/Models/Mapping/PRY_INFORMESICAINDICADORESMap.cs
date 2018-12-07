using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class PRY_INFORMESICAINDICADORESMap : EntityTypeConfiguration<PRY_INFORMESICAINDICADORES>
    {
        public PRY_INFORMESICAINDICADORESMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IDINFORME, t.IDINDICADOR });

            // Properties
            this.Property(t => t.IDINFORME)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IDINDICADOR)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LOGROS)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("PRY_INFORMESICAINDICADORES");
            this.Property(t => t.IDINFORME).HasColumnName("IDINFORME");
            this.Property(t => t.IDINDICADOR).HasColumnName("IDINDICADOR");
            this.Property(t => t.LOGROS).HasColumnName("LOGROS");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Pry_Indicadores)
                .WithMany(t => t.PRY_INFORMESICAINDICADORES)
                .HasForeignKey(d => d.IDINDICADOR);
            this.HasRequired(t => t.PRY_INFORMESICA)
                .WithMany(t => t.PRY_INFORMESICAINDICADORES)
                .HasForeignKey(d => d.IDINFORME);

        }
    }
}
