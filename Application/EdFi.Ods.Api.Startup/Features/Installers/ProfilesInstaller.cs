// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Reflection;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Api.Services.Metadata.Providers;
using EdFi.Ods.Api.Startup.ExternalTasks;
using EdFi.Ods.Api.Startup.HttpConfigurators;
using EdFi.Ods.Api.Startup.HttpRouteConfigurations;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Security.Profiles;

namespace EdFi.Ods.Api.Startup.Features.Installers
{
    /// <summary>
    /// Registers components with the Castle Windsor container needed for the Profiles feature.
    /// </summary>
    public class ProfilesInstaller : IWindsorInstaller
    {
        private readonly IAssembliesProvider _assembliesProvider;

        public ProfilesInstaller(IAssembliesProvider assembliesProvider)
        {
            _assembliesProvider = Preconditions.ThrowIfNull(assembliesProvider, nameof(assembliesProvider));
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterRoutes(container);
            RegisterHttpConfigurations(container);
            RegisterIAdminProfileNamesPublisher(container);
            RegisterIProfileResourceModelProvider(container);
            RegisterOpenApiContentProvider(container);
            RegisterProfileAssemblyControllers(container);
        }

        private void RegisterRoutes(IWindsorContainer container)
        {
            container.Register(
                Component.For<IRouteConfiguration, IOpenApiMetadataRouteConfiguration>()
                    .ImplementedBy<ProfilesRouteConfiguration>());
        }

        private void RegisterHttpConfigurations(IWindsorContainer container)
        {
            container.Register(Component.For<IHttpConfigurator>().ImplementedBy<ProfilesHttpConfigurator>());
        }

        private void RegisterIAdminProfileNamesPublisher(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IAdminProfileNamesPublisher>()
                    .ImplementedBy<AdminProfileNamesPublisher>(),
                Component.For<IExternalTask>().ImplementedBy<ProfileNamePublisher>()
                );
        }

        private void RegisterIProfileResourceModelProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IProfileResourceModelProvider>()
                    .ImplementedBy<ProfileResourceModelProvider>());
        }

        private void RegisterOpenApiContentProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IOpenApiContentProvider>()
                    .ImplementedBy<ProfilesOpenApiContentProvider>());
        }

        private void RegisterProfileAssemblyControllers(IWindsorContainer container)
        {
            var profileAssemblies = _assembliesProvider.GetAssemblies()
                .Where(EdFiConventions.IsProfileAssembly)
                .ToList();

            foreach (Assembly profileAssembly in profileAssemblies)
            {
                container.Register(
                    Classes
                        .FromAssembly(profileAssembly)
                        .BasedOn<ApiController>()
                        .LifestyleScoped());
            }
        }
    }
}
