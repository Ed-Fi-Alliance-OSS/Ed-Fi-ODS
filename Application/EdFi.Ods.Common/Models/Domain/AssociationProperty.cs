// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Models.Definitions;

namespace EdFi.Ods.Common.Models.Domain
{
    /// <summary>
    /// Represents a property definition on an association that may or may not be "upgraded" to
    /// an <see cref="Domain.EntityProperty"/> on the target <see cref="Entity"/>.
    /// </summary>
    public class AssociationProperty : DomainPropertyBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssociationProperty" /> class using the specified property definition.
        /// </summary>
        /// <param name="entityPropertyDefinition">The definition of the property on the association.</param>
        public AssociationProperty(EntityPropertyDefinition entityPropertyDefinition)
            : base(entityPropertyDefinition) { }

        /// <summary>
        /// Gets the actualized property on the target entity (which may exhibit different properties
        /// if the property represents a key that has been unified with another association).
        /// </summary>
        public EntityProperty EntityProperty
        {
            get
            {
                EntityProperty property;

                if (!Entity.PropertyByName.TryGetValue(PropertyName, out property))
                    throw new Exception($"Unable to find property '{PropertyName}' on entity '{Entity.Name}'.");

                return property;
            }
        }
    }
}