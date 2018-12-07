using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_MontoDonacion : ITenant
    {
        public int IdMontoDonante { get; set; }
        public Nullable<int> IdMovimiento { get; set; }
        public Nullable<int> IdDonante { get; set; }
        public Nullable<double> Monto { get; set; }
        public int IdTenant { get; set; }
        public virtual Pry_Movimientos Pry_Movimientos { get; set; }
    }
}
