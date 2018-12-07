using AdlumenMVC.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdlumenMVC.WebUI.Infraestructure
{
    [Table("AspNetRolesAcciones")]
    public class AccionesRole
    {
        [Key, Column(Order=1) ]
        public string RoleId { get; set; }
        [Key, Column(Order=2)]
        public int AccionesId { get; set; }
        [ForeignKey("AccionesId")]
        public virtual Acciones Acciones { get; set; }
        [ForeignKey("RoleId")]
        public virtual ApplicationRole Role { get; set; }
    }
}