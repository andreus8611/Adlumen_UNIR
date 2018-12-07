using AdlumenMVC.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdlumenMVC.Bussiness.RealRepositories.EmpresasRepository;

namespace AdlumenMVC.Bussiness.AbstractRepositories
{
    public interface ITenantsRepository
    {
        Tenant GetById(int id);
        IEnumerable<Tenant> GetAll();

        void Create(Tenant tenant);
        void Update(Tenant tenant);
        void Delete(Tenant tenant);
    }

    #region periodos

    public interface IPeriodosProyectos
    {

        //Devuelve todos los períodos existentes

        IEnumerable<Object> GetAll();

        //Devuelve todos los Períodos de un Proyecto.

        List<PRY_PERIODOSPROYECTOS> GetAllPeriodsByProject(int IdProject);

        //Devolver periodo por el Id del proyecto y del periodo

        PRY_PERIODOSPROYECTOS GetPeriodById(int idProyecto, int idPeriodo);

        //Procedimiento para cambiar estado del período.

        void PeriodChangeState(int idPeriodo, int idProyecto);
    }

    #endregion

    #region Facilitadores

    public interface IFacilitadores
    {
        IEnumerable<Object> GetFacilitadores();

        Pry_Facilitadores GetFacilitadorById(int idFacilitador);

        void addFacilitador(Pry_Facilitadores facilitador);

        void updateFacilitador(Pry_Facilitadores facilitador);

        void deleteFacilitador(Pry_Facilitadores facilitador);
    }


    #endregion

    #region Capacitaciones

    public interface ICapacitaciones
    {
        IEnumerable<Object> GetCapacitaciones();

        Pry_Capacitaciones GetCapacitacionById(int idCapacitacion);

        void addCapacitacion(Pry_Capacitaciones capacitacion);

        void updateCapacitacion(Pry_Capacitaciones capacitacion);

        void deleteCapacitacion(Pry_Capacitaciones capacitacion);
    }

    #endregion

    #region Beneficiarios
    public interface IBeneficiarios
    {
        IEnumerable<Object> GetBeneficiarios();

        Pry_Beneficiarios GetBeneficiarioById(int idBeneficiario);

        void addBeneficiario(Pry_Beneficiarios beneficiario);

        void updateBeneficiario(Pry_Beneficiarios beneficiario);

        void deleteBeneficiario(Pry_Beneficiarios beneficiario);
    }
    #endregion

    #region Productividad Beneficiario
    public interface IProductividadBeneficiario
    {
        IEnumerable<Object> GetProductividadBeneficiario();

        Pry_ProductividadBeneficiario GetProductividadBeneficiarioById(int idProductividadBeneficiario);

        void addProductividadBeneficiario(Pry_ProductividadBeneficiario productividad);

        void deleteProductividadBeneficiario(Pry_ProductividadBeneficiario productividad);
    }
    #endregion

    #region Beneficiarios Capacitaciones
    public interface ICapacitacionBeneficiario
    {
        IEnumerable<Object> GetBeneficiariosCapacitaciones();

        Pry_CapacitacionBeneficiario GetBeneficiarioCapacitacionById(int idCapacitacionBeneficiario);

        void addBeneficiarioCapacitacion(Pry_CapacitacionBeneficiario beneficiarioCapacitacion);

        void deleteBeneficiarioCapacitacion(Pry_CapacitacionBeneficiario beneficiarioCapacitacion);
    }
    #endregion

    #region Objetivos

    public interface IObjetivos
    {
        IEnumerable<Object> GetObjetivos();

        //Pry_Beneficiarios GetBeneficiarioById(int idBeneficiario);

        //void addBeneficiario(Pry_Beneficiarios beneficiario);

    }

    #endregion


    #region proyectos

    public interface IProjects
    {

        //retorna el listado de todos los proyectos

        IEnumerable<Object> GetAll();
        //retorna listado de proyectos de acuerdo al usuario responsable

        Pry_Proyectos GetProjects(int idUsuario);

        //retorna un proyecto por id
        Pry_Proyectos GetProyectoById(int idProject);

        Object GetProyectoFullDataById(int idProject);

        string GetNextObjetivoCode(int idPadre);

        Sys_Usuarios GetUsuarioById(int idUsuario);

        Pry_Objetivos GetObjetivoById(int idObjetivo);

        Pry_Indicadores GetIndicadorById(int idIndicador);

        Pry_IndicadoresTipos GetIndicadorTipo(int idIndicadorTipo);

