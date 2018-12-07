using AdlumenMVC.Bussiness.AbstractRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdlumenMVC.WebUI.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Base()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
    }
}
