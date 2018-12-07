using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Proyectos : ITenant
    {
        public Pry_Proyectos()
        {
            this.Pry_Bitacoras = new List<Pry_Bitacoras>();
            this.Pry_CalendarioDonaciones = new List<Pry_CalendarioDonaciones>();
            this.Pry_EvaluacionHitos = new List<Pry_EvaluacionHitos>();
            this.PRY_EVALUACIONINDICADORESPERIODO = new List<PRY_EVALUACIONINDICADORESPERIODO>();
            this.PRY_EVALUACIONPROYECTOPERIODO = new List<PRY_EVALUACIONPROYECTOPERIODO>();
            this.Pry_Informes = new List<Pry_Informes>();
            this.PRY_INFORMESICA = new List<PRY_INFORMESICA>();
            this.PRY_PERIODOSPROYECTOS = new List<PRY_PERIODOSPROYECTOS>();
            this.Pry_Presupuesto = new List<Pry_Presupuesto>();
            this.Pry_Proyectos_Donantes = new List<Pry_Proyectos_Donantes>();
            this.Pry_Proyectos_NivelAceptacion = new List<Pry_Proyectos_NivelAceptacion>();
            this.Pry_Proyectos1 = new List<Pry_Proyectos>();
            this.Tar_Listas = new List<Tar_Listas>();
        }

        public int IdProyecto { get; set; }
        public Nullable<int> IdUsuarioResponsable { get; set; }
        public Nullable<int> IdUsuarioDigitador { get; set; }
        public Nullable<int> IdUsuarioEvaluador { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Problema { get; set; }
        public string DescripcionProblema { get; set; }
        public string Justificacion { get; set; }
        public Nullable<int> IdCategoriaDocumentos { get; set; }
        public Nullable<int> IdCategoriaSupuestos { get; set; }
        public string Beneficiarios { get; set; }
        public string Region { get; set; }
        public int DiasNotificacion { get; set; }
        public Nullable<int> IdMoneda { get; set; }
        public bool Eliminado { get; set; }
        public Nullable<int> IdProposito { get; set; }
        public string Area { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<double> Presupuesto { get; set; }
        public string Logo { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public int CustomerId { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public int IdTipo { get; set; }
        public Nullable<int> IDPROYECTOPADRE { get; set; }
        public Nullable<double> MONTOFINANCIAMIENTO { get; set; }
        public Nullable<double> MONTOCONTRAPARTIDA { get; set; }
        public int IdTenant { get; set; }
        public virtual M_Monedas M_Monedas { get; set; }
        public virtual ICollection<Pry_Bitacoras> Pry_Bitacoras { get; set; }
        public virtual ICollection<Pry_CalendarioDonaciones> Pry_CalendarioDonaciones { get; set; }
        public virtual ICollection<Pry_EvaluacionHitos> Pry_EvaluacionHitos { get; set; }
        public virtual ICollection<PRY_EVALUACIONINDICADORESPERIODO> PRY_EVALUACIONINDICADORESPERIODO { get; set; }
        public virtual ICollection<PRY_EVALUACIONPROYECTOPERIODO> PRY_EVALUACIONPROYECTOPERIODO { get; set; }
        public virtual ICollection<Pry_Informes> Pry_Informes { get; set; }
        public virtual ICollection<PRY_INFORMESICA> PRY_INFORMESICA { get; set; }
        public virtual Pry_Objetivos Pry_Objetivos { get; set; }
        public virtual ICollection<PRY_PERIODOSPROYECTOS> PRY_PERIODOSPROYECTOS { get; set; }
        public virtual ICollection<Pry_Presupuesto> Pry_Presupuesto { get; set; }
        public virtual ICollection<Pry_Proyectos_Donantes> Pry_Proyectos_Donantes { get; set; }
        public virtual ICollection<Pry_Proyectos_NivelAceptacion> Pry_Proyectos_NivelAceptacion { get; set; }
        public virtual ICollection<Pry_Proyectos> Pry_Proyectos1 { get; set; }
        public virtual Pry_Proyectos Pry_Proyectos2 { get; set; }
        public virtual Pry_ProyectosEstados Pry_ProyectosEstados { get; set; }
        public virtual Pry_ProyectosTipos Pry_ProyectosTipos { get; set; }
        public virtual Sys_Clientes Sys_Clientes { get; set; }
        public virtual Sys_Usuarios Sys_Usuarios { get; set; }
        public virtual Sys_Usuarios Sys_Usuarios1 { get; set; }
        public virtual Sys_Usuarios Sys_Usuarios2 { get; set; }
        public virtual ICollection<Tar_Listas> Tar_Listas { get; set; }
    }
}
