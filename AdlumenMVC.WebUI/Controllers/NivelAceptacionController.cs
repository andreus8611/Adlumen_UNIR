using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class NivelAceptacionController : ApiController
    {

        private INivelAceptacionRepository Context;

        public NivelAceptacionController(INivelAceptacionRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Lectura")]
        // GET: api/NivelAceptacion
        public IEnumerable<Object> Get()
        {
            return Context.getAll();
        }

    }
}
