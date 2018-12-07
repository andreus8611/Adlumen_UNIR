using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_DatosVerificadoresMap : EntityTypeConfiguration<Pry_DatosVerificadores>
    {
        public Pry_DatosVerificadoresMap()
        {
            // Primary Key
            this.HasKey(t => t.IdDatosFuentes);

            // Properties
            this.Property(t => t.Url)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Pry_DatosVerificadores");
            this.Property(t => t.IdDatosFuentes).HasColumnName("IdDatosFuentes");
            this.Property(t => t.IdDatosMuestra).HasColumnName("IdDatosMuestra");
            this.Property(t => t.IdVerificador).HasColumnName("IdVerificador");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Pry_DatosMuestras)
                .WithMany(t => t.Pry_DatosVerificadores)
                .HasForeignKey(d => d.IdDatosMuestra);
            this.HasOptional(t => t.Pry_IndicadoresVerificadores)
                .WithMany(t => t.Pry_DatosVerificadores)
                .HasForeignKey(d => d.IdVerificador);

        }
    }
}
