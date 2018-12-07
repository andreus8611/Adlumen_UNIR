using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class PRY_INFORMESICAOBJETIVOSMap : EntityTypeConfiguration<PRY_INFORMESICAOBJETIVOS>
    {
        public PRY_INFORMESICAOBJETIVOSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IDINFORME, t.IDOBJETIVO });

            // Properties
            this.Property(t => t.IDINFORME)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IDOBJETIVO)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LOGROS)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("PRY_INFORMESICAOBJETIVOS");
            this.Property(t => t.IDINFORME).HasColumnName("IDINFORME");
            this.Property(t => t.IDOBJETIVO).HasColumnName("IDOBJETIVO");
            this.Property(t => t.LOGROS).HasColumnName("LOGROS");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.PRY_INFORMESICA)
                .WithMany(t => t.PRY_INFORMESICAOBJETIVOS)
                .HasForeignKey(d => d.IDINFORME);
            this.HasRequired(t => t.Pry_Objetivos)
                .WithMany(t => t.PRY_INFORMESICAOBJETIVOS)
                .HasForeignKey(d => d.IDOBJETIVO);

        }
    }
}
