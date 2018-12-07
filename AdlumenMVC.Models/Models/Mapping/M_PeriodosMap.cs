using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class M_PeriodosMap : EntityTypeConfiguration<M_Periodos>
    {
        public M_PeriodosMap()
        {
            // Primary Key
            this.HasKey(t => t.IdPeriodo);

            // Properties
            this.Property(t => t.IdPeriodo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Descripcion)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("M_Periodos");
            this.Property(t => t.IdPeriodo).HasColumnName("IdPeriodo");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.ValorDias).HasColumnName("ValorDias");
            //this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
