﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using Microsoft.OpenApi;

namespace EdFi.Ods.Features.OpenApiMetadata.Factories
{
    public interface IOpenApiMetadataDocumentFactory
    {
        string Create(IOpenApiMetadataResourceStrategy resourceStrategy,
            OpenApiMetadataDocumentContext documentContext,
            OpenApiSpecVersion openApiSpecVersion);
    }
}
