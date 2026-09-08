// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Security.Authorization;

/// <summary>
/// Carries the name of the tracked changes table a change query reads from, so an authorization
/// filter can restrict what it materializes to the rows that table actually holds. The table name is
/// known by the change queries feature and needed by the authorization filters, which are in
/// assemblies that cannot reference each other.
/// </summary>
public static class TrackedChangesQueryBuilderContextExtensions
{
    private const string TrackedChangesTableNameKey = "TrackedChangesTableName";

    public static void SetTrackedChangesTableName(this IDictionary<string, object> queryBuilderContext, string tableName)
    {
        queryBuilderContext[TrackedChangesTableNameKey] = tableName;
    }

    public static bool TryGetTrackedChangesTableName(this IDictionary<string, object> queryBuilderContext, out string tableName)
    {
        if (queryBuilderContext.TryGetValue(TrackedChangesTableNameKey, out var value) && value is string name)
        {
            tableName = name;

            return true;
        }

        tableName = null;

        return false;
    }
}
