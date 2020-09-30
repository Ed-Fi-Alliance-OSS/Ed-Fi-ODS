// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Common.Configuration
{
    /// <summary>
    /// Defines a facade for working with the connection strings section of an application configuration file.
    /// </summary>
    public interface IConfigConnectionStringsProvider
    {
        /// <summary>
        /// Gets the number of connection strings defined.
        /// </summary>
        int Count { get; }

        IDictionary<string, string> ConnectionStringProviderByName { get; }

        /// <summary>
        /// Get a configured connection string by name.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <returns>The configured connection string.</returns>
        string GetConnectionString(string name);
    }
}
