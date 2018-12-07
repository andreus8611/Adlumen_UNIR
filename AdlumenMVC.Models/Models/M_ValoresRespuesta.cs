using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class M_ValoresRespuesta : ITenant
    {
        public int IdValorRespuesta { get; set; }
        public Nullable<int> IdPreguntaResuelta { get; set; }
        public string Valor { get; set; }
        public int IdTenant { get; set; }
        public virtual M_PreguntasResueltas M_PreguntasResueltas { get; set; }
    }
}
