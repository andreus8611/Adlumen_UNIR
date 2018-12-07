using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_ProyectosEstados// : ITenant
    {
        public Pry_ProyectosEstados()
        {
            this.Pry_Proyectos = new List<Pry_Proyectos>();
        }

        public int IdEstado { get; set; }
        public string Descripcion { get; set; }
        //public int IdTenant { get; set; }
        public virtual ICollection<Pry_Proyectos> Pry_Proyectos { get; set; }
    }
}
