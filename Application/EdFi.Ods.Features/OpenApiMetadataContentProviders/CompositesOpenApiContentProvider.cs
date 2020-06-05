// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;

namespace EdFi.Ods.Features.Composites
{
    public class CompositesOpenApiContentProvider : IOpenApiContentProvider
    {
        private readonly ICompositesMetadataProvider _compositesMetadataProvider;
        private readonly IResourceModelProvider _resourceModelProvider;

        public CompositesOpenApiContentProvider(ICompositesMetadataProvider compositesMetadataProvider,
            IResourceModelProvider resourceModelProvider)
        {
            _compositesMetadataProvider = Preconditions.ThrowIfNull(
                compositesMetadataProvider, nameof(compositesMetadataProvider));

            _resourceModelProvider = Preconditions.ThrowIfNull(resourceModelProvider, nameof(resourceModelProvider));
        }

        public string RouteName
        {
            get => MetadataRouteConstants.Composites;
        }

        public IEnumerable<OpenApiContent> GetOpenApiContent()
        {
            var openApiStrategy = new OpenApiCompositeStrategy(_compositesMetadataProvider);

            return _compositesMetadataProvider
                .GetAllCategories()
                .Select(
                    x => new SwaggerCompositeContext
                    {
                        OrganizationCode = x.OrganizationCode,
                        CategoryName = x.Name
                    })
                .Select(x => new SwaggerDocumentContext(_resourceModelProvider.GetResourceModel()) {CompositeContext = x})
                .Select(
                    c =>
                        new OpenApiContent(
                            OpenApiMetadataSections.Composites,
                            c.CompositeContext.CategoryName,
                            new Lazy<string>(() => new SwaggerDocumentFactory(c).Create(openApiStrategy)),
                            $"{OpenApiMetadataSections.Composites.ToLowerInvariant()}/v{ApiVersionConstants.Composite}",
                            $"{c.CompositeContext.OrganizationCode}/{c.CompositeContext.CategoryName}"));
        }
    }
}
