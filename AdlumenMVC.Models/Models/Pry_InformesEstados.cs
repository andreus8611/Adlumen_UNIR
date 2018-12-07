using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_InformesEstados// : ITenant
    {
        public Pry_InformesEstados()
        {
            this.Pry_Informes = new List<Pry_Informes>();
        }

        public int IdEstado { get; set; }
        public string Descripcion { get; set; }
        //public int IdTenant { get; set; }
        public virtual ICollection<Pry_Informes> Pry_Informes { get; set; }
    }
}
