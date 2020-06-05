// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Utils.Profiles;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies
{
    public class SwaggerPathsFactoryCompositeStrategy : ISwaggerPathsFactoryNamingStrategy
    {
        public string GetResourceName(SwaggerResource swaggerResource, ContentTypeUsage contentTypeUsage)
        {
            return swaggerResource.Resource.Name.ToCamelCase();
        }
    }
}
