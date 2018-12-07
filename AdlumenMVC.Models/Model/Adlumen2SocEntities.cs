using System.Linq;
using System.Collections.Generic;
using AdlumenMVC.Models.AbstractRepository;
namespace AdlumenMVC.Models.Model
{
    public partial class Adlumen2SocEntities : IContextRepository
    {
        #region Declaracion de Metodos de Interfaces

        #region Interface Tables

        IQueryable<PRY_INFORMESICA> IContextRepository.pry_informesica { get { return PRY_INFORMESICA; } }

        IQueryable<PRY_PERIODOSPROYECTOS> IContextRepository.pry_periodosproyectos { get { return PRY_PERIODOSPROYECTOS; } }

        IQueryable<Pry_Proyectos> IContextRepository.pry_proyectos { get { return Pry_Proyectos; } }

        IQueryable<M_Monedas> IContextRepository.m_monedas { get { return M_Monedas; } }


        IQueryable<Pry_Facilitadores> IContextRepository.Pry_Facilitadores { get { return Pry_Facilitadores; } }
        IQueryable<Pry_Capacitaciones> IContextRepository.Pry_Capacitaciones { get { return Pry_Capacitaciones; } }

        IQueryable<Pry_Objetivos> IContextRepository.Pry_Objetivos { get { return Pry_Objetivos; } }

        IQueryable<Pry_Beneficiarios> IContextRepository.Pry_Beneficiarios { get { return Pry_Beneficiarios; } }

        IQueryable<Pry_ProductividadBeneficiario> IContextRepository.Pry_ProductividadBeneficiario { get { return Pry_ProductividadBeneficiario; } }

        IQueryable<Pry_CapacitacionBeneficiario> IContextRepository.Pry_CapacitacionBeneficiario { get { return Pry_CapacitacionBeneficiario; } }

        IQueryable<m_TipCambio> IContextRepository.m_tipcambio { get { return m_TipCambio; } }

        IQueryable<M_Preguntas> IContextRepository.m_preguntas { get { return M_Preguntas; } }

        IQueryable<M_Encuestas> IContextRepository.m_encuestas { get { return M_Encuestas; } }

        IQueryable<M_Idiomas> IContextRepository.m_idiomas { get { return M_Idiomas; } }

        IQueryable<M_Paises> IContextRepository.m_paises { get { return M_Paises; } }

        IQueryable<Tar_Visitas> IContextRepository.tar_visitas { get { return Tar_Visitas; } }

        IQueryable<Tar_Bitacora> IContextRepository.tar_bitacora { get { return Tar_Bitacora; } }

        IQueryable<Tar_Permisos_Bitacora> IContextRepository.tar_permisos_bitacora { get { return Tar_Permisos_Bitacora; } }

        IQueryable<Sys_Usuarios> IContextRepository.sys_usuarios { get { return Sys_Usuarios; } }

        IQueryable<Sys_Clientes> IContextRepository.sys_clientes { get { return Sys_Clientes; } }

        IQueryable<Tar_Tareas> IContextRepository.tar_tareas { get { return Tar_Tareas; } }

        IQueryable<Pry_EvaluacionHitos> IContextRepository.pry_evaluacionhitos { get { return Pry_EvaluacionHitos; } }

        IQueryable<PRY_EVALUACIONINDICADORESPERIODO> IContextRepository.pry_evaluacionindicadores { get { return PRY_EVALUACIONINDICADORESPERIODO; } }

        IQueryable<PRY_EVALUACIONPROYECTOPERIODO> IContextRepository.pry_evaluacionproyectoperiodo { get { return PRY_EVALUACIONPROYECTOPERIODO; } }

        IQueryable<PRY_EVALUACIONESACTIVIDADESPERIODO> IContextRepository.pry_evaluacionactividades { get { return PRY_EVALUACIONESACTIVIDADESPERIODO; } }

        IQueryable<Tar_Listas> IContextRepository.tar_listas { get { return Tar_Listas; } }

        IQueryable<Pry_Objetivos> IContextRepository.pry_objetivos { get { return Pry_Objetivos; } }

        IQueryable<Pry_ObjetivosClase> IContextRepository.pry_objetivosclase { get { return Pry_ObjetivosClase; } }

        IQueryable<Pry_NivelAceptacion> IContextRepository.pry_nivelaceptacion { get { return Pry_NivelAceptacion; } }

        IQueryable<Pry_Presupuesto> IContextRepository.pry_presupuesto { get { return Pry_Presupuesto; } }

        IQueryable<Pry_PresupuestoTipo> IContextRepository.pry_presupuestotipo { get { return Pry_PresupuestoTipo; } }

        IQueryable<PRY_PARTIDAGASTOS> IContextRepository.pry_partidagastos { get { return PRY_PARTIDAGASTOS; } }

        IQueryable<Pry_Movimientos> IContextRepository.pry_movimientos { get { return Pry_Movimientos; } }

        IQueryable<Pry_MontoDonacion> IContextRepository.pry_montosdonacion { get { return Pry_MontoDonacion; } }

        IQueryable<Pry_Indicadores> IContextRepository.pry_indicadores { get { return Pry_Indicadores; } }

        IQueryable<Pry_IndicadoresTipos> IContextRepository.pry_indicadorestipos { get { return Pry_IndicadoresTipos; } }

        IQueryable<Pry_DatosMuestras> IContextRepository.pry_datosmuestras { get { return Pry_DatosMuestras; } }

        IQueryable<Pry_Informes> IContextRepository.pry_informes { get { return Pry_Informes; } }

