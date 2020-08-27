// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Services.Metadata.Models;
using EdFi.Ods.Api.Services.Metadata.Strategies.FactoryStrategies;
using EdFi.Ods.Common.Extensions;
using Swashbuckle.Swagger;

namespace EdFi.Ods.Api.Services.Metadata.Factories
{
    public class SwaggerTagsFactory
    {
        private readonly ISwaggerFactoryResourceFilterStrategy _filterStrategy;

        public SwaggerTagsFactory(ISwaggerFactoryResourceFilterStrategy filterStrategy)
        {
            _filterStrategy = filterStrategy;
        }

        public IList<Tag> Create(IEnumerable<SwaggerResource> swaggerResources)
        {
            return swaggerResources.Where(x => _filterStrategy.ShouldInclude(x.Resource))
                                   .Select(
                                        x => new Tag
                                             {
                                                 name = SwaggerDocumentHelper.GetResourcePluralName(x.Resource)
                                                                             .ToCamelCase(),
                                                 description = x.Description
                                             })
                                   .GroupBy(t => t.name)
                                   .Select(g => g.First())
                                   .OrderBy(x => x.name)
                                   .ToList();
        }
    }
}
