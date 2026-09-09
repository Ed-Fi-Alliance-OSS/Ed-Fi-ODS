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

    private const string TrackedChangesCriterionKey = "TrackedChangesCriterion";

    /// <summary>
    /// Records the criterion that selects the kind of change the query is about, expressed against a row of the
    /// tracked changes table and without a table alias (for example "NewBeginDate IS NOT NULL").
    /// </summary>
    /// <remarks>
    /// Deletes and key changes read the same table and are told apart by this criterion. An authorization filter
    /// that restricts what it materializes has to apply it too, or a table full of one kind of change looks like
    /// work to be done when the query will discard all of it.
    /// </remarks>
    public static void SetTrackedChangesCriterion(this IDictionary<string, object> queryBuilderContext, string criterion)
    {
        queryBuilderContext[TrackedChangesCriterionKey] = criterion;
    }

    public static bool TryGetTrackedChangesCriterion(this IDictionary<string, object> queryBuilderContext, out string criterion)
    {
        if (queryBuilderContext.TryGetValue(TrackedChangesCriterionKey, out var value) && value is string criterionText)
        {
            criterion = criterionText;

            return true;
        }

        criterion = null;

        return false;
    }

    /// <summary>
    /// Records the tracked changes table the query reads, schema-qualified and without an alias (for example
    /// "tracked_changes_edfi.StudentSectionAssociation").
    /// </summary>
    /// <remarks>
    /// Set this together with <see cref="SetTrackedChangesCriterion" />. A filter that has the table but not the
    /// criterion cannot tell one kind of change from the other, and the two are consumed as a unit for that reason.
    /// </remarks>
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
