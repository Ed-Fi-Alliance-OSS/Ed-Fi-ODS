// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Common.Security
{
    public class ApiKeyContextProvider : IApiKeyContextProvider, IHttpContextStorageTransferKeys
    {
        private const string ApiKeyContextKeyName = "ApiKeyContextProvider.ApiKeyContext";
        private readonly IContextStorage _contextStorage;

        public ApiKeyContextProvider(IContextStorage contextStorage)
        {
            _contextStorage = contextStorage;
        }

        public ApiKeyContext GetApiKeyContext()
        {
            return _contextStorage.GetValue<ApiKeyContext>(ApiKeyContextKeyName)
                   ?? ApiKeyContext.Empty;
        }

        public void SetApiKeyContext(ApiKeyContext apiKeyContext)
        {
            _contextStorage.SetValue(ApiKeyContextKeyName, apiKeyContext);
        }

        /// <summary>
        /// Declare the <see cref="IContextStorage"/> keys that are read and written by the component
        /// and should be transferred from <see cref="HttpContext"/> to <see cref="CallContext"/> for background Tasks.
        /// </summary>
        /// <returns>A list of keys to be transferred from <see cref="HttpContext"/> to <see cref="CallContext"/>.</returns>
        IReadOnlyList<string> IHttpContextStorageTransferKeys.GetKeys()
        {
            return new[]
                   {
                       ApiKeyContextKeyName
                   };
        }
    }
}
