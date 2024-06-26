﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Common.Security
{
    public class ApiClientContextProvider : IApiClientContextProvider
    {
        private const string ApiClientContextKeyName = "ApiClientContextProvider.ApiClientContext";

        private readonly IContextStorage _contextStorage;

        public ApiClientContextProvider(IContextStorage contextStorage)
        {
            _contextStorage = contextStorage;
        }

        public ApiClientContext GetApiClientContext()
        {
            return _contextStorage.GetValue<ApiClientContext>(ApiClientContextKeyName)
                   ?? ApiClientContext.Empty;
        }

        public void SetApiClientContext(ApiClientContext apiClientContext)
        {
            _contextStorage.SetValue(ApiClientContextKeyName, apiClientContext);
        }
    }
}
