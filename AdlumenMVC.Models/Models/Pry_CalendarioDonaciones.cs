using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_CalendarioDonaciones : ITenant
    {
        public int IdDonacion { get; set; }
        public int IdProyecto { get; set; }
        public int IdDonante { get; set; }
        public double Monto { get; set; }
        public System.DateTime FechaProgramada { get; set; }
        public int IdTenant { get; set; }
        public virtual Org_Donantes Org_Donantes { get; set; }
        public virtual Pry_Proyectos Pry_Proyectos { get; set; }
    }
}
