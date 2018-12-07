using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdlumenMVC.WebUI.Models
{
    public class UserWithRole
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string Role { get; set; }
    }
}