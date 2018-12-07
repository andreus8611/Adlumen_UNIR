using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Org_Donantes_EmpresasMap : EntityTypeConfiguration<Org_Donantes_Empresas>
    {
        public Org_Donantes_EmpresasMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdDonante, t.IdEmpresa });

            // Properties
            this.Property(t => t.IdDonante)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdEmpresa)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Org_Donantes_Empresas");
            this.Property(t => t.IdDonante).HasColumnName("IdDonante");
            this.Property(t => t.IdEmpresa).HasColumnName("IdEmpresa");

            // Relationships
            //this.HasRequired(t => t.Org_Donantes)
            //    .WithMany(t => t.Org_Donantes_Empresas)
            //    .HasForeignKey(d => d.IdDonante);
            //this.HasRequired(t => t.Org_Empresas)
            //    .WithMany(t => t.Org_Donantes_Empresas)
            //    .HasForeignKey(d => d.IdEmpresa);

        }
    }
}
