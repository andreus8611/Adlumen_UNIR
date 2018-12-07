using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AdlumenMVC.Models.Model.Mapping
{
    public class PRY_INFORMESICADETALLEMap : EntityTypeConfiguration<PRY_INFORMESICADETALLE>
    {
        public PRY_INFORMESICADETALLEMap()
        {
            // Primary Key
            this.HasKey(t => t.IDDETALLE);

            // Properties
            this.Property(t => t.DATOSFINANCIEROS)
                .HasMaxLength(4000);

            this.Property(t => t.OBSERVACIONES)
                .HasMaxLength(4000);

            this.Property(t => t.LOGROSPRINCIPALES)
                .HasMaxLength(4000);

            this.Property(t => t.PROBLEMASYACCIONES)
                .HasMaxLength(4000);

            this.Property(t => t.SUPUESTOS)
                .HasMaxLength(4000);

            this.Property(t => t.RECOMENDACIONES)
                .HasMaxLength(4000);

            this.Property(t => t.FACTORESEXITO)
                .HasMaxLength(4000);

            this.Property(t => t.FACTORESLIMITANTES)
                .HasMaxLength(4000);

            this.Property(t => t.CONDICIONALIDAD)
                .HasMaxLength(4000);

            this.Property(t => t.SOSTENIBILIDAD)
                .HasMaxLength(4000);

            this.Property(t => t.EFICACIAPROYECTO)
                .HasMaxLength(4000);

            this.Property(t => t.EFICACIARESULTADOS)
                .HasMaxLength(4000);

            this.Property(t => t.RELEVANCIAOBJETIVOS)
                .HasMaxLength(4000);

            this.Property(t => t.RELEVANCIAEXTERNA)
                .HasMaxLength(4000);

            this.Property(t => t.SOSTENIBILIDADBENEFICIOS)
                .HasMaxLength(4000);

            this.Property(t => t.SOSTENIBILIDADCAPACIDADES)
                .HasMaxLength(4000);

            this.Property(t => t.SOSTENIBILIDADPERTENECIA)
                .HasMaxLength(4000);

            this.Property(t => t.SOSTENIBILIDADOREPLICAS)
                .HasMaxLength(4000);

            this.Property(t => t.IMPACTOOBJETIVOS)
                .HasMaxLength(4000);

            this.Property(t => t.IMPACTOGENERAL)
                .HasMaxLength(4000);

            this.Property(t => t.IMPACTOALIANZAS)
                .HasMaxLength(4000);

            this.Property(t => t.IMPACTODIALOGO)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("PRY_INFORMESICADETALLE");
            this.Property(t => t.IDDETALLE).HasColumnName("IDDETALLE");
            this.Property(t => t.IDINFORME).HasColumnName("IDINFORME");
            this.Property(t => t.DATOSFINANCIEROS).HasColumnName("DATOSFINANCIEROS");
            this.Property(t => t.OBSERVACIONES).HasColumnName("OBSERVACIONES");
            this.Property(t => t.LOGROSPRINCIPALES).HasColumnName("LOGROSPRINCIPALES");
            this.Property(t => t.PROBLEMASYACCIONES).HasColumnName("PROBLEMASYACCIONES");
            this.Property(t => t.SUPUESTOS).HasColumnName("SUPUESTOS");
            this.Property(t => t.RECOMENDACIONES).HasColumnName("RECOMENDACIONES");
            this.Property(t => t.FACTORESEXITO).HasColumnName("FACTORESEXITO");
            this.Property(t => t.FACTORESLIMITANTES).HasColumnName("FACTORESLIMITANTES");
            this.Property(t => t.CONDICIONALIDAD).HasColumnName("CONDICIONALIDAD");
            this.Property(t => t.SOSTENIBILIDAD).HasColumnName("SOSTENIBILIDAD");
            this.Property(t => t.EFICACIAPROYECTO).HasColumnName("EFICACIAPROYECTO");
            this.Property(t => t.EFICACIARESULTADOS).HasColumnName("EFICACIARESULTADOS");
            this.Property(t => t.RELEVANCIAOBJETIVOS).HasColumnName("RELEVANCIAOBJETIVOS");
            this.Property(t => t.RELEVANCIAEXTERNA).HasColumnName("RELEVANCIAEXTERNA");
            this.Property(t => t.SOSTENIBILIDADBENEFICIOS).HasColumnName("SOSTENIBILIDADBENEFICIOS");
            this.Property(t => t.SOSTENIBILIDADCAPACIDADES).HasColumnName("SOSTENIBILIDADCAPACIDADES");
            this.Property(t => t.SOSTENIBILIDADPERTENECIA).HasColumnName("SOSTENIBILIDADPERTENECIA");
            this.Property(t => t.SOSTENIBILIDADOREPLICAS).HasColumnName("SOSTENIBILIDADOREPLICAS");
            this.Property(t => t.IMPACTOOBJETIVOS).HasColumnName("IMPACTOOBJETIVOS");
            this.Property(t => t.IMPACTOGENERAL).HasColumnName("IMPACTOGENERAL");
            this.Property(t => t.IMPACTOALIANZAS).HasColumnName("IMPACTOALIANZAS");
            this.Property(t => t.IMPACTODIALOGO).HasColumnName("IMPACTODIALOGO");
            this.Property(t => t.IdTenant).HasColumnName("IdTenant");

            // Relationships
            this.HasRequired(t => t.PRY_INFORMESICA)
                .WithMany(t => t.PRY_INFORMESICADETALLE)
                .HasForeignKey(d => d.IDINFORME);

        }
    }
}
