#if NETFRAMEWORK
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
using EdFi.Ods.Common;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;

namespace EdFi.Ods.Features.Profiles
{
    public class ProfilesOpenApiContentProvider : IOpenApiContentProvider
    {
        private readonly IProfileResourceModelProvider _profileResourceModelProvider;
        private readonly IProfileResourceNamesProvider _profileResourceNamesProvider;
        private readonly IResourceModelProvider _resourceModelProvider;

        public ProfilesOpenApiContentProvider(IProfileResourceModelProvider profileResourceModelProvider,
            IProfileResourceNamesProvider profileResourceNamesProvider,
            IResourceModelProvider resourceModelProvider)
        {
            _profileResourceModelProvider =
                Preconditions.ThrowIfNull(profileResourceModelProvider, nameof(profileResourceModelProvider));

            _profileResourceNamesProvider =
                Preconditions.ThrowIfNull(profileResourceNamesProvider, nameof(profileResourceNamesProvider));

            _resourceModelProvider = Preconditions.ThrowIfNull(resourceModelProvider, nameof(resourceModelProvider));
        }

        public string RouteName
        {
            get => MetadataRouteConstants.Profiles;
        }

        public IEnumerable<OpenApiContent> GetOpenApiContent()
        {
            var openApiStrategy = new OpenApiProfileStrategy();

            return _profileResourceNamesProvider
                .GetProfileResourceNames()
                .Select(x => x.ProfileName)
                .Select(
                    x => new SwaggerProfileContext
                    {
                        ProfileName = x,
                        ProfileResourceModel = _profileResourceModelProvider.GetProfileResourceModel(x)
                    })
                .Select(
                    x => new SwaggerDocumentContext(_resourceModelProvider.GetResourceModel())
                    {
                        ProfileContext = x,
                        IsIncludedExtension = r => true
                    })
                .Select(
                    c =>
                        new OpenApiContent(
                            OpenApiMetadataSections.Profiles,
                            c.ProfileContext.ProfileName,
                            new Lazy<string>(() => new SwaggerDocumentFactory(c).Create(openApiStrategy)),
                            RouteConstants.DataManagementRoutePrefix,
                            $"{OpenApiMetadataSections.Profiles}/{c.ProfileContext.ProfileName}"));
        }
    }
}
#endif
