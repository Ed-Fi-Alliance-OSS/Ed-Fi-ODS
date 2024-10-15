// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Providers.Queries;

public class EntityIdentificationCodeQueryablePropertiesProvider : IEntityIdentificationCodeQueryablePropertiesProvider
{
    private readonly ConcurrentDictionary<FullName, Dictionary<string, EntityProperty>>
        _identificationCodeParameterDictByEntityFullName = new();

    public bool TryGetIdentificationCodePropertiesByParameterName(Entity entity,
        out Dictionary<string, EntityProperty> identificationCodePropertiesByParameterName) {
        identificationCodePropertiesByParameterName = _identificationCodeParameterDictByEntityFullName.GetOrAdd(entity.FullName, _ => 
        {
            if (TryFindIdentificationCodeProperty(entity, out EntityProperty identificationCodeProperty))
            {
                return identificationCodeProperty.Entity.Properties
                    .Where(IsQueryableIdentificationCodeProperty)
                    .ToDictionary(GetParameterNameForIdentificationCodeProperty, StringComparer.OrdinalIgnoreCase);
            }
            
            return null;
        });
        
        return identificationCodePropertiesByParameterName.Count > 0;
        
        string GetParameterNameForIdentificationCodeProperty(EntityProperty property)
        {
            return property.DescriptorEntity?.Name ?? property.PropertyName;
        }
        
        bool IsQueryableIdentificationCodeProperty(EntityProperty property)
        {
            return property.PropertyName.Equals("IdentificationCode") ||
                   !(property.IsPredefinedProperty());
        }
    }

    private static bool TryFindIdentificationCodeProperty(Entity entity, out EntityProperty identificationCodeProperty)
    {
        identificationCodeProperty = null;
        
        while (entity != null && !TryFindIdentificationCodePropertyInChildren(entity, out identificationCodeProperty))
        {
            entity = entity.BaseEntity;
        }
        
        return identificationCodeProperty != null;

        bool TryFindIdentificationCodePropertyInChildren(Entity entity, out EntityProperty identificationCodeProperty)
        {
            identificationCodeProperty = entity.NavigableChildren
                .Select(association => association.OtherEntity.PropertyByName)
                .Select(p => p.GetValueOrDefault("IdentificationCode"))
                .FirstOrDefault(x => x != null);

            return identificationCodeProperty != null;
        }
    }
}
