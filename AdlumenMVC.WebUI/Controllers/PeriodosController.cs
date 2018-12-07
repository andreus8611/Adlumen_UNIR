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
    public class PeriodosController : ApiController
    {

        private IPeriodosProyectos Context;

        public PeriodosController(IPeriodosProyectos _Context)
        {
            Context = _Context;
        }

        //GET api/periodos
        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Lectura")]
        public IEnumerable<Object> GetAllPeriods()
        {
            return Context.GetAll();
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Lectura")]
         //GET api/periodos/id
        public IEnumerable<PRY_PERIODOSPROYECTOS> GetPeriodosByProject(int id)
        {
            return Context.GetAllPeriodsByProject(id);
        }


        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Lectura")]
        // api/periodos/?idProyecto=value&idPeriodo=value
        public PRY_PERIODOSPROYECTOS GetPeriodByIds(int idProyecto, int idPeriodo)
        {
            return Context.GetPeriodById(idProyecto,idPeriodo);

        }

        // POST api/periodos
        //public void Post()
        //{
        //}

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Escritura")]
        // PUT api/periodos/5
        public void Post(JObject periodo)
        {

            Context.PeriodChangeState((int)periodo.SelectToken("idPeriodo"), (int)periodo.SelectToken("idProyecto"));
        }

        // DELETE api/periodos/5
        //public void Delete(int id)
        //{
        //}
    }
}
