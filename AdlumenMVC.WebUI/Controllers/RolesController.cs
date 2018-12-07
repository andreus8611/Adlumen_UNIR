using AdlumenMVC.WebUI.Infraestructure;
using AdlumenMVC.WebUI.Infrastructure;
using AdlumenMVC.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{


    //[Authorize(Roles="Admin")]
    [RoutePrefix("api/roles")]
    public class RolesController : BaseApiController
    {

        [ClaimsAuthorization(Modulo = "Roles", ActionName = "Lectura")]
        [Route("{id:guid}", Name = "GetRoleById")]
        public async Task<IHttpActionResult> GetRole(string Id)
        {
            var role = await this.AppRoleManager.FindByIdAsync(Id);

            if (role != null)
            {
                return Ok(TheModelFactory.Create(role));
            }

            return NotFound();

        }

        [ClaimsAuthorization(Modulo = "Roles", ActionName = "Lectura")]
        [Route("roles")]
        public IHttpActionResult GetRoles()
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var identity = User.Identity as System.Security.Claims.ClaimsIdentity;

            return Ok(this.AppRoleManager.Roles.ToList().Select(u => this.TheModelFactory.Create(u)));
        }

        [ClaimsAuthorization(Modulo = "Roles", ActionName = "Escritura")]
        [Route("create")]
        public async Task<IHttpActionResult> Create(CreateRoleBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = new IdentityRole { Name = model.Name };
            
            var result = await this.AppRoleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            try
            {
                AddDefaultActions(role);
            }
            catch (Exception ex)
            {
                return BadRequest("No se agregaron los permisos de Usuarios. Agreguelos manualmente.");
            }

            Uri locationHeader = new Uri(Url.Link("GetRoleById", new { id = role.Id }));

            return Created(locationHeader, TheModelFactory.Create(role));
        }

        [ClaimsAuthorization(Modulo = "Roles", ActionName = "Escritura")]
        [Route("deleterole/{id:guid}")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteRole(string id)
        {
            var role = await this.AppRoleManager.FindByIdAsync(id);

            if (role != null)
            {
                var result = await this.AppRoleManager.DeleteAsync(role);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
                return Ok();
            }
            return NotFound();
        }

        [ClaimsAuthorization(Modulo = "Roles", ActionName = "Escritura")]
        [Route("ManageUsersInRole")]
        public async Task<IHttpActionResult> ManageUsersInRole(UsersInRoleModel model)
        {
            var role = await this.AppRoleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ModelState.AddModelError("", "Role does not exist");
                return BadRequest(ModelState);
            }

            foreach (string user in model.EnrolledUsers)
            {
                var appUser = await this.AppUserManager.FindByIdAsync(user);

                if (appUser == null)
                {
                    ModelState.AddModelError("", String.Format("User: {0} does not exists", user));
                    continue;
                }

                if (!this.AppUserManager.IsInRole(user, role.Name))
                {
                    IdentityResult result = await this.AppUserManager.AddToRoleAsync(user, role.Name);

                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", String.Format("User: {0} could not be added to role", user));
                    }

                }
            }

            foreach (string user in model.RemovedUsers)
            {
                var appUser = await this.AppUserManager.FindByIdAsync(user);

                if (appUser == null)
                {
                    ModelState.AddModelError("", String.Format("User: {0} does not exists", user));
                    continue;
                }

                IdentityResult result = await this.AppUserManager.RemoveFromRoleAsync(user, role.Name);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", String.Format("User: {0} could not be removed from role", user));
                }
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpGet]
        [Route("fixroles")]
        public IHttpActionResult FixRoles1()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var roles = db.Roles.ToList();
                    var actions = db.AccionesRoles.ToList();
                    var action2 = db.Acciones.FirstOrDefault(x => x.Nombre == "Lectura" && x.ModuloId == 4);
                    var action1 = db.Acciones.FirstOrDefault(x => x.Nombre == "GetUserById" && x.ModuloId == 4);

                    if (action1 == null || action2 == null)
                    {
                        return Ok("Las acciones predefinidas de Usuario no existen.");
                    }

                    foreach (var role in roles)
                    {
                        var permissionExists = actions.Any(x =>
                            x.RoleId == role.Id &&
                            x.AccionesId == action1.AccionesId);

                        if (!permissionExists)
                        {
                            db.AccionesRoles.Add(new AccionesRole
                            {
                                RoleId = role.Id,
                                AccionesId = action1.AccionesId
                            });
                        }

                        permissionExists = actions.Any(x =>
                            x.RoleId == role.Id &&
                            x.AccionesId == action2.AccionesId);

                        if (!permissionExists)
                        {
                            db.AccionesRoles.Add(new AccionesRole
                            {
                                RoleId = role.Id,
                                AccionesId = action2.AccionesId
                            });
                        }
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Ok("Error. Intente de nuevo.<br><br>" + ex.Message);
            }

            return Ok("Los roles han sido corregidos.");
        }

        private void AddDefaultActions(IdentityRole role)
        {
            using (var db = new ApplicationDbContext())
            {
                var action2 = db.Acciones.FirstOrDefault(x => x.Nombre == "Lectura" && x.ModuloId == 4);
                var action1 = db.Acciones.FirstOrDefault(x => x.Nombre == "GetUserById" && x.ModuloId == 4);

                db.AccionesRoles.Add(new AccionesRole
                {
                    RoleId = role.Id,
                    AccionesId = action1.AccionesId
                });

                db.AccionesRoles.Add(new AccionesRole
                {
                    RoleId = role.Id,
                    AccionesId = action2.AccionesId
                });

                db.SaveChanges();
            }
        }
    }
}
