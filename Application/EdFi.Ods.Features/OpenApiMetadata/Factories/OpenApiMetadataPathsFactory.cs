// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
#if NETFRAMEWORK
using EdFi.Ods.Api.ChangeQueries;
#endif
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Utils.Extensions;
using EdFi.Ods.Common.Utils.Profiles;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies;

namespace EdFi.Ods.Features.OpenApiMetadata.Factories
{
    public class OpenApiMetadataPathsFactory
    {
        private readonly IOpenApiMetadataPathsFactoryContentTypeStrategy _contentTypeStrategy;
        private readonly IOpenApiMetadataPathsFactoryNamingStrategy _pathsFactoryNamingStrategy;
        private readonly IOpenApiMetadataPathsFactorySelectorStrategy _swaggerPathsFactorySelectorStrategy;

        public OpenApiMetadataPathsFactory(
            IOpenApiMetadataPathsFactorySelectorStrategy swaggerPathsFactorySelectorStrategy,
            IOpenApiMetadataPathsFactoryContentTypeStrategy contentTypeStrategy,
            IOpenApiMetadataPathsFactoryNamingStrategy pathsFactoryNamingStrategy)
        {
            _swaggerPathsFactorySelectorStrategy = swaggerPathsFactorySelectorStrategy;
            _contentTypeStrategy = contentTypeStrategy;
            _pathsFactoryNamingStrategy = pathsFactoryNamingStrategy;
        }

        public IDictionary<string, PathItem> Create(IList<OpenApiMetadataResource> swaggerResources, bool isCompositeContext)
        {
            return _swaggerPathsFactorySelectorStrategy
                .ApplyStrategy(swaggerResources)
                .Where(r => r.Readable || r.Writable)
                .OrderBy(r => r.Name)
                .SelectMany(
                    r =>
                    {
                        var resourceName = string.IsNullOrWhiteSpace(r.Path)
                            ? $"/{OpenApiMetadataDocumentHelper.GetResourcePluralName(r.Resource).ToCamelCase()}"
                            : r.Path;

                        var resourcePath = $"/{r.ResourceSchema}{resourceName}";

                        var paths = new[]
                        {
                            r.SupportsAccessNonIdAccessOperations
                                ? new
                                {
                                    Path = resourcePath,
                                    PathItem = CreatePathItemForNonIdAccessedOperations(r, isCompositeContext)
                                }
                                : null,
                            r.SupportsIdAccessOperations
                                ? new
                                {
                                    Path = $"{resourcePath}/{{id}}",
                                    PathItem = CreatePathItemForAccessByIdsOperations(r)
                                }
                                : null
#if NETFRAMEWORK
                            ,
                            ChangeQueryFeature.IsEnabled && !r.Name.Equals(ChangeQueryFeature.SchoolYearTypesResourceName) && !isCompositeContext
                                ? new
                                {
                                    Path = $"{resourcePath}/deletes",
                                    PathItem = CreatePathItemForChangeQueryOperation(r)
                                }
                                : null
#endif
                        };

                        return paths.Where(p => p != null);
                    })
                .GroupBy(p => p.Path)
                .Select(p => p.First())
                .ToDictionary(p => p.Path, p => p.PathItem);
        }

        private PathItem CreatePathItemForNonIdAccessedOperations(OpenApiMetadataPathsResource swaggerResource, bool isCompositeContext)
            => new PathItem
            {
                get = swaggerResource.Readable
                    ? CreateGetOperation(swaggerResource, isCompositeContext)
                    : null,
                post = swaggerResource.Writable
                    ? CreatePostOperation(swaggerResource)
                    : null
            };

        private PathItem CreatePathItemForAccessByIdsOperations(OpenApiMetadataPathsResource swaggerResource)
            => new PathItem
            {
                get = swaggerResource.Readable
                    ? CreateGetByIdOperation(swaggerResource)
                    : null,
                put = swaggerResource.Writable
                    ? CreatePutByIdOperation(swaggerResource)
                    : null,
                delete = swaggerResource.Writable
                    ? CreateDeleteByIdOperation(swaggerResource)
                    : null
            };

        private PathItem CreatePathItemForChangeQueryOperation(OpenApiMetadataPathsResource swaggerResource)
            => new PathItem
            {
                get = swaggerResource.Writable
                    ? CreateDeletesOperation(swaggerResource)
                    : null
            };

        private Operation CreateGetOperation(OpenApiMetadataPathsResource swaggerResource, bool isCompositeContext)
        {
            var operation = new Operation
            {
                tags = new List<string>
                {
                    OpenApiMetadataDocumentHelper.GetResourcePluralName(swaggerResource.Resource)
                        .ToCamelCase()
                },
                summary = "Retrieves specific resources using the resource's property values (using the \"Get\" pattern).",
                description =
                    "This GET operation provides access to resources using the \"Get\" search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).",
                operationId = swaggerResource.OperationId ?? $"get{swaggerResource.Resource.PluralName}",
                deprecated = swaggerResource.IsDeprecated,
                produces = new[] { _contentTypeStrategy.GetOperationContentType(swaggerResource, ContentTypeUsage.Readable) },
                parameters = CreateGetByExampleParameters(swaggerResource, isCompositeContext),
                responses = OpenApiMetadataDocumentHelper.GetReadOperationResponses(
                    _pathsFactoryNamingStrategy.GetResourceName(swaggerResource, ContentTypeUsage.Readable),
                    true)
            };

            return operation;
        }

