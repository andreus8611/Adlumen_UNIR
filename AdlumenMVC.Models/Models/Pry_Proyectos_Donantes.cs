using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Proyectos_Donantes : ITenant
    {
        public int IdProyecto { get; set; }
        public int IdDonante { get; set; }
        public Nullable<int> IdUsuarioResponsable { get; set; }
        public Nullable<double> Monto { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public int IdTenant { get; set; }
        public virtual Org_Donantes Org_Donantes { get; set; }
        public virtual Pry_Proyectos Pry_Proyectos { get; set; }
        public virtual Sys_Usuarios Sys_Usuarios { get; set; }
    }
}
