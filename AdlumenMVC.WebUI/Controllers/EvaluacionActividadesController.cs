using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.WebUI.Infrastructure;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class EvaluacionActividadesController : ApiController
    {
        private IEvaluacionProyectoActividadRepository Context;

        public EvaluacionActividadesController(IEvaluacionProyectoActividadRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Evaluación", ActionName = "Lectura")]
        // GET api/evaluacionactividades/5
        public Object Get(int id)
        {
            var userId = User.Identity.GetUserId();
            var user = UserUtil.GetUserById(userId);
            var data = Context.GetEvaluacionActividadObjectByProject(id, user.IdTenant);

            return data;
        }

        [ClaimsAuthorization(Modulo = "Evaluación", ActionName = "Escritura")]
        // POST api/evaluacionactividades
        public void Post(JObject value)
        {
            dynamic data = value;
            string action = (string)data.action;
            switch (action)
            {
                case "modify":
                    {
                        int idproyecto = (int)data.idProyecto;
                        int idperiodo = (int)data.idPeriodo;
                        int idobjetivo = (int)data.idObjetivo;
                        string observaciones = (string)data.observaciones;
                        int idusuario = (int)data.idUsuario;

                        Context.AddEvaluationActividades(idproyecto, idperiodo, idobjetivo,
                                                  observaciones, idusuario);
                    }
                    break;
            }
        }

        // PUT api/evaluacionactividades/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/evaluacionactividades/5
        public void Delete(int id)
        {
        }
    }
}
