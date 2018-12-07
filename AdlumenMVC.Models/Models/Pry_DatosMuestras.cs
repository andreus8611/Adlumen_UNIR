using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_DatosMuestras : ITenant
    {
        public Pry_DatosMuestras()
        {
            this.Pry_DatosVariables = new List<Pry_DatosVariables>();
            this.Pry_DatosVerificadores = new List<Pry_DatosVerificadores>();
            this.Pry_Informes_Indicador = new List<Pry_Informes_Indicador>();
        }

        public int IdDatosMuestra { get; set; }
        public Nullable<int> IdIndicador { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<double> Logro { get; set; }
        public string Observaciones { get; set; }
        public Nullable<double> Efectividad { get; set; }
        public Nullable<int> IdNivelAceptacionEfectividad { get; set; }
        public Nullable<double> Eficacia { get; set; }
        public Nullable<int> IdNivelAceptacionEficacia { get; set; }
        public Nullable<long> IdPeriodo { get; set; }
        public string USUARIOCREACION { get; set; }
        public Nullable<System.DateTime> FECHACREACION { get; set; }
        public string USUARIOMODIFICACION { get; set; }
        public Nullable<System.DateTime> FECHAMODIFICACION { get; set; }
        public int IdTenant { get; set; }
        public virtual Pry_Indicadores Pry_Indicadores { get; set; }
        public virtual Pry_NivelAceptacion Pry_NivelAceptacion { get; set; }
        public virtual PRY_PERIODOSPROYECTOS PRY_PERIODOSPROYECTOS { get; set; }
        public virtual ICollection<Pry_DatosVariables> Pry_DatosVariables { get; set; }
        public virtual ICollection<Pry_DatosVerificadores> Pry_DatosVerificadores { get; set; }
        public virtual ICollection<Pry_Informes_Indicador> Pry_Informes_Indicador { get; set; }
    }
}
