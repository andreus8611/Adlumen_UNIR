using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Tar_Permisos_Bitacora : ITenant
    {
        public int IdPermisoBitacora { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdVisita { get; set; }
        public string Permiso { get; set; }
        public int IdTenant { get; set; }
        public virtual Sys_Usuarios Sys_Usuarios { get; set; }
        public virtual Tar_Visitas Tar_Visitas { get; set; }
    }
}
