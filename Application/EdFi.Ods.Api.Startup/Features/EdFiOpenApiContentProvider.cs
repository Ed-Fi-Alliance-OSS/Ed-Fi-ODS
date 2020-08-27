// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Api.Services.Metadata.Factories;
using EdFi.Ods.Api.Services.Metadata.Models;
using EdFi.Ods.Api.Services.Metadata.Providers;
using EdFi.Ods.Api.Services.Metadata.Strategies.ResourceStrategies;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;

namespace EdFi.Ods.Api.Startup.Features
{
    public class EdFiOpenApiContentProvider : IOpenApiContentProvider
    {
        private readonly IResourceModelProvider _resourceModelProvider;

        public EdFiOpenApiContentProvider(IResourceModelProvider resourceModelProvider)
        {
            _resourceModelProvider = Preconditions.ThrowIfNull(resourceModelProvider, nameof(resourceModelProvider));
        }

        public string RouteName
        {
            get => MetadataRouteConstants.Schema;
        }

        public IEnumerable<OpenApiContent> GetOpenApiContent()
            => new[]
            {
                new OpenApiContent(
                    OpenApiMetadataSections.SdkGen,
                    EdFiConventions.UriSegment,
                    new Lazy<string>(
                        () =>
                            new SwaggerDocumentFactory(
                                    new SwaggerDocumentContext(_resourceModelProvider.GetResourceModel())
                                    {
                                        RenderType = RenderType.GeneralizedExtensions,
                                        IsIncludedExtension = x
                                            => x.FullName.Schema.Equals(EdFiConventions.PhysicalSchemaName)
                                    })
                                .Create(new SdkGenAllEdFiResourceStrategy())),
                    RouteConstants.OdsDataBasePath)
            };
    }
}
