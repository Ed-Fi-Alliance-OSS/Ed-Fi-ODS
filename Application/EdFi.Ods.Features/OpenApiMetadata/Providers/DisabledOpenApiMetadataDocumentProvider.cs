﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi;

namespace EdFi.Ods.Features.OpenApiMetadata.Providers
{
    public class DisabledOpenApiMetadataDocumentProvider : IOpenApiMetadataDocumentProvider
    {
        public bool TryGetSwaggerDocument(HttpRequest request, out string document, OpenApiSpecVersion openApiSpecVersion)
        {
            document = null;
            return false;
        }
    }
}
