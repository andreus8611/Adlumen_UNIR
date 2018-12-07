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
    public class UsuariosController : ApiController
    {
        private IUsuariosRepository Context;

        public UsuariosController(IUsuariosRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Usuarios", ActionName = "Lectura")]
        // GET api/usuarios
        public IEnumerable<Object> Get()
        {
            return Context.GetAllUser();
        }
    }

}
