using AdlumenMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdlumenMVC.WebUI
{
    public class TenantFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var url = filterContext.HttpContext.Request.Url;
            var tenant = TenantUtil.GetTenantFromUrl(url);

            if (tenant == null)
            {
                filterContext.Result = new RedirectResult("http://www.adlumen.org");
            }
            else
            {
                //HttpContext.Current.Session["Tenant"] = tenant;
            }
        }
    }
}