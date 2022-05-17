// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Utils.Profiles;
using EdFi.Ods.Features.ChangeQueries;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies;
using IEnumerableExtensions = EdFi.Common.Utils.Extensions.IEnumerableExtensions;
using Schema = EdFi.Ods.Features.OpenApiMetadata.Models.Schema;

namespace EdFi.Ods.Features.OpenApiMetadata.Factories
{
    public class OpenApiMetadataPathsFactory
    {
        private readonly ApiSettings _apiSettings;
        private readonly IOpenApiMetadataPathsFactoryContentTypeStrategy _contentTypeStrategy;
        private readonly IOpenApiMetadataPathsFactorySelectorStrategy _openApiMetadataPathsFactorySelectorStrategy;
        private readonly IOpenApiMetadataPathsFactoryNamingStrategy _pathsFactoryNamingStrategy;

        public OpenApiMetadataPathsFactory(
            IOpenApiMetadataPathsFactorySelectorStrategy openApiMetadataPathsFactorySelectorStrategy,
            IOpenApiMetadataPathsFactoryContentTypeStrategy contentTypeStrategy,
            IOpenApiMetadataPathsFactoryNamingStrategy pathsFactoryNamingStrategy,
            ApiSettings apiSettings)
        {
            _openApiMetadataPathsFactorySelectorStrategy = openApiMetadataPathsFactorySelectorStrategy;
            _contentTypeStrategy = contentTypeStrategy;
            _pathsFactoryNamingStrategy = pathsFactoryNamingStrategy;
            _apiSettings = apiSettings;
        }

        public IDictionary<string, PathItem> Create(IList<OpenApiMetadataResource> openApiMetadataResources,
            bool isCompositeContext)
        {
            return _openApiMetadataPathsFactorySelectorStrategy
                .ApplyStrategy(openApiMetadataResources)
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
                        }.ToList();

                        if (_apiSettings.IsFeatureEnabled("ChangeQueries")
                            && !r.Name.Equals(ChangeQueriesConstants.SchoolYearTypesResourceName)
                            && !isCompositeContext)
                        {
                            paths.AddRange(
                                new[]
                                {
                                    new
                                    {
                                        Path = $"{resourcePath}/deletes",
                                        PathItem = CreatePathItemForTrackedChangesDeleteOperation(r)
                                    },
                                    new
                                    {
                                        Path = $"{resourcePath}/keyChanges",
                                        PathItem = CreatePathItemForTrackedChangesKeyChangeOperation(r)
                                    }
                                });
                        }

