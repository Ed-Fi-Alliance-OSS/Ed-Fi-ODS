// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Providers;

namespace EdFi.Ods.Api.Providers
{
    /// <summary>
    /// Implements an IEdFiOdsInstanceIdentificationProvider that returns a stable unsigned-long value
    /// using the xxHash3 algorithm on the ODS connection string.
    /// </summary>
    /// <remarks>Unlike the GetHashCode method implementation for strings, the xxHash3 algorithm is stable
    /// across process runs.</remarks>
    public class EdFiOdsInstanceIdentificationProvider : IEdFiOdsInstanceIdentificationProvider
    {
        private readonly IOdsDatabaseConnectionStringProvider _odsDatabaseConnectionStringProvider;

        public EdFiOdsInstanceIdentificationProvider(IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider)
        {
            _odsDatabaseConnectionStringProvider = odsDatabaseConnectionStringProvider;
        }

        /// <inheritdoc cref="IEdFiOdsInstanceIdentificationProvider.GetInstanceIdentification" />
        public ulong GetInstanceIdentification()
            => _odsDatabaseConnectionStringProvider
                .GetConnectionString()
                .GetXxHash3Code();
    }
}
