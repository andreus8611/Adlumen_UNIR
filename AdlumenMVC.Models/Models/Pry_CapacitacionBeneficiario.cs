using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_CapacitacionBeneficiario : ITenant
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
