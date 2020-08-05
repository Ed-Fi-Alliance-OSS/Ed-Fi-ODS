// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Validation;
using EdFi.Ods.Common.Utils.Extensions;
using EdFi.Ods.Common.Validation;
using FluentValidation;

namespace EdFi.Ods.Common.Models.Domain
{
    /// <summary>
    /// Builds a domain model through the addition of aggregates, entities and associations.
    /// </summary>
    public class DomainModelBuilder
    {
        private DomainModel _domainModel;

        /// <summary>
        /// Default constructor
        /// </summary>
        public DomainModelBuilder()
            : this(new List<DomainModelDefinitions>()) { }

        /// <summary>
        /// Constructor that takes a set of DomainModelDefinitions to initialize it values
        /// </summary>
        /// <param name="domainModelDefinitions"></param>
        public DomainModelBuilder(IEnumerable<DomainModelDefinitions> domainModelDefinitions)
        {
            _domainModel = new DomainModel();
            domainModelDefinitions.ForEach(x => _domainModel.AddDomainModelDefinitions(x));
        }

        /// <summary>
        /// Adds an AggregateDefinition to be built into the Domain Model
        /// </summary>
        /// <param name="aggregateDefinition"></param>
        public void AddAggregate(AggregateDefinition aggregateDefinition)
        {
            EnsureDomainModelIsNotNull();
            _domainModel.AddAggregate(aggregateDefinition);
        }

        /// <summary>
        /// Adds an <see cref="AggregateExtensionDefinition" /> to be built into the Domain Model
        /// </summary>
        /// <param name="aggregateExtensionDefinition"></param>
        public void AddAggregateExtension(AggregateExtensionDefinition aggregateExtensionDefinition)
        {
            EnsureDomainModelIsNotNull();
            _domainModel.AddAggregateExtension(aggregateExtensionDefinition);
        }

        /// <summary>
        /// Adds an EntityDefinition to be built into the domain model
        /// </summary>
        /// <param name="entityDefinition"></param>
        public void AddEntity(EntityDefinition entityDefinition)
        {
            EnsureDomainModelIsNotNull();
            _domainModel.AddEntity(entityDefinition);
        }

        /// <summary>
        /// A Set of DomainModelDefinitions will be passed and used to initialize the DomainModel Instance that is created
        ///       in the Build() method
        /// </summary>
        /// <param name="domainModelDefList"></param>
        public void AddDomainModelDefinitionsList(IEnumerable<DomainModelDefinitions> domainModelDefList)
        {
            EnsureDomainModelIsNotNull();
            domainModelDefList.ForEach(x => _domainModel.AddDomainModelDefinitions(x));
        }

        /// <summary>
        /// Add an Association that will be built into the domain model
        /// </summary>
        /// <param name="associationDefinition"></param>
        public void AddAssociation(AssociationDefinition associationDefinition)
        {
            EnsureDomainModelIsNotNull();
            _domainModel.AddAssociation(associationDefinition);
        }

        /// <summary>
        /// Add a SchemaDefinition that will be built into the domain model
        /// </summary>
        /// <param name="schemaDefinition"></param>
        public void AddSchema(SchemaDefinition schemaDefinition)
        {
            EnsureDomainModelIsNotNull();
            _domainModel.AddSchema(schemaDefinition);
        }

        /// <summary>
        /// Builds and returns the final domain model.
        /// </summary>
        /// <returns>The new built domain model.</returns>
        /// <remarks>This method can only be called once per builder instance.</remarks>
        public DomainModel Build()
        {
            ValidateModel();

            var domainModel = Interlocked.Exchange(ref _domainModel, null);

            if (domainModel == null)
            {
                throw new InvalidOperationException("A domain model has already been built with this builder.  Create a new builder.");
            }

            return domainModel;
        }

        private void ValidateModel()
        {
            EnsureDomainModelIsNotNull();

            var validator = new FluentValidationObjectValidator(
                new IValidator[]
                {
                    new SchemaValidator(_domainModel),
                    new EntityValidator(_domainModel),
                    new AssociationValidator(_domainModel),
                    new AggregateValidator(_domainModel)
                });

            var validationResults =

                // Validate the Schemas
                _domainModel.Schemas.SelectMany(schema => validator.ValidateObject(schema))

                             // Validate the Aggregates
                            .Concat(_domainModel.Aggregates.SelectMany(aggregate => validator.ValidateObject(aggregate)))

                             // Validate the Entities
                            .Concat(_domainModel.Entities.SelectMany(entity => validator.ValidateObject(entity)))

                             // Validate the Associations
                            .Concat(_domainModel.Associations.SelectMany(association => validator.ValidateObject(association)))
                            .ToList();

            if (validationResults.Any())
            {
                throw new Exception(
                    string.Format(
                        "Domain model is invalid.{0}{1}",
                        Environment.NewLine,
                        string.Join("\t" + Environment.NewLine, validationResults.GetAllMessages())));
            }
        }

        private void EnsureDomainModelIsNotNull()
        {
            if (_domainModel == null)
            {
                throw new InvalidOperationException("A domain model has already been built with this builder.  Create a new builder.");
            }
        }
    }
}
