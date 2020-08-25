// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Dapper;
using EdFi.Ods.Api.NHibernate;
using EdFi.Ods.Api.Services.Authentication;
using EdFi.Ods.Api.Services.Controllers.DataManagement;
using EdFi.Ods.Api.Services.Queries;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Inflection;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;
using log4net;

namespace EdFi.Ods.Api.Services.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authenticate]
    public partial class DataManagementResourceController : ApiController
    {
        private readonly IDatabaseConnectionStringProvider _connectionStringProvider;
        private readonly IResourceModelProvider _resourceModelProvider;
        private readonly IApiConfigurationProvider _apiConfigurationProvider;

        private readonly ILog _logger = LogManager.GetLogger(typeof(DataManagementResourceController));
        
        public DataManagementResourceController(
            IDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            IResourceModelProvider resourceModelProvider,
            IApiConfigurationProvider apiConfigurationProvider)
        {
            _connectionStringProvider = odsDatabaseConnectionStringProvider;
            _resourceModelProvider = resourceModelProvider;
            _apiConfigurationProvider = apiConfigurationProvider;
        }
        
        // Collection operations
        public virtual async Task<HttpResponseMessage> GetAll([FromUri] UrlQueryParametersRequest urlQueryParametersRequest)
        {
            string schemaUriSegment = (string) Request.GetRouteData().Values["schema"];
            string resourceCollectionName = (string) Request.GetRouteData().Values["resourceCollection"];

            var resourceModel = _resourceModelProvider.GetResourceModel();
            var schemaNameMapProvider = resourceModel.SchemaNameMapProvider; // _domainModelProvider.GetDomainModel().SchemaNameMapProvider;
            
            string schema = schemaNameMapProvider.GetSchemaMapByUriSegment(schemaUriSegment).PhysicalName;
            string resourceName = CompositeTermInflector.MakeSingular(resourceCollectionName);

            var resourceFullName = new FullName(schema, resourceName);

            var resource = resourceModel.GetResourceByFullName(resourceFullName);
            
            if (resource == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            int offset = urlQueryParametersRequest.Offset ?? 0;
            int limit = urlQueryParametersRequest.Limit ?? 25;
            
            var pagedQueryBuilder = BuildPagedQueryForEntity(resource.Entity, offset, limit);
            
            var resourceClassQueries = BuildQueriesForResource(resource).ToList();
            
            var sql = new StringBuilder();
            sql.AppendLine(pagedQueryBuilder.RawSql);

            foreach (var resourceClassQuery in resourceClassQueries)
            {
                sql.Append(resourceClassQuery.Template.RawSql);
            }
            
            using (var conn = new SqlConnection(_connectionStringProvider.GetConnectionString()))
            {
                await conn.OpenAsync();

                _logger.Debug($"SQL: {sql}");
                
                using (var multipleResults = await conn.QueryMultipleAsync(sql.ToString(), new { offset, limit}))
                {
                    int i = 0;
                    
                    while (!multipleResults.IsConsumed)
                    {
                        var result = await multipleResults.ReadAsync();
                        resourceClassQueries[i++].Results = (List<object>) result;
                    }
                }
            }

            return new HttpResponseMessage {Content = new ResourceJsonContent(resourceClassQueries)};
        }

        public class ResourceClassQuery
        {
            public ResourceClassQuery(ResourceClassBase resourceClass, SqlBuilder.Template template)
            {
                ResourceClass = resourceClass;
                Template = template;
            }

            public ResourceClassBase ResourceClass { get; set; }
            public SqlBuilder.Template Template { get; set; }

            public List<object> Results { get; set; }
        }

        private IEnumerable<ResourceClassQuery> BuildQueriesForResource(Resource resource)
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
                sqlBuilder.Where("b.Id IN (SELECT Id FROM @ids)");
                
                CreateBaseEntityJoin(resource.Entity, sqlBuilder);
                
                sqlBuilder.Select("b.*");

                // TODO: Semantic model property candidate: Resource.BaseResource
                var baseFullName = resource.Entity.BaseEntity.FullName;
                var baseResource = _resourceModelProvider.GetResourceModel().GetResourceByFullName(baseFullName);
                
                ProcessPropertyExpansions(baseResource, "b", sqlBuilder, aliasGenerator);
            }
            else
            {
                sqlBuilder.Where("e.Id IN (SELECT Id FROM @ids)");
            }

            var query = sqlBuilder.AddTemplate($@"
SELECT /**select**/ 
FROM {resource.FullName} AS e
/**innerjoin**/
/**leftjoin**/
/**where**/
/**orderby**/");

            yield return new ResourceClassQuery(resource, query);

            foreach (var childQuery in ProcessChildren(resource))
            {
                yield return childQuery;
            }
        }

        private IEnumerable<ResourceClassQuery> ProcessChildren(ResourceClassBase resourceClass)
        {
            foreach (var childResource in resourceClass.Collections)
            {
                var queries = BuildQueriesForResource(childResource.ItemType);

                foreach (var query in queries)
                {
                    yield return new ResourceClassQuery(childResource.ItemType, query);

                    foreach (var childQuery in ProcessChildren(childResource.ItemType))
                    {
                        yield return childQuery;
                    }
                }
            }

            foreach (var childResource in resourceClass.EmbeddedObjects)
            {
                var queries = BuildQueriesForResource(childResource.ObjectType);

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

        private IEnumerable<SqlBuilder.Template> BuildQueriesForResource(ResourceChildItem resourceChildItem)
        {
            var sqlBuilder = new SqlBuilder();
            var aliasGenerator = new AliasGenerator();
            
            var entity = resourceChildItem.Entity;

            sqlBuilder.Select("e.*");
            
            // Child join to root
            var aggregateRoot = resourceChildItem.Entity.Aggregate.AggregateRoot;
            
            sqlBuilder.InnerJoin($"{(aggregateRoot.IsDerived ? aggregateRoot.BaseEntity.FullName : aggregateRoot.FullName)} r on {JoinCriteriaToRoot(entity)}");

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
WHERE r.Id IN (SELECT Id FROM @ids)
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

        private SqlBuilder.Template BuildPagedQueryForEntity(Entity entity, int offset, int limit)
        {
            var sqlPageBuilder = new SqlBuilder();

            foreach (var property in entity.Identifier.Properties)
            {
                sqlPageBuilder.OrderBy($"e.{property.PropertyName}");
            }

            // Handle inheritance (single-level only, at this point)
            if (entity.IsDerived)
            {
                CreateBaseEntityJoin(entity, sqlPageBuilder);

                sqlPageBuilder.Select("b.Id");
            }
            else
            {
                sqlPageBuilder.Select("e.Id");
            }
            
            // TODO: Perform authorization joins
            
            var template = sqlPageBuilder.AddTemplate(
                $@"
DECLARE @ids as dbo.UniqueIdentifierTable

INSERT INTO @ids
SELECT /**select**/ FROM {entity.FullName} AS e
/**innerjoin**/
/**leftjoin**/
/**orderby**/
OFFSET @offset ROWS
FETCH NEXT @limit ROWS ONLY",
                new
                {
                    offset,
                    limit
                });

            return template;
        }

        private static void CreateBaseEntityJoin(Entity entity, SqlBuilder sqlBuilder)
        {
            string joinCriteria = string.Join(
                " AND ",
                entity.BaseAssociation.PropertyMappings.Select(
                    pm => $"e.{pm.ThisProperty.PropertyName} = b.{pm.OtherProperty.PropertyName}"));

            string join = $"{entity.BaseEntity.FullName} AS b ON {joinCriteria}";

            sqlBuilder.InnerJoin(@join);
        }

        public virtual async Task<IHttpActionResult> Post()
        {
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
            return Ok(new {hello = "world"});
        }

        // Item operations
        public virtual async Task<IHttpActionResult> Get([FromUri] Guid id)
        {
            return Ok(new {hello = "world"});
        }
        
        public virtual async Task<IHttpActionResult> Put([FromUri] Guid id)
        {
            return Ok(new {hello = "world"});
        }

        public async Task<IHttpActionResult> Delete([FromUri] Guid id)
        {
            return Ok(new {hello = "world"});
        }
    }
}
