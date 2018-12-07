using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class PRY_INFORMESICAINDICADORES : ITenant
    {
        public int IDINFORME { get; set; }
        public int IDINDICADOR { get; set; }
        public string LOGROS { get; set; }
        public int IdTenant { get; set; }
        public virtual Pry_Indicadores Pry_Indicadores { get; set; }
        public virtual PRY_INFORMESICA PRY_INFORMESICA { get; set; }
    }
}
