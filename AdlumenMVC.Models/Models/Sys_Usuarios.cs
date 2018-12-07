using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Sys_Usuarios : ITenant
    {
        public Sys_Usuarios()
        {
            this.Com_Mensajes = new List<Com_Mensajes>();
            this.Org_Empleados = new List<Org_Empleados>();
            this.Pry_Proyectos = new List<Pry_Proyectos>();
            this.Pry_Proyectos1 = new List<Pry_Proyectos>();
            this.Pry_Proyectos2 = new List<Pry_Proyectos>();
            this.Pry_Proyectos_Donantes = new List<Pry_Proyectos_Donantes>();
            this.Org_Donantes = new List<Org_Donantes>();
            this.Org_Empresas = new List<Org_Empresas>();
            this.Tar_Bitacora = new List<Tar_Bitacora>();
            this.Tar_Listas = new List<Tar_Listas>();
            this.Tar_Listas1 = new List<Tar_Listas>();
            this.Tar_Permisos_Bitacora = new List<Tar_Permisos_Bitacora>();
            this.Tar_Tareas = new List<Tar_Tareas>();
            this.Tar_Tareas1 = new List<Tar_Tareas>();
            this.Tar_Tareas2 = new List<Tar_Tareas>();
            this.Tar_Tareas3 = new List<Tar_Tareas>();
        }

        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string UserReport { get; set; }
        public int idEmpresa { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<Com_Mensajes> Com_Mensajes { get; set; }
        public virtual ICollection<Org_Empleados> Org_Empleados { get; set; }
        public virtual ICollection<Pry_Proyectos> Pry_Proyectos { get; set; }
        public virtual ICollection<Pry_Proyectos> Pry_Proyectos1 { get; set; }
        public virtual ICollection<Pry_Proyectos> Pry_Proyectos2 { get; set; }
        public virtual ICollection<Pry_Proyectos_Donantes> Pry_Proyectos_Donantes { get; set; }
        public virtual ICollection<Org_Donantes> Org_Donantes { get; set; }
        public virtual ICollection<Org_Empresas> Org_Empresas { get; set; }
        public virtual ICollection<Tar_Bitacora> Tar_Bitacora { get; set; }
        public virtual ICollection<Tar_Listas> Tar_Listas { get; set; }
        public virtual ICollection<Tar_Listas> Tar_Listas1 { get; set; }
        public virtual ICollection<Tar_Permisos_Bitacora> Tar_Permisos_Bitacora { get; set; }
        public virtual ICollection<Tar_Tareas> Tar_Tareas { get; set; }
        public virtual ICollection<Tar_Tareas> Tar_Tareas1 { get; set; }
        public virtual ICollection<Tar_Tareas> Tar_Tareas2 { get; set; }
        public virtual ICollection<Tar_Tareas> Tar_Tareas3 { get; set; }
    }
}
