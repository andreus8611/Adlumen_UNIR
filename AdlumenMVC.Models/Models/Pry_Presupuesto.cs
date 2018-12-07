using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Presupuesto : ITenant
    {
        public Pry_Presupuesto()
        {
            this.Pry_Informes_Presupuestos = new List<Pry_Informes_Presupuestos>();
            this.Pry_Movimientos = new List<Pry_Movimientos>();
        }

        public int IdPresupuesto { get; set; }
        public Nullable<int> IdTipoPresupuesto { get; set; }
        public Nullable<int> IdObjetivo { get; set; }
        public Nullable<int> IdProyecto { get; set; }
        public Nullable<double> Monto { get; set; }
        public Nullable<int> IdDonante { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<Pry_Informes_Presupuestos> Pry_Informes_Presupuestos { get; set; }
        public virtual ICollection<Pry_Movimientos> Pry_Movimientos { get; set; }
        public virtual Pry_PresupuestoTipo Pry_PresupuestoTipo { get; set; }
        public virtual Pry_Proyectos Pry_Proyectos { get; set; }
    }
}
