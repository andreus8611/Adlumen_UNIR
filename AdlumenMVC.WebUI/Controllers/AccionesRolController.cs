using AdlumenMVC.WebUI.Infraestructure;
using AdlumenMVC.WebUI.Infraestructure.CustomTablesRepositories.Abstract;
using AdlumenMVC.WebUI.Infrastructure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class AccionesRolController : BaseApiController
    {
        private IAccionesRoles Context;

        public AccionesRolController(IAccionesRoles _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Roles", ActionName = "GetAcciones")]
        public IEnumerable<AccionesRole> Get()
        {
            return Context.GetAll();
        }
        [ClaimsAuthorization(Modulo = "Roles", ActionName = "GetAcciones")]
        public IEnumerable<AccionesRole> Get(string idRole)
        {
            return Context.GetByRole(idRole);
        }

        [ClaimsAuthorization(Modulo = "Roles", ActionName = "GetAcciones")]
        public IHttpActionResult Post(JObject _data)
        {
            dynamic data = _data;

            List<AccionesRole> AccionesRol = new List<AccionesRole>();

            foreach(var module in data.permissions) {

                foreach (var action in module.actions)
                {
                    if (action.idAccion != 0 && (bool)action.permission == true)
                    {
                        AccionesRol.Add(new AccionesRole() { 
                            RoleId = (string)data.role,
                            AccionesId = (int)action.idAccion
                        });
                    }
                }
            }

            Context.assignPermission(AccionesRol);

            return Ok();

        }
    }
}
