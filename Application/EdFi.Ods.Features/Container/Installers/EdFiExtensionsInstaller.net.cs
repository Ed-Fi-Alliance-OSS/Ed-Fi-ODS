#if NETFRAMEWORK
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Api.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;

namespace EdFi.Ods.Features.Container.Installers
{
    public class EdFiExtensionsInstaller : IWindsorInstaller
    {
        private const string ExcludedExtensionSourcesKey = "ExcludedExtensionSources";
        private readonly IAssembliesProvider _assembliesProvider;
        private readonly IConfigValueProvider _configValueProvider;

        public EdFiExtensionsInstaller(IAssembliesProvider assembliesProvider, IConfigValueProvider configValueProvider)
        {
            _assembliesProvider = assembliesProvider;
            _configValueProvider = configValueProvider;
        }

        public virtual void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var extensionAssemblies = InstalledExtensions();

            // Ensure all the domain model definitions are registered before handling any other extension concerns
            extensionAssemblies.ForEach(a => RegisterIDomainModelDefinitionsProvider(a, container));

            container.Register(
                Component.For<IEntityExtensionsFactory>().ImplementedBy<EntityExtensionsFactory>().LifestyleSingleton());

            container.Register(
                Component.For<IEntityExtensionRegistrar>().ImplementedBy<EntityExtensionRegistrar>()
                    .DependsOn(Dependency.OnValue<IEnumerable<Assembly>>(extensionAssemblies))
                    .LifestyleSingleton());

            extensionAssemblies.ForEach(
                a =>
                {
                    RegisterExtensionNHibernateConfigurationProvider(a, container);
                    RegisterControllers(a, container);
                }
            );

            List<Assembly> InstalledExtensions()
            {
                var excludedExtensionSourcesValue = _configValueProvider.GetValue(ExcludedExtensionSourcesKey);

                // Register extension assemblies based on naming convention
                var assemblies = _assembliesProvider.GetAssemblies().Where(a => ExtensionsConventions.IsExtensionAssembly((Assembly) a)).ToList();

                // Exclude any extension assemblies specified by configuration
                if (!string.IsNullOrWhiteSpace(excludedExtensionSourcesValue))
                {
                    return assemblies
                        .Where(
                            a => a.IsExtensionAssembly() && !excludedExtensionSourcesValue.Split(',').Contains(
                                     ExtensionsConventions.GetProperCaseNameFromAssemblyName(a.GetName().Name)))
                        .ToList();
                }

                return assemblies;
            }
        }

        protected virtual void RegisterExtensionNHibernateConfigurationProvider(Assembly assembly, IWindsorContainer container)
        {
            var assemblyName = assembly.GetName()
                .Name;

            // to avoid collisions between assemblies we need to mark them as named in the container
            container.Register(
                Component.For<IExtensionNHibernateConfigurationProvider>()
                    .ImplementedBy<ExtensionNHibernateConfigurationProvider>()
                    .DependsOn(Dependency.OnValue("assemblyName", assemblyName))
                    .Named(typeof(ExtensionNHibernateConfigurationProvider).FullName + "_" + assemblyName));
        }

        protected virtual void RegisterControllers(Assembly assembly, IWindsorContainer container)
        {
            // Controllers
            // These are api controllers so they need to be scoped to fit the Windsor integration for resolving dependencies
            container.Register(
                Classes.FromAssembly(assembly)
                    .BasedOn<ApiController>()
                    .LifestyleScoped());
        }

        private void RegisterIDomainModelDefinitionsProvider(Assembly assembly, IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IDomainModelDefinitionsProvider>()
                    .ImplementedBy<DomainModelDefinitionsJsonEmbeddedResourceProvider>()
                    .Named($"{assembly.FullName}.{typeof(DomainModelDefinitionsJsonEmbeddedResourceProvider).Name}")
                    .DependsOn(Dependency.OnValue("sourceAssembly", assembly)));
        }
    }
}
#endif
