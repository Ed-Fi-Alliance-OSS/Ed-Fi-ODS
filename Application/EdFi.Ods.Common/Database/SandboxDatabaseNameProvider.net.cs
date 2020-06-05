#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.Ods.Common.Security;

namespace EdFi.Ods.Common.Database
{
    [Obsolete("This class will soon be deprecated. Use SandboxDatabaseNameReplacementTokenProvider instead.", false)]
    public class SandboxDatabaseNameProvider : IDatabaseNameProvider
    {
        private readonly IApiKeyContextProvider apiKeyContextProvider;

        public SandboxDatabaseNameProvider(IApiKeyContextProvider apiKeyContextProvider)
        {
            this.apiKeyContextProvider = apiKeyContextProvider;
        }

        public string GetDatabaseName()
        {
            //Convention: "Ods_Sandbox_" + vendor's api key.
            string apiKey = apiKeyContextProvider.GetApiKeyContext()
                                                 .ApiKey;

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException(
                    "The sandbox ODS database name cannot be derived because the API key was not set in the current context.");
            }

            return $"Ods_Sandbox_{apiKey}";
        }
    }
}
#endif