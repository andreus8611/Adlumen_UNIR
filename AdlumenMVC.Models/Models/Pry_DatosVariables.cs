using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_DatosVariables : ITenant
    {
        public int IdDatosMuestra { get; set; }
        public int IdVariable { get; set; }
        public Nullable<double> Valor { get; set; }
        public int IdTenant { get; set; }
        public virtual Pry_DatosMuestras Pry_DatosMuestras { get; set; }
        public virtual Pry_Variables Pry_Variables { get; set; }
    }
}
