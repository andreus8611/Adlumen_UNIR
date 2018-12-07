using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Bussiness.RealRepositories;
using AdlumenMVC.Models;
using AdlumenMVC.Models.AbstractRepository;
using AdlumenMVC.Models.Model;
using AdlumenMVC.WebUI.Infraestructure.CustomTablesRepositories.Abstract;
using AdlumenMVC.WebUI.Infraestructure.CustomTablesRepositories.Concrete;
using Ninject;
using Ninject.Modules;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;


namespace AdlumenMVC.WebUI.Infraestructure
{

    public class NinjectDependencyScope : IDependencyScope
{
    private IResolutionRoot resolver;
 
    internal NinjectDependencyScope(IResolutionRoot resolver)
    {
        Contract.Assert(resolver != null);
 
        this.resolver = resolver;
    }
 
    public void Dispose()
    {
        var disposable = this.resolver as IDisposable;
        if (disposable != null)
        {
            disposable.Dispose();
        }
 
        this.resolver = null;
    }
 
    public object GetService(Type serviceType)
    {
        if (this.resolver == null)
        {
            throw new ObjectDisposedException("this", "This scope has already been disposed");
        }
 
        return this.resolver.TryGet(serviceType);
    }
 
    public IEnumerable<object> GetServices(Type serviceType)
    {
        if (this.resolver == null)
        {
            throw new ObjectDisposedException("this", "This scope has already been disposed");
        }
 
        return this.resolver.GetAll(serviceType);
    }
}

    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(this.kernel.BeginBlock());
        }
    }

    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IContextRepository>().To<Adlumen2SocEntities>();
            //Bind<IContextRepository>().ToConstructor(x => new Adlumen2SocEntities(new TenantDiscovery()));
            Bind<IPeriodosProyectos>().To<PeriodosProyectosRepository>();
            Bind<IProjects>().To<ProjectRepository>();
            Bind<IMonedaRepository>().To<MonedasRepository>();
            Bind<IFacilitadores>().To<FacilitadorRepository>();
            Bind<IMensajesRepository>().To<MensajeRepository>();
            Bind<IListasRepository>().To<ListasRepository>();
            Bind<ITareasRepository>().To<TareasRepository>();
            //Bind<ICapacitaciones>().To<CapacitacionRepository>();
            //Bind<ITipCambioRepository>().To<TipCambioRepository>();
            Bind<ICuestionarioRepository>().To<CuestionarioRepository>();
            Bind<IEncuestasRepository>().To<EncuestasRepository>();
            Bind<IPreguntasRepository>().To<PreguntasRepository>();
            Bind<IIdiomasRepository>().To<IdiomasRepository>();
            Bind<IVisitasRepository>().To<VisitasRepository>();
            Bind<IBitacoraRepository>().To<BitacoraRepository>();
            Bind<IPermisosBitacoraRepository>().To<PermisosBitacoraRepository>();
            Bind<IEvaluacionHitosRepository>().To<EvaluacionHitosRepository>();
            Bind<IEvaluacionIndicadoresRepository>().To<EvaluacionIndicadoresRepository>();
            Bind<IEvaluacionProyectoPeriodoRepository>().To<EvaluacionProyectoPeriodoRepository>();
            Bind<IEvaluacionProyectoActividadRepository>().To<EvaluacionProyectoActividadRepository>();
            Bind<IIndicadoresProyectoRepository>().To<IndicadoresProyectoRepository>();
            Bind<IEmpresasRepository>().To<EmpresasRepository>();
            Bind<IPaisesRepository>().To<PaisesRepository>();
            Bind<IArchivosTiposRepository>().To<ArchivosTiposRepository>();
            Bind<IListasTareasRepository>().To<ListasTareasRepository>();
            Bind<IUsuariosRepository>().To<UsuariosRepository>();
            Bind<IFinancieroRepository>().To<FinancieroRepository>();
            Bind<IPartidasGastosRepository>().To<PartidasGastosRepository>();
            Bind<IConversorMonedasRepository>().To<ConversorMonedasRepository>();
            Bind<IClienteRepository>().To<ClienteRepository>();
            Bind<IObjetivosClasesRepository>().To<ObjetivosClasesRepository>();
            Bind<IIndicadoresTiposRepository>().To<IndicadoresTiposRepository>();
            Bind<IDonantesRepository>().To<DonantesRepository>();
            Bind<IPresupuestoProyecto>().To<PresupuestoProyectoRepository>();
            Bind<IVariablesRepository>().To<VariablesRepository>();
            Bind<ICapacitaciones>().To<CapacitacionRepository>();
            Bind<IObjetivos>().To<ObjetivosRepository>();
            Bind<IBeneficiarios>().To<BeneficiariosRepository>();
            Bind<IProductividadBeneficiario>().To<ProductividadBeneficiarioRepository>();
            Bind<ICapacitacionBeneficiario>().To<CapacitacionBeneficiariosRepository>();
            Bind<ITipCambioRepository>().To<TipCambioRepository>();
            Bind<IPryPartidasRepository>().To<PryPartidasRepository>();
            Bind<INivelAceptacionRepository>().To<NivelAceptacionRepository>();
            Bind<IModules>().To<ModuloRepository>();
            Bind<IAcciones>().To<AccionesRepository>();
            Bind<IAccionesRoles>().To<AccionesRoleRepository>();
            Bind<ITenantsRepository>().To<TenantsRepository>();
        }
    }
}