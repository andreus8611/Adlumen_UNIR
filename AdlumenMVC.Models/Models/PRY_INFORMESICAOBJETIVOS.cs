using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class PRY_INFORMESICAOBJETIVOS : ITenant
    {
        public int IDINFORME { get; set; }
        public int IDOBJETIVO { get; set; }
        public string LOGROS { get; set; }
        public int IdTenant { get; set; }
        public virtual PRY_INFORMESICA PRY_INFORMESICA { get; set; }
        public virtual Pry_Objetivos Pry_Objetivos { get; set; }
    }
}