        IQueryable<Pry_Informes_Indicador> IContextRepository.pry_informes_indicador { get { return Pry_Informes_Indicador; } }

        IQueryable<Pry_Variables> IContextRepository.pry_variables { get { return Pry_Variables; } }

        IQueryable<Pry_IndicadoresVerificadores> IContextRepository.pry_indicadoresverificadores { get { return Pry_IndicadoresVerificadores; } }

        IQueryable<Pry_DatosVariables> IContextRepository.pry_datosvariables { get { return Pry_DatosVariables; } }

        IQueryable<Pry_DatosVerificadores> IContextRepository.pry_datosverificadores { get { return Pry_DatosVerificadores; } }

        IQueryable<Pry_ProyectosEstados> IContextRepository.pry_proyectosestados { get { return Pry_ProyectosEstados; } }

        IQueryable<Pry_Supuestos> IContextRepository.pry_supuestos { get { return Pry_Supuestos; } }

        IQueryable<Pry_Proyectos_Donantes> IContextRepository.pry_proyectos_donantes { get { return Pry_Proyectos_Donantes; } }

        IQueryable<Pry_Recursos> IContextRepository.pry_recursos { get { return Pry_Recursos; } }

        IQueryable<Pry_CalendarioDonaciones> IContextRepository.pry_calendariodonaciones { get { return Pry_CalendarioDonaciones; } }
        IQueryable<Pry_Proyectos_NivelAceptacion> IContextRepository.pry_proyectos_nivelaceptacion { get { return Pry_Proyectos_NivelAceptacion; } }

        IQueryable<Pry_ProyectosTipos> IContextRepository.pry_proyectostipos { get { return Pry_ProyectosTipos; } }


        IQueryable<Org_Areas> IContextRepository.org_areas { get { return Org_Areas; } }

        IQueryable<Org_Cargos> IContextRepository.org_cargos { get { return Org_Cargos; } }

        IQueryable<Org_Empleados> IContextRepository.org_empleados { get { return Org_Empleados; } }

        IQueryable<Org_Empresas> IContextRepository.org_empresas { get { return Org_Empresas; } }

        IQueryable<Org_Proveedores> IContextRepository.org_proveedores { get { return Org_Proveedores; } }

        IQueryable<Org_IdentificacionTipos> IContextRepository.org_identificaciontipos { get { return Org_IdentificacionTipos; } }

        IQueryable<Org_Donantes> IContextRepository.org_donantes { get { return Org_Donantes; } }

        IQueryable<Doc_Documentos> IContextRepository.doc_documentos { get { return Doc_Documentos; } }

        IQueryable<Doc_Categorias> IContextRepository.doc_categorias { get { return Doc_Categorias; } }

        IQueryable<Doc_ArchivosTipos> IContextRepository.doc_archivostipos { get { return Doc_ArchivosTipos; } }
        //Realizados por andres
        IQueryable<Com_Mensajes> IContextRepository.com_mensajes { get { return Com_Mensajes; } }
        IQueryable<M_EncuestasResueltas> IContextRepository.m_encuestasResueltas { get { return M_EncuestasResueltas; } }

        IQueryable<M_PosiblesRespuestas> IContextRepository.m_posiblesRespuestas { get { return M_PosiblesRespuestas; } }
        IQueryable<M_PreguntasResueltas> IContextRepository.m_preguntasResueltas { get { return M_PreguntasResueltas; } }

        IQueryable<Tenant> IContextRepository.Tenants {  get { return Tenants; } }
        #endregion

        #region  Interface Functions and Procedures

        //int IContextRepository.selperiodoactivo(int idperiodo, int idproyecto)
        //{
        //    return SELPERIODOACTIVO(idperiodo, idproyecto);
        //}

        T IContextRepository.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }

        T IContextRepository.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }

        int IContextRepository.SaveChanges()
        {
            return SaveChanges();
        }

        List<SELEVALUACIONESHITOS_Result> IContextRepository.selevaluacioneshitos(int idproyecto, int idperiodo, int idTenant)
        {
            return SELEVALUACIONESHITOS(idproyecto, idperiodo, idTenant).ToList();
        }

        List<SELEVALUACIONESINDICADORES_Result> IContextRepository.selevaluacionesindicadores(int idproyecto, int idperiodo, int idTenant)
        {
            return SELEVALUACIONESINDICADORES(idproyecto, idperiodo, idTenant).ToList();
        }

        List<SELEVALUACIONPROYECTOPERIODO_Result> IContextRepository.selevaluacionesproyectoperiodo(int idproyecto, int idTenant)
        {
            return SELEVALUACIONPROYECTOPERIODO(idproyecto, idTenant).ToList();
        }

        List<SELEVALUACIONESACTIVIDADESPERIODO_Result> IContextRepository.selevaluacionesactividades(int idproyecto, int idperiodo, int idTenant)
        {
            return SELEVALUACIONESACTIVIDADESPERIODO(idproyecto, idperiodo, idTenant).ToList();
        }

        List<SELTOTALESMOVIMIENTOPROYECTO_Result> IContextRepository.seltotalesmovimientoproyecto(int idproyecto, int idTenant)
        {
            return SELTOTALESMOVIMIENTOPROYECTO(idproyecto, idTenant).ToList();
        }

        List<SELMOVIMIENTOEJECUTADOPROYECTO_Result> IContextRepository.selmovimientoejecutadoproyecto(int idproyecto, int idTenant)
        {
            return SELMOVIMIENTOEJECUTADOPROYECTO(idproyecto, idTenant).ToList();
        }

        #endregion

        #endregion
    }
}