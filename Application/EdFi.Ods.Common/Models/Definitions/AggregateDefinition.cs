// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Definitions
{
    public class AggregateDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateDefinition" /> class.
        /// </summary>
        public AggregateDefinition() { }

        /// <summary>
        /// Initializes an <see cref="AggregateDefinition"/> for the domain model.
        /// </summary>
        /// <param name="aggregateRootEntityName">Aggregate root name.</param>
        /// <param name="aggregateEntityNames">An array of aggregates.</param>
        public AggregateDefinition(FullName aggregateRootEntityName, FullName[] aggregateEntityNames)
        {
            AggregateRootEntityName = aggregateRootEntityName;
            AggregateEntityNames = aggregateEntityNames;
        }

        public FullName AggregateRootEntityName { get; set; }

        public FullName[] AggregateEntityNames { get; set; }

        public override string ToString() => AggregateRootEntityName.ToString();
    }
}
