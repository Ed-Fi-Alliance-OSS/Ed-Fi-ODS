// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Web.Http.Dependencies;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.HttpConfigurators;
using EdFi.Ods.Api.HttpRouteConfigurations;
using EdFi.Ods.Api.InversionOfControl;
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api._Installers
{
    public class HttpConfigurationInstaller : IWindsorInstaller
    {
        private readonly IApiConfigurationProvider _apiConfigurationProvider;

        public HttpConfigurationInstaller(IApiConfigurationProvider apiConfigurationProvider)
        {
            _apiConfigurationProvider = Preconditions.ThrowIfNull(apiConfigurationProvider, nameof(apiConfigurationProvider));
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Web API Dependency Injection
            container.Register(Component.For<IDependencyResolver>().Instance(new WindsorDependencyResolver(container)));

            RegisterApiSpecificConfigurators(container);
            RegisterRouteConfigurator(container);
            RegisterDefaultApiRoutes(container);
        }

        private void RegisterApiSpecificConfigurators(IWindsorContainer container)
        {
            container.Register(
                Component.For<IHttpConfigurator>().ImplementedBy<HttpCorsConfigurator>(),
                Component.For<IHttpConfigurator>().ImplementedBy<HttpDelegatingHandlerConfigurator>(),
                Component.For<IHttpConfigurator>().ImplementedBy<HttpFilterConfigurator>(),
                Component.For<IHttpConfigurator>().ImplementedBy<HttpFormatterConfigurator>());
        }

        private void RegisterRouteConfigurator(IWindsorContainer container)
        {
            container.Register(
                Component.For<IHttpConfigurator>().ImplementedBy<HttpRouteConfigurator>()
                    .DependsOn(Dependency.OnValue<bool>(_apiConfigurationProvider.IsYearSpecific())));
        }

        private void RegisterDefaultApiRoutes(IWindsorContainer container)
        {
            container.Register(
                Component.For<IRouteConfiguration, IOpenApiMetadataRouteConfiguration>()
                    .ImplementedBy<ApiDefaultRouteConfiguration>(),
                Component.For<IRouteConfiguration, IOpenApiMetadataRouteConfiguration>()
                    .ImplementedBy<HttpOAuthRouteConfiguration>(),
                Component.For<IRouteConfiguration, IOpenApiMetadataRouteConfiguration>()
                    .ImplementedBy<MetadataSectionsRouteConfiguration>(),
                Component.For<IHttpConfiguratorFactory>().ImplementedBy<HttpConfiguratorFactory>());
        }
    }
}
