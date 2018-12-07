using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class PRY_INFORMESICA : ITenant
    {
        public PRY_INFORMESICA()
        {
            this.PRY_INFORMESICADETALLE = new List<PRY_INFORMESICADETALLE>();
            this.PRY_INFORMESICADOCUMENTOS = new List<PRY_INFORMESICADOCUMENTOS>();
            this.PRY_INFORMESICAINDICADORES = new List<PRY_INFORMESICAINDICADORES>();
            this.PRY_INFORMESICAOBJETIVOS = new List<PRY_INFORMESICAOBJETIVOS>();
        }

        public int IDINFORME { get; set; }
        public int IDPROYECTO { get; set; }
        public int IDTIPO { get; set; }
        public System.DateTime FECHA { get; set; }
        public int IDESTADO { get; set; }
        public long PERIODOINICIAL { get; set; }
        public long PERIODOFINAL { get; set; }
        public int IdTenant { get; set; }
        public virtual PRY_INFORMESICAESTADOS PRY_INFORMESICAESTADOS { get; set; }
        public virtual PRY_INFORMESICATIPOS PRY_INFORMESICATIPOS { get; set; }
        public virtual PRY_PERIODOSPROYECTOS PRY_PERIODOSPROYECTOS { get; set; }
        public virtual PRY_PERIODOSPROYECTOS PRY_PERIODOSPROYECTOS1 { get; set; }
        public virtual Pry_Proyectos Pry_Proyectos { get; set; }
        public virtual ICollection<PRY_INFORMESICADETALLE> PRY_INFORMESICADETALLE { get; set; }
        public virtual ICollection<PRY_INFORMESICADOCUMENTOS> PRY_INFORMESICADOCUMENTOS { get; set; }
        public virtual ICollection<PRY_INFORMESICAINDICADORES> PRY_INFORMESICAINDICADORES { get; set; }
        public virtual ICollection<PRY_INFORMESICAOBJETIVOS> PRY_INFORMESICAOBJETIVOS { get; set; }
    }
}
