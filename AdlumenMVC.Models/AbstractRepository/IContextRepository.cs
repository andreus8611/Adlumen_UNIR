using AdlumenMVC.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace AdlumenMVC.Models.AbstractRepository
{
    public interface IContextRepository
    {

        #region Interface Tables
        IQueryable<PRY_INFORMESICA> pry_informesica { get; }

        IQueryable<PRY_PERIODOSPROYECTOS> pry_periodosproyectos { get; }

        IQueryable<Pry_Proyectos> pry_proyectos { get; }

        IQueryable<M_Monedas> m_monedas { get; }

        IQueryable<Pry_Facilitadores> Pry_Facilitadores { get; }

        IQueryable<M_Preguntas> m_preguntas { get; }

        IQueryable<M_Encuestas> m_encuestas { get; }

        IQueryable<M_Idiomas> m_idiomas { get; }

        IQueryable<M_Paises> m_paises { get; }

        IQueryable<m_TipCambio> m_tipcambio { get; }

        IQueryable<Tar_Visitas> tar_visitas { get; }

        IQueryable<Tar_Bitacora> tar_bitacora { get; }

        IQueryable<Tar_Permisos_Bitacora> tar_permisos_bitacora { get; }

        IQueryable<Sys_Usuarios> sys_usuarios { get; }

        IQueryable<Sys_Clientes> sys_clientes { get; }

        IQueryable<Tar_Tareas> tar_tareas { get; }

        IQueryable<Pry_EvaluacionHitos> pry_evaluacionhitos { get; }

        IQueryable<PRY_EVALUACIONINDICADORESPERIODO> pry_evaluacionindicadores { get; }

        IQueryable<PRY_EVALUACIONPROYECTOPERIODO> pry_evaluacionproyectoperiodo { get; }

        IQueryable<PRY_EVALUACIONESACTIVIDADESPERIODO> pry_evaluacionactividades { get; }

        IQueryable<Tar_Listas> tar_listas { get; }

        IQueryable<Pry_Objetivos> pry_objetivos { get; }

        IQueryable<Pry_ObjetivosClase> pry_objetivosclase { get; }

        IQueryable<Pry_NivelAceptacion> pry_nivelaceptacion { get; }
        IQueryable<Pry_Presupuesto> pry_presupuesto { get; }

        IQueryable<Pry_Movimientos> pry_movimientos { get; }

        IQueryable<Pry_MontoDonacion> pry_montosdonacion { get; }

        IQueryable<Pry_PresupuestoTipo> pry_presupuestotipo { get; }

        IQueryable<PRY_PARTIDAGASTOS> pry_partidagastos { get; }

        IQueryable<Pry_Indicadores> pry_indicadores { get; }

        IQueryable<Pry_IndicadoresTipos> pry_indicadorestipos { get; }

        IQueryable<Pry_DatosMuestras> pry_datosmuestras { get; }

        IQueryable<Pry_Informes> pry_informes { get; }

        IQueryable<Pry_Informes_Indicador> pry_informes_indicador { get; }

        IQueryable<Pry_Variables> pry_variables { get; }

        IQueryable<Pry_IndicadoresVerificadores> pry_indicadoresverificadores { get; }

        IQueryable<Pry_DatosVariables> pry_datosvariables { get; }

        IQueryable<Pry_DatosVerificadores> pry_datosverificadores { get; }

        IQueryable<Pry_Proyectos_NivelAceptacion> pry_proyectos_nivelaceptacion { get; }

        IQueryable<Pry_ProyectosTipos> pry_proyectostipos { get; }

        IQueryable<Pry_ProyectosEstados> pry_proyectosestados { get; }

        IQueryable<Pry_Supuestos> pry_supuestos { get; }

        IQueryable<Pry_Proyectos_Donantes> pry_proyectos_donantes { get; }

        IQueryable<Pry_Recursos> pry_recursos { get; }

        IQueryable<Pry_CalendarioDonaciones> pry_calendariodonaciones { get; }

        IQueryable<Org_Areas> org_areas { get; }

        IQueryable<Org_Cargos> org_cargos { get; }

        IQueryable<Org_Empleados> org_empleados { get; }

        IQueryable<Org_Empresas> org_empresas { get; }

        IQueryable<Org_IdentificacionTipos> org_identificaciontipos { get; }

        IQueryable<Org_Proveedores> org_proveedores { get; }

        IQueryable<Org_Donantes> org_donantes { get; }

        IQueryable<Doc_Documentos> doc_documentos { get; }

        IQueryable<Doc_Categorias> doc_categorias { get; }

        IQueryable<Doc_ArchivosTipos> doc_archivostipos { get; }

        IQueryable<Pry_Capacitaciones> Pry_Capacitaciones { get; }

        IQueryable<Pry_Objetivos> Pry_Objetivos { get; }

        IQueryable<Pry_Beneficiarios> Pry_Beneficiarios { get; }

        IQueryable<Pry_ProductividadBeneficiario> Pry_ProductividadBeneficiario { get; }

        IQueryable<Pry_CapacitacionBeneficiario> Pry_CapacitacionBeneficiario { get; }

        IQueryable<Com_Mensajes> com_mensajes { get; }

        IQueryable<M_EncuestasResueltas> m_encuestasResueltas { get; }

        IQueryable<M_PosiblesRespuestas> m_posiblesRespuestas { get; }
        IQueryable<M_PreguntasResueltas> m_preguntasResueltas { get; }

        IQueryable<Tenant> Tenants { get; }
        #endregion

        #region  Interface Functions and Procedures

        //int selperiodoactivo(int idperiodo, int idproyecto);

        T Add<T>(T entity) where T : class;

        T Delete<T>(T entity) where T : class;

        int SaveChanges();

        List<SELEVALUACIONESHITOS_Result> selevaluacioneshitos(int idproyecto, int idperiodo, int idTenant);

        List<SELEVALUACIONESINDICADORES_Result> selevaluacionesindicadores(int idproyecto, int idperiodo, int idTenant);

        List<SELEVALUACIONPROYECTOPERIODO_Result> selevaluacionesproyectoperiodo(int idproyecto, int idTenant);

        List<SELEVALUACIONESACTIVIDADESPERIODO_Result> selevaluacionesactividades(int idproyecto, int idperiodo, int idTenant);

        List<SELTOTALESMOVIMIENTOPROYECTO_Result> seltotalesmovimientoproyecto(int idproyecto, int idTenant);

        List<SELMOVIMIENTOEJECUTADOPROYECTO_Result> selmovimientoejecutadoproyecto(int idproyecto, int idTenant);

        #endregion
    }
}
