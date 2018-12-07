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
using System.Data.Entity;
using Newtonsoft.Json;
using AdlumenMVC.WebUI.Models;
using AdlumenMVC.Models;

namespace AdlumenMVC.WebUI.Controllers
{
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiController
    {

        private IProjects Context;

        public ProjectsController(IProjects _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Lectura")]
        // GET api/projects
        public IEnumerable<Object> GetAll()
        {
            return Context.GetAll();
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Lectura")]
        // GET api/projects/5
        public Object Get(int id)
        {
            //Gets the full project data
            return Context.GetProyectoFullDataById(id);
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Lectura")]
        [Route("projectsbyclient/{id:int}")]
        public IEnumerable<object> GetbyClient(int id)
        {
            var context = Context as Adlumen2SocEntities;
            if (context != null)
            {
                context.Configuration.ProxyCreationEnabled = false;
            }
            var filteredProjects = Context.GetAll().Where(c => 
            { 
                var type = c.GetType();
                var property = type.GetProperty("CustomerId");
                return property.GetValue(c) as int? == id;
            }).ToList();
            return filteredProjects;
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Escritura")]
        [Route("activate/{id:int}")]
        public int Activate(int id)
        {
            try
            {
                var project = Context.GetProyectoById(id);
                project.IdEstado = 2;
                Context.modifyData();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Escritura")]
        [Route("close/{id:int}")]
        public int Close(int id)
        {
            try
            {
                var project = Context.GetProyectoById(id);
                project.IdEstado = 4;
                Context.modifyData();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Escritura")]
        public void Delete(int id)
        {
            try
            {
                var project = Context.GetProyectoById(id);
                Context.deleteProyecto(project);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Lectura")]
        [Route("getUsersByCompany/{id:int}")]
        public IEnumerable<object> GetUsersByCompany(int id)
        {
            try
            {
                using (var db = new Adlumen2SocEntities())
                {
                    var users = db.Database.SqlQuery<UserWithRole>(@"
SELECT su.IdUsuario, su.Nombre, anr.Name as Role
FROM Sys_Usuarios su
LEFT JOIN Sys_Usuarios_Empresas sue ON su.IdUsuario = sue.IdUsuario
LEFT JOIN AspNetUsers anu ON su.IdUsuario = anu.IdLocal
LEFT JOIN AspNetUserRoles anur ON anu.Id = anur.UserId
LEFT JOIN AspNetRoles anr ON anr.Id = anur.RoleId
WHERE sue.IdEmpresa = @p0
AND anr.Name IN ('digitador', 'evaluador', 'gerente')
AND anu.IdTenant = @p1", id, TenantUtil.GetTenantFromUrl().Id).ToList();

                    return users;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Escritura")]
        // POST api/projects
        public int Post(JObject value)
        {
            dynamic data = value;
            string action = (string)data.action;
            string userName = null;
            int elementId = 0;
            if (data.userId != null)
            {
                userName = Context.GetUsuarioById((int)data.userId).UserName;
            }

            switch (action)
            {
                case "addGeneral":
                    {
                        Pry_Proyectos proyecto = new Pry_Proyectos()
                        {
                            CustomerId = (int)data.proyecto.idCliente,
                            IdTipo = (int)data.proyecto.idTipo,
                            Codigo = (string)data.proyecto.codigo,
                            Nombre = (string)data.proyecto.nombre,
                            Area = (string)data.proyecto.area,
                            Region = (string)data.proyecto.region,
                            Beneficiarios = (string)data.proyecto.beneficiarios,
                            FechaInicio = (DateTime)data.proyecto.fechaInicio,
                            FechaFin = (DateTime)data.proyecto.fechaFin,
                            IdEmpresa = (int)data.proyecto.idEmpresa,
                            IdUsuarioResponsable = (int)data.proyecto.idUsuarioResponsable,
                            IdUsuarioDigitador = (int)data.proyecto.idUsuarioDigitador,
                            IdUsuarioEvaluador = (int)data.proyecto.idUsuarioEvaluador,
                            IDPROYECTOPADRE = data.proyecto.idproyectopadre != null ? (int)data.proyecto.idproyectopadre : (int?)null,
                            MONTOFINANCIAMIENTO = data.proyecto.montofinanciamiento != null ? (double)data.proyecto.montofinanciamiento : (double?)null,
                            MONTOCONTRAPARTIDA = data.proyecto.montocontrapartida != null ? (double)data.proyecto.montocontrapartida : (double?)null,
                            Presupuesto = data.proyecto.presupuesto != null ? (double)data.proyecto.presupuesto : (double?)null,
                            IdMoneda = data.proyecto.idMoneda != null ? (int)data.proyecto.idMoneda : (int?)null,
                            Logo = (string)data.proyecto.logo,
                            DiasNotificacion = data.proyecto.diasNotificacion != null ? (int)data.proyecto.diasNotificacion : 0,
                            IdEstado = 1 //Formulation
                        };

                        Context.addProyecto(proyecto);

                        //PRY_PERIODOSPROYECTOS
                        DateTime fechaInicio = proyecto.FechaInicio.Value;
                        DateTime fechaFin = proyecto.FechaFin.Value;
                        var tmpdate = new DateTime(fechaInicio.Year, fechaInicio.Month, 1);
                        int count = 1;
                        do
                        {
                            PRY_PERIODOSPROYECTOS periodoProyecto = new PRY_PERIODOSPROYECTOS
                            {
                                FechaFin = tmpdate.AddMonths(1).AddSeconds(-1),
                                FechaInicio = tmpdate,
                                IdProyecto = proyecto.IdProyecto,
                                Nombre = "Periodo " + count,
                                Secuencia = count,
                                Activo = true
                            };
                            Context.addPeriodoProyecto(periodoProyecto);
                            tmpdate = periodoProyecto.FechaFin.AddSeconds(+1);
                            count++;
                        } while (tmpdate <= fechaFin);

                        //Pry_Proyectos_NivelAceptacion
                        foreach (var _nivelaceptacion in data.proyecto.nivelesAceptacion )
                        {
                            Pry_Proyectos_NivelAceptacion nivelAceptacion = new Pry_Proyectos_NivelAceptacion
                            {
                                IdProyecto = proyecto.IdProyecto,
                                IdNivelAceptacion = (int)_nivelaceptacion.idNivelAceptacion,
                                Valor = (double)_nivelaceptacion.valor
                            };

                            Context.addNivelAceptacionProyecto(nivelAceptacion);
                        
                        }

                        elementId = proyecto.IdProyecto;
                    }
                    break;
                case "modifyGeneral":
                    {
                        Pry_Proyectos proyecto = Context.GetProyectoById((int)data.idProyecto);
                        bool modified = false;
                        bool datesModified = false;
                        if (!proyecto.Codigo.Equals((string)data.proyecto.codigo))
                        {
                            proyecto.Codigo = (string)data.proyecto.codigo;
                            modified = true;
                        }
                        if (!proyecto.Nombre.Equals((string)data.proyecto.nombre))
                        {
                            proyecto.Nombre = (string)data.proyecto.nombre;
                            modified = true;
                        }
                        if (!proyecto.Area.Equals((string)data.proyecto.area))
                        {
                            proyecto.Area = (string)data.proyecto.area;
                            modified = true;
                        }
                        if (!proyecto.Region.Equals((string)data.proyecto.region))
                        {
                            proyecto.Region = (string)data.proyecto.region;
                            modified = true;
                        }
                        if (!proyecto.Beneficiarios.Equals((string)data.proyecto.beneficiarios))
                        {
                            proyecto.Beneficiarios = (string)data.proyecto.beneficiarios;
                            modified = true;
                        }
                        if (proyecto.FechaInicio != (DateTime)data.proyecto.fechaInicio)
                        {
                            proyecto.FechaInicio = (DateTime)data.proyecto.fechaInicio;
                            modified = true;
                            datesModified = true;

                        }
                        if (proyecto.FechaFin != (DateTime)data.proyecto.fechaFin)
                        {
                            proyecto.FechaFin = (DateTime)data.proyecto.fechaFin;
                            modified = true;
                            datesModified = true;
                        }
                        if (proyecto.IdEmpresa != (int)data.proyecto.idEmpresa)
                        {
                            proyecto.IdEmpresa = (int)data.proyecto.idEmpresa;
                            modified = true;
                        }
                        if (proyecto.IdUsuarioResponsable != (int)data.proyecto.idUsuarioResponsable)
                        {
                            proyecto.IdUsuarioResponsable = (int)data.proyecto.idUsuarioResponsable;
                            modified = true;
                        }
                        if (proyecto.IdUsuarioDigitador != (int)data.proyecto.idUsuarioDigitador)
                        {
                            proyecto.IdUsuarioDigitador = (int)data.proyecto.idUsuarioDigitador;
                            modified = true;
                        }
                        if (proyecto.IdUsuarioEvaluador != (int)data.proyecto.idUsuarioEvaluador)
                        {
                            proyecto.IdUsuarioEvaluador = (int)data.proyecto.idUsuarioEvaluador;
                            modified = true;
                        }
                        if (proyecto.IDPROYECTOPADRE != (int?)data.proyecto.idproyectopadre)
                        {
                            proyecto.IDPROYECTOPADRE = (int?)data.proyecto.idproyectopadre;
                            modified = true;
                        }
                        if (proyecto.MONTOFINANCIAMIENTO != (double?)data.proyecto.montofinanciamiento)
                        {
                            proyecto.MONTOFINANCIAMIENTO = (double?)data.proyecto.montofinanciamiento;
                            modified = true;
                        }
                        if (proyecto.MONTOCONTRAPARTIDA != (double?)data.proyecto.montocontrapartida)
                        {
                            proyecto.MONTOCONTRAPARTIDA = (double?)data.proyecto.montocontrapartida;
                            modified = true;
                        }
                        if (proyecto.Presupuesto != (double?)data.proyecto.presupuesto)
                        {
                            proyecto.Presupuesto = (double?)data.proyecto.presupuesto;
                            modified = true;
                        }
                        if (proyecto.IdMoneda != (int?)data.proyecto.idMoneda)
                        {
                            proyecto.IdMoneda = (int?)data.proyecto.idMoneda;
                            modified = true;
                        }
                        if (proyecto.Logo != (string)data.proyecto.logo)
                        {
                            proyecto.Logo = (string)data.proyecto.logo;
                            modified = true;
                        }
                        if (proyecto.DiasNotificacion != (int)data.proyecto.diasNotificacion)
                        {
                            proyecto.DiasNotificacion = (int)data.proyecto.diasNotificacion;
                            modified = true;
                        }
                        if (proyecto.Latitude != (double?)data.proyecto.latitude)
                        {
                            proyecto.Latitude = (double?)data.proyecto.latitude;
                            modified = true;
                        }
                        if (proyecto.Longitude != (double?)data.proyecto.longitude)
                        {
                            proyecto.Longitude = (double?)data.proyecto.longitude;
                            modified = true;
                        }
                        if (proyecto.Problema != (string)data.proyecto.problema)
                        {
                            proyecto.Problema = (string)data.proyecto.problema;
                            modified = true;
                        }
                        if (proyecto.DescripcionProblema != (string)data.proyecto.descripcionProblema)
                        {
                            proyecto.DescripcionProblema = (string)data.proyecto.descripcionProblema;
                            modified = true;
                        }
                        if (proyecto.Justificacion != (string)data.proyecto.justificacion)
                        {
                            proyecto.Justificacion = (string)data.proyecto.justificacion;
                            modified = true;
                        }
                        
                        Context.modifyData();
                        if (datesModified)
                        {
                            List<PRY_PERIODOSPROYECTOS> periodosProyecto = Context.GetAllPeriodosByProyecto(proyecto.IdProyecto);
                            foreach (PRY_PERIODOSPROYECTOS periodoProyecto in periodosProyecto)
                            {
                                Context.deletePeriodoProyecto(periodoProyecto);
                            }
                            DateTime fechaInicio = proyecto.FechaInicio.Value;
                            DateTime fechaFin = proyecto.FechaFin.Value;
                            var tmpdate = new DateTime(fechaInicio.Year, fechaInicio.Month, 1);
                            int count = 1;
                            do
                            {
                                PRY_PERIODOSPROYECTOS periodoProyecto = new PRY_PERIODOSPROYECTOS
                                {
                                    FechaFin = tmpdate.AddMonths(1).AddSeconds(-1),
                                    FechaInicio = tmpdate,
                                    IdProyecto = proyecto.IdProyecto,
                                    Nombre = "Periodo " + count,
                                    Secuencia = count,
                                    Activo = true
                                };
                                Context.addPeriodoProyecto(periodoProyecto);
                                tmpdate = periodoProyecto.FechaFin.AddSeconds(+1);
                                count++;
                            } while (tmpdate <= fechaFin);
                        }
                        //Niveles de aceptación
                        JArray nivelesAceptacion = (JArray)data.nivelesAceptacion;
                        foreach (JObject oNivelAceptacion in nivelesAceptacion)
                        {
                            Pry_Proyectos_NivelAceptacion nivelAceptacionProyecto = Context.GetProyectoNivelAceptacion(proyecto.IdProyecto, (int)oNivelAceptacion["idNivelAceptacion"]);
                            double dValor = !string.IsNullOrEmpty(oNivelAceptacion["valor"].ToString()) ? (double)oNivelAceptacion["valor"] : 0;
                            if (nivelAceptacionProyecto == null)
                            {
                                nivelAceptacionProyecto = new Pry_Proyectos_NivelAceptacion()
                                {
                                    IdProyecto = proyecto.IdProyecto,
                                    IdNivelAceptacion = (int)oNivelAceptacion["idNivelAceptacion"],
                                    Valor = dValor
                                };
                                Context.addNivelAceptacionProyecto(nivelAceptacionProyecto);
                            }
                            else
                            {
                                if (nivelAceptacionProyecto.Valor != dValor)
                                {
                                    nivelAceptacionProyecto.Valor = dValor;
                                    Context.modifyData();
                                }
                            }
                        }

                        elementId = proyecto.IdProyecto;
                    }

                    break;
                case "deleteProyecto":
                    {
                        Pry_Proyectos proyecto = Context.GetProyectoById((int)data.idProyecto);
                        Context.deleteProyecto(proyecto);
                    }
                    break;
                case "addObjetivo":
                    {
                        string code = Context.GetNextObjetivoCode((int)data.idPadre);

                        Pry_Objetivos objetivo = new Pry_Objetivos()
                        {
                            IdPadre = (int)data.idPadre,
                            IdObjetivoClase = (int)data.idObjetivoClase,
                            Codigo = code,
                            Eliminado = false,
                            IdProyecto = (int)data.idProyecto,
                            Descripcion = (string)data.descripcion
                        };

                        Context.addObjetivo(objetivo);
                        elementId = objetivo.IdObjetivo;
                    }
                    break;
                case "modifyObjetivo":
                    {
                        Pry_Objetivos objetivo = Context.GetObjetivoById((int)data.idObjetivo);
                        bool modified = false;

                        var id = value["objetivo"]["$ref"]?.ToString();
                        var token = $"$.objetivoClase.pry_Objetivos[?(@.$id == '{id}')]";
                        dynamic subdata = value.SelectToken(token);

                        if (objetivo.IdPadre != (int)data.idPadre)
                        {
                            objetivo.IdPadre = (int)data.idPadre;
                            modified = true;
                        }
                        if (objetivo.IdObjetivoClase != (int)data.idObjetivoClase)
                        {
                            objetivo.IdObjetivoClase = (int)data.idObjetivoClase;
                            modified = true;
                        }
                        if (!objetivo.Codigo.Equals((string)data.codigo))
                        {
                            objetivo.Codigo = (string)data.codigo;
                            modified = true;
                        }
                        if (objetivo.Descripcion != (string)data.descripcion)
                        {
                            objetivo.Descripcion = (string)data.descripcion;
                            modified = true;
                        }
                        if (objetivo.IdProyecto != (int)data.idProyecto)
                        {
                            objetivo.IdProyecto = (int)data.idProyecto;
                            modified = true;
                        }
                        if (objetivo.Eliminado != (bool?)subdata.eliminado)
                        {
                            objetivo.Eliminado = subdata.eliminado != null ? (bool)subdata.eliminado : false;
                            modified = true;
                        }
                        if (objetivo.IdResponsable != (int?)subdata.idResponsable)
                        {
                            objetivo.IdResponsable = (int?)subdata.idResponsable;
                            modified = true;
                        }
                        if (objetivo.FechaInicio != (DateTime?)subdata.fechaInicio)
                        {
                            objetivo.FechaInicio = (DateTime?)subdata.fechaInicio;
                            modified = true;
                        }
                        if (objetivo.FechaFin != (DateTime?)subdata.fechaFin)
                        {
                            objetivo.FechaFin = (DateTime?)subdata.fechaFin;
                            modified = true;
                        }
                        if (objetivo.CustomerId != (int?)subdata.customerId)
                        {
                            objetivo.CustomerId = (int?)subdata.customerId;
                            modified = true;
                        }
                        if (objetivo.Ponderado != (double?)subdata.ponderado)
                        {
                            objetivo.Ponderado = (double?)subdata.ponderado;
                            modified = true;
                        }

                        Context.modifyData();
                    }
                    break;
                case "deleteObjetivo":
                    {
                        Pry_Objetivos objetivo = Context.GetObjetivoById((int)data.idObjetivo);
                        Context.deleteObjetivo(objetivo);
                    }
                    break;
                case "addIndicador":
                    {
                        Pry_Objetivos objetivo = Context.GetObjetivoById((int)data.idObjetivo);
                        int idSubtipo = 0;

                        if (objetivo.IdObjetivoClase == 1) //GENERAL PURPOSE
                            idSubtipo = 3; //IMPACT
                        if (objetivo.IdObjetivoClase == 2) //GENERAL PURPOSE
                            idSubtipo = 4; //EFFECT
                        if (objetivo.IdObjetivoClase == 3) //RESULTS
                            idSubtipo = 10; //RESULT
                        if (objetivo.IdObjetivoClase == 4) //PRODUCTS
                            idSubtipo = 5; //PRODUCTS
                        if (objetivo.IdObjetivoClase == 5) //ACTIVITIES
                            idSubtipo = 6; //ACTIVITY

                        Pry_IndicadoresTipos indicadorSubTipo = Context.GetIndicadorTipo(idSubtipo);
                        Pry_IndicadoresTipos indicadorTipo = Context.GetIndicadorTipo(indicadorSubTipo.IdPadre.Value);

                        int nextCode = Context.GetNextIndicatorCode(objetivo.IdObjetivo, indicadorSubTipo.IdTipo, indicadorSubTipo.IdPadre.Value);
                        string indicadorCode = indicadorTipo.Myme + indicadorSubTipo.Myme + nextCode;

                        Pry_Indicadores indicador = new Pry_Indicadores()
                        {
                            IdObjetivo = (int)data.idObjetivo,
                            Codigo = indicadorCode,
                            IdTipo = indicadorTipo.IdTipo,
                            IdSubTipo = indicadorSubTipo.IdTipo,
                            Descripcion = (string)data.descripcion,
                            Definicion = (string)data.definicion,
                            Objetivo = (string)data.objetivo,
                            Cualidades = (string)data.cualidades,
                            Cobertura = (string)data.cobertura,
                            IdResponsableIndicador = (int?)data.idResponsableIndicador,
                            FechaInicio = (DateTime?)data.fechaInicio,
                            FechaFin = (DateTime?)data.fechaFin,
                            Base = (double)data["base"],
                            Meta = (double)data.meta,
                            UnidadMedida = (string)data.unidadMedida,
                            Porcentual = data.porcentual != null ? (bool)data.porcentual : false,
                            UnidadOperativa = (string)data.unidadOperativa,
                            UnidadOperativaId = (string)data.unidadOperativaId,
                            PalabrasClave = (string)data.palabrasClave
                        };

                        Context.addIndicador(indicador);

                        //added by Ernesto Duarte --save pry_IndicadoresVerificadores

                        List<Pry_IndicadoresVerificadores> verificators = new List<Pry_IndicadoresVerificadores>();

                        foreach(var verificator in data.pry_IndicadoresVerificadores)
                        {
                            
                            Pry_IndicadoresVerificadores _verificator = new Pry_IndicadoresVerificadores { 
                                IdIndicador = indicador.IdIndicador,
                                Descripcion = (string)verificator.descripcion
                            };

                            verificators.Add(_verificator);
                        }

                        Context.addVerificadores(verificators);

                        elementId = indicador.IdIndicador;
                    }
                    break;
                case "modifyIndicador":
                    {
                        Pry_Indicadores indicador = Context.GetIndicadorById((int)data.idIndicador);
                        bool modified = false;

                        if (indicador.Descripcion != (string)data.descripcion)
                        {
                            indicador.Descripcion = (string)data.descripcion;
                            modified = true;
                        }
                        if (indicador.Definicion != (string)data.definicion)
                        {
                            indicador.Definicion = (string)data.definicion;
                            modified = true;
                        }
                        if (indicador.Objetivo != (string)data.objetivo)
                        {
                            indicador.Objetivo = (string)data.objetivo;
                            modified = true;
                        }
                        if (indicador.Cualidades != (string)data.cualidades)
                        {
                            indicador.Cualidades = (string)data.cualidades;
                            modified = true;
                        }
                        if (indicador.Cobertura != (string)data.cobertura)
                        {
                            indicador.Cobertura = (string)data.cobertura;
                            modified = true;
                        }
                        if (indicador.IdResponsableIndicador != (int?)data.idResponsableIndicador)
                        {
                            indicador.IdResponsableIndicador = (int?)data.idResponsableIndicador;
                            modified = true;
                        }
                        if (indicador.FechaInicio != (DateTime?)data.fechaInicio)
                        {
                            indicador.FechaInicio = (DateTime?)data.fechaInicio;
                            modified = true;
                        }
                        if (indicador.FechaFin != (DateTime?)data.fechaFin)
                        {
                            indicador.FechaFin = (DateTime?)data.fechaFin;
                            modified = true;
                        }
                        if (indicador.Base != (double)data["base"])
                        {
                            indicador.Base = (double)data["base"];
                            modified = true;
                        }
                        if (indicador.Meta != (double)data.meta)
                        {
                            indicador.Meta = (double)data.meta;
                            modified = true;
                        }
                        if (indicador.UnidadMedida != (string)data.unidadMedida)
                        {
                            indicador.UnidadMedida = (string)data.unidadMedida;
                            modified = true;
                        }
                        if (indicador.UnidadOperativa != (string)data.unidadOperativa)
                        {
                            indicador.UnidadOperativa = (string)data.unidadOperativa;
                            modified = true;
                        }
                        if (indicador.UnidadOperativaId != (string)data.unidadOperativaId)
                        {
                            indicador.UnidadOperativaId = (string)data.unidadOperativaId;
                            modified = true;
                        }
                        if (indicador.Porcentual != (data.porcentual != null ? (bool)data.porcentual : false))
                        {
                            indicador.Porcentual = data.porcentual != null ? (bool)data.porcentual : false;
                            modified = true;
                        }
                        if (indicador.PalabrasClave != (string)data.palabrasClave)
                        {
                            indicador.PalabrasClave = (string)data.palabrasClave;
                            modified = true;
                        }
                        if (indicador.Ponderado != (double?)data.ponderado)
                        {
                            indicador.Ponderado = (double?)data.ponderado;
                            modified = true;
                        }
                        
                        List<Pry_IndicadoresVerificadores> verificators = new List<Pry_IndicadoresVerificadores>();

                         foreach(var verificator in data.pry_IndicadoresVerificadores)
                        {
                            
                            Pry_IndicadoresVerificadores _verificator = new Pry_IndicadoresVerificadores { 
                                IdIndicador = indicador.IdIndicador,
                                Descripcion = (string)verificator.descripcion
                            };

                            verificators.Add(_verificator);
                            
                        }

                         Context.modifyVerificadores(indicador.IdIndicador, verificators);

                        Context.modifyData();
                        elementId = indicador.IdIndicador;
                    }
                    break;
                case "deleteIndicador":
                    {
                        Pry_Indicadores indicador = Context.GetIndicadorById((int)data.idIndicador);
                        Context.deleteIndicador(indicador);
                    }
                    break;
                case "addSupuesto":
                    {
                        Pry_Supuestos supuesto = new Pry_Supuestos()
                        {
                            IdObjetivo = (int)data.idObjetivo,
                            Descripcion = (string)data.descripcion,
                            Impacto =  (int)data.impacto == 1 ? true : false,
                            PlanContingencia = (string)data.planContingencia
                        };

                        Context.addSupuesto(supuesto);
                        elementId = supuesto.IdSupuesto;
                    }
                    break;
                case "modifySupuesto":
                    {
                        Pry_Supuestos supuesto = Context.GetSupuestoById((int)data.idSupuesto);
                        bool modified = false;

                        if (supuesto.Descripcion != (string)data.descripcion)
                        {
                            supuesto.Descripcion = (string)data.descripcion;
                            modified = true;
                        }
                        if (supuesto.Impacto != ((int)data.impacto == 1 ? true : false))
                        {
                            supuesto.Impacto = ((int)data.impacto == 1 ? true : false);
                            modified = true;
                        }
                        if (supuesto.PlanContingencia != (string)data.planContingencia)
                        {
                            supuesto.PlanContingencia = (string)data.planContingencia;
                            modified = true;
                        }
                        
                        Context.modifyData();

                    }
                    break;
                case "deleteSupuesto":
                    {
                        Pry_Supuestos supuesto = Context.GetSupuestoById((int)data.idSupuesto);
                        Context.deleteSupuesto(supuesto);

                    }
                    break;
                case "addInforme":
                    {
                        Pry_Informes informe = new Pry_Informes()
                        {
                            IdProyecto = (int)data.idProyecto,
                            Descripcion = (string)data.descripcion,
                            FechaProgramada = (DateTime)data.fechaProgramada,
                            PresupuestoMeta = data.presupuestoMeta != 0 ? (double)data.presupuestoMeta : 0,
                            AvanceMeta = data.avanceMeta != 0 ? (double)data.avanceMeta : 0
                        };

                        Context.addInforme(informe);
                        elementId = informe.IdInforme;
                    }
                    break;
                case "modifyInforme":
                    {
                        Pry_Informes informe = Context.GetInformeById((int)data.idInforme);
                        bool modified = false;

                        if (informe.Descripcion != (string)data.descripcion)
                        {
                            informe.Descripcion = (string)data.descripcion;
                            modified = true;
                        }
                        if (informe.FechaProgramada != (DateTime)data.fechaProgramada)
                        {
                            informe.FechaProgramada = (DateTime)data.fechaProgramada;
                            modified = true;
                        }
                        if (informe.PresupuestoMeta != (data.presupuestoMeta != 0 ? (double)data.presupuestoMeta : 0))
                        {
                            informe.PresupuestoMeta = data.presupuestoMeta != 0 ? (double)data.presupuestoMeta : 0;
                            modified = true;
                        }
                        if (informe.AvanceMeta != (data.avanceMeta != 0 ? (double)data.avanceMeta : 0))
                        {
                            informe.AvanceMeta = data.avanceMeta != 0 ? (double)data.avanceMeta : 0;
                            modified = true;
                        }

                        Context.modifyData();
                        elementId = informe.IdInforme;
                    }
                    break;
                case "deleteInforme":
                    {
                        Pry_Informes informe = Context.GetInformeById((int)data.idInforme);
                        Context.deleteInforme(informe);

                    }
                    break;
            }

            return elementId;
        }

    }
}
