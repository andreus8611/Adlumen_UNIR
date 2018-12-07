using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Proyectos_NivelAceptacion : ITenant
    {
        public int IdProyecto { get; set; }
        public int IdNivelAceptacion { get; set; }
        public double Valor { get; set; }
        public int IdTenant { get; set; }
        public virtual Pry_NivelAceptacion Pry_NivelAceptacion { get; set; }
        public virtual Pry_Proyectos Pry_Proyectos { get; set; }
    }
}
