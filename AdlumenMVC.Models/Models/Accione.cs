using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Accione
    {
        public Accione()
        {
            this.AspNetRoles = new List<AspNetRole>();
        }

        public int AccionesId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int ModuloId { get; set; }
        public virtual Modulo Modulo { get; set; }
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
    }
}
