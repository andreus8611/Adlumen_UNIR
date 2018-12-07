using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Doc_Documentos : ITenant
    {
        public Doc_Documentos()
        {
            this.Documentos_Tareas = new List<Documentos_Tareas>();
            this.Documentos_Tareas1 = new List<Documentos_Tareas>();
        }

        public int IdDocumento { get; set; }
        public int IdCategoria { get; set; }
        public int IdTipoArchivo { get; set; }
        public string Titulo { get; set; }
        public string PalabrasClaves { get; set; }
        public string Resumen { get; set; }
        public string Url { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string Roles { get; set; }
        public int IdTenant { get; set; }
        public virtual Doc_ArchivosTipos Doc_ArchivosTipos { get; set; }
        public virtual Doc_Categorias Doc_Categorias { get; set; }
        public virtual ICollection<Documentos_Tareas> Documentos_Tareas { get; set; }
        public virtual ICollection<Documentos_Tareas> Documentos_Tareas1 { get; set; }
    }
}
