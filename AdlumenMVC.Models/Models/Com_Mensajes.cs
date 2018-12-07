using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Com_Mensajes : ITenant
    {
        public int IdMensaje { get; set; }
        public int IdUsuarioRemitente { get; set; }
        public int IdUsuarioDestinatario { get; set; }
        public int IdEstado { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public bool Prioridad { get; set; }
        public System.DateTime FechaEnvio { get; set; }
        public Nullable<System.DateTime> FechaLectura { get; set; }
        public Nullable<System.DateTime> FechaBorrado { get; set; }
        public int IdTenant { get; set; }
        public virtual Sys_Usuarios Sys_Usuarios { get; set; }
        public virtual Com_MensajesEstado Com_MensajesEstado { get; set; }
    }
}
