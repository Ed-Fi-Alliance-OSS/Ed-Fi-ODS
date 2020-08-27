// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api._Installers;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Dependencies;
using EdFi.Ods.Api.Startup.Features;
using EdFi.Ods.Api.Startup.Features.Installers;
using EdFi.Ods.Api.Startup.HttpConfigurators;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.ChainOfResponsibility;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common._Installers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensibility;
using EdFi.Ods.Common.Security;
using log4net;
using EdFi.Ods.Security.Authorization;

namespace EdFi.Ods.Api.Startup.ContainerBuilders
{
    public class WindsorContainerBuilder : IWindsorContainerBuilder
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(WindsorContainerBuilder));

        public IWindsorContainer Build()
        {
            var container = new WindsorContainerEx();

            container.AddSupportForEmptyCollections();

            InstallFacilities(container);

            InstallFeaturePrerequisites(container);
            
            var assembliesProvider = container.Resolve<IAssembliesProvider>();
            var configValueProvider = container.Resolve<IConfigValueProvider>();
            
            InstallPlugins();
            
            InstallCoreFeatures(container);

            InstallFeatures(container);

            ApplyHttpSpecific(container);

            FinalizeContainer(container);

            return container;

            void InstallPlugins()
            {
                var pluginFolder = configValueProvider.GetValue("plugin:folder");

                _logger.Debug($"Loading plugins from folder {pluginFolder}.");
                assembliesProvider.LoadPluginAssemblies(pluginFolder);
            }
        }

        private void InstallFeaturePrerequisites(IWindsorContainer container)
        {
            // Install the common items
            container.Install(new CommonInstaller(), new ApiModeProviderInstaller());

            var assembliesProvider = container.Resolve<IAssembliesProvider>();
            var apiConfigurationProvider = container.Resolve<IApiConfigurationProvider>();
            var configValueProvider = container.Resolve<IConfigValueProvider>();

            container.Install(
                new ConnectionStringProvidersInstaller(apiConfigurationProvider),
                new HttpConfigurationInstaller(apiConfigurationProvider),
                new SecurityInstaller(assembliesProvider, configValueProvider),
                new NHibernateInstaller(),
                new CoreApiInstaller(assembliesProvider, apiConfigurationProvider, configValueProvider),
                new NHibernateConfiguratorInstaller(apiConfigurationProvider)
            );

            container.Register(
                Component
                    .For<IProfileResourceModelProvider>()
                    .ImplementedBy<ProfilePassthroughResourceModelProvider>().IsFallback());

            container.Register(
                Component.For<IResourceLoadGraphTransformer>()
                    .ImplementedBy<PersonResourceLoadGraphTransformer>());
        }

        private void InstallCoreFeatures(IWindsorContainer container)
        {
            var assembliesProvider = container.Resolve<IAssembliesProvider>();

            foreach (var assembly in assembliesProvider.GetAssembliesContaining<IFeature>())
            {
                _logger.Debug($"Registering features from assembly {assembly.FullName}.");
                container.Register(
                    Classes.FromAssembly(assembly)
                        .BasedOn<IFeature>()
                        .WithService
                        .AllInterfaces());
            }

            // Install the feature provider into the container.
            container.Register(Component.For<IFeatureProvider>().ImplementedBy<FeatureProvider>());
        }

        private void InstallFeatures(IWindsorContainer container)
        {
            // apply the features that are enabled.
            var enabledFeatures = container.Resolve<IFeatureProvider>().EnabledFeatures();

            var featureNames = string.Join(", ", enabledFeatures.Select(f => f.FeatureName)); 
            
            _logger.Debug($"The following features are being installed: {featureNames}");

            container.Install(enabledFeatures.Select(f => f.Installer).ToArray());
        }

        private static void ApplyHttpSpecific(IWindsorContainer container)
        {
            _logger.Debug("Applying HTTP specific registrations to the container.");

            container.Register(

                // Create http configuration
                Component.For<HttpConfiguration>()
                    .UsingFactoryMethod(kernel => kernel.Resolve<IHttpConfiguratorFactory>().Configure()),

                // Register http routes for caching of open api metadata
                Component.For<HttpRouteCollection>()
                    .UsingFactoryMethod(kernel => kernel.Resolve<HttpConfiguration>().Routes));
        }

        private void FinalizeContainer(IWindsorContainer container)
        {
            _logger.Debug("Finalizing container");

            container.Kernel.GetFacilities()
                .OfType<ChainOfResponsibilityFacility>()
                .SingleOrDefault()
                ?.FinalizeChains();

            // Make this dependency available to generated artifacts
            GeneratedArtifactStaticDependencies.Resolvers.Set(() => container.Resolve<IResourceModelProvider>());
            GeneratedArtifactStaticDependencies.Resolvers.Set(() => container.Resolve<IAuthorizationContextProvider>());

            ClaimsPrincipal.ClaimsPrincipalSelector =
                () => EdFiClaimsPrincipalSelector.GetClaimsPrincipal(container.Resolve<IClaimsIdentityProvider>());

            // Provide cache using a closure rather than repeated invocations to the container
            IPersonUniqueIdToUsiCache personUniqueIdToUsiCache = null;
            PersonUniqueIdToUsiCache.GetCache = () => personUniqueIdToUsiCache ?? (personUniqueIdToUsiCache = container.Resolve<IPersonUniqueIdToUsiCache>());

            // Provide cache using a closure rather than repeated invocations to the container
            IDescriptorsCache cache = null;
            DescriptorsCache.GetCache = () => cache ?? (cache = container.Resolve<IDescriptorsCache>());

            ResourceModelHelper.ResourceModel =
                new Lazy<ResourceModel>(() => container.Resolve<IResourceModelProvider>().GetResourceModel());
        }

        private void InstallFacilities(IWindsorContainer container)
        {
            _logger.Debug("Installing facilities");
            container.AddFacility<TypedFactoryFacility>();
            container.AddFacility<DatabaseConnectionStringProviderFacility>();
            container.AddFacility<ChainOfResponsibilityFacility>();
        }
    }
}
