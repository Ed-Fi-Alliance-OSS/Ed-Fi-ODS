﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using Schema = EdFi.Ods.Features.OpenApiMetadata.Models.Schema;

namespace EdFi.Ods.Features.OpenApiMetadata.Factories
{
    public static class OpenApiMetadataDocumentHelper
    {
        public const string ContentType = "application/json";

        public const string Json = "swagger.json";

        public static string GetResourcePluralName(ResourceClassBase resourceClassBase) => resourceClassBase.PluralName;

        public static string GetResourceItemName(Resource resource) => resource.Name;

        public static string GetDefinitionReference(string definitionName) => $"#/definitions/{definitionName}";

        public static string GetResponseReference(string responseName) => $"#/responses/{responseName}";

        public static string GetParameterReference(string parameterName) => $"#/parameters/{parameterName}";

        public static string GetLinkReference() => "#/definitions/link";

        public static string[] GetConsumes() => new[]
                                                {
                                                    ContentType
                                                };

        public static string[] GetProduces() => new[]
                                                {
                                                    ContentType
                                                };

        public static string CamelCaseSegments(string value) => string.Join(
            "_",
            value.Split('_')
                 .Select(segment => segment.ToCamelCase()));

        public static string PropertyType(ResourceProperty resourceProperty) => resourceProperty.IsDescriptorUsage
                                                                                || UniqueIdConventions.IsUniqueId(resourceProperty.JsonPropertyName)
            ? "string"
            : resourceProperty.PropertyType.ToOpenApiType();

        public static string PropertyFormat(ResourceProperty resourceProperty) => UniqueIdConventions.IsUniqueId(resourceProperty.JsonPropertyName)
            ? null
            : resourceProperty.PropertyType.ToOpenApiFormat();

        public static string PropertyDescription(ResourceProperty resourceProperty)
            => UniqueIdConventions.IsUniqueId(resourceProperty.JsonPropertyName)
                ? $"A unique alphanumeric code assigned to a {UniqueIdConventions.RemoveUniqueIdSuffix(resourceProperty.JsonPropertyName.ScrubForOpenApi()).ToLower()}."
                : resourceProperty.Description
                                  .ScrubForOpenApi();

        public static Schema CreatePropertySchema(ResourceProperty resourceProperty)
        {
            var schema =  new Schema
            {
                type = PropertyType(resourceProperty),
                format = resourceProperty.PropertyType.ToOpenApiFormat(),
                description = PropertyDescription(resourceProperty),
                isIdentity = GetIsIdentity(resourceProperty),
                maxLength = GetMaxLength(resourceProperty),
                minLength = GetMinLength(resourceProperty),
                minimum = GetMinimum(resourceProperty),
                maximum = GetMaximum(resourceProperty),
                isDeprecated = GetIsDeprecated(resourceProperty),
                deprecatedReasons = GetDeprecatedReasons(resourceProperty)
            };

            if (resourceProperty.PropertyType.IsNullable)
            {
                schema.nullable = true;
            }

            return schema;
        }

        public static bool? GetIsIdentity(ResourceProperty resourceProperty)
        {
            return resourceProperty.IsIdentifying
                ? true
                : (bool?)null;
        }

        public static bool? GetIsDeprecated(ResourceProperty resourceProperty)
        {
            return resourceProperty.IsDeprecated
                ? true
                : (bool?)null;
        }

        public static string GetDeprecatedReasons(ResourceProperty resourceProperty)
        {
            return resourceProperty.DeprecationReasons?.Length > 0
                ? string.Join(" ", resourceProperty.DeprecationReasons)
                : null;
        }

        public static int? GetMaxLength(ResourceProperty resourceProperty)
        {
            if (UniqueIdConventions.IsUniqueId(resourceProperty.JsonPropertyName))
            {
                return 32;
            }

            return resourceProperty.PropertyType.ToCSharp().EqualsIgnoreCase("string") && 
                resourceProperty.PropertyType.MaxLength > 0
                ? resourceProperty.PropertyType.MaxLength
                : (int?)null;
        }
        public static int? GetMinLength(ResourceProperty resourceProperty)
        {
            return resourceProperty.PropertyType.ToCSharp().EqualsIgnoreCase("string") && 
                resourceProperty.PropertyType.MinLength > 0
                ? resourceProperty.PropertyType.MinLength
                : (int?)null;
        }
        public static dynamic GetMinimum(ResourceProperty resourceProperty)
        {
            if (resourceProperty.PropertyType.ToCSharp().EqualsIgnoreCase("int"))
                return (int?)resourceProperty.PropertyType.MinValue;
            else if (resourceProperty.PropertyType.ToCSharp().EqualsIgnoreCase("decimal"))
                return (resourceProperty.PropertyType.MinValue);

            return null;
        }
        public static dynamic GetMaximum(ResourceProperty resourceProperty)
        {
            if (resourceProperty.PropertyType.ToCSharp().EqualsIgnoreCase("int"))
                return (int?)resourceProperty.PropertyType.MaxValue;
            else if (resourceProperty.PropertyType.ToCSharp().EqualsIgnoreCase("decimal"))
                return (resourceProperty.PropertyType.MaxValue);

            return null;
        }

        public static string GetEdFiExtensionBridgeName(ResourceClassBase resource, IOpenApiMetadataResourceContext resourceContext = null)
        {
            var name = $"{resource.Name}Extensions";

            if (!string.IsNullOrEmpty(resourceContext?.OperationNamingContext))
            {
                name += $"_{resourceContext.OperationNamingContext}";
            }

            return CamelCaseSegments(name);
        }

