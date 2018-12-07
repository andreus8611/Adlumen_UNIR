using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Org_Empresas : ITenant
    {
        public Org_Empresas()
        {
            this.Org_Areas = new List<Org_Areas>();
            this.Org_Donantes = new List<Org_Donantes>();
            this.Org_Proveedores = new List<Org_Proveedores>();
            this.Pry_Objetivos = new List<Pry_Objetivos>();
            this.Sys_Usuarios = new List<Sys_Usuarios>();
        }

        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string URL { get; set; }
        public string Telefono { get; set; }
        public string Logo { get; set; }
        public int IdIdentificacionTipo { get; set; }
        public string Identificacion { get; set; }
        public int IdPais { get; set; }
        public Nullable<int> IdMenuAdministracion { get; set; }
        public Nullable<int> IdMenuSuperior { get; set; }
        public Nullable<int> IdMenuIzquierdo { get; set; }
        public Nullable<int> IdMenuPanel { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool Eliminado { get; set; }
        public Nullable<int> IdMenuSLDerecho { get; set; }
        public Nullable<int> IdMenuReportes { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> IdCategoriaDocumentos { get; set; }
        public int IdTenant { get; set; }
        public virtual Cms_Menus Cms_Menus { get; set; }
        public virtual Cms_Menus Cms_Menus1 { get; set; }
        public virtual Cms_Menus Cms_Menus2 { get; set; }
        public virtual M_Paises M_Paises { get; set; }
        public virtual ICollection<Org_Areas> Org_Areas { get; set; }
        public virtual ICollection<Org_Donantes> Org_Donantes { get; set; }
        public virtual Org_IdentificacionTipos Org_IdentificacionTipos { get; set; }
        public virtual Sys_Clientes Sys_Clientes { get; set; }
        public virtual ICollection<Org_Proveedores> Org_Proveedores { get; set; }
        public virtual ICollection<Pry_Objetivos> Pry_Objetivos { get; set; }
        public virtual ICollection<Sys_Usuarios> Sys_Usuarios { get; set; }
    }
}
