// SPDX-License-Identifier: Apache-2.0
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
    public class SwaggerPathsFactoryProfileStrategy
        : ISwaggerPathsFactorySelectorStrategy, ISwaggerPathsFactoryContentTypeStrategy, ISwaggerPathsFactoryNamingStrategy
    {
        private readonly SwaggerDocumentContext _documentContext;

        public SwaggerPathsFactoryProfileStrategy(SwaggerDocumentContext documentContext)
        {
            _documentContext = documentContext;
        }

        public string GetOperationContentType(SwaggerResource swaggerResource, ContentTypeUsage contentTypeUsage)
            => ProfilesContentTypeHelper.CreateContentType(
                swaggerResource.Resource.Name,
                _documentContext.ProfileContext.ProfileName,
                contentTypeUsage);

        public string GetResourceName(SwaggerResource swaggerResource, ContentTypeUsage contentTypeUsage)
        {
            var schemaPrefix =
                swaggerResource.Resource.Entity.DomainModel.SchemaNameMapProvider
                               .GetSchemaMapByPhysicalName(swaggerResource.Resource.Entity.Schema)
                               .ProperCaseName;

            var name = swaggerResource.ContextualResource == null
                ? string.Format(
                    "{0}_{1}_{2}",
                    schemaPrefix,
                    CompositeTermInflector.MakeSingular(swaggerResource.Resource.Name),
                    contentTypeUsage)
                : string.Format(
                    "{0}_{1}_{2}_{3}",
                    schemaPrefix,
                    CompositeTermInflector.MakeSingular(swaggerResource.Resource.Name),
                    swaggerResource.ContextualResource.Name,
                    contentTypeUsage);

            return SwaggerDocumentHelper.CamelCaseSegments(name);
        }

        public IEnumerable<SwaggerPathsResource> ApplyStrategy(IEnumerable<SwaggerResource> swaggerResources)
        {
            // When rendering definitions, profile resources exist as separate SwaggerResource objects
            // per content type (Readable / Writable).
            // When rendering paths, all profile resource content types are rendered
            // in the same 'Paths' section and need to be merged into a unified SwaggerPathsResource.
            return swaggerResources.GroupBy(
                                        r => new
                                             {
                                                 r.NameWithoutContext, r.Resource.Entity.Schema, Context = r.ContextualResource
                                             })
                                   .Select(
                                        r => new SwaggerPathsResource(
                                                 r.First()
                                                  .Resource)
                                             {
                                                 Name = r.First()
                                                         .NameWithoutContext,
                                                 IsProfileResource = true, Readable = r.First()
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
