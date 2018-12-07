using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class View_saldoppto_resultado_tipo
    {
        public int idproyecto { get; set; }
        public Nullable<int> idobjetivo { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int tipopresupuesto { get; set; }
        public Nullable<decimal> presupuesto { get; set; }
        public Nullable<decimal> ejecutado { get; set; }
        public Nullable<int> anio { get; set; }
    }
}
