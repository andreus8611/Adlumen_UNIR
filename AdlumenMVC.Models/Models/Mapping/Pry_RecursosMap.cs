using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_RecursosMap : EntityTypeConfiguration<Pry_Recursos>
    {
        public Pry_RecursosMap()
        {
            // Primary Key
            this.HasKey(t => t.IdRecurso);

            // Properties
            this.Property(t => t.Codigo)
                .HasMaxLength(50);

            this.Property(t => t.Descripcion)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Tipo)
                .HasMaxLength(100);

            this.Property(t => t.UnidadMedida)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Pry_Recursos");
            this.Property(t => t.IdRecurso).HasColumnName("IdRecurso");
            this.Property(t => t.IdObjetivo).HasColumnName("IdObjetivo");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
            this.Property(t => t.Cantidad).HasColumnName("Cantidad");
            this.Property(t => t.UnidadMedida).HasColumnName("UnidadMedida");
            this.Property(t => t.ValorUnitario).HasColumnName("ValorUnitario");
            this.Property(t => t.Monto).HasColumnName("Monto");
            this.Property(t => t.IDPARTIDAGASTO).HasColumnName("IDPARTIDAGASTO");
            this.Property(t => t.CONTRAPARTIDA).HasColumnName("CONTRAPARTIDA");
            this.Property(t => t.APORTEPROGRAMA).HasColumnName("APORTEPROGRAMA");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.Pry_Objetivos)
                .WithMany(t => t.Pry_Recursos)
                .HasForeignKey(d => d.IdObjetivo);
            this.HasOptional(t => t.PRY_PARTIDAGASTOS)
                .WithMany(t => t.Pry_Recursos)
                .HasForeignKey(d => d.IDPARTIDAGASTO);

        }
    }
}
