using AdlumenMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace AdlumenMVC.WebUI
{
    public class TenantValidationFilter : IAuthenticationFilter
    {
        public bool AllowMultiple => true;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var url = context.Request.RequestUri;
            var tenant = TenantUtil.GetTenantFromUrl(url);

            if (tenant == null)
            {
                context.ErrorResult = new RedirectResult(new Uri("http://www.adlumen.org/"), context.Request);
            }
            else
            {
                //context.HttpContext.Session["Tenant"] = tenant;
            }
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {

        }
    }
}