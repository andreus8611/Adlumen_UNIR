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
    public class PresupuestoProyectoController : ApiController
    {
        private IPresupuestoProyecto Context;

        
        public PresupuestoProyectoController(IPresupuestoProyecto _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Lectura")]
        // GET api/presupuestoproyecto/5
        public Object Get(int id)
        {
            return Context.GetPresupuestoProyectoData(id);
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Escritura")]
        // POST api/presupuestoproyecto
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
                case "addProyectoDonante":
                    {
                        Pry_Proyectos_Donantes proyectoDonante = new Pry_Proyectos_Donantes()
                        {
                            IdProyecto = (int)data.idProyecto,
                            IdDonante = (int)data.idDonante,
                            IdUsuarioResponsable = (int)data.idUsuarioResponsable,
                            Monto = (double?)data.monto,
                            UsuarioCreacion = userName,
                            FechaCreacion = DateTime.Now
                        };

                        Pry_Presupuesto presupuestoDonante = new Pry_Presupuesto {
                            IdTipoPresupuesto = 5,
                            IdProyecto = proyectoDonante.IdProyecto,
                            Monto = proyectoDonante.Monto,
                            IdDonante = proyectoDonante.IdDonante,
                            UsuarioCreacion = userName,
                            FechaCreacion = DateTime.Now
                        };

                        //guardar presupuesto

                        Context.addPresupuesto(presupuestoDonante);

                        //guardar proyecto donantes

                        Context.addProyectoDonante(proyectoDonante);
                    }
                    break;
                case "modifyProyectoDonante":
                    {
                        Pry_Proyectos_Donantes proyectoDonante = Context.GetProyectoDonante((int)data.idProyecto, (int)data.idDonante);
                        bool modified = false;

                        if (proyectoDonante.IdProyecto != (int)data.idProyecto)
                        {
                            proyectoDonante.IdProyecto = (int)data.idProyecto;
                            modified = true;
                        }
                        if (proyectoDonante.IdDonante != (int)data.idDonante)
                        {
                            proyectoDonante.IdDonante = (int)data.idDonante;
                            modified = true;
                        }
                        if (proyectoDonante.IdUsuarioResponsable != (int)data.idUsuarioResponsable)
                        {
                            proyectoDonante.IdUsuarioResponsable = (int)data.idUsuarioResponsable;
                            modified = true;
                        }
                        if (proyectoDonante.Monto != (double?)data.monto)
                        {
                            proyectoDonante.Monto = (double?)data.monto;
                            modified = true;
                        }

                        Pry_Presupuesto presupuestoDonante = Context.GetPresupuestoDonanteByProjectDonante(proyectoDonante.IdProyecto, proyectoDonante.IdDonante);

                        if (presupuestoDonante == null)
                        {
                            Pry_Presupuesto _presupuesto = new Pry_Presupuesto
                            {
                                IdTipoPresupuesto = 5,
                                IdProyecto = proyectoDonante.IdProyecto,
                                Monto = proyectoDonante.Monto,
                                IdDonante = proyectoDonante.IdDonante,
                                UsuarioCreacion = userName,
                                FechaCreacion = DateTime.Now

                            };

                            Context.addPresupuesto(_presupuesto);
                        }
                        else
                        {
                            if(presupuestoDonante.Monto != (double?)data.monto) 
                            {
                                presupuestoDonante.Monto = (double?)data.monto;
                            }
                        }

                        if (modified)
                        {
                            proyectoDonante.UsuarioModificacion = userName;
                            proyectoDonante.FechaModificacion = DateTime.Now;

                            if (presupuestoDonante != null)
                            {
                                presupuestoDonante.UsuarioModificacion = userName;
                                presupuestoDonante.FechaModificacion = DateTime.Now;
                            }
                            
                        }

                        Context.modifyData();
                    }
                    break;
                case "deleteProyectoDonante":
                {
                    var db = new Adlumen2SocEntities();
                    using (var tx = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var idProyecto = (int)data.idProyecto;
                            var idDonante = (int)data.idDonante;
                            var proyectoDonante = db.Pry_Proyectos_Donantes.FirstOrDefault(
                                x => x.IdProyecto == idProyecto && x.IdDonante == idDonante);

                            var budgets = db.Pry_Presupuesto.Where(p => p.IdProyecto == idProyecto && p.IdDonante == idDonante);
                            foreach (var budget in budgets)
                            {
                                db.Pry_Presupuesto.Remove(budget);
                            }

                            db.Pry_Proyectos_Donantes.Remove(proyectoDonante);

                            db.SaveChanges();
                            tx.Commit();
                        }
                        catch (Exception)
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }
                    break;
                case "modifyDistribucion":
                    {
                        int idPresupuesto = data.idPresupuesto != null ? (int)data.idPresupuesto : 0;

                        if (idPresupuesto == 0) //Add new
                        {
                            Pry_Presupuesto presupuesto = new Pry_Presupuesto()
                            {
                                IdTipoPresupuesto = (int)data.idTipo,
                                IdProyecto = (int)data.idProyecto,
                                Monto = (double?)data.monto,
                                UsuarioCreacion = userName,
                                FechaCreacion = DateTime.Now
                            };

                            Context.addPresupuesto(presupuesto);
                        }
                        else
                        {
                            Pry_Presupuesto presupuesto = Context.GetPresupuestoById(idPresupuesto);
                            bool modified = false;

                            if (presupuesto.Monto != (double?)data.monto)
                            {
                                presupuesto.Monto = (double?)data.monto;
                                modified = true;
                            }

                            if (modified)
                            {
                                presupuesto.UsuarioModificacion = userName;
                                presupuesto.FechaModificacion = DateTime.Now;
                            }

                            Context.modifyData();
                        }
                    }
                    break;
                case "addPresupuesto":
                    {
                        Pry_Presupuesto presupuesto = new Pry_Presupuesto()
                        {
                            IdTipoPresupuesto = (int)data.idTipoPresupuesto,
                            IdProyecto = (int)data.objetivoProyecto.idProyecto,
                            IdObjetivo = (int)data.idObjetivo,
                            IdDonante = (int?)data.idDonante,
                            Monto = (double?)data.presupuesto.monto,
                            UsuarioCreacion = userName,
                            FechaCreacion = DateTime.Now
                        };

                        Context.addPresupuesto(presupuesto);
                    }
                    break;
                case "modifyPresupuesto":
                    {
                        Pry_Presupuesto presupuesto = Context.GetPresupuestoById((int)data.presupuesto.idPresupuesto);
                        bool modified = false;

                        if (presupuesto.Monto != (double?)data.presupuesto.monto)
                        {
                            presupuesto.Monto = (double?)data.presupuesto.monto;
                            modified = true;
                        }

                        if (modified)
                        {
                            presupuesto.UsuarioModificacion = userName;
                            presupuesto.FechaModificacion = DateTime.Now;
                        }

                        Context.modifyData();
                    }
                    break;
                case "deletePresupuesto":
                    {
                        Pry_Presupuesto presupuesto = Context.GetPresupuestoById((int)data.idPresupuesto);
                        Context.deletePresupuesto(presupuesto);
                    }
                    break;
                case "addRecurso":
                    {
                        string code = Context.GetNextCode((int)data.idObjetivo);

                        Pry_Recursos recurso = new Pry_Recursos()
                        {
                            IdObjetivo = (int)data.idObjetivo,
                            Codigo = code,
                            Descripcion = (string)data.descripcion,
                            Tipo = (string)data.tipo,
                            Cantidad = (double?)data.cantidad,
                            UnidadMedida = (string)data.unidadMedida,
                            ValorUnitario = (double?)data.valorUnitario,
                            Monto = (double?)data.monto,
                            IDPARTIDAGASTO = (int)data.idpartidagasto,
                            CONTRAPARTIDA = (decimal?)data.contrapartida,
                            APORTEPROGRAMA = (decimal?)data.aporteprograma
                        };

                        Context.addRecurso(recurso);
                    }
                    break;
                case "modifyRecurso":
                    {
                        Pry_Recursos recurso = Context.GetRecursoById((int)data.idRecurso);
                        bool modified = false;

                        if (recurso.Descripcion != (string)data.descripcion)
                        {
                            recurso.Descripcion = (string)data.descripcion;
                            modified = true;
                        }
                        if (recurso.Tipo != (string)data.tipo)
                        {
                            recurso.Tipo = (string)data.tipo;
                            modified = true;
                        }
                        if (recurso.Cantidad != (double?)data.cantidad)
                        {
                            recurso.Cantidad = (double?)data.cantidad;
                            modified = true;
                        }
                        if (recurso.UnidadMedida != (string)data.unidadMedida)
                        {
                            recurso.UnidadMedida = (string)data.unidadMedida;
                            modified = true;
                        }
                        if (recurso.ValorUnitario != (double?)data.valorUnitario)
                        {
                            recurso.ValorUnitario = (double?)data.valorUnitario;
                            modified = true;
                        }
                        if (recurso.Monto != (double?)data.monto)
                        {
                            recurso.Monto = (double?)data.monto;
                            modified = true;
                        }
                        if (recurso.IDPARTIDAGASTO != (int)data.idpartidagasto)
                        {
                            recurso.IDPARTIDAGASTO = (int)data.idpartidagasto;
                            modified = true;
                        }
                        if (recurso.CONTRAPARTIDA != (decimal?)data.contrapartida)
                        {
                            recurso.CONTRAPARTIDA = (decimal?)data.contrapartida;
                            modified = true;
                        }
                        if (recurso.APORTEPROGRAMA != (decimal?)data.aporteprograma)
                        {
                            recurso.APORTEPROGRAMA = (decimal?)data.aporteprograma;
                            modified = true;
                        }

                        Context.modifyData();
                    }
                    break;
                case "deleteRecurso":
                    {
                        Pry_Recursos recurso = Context.GetRecursoById((int)data.idRecurso);
                        Context.deleteRecurso(recurso);
                    }
                    break;
                case "addCalendarioDonacion":
                    {
                        Pry_CalendarioDonaciones calendarioDonaciones = new Pry_CalendarioDonaciones()
                        {
                            IdDonante = (int)data.idDonante,
                            IdProyecto = (int)data.idProyecto,
                            Monto = (double)data.monto,
                            FechaProgramada = (DateTime)data.fechaProgramada
                        };

                        Context.addCalendarioDonacion(calendarioDonaciones);
                    }
                    break;
                case "modifyCalendarioDonacion":
                    {
                        Pry_CalendarioDonaciones calendarioDonaciones = Context.GetCalendarioDonacionById((int)data.idDonacion);
                        bool modified = false;

                        if (calendarioDonaciones.Monto != (double)data.monto)
                        {
                            calendarioDonaciones.Monto = (double)data.monto;
                            modified = true;
                        }
                        if (calendarioDonaciones.FechaProgramada != (DateTime)data.fechaProgramada)
                        {
                            calendarioDonaciones.FechaProgramada = (DateTime)data.fechaProgramada;
                            modified = true;
                        }
                        
                        Context.modifyData();
                    }
                    break;
                case "deleteCalendarioDonacion":
                    {
                        Pry_CalendarioDonaciones calendarioDonaciones = Context.GetCalendarioDonacionById((int)data.idDonacion);
                        Context.deleteCalendarioDonacion(calendarioDonaciones);
                    }
                    break;
            }
        }

    }
}
