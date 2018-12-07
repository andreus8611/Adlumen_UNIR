using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class PRY_INFORMESICAESTADOS// : ITenant
    {
        public PRY_INFORMESICAESTADOS()
        {
            this.PRY_INFORMESICA = new List<PRY_INFORMESICA>();
        }

        public int IDESTADO { get; set; }
        public string DESCRIPCION { get; set; }
        //public int IdTenant { get; set; }
        public virtual ICollection<PRY_INFORMESICA> PRY_INFORMESICA { get; set; }
    }
}
