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
    
    public partial class Pry_DatosVerificadores
    {
        public int IdDatosFuentes { get; set; }
        public Nullable<int> IdDatosMuestra { get; set; }
        public Nullable<int> IdVerificador { get; set; }
        public string Url { get; set; }
        public int IdTenant { get; set; }
    
        public virtual Pry_DatosMuestras Pry_DatosMuestras { get; set; }
        public virtual Pry_IndicadoresVerificadores Pry_IndicadoresVerificadores { get; set; }
    }
}