        private Operation CreateGetByIdOperation(OpenApiMetadataPathsResource swaggerResource)
        {
            return new Operation
            {
                tags = new List<string>
                {
                    OpenApiMetadataDocumentHelper.GetResourcePluralName(swaggerResource.Resource)
                        .ToCamelCase()
                },
                summary = "Retrieves a specific resource using the resource's identifier (using the \"Get By Id\" pattern).",
                description = "This GET operation retrieves a resource by the specified resource identifier.",
                operationId = $"get{swaggerResource.Resource.PluralName}ById",
                deprecated = swaggerResource.IsDeprecated,
                produces = new[] { _contentTypeStrategy.GetOperationContentType(swaggerResource, ContentTypeUsage.Readable) },
                parameters = new[]
                    {
                        // Path parameters need to be inline in the operation, and not referenced.
                        OpenApiMetadataDocumentHelper.CreateIdParameter(),
                        new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("If-None-Match")}
                    }.Concat(
                        swaggerResource.DefaultGetByIdParameters
                            .Select(p => new Parameter { @ref = OpenApiMetadataDocumentHelper.GetParameterReference(p) }))
                    .ToList(),
                responses =
                    OpenApiMetadataDocumentHelper.GetReadOperationResponses(
                        _pathsFactoryNamingStrategy.GetResourceName(swaggerResource, ContentTypeUsage.Readable),
                        false)
            };
        }

        private IList<Parameter> CreateQueryParameters(bool isCompositeContext)
        {
            var parameterList = new List<Parameter>
            {
                new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("offset")},
                new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("limit")}
            };

#if NETFRAMEWORK
            if (ChangeQueryFeature.IsEnabled && !isCompositeContext)
            {
                parameterList.Add(
                    new Parameter { @ref = OpenApiMetadataDocumentHelper.GetParameterReference("MinChangeVersion") });

                parameterList.Add(
                    new Parameter { @ref = OpenApiMetadataDocumentHelper.GetParameterReference("MaxChangeVersion") });
            }
