using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Cms_Menus : ITenant
    {
        public Cms_Menus()
        {
            this.Cms_MenuNodos = new List<Cms_MenuNodos>();
            this.Org_Empresas = new List<Org_Empresas>();
            this.Org_Empresas1 = new List<Org_Empresas>();
            this.Org_Empresas2 = new List<Org_Empresas>();
        }

        public int IdMenu { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<Cms_MenuNodos> Cms_MenuNodos { get; set; }
        public virtual ICollection<Org_Empresas> Org_Empresas { get; set; }
        public virtual ICollection<Org_Empresas> Org_Empresas1 { get; set; }
        public virtual ICollection<Org_Empresas> Org_Empresas2 { get; set; }
    }
}
