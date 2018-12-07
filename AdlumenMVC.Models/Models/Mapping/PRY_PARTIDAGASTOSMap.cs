using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class PRY_PARTIDAGASTOSMap : EntityTypeConfiguration<PRY_PARTIDAGASTOS>
    {
        public PRY_PARTIDAGASTOSMap()
        {
            // Primary Key
            this.HasKey(t => t.IDPARTIDAGASTO);

            // Properties
            this.Property(t => t.ABREVIATURA)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CODIGO)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.NOMBRE)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PRY_PARTIDAGASTOS");
            this.Property(t => t.IDPARTIDAGASTO).HasColumnName("IDPARTIDAGASTO");
            this.Property(t => t.ABREVIATURA).HasColumnName("ABREVIATURA");
            this.Property(t => t.CODIGO).HasColumnName("CODIGO");
            this.Property(t => t.NOMBRE).HasColumnName("NOMBRE");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
