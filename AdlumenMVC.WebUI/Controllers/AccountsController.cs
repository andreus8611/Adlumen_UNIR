using AdlumenMVC.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using AdlumenMVC.WebUI.Models;
using System.Security.Claims;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json.Linq;
using AdlumenMVC.Models.Model;
using AdlumenMVC.WebUI.Infraestructure;

namespace AdlumenMVC.WebUI.Controllers
{

    
    [RoutePrefix("api/accounts")]
    public class AccountsController : BaseApiController
    {

        //[AllowAnonymous]
        //[Route("roles")]
        //public IHttpActionResult GetRoles()
        //{
        //    //Only SuperAdmin or Admin can delete users (Later when implement roles)
        //    var identity = User.Identity as System.Security.Claims.ClaimsIdentity;

        //    return Ok(this.AppRoleManager.Roles.ToList().Select(u => this.TheModelFactory.Create(u)));
        //}
        

        [ClaimsAuthorization(Modulo = "Usuarios", ActionName="Lectura")]
        [Route("users")]
        public IHttpActionResult GetUsers()
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var identity = User.Identity as System.Security.Claims.ClaimsIdentity;

            return Ok(this.AppUserManager.Users.ToList().Select(u => this.TheModelFactory.Create(u)));
        }

        [ClaimsAuthorization(Modulo = "Usuarios", ActionName = "GetUserById")]
        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        [Route("user/{id:guid}", Name = "GetUserById")]
       // [Route("user/{id:guid}")]
        public async Task<IHttpActionResult> GetUser(string Id)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var user = await this.AppUserManager.FindByIdAsync(Id);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }

        [ClaimsAuthorization(Modulo = "Usuarios", ActionName = "GetUserById")]
        [Route("{username}")]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var user = await this.AppUserManager.FindByNameAsync(username);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }


        //[HttpPut]
        [ClaimsAuthorization(Modulo = "Usuarios", ActionName = "Escritura")]
        [Route("user/{id:guid}")]
        public async Task<IHttpActionResult> PutUser(string Id, EditUserBindingModel user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var appUser = await this.AppUserManager.FindByIdAsync(Id);

            if (appUser == null)
            {
                return NotFound();
            }

            if (appUser != null)
            {

                appUser.UserName = user.UserName;

                appUser.Email = user.Email;

                appUser.FirstName = user.FirstName;

                appUser.LastName = user.LastName;

                appUser.PhoneNumber = user.PhoneNumber;

                appUser.Latitude = user.Latitude;

                appUser.Longitude = user.Longitude;

                //appUser.Roles = user.Roles;

                //var currentRoles = await this.AppUserManager.GetRolesAsync(appUser.Id);

                //var rolesNotExists = rolesToAssign.Except(this.AppRoleManager.Roles.Select(x => x.Name)).ToArray();

                //if (rolesNotExists.Count() > 0)
                //{

                //    ModelState.AddModelError("", string.Format("Roles '{0}' does not exixts in the system", string.Join(",", rolesNotExists)));
                //    return BadRequest(ModelState);
                //}

                //IdentityResult removeResult = await this.AppUserManager.RemoveFromRolesAsync(appUser.Id, currentRoles.ToArray());

                //if (!removeResult.Succeeded)
                //{
                //    ModelState.AddModelError("", "Failed to remove user roles");
                //    return BadRequest(ModelState);
                //}

                //IdentityResult addResult = await this.AppUserManager.AddToRolesAsync(appUser.Id, rolesToAssign);

                //if (!addResult.Succeeded)
                //{
                //    ModelState.AddModelError("", "Failed to add user roles");
                //    return BadRequest(ModelState);
                //}

                IdentityResult result = await this.AppUserManager.UpdateAsync(appUser);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok(appUser);

            }

            return NotFound();

        }


        [ClaimsAuthorization(Modulo = "Usuarios", ActionName = "Escritura")]
        [Route("create")]
        public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser user = null;
            var db = new Adlumen2SocEntities();

            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    var sysusuario = new Sys_Usuarios
                    {
                        UserName = createUserModel.Username,
                        Nombre = createUserModel.Username,
                        Correo = createUserModel.Email,
                        UserReport = "test",
                        idEmpresa = 0,
                        CustomerId = createUserModel.Client
                    };
                    db.Sys_Usuarios.Add(sysusuario);
                    db.SaveChanges();

                    user = new ApplicationUser()
                    {
                        UserName = createUserModel.Username,
                        Email = createUserModel.Email,
                        FirstName = createUserModel.FirstName,
                        LastName = createUserModel.LastName,
                        JoinDate = DateTime.UtcNow,
                        Level = 3,
                        EmailConfirmed = true,
                        IdLocal = sysusuario.IdUsuario,
                        Client = createUserModel.Client
                        //Roles=createUserModel.RoleName;
                    };

                    var result = await AppUserManager.CreateAsync(user, createUserModel.Password);

                    if (!result.Succeeded)
                    {
                        return GetErrorResult(result);
                    }

                    //string code = await this.AppUserManager.GenerateEmailConfirmationTokenAsync(user.Id);

                    //var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = user.Id, code = code }));

                    //await this.AppUserManager.SendEmailAsync(user.Id,
                    //                                        "Confirm your account",
                    //                                        "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");


                    db.SaveChanges();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
            Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));
            return Created(locationHeader, TheModelFactory.Create(user));
        }

        [ClaimsAuthorization(Modulo = "Usuarios", ActionName = "ChangePassword")]
        [HttpGet]
        [Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
        public async Task<IHttpActionResult> ConfirmEmail(string userId = "", string code = "")
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }

            IdentityResult result = await this.AppUserManager.ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return GetErrorResult(result);
            }
        }

        [ClaimsAuthorization(Modulo = "Usuarios", ActionName = "ChangePassword")]
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await this.AppUserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        [ClaimsAuthorization(Modulo = "Usuarios", ActionName = "Escritura")]
        [Route("user/{id:guid}")]
        public async Task<IHttpActionResult> DeleteUser(string id)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var appUser = await this.AppUserManager.FindByIdAsync(id);
         
            if (appUser != null)
            {
                var result = await this.AppUserManager.DeleteAsync(appUser);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
                return Ok();
            }
            return NotFound();
        }

        [ClaimsAuthorization(Modulo = "Usuarios", ActionName = "Escritura")]
        [Route("user/{id:guid}/roles")]
        [HttpPut]
        public async Task<IHttpActionResult> AssignRolesToUser([FromUri] string id, [FromBody] string[] rolesToAssign)
        {

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }
            
            var currentRoles = await this.AppUserManager.GetRolesAsync(appUser.Id);

            var rolesNotExists = rolesToAssign.Except(this.AppRoleManager.Roles.Select(x => x.Name)).ToArray();

            if (rolesNotExists.Count() > 0) {

                ModelState.AddModelError("", string.Format("Roles '{0}' does not exixts in the system", string.Join(",", rolesNotExists)));
                return BadRequest(ModelState);
            }

            var removeResult = await this.AppUserManager.RemoveFromRolesAsync(appUser.Id, currentRoles.ToArray());

            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to remove user roles");
                return BadRequest(ModelState);
            }

            var addResult = await this.AppUserManager.AddToRolesAsync(appUser.Id, rolesToAssign);

            if (!addResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to add user roles");
                return BadRequest(ModelState);
            }

            return Ok();

        }

        [ClaimsAuthorization(Modulo = "Usuarios", ActionName = "Escritura")]
        [Route("user/{id:guid}/assignclaims")]
        [HttpPut]
        public async Task<IHttpActionResult> AssignClaimsToUser([FromUri] string id, [FromBody] List<ClaimBindingModel> claimsToAssign) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            foreach (ClaimBindingModel claimModel in claimsToAssign)
            {
                if (appUser.Claims.Any(c => c.ClaimType == claimModel.Type)) {
                   
                    await this.AppUserManager.RemoveClaimAsync(id, ExtendedClaimsProvider.CreateClaim(claimModel.Type, claimModel.Value));
                }

                await this.AppUserManager.AddClaimAsync(id, ExtendedClaimsProvider.CreateClaim(claimModel.Type, claimModel.Value));
            }
            
            return Ok();
        }

        [ClaimsAuthorization(Modulo = "Usuarios", ActionName = "Escritura")]
        [Route("user/{id:guid}/removeclaims")]
        [HttpPut]
        public async Task<IHttpActionResult> RemoveClaimsFromUser([FromUri] string id, [FromBody] List<ClaimBindingModel> claimsToRemove)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            foreach (ClaimBindingModel claimModel in claimsToRemove)
            {
                if (appUser.Claims.Any(c => c.ClaimType == claimModel.Type))
                {
                    await this.AppUserManager.RemoveClaimAsync(id, ExtendedClaimsProvider.CreateClaim(claimModel.Type, claimModel.Value));
                }
            }

            return Ok();
        }

        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [Route("ForgotPassword")]
        public async Task<IHttpActionResult> ForgotPassword(string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await AppUserManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("El email es incorrecto.");
            }

            var code = await AppUserManager.GeneratePasswordResetTokenAsync(user.Id);
            code = HttpUtility.UrlEncode(code);

            var callbackUrl = string.Concat(
                Request.RequestUri.Scheme,
                "://",
                Request.RequestUri.Authority,
                "/#!/resetPassword?key=",
                user.Id,
                "&code=",
                code
            );
            await AppUserManager.SendEmailAsync(user.Id, "Recuperar Contraseña", "Por favor, recupere su contraseña siguiendo <a href=\"" + callbackUrl + "\">este enlace.</a>");

            return Ok();
        }

        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [Route("ResetPassword")]
        public async Task<IHttpActionResult> ResetPassword(JObject value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dynamic data = value;
            var pass = (string)data.pass;
            var code = (string)data.code;
            var userId = (string)data.userId;

            //code = HttpUtility.UrlDecode(code);

            var user = await AppUserManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest("El usuario es incorrecto.");
            }
            var result = await AppUserManager.ResetPasswordAsync(user.Id, code, pass);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest("El enlace de recuperación ya no es valido.");
        }
    }
}