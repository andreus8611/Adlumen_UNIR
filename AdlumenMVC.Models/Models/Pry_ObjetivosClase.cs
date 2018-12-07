using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_ObjetivosClase //: ITenant
    {
        public Pry_ObjetivosClase()
        {
            this.Pry_Objetivos = new List<Pry_Objetivos>();
        }

        public int IdObjetivoClase { get; set; }
        public string Descripcion { get; set; }
        //public int IdTenant { get; set; }
        public virtual ICollection<Pry_Objetivos> Pry_Objetivos { get; set; }
    }
}
