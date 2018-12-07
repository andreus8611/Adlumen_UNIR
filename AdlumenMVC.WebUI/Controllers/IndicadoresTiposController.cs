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
    public class IndicadoresTiposController : ApiController
    {
        private IIndicadoresTiposRepository Context;

        public IndicadoresTiposController(IIndicadoresTiposRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Indicadores", ActionName="Lectura")]
        // GET api/indicadorestipos
        public List<Pry_IndicadoresTipos> Get()
        {
            return Context.GetAll();
        }

    }
}
