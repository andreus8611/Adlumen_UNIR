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
