using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Informes_Indicador : ITenant
    {
        public int IdInforme { get; set; }
        public int IdIndicador { get; set; }
        public Nullable<double> Meta { get; set; }
        public Nullable<int> IdDatosMuestra { get; set; }
        public Nullable<int> Evaluacion { get; set; }
        public int IdTenant { get; set; }
        public virtual Pry_DatosMuestras Pry_DatosMuestras { get; set; }
        public virtual Pry_Indicadores Pry_Indicadores { get; set; }
        public virtual Pry_Informes Pry_Informes { get; set; }
        public virtual Pry_NivelAceptacion Pry_NivelAceptacion { get; set; }
    }
}
