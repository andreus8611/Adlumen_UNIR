using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Tar_Visitas : ITenant
    {
        public Tar_Visitas()
        {
            this.Tar_Bitacora = new List<Tar_Bitacora>();
            this.Tar_Permisos_Bitacora = new List<Tar_Permisos_Bitacora>();
        }

        public int IdVisita { get; set; }
        public Nullable<int> IdTarea { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string PersonaContacto { get; set; }
        public Nullable<decimal> Latitud { get; set; }
        public Nullable<decimal> Longitud { get; set; }
        public string Estado { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<Tar_Bitacora> Tar_Bitacora { get; set; }
        public virtual ICollection<Tar_Permisos_Bitacora> Tar_Permisos_Bitacora { get; set; }
        public virtual Tar_Tareas Tar_Tareas { get; set; }
    }
}
