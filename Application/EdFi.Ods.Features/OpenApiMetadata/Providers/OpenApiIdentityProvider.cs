//// SPDX-License-Identifier: Apache-2.0
//// Licensed to the Ed-Fi Alliance under one or more agreements.
//// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
//// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.ChangeQueries.Repositories;

namespace EdFi.Ods.Features.OpenApiMetadata.Providers
{
    public class OpenApiIdentityProvider : IOpenApiIdentityProvider
    {
        private readonly ITrackedChangesIdentifierProjectionsProvider _trackedChangesIdentifierProjectionsProvider;

        public OpenApiIdentityProvider(ITrackedChangesIdentifierProjectionsProvider trackedChangesIdentifierProjectionsProvider)
        {
            _trackedChangesIdentifierProjectionsProvider = trackedChangesIdentifierProjectionsProvider;
        }

        public bool IsIdentity(ResourceProperty resourceProperty)
        {
            return resourceProperty.Parent.Entity == null ? resourceProperty.IsIdentifying :
                GetIdentifyingProperties(resourceProperty.Parent).Any(p => p == resourceProperty.JsonPropertyName);
        }

        public IEnumerable<string> GetIdentifyingProperties(ResourceClassBase resource)
        {
            return _trackedChangesIdentifierProjectionsProvider.GetIdentifierProjections(resource)
                .SelectMany(
                    p => p.IsDescriptorUsage
                        ? [p.JsonPropertyName]
                        : p.SelectColumns.Select(i => i.JsonPropertyName))
                .Distinct();
        }
    }
}
