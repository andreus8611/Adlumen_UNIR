//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tar_Permisos_Bitacora
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
