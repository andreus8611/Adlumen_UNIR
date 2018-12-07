using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Variables : ITenant
    {
        public Pry_Variables()
        {
            this.Pry_DatosVariables = new List<Pry_DatosVariables>();
            this.Pry_Indicadores_Variables = new List<Pry_Indicadores_Variables>();
        }

        public int IdVariable { get; set; }
        public string Nombre { get; set; }
        public string FuenteInformacion { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<Pry_DatosVariables> Pry_DatosVariables { get; set; }
        public virtual ICollection<Pry_Indicadores_Variables> Pry_Indicadores_Variables { get; set; }
    }
}
