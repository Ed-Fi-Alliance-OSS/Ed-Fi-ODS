#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.HttpConfigurators;
using EdFi.Ods.Api.Services.Filters;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Security;

namespace EdFi.Ods.Features.Profiles
{
    public class ProfilesHttpConfigurator : IHttpConfigurator
    {
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        private readonly IProfileResourceNamesProvider _profileResourceNamesProvider;

        public ProfilesHttpConfigurator(IApiKeyContextProvider apiKeyContextProvider,
            IProfileResourceNamesProvider profileResourceNamesProvider)
        {
            _apiKeyContextProvider = Preconditions.ThrowIfNull(apiKeyContextProvider, nameof(apiKeyContextProvider));

            _profileResourceNamesProvider = Preconditions.ThrowIfNull(
                profileResourceNamesProvider, nameof(profileResourceNamesProvider));
        }

        public void Configure(HttpConfiguration config)
        {
            Preconditions.ThrowIfNull(config, nameof(config));

            ConfigureProfilesJsonSerializer(config);
            ConfigureProfilesAuthorizationFilter(config);

            HttpConfigHelper.ConfigureJsonFormatter(config);
        }


        private void ConfigureProfilesJsonSerializer(HttpConfiguration config)
        {
            // Replace existing JSON formatter to be profiles-aware
            var existingJsonFormatter = config.Formatters.SingleOrDefault(f => f is JsonMediaTypeFormatter);

            // Remove the original one
            if (existingJsonFormatter != null)
            {
                config.Formatters.Remove(existingJsonFormatter);
            }

            // Add our customized json formatter, supporting dynamic addition of media types for deserializing messages
            config.Formatters.Insert(0, new ProfilesContentTypeAwareJsonMediaTypeFormatter());
        }

        private void ConfigureProfilesAuthorizationFilter(HttpConfiguration config)
        {
            config.Filters.Add(new ProfilesAuthorizationFilter(_apiKeyContextProvider, _profileResourceNamesProvider));
        }
    }
}
#endif