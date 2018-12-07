using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class PRY_INFORMESICADOCUMENTOS : ITenant
    {
        public System.Guid IDDOCUMENTO { get; set; }
        public int IDINFORME { get; set; }
        public string DESCRIPCION { get; set; }
        public string URL { get; set; }
        public string NOMBRE { get; set; }
        public int TIPO { get; set; }
        public int IdTenant { get; set; }
        public virtual PRY_INFORMESICA PRY_INFORMESICA { get; set; }
    }
}
