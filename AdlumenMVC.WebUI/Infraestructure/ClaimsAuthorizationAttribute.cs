using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using AdlumenMVC.WebUI.Infraestructure.CustomTablesRepositories.Abstract;
using AdlumenMVC.WebUI.Infraestructure.CustomTablesRepositories.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AdlumenMVC.WebUI.Infrastructure
{

    public class ClaimsAuthorizationAttribute : AuthorizationFilterAttribute
    {

        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string Modulo { get; set; }
        public string ActionName { get; set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {

            var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;

            if (!principal.Identity.IsAuthenticated)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return;
            }

            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var userManager = new UserManager<ApplicationUser>(userStore);
            //var user = userManager.FindByNameAsync(principal.Identity.Name);
            var user = (new ApplicationDbContext()).Users.Include(x => x.Roles).FirstOrDefault(x => x.UserName == principal.Identity.Name);
            if (user == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            bool hasPermission = false;

            foreach(var role in user.Roles)
            {
                var module = new ModuloRepository().GetByName(Modulo);
                var action = new AccionesRepository().GetByName(ActionName, module.ModuloId);

                if (action != null && new AccionesRoleRepository().exist(module.ModuloId, action.AccionesId, role.RoleId))
                {
                    hasPermission = true;
                    break;
                }
            }

            if (!hasPermission)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                //return Task.FromResult<object>(null);
            }
            //User is Authorized, complete execution
            //return Task.FromResult<object>(null);

        }

    }
}