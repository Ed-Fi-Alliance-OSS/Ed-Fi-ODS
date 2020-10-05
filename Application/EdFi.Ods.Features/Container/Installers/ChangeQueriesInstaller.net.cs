#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Common.InversionOfControl;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Infrastructure.Pipelines;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Features.ChangeQueries;
using EdFi.Ods.Features.ChangeQueries.Providers;
using Component = Castle.MicroKernel.Registration.Component;
using EdFi.Ods.Features.Providers;

namespace EdFi.Ods.Features.Container.Installers
{
    /// <summary>
    /// Registers components with the Castle Windsor container needed for the Change Queries API feature.
    /// </summary>
    public class ChangeQueriesInstaller : RegistrationMethodsInstallerBase
    {
        private void RegisterRoutes(IWindsorContainer container)
        {
            container.Register(Component.For<IRouteConfiguration>().ImplementedBy<ChangeQueriesRouteConfiguration>());
        }

        private void RegisterNHibernateConfigurationActivities(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<INHibernateBeforeBindMappingActivity>()
                   .ImplementedBy<ChangeQueryMappingNHibernateConfigurationActivity>());
        }

        private void RegisterIAvailableChangeEventsProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IAvailableChangeVersionProvider>()
                   .ImplementedBy<AvailableChangeVersionProvider>());
        }

        private void RegisterDeletedChanges(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IGetDeletedResourceIds>()
                   .ImplementedBy<GetDeletedResourceIds>());
        }

        private void RegisterOpenApiMetadata(IWindsorContainer container)
        {
            container.Register(Component.For<IOpenApiContentProvider>().ImplementedBy<ChangeQueriesOpenApiContentProvider>());
        }

        private void RegisterControllers(IWindsorContainer container)
        {
            container.Register(
                Classes.FromThisAssembly()
                       .BasedOn<ApiController>()
                       .LifestyleScoped());
        }
    }
}
#endif