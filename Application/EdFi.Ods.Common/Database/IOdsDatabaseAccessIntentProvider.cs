// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Database
{
    /// <summary>
    /// Defines a method for obtaining a <see cref="DatabaseAccessIntent"/> that describes the the database access intent of the current request
    /// ReadOnly or ReadWrite
    /// </summary>
    public interface IOdsDatabaseAccessIntentProvider
    {
        /// <summary>
        /// Gets the Database Access Intent of the current request based on a convention of the URI name starting with "read" for ReadOnly operations
        /// </summary>
        /// <returns>The <see cref="DatabaseAccessIntent"/> database access intent of the current request</returns>
        public DatabaseAccessIntent GetDatabaseAccessIntent();
    }
}
