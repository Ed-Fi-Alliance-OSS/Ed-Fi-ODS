// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Container;
using EdFi.Ods.Api.Common.Infrastructure.Composites;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Common.Composites;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.Composites;
using EdFi.Ods.Features.Conventions;
using EdFi.Ods.Security.Authorization.Repositories;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.Features.Container.Modules
{
    public class CompositesModule : ConditionalModule
    {
        public CompositesModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(CompositesModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.Composites);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<CompositesMetadataProvider>()
                .As<ICompositesMetadataProvider>();

            builder.RegisterGeneric(typeof(CompositeDefinitionProcessor<,>))
                .As(typeof(ICompositeDefinitionProcessor<,>));

            builder.RegisterType<ResourceJoinPathExpressionProcessor>()
                .As<IResourceJoinPathExpressionProcessor>();

            builder.RegisterType<FieldsExpressionParser>()
                .As<IFieldsExpressionParser>();

            builder.RegisterType<CompositesOpenApiContentProvider>()
                .As<IOpenApiContentProvider>();

            builder.RegisterType<HqlBuilder>()
                .As<ICompositeItemBuilder<HqlBuilderContext, CompositeQuery>>();

            builder
                .RegisterDecorator<HqlBuilderAuthorizationDecorator, ICompositeItemBuilder<HqlBuilderContext, CompositeQuery>>();

            builder.RegisterType<CompositeResourceResponseProvider>()
                .As<ICompositeResourceResponseProvider>();

            builder.RegisterType<CompositesRouteConvention>()
                .As<IApplicationModelConvention>();
        }
    }
}
#endif