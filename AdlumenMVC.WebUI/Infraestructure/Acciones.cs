using AdlumenMVC.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AdlumenMVC.WebUI.Infraestructure
{
    public class Acciones
    {
        public Acciones() { }

        public int AccionesId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int ModuloId { get; set; }
        [ForeignKey("ModuloId")]
        public virtual Modulo Modulo { get; set; }
        public virtual ICollection<AccionesRole> AccionesRoles { get; set; }
    }
}
