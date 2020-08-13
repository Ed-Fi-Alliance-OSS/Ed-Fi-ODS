// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Providers;

#if NETCOREAPP
namespace EdFi.Ods.Api.Providers
{
    public class EdFiOdsInstanceIdentificationProvider : IEdFiOdsInstanceIdentificationProvider
    {
        private readonly IOdsDatabaseConnectionStringProvider _odsDatabaseConnectionStringProvider;

        public EdFiOdsInstanceIdentificationProvider(IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider)
        {
            _odsDatabaseConnectionStringProvider = odsDatabaseConnectionStringProvider;
        }

        public int GetInstanceIdentification()
            => _odsDatabaseConnectionStringProvider
                .GetConnectionString()
                .GetHashCode();
    }
}
#endif
