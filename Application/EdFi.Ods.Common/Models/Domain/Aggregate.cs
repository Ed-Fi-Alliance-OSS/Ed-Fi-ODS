// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Definitions;

namespace EdFi.Ods.Common.Models.Domain
{
    public class Aggregate
    {
        internal Aggregate(DomainModel domainModel, AggregateDefinition aggregateDefinition)
        {
            DomainModel = domainModel;

            FullName = aggregateDefinition.AggregateRootEntityName;

            var memberEntityNames = new[]
                                    {
                                        aggregateDefinition.AggregateRootEntityName
                                    }
                                   .Concat(aggregateDefinition.AggregateEntityNames)
                                   .Distinct()
                                   .ToArray();

            Name = aggregateDefinition.AggregateRootEntityName.Name;
            MemberEntityNames = memberEntityNames;
        }

        public string Name { get; }

        internal FullName[] MemberEntityNames { get; private set; }

        public FullName FullName { get; }

        internal DomainModel DomainModel { get; }

        public Entity AggregateRoot
        {
            get
            {
                Entity entity;

                if (DomainModel.EntityByFullName.TryGetValue(FullName, out entity))
                {
                    return entity;
                }

                throw new Exception($"Could not find entity for aggregate '{Name}'.");
            }
        }

        public IReadOnlyList<Entity> Members
        {
            get
            {
                return MemberEntityNames.Where(
                                             n => DomainModel.EntityByFullName.ContainsKey(n))
                                        .Select(n => DomainModel.EntityByFullName[n])
                                        .ToList();
            }
        }

        internal void AppendExtensionEntities(FullName[] extensionEntities)
        {
            MemberEntityNames = MemberEntityNames
                               .Concat(extensionEntities)
                               .Distinct()
                               .ToArray();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return Name + " [" + string.Join(", ", MemberEntityNames) + "]";
        }
    }
}
