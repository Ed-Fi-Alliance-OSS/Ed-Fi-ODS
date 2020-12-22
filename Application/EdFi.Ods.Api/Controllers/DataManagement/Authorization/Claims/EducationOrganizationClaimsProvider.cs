// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Security;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Claims
{
    public class EducationOrganizationClaimsProvider : IEducationOrganizationClaimsProvider
    {
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        private readonly IEducationOrganizationDiscriminatorProvider _educationOrganizationDiscriminatorProvider;

        public EducationOrganizationClaimsProvider(
            IApiKeyContextProvider apiKeyContextProvider,
            IEducationOrganizationDiscriminatorProvider educationOrganizationDiscriminatorProvider)
        {
            _apiKeyContextProvider = apiKeyContextProvider;
            _educationOrganizationDiscriminatorProvider = educationOrganizationDiscriminatorProvider;
        }
        
        public IList<EducationOrganizationClaims> GetEducationOrganizationClaims()
        {
            var educationOrganizationClaims = _apiKeyContextProvider.GetApiKeyContext()
                .EducationOrganizationIds.Select(
                    claimEducationOrganizationId =>
                    {
                        var discriminator = _educationOrganizationDiscriminatorProvider.GetDiscriminator(claimEducationOrganizationId);

                        return new
                        {
                            EducationOrganizationEntityName = discriminator,
                            EducationOrganizationId = claimEducationOrganizationId,
                        };
                    })
                .GroupBy(x => x.EducationOrganizationEntityName)
                .Select(g => 
                    new EducationOrganizationClaims(
                        g.Key,
                        g.Select(x => x.EducationOrganizationId).ToArray()))
                .ToList();

            return educationOrganizationClaims;
        }
    }
}
