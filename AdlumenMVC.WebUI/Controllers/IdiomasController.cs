using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Models.Model;
using AdlumenMVC.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class IdiomasController : ApiController
    {
        private IIdiomasRepository Context;

        public IdiomasController(IIdiomasRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo="Encuestas", ActionName="Lectura")]
        // GET api/idiomas
        public IEnumerable<M_Idiomas> Get()
        {
            return Context.GetAll();
        }

        [Authorize(Roles="SuperAdmin")]
        // GET api/idiomas/5
        public string Get(int id)
        {
            return "value";
        }
        [Authorize(Roles = "SuperAdmin")]
        // POST api/idiomas
        public void Post([FromBody]string value)
        {
        }
        [Authorize(Roles = "SuperAdmin")]
        // PUT api/idiomas/5
        public void Put(int id, [FromBody]string value)
        {
        }
        [Authorize(Roles = "SuperAdmin")]
        // DELETE api/idiomas/5
        public void Delete(int id)
        {
        }
    }
}
