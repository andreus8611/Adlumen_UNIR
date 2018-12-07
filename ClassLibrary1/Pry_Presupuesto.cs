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
    
    public partial class Pry_Presupuesto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pry_Presupuesto()
        {
            this.Pry_Informes_Presupuestos = new HashSet<Pry_Informes_Presupuestos>();
            this.Pry_Movimientos = new HashSet<Pry_Movimientos>();
        }
    
        public int IdPresupuesto { get; set; }
        public Nullable<int> IdTipoPresupuesto { get; set; }
        public Nullable<int> IdObjetivo { get; set; }
        public Nullable<int> IdProyecto { get; set; }
        public Nullable<double> Monto { get; set; }
        public Nullable<int> IdDonante { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public int IdTenant { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pry_Informes_Presupuestos> Pry_Informes_Presupuestos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pry_Movimientos> Pry_Movimientos { get; set; }
        public virtual Pry_PresupuestoTipo Pry_PresupuestoTipo { get; set; }
        public virtual Pry_Proyectos Pry_Proyectos { get; set; }
    }
}
