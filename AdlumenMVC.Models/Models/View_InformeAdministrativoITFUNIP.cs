using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class View_InformeAdministrativoITFUNIP
    {
        public string Programa { get; set; }
        public int IdProyecto { get; set; }
        public string Proyecto { get; set; }
        public string Codigo { get; set; }
        public Nullable<System.DateTime> Fecha_de_Inicio { get; set; }
        public Nullable<System.DateTime> Fecha_de_Vencimiento { get; set; }
        public string Pais { get; set; }
        public string Entidad_Desarrolladora { get; set; }
        public long IdPeriodo { get; set; }
        public string Periodo { get; set; }
        public Nullable<int> ObjetivoActividad { get; set; }
        public string Actividad { get; set; }
        public string Descripcion_de_Actividad { get; set; }
        public string Observacion_de_la_Actividad { get; set; }
        public string Recomendaciones { get; set; }
        public string Observaciones_Generales { get; set; }
        public string Datos_Financieros { get; set; }
    }
}
