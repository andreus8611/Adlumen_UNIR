using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Models.Model;
using AdlumenMVC.WebUI.Infrastructure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{

   
    public class MonedasController : ApiController
    {

        private IMonedaRepository Context;

        public MonedasController(IMonedaRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Gastos", ActionName = "VerMoneda")]
        // GET api/monedas
        public IEnumerable<Object> Get()
        {
            return Context.GetAll();
        }

        [ClaimsAuthorization(Modulo = "Gastos", ActionName = "VerMoneda")]
        // GET api/monedas/5
        public M_Monedas Get(int id)
        {
            return Context.getModedaById(id);
        }

        [ClaimsAuthorization(Modulo = "Gastos", ActionName = "SetMoneda")]
        // POST api/monedas
        public void Post(M_Monedas moneda)
        {
            //M_Monedas moneda = new M_Monedas()
            //{
            //    Nombre = (string)value.SelectToken("inputNombre"),
            //    Representacion = (string)value.SelectToken("inputRepresentacion")
            //};

            Context.addMoneda(moneda);

        }

        [ClaimsAuthorization(Modulo = "Gastos", ActionName = "SetMoneda")]
        public void Put(M_Monedas moneda)
        {
            try
            {
                Context.Update(moneda);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [ClaimsAuthorization(Modulo = "Gastos", ActionName = "SetMoneda")]
        public void Delete(int id)
        {
            try
            {
                var moneda = Context.getModedaById(id);
                Context.Delete(moneda);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
