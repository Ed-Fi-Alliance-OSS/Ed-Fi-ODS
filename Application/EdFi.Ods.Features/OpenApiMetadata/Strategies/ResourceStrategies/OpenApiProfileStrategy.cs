// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Common.Inflection;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Utils.Profiles;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies
{
    public class OpenApiProfileStrategy : IOpenApiMetadataResourceStrategy
    {
        public IEnumerable<OpenApiMetadataResource> GetFilteredResources(OpenApiMetadataDocumentContext openApiMetadataDocumentContext)
        {
            var profileResources =
                openApiMetadataDocumentContext.ProfileContext.ProfileResourceModel.ResourceByName.Values
                                      .ToList();

            var allResources = profileResources.Where(r => r.Readable != null)
                                               .Select(r => r.Readable)
                                               .Concat(
                                                    profileResources.Where(r => r.Writable != null)
                                                                    .Select(r => r.Writable))
                                               .ToList();

            var readableOpenApiMetadataResources =
                profileResources.Where(r => r.Readable != null)
                                .Select(
                                     r => new OpenApiMetadataResource(r.Readable)
                                     {
                                         Name = GetResourceName(r.Readable, ContentTypeUsage.Readable),
                                         Readable = true,
                                         IsProfileResource = true
                                     })
                                .ToList();

            var writableOpenApiMetadataResources =
                profileResources.Where(r => r.Writable != null)
                                .Select(
                                     r => new OpenApiMetadataResource(r.Writable)
                                     {
                                         Name = GetResourceName(r.Writable, ContentTypeUsage.Writable),
                                         Writable = true,
                                         IsProfileResource = true
                                     })
                                .ToList();

            return readableOpenApiMetadataResources.Concat(writableOpenApiMetadataResources)
                                           .Concat(
                                                readableOpenApiMetadataResources.Select(
                                                    r => GetBaseResourceInProfile(
                                                        allResources,
                                                        r,
                                                        ContentTypeUsage.Readable)))
                                           .Concat(
                                                readableOpenApiMetadataResources.Select(
                                                    r => GetGenerationContextForSwaggerResource(
                                                        allResources,
                                                        r,
                                                        ContentTypeUsage.Readable)))
                                           .Concat(
                                                writableOpenApiMetadataResources.Select(
                                                    r => GetBaseResourceInProfile(
                                                        allResources,
                                                        r,
                                                        ContentTypeUsage.Writable)))
                                           .Concat(
                                                writableOpenApiMetadataResources.Select(
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

        private OpenApiMetadataResource GetBaseResourceInProfile(
            IList<Resource> resources,
            OpenApiMetadataResource openApiMetadataResource,
            ContentTypeUsage contentTypeUsage)
        {
            if (openApiMetadataResource.Resource.IsBase())
            {
                return null;
            }

            var baseResource =
                resources.FirstOrDefault(r => openApiMetadataResource.Resource.IsDerivedFrom(r));

            return baseResource == null
                ? null
                : new OpenApiMetadataResource(baseResource)
                {
                    Name = GetBaseResourceName(baseResource, openApiMetadataResource.Resource, contentTypeUsage),
                    Readable = contentTypeUsage == ContentTypeUsage.Readable,
                    Writable = contentTypeUsage == ContentTypeUsage.Writable,
                    IsProfileResource = true
                };
        }

        private OpenApiMetadataResource GetGenerationContextForSwaggerResource(
            IList<Resource> resources,
            OpenApiMetadataResource openApiMetadataResource,
            ContentTypeUsage contentTypeUsage)
        {
            if (!openApiMetadataResource.Resource.IsBase())
            {
                return null;
            }

            var derivedResource =
                resources.FirstOrDefault(r => r.IsDerivedFrom(openApiMetadataResource.Resource));

            return derivedResource == null
                ? null
                : new OpenApiMetadataResource(openApiMetadataResource.Resource)
                {
                    ContextualResource = derivedResource,
                    Name = openApiMetadataResource.Name,
                    Readable = contentTypeUsage == ContentTypeUsage.Readable,
                    Writable = contentTypeUsage == ContentTypeUsage.Writable,
                    IsProfileResource = true
                };
        }
    }
}