        int GetNextIndicatorCode(int idObjetivo, int idSubTipo, int idTipo);

        Pry_Supuestos GetSupuestoById(int idSupuesto);

        Pry_Informes GetInformeById(int idInforme);

        List<PRY_PERIODOSPROYECTOS> GetAllPeriodosByProyecto(int proyectoId);
        Pry_Proyectos_NivelAceptacion GetProyectoNivelAceptacion(int idProyecto, int idNivelAceptacion);



        void addProyecto(Pry_Proyectos newProyecto);

        void deleteProyecto(Pry_Proyectos proyecto);

        void addObjetivo(Pry_Objetivos newObjetivo);

        void deleteObjetivo(Pry_Objetivos objetivo);

        void addIndicador(Pry_Indicadores indicador);

        void deleteIndicador(Pry_Indicadores indicador);

        void addVerificadores(List<Pry_IndicadoresVerificadores> verificators);

        void modifyVerificadores(int idIndicador, List<Pry_IndicadoresVerificadores> verificators);

        void addSupuesto(Pry_Supuestos supuesto);

        void deleteSupuesto(Pry_Supuestos supuesto);

        void addInforme(Pry_Informes informe);

        void deleteInforme(Pry_Informes informe);

        void addPeriodoProyecto(PRY_PERIODOSPROYECTOS periodoProyecto);
        void deletePeriodoProyecto(PRY_PERIODOSPROYECTOS periodoProyecto);
        void addNivelAceptacionProyecto(Pry_Proyectos_NivelAceptacion nivelAceptacionProyecto);

        void modifyData();
    }

    #endregion

    #region Monedas

    public interface IMonedaRepository
    {
        //Devuelve todas las monedas

        IEnumerable<Object> GetAll();

        //Devuelve una moneda por Id

        M_Monedas getModedaById(int id);

        //Agrega una moneda

        void addMoneda(M_Monedas newMoneda);
        void Update(M_Monedas moneda);
        void Delete(M_Monedas moneda);
    }

    #endregion

    #region Tipos de Cambio

    public interface ITipCambioRepository
    {

        //devuelve todos los tipos de cambios por mes, año y moneda

        IEnumerable<Object> GetAll();

        //devuelve un tipo de cambio por fecha y moneda

        Object GetTipCamioByFechaMoneda(DateTime fecCambio, int idMoneda);

        //add tipos de cambio de un mes

        void addTipCambio(List<m_TipCambio> TiposCambios);

    }

    #endregion

    #region Encuestas

    public interface ICuestionarioRepository
    {
        IEnumerable<Object> GetCuestionarios();

        //Devuelve un cuestionario por Encuesta Id
        object GetCuestionarioById(int idEncuesta);

        //Agrega un cuestionario
        void addEncuestaResuelta(M_EncuestasResueltas newEncuestaResuelta);
    }

    public interface IEncuestasRepository
    {
        //Devuelve todas las encuestas
        IEnumerable<M_Encuestas> GetAll();

        //retorna una encuesta por Id
        M_Encuestas GetEncuestaById(int id);

        //Agrega una encuesta
        void addEncuesta(M_Encuestas newEncuesta);

        //Mofifica una encuesta
        void modifyEncuesta();

        //Elimina una encuesta
        void deleteEncuesta(M_Encuestas encuesta);

        //Bloquea una encuesta
        void lockEncuesta(M_Encuestas encuesta);

        //Termina una encuesta
        void finishEncuesta(M_Encuestas encuesta);
    }

    public interface IPreguntasRepository
    {
        //Devuelve todas las encuestas
        IEnumerable<Object> GetAll();

        //retorna una pregunta por Id
        M_Preguntas GetPreguntaById(int id);

        //Agrega una pregunta
        void addPregunta(M_Preguntas newPregunta);

        //Mofifica una pregunta
        void modifyPregunta(M_Preguntas pregunta);

        //Elimina una pregunta
        void deletePregunta(M_Preguntas pregunta);

        //Elimina las posibles respuestas de una pregunta
        void deletePosiblesRespuestas(M_Preguntas pregunta);
    }

    #endregion

    #region Idiomas
    public interface IIdiomasRepository
    {
        //Devuelve todos lo idiomas
        IEnumerable<M_Idiomas> GetAll();
    }
    #endregion

    #region Visitas
    public interface IVisitasRepository
    {
        //Devuelve todas las visita
        IEnumerable<Object> GetAll();

