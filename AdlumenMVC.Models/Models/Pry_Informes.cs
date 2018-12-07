using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Informes : ITenant
    {
        public Pry_Informes()
        {
            this.Pry_Informes_Donantes = new List<Pry_Informes_Donantes>();
            this.Pry_Informes_Encuestas = new List<Pry_Informes_Encuestas>();
            this.Pry_Informes_Indicador = new List<Pry_Informes_Indicador>();
            this.Pry_Informes_Presupuestos = new List<Pry_Informes_Presupuestos>();
            this.Pry_Informes_Supuestos = new List<Pry_Informes_Supuestos>();
        }

        public int IdInforme { get; set; }
        public Nullable<int> IdProyecto { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> FechaProgramada { get; set; }
        public Nullable<System.DateTime> FechaInforme { get; set; }
        public Nullable<double> PresupuestoMeta { get; set; }
        public Nullable<double> PresupuestoEjecutado { get; set; }
        public Nullable<double> AvanceMeta { get; set; }
        public Nullable<double> AvanceEjecutado { get; set; }
        public string DescripcionSupuestos { get; set; }
        public string Informe { get; set; }
        public Nullable<int> EvaluacionComponentes { get; set; }
        public string EvaluacionComponentesDes { get; set; }
        public Nullable<int> EvaluacionProposito { get; set; }
        public string EvaluacionPropositoDes { get; set; }
        public string Lecciones { get; set; }
        public string Acciones { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public Nullable<bool> IdEstadoNotificado { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<Pry_Informes_Donantes> Pry_Informes_Donantes { get; set; }
        public virtual ICollection<Pry_Informes_Encuestas> Pry_Informes_Encuestas { get; set; }
        public virtual ICollection<Pry_Informes_Indicador> Pry_Informes_Indicador { get; set; }
        public virtual ICollection<Pry_Informes_Presupuestos> Pry_Informes_Presupuestos { get; set; }
        public virtual Pry_InformesEstados Pry_InformesEstados { get; set; }
        public virtual Pry_NivelAceptacion Pry_NivelAceptacion { get; set; }
        public virtual Pry_NivelAceptacion Pry_NivelAceptacion1 { get; set; }
        public virtual Pry_Proyectos Pry_Proyectos { get; set; }
        public virtual ICollection<Pry_Informes_Supuestos> Pry_Informes_Supuestos { get; set; }
    }
}
