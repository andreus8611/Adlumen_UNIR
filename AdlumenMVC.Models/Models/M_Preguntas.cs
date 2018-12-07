using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class M_Preguntas : ITenant
    {
        public M_Preguntas()
        {
            this.M_PosiblesRespuestas = new List<M_PosiblesRespuestas>();
            this.M_PreguntasResueltas = new List<M_PreguntasResueltas>();
            this.Pry_Informes_Encuestas = new List<Pry_Informes_Encuestas>();
        }

        public int IdPregunta { get; set; }
        public Nullable<int> IdEncuesta { get; set; }
        public string Pregunta { get; set; }
        public Nullable<int> Tipo { get; set; }
        public Nullable<int> Orden { get; set; }
        public int IdTenant { get; set; }
        public virtual M_Encuestas M_Encuestas { get; set; }
        public virtual ICollection<M_PosiblesRespuestas> M_PosiblesRespuestas { get; set; }
        public virtual ICollection<M_PreguntasResueltas> M_PreguntasResueltas { get; set; }
        public virtual ICollection<Pry_Informes_Encuestas> Pry_Informes_Encuestas { get; set; }
    }
}