                        return paths.Where(p => p != null);
                    })
                .GroupBy(p => p.Path)
                .Select(p => p.First())
                .ToDictionary(p => p.Path, p => p.PathItem);
        }

        private PathItem CreatePathItemForNonIdAccessedOperations(OpenApiMetadataPathsResource openApiMetadataResource,
            bool isCompositeContext)
            => new PathItem
            {
                get = openApiMetadataResource.Readable
                    ? CreateGetOperation(openApiMetadataResource, isCompositeContext)
                    : null,
                post = openApiMetadataResource.Writable
                    ? CreatePostOperation(openApiMetadataResource)
                    : null
            };

        private PathItem CreatePathItemForAccessByIdsOperations(OpenApiMetadataPathsResource openApiMetadataResource)
            => new PathItem
            {
                get = openApiMetadataResource.Readable
                    ? CreateGetByIdOperation(openApiMetadataResource)
                    : null,
                put = openApiMetadataResource.Writable
                    ? CreatePutByIdOperation(openApiMetadataResource)
                    : null,
                delete = openApiMetadataResource.Writable
                    ? CreateDeleteByIdOperation(openApiMetadataResource)
                    : null
            };

        private PathItem CreatePathItemForTrackedChangesDeleteOperation(OpenApiMetadataPathsResource openApiMetadataResource)
            => new PathItem
            {
                get = openApiMetadataResource.Writable
                    ? CreateTrackedChangesDeleteOperation(openApiMetadataResource)
                    : null
            };

        private PathItem CreatePathItemForTrackedChangesKeyChangeOperation(OpenApiMetadataPathsResource openApiMetadataResource)
            => new PathItem
            {
                get = openApiMetadataResource.Writable
                    ? CreateTrackedChangesKeyChangeOperation(openApiMetadataResource)
                    : null
            };

        private Operation CreateGetOperation(OpenApiMetadataPathsResource openApiMetadataResource, bool isCompositeContext)
        {
            var operation = new Operation
            {
                tags = new List<string>
                {
                    OpenApiMetadataDocumentHelper.GetResourcePluralName(openApiMetadataResource.Resource)
                        .ToCamelCase()
                },
                summary = "Retrieves specific resources using the resource's property values (using the \"Get\" pattern).",
                description =
                    "This GET operation provides access to resources using the \"Get\" search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).",
                operationId = openApiMetadataResource.OperationId ?? $"get{openApiMetadataResource.Resource.PluralName}",
                deprecated = openApiMetadataResource.IsDeprecated,
                produces = new[]
                {
                    _contentTypeStrategy.GetOperationContentType(openApiMetadataResource, ContentTypeUsage.Readable)
                },
                parameters = CreateGetByExampleParameters(openApiMetadataResource, isCompositeContext),
                responses = CreateReadResponses(openApiMetadataResource, true)
            };

            return operation;
        }

        private Operation CreateGetByIdOperation(OpenApiMetadataPathsResource openApiMetadataResource)
        {
            var parameters = new[]
                {
                    // Path parameters need to be inline in the operation, and not referenced.
                    OpenApiMetadataDocumentHelper.CreateIdParameter(),
                    new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("If-None-Match")}
                }.Concat(
                    openApiMetadataResource.DefaultGetByIdParameters
                        .Select(p => new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference(p)}))
                .ToList();

            if (_apiSettings.IsFeatureEnabled(ApiFeature.ChangeQueries.GetConfigKeyName()))
            {
                parameters.Add(new Parameter
                {
                    name = "Snapshot-Identifier",
                    @in = "header",
                    description = "Indicates the Snapshot-Identifier that should be used.",
                    type = "string",
                    required = false
                });
            }

            return new Operation
            {
                tags = new List<string>
                {
                    OpenApiMetadataDocumentHelper.GetResourcePluralName(openApiMetadataResource.Resource)
                        .ToCamelCase()
                },
                summary = "Retrieves a specific resource using the resource's identifier (using the \"Get By Id\" pattern).",
                description = "This GET operation retrieves a resource by the specified resource identifier.",
                operationId = $"get{openApiMetadataResource.Resource.PluralName}ById",
                deprecated = openApiMetadataResource.IsDeprecated,
                produces = new[]
                {
                    _contentTypeStrategy.GetOperationContentType(openApiMetadataResource, ContentTypeUsage.Readable)
                },
                parameters = parameters,
                responses = CreateReadResponses(openApiMetadataResource, false)
            };
        }

        private Dictionary<string, Response> CreateReadResponses(OpenApiMetadataPathsResource openApiMetadataResource, bool isArray)
        {
            var responses = OpenApiMetadataDocumentHelper.GetReadOperationResponses(
                _pathsFactoryNamingStrategy.GetResourceName(openApiMetadataResource, ContentTypeUsage.Readable),
                isArray);

            if (_apiSettings.IsFeatureEnabled(ApiFeature.ChangeQueries.GetConfigKeyName()))
            {
                responses.Add(
                    "410",
                    new Response
                    {
                        description = 
                            "Gone. An attempt to connect to the database for the snapshot specified by the Snapshot-Identifier header was unsuccessful (indicating the snapshot may have been removed)."
                    });
            }

            return responses;
        }

        private IList<Parameter> CreateQueryParameters(bool isCompositeContext)
        {
            var parameterList = new List<Parameter>
            {
                new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("offset")},
                new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("limit")}
            };

            if (_apiSettings.IsFeatureEnabled("ChangeQueries") && !isCompositeContext)
            {
                parameterList.Add(
                    new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("MinChangeVersion")});

                parameterList.Add(
                    new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("MaxChangeVersion")});
            }

            if (_openApiMetadataPathsFactorySelectorStrategy.HasTotalCount)
            {
                parameterList.Add(
                    new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("totalCount")});
            }

            return parameterList;
        }

        private IList<Parameter> CreateGetByExampleParameters(OpenApiMetadataPathsResource openApiMetadataResource,
            bool isCompositeContext)
        {
            var parameterList = CreateQueryParameters(isCompositeContext)
                .Concat(
                    openApiMetadataResource.DefaultGetByExampleParameters.Select(
                        p => new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference(p)}))
                .ToList();

            IEnumerableExtensions.ForEach(
                openApiMetadataResource.RequestProperties, x =>
                {
                    parameterList.Add(
                        new Parameter
                        {
                            name = StringExtensions.ToCamelCase(x.PropertyName),
                            @in = openApiMetadataResource.IsPathParameter(x)
                                ? "path"
                                : "query",
                            description = OpenApiMetadataDocumentHelper.PropertyDescription(x),
                            type = OpenApiMetadataDocumentHelper.PropertyType(x),
                            format = x.PropertyType.ToOpenApiFormat(),
                            required = openApiMetadataResource.IsPathParameter(x),
                            isIdentity = OpenApiMetadataDocumentHelper.GetIsIdentity(x),
                            maxLength = OpenApiMetadataDocumentHelper.GetMaxLength(x),
                            isDeprecated = OpenApiMetadataDocumentHelper.GetIsDeprecated(x),
                            deprecatedReasons = OpenApiMetadataDocumentHelper.GetDeprecatedReasons(x)
                        });
                });

            if (_apiSettings.IsFeatureEnabled(ApiFeature.ChangeQueries.GetConfigKeyName()))
            {
                parameterList.Add(new Parameter
                {
                    name = "Snapshot-Identifier",
                    @in = "header",
                    description = "Indicates the Snapshot-Identifier that should be used.",
                    type = "string",
                    required = false
                });
            }

            return parameterList;
        }

        private Operation CreatePutByIdOperation(OpenApiMetadataPathsResource openApiMetadataResource)
        {
            var responses = OpenApiMetadataDocumentHelper.GetWriteOperationResponses(HttpMethod.Put);

            if (_apiSettings.IsFeatureEnabled(ApiFeature.ChangeQueries.GetConfigKeyName()))
            {
                responses.Add(
                    "405",
                    new Response
                    {
                        description =
                            "Method Is Not Allowed. When the Snapshot-Identifier header is present the method is not allowed."
                    });
            }

            return new Operation
            {
                tags = new List<string>
                {
                    OpenApiMetadataDocumentHelper.GetResourcePluralName(openApiMetadataResource.Resource)
                        .ToCamelCase()
                },
                summary = "Updates a resource based on the resource identifier.",
                description = GetDescription(openApiMetadataResource),
                operationId = $"put{openApiMetadataResource.Name}",
                deprecated = openApiMetadataResource.IsDeprecated,
                consumes = new[]
                {
                    _contentTypeStrategy.GetOperationContentType(openApiMetadataResource, ContentTypeUsage.Writable)
                },
                parameters = CreatePutParameters(openApiMetadataResource),
                responses = responses,
                isUpdatable = GetIsUpdatableCustomMetadataValue(openApiMetadataResource)
            };
        }

        private string GetDescription(OpenApiMetadataPathsResource openApiMetadataResource)
        {
            return openApiMetadataResource.Resource.Entity.Identifier.IsUpdatable
                ? "The PUT operation is used to update a resource by identifier. If the resource identifier (\"id\") is provided in the JSON body, it will be ignored. Additionally, if natural key values are being updated by the JSON body, those changes will be applied to the resource and will also cascade through to dependent resources."
                : "The PUT operation is used to update a resource by identifier. If the resource identifier (\"id\") is provided in the JSON body, it will be ignored. Additionally, this API resource is not configured for cascading natural key updates. Natural key values for this resource cannot be changed using PUT operation and will not be modified in the database, and so recommendation is to use POST as that supports upsert behavior.";
        }

        private bool? GetIsUpdatableCustomMetadataValue(OpenApiMetadataPathsResource openApiMetadataResource)
            => openApiMetadataResource.Resource.Entity.Identifier.IsUpdatable ? (bool?) true : null;

        private IList<Parameter> CreatePutParameters(OpenApiMetadataPathsResource openApiMetadataResource)
        {
            IList<Parameter> parameterList = new List<Parameter>();

            parameterList.Add(OpenApiMetadataDocumentHelper.CreateIdParameter());

            parameterList.Add(CreateIfMatchParameter("PUT from updating"));
            parameterList.Add(CreateBodyParameter(openApiMetadataResource));

            return parameterList;
        }

        private Operation CreateDeleteByIdOperation(OpenApiMetadataPathsResource openApiMetadataResource)
        {
            var responses = OpenApiMetadataDocumentHelper.GetWriteOperationResponses(HttpMethod.Delete);

            if (_apiSettings.IsFeatureEnabled(ApiFeature.ChangeQueries.GetConfigKeyName()))
            {
                responses.Add(
                    "405",
                    new Response
                    {
                        description =
                            "Method Is Not Allowed. When the Snapshot-Identifier header is present the method is not allowed."
                    });
            }

            return new Operation
            {
                tags = new List<string>
                {
                    OpenApiMetadataDocumentHelper.GetResourcePluralName(openApiMetadataResource.Resource)
                        .ToCamelCase()
                },
                summary = "Deletes an existing resource using the resource identifier.",
                description =
                    "The DELETE operation is used to delete an existing resource by identifier. If the resource doesn't exist, an error will result (the resource will not be found).",
                operationId = $"delete{openApiMetadataResource.Name}ById",
                deprecated = openApiMetadataResource.IsDeprecated,
                consumes = new[]
                {
                    _contentTypeStrategy.GetOperationContentType(openApiMetadataResource, ContentTypeUsage.Writable)
                },
                parameters = new[]
                {
                    OpenApiMetadataDocumentHelper.CreateIdParameter(),
                    CreateIfMatchParameter("DELETE from removing")
                },
                responses = responses
            };
        }

        private Operation CreateTrackedChangesDeleteOperation(OpenApiMetadataPathsResource openApiMetadataResource)
        {
            var responses = OpenApiMetadataDocumentHelper.GetReadOperationResponses(
                _pathsFactoryNamingStrategy.GetResourceName(openApiMetadataResource, ContentTypeUsage.Readable),
                true, true);

            var parameters = new List<Parameter>
            {
                new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("offset")},
                new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("limit")},
                new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("MinChangeVersion")},
                new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("MaxChangeVersion")},
                new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("totalCount")}
            };

            if (_apiSettings.IsFeatureEnabled(ApiFeature.ChangeQueries.GetConfigKeyName()))
            {
                responses.Add(
                    "410",
                    new Response
                    {
                        description =
                            "Gone. An attempt to connect to the database for the snapshot specified by the Snapshot-Identifier header was unsuccessful (indicating the snapshot may have been removed)."
                    });

                parameters.Add(new Parameter {
                    name = "Snapshot-Identifier",
                    @in = "header",
                    description = "Indicates the Snapshot-Identifier that should be used.",
                    type = "string",
                    required = false
                });
            }

            return new Operation
            {
                tags = new List<string>
                {
                    OpenApiMetadataDocumentHelper.GetResourcePluralName(openApiMetadataResource.Resource)
                        .ToCamelCase()
                },
                summary = "Retrieves deleted resources based on change version.",
                description = "This operation is used to retrieve identifying information about resources that have been deleted.",
                operationId = $"deletes{openApiMetadataResource.Resource.PluralName}",
                deprecated = openApiMetadataResource.IsDeprecated,
                consumes = new[]
                {
                    _contentTypeStrategy.GetOperationContentType(
                        openApiMetadataResource,
                        ContentTypeUsage.Writable)
                },
                parameters = parameters,
                responses = responses
            };
        }

        private Operation CreateTrackedChangesKeyChangeOperation(OpenApiMetadataPathsResource openApiMetadataResource)
        {
            var responses = OpenApiMetadataDocumentHelper.GetReadOperationResponses(
                _pathsFactoryNamingStrategy.GetResourceName(openApiMetadataResource, ContentTypeUsage.Readable),
                true, false, true);

            var parameters = new List<Parameter>
            {
                new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("offset")},
                new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("limit")},
                new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("MinChangeVersion")},
                new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("MaxChangeVersion")},
                new Parameter {@ref = OpenApiMetadataDocumentHelper.GetParameterReference("totalCount")}
            };

            if (_apiSettings.IsFeatureEnabled(ApiFeature.ChangeQueries.GetConfigKeyName()))
            {
                responses.Add(
                    "410",
                    new Response
                    {
                        description =
                            "Gone. An attempt to connect to the database for the snapshot specified by the Snapshot-Identifier header was unsuccessful (indicating the snapshot may have been removed)."
                    });

                parameters.Add(new Parameter
                {
                    name = "Snapshot-Identifier",
                    @in = "header",
                    description = "Indicates the Snapshot-Identifier that should be used.",
                    type = "string",
                    required = false
                });
            }

            return new Operation
            {
                tags = new List<string>
                {
                    OpenApiMetadataDocumentHelper.GetResourcePluralName(openApiMetadataResource.Resource)
                        .ToCamelCase()
                },
                summary = "Retrieves resources key changes based on change version.",
                description = "This operation is used to retrieve identifying information about resources whose key values have been changed.",
                operationId = $"keyChanges{openApiMetadataResource.Resource.PluralName}",
                deprecated = openApiMetadataResource.IsDeprecated,
                consumes = new[]
                {
                    _contentTypeStrategy.GetOperationContentType(
                        openApiMetadataResource,
                        ContentTypeUsage.Writable)
                },
                parameters = parameters,
                responses = responses
            };
        }

        private Operation CreatePostOperation(OpenApiMetadataPathsResource openApiMetadataResource)
        {
            var responses = OpenApiMetadataDocumentHelper.GetWriteOperationResponses(HttpMethod.Post);

            if (_apiSettings.IsFeatureEnabled(ApiFeature.ChangeQueries.GetConfigKeyName()))
            {
                responses.Add(
                    "405",
                    new Response
                    {
                        description =
                            "Method Is Not Allowed. When the Snapshot-Identifier header is present the method is not allowed."
                    });
            }

            return new Operation
            {
                tags = new List<string>
                {
                    OpenApiMetadataDocumentHelper.GetResourcePluralName(openApiMetadataResource.Resource)
                        .ToCamelCase()
                },
                summary = "Creates or updates resources based on the natural key values of the supplied resource.",
                description =
                    "The POST operation can be used to create or update resources. In database terms, this is often referred to as an \"upsert\" operation (insert + update). Clients should NOT include the resource \"id\" in the JSON body because it will result in an error. The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately. It is recommended to use POST for both create and update except while updating natural key of a resource in which case PUT operation must be used.",
                operationId = "post" + openApiMetadataResource.Name,
                deprecated = openApiMetadataResource.IsDeprecated,
                consumes = new[]
                {
                    _contentTypeStrategy.GetOperationContentType(openApiMetadataResource, ContentTypeUsage.Writable)
                },
                parameters = CreatePostParameters(openApiMetadataResource),
                responses =  responses
            };
        }

        private IList<Parameter> CreatePostParameters(OpenApiMetadataPathsResource openApiMetadataResource)
        {
            return new List<Parameter> {CreateBodyParameter(openApiMetadataResource)};
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

        private Parameter CreateBodyParameter(OpenApiMetadataPathsResource openApiMetadataPathsResource)
        {
            var camelCaseName = openApiMetadataPathsResource.Resource.Name.ToCamelCase();

            var referenceName =
                _pathsFactoryNamingStrategy.GetResourceName(openApiMetadataPathsResource, ContentTypeUsage.Writable);

            return new Parameter
            {
                name = camelCaseName,
                description =
                    $"The JSON representation of the \"{camelCaseName}\" resource to be created or updated.",
                @in = "body",
                required = true,
                schema = new Schema {@ref = OpenApiMetadataDocumentHelper.GetDefinitionReference(referenceName)}
            };
        }
    }
}