        //retorna una visita por Id
        Tar_Visitas GetVisitaById(int id);

        //Agrega una visita
        void addVisita(Tar_Visitas newVisita);

        //Mofifica una visita
        void modifyVisita();

        //Elimina una visita
        void deleteVisita(Tar_Visitas visita);

        //Bloquea una encuesta
        void completeVisita(Tar_Visitas visita);
    }

    public interface IBitacoraRepository
    {
        //Devuelve todas las bitacoras
        IEnumerable<Object> GetAll();

        //Agrega una bitacora
        void addBitacora(Tar_Bitacora newBitacora);
    }

    public interface IPermisosBitacoraRepository
    {
        //retorna los permisos de una visita
        IEnumerable<Object> GetPermisos();

        void deletePermisosByVisitaId(int idVisita);

        //Agrega un permiso de bitacora
        void addPermisoBitacora(Tar_Permisos_Bitacora newPermisoBitacora);
    }

    #endregion

    #region Evaluacion
    public interface IEvaluacionHitosRepository
    {
        //retorna el objeto de evaluación de hitos por periodo
        object GetEvaluacionHitosObjectByPeriod(int idPeriodo, int idTenant);

        //retorna todas las evaluaciones hitos
        List<SELEVALUACIONESHITOS_Result> GetAll(int idProyecto, int idPeriodo, int idTenant);

        //Salva la evaluación
        void AddEvaluationHito(int idProyecto, int idPeriodo, int idResultado,
                               int idActividad, int idHito, string observacionED,
                               string observacionUrip, int idUsuario,
                               decimal porcentajehito, decimal cv, decimal adh);
    }

    public interface IEvaluacionIndicadoresRepository
    {
        //retorna el objeto de evaluación de indicadores por periodo
        object GetEvaluacionIndicadoresObjectByPeriod(int idPeriodo, int idTenant);

        //retorna todas las evaluaciones hitos
        List<SELEVALUACIONESINDICADORES_Result> GetAll(int idProyecto, int idPeriodo, int idTenant);

        //Salva la evaluación
        void AddEvaluationIndicador(int idProyecto, int idPeriodo, int idResultado,
                                  int idHito, string observacionED,
                                  string observacionUrip, int idUsuario,
                                  decimal porcentajeHito, decimal cv, decimal adh);
    }

    public interface IEvaluacionProyectoPeriodoRepository
    {
        //retorna el objeto de evaluación de indicadores por periodo
        object GetEvaluacionProyectoPeriodoObjectByProject(int idPeriodo, int idTenant);

        //retorna todas las evaluaciones hitos
        List<SELEVALUACIONPROYECTOPERIODO_Result> GetAll(int idProyecto, int idTenant);

        //Salva la evaluación
        void AddEvaluationProyectoPeriodo(int idProyecto, int idPeriodo, string datosfinancieros, string observaciones,
                                  string recomendaciones, int idUsuario);
    }

    public interface IEvaluacionProyectoActividadRepository
    {
        //retorna el objeto de evaluación de indicadores por periodo
        object GetEvaluacionActividadObjectByProject(int idPeriodo, int idTenant);

        //retorna todas las evaluaciones hitos
        List<SELEVALUACIONESACTIVIDADESPERIODO_Result> GetAll(int idProyecto, int idPeriodo, int idTenant);

        //Salva la evaluación
        void AddEvaluationActividades(int idProyecto, int idPeriodo, int idObjetivo, string observaciones, int idUsuario);
    }
    #endregion

    #region indicadores
    public interface IIndicadoresProyectoRepository
    {
        Object GetProjectObjectives(int idProyecto);

        Object GetPurposeObjectives(int idPurpose);

        Object GetIndicatorsDetail(int idObjective);

        Object GetIndicatorDetail(int idIndicator);

        Object GetVerificadoresIndicador(int idIndicador);

        Pry_DatosMuestras GetDatosMuestrasById(int id);

        Pry_DatosVariables GetDatosVariablesById(int idMuestra, int idVariable);

        void modifyMuestra();

        void addDatosVariable(Pry_DatosVariables newDatosVariable);

        void actualizarIndicador(Pry_DatosMuestras muestra);

        void actualizarLogros(Pry_DatosMuestras muestra, bool nuevaMuestra);

        void addDatosMuestra(Pry_DatosMuestras newDatosMuestra);

        void addDatosVerificador(Pry_DatosVerificadores newDatosVerificador);

        void deleteDatosVerificador(int idDatosFuentes);

