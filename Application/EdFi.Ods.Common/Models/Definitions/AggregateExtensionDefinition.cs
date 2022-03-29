// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Definitions
{
    public class AggregateExtensionDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateExtensionDefinition" /> class.
        /// </summary>
        public AggregateExtensionDefinition()
        {
            ExtensionEntityNames = new FullName[]
                                   { };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateExtensionDefinition" /> class using the supplied extension entity names.
        /// </summary>
        /// <param name="aggregateRootEntityName">The full name of the Ed-Fi Standard aggregate root entity identifying the aggregate to which the extension entities are to be added.</param>
        /// <param name="extensionEntityNames">The full names of the extension entities to be added to the aggregate.</param>
        public AggregateExtensionDefinition(FullName aggregateRootEntityName, FullName[] extensionEntityNames)
        {
            AggregateRootEntityName = aggregateRootEntityName;
            ExtensionEntityNames = extensionEntityNames;
        }

        /// <summary>
        /// Gets the full name of the Ed-Fi Standard aggregate root entity identifying the aggregate to which the extension entities are to be added.
        /// </summary>
        public FullName AggregateRootEntityName { get; set; }

        /// <summary>
        /// Gets the full names of the extension entities to be added to the aggregate.
        /// </summary>
        public FullName[] ExtensionEntityNames { get; set; }

        public override string ToString() => $"{AggregateRootEntityName} (extensions)";
    }
}
