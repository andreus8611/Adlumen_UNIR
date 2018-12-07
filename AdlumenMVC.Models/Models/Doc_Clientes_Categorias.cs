using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Doc_Clientes_Categorias : ITenant
    {
        public int IdCliente { get; set; }
        public int IdCategoria { get; set; }
        public int IdTenant { get; set; }
        public virtual Doc_Categorias Doc_Categorias { get; set; }
        public virtual Sys_Clientes Sys_Clientes { get; set; }
    }
}
