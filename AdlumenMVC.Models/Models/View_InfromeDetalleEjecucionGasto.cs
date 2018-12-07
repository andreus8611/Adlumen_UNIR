using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class View_InfromeDetalleEjecucionGasto
    {
        public Nullable<long> id { get; set; }
        public string Proyecto { get; set; }
        public int IdProyecto { get; set; }
        public string Pais { get; set; }
        public string Ejecutor { get; set; }
        public Nullable<System.DateTime> Fecha_de_Inicio { get; set; }
        public Nullable<System.DateTime> Fecha_de_Vencimiento { get; set; }
        public string Periodo_Movimiento { get; set; }
        public int ObjetivoProposito { get; set; }
        public string Proposito { get; set; }
        public Nullable<double> Presupuesto_Proposito { get; set; }
        public int ObjetivoResultado { get; set; }
        public string Resultado { get; set; }
        public int ObjetivoActividad { get; set; }
        public string Actividad { get; set; }
        public string Descripcion_de_Actividad { get; set; }
        public Nullable<double> Presupuesto_Actividad { get; set; }
        public string IdPresupuestoActividad { get; set; }
        public Nullable<double> Monto_Movimiento { get; set; }
        public Nullable<int> Tipo_Presupuesto_Actividad { get; set; }
        public int IdPartidaGasto { get; set; }
        public string Partida_Gasto { get; set; }
        public string Beneficiario { get; set; }
        public Nullable<decimal> Aportes { get; set; }
        public Nullable<decimal> Contrapartida { get; set; }
        public Nullable<System.DateTime> Fecha_Pago { get; set; }
        public decimal Taza_Cambio { get; set; }
        public int Cheque_Operacion { get; set; }
        public string Numero_Comprobante { get; set; }
    }
}
