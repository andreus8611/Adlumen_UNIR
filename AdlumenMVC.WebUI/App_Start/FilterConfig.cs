using System.Web;
using System.Web.Mvc;

namespace AdlumenMVC.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new TenantFilter());
            //filters.Add(new TenantValidationFilter());
        }
    }
}