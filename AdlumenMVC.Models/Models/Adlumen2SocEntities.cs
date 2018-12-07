using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AdlumenMVC.Models.Model.Mapping;

namespace AdlumenMVC.Models.Model
{
    public partial class Adlumen2SocEntities : TenantDbContext
    {
        static Adlumen2SocEntities()
        {
            Database.SetInitializer<Adlumen2SocEntities>(null);
        }

        public Adlumen2SocEntities()
            : base("Name=Adlumen2SocEntities")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.Log = sql => Debug.Write(sql);
        }

        public DbSet<Accione> Acciones { get; set; }
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Cms_MenuNodos> Cms_MenuNodos { get; set; }
        public DbSet<Cms_Menus> Cms_Menus { get; set; }
        public DbSet<Com_Mensajes> Com_Mensajes { get; set; }
        public DbSet<Com_MensajesEstado> Com_MensajesEstado { get; set; }
        public DbSet<Doc_ArchivosTipos> Doc_ArchivosTipos { get; set; }
        public DbSet<Doc_Categorias> Doc_Categorias { get; set; }
        public DbSet<Doc_Clientes_Categorias> Doc_Clientes_Categorias { get; set; }
        public DbSet<Doc_Documentos> Doc_Documentos { get; set; }
        public DbSet<Documentos_Tareas> Documentos_Tareas { get; set; }
        public DbSet<M_Encuestas> M_Encuestas { get; set; }
        public DbSet<M_EncuestasResueltas> M_EncuestasResueltas { get; set; }
        public DbSet<M_Idiomas> M_Idiomas { get; set; }
        public DbSet<M_Monedas> M_Monedas { get; set; }
        public DbSet<M_Paises> M_Paises { get; set; }
        public DbSet<M_Periodos> M_Periodos { get; set; }
        public DbSet<M_Plantillas> M_Plantillas { get; set; }
        public DbSet<M_PosiblesRespuestas> M_PosiblesRespuestas { get; set; }
        public DbSet<M_Preguntas> M_Preguntas { get; set; }
        public DbSet<M_PreguntasResueltas> M_PreguntasResueltas { get; set; }
        public DbSet<M_Temas> M_Temas { get; set; }
        public DbSet<m_TipCambio> m_TipCambio { get; set; }
        public DbSet<M_ValoresRespuesta> M_ValoresRespuesta { get; set; }
        public DbSet<Modulo> Moduloes { get; set; }
        public DbSet<Org_Areas> Org_Areas { get; set; }
        public DbSet<Org_Cargos> Org_Cargos { get; set; }
        public DbSet<Org_Donantes> Org_Donantes { get; set; }
        public DbSet<Org_Donantes_Empresas> Org_Donantes_Empresas { get; set; }
        public DbSet<Org_Empleados> Org_Empleados { get; set; }
        public DbSet<Org_EmpleadosCargosHistorico> Org_EmpleadosCargosHistorico { get; set; }
        public DbSet<Org_Empresas> Org_Empresas { get; set; }
        public DbSet<Org_IdentificacionTipos> Org_IdentificacionTipos { get; set; }
        public DbSet<Org_Proveedores> Org_Proveedores { get; set; }
        public DbSet<Pry_Beneficiarios> Pry_Beneficiarios { get; set; }
        public DbSet<Pry_Bitacoras> Pry_Bitacoras { get; set; }
        public DbSet<Pry_CalendarioDonaciones> Pry_CalendarioDonaciones { get; set; }
        public DbSet<Pry_CapacitacionBeneficiario> Pry_CapacitacionBeneficiario { get; set; }
        public DbSet<Pry_Capacitaciones> Pry_Capacitaciones { get; set; }
        public DbSet<Pry_DatosMuestras> Pry_DatosMuestras { get; set; }
        public DbSet<Pry_DatosVariables> Pry_DatosVariables { get; set; }
        public DbSet<Pry_DatosVerificadores> Pry_DatosVerificadores { get; set; }
        public DbSet<PRY_EVALUACIONESACTIVIDADESPERIODO> PRY_EVALUACIONESACTIVIDADESPERIODO { get; set; }
        public DbSet<Pry_EvaluacionHitos> Pry_EvaluacionHitos { get; set; }
        public DbSet<PRY_EVALUACIONINDICADORESPERIODO> PRY_EVALUACIONINDICADORESPERIODO { get; set; }
        public DbSet<PRY_EVALUACIONPROYECTOPERIODO> PRY_EVALUACIONPROYECTOPERIODO { get; set; }
        public DbSet<Pry_Facilitadores> Pry_Facilitadores { get; set; }
        public DbSet<Pry_Indicadores> Pry_Indicadores { get; set; }
        public DbSet<Pry_Indicadores_Variables> Pry_Indicadores_Variables { get; set; }
        public DbSet<Pry_IndicadoresProyecto_Programa> Pry_IndicadoresProyecto_Programa { get; set; }
        public DbSet<Pry_IndicadoresTipos> Pry_IndicadoresTipos { get; set; }
        public DbSet<Pry_IndicadoresVerificadores> Pry_IndicadoresVerificadores { get; set; }
        public DbSet<Pry_Informes> Pry_Informes { get; set; }
        public DbSet<Pry_Informes_Donantes> Pry_Informes_Donantes { get; set; }
        public DbSet<Pry_Informes_Encuestas> Pry_Informes_Encuestas { get; set; }
        public DbSet<Pry_Informes_Indicador> Pry_Informes_Indicador { get; set; }
        public DbSet<Pry_Informes_Presupuestos> Pry_Informes_Presupuestos { get; set; }
        public DbSet<Pry_Informes_Supuestos> Pry_Informes_Supuestos { get; set; }
        public DbSet<Pry_InformesEstados> Pry_InformesEstados { get; set; }
        public DbSet<PRY_INFORMESICA> PRY_INFORMESICA { get; set; }
        public DbSet<PRY_INFORMESICADETALLE> PRY_INFORMESICADETALLE { get; set; }
        public DbSet<PRY_INFORMESICADOCUMENTOS> PRY_INFORMESICADOCUMENTOS { get; set; }
        public DbSet<PRY_INFORMESICAESTADOS> PRY_INFORMESICAESTADOS { get; set; }
        public DbSet<PRY_INFORMESICAINDICADORES> PRY_INFORMESICAINDICADORES { get; set; }
        public DbSet<PRY_INFORMESICAOBJETIVOS> PRY_INFORMESICAOBJETIVOS { get; set; }
        public DbSet<PRY_INFORMESICATIPOS> PRY_INFORMESICATIPOS { get; set; }
        public DbSet<Pry_MontoDonacion> Pry_MontoDonacion { get; set; }
        public DbSet<Pry_Movimientos> Pry_Movimientos { get; set; }
        public DbSet<Pry_NivelAceptacion> Pry_NivelAceptacion { get; set; }
        public DbSet<Pry_Objetivos> Pry_Objetivos { get; set; }
        public DbSet<Pry_ObjetivosClase> Pry_ObjetivosClase { get; set; }
        public DbSet<PRY_PARTIDAGASTOS> PRY_PARTIDAGASTOS { get; set; }
        public DbSet<PRY_PERIODOSPROYECTOS> PRY_PERIODOSPROYECTOS { get; set; }
        public DbSet<Pry_Presupuesto> Pry_Presupuesto { get; set; }
        public DbSet<Pry_PresupuestoTipo> Pry_PresupuestoTipo { get; set; }
        public DbSet<Pry_ProductividadBeneficiario> Pry_ProductividadBeneficiario { get; set; }
        public DbSet<Pry_Proyectos> Pry_Proyectos { get; set; }
        public DbSet<Pry_Proyectos_Donantes> Pry_Proyectos_Donantes { get; set; }
        public DbSet<Pry_Proyectos_NivelAceptacion> Pry_Proyectos_NivelAceptacion { get; set; }
        public DbSet<Pry_ProyectosEstados> Pry_ProyectosEstados { get; set; }
        public DbSet<Pry_ProyectosTipos> Pry_ProyectosTipos { get; set; }
        public DbSet<Pry_Recursos> Pry_Recursos { get; set; }
        public DbSet<Pry_Supuestos> Pry_Supuestos { get; set; }
        public DbSet<Pry_Variables> Pry_Variables { get; set; }
        public DbSet<Sys_Clientes> Sys_Clientes { get; set; }
        public DbSet<Sys_Usuarios> Sys_Usuarios { get; set; }
        public DbSet<Sys_Usuarios_Donantes> Sys_Usuarios_Donantes { get; set; }
        //public DbSet<Sys_Usuarios_Empresas> Sys_Usuarios_Empresas { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Tar_Bitacora> Tar_Bitacora { get; set; }
        public DbSet<Tar_Listas> Tar_Listas { get; set; }
        public DbSet<Tar_Permisos_Bitacora> Tar_Permisos_Bitacora { get; set; }
        public DbSet<Tar_Tareas> Tar_Tareas { get; set; }
        public DbSet<Tar_Visitas> Tar_Visitas { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        //public DbSet<View_ejecutado_resultado_tipo> View_ejecutado_resultado_tipo { get; set; }
        //public DbSet<View_Informe_de_Saldos> View_Informe_de_Saldos { get; set; }
        //public DbSet<View_Informe_ITFSemestral> View_Informe_ITFSemestral { get; set; }
        //public DbSet<View_Informe_Saldos_FER> View_Informe_Saldos_FER { get; set; }
        //public DbSet<View_InformeAdministrativoITFUNIP> View_InformeAdministrativoITFUNIP { get; set; }
        //public DbSet<View_InformeAvanceHitos> View_InformeAvanceHitos { get; set; }
        //public DbSet<View_InformeCronogramaHitos> View_InformeCronogramaHitos { get; set; }
        //public DbSet<View_InformeCronogramaHitos1> View_InformeCronogramaHitos1 { get; set; }
        //public DbSet<View_InformeRendicionGastos1> View_InformeRendicionGastos1 { get; set; }
        //public DbSet<View_InformeRendicionGastos1fer> View_InformeRendicionGastos1fer { get; set; }
        //public DbSet<View_InformeTecnicoAvanceHitos> View_InformeTecnicoAvanceHitos { get; set; }
        //public DbSet<View_InfromeDetalleEjecucionGasto> View_InfromeDetalleEjecucionGasto { get; set; }
        //public DbSet<View_ppto_resultado_tipo> View_ppto_resultado_tipo { get; set; }
        //public DbSet<View_saldoppto_resultado_tipo> View_saldoppto_resultado_tipo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AccioneMap());
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new Cms_MenuNodosMap());
            modelBuilder.Configurations.Add(new Cms_MenusMap());
            modelBuilder.Configurations.Add(new Com_MensajesMap());
            modelBuilder.Configurations.Add(new Com_MensajesEstadoMap());
            modelBuilder.Configurations.Add(new Doc_ArchivosTiposMap());
            modelBuilder.Configurations.Add(new Doc_CategoriasMap());
            modelBuilder.Configurations.Add(new Doc_Clientes_CategoriasMap());
            modelBuilder.Configurations.Add(new Doc_DocumentosMap());
            modelBuilder.Configurations.Add(new Documentos_TareasMap());
            modelBuilder.Configurations.Add(new M_EncuestasMap());
            modelBuilder.Configurations.Add(new M_EncuestasResueltasMap());
            modelBuilder.Configurations.Add(new M_IdiomasMap());
            modelBuilder.Configurations.Add(new M_MonedasMap());
            modelBuilder.Configurations.Add(new M_PaisesMap());
            modelBuilder.Configurations.Add(new M_PeriodosMap());
            modelBuilder.Configurations.Add(new M_PlantillasMap());
            modelBuilder.Configurations.Add(new M_PosiblesRespuestasMap());
            modelBuilder.Configurations.Add(new M_PreguntasMap());
            modelBuilder.Configurations.Add(new M_PreguntasResueltasMap());
            modelBuilder.Configurations.Add(new M_TemasMap());
            modelBuilder.Configurations.Add(new m_TipCambioMap());
            modelBuilder.Configurations.Add(new M_ValoresRespuestaMap());
            modelBuilder.Configurations.Add(new ModuloMap());
            modelBuilder.Configurations.Add(new Org_AreasMap());
            modelBuilder.Configurations.Add(new Org_CargosMap());
            modelBuilder.Configurations.Add(new Org_DonantesMap());
            modelBuilder.Configurations.Add(new Org_Donantes_EmpresasMap());
            modelBuilder.Configurations.Add(new Org_EmpleadosMap());
            modelBuilder.Configurations.Add(new Org_EmpleadosCargosHistoricoMap());
            modelBuilder.Configurations.Add(new Org_EmpresasMap());
            modelBuilder.Configurations.Add(new Org_IdentificacionTiposMap());
            modelBuilder.Configurations.Add(new Org_ProveedoresMap());
            modelBuilder.Configurations.Add(new Pry_BeneficiariosMap());
            modelBuilder.Configurations.Add(new Pry_BitacorasMap());
            modelBuilder.Configurations.Add(new Pry_CalendarioDonacionesMap());
            modelBuilder.Configurations.Add(new Pry_CapacitacionBeneficiarioMap());
            modelBuilder.Configurations.Add(new Pry_CapacitacionesMap());
            modelBuilder.Configurations.Add(new Pry_DatosMuestrasMap());
            modelBuilder.Configurations.Add(new Pry_DatosVariablesMap());
            modelBuilder.Configurations.Add(new Pry_DatosVerificadoresMap());
            modelBuilder.Configurations.Add(new PRY_EVALUACIONESACTIVIDADESPERIODOMap());
            modelBuilder.Configurations.Add(new Pry_EvaluacionHitosMap());
            modelBuilder.Configurations.Add(new PRY_EVALUACIONINDICADORESPERIODOMap());
            modelBuilder.Configurations.Add(new PRY_EVALUACIONPROYECTOPERIODOMap());
            modelBuilder.Configurations.Add(new Pry_FacilitadoresMap());
            modelBuilder.Configurations.Add(new Pry_IndicadoresMap());
            modelBuilder.Configurations.Add(new Pry_Indicadores_VariablesMap());
            modelBuilder.Configurations.Add(new Pry_IndicadoresProyecto_ProgramaMap());
            modelBuilder.Configurations.Add(new Pry_IndicadoresTiposMap());
            modelBuilder.Configurations.Add(new Pry_IndicadoresVerificadoresMap());
            modelBuilder.Configurations.Add(new Pry_InformesMap());
            modelBuilder.Configurations.Add(new Pry_Informes_DonantesMap());
            modelBuilder.Configurations.Add(new Pry_Informes_EncuestasMap());
            modelBuilder.Configurations.Add(new Pry_Informes_IndicadorMap());
            modelBuilder.Configurations.Add(new Pry_Informes_PresupuestosMap());
            modelBuilder.Configurations.Add(new Pry_Informes_SupuestosMap());
            modelBuilder.Configurations.Add(new Pry_InformesEstadosMap());
            modelBuilder.Configurations.Add(new PRY_INFORMESICAMap());
            modelBuilder.Configurations.Add(new PRY_INFORMESICADETALLEMap());
            modelBuilder.Configurations.Add(new PRY_INFORMESICADOCUMENTOSMap());
            modelBuilder.Configurations.Add(new PRY_INFORMESICAESTADOSMap());
            modelBuilder.Configurations.Add(new PRY_INFORMESICAINDICADORESMap());
            modelBuilder.Configurations.Add(new PRY_INFORMESICAOBJETIVOSMap());
            modelBuilder.Configurations.Add(new PRY_INFORMESICATIPOSMap());
            modelBuilder.Configurations.Add(new Pry_MontoDonacionMap());
            modelBuilder.Configurations.Add(new Pry_MovimientosMap());
            modelBuilder.Configurations.Add(new Pry_NivelAceptacionMap());
            modelBuilder.Configurations.Add(new Pry_ObjetivosMap());
            modelBuilder.Configurations.Add(new Pry_ObjetivosClaseMap());
            modelBuilder.Configurations.Add(new PRY_PARTIDAGASTOSMap());
            modelBuilder.Configurations.Add(new PRY_PERIODOSPROYECTOSMap());
            modelBuilder.Configurations.Add(new Pry_PresupuestoMap());
            modelBuilder.Configurations.Add(new Pry_PresupuestoTipoMap());
            modelBuilder.Configurations.Add(new Pry_ProductividadBeneficiarioMap());
            modelBuilder.Configurations.Add(new Pry_ProyectosMap());
            modelBuilder.Configurations.Add(new Pry_Proyectos_DonantesMap());
            modelBuilder.Configurations.Add(new Pry_Proyectos_NivelAceptacionMap());
            modelBuilder.Configurations.Add(new Pry_ProyectosEstadosMap());
            modelBuilder.Configurations.Add(new Pry_ProyectosTiposMap());
            modelBuilder.Configurations.Add(new Pry_RecursosMap());
            modelBuilder.Configurations.Add(new Pry_SupuestosMap());
            modelBuilder.Configurations.Add(new Pry_VariablesMap());
            modelBuilder.Configurations.Add(new Sys_ClientesMap());
            modelBuilder.Configurations.Add(new Sys_UsuariosMap());
            modelBuilder.Configurations.Add(new Sys_Usuarios_DonantesMap());
            //modelBuilder.Configurations.Add(new Sys_Usuarios_EmpresasMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new Tar_BitacoraMap());
            modelBuilder.Configurations.Add(new Tar_ListasMap());
            modelBuilder.Configurations.Add(new Tar_Permisos_BitacoraMap());
            modelBuilder.Configurations.Add(new Tar_TareasMap());
            modelBuilder.Configurations.Add(new Tar_VisitasMap());
            modelBuilder.Configurations.Add(new TenantMap());
            //modelBuilder.Configurations.Add(new View_ejecutado_resultado_tipoMap());
            //modelBuilder.Configurations.Add(new View_Informe_de_SaldosMap());
            //modelBuilder.Configurations.Add(new View_Informe_ITFSemestralMap());
            //modelBuilder.Configurations.Add(new View_Informe_Saldos_FERMap());
            //modelBuilder.Configurations.Add(new View_InformeAdministrativoITFUNIPMap());
            //modelBuilder.Configurations.Add(new View_InformeAvanceHitosMap());
            //modelBuilder.Configurations.Add(new View_InformeCronogramaHitosMap());
            //modelBuilder.Configurations.Add(new View_InformeCronogramaHitos1Map());
            //modelBuilder.Configurations.Add(new View_InformeRendicionGastos1Map());
            //modelBuilder.Configurations.Add(new View_InformeRendicionGastos1ferMap());
            //modelBuilder.Configurations.Add(new View_InformeTecnicoAvanceHitosMap());
            //modelBuilder.Configurations.Add(new View_InfromeDetalleEjecucionGastoMap());
            //modelBuilder.Configurations.Add(new View_ppto_resultado_tipoMap());
            //modelBuilder.Configurations.Add(new View_saldoppto_resultado_tipoMap());
        }

        [DbFunction("Adlumen2SocEntities", "FSELPERIODOPORFECHAS")]
        public virtual IQueryable<FSELPERIODOPORFECHAS_Result> FSELPERIODOPORFECHAS(Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, Nullable<int> idproyecto)
        {
            var fechaInicioParameter = fechaInicio.HasValue ?
                new ObjectParameter("fechaInicio", fechaInicio) :
                new ObjectParameter("fechaInicio", typeof(System.DateTime));

            var fechaFinParameter = fechaFin.HasValue ?
                new ObjectParameter("fechaFin", fechaFin) :
                new ObjectParameter("fechaFin", typeof(System.DateTime));

            var idproyectoParameter = idproyecto.HasValue ?
                new ObjectParameter("idproyecto", idproyecto) :
                new ObjectParameter("idproyecto", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FSELPERIODOPORFECHAS_Result>("[Adlumen2SocEntities].[FSELPERIODOPORFECHAS](@fechaInicio, @fechaFin, @idproyecto)", fechaInicioParameter, fechaFinParameter, idproyectoParameter);
        }

        [DbFunction("Adlumen2SocEntities", "FSELPERIODOSPROYECTO")]
        public virtual IQueryable<FSELPERIODOSPROYECTO_Result> FSELPERIODOSPROYECTO(Nullable<int> idproyecto)
        {
            var idproyectoParameter = idproyecto.HasValue ?
                new ObjectParameter("idproyecto", idproyecto) :
                new ObjectParameter("idproyecto", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FSELPERIODOSPROYECTO_Result>("[Adlumen2SocEntities].[FSELPERIODOSPROYECTO](@idproyecto)", idproyectoParameter);
        }

        public virtual ObjectResult<SELEVALUACIONESACTIVIDADESPERIODO_Result> SELEVALUACIONESACTIVIDADESPERIODO(Nullable<int> idProyecto, Nullable<long> idPeriodo, int idTenant)
        {
            var idProyectoParameter = idProyecto.HasValue ?
                new SqlParameter("idProyecto", idProyecto) :
                new SqlParameter("idProyecto", typeof(int));

            var idPeriodoParameter = idPeriodo.HasValue ?
                new SqlParameter("idPeriodo", idPeriodo) :
                new SqlParameter("idPeriodo", typeof(long));

            var idTenantParameter = new SqlParameter("idTenant", idTenant);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<SELEVALUACIONESACTIVIDADESPERIODO_Result>("SELEVALUACIONESACTIVIDADESPERIODO @idProyecto, @idPeriodo, @idTenant", idProyectoParameter, idPeriodoParameter, idTenantParameter);
        }

        public virtual ObjectResult<SELEVALUACIONESHITOS_Result> SELEVALUACIONESHITOS(Nullable<int> idProyecto, Nullable<long> idPeriodo, int idTenant)
        {
            var idProyectoParameter = idProyecto.HasValue ?
                new SqlParameter("idProyecto", idProyecto) :
                new SqlParameter("idProyecto", typeof(int));

            var idPeriodoParameter = idPeriodo.HasValue ?
                new SqlParameter("idPeriodo", idPeriodo) :
                new SqlParameter("idPeriodo", typeof(long));

            var idTenantParameter = new SqlParameter("idTenant", idTenant);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<SELEVALUACIONESHITOS_Result>("SELEVALUACIONESHITOS @idProyecto, @idPeriodo, @idTenant", idProyectoParameter, idPeriodoParameter, idTenantParameter);
        }

        public virtual ObjectResult<SELEVALUACIONESINDICADORES_Result> SELEVALUACIONESINDICADORES(Nullable<int> idProyecto, Nullable<long> idPeriodo, int idTenant)
        {
            var idProyectoParameter = idProyecto.HasValue ?
                new SqlParameter("idProyecto", idProyecto) :
                new SqlParameter("idProyecto", typeof(int));

            var idPeriodoParameter = idPeriodo.HasValue ?
                new SqlParameter("idPeriodo", idPeriodo) :
                new SqlParameter("idPeriodo", typeof(long));

            var idTenantParameter = new SqlParameter("idTenant", idTenant);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<SELEVALUACIONESINDICADORES_Result>("SELEVALUACIONESINDICADORES @idProyecto, @idPeriodo, @idTenant", idProyectoParameter, idPeriodoParameter, idTenantParameter);
        }

        public virtual ObjectResult<SELEVALUACIONPROYECTOPERIODO_Result> SELEVALUACIONPROYECTOPERIODO(Nullable<int> idProyecto, int idTenant)
        {
            var idProyectoParameter = idProyecto.HasValue ?
                new SqlParameter("idProyecto", idProyecto) :
                new SqlParameter("idProyecto", typeof(int));

            var idTenantParameter = new SqlParameter("idTenant", idTenant);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<SELEVALUACIONPROYECTOPERIODO_Result>("SELEVALUACIONPROYECTOPERIODO @idProyecto, @idTenant", idProyectoParameter, idTenantParameter);
        }

        public virtual ObjectResult<SELMOVIMIENTOEJECUTADOPROYECTO_Result> SELMOVIMIENTOEJECUTADOPROYECTO(Nullable<int> idProyecto, int idTenant)
        {
            var idProyectoParameter = idProyecto.HasValue ?
                new SqlParameter("idProyecto", idProyecto) :
                new SqlParameter("idProyecto", typeof(int));

            var idTenantParameter = new SqlParameter("idTenant", idTenant);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<SELMOVIMIENTOEJECUTADOPROYECTO_Result>("SELMOVIMIENTOEJECUTADOPROYECTO @idProyecto, @idTenant", idProyectoParameter, idTenantParameter);
        }

        //public virtual ObjectResult<SELOBJETIVOSPORPERIODOINDICADOR_Result> SELOBJETIVOSPORPERIODOINDICADOR(Nullable<int> idproposito, Nullable<System.DateTime> fECHAINICIO, Nullable<System.DateTime> fECHAFIN)
        //{
        //    var idpropositoParameter = idproposito.HasValue ?
        //        new SqlParameter("idproposito", idproposito) :
        //        new SqlParameter("idproposito", typeof(int));

        //    var fECHAINICIOParameter = fECHAINICIO.HasValue ?
        //        new SqlParameter("FECHAINICIO", fECHAINICIO) :
        //        new SqlParameter("FECHAINICIO", typeof(System.DateTime));

        //    var fECHAFINParameter = fECHAFIN.HasValue ?
        //        new SqlParameter("FECHAFIN", fECHAFIN) :
        //        new SqlParameter("FECHAFIN", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<SELOBJETIVOSPORPERIODOINDICADOR_Result>("SELOBJETIVOSPORPERIODOINDICADOR @idproposito, @FECHAINICIO, @FECHAFIN", idpropositoParameter, fECHAINICIOParameter, fECHAFINParameter);
        //}

        //public virtual int SELPERIODOACTIVO(Nullable<int> idperiodo, Nullable<int> idproyecto)
        //{
        //    var idperiodoParameter = idperiodo.HasValue ?
        //        new SqlParameter("idperiodo", idperiodo) :
        //        new SqlParameter("idperiodo", typeof(int));

        //    var idproyectoParameter = idproyecto.HasValue ?
        //        new SqlParameter("idproyecto", idproyecto) :
        //        new SqlParameter("idproyecto", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<SELPERIODOACTIVO_Result>("SELPERIODOACTIVO", idperiodoParameter, idproyectoParameter);
        //}

        public virtual ObjectResult<SELTOTALESMOVIMIENTOPROYECTO_Result> SELTOTALESMOVIMIENTOPROYECTO(Nullable<int> idProyecto, int idTenant)
        {
            var idProyectoParameter = idProyecto.HasValue ?
                new SqlParameter("idProyecto", idProyecto) :
                new SqlParameter("idProyecto", typeof(int));

            var idTenantParameter = new SqlParameter("idTenant", idTenant);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<SELTOTALESMOVIMIENTOPROYECTO_Result>("SELTOTALESMOVIMIENTOPROYECTO @idProyecto, @idTenant", idProyectoParameter, idTenantParameter);
        }
    }
}
