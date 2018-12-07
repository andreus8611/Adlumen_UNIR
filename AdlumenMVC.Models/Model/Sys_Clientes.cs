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
    
    public partial class Sys_Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sys_Clientes()
        {
            this.Org_Donantes = new HashSet<Org_Donantes>();
            this.Org_Empresas = new HashSet<Org_Empresas>();
            this.Pry_Proyectos = new HashSet<Pry_Proyectos>();
            this.Doc_Categorias = new HashSet<Doc_Categorias>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxUsers { get; set; }
        public int MaxProjects { get; set; }
        public int MaxStorage { get; set; }
        public System.DateTime OrderDate { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public string Logo { get; set; }
        public bool Status { get; set; }
        public string ContactName { get; set; }
        public string ContactMail { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPhone { get; set; }
        public int IdTenant { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Org_Donantes> Org_Donantes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Org_Empresas> Org_Empresas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pry_Proyectos> Pry_Proyectos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Doc_Categorias> Doc_Categorias { get; set; }
    }
}
