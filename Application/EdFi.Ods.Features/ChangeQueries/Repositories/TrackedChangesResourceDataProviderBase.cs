using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    public abstract class TrackedChangesResourceDataProviderBase<TItem>
    {
        private readonly DbProviderFactory _dbProviderFactory;
        private readonly IOdsDatabaseConnectionStringProvider _odsDatabaseConnectionStringProvider;
        private readonly ITrackedChangesQueriesPreparer _deletedItemsQueriesPreparer;
        private readonly IDatabaseNamingConvention _namingConvention;

        protected TrackedChangesResourceDataProviderBase(
            DbProviderFactory dbProviderFactory,
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            ITrackedChangesQueriesPreparer deletedItemsQueriesPreparer,
            IDatabaseNamingConvention namingConvention)
        {
            _dbProviderFactory = dbProviderFactory;
            _odsDatabaseConnectionStringProvider = odsDatabaseConnectionStringProvider;
            _deletedItemsQueriesPreparer = deletedItemsQueriesPreparer;
            _namingConvention = namingConvention;
        }

        protected async Task<ResourceData<TItem>> GetResourceDataAsync(Resource resource, IQueryParameters queryParameters, 
            Query templateQuery, Func<IDictionary<string, object>, TItem> createItem)
        {
            await using var conn = _dbProviderFactory.CreateConnection();

            conn.ConnectionString = _odsDatabaseConnectionStringProvider.GetConnectionString();
            await conn.OpenAsync();

            var queries = _deletedItemsQueriesPreparer.PrepareQueries(conn, templateQuery, queryParameters, resource);

            var responseData = new ResourceData<TItem>()
            {
                Items = await GetDataAsync(queries.MainQuery),
                Count = await GetCountAsync(queries.CountQuery),
            };

            return responseData;

            async Task<IReadOnlyList<TItem>> GetDataAsync(Query dataQuery)
            {
                if (dataQuery != null)
                {
                    // Execute query, casting to strong type to avoid use of dynamic
                    var rawData = (List<object>) await dataQuery.GetAsync();

                    var items = rawData
                        .Cast<IDictionary<string, object>>()
                        .Select(createItem)
                        .ToList();

                    return items;
                }

                return null;
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
                        $"{itemData[namespaceColumn]}#{itemData[codeValueColumn]}";
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