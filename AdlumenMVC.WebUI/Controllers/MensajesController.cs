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
    public class MensajesController : ApiController
    {

        private IMensajesRepository Context;

        public MensajesController(IMensajesRepository _Context)
        {
            Context = _Context;

        }

        [ClaimsAuthorization(Modulo = "Mensajes", ActionName = "Lectura")]
        //cambiar el usuario
        public IEnumerable<Object> GetMensajes()
        {

            return Context.GetMensajes();
        }

        [ClaimsAuthorization(Modulo = "Mensajes", ActionName = "Escritura")]
        public void PostMensaje(JObject mensaje)
        {
       
            if (Convert.ToInt16(  mensaje.Property("idEstado").Value) == 1)
            {
                Com_Mensajes _mensajes = new Com_Mensajes()
                {

                    IdUsuarioRemitente = (int)mensaje.SelectToken("idUsuarioRemitente"),
                    IdUsuarioDestinatario = (int)mensaje.SelectToken("idUsuarioDestinatario"),
                    IdEstado = 1,
                    Asunto = (string)mensaje.SelectToken("asunto"),
                    Mensaje = (string)mensaje.SelectToken("mensaje"),
                    Prioridad = (bool)mensaje.SelectToken("prioridad"),
                    FechaEnvio = DateTime.Now,

                };
                Context.addMensaje(_mensajes);
            }
            else
                 if (Convert.ToInt16(mensaje.Property("idEstado").Value) == 4)
            {
                Com_Mensajes _mensajes = new Com_Mensajes()
                {

                    IdUsuarioRemitente = (int)mensaje.SelectToken("idUsuarioRemitente"),
                    IdUsuarioDestinatario = (int)mensaje.SelectToken("idUsuarioDestinatario"),
                    IdEstado = 4,
                    Asunto = (string)mensaje.SelectToken("asunto"),
                    Mensaje = (string)mensaje.SelectToken("mensaje"),
                    Prioridad = (bool)mensaje.SelectToken("prioridad"),
                    FechaEnvio = DateTime.Now,

                };
                Context.addMensaje(_mensajes);
            }
           

        }

       

        [ClaimsAuthorization(Modulo = "Mensajes", ActionName="Escritura")]

        public void PutCambiar(int idMensaje,int estado)
        {

            Context.ActualizarEstado(idMensaje,estado);
        }


        // GET api/mensajes



        //public   IEnumerable<Object> GetAll(int usuarioRemitente, int estado)
        //{

        //    return Context.GetAll(usuarioRemitente, estado);

        //}
      

        // GET api/mensajes/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/mensajes
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/mensajes/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/mensajes/5
        //public void Delete(int id)
        //{
        //}
    }
}
