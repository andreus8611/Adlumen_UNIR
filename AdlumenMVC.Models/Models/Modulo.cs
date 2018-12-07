using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Modulo
    {
        public Modulo()
        {
            this.Acciones = new List<Accione>();
        }

        public int ModuloId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Accione> Acciones { get; set; }
    }
}
