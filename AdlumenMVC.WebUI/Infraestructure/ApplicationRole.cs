using AdlumenMVC.WebUI.Infraestructure;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdlumenMVC.WebUI.Infrastructure
{
    public class ApplicationRole: IdentityRole
    {
        public ApplicationRole() : base() { }

        public virtual ICollection<AccionesRole> AccionesRoles { get; set; }

    }

}