// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;

namespace EdFi.Ods.Features.Composites
{
    public class CompositesOpenApiContentProvider : IOpenApiContentProvider
    {
        private readonly ICompositesMetadataProvider _compositesMetadataProvider;
        private readonly IResourceModelProvider _resourceModelProvider;
        private readonly IOpenApiMetadataDocumentFactory _openApiMetadataDocumentFactory;

        public CompositesOpenApiContentProvider(ICompositesMetadataProvider compositesMetadataProvider,
            IResourceModelProvider resourceModelProvider, IOpenApiMetadataDocumentFactory openApiMetadataDocumentFactory)
        {
            _compositesMetadataProvider = Preconditions.ThrowIfNull(
                compositesMetadataProvider, nameof(compositesMetadataProvider));

            _resourceModelProvider = Preconditions.ThrowIfNull(resourceModelProvider, nameof(resourceModelProvider));

            _openApiMetadataDocumentFactory = Preconditions.ThrowIfNull(
                openApiMetadataDocumentFactory, nameof(openApiMetadataDocumentFactory));
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
                    x => new OpenApiMetadataCompositeContext
                    {
                        OrganizationCode = x.OrganizationCode,
                        CategoryName = x.Name
                    })
                .Select(x => new OpenApiMetadataDocumentContext(_resourceModelProvider.GetResourceModel()) {CompositeContext = x})
                .Select(
                    c =>
                        new OpenApiContent(
                            OpenApiMetadataSections.Composites,
                            c.CompositeContext.CategoryName,
                            new Lazy<string>(() => _openApiMetadataDocumentFactory.Create(openApiStrategy, c)),
                            $"{OpenApiMetadataSections.Composites.ToLowerInvariant()}/v{ApiVersionConstants.Composite}",
                            $"{c.CompositeContext.OrganizationCode}/{c.CompositeContext.CategoryName}"));
        }
    }
}
