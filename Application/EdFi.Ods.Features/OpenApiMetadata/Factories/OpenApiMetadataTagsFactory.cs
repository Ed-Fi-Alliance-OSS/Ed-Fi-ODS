// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies;

namespace EdFi.Ods.Features.OpenApiMetadata.Factories
{
    public class OpenApiMetadataTagsFactory
    {
        private readonly IOpenApiMetadataFactoryResourceFilterStrategy _filterStrategy;

        public OpenApiMetadataTagsFactory(IOpenApiMetadataFactoryResourceFilterStrategy filterStrategy)
        {
            _filterStrategy = filterStrategy;
        }

        public IList<Tag> Create(IEnumerable<OpenApiMetadataResource> openApiMetadataResources)
        {
            return openApiMetadataResources.Where(x => _filterStrategy.ShouldInclude(x.Resource))
                .Select(
                    x => new Tag
                    {
                        name = OpenApiMetadataDocumentHelper.GetResourcePluralName(x.Resource).ToCamelCase(),
                        description = x.Description
                    })
                .GroupBy(t => t.name)
                .Select(g => g.First())
                .OrderBy(x => x.name)
                .ToList();
        }
    }
}
