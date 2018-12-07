using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class M_EncuestasResueltas : ITenant
    {
        public M_EncuestasResueltas()
        {
            this.M_PreguntasResueltas = new List<M_PreguntasResueltas>();
        }

        public int IdEncuestaResuelta { get; set; }
        public Nullable<int> IdEncuesta { get; set; }
        public string Usuario { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Comentarios { get; set; }
        public int IdTenant { get; set; }
        public virtual M_Encuestas M_Encuestas { get; set; }
        public virtual ICollection<M_PreguntasResueltas> M_PreguntasResueltas { get; set; }
    }
}
