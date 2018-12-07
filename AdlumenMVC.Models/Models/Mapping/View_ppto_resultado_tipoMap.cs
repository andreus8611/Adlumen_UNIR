using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class View_ppto_resultado_tipoMap : EntityTypeConfiguration<View_ppto_resultado_tipo>
    {
        public View_ppto_resultado_tipoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idproyecto, t.tipopresupuesto });

            // Properties
            this.Property(t => t.idproyecto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Codigo)
                .HasMaxLength(50);

            this.Property(t => t.Descripcion)
                .HasMaxLength(2000);

            this.Property(t => t.tipopresupuesto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("View_ppto_resultado_tipo");
            this.Property(t => t.idproyecto).HasColumnName("idproyecto");
            this.Property(t => t.idobjetivo).HasColumnName("idobjetivo");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.tipopresupuesto).HasColumnName("tipopresupuesto");
            this.Property(t => t.presupuesto).HasColumnName("presupuesto");
        }
    }
}
