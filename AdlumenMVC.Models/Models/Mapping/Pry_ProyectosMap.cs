using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Pry_ProyectosMap : EntityTypeConfiguration<Pry_Proyectos>
    {
        public Pry_ProyectosMap()
        {
            // Primary Key
            this.HasKey(t => t.IdProyecto);

            // Properties
            this.Property(t => t.Codigo)
                .HasMaxLength(50);

            this.Property(t => t.Nombre)
                .HasMaxLength(500);

            this.Property(t => t.Descripcion)
                .HasMaxLength(2000);

            this.Property(t => t.Beneficiarios)
                .HasMaxLength(256);

            this.Property(t => t.Region)
                .HasMaxLength(256);

            this.Property(t => t.Area)
                .HasMaxLength(256);

            this.Property(t => t.Logo)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Pry_Proyectos");
            this.Property(t => t.IdProyecto).HasColumnName("IdProyecto");
            this.Property(t => t.IdUsuarioResponsable).HasColumnName("IdUsuarioResponsable");
            this.Property(t => t.IdUsuarioDigitador).HasColumnName("IdUsuarioDigitador");
            this.Property(t => t.IdUsuarioEvaluador).HasColumnName("IdUsuarioEvaluador");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.Problema).HasColumnName("Problema");
            this.Property(t => t.DescripcionProblema).HasColumnName("DescripcionProblema");
            this.Property(t => t.Justificacion).HasColumnName("Justificacion");
            this.Property(t => t.IdCategoriaDocumentos).HasColumnName("IdCategoriaDocumentos");
            this.Property(t => t.IdCategoriaSupuestos).HasColumnName("IdCategoriaSupuestos");
            this.Property(t => t.Beneficiarios).HasColumnName("Beneficiarios");
            this.Property(t => t.Region).HasColumnName("Region");
            this.Property(t => t.DiasNotificacion).HasColumnName("DiasNotificacion");
            this.Property(t => t.IdMoneda).HasColumnName("IdMoneda");
            this.Property(t => t.Eliminado).HasColumnName("Eliminado");
            this.Property(t => t.IdProposito).HasColumnName("IdProposito");
            this.Property(t => t.Area).HasColumnName("Area");
            this.Property(t => t.FechaInicio).HasColumnName("FechaInicio");
            this.Property(t => t.FechaFin).HasColumnName("FechaFin");
            this.Property(t => t.Presupuesto).HasColumnName("Presupuesto");
            this.Property(t => t.Logo).HasColumnName("Logo");
            this.Property(t => t.IdEstado).HasColumnName("IdEstado");
            this.Property(t => t.Latitude).HasColumnName("Latitude");
            this.Property(t => t.Longitude).HasColumnName("Longitude");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.IdEmpresa).HasColumnName("IdEmpresa");
            this.Property(t => t.IdTipo).HasColumnName("IdTipo");
            this.Property(t => t.IDPROYECTOPADRE).HasColumnName("IDPROYECTOPADRE");
            this.Property(t => t.MONTOFINANCIAMIENTO).HasColumnName("MONTOFINANCIAMIENTO");
            this.Property(t => t.MONTOCONTRAPARTIDA).HasColumnName("MONTOCONTRAPARTIDA");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasOptional(t => t.M_Monedas)
                .WithMany(t => t.Pry_Proyectos)
                .HasForeignKey(d => d.IdMoneda);
            this.HasOptional(t => t.Pry_Objetivos)
                .WithMany(t => t.Pry_Proyectos)
                .HasForeignKey(d => d.IdProposito);
            this.HasOptional(t => t.Pry_Proyectos2)
                .WithMany(t => t.Pry_Proyectos1)
                .HasForeignKey(d => d.IDPROYECTOPADRE);
            this.HasOptional(t => t.Pry_ProyectosEstados)
                .WithMany(t => t.Pry_Proyectos)
                .HasForeignKey(d => d.IdEstado);
            this.HasRequired(t => t.Pry_ProyectosTipos)
                .WithMany(t => t.Pry_Proyectos)
                .HasForeignKey(d => d.IdTipo);
            this.HasRequired(t => t.Sys_Clientes)
                .WithMany(t => t.Pry_Proyectos)
                .HasForeignKey(d => d.CustomerId);
            this.HasOptional(t => t.Sys_Usuarios)
                .WithMany(t => t.Pry_Proyectos)
                .HasForeignKey(d => d.IdUsuarioEvaluador);
            this.HasOptional(t => t.Sys_Usuarios1)
                .WithMany(t => t.Pry_Proyectos1)
                .HasForeignKey(d => d.IdUsuarioResponsable);
            this.HasOptional(t => t.Sys_Usuarios2)
                .WithMany(t => t.Pry_Proyectos2)
                .HasForeignKey(d => d.IdUsuarioDigitador);

        }
    }
}
