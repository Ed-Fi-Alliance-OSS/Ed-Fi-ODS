// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Models.Domain
{
    /// <summary>
    /// Provides an abstraction over association and entity properties.
    /// </summary>
    public abstract class DomainPropertyBase : IHasNameContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainPropertyBase" /> class using the specified property definition.
        /// </summary>
        /// <param name="entityPropertyDefinition"></param>
        protected DomainPropertyBase(EntityPropertyDefinition entityPropertyDefinition)
        {
            PropertyName = entityPropertyDefinition.PropertyName;
            PropertyType = entityPropertyDefinition.PropertyType;
            Description = entityPropertyDefinition.Description?.Trim();
            IsIdentifying = entityPropertyDefinition.IsIdentifying;
            IsServerAssigned = entityPropertyDefinition.IsServerAssigned;
            ColumnNameByDatabaseEngine = entityPropertyDefinition.ColumnNames;
        }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Gets the type of the property.
        /// </summary>
        public PropertyType PropertyType { get; }

        /// <summary>
        /// Gets the documented description of the property.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Indicates whether or not the property contributes to the domain identity of the entity on which it is defined.
        /// </summary>
        public bool IsIdentifying { get; }

        /// <summary>
        /// Indicates whether or not the property value is assigned by the server automatically.
        /// </summary>
        public bool IsServerAssigned { get; }

        /// <summary>
        /// Gets a reference to the <see cref="Domain.Entity"/> associated with the property.
        /// </summary>
        public Entity Entity { get; internal set; }

        /// <summary>
        /// Overrides the method implementation to return the name of the property.
        /// </summary>
        /// <returns>The name of the property.</returns>
        public override string ToString() => PropertyName;

        FullName IHasNameContext.ParentFullName
        {
            get => Entity.FullName;
        }

        /// <summary>
        /// Gets the mapping of the entity property's physical column names by database engine identifier.
        /// </summary>
        public IDictionary<DatabaseEngine, string> ColumnNameByDatabaseEngine { get; }
    }
}