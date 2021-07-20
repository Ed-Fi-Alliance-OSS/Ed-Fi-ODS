// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using log4net;

namespace Nde.Adviser.Lds.SqlGeneration.Transformers
{
    public class SchoolYearContextInjectionTransformer : IDomainModelDefinitionsTransformer
    {
        private const string ContextSchoolYearName = "ContextSchoolYear";
        private readonly ILog _logger = LogManager.GetLogger(typeof(SchoolYearContextInjectionTransformer));
        
        public IEnumerable<DomainModelDefinitions> TransformDefinitions(IEnumerable<DomainModelDefinitions> definitions)
        {
            var definitionsArray = definitions.ToArray();
            
            var domainModelDefinitionsBySchema = definitionsArray.ToDictionary(x => x.SchemaDefinition.PhysicalName, x => x);

            // Build domain model
            var domainModel = new DomainModelBuilder(definitionsArray).Build();

            // var edOrgFullName = new FullName( EdFiConventions.PhysicalSchemaName, "EducationOrganization");

            // var educationOrganizationEntityNames = domainModel.EntityByFullName[edOrgFullName]
            //     .DerivedEntities
            //     .Select(e => e.FullName);

            var knownPersonEntityNames = new[]
            {
                new FullName(EdFiConventions.PhysicalSchemaName, "Student"),
                new FullName(EdFiConventions.PhysicalSchemaName, "Staff"),
                new FullName(EdFiConventions.PhysicalSchemaName, "Parent"),
                new FullName(EdFiConventions.PhysicalSchemaName, "Person"),
            };
            
            var entitiesNotToInjectSchoolYearContext = domainModel.Entities
                .Where(e => 
                    // Don't inject into non-aggregate root members
                    !e.IsAggregateRoot
                    // Don't inject into people
                    || knownPersonEntityNames.Contains(e.FullName)
                    // Don't inject into EdOrg base or EdOrgs
                    || (e.IsEducationOrganizationBaseEntity() || e.IsEducationOrganizationDerivedEntity())
                    // Don't inject into Descriptor base or Descriptors
                    || (e.IsDescriptorBaseEntity() || e.IsDescriptorEntity())
                    // Don't inject into the SchoolYearType
                    || e.FullName.IsEdFiSchoolYearType())
                .Select(e => e.FullName)
                .ToList();

            var injectionSites = domainModel.Entities.Where(
                e =>
                    !entitiesNotToInjectSchoolYearContext.Contains(e.FullName) 
                    && !e.IncomingAssociations.Any(a => a.IsIdentifying && !entitiesNotToInjectSchoolYearContext.Contains(a.OtherEntity.FullName)))
                .ToList();
            
            var schoolYearContextAssociationsBySchema = new ConcurrentDictionary<string, List<AssociationDefinition>>();

            // Inject direct SchoolYear associations in these "top level" context entities
            var injectionSiteDefinitions = injectionSites.Select(
                e => new
                {
                    Entity = e,
                    EntityDefinition = domainModelDefinitionsBySchema[e.Schema]
                        .EntityDefinitions.Single(d => e.FullName == new FullName(d.Schema, d.Name))
                })
                .ToList();
                
            _logger.Debug($"SchoolYear context being injected to the following entities:{Environment.NewLine}{string.Join(Environment.NewLine, injectionSites)}");
            
            // Process all entity definitions
            foreach (var injectionSiteDefinition in injectionSiteDefinitions)
            {
                // Add an association definition from SchoolYearType
                var associationDefinition = new AssociationDefinition
                {
                    Cardinality = Cardinality.OneToZeroOrMore,
                    FullName = new FullName(injectionSiteDefinition.Entity.Schema, $"FK_{injectionSiteDefinition.Entity.Name}_SchoolYearTypeContext"),
                    IsIdentifying = true,
                    PrimaryEntityFullName = new FullName("edfi", "SchoolYearType"),
                    PrimaryEntityProperties = new[]
                    {
                        new EntityPropertyDefinition
                        {
                            PropertyName = "SchoolYear",
                            PropertyType = new PropertyType(DbType.Int16),
                            ColumnNames = new Dictionary<DatabaseEngine, string> {{DatabaseEngine.SqlServer, "SchoolYear"}},
                            IsIdentifying = true,
                        }
                    },
                    SecondaryEntityFullName = new FullName(injectionSiteDefinition.Entity.Schema, injectionSiteDefinition.Entity.Name),
                    SecondaryEntityProperties = new[]
                    {
                        CreateSchoolYearContextEntityPropertyDefinition()
                    },
                };

                // Add the SchoolYearType association to the right schema's association definitions collection
                var associationDefinitions = schoolYearContextAssociationsBySchema.GetOrAdd(
                    associationDefinition.SecondaryEntityFullName.Schema,
                    new List<AssociationDefinition>());

                associationDefinitions.Add(associationDefinition);
                
                // Add the SchoolYearContext column to the beginning of the primary key property names
                foreach (var identifier in injectionSiteDefinition.EntityDefinition.Identifiers.Where(x => x.IsPrimary))
                {
                    identifier.IdentifyingPropertyNames =
                        (new[] {ContextSchoolYearName})
                        .Concat(identifier.IdentifyingPropertyNames)
                        .Distinct() // TODO: REVISIT THIS HACK!
                        .ToArray();
                }

                var primaryEntityFullName = injectionSiteDefinition.Entity.FullName;
                
                // Process downstream dependencies, adding school year context through the composite keys / associations
                AddSchoolYearContextToDependencies(primaryEntityFullName);
            }

            // Add the new associations to the appropriate schema-specific definitions
            foreach (var kvp in schoolYearContextAssociationsBySchema)
            {
                domainModelDefinitionsBySchema[kvp.Key].AssociationDefinitions = 
                    domainModelDefinitionsBySchema[kvp.Key].AssociationDefinitions
                        .Concat(kvp.Value)
                        .ToArray();
            }

            return definitionsArray;

            void AddSchoolYearContextToDependencies(FullName fullName)
            {
                // _logger.Debug($"Processing dependencies for '{fullName}'.");

                // Find all dependencies of this entity
                var dependencyAssociations = domainModelDefinitionsBySchema
                    .SelectMany(x => x.Value.AssociationDefinitions.Where(d => d.PrimaryEntityFullName == fullName))
                    // Eliminate self-recursive relationships (TODO: Still need to deal with this the first time, but without recursing)
                    .Select(x => new
                    {
                        Definition = x,
                        IsSelfRecursive = x.PrimaryEntityFullName == x.SecondaryEntityFullName,
                    });

                foreach (var dependencyAssociation in dependencyAssociations)
                {
                    // Prevent infinite recursion by detecting the presence of the ContextSchoolYear in the primary key
                    if (dependencyAssociation.Definition.PrimaryEntityProperties.Any(p => p.PropertyName == ContextSchoolYearName))
                    {
                        continue;
                    }
                    
                    // Add SchoolYearContext to the association's primary entity properties
                    dependencyAssociation.Definition.PrimaryEntityProperties = (new[] {CreateSchoolYearContextEntityPropertyDefinition()})
                        .Concat(dependencyAssociation.Definition.PrimaryEntityProperties)
                        .ToArray();

                    // Add SchoolYearContext to the association's secondary entity properties
                    dependencyAssociation.Definition.SecondaryEntityProperties = (new[] {CreateSchoolYearContextEntityPropertyDefinition()})
                        .Concat(dependencyAssociation.Definition.SecondaryEntityProperties)
                        .ToArray();

                    // Determine if dependency entity definition already has the column in the primary identifier
                    var secondaryEntityDefinition = domainModelDefinitionsBySchema[dependencyAssociation.Definition.SecondaryEntityFullName.Schema]
                        .EntityDefinitions.Single(d => new FullName(d.Schema, d.Name) == dependencyAssociation.Definition.SecondaryEntityFullName);

                    var primaryIdentifier = secondaryEntityDefinition.Identifiers
                        .Single(id => id.IsPrimary);

                    // Add the SchoolYearContext to the dependency's primary key identifier's properties
                    if (!primaryIdentifier.IdentifyingPropertyNames.Contains(ContextSchoolYearName))
                    {
                        primaryIdentifier.IdentifyingPropertyNames = (new[] {ContextSchoolYearName})
                            .Concat(primaryIdentifier.IdentifyingPropertyNames)
                            .ToArray();
                    }
                    
                    _logger.Debug($"Processing dependencies for association target entity '{dependencyAssociation.Definition.SecondaryEntityFullName}' (from {dependencyAssociation.Definition.PrimaryEntityFullName}).");

                    if (!dependencyAssociation.IsSelfRecursive)
                    {
                        AddSchoolYearContextToDependencies(dependencyAssociation.Definition.SecondaryEntityFullName);
                    }
                }
            }

            EntityPropertyDefinition CreateSchoolYearContextEntityPropertyDefinition() => new EntityPropertyDefinition
            {
                PropertyName = ContextSchoolYearName,
                PropertyType = new PropertyType(DbType.Int16),
                ColumnNames = new Dictionary<DatabaseEngine, string> {{DatabaseEngine.SqlServer, ContextSchoolYearName}},
                IsIdentifying = true,
            };
        }
    }
}
