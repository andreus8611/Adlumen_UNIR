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
    public class BitacoraController : ApiController
    {
        private IBitacoraRepository Context;

        public BitacoraController(IBitacoraRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo="Tareas", ActionName="Lectura")]
        // GET api/bitacora
        public IEnumerable<Object> Get()
        {
            return Context.GetAll();
        }


        [ClaimsAuthorization(Modulo = "Tareas", ActionName = "RegistrarBitacora")]
        //[Authorize(Roles = "Admin, manager, typesetter, SuperAdmin, Gerente")]
        // POST api/bitacora
        public void Post(JObject value)
        {
            dynamic data = value;
            string action = (string)data.action;
            switch (action)
            {
                case "addmodify":
                    {
                        if (data.idBitacora == 0) //Nueva Pregunta
                        {
                            Tar_Bitacora bitacora = new Tar_Bitacora()
                            {
                                IdVisita = data.idVisita,
                                //IdUsuario = data.usuario //Pendiente
                                FechaRegistro = DateTime.Parse(data.formatedDateTime.ToString(), CultureInfo.InvariantCulture),
                                Comentario = data.comentario,
                                IdUsuario = data.idUsuario
                            };

                            Context.addBitacora(bitacora);
                        }
                    }
                    break;
            };
        }

        // PUT api/bitacora/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/bitacora/5
        public void Delete(int id)
        {
        }
    }
}
