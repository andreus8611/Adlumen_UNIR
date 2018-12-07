using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Bussiness.RealRepositories;
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
    public class ObjetivosController : ApiController
    {
        private IObjetivos Context;

        public ObjetivosController(IObjetivos _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Lectura")]
        public IEnumerable<Object> GetObjetivos()
        {
            return null;// Context.GetObjetivos();
        }
    }
}
