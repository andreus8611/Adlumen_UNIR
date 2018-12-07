using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_DatosVerificadores : ITenant
    {
        public int IdDatosFuentes { get; set; }
        public Nullable<int> IdDatosMuestra { get; set; }
        public Nullable<int> IdVerificador { get; set; }
        public string Url { get; set; }
        public int IdTenant { get; set; }
        public virtual Pry_DatosMuestras Pry_DatosMuestras { get; set; }
        public virtual Pry_IndicadoresVerificadores Pry_IndicadoresVerificadores { get; set; }
    }
}
