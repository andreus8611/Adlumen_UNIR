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
    
    public partial class Pry_Informes_Indicador
    {
        public int IdInforme { get; set; }
        public int IdIndicador { get; set; }
        public Nullable<double> Meta { get; set; }
        public Nullable<int> IdDatosMuestra { get; set; }
        public Nullable<int> Evaluacion { get; set; }
        public int IdTenant { get; set; }
    
        public virtual Pry_DatosMuestras Pry_DatosMuestras { get; set; }
        public virtual Pry_Indicadores Pry_Indicadores { get; set; }
        public virtual Pry_Informes Pry_Informes { get; set; }
        public virtual Pry_NivelAceptacion Pry_NivelAceptacion { get; set; }
    }
}
