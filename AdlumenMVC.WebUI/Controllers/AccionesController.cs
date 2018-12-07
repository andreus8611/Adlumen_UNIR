using AdlumenMVC.WebUI.Infraestructure;
using AdlumenMVC.WebUI.Infraestructure.CustomTablesRepositories.Abstract;
using AdlumenMVC.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class AccionesController : BaseApiController
    {
        private IAcciones Context;

        public AccionesController(IAcciones _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo="Roles", ActionName="GetAcciones")]
        public IEnumerable<Acciones> GetAll()
        {
            return Context.GetAll();
        }

        [ClaimsAuthorization(Modulo = "Roles", ActionName = "GetAcciones")]
        public Acciones GetById(int id)
        {
            return Context.GetById(id);
        }
    }
}
