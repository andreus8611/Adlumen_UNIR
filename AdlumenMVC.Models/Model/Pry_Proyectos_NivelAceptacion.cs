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
    
    public partial class Pry_Proyectos_NivelAceptacion
    {
        public int IdProyecto { get; set; }
        public int IdNivelAceptacion { get; set; }
        public double Valor { get; set; }
        public int IdTenant { get; set; }
    
        public virtual Pry_NivelAceptacion Pry_NivelAceptacion { get; set; }
        public virtual Pry_Proyectos Pry_Proyectos { get; set; }
    }
}