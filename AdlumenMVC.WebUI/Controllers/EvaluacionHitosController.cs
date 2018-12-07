using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Models.Model;
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
    public class EvaluacionHitosController : ApiController
    {
        private IEvaluacionHitosRepository Context;

        public EvaluacionHitosController(IEvaluacionHitosRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Evaluación", ActionName = "Lectura")]
        // GET api/evaluacionhitos
        public Object Get(int id)
        {
            var userId = User.Identity.GetUserId();
            var user = UserUtil.GetUserById(userId);
            var data = Context.GetEvaluacionHitosObjectByPeriod(id, user.IdTenant);

            return data;
        }

        [ClaimsAuthorization(Modulo = "Evaluación", ActionName = "Escritura")]
        // POST api/evaluacionhitos
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
                        int idactividad = (int)data.idActividad;
                        int idhito = (int)data.idHito;
                        string observacioned = (string)data.observacionED;
                        string observacionurip = (string)data.observacionUrip;
                        int idusuario = (int)data.idUsuario;

                        decimal porcentajehito = data.porcentajeHito != null ? (decimal)data.porcentajeHito : 0M;
                        decimal cv = data.cv != null ? (decimal)data.cv : 0M;
                        decimal adh  = data.adh != null ? (decimal)data.adh : 0M;

                        Context.AddEvaluationHito(idproyecto, idperiodo, idresultado,
                                                  idactividad, idhito, observacioned,
                                                  observacionurip, idusuario, porcentajehito, cv, adh);
                    }
                    break;
            }
        }

        // PUT api/evaluacionhitos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/evaluacionhitos/5
        public void Delete(int id)
        {
        }

    }
}
