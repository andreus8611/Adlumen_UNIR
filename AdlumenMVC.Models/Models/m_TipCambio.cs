using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdlumenMVC.Models.Model
{
    public partial class m_TipCambio : ITenant
    {
        public int idTipCambio { get; set; }
        public int idMoneda { get; set; }
        public System.DateTime FecTipCambio { get; set; }
        public Nullable<decimal> ValCompra { get; set; }
        public Nullable<decimal> ValVenta { get; set; }
        public int IdTenant { get; set; }
        [ForeignKey("idMoneda")]
        public virtual M_Monedas M_Monedas { get; set; }
    }
}