        public static string GetResourceExtensionDefinitionName(Extension extension, IOpenApiMetadataResourceContext resourceContext = null)
        {
            var name = $"{extension.PropertyName}_{extension.ObjectType.Parent.Name}Extension";

            if (!string.IsNullOrEmpty(resourceContext?.OperationNamingContext))
            {
                name += $"_{resourceContext.OperationNamingContext}";
            }

            return CamelCaseSegments(name);
        }

        public static Schema CreateReferenceSchema(Reference reference)
        {
            var properties = reference.ReferenceTypeProperties
                                      .Where(x => x.IsIdentifying)
                                      .Select(
                                           x => new
                                           {
                                               IsRequired = x.IsIdentifying || reference.IsRequired,
                                               PropertyName = x.JsonPropertyName,
                                               Schema = CreatePropertySchema(x)
                                           })
                                      .OrderBy(x => x.PropertyName)
                                      .ToList();

            var propertyDict = properties.ToDictionary(x => x.PropertyName.ToCamelCase(), x => x.Schema);

            propertyDict.Add(
                "link",
                new Schema
                {
                    @ref = GetLinkReference()
                });

            return new Schema
            {
                type = "object",
                required = properties.Where(x => x.IsRequired)
                    .Select(x => x.PropertyName.ToCamelCase())
                    .ToList(),
                properties = propertyDict
            };
        }

        public static Dictionary<string, Response> GetReadOperationResponses(string resourceName, bool isArray, bool isChangeQueryDeletes = false, bool isChangeQueryKeyChanges = false)
        {
            if (isChangeQueryDeletes && isChangeQueryKeyChanges)
            {
                throw new ArgumentException(
                    $"{nameof(isChangeQueryDeletes)} and {nameof(isChangeQueryKeyChanges)} cannot be both true.");
            }

            var schemaRef = new Schema
            {
                @ref = isChangeQueryDeletes
                    ? GetDefinitionReference($"trackedChanges_{resourceName}Delete")
                    : isChangeQueryKeyChanges
                        ? GetDefinitionReference($"trackedChanges_{resourceName}KeyChange")
                        : GetDefinitionReference(resourceName)
            };

            var schema = isArray
                ? new Schema
                {
                    type = "array",
                    items = schemaRef
                }
                : schemaRef;

            return new Dictionary<string, Response>
                   {
                       {
                           "200", new Response
                                  {
                                      description = "The requested resource was successfully retrieved.", schema = schema
                                  }
                       },
                       {
                           "304", new Response
                                  {
                                      @ref = GetResponseReference("NotModified")
                                  }
                       },
                       {
                           "400", new Response
                                  {
                                      @ref = GetResponseReference("BadRequest")
                                  }
                       },
                       {
                           "401", new Response
                                  {
                                      @ref = GetResponseReference("Unauthorized")
                                  }
                       },
                       {
                           "403", new Response
                                  {
                                      @ref = GetResponseReference("Forbidden")
                                  }
                       },
                       {
                           "404", new Response
                                  {
                                      @ref = GetResponseReference("NotFound")
                                  }
                       },
                       {
                           "500", new Response
                                  {
                                      @ref = GetResponseReference("Error")
                                  }
                       }
                   };
        }

        public static SortedDictionary<string, Response> GetWriteOperationResponses(HttpMethod httpMethod)
        {
            var responses = new Dictionary<string, Response>();

            switch (httpMethod.ToString())
            {
                case "PUT":

                    responses.Add(
                        "204",
                        new Response
                        {
                            @ref = GetResponseReference("Updated")
                        });

                    responses.Add(
                        "404",
                        new Response
                        {
                            @ref = GetResponseReference("NotFound")
                        });

                    break;

                case "DELETE":

                    responses.Add(
                        "204",
                        new Response
                        {
                            @ref = GetResponseReference("Deleted")
                        });

                    responses.Add(
                        "404",
                        new Response
                        {
                            @ref = GetResponseReference("NotFound")
                        });

                    break;

                case "POST":

                    responses.Add(
                        "201",
                        new Response
                        {
                            @ref = GetResponseReference("Created")
                        });

                    responses.Add(
                        "200",
                        new Response
                        {
                            @ref = GetResponseReference("Updated")
                        });

                    break;

                default:
                    return new SortedDictionary<string, Response>();
            }

            responses.Add(
                "400",
                new Response
                {
                    @ref = GetResponseReference("BadRequest")
                });

            responses.Add(
                "401",
                new Response
                {
                    @ref = GetResponseReference("Unauthorized")
                });

            responses.Add(
                "403",
                new Response
                {
                    @ref = GetResponseReference("Forbidden")
                });

            responses.Add(
                "409",
                new Response
                {
                    @ref = GetResponseReference("Conflict")
                });

            responses.Add(
                "412",
                new Response
                {
                    @ref = GetResponseReference("PreconditionFailed")
                });

            responses.Add(
                "500",
                new Response
                {
                    @ref = GetResponseReference("Error")
                });

            return new SortedDictionary<string, Response>(responses);
        }

        public static Parameter CreateIdParameter()
        {
            return new Parameter
            {
                name = "id",
                @in = "path",
                type = "string",
                required = true,
                description = "A resource identifier that uniquely identifies the resource."
            };
        }
    }
}
