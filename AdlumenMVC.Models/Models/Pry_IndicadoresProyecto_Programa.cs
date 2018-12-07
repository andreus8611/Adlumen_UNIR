using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_IndicadoresProyecto_Programa : ITenant
    {
        public int IdIndicadorProyecto { get; set; }
        public int IdIndicadorPrograma { get; set; }
        public int IdTenant { get; set; }
        public virtual Pry_Indicadores Pry_Indicadores { get; set; }
    }
}
