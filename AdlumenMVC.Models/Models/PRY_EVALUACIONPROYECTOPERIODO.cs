using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class PRY_EVALUACIONPROYECTOPERIODO : ITenant
    {
        public PRY_EVALUACIONPROYECTOPERIODO()
        {
            this.PRY_EVALUACIONESACTIVIDADESPERIODO = new List<PRY_EVALUACIONESACTIVIDADESPERIODO>();
        }

        public long IDPERIODO { get; set; }
        public int IDPROYECTO { get; set; }
        public string DATOSFINANCIEROS { get; set; }
        public string OBSERVACIONES { get; set; }
        public string RECOMENDACIONES { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<PRY_EVALUACIONESACTIVIDADESPERIODO> PRY_EVALUACIONESACTIVIDADESPERIODO { get; set; }
        public virtual PRY_PERIODOSPROYECTOS PRY_PERIODOSPROYECTOS { get; set; }
        public virtual Pry_Proyectos Pry_Proyectos { get; set; }
    }
}
