using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Sys_Usuarios_Donantes
    {
        public int IdUsuario { get; set; }
        public int IdDonante { get; set; }
        public virtual Org_Donantes Org_Donantes { get; set; }
        public virtual Sys_Usuarios Sys_Usuarios { get; set; }
    }
}
