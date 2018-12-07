using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class PRY_EVALUACIONESACTIVIDADESPERIODO : ITenant
    {
        public int IDOBJETIVO { get; set; }
        public long IDPERIODO { get; set; }
        public int IDPROYECTO { get; set; }
        public string OBSERVACIONES { get; set; }
        public int IdTenant { get; set; }
        public virtual PRY_EVALUACIONPROYECTOPERIODO PRY_EVALUACIONPROYECTOPERIODO { get; set; }
        public virtual Pry_Objetivos Pry_Objetivos { get; set; }
    }
}
