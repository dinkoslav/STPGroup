[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(STPGroup.WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(STPGroup.WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace STPGroup.WebAPI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using AutoMapper;
    using AutomapperProfiles;
    using Database;
    using Services.Infrastructure.Interfaces;
    using Data;
    using Services.Infrastructure;
    using Data.DataHandlers.Interfaces;
    using Data.DataHandlers;
    using ApiServices.Interfaces;
    using ApiServices;

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
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                NinjectWebCommon.InitializeAutomapperConfig();
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
            kernel.Bind<STPGroupDbContext>().ToSelf();
            kernel.Bind<ISTPGroupData>().To<STPGroupData>().InRequestScope();
            kernel.Bind<IMapperService>().To<MapperService>().InRequestScope();

            kernel.Bind<ICompaniesDataHandler>().To<CompaniesDataHandler>();
            kernel.Bind<IEmployeesDataHandler>().To<EmployeesDataHandler>();

            kernel.Bind<ICompaniesService>().To<CompaniesService>();
            kernel.Bind<IEmployeesService>().To<EmployeesService>();
        }

        private static void InitializeAutomapperConfig()
        {
            Mapper.Initialize(NinjectWebCommon.AddProfilesToAutomapperConfig);
        }

        private static void AddProfilesToAutomapperConfig(IMapperConfigurationExpression config)
        {
            config.AddProfile(new CompaniesProfile());
            config.AddProfile(new EmployeesProfile());
        }
    }
}