#endif

            if (_swaggerPathsFactorySelectorStrategy.HasTotalCount)
            {
                parameterList.Add(
                    new Parameter { @ref = OpenApiMetadataDocumentHelper.GetParameterReference("totalCount") });
            }

            return parameterList;
        }

        private IList<Parameter> CreateGetByExampleParameters(OpenApiMetadataPathsResource swaggerResource, bool isCompositeContext)
        {
            var parameterList = CreateQueryParameters(isCompositeContext)
                .Concat(
                    swaggerResource.DefaultGetByExampleParameters.Select(
                        p => new Parameter { @ref = OpenApiMetadataDocumentHelper.GetParameterReference(p) }))
                .ToList();

            swaggerResource.RequestProperties.ForEach(
                x =>
                {
                    parameterList.Add(
                        new Parameter
                        {
                            name = x.PropertyName.ToCamelCase(),
                            @in = swaggerResource.IsPathParameter(x)
                                ? "path"
                                : "query",
                            description = OpenApiMetadataDocumentHelper.PropertyDescription(x),
                            type = OpenApiMetadataDocumentHelper.PropertyType(x),
                            format = x.PropertyType.ToOpenApiFormat(),
                            required = swaggerResource.IsPathParameter(x),
                            isIdentity = OpenApiMetadataDocumentHelper.GetIsIdentity(x),
                            maxLength = OpenApiMetadataDocumentHelper.GetMaxLength(x),
                            isDeprecated = OpenApiMetadataDocumentHelper.GetIsDeprecated(x),
                            deprecatedReasons = OpenApiMetadataDocumentHelper.GetDeprecatedReasons(x)
                        });
                });

            return parameterList;
        }

        private Operation CreatePutByIdOperation(OpenApiMetadataPathsResource swaggerResource)
        {
            return new Operation
            {
                tags = new List<string>
                {
                    OpenApiMetadataDocumentHelper.GetResourcePluralName(swaggerResource.Resource)
                        .ToCamelCase()
                },
                summary = "Updates or creates a resource based on the resource identifier.",
                description =
                    "The PUT operation is used to update or create a resource by identifier. If the resource doesn't exist, the resource will be created using that identifier. Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource \"id\" is provided in the JSON body, it will be ignored as well.",
                operationId = $"put{swaggerResource.Name}",
                deprecated = swaggerResource.IsDeprecated,
                consumes = new[] { _contentTypeStrategy.GetOperationContentType(swaggerResource, ContentTypeUsage.Writable) },
                parameters = CreatePutParameters(swaggerResource),
                responses = OpenApiMetadataDocumentHelper.GetWriteOperationResponses(HttpMethod.Put)
            };
        }

        private IList<Parameter> CreatePutParameters(OpenApiMetadataPathsResource swaggerResource)
        {
            IList<Parameter> parameterList = new List<Parameter>();

            parameterList.Add(OpenApiMetadataDocumentHelper.CreateIdParameter());

            parameterList.Add(CreateIfMatchParameter("PUT from updating"));
            parameterList.Add(CreateBodyParameter(swaggerResource));

            return parameterList;
        }

        private Operation CreateDeleteByIdOperation(OpenApiMetadataPathsResource swaggerResource)
        {
            return new Operation
            {
                tags = new List<string>
                {
                    OpenApiMetadataDocumentHelper.GetResourcePluralName(swaggerResource.Resource)
                        .ToCamelCase()
                },
                summary = "Deletes an existing resource using the resource identifier.",
                description =
                    "The DELETE operation is used to delete an existing resource by identifier. If the resource doesn't exist, an error will result (the resource will not be found).",
                operationId = $"delete{swaggerResource.Name}ById",
                deprecated = swaggerResource.IsDeprecated,
                consumes = new[] { _contentTypeStrategy.GetOperationContentType(swaggerResource, ContentTypeUsage.Writable) },
                parameters = new[]
                {
                    OpenApiMetadataDocumentHelper.CreateIdParameter(),
                    CreateIfMatchParameter("DELETE from removing")
                },
                responses = OpenApiMetadataDocumentHelper.GetWriteOperationResponses(HttpMethod.Delete)
            };
        }

        private Operation CreateDeletesOperation(OpenApiMetadataPathsResource swaggerResource)
        {
            return new Operation
            {
                tags = new List<string>
                {
                    OpenApiMetadataDocumentHelper.GetResourcePluralName(swaggerResource.Resource)
                        .ToCamelCase()
                },
                summary = "Retrieves deleted resources based on change version.",
                description = "The DELETES operation is used to retrieve deleted resources.",
                operationId = $"deletes{swaggerResource.Resource.PluralName}",
                deprecated = swaggerResource.IsDeprecated,
                consumes = new[]
                {
                    _contentTypeStrategy.GetOperationContentType(
                        swaggerResource,
                        ContentTypeUsage.Writable)
                },
                parameters = new List<Parameter>
                {
                    new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("offset")},
                    new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("limit")},
                    new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("MinChangeVersion")},
                    new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("MaxChangeVersion")}
                },
                responses = OpenApiMetadataDocumentHelper.GetReadOperationResponses(
                    _pathsFactoryNamingStrategy.GetResourceName(swaggerResource, ContentTypeUsage.Readable),
                    true)
            };
        }

        private Operation CreatePostOperation(OpenApiMetadataPathsResource swaggerResource)
        {
            return new Operation
            {
                tags = new List<string>
                {
                    OpenApiMetadataDocumentHelper.GetResourcePluralName(swaggerResource.Resource)
                        .ToCamelCase()
                },
                summary = "Creates or updates resources based on the natural key values of the supplied resource.",
                description =
                    "The POST operation can be used to create or update resources. In database terms, this is often referred to as an \"upsert\" operation (insert + update). Clients should NOT include the resource \"id\" in the JSON body because it will result in an error (you must use a PUT operation to update a resource by \"id\"). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.",
                operationId = "post" + swaggerResource.Name,
                deprecated = swaggerResource.IsDeprecated,
                consumes = new[] { _contentTypeStrategy.GetOperationContentType(swaggerResource, ContentTypeUsage.Writable) },
                parameters = CreatePostParameters(swaggerResource),
                responses = OpenApiMetadataDocumentHelper.GetWriteOperationResponses(HttpMethod.Post)
            };
        }

        private IList<Parameter> CreatePostParameters(OpenApiMetadataPathsResource swaggerResource)
        {
            return new List<Parameter> { CreateBodyParameter(swaggerResource) };
        }

        private Parameter CreateIfMatchParameter(string operationText)
            => new Parameter
            {
                name = "If-Match",
                description =
                    $"The ETag header value used to prevent the {operationText} a resource modified by another consumer.",
                @in = "header",
                type = "string"
            };

        private Parameter CreateBodyParameter(OpenApiMetadataPathsResource swaggerPathsResource)
        {
            var camelCaseName = swaggerPathsResource.Resource.Name.ToCamelCase();

            var referenceName =
                _pathsFactoryNamingStrategy.GetResourceName(swaggerPathsResource, ContentTypeUsage.Writable);

            return new Parameter
            {
                name = camelCaseName,
                description =
                    $"The JSON representation of the \"{camelCaseName}\" resource to be created or updated.",
                @in = "body",
                required = true,
                schema = new Models.Schema { @ref = OpenApiMetadataDocumentHelper.GetDefinitionReference(referenceName) }
            };
        }
    }
}
