using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class M_Idiomas
    {
        public M_Idiomas()
        {
            this.M_Encuestas = new List<M_Encuestas>();
        }

        public int IdIdioma { get; set; }
        public string Nombre { get; set; }
        public string Mime { get; set; }
        public virtual ICollection<M_Encuestas> M_Encuestas { get; set; }
    }
}
