using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Sys_Clientes : ITenant
    {
        public Sys_Clientes()
        {
            this.Doc_Clientes_Categorias = new List<Doc_Clientes_Categorias>();
            this.Org_Donantes = new List<Org_Donantes>();
            this.Org_Empresas = new List<Org_Empresas>();
            this.Pry_Proyectos = new List<Pry_Proyectos>();
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
        public virtual ICollection<Doc_Clientes_Categorias> Doc_Clientes_Categorias { get; set; }
        public virtual ICollection<Org_Donantes> Org_Donantes { get; set; }
        public virtual ICollection<Org_Empresas> Org_Empresas { get; set; }
        public virtual ICollection<Pry_Proyectos> Pry_Proyectos { get; set; }
    }
}
