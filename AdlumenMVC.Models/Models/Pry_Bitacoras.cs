using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Pry_Bitacoras : ITenant
    {
        public int IdBitacora { get; set; }
        public Nullable<int> IdProyecto { get; set; }
        public string Titulo { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public int IdTenant { get; set; }
        public virtual Pry_Proyectos Pry_Proyectos { get; set; }
    }
}
