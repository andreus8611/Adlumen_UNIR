using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Doc_Categorias : ITenant
    {
        public Doc_Categorias()
        {
            this.Doc_Clientes_Categorias = new List<Doc_Clientes_Categorias>();
            this.Doc_Documentos = new List<Doc_Documentos>();
        }

        public int IdCategoria { get; set; }
        public Nullable<int> IdPadre { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ruta { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<int> IdTipo { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<Doc_Clientes_Categorias> Doc_Clientes_Categorias { get; set; }
        public virtual ICollection<Doc_Documentos> Doc_Documentos { get; set; }
    }
}
