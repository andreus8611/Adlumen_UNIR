using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_IndicadoresVerificadoresMap : EntityTypeConfiguration<Pry_IndicadoresVerificadores>
    {
        public Pry_IndicadoresVerificadoresMap()
        {
            // Primary Key
            this.HasKey(t => t.IdVerificador);

            // Properties
            this.Property(t => t.Descripcion)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Pry_IndicadoresVerificadores");
            this.Property(t => t.IdVerificador).HasColumnName("IdVerificador");
            this.Property(t => t.IdIndicador).HasColumnName("IdIndicador");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Pry_Indicadores)
                .WithMany(t => t.Pry_IndicadoresVerificadores)
                .HasForeignKey(d => d.IdIndicador);

        }
    }
}
