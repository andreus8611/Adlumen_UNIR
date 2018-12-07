using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Informes_Presupuestos : ITenant
    {
        public int IdInforme { get; set; }
        public int IdPresupuesto { get; set; }
        public Nullable<double> Ejecutado { get; set; }
        public Nullable<double> Utilizacion { get; set; }
        public Nullable<int> Evaluacion { get; set; }
        public int IdTenant { get; set; }
        public virtual Pry_Informes Pry_Informes { get; set; }
        public virtual Pry_NivelAceptacion Pry_NivelAceptacion { get; set; }
        public virtual Pry_Presupuesto Pry_Presupuesto { get; set; }
    }
}
