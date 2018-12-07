using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Org_Donantes_Empresas
    {
        public int IdDonante { get; set; }
        public int IdEmpresa { get; set; }
        public virtual Org_Donantes Org_Donantes { get; set; }
        public virtual Org_Empresas Org_Empresas { get; set; }
    }
}
