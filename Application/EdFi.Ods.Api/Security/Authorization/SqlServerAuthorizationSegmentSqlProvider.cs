// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Api.Security.Utilities;

namespace EdFi.Ods.Api.Security.Authorization
{
    public class SqlServerAuthorizationSegmentSqlProvider : AuthorizationSegmentSqlProviderBase
    {
        public SqlServerAuthorizationSegmentSqlProvider(IAuthorizationTablesAndViewsProvider authorizationTablesAndViewsProvider)
            : base(authorizationTablesAndViewsProvider)
        {
        }

        protected override DbParameter CreateParameter(
            string parameterName,
            AuthorizationSegmentEndpointWithValue segmentEndpoint)
        {
            return new SqlParameter
            {
                ParameterName = parameterName,
                Value = segmentEndpoint.Value
            };
        }

        protected override string BuildMultiValueCriteriaExpression(
            IList<AuthorizationSegmentEndpointWithValue> endpointsWithValues,
            IList<DbParameter> parameters,
            ref int parameterIndex)
        {
            DataTable edOrgIdTable = new DataTable("IntTable");
            edOrgIdTable.Columns.Add("Id", typeof(int));

            foreach (var endpointWithValue in endpointsWithValues)
            {
                edOrgIdTable.Rows.Add(endpointWithValue.Value);
            }

            string parameterName = "@p" + parameterIndex++;

            var edOrgIdsParameter = new SqlParameter
            {
                ParameterName = parameterName,
                SqlDbType = SqlDbType.Structured,
                TypeName = "dbo.IntTable",
                Value = edOrgIdTable
            };

            parameters.Add(edOrgIdsParameter);

            return $" IN (SELECT Id from {parameterName})";
        }
    }
}
