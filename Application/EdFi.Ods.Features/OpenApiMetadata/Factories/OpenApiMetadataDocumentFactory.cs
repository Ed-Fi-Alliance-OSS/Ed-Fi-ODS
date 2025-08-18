// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Providers.Queries;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.Ods.Features.OpenApiMetadata.Providers;
using EdFi.Ods.Features.OpenApiMetadata.Strategies;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using log4net;
using Microsoft.FeatureManagement;
using Microsoft.OpenApi;
using Newtonsoft.Json;

namespace EdFi.Ods.Features.OpenApiMetadata.Factories
{
    public class OpenApiMetadataDocumentFactory : IOpenApiMetadataDocumentFactory
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(OpenApiMetadataDocumentFactory));
        private readonly IFeatureManager _featureManager;
        private readonly IDefaultPageSizeLimitProvider _defaultPageSizeLimitProvider;
        private readonly IOpenApiIdentityProvider _openApiIdentityProvider;
        private readonly IOpenApiUpconversionProvider _openApiUpconversionProvider;
        private readonly IResourceIdentificationCodePropertiesProvider _resourceIdentificationCodePropertiesProvider;
        private readonly IOpenApiMetadataDomainFilter _domainFilter;

        public OpenApiMetadataDocumentFactory(
            IFeatureManager featureManager,
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider,
            IOpenApiUpconversionProvider openApiUpconversionProvider,
            IResourceIdentificationCodePropertiesProvider resourceIdentificationCodePropertiesProvider,
            IOpenApiIdentityProvider openApiIdentityProvider,
            IOpenApiMetadataDomainFilter domainFilter)
        {
            _featureManager = featureManager;
            _defaultPageSizeLimitProvider = defaultPageSizeLimitProvider;
            _openApiIdentityProvider = openApiIdentityProvider;
            _resourceIdentificationCodePropertiesProvider = resourceIdentificationCodePropertiesProvider;
            _openApiUpconversionProvider = openApiUpconversionProvider;
            _domainFilter = domainFilter;
        }

        public string Create(IOpenApiMetadataResourceStrategy resourceStrategy, OpenApiMetadataDocumentContext documentContext, OpenApiSpecVersion openApiSpecVersion)
        {
            try
            {
                var parametersFactory = new OpenApiMetadataParametersFactory(_defaultPageSizeLimitProvider);

                var definitionsFactory =
                    OpenApiMetadataDocumentFactoryHelper.CreateOpenApiMetadataDefinitionsFactory(documentContext,
                        _openApiIdentityProvider, _featureManager);

                var responsesFactory = new OpenApiMetadataResponsesFactory();

                var pathsFactory =
                    OpenApiMetadataDocumentFactoryHelper.CreateOpenApiMetadataPathsFactory(
                        documentContext, _openApiIdentityProvider, _resourceIdentificationCodePropertiesProvider, _featureManager, _domainFilter);

                var tagsFactory =
                    OpenApiMetadataDocumentFactoryHelper.CreateOpenApiMetadataTagsFactory(documentContext);

                var resources = resourceStrategy.GetFilteredResources(documentContext)
                    .ToList();

                var openApiMetadataDocument = new OpenApiMetadataDocument
                {
                    info = new Info
                    {
                        title = "Ed-Fi Operational Data Store API",
                        version = $"{ApiVersionConstants.Ods}",
                        description =
                            "The Ed-Fi ODS / API enables applications to read and write education data stored in an Ed-Fi ODS through a secure REST interface. \n***\n > *Note: Consumers of ODS / API information should sanitize all data for display and storage. The ODS / API provides reasonable safeguards against cross-site scripting attacks and other malicious content, but the platform does not and cannot guarantee that the data it contains is free of all potentially harmful content.* \n***\n"
                    },
                    host = "%HOST%",
                    basePath = "%BASE_PATH%",
                    schemes = new string[]{
                        "%SCHEME%"
                    },
                    securityDefinitions =
                        new Dictionary<string, SecurityScheme>
                        {
                            {
                                "oauth2_client_credentials", new SecurityScheme
                                {
                                    type = "oauth2",
                                    description =
                                        "Ed-Fi ODS/API OAuth 2.0 Client Credentials Grant Type authorization",
                                    flow = "application",
                                    tokenUrl = "%TOKEN_URL%",
                                    scopes = new Dictionary<string, string>()
                                }
                            }
                        },
                    security =
                        new List<IDictionary<string, IEnumerable<string>>>
                        {
                            new Dictionary<string, IEnumerable<string>> {{"oauth2_client_credentials", Array.Empty<string>()}}
                        },
                    consumes = documentContext.IsCompositeContext
                        ? null
                        : OpenApiMetadataDocumentHelper.GetConsumes(),
                    produces = OpenApiMetadataDocumentHelper.GetProduces(),
                    tags = tagsFactory.Create(resources),
                    paths = pathsFactory.Create(resources, documentContext.IsCompositeContext),
                    definitions = definitionsFactory.Create(resources),
                    parameters = parametersFactory.Create(documentContext.IsCompositeContext),
                    responses = responsesFactory.Create(documentContext.IsCompositeContext)
                };
                var jsonString = JsonConvert.SerializeObject(
                    openApiMetadataDocument,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                if (openApiSpecVersion == OpenApiSpecVersion.OpenApi3_0)
                {
                    jsonString = _openApiUpconversionProvider.GetUpconvertedOpenApiJson(jsonString);
                }

                return jsonString;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
    }
}
