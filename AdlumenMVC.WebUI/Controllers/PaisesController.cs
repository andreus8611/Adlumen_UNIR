using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Models.Model;
using AdlumenMVC.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class PaisesController : ApiController
    {
        private IPaisesRepository Context;

        public PaisesController(IPaisesRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Empresa", ActionName = "Lectura")]
        // GET api/paises
        public IEnumerable<Object> Get()
        {
            return Context.GetAll();
        }

    }
}
