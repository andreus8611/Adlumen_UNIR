using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Informes_Supuestos : ITenant
    {
        public int IdInforme { get; set; }
        public int IdSupuesto { get; set; }
        public bool Valor { get; set; }
        public string Tipo { get; set; }
        public int IdTenant { get; set; }
        public virtual Pry_Informes Pry_Informes { get; set; }
        public virtual Pry_Supuestos Pry_Supuestos { get; set; }
    }
}
