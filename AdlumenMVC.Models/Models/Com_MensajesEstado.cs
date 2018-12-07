using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Com_MensajesEstado// : ITenant
    {
        public Com_MensajesEstado()
        {
            this.Com_Mensajes = new List<Com_Mensajes>();
        }

        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public string Observaciones { get; set; }
        //public int IdTenant { get; set; }
        public virtual ICollection<Com_Mensajes> Com_Mensajes { get; set; }
    }
}
