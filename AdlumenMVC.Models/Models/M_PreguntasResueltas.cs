using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class M_PreguntasResueltas : ITenant
    {
        public M_PreguntasResueltas()
        {
            this.M_ValoresRespuesta = new List<M_ValoresRespuesta>();
        }

        public int IdPreguntaResuelta { get; set; }
        public Nullable<int> IdEncuestaResuelta { get; set; }
        public Nullable<int> IdPregunta { get; set; }
        public string TextoRespuesta { get; set; }
        public int IdTenant { get; set; }
        public virtual M_EncuestasResueltas M_EncuestasResueltas { get; set; }
        public virtual M_Preguntas M_Preguntas { get; set; }
        public virtual ICollection<M_ValoresRespuesta> M_ValoresRespuesta { get; set; }
    }
}
