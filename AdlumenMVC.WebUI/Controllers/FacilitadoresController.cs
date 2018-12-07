using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Bussiness.RealRepositories;
using AdlumenMVC.Models.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class FacilitadoresController : ApiController
    {

        private IFacilitadores Context;

        public FacilitadoresController(IFacilitadores _Context)
        {
            Context = _Context;
        }

        // GET: api/facilitadores/
        
        public IEnumerable<Object> GetFacilitadores()
        {
            return Context.GetFacilitadores();
        }

        // GET: api/facilitadores/1
        public Pry_Facilitadores GetFacilitadorById(int idFacilitador)
        {
            return Context.GetFacilitadorById(idFacilitador);
        }

        // POST: api/facilitadores

        public void PostFacilitador(JObject facilitador)
        {
            Pry_Facilitadores _facilitador = new Pry_Facilitadores()
            {
                Nombre = (string)facilitador.SelectToken("txtNombre"),
                Email = (string)facilitador.SelectToken("txtEmail"),
                Telefono = (string)facilitador.SelectToken("txtTelefono"),
                Direccion = (string)facilitador.SelectToken("txtDireccion"),
                Status = 1
            };

            Context.addFacilitador(_facilitador);
        }

        // DELETE: api/facilitadores/1

        public void DeleteFacilitador(JObject facilitador)
        {
            Pry_Facilitadores _facilitador = new Pry_Facilitadores()
            {
                IdFacilitador = (int)facilitador.SelectToken("txtIdFacilitador"),
                Nombre = (string)facilitador.SelectToken("txtNombre"),
                Email = (string)facilitador.SelectToken("txtEmail"),
                Telefono = (string)facilitador.SelectToken("txtTelefono"),
                Direccion = (string)facilitador.SelectToken("txtDireccion"),
                Status = 0
            };

            Context.deleteFacilitador(_facilitador);
        }

    }
}
