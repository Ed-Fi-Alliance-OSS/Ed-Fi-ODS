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
using EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems;
using EdFi.Ods.Features.ChangeQueries.Resources;
using EdFi.Ods.Generator.Database.NamingConventions;
using log4net;
using SqlKata;
using SqlKata.Execution;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges
{
    public class KeyChangesResourceDataProvider : IKeyChangesResourceDataProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(DeletedItemsResourceDataProvider));
        
        private readonly DbProviderFactory _dbProviderFactory;
        private readonly IOdsDatabaseConnectionStringProvider _odsDatabaseConnectionStringProvider;

        private readonly IKeyChangesTemplateQueryProvider _keyChangesTemplateQueryProvider;
        private readonly IKeyChangesQueriesProvider _keyChangesQueriesProvider;
        private readonly IDatabaseNamingConvention _namingConvention;

        public KeyChangesResourceDataProvider(
            DbProviderFactory dbProviderFactory,
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            IKeyChangesTemplateQueryProvider keyChangesTemplateQueryProvider,
            IKeyChangesQueriesProvider keyChangesQueriesProvider,
            IDatabaseNamingConvention namingConvention)
        {
            _dbProviderFactory = dbProviderFactory;
            _odsDatabaseConnectionStringProvider = odsDatabaseConnectionStringProvider;
            _keyChangesTemplateQueryProvider = keyChangesTemplateQueryProvider;
            _keyChangesQueriesProvider = keyChangesQueriesProvider;
            _namingConvention = namingConvention;
        }

        public async Task<KeyChangesResourceData> GetResourceDataAsync(Resource resource, IQueryParameters queryParameters)
        {
            using (var conn = _dbProviderFactory.CreateConnection())
            {
                conn.ConnectionString = _odsDatabaseConnectionStringProvider.GetConnectionString();
                await conn.OpenAsync();

                var queries = _keyChangesQueriesProvider.GetQueries(conn, resource, queryParameters);

                var responseData = new KeyChangesResourceData()
                {
                    KeyChanges = await GetDataAsync(queries.DataQuery),
                    Count = await GetCountAsync(queries.CountQuery),
                };

                return responseData;
            }

            async Task<IReadOnlyList<KeyChange>> GetDataAsync(Query dataQuery)
            {
                if (dataQuery != null)
                {
                    // Execute query, casting to strong type to avoid use of dynamic
                    var keyChangesRawData = (List<object>) await dataQuery.GetAsync();

                    var keyChanges = keyChangesRawData
                        .Cast<IDictionary<string, object>>()
                        .Select(
                            keyChange => new KeyChange()
                            {
                                Id = (Guid) keyChange[_namingConvention.ColumnName("Id")],
                                ChangeVersion =
                                    (long) keyChange[_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)],
                                OldKeyValues = 
                                    GetIdentifierKeyValues(
                                        _keyChangesTemplateQueryProvider.GetIdentifierProjections(resource),
                                        keyChange, 
                                        ColumnGroup.OldValue,
                                        ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix),
                                NewKeyValues = 
                                    GetIdentifierKeyValues(
                                        _keyChangesTemplateQueryProvider.GetIdentifierProjections(resource),
                                        keyChange, 
                                        ColumnGroup.NewValue,
                                        ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix),
                            })
                        .ToList();

                    return keyChanges;
                }

                return null;
                
                Dictionary<string, object> GetIdentifierKeyValues(
                    QueryProjection[] identifierProjections, 
                    IDictionary<string, object> keyChange,
                    ColumnGroup columnGroup,
                    string columnPrefix)
                {
                    var keyValues = new Dictionary<string, object>();

                    foreach (var identifierMetadata in identifierProjections)
                    {
                        if (identifierMetadata.IsDescriptorUsage)
                        {
                            string namespaceColumn = identifierMetadata.SelectColumns.Where(c => c.ColumnGroup == columnGroup).FirstOrDefault(c => c.ColumnName.EndsWithIgnoreCase("Namespace"))?.ColumnName;
                            string codeValueColumn = identifierMetadata.SelectColumns.Where(c => c.ColumnGroup == columnGroup).FirstOrDefault(c => c.ColumnName.EndsWithIgnoreCase("CodeValue"))?.ColumnName;

                            if (namespaceColumn == null)
                            {
                                throw new Exception("Unable to find Namespace column in deleted item query results for building a descriptor URI.");
                            }
                    
                            if (codeValueColumn == null)
                            {
                                throw new Exception("Unable to find CodeValue column in deleted item query results for building a descriptor URI.");
                            }
                    
                            keyValues[identifierMetadata.JsonPropertyName] =
                                $"{keyChange[namespaceColumn]}#{keyChange[codeValueColumn]}";
                        }
                        else
                        {
                            foreach (var selectColumn in identifierMetadata.SelectColumns.Where(c => c.ColumnGroup == columnGroup))
                            {
                                keyValues[selectColumn.JsonPropertyName] = keyChange[selectColumn.ColumnName];
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
