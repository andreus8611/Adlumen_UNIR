using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class PRY_PARTIDAGASTOS : ITenant
    {
        public PRY_PARTIDAGASTOS()
        {
            this.Pry_Movimientos = new List<Pry_Movimientos>();
            this.Pry_Recursos = new List<Pry_Recursos>();
        }

        public int IDPARTIDAGASTO { get; set; }
        public string ABREVIATURA { get; set; }
        public string CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<Pry_Movimientos> Pry_Movimientos { get; set; }
        public virtual ICollection<Pry_Recursos> Pry_Recursos { get; set; }
    }
}
