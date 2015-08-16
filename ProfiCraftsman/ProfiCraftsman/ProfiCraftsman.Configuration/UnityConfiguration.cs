using System.Configuration;
using ProfiCraftsman.Contracts;
using ProfiCraftsman.Contracts.Services;
using ProfiCraftsman.Lib.Data;
using ProfiCraftsman.Lib.Services;
using Microsoft.Practices.Unity;
using ProfiCraftsman.Contracts.SaveActors;
using ProfiCraftsman.Lib.Data.SaveActors;
using ProfiCraftsman.Lib.DuplicateCheckers;

namespace ProfiCraftsman.Configuration
{
    public static partial class UnityConfiguration
    {
        public static void ConfigureContainer(IUnityContainer container)
        {           
            container.RegisterType<IProfiCraftsmanEntities, ProfiCraftsmanEntities>(new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<IProfiCraftsmanSaveActorManager>(), ConfigurationManager.ConnectionStrings["ProfiCraftsmanEntities"].ConnectionString));

             container.RegisterType<IProfiCraftsmanSaveActorManager, ProfiCraftsmanSaveActorManager>(new PerRequestLifetimeManager());

            RegisterDuplicateCheckers(container);
            RegisterManagers(container);
        }

        private static void RegisterDuplicateCheckers(IUnityContainer container)
        {
            container.RegisterType<IProfiCraftsmanSaveActor, ProfiCraftsmanDuplicateCheckerSaveActor>("masterDataDuplicateCheckerSaveActor", new PerRequestLifetimeManager());

            InitializeProfiCraftsmanDuplicateCheckers(container);
        }

        private static void RegisterManagers(IUnityContainer container)
        {
            InitializeProfiCraftsman(container);
            container.RegisterType<IUniqueNumberProvider, UniqueNumberProvider>(new ContainerControlledLifetimeManager());
        }
    }
}