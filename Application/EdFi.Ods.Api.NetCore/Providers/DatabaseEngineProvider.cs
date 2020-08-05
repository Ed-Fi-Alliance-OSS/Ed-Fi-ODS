// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.NetCore.Providers
{
    public class DatabaseEngineProvider : IDatabaseEngineProvider
    {
        private readonly ApiSettings _apiSettings;

        public DatabaseEngineProvider(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public DatabaseEngine DatabaseEngine { get => _apiSettings.GetDatabaseEngine(); }
    }
}
