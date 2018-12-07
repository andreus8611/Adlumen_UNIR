using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class View_InformeCronogramaHitos
    {
        public string idproyecto { get; set; }
        public string nombreproyecto { get; set; }
        public string idejcutor { get; set; }
        public string nombreejecutor { get; set; }
        public string nombrepais { get; set; }
        public string fechainicio { get; set; }
        public string fechafin { get; set; }
        public int resultadoid { get; set; }
        public int porcentajeresultado { get; set; }
        public string nombreresultado { get; set; }
        public decimal actividadid { get; set; }
        public string actividadDes { get; set; }
        public int porcentajeact { get; set; }
        public int Idhito { get; set; }
        public string hito { get; set; }
        public int porcentajehito { get; set; }
        public int porcentajeperiodo { get; set; }
        public int periodo { get; set; }
    }
}
