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
    public class PartidasGastosController : ApiController
    {
        private IPartidasGastosRepository Context;

        public PartidasGastosController(IPartidasGastosRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Gastos", ActionName = "VerPartidas")]
        // GET api/partidasgastos
        public IEnumerable<Object> Get()
        {
            return Context.GetAllPartidasGastos();
        }

    }
}
