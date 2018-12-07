using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Org_EmpleadosCargosHistorico : ITenant
    {
        public int IdEmpleadoCargo { get; set; }
        public int IdEmpleado { get; set; }
        public int IdCargo { get; set; }
        public System.DateTime FechaInicioCargo { get; set; }
        public Nullable<System.DateTime> FechaFinCargo { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public int IdTenant { get; set; }
        public virtual Org_Cargos Org_Cargos { get; set; }
        public virtual Org_Empleados Org_Empleados { get; set; }
    }
}
