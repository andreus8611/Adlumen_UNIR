//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Org_Areas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Org_Areas()
        {
            this.Org_Cargos = new HashSet<Org_Cargos>();
        }
    
        public int IdArea { get; set; }
        public int IdPadre { get; set; }
        public int IdEmpresa { get; set; }
        public Nullable<int> IdResponsable { get; set; }
        public string Nombre { get; set; }
        public string Objetivo { get; set; }
        public string Descripcion { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public bool Eliminado { get; set; }
        public int IdTenant { get; set; }
    
        public virtual Org_Empresas Org_Empresas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Org_Cargos> Org_Cargos { get; set; }
    }
}
