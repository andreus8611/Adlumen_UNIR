using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class PRY_PERIODOSPROYECTOS : ITenant
    {
        public PRY_PERIODOSPROYECTOS()
        {
            this.Pry_DatosMuestras = new List<Pry_DatosMuestras>();
            this.Pry_EvaluacionHitos = new List<Pry_EvaluacionHitos>();
            this.PRY_EVALUACIONINDICADORESPERIODO = new List<PRY_EVALUACIONINDICADORESPERIODO>();
            this.PRY_EVALUACIONPROYECTOPERIODO = new List<PRY_EVALUACIONPROYECTOPERIODO>();
            this.PRY_INFORMESICA = new List<PRY_INFORMESICA>();
            this.PRY_INFORMESICA1 = new List<PRY_INFORMESICA>();
            this.Pry_Movimientos = new List<Pry_Movimientos>();
        }

        public long IdPeriodo { get; set; }
        public string Nombre { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
        public Nullable<int> IdProyecto { get; set; }
        public bool Activo { get; set; }
        public int Secuencia { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<Pry_DatosMuestras> Pry_DatosMuestras { get; set; }
        public virtual ICollection<Pry_EvaluacionHitos> Pry_EvaluacionHitos { get; set; }
        public virtual ICollection<PRY_EVALUACIONINDICADORESPERIODO> PRY_EVALUACIONINDICADORESPERIODO { get; set; }
        public virtual ICollection<PRY_EVALUACIONPROYECTOPERIODO> PRY_EVALUACIONPROYECTOPERIODO { get; set; }
        public virtual ICollection<PRY_INFORMESICA> PRY_INFORMESICA { get; set; }
        public virtual ICollection<PRY_INFORMESICA> PRY_INFORMESICA1 { get; set; }
        public virtual ICollection<Pry_Movimientos> Pry_Movimientos { get; set; }
        public virtual Pry_Proyectos Pry_Proyectos { get; set; }
    }
}
