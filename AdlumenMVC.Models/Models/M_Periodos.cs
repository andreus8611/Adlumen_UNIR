using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class M_Periodos// : ITenant
    {
        public int IdPeriodo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> ValorDias { get; set; }
        //public int IdTenant { get; set; }
    }
}
