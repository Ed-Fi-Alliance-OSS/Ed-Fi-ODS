// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Common.Utils.Extensions;

namespace EdFi.Ods.ChangeQueries.Providers
{
    public class ChangeQueriesOpenApiContentProvider : IOpenApiContentProvider
    {
        private const string Name = "ChangeQueries";

        public string RouteName
        {
            get => ChangeQueriesConstants.ChangeQueriesMetadataRouteName;
        }

        public IEnumerable<OpenApiContent> GetOpenApiContent()
        {
            var assembly = GetType()
                .Assembly;

            return assembly
                .GetManifestResourceNames()
                .Where(x => x.EndsWith($"{Name}.json"))
                .Select(
                    x => new OpenApiContent(
                        OpenApiMetadataSections.Other, Name,
                        new Lazy<string>(() => assembly.ReadResource(x)),
                        $"{Name}/v{ChangeQueriesConstants.FeatureVersion}", string.Empty));
        }
    }
}
