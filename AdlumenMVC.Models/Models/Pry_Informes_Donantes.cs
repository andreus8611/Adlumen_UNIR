using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Informes_Donantes : ITenant
    {
        public int IdInforme { get; set; }
        public int IdDonante { get; set; }
        public Nullable<double> Donacion { get; set; }
        public Nullable<System.DateTime> FechaPrimeraDonacion { get; set; }
        public Nullable<System.DateTime> FechaUltimaDonacion { get; set; }
        public int IdTenant { get; set; }
        public virtual Org_Donantes Org_Donantes { get; set; }
        public virtual Pry_Informes Pry_Informes { get; set; }
    }
}
