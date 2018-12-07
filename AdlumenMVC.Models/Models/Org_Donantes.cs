using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Org_Donantes : ITenant
    {
        public Org_Donantes()
        {
            this.Org_Empresas = new List<Org_Empresas>();
            this.Pry_Proyectos_Donantes = new List<Pry_Proyectos_Donantes>();
            this.Pry_CalendarioDonaciones = new List<Pry_CalendarioDonaciones>();
            this.Pry_Informes_Donantes = new List<Pry_Informes_Donantes>();
            this.Sys_Usuarios = new List<Sys_Usuarios>();
        }

        public int IdDonante { get; set; }
        public string Nombre { get; set; }
        public int IdIdentificacionTipo { get; set; }
        public string Identificacion { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Ubicacion { get; set; }
        public string Correo { get; set; }
        public string URL { get; set; }
        public string HojaVida { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool Eliminado { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> IdPrograma { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<Org_Empresas> Org_Empresas { get; set; }
        public virtual Org_IdentificacionTipos Org_IdentificacionTipos { get; set; }
        public virtual Sys_Clientes Sys_Clientes { get; set; }
        public virtual ICollection<Pry_Proyectos_Donantes> Pry_Proyectos_Donantes { get; set; }
        public virtual ICollection<Pry_CalendarioDonaciones> Pry_CalendarioDonaciones { get; set; }
        public virtual ICollection<Pry_Informes_Donantes> Pry_Informes_Donantes { get; set; }
        public virtual ICollection<Sys_Usuarios> Sys_Usuarios { get; set; }
    }
}
