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
    
    public partial class Pry_Indicadores_Variables
    {
        public int IdIndicador { get; set; }
        public int IdVariable { get; set; }
        public int IdTenant { get; set; }
    
        public virtual Pry_Indicadores Pry_Indicadores { get; set; }
        public virtual Pry_Variables Pry_Variables { get; set; }
    }
}
