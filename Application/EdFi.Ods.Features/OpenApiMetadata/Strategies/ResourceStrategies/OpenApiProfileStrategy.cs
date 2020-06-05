// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Inflection;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Utils.Profiles;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies
{
    public class OpenApiProfileStrategy : IOpenApiMetadataResourceStrategy
    {
        public IEnumerable<SwaggerResource> GetFilteredResources(SwaggerDocumentContext swaggerDocumentContext)
        {
            var profileResources =
                swaggerDocumentContext.ProfileContext.ProfileResourceModel.ResourceByName.Values
                                      .ToList();

            var allResources = profileResources.Where(r => r.Readable != null)
                                               .Select(r => r.Readable)
                                               .Concat(
                                                    profileResources.Where(r => r.Writable != null)
                                                                    .Select(r => r.Writable))
                                               .ToList();

            var readableSwaggerResources =
                profileResources.Where(r => r.Readable != null)
                                .Select(
                                     r => new SwaggerResource(r.Readable)
                                          {
                                              Name = GetResourceName(r.Readable, ContentTypeUsage.Readable), Readable = true, IsProfileResource = true
                                          })
                                .ToList();

            var writableSwaggerResources =
                profileResources.Where(r => r.Writable != null)
                                .Select(
                                     r => new SwaggerResource(r.Writable)
                                          {
                                              Name = GetResourceName(r.Writable, ContentTypeUsage.Writable), Writable = true, IsProfileResource = true
                                          })
                                .ToList();

            return readableSwaggerResources.Concat(writableSwaggerResources)
                                           .Concat(
                                                readableSwaggerResources.Select(
                                                    r => GetBaseResourceInProfile(
                                                        allResources,
                                                        r,
                                                        ContentTypeUsage.Readable)))
                                           .Concat(
                                                readableSwaggerResources.Select(
                                                    r => GetGenerationContextForSwaggerResource(
                                                        allResources,
                                                        r,
                                                        ContentTypeUsage.Readable)))
                                           .Concat(
                                                writableSwaggerResources.Select(
                                                    r => GetBaseResourceInProfile(
                                                        allResources,
                                                        r,
                                                        ContentTypeUsage.Writable)))
                                           .Concat(
                                                writableSwaggerResources.Select(
                                                    r => GetGenerationContextForSwaggerResource(
                                                        allResources,
                                                        r,
                                                        ContentTypeUsage.Writable)))
                                           .Where(r => r != null);
        }

        private string GetResourceName(Resource resource, ContentTypeUsage contentTypeUsage)
            => $"{CompositeTermInflector.MakeSingular(resource.Name)}_{contentTypeUsage}".ToCamelCase();

        private string GetBaseResourceName(Resource baseResource, Resource resource, ContentTypeUsage contentTypeUsage)
            => $"{baseResource.Name}_{CompositeTermInflector.MakeSingular(resource.Name)}_{contentTypeUsage}".ToCamelCase();

        private SwaggerResource GetBaseResourceInProfile(
            IList<Resource> resources,
            SwaggerResource swaggerResource,
            ContentTypeUsage contentTypeUsage)
        {
            if (swaggerResource.Resource.IsBase())
            {
                return null;
            }

            var baseResource =
                resources.FirstOrDefault(r => swaggerResource.Resource.IsDerivedFrom(r));

            return baseResource == null
                ? null
                : new SwaggerResource(baseResource)
                  {
                      Name = GetBaseResourceName(baseResource, swaggerResource.Resource, contentTypeUsage),
                      Readable = contentTypeUsage == ContentTypeUsage.Readable, Writable = contentTypeUsage == ContentTypeUsage.Writable,
                      IsProfileResource = true
                  };
        }

        private SwaggerResource GetGenerationContextForSwaggerResource(
            IList<Resource> resources,
            SwaggerResource swaggerResource,
            ContentTypeUsage contentTypeUsage)
        {
            if (!swaggerResource.Resource.IsBase())
            {
                return null;
            }

            var derivedResource =
                resources.FirstOrDefault(r => r.IsDerivedFrom(swaggerResource.Resource));

            return derivedResource == null
                ? null
                : new SwaggerResource(swaggerResource.Resource)
                  {
                      ContextualResource = derivedResource, Name = swaggerResource.Name, Readable = contentTypeUsage == ContentTypeUsage.Readable,
                      Writable = contentTypeUsage == ContentTypeUsage.Writable, IsProfileResource = true
                  };
        }
    }
}
