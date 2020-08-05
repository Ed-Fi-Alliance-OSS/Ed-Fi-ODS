// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Definitions;

namespace EdFi.Ods.Common.Models.Domain
{
    public class EntityIdentifier
    {
        private readonly Lazy<IReadOnlyList<EntityProperty>> _identifyingProperties;
        private readonly IReadOnlyList<string> _identifyingPropertyNames;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIdentifier"/> class using the supplied name and properties.
        /// </summary>
        /// <param name="entityIdentifierDefinition">The definition file <seealso cref="EntityIdentifierDefinition"/></param>
        public EntityIdentifier(EntityIdentifierDefinition entityIdentifierDefinition)
        {
            Name = entityIdentifierDefinition.IdentifierName;

            _identifyingPropertyNames = entityIdentifierDefinition.IdentifyingPropertyNames.ToReadOnlyList();
            IsPrimary = entityIdentifierDefinition.IsPrimary;
            IsUpdatable = entityIdentifierDefinition.IsUpdatable;

            _identifyingProperties = new Lazy<IReadOnlyList<EntityProperty>>(
                () =>
                    _identifyingPropertyNames.Select(x => Entity.PropertyByName.GetValueOrThrow(x, "Identifying property '{0}' not found on entity."))
                                             .ToList());

            ConstraintByDatabaseEngine = entityIdentifierDefinition.ConstraintNames;
        }

        /// <summary>
        /// Gets a mapping of the entity's physical constraint names by database engine identifier.
        /// </summary>
        public IDictionary<string, string> ConstraintByDatabaseEngine { get; }

        /// <summary>
        /// The name of the identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets all the properties on the entity that are part of the entity's identity.
        /// </summary>
        public IReadOnlyList<EntityProperty> Properties => _identifyingProperties.Value;

        internal bool IsPrimary { get; }

        /// <summary>
        /// Indicates whether the individual values of the identifier can be updated after entity creation.
        /// </summary>
        public bool IsUpdatable { get; }

        /// <summary>
        /// Gets and sets the reference to the entity to which the identifier applies.
        /// </summary>
        internal Entity Entity { get; set; }
    }
}
