﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using Microsoft.OpenApi;
using OpenApiMetadataSections = EdFi.Ods.Api.Constants.OpenApiMetadataSections;

namespace EdFi.Ods.Features.Extensions
{
    public class ExtensionsOpenApiContentProvider : IOpenApiContentProvider
    {
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly IResourceModelProvider _resourceModelProvider;
        private readonly ISchemaNameMapProvider _schemaNameMapProvider;
        private readonly IOpenApiMetadataDocumentFactory _openApiMetadataDocumentFactory;

        public ExtensionsOpenApiContentProvider(IDomainModelProvider domainModelProvider,
            IResourceModelProvider resourceModelProvider, ISchemaNameMapProvider schemaNameMapProvider,
            IOpenApiMetadataDocumentFactory documentFactory)
        {
            _domainModelProvider = Preconditions.ThrowIfNull(domainModelProvider, nameof(domainModelProvider));
            _resourceModelProvider = Preconditions.ThrowIfNull(resourceModelProvider, nameof(resourceModelProvider));
            _schemaNameMapProvider = Preconditions.ThrowIfNull(schemaNameMapProvider, nameof(schemaNameMapProvider));
            _openApiMetadataDocumentFactory = Preconditions.ThrowIfNull(documentFactory, nameof(documentFactory));
        }

        public string RouteName
        {
            get => MetadataRouteConstants.Schema;
        }

        public IEnumerable<OpenApiContent> GetOpenApiContent()
            => _domainModelProvider.GetDomainModel()
                .Schemas.Where(x => !x.LogicalName.EqualsIgnoreCase(EdFiConventions.LogicalName)).Select(
                    schema => new
                    {
                        UriSegment = _schemaNameMapProvider.GetSchemaMapByLogicalName(schema.LogicalName).UriSegment,
                        Factory = _openApiMetadataDocumentFactory
                    })
                .Select(
                    sf => new OpenApiContent(
                        OpenApiMetadataSections.Extensions,
                        sf.UriSegment,
                        new Lazy<string>(
                            () => sf.Factory.Create(
                                new SdkGenExtensionResourceStrategy(),
                                new OpenApiMetadataDocumentContext(_resourceModelProvider.GetResourceModel())
                                {
                                    RenderType = RenderType.ExtensionArtifactsOnly,
                                    IsIncludedExtension = r => r.FullName.Schema.Equals(
                                        _schemaNameMapProvider.GetSchemaMapByUriSegment(sf.UriSegment).PhysicalName)
                                }, OpenApiSpecVersion.OpenApi2_0)),
                        new Lazy<string>(
                            () => sf.Factory.Create(
                                new SdkGenExtensionResourceStrategy(),
                                new OpenApiMetadataDocumentContext(_resourceModelProvider.GetResourceModel())
                                {
                                    RenderType = RenderType.ExtensionArtifactsOnly,
                                    IsIncludedExtension = r => r.FullName.Schema.Equals(
                                        _schemaNameMapProvider.GetSchemaMapByUriSegment(sf.UriSegment).PhysicalName)
                                }, OpenApiSpecVersion.OpenApi3_0)),
                        RouteConstants.DataManagementRoutePrefix));
    }
}
