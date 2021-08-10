// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.ChangeQueries.Resources;
using EdFi.Ods.Generator.Database.NamingConventions;
using log4net;
using SqlKata;
using SqlKata.Execution;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems
{
    public class DeletedItemsResourceDataProvider : IDeletedItemsResourceDataProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(DeletedItemsResourceDataProvider));
        
        private readonly DbProviderFactory _dbProviderFactory;
        private readonly IOdsDatabaseConnectionStringProvider _odsDatabaseConnectionStringProvider;

        private readonly IDeletedItemsQueryMetadataProvider _deletedItemsQueryMetadataProvider;
        private readonly IDeletedItemsQueriesProvider _deletedItemsQueriesProvider;
        private readonly IDatabaseNamingConvention _namingConvention;

        public DeletedItemsResourceDataProvider(
            DbProviderFactory dbProviderFactory,
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            IDeletedItemsQueryMetadataProvider deletedItemsQueryMetadataProvider,
            IDeletedItemsQueriesProvider deletedItemsQueriesProvider,
            IDatabaseNamingConvention namingConvention)
        {
            _dbProviderFactory = dbProviderFactory;
            _odsDatabaseConnectionStringProvider = odsDatabaseConnectionStringProvider;
            _deletedItemsQueryMetadataProvider = deletedItemsQueryMetadataProvider;
            _deletedItemsQueriesProvider = deletedItemsQueriesProvider;
            _namingConvention = namingConvention;
        }

        public async Task<DeletedItemsResourceData> GetResourceDataAsync(Resource resource, IQueryParameters queryParameters)
        {
            using (var conn = _dbProviderFactory.CreateConnection())
            {
                conn.ConnectionString = _odsDatabaseConnectionStringProvider.GetConnectionString();
                await conn.OpenAsync();

                var queries = _deletedItemsQueriesProvider.GetQueries(conn, resource, queryParameters);

                var responseData = new DeletedItemsResourceData
                {
                    DeletedResources = await GetDataAsync(queries.DataQuery),
                    Count = await GetCountAsync(queries.CountQuery),
                };

                return responseData;
            }

            async Task<IReadOnlyList<DeletedResourceItem>> GetDataAsync(Query dataQuery)
            {
                if (dataQuery != null)
                {
                    // Execute query, casting to strong type to avoid use of dynamic
                    var deletedItems = (List<object>) await dataQuery.GetAsync();

                    var deletedResources = deletedItems
                        .Cast<IDictionary<string, object>>()
                        .Select(
                            deletedItem => new DeletedResourceItem
                            {
                                Id = (Guid)deletedItem[_namingConvention.ColumnName("Id")],
                                ChangeVersion =
                                    (long)deletedItem[_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)],
                                KeyValues =
                                    GetIdentifierKeyValues(
                                        _deletedItemsQueryMetadataProvider.GetIdentifierProjections(resource),
                                        deletedItem),
                            })
                        .ToList();

                    return deletedResources;
                }

                return null;
                
                Dictionary<string, object> GetIdentifierKeyValues(
                    QueryProjection[] identifierProjections, 
                    IDictionary<string, object> deletedItem)
                {
                    var keyValues = new Dictionary<string, object>();

                    foreach (var identifierMetadata in identifierProjections)
                    {
                        if (identifierMetadata.IsDescriptorUsage)
                        {
                            string namespaceColumn = identifierMetadata.SelectColumns.FirstOrDefault(c => c.ColumnAlias.EndsWithIgnoreCase("Namespace"))?.ColumnAlias;
                            string codeValueColumn = identifierMetadata.SelectColumns.FirstOrDefault(c => c.ColumnAlias.EndsWithIgnoreCase("CodeValue"))?.ColumnAlias;

                            if (namespaceColumn == null)
                            {
                                throw new Exception("Unable to find Namespace column in deleted item query results for building a descriptor URI.");
                            }
                    
                            if (codeValueColumn == null)
                            {
                                throw new Exception("Unable to find CodeValue column in deleted item query results for building a descriptor URI.");
                            }
                    
                            keyValues[identifierMetadata.JsonPropertyName] =
                                $"{deletedItem[namespaceColumn]}#{deletedItem[codeValueColumn]}";
                        }
                        else
                        {
                            foreach (var selectColumn in identifierMetadata.SelectColumns)
                            {
                                keyValues[selectColumn.JsonPropertyName] = deletedItem[selectColumn.ColumnAlias];
                            }
                        }
                    }

                    return keyValues;
                }
            }

            async Task<long?> GetCountAsync(Query countQuery)
            {
                if (queryParameters.TotalCount)
                {
                    var count = await countQuery.CountAsync<long>();
                    return Convert.ToInt64(count);
                }

                return null;
            }
        }
    }
}
