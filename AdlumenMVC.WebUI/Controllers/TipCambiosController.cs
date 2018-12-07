using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Models.Model;
using AdlumenMVC.WebUI.Infrastructure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class TipCambiosController : ApiController
    {

        private ITipCambioRepository Context;

        public TipCambiosController(ITipCambioRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Tipos de Cambio", ActionName = "Lectura")]
         //GET api/tipcambios
        public IEnumerable<Object> GetAllExchanges()
        {
            return Context.GetAll();
        }

        [ClaimsAuthorization(Modulo = "Tipos de Cambio", ActionName = "Lectura")]
         //GET api/tipcambios/5
        public Object GetByDate(DateTime fecha, int idMoneda)
        {
            return Context.GetTipCamioByFechaMoneda(fecha, idMoneda); 
        }

        [ClaimsAuthorization(Modulo = "Tipos de Cambio", ActionName = "Escritura")]
         //POST api/tipcambios
        public void Post(JObject tc)
        {

            try
            {
                List<m_TipCambio> exchangeRates = new List<m_TipCambio>();

                var tipCambio = (JArray)tc.SelectToken("exchangeRates");

                tipCambio.RemoveAt(0);

                foreach (var exchange in tipCambio)
                {

                    exchangeRates.Add(new m_TipCambio
                    {
                        idMoneda = (int)exchange[0],
                        FecTipCambio = DateTime.Parse((string)exchange[1]),
                        ValCompra = (decimal)exchange[2],
                        ValVenta = (decimal)exchange[3]
                    });
                }

                Context.addTipCambio(exchangeRates);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
