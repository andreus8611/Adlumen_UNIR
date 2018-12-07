using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Org_Cargos : ITenant
    {
        public Org_Cargos()
        {
            this.Org_Empleados = new List<Org_Empleados>();
            this.Org_EmpleadosCargosHistorico = new List<Org_EmpleadosCargosHistorico>();
        }

        public int IdCargo { get; set; }
        public int IdArea { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> IdPadre { get; set; }
        public string Descripcion { get; set; }
        public string Perfil { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public bool Eliminado { get; set; }
        public int IdTenant { get; set; }
        public virtual Org_Areas Org_Areas { get; set; }
        public virtual ICollection<Org_Empleados> Org_Empleados { get; set; }
        public virtual ICollection<Org_EmpleadosCargosHistorico> Org_EmpleadosCargosHistorico { get; set; }
    }
}
