using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class View_Informe_Saldos_FERMap : EntityTypeConfiguration<View_Informe_Saldos_FER>
    {
        public View_Informe_Saldos_FERMap()
        {
            // Primary Key
            this.HasKey(t => t.tipopresupuesto);

            // Properties
            this.Property(t => t.CodigoPRY)
                .HasMaxLength(50);

            this.Property(t => t.NombrePRY)
                .HasMaxLength(500);

            this.Property(t => t.codigo)
                .HasMaxLength(50);

            this.Property(t => t.descripcion)
                .HasMaxLength(2000);

            this.Property(t => t.tipopresupuesto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.NombreEMP)
                .HasMaxLength(256);

            this.Property(t => t.pais)
                .HasMaxLength(50);

            this.Property(t => t.moneda)
                .HasMaxLength(50);

            this.Property(t => t.simbolomnd)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("View_Informe_Saldos_FER");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.CodigoPRY).HasColumnName("CodigoPRY");
            this.Property(t => t.NombrePRY).HasColumnName("NombrePRY");
            this.Property(t => t.FechaInicio).HasColumnName("FechaInicio");
            this.Property(t => t.FechaFin).HasColumnName("FechaFin");
            this.Property(t => t.idobjetivo).HasColumnName("idobjetivo");
            this.Property(t => t.codigo).HasColumnName("codigo");
            this.Property(t => t.descripcion).HasColumnName("descripcion");
            this.Property(t => t.tipopresupuesto).HasColumnName("tipopresupuesto");
            this.Property(t => t.anio).HasColumnName("anio");
            this.Property(t => t.presupuesto).HasColumnName("presupuesto");
            this.Property(t => t.ejecutado).HasColumnName("ejecutado");
            this.Property(t => t.NombreEMP).HasColumnName("NombreEMP");
            this.Property(t => t.pais).HasColumnName("pais");
            this.Property(t => t.moneda).HasColumnName("moneda");
            this.Property(t => t.simbolomnd).HasColumnName("simbolomnd");
        }
    }
}
