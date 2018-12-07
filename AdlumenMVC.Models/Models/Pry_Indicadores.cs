using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Indicadores : ITenant
    {
        public Pry_Indicadores()
        {
            this.Pry_DatosMuestras = new List<Pry_DatosMuestras>();
            this.Pry_EvaluacionHitos = new List<Pry_EvaluacionHitos>();
            this.PRY_EVALUACIONINDICADORESPERIODO = new List<PRY_EVALUACIONINDICADORESPERIODO>();
            this.Pry_Indicadores_Variables = new List<Pry_Indicadores_Variables>();
            this.Pry_IndicadoresProyecto_Programa = new List<Pry_IndicadoresProyecto_Programa>();
            this.Pry_IndicadoresVerificadores = new List<Pry_IndicadoresVerificadores>();
            this.Pry_Informes_Indicador = new List<Pry_Informes_Indicador>();
            this.PRY_INFORMESICAINDICADORES = new List<PRY_INFORMESICAINDICADORES>();
        }

        public int IdIndicador { get; set; }
        public Nullable<int> IdObjetivo { get; set; }
        public string Codigo { get; set; }
        public int IdTipo { get; set; }
        public int IdSubTipo { get; set; }
        public string Descripcion { get; set; }
        public string Definicion { get; set; }
        public string Objetivo { get; set; }
        public string Cualidades { get; set; }
        public string UnidadMedida { get; set; }
        public string Cobertura { get; set; }
        public Nullable<int> IdResponsableIndicador { get; set; }
        public string UnidadOperativa { get; set; }
        public string UnidadOperativaId { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public double Base { get; set; }
        public double Meta { get; set; }
        public bool Porcentual { get; set; }
        public Nullable<double> Ponderado { get; set; }
        public Nullable<int> IdDatosMuestra { get; set; }
        public bool EfectividadNotificada { get; set; }
        public string PalabrasClave { get; set; }
        public Nullable<long> IdPeriodo { get; set; }
        public int IdTenant { get; set; }
        public virtual Org_Empleados Org_Empleados { get; set; }
        public virtual ICollection<Pry_DatosMuestras> Pry_DatosMuestras { get; set; }
        public virtual ICollection<Pry_EvaluacionHitos> Pry_EvaluacionHitos { get; set; }
        public virtual ICollection<PRY_EVALUACIONINDICADORESPERIODO> PRY_EVALUACIONINDICADORESPERIODO { get; set; }
        public virtual Pry_IndicadoresTipos Pry_IndicadoresTipos { get; set; }
        public virtual Pry_IndicadoresTipos Pry_IndicadoresTipos1 { get; set; }
        public virtual ICollection<Pry_Indicadores_Variables> Pry_Indicadores_Variables { get; set; }
        public virtual ICollection<Pry_IndicadoresProyecto_Programa> Pry_IndicadoresProyecto_Programa { get; set; }
        public virtual ICollection<Pry_IndicadoresVerificadores> Pry_IndicadoresVerificadores { get; set; }
        public virtual ICollection<Pry_Informes_Indicador> Pry_Informes_Indicador { get; set; }
        public virtual ICollection<PRY_INFORMESICAINDICADORES> PRY_INFORMESICAINDICADORES { get; set; }
    }
}
