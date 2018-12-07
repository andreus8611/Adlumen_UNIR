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
    public class PermisosBitacoraController : ApiController
    {
        private IPermisosBitacoraRepository Context;

        public PermisosBitacoraController(IPermisosBitacoraRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Tareas", ActionName = "VerPermisosBitacora")]
        // GET api/permisosbitacora
        public IEnumerable<Object> Get()
        {
            return Context.GetPermisos();
        }

        [ClaimsAuthorization(Modulo = "Tareas", ActionName = "RegistrarPermisosBitácora")]
        // POST api/permisosbitacora
        public void Post(JArray value)
        {
            JArray permisos = value;
            int i = 0;
            foreach (JObject oPermisos in permisos)
            {
                dynamic dataPermiso = oPermisos;
                if (dataPermiso.idVisita != null && i == 0) //delete rights only once
                {
                    Context.deletePermisosByVisitaId((int)dataPermiso.idVisita);
                    i++;
                }
                
                if ((bool)dataPermiso.readVisita || (bool)dataPermiso.writeVisita ||
                    (bool)dataPermiso.readBitacora || (bool)dataPermiso.writeBitacora)
                {
                    string permisoStr = null;
                    if ((bool)dataPermiso.readVisita) permisoStr += string.IsNullOrEmpty(permisoStr) ? "RV" : "," + "RV";
                    if ((bool)dataPermiso.writeVisita) permisoStr += string.IsNullOrEmpty(permisoStr) ? "WV" : "," + "WV";
                    if ((bool)dataPermiso.readBitacora) permisoStr += string.IsNullOrEmpty(permisoStr) ? "RB" : "," + "RB";
                    if ((bool)dataPermiso.writeBitacora) permisoStr += string.IsNullOrEmpty(permisoStr) ? "WB" : "," + "WB";
                    Tar_Permisos_Bitacora permisoBitacora = new Tar_Permisos_Bitacora()
                    {
                        IdVisita = dataPermiso.idVisita,
                        IdUsuario = dataPermiso.idUsuario,
                        Permiso = permisoStr
                    };

                    Context.addPermisoBitacora(permisoBitacora);
                }
            }
        }

    }
}
