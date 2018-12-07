using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class M_Encuestas : ITenant
    {
        public M_Encuestas()
        {
            this.M_EncuestasResueltas = new List<M_EncuestasResueltas>();
            this.M_Preguntas = new List<M_Preguntas>();
        }

        public int IdEncuesta { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<int> IdIdioma { get; set; }
        public string Estado { get; set; }
        public int IdTenant { get; set; }
        public virtual M_Idiomas M_Idiomas { get; set; }
        public virtual ICollection<M_EncuestasResueltas> M_EncuestasResueltas { get; set; }
        public virtual ICollection<M_Preguntas> M_Preguntas { get; set; }
    }
}
