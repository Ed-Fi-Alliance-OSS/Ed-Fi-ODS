// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Database
{
    /// <summary>
    /// Defines an interface for creating a database name (for inclusion in a connection string).
    /// </summary>
    public interface IDatabaseNameProvider
    {
        /// <summary>
        /// Gets the database name.
        /// </summary>
        /// <returns>The database name.</returns>
        string GetDatabaseName();
    }
}
