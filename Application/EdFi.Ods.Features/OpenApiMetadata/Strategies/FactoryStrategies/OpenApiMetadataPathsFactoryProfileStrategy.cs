﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Inflection;
using EdFi.Ods.Common.Utils.Profiles;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies
{
    public class OpenApiMetadataPathsFactoryProfileStrategy
        : IOpenApiMetadataPathsFactorySelectorStrategy, IOpenApiMetadataPathsFactoryContentTypeStrategy, IOpenApiMetadataPathsFactoryNamingStrategy
    {
        private readonly OpenApiMetadataDocumentContext _documentContext;

        public OpenApiMetadataPathsFactoryProfileStrategy(OpenApiMetadataDocumentContext documentContext)
        {
            _documentContext = documentContext;
        }

        public string GetOperationContentType(OpenApiMetadataResource openApiMetadataResource, ContentTypeUsage contentTypeUsage)
            => ProfilesContentTypeHelper.CreateContentType(
                openApiMetadataResource.Resource.Name,
                _documentContext.ProfileContext.ProfileName,
                contentTypeUsage);

        public string GetResourceName(OpenApiMetadataResource openApiMetadataResource, ContentTypeUsage contentTypeUsage)
        {
            var schemaPrefix =
                openApiMetadataResource.Resource.Entity.DomainModel.SchemaNameMapProvider
                               .GetSchemaMapByPhysicalName(openApiMetadataResource.Resource.Entity.Schema)
                               .ProperCaseName;

            var name = openApiMetadataResource.ContextualResource == null
                ? string.Format(
                    "{0}_{1}_{2}",
                    schemaPrefix,
                    CompositeTermInflector.MakeSingular(openApiMetadataResource.Resource.Name),
                    contentTypeUsage)
                : string.Format(
                    "{0}_{1}_{2}_{3}",
                    schemaPrefix,
                    CompositeTermInflector.MakeSingular(openApiMetadataResource.Resource.Name),
                    openApiMetadataResource.ContextualResource.Name,
                    contentTypeUsage);

            return OpenApiMetadataDocumentHelper.CamelCaseSegments(name);
        }

        public IEnumerable<OpenApiMetadataPathsResource> ApplyStrategy(IEnumerable<OpenApiMetadataResource> openApiMetadataResources)
        {
            // When rendering definitions, profile resources exist as separate OpenApiMetadataResource objects
            // per content type (Readable / Writable).
            // When rendering paths, all profile resource content types are rendered
            // in the same 'Paths' section and need to be merged into a unified OpenApiMetadataPathsResource.
            return openApiMetadataResources.GroupBy(
                                        r => new
                                        {
                                            r.NameWithoutContext,
                                            r.Resource.Entity.Schema,
                                            Context = r.ContextualResource
                                        })
                                   .Select(
                                        r => new OpenApiMetadataPathsResource(
                                                 r.First()
                                                  .Resource)
                                        {
                                            Name = r.First()
                                                         .NameWithoutContext,
                                            IsProfileResource = true,
                                            Readable = r.First()
                                                                                       .Readable,
                                            Writable = r.LastOrDefault() != null
                                                            && r.Last()
                                                                .Writable,
                                            RequestProperties = r.First()
                                                                      .Readable
                                                     ? r.First()
                                                        .RequestProperties
                                                     : r.LastOrDefault()
                                                       ?.RequestProperties,
                                            ContextualResource = r.First()
                                                                       .ContextualResource
                                        });
        }

        public bool HasTotalCount => true;
    }
}
