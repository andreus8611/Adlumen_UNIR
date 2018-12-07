using AdlumenMVC.WebUI.Infraestructure;
using AdlumenMVC.WebUI.Infraestructure.CustomTablesRepositories.Abstract;
using AdlumenMVC.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class ModulosController : BaseApiController
    {

        private IModules Context;

        public ModulosController(IModules _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Roles", ActionName = "GetModulos")]
        public IEnumerable<Modulo> Get()
        {
            var modules = Context.GetAll();

            return modules;
        }

        [ClaimsAuthorization(Modulo = "Roles", ActionName = "GetModulos")]
        public Modulo Get(int id)
        {
            var module = Context.Get(id);

            return module;
        }
    }
}
