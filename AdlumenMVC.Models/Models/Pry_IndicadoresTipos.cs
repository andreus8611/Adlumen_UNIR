using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_IndicadoresTipos// : ITenant
    {
        public Pry_IndicadoresTipos()
        {
            this.Pry_Indicadores = new List<Pry_Indicadores>();
            this.Pry_Indicadores1 = new List<Pry_Indicadores>();
        }

        public int IdTipo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdPadre { get; set; }
        public string Myme { get; set; }
        //public int IdTenant { get; set; }
        public virtual ICollection<Pry_Indicadores> Pry_Indicadores { get; set; }
        public virtual ICollection<Pry_Indicadores> Pry_Indicadores1 { get; set; }
    }
}
