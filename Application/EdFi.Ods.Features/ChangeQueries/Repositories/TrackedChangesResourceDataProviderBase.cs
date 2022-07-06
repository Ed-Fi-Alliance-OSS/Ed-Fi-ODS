// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Models.Resource;
using log4net;

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    public abstract class TrackedChangesResourceDataProviderBase<TItem>
    {
        private readonly DbProviderFactory _dbProviderFactory;
        private readonly ITrackedChangesQueryTemplatePreparer _trackedChangesQueryTemplatePreparer;
        private readonly IOdsDatabaseConnectionStringProvider _odsDatabaseConnectionStringProvider;

        protected readonly string ChangeVersionColumnName;
        protected readonly string IdColumnName;

        private readonly ILog _logger;

        protected TrackedChangesResourceDataProviderBase(
            DbProviderFactory dbProviderFactory,
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            ITrackedChangesQueryTemplatePreparer trackedChangesQueryTemplatePreparer,
            IDatabaseNamingConvention namingConvention)
        {
            _dbProviderFactory = dbProviderFactory;
            _odsDatabaseConnectionStringProvider = odsDatabaseConnectionStringProvider;
            _trackedChangesQueryTemplatePreparer = trackedChangesQueryTemplatePreparer;

            ChangeVersionColumnName = namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName);
            IdColumnName = namingConvention.ColumnName("Id");

            _logger = LogManager.GetLogger(this.GetType());
        }

        protected async Task<ResourceData<TItem>> GetResourceDataAsync(
            Resource resource,
            IQueryParameters queryParameters,
            Func<IDictionary<string, object>, TItem> mapResponseItem)
        {
            await using var conn = _dbProviderFactory.CreateConnection();

            conn.ConnectionString = _odsDatabaseConnectionStringProvider.GetConnectionString();
            await conn.OpenAsync();

            var templates = _trackedChangesQueryTemplatePreparer.PrepareQueryTemplates(queryParameters, resource);

            var responseData = new ResourceData<TItem>()
            {
                Items = await GetDataAsync(templates.DataQueryTemplate),
                Count = await GetCountAsync(templates.CountQueryTemplate),
            };

            return responseData;

            async Task<IReadOnlyList<TItem>> GetDataAsync(SqlBuilder.Template dataQueryTemplate)
            {
                if (dataQueryTemplate != null && queryParameters.Limit is null or > 0)
                {
                    // Execute query, casting to strong type to avoid use of dynamic
                    string templateRawSql = dataQueryTemplate.RawSql;

                    if (_logger.IsDebugEnabled)
                    {
                        _logger.Debug($"Raw SQL: {templateRawSql}");
                    }
                    
                    var rawData = (List<object>) await conn.QueryAsync(templateRawSql, dataQueryTemplate.Parameters);

                    var items = rawData.Cast<IDictionary<string, object>>().Select(mapResponseItem).ToList();

                    return items;
                }

                return Enumerable.Empty<TItem>().ToList();
            }

            async Task<long?> GetCountAsync(SqlBuilder.Template countQueryTemplate)
            {
                if (queryParameters.TotalCount)
                {
                    var count = await conn.ExecuteScalarAsync(countQueryTemplate.RawSql, countQueryTemplate.Parameters);

                    return Convert.ToInt64(count);
                }

                return null;
            }
        }

        protected Dictionary<string, object> GetIdentifierKeyValues(
            QueryProjection[] identifierProjections,
            IDictionary<string, object> itemData,
            ColumnGroups columnGroup)
        {
            var keyValues = new Dictionary<string, object>();

            foreach (var identifierMetadata in identifierProjections)
            {
                if (identifierMetadata.IsDescriptorUsage)
                {
                    string namespaceColumn = identifierMetadata.SelectColumns.Where(c => c.ColumnGroup == columnGroup)
                        .FirstOrDefault(c => c.ColumnName.EndsWithIgnoreCase("Namespace"))
                        ?.ColumnName;

                    string codeValueColumn = identifierMetadata.SelectColumns.Where(c => c.ColumnGroup == columnGroup)
                        .FirstOrDefault(c => c.ColumnName.EndsWithIgnoreCase("CodeValue"))
                        ?.ColumnName;

                    if (namespaceColumn == null)
                    {
                        throw new Exception(
                            "Unable to find Namespace column in deleted item query results for building a descriptor URI.");
                    }

                    if (codeValueColumn == null)
                    {
                        throw new Exception(
                            "Unable to find CodeValue column in deleted item query results for building a descriptor URI.");
                    }

                    keyValues[identifierMetadata.JsonPropertyName] = $"{itemData[namespaceColumn]}#{itemData[codeValueColumn]}";
                }
                else
                {
                    foreach (var selectColumn in identifierMetadata.SelectColumns.Where(c => c.ColumnGroup == columnGroup))
                    {
                        keyValues[selectColumn.JsonPropertyName] = itemData[selectColumn.ColumnName];
                    }
                }
            }

            return keyValues;
        }
    }
}
