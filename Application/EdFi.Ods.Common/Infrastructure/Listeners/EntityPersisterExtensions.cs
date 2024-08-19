// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using NHibernate.Persister.Entity;

namespace EdFi.Ods.Common.Infrastructure.Listeners;

public static class EntityPersisterExtensions
{
    public static int GetPropertyIndex(this IEntityPersister persister, string propertyName)
    {
        return Array.IndexOf(persister.PropertyNames, propertyName);
    }
        
    public static void Set(this IEntityPersister persister, object[] state, string propertyName, object value)
    {
        var propertyIndex = Array.IndexOf(persister.PropertyNames, propertyName);
        Set(state, propertyIndex, value);
    }

    private static void Set(object[] state, int propertyIndex, object value)
    {
        if (propertyIndex == -1)
        {
            return;
        }

        state[propertyIndex] = value;
    }

    public static T Get<T>(this IEntityPersister persister, object[] state, string propertyName)
    {
        var index = Array.IndexOf(persister.PropertyNames, propertyName);

        if (index == -1)
        {
            return default(T);
        }

        return (T) state[index];
    }
}
