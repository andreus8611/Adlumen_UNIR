using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Bussiness.RealRepositories;
using AdlumenMVC.Models.Model;
using AdlumenMVC.WebUI.Infrastructure;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
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

        [ClaimsAuthorization(Modulo = "Mensajes", ActionName = "Escritura")]
        [HttpPost]
        [Route("api/Mensajes/AddMensaje")]
        public void AddMensaje()
        {
            var request = HttpContext.Current.Request;

            try
            {
                var msg = new Com_Mensajes()
                {
                    IdUsuarioRemitente = int.Parse(request["idUsuarioRemitente"]),
                    IdUsuarioDestinatario = int.Parse(request["idUsuarioDestinatario"]),
                    IdEstado = 1,
                    Asunto = request["asunto"],
                    Mensaje = request.Unvalidated.Form["mensaje"],
                    Prioridad = bool.Parse(request["prioridad"]),
                    FechaEnvio = DateTime.Now,
                };
                Context.addMensaje(msg);

                if (request.Files.Count > 0)
                {
                    //var id = Encoding.UTF8.GetBytes(msg.IdMensaje.ToString());
                    //var name = Convert.ToBase64String(id);

                    var postedFile = request.Files[0];
                    //var fileName = msg.IdMensaje.ToString() + (new FileInfo(postedFile.FileName)).Extension;
                    var path = Path.Combine("~/app/userfiles", msg.IdTenant.ToString(), "attachments", msg.IdUsuarioDestinatario.ToString(), msg.IdMensaje.ToString(), postedFile.FileName);
                    var filePath = HttpContext.Current.Server.MapPath(path);

                    var directory = (new FileInfo(filePath)).DirectoryName;
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    postedFile.SaveAs(filePath);
                }
            }
            catch (Exception ex)
            {
                throw;
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

        [ClaimsAuthorization(Modulo = "Mensajes", ActionName = "Lectura")]
        [Route("api/mensajes/GetAttachmentUrl")]
        [HttpGet]
        public IHttpActionResult GetAttachmentUrl(int idMessage)
        {
            var msg = Context.GetMessage(idMessage);
            if (msg != null)
            {
                var appPath = String.Concat("app/userfiles/", msg.IdTenant.ToString(), "/attachments/", msg.IdUsuarioDestinatario.ToString(), "/", msg.IdMensaje.ToString(), "/");
                var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, appPath);
                if (Directory.Exists(fullPath))
                {
                    var files = Directory.EnumerateFiles(fullPath).ToList();
                    if (files.Count > 0)
                    {
                        return Json(new
                        {
                            name = Path.GetFileName(files[0]),
                            key = User.Identity.GetUserId()
                        }); 
                    }
                }
            }
            return null;
        }

        //[ClaimsAuthorization(Modulo = "Mensajes", ActionName = "Lectura")]
        [Route("api/mensajes/DownloadAttachment/{id}/{key}")]
        [HttpGet]
        public HttpResponseMessage DownloadAttachment(int id, string key)
        {
            var msg = Context.GetMessage(id);
            if (msg != null)
            {
                var user = UserUtil.GetUserById(key);
                if (user.IdLocal != msg.IdUsuarioDestinatario)
                {
                    return new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }

                var appPath = string.Concat("app/userfiles/", msg.IdTenant.ToString(), "/attachments/", msg.IdUsuarioDestinatario.ToString(), "/", msg.IdMensaje.ToString(), "/");
                var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, appPath);
                if (Directory.Exists(fullPath))
                {
                    var files = Directory.EnumerateFiles(fullPath).ToList();
                    if (files.Count > 0)
                    {
                        var result = new HttpResponseMessage(HttpStatusCode.OK);
                        var stream = new FileStream(files[0], FileMode.Open, FileAccess.Read);
                        result.Content = new StreamContent(stream);
                        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        {
                            FileName = Path.GetFileName(files[0])
                        };
                        return result;
                    }
                }
            }
            return null;
        }
    }
}
