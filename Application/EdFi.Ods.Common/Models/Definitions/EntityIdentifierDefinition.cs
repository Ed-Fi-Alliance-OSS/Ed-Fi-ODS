// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Models.Definitions
{
    public class EntityIdentifierDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIdentifierDefinition" /> class.
        /// </summary>
        public EntityIdentifierDefinition() { }

        /// <summary>
        /// Initialized an <see cref="EntityIdentifierDefinition"/> for adding to the domain model.
        /// </summary>
        /// <param name="identifierName">The identifier name.</param>
        /// <param name="identifyingPropertyNames">Additional identifiers.</param>
        /// <param name="constraintNameByDatabaseEngine">The dictionary that provides physical constraint names by database engine.</param>
        /// <param name="isPrimary">If the identifier is the primary key.</param>
        /// <param name="isUpdatable">If the identifier can be updated.</param>
        public EntityIdentifierDefinition(
            string identifierName,
            string[] identifyingPropertyNames,
            bool isPrimary = false,
            bool isUpdatable = false,
            IDictionary<string, string> constraintNameByDatabaseEngine = null)
        {
            IdentifierName = identifierName;
            IdentifyingPropertyNames = identifyingPropertyNames;
            IsPrimary = isPrimary;
            IsUpdatable = isUpdatable;
            ConstraintNames = constraintNameByDatabaseEngine;
        }

        public string IdentifierName { get; set; }

        public string[] IdentifyingPropertyNames { get; set; }

        public bool IsPrimary { get; set; }

        public bool IsUpdatable { get; set; }

        public IDictionary<string, string> ConstraintNames { get; set; }

        public override string ToString() => $"{IdentifierName} ({string.Join(", ", IdentifyingPropertyNames)})";
    }
}
