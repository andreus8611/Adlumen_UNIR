using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Models.Model;
using AdlumenMVC.WebUI.Infrastructure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class ImportarBitacoraController : ApiController
    {
        private IBitacoraRepository Context;

        public ImportarBitacoraController(IBitacoraRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Tareas", ActionName = "RegistrarBitacora")]
        // POST api/importarbitacora
        public void Post(JObject value)
        {
            dynamic data = value;
            JArray logs = (JArray)data.logsArray;

            foreach (JObject oLog in logs)
            {
                dynamic dataLog = oLog;
                Tar_Bitacora bitacora = new Tar_Bitacora()
                {
                    IdVisita = dataLog.idVisita,
                    //IdUsuario = dataLog.usuario //Pendiente
                    FechaRegistro = DateTime.Parse(dataLog.formatedDateTime.ToString(), CultureInfo.InvariantCulture),
                    Comentario = dataLog.comentario
                };

                Context.addBitacora(bitacora);
            }
        }

        [Authorize(Roles="SuperAdmin")]
        // PUT api/importarbitacora/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [Authorize(Roles = "SuperAdmin")]
        // DELETE api/importarbitacora/5
        public void Delete(int id)
        {
        }
    }
}
