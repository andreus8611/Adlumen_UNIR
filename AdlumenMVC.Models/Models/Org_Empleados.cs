using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Org_Empleados : ITenant
    {
        public Org_Empleados()
        {
            this.Org_EmpleadosCargosHistorico = new List<Org_EmpleadosCargosHistorico>();
            this.Pry_Indicadores = new List<Pry_Indicadores>();
        }

        public int IdEmpleado { get; set; }
        public Nullable<int> IdCargo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdIdentificacionTipo { get; set; }
        public string Identificacion { get; set; }
        public string Foto { get; set; }
        public string Correo { get; set; }
        public string Observaciones { get; set; }
        public string Competencias { get; set; }
        public string HojaVida { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public bool Retirado { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public int IdTenant { get; set; }
        public virtual Org_Cargos Org_Cargos { get; set; }
        public virtual Org_IdentificacionTipos Org_IdentificacionTipos { get; set; }
        public virtual Sys_Usuarios Sys_Usuarios { get; set; }
        public virtual ICollection<Org_EmpleadosCargosHistorico> Org_EmpleadosCargosHistorico { get; set; }
        public virtual ICollection<Pry_Indicadores> Pry_Indicadores { get; set; }
    }
}
