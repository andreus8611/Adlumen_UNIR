using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Capacitaciones : ITenant
    {
        public Pry_Capacitaciones()
        {
            this.Pry_CapacitacionBeneficiario = new List<Pry_CapacitacionBeneficiario>();
        }

        public int IdCapacitacion { get; set; }
        public int IdFacilitador { get; set; }
        public string NombreCapacitacion { get; set; }
        public string DescripcionCapacitacion { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFinal { get; set; }
        public byte Status { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<Pry_CapacitacionBeneficiario> Pry_CapacitacionBeneficiario { get; set; }
        public virtual Pry_Facilitadores Pry_Facilitadores { get; set; }
    }
}
