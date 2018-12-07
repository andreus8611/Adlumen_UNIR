using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Bussiness.RealRepositories;
using AdlumenMVC.Models.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    [Authorize(Roles="Admin")]
    public class CapacitacionesController : ApiController
    {
        private ICapacitaciones Context;

        public CapacitacionesController(ICapacitaciones _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Object> GetCapacitaciones()
        {
            return Context.GetCapacitaciones();
        }

        public Pry_Capacitaciones GetCapacitacionById(int idCapacitacion)
        {
            return Context.GetCapacitacionById(idCapacitacion);
        }

        public void postCapacitacion(JObject capacitacion)
        {
            Pry_Capacitaciones _capacitacion = new Pry_Capacitaciones()
            {
                IdFacilitador = (int)capacitacion.SelectToken("cmbIdFacilitador"),
                NombreCapacitacion = (string)capacitacion.SelectToken("txtNombreCapacitacion"),
                DescripcionCapacitacion = (string)capacitacion.SelectToken("txtDescripcionCapacitacion"),
                FechaInicio = (DateTime)capacitacion.SelectToken("txtFechaInicio"),
                FechaFinal = (DateTime)capacitacion.SelectToken("txtFechaFinal"),
                Status = 1
            };

            Context.addCapacitacion(_capacitacion);
        }

        public void putCapacitacion(JObject capacitacion)
        {
            Pry_Capacitaciones _capacitacion = new Pry_Capacitaciones()
            {
                IdFacilitador = (int)capacitacion.SelectToken("cmbIdFacilitador"),
                NombreCapacitacion = (string)capacitacion.SelectToken("txtNombreCapacitacion"),
                DescripcionCapacitacion = (string)capacitacion.SelectToken("txtDescripcionCapacitacion"),
                FechaInicio = (DateTime)capacitacion.SelectToken("txtFechaInicio"),
                FechaFinal = (DateTime)capacitacion.SelectToken("txtFechaFinal"),
                Status = (byte)capacitacion.SelectToken("Status"),
            };

            Context.updateCapacitacion(_capacitacion);
        }

    }
}
