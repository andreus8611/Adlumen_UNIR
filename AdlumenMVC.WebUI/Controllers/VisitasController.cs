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
    public class VisitasController : ApiController
    {
        private IVisitasRepository Context;

        public VisitasController(IVisitasRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Lectura")]
        // GET api/visitas
        public IEnumerable<Object> Get()
        {
            return Context.GetAll();
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Lectura")]
        // GET api/visitas/5
        public Tar_Visitas Get(int id)
        {
            return Context.GetVisitaById(id);
        }

        [ClaimsAuthorization(Modulo = "Tareas", ActionName = "RegistrarVisitas")]
        // POST api/visitas
        public void Post(JObject value)
        {
            dynamic data = value;
            string action = (string)data.action;
            switch (action)
            {
                case "addmodify":
                    {
                        if (data.idVisita == 0) //Nueva Encuesta
                        {
                            Tar_Visitas visita = new Tar_Visitas()
                            {
                                IdTarea = data.idTarea,
                                Fecha = data.fecha,
                                Descripcion = data.descripcion,
                                Ubicacion = data.ubicacion,
                                Latitud = data.latitud,
                                Longitud = data.longitud,
                                PersonaContacto = data.personaContacto
                            };

                            Context.addVisita(visita);
                        }
                        else //Edición Visita
                        {
                            Tar_Visitas visita = Context.GetVisitaById((int)data.idVisita);
                            if (visita.Fecha != (DateTime)data.fecha) visita.Fecha = (DateTime)data.fecha;
                            if (visita.Descripcion != (string)data.descripcion) visita.Descripcion = (string)data.descripcion;
                            if (visita.Ubicacion != (string)data.ubicacion) visita.Ubicacion = (string)data.ubicacion;
                            if (visita.PersonaContacto != (string)data.personaContacto) visita.PersonaContacto = (string)data.personaContacto;

                            Context.modifyVisita();
                        }
                    }
                    break;
                case "delete":
                    {
                        Tar_Visitas visita = Context.GetVisitaById((int)data.idVisita);
                        Context.deleteVisita(visita);
                    }
                    break;
                case "complete":
                    {
                        Tar_Visitas visita = Context.GetVisitaById((int)data.idVisita);
                        Context.completeVisita(visita);
                    }
                    break;
            }
        }
    }
}