        Sys_Usuarios GetUsuarioById(int idUsuario);

        void deleteMuestra(Pry_DatosMuestras muestra);
        Pry_DatosVerificadores GetDatoVerificador(int id);
    }

    #endregion

    #region Empresas
    public interface IEmpresasRepository
    {
        //retorna el listado de todas las empresas
        IEnumerable<Object> GetEmpresasActivas();

        IEnumerable<Object> GetIdentificacionTipos();

        Org_Empresas GetEmpresa(int idEmpresa);

        //retorna una empresa por id
        Object GetEmpresaById(int idEmpresa);

        List<Org_Empleados> GetEmployeesByCargo(int idCargo);

        List<Object> GetEmpleadosActivos();

        Org_Areas GetAreaById(int idArea);

        Org_Cargos GetCargoById(int idCargo);

        Org_Empleados GetEmpleadoById(int idEmpleado);

        Doc_Categorias GetCategoriaById(int idCategoria);

        Doc_Documentos GetDocumentoById(int idDocumento);

        Org_Proveedores GetProveedorById(int idProveedor);

        Sys_Usuarios GetUsuarioById(int idUsuario);

        void addEmpresa(Org_Empresas newEmpresa);

        void modifyEmpresa();

        void deleteEmpresa(Org_Empresas empresa);

        void addArea(Org_Areas newArea);

        void modifyArea();

        void addCargo(Org_Cargos newCargo);

        void modifyCargo();

        void addEmpleado(Org_Empleados newEmpleado);

        void modifyEmpleado();

        void addCategoria(Doc_Categorias newCategoria);

        void modifyCategoria();

        void deleteCategoria(Doc_Categorias categoria);

        void addDocumento(Doc_Documentos newDocumento);

        void modifyDocumento();

        void deleteDocumento(Doc_Documentos documento);

        void addTarea(Tar_Tareas tarea);

        void addProveedor(Org_Proveedores newProveedor);

        void modifyProveedor();

        void deleteUsuariosEmpresa(Org_Empresas empresa);

        void addUsuarioEmpresa(Org_Empresas empresa, Sys_Usuarios usuario);
    }
    #endregion

    #region Paises
    public interface IPaisesRepository
    {
        //Devuelve todos los países
        IEnumerable<Object> GetAll();
    }
    #endregion

    #region Archivos Tipos
    public interface IArchivosTiposRepository
    {
        //Devuelve todos los tipos de archivo
        IEnumerable<Object> GetAll();
    }
    #endregion

    #region Lista de tareas
    public interface IListasTareasRepository
    {
        //Devuelve todas las listas de tareas
        IEnumerable<Object> GetAll();
    }
    #endregion

    #region Usuarios
    public interface IUsuariosRepository
    {
        //Devuelve todos los usuarios
        IEnumerable<Object> GetAll();
        //Devulve el listado de usuarios para enviar correo.
        IEnumerable<Object> GetAllUser();
    }
    #endregion

    #region Costos Repository
    public interface ICostosRepository
    {
        void CalcularCostoObjetivos(int idObjetivo, IQueryable<Pry_Proyectos_NivelAceptacion> nivelesDeAceptacion, int tipo, long idPeriodo);
    }
    #endregion

    #region Financiero
    public interface IFinancieroRepository
    {

        Object GetTotalesMovimientoPorProyecto(int idProyecto, int idTenant);

        IEnumerable<Object> GetAllActividadesByProducto(int idProducto);

        Sys_Usuarios GetUsuarioById(int idUsuario);

        void addMovimiento(Pry_Movimientos movimiento);

        Pry_Movimientos GetMovimiento(int idMovimiento);

        void modifyMovimiento();

        void deleteMovimiento(Pry_Movimientos movimiento);

        void addMontoDonacion(Pry_MontoDonacion montoDonacion);

        void deleteMontoDonacion(Pry_Movimientos movimiento);

    }
    #endregion

    #region Partidas Gastos
    public interface IPartidasGastosRepository
    {
        IEnumerable<Object> GetAllPartidasGastos();
    }
    #endregion

    #region Conversor Monedas
    public interface IConversorMonedasRepository
    {
        m_TipCambio GetTipoCambio(int idMoneda);

    }
    #endregion

    #region Cliente
    public interface IClienteRepository
    {
        Object GetCliente(int id);

        Sys_Usuarios GetUsuarioById(int idUsuario);

        IEnumerable<Object> GetAll();

        IEnumerable<Object> GetActive();

