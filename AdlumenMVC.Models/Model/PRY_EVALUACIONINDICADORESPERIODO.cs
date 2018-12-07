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
    
    public partial class PRY_EVALUACIONINDICADORESPERIODO
    {
        public int IdProyecto { get; set; }
        public long IdPeriodo { get; set; }
        public int IdResultado { get; set; }
        public int IdHito { get; set; }
        public Nullable<decimal> HitoEfectividad { get; set; }
        public string ObservacionED { get; set; }
        public Nullable<decimal> ADH { get; set; }
        public Nullable<decimal> CV { get; set; }
        public string ObservacionUrip { get; set; }
        public int IdTenant { get; set; }
    
        public virtual Pry_Indicadores Pry_Indicadores { get; set; }
        public virtual Pry_Objetivos Pry_Objetivos { get; set; }
        public virtual PRY_PERIODOSPROYECTOS PRY_PERIODOSPROYECTOS { get; set; }
        public virtual Pry_Proyectos Pry_Proyectos { get; set; }
    }
}