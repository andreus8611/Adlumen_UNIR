using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_NivelAceptacion// : ITenant
    {
        public Pry_NivelAceptacion()
        {
            this.Pry_DatosMuestras = new List<Pry_DatosMuestras>();
            this.Pry_Informes = new List<Pry_Informes>();
            this.Pry_Informes1 = new List<Pry_Informes>();
            this.Pry_Informes_Indicador = new List<Pry_Informes_Indicador>();
            this.Pry_Informes_Presupuestos = new List<Pry_Informes_Presupuestos>();
            this.Pry_Proyectos_NivelAceptacion = new List<Pry_Proyectos_NivelAceptacion>();
        }

        public int IdNivelAceptacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
        //public int IdTenant { get; set; }
        public virtual ICollection<Pry_DatosMuestras> Pry_DatosMuestras { get; set; }
        public virtual ICollection<Pry_Informes> Pry_Informes { get; set; }
        public virtual ICollection<Pry_Informes> Pry_Informes1 { get; set; }
        public virtual ICollection<Pry_Informes_Indicador> Pry_Informes_Indicador { get; set; }
        public virtual ICollection<Pry_Informes_Presupuestos> Pry_Informes_Presupuestos { get; set; }
        public virtual ICollection<Pry_Proyectos_NivelAceptacion> Pry_Proyectos_NivelAceptacion { get; set; }
    }
}
