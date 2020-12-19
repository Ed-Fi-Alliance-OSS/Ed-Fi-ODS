// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using Dapper;
using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNaming;
using EdFi.Ods.Api.Controllers.DataManagement.ResponseBuilding;
using EdFi.Ods.Api.Controllers.DataManagement.Utilities;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Api.Controllers.DataManagement.ResourceDataQueryBuilding
{
    public class ResourceQueryBuilder : IResourceQueryBuilder
    {
        private readonly IResourceModelProvider _resourceModelProvider;
        private readonly IDatabaseArtifactPhysicalNameProvider _physicalNameProvider;
        private readonly IResourceQueryBuilderPropertyExpansion[] _propertyExpansions;

        public ResourceQueryBuilder(
            IResourceModelProvider resourceModelProvider,
            IDatabaseArtifactPhysicalNameProvider physicalNameProvider,
            IResourceQueryBuilderPropertyExpansion[] propertyExpansions)
        {
            _resourceModelProvider = resourceModelProvider;
            _physicalNameProvider = physicalNameProvider;
            _propertyExpansions = propertyExpansions;
        }
        
        public IEnumerable<ResourceClassQuery> BuildQueries(
            Resource resource,
            IDictionary<string, object> primaryKeyValues = null)
        {
            var sqlBuilder = new SqlBuilder();
            var aliasGenerator = new AliasGenerator();

            sqlBuilder.Select("e.*");

            sqlBuilder.OrderByPrimaryKey(resource.Entity, _physicalNameProvider);
            
            ProcessPropertyExpansions(resource, "e", sqlBuilder, aliasGenerator);

            if (resource.IsDerived)
            {
                // Select all base entity properties
                sqlBuilder.Select("b.*");

                // Join from resource entity to base entity
                sqlBuilder.ApplyJoinToBaseEntity(resource.Entity, _physicalNameProvider);

                // Filter results for a page of data
                if (primaryKeyValues == null)
                {
                    sqlBuilder.Where("b.Id IN (SELECT Id FROM @ids)");
                }

                // TODO: Simple API - Semantic model property candidate: Resource.BaseResource to obtain Resource for base, profile-constrained when appropriate
                var baseFullName = resource.Entity.BaseEntity.FullName;
                var baseResource = _resourceModelProvider.GetResourceModel().GetResourceByFullName(baseFullName);

                ProcessPropertyExpansions(baseResource, "b", sqlBuilder, aliasGenerator);
            }
            else
            {
                if (primaryKeyValues == null)
                {
                    sqlBuilder.Where("e.Id IN (SELECT Id FROM @ids)");
                }
            }

            if (primaryKeyValues != null)
            {
                ApplyRootResourcePrimaryKeyCriteria(sqlBuilder, aliasGenerator, resource, primaryKeyValues);
            }

            var query = sqlBuilder.AddTemplate(
                $@"
SELECT /**select**/ 
FROM {resource.FullName} AS e
/**innerjoin**/
/**leftjoin**/
/**where**/
/**orderby**/");

            yield return new ResourceClassQuery(resource, query);

            foreach (var childQuery in ProcessChildren(resource, primaryKeyValues))
            {
                yield return childQuery;
            }
        }

        private static void ApplyRootResourcePrimaryKeyCriteria(
            SqlBuilder sqlBuilder,
            AliasGenerator aliasGenerator,
            ResourceClassBase resourceClass,
            IDictionary<string, object> primaryKeyValues)
        {
            string rootAlias = (resourceClass is Resource)
                ? "e"
                : "r";

            // TODO: Semantic model candidate
            bool isInheritedChild = (resourceClass.Entity.Aggregate.AggregateRoot != resourceClass.ResourceRoot.Entity);

            foreach (var resourceProperty in resourceClass.ResourceRoot.AllIdentifyingProperties)
            {
                var entityProperty = isInheritedChild
                    ? resourceProperty.EntityProperty.BaseProperty // e.g. EducationOrganizationId
                    : resourceProperty.EntityProperty; // e.g. SchoolId

                if (entityProperty.IsLookup)
                {
                    // TODO: Descriptor requires join to Descriptor on Namespace/CodeValue, splitting on #
                    var descriptorParts = ((string) primaryKeyValues[resourceProperty.PropertyName])?.Split('#');

                    string descriptorAlias = aliasGenerator.GetNextAlias();

                    sqlBuilder.InnerJoin(
                        $"edfi.Descriptor AS {descriptorAlias} ON {rootAlias}.{entityProperty.PropertyName} = {descriptorAlias}.DescriptorId");

                    var parameters = new DynamicParameters();
                    parameters.Add($"{descriptorAlias}_Namespace", descriptorParts[0]);
                    parameters.Add($"{descriptorAlias}_CodeValue", descriptorParts[1]);

                    sqlBuilder.Where(
                        $"{descriptorAlias}.Namespace = @{descriptorAlias}_Namespace AND {descriptorAlias}.CodeValue = @{descriptorAlias}_CodeValue",
                        parameters);
                }
                else if (UniqueIdSpecification.IsUniqueId(resourceProperty.PropertyName))
                {
                    // TODO: UniqueId requires join to corresponding Person table
                    var personType = UniqueIdSpecification.GetUSIPersonType(entityProperty.PropertyName);

                    string personTypeUsiName = $"{personType}USI"; // TODO: Embedded convention - PersonUSI name
                    string personTypeUniqueName = $"{personType}UniqueId"; // TODO: Embedded convention - PersonUniqueId name

                    string personAlias = aliasGenerator.GetNextAlias();

                    sqlBuilder.InnerJoin(
                        $"edfi.{personType} AS {personAlias} ON e.{entityProperty.PropertyName} = {personAlias}.{personTypeUsiName}");

                    var parameters = new DynamicParameters();
                    parameters.Add(personAlias, primaryKeyValues[resourceProperty.PropertyName]);

                    sqlBuilder.Where($"{personAlias}.{personTypeUniqueName} = @{personAlias}", parameters);
                }
                else
                {
                    var parameters = new DynamicParameters();
                    parameters.Add(resourceProperty.PropertyName, primaryKeyValues[resourceProperty.EntityProperty.PropertyName]);

                    sqlBuilder.Where(
                        $"{entityProperty.PropertyName} = @{resourceProperty.EntityProperty.PropertyName}",
                        parameters);
                }
            }
        }

        private IEnumerable<ResourceClassQuery> ProcessChildren(
            ResourceClassBase resourceClass,
            IDictionary<string, object> rootPrimaryKeyValues = null)
        {
            foreach (var childResource in resourceClass.Collections)
            {
                var queries = BuildQueriesForChildResource(childResource.ItemType, rootPrimaryKeyValues);

                foreach (var query in queries)
                {
                    yield return new ResourceClassQuery(childResource.ItemType, query);

                    foreach (var childQuery in ProcessChildren(childResource.ItemType, rootPrimaryKeyValues))
                    {
                        yield return childQuery;
                    }
                }
            }

            foreach (var childResource in resourceClass.EmbeddedObjects)
            {
                var queries = BuildQueriesForChildResource(childResource.ObjectType, rootPrimaryKeyValues);

                foreach (var query in queries)
                {
                    yield return new ResourceClassQuery(childResource.ObjectType, query);

                    foreach (var childQuery in ProcessChildren(childResource.ObjectType))
                    {
                        yield return childQuery;
                    }
                }
            }
        }

        private IEnumerable<SqlBuilder.Template> BuildQueriesForChildResource(
            ResourceChildItem resourceChildItem,
            IDictionary<string, object> rootPrimaryKeyValues)
        {
            var sqlBuilder = new SqlBuilder();
            var aliasGenerator = new AliasGenerator();

            var entity = resourceChildItem.Entity;

            sqlBuilder.Select("e.*");

            // Apply root criteria
            if (rootPrimaryKeyValues == null)
            {
                // Join child entity to root entity
                var aggregateRoot = entity.Aggregate.AggregateRoot;

                sqlBuilder.InnerJoin(
                    $"{(aggregateRoot.IsDerived ? aggregateRoot.BaseEntity.FullName : aggregateRoot.FullName)} r on {JoinCriteriaToRoot(entity)}");

                sqlBuilder.Where("r.Id IN (SELECT Id FROM @ids)");
            }
            else
            {
                ApplyRootResourcePrimaryKeyCriteria(sqlBuilder, aliasGenerator, resourceChildItem, rootPrimaryKeyValues);
            }

            // Sort results by PK
            foreach (var property in entity.Identifier.Properties)
            {
                sqlBuilder.OrderBy($"e.{property.PropertyName}");
            }

            ProcessPropertyExpansions(resourceChildItem, "e", sqlBuilder, aliasGenerator);

            var template = sqlBuilder.AddTemplate(
                $@"
SELECT /**select**/
FROM {entity.FullName} e
    /**innerjoin**/
    /**leftjoin**/
/**where**/
/**orderby**/
");

            yield return template;
        }

        private void ProcessPropertyExpansions(
            ResourceClassBase resourceClass,
            string resourceAlias,
            SqlBuilder sqlBuilder,
            AliasGenerator aliasGenerator)
        {
            foreach (var propertyExpansion in _propertyExpansions)
            {
                propertyExpansion.Process(resourceClass, resourceAlias, sqlBuilder, aliasGenerator);
            }
        }

        private static string JoinCriteriaToRoot(Entity entity)
        {
            var aggregateRoot = entity.Aggregate.AggregateRoot;

            if (aggregateRoot.IsDerived)
            {
                var rootPropertyNames = aggregateRoot.Identifier.Properties.Select(p => p.PropertyName).ToArray();

                return string.Join(
                    " AND ",
                    entity.ParentAssociation.PropertyMappings
                        .Where(pm => rootPropertyNames.Contains(pm.OtherProperty.PropertyName))
                        .Select(
                            pm => new
                            {
                                PropertyMapping = pm,
                                BasePropertyMapping = aggregateRoot.BaseAssociation.PropertyMappings.Single(
                                    pm2 => pm.OtherProperty.PropertyName == pm2.ThisProperty.PropertyName)
                            })
                        .Select(
                            x => $"e.{x.PropertyMapping.ThisProperty.PropertyName} = r.{x.BasePropertyMapping.OtherProperty.PropertyName}"));
            }
            else
            {
                var rootPropertyNames = aggregateRoot.Identifier.Properties.Select(p => p.PropertyName).ToArray();

                return string.Join(
                    " AND ",
                    entity.ParentAssociation.PropertyMappings
                        .Where(pm => rootPropertyNames.Contains(pm.OtherProperty.PropertyName))
                        .Select(pm => $"e.{pm.ThisProperty.PropertyName} = r.{pm.OtherProperty.PropertyName}"));
            }
        }
    }
}
