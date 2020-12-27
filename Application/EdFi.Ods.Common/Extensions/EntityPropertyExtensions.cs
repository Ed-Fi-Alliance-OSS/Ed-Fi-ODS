// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Extensions
{
    public static class EntityPropertyExtensions
    {
        /// <summary>
        /// Gets the UniqueId property for the supplied USI property on a person-type entity.
        /// </summary>
        /// <param name="entityProperty">The USI property on a person-type entity.</param>
        /// <returns>The corresponding UniqueId property.</returns>
        /// <exception cref="ArgumentException">Occurs when the <paramref name="entityProperty"/> supplied is not the USI property.</exception>
        /// <exception cref="Exception">Occurs when the corresponding UniqueId property cannot be found using the expected naming convention.</exception>
        public static EntityProperty CorrespondingUniqueIdProperty(this EntityProperty entityProperty)
        {
            if (!(entityProperty.Entity.IsPersonEntity() && entityProperty.IsIdentifying))
            {
                throw new ArgumentException($"{nameof(entityProperty)} is not a defining USI property on a person-type entity.");
            }

            if (!entityProperty.Entity.PropertyByName.TryGetValue(
                $"{entityProperty.Entity.Name}UniqueId",
                out EntityProperty uniqueIdProperty))
            {
                throw new Exception(
                    $"Unable to find paired UniqueId property for property '{entityProperty.PropertyName}' on entity '{entityProperty.Entity}'.");
            }

            return uniqueIdProperty;
        }
    }
}
