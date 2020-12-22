// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EdFi.Ods.Api.Controllers.DataManagement.ResourcePageQuery;
using EdFi.Ods.Api.Controllers.DataManagement.ResourcePageQueryTemplating;
using EdFi.Ods.Api.Controllers.DataManagement.ResourceDataQuery;
using EdFi.Ods.Api.Controllers.DataManagement.ResponseBuilding;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Models.Resource;
using log4net;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Controllers.DataManagement
{
    public class ResourceDataProvider : IResourceDataProvider
    {
        private readonly IOdsDatabaseConnectionStringProvider _odsDatabaseConnectionStringProvider;
        private readonly IResourcePageQueryBuilder _resourcePageQueryBuilder;
        private readonly IResourcePageQuerySqlProvider _resourcePageQuerySqlProvider;
        private readonly IResourceQueryBuilder _resourceQueryBuilder;

        private readonly ILog _logger = LogManager.GetLogger(typeof(ResourceDataProvider));
        
        public ResourceDataProvider(
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            IResourcePageQueryBuilder resourcePageQueryBuilder,
            IResourcePageQuerySqlProvider resourcePageQuerySqlProvider,
            IResourceQueryBuilder resourceQueryBuilder)
        {
            _odsDatabaseConnectionStringProvider = odsDatabaseConnectionStringProvider;
            _resourcePageQueryBuilder = resourcePageQueryBuilder;
            _resourcePageQuerySqlProvider = resourcePageQuerySqlProvider;
            _resourceQueryBuilder = resourceQueryBuilder;
        }
        
        public async Task<ResourceData> GetResourceData(
            Resource resource, 
            IQueryCollection query,
            IDictionary<string, object> primaryKeyValues = null)
        {
            var batchSqlStringBuilder = new StringBuilder();
            var parameters = new DynamicParameters();

            // Build the SQL elements for the paged query
            var pagedQuerySqlBuilder = _resourcePageQueryBuilder.BuildQuery(resource.Entity, query);
            _resourcePageQueryBuilder.ApplyParameters(parameters, query);
            
            // Add the primary key values as parameters, if supplied
            if (primaryKeyValues != null)
            {
                parameters.AddDynamicParams(primaryKeyValues);
            }
            
            // Apply the database-specific SQL template
            string sqlTemplate = _resourcePageQuerySqlProvider.GetSqlTemplate(resource.Entity);
            var template = pagedQuerySqlBuilder.AddTemplate(sqlTemplate);

            // If the paged query is batchable, just include it in the string builder
            if (_resourcePageQuerySqlProvider.IsBatchable)
            {
                batchSqlStringBuilder.AppendLine(template.RawSql);
            }
            else
            {
                // TODO: Simple API - Execute first round-trip query to obtain Ids for page (need to investigate Postgres arrays as possible way to avoid this completely)
                throw new NotImplementedException("Separate round-trip query to obtain Ids for paged resource results has not yet been implemented.");
                // Pseudo code: parameters = new DynamicParameters(ids);
            }
            
            // Build the remaining resource queries
            // TODO: Simple API - May need to also pass the "ids" array here as well (if batched, single-trip SQL isn't possible for Postgres)
            var resourceClassQueries = _resourceQueryBuilder.BuildQueries(resource, primaryKeyValues).ToList();

            // Add all the raw SQL for the queries to the batch SQL query
            foreach (var resourceClassQuery in resourceClassQueries)
            {
                batchSqlStringBuilder.Append(resourceClassQuery.Template.RawSql);
            }

            // TODO: Simple API - Establish database-specific connection
            using (var conn = new SqlConnection(_odsDatabaseConnectionStringProvider.GetConnectionString()))
            {
                await conn.OpenAsync();

                _logger.Debug($"SQL: {batchSqlStringBuilder}");

                string batchSql = batchSqlStringBuilder.ToString();
                
                var results = new List<ResourceClassQueryResults>();
                
                using (var multipleResults = await conn.QueryMultipleAsync(batchSql, parameters))
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
    }
}
