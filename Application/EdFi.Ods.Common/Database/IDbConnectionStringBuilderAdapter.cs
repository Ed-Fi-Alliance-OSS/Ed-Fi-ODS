// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Common;

namespace EdFi.Ods.Common.Database
{
    /// <summary>
    /// Defines properties for manipulating components of a connection string in a generalized
    /// manner, abstracting the caller from the database-specific implementations of the
    /// <see cref="DbConnectionStringBuilder" /> class.
    /// </summary>
    public interface IDbConnectionStringBuilderAdapter
    {
        /// <summary>
        /// Gets or sets the database connection string.
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the database name in the connection string.
        /// </summary>
        string DatabaseName { get; set; }
    }
}
