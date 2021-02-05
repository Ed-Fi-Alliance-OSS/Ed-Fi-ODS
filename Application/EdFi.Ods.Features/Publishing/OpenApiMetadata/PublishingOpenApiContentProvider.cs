// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Utils.Extensions;

namespace EdFi.Ods.Features.Publishing.OpenApiMetadata
{
    public class PublishingOpenApiContentProvider : IOpenApiContentProvider
    {
        public string RouteName
        {
            get => PublishingConstants.PublishingMetadataRouteName;
        }

        public IEnumerable<OpenApiContent> GetOpenApiContent()
        {
            var assembly = GetType().Assembly;

            return assembly
                .GetManifestResourceNames()
                .Where(x => x.EndsWith($"{PublishingConstants.FeatureName}.json"))
                .Select(
                    x => new OpenApiContent(
                        OpenApiMetadataSections.Other,
                        PublishingConstants.FeatureName,
                        new Lazy<string>(() => assembly.ReadResource(x)),
                        PublishingConstants.RoutePrefix,
                        string.Empty));
        }
    }
}
