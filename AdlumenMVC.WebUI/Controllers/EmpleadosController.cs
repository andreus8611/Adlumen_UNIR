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
    public class EmpleadosController : ApiController
    {
        private IEmpresasRepository Context;

        public EmpleadosController(IEmpresasRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Empresa", ActionName="Lectura")]
        // GET api/empleados
        public IEnumerable<Object> Get()
        {
            return Context.GetEmpleadosActivos();
        }
    }
}
