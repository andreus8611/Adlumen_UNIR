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
    
    public partial class Pry_IndicadoresVerificadores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pry_IndicadoresVerificadores()
        {
            this.Pry_DatosVerificadores = new HashSet<Pry_DatosVerificadores>();
        }
    
        public int IdVerificador { get; set; }
        public int IdIndicador { get; set; }
        public string Descripcion { get; set; }
        public int IdTenant { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pry_DatosVerificadores> Pry_DatosVerificadores { get; set; }
        public virtual Pry_Indicadores Pry_Indicadores { get; set; }
    }
}
