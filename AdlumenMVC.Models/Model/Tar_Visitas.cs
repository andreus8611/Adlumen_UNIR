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
    
    public partial class Tar_Visitas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tar_Visitas()
        {
            this.Tar_Bitacora = new HashSet<Tar_Bitacora>();
            this.Tar_Permisos_Bitacora = new HashSet<Tar_Permisos_Bitacora>();
        }
    
        public int IdVisita { get; set; }
        public Nullable<int> IdTarea { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string PersonaContacto { get; set; }
        public Nullable<decimal> Latitud { get; set; }
        public Nullable<decimal> Longitud { get; set; }
        public string Estado { get; set; }
        public int IdTenant { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tar_Bitacora> Tar_Bitacora { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tar_Permisos_Bitacora> Tar_Permisos_Bitacora { get; set; }
        public virtual Tar_Tareas Tar_Tareas { get; set; }
    }
}