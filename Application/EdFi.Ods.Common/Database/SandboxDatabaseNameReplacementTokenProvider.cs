// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Security;
using System;

namespace EdFi.Ods.Common.Database
{
    public class SandboxDatabaseNameReplacementTokenProvider : IDatabaseNameReplacementTokenProvider
    {
        private readonly IApiKeyContextProvider apiKeyContextProvider;

        public SandboxDatabaseNameReplacementTokenProvider(IApiKeyContextProvider apiKeyContextProvider)
        {
            this.apiKeyContextProvider = apiKeyContextProvider;
        }

        public string GetReplacementToken()
        {
            //Convention: "Ods_Sandbox_" + vendor's api key.
            string apiKey = apiKeyContextProvider.GetApiKeyContext()
                .ApiKey;

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException(
                    "The sandbox ODS database name replacement token cannot be derived because the API key was not set in the current context.");
            }

            return string.Format("Ods_Sandbox_{0}", apiKey);
        }
    }
}
