// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Common.Providers.Criteria;

internal static class AggregateRootCriteriaProviderHelpers
{
    private static string[] _uniqueIds;
    private static readonly ConcurrentDictionary<string, EntityProperty> _entityIdentificationCodePropertyCache = [];

    public static string[] GetUniqueIdProperties(IPersonTypesProvider personTypesProvider)
    {
        return _uniqueIds ??= personTypesProvider.PersonTypes.Select(pt => $"{pt}UniqueId").ToArray();
    }

    public static readonly string[] PropertiesToIgnore =
    {
        "Offset",
        "Limit",
        "TotalCount",
        "Q",
        "SortBy",
        "SortDirection"
    };
    
    public static EntityProperty FindIdentificationCodeProperty(Entity entity)
    {
        var entityFullName = entity.FullName.Name;
        var identificationCodeEntityProperty = _entityIdentificationCodePropertyCache.GetValueOrDefault(entityFullName);

        if (identificationCodeEntityProperty != null)
            return identificationCodeEntityProperty;

        while (entity != null)
        {
            identificationCodeEntityProperty = FindIdentificationCodePropertyInAssociations(entity);

            if (identificationCodeEntityProperty != null)
            {
                _entityIdentificationCodePropertyCache[entityFullName] = identificationCodeEntityProperty;
                return identificationCodeEntityProperty;
            }

            entity = entity.BaseEntity;
        }

        return null;

        EntityProperty FindIdentificationCodePropertyInAssociations(Entity entity)
        {
            return entity.OutgoingAssociations
                .Select(association => association.OtherEntity.PropertyByName)
                .Select(p => p.GetValueOrDefault("IdentificationCode"))
                .FirstOrDefault(x => x != null);
        }
    }
}
