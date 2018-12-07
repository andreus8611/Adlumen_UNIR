using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Sys_Usuarios_Empresas
    {
        public int IdUsuario { get; set; }
        public int IdEmpresa { get; set; }
        public virtual Org_Empresas Org_Empresas { get; set; }
        public virtual Sys_Usuarios Sys_Usuarios { get; set; }
    }
}
