//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdlumenMVC.Models.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Org_IdentificacionTipos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Org_IdentificacionTipos()
        {
            this.Org_Donantes = new HashSet<Org_Donantes>();
            this.Org_Empleados = new HashSet<Org_Empleados>();
            this.Org_Empresas = new HashSet<Org_Empresas>();
            this.Org_Proveedores = new HashSet<Org_Proveedores>();
        }
    
        public int IdIdentificacionTipo { get; set; }
        public string Nombre { get; set; }
        public int IdTenant { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Org_Donantes> Org_Donantes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Org_Empleados> Org_Empleados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Org_Empresas> Org_Empresas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Org_Proveedores> Org_Proveedores { get; set; }
    }
}