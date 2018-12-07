using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Objetivos : ITenant
    {
        public Pry_Objetivos()
        {
            this.Pry_Beneficiarios = new List<Pry_Beneficiarios>();
            this.PRY_EVALUACIONESACTIVIDADESPERIODO = new List<PRY_EVALUACIONESACTIVIDADESPERIODO>();
            this.Pry_EvaluacionHitos = new List<Pry_EvaluacionHitos>();
            this.Pry_EvaluacionHitos1 = new List<Pry_EvaluacionHitos>();
            this.PRY_EVALUACIONINDICADORESPERIODO = new List<PRY_EVALUACIONINDICADORESPERIODO>();
            this.PRY_INFORMESICAOBJETIVOS = new List<PRY_INFORMESICAOBJETIVOS>();
            this.Pry_Proyectos = new List<Pry_Proyectos>();
            this.Pry_Recursos = new List<Pry_Recursos>();
            this.Pry_Supuestos = new List<Pry_Supuestos>();
        }

        public int IdObjetivo { get; set; }
        public Nullable<int> IdPadre { get; set; }
        public Nullable<int> IdObjetivoClase { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Eliminado { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<int> IdResponsable { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<double> Ponderado { get; set; }
        public Nullable<double> Progreso { get; set; }
        public Nullable<int> IdNivelAceptacion { get; set; }
        public Nullable<double> Efectividad { get; set; }
        public Nullable<double> Eficacia { get; set; }
        public Nullable<double> Eficiencia { get; set; }
        public Nullable<double> Costo { get; set; }
        public Nullable<int> IdNivelAceptacionEfectividad { get; set; }
        public Nullable<int> IdNivelAceptacionEficacia { get; set; }
        public Nullable<int> IdNivelAceptacionEficiencia { get; set; }
        public Nullable<int> IdNivelAceptacionCosto { get; set; }
        public bool CostoNotificado { get; set; }
        public bool EfectividadNotificada { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public int IdProyecto { get; set; }
        public int IdTenant { get; set; }
        public virtual Org_Empresas Org_Empresas { get; set; }
        public virtual ICollection<Pry_Beneficiarios> Pry_Beneficiarios { get; set; }
        public virtual ICollection<PRY_EVALUACIONESACTIVIDADESPERIODO> PRY_EVALUACIONESACTIVIDADESPERIODO { get; set; }
        public virtual ICollection<Pry_EvaluacionHitos> Pry_EvaluacionHitos { get; set; }
        public virtual ICollection<Pry_EvaluacionHitos> Pry_EvaluacionHitos1 { get; set; }
        public virtual ICollection<PRY_EVALUACIONINDICADORESPERIODO> PRY_EVALUACIONINDICADORESPERIODO { get; set; }
        public virtual ICollection<PRY_INFORMESICAOBJETIVOS> PRY_INFORMESICAOBJETIVOS { get; set; }
        public virtual Pry_ObjetivosClase Pry_ObjetivosClase { get; set; }
        public virtual ICollection<Pry_Proyectos> Pry_Proyectos { get; set; }
        public virtual ICollection<Pry_Recursos> Pry_Recursos { get; set; }
        public virtual ICollection<Pry_Supuestos> Pry_Supuestos { get; set; }
    }
}
