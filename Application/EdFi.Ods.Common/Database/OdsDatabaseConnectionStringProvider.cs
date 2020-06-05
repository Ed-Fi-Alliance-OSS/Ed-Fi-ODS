// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETSTANDARD
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Common.Database {
    public class OdsDatabaseConnectionStringProvider : IOdsDatabaseConnectionStringProvider
    {
        private readonly IConfigConnectionStringsProvider _configConnectionStringsProvider;

        public OdsDatabaseConnectionStringProvider(IConfigConnectionStringsProvider configConnectionStringsProvider)
        {
            _configConnectionStringsProvider = configConnectionStringsProvider;
        }

        public string GetConnectionString() => _configConnectionStringsProvider.GetConnectionString("EdFi_Ods");
    }
}
#endif
