// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Database
{
    /// <summary>
    /// The default implementation of <see cref="IDatabaseServerNameProvider"/>, returns the database name replacement token.
    /// </summary>
    public class ConventionSpecificDatabaseServerNameProvider : IDatabaseServerNameProvider
    {
        private readonly IDatabaseNameReplacementTokenProvider _databaseNameReplacementTokenProvider;

        public ConventionSpecificDatabaseServerNameProvider(IDatabaseNameReplacementTokenProvider databaseNameReplacementTokenProvider)
        {
            _databaseNameReplacementTokenProvider = databaseNameReplacementTokenProvider;
        }

        public string GetDatabaseServerName()
        {
            return _databaseNameReplacementTokenProvider.GetReplacementToken();
        }
    }
}
