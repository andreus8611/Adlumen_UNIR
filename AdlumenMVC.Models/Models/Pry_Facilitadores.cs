using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Facilitadores : ITenant
    {
        public Pry_Facilitadores()
        {
            this.Pry_Capacitaciones = new List<Pry_Capacitaciones>();
        }

        public int IdFacilitador { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public byte Status { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<Pry_Capacitaciones> Pry_Capacitaciones { get; set; }
    }
}
