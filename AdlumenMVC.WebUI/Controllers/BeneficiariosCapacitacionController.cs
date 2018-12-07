using AdlumenMVC.Bussiness.AbstractRepositories;
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
    public class BeneficiariosCapacitacionController : ApiController
    {
        private ICapacitacionBeneficiario Context;

        public BeneficiariosCapacitacionController(ICapacitacionBeneficiario _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Object> getBeneficiariosCapacitacion()
        {
            return Context.GetBeneficiariosCapacitaciones();
        }

        public Pry_CapacitacionBeneficiario GetBeneficiarioCapacitacionById(int idCapacitacionBeneficiario)
        {
            return Context.GetBeneficiarioCapacitacionById(idCapacitacionBeneficiario);
        }

        public void addBeneficiariosCapacitacion(JObject beneficiariosCapacitacion)
        {
            Pry_CapacitacionBeneficiario _beneficiarioCapacitacion = new Pry_CapacitacionBeneficiario()
            {
                IdCapacitacion = (int)beneficiariosCapacitacion.SelectToken("cmbIdCapacitacion"),
                IdBeneficiario = (int)beneficiariosCapacitacion.SelectToken("cmbIdBeneficiario"),
                FechaInscripcion = System.DateTime.Now,
                Status = 1
            };

            Context.addBeneficiarioCapacitacion(_beneficiarioCapacitacion);
        }

    }
}
