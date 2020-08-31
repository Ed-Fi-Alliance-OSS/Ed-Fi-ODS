﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Utils.Profiles;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies
{
    public interface IOpenApiMetadataPathsFactorySelectorStrategy
    {
        IEnumerable<OpenApiMetadataPathsResource> ApplyStrategy(IEnumerable<OpenApiMetadataResource> openApiMetadataResources);
        bool HasTotalCount { get; }
    }

    public interface IOpenApiMetadataPathsFactoryContentTypeStrategy
    {
        string GetOperationContentType(OpenApiMetadataResource openApiMetadataResource, ContentTypeUsage contentTypeUsage);
    }

    public interface IOpenApiMetadataPathsFactoryNamingStrategy
    {
        string GetResourceName(OpenApiMetadataResource openApiMetadataResource, ContentTypeUsage contentTypeUsage);
    }
}
