//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdlumenMVC.Models.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Com_Mensajes
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