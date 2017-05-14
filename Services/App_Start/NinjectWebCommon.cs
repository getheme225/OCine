[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Services.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Services.App_Start.NinjectWebCommon), "Stop")]

namespace Services.App_Start
{
    using System;
    using System.Web;
    using Ocine.DAL.Repository;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using CommonComponent.Ninject;
    using OCine.Common.CommonRepository.Interface;
    using OCine.Common.CommonRepository.AutoMapper;
    using System.Web.Http;
    using Services;
    using Interfaces;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<OcineDbEntities>().InRequestScope().Named(ContextualBinding.OcineDb);
            kernel.Bind<IAutoMapperConfig>().To<AutoMapperConfig>();
            kernel.Bind<IFilmServices>().To<FilmsService>();
            kernel.Bind<ISeanceServices>().To<SeanceServices>();
            kernel.Bind<ICinemaServices>().To<CinemaServices>();
        }        
    }
}
