using AdlumenMVC.WebUI.Controllers;
using AdlumenMVC.WebUI.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace AdlumenMVC.WebUI.Infraestructure
{
    internal sealed class MigrationConfig : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public MigrationConfig()
        {

            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(ApplicationDbContext context)
        {

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new ApplicationDbContext()));

            var users = new List<ApplicationUser>()
            { 
                new ApplicationUser() 
                {
                    UserName = "admin",
                    Email = "heytelmartinez@hotmail.com",
                    EmailConfirmed = true,
                    FirstName = "Heytel",
                    LastName = "Martinez",
                    Level = 1,
                    JoinDate = DateTime.Now.AddYears(-3),
                    Client = 81,
                    Latitude = "12.1149926",
                    Longitude = "-86.2361744",
                    Logo = "/Images/userNew.png",
                    IdLocal = 489
                },
                new ApplicationUser() 
                {
                    UserName = "rboutet",
                    Email = "roberto.boutet@spiritsol.net",
                    EmailConfirmed = true,
                    FirstName = "Roberto",
                    LastName = "Boutet",
                    Level = 1,
                    JoinDate = DateTime.Now.AddYears(-3),
                    Client = 81,
                    Latitude = "12.1149926",
                    Longitude = "-86.2361744",
                    Logo = "/Images/userNew.png",
                    IdLocal = 490
                },
                new ApplicationUser() 
                {
                    UserName = "evaluador",
                    Email = "heytelmartinez@hotmail.com",
                    EmailConfirmed = true,
                    FirstName = "evaluador",
                    LastName = "demo",
                    Level = 1,
                    JoinDate = DateTime.Now.AddYears(-3),
                    Client = 81,
                    Latitude = "12.1149926",
                    Longitude = "-86.2361744",
                    Logo = "/Images/userNew.png",
                    IdLocal = 491
                },
                new ApplicationUser() 
                {
                    UserName = "digitador",
                    Email = "heytelmartinez@hotmail.com",
                    EmailConfirmed = true,
                    FirstName = "digitador",
                    LastName = "demo",
                    Level = 1,
                    JoinDate = DateTime.Now.AddYears(-3),
                    Client = 81,
                    Latitude = "12.1149926",
                    Longitude = "-86.2361744",
                    Logo = "/Images/userNew.png",
                    IdLocal = 492
                }
            };

            foreach (ApplicationUser user in users)
                manager.Create(user, "Adlumen2015!");

            if (roleManager.Roles.Count() == 0)
            {

                roleManager.Create(new ApplicationRole { Name = "SuperAdmin" });
                roleManager.Create(new ApplicationRole { Name = "Admin" });
                roleManager.Create(new ApplicationRole { Name = "Evaluador" });
                roleManager.Create(new ApplicationRole { Name = "Digitador" });
                roleManager.Create(new ApplicationRole { Name = "Donante" });
                roleManager.Create(new ApplicationRole { Name = "Gerente" });
            }

            var adminUser = manager.FindByName("admin");

            manager.AddToRoles(adminUser.Id, new string[] { "SuperAdmin", "Admin" });

            List<Modulo> Modulos = new List<Modulo>() 
                {
                    new Modulo() 
                    {
                        Nombre = "Dashboard"

                    },
                    new Modulo() 
                    {
                        Nombre = "Empresa"

                    },
                    new Modulo() 
                    {
                        Nombre = "Cliente"

                    },
                     new Modulo() 
                    {
                        Nombre = "Usuarios"

                    },
                     new Modulo() 
                    {
                        Nombre = "Roles"

                    },
                     new Modulo() 
                    {
                        Nombre = "Proyectos"

                    },
                     new Modulo() 
                    {
                        Nombre = "Patrocinadores"

                    },
                     new Modulo() 
                    {
                        Nombre = "Tipos de Cambio"

                    },
                     new Modulo() 
                    {
                        Nombre = "Partidas de Gastos"

                    },
                    new Modulo() 
                    {
                        Nombre = "Indicadores"

                    },
                    new Modulo() 
                    {
                        Nombre = "Gastos"

                    },
                    new Modulo() 
                    {
                        Nombre = "Reportes"

                    },
                    new Modulo() 
                    {
                        Nombre = "Tareas"

                    },
                    new Modulo() 
                    {
                        Nombre = "Evaluación"

                    },
                    new Modulo() 
                    {
                        Nombre = "Encuestas"

                    },
                    new Modulo() 
                    {
                        Nombre = "Mensajes"

                    }

                };

            List<Acciones> accionesList = new List<Acciones>();

            foreach (var module in Modulos)
            {
                context.Modulo.Add(module);

                accionesList.AddRange(
                        new List<Acciones>()
                        {
                            new Acciones() 
                            {
                                Nombre = "Lectura",
                                Descripcion = "Derecho a ver la información",
                                Modulo = module
                            },
                            new Acciones()
                            {
                                Nombre = "Escritura",
                                Descripcion = "Derecho a escribir la información",
                                Modulo = module
                            }
                        
                        }
                    );
            }

            context.Acciones.AddRange(accionesList);

            IList<AccionesRole> accionesRol = new List<AccionesRole>();

            foreach (var role in adminUser.Roles)
            {
                foreach (var _action in accionesList)
                {
                    accionesRol.Add(new AccionesRole { RoleId = role.RoleId, Acciones = _action });
                }
            }

            context.AccionesRoles.AddRange(accionesRol);

            context.SaveChanges();
        }

        
    }
}