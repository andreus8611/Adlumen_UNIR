using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class M_Plantillas : ITenant
    {
        public Nullable<int> IdPlantilla { get; set; }
        public string Plantilla { get; set; }
        public int IdTenant { get; set; }
    }
}
