// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Services.Metadata.Providers;
using EdFi.Ods.Api.Startup.ExternalTasks;
using EdFi.Ods.Api.Startup.HttpConfigurators;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Startup.Features.Installers
{
    public class OpenApiMetadataInstaller : IWindsorInstaller
    {
        private readonly IApiConfigurationProvider _apiConfigurationProvider;

        public OpenApiMetadataInstaller(IApiConfigurationProvider apiConfigurationProvider)
        {
            _apiConfigurationProvider = Preconditions.ThrowIfNull(apiConfigurationProvider, nameof(apiConfigurationProvider));
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IOpenApiMetadataRouteProvider>().ImplementedBy<OpenApiMetadataRouteProvider>(),
                Component.For<IOpenApiMetadataCacheProvider>().ImplementedBy<OpenApiMetadataCacheProvider>(),
                Component.For<IHttpConfigurator>().ImplementedBy<HttpOpenApiMetadataRouteConfigurator>().DependsOn(Dependency.OnValue<bool>(_apiConfigurationProvider.IsYearSpecific())),
                Component.For<IExternalTask>().ImplementedBy<InitializeOpenApiMetadataCache>(),
                Component.For<IOpenApiContentProvider>().ImplementedBy<EdFiOpenApiContentProvider>());

            RegisterControllers(container);
        }

        private void RegisterControllers(IWindsorContainer container)
        {
            // TODO -JSM resolve once we move open api to another assembly with ODS-3225
            // container.Register(Component.For<OpenApiMetadataController>().LifestyleScoped());
        }
    }
}
