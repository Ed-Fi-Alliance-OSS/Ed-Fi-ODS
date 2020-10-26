// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.Composites;
using EdFi.Ods.Features.Composites.Infrastructure;
using EdFi.Ods.Features.Conventions;
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
                .As<ICompositesMetadataProvider>()
                .SingleInstance();

            builder.RegisterGeneric(typeof(CompositeDefinitionProcessor<,>))
                .As(typeof(ICompositeDefinitionProcessor<,>))
                .SingleInstance();

            builder.RegisterType<ResourceJoinPathExpressionProcessor>()
                .As<IResourceJoinPathExpressionProcessor>()
                .SingleInstance();

            builder.RegisterType<FieldsExpressionParser>()
                .As<IFieldsExpressionParser>()
                .SingleInstance();

            builder.RegisterType<CompositesOpenApiContentProvider>()
                .As<IOpenApiContentProvider>()
                .SingleInstance();

            builder.RegisterType<HqlBuilder>()
                .As<ICompositeItemBuilder<HqlBuilderContext, CompositeQuery>>()
                .SingleInstance();

            builder
                .RegisterDecorator<HqlBuilderAuthorizationDecorator, ICompositeItemBuilder<HqlBuilderContext, CompositeQuery>>();

            builder.RegisterType<CompositeResourceResponseProvider>()
                .As<ICompositeResourceResponseProvider>()
                .SingleInstance();

            builder.RegisterType<CompositesRouteConvention>()
                .As<IApplicationModelConvention>()
                .SingleInstance();
        }
    }
}
