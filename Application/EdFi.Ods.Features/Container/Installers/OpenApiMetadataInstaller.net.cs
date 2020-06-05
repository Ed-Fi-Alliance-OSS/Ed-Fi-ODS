#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Api;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Common.ExternalTasks;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Features.AggregateDepenedencies;
using EdFi.Ods.Features.OpenApiMetadata;
using EdFi.Ods.Features.OpenApiMetadata.Controllers;
using EdFi.Ods.Features.OpenApiMetadata.Providers;

namespace EdFi.Ods.Features.Container.Installers
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
            container.Register(Component.For<OpenApiMetadataController>().LifestyleScoped());
            container.Register(Component.For<AggregateDependencyController>().LifestyleScoped());
        }
    }
}
#endif