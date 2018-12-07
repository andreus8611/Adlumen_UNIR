using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Documentos_Tareas : ITenant
    {
        public int IdDocumento { get; set; }
        public int IdTarea { get; set; }
        public int IdTenant { get; set; }
        public virtual Doc_Documentos Doc_Documentos { get; set; }
        public virtual Doc_Documentos Doc_Documentos1 { get; set; }
        public virtual Tar_Tareas Tar_Tareas { get; set; }
        public virtual Tar_Tareas Tar_Tareas1 { get; set; }
    }
}
