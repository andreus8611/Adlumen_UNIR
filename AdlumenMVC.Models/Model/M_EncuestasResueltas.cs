//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdlumenMVC.Models.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class M_EncuestasResueltas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M_EncuestasResueltas()
        {
            this.M_PreguntasResueltas = new HashSet<M_PreguntasResueltas>();
        }
    
        public int IdEncuestaResuelta { get; set; }
        public Nullable<int> IdEncuesta { get; set; }
        public string Usuario { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Comentarios { get; set; }
        public int IdTenant { get; set; }
    
        public virtual M_Encuestas M_Encuestas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_PreguntasResueltas> M_PreguntasResueltas { get; set; }
    }
}
