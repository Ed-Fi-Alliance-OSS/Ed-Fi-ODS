#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.Composites;
using EdFi.Ods.Features.Composites.Infrastructure;

namespace EdFi.Ods.Features.Container.Installers
{
    /// <summary>
    /// Registers components with the Castle Windsor container needed for the Composites feature.
    /// </summary>
    public class CompositesInstaller : RegistrationMethodsInstallerBase
    {
        private void RegisterCompositesMetadataProvider(IWindsorContainer container)
        {
            container.Register(Component.For<ICompositesMetadataProvider>().ImplementedBy<CompositesMetadataProvider>());
        }

        private void RegisterCompositeDefinitionsProcessor(IWindsorContainer container)
        {
            container.Register(
                Component.For(typeof(ICompositeDefinitionProcessor<,>)).ImplementedBy(typeof(CompositeDefinitionProcessor<,>)));
        }

        private void RegisterJoinPathExpressionProcessor(IWindsorContainer container)
        {
            container.Register(
                Component.For<IResourceJoinPathExpressionProcessor>().ImplementedBy<ResourceJoinPathExpressionProcessor>());
        }

        private void RegisterFieldsExpressionParser(IWindsorContainer container)
        {
            container.Register(Component.For<IFieldsExpressionParser>().ImplementedBy<FieldsExpressionParser>());
        }

        private void RegisterControllers(IWindsorContainer container)
        {
            container.Register(Component.For<CompositeResourceController>().LifestyleScoped());
        }

        private void RegisterRoutes(IWindsorContainer container)
        {
            container.Register(
                Component.For<IRouteConfiguration, IOpenApiMetadataRouteConfiguration>()
                    .ImplementedBy<CompositesRouteConfiguration>(),
                Component.For<IOpenApiContentProvider>().ImplementedBy<CompositesOpenApiContentProvider>());
        }

        private void RegisterHqlBuilderContext(IWindsorContainer container)
        {
            container.Register(

                // decorators must be installed first, we are implying that security is needed for the api
                Component.For<ICompositeItemBuilder<HqlBuilderContext, CompositeQuery>>()
                    .ImplementedBy<HqlBuilderAuthorizationDecorator>().IsDecorator(),
                Component.For<ICompositeItemBuilder<HqlBuilderContext, CompositeQuery>>().ImplementedBy<HqlBuilder>());
        }

        private void RegisterCompositeResourceResponseProvider(IWindsorContainer container)
        {
            container.Register(Component.For<ICompositeResourceResponseProvider>().ImplementedBy<CompositeResourceResponseProvider>());
        }
    }
}
#endif