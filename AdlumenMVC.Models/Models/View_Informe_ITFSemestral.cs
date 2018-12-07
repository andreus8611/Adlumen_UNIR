using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class View_Informe_ITFSemestral
    {
        public Nullable<long> id { get; set; }
        public string Proyecto { get; set; }
        public int IdProyecto { get; set; }
        public string Codigo { get; set; }
        public string Pais { get; set; }
        public string Ejecutor { get; set; }
        public string Periodo { get; set; }
        public long IdPeriodo { get; set; }
        public string LogrosPrincipales { get; set; }
        public string Observaciones { get; set; }
        public string Factores_Exito { get; set; }
        public string Factores_Limitantes { get; set; }
        public string Condiicionalidad { get; set; }
        public string Sostenibilidad { get; set; }
        public string Problemas_y_Acciones { get; set; }
        public string Sostenibilidad_Replicas { get; set; }
        public Nullable<int> ObjetivoProposito { get; set; }
        public string Proposito { get; set; }
        public string Logros_Comentarios_Proproposito { get; set; }
        public double CantidadPro { get; set; }
        public double CantidadResul { get; set; }
        public string Indicadores_Proposito { get; set; }
        public int IdIndicadorproposito { get; set; }
        public string Explicacion_Logros_Proposito { get; set; }
        public int ObjetivoResultado { get; set; }
        public string Resultado { get; set; }
        public string Logros_Comentarios_Resultado { get; set; }
        public string Recomendaciones { get; set; }
        public string Replicas { get; set; }
        public string Avance_Principal { get; set; }
        public string Cambios_Internos { get; set; }
        public int Tipo_Informe { get; set; }
        public string Objetivo_General { get; set; }
        public Nullable<System.DateTime> Fecha_Fin { get; set; }
        public Nullable<System.DateTime> Fecha_Inicio { get; set; }
        public string Indicadores_Resultado { get; set; }
        public string Explicacion_logros_Resultado { get; set; }
        public int Idindicadorresultado { get; set; }
        public double Base_Proposito { get; set; }
        public double Base_Resultado { get; set; }
    }
}
