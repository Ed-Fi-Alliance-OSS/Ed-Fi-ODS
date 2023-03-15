// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Common.Configuration;

namespace EdFi.Ods.Common.Database
{
    /// <summary>
    /// Provides a method for getting an implementation of
    /// <see cref="StringComparer" /> 
    /// that aligns with the default collation of the database engine currently in use.
    /// </summary>
    public class DatabaseEngineSpecificStringComparerProvider : IDatabaseEngineSpecificEqualityComparerProvider<string>
    {
        private readonly IEqualityComparer<string> _stringComparer;

        public DatabaseEngineSpecificStringComparerProvider(DatabaseEngine databaseEngine)
        {
            if (databaseEngine == DatabaseEngine.SqlServer)
            {
                _stringComparer = StringComparer.OrdinalIgnoreCase;
            }
            else if (databaseEngine == DatabaseEngine.Postgres)
            {
                _stringComparer = StringComparer.Ordinal;
            }
            else
            {
                throw new NotSupportedException($"The database engine '{databaseEngine.DisplayName}' is not supported.");
            }
        }

        /// <summary>
        /// Returns an instance of <see cref="StringComparer" /> 
        /// that aligns with the default collation of the database engine currently in use.
        /// </summary>
        /// <remarks>
        /// To match case-sensitivity of the default database collation, this returns 
        /// <see cref="StringComparer.Ordinal" /> when Postgres is in use and 
        /// <see cref="StringComparer.OrdinalIgnoreCase" /> when SqlServer is in use.
        /// </remarks>
        public IEqualityComparer<string> GetEqualityComparer()
        {
            return _stringComparer;
        }
    }
}

