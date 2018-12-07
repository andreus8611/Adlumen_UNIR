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
    public class IndicadoresVerificadoresController : ApiController
    {
        private IIndicadoresProyectoRepository Context;

        public IndicadoresVerificadoresController(IIndicadoresProyectoRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo="Indicadores", ActionName="Lectura")]
        // GET api/indicadoresverificadores/5
        public Object Get(int id)
        {
            return Context.GetVerificadoresIndicador(id);
        }
    }
}
