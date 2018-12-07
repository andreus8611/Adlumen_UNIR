using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdlumenMVC.Models.Model
{
    public partial class M_Monedas : ITenant
    {
        public M_Monedas()
        {
            this.m_TipCambio = new List<m_TipCambio>();
            this.Pry_Movimientos = new List<Pry_Movimientos>();
            this.Pry_Proyectos = new List<Pry_Proyectos>();
        }

        public int IdMoneda { get; set; }
        public string Nombre { get; set; }
        public string Representacion { get; set; }
        public string Codigo { get; set; }
        public int IdTenant { get; set; }

        [InverseProperty("M_Monedas")]
        public virtual ICollection<m_TipCambio> m_TipCambio { get; set; }
        public virtual ICollection<Pry_Movimientos> Pry_Movimientos { get; set; }
        public virtual ICollection<Pry_Proyectos> Pry_Proyectos { get; set; }
    }
}
