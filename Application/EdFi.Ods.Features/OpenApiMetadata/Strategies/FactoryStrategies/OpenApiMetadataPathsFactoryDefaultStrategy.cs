// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Utils.Profiles;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies
{
    public class OpenApiMetadataPathsFactoryDefaultStrategy : IOpenApiMetadataPathsFactoryNamingStrategy
    {
        public string GetResourceName(OpenApiMetadataResource openApiMetadataResource, ContentTypeUsage contentTypeUsage)
        {
            var resource = openApiMetadataResource.Resource;

            var schemaPrefix =
                resource.Entity.DomainModel.SchemaNameMapProvider.GetSchemaMapByPhysicalName(
                             resource.Entity.Schema)
                        .ProperCaseName;

            return OpenApiMetadataDocumentHelper.CamelCaseSegments($"{schemaPrefix}_{resource.Name}");
        }
    }
}
