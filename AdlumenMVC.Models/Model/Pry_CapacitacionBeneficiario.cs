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
    
    public partial class Pry_CapacitacionBeneficiario
    {
        public int IdCapacitacionBeneficiario { get; set; }
        public int IdCapacitacion { get; set; }
        public int IdBeneficiario { get; set; }
        public System.DateTime FechaInscripcion { get; set; }
        public byte Status { get; set; }
        public int IdTenant { get; set; }
    
        public virtual Pry_Beneficiarios Pry_Beneficiarios { get; set; }
        public virtual Pry_Capacitaciones Pry_Capacitaciones { get; set; }
    }
}
