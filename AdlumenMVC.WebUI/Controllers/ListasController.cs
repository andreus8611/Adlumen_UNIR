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
    public class ListasController : ApiController
    {
       private IListasRepository  Context;

       public ListasController(IListasRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo="Tareas", ActionName="Lectura")]
        //cambiar el usuario
        public IEnumerable<Object> GetListas()
        {
            return Context.Get();
        }
        //agregar Listas
       [ClaimsAuthorization(Modulo = "Tareas", ActionName = "Escritura")]
        public void PostListas(JObject lista)
        {
            Tar_Listas _Listas = new Tar_Listas()
            {
                Descripcion = (string)lista.SelectToken("descripcion"),
                IdUsuarioCreacion = (int)lista.SelectToken("idUsuario"),
                IdProyecto = (int)lista.SelectToken("idProyecto"),
                FechaCreacion = DateTime.Now,

            };
            Context.addListas(_Listas);

        }

        [ClaimsAuthorization(Modulo = "Tareas", ActionName = "Escritura")]
        public void PutCambiar(JObject list)
        {

            Tar_Listas _list = new Tar_Listas()
            {
                Id = (int)((dynamic)list).id,
                Descripcion = (string)((dynamic)list).descripcion,
                IdUsuarioModificacion = (int)((dynamic)list).idUsuario,
                FechaModificacion = DateTime.Now

            };

            Context.ActualizarLista(_list);
        }
    }
}
