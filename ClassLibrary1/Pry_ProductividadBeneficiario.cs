//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pry_ProductividadBeneficiario
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
