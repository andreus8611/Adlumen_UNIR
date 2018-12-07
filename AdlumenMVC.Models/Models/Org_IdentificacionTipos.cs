using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Org_IdentificacionTipos// : ITenant
    {
        public Org_IdentificacionTipos()
        {
            this.Org_Donantes = new List<Org_Donantes>();
            this.Org_Empleados = new List<Org_Empleados>();
            this.Org_Empresas = new List<Org_Empresas>();
            this.Org_Proveedores = new List<Org_Proveedores>();
        }

        public int IdIdentificacionTipo { get; set; }
        public string Nombre { get; set; }
        //public int IdTenant { get; set; }
        public virtual ICollection<Org_Donantes> Org_Donantes { get; set; }
        public virtual ICollection<Org_Empleados> Org_Empleados { get; set; }
        public virtual ICollection<Org_Empresas> Org_Empresas { get; set; }
        public virtual ICollection<Org_Proveedores> Org_Proveedores { get; set; }
    }
}
