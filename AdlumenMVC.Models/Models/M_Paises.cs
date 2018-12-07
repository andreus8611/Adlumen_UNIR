using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class M_Paises
    {
        public M_Paises()
        {
            this.Org_Empresas = new List<Org_Empresas>();
        }

        public int IdPais { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Org_Empresas> Org_Empresas { get; set; }
    }
}
