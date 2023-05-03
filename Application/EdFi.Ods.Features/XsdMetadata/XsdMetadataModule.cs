// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.Features.XsdMetadata
{
    public class XsdMetadataModule : ConditionalModule
    {
        public XsdMetadataModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(XsdMetadataModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.XsdMetadata);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<XsdFileInformationProvider>()
                .As<IXsdFileInformationProvider>()
                .SingleInstance();

            builder.RegisterType<XsdMetadataFileMiddleware>()
                .As<IMiddleware>()
                .AsSelf()
                .SingleInstance();
        }
    }
}
