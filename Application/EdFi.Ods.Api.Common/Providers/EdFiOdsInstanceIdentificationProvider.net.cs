// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.Api.Common.Providers
{
    /// <summary>
    /// Implements an ODS identification provider that returns unique values based on the
    /// GetHashCode return value for the ODS connection string currently in context.
    /// </summary>
    public class EdFiOdsInstanceIdentificationProvider : IEdFiOdsInstanceIdentificationProvider
    {
        private readonly IDatabaseConnectionStringProvider _odsDatabaseConnectionStringProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="EdFiOdsInstanceIdentificationProvider"/> class
        /// the specified ODS database connection string provider.
        /// </summary>
        /// <param name="odsDatabaseConnectionStringProvider">The ODS connection string provider.</param>
        public EdFiOdsInstanceIdentificationProvider(IDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider)
        {
            _odsDatabaseConnectionStringProvider = odsDatabaseConnectionStringProvider;
        }

        /// <summary>
        /// Gets the identification value for the ODS currently in context.
        /// </summary>
        /// <returns>The identification value.</returns>
        public int GetInstanceIdentification()
            => _odsDatabaseConnectionStringProvider
                .GetConnectionString()
                .GetHashCode();
    }
}
#endif