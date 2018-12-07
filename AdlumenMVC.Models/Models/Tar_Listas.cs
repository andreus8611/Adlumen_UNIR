using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Tar_Listas : ITenant
    {
        public Tar_Listas()
        {
            this.Tar_Tareas = new List<Tar_Tareas>();
        }

        public int Id { get; set; }
        public Nullable<int> IdProyecto { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdPadre { get; set; }
        public int IdTenant { get; set; }
        public virtual Pry_Proyectos Pry_Proyectos { get; set; }
        public virtual Sys_Usuarios Sys_Usuarios { get; set; }
        public virtual Sys_Usuarios Sys_Usuarios1 { get; set; }
        public virtual ICollection<Tar_Tareas> Tar_Tareas { get; set; }
    }
}
