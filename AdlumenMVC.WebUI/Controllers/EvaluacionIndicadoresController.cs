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
    public class EvaluacionIndicadoresController : ApiController
    {
        private IEvaluacionIndicadoresRepository Context;

        public EvaluacionIndicadoresController(IEvaluacionIndicadoresRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Evaluación", ActionName = "Lectura")]
        // GET api/evaluacionindicadores/5
        public Object Get(int id)
        {
            var userId = User.Identity.GetUserId();
            var user = UserUtil.GetUserById(userId);
            var data = Context.GetEvaluacionIndicadoresObjectByPeriod(id, user.IdTenant);

            return data;
        }

        [ClaimsAuthorization(Modulo = "Evaluación", ActionName = "Escritura")]
        // POST api/evaluacionindicadores
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
                        int idresultado = (int)data.idResultado;
                        int idhito = (int)data.idHito;
                        string observacioned = (string)data.observacionED;
                        string observacionurip = (string)data.observacionUrip;
                        int idusuario = (int)data.idUsuario;

                        decimal porcentajehito = data.porcentajeHito != null ? (decimal)data.porcentajeHito : 0M;
                        decimal cv = data.cv != null ? (decimal)data.cv : 0M;
                        decimal adh = data.adh != null ? (decimal)data.adh : 0M;

                        Context.AddEvaluationIndicador(idproyecto, idperiodo, idresultado,
                                                  idhito, observacioned,
                                                  observacionurip, idusuario, porcentajehito, cv, adh);
                    }
                    break;
            }
        }

        // PUT api/evaluacionindicadores/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/evaluacionindicadores/5
        public void Delete(int id)
        {
        }
    }
}
