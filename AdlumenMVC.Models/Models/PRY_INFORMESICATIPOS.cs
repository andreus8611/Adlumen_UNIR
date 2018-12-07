using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class PRY_INFORMESICATIPOS// : ITenant
    {
        public PRY_INFORMESICATIPOS()
        {
            this.PRY_INFORMESICA = new List<PRY_INFORMESICA>();
        }

        public int IDTIPO { get; set; }
        public string DESCRIPCION { get; set; }
        //public int IdTenant { get; set; }
        public virtual ICollection<PRY_INFORMESICA> PRY_INFORMESICA { get; set; }
    }
}
