// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Configuration;

namespace EdFi.Ods.Common.Database
{
    public class OdsDatabaseConnectionStringProvider : IOdsDatabaseConnectionStringProvider
    {
        private readonly IConfigConnectionStringsProvider _configConnectionStringsProvider;

        private readonly Lazy<string> _connectionString;
        private readonly Lazy<string> _readOnlyConnectionString;

        public OdsDatabaseConnectionStringProvider(IConfigConnectionStringsProvider configConnectionStringsProvider)
        {
            _configConnectionStringsProvider = configConnectionStringsProvider;

            _connectionString = new Lazy<string>(() => _configConnectionStringsProvider.GetConnectionString("EdFi_Ods"));

            _readOnlyConnectionString = new Lazy<string>(
                () =>
                {
                    if (_configConnectionStringsProvider.ConnectionStringProviderByName.TryGetValue(
                            "EdFi_Ods_ReadOnly",
                            out var cs))
                    {
                        return cs;
                    }

                    return _configConnectionStringsProvider.GetConnectionString("EdFi_Ods");
                });
        }

        public string GetConnectionString() => _connectionString.Value;

        public string GetReadOnlyConnectionString() => _readOnlyConnectionString.Value;
    }
}
