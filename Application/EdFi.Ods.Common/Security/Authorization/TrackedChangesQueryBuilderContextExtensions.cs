// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Database.Querying;

namespace EdFi.Ods.Common.Security.Authorization;

/// <summary>
/// Carries the rows a change query is about from the change queries feature, which knows them, to the authorization
/// filters, which need them to restrict what they materialize. The two are in assemblies that cannot reference each
/// other.
/// </summary>
public static class TrackedChangesQueryBuilderContextExtensions
{
    private const string TrackedChangesRestrictionKey = "TrackedChangesRestriction";

    public static void SetTrackedChangesRestriction(
        this IDictionary<string, object> queryBuilderContext,
        TrackedChangesRestriction restriction)
    {
        queryBuilderContext[TrackedChangesRestrictionKey] = restriction;
    }

    public static bool TryGetTrackedChangesRestriction(
        this IDictionary<string, object> queryBuilderContext,
        out TrackedChangesRestriction restriction)
    {
        if (queryBuilderContext.TryGetValue(TrackedChangesRestrictionKey, out var value)
            && value is TrackedChangesRestriction trackedChangesRestriction)
        {
            restriction = trackedChangesRestriction;

            return true;
        }

        restriction = null;

        return false;
    }
}
