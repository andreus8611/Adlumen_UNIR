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
    public class IndicadoresProyectoController : ApiController
    {
        private IIndicadoresProyectoRepository Context;

        public IndicadoresProyectoController(IIndicadoresProyectoRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo="Proyectos", ActionName="Lectura")]
        // GET api/indicadoresproyecto/5
        public Object Get(int id)
        {
            return Context.GetProjectObjectives(id);
        }

    }
}
