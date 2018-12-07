using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Doc_ArchivosTipos// : ITenant
    {
        public Doc_ArchivosTipos()
        {
            this.Doc_Documentos = new List<Doc_Documentos>();
        }

        public int IdTipoArchivo { get; set; }
        public string Nombre { get; set; }
        public string Mime_Type { get; set; }
        //public int IdTenant { get; set; }
        public virtual ICollection<Doc_Documentos> Doc_Documentos { get; set; }
    }
}
