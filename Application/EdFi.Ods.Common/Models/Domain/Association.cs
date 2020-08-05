// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Utils.Extensions;

namespace EdFi.Ods.Common.Models.Domain
{
    public class Association
    {
        private readonly DomainModel _domainModel;

        private readonly Lazy<AssociationProperty[]> _primaryEntityAssociationProperties;

        private readonly Lazy<AssociationProperty[]> _secondaryEntityAssociationProperties;

        internal Association(DomainModel domainModel, AssociationDefinition associationDefinition)
        {
            if (associationDefinition.PrimaryEntityProperties.Length != associationDefinition.SecondaryEntityProperties.Length)
                throw new Exception("The association definition is invalid because a different number of properties were provided for the primary and secondary ends of the association.");

            _domainModel = domainModel;

            FullName = associationDefinition.FullName;

            var primaryEntityAssociationProperties = associationDefinition.PrimaryEntityProperties
                                                               .Select(x => new AssociationProperty(x))
                                                               .ToArray();

            // Identifying associations mean that the properties in the receiving entity must also be identifying
            if (associationDefinition.IsIdentifying)
            {
                // Coerce each secondary entity property definition to be identifying
                associationDefinition.SecondaryEntityProperties.ForEach(p => p.IsIdentifying = true);
            }

            var secondaryEntityAssociationProperties = associationDefinition.SecondaryEntityProperties
                                                                 .Select(x => new AssociationProperty(x))
                                                                 .ToArray();

            Cardinality = associationDefinition.Cardinality;

            PrimaryEntityFullName = associationDefinition.PrimaryEntityFullName;
            SecondaryEntityFullName = associationDefinition.SecondaryEntityFullName;

            _primaryEntityAssociationProperties = new Lazy<AssociationProperty[]>(
                () =>
                {
                    Entity primaryEntity;

                    if (!_domainModel.EntityByFullName.TryGetValue(PrimaryEntityFullName, out primaryEntity))
                        throw new Exception($"The primary entity '{PrimaryEntityFullName}' could not be found.");

                    primaryEntityAssociationProperties.ForEach(p => p.Entity = primaryEntity);

                    return primaryEntityAssociationProperties;
                });

            _secondaryEntityAssociationProperties = new Lazy<AssociationProperty[]>(
                () =>
                {
                    Entity secondaryEntity;

                    if (!_domainModel.EntityByFullName.TryGetValue(SecondaryEntityFullName, out secondaryEntity))
                        throw new Exception($"The secondary entity '{SecondaryEntityFullName}' could not be found.");

                    secondaryEntityAssociationProperties.ForEach(p => p.Entity = secondaryEntity);

                    return secondaryEntityAssociationProperties;
                });

            IsIdentifying = associationDefinition.IsIdentifying;
            IsRequired = associationDefinition.IsRequired;
            IsRequiredCollection = associationDefinition.Cardinality == Cardinality.OneToOneOrMore;
            ConstraintByDatabaseEngine = associationDefinition.ConstraintNames;
        }

        /// <summary>
        /// Gets a mapping of the entity's physical constraint names by database engine identifier.
        /// </summary>
        public IDictionary<string, string> ConstraintByDatabaseEngine { get; }

        public FullName FullName { get; }

        public FullName PrimaryEntityFullName { get; }

        public FullName SecondaryEntityFullName { get; }

        public Cardinality Cardinality { get; }

        public bool IsIdentifying { get; }

        public bool IsRequiredCollection { get; }

        public Entity PrimaryEntity
        {
            get
            {
                Entity entity;

                _domainModel.EntityByFullName.TryGetValue(
                    PrimaryEntityFullName,
                    out entity);

                return entity;
            }
        }

        public AssociationProperty[] PrimaryEntityAssociationProperties => _primaryEntityAssociationProperties.Value;

        public Entity SecondaryEntity
        {
            get
            {
                Entity entity;

                _domainModel.EntityByFullName.TryGetValue(
                    SecondaryEntityFullName,
                    out entity);

                return entity;
            }
        }

        public AssociationProperty[] SecondaryEntityAssociationProperties => _secondaryEntityAssociationProperties.Value;

        /// <summary>
        /// Indicates whether the association starts and ends on the same table.
        /// </summary>
        public bool IsSelfReferencing => PrimaryEntityFullName.Name.EqualsIgnoreCase(SecondaryEntityFullName.Name)
                                         && PrimaryEntityFullName.Schema.Equals(SecondaryEntityFullName.Schema);

        public bool IsRequired { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            string cardinality;

            switch (Cardinality)
            {
                case Cardinality.OneToZeroOrMore:
                    cardinality = "(1)-->(*)";
                    break;

                case Cardinality.OneToOneOrMore:
                    cardinality = "(1)-->(+)";
                    break;

                case Cardinality.OneToOne:
                    cardinality = "(1)-->(1)";
                    break;

                case Cardinality.OneToOneInheritance:
                    cardinality = "<|---";
                    break;

                case Cardinality.OneToOneExtension:
                    cardinality = "(1)-->(1X)";
                    break;

                case Cardinality.OneToZeroOrOneExtension:
                    cardinality = "(1)-->(1X?)";
                    break;

                default:
                    throw new NotImplementedException($"Unimplemented cardinality: '{Cardinality}.");
            }

            return $"{PrimaryEntityFullName}{cardinality}{SecondaryEntityFullName}";
        }
    }
}
