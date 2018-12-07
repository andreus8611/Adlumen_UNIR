using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Recursos : ITenant
    {
        public int IdRecurso { get; set; }
        public int IdObjetivo { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public Nullable<double> ValorUnitario { get; set; }
        public Nullable<double> Monto { get; set; }
        public Nullable<int> IDPARTIDAGASTO { get; set; }
        public Nullable<decimal> CONTRAPARTIDA { get; set; }
        public Nullable<decimal> APORTEPROGRAMA { get; set; }
        public int IdTenant { get; set; }
        public virtual Pry_Objetivos Pry_Objetivos { get; set; }
        public virtual PRY_PARTIDAGASTOS PRY_PARTIDAGASTOS { get; set; }
    }
}
