// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EdFi.Common.Database;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Controllers.DataManagement;
using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNaming;
using EdFi.Ods.Api.Controllers.DataManagement.QueryBuilding;
using EdFi.Ods.Api.Controllers.DataManagement.QueryTemplating;
using EdFi.Ods.Api.Controllers.DataManagement.ResponseBuilding;
using EdFi.Ods.Api.Controllers.DataManagement.Utilities;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EdFi.Ods.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    [Produces("application/json")]
    [Route("{schema}/{resourceCollection}")]
    public class DataManagementResourceController : ControllerBase
    {
        private readonly IDatabaseConnectionStringProvider _connectionStringProvider;
        private readonly IResourceModelProvider _resourceModelProvider;
        private readonly IRequestResourceResolver _requestResourceResolver;
        private readonly IPagedAggregateIdsQueryBuilder _pagedAggregateIdsQueryBuilder;
        private readonly IPagedAggregateIdsQueryTemplateProvider _pagedAggregateIdsQueryTemplateProvider;
        private readonly IDatabaseArtifactPhysicalNameProvider _physicalNameProvider;

        private readonly ILog _logger = LogManager.GetLogger(typeof(DataManagementResourceController));
        
        public DataManagementResourceController(
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            IResourceModelProvider resourceModelProvider,
            IRequestResourceResolver requestResourceResolver,
            IPagedAggregateIdsQueryBuilder pagedAggregateIdsQueryBuilder,
            IPagedAggregateIdsQueryTemplateProvider pagedAggregateIdsQueryTemplateProvider,
            IDatabaseArtifactPhysicalNameProvider physicalNameProvider)
        {
            _connectionStringProvider = odsDatabaseConnectionStringProvider;
            _resourceModelProvider = resourceModelProvider;
            _requestResourceResolver = requestResourceResolver;
            _pagedAggregateIdsQueryBuilder = pagedAggregateIdsQueryBuilder;
            _pagedAggregateIdsQueryTemplateProvider = pagedAggregateIdsQueryTemplateProvider;
            _physicalNameProvider = physicalNameProvider;
        }
        
        // Collection operations
        [HttpGet]
        public virtual async Task<IActionResult> GetAll(UrlQueryParametersRequest urlQueryParametersRequest)
        {
            var (resource, error) = _requestResourceResolver.GetResourceForRequest(Request);

            if (resource == null)
            {
                return StatusCode(error.Code, new { error.Message });
            }

            // int offset = urlQueryParametersRequest.Offset ?? 0;
            // int limit = urlQueryParametersRequest.Limit ?? 25;
            
            var resourceData = await GetResourceData(resource, Request.Query);

            return new ContentResult
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = resourceData.ToJson(),
            };
        }

        private async Task<ResourceData> GetResourceData(
            Resource resource, 
            IQueryCollection requestQueryParameters,
            IDictionary<string, object> primaryKeyValues = null)
        {
            var sqlStringBuilder = new StringBuilder();

            // Build the SQL elements to execute for the paged query
            var pagedQuerySqlBuilder = _pagedAggregateIdsQueryBuilder.BuildQuery(resource.Entity, requestQueryParameters);
            
            // Get parameters
            var parameters = new DynamicParameters();
            _pagedAggregateIdsQueryBuilder.ApplyParameters(parameters, requestQueryParameters);
            
            // Apply the database-specific SQL template
            var template = pagedQuerySqlBuilder.AddTemplate(
                _pagedAggregateIdsQueryTemplateProvider.GetSqlTemplate(resource.Entity));

            // If the paged query is batchable, just include it
            if (_pagedAggregateIdsQueryTemplateProvider.IsBatchable)
            {
                sqlStringBuilder.AppendLine(template.RawSql);
            }
            else
            {
                // TODO: Execute first query to obtain Ids for page
                throw new NotImplementedException("Separate query to obtain Ids for paged resource results has not yet been implemented.");
            }
            
            // Build the remaining resource queries
            var resourceClassQueries = BuildQueriesForResource(resource, primaryKeyValues).ToList();

            // Add all the raw SQL to the batch
            foreach (var resourceClassQuery in resourceClassQueries)
            {
                sqlStringBuilder.Append(resourceClassQuery.Template.RawSql);
            }

            // TODO: Simple API - Establish database-specific connection
            using (var conn = new SqlConnection(_connectionStringProvider.GetConnectionString()))
            {
                await conn.OpenAsync();

                _logger.Debug($"SQL: {sqlStringBuilder}");

                if (primaryKeyValues != null)
                {
                    parameters.AddDynamicParams(primaryKeyValues);
                }

                string sql = sqlStringBuilder.ToString();
                
                var results = new List<ResourceClassQueryResults>();
                
                using (var multipleResults = await conn.QueryMultipleAsync(sql, parameters))
                {
                    int i = 0;

                    while (!multipleResults.IsConsumed)
                    {
                        var result = await multipleResults.ReadAsync();
                        results.Add(new ResourceClassQueryResults(resourceClassQueries[i++].ResourceClass, (List<object>) result));
                    }
                }

                return new ResourceData(results);
            }
        }
        
        private IEnumerable<ResourceClassQuery> BuildQueriesForResource(
                Resource resource, 
                IDictionary<string, object> primaryKeyValues = null)
            {
                var sqlBuilder = new SqlBuilder();
                var aliasGenerator = new AliasGenerator();

                sqlBuilder.Select("e.*");

                foreach (var property in resource.Entity.Identifier.Properties)
                {
                    sqlBuilder.OrderBy($"e.{property.PropertyName}");
                }

                ProcessPropertyExpansions(resource, "e", sqlBuilder, aliasGenerator);

                if (resource.IsDerived)
                {
                    if (primaryKeyValues == null)
                    {
                        sqlBuilder.Where("b.Id IN (SELECT Id FROM @ids)");
                    }
                    
                    sqlBuilder.ApplyJoinToBaseEntity(resource.Entity, _physicalNameProvider);
                    
                    sqlBuilder.Select("b.*");

                    // TODO: Semantic model property candidate: Resource.BaseResource
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

                var query = sqlBuilder.AddTemplate($@"
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

                        sqlBuilder.Where($"{entityProperty.PropertyName} = @{resourceProperty.EntityProperty.PropertyName}", parameters);
                    }
                }
            }

            private IEnumerable<ResourceClassQuery> ProcessChildren(
                ResourceClassBase resourceClass,
                IDictionary<string, object> rootPrimaryKeyValues = null)
            {
                foreach (var childResource in resourceClass.Collections)
                {
                    var queries = BuildQueriesForResource(childResource.ItemType, rootPrimaryKeyValues);

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
                    var queries = BuildQueriesForResource(childResource.ObjectType, rootPrimaryKeyValues);

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

            private IEnumerable<SqlBuilder.Template> BuildQueriesForResource(
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
                    sqlBuilder.InnerJoin($"{(aggregateRoot.IsDerived ? aggregateRoot.BaseEntity.FullName : aggregateRoot.FullName)} r on {JoinCriteriaToRoot(entity)}");
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

            private void ProcessPropertyExpansions(ResourceClassBase resourceClass, string resourceAlias, SqlBuilder sqlBuilder, AliasGenerator aliasGenerator)
            {
                // Process descriptors (from this entity/resource class only)
                var descriptorProperties = resourceClass.AllProperties
                    .Where(p => !p.IsInherited)
                    .Where(p => p.IsLookup);

                foreach (var descriptorProperty in descriptorProperties)
                {
                    string descriptorAlias = aliasGenerator.GetNextAlias();

                    // var lookupEntityFullName = descriptorProperty.EntityProperty.LookupEntity.FullName;
                    // string otherDescriptorId = descriptorProperty.EntityProperty.LookupEntity.Identifier.Properties.Single().PropertyName;

                    string thisDescriptorId = descriptorProperty.EntityProperty.PropertyName;
                    
                    string join = $"edfi.Descriptor AS {descriptorAlias} ON {resourceAlias}.{thisDescriptorId} = {descriptorAlias}.DescriptorId";

                    sqlBuilder.Select($"{descriptorAlias}.Namespace AS {descriptorProperty.PropertyName}_Namespace");
                    sqlBuilder.Select($"{descriptorAlias}.CodeValue AS {descriptorProperty.PropertyName}_CodeValue");
                    
                    if (descriptorProperty.PropertyType.IsNullable)
                    {
                        sqlBuilder.LeftJoin(join);
                    }
                    else
                    {
                        sqlBuilder.InnerJoin(join);
                    }
                }
                
                // Process UniqueIds
                var uniqueIdProperties = resourceClass.AllProperties
                    .Where(p => !p.IsInherited)
                    .Where(p => IsUniqueId(p) && !IsDefiningUniqueId(resourceClass, p));

                foreach (var uniqueIdProperty in uniqueIdProperties)
                {
                    string personType = UniqueIdSpecification.GetUniqueIdPersonType(uniqueIdProperty.PropertyName);

                    string personAlias = aliasGenerator.GetNextAlias();
                    string join = $"edfi.{personType} AS {personAlias} ON {resourceAlias}.{uniqueIdProperty.EntityProperty.PropertyName} = {personAlias}.{personType}USI";

                    sqlBuilder.Select($"{personAlias}.{personType}UniqueId AS {uniqueIdProperty.PropertyName}");

                    if (uniqueIdProperty.PropertyType.IsNullable)
                    {
                        sqlBuilder.LeftJoin(join);
                    }
                    else
                    {
                        sqlBuilder.InnerJoin(join);
                    }
                }
                
                // Process joins for references from this entity/class only (for identifying properties and resource Ids)
                foreach (var reference in resourceClass.References.Where(r => !r.IsInherited))
                {
                    string referenceAlias = aliasGenerator.GetNextAlias();

                    string join;

                    if (reference.Association.OtherEntity.IsDerived)
                    {
                        string joinCriteria = string.Join(" AND ",
                            reference.Association.PropertyMappings.Select((pm, i) => $"{resourceAlias}.{pm.ThisProperty.PropertyName} = {referenceAlias}.{reference.Association.OtherEntity.BaseAssociation.PropertyMappingByThisName[pm.OtherProperty.PropertyName].OtherProperty.PropertyName}"));
                        
                        @join = $"{reference.Association.OtherEntity.BaseEntity.FullName} AS {referenceAlias} ON {joinCriteria}";
                        
                        sqlBuilder.Select($"{referenceAlias}.Id AS {reference.PropertyName}_Id");
                        sqlBuilder.Select($"{referenceAlias}.Discriminator AS {reference.PropertyName}_Discriminator");
                    }
                    else
                    {
                        string joinCriteria = string.Join(" AND ",
                            reference.Association.PropertyMappings.Select(pm => $"{resourceAlias}.{pm.ThisProperty.PropertyName} = {referenceAlias}.{pm.OtherProperty.PropertyName}"));
                    
                        @join = $"{reference.Association.OtherEntity.FullName} AS {referenceAlias} ON {joinCriteria}";

                        sqlBuilder.Select($"{referenceAlias}.Id AS {reference.PropertyName}_Id");

                        if (reference.Association.OtherEntity.IsBase)
                        {
                            sqlBuilder.Select($"{referenceAlias}.Discriminator AS {reference.PropertyName}_Discriminator");
                        }
                    }
                    
                    if (reference.IsRequired)
                    {
                        sqlBuilder.InnerJoin(join);
                    }
                    else
                    {
                        sqlBuilder.LeftJoin(join);
                    }
                }
            }

            private static bool IsUniqueId(ResourceProperty property)
            {
                return UniqueIdSpecification.IsUniqueId(property.PropertyName);
            }

            private static bool IsDefiningUniqueId(ResourceClassBase resourceClass, ResourceProperty property)
            {
                return UniqueIdSpecification.IsUniqueId(property.PropertyName)
                    && PersonEntitySpecification.IsPersonEntity(resourceClass.Name);
            }

            private string JoinCriteriaToRoot(Entity entity)
            {
                var aggregateRoot = entity.Aggregate.AggregateRoot;

                if (aggregateRoot.IsDerived)
                {
                    var rootPropertyNames = aggregateRoot.Identifier.Properties.Select(p => p.PropertyName).ToArray();
                
                    return string.Join(
                        " AND ",
                        entity.ParentAssociation.PropertyMappings
                            .Where(pm => rootPropertyNames.Contains(pm.OtherProperty.PropertyName))
                            .Select(pm => new { PropertyMapping = pm, BasePropertyMapping = aggregateRoot.BaseAssociation.PropertyMappings.Single(pm2 => pm.OtherProperty.PropertyName == pm2.ThisProperty.PropertyName) })
                            .Select(x => $"e.{x.PropertyMapping.ThisProperty.PropertyName} = r.{x.BasePropertyMapping.OtherProperty.PropertyName}"));
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

            // private SqlBuilder.Template BuildPagedIdsQueryForEntity(Entity entity, int offset, int limit)
            // {
            //     var pagedIdsQueryBuilder = new SqlBuilder();
            //     
            //     _pagedIdsQueryBuilder.BuildPagedIdsQuery
            //     
            //     var template = pagedIdsQueryBuilder.AddTemplate(
            //         _pagedAggregateIdsQueryTemplateProvider.GetSqlTemplate(entity),
            //         new
            //         {
            //             int.TryParse(queryCollection["offset"],
            //                 limit
            //         });
            //
            //     return template;
            // }


        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] JObject jsonData)
        {
            var (resource, error) = _requestResourceResolver.GetResourceForRequest(Request);

            if (resource == null)
            {
                return StatusCode(error.Code, new { error.Message });
            }

            // Get the primary key of the resource
            var primaryKeyValues = resource.AllIdentifyingProperties
                .ToDictionary(
                    rp => rp.PropertyName, 
                    rp => (object) jsonData[rp.JsonPropertyName].Value<JValue>().Value);
            
            var resourceData = await GetResourceData(resource, Request.Query, primaryKeyValues);

            var dataByFullName = resourceData.Results.ToDictionary(
                x => x.ResourceClass.FullName,
                x => (List<object>) x.Results);

            // Process root resource class
            var odsData = dataByFullName[resource.FullName];
            
            // Process identifying properties
            IDictionary<string,object> odsRow = (IDictionary<string,object>) odsData[0];

            if (resource.IsDerived)
            {
                await Update(resource, resource.Entity.BaseEntity, jsonData);
            }

            await Update(resource, resource.Entity, jsonData);

            async Task Update(ResourceClassBase resourceClass, Entity entity, JObject sourceData)
            {
                var sqlSetBuilder = new StringBuilder();
                var sqlFromBuilder = new StringBuilder();
                var sqlWhereBuilder = new StringBuilder();
                
                var descriptorWhereBuilder = new StringBuilder();
                
                var parameters = new Dictionary<string, object>();

                foreach (var identifyingProperty in resourceClass.AllIdentifyingProperties)
                {
                    string entityPropertyName = identifyingProperty.EntityProperty.PropertyName;
                    parameters.Add(entityPropertyName, odsRow[entityPropertyName]);
                    sqlWhereBuilder.Append($"AND {entityPropertyName} = @{entityPropertyName}");
                }

                string jsonPathBase = resourceClass.JsonPath + ".";

                int descriptorIndex = 1;
                var attemptedDescriptors = new List<ValueTuple<string, string, string>>();
                
                // Process non-identifying properties
                foreach (var property in resourceClass.NonIdentifyingProperties
                        .Where(p => p.PropertyName != "Id")
                        .Where(p => p.EntityProperty.Entity == entity))
                {
                    string entityPropertyName = property.EntityProperty.PropertyName;

                    string relativeJsonPath = property.JsonPath.TrimPrefix(jsonPathBase);
                    
                    // var existingValue = odsRow[entityPropertyName];
                    var proposedValue = jsonData.SelectToken(relativeJsonPath)?.Value<JValue>()?.Value; // [property.JsonPropertyName]?.Value<object>();

                    // var proposedValue = Convert.ChangeType(proposedValueAsObject, TypeCode.Int32); // property.PropertyType.GetTypeCode())

                    if (property.EntityProperty.IsLookup)
                    {
                        if (proposedValue == null)
                        {
                            //parameters.Add(entityPropertyName, proposedValue);
                            sqlSetBuilder.Append($", {entityPropertyName} = NULL");
                        }
                        else
                        {
                            sqlFromBuilder.Append($", edfi.Descriptor d{descriptorIndex}");
                            
                            var descriptorParts = (proposedValue as string)?.Split('#');

                            sqlSetBuilder.Append($", {entityPropertyName} = COALESCE(d{descriptorIndex}.DescriptorId, 0)");

                            sqlWhereBuilder.Append(
                                $" AND (d{descriptorIndex}.Namespace = @d{descriptorIndex}Namespace AND d{descriptorIndex}.CodeValue = @d{descriptorIndex}CodeValue)");
                            
                            parameters.Add($"d{descriptorIndex}Namespace", descriptorParts[0]);
                            parameters.Add($"d{descriptorIndex}CodeValue", descriptorParts[1]);

                            descriptorWhereBuilder.Append(
                                $" OR (Namespace = @d{descriptorIndex}Namespace AND CodeValue = @d{descriptorIndex}CodeValue)");
                            
                            attemptedDescriptors.Add((property.LookupTypeName, descriptorParts[0], descriptorParts[1]));

                            descriptorIndex++;
                        }
                    }
                    else // if (!proposedValue.Equals(existingValue))
                    {
                        parameters.Add(entityPropertyName, proposedValue);
                        sqlSetBuilder.Append($", {entityPropertyName} = @{entityPropertyName}");
                    }
                }

                using (var conn = new SqlConnection(_connectionStringProvider.GetConnectionString()))
                {
                    await conn.OpenAsync();

                    string from = sqlFromBuilder.Length > 0
                        ? $"FROM {resourceClass.FullName.Schema}.{resourceClass.FullName.Name}{sqlFromBuilder.ToString()}"
                        : null;

                    string descriptorDiagnostics = descriptorWhereBuilder.Length > 0
                        ? $@" IF @@rowcount = 0
                    SELECT   DescriptorId, Namespace, CodeValue
                    FROM     edfi.Descriptor 
                    WHERE {descriptorWhereBuilder.ToString(3, descriptorWhereBuilder.Length - 3)}"
                        : null;
                    
                    string sql = $@"
    UPDATE {entity.FullName.Schema}.{entity.FullName.Name}
    SET {sqlSetBuilder.ToString(2, sqlSetBuilder.Length - 2)}
    {@from}
    WHERE {sqlWhereBuilder.ToString(4, sqlWhereBuilder.Length - 4)}
    {descriptorDiagnostics}";

                    if (descriptorDiagnostics.Length > 0)
                    {
                        using (var multipleResults = await conn.QueryMultipleAsync(sql, parameters))
                        {
                            int i = 0;

                            // Skip the first result
                            var readerField = typeof(SqlMapper.GridReader).GetField("reader", BindingFlags.Instance | BindingFlags.NonPublic);
                            var reader = (IDataReader) readerField.GetValue(multipleResults);

                            if (reader.FieldCount > 0)
                            {
                                while (!multipleResults.IsConsumed)
                                {
                                    var result = await multipleResults.ReadAsync();

                                    var invalidAttemptedDescriptors = attemptedDescriptors
                                        .Where(
                                            attemptedDescriptor => !result.Any(
                                                locatedDescriptor => attemptedDescriptor.Item2 == locatedDescriptor.Namespace
                                                    && attemptedDescriptor.Item3 == locatedDescriptor.CodeValue))
                                        .ToArray();
                                
                                    if (invalidAttemptedDescriptors.Any())
                                    {
                                        string propertyName = invalidAttemptedDescriptors.First().Item1;
                                        string @namespace = invalidAttemptedDescriptors.First().Item2;
                                        string codeValue = invalidAttemptedDescriptors.First().Item3;
                                    
                                        throw new BadRequestException($"Unable to resolve value '{@namespace}#{codeValue}' to an existing '{propertyName}' resource.");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        await conn.ExecuteAsync(sql, parameters);
                    }
                }
            }

            // var requestStream = await Request.Content.ReadAsStreamAsync();
            // var jsonReader = new JsonTextReader(new StreamReader(requestStream));


            // var sqlBuilder = new Dapper.SqlBuilder();
            //
            // foreach (var property in entity.Properties)
            // {
            //     sqlBuilder.Select(property.PropertyName);
            // }
            //
            // foreach (var property in entity.Identifier.Properties)
            // {
            //     sqlBuilder.OrderBy(property.PropertyName);
            // }
            //
            // var builderTemplate = sqlBuilder.AddTemplate(
            //     $"Select /**select**/ from {entity.FullName} /**innerjoin**/ /**where**/ /**orderby**/ ");
            //
            // int count;
            //
            // using (var conn = new SqlConnection(_connectionStringProvider.GetConnectionString()))
            // {
            //     await conn.OpenAsync();
            //
            //     var results = (IEnumerable<IDictionary<string, object>>) await conn.QueryAsync(builderTemplate.RawSql);
            //
            //     return Ok(results);
            // }
            //
            return Ok();
        }

        // Item-level operations
        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> Get(/*[FromUri]*/ Guid id)
        {
            return Ok(new {hello = "world"});
        }
        
        [HttpPut]
        [Route("{id}")]
        public virtual async Task<IActionResult> Put(/*[FromUri]*/ Guid id)
        {
            return Ok(new {hello = "world"});
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual async Task<IActionResult> Delete(/*[FromUri]*/ Guid id)
        {
            return Ok(new {hello = "world"});
        }
    }
}