        void Update(Sys_Clientes client);

        void Add(Sys_Clientes client);

        void Delete(int id);
    }

    #endregion

    #region Objetivos Clases
    public interface IObjetivosClasesRepository
    {
        List<Object> GetAll();
    }
    #endregion

    #region Indicadores Tipos
    public interface IIndicadoresTiposRepository
    {
        List<Pry_IndicadoresTipos> GetAll();
    }
    #endregion

    #region Donantes
    public interface IDonantesRepository
    {
        List<Org_Donantes> GetAll();

        Org_Donantes GetDonanteById(int idDonante);

        Sys_Usuarios GetUsuarioById(int idUsuario);

        void modifyData();

        void addDonante(Org_Donantes donante);
    }
    #endregion

    #region Presupuesto Proyecto
    public interface IPresupuestoProyecto
    {

        Pry_Presupuesto GetPresupuestoDonanteByProjectDonante(int idProyecto, int idDonante);

        IEnumerable<Pry_Presupuesto> GetAllPresupuestoDonanteByProjectDonante(int idProyecto, int idDonante);

        Object GetPresupuestoProyectoData(int idProyecto);

        string GetNextCode(int idObjetivo);

        Sys_Usuarios GetUsuarioById(int idUsuario);

        Pry_Proyectos_Donantes GetProyectoDonante(int idProyecto, int idDonante);

        Pry_Presupuesto GetPresupuestoById(int idPresupuesto);

        Pry_Recursos GetRecursoById(int idRecurso);

        Pry_CalendarioDonaciones GetCalendarioDonacionById(int idDonacion);

        void addProyectoDonante(Pry_Proyectos_Donantes proyectoDonante);

        void addPresupuesto(Pry_Presupuesto presupuesto);

        void addRecurso(Pry_Recursos recurso);

        void addCalendarioDonacion(Pry_CalendarioDonaciones calendarioDonacion);

        void modifyData();

        void deleteProyectoDonante(Pry_Proyectos_Donantes proyectoDonante);

        void deleteRecurso(Pry_Recursos recurso);

        void deleteCalendarioDonacion(Pry_CalendarioDonaciones calendarioDonacion);

        void deletePresupuesto(Pry_Presupuesto presupuesto);

    }
    #endregion

    #region mensajes
    public interface IMensajesRepository
    {

        IEnumerable<Object> GetMensajes();
        //IEnumerable<Object> GetMensajesId();

        //add tipos de cambio de un mes
        void addMensaje(Com_Mensajes newMensaje);

        void ActualizarEstado(int idMensaje, int idEstado);

        Com_Mensajes GetMessage(int idMessage);
    }


    #endregion


    // Se agrega para Listas
    #region Listas
    public interface IListasRepository
    {

        //IEnumerable<Object> Listas();
        IEnumerable<Object> Get();
        //Agregar _Listas
        void addListas(Tar_Listas newLista);
        //Agregar _Acatulizar
        void ActualizarLista(Tar_Listas list);

    }


    #endregion
    // Se agrega para Listas
    #region Tareas
    public interface ITareasRepository
    {

        //IEnumerable<Object> Listas();
        IEnumerable<Object> Get();

        void addTarea(Tar_Tareas newTarea);

        void ActualizarTarea(Tar_Tareas task);
        void EliminarTarea(int id);
        Tar_Tareas GetTareaById(int id);


    }


    #endregion

    #region variables
    public interface IVariablesRepository
    {
        IEnumerable<Pry_Variables> GetAllVariables();

        Pry_Variables GetVariable(int idVariable);

        void addVariable(Pry_Variables variable);

        void modifyData();

        void deleteVariable(Pry_Variables variable);
    }
    #endregion
    #region Partidas
    public interface IPryPartidasRepository
    {

        //IEnumerable<Object> Listas();
        IEnumerable<Object> GetPartidas();

        //Partidas
        void addPartidas(PRY_PARTIDAGASTOS newPartida);

        void ActualizarPartidas(int id, string abrevi, string codigo, string nombre);
        //void ActualizarTarea(int id, string descrip, int idResponsable, bool prioridad, DateTime inicio, DateTime Fin, int idUsurioModifica);
        //void EliminarTarea(int id, int idUsuarioMod, string estado);
        void Eliminar(int id);

    }


    #endregion

#region Nivel Aceptacion

    public interface INivelAceptacionRepository
    {
        IEnumerable<Object> getAll();
    }

#endregion
}
