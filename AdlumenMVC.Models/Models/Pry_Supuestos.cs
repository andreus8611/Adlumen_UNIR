using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Supuestos : ITenant
    {
        public Pry_Supuestos()
        {
            this.Pry_Informes_Supuestos = new List<Pry_Informes_Supuestos>();
        }

        public int IdSupuesto { get; set; }
        public Nullable<int> IdObjetivo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Impacto { get; set; }
        public string PlanContingencia { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<Pry_Informes_Supuestos> Pry_Informes_Supuestos { get; set; }
        public virtual Pry_Objetivos Pry_Objetivos { get; set; }
    }
}
