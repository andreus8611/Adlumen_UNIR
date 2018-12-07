using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class View_Informe_Saldos_FER
    {
        public Nullable<int> IdProyecto { get; set; }
        public string CodigoPRY { get; set; }
        public string NombrePRY { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<int> idobjetivo { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int tipopresupuesto { get; set; }
        public Nullable<int> anio { get; set; }
        public Nullable<decimal> presupuesto { get; set; }
        public Nullable<decimal> ejecutado { get; set; }
        public string NombreEMP { get; set; }
        public string pais { get; set; }
        public string moneda { get; set; }
        public string simbolomnd { get; set; }
    }
}
