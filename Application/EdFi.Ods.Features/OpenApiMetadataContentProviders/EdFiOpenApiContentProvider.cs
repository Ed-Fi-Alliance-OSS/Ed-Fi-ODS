// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using OpenApiMetadataSections = EdFi.Ods.Features.OpenApiMetadata.Models.OpenApiMetadataSections;

namespace EdFi.Ods.Features.OpenApiMetadata
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
                            new OpenApiMetadataDocumentFactory()
                                .Create(
                                    new SdkGenAllEdFiResourceStrategy(),
                                    new OpenApiMetadataDocumentContext(_resourceModelProvider.GetResourceModel())
                                    {
                                        RenderType = RenderType.GeneralizedExtensions,
                                        IsIncludedExtension = x
                                            => x.FullName.Schema.Equals(EdFiConventions.PhysicalSchemaName)
                                    })),
                    RouteConstants.DataManagementRoutePrefix)
            };
    }
}
