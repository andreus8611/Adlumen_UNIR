using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class View_InformeTecnicoAvanceHitos
    {
        public Nullable<long> id { get; set; }
        public string Proyecto { get; set; }
        public int IdProyecto { get; set; }
        public Nullable<System.DateTime> Fecha_de_Inicio { get; set; }
        public Nullable<System.DateTime> Fecha_de_Vencimiento { get; set; }
        public string Periodo { get; set; }
        public Nullable<int> IdProposito { get; set; }
        public string Proposito { get; set; }
        public int IdobjetivoResultado { get; set; }
        public string Entregable { get; set; }
        public Nullable<int> IdClaseResultdo { get; set; }
        public int IdobjetivoAvtividad { get; set; }
        public string Actividad { get; set; }
        public string Descripcion_Actividad { get; set; }
        public Nullable<System.DateTime> Fecha_de_Inicio_Actividad { get; set; }
        public Nullable<int> IdClaseActividad { get; set; }
        public Nullable<System.DateTime> Fecha_de_Inicio_Resultado { get; set; }
        public string Hito { get; set; }
        public Nullable<double> PondereadoProposito { get; set; }
        public Nullable<double> PonderedoResultado { get; set; }
        public Nullable<double> PonderedoActividad { get; set; }
        public Nullable<double> Ponderado_Hito { get; set; }
        public double Meta_actividad { get; set; }
        public double Meta_Resultado { get; set; }
        public double Meta_Proposito { get; set; }
        public long Idperiodo { get; set; }
        public Nullable<double> Ponderado_Avance_Hito { get; set; }
        public double Base_Hito { get; set; }
        public int IdIndicador { get; set; }
        public double Meta_Hito { get; set; }
        public string Obserbaciones_ED { get; set; }
        public string Observaciones_URIP { get; set; }
        public Nullable<decimal> ADH { get; set; }
        public Nullable<decimal> CV { get; set; }
    }
}
