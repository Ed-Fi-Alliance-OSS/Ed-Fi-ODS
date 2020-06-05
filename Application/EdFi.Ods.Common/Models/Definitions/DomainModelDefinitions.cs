// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Models.Definitions
{
    public class DomainModelDefinitions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainModelDefinitions" /> class.
        /// </summary>
        public DomainModelDefinitions() { }

        public DomainModelDefinitions(
            SchemaDefinition schemaDefinition,
            AggregateDefinition[] aggregateDefinitions,
            EntityDefinition[] entityDefinitions,
            AssociationDefinition[] associationDefinitions,
            AggregateExtensionDefinition[] aggregateExtensionDefinitions = null)
        {
            SchemaDefinition = schemaDefinition;
            AggregateDefinitions = aggregateDefinitions;
            EntityDefinitions = entityDefinitions;
            AssociationDefinitions = associationDefinitions;
            AggregateExtensionDefinitions = aggregateExtensionDefinitions;
        }

        public SchemaDefinition SchemaDefinition { get; set; }

        public AggregateDefinition[] AggregateDefinitions { get; set; }

        public AggregateExtensionDefinition[] AggregateExtensionDefinitions { get; set; }

        public EntityDefinition[] EntityDefinitions { get; set; }

        public AssociationDefinition[] AssociationDefinitions { get; set; }
    }
}
