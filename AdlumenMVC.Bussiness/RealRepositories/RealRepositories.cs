using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Models.AbstractRepository;
using AdlumenMVC.Models.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AdlumenMVC.Models.Models;
using System.IO;

namespace AdlumenMVC.Bussiness.RealRepositories
{
    public class TenantsRepository : ITenantsRepository
    {
        private IContextRepository Context;

        public TenantsRepository(IContextRepository _context)
        {
            Context = _context;
        }

        public Tenant GetById(int id)
        {
            return Context.Tenants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Tenant> GetAll()
        {
            return Context.Tenants.ToList();
        }

        public void Create(Tenant tenant)
        {
            Context.Add(tenant);
            Context.SaveChanges();
        }

        public void Update(Tenant tenant)
        {
            ((DbContext)Context).Entry(tenant).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(Tenant tenant)
        {
            Context.Delete(tenant);
            Context.SaveChanges();
        }
    }
    #region Facilitadores

    public class FacilitadorRepository : IFacilitadores
    {
        private IContextRepository Context;

        public FacilitadorRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Object> GetFacilitadores()
        {
            return (from facilitador in Context.Pry_Facilitadores
                    where facilitador.Status == 1
                    select new
                    {
                        facilitador.IdFacilitador,
                        facilitador.Nombre,
                        facilitador.Email,
                        facilitador.Telefono,
                        facilitador.Direccion
                    }).AsEnumerable();
        }


        public Pry_Facilitadores GetFacilitadorById(int idFacilitador)
        {
            return Context.Pry_Facilitadores.FirstOrDefault(facilitador => facilitador.IdFacilitador == idFacilitador);
        }

        public void addFacilitador(Pry_Facilitadores facilitador)
        {
            Context.Add(facilitador);
            Context.SaveChanges();
        }

        public void updateFacilitador(Pry_Facilitadores facilitador)
        {
            var bdFacilitador = Context.Pry_Facilitadores.FirstOrDefault(b => b.IdFacilitador == facilitador.IdFacilitador);
            bdFacilitador.Nombre = facilitador.Nombre;
            bdFacilitador.Email = facilitador.Email;
            bdFacilitador.Telefono = facilitador.Telefono;
            bdFacilitador.Direccion = facilitador.Direccion;
            bdFacilitador.Status = facilitador.Status;
            Context.SaveChanges();
        }

        public void deleteFacilitador(Pry_Facilitadores facilitador)
        {
            Context.Delete(facilitador);
            Context.SaveChanges();
        }
    }
    #endregion


    #region Capacitaciones
    public class CapacitacionRepository : ICapacitaciones
    {
        private IContextRepository Context;

        public CapacitacionRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Object> GetCapacitaciones()
        {
            return Context.Pry_Capacitaciones.Join(Context.Pry_Facilitadores,
                capacitacion => capacitacion.IdFacilitador,
                facilitador => facilitador.IdFacilitador,
                (capacitacion, facilitador) => new
                {
                    capacitacion.IdCapacitacion,
                    facilitador.Nombre,
                    capacitacion.NombreCapacitacion,
                    capacitacion.DescripcionCapacitacion,
                    capacitacion.FechaInicio,
                    capacitacion.FechaFinal
                }).ToList();
        }

        public Pry_Capacitaciones GetCapacitacionById(int idCapacitacion)
        {
            return Context.Pry_Capacitaciones.FirstOrDefault(c => c.IdCapacitacion == idCapacitacion);
        }

        public void addCapacitacion(Pry_Capacitaciones capacitacion)
        {
            Context.Add(capacitacion);
            Context.SaveChanges();
        }

        public void updateCapacitacion(Pry_Capacitaciones capacitacion)
        {
            var bdCapacitacion = Context.Pry_Capacitaciones.FirstOrDefault(b => b.IdCapacitacion == capacitacion.IdCapacitacion);
            bdCapacitacion.IdFacilitador = capacitacion.IdFacilitador;
            bdCapacitacion.NombreCapacitacion = capacitacion.NombreCapacitacion;
            bdCapacitacion.DescripcionCapacitacion = capacitacion.DescripcionCapacitacion;
            bdCapacitacion.FechaInicio = capacitacion.FechaInicio;
            bdCapacitacion.FechaFinal = capacitacion.FechaFinal;
            bdCapacitacion.Status = capacitacion.Status;
            Context.SaveChanges();
        }

        public void deleteCapacitacion(Pry_Capacitaciones capacitacion)
        {
            Context.Delete(capacitacion);
            Context.SaveChanges();
        }

    }
    #endregion

    #region Objetivos
    public class ObjetivosRepository : IObjetivos
    {
        private IContextRepository Context;

        public ObjetivosRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Object> GetObjetivos()
        {
            return (from objetivo in Context.Pry_Objetivos
                    where objetivo.IdObjetivoClase == 3
                    select new
                    {
                        objetivo.IdObjetivo,
                        objetivo.Descripcion
                    }).AsEnumerable();
        }

    }
    #endregion


    #region Beneficiarios
    public class BeneficiariosRepository : IBeneficiarios
    {
        private IContextRepository Context;

        public BeneficiariosRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Object> GetBeneficiarios()
        {
            return Context.Pry_Beneficiarios.Join(Context.Pry_Objetivos,
                beneficiario => beneficiario.IdObjetivo,
                objetivo => objetivo.IdObjetivo,
                (beneficiario, objetivo) => new
                {
                    beneficiario.IdBeneficiario,
                    beneficiario.IdObjetivo,
                    objetivo.Descripcion,
                    beneficiario.Nombre,
                    beneficiario.Email,
                    beneficiario.Telefono,
                    beneficiario.Direccion,
                    beneficiario.extensionTerritorial
                }).ToList();
        }

        public Pry_Beneficiarios GetBeneficiarioById(int idBeneficiario)
        {
            return Context.Pry_Beneficiarios.FirstOrDefault(b => b.IdBeneficiario == idBeneficiario);
        }

        public void addBeneficiario(Pry_Beneficiarios beneficiario)
        {
            Context.Add(beneficiario);
            Context.SaveChanges();
        }

        public void updateBeneficiario(Pry_Beneficiarios beneficiario)
        {
            var bdBeneficiario = Context.Pry_Beneficiarios.FirstOrDefault(b => b.IdBeneficiario == beneficiario.IdBeneficiario);
            bdBeneficiario.IdObjetivo = beneficiario.IdObjetivo;
            bdBeneficiario.Nombre = beneficiario.Nombre;
            bdBeneficiario.Email = beneficiario.Email;
            bdBeneficiario.Telefono = beneficiario.Telefono;
            bdBeneficiario.Direccion = beneficiario.Direccion;
            bdBeneficiario.extensionTerritorial = beneficiario.extensionTerritorial;
            bdBeneficiario.Status = beneficiario.Status;
            Context.SaveChanges();
        }

        public void deleteBeneficiario(Pry_Beneficiarios beneficiario)
        {
            Context.Delete(beneficiario);
            Context.SaveChanges();
        }

    }
    #endregion

    #region
    public class CapacitacionBeneficiariosRepository : ICapacitacionBeneficiario
    {
        private IContextRepository Context;

        public CapacitacionBeneficiariosRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Object> GetBeneficiariosCapacitaciones()
        {
            return (from beneficiarioCapacitacion in Context.Pry_CapacitacionBeneficiario
                    join capacitacion in Context.Pry_Capacitaciones on beneficiarioCapacitacion.IdCapacitacion equals capacitacion.IdCapacitacion
                    join beneficiario in Context.Pry_Beneficiarios on beneficiarioCapacitacion.IdBeneficiario equals beneficiario.IdBeneficiario
                    where beneficiarioCapacitacion.Status == 1
                    select new
                    {
                        beneficiarioCapacitacion.IdCapacitacionBeneficiario,
                        capacitacion.IdCapacitacion,
                        capacitacion.NombreCapacitacion,
                        beneficiario.IdBeneficiario,
                        beneficiario.Nombre,
                        beneficiarioCapacitacion.FechaInscripcion

                    }).AsEnumerable();
        }

        public Pry_CapacitacionBeneficiario GetBeneficiarioCapacitacionById(int idCapacitacionBeneficiario)
        {
            return Context.Pry_CapacitacionBeneficiario.FirstOrDefault(b => b.IdCapacitacionBeneficiario == idCapacitacionBeneficiario);
        }

        public void addBeneficiarioCapacitacion(Pry_CapacitacionBeneficiario beneficiarioCapacitacion)
        {
            Context.Add(beneficiarioCapacitacion);
            Context.SaveChanges();
        }

        public void deleteBeneficiarioCapacitacion(Pry_CapacitacionBeneficiario beneficiarioCapacitacion)
        {
            Context.Delete(beneficiarioCapacitacion);
            Context.SaveChanges();
        }
    }
    #endregion

    #region Productividad Beneficiario
    public class ProductividadBeneficiarioRepository : IProductividadBeneficiario
    {
        private IContextRepository Context;

        public ProductividadBeneficiarioRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Object> GetProductividadBeneficiario()
        {
            return (from productividad in Context.Pry_ProductividadBeneficiario
                    select new
                    {
                        productividad.IdProductividadBeneficiario,
                        productividad.AreaSembrada,
                        productividad.CultivoSembrado,
                        productividad.CantidadSembrada,
                        productividad.ProduccionCultivo
                    }).AsEnumerable();
        }

        public Pry_ProductividadBeneficiario GetProductividadBeneficiarioById(int idProductividadBeneficiario)
        {
            return Context.Pry_ProductividadBeneficiario.FirstOrDefault(productividad => productividad.IdProductividadBeneficiario == idProductividadBeneficiario);
        }

        public void addProductividadBeneficiario(Pry_ProductividadBeneficiario productividad)
        {
            Context.Add(productividad);
            Context.SaveChanges();
        }

        public void deleteProductividadBeneficiario(Pry_ProductividadBeneficiario productividad)
        {
            Context.Delete(productividad);
            Context.SaveChanges();
        }

    }
    #endregion

    #region Periodos Repository

    public class PeriodosProyectosRepository : IPeriodosProyectos
    {

        //Interface de acceso a datos

        private IContextRepository Context;

        public PeriodosProyectosRepository(IContextRepository _Context)
        {

            //iniciando la variable de la interface

            Context = _Context;
        }

        //Devuelve todos los períodos

        public IEnumerable<Object> GetAll()
        {

            return Context.pry_periodosproyectos.Join(Context.pry_proyectos,
                period => period.IdProyecto,
                project => project.IdProyecto,
                (period, project) => new
                {
                    period.IdPeriodo,
                    period.Nombre,
                    period.FechaInicio,
                    period.FechaFin,
                    project.IdProyecto,
                    period.Activo,
                    projectName = project.Nombre
                }).ToList();
        }

        //Devuelve todos los Períodos de un Proyecto.

        public List<PRY_PERIODOSPROYECTOS> GetAllPeriodsByProject(int IdProject)
        {
            return Context.pry_periodosproyectos.Where(p => p.IdProyecto == IdProject).OrderBy(p => p.FechaInicio).ToList();
        }

        //Devolver periodo por el Id del proyecto y del periodo

        public PRY_PERIODOSPROYECTOS GetPeriodById(int idProyecto, int idPeriodo)
        {
            var periodo = Context.pry_periodosproyectos.FirstOrDefault(p => p.IdPeriodo == idPeriodo && p.IdProyecto == idProyecto);

            return periodo;
        }

        //Procedimiento para cambiar estado del período.

        public void PeriodChangeState(int idPeriodo, int idProyecto)
        {
            var isActive = Context.pry_periodosproyectos.FirstOrDefault(p => p.IdPeriodo == idPeriodo && p.IdProyecto == idProyecto).Activo;

            if (!isActive == true)
            {

                var periodo = Context.pry_periodosproyectos.FirstOrDefault(p => p.IdPeriodo == idPeriodo && p.IdProyecto == idProyecto);

                periodo.Activo = true;

                Context.SaveChanges();
            }
            else
            {
                Exception ex = new Exception("Err000001");

                throw ex;

            }
        }
    }

    #endregion

    #region Projects Repository

    public class ProjectRepository : IProjects
    {

        //declaramos una variables del repositorio abstracto del modelo

        private IContextRepository Context;

        //inicializamos la clase del repositorio real y le pasamos un contexto del modelo

        public ProjectRepository(IContextRepository _Context)
        {

            Context = _Context;
        }

        //devuelve el listado de los proyectos

        public IEnumerable<Object> GetAll()
        {
            var data = Context.pry_proyectos
                .Include("Pry_ProyectosTipos")
                .Include("Pry_ProyectosEstados");

            var projects = (from pry in data
                            where pry.Eliminado == false
                            select new
                            {
                                //projects fields
                                pry.IdProyecto,
                                pry.Codigo,
                                pry.Nombre,
                                manager = pry.Sys_Usuarios.Nombre,
                                pry.Presupuesto,
                                pry.Area,
                                pry.Region,
                                pry.Beneficiarios,
                                pry.FechaInicio,
                                pry.FechaFin,
                                pry.IdEstado,
                                pry.Latitude,
                                pry.Longitude,
                                pry.Logo,
                                pry.Eliminado,
                                pry.CustomerId,
                                pry.M_Monedas,
                                type = pry.Pry_ProyectosTipos,
                                status = pry.Pry_ProyectosEstados,
                                nivelesAceptacion = pry.Pry_Proyectos_NivelAceptacion.Select(pn => new { pn.IdNivelAceptacion, pn.Pry_NivelAceptacion.Descripcion, pn.Valor }),
                                disbursementCalendar = Context.pry_calendariodonaciones.Where(c => c.IdProyecto == pry.IdProyecto).Select(c => new { c.IdDonacion, c.Org_Donantes.Nombre, c.Monto, c.FechaProgramada }),
                                //objectives fields
                                objectives = Context.pry_objetivos.Where(objective => objective.IdProyecto == pry.IdProyecto).Select(objective => new
                                {
                                    objective.IdObjetivo,
                                    objective.IdPadre,
                                    objective.Codigo,
                                    objective.Descripcion,
                                    objective.FechaInicio,
                                    objective.FechaFin,
                                    objective.Progreso,
                                    objective.Efectividad,
                                    objective.Eficacia,
                                    objective.Eficiencia,
                                    objective.IdNivelAceptacion,
                                    objective.IdNivelAceptacionEfectividad,
                                    objective.IdNivelAceptacionEficacia,
                                    objective.IdNivelAceptacionEficiencia,
                                    objectiveType = new { objective.Pry_ObjetivosClase.IdObjetivoClase, objective.Pry_ObjetivosClase.Descripcion },
                                    //budget amount
                                    budgets = pry.Pry_Presupuesto.FirstOrDefault(p => p.IdObjetivo == objective.IdObjetivo && p.IdTipoPresupuesto == 1).Monto,
                                    //budget executed
                                    expensives = pry.Pry_Presupuesto.FirstOrDefault(budget => budget.IdObjetivo == objective.IdObjetivo && budget.IdTipoPresupuesto == 1)
                                    .Pry_Movimientos.Sum(budget => budget.APORTEMONEDALOCAL + budget.APORTEPROGRAMA),
                                    //indicators
                                    indicators = Context.pry_indicadores.Where(indicator => indicator.IdObjetivo == objective.IdObjetivo).Select(indicator => new
                                    {
                                        indicator.IdIndicador,
                                        indicator.Codigo,
                                        type = Context.pry_indicadorestipos.FirstOrDefault(indicatorType => indicatorType.IdTipo == indicator.IdTipo).Descripcion,
                                        subtype = indicator.Pry_IndicadoresTipos.Descripcion,
                                        indicator.Descripcion,
                                        indicator.Base,
                                        indicator.Meta,
                                        indicator.FechaInicio,
                                        indicator.FechaFin,
                                        periods = Context.pry_periodosproyectos.Where(p => p.FechaInicio >= indicator.FechaInicio && p.FechaFin <= indicator.FechaFin && p.IdProyecto == pry.IdProyecto).Select(p => new { p.IdPeriodo, p.Nombre }),
                                        indicator.UnidadMedida,
                                        indicator.UnidadOperativa,
                                        indicator.IdDatosMuestra,
                                        samples = indicator.Pry_DatosMuestras.Select(sample => new { sample.IdDatosMuestra, sample.Fecha, sample.Logro, sample.IdPeriodo, sample.Eficacia, progressColor = Context.pry_nivelaceptacion.FirstOrDefault(n => n.IdNivelAceptacion == sample.IdNivelAceptacionEficacia).Color })
                                    }),
                                    //supuestos
                                    assumptions = objective.Pry_Supuestos.Select(assumption => new { assumption.Descripcion, assumption.Impacto, assumption.PlanContingencia }),
                                    //Resources (only for activities)
                                    resources = objective.Pry_Recursos.Where(r => r.IdObjetivo == objective.IdObjetivo).Select(r => new { r.Descripcion, r.Tipo, r.Cantidad, r.UnidadMedida }),
                                    progressColor = Context.pry_nivelaceptacion.FirstOrDefault(n => n.IdNivelAceptacion == objective.IdNivelAceptacion).Color,
                                    efectividadColor = Context.pry_nivelaceptacion.FirstOrDefault(n => n.IdNivelAceptacion == objective.IdNivelAceptacionEfectividad).Color,
                                    eficaciaColor = Context.pry_nivelaceptacion.FirstOrDefault(n => n.IdNivelAceptacion == objective.IdNivelAceptacionEficacia).Color,
                                    eficienciaColor = Context.pry_nivelaceptacion.FirstOrDefault(n => n.IdNivelAceptacion == objective.IdNivelAceptacionEficiencia).Color
                                })
                            }).AsEnumerable();

            //return (from pry in Context.pry_proyectos select new { pry.IdProyecto, pry.Nombre }).AsEnumerable(); 

            return projects;
        }

        public Pry_Proyectos GetProyectoById(int idProject)
        {
            return Context.pry_proyectos.FirstOrDefault(pry => pry.IdProyecto == idProject);
        }

        public Pry_Proyectos GetProjects(int idUsuario)
        {

            return (Context.pry_proyectos.FirstOrDefault(pry => pry.IdUsuarioResponsable == idUsuario));
        }

        //devuelve el proyecto por id
        public Object GetProyectoFullDataById(int idProject)
        {
            Pry_Proyectos pry_proyecto = Context.pry_proyectos.FirstOrDefault(pry => pry.IdProyecto == idProject);

            Proyecto proyecto = new Proyecto()
            {
                idProyecto = pry_proyecto.IdProyecto,
                proyecto = pry_proyecto
            };

            List<NivelAceptacionProyecto> pry_nivelesAceptacion = new List<NivelAceptacionProyecto>();

            foreach (Pry_NivelAceptacion nivelesAceptacion in Context.pry_nivelaceptacion.OrderBy(a => a.IdNivelAceptacion))
            {
                Pry_Proyectos_NivelAceptacion pry_nivelActual = Context.pry_proyectos_nivelaceptacion.Where(a => a.IdProyecto == pry_proyecto.IdProyecto && a.IdNivelAceptacion == nivelesAceptacion.IdNivelAceptacion).FirstOrDefault();
                pry_nivelesAceptacion.Add(new NivelAceptacionProyecto()
                {
                    idNivelAceptacion = nivelesAceptacion.IdNivelAceptacion,
                    nombre = nivelesAceptacion.Nombre = nivelesAceptacion.Nombre,
                    valor = pry_nivelActual != null ? pry_nivelActual.Valor : (double?)null
                });
                proyecto.nivelesAceptacion = pry_nivelesAceptacion;
            }

            List<ObjetivoProyecto> objetivos = GetObjetivosProyecto(proyecto.idProyecto);

            //List<ObjetivoProyecto> flatObjetivos = GetFlatObjetivosProyecto(objetivos);

            proyecto.objetivos = objetivos;
            //proyecto.flatObjetivos = flatObjetivos;

            proyecto.informes = Context.pry_informes.Where(a => a.IdProyecto == proyecto.idProyecto).ToList();

            return proyecto;
        }

        public List<ObjetivoProyecto> GetObjetivosProyecto(int idProyecto)
        {
            List<ObjetivoProyecto> objetivos = new List<ObjetivoProyecto>();
            foreach (Pry_Objetivos pry_objetivo in Context.pry_objetivos.Where(a => a.IdProyecto == idProyecto && a.IdPadre == 0 && a.Eliminado == false))
            {
                ObjetivoProyecto objetivoProyecto = GetObjetivoInfo(pry_objetivo.IdObjetivo);
                if (objetivoProyecto != null) objetivos.Add(objetivoProyecto);
            }
            return objetivos;
        }

        public List<ObjetivoProyecto> GetFlatObjetivosProyecto(List<ObjetivoProyecto> objetivos)
        {
            List<ObjetivoProyecto> flatObjetivos = new List<ObjetivoProyecto>();
            foreach (ObjetivoProyecto objetivoProyecto in objetivos)
            {
                GetFlatObjects(objetivoProyecto, ref flatObjetivos);
            }
            return flatObjetivos;
        }

        private void GetFlatObjects(ObjetivoProyecto objetivoProyecto, ref List<ObjetivoProyecto> flatObjetivos)
        {
            flatObjetivos.Add(objetivoProyecto);
            foreach (ObjetivoProyecto childObjetivoProyecto in objetivoProyecto.children)
            {
                GetFlatObjects(childObjetivoProyecto, ref flatObjetivos);
            }
        }

        private ObjetivoProyecto GetObjetivoInfo(int idObjetivo)
        {
            ObjetivoProyecto objetivo = (from o in Context.pry_objetivos
                                         where o.IdObjetivo == idObjetivo
                                         && o.Eliminado == false
                                         select new ObjetivoProyecto
                                         {
                                             idObjetivo = o.IdObjetivo,
                                             idObjetivoClase = o.IdObjetivoClase.Value,
                                             idPadre = o.IdPadre,
                                             idProyecto = o.IdProyecto,
                                             codigo = o.Codigo,
                                             descripcion = o.Descripcion,
                                             objetivo = o
                                         }).FirstOrDefault();
            if (objetivo != null)
            {
                objetivo.objetivoClase = Context.pry_objetivosclase.Where(a => a.IdObjetivoClase == objetivo.idObjetivoClase).FirstOrDefault();
                objetivo.parent = Context.pry_objetivos.Where(a => a.IdObjetivo == objetivo.idPadre).FirstOrDefault();
                objetivo.indicadores = Context.pry_indicadores.Where(a => a.IdObjetivo == objetivo.idObjetivo).ToList();
                foreach (Pry_Indicadores indicador in objetivo.indicadores)
                {
                    indicador.Pry_IndicadoresVerificadores = Context.pry_indicadoresverificadores.Where(a => a.IdIndicador == indicador.IdIndicador).ToList();
                }

                objetivo.supuestos = Context.pry_supuestos.Where(a => a.IdObjetivo == objetivo.idObjetivo).ToList();
                objetivo.supuestos.ForEach(x => x.Pry_Objetivos = null);

                objetivo.children = new List<ObjetivoProyecto>();
                foreach (Pry_Objetivos objetivoHijo in Context.pry_objetivos.Where(a => a.IdPadre == idObjetivo))
                {
                    ObjetivoProyecto objetivoProyecto = GetObjetivoInfo(objetivoHijo.IdObjetivo);
                    if (objetivoProyecto != null) objetivo.children.Add(objetivoProyecto);   
                }

                IEnumerable<Pry_Presupuesto> presupuesto = Context.pry_presupuesto.Where(a => a.IdObjetivo == objetivo.idObjetivo && a.IdTipoPresupuesto == 1);
                objetivo.totalPresupuesto = (presupuesto != null && presupuesto.Count() > 0) ? presupuesto.Sum(a => (a.Monto.HasValue ? a.Monto.Value : 0)) : 0;

                objetivo.recursos = Context.pry_recursos.Where(a => a.IdObjetivo == objetivo.idObjetivo).ToList();
                objetivo.totalDistribuidoRecursos = objetivo.recursos.Sum(a => (a.APORTEPROGRAMA.HasValue ? a.APORTEPROGRAMA.Value : 0));

            }

            return objetivo;
        }

        public string GetNextObjetivoCode(int idPadre)
        {
            string nextCode = "0";
            if (idPadre != 0)
            {
                Pry_Objetivos objetivoPadre = Context.pry_objetivos.Where(a => a.IdObjetivo == idPadre).FirstOrDefault();
                if (objetivoPadre.IdPadre != 0) //Ver el padre del padre, para no incluir en el código el nivel 2 (propósito)
                {
                    if (objetivoPadre.IdObjetivoClase == 2)
                    {
                        int index = 0;
                        foreach (Pry_Objetivos objetivoHijo in Context.pry_objetivos.Where(a => a.IdPadre == objetivoPadre.IdObjetivo))
                        {
                            int codigoNumber;
                            if (int.TryParse(objetivoHijo.Codigo, out codigoNumber))
                            {
                                if (index < codigoNumber) index = codigoNumber;
                            }
                        }
                        index += 1;
                        nextCode = index.ToString();
                    }
                    else if (objetivoPadre.IdObjetivoClase >= 3)
                    {
                        string objetivoCode = objetivoPadre.Codigo;

                        //var numHijos = Context.pry_objetivos.Count(o => o.IdPadre == objetivoPadre.IdObjetivo);
                        var last = Context.pry_objetivos
                            .OrderByDescending(x => x.Codigo)
                            .FirstOrDefault(x => x.IdPadre == objetivoPadre.IdObjetivo && x.Eliminado == false);

                        if (last == null)
                        {
                            nextCode = objetivoCode + ".1";
                        }
                        else
                        {
                            var num = last.Codigo.Split('.').LastOrDefault();
                            if (int.TryParse(num, out var i))
                            {
                                nextCode = string.Concat(objetivoCode, ".", ++i);
                            }
                            else
                            {
                                nextCode = objetivoCode + ".1";
                            }
                            //nextCode = objetivoCode + "." + (numHijos + 1).ToString();
                        }
                    }
                }
            }
            return nextCode;
        }

        public Sys_Usuarios GetUsuarioById(int idUsuario)
        {
            return Context.sys_usuarios.Where(a => a.IdUsuario == idUsuario).FirstOrDefault();
        }

        public Pry_Objetivos GetObjetivoById(int idObjetivo)
        {
            return Context.pry_objetivos.Where(a => a.IdObjetivo == idObjetivo).FirstOrDefault();
        }

        public Pry_Indicadores GetIndicadorById(int idIndicador)
        {
            return Context.pry_indicadores.Where(a => a.IdIndicador == idIndicador).FirstOrDefault();
        }

        public Pry_IndicadoresTipos GetIndicadorTipo(int idIndicadorTipo)
        {
            return Context.pry_indicadorestipos.Where(a => a.IdTipo == idIndicadorTipo).FirstOrDefault();
        }

        public int GetNextIndicatorCode(int idObjetivo, int idSubTipo, int idTipo)
        {
            return (Context.pry_indicadores.Where(a => a.IdObjetivo == idObjetivo && a.IdSubTipo == idSubTipo && a.IdTipo == idTipo).Count()) + 1;
        }

        public Pry_Supuestos GetSupuestoById(int idSupuesto)
        {
            return Context.pry_supuestos.Where(a => a.IdSupuesto == idSupuesto).FirstOrDefault();
        }

        public Pry_Informes GetInformeById(int idInforme)
        {
            return Context.pry_informes.Where(a => a.IdInforme == idInforme).FirstOrDefault();
        }

        public List<PRY_PERIODOSPROYECTOS> GetAllPeriodosByProyecto(int proyectoId)
        {
            return Context.pry_periodosproyectos.Where(a => a.IdProyecto == proyectoId).ToList();
        }

        public Pry_Proyectos_NivelAceptacion GetProyectoNivelAceptacion(int idProyecto, int idNivelAceptacion)
        {
            return Context.pry_proyectos_nivelaceptacion.Where(a => a.IdProyecto == idProyecto && a.IdNivelAceptacion == idNivelAceptacion).FirstOrDefault();
        }

        public List<object> GetUsersByCompany(int id)
        {
            //Context.da
            return null;
        }

        public void addProyecto(Pry_Proyectos newProyecto)
        {
            Context.Add(newProyecto);
            Context.SaveChanges();
        }

        public void deleteProyecto(Pry_Proyectos proyecto)
        {
            proyecto.Eliminado = true;
            Context.SaveChanges();
        }

        public void addObjetivo(Pry_Objetivos newObjetivo)
        {
            Context.Add(newObjetivo);

            Context.SaveChanges();

            if (newObjetivo.IdObjetivoClase == 2)
            {
                Context.pry_proyectos.FirstOrDefault(p => p.IdProyecto == newObjetivo.IdProyecto).IdProposito = newObjetivo.IdObjetivo;

                Context.SaveChanges();
            }
        }

        public void deleteObjetivo(Pry_Objetivos objetivo)
        {
            objetivo.Eliminado = true;
            Context.SaveChanges();
        }

        public void addIndicador(Pry_Indicadores indicador)
        {
            Context.Add(indicador);
            Context.SaveChanges();
        }

        public void deleteIndicador(Pry_Indicadores indicador)
        {
            foreach (Pry_IndicadoresVerificadores verificador in indicador.Pry_IndicadoresVerificadores)
            {
                Context.Delete(verificador);
            }
            foreach (Pry_DatosMuestras datoMuestra in indicador.Pry_DatosMuestras)
            {
                Context.Delete(datoMuestra);
            }
            foreach (Pry_EvaluacionHitos evaluacionHito in indicador.Pry_EvaluacionHitos)
            {
                Context.Delete(evaluacionHito);
            }
            foreach (Pry_IndicadoresProyecto_Programa proyectoPrograma in indicador.Pry_IndicadoresProyecto_Programa)
            {
                Context.Delete(proyectoPrograma);
            }

            Context.Delete(indicador);
            Context.SaveChanges();
        }

        //added by Ernesto Duarte --save pry_indicadoresVerificadores
        public void addVerificadores(List<Pry_IndicadoresVerificadores> verificators) 
        {
            foreach (var verificator in verificators) 
            { 
                if (verificator.Descripcion != "" && verificator.IdIndicador != null)
                {
                    Context.Add(verificator);
                }
            }

            Context.SaveChanges();
        }

        public void modifyVerificadores(int idIndicador, List<Pry_IndicadoresVerificadores> verificators) 
        {
            var _verificators = Context.pry_indicadoresverificadores.Where(v => v.IdIndicador == idIndicador).ToList();

            //first we delete all existing verificators

            foreach (var verificator in _verificators)
            {
                Context.Delete(verificator);
            }

            //then add the modified ones

            foreach (var verificator in verificators)
            {
                Context.Add(verificator);
            }

            Context.SaveChanges();
        }

        //

        public void addSupuesto(Pry_Supuestos supuesto)
        {
            Context.Add(supuesto);
            Context.SaveChanges();
        }

        public void deleteSupuesto(Pry_Supuestos supuesto)
        {
            Context.Delete(supuesto);
            Context.SaveChanges();
        }

        public void addInforme(Pry_Informes informe)
        {
            Context.Add(informe);
            Context.SaveChanges();
        }

        public void addPeriodoProyecto(PRY_PERIODOSPROYECTOS periodoProyecto)
        {
            Context.Add(periodoProyecto);
            Context.SaveChanges();
        }
        public void deletePeriodoProyecto(PRY_PERIODOSPROYECTOS periodoProyecto)
        {
            Context.Delete(periodoProyecto);
            Context.SaveChanges();
        }
        public void addNivelAceptacionProyecto(Pry_Proyectos_NivelAceptacion nivelAceptacionProyecto)
        {
            Context.Add(nivelAceptacionProyecto);
            Context.SaveChanges();
        }


        public void deleteInforme(Pry_Informes informe)
        {
            Context.Delete(informe);
            Context.SaveChanges();
        }

        public void modifyData()
        {
            Context.SaveChanges();
        }

        public class Proyecto
        {
            public int idProyecto { get; set; }
            public Pry_Proyectos proyecto { get; set; }
            public List<NivelAceptacionProyecto> nivelesAceptacion { get; set; }
            public List<ObjetivoProyecto> objetivos { get; set; }
            public List<ObjetivoProyecto> flatObjetivos { get; set; }
            public List<Pry_Informes> informes { get; set; }
        }

        public class NivelAceptacionProyecto
        {
            public int idNivelAceptacion { get; set; }
            public string nombre { get; set; }
            public double? valor { get; set; }
        }

        public class ObjetivoProyecto
        {
            public int idObjetivo { get; set; }
            public int idProyecto { get; set; }
            public int idObjetivoClase { get; set; }
            public Pry_ObjetivosClase objetivoClase { get; set; }
            public Pry_Objetivos objetivo { get; set; }
            public int? idPadre { get; set; }
            public Pry_Objetivos parent { get; set; }
            public string codigo { get; set; }
            public string descripcion { get; set; }
            public List<Pry_Indicadores> indicadores { get; set; }
            public List<Pry_Supuestos> supuestos { get; set; }
            public List<ObjetivoProyecto> children { get; set; }
            public double totalPonderado { get { return children != null ? children.Sum(a => (a.objetivo != null && a.objetivo.Ponderado.HasValue) ? a.objetivo.Ponderado.Value : 0) : 0; } }
            public double totalPonderadoIndicadores { get { return indicadores != null ? indicadores.Sum(a => a.Ponderado.HasValue ? a.Ponderado.Value : 0) : 0; } }
            public List<Pry_Recursos> recursos { get; set; }
            public double totalPresupuesto { get; set; }
            public decimal totalDistribuidoRecursos { get; set; }
            public double pendientePresupuesto { get { return totalPresupuesto - (double)totalDistribuidoRecursos; } }
        }
    }

    #endregion

    #region Monedas Repository

    public class MonedasRepository : IMonedaRepository
    {
        private IContextRepository Context;

        public MonedasRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        //retorna todas las monedas

        public IEnumerable<Object> GetAll()
        {
            return (from m in Context.m_monedas select new { m.IdMoneda, m.Nombre, m.Representacion, m.Codigo }).AsEnumerable();
        }

        //retorna una modena por Id
        public M_Monedas getModedaById(int id)
        {
            return Context.m_monedas.FirstOrDefault(m => m.IdMoneda == id);
        }

        public void addMoneda(M_Monedas newMoneda)
        {

            var moneda = Context.m_monedas.FirstOrDefault(m => m.Nombre == newMoneda.Nombre);

            Context.Add(newMoneda);

            Context.SaveChanges();
        }

        public void Update(M_Monedas moneda)
        {
            ((DbContext)Context).Entry(moneda).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(M_Monedas moneda)
        {
            Context.Delete(moneda);
            Context.SaveChanges();
        }
    }

    #endregion

    #region Encuestas Repository

    public class EncuestasRepository : IEncuestasRepository
    {
        private const string ESTADO_ENCUESTA_ABIERTO = "A"; //Recibe modificaciones 
        private const string ESTADO_ENCUESTA_BLOQUEADO = "B"; //No acepta modificaciones 
        private const string ESTADO_ENCUESTA_ELIMINADO = "E"; //Eliminada, no se muestra
        private const string ESTADO_ENCUESTA_TERMINADA = "T"; //Terminó el periodo para ser resuelta

        private IContextRepository Context;

        public EncuestasRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        //retorna todas las encuestas
        public IEnumerable<M_Encuestas> GetAll()
        {
            return Context.m_encuestas.Where(a => a.Estado != ESTADO_ENCUESTA_ELIMINADO);
        }

        //retorna una encuesta por Id
        public M_Encuestas GetEncuestaById(int id)
        {
            return Context.m_encuestas.FirstOrDefault(m => m.IdEncuesta == id);
        }

        //Agrega una encuesta
        public void addEncuesta(M_Encuestas newEncuesta)
        {
            newEncuesta.Estado = ESTADO_ENCUESTA_ABIERTO;
            Context.Add(newEncuesta);
            Context.SaveChanges();
        }

        public void modifyEncuesta()
        {
            Context.SaveChanges();
        }

        public void deleteEncuesta(M_Encuestas encuesta)
        {
            if (encuesta.M_EncuestasResueltas.Count > 0 || encuesta.M_Preguntas.Count > 0)
            {
                //Si la encuesta tiene preguntas o ha sido resuleta al menos una vez, ésta no se elimina
                //sólo se le cambia el estado a "Eliminado"
                encuesta.Estado = ESTADO_ENCUESTA_ELIMINADO;
            }
            else
            {
                //Si la encuesta no tiene preguntas asociadas, ésta se elimna definitivamente para no 
                //guardar registros "basura" en la base de datos
                Context.Delete(encuesta);
            }
            Context.SaveChanges();
        }

        //Bloquea una encuesta
        //La encuestas bloqueadas ya no se pueden editar sólo se pueden resolver
        public void lockEncuesta(M_Encuestas encuesta)
        {
            encuesta.Estado = ESTADO_ENCUESTA_BLOQUEADO;
            Context.SaveChanges();
        }

        //Termina una encuesta
        //La encuestas terminadas ya no se pueden resolver
        public void finishEncuesta(M_Encuestas encuesta)
        {
            encuesta.Estado = ESTADO_ENCUESTA_TERMINADA;
            Context.SaveChanges();
        }
    }

    public class PreguntasRepository : IPreguntasRepository
    {
        private IContextRepository Context;

        public PreguntasRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        //retorna todas las encuestas
        public IEnumerable<Object> GetAll()
        {
            return Context.m_preguntas.Select(p => 
                new { 
                    p.IdPregunta,
                    p.IdEncuesta,
                    p.Pregunta,
                    p.Tipo,
                    p.Orden,
                    M_PosiblesRespuestas = Context.m_posiblesRespuestas.Where(pp => pp.IdPregunta == p.IdPregunta),
                    M_PreguntasResueltas = Context.m_preguntasResueltas.Where(pr => pr.IdPregunta == p.IdPregunta)
                }).OrderBy(m => m.Orden);
        }

        //retorna una pregunta por Id
        public M_Preguntas GetPreguntaById(int id)
        {
            return Context.m_preguntas.Include(x => x.M_PosiblesRespuestas).Where(m => m.IdPregunta == id).FirstOrDefault();
        }

        public void addPregunta(M_Preguntas newPregunta)
        {
            pushOrdenPregunta(newPregunta.IdEncuesta.Value, newPregunta.Orden.Value);
            Context.Add(newPregunta);
            Context.SaveChanges();
        }

        public void modifyPregunta(M_Preguntas pregunta)
        {
            Context.SaveChanges();
            pushOrdenPregunta(pregunta);
        }

        public void deletePregunta(M_Preguntas pregunta)
        {
            int idEncuesta = (int)pregunta.IdEncuesta;
            Context.Delete(pregunta);
            Context.SaveChanges();
            arrangeOrdenPreguntasByEncuesta(idEncuesta);
        }

        public void deletePosiblesRespuestas(M_Preguntas pregunta)
        {
            var tmpPosiblesRespuestas = new List<M_PosiblesRespuestas>();

            foreach (var posibleRespuesta in pregunta.M_PosiblesRespuestas)
            {
                tmpPosiblesRespuestas.Add(posibleRespuesta);
            }

            foreach (var posibleRespuesta in tmpPosiblesRespuestas)
            {
                Context.Delete(posibleRespuesta);
                Context.SaveChanges();
            }
        }

        private void pushOrdenPregunta(int idEncuesta, int newOrden)
        {
            var preguntasList = Context.m_preguntas.Where(m => m.IdEncuesta == idEncuesta && m.Orden >= newOrden).OrderBy(m => m.Orden).ToList();
            foreach (var pregunta in preguntasList)
            {
                pregunta.Orden++;
                Context.SaveChanges();
            }
        }

        private void pushOrdenPregunta(M_Preguntas pregunta)
        {
            int index = (int)pregunta.Orden;
            List<M_Preguntas> preguntasList = Context.m_preguntas.Where(m => m.IdEncuesta == pregunta.IdEncuesta && m.Orden >= pregunta.Orden && m.IdPregunta != pregunta.IdPregunta).OrderBy(m => m.Orden).ToList();
            foreach (M_Preguntas otrapregunta in preguntasList)
            {
                index++;
                otrapregunta.Orden = index;
                Context.SaveChanges();
            }
        }

        private void arrangeOrdenPreguntasByEncuesta(int idEncuesta)
        {
            int index = 0;
            List<M_Preguntas> preguntasList = Context.m_preguntas.Where(m => m.IdEncuesta == idEncuesta).OrderBy(m => m.Orden).ToList();
            foreach (M_Preguntas pregunta in preguntasList)
            {
                index++;
                pregunta.Orden = index;
                Context.SaveChanges();
            }
        }
    }

    public class CuestionarioRepository : ICuestionarioRepository
    {
        private Dictionary<int, string> TemplatesDefinition = new Dictionary<int, string>
    	                                                      {
                                                                  {1, "templateText"}, 
                                                                  {2, "templateNumber"}, 
                                                                  {3, "templateDate"}, 
                                                                  {4, "singleOption"}, 
                                                                  {5, "multiOption"}
    	                                                      };

        private IContextRepository Context;

        public CuestionarioRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Object> GetCuestionarios()
        {

            return new List<EncuestaAMostrar>();

        }

        //retorna una modena por Id
        public Object GetCuestionarioById(int idEncuesta)
        {
            EncuestaAMostrar cuestionario = new EncuestaAMostrar();
            List<PreguntaAMostrar> preguntasAMostrar = new List<PreguntaAMostrar>();

            M_Encuestas encuesta = Context.m_encuestas.Where(a => a.IdEncuesta == idEncuesta).FirstOrDefault();
            if (encuesta != null)
            {
                foreach (M_Preguntas pregunta in Context.m_preguntas.Where(p => p.IdEncuesta == encuesta.IdEncuesta).OrderBy(a => a.Orden))
                {
                    PreguntaAMostrar preguntaAMostrar = new PreguntaAMostrar
                    {
                        IdPregunta = pregunta.IdPregunta,
                        Orden = pregunta.Orden.HasValue ? pregunta.Orden.Value : 0,
                        Pregunta = pregunta.Pregunta,
                        TipoPregunta = TemplatesDefinition[pregunta.Tipo.HasValue ? pregunta.Tipo.Value : 1],
                        RespuestasAMostrar = new List<RespuestaAMostrar>()
                    };
                    foreach (M_PosiblesRespuestas posiblesRespuestas in Context.m_posiblesRespuestas.Where(pr => pr.IdPregunta == pregunta.IdPregunta))
                    {
                        RespuestaAMostrar respuestaAMostrar = new RespuestaAMostrar
                        {
                            IdRespuesta = posiblesRespuestas.IdPosibleRespuesta,
                            PreguntaAMostrar = preguntaAMostrar,
                            Respuesta = posiblesRespuestas.Respuesta
                        };
                        preguntaAMostrar.RespuestasAMostrar.Add(respuestaAMostrar);
                    };

                    preguntasAMostrar.Add(preguntaAMostrar);
                }
                cuestionario.IdEncuesta = encuesta.IdEncuesta;
                cuestionario.Titulo = encuesta.Titulo;
                cuestionario.PreguntasAMostrar = preguntasAMostrar;
            }
            return cuestionario;
        }

        public void addEncuestaResuelta(M_EncuestasResueltas newEncuestaResuelta)
        {
            Context.Add(newEncuestaResuelta);
            Context.SaveChanges();
        }

    }

    public class EncuestaAMostrar
    {
        public int IdEncuesta { get; set; }
        public string Titulo { get; set; }
        public List<PreguntaAMostrar> PreguntasAMostrar { get; set; }
    }

    public class PreguntaAMostrar
    {
        public EncuestaAMostrar EncuestaAMostrar { get; set; }
        public int IdPregunta { get; set; }
        public int Orden { get; set; }
        public string Pregunta { get; set; }
        public decimal? NumeroRespuesta { get; set; }
        public DateTime? FechaRespuesta { get; set; }
        public string TextoRespuesta { get; set; }
        public string ValorRespuestaSimple { get; set; }
        public string TipoPregunta { get; set; }
        public List<RespuestaAMostrar> RespuestasAMostrar { get; set; }
    }

    public class RespuestaAMostrar
    {
        public int IdRespuesta { get; set; }
        public PreguntaAMostrar PreguntaAMostrar { get; set; }
        public string Respuesta { get; set; }
        public bool Seleccionada { get; set; }
    }

    #endregion

    #region Idiomas
    public class IdiomasRepository : IIdiomasRepository
    {
        private IContextRepository Context;

        public IdiomasRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        //Devuelve todos lo idiomas
        public IEnumerable<M_Idiomas> GetAll()
        {
            return Context.m_idiomas.OrderBy(m => m.Nombre);
        }
    }
    #endregion

    #region Visitas
    public class VisitasRepository : IVisitasRepository
    {
        private const string ESTADO_VISITA_ABIERTA = "A"; //Recibe modificaciones 
        private const string ESTADO_VISITA_COMPLETADA = "C"; //No acepta modificaciones 
        private const string ESTADO_VISITA_ELIMINADA = "E"; //No se muestra

        private IContextRepository Context;

        public VisitasRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        //retorna todas las visitas
        public IEnumerable<Object> GetAll()
        {
            return Context.tar_visitas.Where(a => a.Estado != ESTADO_VISITA_ELIMINADA)
                .Select(t => new { 
                    t.IdTarea,
                    t.IdVisita,
                    t.Descripcion,
                    t.Fecha,
                    t.Latitud,
                    t.Longitud,
                    t.PersonaContacto,
                    t.Tar_Bitacora,
                    t.Tar_Permisos_Bitacora,
                    Tar_Tareas = Context.tar_tareas.FirstOrDefault(task => task.Id == t.IdTarea),
                    t.Ubicacion,
                    t.Estado
                })
                .OrderBy(a => a.Fecha).AsEnumerable();
        }

        //retorna una visitas por Id
        public Tar_Visitas GetVisitaById(int id)
        {
            return Context.tar_visitas.FirstOrDefault(m => m.IdVisita == id);
        }

        //Agrega una visitas
        public void addVisita(Tar_Visitas newVisita)
        {
            newVisita.Estado = ESTADO_VISITA_ABIERTA;
            Context.Add(newVisita);
            Context.SaveChanges();
        }

        public void modifyVisita()
        {
            Context.SaveChanges();
        }

        public void deleteVisita(Tar_Visitas visita)
        {
            visita.Estado = ESTADO_VISITA_ELIMINADA;
            Context.SaveChanges();
        }

        //Termina una visita
        //Las visitas terminadas ya no se pueden editar
        public void completeVisita(Tar_Visitas visita)
        {
            visita.Estado = ESTADO_VISITA_COMPLETADA;
            Context.SaveChanges();
        }
    }

    public class BitacoraRepository : IBitacoraRepository
    {
        private IContextRepository Context;

        public BitacoraRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        //retorna todas las bitacoras
        public IEnumerable<Object> GetAll()
        {
            return Context.tar_bitacora.Select(b => new { 
                b.IdBitacora,
                b.IdVisita,
                b.FechaRegistro,
                b.Comentario,
                b.IdUsuario,
                b.Sys_Usuarios
            }).OrderByDescending(m => m.FechaRegistro);
        }

        //Agrega una bitacora
        public void addBitacora(Tar_Bitacora newBitacora)
        {
            Context.Add(newBitacora);
            Context.SaveChanges();
        }

    }

    public class PermisosBitacoraRepository : IPermisosBitacoraRepository
    {
        private const string PERMISO_READ_VISITA = "RV";
        private const string PERMISO_WRITE_VISITA = "WV";
        private const string PERMISO_READ_BITACORA = "RB";
        private const string PERMISO_WRITE_BITACORA = "WB";

        private IContextRepository Context;

        public PermisosBitacoraRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Object> GetPermisosActuales()
        {

            return new List<PermisosVisitasYBitacoras>();

        }

        //retorna los permisos de una visita
        public IEnumerable<Object> GetPermisos()
        {
            List<PermisosVisitasYBitacoras> permisos = new List<PermisosVisitasYBitacoras>();
            foreach (Tar_Visitas visita in Context.tar_visitas)
            {
                int idUsuarioCreador = 0;
                if (visita.Tar_Tareas != null) idUsuarioCreador = visita.Tar_Tareas.IdUsuarioCreacion.HasValue ? visita.Tar_Tareas.IdUsuarioCreacion.Value : 0;
                foreach (Sys_Usuarios usuario in Context.sys_usuarios.Where(a => a.IdUsuario != idUsuarioCreador))
                {
                    Tar_Permisos_Bitacora permisoUsuario = Context.tar_permisos_bitacora.Where(a => a.IdUsuario == usuario.IdUsuario && a.IdVisita == visita.IdVisita).FirstOrDefault();
                    PermisosVisitasYBitacoras permiso = new PermisosVisitasYBitacoras
                    {
                        IdVisita = visita.IdVisita,
                        IdUsuario = usuario.IdUsuario,
                        UserName = usuario.UserName,
                        NombreUsuario = usuario.Nombre,
                        ReadVisita = false,
                        WriteVisita = false,
                        ReadBitacora = false,
                        WriteBitacora = false
                    };

                    if (permisoUsuario != null)
                    {
                        string[] arrayPermisos = permisoUsuario.Permiso.Split(new string[] { "," }, StringSplitOptions.None);
                        if (arrayPermisos.Contains(PERMISO_READ_VISITA)) permiso.ReadVisita = true;
                        if (arrayPermisos.Contains(PERMISO_WRITE_VISITA)) permiso.WriteVisita = true;
                        if (arrayPermisos.Contains(PERMISO_READ_BITACORA)) permiso.ReadBitacora = true;
                        if (arrayPermisos.Contains(PERMISO_WRITE_BITACORA)) permiso.WriteBitacora = true;
                    }

                    permisos.Add(permiso);
                }
            }
            return permisos;
        }

        public void deletePermisosByVisitaId(int idVisita)
        {
            foreach (Tar_Permisos_Bitacora permiso in Context.tar_permisos_bitacora.Where(a => a.IdVisita == idVisita))
            {
                Context.Delete(permiso);
            }
            Context.SaveChanges();
        }

        //Agrega un permiso de bitacora
        public void addPermisoBitacora(Tar_Permisos_Bitacora newPermisoBitacora)
        {
            Context.Add(newPermisoBitacora);
            Context.SaveChanges();
        }

    }

    public class PermisosVisitasYBitacoras
    {
        public int IdVisita { get; set; }
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string NombreUsuario { get; set; }
        public bool ReadVisita { get; set; }
        public bool WriteVisita { get; set; }
        public bool ReadBitacora { get; set; }
        public bool WriteBitacora { get; set; }
    }

    #endregion

    #region Evaluacion
    public class EvaluacionHitosRepository : IEvaluacionHitosRepository
    {
        private IContextRepository Context;

        public EvaluacionHitosRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public object GetEvaluacionHitosObjectByPeriod(int idPeriodo, int idTenant)
        {
            EvaluacionHitosObject evaluacionHitosObject = new EvaluacionHitosObject();
            evaluacionHitosObject.evaluacionesHitos = new List<SELEVALUACIONESHITOS_Result>();
            PRY_PERIODOSPROYECTOS periodo = Context.pry_periodosproyectos.Where(a => a.IdPeriodo == idPeriodo).FirstOrDefault();
            if (periodo != null)
            {
                evaluacionHitosObject.evaluacionesHitos = GetAll((int)periodo.IdProyecto, (int)periodo.IdPeriodo, idTenant);
            }
            return evaluacionHitosObject;
        }

        //retorna todas las evaluaciones hitos
        public List<SELEVALUACIONESHITOS_Result> GetAll(int idProyecto, int idPeriodo, int idTenant)
        {
            return Context.selevaluacioneshitos(idProyecto, idPeriodo, idTenant);
        }

        public void AddEvaluationHito(int idProyecto, int idPeriodo, int idResultado,
                                      int idActividad, int idHito, string observacionED,
                                      string observacionUrip, int idUsuario,
                                      decimal porcentajeHito, decimal cv, decimal adh)
        {
            bool isObservationEDChanged = false;
            string EvaluationTaskListName = "Observaciones del Evaluador";
            int observationTaskEndDate = 1; //valor total de dias a añadir fecha de finalización de la tarea

            //valida si existe
            Pry_EvaluacionHitos local = (from s in Context.pry_evaluacionhitos
                                         where s.IdPeriodo == idPeriodo
                                         && s.IdProyecto == idProyecto && s.IdResultado == idResultado
                                         && s.IdActividad == idActividad && s.IdHito == idHito
                                         select s).FirstOrDefault();

            if (local == null)//nuevo
            {
                local = new Pry_EvaluacionHitos()
                {
                    IdResultado = idResultado,
                    IdActividad = idActividad,
                    IdHito = idHito,
                    IdPeriodo = idPeriodo,
                    IdProyecto = idProyecto,
                    HitoEfectividad = porcentajeHito,
                    ObservacionED = observacionED,
                    ADH = adh,
                    CV = cv,
                    ObservacionUrip = observacionUrip
                };
                Context.Add(local);
                if (!string.IsNullOrEmpty(observacionED)) isObservationEDChanged = true;
            }
            else
            {
                local.HitoEfectividad = porcentajeHito;
                if (local.ObservacionED != observacionED)
                    isObservationEDChanged = true;
                local.ObservacionED = observacionED;
                local.ADH = adh;
                local.CV = cv;
                local.ObservacionUrip = observacionUrip;
            }
            Context.SaveChanges();

            //crear una tarea para el director del proyecto
            if (isObservationEDChanged)
            {
                int? listId = (from s in Context.tar_listas
                               where s.IdProyecto == idProyecto
                               && s.Descripcion == EvaluationTaskListName
                               select s.Id).FirstOrDefault();
                if (listId == null || listId == 0)
                {
                    //la creamos
                    Tar_Listas localLista = new Tar_Listas()
                    {
                        Descripcion = EvaluationTaskListName,
                        FechaCreacion = DateTime.Now,
                        IdProyecto = idProyecto,
                        IdUsuarioCreacion = idUsuario,
                        IdPadre = 0
                    };
                    Context.Add(localLista);
                    Context.SaveChanges();
                    listId = localLista.Id;
                }
                var proyecto = (from s in Context.pry_proyectos
                                where s.IdProyecto == idProyecto
                                select s).FirstOrDefault();
                if (proyecto != null)
                {
                    //TO DO: Adicionar lógica para crear el mensaje

                    //la creamos
                    Tar_Tareas localTarea = new Tar_Tareas();
                    localTarea.FechaCreacion = DateTime.Now;
                    localTarea.IdUsuarioCreacion = idUsuario;
                    //localTarea.Descripcion = string.Format(taskDescription, local.ObservacionED, item.Hito, item.ActivityCode, item.Codigo);
                    localTarea.FechaFin = DateTime.Now.AddDays(observationTaskEndDate);
                    localTarea.FechaInicio = DateTime.Now;
                    localTarea.Estado = false;
                    localTarea.IdLista = listId;
                    localTarea.Prioridad = true;
                    localTarea.IdResponsable = proyecto.IdUsuarioResponsable;
                    Context.Add(localTarea);
                    Context.SaveChanges();

                    //log
                    string result = (from p in Context.tar_listas
                                     join pro in Context.pry_proyectos on p.IdProyecto equals pro.IdProyecto
                                     where p.Id == listId
                                     select pro.Nombre).FirstOrDefault();

                    //TO DO: Adicionar lógica para enviar el mensaje
                }
            }
            //
            Context.SaveChanges();
        }
    }

    public class EvaluacionHitosObject
    {
        public List<SELEVALUACIONESHITOS_Result> evaluacionesHitos { get; set; }

    }

    public class EvaluacionIndicadoresRepository : IEvaluacionIndicadoresRepository
    {
        private IContextRepository Context;

        public EvaluacionIndicadoresRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public object GetEvaluacionIndicadoresObjectByPeriod(int idPeriodo, int idTenant)
        {
            EvaluacionIndicadoresObject evaluacionIndicadoresObject = new EvaluacionIndicadoresObject();
            evaluacionIndicadoresObject.evaluacionesIndicadores = new List<SELEVALUACIONESINDICADORES_Result>();
            PRY_PERIODOSPROYECTOS periodo = Context.pry_periodosproyectos.Where(a => a.IdPeriodo == idPeriodo).FirstOrDefault();
            if (periodo != null)
            {
                evaluacionIndicadoresObject.evaluacionesIndicadores = GetAll((int)periodo.IdProyecto, (int)periodo.IdPeriodo, idTenant);
            }
            return evaluacionIndicadoresObject;
        }

        //retorna todas las evaluaciones indicadores
        public List<SELEVALUACIONESINDICADORES_Result> GetAll(int idProyecto, int idPeriodo, int idTenant)
        {
            return Context.selevaluacionesindicadores(idProyecto, idPeriodo, idTenant);
        }

        public void AddEvaluationIndicador(int idProyecto, int idPeriodo, int idResultado,
                                      int idHito, string observacionED,
                                      string observacionUrip, int idUsuario,
                                      decimal porcentajeHito, decimal cv, decimal adh)
        {
            bool isObservationEDChanged = false;
            string EvaluationTaskListName = "Observaciones del Evaluador";
            int observationTaskEndDate = 1; //valor total de dias a añadir fecha de finalización de la tarea

            //valida si existe
            PRY_EVALUACIONINDICADORESPERIODO local = (from s in Context.pry_evaluacionindicadores
                                                      where s.IdPeriodo == idPeriodo
                                                      && s.IdProyecto == idProyecto && s.IdResultado == idResultado
                                                      && s.IdHito == idHito
                                                      select s).FirstOrDefault();

            if (local == null)//nuevo
            {
                local = new PRY_EVALUACIONINDICADORESPERIODO()
                {
                    IdResultado = idResultado,
                    IdHito = idHito,
                    IdPeriodo = idPeriodo,
                    IdProyecto = idProyecto,
                    HitoEfectividad = porcentajeHito,
                    ObservacionED = observacionED,
                    ADH = adh,
                    CV = cv,
                    ObservacionUrip = observacionUrip
                };
                Context.Add(local);
                if (!string.IsNullOrEmpty(observacionED)) isObservationEDChanged = true;
            }
            else
            {
                local.HitoEfectividad = porcentajeHito;
                if (local.ObservacionED != observacionED)
                    isObservationEDChanged = true;
                local.ObservacionED = observacionED;
                local.ADH = adh;
                local.CV = cv;
                local.ObservacionUrip = observacionUrip;
            }
            Context.SaveChanges();

            //crear una tarea para el director del proyecto
            if (isObservationEDChanged)
            {
                int? listId = (from s in Context.tar_listas
                               where s.IdProyecto == idProyecto
                               && s.Descripcion == EvaluationTaskListName
                               select s.Id).FirstOrDefault();
                if (listId == null || listId == 0)
                {
                    //la creamos
                    Tar_Listas localLista = new Tar_Listas()
                    {
                        Descripcion = EvaluationTaskListName,
                        FechaCreacion = DateTime.Now,
                        IdProyecto = idProyecto,
                        IdUsuarioCreacion = idUsuario,
                        IdPadre = 0
                    };
                    Context.Add(localLista);
                    Context.SaveChanges();
                    listId = localLista.Id;
                }
                var proyecto = (from s in Context.pry_proyectos
                                where s.IdProyecto == idProyecto
                                select s).FirstOrDefault();
                if (proyecto != null)
                {
                    //TO DO: Adicionar lógica para crear el mensaje

                    //la creamos
                    Tar_Tareas localTarea = new Tar_Tareas();
                    localTarea.FechaCreacion = DateTime.Now;
                    localTarea.IdUsuarioCreacion = idUsuario;
                    //localTarea.Descripcion = string.Format(taskDescription, local.ObservacionED, item.Hito, item.ActivityCode, item.Codigo);
                    localTarea.FechaFin = DateTime.Now.AddDays(observationTaskEndDate);
                    localTarea.FechaInicio = DateTime.Now;
                    localTarea.Estado = false;
                    localTarea.IdLista = listId;
                    localTarea.Prioridad = true;
                    localTarea.IdResponsable = proyecto.IdUsuarioResponsable;
                    Context.Add(localTarea);
                    Context.SaveChanges();

                    //log
                    string result = (from p in Context.tar_listas
                                     join pro in Context.pry_proyectos on p.IdProyecto equals pro.IdProyecto
                                     where p.Id == listId
                                     select pro.Nombre).FirstOrDefault();

                    //TO DO: Adicionar lógica para enviar el mensaje
                }
            }
            //
            Context.SaveChanges();
        }
    }

    public class EvaluacionIndicadoresObject
    {
        public List<SELEVALUACIONESINDICADORES_Result> evaluacionesIndicadores { get; set; }

    }

    public class EvaluacionProyectoPeriodoRepository : IEvaluacionProyectoPeriodoRepository
    {
        private IContextRepository Context;

        public EvaluacionProyectoPeriodoRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public object GetEvaluacionProyectoPeriodoObjectByProject(int IdProyecto, int idTenant)
        {
            EvaluacionProyectoPeriodoObject evaluacionProyectoPeriodoObject = new EvaluacionProyectoPeriodoObject();
            evaluacionProyectoPeriodoObject.evaluacionesProyectoPeriodo = GetAll(IdProyecto, idTenant);
            return evaluacionProyectoPeriodoObject;
        }

        //retorna todas las evaluaciones hitos
        public List<SELEVALUACIONPROYECTOPERIODO_Result> GetAll(int idProyecto, int idTenant)
        {
            return Context.selevaluacionesproyectoperiodo(idProyecto, idTenant);
        }

        public void AddEvaluationProyectoPeriodo(int idProyecto, int idPeriodo, string datosfinancieros, string observaciones,
                                      string recomendaciones, int idUsuario)
        {
            string EvaluationTaskListName = "Observaciones del Evaluador";
            int observationTaskEndDate = 1; //valor total de dias a añadir fecha de finalización de la tarea

            //reporte
            PRY_EVALUACIONPROYECTOPERIODO epp = (from p in Context.pry_evaluacionproyectoperiodo
                                                 where p.IDPERIODO == idPeriodo && p.IDPROYECTO == idProyecto
                                                 select p).FirstOrDefault();
            epp.DATOSFINANCIEROS = datosfinancieros;
            epp.OBSERVACIONES = observaciones;
            epp.RECOMENDACIONES = recomendaciones;

            Context.SaveChanges();

            //crear una tarea para el director del proyecto
            int? listId = (from s in Context.tar_listas
                           where s.IdProyecto == idProyecto
                           && s.Descripcion == EvaluationTaskListName
                           select s.Id).FirstOrDefault();
            if (listId == null || listId == 0)
            {
                //la creamos
                Tar_Listas localLista = new Tar_Listas()
                {
                    Descripcion = EvaluationTaskListName,
                    FechaCreacion = DateTime.Now,
                    IdProyecto = idProyecto,
                    IdUsuarioCreacion = idUsuario,
                    IdPadre = 0
                };
                Context.Add(localLista);
                Context.SaveChanges();
                listId = localLista.Id;
            }
            var proyecto = (from s in Context.pry_proyectos
                            where s.IdProyecto == idProyecto
                            select s).FirstOrDefault();
            if (proyecto != null)
            {
                //TO DO: Adicionar lógica para crear el mensaje

                //la creamos
                Tar_Tareas localTarea = new Tar_Tareas();
                localTarea.FechaCreacion = DateTime.Now;
                localTarea.IdUsuarioCreacion = idUsuario;
                //localTarea.Descripcion = string.Format(taskDescription, local.ObservacionED, item.Hito, item.ActivityCode, item.Codigo);
                localTarea.FechaFin = DateTime.Now.AddDays(observationTaskEndDate);
                localTarea.FechaInicio = DateTime.Now;
                localTarea.Estado = false;
                localTarea.IdLista = listId;
                localTarea.Prioridad = true;
                localTarea.IdResponsable = proyecto.IdUsuarioResponsable;
                Context.Add(localTarea);
                Context.SaveChanges();

                //log
                string result = (from p in Context.tar_listas
                                 join pro in Context.pry_proyectos on p.IdProyecto equals pro.IdProyecto
                                 where p.Id == listId
                                 select pro.Nombre).FirstOrDefault();

                //TO DO: Adicionar lógica para enviar el mensaje
            }
            //
            Context.SaveChanges();
        }
    }

    public class EvaluacionProyectoPeriodoObject
    {
        public List<SELEVALUACIONPROYECTOPERIODO_Result> evaluacionesProyectoPeriodo { get; set; }

    }

    public class EvaluacionProyectoActividadRepository : IEvaluacionProyectoActividadRepository
    {
        private IContextRepository Context;

        public EvaluacionProyectoActividadRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public object GetEvaluacionActividadObjectByProject(int idPeriodo, int idTenant)
        {
            EvaluacionActividadesObject evaluacionActividadObject = new EvaluacionActividadesObject();
            PRY_PERIODOSPROYECTOS periodo = Context.pry_periodosproyectos.Where(a => a.IdPeriodo == idPeriodo).FirstOrDefault();
            if (periodo != null)
            {
                evaluacionActividadObject.evaluacionesActividades = GetAll((int)periodo.IdProyecto, (int)periodo.IdPeriodo, idTenant);
            }
            return evaluacionActividadObject;
        }

        //retorna todas las evaluaciones hitos
        public List<SELEVALUACIONESACTIVIDADESPERIODO_Result> GetAll(int idProyecto, int idPeriodo, int idTenant)
        {
            return Context.selevaluacionesactividades(idProyecto, idPeriodo, idTenant);
        }

        public void AddEvaluationActividades(int idProyecto, int idPeriodo, int idObjetivo, string observaciones, int idUsuario)
        {
            string EvaluationTaskListName = "Observaciones del Evaluador";
            int observationTaskEndDate = 1; //valor total de dias a añadir fecha de finalización de la tarea
            bool observationEdChanged = false;

            //validar si existe
            PRY_EVALUACIONESACTIVIDADESPERIODO epp = (from p in Context.pry_evaluacionactividades
                                                      where p.IDPERIODO == idPeriodo && p.IDPROYECTO == idProyecto &&
                                                            p.IDOBJETIVO == idObjetivo
                                                      select p).FirstOrDefault();

            if (epp == null)//crear
            {
                epp = new PRY_EVALUACIONESACTIVIDADESPERIODO
                {
                    IDOBJETIVO = idObjetivo,
                    IDPERIODO = idPeriodo,
                    IDPROYECTO = idProyecto,
                    OBSERVACIONES = observaciones
                };
                Context.Add(epp);
                if (!string.IsNullOrEmpty(observaciones)) observationEdChanged = true;
            }
            else
            {
                if (epp.OBSERVACIONES != observaciones) observationEdChanged = true;
                epp.OBSERVACIONES = observaciones;//
            }

            Context.SaveChanges();

            //crear una tarea para el director del proyecto
            if (observationEdChanged)
            {
                int? listId = (from s in Context.tar_listas
                               where s.IdProyecto == idProyecto
                               && s.Descripcion == EvaluationTaskListName
                               select s.Id).FirstOrDefault();
                if (listId == null || listId == 0)
                {
                    //la creamos
                    Tar_Listas localLista = new Tar_Listas()
                    {
                        Descripcion = EvaluationTaskListName,
                        FechaCreacion = DateTime.Now,
                        IdProyecto = idProyecto,
                        IdUsuarioCreacion = idUsuario,
                        IdPadre = 0
                    };
                    Context.Add(localLista);
                    Context.SaveChanges();
                    listId = localLista.Id;
                }

                var proyecto = (from s in Context.pry_proyectos
                                where s.IdProyecto == idProyecto
                                select s).FirstOrDefault();
                if (proyecto != null)
                {
                    //TO DO: Adicionar lógica para crear el mensaje

                    //la creamos
                    Tar_Tareas localTarea = new Tar_Tareas();
                    localTarea.FechaCreacion = DateTime.Now;
                    localTarea.IdUsuarioCreacion = idUsuario;
                    //localTarea.Descripcion = string.Format(taskDescription, local.ObservacionED, item.Hito, item.ActivityCode, item.Codigo);
                    localTarea.FechaFin = DateTime.Now.AddDays(observationTaskEndDate);
                    localTarea.FechaInicio = DateTime.Now;
                    localTarea.Estado = false;
                    localTarea.IdLista = listId;
                    localTarea.Prioridad = true;
                    localTarea.IdResponsable = proyecto.IdUsuarioResponsable;
                    Context.Add(localTarea);
                    Context.SaveChanges();

                    //log
                    string result = (from p in Context.tar_listas
                                     join pro in Context.pry_proyectos on p.IdProyecto equals pro.IdProyecto
                                     where p.Id == listId
                                     select pro.Nombre).FirstOrDefault();

                    //TO DO: Adicionar lógica para enviar el mensaje
                }
            }
            //
            Context.SaveChanges();
        }
    }

    public class EvaluacionActividadesObject
    {
        public List<SELEVALUACIONESACTIVIDADESPERIODO_Result> evaluacionesActividades { get; set; }

    }
    #endregion

    #region indicadores
    public class IndicadoresProyectoRepository : IIndicadoresProyectoRepository
    {
        private IContextRepository Context;

        public IndicadoresProyectoRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public Indicators GetIndicators(int objectiveId)
        {
            Indicators _indicators = new Indicators();

            Progress progress = (from p in Context.pry_objetivos
                                 where p.IdObjetivo == objectiveId
                                 join q in Context.pry_nivelaceptacion on p.IdNivelAceptacion equals q.IdNivelAceptacion into pq
                                 from r in pq.DefaultIfEmpty()
                                 select new Progress() { Actual = p.Progreso, Color = r.Color, Description = r.Descripcion, Name = r.Nombre }).FirstOrDefault();
            _indicators.Progress = progress;
            Progress effectiveness = (from p in Context.pry_objetivos
                                      where p.IdObjetivo == objectiveId
                                      join q in Context.pry_nivelaceptacion on p.IdNivelAceptacionEfectividad equals q.IdNivelAceptacion into pq
                                      from r in pq.DefaultIfEmpty()
                                      select new Progress() { Actual = p.Efectividad, Color = r.Color, Description = r.Descripcion, Name = r.Nombre }).FirstOrDefault();
            _indicators.Effectiveness = effectiveness;
            Progress effectivenessOverTime = (from p in Context.pry_objetivos
                                              where p.IdObjetivo == objectiveId
                                              join q in Context.pry_nivelaceptacion on p.IdNivelAceptacionEficacia equals q.IdNivelAceptacion into pq
                                              from r in pq.DefaultIfEmpty()
                                              select new Progress() { Actual = p.Eficacia, Color = r.Color, Description = r.Descripcion, Name = r.Nombre }).FirstOrDefault();
            _indicators.EffectivenessOverTime = effectivenessOverTime;
            Progress efficiency = (from p in Context.pry_objetivos
                                   where p.IdObjetivo == objectiveId
                                   join q in Context.pry_nivelaceptacion on p.IdNivelAceptacionEficiencia equals q.IdNivelAceptacion into pq
                                   from r in pq.DefaultIfEmpty()
                                   select new Progress() { Actual = p.Eficiencia, Color = r.Color, Description = r.Descripcion, Name = r.Nombre }).FirstOrDefault();
            _indicators.Eficiency = efficiency;

            var budget = (from p in Context.pry_objetivos
                          where p.IdObjetivo == objectiveId
                          join q in Context.pry_nivelaceptacion on p.IdNivelAceptacionCosto equals q.IdNivelAceptacion into pq
                          from r in pq.DefaultIfEmpty()
                          join sp in Context.pry_presupuesto on p.IdObjetivo equals sp.IdObjetivo into prsp
                          from t in prsp.DefaultIfEmpty()
                          where t.IdDonante == null
                          select new Progress() { Scheduled = t.Monto, Actual = p.Costo, Color = r.Color, Description = r.Descripcion, Name = r.Nombre }).FirstOrDefault();

            _indicators.Budget = budget;
            return _indicators;
        }

        public Object GetProjectObjectives(int idProyecto)
        {
            int? idProposito = (from p in Context.pry_proyectos
                                where p.IdProyecto == idProyecto
                                select p.IdProposito).FirstOrDefault();

            if (idProposito.HasValue) return GetPurposeObjectives(idProposito.Value);
            else return null;
        }

        public Object GetPurposeObjectives(int idPurpose)
        {
            int? id = idPurpose;
            List<Objective> objectives = new List<Objective>();

            //Get purpose - Level 2
            Objective purpose = (from p in Context.pry_objetivos
                                 join type in Context.pry_objetivosclase on p.IdObjetivoClase equals type.IdObjetivoClase
                                 join res in Context.sys_usuarios on p.IdResponsable equals res.IdUsuario into resFinal
                                 from res in resFinal.DefaultIfEmpty()
                                 where p.IdObjetivo == id
                                 select new Objective
                                 {
                                     Code = p.Codigo,
                                     Description = p.Descripcion,
                                     EndDate = p.FechaFin,
                                     Id = p.IdObjetivo,
                                     IdFather = p.IdPadre,
                                     IdResponsible = p.IdResponsable,
                                     IdType = p.IdObjetivoClase,
                                     ReportedCost = p.CostoNotificado,
                                     ReportedEffectiveness = p.EfectividadNotificada,
                                     Responsible = res.Nombre,
                                     StarDate = p.FechaInicio,
                                     TypeName = type.Descripcion,
                                     Weighted = p.Ponderado
                                 }).FirstOrDefault();
            purpose.Children = new List<Objective>();
            if (purpose != null)
            {
                purpose.Indicator = GetIndicators(purpose.Id);
                //goal and purpose - Level 1
                Objective main = (from p in Context.pry_objetivos
                                  join type in Context.pry_objetivosclase on p.IdObjetivoClase equals type.IdObjetivoClase
                                  join res in Context.sys_usuarios on p.IdResponsable equals res.IdUsuario into resFinal
                                  from res in resFinal.DefaultIfEmpty()
                                  where p.IdObjetivo == purpose.IdFather
                                  select new Objective
                                  {
                                      Code = p.Codigo,
                                      Description = p.Descripcion,
                                      EndDate = p.FechaFin,
                                      Id = p.IdObjetivo,
                                      IdFather = p.IdPadre,
                                      IdResponsible = p.IdResponsable,
                                      IdType = p.IdObjetivoClase,
                                      ReportedCost = p.CostoNotificado,
                                      ReportedEffectiveness = p.EfectividadNotificada,
                                      Responsible = res.Nombre,
                                      StarDate = p.FechaInicio,
                                      TypeName = type.Descripcion,
                                      Weighted = p.Ponderado
                                  }).FirstOrDefault();

                main.Indicator = GetIndicators(main.Id);
                main.Children = new List<Objective>();
                main.Children.Add(purpose);
                purpose.Parent = main;

                //Get products // Level 3
                List<Objective> products = (from p in Context.pry_objetivos
                                            join type in Context.pry_objetivosclase on p.IdObjetivoClase equals type.IdObjetivoClase
                                            join p2 in Context.pry_objetivos on p.IdObjetivo equals p2.IdPadre
                                            join res in Context.sys_usuarios on p.IdResponsable equals res.IdUsuario into resFinal
                                            from res in resFinal.DefaultIfEmpty()
                                            where p.IdPadre == id
                                            group p2 by new
                                            {
                                                p.Codigo,
                                                p.Descripcion,
                                                p.IdObjetivo,
                                                p.IdPadre,
                                                p.IdResponsable,
                                                p.IdObjetivoClase,
                                                p.CostoNotificado,
                                                p.EfectividadNotificada,
                                                res.Nombre,
                                                TypeName = type.Descripcion,
                                                p.Ponderado
                                            } into gFinal
                                            select new Objective
                                            {
                                                Code = gFinal.Key.Codigo,
                                                Description = gFinal.Key.Descripcion,
                                                Id = gFinal.Key.IdObjetivo,
                                                IdFather = gFinal.Key.IdPadre,
                                                IdResponsible = gFinal.Key.IdResponsable,
                                                IdType = gFinal.Key.IdObjetivoClase,
                                                ReportedCost = gFinal.Key.CostoNotificado,
                                                ReportedEffectiveness = gFinal.Key.EfectividadNotificada,
                                                Responsible = gFinal.Key.Nombre,
                                                StarDate = gFinal.Min(d => d.FechaInicio),
                                                EndDate = gFinal.Max(d => d.FechaFin),
                                                TypeName = gFinal.Key.TypeName,
                                                Weighted = gFinal.Key.Ponderado
                                            }).ToList();

                //Add products to purpose
                purpose.Children.AddRange(products);
                int purposeindex = 1;
                foreach (var product in products)
                {
                    product.Indicator = GetIndicators(product.Id);
                    product.Parent = purpose;
                    product.index = purposeindex;
                    purposeindex++;
                    product.Children = new List<Objective>();

                    //actividades - Level 4
                    List<Objective> activities = (from p in Context.pry_objetivos
                                                  join type in Context.pry_objetivosclase on p.IdObjetivoClase equals type.IdObjetivoClase
                                                  join res in Context.sys_usuarios on p.IdResponsable equals res.IdUsuario into resFinal
                                                  from res in resFinal.DefaultIfEmpty()
                                                  where p.IdPadre.HasValue && p.IdPadre.Value == product.Id
                                                  select new Objective
                                                  {
                                                      Code = p.Codigo,
                                                      Description = p.Descripcion,
                                                      EndDate = p.FechaFin,
                                                      Id = p.IdObjetivo,
                                                      IdFather = p.IdPadre,
                                                      IdResponsible = p.IdResponsable,
                                                      IdType = p.IdObjetivoClase,
                                                      ReportedCost = p.CostoNotificado,
                                                      ReportedEffectiveness = p.EfectividadNotificada,
                                                      Responsible = res.Nombre,
                                                      StarDate = p.FechaInicio,
                                                      TypeName = type.Descripcion,
                                                      Weighted = p.Ponderado
                                                  }).ToList();

                    product.Children.AddRange(activities);
                    int activityindex = 1;

                    foreach (var activity in activities)
                    {
                        activity.Parent = product;
                        activity.Indicator = GetIndicators(activity.Id);
                        activity.index = activityindex;
                        activityindex++;
                        activity.Children = new List<Objective>();
                    }
                }


                objectives.Add(main);
            }
            ProjectObjectives projectObjectives = new ProjectObjectives();
            projectObjectives.Objectives = objectives;
            return projectObjectives;
        }

        public Object GetIndicatorsDetail(int idObjetivo)
        {
            List<Indicator> indicators = null;
            indicators = (from p in Context.pry_indicadores
                          where p.IdObjetivo == idObjetivo
                          join q in Context.org_empleados on p.IdResponsableIndicador equals q.IdEmpleado
                          join r in Context.pry_indicadorestipos on p.IdTipo equals r.IdTipo
                          join s in Context.pry_indicadorestipos on p.IdSubTipo equals s.IdTipo

                          select new Indicator()
                          {
                              Base = p.Base,
                              Cobertura = p.Cobertura,
                              Cualidades = p.Cualidades,
                              Definicion = p.Definicion,
                              Descripcion = p.Descripcion,
                              FechaFin = p.FechaFin,
                              FechaInicio = p.FechaInicio,
                              Id = p.IdIndicador,
                              IdDatosMuestra = p.IdDatosMuestra,
                              IdObjetivo = p.IdObjetivo,
                              Meta = p.Meta,
                              Objetivo = p.Objetivo,
                              Ponderado = p.Ponderado,
                              Porcentual = p.Porcentual,
                              UnidadMedida = p.UnidadMedida,
                              UnidadOperativa = p.UnidadOperativa,
                              UnidadOperativaId = p.UnidadOperativaId,
                              Responsable = q.Nombre + " " + q.Apellido,
                              Tipo = r.Descripcion,
                              SubTipo = s.Descripcion,
                              Codigo = p.Codigo
                          }).Distinct().ToList();

            if (indicators != null)
            {
                foreach (var indicador in indicators)
                {
                    GetMuestrasPorIndicador(indicador, true /* incluir nueva muestra */);
                }
            }

            IndicadorObjetivoObject indicadorObjetivo = new IndicadorObjetivoObject();
            indicadorObjetivo.indicadoresObjetivo = indicators;
            return indicadorObjetivo;
        }

        public Object GetIndicatorDetail(int idIndicator)
        {
            Indicator indicator = (from p in Context.pry_indicadores
                                   where p.IdIndicador == idIndicator
                                   join q in Context.org_empleados on p.IdResponsableIndicador equals q.IdEmpleado
                                   join r in Context.pry_indicadorestipos on p.IdTipo equals r.IdTipo
                                   join s in Context.pry_indicadorestipos on p.IdSubTipo equals s.IdTipo

                                   select new Indicator()
                                   {
                                       Base = p.Base,
                                       Cobertura = p.Cobertura,
                                       Cualidades = p.Cualidades,
                                       Definicion = p.Definicion,
                                       Descripcion = p.Descripcion,
                                       FechaFin = p.FechaFin,
                                       FechaInicio = p.FechaInicio,
                                       Id = p.IdIndicador,
                                       IdDatosMuestra = p.IdDatosMuestra,
                                       IdObjetivo = p.IdObjetivo,
                                       Meta = p.Meta,
                                       Objetivo = p.Objetivo,
                                       Ponderado = p.Ponderado,
                                       Porcentual = p.Porcentual,
                                       UnidadMedida = p.UnidadMedida,
                                       UnidadOperativa = p.UnidadOperativa,
                                       UnidadOperativaId = p.UnidadOperativaId,
                                       Responsable = q.Nombre + " " + q.Apellido,
                                       Tipo = r.Descripcion,
                                       SubTipo = s.Descripcion,
                                       Codigo = p.Codigo
                                   }).Distinct().FirstOrDefault();

            if (indicator != null)
            {
                GetMuestrasPorIndicador(indicator, true /* incluir nueva muestra */);
            }

            return indicator;
        }

        private void GetMuestrasPorIndicador(Indicator indicador, bool incluirNueva)
        {
            Pry_Objetivos objetivo = Context.pry_objetivos.Where(a => a.IdObjetivo == indicador.IdObjetivo).FirstOrDefault();
            //validar que la muestra sea del siguiente período sin saltos
            var nextPeriodId = (from p in Context.pry_datosmuestras where p.IdIndicador == indicador.Id select p.IdPeriodo).Max() + 1;

            if (indicador.IdDatosMuestra != null)
            {
                List<Muestra> muestras = (from p in Context.pry_datosmuestras
                                          where p.IdIndicador == indicador.Id
                                          join q in Context.pry_nivelaceptacion on p.IdNivelAceptacionEfectividad equals q.IdNivelAceptacion
                                          join r in Context.pry_nivelaceptacion on p.IdNivelAceptacionEficacia equals r.IdNivelAceptacion
                                          join pe in Context.pry_periodosproyectos on p.IdPeriodo equals pe.IdPeriodo
                                          into pep
                                          from pepe in pep.DefaultIfEmpty()
                                          select new Muestra()
                                          {
                                              IdPeriodo = p.IdPeriodo.HasValue ? p.IdPeriodo.Value : 0,
                                              Periodo = pepe.Nombre,
                                              Fecha = p.IdPeriodo.HasValue ? pepe.FechaInicio : p.Fecha,//si hay periodo la fecha de la muestra es la fecha de inciio
                                              Id = p.IdDatosMuestra,
                                              IdIndicador = p.IdIndicador,
                                              Logro = p.Logro.HasValue ? p.Logro.Value : 0,
                                              Observaciones = p.Observaciones,
                                              Efectividad = new Progress() { Actual = p.Efectividad, Color = q.Color, Description = q.Descripcion, Name = q.Nombre },
                                              Eficacia = new Progress() { Actual = p.Eficacia, Color = r.Color, Description = r.Descripcion, Name = r.Nombre }
                                          }).Distinct().ToList();
                if (muestras != null)
                {
                    foreach (Muestra muestra in muestras)
                    {
                        muestra.NextPeriodId = nextPeriodId;

                        //13-Jul-2015 Cristina Cancelado
                        //Migrated from IProjectsService.GetVerificatorsByIndicator
                        if (indicador.IdDatosMuestra == muestra.Id)
                        {
                            indicador.DatosMuestraActual = muestra;

                            //aqui debo validar el periodo si esta o no esta cerrado
                            //*****Espacio para validacion
                            bool valPeriodo = true;//periodo true es porque puede borrar o editar, es decir que no esta cerrado
                            if (valPeriodo)
                            {
                                //valido si hay generados informes de indicadores. estos informes son los que vienen en 
                                //adlumen antes de hacer lo del iica pero hjay que ponerlos porque cuando se activen de nuevo
                                //debe funcionar bien
                                var informeIndicador = (from p in Context.pry_informes_indicador
                                                        where p.IdDatosMuestra == muestra.Id && p.IdIndicador == indicador.Id
                                                        select p).FirstOrDefault();
                                if (informeIndicador == null)
                                {
                                    muestra.CanDelete = true;
                                    muestra.CanEdit = true;
                                }
                                else
                                {
                                    muestra.CanDelete = false;
                                    muestra.CanEdit = false;
                                }
                            }
                        }
                        else
                        {
                            muestra.CanDelete = false;
                            muestra.CanEdit = false;
                        }

                        GetAccountability(indicador, objetivo, muestra);

                    }
                    indicador.DatosMuestra = muestras;
                }
            }
            if (incluirNueva)
            {
                Muestra nuevaMuestra = new Muestra()
                {
                    Id = 0, //Nueva
                    IdPeriodo = nextPeriodId.HasValue ? nextPeriodId.Value : 0,
                    IdIndicador = indicador.Id,
                    CanEdit = true,
                    CanDelete = true
                };
                GetAccountability(indicador, objetivo, nuevaMuestra);
                indicador.NuevaMuestra = nuevaMuestra;
            }
        }

        private void GetAccountability(Indicator indicador, Pry_Objetivos objetivo, Muestra muestra)
        {
            //13-Jul-2015 Cristina Cancelado
            //Migrated from IProjectsService.Accountability
            //traer el informe
            DateTime dtReportDate = DateTime.Now;
            ReportIndicator reportIndicator = null;
            var informe = (from p in Context.pry_informes
                           join q in Context.pry_informes_indicador on p.IdInforme equals q.IdInforme into pq
                           from r in pq.DefaultIfEmpty()
                           orderby p.FechaProgramada
                           where p.IdProyecto == objetivo.IdProyecto && p.FechaInforme >= dtReportDate && r.IdIndicador == indicador.Id && r.Meta != 0
                           select new { ReportId = p.IdInforme, Date = p.FechaProgramada, Goal = r.Meta }).FirstOrDefault();
            if (informe != null)
            {
                reportIndicator = new ReportIndicator();
                reportIndicator.Id = informe.ReportId;
                reportIndicator.Date = Convert.ToDateTime(informe.Date, CultureInfo.InvariantCulture);
                reportIndicator.Goal = informe.Goal;
                reportIndicator.IndicatorId = indicador.Id;
            }
            //traer las variables
            List<string> sVar = new List<string>();

            if (!string.IsNullOrEmpty(indicador.UnidadOperativaId)) sVar = indicador.UnidadOperativaId.Split('|').ToList();

            List<int> lVar = new List<int>();
            foreach (var item in sVar)
            {
                if (!item.Equals("") && item.StartsWith("$"))
                {
                    string itemLocal = item.Substring(1).Trim();
                    lVar.Add(Convert.ToInt32(itemLocal, CultureInfo.InvariantCulture));
                }
            }

            List<Variables> variables = (from p in Context.pry_variables
                                         where lVar.Contains(p.IdVariable)
                                         select new Variables() { Id = p.IdVariable, Description = p.Nombre, Source = p.FuenteInformacion }).ToList();

            foreach (Variables variable in variables)
            {
                double valor = (from p in Context.pry_datosvariables
                                where p.IdDatosMuestra == muestra.Id
                                && p.IdVariable == variable.Id
                                select (double)p.Valor).FirstOrDefault();

                variable.Value = valor;
            }

            //traemos los verificadores por indicador
            List<Verificators> verificators = (from p in Context.pry_datosverificadores
                                               where p.IdDatosMuestra == muestra.Id
                                               join q in Context.pry_indicadoresverificadores on p.IdVerificador equals q.IdVerificador
                                               select new Verificators()
                                               {
                                                   Id = p.IdDatosFuentes,
                                                   IdMuestra = (int)p.IdDatosMuestra,
                                                   IdVerificator = (int)p.IdVerificador,
                                                   URL = p.Url,
                                                   Description = q.Descripcion,
                                                   IsNew = false
                                               }).ToList();

            foreach (Verificators verificator in verificators)
            {
                verificator.FileName = (!string.IsNullOrEmpty(verificator.URL) && verificator.URL.LastIndexOf("/") != -1 ? verificator.URL.Substring(verificator.URL.LastIndexOf("/") + 1) : null);
            }

            //armamos el resultado
            muestra.Variables = variables;
            muestra.Verificators = verificators;
            muestra.ReportIndicator = reportIndicator;
        }

        //retorna una muestra por Id
        public Pry_DatosMuestras GetDatosMuestrasById(int id)
        {
            return Context.pry_datosmuestras.FirstOrDefault(m => m.IdDatosMuestra == id);
        }

        public void modifyMuestra()
        {
            Context.SaveChanges();
        }

        public void deleteMuestra(Pry_DatosMuestras muestra)
        {
            List<Pry_DatosVerificadores> tmpDatosVerificadores = new List<Pry_DatosVerificadores>();

            foreach (Pry_DatosVerificadores datosVerificadores in muestra.Pry_DatosVerificadores)
            {
                tmpDatosVerificadores.Add(datosVerificadores);
            }

            foreach (Pry_DatosVerificadores datosVerificadores in tmpDatosVerificadores)
            {
                Context.Delete(datosVerificadores);
                Context.SaveChanges();
            }

            List<Pry_DatosVariables> tmpDatosVariables = new List<Pry_DatosVariables>();

            foreach (Pry_DatosVariables datosVariables in muestra.Pry_DatosVariables)
            {
                tmpDatosVariables.Add(datosVariables);
            }

            foreach (Pry_DatosVariables datosVariables in tmpDatosVariables)
            {
                Context.Delete(datosVariables);
                Context.SaveChanges();
            }

            Pry_Indicadores indicador = Context.pry_indicadores.Where(a => a.IdIndicador == muestra.IdIndicador).FirstOrDefault();
            int? maxMuestraId = (Context.pry_datosmuestras.Where(a => a.IdIndicador == muestra.IdIndicador && a.IdDatosMuestra != muestra.IdDatosMuestra).Count() > 0) ?
                                Context.pry_datosmuestras.Where(a => a.IdIndicador == muestra.IdIndicador && a.IdDatosMuestra != muestra.IdDatosMuestra).Max(a => a.IdDatosMuestra) : (int?)null;
            indicador.IdDatosMuestra = maxMuestraId;

            Context.Delete(muestra);
            Context.SaveChanges();
        }

        public Pry_DatosVariables GetDatosVariablesById(int idMuestra, int idVariable)
        {
            return Context.pry_datosvariables.FirstOrDefault(m => m.IdDatosMuestra == idMuestra && m.IdVariable == idVariable);
        }

        public Sys_Usuarios GetUsuarioById(int idUsuario)
        {
            return Context.sys_usuarios.Where(a => a.IdUsuario == idUsuario).FirstOrDefault();
        }

        public void addDatosMuestra(Pry_DatosMuestras newDatosMuestra)
        {
            Context.Add(newDatosMuestra);
            Context.SaveChanges();
        }

        public void addDatosVariable(Pry_DatosVariables newDatosVariable)
        {
            Context.Add(newDatosVariable);
            Context.SaveChanges();
        }

        public void addDatosVerificador(Pry_DatosVerificadores newDatosVerificador)
        {
            Context.Add(newDatosVerificador);
            Context.SaveChanges();
        }

        public void deleteDatosVerificador(int idDatosFuentes)
        {
            Pry_DatosVerificadores datosVerificador = Context.pry_datosverificadores.Where(a => a.IdDatosFuentes == idDatosFuentes).FirstOrDefault();
            if (datosVerificador != null)
            {
                Context.Delete(datosVerificador);
                Context.SaveChanges();
            }
        }

        public Pry_DatosVerificadores GetDatoVerificador(int id)
        {
            return Context.pry_datosverificadores.Where(a => a.IdDatosFuentes == id).FirstOrDefault();
        }

        public void actualizarIndicador(Pry_DatosMuestras muestra)
        {
            Pry_Indicadores indicador = Context.pry_indicadores.Where(a => a.IdIndicador == muestra.IdIndicador).FirstOrDefault();
            indicador.IdDatosMuestra = muestra.IdDatosMuestra;
            Context.SaveChanges();
        }

        public void actualizarLogros(Pry_DatosMuestras muestra, bool nuevaMuestra)
        {
            //14/Jul/2015 - Cristina Cancelado
            //Esta función se ha creado con la fusión de las funciones InsertarSL y EditarSL del paquete BizEntities.Projects.Muestras
            //------------------------------------------------------------------------------------------------------------------------
            //calcular nuevamente el logro para la muestra, para el indicador y para el objetivo
            Pry_Indicadores indicador = Context.pry_indicadores.Where(a => a.IdIndicador == muestra.IdIndicador).FirstOrDefault();
            Pry_Objetivos objetivo = Context.pry_objetivos.Where(a => a.IdObjetivo == indicador.IdObjetivo).FirstOrDefault();

            int intIdInforme = 0;
            double intLogro = 0;
            //Indicador
            double baseP = indicador.Base;
            double metaP = indicador.Meta;
            DateTime fechaI = indicador.FechaInicio.Value;
            DateTime fechaP = indicador.FechaFin.Value;
            double PonderadoIndicador = indicador.Ponderado.Value;
            //Objetivo
            double progresoT = 0;
            double eficaciaT = 0;
            double efectividadT = 0;
            int intIdNivelAceptacionEficaciaT = 0;
            int intIdNivelAceptacionEfectividadT = 0;
            int intIdNivelAceptacionT = 0;

            //1.traemos la meta del informe mas cercano... Primero traermos el informe
            var informe = (from p in Context.pry_informes
                           join q in Context.pry_informes_indicador on p.IdInforme equals q.IdInforme into pq
                           from r in pq.DefaultIfEmpty()
                           orderby p.FechaProgramada
                           where p.IdProyecto == objetivo.IdProyecto && p.FechaInforme >= DateTime.Now && r.IdIndicador == indicador.IdIndicador && r.Meta != 0
                           select new { ReportId = p.IdInforme, Date = p.FechaProgramada, Goal = r.Meta }).FirstOrDefault();

            //aqui puede no ser una meta cercana.
            if (informe != null)
            {
                //tomamos el primer informe que es el mas cercano
                intIdInforme = (int)informe.ReportId;
                fechaP = (DateTime)informe.Date;
                metaP = (double)informe.Goal;
            }

            //2. calculamos el valor del indicador segun las variables
            string strFormula = indicador.UnidadOperativaId;
            string[] formulaSplit = strFormula.Split('|');
            string strFormulaFinal = "";
            foreach (string str in formulaSplit)
            {
                string strAux = str;
                if (str.StartsWith("$"))
                {
                    foreach (Pry_DatosVariables var in muestra.Pry_DatosVariables)
                    {
                        if (str.Equals("$" + var.IdVariable.ToString()))
                            strAux = var.Valor.ToString();
                    }
                }
                strFormulaFinal += strAux;
            }

            //18-Jul-2015 Cristina Cancelado
            //Funcionalidad modificada por requrimiento de negocio:
            //  Al registrar el periodo el logro total debería  se acumula únicamente con el inmediatamente anterior
            //  porque allí ya estan acumulados los periodos anteriores.
            //Obtenemos el id del último periodo registrado para acumular solo el anterior.
            var previousPeriodId =  Context.pry_datosmuestras.Where(a => a.IdIndicador == indicador.IdIndicador && a.IdPeriodo < muestra.IdPeriodo).Max(a => a.IdPeriodo);

            foreach (Pry_DatosMuestras auxMuestra in Context.pry_datosmuestras.Where(a => a.IdIndicador == indicador.IdIndicador && a.IdPeriodo == previousPeriodId))
            {
                intLogro += (auxMuestra.Logro.HasValue ? auxMuestra.Logro.Value : 0);
            }

            //evaluamos la formula
            //TO DO: Evaluator needs to be defined
            //logro = intLogro +  Adlumen2.BizEntities.Masters.Evaluator.EvalToDouble(strFormulaFinal);
            double logro = intLogro + double.Parse(strFormulaFinal);

            var current = Context.pry_periodosproyectos.FirstOrDefault(p => p.IdPeriodo == muestra.IdPeriodo && p.IdProyecto == objetivo.IdProyecto);

            double tiempoE = current.FechaFin.Subtract(fechaI).Days;
            double tiempoP = fechaP.Subtract(fechaI).Days;
            double efectividad;
            double eficacia;

            //hallamos efectividad logro/meta en porcentaje y eficacia logro*tiempoPlaneado/meta * tiempoEjecutado
            if (metaP == 0)
            {
                efectividad = 100;
                eficacia = 100;
            }
            else
            {
                efectividad = (logro / (metaP - baseP)) * 100;//efectividad = (logro / metaP) * 100; antes solo se tomaba en cuenta el logro
                if (tiempoE == 0)//si tiempo es igual a cero se coloca el mismo valo en la eficacia que en l aefectividad
                    eficacia = efectividad;
                else
                    eficacia = ((logro / tiempoE) / ((metaP - baseP) / tiempoP)) * 100;//eficacia 
            }

            //3. calculamos el ponderado .. para saber el aporte del indicador en la realizacion del objetivo   
            double progreso = (efectividad * PonderadoIndicador) / 100;

            CostosRepository costosRepository = new CostosRepository(Context);
            //asigamos los niveles de aceptacion del indicador
            //para esta interpretacion el semaforo de la efectividad sera igual al de la eficacia ********************
            //intIdNivelAceptacionEfectividad = CalcularNivelAceptacion(dtNivelAceptacion, efectividad);
            IQueryable<Pry_Proyectos_NivelAceptacion> nivelesDeAceptacion = Context.pry_proyectos_nivelaceptacion.Where(a => a.IdProyecto == objetivo.IdProyecto);
            int intIdNivelAceptacionEficacia = costosRepository.CalcularNivelAceptacion(nivelesDeAceptacion, eficacia);
            int intIdNivelAceptacion = costosRepository.CalcularNivelAceptacion(nivelesDeAceptacion, progreso);
            int intIdNivelAceptacionEfectividad = intIdNivelAceptacion;

            //4. guardamos en datosmuestras
            if (nuevaMuestra)
            {
                muestra.Logro = logro;
                muestra.Efectividad = efectividad;
                muestra.Eficacia = eficacia;
                muestra.IdNivelAceptacionEfectividad = intIdNivelAceptacionEfectividad;
                muestra.IdNivelAceptacionEficacia = intIdNivelAceptacionEficacia;
                muestra.Fecha = current.FechaFin;//fecha final del periodo

                Context.SaveChanges();
            }


            //traemos todos los indicadores del objetivo para el progreso
            foreach (Pry_DatosMuestras auxMuestra in indicador.Pry_DatosMuestras)
            {
                double ProgresoIndicador = ((auxMuestra.Efectividad.HasValue ? auxMuestra.Efectividad.Value : 0) * (indicador.Ponderado.HasValue ? indicador.Ponderado.Value : 0)) / 100;
                double EficaciaIndicador = ((auxMuestra.Eficacia.HasValue ? auxMuestra.Eficacia.Value : 0) * (indicador.Ponderado.HasValue ? indicador.Ponderado.Value : 0)) / 100;
                progresoT += ProgresoIndicador;
                efectividadT += ProgresoIndicador;
                eficaciaT += EficaciaIndicador;
            }

            //asigamos los niveles de aceptacion del indicador
            //para esta interpretacion el semaforo de la efectividad sera igual al de la eficacia ***********************
            //intIdNivelAceptacionEfectividadT = CalcularNivelAceptacion(dtNivelAceptacion, efectividadT);
            intIdNivelAceptacionEficaciaT = costosRepository.CalcularNivelAceptacion(nivelesDeAceptacion, eficaciaT);
            intIdNivelAceptacionEfectividadT = costosRepository.CalcularNivelAceptacion(nivelesDeAceptacion, efectividadT);
            //int idNivelAceptacionEficienciaT = CalcularNivelAceptacion(dtNivelAceptacion, eficienciaT);
            //intIdNivelAceptacionT = CalcularNivelAceptacion(dtNivelAceptacion, progresoT);
            intIdNivelAceptacionT = intIdNivelAceptacionEficaciaT;

            /******************************************/
            //aqui revisar lo de la eficiencia si ya existe.
            /*************************************************/

            //6. actualizar objetivo en la base de datos.
            objetivo.Efectividad = efectividadT;
            objetivo.Eficacia = eficaciaT;
            objetivo.Progreso = progresoT;
            objetivo.IdNivelAceptacionEfectividad = intIdNivelAceptacionEfectividadT;
            objetivo.IdNivelAceptacionEficacia = intIdNivelAceptacionEficaciaT;
            objetivo.IdNivelAceptacion = intIdNivelAceptacionT;

            Context.SaveChanges();

            //7. Buscar el objetivo y recalcular. para progreso.              
            //traemos los objetivos hijos. A menos que sea finalidad.
            //sacar ponderados de cada uno.. ponderado total y ponderado relativo. y calculamos el del objetivo.
            //guardar y llamar al padre.
            CalcularPonderadosObjetivos(objetivo.IdObjetivo);

            //hacemos calculos de eficiencia *************esta a prueba
            costosRepository.CalcularCostoObjetivos(objetivo.IdObjetivo, nivelesDeAceptacion, 2, muestra.IdPeriodo.Value);
        }

        private void CalcularPonderadosObjetivos(int idObjetivo)
        {
            Pry_Objetivos objetivo = Context.pry_objetivos.Where(a => a.IdObjetivo == idObjetivo).FirstOrDefault();
            if (objetivo != null && objetivo.IdPadre != null)
            {
                if (objetivo.IdObjetivoClase == (int)ObjectiveClass.Activity)//actividad nohace nada pues no tiene hijos
                    CalcularPonderadosObjetivos(objetivo.IdPadre.Value);
                else if (objetivo.IdObjetivoClase == (int)ObjectiveClass.Purpose ||
                    objetivo.IdObjetivoClase == (int)ObjectiveClass.Result ||
                    objetivo.IdObjetivoClase == (int)ObjectiveClass.Product)//componente o proposito debe traer todos los hijos y recalcular.
                {
                    ActualizarProgreso(idObjetivo);
                    CalcularPonderadosObjetivos(objetivo.IdPadre.Value);
                }
                else if (objetivo.IdObjetivoClase == (int)ObjectiveClass.EndGoal) //finalidad debe actualizar pero ademas no debe llamar por padre.
                {
                    ActualizarProgreso(idObjetivo);
                }
            }
        }

        private void ActualizarProgreso(int idObjetivo)
        {
            //traemos los hijos
            Pry_Objetivos objetivo = Context.pry_objetivos.Where(a => a.IdObjetivo == idObjetivo).FirstOrDefault();
            IQueryable<Pry_Objetivos> hijos = Context.pry_objetivos.Where(a => a.IdPadre == idObjetivo);
            double progreso = 0;

            if (objetivo.IdObjetivoClase == 1 && hijos.Count() == 1)
            {
                hijos.FirstOrDefault().Ponderado = 100;
            }
            //
            foreach (Pry_Objetivos hijo in hijos)
            {
                double ponderado = ((hijo.Ponderado.HasValue ? hijo.Ponderado.Value : 0) * (hijo.Progreso.HasValue ? hijo.Progreso.Value : 0)) / 100;
                progreso += ponderado;
            }
            //insertar nuevo ponderado en el papa
            objetivo.Progreso = progreso;
            Context.SaveChanges();
        }

        public Object GetVerificadoresIndicador(int idIndicador)
        {
            List<IndicadorVerificador> verificadores = (from p in Context.pry_indicadoresverificadores
                                                        where p.IdIndicador == idIndicador
                                                        select new IndicadorVerificador() { idVerificador = p.IdVerificador, idIndicador = p.IdIndicador, description = p.Descripcion }).ToList();
            VerificadoresObject verificadoresObject = new VerificadoresObject();
            verificadoresObject.verificadores = verificadores;
            return verificadoresObject;
        }

        public class VerificadoresObject
        {
            public List<IndicadorVerificador> verificadores { get; set; }
        }

        public class IndicadorObjetivoObject
        {
            public List<Indicator> indicadoresObjetivo { get; set; }
        }

        public class ProjectObjectives
        {
            public List<Objective> Objectives { get; set; }
        }

        public class Objective
        {
            public int Id { get; set; }
            public int? IdFather { get; set; }
            public int? IdType { get; set; }
            public string TypeName { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }
            public int? IdResponsible { get; set; }
            public string Responsible { get; set; }
            public DateTime? StarDate { get; set; }
            public DateTime? EndDate { get; set; }
            public double? Weighted { get; set; }
            public Indicators Indicator { get; set; }
            public bool ReportedCost { get; set; }
            public bool ReportedEffectiveness { get; set; }
            public Objective Parent { get; set; }
            public List<Objective> Children { get; set; }
            public int? index { get; set; }
        }

        public class Indicators
        {
            public Progress Progress { get; set; }
            public Progress Effectiveness { get; set; }
            public Progress EffectivenessOverTime { get; set; }
            public Progress Eficiency { get; set; }
            public Progress Budget { get; set; }
        }

        public class Progress
        {
            public double? Scheduled { get; set; }
            public double? Actual { get; set; }
            public string Color { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class Indicator
        {
            public int Id { get; set; }
            public int? IdObjetivo { get; set; }
            public string Codigo { get; set; }
            public string Tipo { get; set; }
            public string SubTipo { get; set; }
            public string Descripcion { get; set; }
            public string Definicion { get; set; }
            public string Objetivo { get; set; }
            public string Cualidades { get; set; }
            public string UnidadMedida { get; set; }
            public string Cobertura { get; set; }
            public string Responsable { get; set; }
            public string UnidadOperativa { get; set; }
            public string UnidadOperativaId { get; set; }
            public DateTime? FechaInicio { get; set; }
            public DateTime? FechaFin { get; set; }
            public double Base { get; set; }
            public double Meta { get; set; }
            public bool Porcentual { get; set; }
            public double? Ponderado { get; set; }
            public int? IdDatosMuestra { get; set; }
            public List<Muestra> DatosMuestra { get; set; }
            public Muestra NuevaMuestra { get; set; }
            public Muestra DatosMuestraActual { get; set; }
        }

        public class Muestra
        {
            public int Id { get; set; }
            public int? IdIndicador { get; set; }
            public DateTime? Fecha { get; set; }
            public double Logro { get; set; }
            public string Observaciones { get; set; }
            public Progress Efectividad { get; set; }
            public Progress Eficacia { get; set; }
            public DateTime Date { get; set; }
            public List<Verificators> Verificators { get; set; }
            public List<Variables> Variables { get; set; }
            public Int64 IdPeriodo { get; set; }
            public string Periodo { get; set; }
            public ReportIndicator ReportIndicator { get; set; }
            public bool CanEdit { get; set; }
            public bool CanDelete { get; set; }
            public Int64? NextPeriodId { get; set; }
        }

        public class Verificators
        {
            public int Id { get; set; }
            public int IdMuestra { get; set; }
            public int IdVerificator { get; set; }
            public string URL { get; set; }
            public string Description { get; set; }
            public bool IsNew { get; set; }
            public byte[] File { get; set; }
            public bool Deleted { get; set; }
            public string FileName { get; set; }
        }

        public class Variables
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public string Source { get; set; }
            public virtual double Value { get; set; }
        }

        public class ReportIndicator
        {
            public int Id { get; set; }
            public int IndicatorId { get; set; }
            public double? Goal { get; set; }
            public DateTime Date { get; set; }
        }

        public class IndicadorVerificador
        {
            public int idVerificador { get; set; }
            public int idIndicador { get; set; }
            public string description { get; set; }
        }
    }
    #endregion

    #region Costos Repository
    public class CostosRepository : ICostosRepository
    {
        //Interface de acceso a datos
        private IContextRepository Context;

        public CostosRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public void CalcularCostoObjetivos(int idObjetivo, IQueryable<Pry_Proyectos_NivelAceptacion> nivelesDeAceptacion, int tipo, long idPeriodo)
        {
            Pry_Objetivos objetivo = Context.pry_objetivos.Where(a => a.IdObjetivo == idObjetivo).FirstOrDefault();
            IQueryable<Pry_Presupuesto> presupuestos = Context.pry_presupuesto.Where(a => a.IdObjetivo == idObjetivo);
            foreach (Pry_Presupuesto presupuesto in presupuestos.ToList())
            {
                //tipo 
                //1. se esta haciendo movimientos financieros
                //2. se estan introduciendo muestras en los indicadores
                double efectividad = objetivo.Efectividad.HasValue ? objetivo.Efectividad.Value : 0;
                double Presupuesto = presupuesto.Monto.HasValue ? presupuesto.Monto.Value : 0;
                double Costo = objetivo.Costo.HasValue ? objetivo.Costo.Value : 0;

                if (objetivo.IdObjetivoClase == (int)ObjectiveClass.Activity)//actividad se actualiza ella misma
                {
                    if (Costo > 1 || tipo.Equals(1))
                        ActualizarCosto(idObjetivo, efectividad, Costo, Presupuesto, nivelesDeAceptacion, idPeriodo);
                    CalcularCostoObjetivos(objetivo.IdPadre.Value, nivelesDeAceptacion, tipo, idPeriodo);
                }
                else if (objetivo.IdObjetivoClase == (int)ObjectiveClass.Purpose || 
                    objetivo.IdObjetivoClase == (int)ObjectiveClass.Result ||
                    objetivo.IdObjetivoClase == (int)ObjectiveClass.Product)//componente o proposito debe traer todos los hijos y recalcular.
                {
                    if (Costo > 1 || tipo.Equals(1))
                        ActualizarCosto(idObjetivo, efectividad, Costo, Presupuesto, nivelesDeAceptacion, idPeriodo);
                    CalcularCostoObjetivos(objetivo.IdPadre.Value, nivelesDeAceptacion, tipo, idPeriodo);
                }
                else if (objetivo.IdObjetivoClase == (int)ObjectiveClass.EndGoal)//finalidad debe actualizar pero ademas no debe llamar por padre. 
                    if (Costo > 1 || tipo.Equals(1))
                        ActualizarCosto(idObjetivo, efectividad, Costo, Presupuesto, nivelesDeAceptacion, idPeriodo);
            }
        }

        private void ActualizarCosto(int idObjetivo, double efectividad, double Costo, double presupuesto, IQueryable<Pry_Proyectos_NivelAceptacion> nivelesDeAceptacion, long idPeriodo)
        {
            //traemos los hijos
            Pry_Objetivos objetivo = Context.pry_objetivos.Where(a => a.IdObjetivo == idObjetivo).FirstOrDefault();
            IQueryable<Pry_Objetivos> hijos = Context.pry_objetivos.Where(a => a.IdPadre == idObjetivo);
            PRY_PERIODOSPROYECTOS periodo = Context.pry_periodosproyectos.Where(a => a.IdPeriodo == idPeriodo).FirstOrDefault();
            double costo = Costo;
            //si es actividad no tiene hijos
            if (hijos.Count() > 0)
                costo = 0;
            foreach (Pry_Objetivos hijo in hijos)
            {
                costo += (hijo.Costo.HasValue ? hijo.Costo.Value : 0);
            }

            DateTime fechaIT = Context.pry_indicadores.Where(a => a.IdObjetivo == idObjetivo).Min(a => a.FechaInicio).Value;
            DateTime fechaFT = Context.pry_indicadores.Where(a => a.IdObjetivo == idObjetivo).Max(a => a.FechaInicio).Value;

            //insertar nuevo ponderado en el papa
            double eficiencia = 1;
            int intIdNivelAceptacion = 1;
            if (costo > 0)//podemos preguntar por la eficcia si es uno que no procese
            {
                int diferenciaFechaIndicadores = fechaFT.Subtract(fechaIT).Days;
                eficiencia = (efectividad * presupuesto * periodo.FechaFin.Subtract(fechaIT).Days) / (costo * (diferenciaFechaIndicadores == 0 ? 1 : diferenciaFechaIndicadores /* agregado para prevenir división por 0 */));
                intIdNivelAceptacion = CalcularNivelAceptacion(nivelesDeAceptacion, eficiencia);
            }

            objetivo.Costo = costo;
            objetivo.Eficiencia = eficiencia;
            objetivo.IdNivelAceptacionEficiencia = intIdNivelAceptacion;
            Context.SaveChanges();
        }

        public int CalcularNivelAceptacion(IQueryable<Pry_Proyectos_NivelAceptacion> nivelesDeAceptacion, double progreso)
        {
            int intIdNivelAceptacion = 0;
            foreach (Pry_Proyectos_NivelAceptacion nivel in nivelesDeAceptacion)
            {
                if (progreso > nivel.Valor)
                {
                    intIdNivelAceptacion = nivel.IdNivelAceptacion;
                    break;
                }
                else
                    intIdNivelAceptacion = nivel.IdNivelAceptacion;
            }
            return intIdNivelAceptacion;
        }
    }
    #endregion

    #region Empresas Repository

    public class EmpresasRepository : IEmpresasRepository
    {
        private string[] asp_roles = new string[]
        {
            "socialadministrator", "socialdonor", "socialevaluator", "socialmanager", "socialtypesetter"
        };

        //Interface de acceso a datos
        private IContextRepository Context;

        public EmpresasRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        //retorna el listado de todas las empresas
        public IEnumerable<Object> GetEmpresasActivas()
        {
            return (from empresa in Context.org_empresas
                    where empresa.Eliminado == false
                    orderby empresa.Nombre
                    select new
                    {
                        empresa.IdEmpresa,
                        empresa.Nombre,
                        empresa.URL,
                        empresa.Telefono,
                        empresa.IdCliente
                    }).ToList();
        }

        public IEnumerable<Object> GetIdentificacionTipos()
        {
            return (from identificador in Context.org_identificaciontipos
                    orderby identificador.Nombre
                    select new
                    {
                        identificador.IdIdentificacionTipo,
                        identificador.Nombre
                    }).ToList();
        }

        public Org_Empresas GetEmpresa(int idEmpresa)
        {
            var context = Context as Adlumen2SocEntities;
            var company = context.Org_Empresas.Include(x => x.Sys_Usuarios).FirstOrDefault(a => a.IdEmpresa == idEmpresa);
            return company;
        }

        //retorna una empresa por id
        public Object GetEmpresaById(int idEmpresa)
        {
            EmpresaGeneralData empresaData = (from empresa in Context.org_empresas
                                              where empresa.IdEmpresa == idEmpresa
                                              select new EmpresaGeneralData()
                                              {
                                                  idEmpresa = empresa.IdEmpresa,
                                                  nombre = empresa.Nombre,
                                                  ubicacion = empresa.Ubicacion,
                                                  url = empresa.URL,
                                                  telefono = empresa.Telefono,
                                                  logo = empresa.Logo,
                                                  idIdentificacionTipo = empresa.IdIdentificacionTipo,
                                                  identificacion = empresa.Identificacion,
                                                  idPais = empresa.IdPais,
                                                  latitude = empresa.Latitude,
                                                  longitude = empresa.Longitude,
                                                  idCliente = empresa.IdCliente,
                                                  idCategoriaDocumentos = empresa.IdCategoriaDocumentos
                                              }).FirstOrDefault();

            if (empresaData != null)
            {
                empresaData.areas = GetAreasByEmpresa(idEmpresa);
                empresaData.cargos = GetCargosByEmpresa(idEmpresa);
                empresaData.proveedores = GetProveedoresByEmpresa(idEmpresa);
                if (empresaData.idCategoriaDocumentos.HasValue) empresaData.publicaciones = GetDocumentCategoriesByEmpresa(empresaData.idCategoriaDocumentos.Value);
                empresaData.usuarios = GetUsuarioByEmpresa(idEmpresa, empresaData.idCliente);
                empresaData.availableRoles = GetAvailableRoles();
            }

            return empresaData;
        }

        public List<Area> GetAreasByEmpresa(int idEmpresa)
        {
            List<Area> areas = new List<Area>();
            foreach (Org_Areas org_area in Context.org_areas.Where(a => a.IdPadre == 0 && a.IdEmpresa == idEmpresa && a.Eliminado == false)) //get the parents
            {
                Area area = GetArea(org_area.IdArea);
                areas.Add(area);
            }
            return areas;
        }

        public Area GetArea(int idArea)
        {
            Area area = (from p in Context.org_areas
                         where p.IdArea == idArea
                         select new Area
                         {
                             idArea = p.IdArea,
                             nombre = p.Nombre,
                             objetivo = p.Objetivo,
                             descripcion = p.Descripcion,
                             idEmpresa = p.IdEmpresa,
                             idPadre = p.IdPadre,
                             idResponsable = p.IdResponsable,
                             eliminado = p.Eliminado,
                             nuevo = false
                         }).FirstOrDefault();

            if (area != null)
            {
                Org_Empleados empleado = Context.org_empleados.Where(a => a.IdEmpleado == area.idResponsable).FirstOrDefault();
                if (empleado != null) area.responsable = string.Format("{0} {1}", empleado.Nombre, empleado.Apellido);
                area.Children = new List<Area>();
                foreach (Org_Areas org_area in Context.org_areas.Where(a => a.IdPadre == idArea && a.Eliminado == false)) //get the children
                {
                    Area childArea = GetArea(org_area.IdArea);
                    childArea.Parent = area;
                    area.Children.Add(childArea);
                }
            }

            return area;
        }

        public List<Cargo> GetCargosByEmpresa(int idEmpresa)
        {
            List<Cargo> cargos = new List<Cargo>();
            foreach (Org_Cargos org_cargo in Context.org_cargos.Where(a => a.IdPadre == 0 && (a.Org_Areas != null && a.Org_Areas.IdEmpresa == idEmpresa) && a.Eliminado == false)) //get the parents
            {
                Cargo cargo = GetCargo(org_cargo.IdCargo);
                cargos.Add(cargo);
            }
            return cargos;
        }

        public Cargo GetCargo(int idCargo)
        {
            Cargo cargo = (from p in Context.org_cargos
                           where p.IdCargo == idCargo
                           select new Cargo
                           {
                               idArea = p.IdArea,
                               descripcion = p.Descripcion,
                               idPadre = p.IdPadre,
                               nombre = p.Nombre,
                               perfil = p.Perfil,
                               idCargo = p.IdCargo,
                               eliminado = p.Eliminado
                           }).FirstOrDefault();

            if (cargo != null)
            {
                cargo.empleados = GetEmpleadosByCargo(idCargo);
                cargo.Children = new List<Cargo>();
                foreach (Org_Cargos org_cargo in Context.org_cargos.Where(a => a.IdPadre == idCargo && a.Eliminado == false)) //get the children
                {
                    Cargo childCargo = GetCargo(org_cargo.IdCargo);
                    childCargo.Parent = cargo;
                    cargo.Children.Add(childCargo);
                }
            }

            return cargo;
        }

        public List<Empleado> GetEmpleadosByCargo(int idCargo)
        {
            List<Empleado> empleados = (from e in Context.org_empleados
                                        where e.IdCargo == idCargo && e.Retirado == false
                                        select new Empleado
                                        {
                                            EmployeeId = e.IdEmpleado,
                                            TitleId = (int)e.IdCargo,
                                            Name = e.Nombre,
                                            LastName = e.Apellido,
                                            IdType = e.IdIdentificacionTipo,
                                            IdNumber = e.Identificacion,
                                            Picture = e.Foto,
                                            Email = e.Correo,
                                            Observations = e.Observaciones,
                                            Competencies = e.Competencias,
                                            CV = e.HojaVida
                                        }).ToList();
            return empleados;
        }

        public List<Org_Empleados> GetEmployeesByCargo(int idCargo)
        {
            return Context.org_empleados.Where(x => x.IdCargo == idCargo && !x.Retirado).ToList();
        }

        public List<Object> GetEmpleadosActivos()
        {
            List<Object> empleados = (from e in Context.org_empleados
                                      where e.Retirado == false
                                      select new Empleado
                                      {
                                          EmployeeId = e.IdEmpleado,
                                          TitleId = (int)e.IdCargo,
                                          Name = e.Nombre,
                                          LastName = e.Apellido,
                                          IdType = e.IdIdentificacionTipo,
                                          IdNumber = e.Identificacion,
                                          Picture = e.Foto,
                                          Email = e.Correo,
                                          Observations = e.Observaciones,
                                          Competencies = e.Competencias,
                                          CV = e.HojaVida,
                                          Retired = e.Retirado
                                      }).ToList<Object>();
            return empleados;
        }

        public List<Supplier> GetProveedoresByEmpresa(int idEmpresa)
        {
            return (from p in Context.org_proveedores
                    join j in Context.org_identificaciontipos on p.IdIdentificacionTipo equals j.IdIdentificacionTipo
                    join k in Context.org_empresas on p.IdEmpresa equals k.IdEmpresa
                    where p.IdEmpresa == idEmpresa && p.Eliminado == false
                    select new Supplier
                    {
                        Id = p.IdProveedor,
                        IdCompany = p.IdEmpresa,
                        Name = p.Nombre,
                        IdIdentification = p.IdIdentificacionTipo,
                        Identification = p.Identificacion,
                        Phone = p.Telefono,
                        Location = p.Ubicacion,
                        Mail = p.Correo,
                        CV = p.HojaVida,
                        CreatedDate = p.FechaCreacion,
                        CreatedUserName = p.UsuarioCreacion,
                        UpdatedDate = p.FechaModificacion,
                        UpdatedUserName = p.UsuarioModificacion,
                        Delete = p.Eliminado,
                        IdentificationName = j.Nombre,
                        CompanyName = k.Nombre,
                        Deleted = p.Eliminado
                    }).ToList();
        }

        public List<Category> GetDocumentCategoriesByEmpresa(int idEmpresaCategoria)
        {
            List<Category> categorias = new List<Category>();
            foreach (Doc_Categorias doc_categoria in Context.doc_categorias.Where(a => a.IdPadre == 0 && a.IdCategoria == idEmpresaCategoria)) //get the parents
            {
                Category categoria = GetCategoria(doc_categoria.IdCategoria);
                categorias.Add(categoria);
            }
            return categorias;
        }

        public Category GetCategoria(int idCategoria)
        {
            Category categoria = (from p in Context.doc_categorias
                                  where p.IdCategoria == idCategoria
                                  select new Category
                                  {
                                      Id = p.IdCategoria,
                                      Description = p.Descripcion,
                                      ParentId = (int)p.IdPadre,
                                      Name = p.Nombre,
                                      Path = p.Ruta,
                                      Status = p.Estado,
                                      CreateDate = p.FechaCreacion,
                                      CreateUser = p.UsuarioCreacion,
                                      UpdateDate = p.FechaModificacion,
                                      UpdateUser = p.UsuarioModificacion,
                                      TypeId = p.IdTipo
                                  }).FirstOrDefault();

            if (categoria != null)
            {
                categoria.documents = GetDocumentosByCategoria(idCategoria);
                categoria.Children = new List<Category>();
                foreach (Doc_Categorias doc_categoria in Context.doc_categorias.Where(a => a.IdPadre == idCategoria)) //get the children
                {
                    Category childCategory = GetCategoria(doc_categoria.IdCategoria);
                    childCategory.Parent = categoria;
                    categoria.Children.Add(childCategory);
                }
            }

            return categoria;
        }

        public List<Document> GetDocumentosByCategoria(int idCategoria)
        {
            List<Document> documents = (from p in Context.doc_documentos
                                        where p.IdCategoria == idCategoria
                                        select new Document
                                        {
                                            CategoryId = p.IdCategoria,
                                            CreatedDate = p.FechaCreacion,
                                            CreatedUser = p.UsuarioCreacion,
                                            FileTypeId = p.IdTipoArchivo,
                                            Id = p.IdDocumento,
                                            KeyWords = p.PalabrasClaves,
                                            Resume = p.Resumen,
                                            Title = p.Titulo,
                                            UpdatedDate = p.FechaModificacion,
                                            UpdatedUser = p.UsuarioModificacion,
                                            Url = p.Url,
                                            Roles = p.Roles
                                        }).ToList();
            return documents;
        }

        public List<string> GetAvailableRoles()
        {
            return asp_roles.ToList();
        }

        public List<UserCompany> GetUsuarioByEmpresa(int idEmpresa, int? idCliente)
        {
            var users = new List<UserCompany>();
            var context = Context as Adlumen2SocEntities;

            var sys_usuarios = context.Sys_Usuarios
                .Include(x => x.Org_Empresas)
                .Where(a => a.CustomerId == idCliente);

            foreach (Sys_Usuarios sys_usuario in sys_usuarios)
            {
                UserCompany user = new UserCompany()
                {
                    idUsuario = sys_usuario.IdUsuario,
                    UserName = sys_usuario.UserName,
                    FullName = sys_usuario.Nombre
                };

                Org_Empresas org_empresa = sys_usuario.Org_Empresas.Where(a => a.IdEmpresa == idEmpresa).FirstOrDefault();
                if (org_empresa != null)
                {
                    user.idEmpresa = org_empresa.IdEmpresa;
                    user.include = true;
                }
                users.Add(user);
            }

            return users;
        }

        public Org_Areas GetAreaById(int idArea)
        {
            return Context.org_areas.Where(a => a.IdArea == idArea).FirstOrDefault();
        }

        public Org_Cargos GetCargoById(int idCargo)
        {
            return Context.org_cargos.Where(a => a.IdCargo == idCargo).FirstOrDefault();
        }

        public Org_Empleados GetEmpleadoById(int idEmpleado)
        {
            return Context.org_empleados.Where(a => a.IdEmpleado == idEmpleado).FirstOrDefault();
        }

        public Doc_Categorias GetCategoriaById(int idCategoria)
        {
            return Context.doc_categorias.Where(a => a.IdCategoria == idCategoria).FirstOrDefault();
        }

        public Doc_Documentos GetDocumentoById(int idDocumento)
        {
            return Context.doc_documentos.Where(a => a.IdDocumento == idDocumento).FirstOrDefault();
        }

        public Org_Proveedores GetProveedorById(int idProveedor)
        {
            return Context.org_proveedores.Where(a => a.IdProveedor == idProveedor).FirstOrDefault();
        }

        public Sys_Usuarios GetUsuarioById(int idUsuario)
        {
            return Context.sys_usuarios.Where(a => a.IdUsuario == idUsuario).FirstOrDefault();
        }

        public void addEmpresa(Org_Empresas newEmpresa)
        {
            Context.Add(newEmpresa);
            Context.SaveChanges();
        }

        public void modifyEmpresa()
        {
            Context.SaveChanges();
        }

        public void deleteEmpresa(Org_Empresas empresa)
        {
            empresa.Eliminado = true;
            Context.SaveChanges();
        }

        public void addArea(Org_Areas newArea)
        {
            Context.Add(newArea);
            Context.SaveChanges();
        }

        public void modifyArea()
        {
            Context.SaveChanges();
        }

        public void addCargo(Org_Cargos newCargo)
        {
            Context.Add(newCargo);
            Context.SaveChanges();
        }

        public void modifyCargo()
        {
            Context.SaveChanges();
        }

        public void addEmpleado(Org_Empleados newEmpleado)
        {
            Context.Add(newEmpleado);
            Context.SaveChanges();
        }

        public void modifyEmpleado()
        {
            Context.SaveChanges();
        }

        public void addCategoria(Doc_Categorias newCategoria)
        {
            Context.Add(newCategoria);
            Context.SaveChanges();
        }

        public void modifyCategoria()
        {
            Context.SaveChanges();
        }

        public void addDocumento(Doc_Documentos newDocumento)
        {
            Context.Add(newDocumento);
            Context.SaveChanges();
        }

        public void modifyDocumento()
        {
            Context.SaveChanges();
        }

        public void addProveedor(Org_Proveedores newProveedor)
        {
            Context.Add(newProveedor);
            Context.SaveChanges();
        }

        public void modifyProveedor()
        {
            Context.SaveChanges();
        }

        public void deleteUsuariosEmpresa(Org_Empresas empresa)
        {
            List<Sys_Usuarios> tmpUsuarios = new List<Sys_Usuarios>();
            foreach (Sys_Usuarios sys_usuario in empresa.Sys_Usuarios)
            {
                tmpUsuarios.Add(sys_usuario);
            }
            foreach (Sys_Usuarios sys_usuario in tmpUsuarios)
            {
                empresa.Sys_Usuarios.Remove(sys_usuario);
            }
            Context.SaveChanges();
        }

        public void addUsuarioEmpresa(Org_Empresas empresa, Sys_Usuarios usuario)
        {
            empresa.Sys_Usuarios.Add(usuario);
            Context.SaveChanges();
        }

        public void deleteCategoria(Doc_Categorias categoria)
        {
            if (categoria != null)
            {
                deleteDocumentosByCategoria(categoria);
                List<Doc_Categorias> tmpchildren = new List<Doc_Categorias>();
                foreach (Doc_Categorias child in Context.doc_categorias.Where(a => a.IdPadre == categoria.IdCategoria)) //get the children
                {
                    tmpchildren.Add(child);
                }
                foreach (Doc_Categorias doc_categoria in tmpchildren)
                {
                    deleteCategoria(doc_categoria);
                }
                Context.Delete(categoria);
                Context.SaveChanges();
            }
        }

        public void deleteDocumentosByCategoria(Doc_Categorias categoria)
        {
            List<Doc_Documentos> tmpchildrendocs = new List<Doc_Documentos>();
            foreach (Doc_Documentos child in Context.doc_documentos.Where(a => a.IdCategoria == categoria.IdCategoria)) //get the children
            {
                tmpchildrendocs.Add(child);
            }
            foreach (Doc_Documentos doc_documento in tmpchildrendocs)
            {
                deleteDocumento(doc_documento);
            }
        }

        public void deleteDocumento(Doc_Documentos documento)
        {
            Context.Delete(documento);
            Context.SaveChanges();
        }

        public void addTarea(Tar_Tareas tarea)
        {
            Context.Add(tarea);
            Context.SaveChanges();
        }

        public class EmpresaGeneralData
        {
            public int idEmpresa { get; set; }
            public string nombre { get; set; }
            public string ubicacion { get; set; }
            public string url { get; set; }
            public string telefono { get; set; }
            public string logo { get; set; }
            public int idIdentificacionTipo { get; set; }
            public string identificacionTipo { get; set; }
            public string identificacion { get; set; }
            public int idPais { get; set; }
            public double? latitude { get; set; }
            public double? longitude { get; set; }
            public int? idCliente { get; set; }
            public int? idCategoriaDocumentos { get; set; }
            public List<Area> areas { get; set; }
            public List<Cargo> cargos { get; set; }
            public List<Supplier> proveedores { get; set; }
            public List<Category> publicaciones { get; set; }
            public List<UserCompany> usuarios { get; set; }
            public List<String> availableRoles { get; set; }
        }

        public class Area
        {
            public int idArea { get; set; }
            public int idPadre { get; set; }
            public int idEmpresa { get; set; }
            public int? idResponsable { get; set; }
            public string responsable { get; set; }
            public string nombre { get; set; }
            public string objetivo { get; set; }
            public string descripcion { get; set; }
            public bool eliminado { get; set; }
            public bool nuevo { get; set; }
            public Area Parent { get; set; }
            public List<Area> Children { get; set; }
        }

        public class Cargo
        {
            public int idCargo { get; set; }
            public int idArea { get; set; }
            public int? idPadre { get; set; }
            public string nombre { get; set; }
            public string descripcion { get; set; }
            public string perfil { get; set; }
            public bool eliminado { get; set; }
            public List<Empleado> empleados { get; set; }
            public Cargo Parent { get; set; }
            public List<Cargo> Children { get; set; }
        }

        public class Empleado
        {
            public int EmployeeId { get; set; }
            public int? TitleId { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public string FullName { get { return string.Format("{0} {1}", Name, LastName); } }
            public int IdType { get; set; }
            public string IdNumber { get; set; }
            public string Picture { get; set; }
            public string Email { get; set; }
            public string Observations { get; set; }
            public string Competencies { get; set; }
            public string CV { get; set; }
            public string cvFileName { get { return (!string.IsNullOrEmpty(CV) && CV.LastIndexOf("/") != -1 ? CV.Substring(CV.LastIndexOf("/") + 1) : null); } }
            public bool Retired { get; set; }
            public DateTime PositionStartDate { get; set; }
            public DateTime PositionEndDate { get; set; }
        }

        public class Supplier
        {
            public int Id { get; set; }
            public int IdCompany { get; set; }
            public string Name { get; set; }
            public int IdIdentification { get; set; }
            public string Identification { get; set; }
            public string Phone { get; set; }
            public string Mail { get; set; }
            public string Location { get; set; }
            public string CV { get; set; }
            public string cvFileName { get { return (!string.IsNullOrEmpty(CV) && CV.LastIndexOf("/") != -1 ? CV.Substring(CV.LastIndexOf("/") + 1) : null); } }
            public Boolean Delete { get; set; }
            public string IdentificationName { get; set; }
            public string CompanyName { get; set; }
            public string CreatedUserName { get; set; }
            public DateTime CreatedDate { get; set; }
            public string UpdatedUserName { get; set; }
            public DateTime? UpdatedDate { get; set; }
            public bool Deleted { get; set; }
        }

        public class UserCompany
        {
            public int idUsuario { get; set; }
            public string UserName { get; set; }
            public string FullName { get; set; }
            public int? idEmpresa { get; set; }
            public bool include { get; set; }
        }

        public class Document
        {
            public int Id { get; set; }
            public int FileTypeId { get; set; }
            public string Title { get; set; }
            public string KeyWords { get; set; }
            public string Resume { get; set; }
            public string Url { get; set; }
            public string CreatedUser { get; set; }
            public string UpdatedUser { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime? UpdatedDate { get; set; }
            public int CategoryId { get; set; }
            public string FileExtension { get; set; }
            public string Path { get; set; }
            public bool RelacionTarea { get; set; }
            public string Tarea { get; set; }
            public int Lista { get; set; }
            public string Roles { get; set; }
        }

        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int ParentId { get; set; }
            public int? TypeId { get; set; }
            public bool? Status { get; set; }
            public DateTime CreateDate { get; set; }
            public DateTime? UpdateDate { get; set; }public string Path { get; set; }
            public string CreateUser { get; set; }
            public string UpdateUser { get; set; }
            public Category Parent { get; set; }
            public List<Category> Children { get; set; }
            public List<Document> documents { get; set; }
        }
    }

    #endregion

    #region Paises
    public class PaisesRepository : IPaisesRepository
    {
        private IContextRepository Context;

        public PaisesRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        //Devuelve todos lo países
        public IEnumerable<Object> GetAll()
        {
            return (from pais in Context.m_paises
                    orderby pais.Nombre
                    select new
                    {
                        idPais = pais.IdPais,
                        nombre = pais.Nombre
                    }).ToList();
        }
    }
    #endregion

    #region Archivos Tipos
    public class ArchivosTiposRepository : IArchivosTiposRepository
    {
        private IContextRepository Context;

        public ArchivosTiposRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        //Devuelve todos lo países
        public IEnumerable<Object> GetAll()
        {
            return (from archivostipos in Context.doc_archivostipos
                    orderby archivostipos.Nombre
                    select new
                    {
                        idTipoArchivo = archivostipos.IdTipoArchivo,
                        nombre = archivostipos.Nombre,
                        mime_type = archivostipos.Mime_Type
                    }).ToList();
        }
    }
    #endregion

    #region Lista de tareas
    public class ListasTareasRepository : IListasTareasRepository
    {
        private IContextRepository Context;

        public ListasTareasRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        //Devuelve todas las listas de tareas
        public IEnumerable<Object> GetAll()
        {
            return (from lista in Context.tar_listas
                    orderby lista.Descripcion
                    select new
                    {
                        idLista = lista.Id,
                        descripcion = lista.Descripcion
                    }).ToList();
        }
    }
    #endregion

    #region Usuarios
    public class UsuariosRepository : IUsuariosRepository
    {
        private IContextRepository Context;

        public UsuariosRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Object> GetAllUser()
        {
            return (from t in Context.sys_usuarios

                    select new { t.Nombre, t.Correo, t.IdUsuario, t.idEmpresa, t.CustomerId }).AsEnumerable();

        }
        //Devulve el listado de usuarios para enviar correo.
        //Devuelve todos los usuarios
        public IEnumerable<Object> GetAll()
        {
            return (from usuario in Context.sys_usuarios
                    orderby usuario.Nombre
                    select new
                    {
                        idUsuario = usuario.IdUsuario,
                        userName = usuario.UserName,
                        nombre = usuario.Nombre
                    }).ToList();
        }
    }
    #endregion

    #region Financiero
    public class FinancieroRepository : IFinancieroRepository
    {
        private IContextRepository Context;

        public FinancieroRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public Object GetTotalesMovimientoPorProyecto(int idProyecto, int idTenant)
        {
            List<SELTOTALESMOVIMIENTOPROYECTO_Result> totalesResults = Context.seltotalesmovimientoproyecto(idProyecto, idTenant);
            List<FinancialMovResume> totales = new List<FinancialMovResume>();
            foreach (SELTOTALESMOVIMIENTOPROYECTO_Result item in totalesResults)
            {
                FinancialMovResume total = new FinancialMovResume() { IdTipo = item.IdTipo, Descripcion = item.Descripcion, Presupuesto = item.Presupuesto, Costo = item.Costo, Diferencia = item.Diferencia };
                total.Movimientos = GetDetallesMovimientoByTipo(idProyecto, item.IdTipo);
                totales.Add(total);
            }

            FinancialsObject aFinancialObject = new FinancialsObject
            {
                totales = totales,
                presupuestosTipos = GetPresupuestosTipos(),
                productosByProyecto = GetAllProductosByProyecto(idProyecto),
                donorsByProyecto = GetAllDonorsByProyecto(idProyecto),
                movimientoEjecutado = GetMovimientoEjecutadoProyecto(idProyecto, idTenant)
            };
            return aFinancialObject;
        }

        private List<MovEjecutado> GetMovimientoEjecutadoProyecto(int idProyecto, int idTenant)
        {
            List<MovEjecutado> ejecutado = (from e in Context.selmovimientoejecutadoproyecto(idProyecto, idTenant)
                                            select new MovEjecutado()
                                            {
                                                IdTipo = e.IdTipo,
                                                Descripcion = e.Descripcion,
                                                IdPresupuesto = e.IdPresupuesto,
                                                IdObjetivo = e.IdObjetivo,
                                                IdDonante = e.IdDonante,
                                                Monto = e.Monto.HasValue ? e.Monto.Value : 0,
                                                Ejecutado = e.Ejecutado,
                                                Objetivodescripcion = e.Objetivodescripcion,
                                                IdObjetivoClase = e.IdObjetivoClase,
                                                IdPadre = e.IdPadre
                                            }
                                           ).ToList();
            return ejecutado;
        }

        private List<FinancialMovDetail> GetDetallesMovimientoByTipo(int idProyecto, int idTipo)
        {
            List<FinancialMovDetail> detalles = (from m in Context.pry_movimientos
                                                 join p in Context.pry_presupuesto on m.IdPresupuesto equals p.IdPresupuesto
                                                 join t in Context.pry_presupuestotipo on p.IdTipoPresupuesto equals t.IdTipo
                                                 join pp in Context.pry_periodosproyectos on m.IdPeriodo equals pp.IdPeriodo into perpry
                                                 from x in perpry.DefaultIfEmpty()
                                                 join pg in Context.pry_partidagastos on m.IDPARTIDAGASTO equals pg.IDPARTIDAGASTO into part
                                                 from y in part.DefaultIfEmpty()
                                                 join po in Context.pry_objetivos on p.IdObjetivo equals po.IdObjetivo into pobj
                                                 from z in pobj.DefaultIfEmpty()
                                                 where p.IdProyecto == idProyecto && p.IdTipoPresupuesto == idTipo
                                                 select new FinancialMovDetail()
                                                 {
                                                     IdMovimiento = m.IdMovimiento,
                                                     IdPresupuesto = m.IdPresupuesto.HasValue ? m.IdPresupuesto.Value : 0,
                                                     IdTipoPresupuesto = p.IdTipoPresupuesto.HasValue ? p.IdTipoPresupuesto.Value : 0,
                                                     IdProveedor = m.IdProveedor,
                                                     Monto = m.Monto.HasValue ? m.Monto.Value : 0,
                                                     Fecha = m.Fecha,
                                                     Observaciones = m.Observaciones,
                                                     UrlSoporte = m.UrlSoporte,
                                                     IdPeriodo = m.IdPeriodo,
                                                     Periodo = x.Nombre,
                                                     Beneficiario = m.BENEFICIARIO,
                                                     MedioPago = m.MEDIOPAGO,
                                                     AportePrograma = m.APORTEPROGRAMA.HasValue ? m.APORTEPROGRAMA.Value : 0,
                                                     ContraPartida = m.CONTRAPARTIDA.HasValue ? m.CONTRAPARTIDA.Value : 0,
                                                     IdPartidaGasto = y.IDPARTIDAGASTO,
                                                     PartidaGasto = y.NOMBRE,
                                                     IdResultado = z.IdPadre,
                                                     IdActividad = z.IdObjetivo,
                                                     Moneda = m.MONEDALOCAL,
                                                     AporteMonedaLocal = m.APORTEMONEDALOCAL.HasValue ? m.APORTEMONEDALOCAL.Value : 0,
                                                     UsuarioCreacion = m.USUARIOCREACION,
                                                     UsuarioEdicion = m.USUARIOMODIFICACION,
                                                     FechaCreacion = m.FECHACREACION,
                                                     FechaEdicion = m.FECHAMODIFICACION

                                                 }
                                                 ).ToList();

            foreach (FinancialMovDetail detalle in detalles)
            {
                detalle.montosDonacion = Context.pry_montosdonacion.Where(a => a.IdMovimiento == detalle.IdMovimiento).ToList();
            }
            return detalles;
        }

        //Devuelve todos los Presupuestos Tipo
        public IEnumerable<Object> GetPresupuestosTipos()
        {
            return (from presupuestotipo in Context.pry_presupuestotipo
                    where presupuestotipo.IdTipo < 6
                    select new
                    {
                        idTipo = presupuestotipo.IdTipo,
                        descripcion = presupuestotipo.Descripcion
                    }).ToList();
        }

        public List<ProductoProyecto> GetAllProductosByProyecto(int idProyecto)
        {
            Pry_Proyectos proyecto = Context.pry_proyectos.Where(a => a.IdProyecto == idProyecto).FirstOrDefault();

            List<ProductoProyecto> productos = (from producto in Context.pry_objetivos
                                                where producto.IdObjetivoClase == (int)ObjectiveClass.Product && producto.IdProyecto == proyecto.IdProyecto // TODO: verificar si debo incluir (int)ObjectiveClass.Result
                                                && producto.Eliminado == false
                                                select new ProductoProyecto
                                                {
                                                    idObjetivo = producto.IdObjetivo,
                                                    codigo = producto.Codigo,
                                                    descripcion = producto.Codigo + " - " + producto.Descripcion
                                                }).ToList();
            foreach (ProductoProyecto producto in productos)
            {
                producto.actividades = GetAllActividadesByProducto(producto.idObjetivo);
            }

            return productos;
        }

        public IEnumerable<Object> GetAllActividadesByProducto(int idProducto)
        {
            return (from actividad in Context.pry_objetivos
                    where actividad.IdPadre == idProducto
                    && actividad.Eliminado == false
                    select new
                    {
                        idObjetivo = actividad.IdObjetivo,
                        codigo = actividad.Codigo,
                        descripcion = actividad.Codigo + " - " + actividad.Descripcion
                    }).ToList();
        }

        public IEnumerable<Object> GetAllDonorsByProyecto(int idProyecto)
        {
            var budget = (from presupuesto in Context.pry_presupuesto
                    join donante in Context.org_donantes on presupuesto.IdDonante equals donante.IdDonante
                    where presupuesto.IdTipoPresupuesto == 5
                    && presupuesto.IdProyecto == idProyecto
                    select new DonanteProyecto
                    {
                        idDonante = donante.IdDonante,
                        nombre = donante.Nombre,
                        idPresupuesto = presupuesto.IdPresupuesto,
                        monto = presupuesto.Monto
                    }).ToList();

            return budget;
        }

        public void addMovimiento(Pry_Movimientos movimiento)
        {
            Context.Add(movimiento);
            Context.SaveChanges(); //Salvar antes. Así como se hace en el sistema actual
            RealizarAjustesFinancieros(movimiento);
        }

        public void RealizarAjustesFinancieros(Pry_Movimientos movimiento)
        {
            CostosRepository costosRepository = new CostosRepository(Context);

            Pry_Presupuesto presupuesto = Context.pry_presupuesto.Where(a => a.IdPresupuesto == movimiento.IdPresupuesto).FirstOrDefault();
            if (presupuesto != null)
            {
                IQueryable<Pry_Proyectos_NivelAceptacion> nivelesDeAceptacion = Context.pry_proyectos_nivelaceptacion.Where(a => a.IdProyecto == presupuesto.IdProyecto);

                if (presupuesto.IdObjetivo != null)
                {
                    //1 Buscar el objetivo y recalcular.               
                    //traemos los objetivos hijos. A menos que sea finalidad.
                    //sacar ponderados de cada uno. ponderado total y ponderado relativo. y calculamos el del objetivo.
                    //guardar y llamra al padre.

                    double? montoActividad = Context.pry_movimientos.Where(a => a.Pry_Presupuesto.IdObjetivo == presupuesto.IdObjetivo).Sum(a => a.Monto);
                    Pry_Objetivos actividad = Context.pry_objetivos.Where(a => a.IdObjetivo == presupuesto.IdObjetivo).FirstOrDefault();
                    actividad.Costo = montoActividad;
                    Context.SaveChanges(); //Salvar antes. Así como se hace en el sistema actual

                    costosRepository.CalcularCostoObjetivos(presupuesto.IdObjetivo.Value, nivelesDeAceptacion, 1, movimiento.IdPeriodo.Value);

                    //ponemos semaforo en proposito
                    //debemos ver la meta en el informe. y sumar todos los gastos
                    Pry_Proyectos proyecto = Context.pry_proyectos.Where(a => a.IdProyecto == presupuesto.IdProyecto).FirstOrDefault();
                    Pry_Objetivos proposito = Context.pry_objetivos.Where(a => a.IdObjetivo == proyecto.IdProposito).FirstOrDefault();
                    Pry_Presupuesto presupuestoProposito = Context.pry_presupuesto.Where(a => a.IdObjetivo == proposito.IdObjetivo).FirstOrDefault();

                    double eficaciaP = proposito.Eficacia.HasValue ? proposito.Eficacia.Value : 0;
                    double presupuestoP = proyecto.Presupuesto.HasValue ? proyecto.Presupuesto.Value : 0;
                    double costoT = presupuestoProposito != null ? (presupuestoProposito.Monto.HasValue ? presupuestoProposito.Monto.Value : 0) : 0;
                    DateTime fechaInicioP = proyecto.FechaInicio.Value;
                    DateTime fechaFinP = proyecto.FechaFin.Value;
                    int intIdInforme = 0;

                    //traemos la meta del informe mas cercano... Primero traermos el informe
                    Pry_Informes informe = Context.pry_informes.Where(a => a.IdProyecto == presupuesto.IdProyecto && a.FechaProgramada > DateTime.Now).OrderBy(a => a.FechaProgramada).FirstOrDefault();

                    //aqui puede no ser una meta cercana.
                    //1.Hacemos los calculos de eficiencia, eficacia, efectividad
                    if (informe != null)
                    {
                        //tomamos el primer informe que es el mas cercano
                        intIdInforme = informe.IdInforme;
                        fechaFinP = informe.FechaProgramada.Value;
                        presupuestoP = informe.PresupuestoMeta.HasValue ? informe.PresupuestoMeta.Value : 0;
                    }

                    //traemos el costo real del proyecto
                    //double costoT = TraeCostoProyecto(idProyecto);//traer todos los valores..administrativos  imprevistos etc.

                    #region calculos efectividad eficacia. no los usamos en este caso.
                    //hallamos efectividad logro/meta en porcentaje y eficacia logro*tiempo/meta * tiempo
                    //aqui revisar los calculos con dinero.
                    //si solo hago la eficiencia
                    //aqui se hace la eficiencia del proposito como la del proyecto
                    //como y cuando calcular la de los demas objetivos??????*******************************
                    //double efectividad = (costoT / presupuestoP) * 100;
                    //double fechaIV = fechaInicioP.Ticks;
                    //double tiempoE = DateTime.Now.Ticks - fechaIV;
                    //double tiempoP = fechaFinP.Ticks - fechaIV;
                    //eficacia = ((costoT * tiempoE) / (presupuestoP * tiempoP)) * 100;
                    #endregion

                    double efectividad = (costoT / presupuestoP) * 100;
                    double eficienciaP = ((eficaciaP * presupuestoP) / (costoT == 0 ? 1 : costoT /* Incuido para evitar división por 0 */)) * 100;
                    int intIdNivelAceptacionEficienciaP = costosRepository.CalcularNivelAceptacion(nivelesDeAceptacion, eficienciaP);
                    int intIdNivelAceptacionCostoP = costosRepository.CalcularNivelAceptacion(nivelesDeAceptacion, efectividad);

                    proposito.IdNivelAceptacionEficiencia = intIdNivelAceptacionEficienciaP;
                    proposito.IdNivelAceptacionCosto = intIdNivelAceptacionCostoP;

                    Context.SaveChanges();

                }

            }
        }

        public Pry_Movimientos GetMovimiento(int idMovimiento)
        {
            return Context.pry_movimientos.Where(a => a.IdMovimiento == idMovimiento).FirstOrDefault();
        }

        public Sys_Usuarios GetUsuarioById(int idUsuario)
        {
            return Context.sys_usuarios.Where(a => a.IdUsuario == idUsuario).FirstOrDefault();
        }

        public void modifyMovimiento()
        {
            Context.SaveChanges();
        }

        public void deleteMovimiento(Pry_Movimientos movimiento)
        {
            Context.Delete(movimiento);
            Context.SaveChanges();
        }

        public void addMontoDonacion(Pry_MontoDonacion montoDonacion)
        {
            Context.Add(montoDonacion);
            Context.SaveChanges();
        }

        public void deleteMontoDonacion(Pry_Movimientos movimiento)
        {
            List<Pry_MontoDonacion> MontoDonacionList = new List<Pry_MontoDonacion>();
            foreach (Pry_MontoDonacion montoDonacion in Context.pry_montosdonacion.Where(a => a.IdMovimiento == movimiento.IdMovimiento))
            {
                MontoDonacionList.Add(montoDonacion);
            }
            foreach (Pry_MontoDonacion montoDonacion in MontoDonacionList)
            {
                Context.Delete(montoDonacion);
            }

            Context.SaveChanges();
        }

        public class FinancialsObject
        {
            public List<FinancialMovResume> totales;
            public IEnumerable<Object> presupuestosTipos;
            public IEnumerable<Object> productosByProyecto;
            public IEnumerable<Object> donorsByProyecto;
            public List<MovEjecutado> movimientoEjecutado;

        }

        public class FinancialMovResume
        {
            public int IdTipo { get; set; }
            public string Descripcion { get; set; }
            public double? Presupuesto { get; set; }
            public double? Costo { get; set; }
            public double? Diferencia { get; set; }
            public List<FinancialMovDetail> Movimientos { get; set; }

        }

        public class FinancialMovDetail
        {
            public int? IdMovimiento { get; set; }
            public int IdPresupuesto { get; set; }
            public int IdTipoPresupuesto { get; set; }
            public int? IdProveedor { get; set; }
            public double Monto { get; set; }
            public DateTime? Fecha { get; set; }
            public string Observaciones { get; set; }
            public string UrlSoporte { get; set; }
            public Int64? IdPeriodo { get; set; }
            public string Periodo { get; set; }
            public string Beneficiario { get; set; }
            public string MedioPago { get; set; }
            public decimal ContraPartida { get; set; }
            public decimal AportePrograma { get; set; }
            public int? IdPartidaGasto { get; set; }
            public string PartidaGasto { get; set; }
            public int? IdResultado { get; set; }
            public int? IdActividad { get; set; }
            public int? Moneda { get; set; }
            public decimal AporteMonedaLocal { get; set; }
            public string UsuarioCreacion { get; set; }
            public DateTime? FechaCreacion { get; set; }
            public string UsuarioEdicion { get; set; }
            public DateTime? FechaEdicion { get; set; }
            public List<Pry_MontoDonacion> montosDonacion { get; set; }
        }

        public class ProductoProyecto
        {
            public int idObjetivo { get; set; }
            public string codigo { get; set; }
            public string descripcion { get; set; }
            public IEnumerable<Object> actividades { get; set; }
        }

        public class DonanteProyecto
        {
            public int idDonante { get; set; }
            public string nombre { get; set; }
            public int idPresupuesto { get; set; }
            public double? monto { get; set; }
        }

        public class MovEjecutado
        {
            public int IdTipo { get; set; }
            public string Descripcion { get; set; }
            public int IdPresupuesto { get; set; }
            public int? IdObjetivo { get; set; }
            public int? IdDonante { get; set; }
            public double Monto { get; set; }
            public double? Ejecutado { get; set; }
            public string Objetivodescripcion { get; set; }
            public int? IdObjetivoClase { get; set; }
            public int? IdPadre { get; set; }
        }
    }
    #endregion

    #region Partidas Gastos
    public class PartidasGastosRepository : IPartidasGastosRepository
    {
        private IContextRepository Context;

        public PartidasGastosRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Object> GetAllPartidasGastos()
        {
            return (from p in Context.pry_partidagastos
                    select new
                    {
                        idPartidaGasto = p.IDPARTIDAGASTO,
                        nombre = p.NOMBRE,
                        abreviatura = p.ABREVIATURA
                    }).ToList();
        }
    }
    #endregion

    #region Cliente
    public class ClienteRepository : IClienteRepository
    {
        private IContextRepository Context;

        public ClienteRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public Object GetCliente(int id)
        {
            Cliente cliente = (from c in Context.sys_clientes where c.Id == id
                               select new Cliente
                               {
                                   id = c.Id,
                                   nombre = c.Name
                               }).FirstOrDefault();
            if (cliente != null)
            {
                cliente.empresas = Context.org_empresas.Where(a => a.IdCliente == cliente.id).ToList();
                cliente.proyectos = (from p in Context.pry_proyectos
                                     join t in Context.pry_proyectostipos on p.IdTipo equals t.Id
                                     join e in Context.pry_proyectosestados on p.IdEstado equals e.IdEstado
                                     where p.CustomerId == cliente.id
                                     select new
                                     {
                                         idProyecto = p.IdProyecto,
                                         codigo = p.Codigo,
                                         nombre = p.Nombre,
                                         estado = e.Descripcion,
                                         tipo = t.Descripcion
                                     }).ToList<Object>();
                cliente.donantes = Context.org_donantes.Where(a => a.IdCliente == cliente.id && a.Eliminado == false).ToList();
            }

            return cliente;
        }

        public Sys_Usuarios GetUsuarioById(int idUsuario)
        {
            return Context.sys_usuarios.Where(a => a.IdUsuario == idUsuario).FirstOrDefault();
        }

        public class Cliente
        {
            public int id { get; set; }
            public string nombre { get; set; }
            public List<Org_Empresas> empresas { get; set; }
            public List<Object> proyectos { get; set; }
            public List<Org_Donantes> donantes { get; set; }
        }

        //created by Ernesto Duarte, get all clients

        public IEnumerable<Object> GetAll()
        {

            var clientes = Context.sys_clientes.Select(c => new
            {
                c.Id,
                c.Name,
                c.MaxUsers,
                c.MaxProjects,
                c.MaxStorage,
                OrderDate = c.OrderDate,
                ExpirationDate = c.ExpirationDate,
                c.Logo,
                c.Status,
                c.ContactName,
                c.ContactMail,
                c.ContactAddress,
                c.ContactPhone

            }).AsEnumerable();
                
            return clientes;
        }

        public IEnumerable<Object> GetActive()
        {
            var clientes = Context.sys_clientes.Select(c => new
            {
                c.Id,
                c.Name,
                c.MaxUsers,
                c.MaxProjects,
                c.MaxStorage,
                c.OrderDate,
                c.ExpirationDate,
                c.Logo,
                c.Status,
                c.ContactName,
                c.ContactMail,
                c.ContactAddress,
                c.ContactPhone

            }).Where(x => x.Status == true).AsEnumerable();

            return clientes;
        }

        public void Update(Sys_Clientes client)
        {

            Sys_Clientes _client = Context.sys_clientes.FirstOrDefault(c => c.Id == client.Id);

            _client.ContactAddress = client.ContactAddress;
            _client.ContactMail = client.ContactMail;
            _client.ContactName = client.ContactName;
            _client.ContactPhone = client.ContactPhone;
            _client.ExpirationDate = client.ExpirationDate;
            _client.Logo = client.Logo;
            _client.MaxProjects = client.MaxProjects;
            _client.MaxStorage = client.MaxStorage;
            _client.MaxUsers = client.MaxUsers;

            Context.SaveChanges();
                        
        }

        public void Delete(int id)
        {
            Sys_Clientes _client = Context.sys_clientes.FirstOrDefault(c => c.Id == id);

            _client.Status = false;

            Context.SaveChanges();
        }

        public void Add(Sys_Clientes client)
        {

            Context.Add(client);

            Context.SaveChanges();
        }
    }

    #endregion

    #region Objetivos Clases
    public class ObjetivosClasesRepository : IObjetivosClasesRepository
    {
        private IContextRepository Context;

        public ObjetivosClasesRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public List<Object> GetAll()
        {
            return Context.pry_objetivosclase.ToList<Object>();
        }
    }
    #endregion

    #region Indicadores Tipos
    public class IndicadoresTiposRepository : IIndicadoresTiposRepository
    {
        private IContextRepository Context;

        public IndicadoresTiposRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public List<Pry_IndicadoresTipos> GetAll()
        {
            return Context.pry_indicadorestipos.ToList();
        }
    }
    #endregion

    #region Donantes
    public class DonantesRepository : IDonantesRepository
    {
        private IContextRepository Context;

        public DonantesRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public List<Org_Donantes> GetAll()
        {
            return Context.org_donantes.Where(a => a.Eliminado == false).ToList();
        }

        public Org_Donantes GetDonanteById(int idDonante)
        {
            return Context.org_donantes.Where(a => a.IdDonante == idDonante).FirstOrDefault();
        }

        public Sys_Usuarios GetUsuarioById(int idUsuario)
        {
            return Context.sys_usuarios.Where(a => a.IdUsuario == idUsuario).FirstOrDefault();
        }

        public void modifyData()
        {
            Context.SaveChanges();
        }

        public void addDonante(Org_Donantes donante)
        {
            Context.Add(donante);
            Context.SaveChanges();
        }
    }
    #endregion

    #region Presupuesto Proyecto
    public class PresupuestoProyectoRepository : IPresupuestoProyecto
    {
        private IContextRepository Context;

        public PresupuestoProyectoRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public Object GetPresupuestoProyectoData(int idProyecto)
        {
            //Other object repositories to reuse get and set functions
            //ProjectRepository proyectRepository = new ProjectRepository(Context);
            FinancieroRepository financieroRepository = new FinancieroRepository(Context);

            var _flatObjetivos = Context.Pry_Objetivos.Where(o => o.Eliminado == false && o.IdProyecto == idProyecto)
                .Select(o => new
                {
                    idObjetivo = o.IdObjetivo,
                    idObjetivoClase = o.IdObjetivoClase.Value,
                    idPadre = o.IdPadre,
                    idProyecto = o.IdProyecto,
                    codigo = o.Codigo,
                    descripcion = o.Descripcion,
                    objetivoClase = Context.pry_objetivosclase.Where(c => c.IdObjetivoClase == o.IdObjetivoClase).Select(c => new { c.IdObjetivoClase, c.Descripcion }).FirstOrDefault(),
                    parent = Context.pry_objetivos.FirstOrDefault(a => a.IdObjetivo == o.IdPadre),
                    totalPresupuesto = Context.pry_presupuesto.Where(p => p.IdObjetivo == o.IdObjetivo && p.IdTipoPresupuesto == 1).Sum(a => (double?)a.Monto) ?? 0,
                    recursos = Context.pry_recursos.Where(a => a.IdObjetivo == o.IdObjetivo).Select(r =>
                        new
                        {
                            r.IdRecurso,
                            r.IdObjetivo,
                            r.IDPARTIDAGASTO,
                            r.Codigo,
                            r.Descripcion,
                            r.Cantidad,
                            r.UnidadMedida,
                            r.ValorUnitario,
                            r.Tipo,
                            r.Monto,
                            r.APORTEPROGRAMA,
                            r.CONTRAPARTIDA
                        }).ToList().OrderBy(r => r.Codigo),
                    totalDistribuidoRecursos = Context.pry_recursos.Where(a => a.IdObjetivo == o.IdObjetivo).Sum(a => (decimal?)a.APORTEPROGRAMA + (decimal?)a.CONTRAPARTIDA) ?? 0,
                    objetivo = new { 
                        o.IdObjetivo,
                        o.IdPadre,
                        o.Codigo,
                        o.Descripcion,
                        o.FechaInicio,
                        o.FechaFin,
                        o.Progreso,
                        o.Efectividad,
                        o.Eficacia,
                        o.Eficiencia,
                        o.IdNivelAceptacion,
                        o.IdNivelAceptacionEfectividad,
                        o.IdNivelAceptacionEficacia,
                        o.IdNivelAceptacionEficiencia,
                    }
                }).ToList().OrderBy(o => o.codigo);

            List<dynamic> flatDonaciones = new List<dynamic>();

            financieroRepository.GetAllDonorsByProyecto(idProyecto).ToList().ForEach(x =>
            {
                _flatObjetivos.Select(f => new
                {
                    idDonante = ((FinancieroRepository.DonanteProyecto)x).idDonante,
                    idObjetivo = f.idObjetivo,
                    objetivoProyecto = f,
                    donaciones = Context.pry_presupuesto.Where(a => a.IdObjetivo == f.idObjetivo && a.IdTipoPresupuesto == 6).Select(p => new
                    {
                        p.IdPresupuesto,
                        p.IdTipoPresupuesto,
                        p.IdObjetivo,
                        p.IdProyecto,
                        p.Monto,
                        p.IdDonante,
                        p.UsuarioCreacion,
                        p.FechaCreacion,
                        p.UsuarioModificacion,
                        p.FechaModificacion
                    }).ToList(),
                    totalDonaciones = Context.pry_presupuesto.Where(a => a.IdObjetivo == f.idObjetivo && a.IdTipoPresupuesto == 6 && a.IdDonante == ((FinancieroRepository.DonanteProyecto)x).idDonante).Select(p => new
                    {
                        p.IdPresupuesto,
                        p.IdTipoPresupuesto,
                        p.IdObjetivo,
                        p.IdProyecto,
                        p.Monto,
                        p.IdDonante,
                        p.UsuarioCreacion,
                        p.FechaCreacion,
                        p.UsuarioModificacion,
                        p.FechaModificacion
                    }).ToList().Sum(d => d.Monto) ?? 0,
                    totalPresupuesto = Context.pry_presupuesto.Where(p => p.IdObjetivo == f.idObjetivo && p.IdTipoPresupuesto == 1).Sum(a => (double?)a.Monto) ?? 0,
                    
                }).Where(d => d.objetivoProyecto.idObjetivoClase >= 3).ToList().ForEach(fO => flatDonaciones.Add(fO));

            });

            var presupuestoProyectoData = new 
            {
                proyecto = Context.pry_proyectos.Where(p => p.IdProyecto == idProyecto).Select(p => new { p.IdProyecto, p.MONTOCONTRAPARTIDA, p.MONTOFINANCIAMIENTO}).FirstOrDefault(),
                proyectoDonantes = Context.pry_proyectos_donantes.Where(d => d.IdProyecto == idProyecto).Select(pd => new
                {
                    pd.IdProyecto,
                    pd.IdDonante,
                    pd.IdUsuarioResponsable,
                    pd.Monto,
                    pd.UsuarioCreacion,
                    pd.FechaCreacion,
                    pd.UsuarioModificacion,
                    pd.FechaModificacion
                }
                ).ToList(),
                distribucionPresupuesto = Context.pry_presupuestotipo.Where(pt => pt.IdTipo != 5 && pt.IdTipo != 6).Select(pt => new
                {
                    idTipo = pt.IdTipo,
                    idProyecto = idProyecto,
                    descripcion = pt.Descripcion,
                    idPresupuesto = (int?)pt.Pry_Presupuesto.FirstOrDefault(b => b.IdProyecto == idProyecto &&
                        b.IdObjetivo == null).IdPresupuesto,
                    monto = pt.Pry_Presupuesto.FirstOrDefault(b => b.IdProyecto == idProyecto &&
                        b.IdObjetivo == null).Monto ?? 0,
                    fechaCreacion = (DateTime?)pt.Pry_Presupuesto.FirstOrDefault(b => b.IdProyecto == idProyecto &&
                        b.IdObjetivo == null).FechaCreacion

                }).ToList(),
                flatObjetivos = _flatObjetivos,
                flatPresupuesto = _flatObjetivos.Select(f => new
                {
                    idObjetivo = f.idObjetivo,
                    Codigo = f.codigo,
                    objetivo = f.objetivo,
                    objetivoProyecto = f,
                    presupuesto = Context.pry_presupuesto.Where(a => a.IdObjetivo == f.idObjetivo && a.IdTipoPresupuesto == 1).Select(p => new
                    {
                        p.IdPresupuesto,
                        p.IdTipoPresupuesto,
                        p.IdObjetivo,
                        p.IdProyecto,
                        p.Monto,
                        p.IdDonante,
                        p.UsuarioCreacion,
                        p.FechaCreacion,
                        p.UsuarioModificacion,
                        p.FechaModificacion

                    }).FirstOrDefault()
                }).ToList().OrderBy(f => f.Codigo),

                calendarioDonaciones = Context.pry_calendariodonaciones.Where(d => d.IdProyecto == idProyecto).Select(c => new { 
                    c.IdDonacion,
                    c.IdProyecto,
                    c.IdDonante,
                    c.Monto,
                    c.FechaProgramada
                }).ToList(),
                flatDonaciones = flatDonaciones

            };

            var _totalDonado = presupuestoProyectoData.proyectoDonantes.Sum(a => a.Monto) ?? 0;
            var _totalFinanciado = presupuestoProyectoData.proyecto.MONTOFINANCIAMIENTO ?? 0;
            var _totalContrapartida = presupuestoProyectoData.proyecto.MONTOCONTRAPARTIDA ?? 0;
            var _totalPresupuesto = _totalFinanciado + _totalContrapartida;
            var _pendiente = _totalPresupuesto - _totalDonado;
            var _totalDistribuido = (double?)presupuestoProyectoData.distribucionPresupuesto.Sum(a => a.monto) ?? 0;
            var _pendienteDistribucion = _totalPresupuesto - _totalDistribuido;
            var _totalProjectImplementation = (double?)presupuestoProyectoData.distribucionPresupuesto.Where(a => a.idTipo == 1).Sum(a => a.monto) ?? 0;
            var _totalPresupuestoObjetivos = presupuestoProyectoData.flatPresupuesto.Where(a => a.presupuesto != null && a.presupuesto.IdTipoPresupuesto == 1 && a.objetivoProyecto.idObjetivoClase == (int)ObjectiveClass.Product).Sum(a => a.presupuesto.Monto) ?? 0;// TODO: verificar si debo incluir (int)ObjectiveClass.Result
            var _pendientePresupuesto = _totalProjectImplementation - _totalPresupuestoObjetivos;
            var _totalDonacionObjetivos = presupuestoProyectoData.flatDonaciones.Where(a => a.objetivoProyecto.idObjetivoClase == (int)ObjectiveClass.Activity).Select(d => new { 
                donaciones = d.donaciones as IEnumerable<dynamic>
            }).Sum(d => d.donaciones.Sum(m => (double)m.Monto));
            var _pendienteDonacion = _totalDonado - _totalDonacionObjetivos;


            return new { 
                proyecto = presupuestoProyectoData.proyecto,
                proyectoDonantes = presupuestoProyectoData.proyectoDonantes,
                distribucionPresupuesto = presupuestoProyectoData.distribucionPresupuesto,
                totalDonado = _totalDonado,
                totalPresupuesto = _totalPresupuesto,
                totalFinanciado = _totalFinanciado,
                totalContrapartida = _totalContrapartida,
                pendiente = _pendiente,
                totalDistribuido = _totalDistribuido,
                pendienteDistribucion = _pendienteDistribucion,
                flatObjetivos = presupuestoProyectoData.flatObjetivos,
                flatPresupuesto = presupuestoProyectoData.flatPresupuesto,
                flatDonaciones = presupuestoProyectoData.flatDonaciones,
                calendarioDonaciones = presupuestoProyectoData.calendarioDonaciones,
                totalProjectImplementation = _totalProjectImplementation,
                totalPresupuestoObjetivos = _totalPresupuestoObjetivos,
                pendientePresupuesto = _pendientePresupuesto,
                totalDonacionObjetivos = _totalDonacionObjetivos,
                pendienteDonacion = _pendienteDonacion
            };
        }

        private void GetFlatPresupuesto(ProjectRepository.ObjetivoProyecto objetivoProyecto, ref List<PresupuestoObjetivo> flatPresupuesto)
        {
            PresupuestoObjetivo presupuestoObjetivo = new PresupuestoObjetivo()
            {
                idObjetivo = objetivoProyecto.idObjetivo,
                objetivo = objetivoProyecto.objetivo,
                objetivoProyecto = objetivoProyecto,
                presupuesto = Context.pry_presupuesto.Where(a => a.IdObjetivo == objetivoProyecto.idObjetivo && a.IdTipoPresupuesto == 1).FirstOrDefault()
            };
            flatPresupuesto.Add(presupuestoObjetivo);
            foreach (ProjectRepository.ObjetivoProyecto childObjetivoProyecto in objetivoProyecto.children)
            {
                GetFlatPresupuesto(childObjetivoProyecto, ref flatPresupuesto);
            }
        }

        private void GetFlatDonaciones(int idDonante, ProjectRepository.ObjetivoProyecto objetivoProyecto, ref List<DonacionesObjetivo> flatDonaciones)
        {
            IEnumerable<Pry_Presupuesto> presupuestos = Context.pry_presupuesto.Where(a => a.IdObjetivo == objetivoProyecto.idObjetivo && a.IdTipoPresupuesto == 1);

            DonacionesObjetivo donacionObjetivo = new DonacionesObjetivo()
            {
                idDonante = idDonante,
                idObjetivo = objetivoProyecto.idObjetivo,
                objetivoProyecto = objetivoProyecto,
                donaciones = Context.pry_presupuesto.Where(a => a.IdObjetivo == objetivoProyecto.idObjetivo && a.IdTipoPresupuesto == 6).ToList(),
                totalPresupuesto = (presupuestos != null && presupuestos.Count() > 0) ? presupuestos.Sum(a => a.Monto.HasValue ? a.Monto.Value : 0) : 0
            };
            flatDonaciones.Add(donacionObjetivo);
            foreach (ProjectRepository.ObjetivoProyecto childObjetivoProyecto in objetivoProyecto.children)
            {
                GetFlatDonaciones(idDonante, childObjetivoProyecto, ref flatDonaciones);
            }
        }

        public string GetNextCode(int idObjetivo)
        {
            Pry_Objetivos objetivo = Context.pry_objetivos.Where(a => a.IdObjetivo == idObjetivo).FirstOrDefault();
            string objetivoCode = objetivo.Codigo;
            int index = 0;
            foreach (Pry_Recursos recurso in Context.pry_recursos.Where(a => a.IdObjetivo == idObjetivo))
            {
                int codigoNumber;
                if (int.TryParse(recurso.Codigo.Substring(recurso.Codigo.LastIndexOf(".") + 1), out codigoNumber))
                {
                    if (index < codigoNumber) index = codigoNumber;
                }
            }
            index += 1;
            string nextCode = objetivoCode + "." + index;
            return nextCode;
        }

        public Pry_Presupuesto GetPresupuestoDonanteByProjectDonante(int idProyecto, int idDonante)
        {
            return Context.pry_presupuesto.FirstOrDefault(p => p.IdProyecto == idProyecto && p.IdDonante == idDonante && p.IdTipoPresupuesto == 5);
        }

        public IEnumerable<Pry_Presupuesto> GetAllPresupuestoDonanteByProjectDonante(int idProyecto, int idDonante)
        {
            return Context.pry_presupuesto.Where(p => p.IdProyecto == idProyecto && p.IdDonante == idDonante);
        }

        public Pry_Proyectos_Donantes GetProyectoDonante(int idProyecto, int idDonante)
        {
            return Context.pry_proyectos_donantes.Where(a => a.IdProyecto == idProyecto && a.IdDonante == idDonante).FirstOrDefault();
        }

        public Pry_Presupuesto GetPresupuestoById(int idPresupuesto)
        {
            return Context.pry_presupuesto.Where(a => a.IdPresupuesto == idPresupuesto).FirstOrDefault();
        }

        public Pry_Recursos GetRecursoById(int idRecurso)
        {
            return Context.pry_recursos.Where(a => a.IdRecurso == idRecurso).FirstOrDefault();
        }

        public Pry_CalendarioDonaciones GetCalendarioDonacionById(int idDonacion)
        {
            return Context.pry_calendariodonaciones.Where(a => a.IdDonacion == idDonacion).FirstOrDefault();
        }

        public Sys_Usuarios GetUsuarioById(int idUsuario)
        {
            return Context.sys_usuarios.Where(a => a.IdUsuario == idUsuario).FirstOrDefault();
        }

        public void addProyectoDonante(Pry_Proyectos_Donantes proyectoDonante)
        {
            Context.Add(proyectoDonante);
            Context.SaveChanges();
        }

        public void addPresupuesto(Pry_Presupuesto presupuesto)
        {
            Context.Add(presupuesto);
            Context.SaveChanges();
        }

        public void addRecurso(Pry_Recursos recurso)
        {
            Context.Add(recurso);
            Context.SaveChanges();
        }

        public void addCalendarioDonacion(Pry_CalendarioDonaciones calendarioDonacion)
        {
            Context.Add(calendarioDonacion);
            Context.SaveChanges();
        }

        public void modifyData()
        {
            Context.SaveChanges();
        }

        public void deleteProyectoDonante(Pry_Proyectos_Donantes proyectoDonante)
        {
            Context.Delete(proyectoDonante);
            Context.SaveChanges();
        }

        public void deleteRecurso(Pry_Recursos recurso)
        {
            Context.Delete(recurso);
            Context.SaveChanges();
        }

        public void deleteCalendarioDonacion(Pry_CalendarioDonaciones calendarioDonacion)
        {
            Context.Delete(calendarioDonacion);
            Context.SaveChanges();
        }

        public void deletePresupuesto(Pry_Presupuesto presupuesto)
        {
            Context.Delete(presupuesto);
            Context.SaveChanges();
        }

        //class just to return the budget to budget assistant view

        public class PresupuestoProyectoData
        {
            public Pry_Proyectos proyecto { get; set; }
            public List<Pry_Proyectos_Donantes> proyectoDonantes { get; set; }
            public List<DistribucionPresupuestoProyecto> distribucionPresupuesto { get; set; }
            public double totalDonado { get { return proyectoDonantes.Sum(a => a.Monto.HasValue ? a.Monto.Value : 0); } }
            public double totalPresupuesto { get { return (proyecto.MONTOFINANCIAMIENTO.HasValue ? proyecto.MONTOFINANCIAMIENTO.Value : 0) + (proyecto.MONTOCONTRAPARTIDA.HasValue ? proyecto.MONTOCONTRAPARTIDA.Value : 0); } }
            public double totalFinanciado { get { return (proyecto.MONTOFINANCIAMIENTO.HasValue ? proyecto.MONTOFINANCIAMIENTO.Value : 0); } }
            public double totalContrapartida { get { return (proyecto.MONTOCONTRAPARTIDA.HasValue ? proyecto.MONTOCONTRAPARTIDA.Value : 0); } }
            public double pendiente { get { return totalPresupuesto - totalDonado; } }
            public double totalDistribuido { get { return distribucionPresupuesto.Sum(a => a.monto.HasValue ? a.monto.Value : 0); } }
            public double pendienteDistribucion { get { return totalPresupuesto - totalDistribuido; } }
            public List<ProjectRepository.ObjetivoProyecto> objetivos { get; set; }
            public List<ProjectRepository.ObjetivoProyecto> flatObjetivos { get; set; }
            public List<PresupuestoObjetivo> flatPresupuesto { get; set; }
            public List<DonacionesObjetivo> flatDonaciones { get; set; }
            public List<Pry_CalendarioDonaciones> calendarioDonaciones { get; set; }
            public double totalProjectImplementation { get { return distribucionPresupuesto.Where(a => a.idTipo == 1).Sum(a => a.monto.HasValue ? a.monto.Value : 0); } }
            public double totalPresupuestoObjetivos { get { return flatPresupuesto.Where(a => a.presupuesto != null && a.presupuesto.IdTipoPresupuesto == 1 && a.objetivo.IdObjetivoClase == (int)ObjectiveClass.Product).Sum(a => a.presupuesto.Monto.HasValue ? a.presupuesto.Monto.Value : 0); } } // TODO: verificar si debo incluir (int)ObjectiveClass.Result
            public double pendientePresupuesto { get { return totalProjectImplementation - totalPresupuestoObjetivos; } }
            public double totalDonacionObjetivos { get { return flatDonaciones.Where(a => a.objetivo.IdObjetivoClase == (int)ObjectiveClass.Activity).Sum(a => a.totalDonaciones); } }
            public double pendienteDonacion { get { return totalDonado - totalDonacionObjetivos; } }
        }

        public class PresupuestoObjetivo
        {
            public int idObjetivo { get; set; }
            public Pry_Objetivos objetivo { get; set; }
            public ProjectRepository.ObjetivoProyecto objetivoProyecto { get; set; }
            public Pry_Presupuesto presupuesto { get; set; }
        }

        public class DonacionesObjetivo
        {
            public int idDonante { get; set; }
            public int idObjetivo { get; set; }
            public Pry_Objetivos objetivo { get { return objetivoProyecto.objetivo; } }
            public ProjectRepository.ObjetivoProyecto objetivoProyecto { get; set; }
            public List<Pry_Presupuesto> donaciones { get; set; }
            public double totalPresupuesto { get; set; }
            public double totalDonaciones { get { return donaciones.Sum(a => a.Monto.HasValue ? a.Monto.Value : 0); } }
            public double pendiente { get { return totalPresupuesto - totalDonaciones; } }
        }

        public class DistribucionPresupuestoProyecto
        {
            public int idTipo { get; set; }
            public int idProyecto { get; set; }
            public string descripcion { get; set; }
            public int? idPresupuesto { get; set; }
            public double? monto { get; set; }
            public DateTime? fechaCreacion { get; set; }
        }

    }
    #endregion

    #region Conversor Monedas
    public class ConversorMonedasRepository : IConversorMonedasRepository
    {
        private IContextRepository Context;

        public ConversorMonedasRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public m_TipCambio GetTipoCambio(int idMoneda)
        {
            IEnumerable<m_TipCambio> cambiosMoneda = Context.m_tipcambio.Where(b => b.idMoneda == idMoneda);
            if (cambiosMoneda.Count() == 0) return null;
            else
            {
                DateTime? lastDate = Context.m_tipcambio.Where(b => b.idMoneda == idMoneda).Max(b => b.FecTipCambio);
                return Context.m_tipcambio.Where(a => a.idMoneda == idMoneda && a.FecTipCambio == lastDate).FirstOrDefault();
            }
        }

    }
    #endregion

    #region variables
    public class VariablesRepository : IVariablesRepository
    {
        private IContextRepository Context;

        public VariablesRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Pry_Variables> GetAllVariables()
        {
            return Context.pry_variables;
        }

        public Pry_Variables GetVariable(int idVariable)
        {
            return Context.pry_variables.Where(a => a.IdVariable == idVariable).FirstOrDefault();
        }

        public void addVariable(Pry_Variables variable)
        {
            Context.Add(variable);
            Context.SaveChanges();
        }

        public void modifyData()
        {
            Context.SaveChanges();
        }

        public void deleteVariable(Pry_Variables variable)
        {
            Context.Delete(variable);
            Context.SaveChanges();
        }
    }
    #endregion

    #region Tipos de Cambio

    public class TipCambioRepository : ITipCambioRepository
    {

        //Repositorio para ingresar tipos de Cambios.

        private IContextRepository Context;

        public TipCambioRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        //devuelve todos los tipos de cambio por mes, año y la moneda

        public IEnumerable<Object> GetAll()
        {

            var tc = (from t in Context.m_tipcambio
                      select new
                      {
                          t.idTipCambio,
                          t.idMoneda,
                          t.FecTipCambio,
                          t.ValCompra,
                          t.ValVenta,
                          t.M_Monedas.Nombre
                      }).OrderBy(t => t.idMoneda).ThenBy(t => t.FecTipCambio).AsEnumerable();

            return tc;
        }

        //devuelve un tipo de cambio por fecha y moneda

        public Object GetTipCamioByFechaMoneda(DateTime fecCambio, int idMoneda)
        {
            return (from t in Context.m_tipcambio
                    where t.FecTipCambio == fecCambio && t.idMoneda == idMoneda
                    select new { t.idTipCambio, t.idMoneda, t.FecTipCambio, t.ValCompra, t.ValVenta, t.M_Monedas.Nombre }).FirstOrDefault();
        }

        //add tipos de cambio de un mes

        public void addTipCambio(List<m_TipCambio> TiposCambios)
        {
            foreach (var Tipcambio in TiposCambios)
            {
                Context.Add(Tipcambio);
            }

            Context.SaveChanges();
        }



    }

    #endregion*/

    //Realizado andres
    #region  Mensaje Repository

    public class MensajeRepository : IMensajesRepository
    {
        private IContextRepository Context;

        public MensajeRepository(IContextRepository _Context)
        {
            Context = _Context;
        }
        //Metodo para ver todos los mensajes los mensajes 
        public IEnumerable<Object> GetMensajes()
        {
            return (from t in Context.com_mensajes
                    join p in Context.sys_usuarios on t.IdUsuarioRemitente equals p.IdUsuario
                    join dt in Context.sys_usuarios on t.IdUsuarioDestinatario equals dt.IdUsuario
                    
                    select new
                    {
                        idMensaje = t.IdMensaje,
                        idUsuarioRemitente = t.IdUsuarioRemitente,
                        IdUsuarioDestinatario = t.IdUsuarioDestinatario,
                        IdEstado = t.IdEstado,
                        Asunto = t.Asunto,
                        Mensaje = t.Mensaje,
                        Prioridad = t.Prioridad,
                        FechaEnvio = t.FechaEnvio,
                        FechaLectura = t.FechaLectura,
                        FechaBorrado = t.FechaBorrado,
                        nombre = p.Nombre,
                        Enviadoa = dt.Nombre,
                        IdTenant = t.IdTenant,
                    }).AsEnumerable();
        }

        //public IEnumerable<Object> GetMensajesId(int idUsuario)
        //{
        //    return (from t in Context.com_mensajes
        //            join p in Context.sys_Usuarios on t.IdUsuarioRemitente equals p.IdUsuario
        //            join dt in Context.sys_Usuarios on t.IdUsuarioDestinatario equals dt.IdUsuario
        //            where dt.IdUsuario == idUsuario

        //            select new
        //            {
        //                idMensaje = t.IdMensaje,
        //                idUsuarioRemitente = t.IdUsuarioRemitente,
        //                IdUsuarioDestinatario = t.IdUsuarioDestinatario,
        //                IdEstado = t.IdEstado,
        //                Asunto = t.Asunto,
        //                Mensaje = t.Mensaje,
        //                Prioridad = t.Prioridad,
        //                FechaEnvio = t.FechaEnvio,
        //                FechaLectura = t.FechaLectura,
        //                FechaBorrado = t.FechaBorrado,
        //                nombre = p.Nombre,
        //                Enviadoa = dt.Nombre
        //            }).AsEnumerable();
        //}



        //retorna una modena por Id

        //Metodo para agregar un nuevo Mensaje.

        public void addMensaje(Com_Mensajes newMensaje)
        {
            Context.Add(newMensaje);
            Context.SaveChanges();
        }


        public void ActualizarEstado(int idMensaje, int idEstado)
        {
            Com_Mensajes m = new Com_Mensajes();
            try
            {

                if (idEstado == 2)
                {

                    m = Context.com_mensajes.Single(me => me.IdMensaje == idMensaje);
                    m.IdEstado = idEstado;
                    m.FechaLectura = DateTime.Now;

                }
                if (idEstado == 3)
                {
                    
                    m = Context.com_mensajes.Single(me => me.IdMensaje == idMensaje);
                    m.IdEstado = idEstado;
                    m.FechaBorrado = DateTime.Now;
                }
                Context.SaveChanges();


            }
            catch (Exception ex)
            {
                ex = new Exception("Err000001");

                throw ex;
            }

        }

        public Com_Mensajes GetMessage(int idMessage)
        {
            return Context.com_mensajes.FirstOrDefault(x => x.IdMensaje == idMessage);
        }



    }
    #endregion

    # region Listas Repository

    public class ListasRepository : IListasRepository
    {
        private IContextRepository Context;
        public ListasRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        ////Para las Listas
        public IEnumerable<Object> Get()
        {
            return (from t in Context.tar_listas
                    select new { t.IdProyecto, t.Id, t.Descripcion }).AsEnumerable();
        }


        public void addListas(Tar_Listas newLista)
        {
            Context.Add(newLista);
            Context.SaveChanges();
        }
        public void ActualizarLista(Tar_Listas list)
        {

            Tar_Listas _list = Context.tar_listas.FirstOrDefault(l => l.Id == list.Id);

            _list.IdUsuarioModificacion = list.IdUsuarioModificacion;
            _list.Descripcion = list.Descripcion;

            Context.SaveChanges();
            
        }

    }
    #endregion

    # region Tareas Repository

    public class TareasRepository : ITareasRepository
    {
        private IContextRepository Context;
        public TareasRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public Tar_Tareas GetTareaById(int id)
        {
            return Context.tar_tareas.FirstOrDefault(m => m.Id == id);
        }

        //Agregados
        public IEnumerable<Object> Get()
        {
            return (from t in Context.tar_tareas
                    where t.Estado == false
                    select new
                    {
                        t.Id,
                        t.IdLista,
                        t.Descripcion,
                        t.FechaInicio,
                        t.FechaFin,
                        t.FechaCompletado,
                        t.IdResponsable,
                        t.Prioridad,
                        t.Estado,
                        t.IdUsuarioCreacion,
                        usuarioCreacion = Context.sys_usuarios.FirstOrDefault(u => u.IdUsuario == t.IdUsuarioCreacion).Nombre,
                        Responsable = Context.sys_usuarios.FirstOrDefault(u => u.IdUsuario == t.IdResponsable).Nombre
                    }).AsEnumerable();

        }
        //Devulve el listado de usuarios para enviar correo.
        public void addTarea(Tar_Tareas newTarea)
        {
            Context.Add(newTarea);
            Context.SaveChanges();
        }

        public void ActualizarTarea(Tar_Tareas task)
        {

            Tar_Tareas _task = Context.tar_tareas.FirstOrDefault(t => t.Id == task.Id);

            _task.Descripcion = task.Descripcion;
            _task.FechaInicio = task.FechaInicio;
            _task.FechaFin = task.FechaFin;
            _task.IdResponsable = task.IdResponsable;
            _task.IdUsuarioModificacion = task.IdUsuarioModificacion;
            _task.Prioridad = task.Prioridad;

            if (task.IdUsuarioCompletado != null)
            {
                _task.IdUsuarioCompletado = task.IdUsuarioCompletado;
                _task.FechaCompletado = DateTime.Now;
            }

            Context.SaveChanges();
            
        }
        public void EliminarTarea(int id)
        {
            //estado is set to true when the task is deleted

            Tar_Tareas task = Context.tar_tareas.FirstOrDefault(t => t.Id == id);

            task.Estado = true;

            Context.SaveChanges();

        }

    }
    #endregion

    # region PartidasRepository Repository

    public class PryPartidasRepository : IPryPartidasRepository
    {
        private IContextRepository Context;
        public PryPartidasRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Object> GetPartidas()
        {
            return (from d in Context.pry_partidagastos

                    select new
                    {
                        d.IDPARTIDAGASTO,
                        d.ABREVIATURA,
                        d.CODIGO,
                        d.NOMBRE,

                    }).AsEnumerable();

        }
        public void addPartidas(PRY_PARTIDAGASTOS newPartida)
        {
            Context.Add(newPartida);
            Context.SaveChanges();
        }

        public void ActualizarPartidas(int id, string abrevi, string codigo, string nombre)
        {

            PRY_PARTIDAGASTOS m = new PRY_PARTIDAGASTOS();
            try
            {
                m = Context.pry_partidagastos.Single(me => me.IDPARTIDAGASTO == id);
                m.ABREVIATURA = abrevi;
                m.CODIGO = codigo;
                m.NOMBRE = nombre;
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                ex = new Exception("Err000001");

                throw ex;
            }

        }
        public void Eliminar(int id)
        {
            var registro = (from c in Context.pry_partidagastos
                            where c.IDPARTIDAGASTO == id
                            select c).FirstOrDefault();
            Context.Delete(registro);
            Context.SaveChanges();
        }



    }
    #endregion

#region Niveles Aceptacion Repository

    //Controls the Nivel Aceptacion table data

    public class NivelAceptacionRepository : INivelAceptacionRepository
    {
        private IContextRepository Context;

        public NivelAceptacionRepository(IContextRepository _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Object> getAll()
        {
            return Context.pry_nivelaceptacion.Select(n => new { n.IdNivelAceptacion, n.Nombre, n.Descripcion, n.Color }).AsEnumerable();
        }


    }

#endregion

}
