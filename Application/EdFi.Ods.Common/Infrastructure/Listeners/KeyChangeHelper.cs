// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Specialized;

namespace EdFi.Ods.Common.Infrastructure.Listeners;

public static class KeyChangeHelper
{
    public static bool HasNewKeyValues(object eventEntity)
    {
        return (eventEntity as IHasCascadableKeyValues)?.NewKeyValues != null;
    }

    public static bool TryGetNewKeyValues(object eventEntity, out OrderedDictionary newKeyValues)
    {
        var cascadableEntity = eventEntity as IHasCascadableKeyValues;

        // Quit if this is not an entity that supports cascading updates
        if (cascadableEntity == null)
        {
            newKeyValues = null;

            return false;
        }

        // Quit if there are no modified key values to cascade
        newKeyValues = cascadableEntity.NewKeyValues;

        if (newKeyValues == null)
        {
            return false;
        }

        return true;
    }
}
