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
    public class ClienteController : ApiController
    {
        private IClienteRepository Context;

        public ClienteController(IClienteRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo="Cliente", ActionName="Lectura")]
        //Get all clients
        public IEnumerable<Object> GetAll()
        {
            return Context.GetActive();
        }

        [ClaimsAuthorization(Modulo = "Cliente", ActionName = "Lectura")]
        // GET api/cliente/5
        public Object Get(int id)
        {
            return Context.GetCliente(id);
        }

        [Authorize(Roles = "SuperAdmin")]
        //update client
        public void Put(JObject client)
        {
            Sys_Clientes _client = new Sys_Clientes()
            {
                Id = (int)((dynamic)client).id,
                ContactAddress = (string)((dynamic)client).contactAddress,
                ContactMail = (string)((dynamic)client).contactMail,
                ContactName = (string)((dynamic)client).contactName,
                ContactPhone = (string)((dynamic)client).contactPhone,
                ExpirationDate = (DateTime)((dynamic)client).expirationDate,
                Logo = (string)((dynamic)client).logo,
                MaxProjects = (int)((dynamic)client).maxProjects,
                MaxStorage = (int)((dynamic)client).maxStorage,
                MaxUsers = (int)((dynamic)client).maxUsers
            };

            Context.Update(_client);
        }

        [Authorize(Roles = "SuperAdmin")]
        public void Post(JObject client)
        {
            //add client
            Sys_Clientes _client = new Sys_Clientes()
            {
                Name = (string)((dynamic)client).name,
                OrderDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day),
                ContactAddress = (string)((dynamic)client).contactAddress,
                ContactMail = (string)((dynamic)client).contactMail,
                ContactName = (string)((dynamic)client).contactName,
                ContactPhone = (string)((dynamic)client).contactPhone,
                ExpirationDate = DateTime.Parse((string)((dynamic)client).expirationDate),
                Logo = (string)((dynamic)client).logo,
                MaxProjects = (int)((dynamic)client).maxProjects,
                MaxStorage = (int)((dynamic)client).maxStorage,
                MaxUsers = (int)((dynamic)client).maxUsers,
                Status = true
            };

            Context.Add(_client);
        }

        [Authorize(Roles = "SuperAdmin")]
        public void Delete(int id)
        {
            //delete the client
            Context.Delete(id);
        }

    }
}
