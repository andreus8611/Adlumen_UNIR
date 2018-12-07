using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_IndicadoresVerificadores : ITenant
    {
        public Pry_IndicadoresVerificadores()
        {
            this.Pry_DatosVerificadores = new List<Pry_DatosVerificadores>();
        }

        public int IdVerificador { get; set; }
        public int IdIndicador { get; set; }
        public string Descripcion { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<Pry_DatosVerificadores> Pry_DatosVerificadores { get; set; }
        public virtual Pry_Indicadores Pry_Indicadores { get; set; }
    }
}
