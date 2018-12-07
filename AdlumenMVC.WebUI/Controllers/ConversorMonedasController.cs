using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Models.Model;
using AdlumenMVC.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class ConversorMonedasController : ApiController
    {
        private IConversorMonedasRepository Context;

        public ConversorMonedasController(IConversorMonedasRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo="Gastos", ActionName="VerTipoCambio")]
        // GET api/conversormonedas/5
        public m_TipCambio Get(int id)
        {
            return Context.GetTipoCambio(id);
        }

    }
}
