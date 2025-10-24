// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Database;

/// <summary>
/// Executes lightweight queries to resolve discriminator values for abstract entities,
/// enabling more specific dependent resource conflict messages.
/// </summary>
public interface IDiscriminatorResolver
{
    /// <summary>
    /// Queries distinct discriminator values from an abstract base table using parent entity keys.
    /// </summary>
    /// <param name="schema">Database schema name (e.g., "edfi")</param>
    /// <param name="tableName">Abstract base table name</param>
    /// <param name="parentEntity">Domain entity representing the parent being deleted</param>
    /// <param name="parentId">Surrogate Id (GUID) of the parent entity</param>
    /// <param name="maxResults">Maximum discriminators to return (default 1 for performance)</param>
    /// <returns>List of distinct discriminator values, or empty if none found</returns>
    IReadOnlyList<string> GetDistinctDiscriminators(
        string schema,
        string tableName,
        Entity parentEntity,
        Guid parentId,
        int maxResults = 1);
}
