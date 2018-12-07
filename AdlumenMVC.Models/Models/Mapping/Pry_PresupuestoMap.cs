using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_PresupuestoMap : EntityTypeConfiguration<Pry_Presupuesto>
    {
        public Pry_PresupuestoMap()
        {
            // Primary Key
            this.HasKey(t => t.IdPresupuesto);

            // Properties
            this.Property(t => t.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.UsuarioModificacion)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Pry_Presupuesto");
            this.Property(t => t.IdPresupuesto).HasColumnName("IdPresupuesto");
            this.Property(t => t.IdTipoPresupuesto).HasColumnName("IdTipoPresupuesto");
            this.Property(t => t.IdObjetivo).HasColumnName("IdObjetivo");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.Monto).HasColumnName("Monto");
            this.Property(t => t.IdDonante).HasColumnName("IdDonante");
            this.Property(t => t.UsuarioCreacion).HasColumnName("UsuarioCreacion");
            this.Property(t => t.FechaCreacion).HasColumnName("FechaCreacion");
            this.Property(t => t.UsuarioModificacion).HasColumnName("UsuarioModificacion");
            this.Property(t => t.FechaModificacion).HasColumnName("FechaModificacion");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.Pry_PresupuestoTipo)
                .WithMany(t => t.Pry_Presupuesto)
                .HasForeignKey(d => d.IdTipoPresupuesto);
            this.HasOptional(t => t.Pry_Proyectos)
                .WithMany(t => t.Pry_Presupuesto)
                .HasForeignKey(d => d.IdProyecto);

        }
    }
}
