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
    public class DonantesController : ApiController
    {
        private IDonantesRepository Context;

        public DonantesController(IDonantesRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Donantes", ActionName = "GetDonantes")]
        // GET api/donantes
        public IEnumerable<Org_Donantes> Get()
        {
            return Context.GetAll();
        }

        [Authorize(Roles = "Admin")]
        // GET api/donantes/5
        public string Get(int id)
        {
            return "value";
        }

        [ClaimsAuthorization(Modulo = "Donantes", ActionName = "PostDonantes")]
        // POST api/donantes
        public void Post(JObject value)
        {
            dynamic data = value;
            string action = (string)data.action;
            string userName = null;
            if (data.userId != null)
            {
                userName = Context.GetUsuarioById((int)data.userId).UserName;
            }

            switch (action)
            {
                case "addDonante":
                    {
                        Org_Donantes donante = new Org_Donantes()
                        {
                            IdCliente = (int)data.idCliente,
                            Nombre = (string)data.nombre,
                            IdIdentificacionTipo = (int)data.idIdentificacionTipo,
                            Identificacion = (string)data.identificacion,
                            Contacto = (string)data.contacto,
                            Telefono = (string)data.telefono,
                            Ubicacion = (string)data.ubicacion,
                            Correo = (string)data.correo,
                            URL = (string)data.url,
                            HojaVida = (string)data.hojaVida,
                            FechaCreacion = DateTime.Now,
                            UsuarioCreacion = userName,
                            Eliminado = false
                        };

                        Context.addDonante(donante);
                    }
                    break;
                case "modifyDonante":
                    {
                        Org_Donantes donante = Context.GetDonanteById((int)data.idDonante);
                        bool modified = false;

                        if (donante.IdCliente != (int)data.idCliente)
                        {
                            donante.IdCliente = (int)data.idCliente;
                            modified = true;
                        }
                        if (donante.Nombre != (string)data.nombre)
                        {
                            donante.Nombre = (string)data.nombre;
                            modified = true;
                        }
                        if (donante.IdIdentificacionTipo != (int)data.idIdentificacionTipo)
                        {
                            donante.IdIdentificacionTipo = (int)data.idIdentificacionTipo;
                            modified = true;
                        }
                        if (donante.Identificacion != (string)data.identificacion)
                        {
                            donante.Identificacion = (string)data.identificacion;
                            modified = true;
                        }
                        if (donante.Contacto != (string)data.contacto)
                        {
                            donante.Contacto = (string)data.contacto;
                            modified = true;
                        }
                        if (donante.Telefono != (string)data.telefono)
                        {
                            donante.Telefono = (string)data.telefono;
                            modified = true;
                        }
                        if (donante.Ubicacion != (string)data.ubicacion)
                        {
                            donante.Ubicacion = (string)data.ubicacion;
                            modified = true;
                        }
                        if (donante.Correo != (string)data.correo)
                        {
                            donante.Correo = (string)data.correo;
                            modified = true;
                        }
                        if (donante.URL != (string)data.url)
                        {
                            donante.URL = (string)data.url;
                            modified = true;
                        }
                        if (donante.HojaVida != (string)data.hojaVida)
                        {
                            donante.HojaVida = (string)data.hojaVida;
                            modified = true;
                        }
                        if (donante.Eliminado != (data.eliminado != null ? (bool)data.eliminado : false))
                        {
                            donante.Eliminado = (data.eliminado != null ? (bool)data.eliminado : false);
                            modified = true;
                        }

                        if (modified)
                        {
                            donante.UsuarioModificacion = userName;
                            donante.FechaModificacion = DateTime.Now;
                        }

                        Context.modifyData();
                    }
                    break;
            }
        }
    }
}
