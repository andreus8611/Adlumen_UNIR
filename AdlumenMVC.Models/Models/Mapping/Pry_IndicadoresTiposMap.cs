using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_IndicadoresTiposMap : EntityTypeConfiguration<Pry_IndicadoresTipos>
    {
        public Pry_IndicadoresTiposMap()
        {
            // Primary Key
            this.HasKey(t => t.IdTipo);

            // Properties
            this.Property(t => t.IdTipo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Descripcion)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Myme)
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("Pry_IndicadoresTipos");
            this.Property(t => t.IdTipo).HasColumnName("IdTipo");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.IdPadre).HasColumnName("IdPadre");
            this.Property(t => t.Myme).HasColumnName("Myme");
            //this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
