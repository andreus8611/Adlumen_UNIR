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
    public class ObjetivosClasesController : ApiController
    {
        private IObjetivosClasesRepository Context;

        public ObjetivosClasesController(IObjetivosClasesRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Lectura")]
         //GET api/objetivosclases
        public List<Object> Get()
        {
            return Context.GetAll();
        }

    }
}
