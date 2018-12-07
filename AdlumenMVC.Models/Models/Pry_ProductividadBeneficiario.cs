using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_ProductividadBeneficiario : ITenant
    {
        public int IdProductividadBeneficiario { get; set; }
        public int IdBeneficiario { get; set; }
        public decimal AreaSembrada { get; set; }
        public string CultivoSembrado { get; set; }
        public decimal CantidadSembrada { get; set; }
        public decimal ProduccionCultivo { get; set; }
        public bool Eliminado { get; set; }
        public int IdTenant { get; set; }
        public virtual Pry_Beneficiarios Pry_Beneficiarios { get; set; }
    }
}
