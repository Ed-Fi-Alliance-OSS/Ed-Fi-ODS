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
using EdFi.Ods.Features.IdentityManagement;

namespace EdFi.Ods.Features.OpenApiMetadataContentProviders
{
    public class IdentityOpenApiContentProvider : IOpenApiContentProvider
    {
        public string RouteName
        {
            get => IdentityManagementConstants.IdentityMetadataRouteName;
        }

        public IEnumerable<OpenApiContent> GetOpenApiContent()
        {
            var assembly = GetType().Assembly;

            return assembly
                .GetManifestResourceNames()
                .Where(x => x.EndsWith($"{IdentityManagementConstants.FeatureName}.json"))
                .Select(
                    x => new OpenApiContent(
                        OpenApiMetadataSections.Other,
                        IdentityManagementConstants.DeprecatedFeatureName,
                        new Lazy<string>(() => assembly.ReadResource(x)),
                        IdentityManagementConstants.IdentityRoutePrefix,
                        string.Empty));
        }
    }
}
