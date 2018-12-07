using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Indicadores_Variables : ITenant
    {
        public int IdIndicador { get; set; }
        public int IdVariable { get; set; }
        public int IdTenant { get; set; }
        public virtual Pry_Indicadores Pry_Indicadores { get; set; }
        public virtual Pry_Variables Pry_Variables { get; set; }
    }
}
