using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Informes_Encuestas : ITenant
    {
        public int IdInforme { get; set; }
        public int IdPregunta { get; set; }
        public Nullable<bool> Respuesta { get; set; }
        public string Descripcion { get; set; }
        public int IdTenant { get; set; }
        public virtual M_Preguntas M_Preguntas { get; set; }
        public virtual Pry_Informes Pry_Informes { get; set; }
    }
}
