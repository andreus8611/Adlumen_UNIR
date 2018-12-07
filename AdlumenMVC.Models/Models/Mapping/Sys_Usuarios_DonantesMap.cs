using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Sys_Usuarios_DonantesMap : EntityTypeConfiguration<Sys_Usuarios_Donantes>
    {
        public Sys_Usuarios_DonantesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdUsuario, t.IdDonante });

            // Properties
            this.Property(t => t.IdUsuario)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdDonante)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Sys_Usuarios_Donantes");
            this.Property(t => t.IdUsuario).HasColumnName("IdUsuario");
            this.Property(t => t.IdDonante).HasColumnName("IdDonante");

            // Relationships
            //this.HasRequired(t => t.Org_Donantes)
            //    .WithMany(t => t.Sys_Usuarios_Donantes)
            //    .HasForeignKey(d => d.IdDonante);
            //this.HasRequired(t => t.Sys_Usuarios)
            //    .WithMany(t => t.Sys_Usuarios_Donantes)
            //    .HasForeignKey(d => d.IdUsuario);

        }
    }
}
