using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Beneficiarios : ITenant
    {
        public Pry_Beneficiarios()
        {
            this.Pry_CapacitacionBeneficiario = new List<Pry_CapacitacionBeneficiario>();
            this.Pry_ProductividadBeneficiario = new List<Pry_ProductividadBeneficiario>();
        }

        public int IdBeneficiario { get; set; }
        public int IdObjetivo { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public Nullable<decimal> extensionTerritorial { get; set; }
        public byte Status { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<Pry_CapacitacionBeneficiario> Pry_CapacitacionBeneficiario { get; set; }
        public virtual Pry_Objetivos Pry_Objetivos { get; set; }
        public virtual ICollection<Pry_ProductividadBeneficiario> Pry_ProductividadBeneficiario { get; set; }
    }
}
