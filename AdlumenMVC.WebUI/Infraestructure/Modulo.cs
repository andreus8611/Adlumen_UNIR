using AdlumenMVC.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AdlumenMVC.WebUI.Infraestructure
{
    public class Modulo
    {
        public Modulo() { }

        public int ModuloId { get; set; }

        public string Nombre { get; set; }

    }
}
