using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_PresupuestoTipo// : ITenant
    {
        public Pry_PresupuestoTipo()
        {
            this.Pry_Presupuesto = new List<Pry_Presupuesto>();
        }

        public int IdTipo { get; set; }
        public string Descripcion { get; set; }
        //public int IdTenant { get; set; }
        public BudgetType Tipo { get; set; }
        public virtual ICollection<Pry_Presupuesto> Pry_Presupuesto { get; set; }
    }
}
