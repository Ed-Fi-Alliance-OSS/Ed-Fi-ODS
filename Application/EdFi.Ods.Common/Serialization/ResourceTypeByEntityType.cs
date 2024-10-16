// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;

namespace EdFi.Ods.Common.Serialization;

public static class ResourceEntityTypeMap
{
    private static readonly ConcurrentDictionary<Type, Type> _resourceTypeByEntityType = new();

    public static void SetTypes(Type entityType, Type resourceType)
    {
        _resourceTypeByEntityType[entityType] = resourceType;
    }

    public static bool TryGetResourceType(Type entityType, out Type resourceType)
    {
        return _resourceTypeByEntityType.TryGetValue(entityType, out resourceType);
    }
}
