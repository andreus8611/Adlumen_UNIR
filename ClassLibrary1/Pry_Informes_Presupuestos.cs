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
    
    public partial class Pry_Informes_Presupuestos
    {
        public int IdInforme { get; set; }
        public int IdPresupuesto { get; set; }
        public Nullable<double> Ejecutado { get; set; }
        public Nullable<double> Utilizacion { get; set; }
        public Nullable<int> Evaluacion { get; set; }
        public int IdTenant { get; set; }
    
        public virtual Pry_Informes Pry_Informes { get; set; }
        public virtual Pry_NivelAceptacion Pry_NivelAceptacion { get; set; }
        public virtual Pry_Presupuesto Pry_Presupuesto { get; set; }
    }
}
