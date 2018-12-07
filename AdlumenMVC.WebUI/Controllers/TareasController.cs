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
    
    public class TareasController : ApiController
    {

        private ITareasRepository Context;
        public TareasController (ITareasRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Tareas", ActionName="Lectura")]
        public IEnumerable<Object> Get()
        {
            return Context.Get();
        }

        [ClaimsAuthorization(Modulo = "Tareas", ActionName = "Escritura")]
        public void PostTarea(JObject tarea)
        {
            var _tareas = new Tar_Tareas()
            {
                //estado is set to false when the task is active
                IdLista = tarea.SelectToken("idLista")?.ToObject<int?>(),
                Descripcion = tarea.SelectToken("descripcion")?.ToObject<string>(),
                FechaInicio = tarea.SelectToken("fechaInicio")?.ToObject<DateTime?>(),
                FechaFin = tarea.SelectToken("fechaFin")?.ToObject<DateTime?>(),
                IdResponsable = tarea.SelectToken("idResponsable")?.ToObject<int?>(),
                IdUsuarioCreacion = tarea.SelectToken("idUsuario")?.ToObject<int?>(),
                Prioridad = tarea.SelectToken("prioridad")?.ToObject<bool?>(),
                Estado = false,
                FechaCreacion = DateTime.Now
            };

            Context.addTarea(_tareas);
        }

        [ClaimsAuthorization(Modulo = "Tareas", ActionName = "Escritura")]
        public void Put(JObject task)
        {
            var _task = new Tar_Tareas()
            {
                Id = (int)task.SelectToken("id"),
                Descripcion = task.SelectToken("descripcion")?.ToObject<string>(),
                FechaInicio = task.SelectToken("fechaInicio")?.ToObject<DateTime?>(),
                FechaFin = task.SelectToken("fechaFin")?.ToObject<DateTime?>(),
                IdResponsable = task.SelectToken("idResponsable")?.ToObject<int?>(),
                IdUsuarioModificacion = task.SelectToken("idUsuario")?.ToObject<int?>(),
                IdUsuarioCompletado = task.SelectToken("idUsuarioCompletado")?.ToObject<int?>(),
                Prioridad = task.SelectToken("prioridad")?.ToObject<bool?>(),
            };

            Context.ActualizarTarea(_task);
        }

        [ClaimsAuthorization(Modulo = "Tareas", ActionName = "Escritura")]
        public void Delete(int id)
        {
            Context.EliminarTarea(id);
        }
    }
}
