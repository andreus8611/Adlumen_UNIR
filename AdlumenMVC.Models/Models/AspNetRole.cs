using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class AspNetRole
    {
        public AspNetRole()
        {
            this.Acciones = new List<Accione>();
            this.AspNetUsers = new List<AspNetUser>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Discriminator { get; set; }
        public virtual ICollection<Accione> Acciones { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
