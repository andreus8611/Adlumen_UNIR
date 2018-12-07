using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class View_Informe_de_Saldos
    {
        public Nullable<long> id { get; set; }
        public string Proyecto { get; set; }
        public int IdProyecto { get; set; }
        public string Ejecutor { get; set; }
        public string Pais { get; set; }
        public Nullable<System.DateTime> Fecha_de_Vencimiento { get; set; }
        public Nullable<System.DateTime> Fecha_de_Inicio { get; set; }
        public int ObjetivoProposito { get; set; }
        public Nullable<double> Presupuesto_Proposito { get; set; }
        public string Proposito { get; set; }
        public Nullable<double> Presupuesto_de_Resultado { get; set; }
        public Nullable<int> Tipo_Presupuesto_Resultado { get; set; }
        public int ObjetivoResultado { get; set; }
        public string Resultado { get; set; }
        public int ObjetivoActividad { get; set; }
        public string Actividad { get; set; }
        public string Descripcion_de_Actividad { get; set; }
        public int IdPresupuestoActividad { get; set; }
        public Nullable<int> Tipo_de_Presupuesto_Actividad { get; set; }
        public Nullable<double> Presupuesto_de_Actividad { get; set; }
        public Nullable<double> Monto_Movimiento { get; set; }
        public System.DateTime Fecha_Gasto { get; set; }
        public Nullable<int> Año { get; set; }
        public string Descripcion_Monto { get; set; }
        public int IdMovimiento { get; set; }
    }
}
