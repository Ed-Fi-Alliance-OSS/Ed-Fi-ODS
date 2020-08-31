// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Utils.Profiles;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies
{
    public interface ISwaggerPathsFactorySelectorStrategy
    {
        IEnumerable<SwaggerPathsResource> ApplyStrategy(IEnumerable<SwaggerResource> swaggerResources);
        bool HasTotalCount { get; }
    }

    public interface ISwaggerPathsFactoryContentTypeStrategy
    {
        string GetOperationContentType(SwaggerResource swaggerResource, ContentTypeUsage contentTypeUsage);
    }

    public interface ISwaggerPathsFactoryNamingStrategy
    {
        string GetResourceName(SwaggerResource swaggerResource, ContentTypeUsage contentTypeUsage);
    }
}
