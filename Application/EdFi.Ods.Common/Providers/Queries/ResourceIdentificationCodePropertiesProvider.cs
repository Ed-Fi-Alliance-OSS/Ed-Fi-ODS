// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Providers.Queries;

public class ResourceIdentificationCodePropertiesProvider : IResourceIdentificationCodePropertiesProvider
{
    private readonly ConcurrentDictionary<FullName, List<ResourceProperty>>
        _identificationCodePropertiesByRootResourceFullName = new();

    public bool TryGetIdentificationCodeProperties(Resource resource,
        out List<ResourceProperty> identificationCodeProperties)
    {
        if (resource.Entity == null)
        {
            identificationCodeProperties = null;
            return false;
        }

        identificationCodeProperties = _identificationCodePropertiesByRootResourceFullName.GetOrAdd(
            resource.Entity.FullName, _ =>
            {
                if (TryFindIdentificationCode(resource, out ResourceChildItem identificationCode))
                {
                    return identificationCode.Properties
                        .Where(IsQueryableIdentificationCodeProperty).ToList();
                }

                return null;
            });

        return identificationCodeProperties?.Count > 0;

        bool IsQueryableIdentificationCodeProperty(ResourceProperty property)
        {
            return property.PropertyName.Equals("IdentificationCode")
                   || !property.EntityProperty.IsPredefinedProperty();
        }
    }

    private static bool TryFindIdentificationCode(Resource resource, out ResourceChildItem identificationCodeProperty)
    {
        identificationCodeProperty = null;

        identificationCodeProperty = resource.Collections
            .Select(c => c.ItemType)
            .FirstOrDefault(i => i.PropertyByName.ContainsKey("IdentificationCode"));

        return identificationCodeProperty != null;
    }
}
