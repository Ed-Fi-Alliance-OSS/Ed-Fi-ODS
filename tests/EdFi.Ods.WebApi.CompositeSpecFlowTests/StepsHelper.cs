// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.WebApi.CompositeSpecFlowTests
{
    public static class StepsHelper
    {
        public static HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("IncludeNulls", new[] {"true"});
            client.Timeout = new TimeSpan(0, 0, 15, 0);

            // Set client's authorization header to an arbitrary value
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Guid.NewGuid().ToString());

            return client;
        }

        public static async Task<T> GetAsync<T>(string connectionString, string query, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using var conn = DbHelper.GetConnection(connectionString);

            conn.Open();
            return await conn.QuerySingleOrDefaultAsync<T>(query, cancellationToken);
        }

        public static string GetQueryString(string correlationId)
            => $"?{SpecialQueryStringParameters.CorrelationId}={correlationId}";

        public static async Task<Guid> GetResourceIdAsync(string connectionString, string tableName, object keyValues,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var valueByName = keyValues.ToDictionary();

            string whereClause = string.Join(
                " AND ", valueByName.Select(
                    kvp => kvp.Key + " = " + (kvp.Value is string
                        ? kvp.Value.ToString().SingleQuoted()
                        : kvp.Value)));


            var databaseEngine = DbHelper.GetDatabaseEngine();
            using var conn = DbHelper.GetConnection(databaseEngine, connectionString);

            conn.Open();

            string query = String.Empty;
            
            if (databaseEngine == DatabaseEngine.SqlServer)
            {
                query = $@"
                SELECT Id
                FROM  [edfi].[{tableName}]
                WHERE {whereClause}";
            }
            else
            {
                query = $@"
                SELECT Id
                FROM  edfi.""{tableName.ToLowerInvariant()}""
                WHERE {whereClause}";
            }
            

            return await conn.QuerySingleOrDefaultAsync<Guid>(query, cancellationToken);
        }
    }
}
