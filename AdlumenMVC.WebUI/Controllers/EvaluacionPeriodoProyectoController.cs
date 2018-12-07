using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.WebUI.Infrastructure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AdlumenMVC.WebUI.Controllers
{
    public class EvaluacionPeriodoProyectoController : BaseApiController
    {
        private IEvaluacionProyectoPeriodoRepository Context;

        public EvaluacionPeriodoProyectoController(IEvaluacionProyectoPeriodoRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Evaluación", ActionName = "Lectura")]
        // GET api/evaluacionperiodoproyecto/5
        public Object Get(int id)
        {
            var userId = User.Identity.GetUserId();
            var user = UserUtil.GetUserById(userId);
            var data = Context.GetEvaluacionProyectoPeriodoObjectByProject(id, user.IdTenant);

            return data;
        }

        [ClaimsAuthorization(Modulo = "Evaluación", ActionName = "Escritura")]
        // POST api/evaluacionperiodoproyecto
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
                        string datosfinancieros = (string)data.datosfinancieros;
                        string observaciones = (string)data.observaciones;
                        string recomendaciones = (string)data.recomendaciones;
                        int idusuario = (int)data.idUsuario;

                        Context.AddEvaluationProyectoPeriodo(idproyecto, idperiodo, datosfinancieros,
                                                  observaciones, recomendaciones, idusuario);
                    }
                    break;
            }
        }

        // PUT api/evaluacionperiodoproyecto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/evaluacionperiodoproyecto/5
        public void Delete(int id)
        {
        }
    }
}
