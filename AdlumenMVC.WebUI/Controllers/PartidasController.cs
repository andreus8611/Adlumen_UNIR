using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Bussiness.RealRepositories;
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
    public class PartidasController : ApiController
    {
        private IPryPartidasRepository Context;
        public PartidasController(IPryPartidasRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Gastos", ActionName = "VerPartidas")]
        public IEnumerable<Object> GetPatidas()
        {

            return Context.GetPartidas();
        }

        [ClaimsAuthorization(Modulo = "Gastos", ActionName = "SetPartidas")]
        public void PostPartida(JObject partida)
        {
            PRY_PARTIDAGASTOS _partidas = new PRY_PARTIDAGASTOS()
            {

                ABREVIATURA = (string)partida.SelectToken("Abrevi"),
                CODIGO = (string)partida.SelectToken("codigo"),
                NOMBRE = (string)partida.SelectToken("nombre"),

            };
            Context.addPartidas(_partidas);

        }

        [ClaimsAuthorization(Modulo = "Gastos", ActionName = "SetPartidas")]
        public void Put(PRY_PARTIDAGASTOS partida)
        {
            Context.ActualizarPartidas(partida.IDPARTIDAGASTO, partida.ABREVIATURA, partida.CODIGO, partida.NOMBRE);
        }

        [ClaimsAuthorization(Modulo = "Gastos", ActionName = "SetPartidas")]
        public void Delete(int id)
        {

            Context.Eliminar(id);
        }

    }
}
