using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Models.Model;
using AdlumenMVC.WebUI.Infrastructure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class IndicadoresController : ApiController
    {
        private IIndicadoresProyectoRepository Context;

        public IndicadoresController(IIndicadoresProyectoRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo="Indicadores", ActionName="Lectura")]
        // GET api/indicadores/5
        public Object Get(int id)
        {
            return Context.GetIndicatorsDetail(id);
        }

    }
}
