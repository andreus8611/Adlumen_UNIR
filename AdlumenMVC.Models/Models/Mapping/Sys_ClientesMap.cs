using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class Sys_ClientesMap : EntityTypeConfiguration<Sys_Clientes>
    {
        public Sys_ClientesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            //this.Property(t => t.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .HasMaxLength(250);

            this.Property(t => t.Logo)
                .HasMaxLength(250);

            this.Property(t => t.ContactName)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.ContactMail)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ContactAddress)
                .HasMaxLength(255);

            this.Property(t => t.ContactPhone)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Sys_Clientes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.MaxUsers).HasColumnName("MaxUsers");
            this.Property(t => t.MaxProjects).HasColumnName("MaxProjects");
            this.Property(t => t.MaxStorage).HasColumnName("MaxStorage");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            this.Property(t => t.ExpirationDate).HasColumnName("ExpirationDate");
            this.Property(t => t.Logo).HasColumnName("Logo");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.ContactName).HasColumnName("ContactName");
            this.Property(t => t.ContactMail).HasColumnName("ContactMail");
            this.Property(t => t.ContactAddress).HasColumnName("ContactAddress");
            this.Property(t => t.ContactPhone).HasColumnName("ContactPhone");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");
        }
    }
}
