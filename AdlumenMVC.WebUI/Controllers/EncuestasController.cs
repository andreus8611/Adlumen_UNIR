using AdlumenMVC.Bussiness.AbstractRepositories;
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
    public class EncuestasController : ApiController
    {
        private IEncuestasRepository Context;


        public EncuestasController(IEncuestasRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Encuestas", ActionName = "Lectura")]
        // GET api/encuestas
        public IEnumerable<M_Encuestas> Get()
        {
            return Context.GetAll();
        }

        [ClaimsAuthorization(Modulo = "Encuestas", ActionName = "Lectura")]
        // GET api/encuestas/5
        public M_Encuestas Get(int id)
        {
            return Context.GetEncuestaById(id);
        }

         [ClaimsAuthorization(Modulo = "Encuestas", ActionName = "Escritura")]
        // POST api/encuestas
        public void Post(JObject value)
        {
            dynamic data = value;
            string action = (string)data.action;
            switch (action) 
            {
                case "addmodify":
                    {
                        if (data.idEncuesta == 0) //Nueva Encuesta
                        {
                            M_Encuestas encuesta = new M_Encuestas()
                            {
                                Titulo = data.titulo,
                                Descripcion = data.descripcion,
                                FechaCreacion = DateTime.Now,
                                IdIdioma = data.idioma.idIdioma
                            };

                            Context.addEncuesta(encuesta);
                        }
                        else //Edición Encuesta
                        {
                            M_Encuestas encuesta = Context.GetEncuestaById((int)data.idEncuesta);
                            if (encuesta.Titulo != (string)data.titulo) encuesta.Titulo = (string)data.titulo;
                            if (encuesta.Descripcion != (string)data.descripcion) encuesta.Descripcion = (string)data.descripcion;
                            if (encuesta.IdIdioma != (int)data.idioma.idIdioma) encuesta.IdIdioma = (int)data.idioma.idIdioma;

                            Context.modifyEncuesta();
                        }
                    }
                    break;
                case "delete":
                    {
                        M_Encuestas encuesta = Context.GetEncuestaById((int)data.idEncuesta);
                        Context.deleteEncuesta(encuesta);
                    }
                    break;
                case "lock":
                    {
                        M_Encuestas encuesta = Context.GetEncuestaById((int)data.idEncuesta);
                        Context.lockEncuesta(encuesta);
                    }
                    break;
                case "finish":
                    {
                        M_Encuestas encuesta = Context.GetEncuestaById((int)data.idEncuesta);
                        Context.finishEncuesta(encuesta);
                    }
                    break;
            }
        }

        // PUT api/encuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/encuestas/5
        public void Delete(int id)
        {
        }
    }
}
