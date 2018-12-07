using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Cms_MenuNodos : ITenant
    {
        public int IdNodo { get; set; }
        public int IdMenu { get; set; }
        public int IdPadre { get; set; }
        public Nullable<int> Posicion { get; set; }
        public string Destino { get; set; }
        public string Url { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string IconoUrl { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Roles { get; set; }
        public string RutaXml { get; set; }
        public int IdTenant { get; set; }
        public virtual Cms_Menus Cms_Menus { get; set; }
    }
}
