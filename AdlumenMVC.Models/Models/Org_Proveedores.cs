using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Org_Proveedores : ITenant
    {
        public int IdProveedor { get; set; }
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public int IdIdentificacionTipo { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Ubicacion { get; set; }
        public string HojaVida { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool Eliminado { get; set; }
        public int IdTenant { get; set; }
        public virtual Org_Empresas Org_Empresas { get; set; }
        public virtual Org_IdentificacionTipos Org_IdentificacionTipos { get; set; }
    }
}
