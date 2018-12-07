using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Models;
using AdlumenMVC.Models.Model;
using AdlumenMVC.WebUI.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace AdlumenMVC.WebUI.Controllers
{
    public class TenantsController : ApiController
    {
        private ITenantsRepository Context;

        public TenantsController(ITenantsRepository _context)
        {
            Context = _context;
        }

        [ClaimsAuthorization(Modulo = "Tenants", ActionName = "Lectura")]
        public IEnumerable<Object> Get()
        {
            return Context.GetAll();
        }

        [ClaimsAuthorization(Modulo = "Tenants", ActionName = "Escritura")]
        public async void PostTenant(Tenant tenant)
        {
            var db = new Adlumen2SocEntities();
            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    db.Tenants.Add(tenant);
                    db.SaveChanges();
                    
                    var syscliente = new Sys_Clientes
                    {
                        Name = tenant.Name,
                        MaxUsers = 5,
                        MaxProjects = 10,
                        MaxStorage = 100,
                        OrderDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddYears(1),
                        Status = true,
                        ContactName = "contacto",
                        ContactMail = "email",
                        IdTenant = tenant.Id
                    };
                    db.Sys_Clientes.Add(syscliente);
                    db.SaveChanges();

                    var sysusuario = new Sys_Usuarios
                    {
                        UserName = tenant.Name,
                        Nombre = tenant.DisplayName,
                        Correo = tenant.Email,
                        UserReport = "test",
                        idEmpresa = 0,
                        CustomerId = syscliente.Id,
                        IdTenant = tenant.Id
                    };
                    db.Sys_Usuarios.Add(sysusuario);
                    db.SaveChanges();

                    var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var user = new ApplicationUser
                    {
                        UserName = tenant.Name,
                        Email = tenant.Email,
                        FirstName = "nombre",
                        LastName = "apellido",
                        JoinDate = DateTime.Now,
                        Level = 3,
                        EmailConfirmed = true,
                        IdLocal = sysusuario.IdUsuario,
                        Client = syscliente.Id,
                        IdTenant = tenant.Id
                    };

                    var userResult = await userManager.CreateAsync(user, "Adlumen@");
                    if (userResult.Succeeded)
                    {
                        var roleResult = await userManager.AddToRolesAsync(user.Id, "Admin", "SuperAdmin");
                    }

                    db.M_Monedas.AddRange(new M_Monedas[]
                    {
                        new M_Monedas { Nombre = "Dolar", Representacion = "$", Codigo = "USD", IdTenant = tenant.Id },
                        new M_Monedas { Nombre = "Peso mexicano", Representacion = "$", Codigo = "MXN", IdTenant = tenant.Id },
                        new M_Monedas { Nombre = "Euro", Representacion = "€", Codigo = "EUR", IdTenant = tenant.Id },
                        new M_Monedas { Nombre = "Sol", Representacion = "S/", Codigo = "PEN", IdTenant = tenant.Id },
                        new M_Monedas { Nombre = "Peso colombiano", Representacion = "$", Codigo = "COP", IdTenant = tenant.Id }
                    });

                    /*db.Pry_PresupuestoTipo.AddRange(new Pry_PresupuestoTipo[]
                    {
                        new Pry_PresupuestoTipo { Descripcion = "Costos de ejecucion del Proyecto", Tipo = BudgetType.ProjectCosts, IdTenant = tenant.Id },
                        new Pry_PresupuestoTipo { Descripcion = "Seguimiento y Evaluación", Tipo = BudgetType.Evaluations, IdTenant = tenant.Id },
                        new Pry_PresupuestoTipo { Descripcion = "Gastos Administrativos", Tipo = BudgetType.AdministrativeExpenses, IdTenant = tenant.Id },
                        new Pry_PresupuestoTipo { Descripcion = "Imprevistos", Tipo = BudgetType.UnforeseenExpenses, IdTenant = tenant.Id },
                        new Pry_PresupuestoTipo { Descripcion = "Donaciones", Tipo = BudgetType.Donations, IdTenant = tenant.Id },
                        new Pry_PresupuestoTipo { Descripcion = "Distribucion Donaciones Actividad", Tipo = BudgetType.DonationActivity, IdTenant = tenant.Id },
                    });*/

                    db.SaveChanges();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }

            TenantUtil.LoadTenants();
        }

        [ClaimsAuthorization(Modulo = "Tenants", ActionName = "Escritura")]
        public void Put(Tenant tenant)
        {
            try
            {
                Context.Update(tenant);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [ClaimsAuthorization(Modulo = "Tenants", ActionName = "Escritura")]
        public void Delete(int id)
        {
            try
            {
                var tenant = Context.GetById(id);
                Context.Delete(tenant);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("tenants/create/{name}")]
        public async Task<HttpResponseMessage> Create(string name)
        {
            var db = new Adlumen2SocEntities();
            using (var tx = db.Database.BeginTransaction())
            {
                try
                {

                    var tenant = new Tenant
                    {
                        Name = name,
                        DisplayName = name.ToUpper(),
                        Email = "sker@live.com"
                    };
                    db.Tenants.Add(tenant);
                    db.SaveChanges();

                    var syscliente = new Sys_Clientes
                    {
                        Name = name,
                        MaxUsers = 5,
                        MaxProjects = 10,
                        MaxStorage = 100,
                        OrderDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddYears(1),
                        Status = true,
                        ContactName = "contacto",
                        ContactMail = "email",
                        IdTenant = tenant.Id
                    };
                    db.Sys_Clientes.Add(syscliente);
                    db.SaveChanges();

                    var sysusuario = new Sys_Usuarios
                    {
                        UserName = name,
                        Nombre = "nombre",
                        Correo = "correo",
                        UserReport = "test",
                        idEmpresa = 0,
                        CustomerId = syscliente.Id,
                        IdTenant = tenant.Id
                    };
                    db.Sys_Usuarios.Add(sysusuario);
                    db.SaveChanges();

                    var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var user = new ApplicationUser
                    {
                        UserName = name,
                        Email = name + "@test.com",
                        FirstName = "nombre",
                        LastName = "apellido",
                        JoinDate = DateTime.Now,
                        Level = 3,
                        EmailConfirmed = true,
                        IdLocal = sysusuario.IdUsuario,
                        Client = syscliente.Id,
                        IdTenant = tenant.Id
                    };

                    var userResult = await userManager.CreateAsync(user, "Adlumen@");
                    if (userResult.Succeeded)
                    {
                        var roleResult = await userManager.AddToRolesAsync(user.Id, "Admin", "SuperAdmin");
                    }

                    db.M_Monedas.AddRange(new M_Monedas[]
                    {
                        new M_Monedas { Nombre = "Dolar", Representacion = "$", Codigo = "USD", IdTenant = tenant.Id },
                        new M_Monedas { Nombre = "Peso mexicano", Representacion = "$", Codigo = "MXN", IdTenant = tenant.Id },
                        new M_Monedas { Nombre = "Euro", Representacion = "€", Codigo = "EUR", IdTenant = tenant.Id },
                        new M_Monedas { Nombre = "Sol", Representacion = "S/", Codigo = "PEN", IdTenant = tenant.Id },
                        new M_Monedas { Nombre = "Peso colombiano", Representacion = "$", Codigo = "COP", IdTenant = tenant.Id }
                    });

                    /*db.Pry_PresupuestoTipo.AddRange(new Pry_PresupuestoTipo[]
                    {
                        new Pry_PresupuestoTipo { Descripcion = "Costos de ejecucion del Proyecto", Tipo = BudgetType.ProjectCosts, IdTenant = tenant.Id },
                        new Pry_PresupuestoTipo { Descripcion = "Seguimiento y Evaluación", Tipo = BudgetType.Evaluations, IdTenant = tenant.Id },
                        new Pry_PresupuestoTipo { Descripcion = "Gastos Administrativos", Tipo = BudgetType.AdministrativeExpenses, IdTenant = tenant.Id },
                        new Pry_PresupuestoTipo { Descripcion = "Imprevistos", Tipo = BudgetType.UnforeseenExpenses, IdTenant = tenant.Id },
                        new Pry_PresupuestoTipo { Descripcion = "Donaciones", Tipo = BudgetType.Donations, IdTenant = tenant.Id },
                        new Pry_PresupuestoTipo { Descripcion = "Distribucion Donaciones Actividad", Tipo = BudgetType.DonationActivity, IdTenant = tenant.Id },
                    });*/

                    db.SaveChanges();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                }
            }

            TenantUtil.LoadTenants();

            var result = $"<a href='http://{name}.adlumen.com'>http://{name}.adlumen.org</a> Usuario:{name} Contraseña:Adlumen@";
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/html");
            return response;
        }


        private void AddCurrencies(Tenant tenant)
        {

        }

        private void AddBudgetTypes()
        {

        }
    }
}