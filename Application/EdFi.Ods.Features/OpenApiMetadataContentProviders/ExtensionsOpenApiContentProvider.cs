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
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;

namespace EdFi.Ods.Features.Extensions
{
    public class ExtensionsOpenApiContentProvider : IOpenApiContentProvider
    {
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly IResourceModelProvider _resourceModelProvider;
        private readonly ISchemaNameMapProvider _schemaNameMapProvider;

        public ExtensionsOpenApiContentProvider(IDomainModelProvider domainModelProvider,
            IResourceModelProvider resourceModelProvider, ISchemaNameMapProvider schemaNameMapProvider)
        {
            _domainModelProvider = Preconditions.ThrowIfNull(domainModelProvider, nameof(domainModelProvider));
            _resourceModelProvider = Preconditions.ThrowIfNull(resourceModelProvider, nameof(resourceModelProvider));
            _schemaNameMapProvider = Preconditions.ThrowIfNull(schemaNameMapProvider, nameof(schemaNameMapProvider));
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
                        Factory = SwaggerDocumentFactoryHelper
                            .GetExtensionOnlySwaggerDocumentFactory(_resourceModelProvider.GetResourceModel(), schema)
                    })
                .Select(
                    sf => new OpenApiContent(
                        OpenApiMetadataSections.Extensions,
                        sf.UriSegment,
                        new Lazy<string>(() => sf.Factory.Create(new SdkGenExtensionResourceStrategy())),
                        RouteConstants.DataManagementRoutePrefix));
    }
}
