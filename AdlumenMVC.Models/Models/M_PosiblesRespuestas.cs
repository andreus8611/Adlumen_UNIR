using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class M_PosiblesRespuestas : ITenant
    {
        public int IdPosibleRespuesta { get; set; }
        public string Respuesta { get; set; }
        public Nullable<int> IdPregunta { get; set; }
        public int IdTenant { get; set; }
        public virtual M_Preguntas M_Preguntas { get; set; }
    }
}
