// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Security;

namespace EdFi.Ods.Common.Database
{
    public class DistrictSpecificDatabaseNameReplacementTokenProvider : IDatabaseNameReplacementTokenProvider
    {
        private readonly IApiKeyContextProvider _apiKeyContextProvider;

        public DistrictSpecificDatabaseNameReplacementTokenProvider(IApiKeyContextProvider apiKeyContextProvider)
        {
            _apiKeyContextProvider = apiKeyContextProvider;
        }

        public string GetReplacementToken()
        {
            List<int> availableEducationOrganizations = _apiKeyContextProvider.GetApiKeyContext()?.EducationOrganizationIds?.ToList() ??
                                                        new List<int>();

            if (!availableEducationOrganizations.Any())
            {
                throw new InvalidOperationException(
                    "The district-specific ODS database name replacement token cannot be derived because no available education organizations were found in the current context. Ensure the api client is correctly configured for exactly one local education agency to use this token provider.");
            }
            else if (availableEducationOrganizations.Count > 1)
            {
                throw new InvalidOperationException(
                    "The district-specific ODS database name replacement token cannot be derived because more than one available education organization was found in the current context. Ensure the api client is correctly configured for exactly one local education agency to use this token provider.");
            }

            //Convention: "Ods_" + local education agency id
            return $"Ods_{availableEducationOrganizations.Single()}";
        }
    }
}
