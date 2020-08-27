// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Definitions;

namespace EdFi.Ods.Common.Models.Domain
{
    public class AggregateExtension
    {
        private readonly DomainModel _domainModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateExtension" /> class.
        /// </summary>
        public AggregateExtension() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateExtension" /> class using the supplied extension entity names.
        /// </summary>
        public AggregateExtension(DomainModel domainModel, AggregateExtensionDefinition aggregateExtensionDefinition)
        {
            _domainModel = domainModel;

            AggregateRootEntityName = aggregateExtensionDefinition.AggregateRootEntityName;
            ExtensionEntityNames = aggregateExtensionDefinition.ExtensionEntityNames;
        }

        /// <summary>
        /// Gets the full name of the Ed-Fi Standard aggregate root entity identifying the aggregate to which the extension entities are to be added.
        /// </summary>
        public FullName AggregateRootEntityName { get; set; }

        /// <summary>
        /// Gets the full names of the extension entities to be added to the aggregate.
        /// </summary>
        public FullName[] ExtensionEntityNames { get; set; }
    }
}
