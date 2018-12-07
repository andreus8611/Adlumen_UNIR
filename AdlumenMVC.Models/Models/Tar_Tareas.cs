using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Tar_Tareas : ITenant
    {
        public Tar_Tareas()
        {
            this.Documentos_Tareas = new List<Documentos_Tareas>();
            this.Documentos_Tareas1 = new List<Documentos_Tareas>();
            this.Tar_Visitas = new List<Tar_Visitas>();
        }

        public int Id { get; set; }
        public Nullable<int> IdLista { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<int> IdResponsable { get; set; }
        public Nullable<int> IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<bool> Prioridad { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<System.DateTime> FechaCompletado { get; set; }
        public Nullable<int> IdUsuarioCompletado { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<Documentos_Tareas> Documentos_Tareas { get; set; }
        public virtual ICollection<Documentos_Tareas> Documentos_Tareas1 { get; set; }
        public virtual Sys_Usuarios Sys_Usuarios { get; set; }
        public virtual Sys_Usuarios Sys_Usuarios1 { get; set; }
        public virtual Sys_Usuarios Sys_Usuarios2 { get; set; }
        public virtual Sys_Usuarios Sys_Usuarios3 { get; set; }
        public virtual Tar_Listas Tar_Listas { get; set; }
        public virtual ICollection<Tar_Visitas> Tar_Visitas { get; set; }
    }
}
