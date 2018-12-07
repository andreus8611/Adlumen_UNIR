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
    public class ArchivosTiposController : ApiController
    {
        private IArchivosTiposRepository Context;

        public ArchivosTiposController(IArchivosTiposRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Documentos", ActionName = "Lectura")]
        // GET api/archivostipos
        public IEnumerable<Object> Get()
        {
            return Context.GetAll();
        }
    }
}
