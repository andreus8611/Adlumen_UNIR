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
    public class ListasTareasController : ApiController
    {
        private IListasTareasRepository Context;

        public ListasTareasController(IListasTareasRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Tareas", ActionName = "Lectura")]
        // GET api/listastareas
        public IEnumerable<Object> Get()
        {
            return Context.GetAll();
        }
    }
}
