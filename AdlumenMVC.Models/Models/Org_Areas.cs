using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Org_Areas : ITenant
    {
        public Org_Areas()
        {
            this.Org_Cargos = new List<Org_Cargos>();
        }

        public int IdArea { get; set; }
        public int IdPadre { get; set; }
        public int IdEmpresa { get; set; }
        public Nullable<int> IdResponsable { get; set; }
        public string Nombre { get; set; }
        public string Objetivo { get; set; }
        public string Descripcion { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public bool Eliminado { get; set; }
        public int IdTenant { get; set; }
        public virtual Org_Empresas Org_Empresas { get; set; }
        public virtual ICollection<Org_Cargos> Org_Cargos { get; set; }
    }
}
